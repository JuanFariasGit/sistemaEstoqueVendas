Imports System.Data.SQLite
Public Class FormSaidas
    Private op As String = ""
    Private Gl As New Globais
    Private Conn As New SQLiteConnection("Data Source=" & Gl.caminhoBanco.ToString() + ";foreign_keys=true")
    Private Comm As New SQLiteCommand(Conn)
    Private Sub FormSaidas_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        getProdutos()
        getClientes()
        getSaidas()
    End Sub
    Private Sub getProdutos()
        Conn.Open()
        Comm.CommandText = "SELECT produto FROM Produtos"
        cbProduto.Items.Clear()
        cbProdutoPesquisar.Items.Clear()
        Using Reader = Comm.ExecuteReader()
            While Reader.Read()
                cbProduto.Items.Add(Reader.Item("produto").ToString)
                cbProdutoPesquisar.Items.Add(Reader.Item("produto").ToString)
            End While
        End Using
        Conn.Close()
    End Sub
    Private Sub getClientes()
        Conn.Open()
        Comm.CommandText = "SELECT nome FROM Clientes"
        cbCliente.Items.Clear()
        Using Reader = Comm.ExecuteReader()
            While Reader.Read()
                cbCliente.Items.Add(Reader.Item("nome").ToString)
            End While
        End Using
        Conn.Close()
    End Sub
    Private Sub getSaidas()
        DataGridView1.Rows.Clear()
        Conn.Open()
        Comm.CommandText = "SELECT registro, produto, quantidade, preco FROM Saidas"
        Using Reader = Comm.ExecuteReader()
            While Reader.Read()
                Dim subtotal = Reader.Item("quantidade") * Reader.Item("preco")
                DataGridView1.Rows.Add(Reader.Item("registro").ToString,
                                       Reader.Item("produto").ToString,
                                       Reader.Item("quantidade").ToString,
                                       "R$ " & Format(Reader.Item("preco"), "0.00"),
                                       "R$ " & Format(subtotal, "0.00"))
            End While
        End Using
        Conn.Close()
    End Sub
    Private Sub searchEntrada()
        Dim searchValue = cbProdutoPesquisar.Text
        DataGridView1.Rows.Clear()
        Conn.Open()
        Comm.CommandText = "SELECT registro, produto, quantidade, preco FROM Saidas WHERE produto LIKE @searchValue"
        Comm.Parameters.AddWithValue("@searchValue", "%" & searchValue & "%")
        Using Reader = Comm.ExecuteReader()
            While Reader.Read()
                Dim subtotal = Reader.Item("quantidade") * Reader.Item("preco")
                DataGridView1.Rows.Add(Reader.Item("registro").ToString,
                                       Reader.Item("produto").ToString,
                                       Reader.Item("quantidade").ToString,
                                       "R$ " & Format(Reader.Item("preco"), "0.00"),
                                       "R$ " & Format(subtotal, "0.00"))
            End While
        End Using
        Conn.Close()
    End Sub
    Private Sub addSaida()
        If mkDataVenda.Text.Length.Equals(10) And cbCliente.Text.Length > 0 And cbProduto.Text.Length > 0 And tbQuandidade.Text.Length > 0 And tbPreco.Text.Length > 0 Then
            Dim dataVenda = String.Join("-", mkDataVenda.Text.Split("/").Reverse())
            Dim cliente = cbCliente.Text
            Dim produto = cbProduto.Text
            Dim quantidade = tbQuandidade.Text.Trim
            Dim preco = tbPreco.Text.Trim
            Dim estoqueAtual = tbEstoqueAtual.Text

            If (CType(quantidade, Integer) <= CType(estoqueAtual, Integer)) Then
                Try
                    Conn.Open()
                    Comm.CommandText = "INSERT INTO Saidas VALUES (Null, @produto, @cliente, @dataVenda, @quantidade, @preco)"
                    Comm.Parameters.AddWithValue("@dataVenda", dataVenda)
                    Comm.Parameters.AddWithValue("@cliente", cliente)
                    Comm.Parameters.AddWithValue("@produto", produto)
                    Comm.Parameters.AddWithValue("@quantidade", quantidade)
                    Comm.Parameters.AddWithValue("@preco", Replace(preco, ",", "."))
                    Comm.ExecuteNonQuery()
                Catch ex As Exception
                    MessageBox.Show("Erro ao adicionar: " & ex.Message, "", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Finally
                    Conn.Close()
                End Try
                btnCancelar.Enabled = False
                btnSalvar.Enabled = False
                DataGridView1.Enabled = True
                clearFields()
                deactivateFields()
                activeButtons()
                getSaidas()
                op = ""
            Else
                MessageBox.Show("Quantidade escolhida deve ser igual ou menor do que o estoque atual", "", MessageBoxButtons.OK, MessageBoxIcon.Information)
            End If
        Else
            MessageBox.Show("Preencha os campos obrigatórios (*)", "", MessageBoxButtons.OK, MessageBoxIcon.Information)
        End If
    End Sub
    Private Sub editSaida()
        If mkDataVenda.Text.Length.Equals(10) And cbCliente.Text.Length > 0 And cbProduto.Text.Length > 0 And tbQuandidade.Text.Length > 0 And tbPreco.Text.Length > 0 Then
            Dim dataVenda = String.Join("-", mkDataVenda.Text.Split("/").Reverse())
            Dim cliente = cbCliente.Text
            Dim produto = cbProduto.Text
            Dim quantidade = tbQuandidade.Text.Trim
            Dim preco = tbPreco.Text.Trim
            Dim estoqueAtual = tbEstoqueAtual.Text
            If (CType(quantidade, Integer) <= CType(estoqueAtual, Integer)) Then
                Try
                    Conn.Open()
                    Comm.CommandText = "UPDATE Entradas SET produto = @produto, 
                                    fornecedor = @fornecedor, 
                                    dataCompra = @dataCompra, 
                                    dataVencimento = @dataVencimento, 
                                    quantidade = @quantidade, 
                                    custo = @custo WHERE registro = @registro"
                    Comm.Parameters.AddWithValue("@dataVenda", dataVenda)
                    Comm.Parameters.AddWithValue("@cliente", cliente)
                    Comm.Parameters.AddWithValue("@produto", produto)
                    Comm.Parameters.AddWithValue("@quantidade", quantidade)
                    Comm.Parameters.AddWithValue("@preco", Replace(preco, ",", "."))
                    Comm.ExecuteNonQuery()
                Catch ex As Exception
                    MessageBox.Show("Erro ao atualizar: " & ex.Message, "", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Finally
                    Conn.Close()
                End Try
                btnCancelar.Enabled = False
                btnSalvar.Enabled = False
                DataGridView1.Enabled = True
                clearFields()
                deactivateFields()
                activeButtons()
                getSaidas()
                op = ""
            Else
                MessageBox.Show("Quantidade escolhida deve ser igual ou menor do que o estoque atual", "", MessageBoxButtons.OK, MessageBoxIcon.Information)
            End If
        Else
            MessageBox.Show("Preencha os campos obrigatórios (*)", "", MessageBoxButtons.OK, MessageBoxIcon.Information)
        End If
    End Sub
    Private Sub delSaida()
        Dim dialog = MessageBox.Show("Deseja realmente excluir", "", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
        If dialog = DialogResult.Yes Then
            Dim registro = tbRegistro.Text
            Try
                Conn.Open()
                Comm.CommandText = "DELETE FROM Saidas WHERE registro = @registro"
                Comm.Parameters.AddWithValue("@registro", registro)
                Comm.ExecuteNonQuery()
            Catch ex As Exception
                MessageBox.Show("Erro ao excluir: " & ex.Message)
            Finally
                Conn.Close()
            End Try
            clearFields()
            getSaidas()
        End If
    End Sub
    Private Sub clearFields()
        tbRegistro.Clear()
        mkDataVenda.Clear()
        cbCliente.SelectedIndex = -1
        cbProduto.SelectedIndex = -1
        tbQuandidade.Clear()
        tbPreco.Clear()
    End Sub
    Private Sub activeFields()
        mkDataVenda.Enabled = True
        cbCliente.Enabled = True
        cbProduto.Enabled = True
        tbQuandidade.Enabled = True
        mkDataVenda.Enabled = True
        tbPreco.Enabled = True
        tbEstoqueAtual.Visible = True
        mkDataVenda.Focus()
    End Sub
    Private Sub deactivateFields()
        mkDataVenda.Enabled = False
        cbCliente.Enabled = False
        cbProduto.Enabled = False
        tbQuandidade.Enabled = False
        tbPreco.Enabled = False
    End Sub
    Private Sub activeButtons()
        btnAdicionar.Enabled = True
        btnEditar.Enabled = True
        btnExcluir.Enabled = True
    End Sub
    Private Sub deactivateButtons()
        btnAdicionar.Enabled = False
        btnEditar.Enabled = False
        btnExcluir.Enabled = False
    End Sub
    Private Sub DataGridView1_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView1.CellClick
        If e.RowIndex <> -1 Then
            Dim selectedRow = DataGridView1.Rows(e.RowIndex)
            Dim registro = selectedRow.Cells("registro").Value
            Conn.Open()
            Comm.CommandText = "SELECT * FROM Saidas WHERE registro = @registro"
            Comm.Parameters.AddWithValue("@registro", registro)
            Using Reader = Comm.ExecuteReader()
                While Reader.Read()
                    Dim dataVenda = String.Join("/", Reader.Item("dataVenda").ToString.Split("-").Reverse())
                    tbRegistro.Text = Reader.Item("registro").ToString()
                    mkDataVenda.Text = dataVenda
                    cbCliente.Text = Reader.Item("cliente").ToString
                    cbProduto.Text = Reader.Item("produto").ToString
                    tbQuandidade.Text = Reader.Item("quantidade").ToString
                    tbPreco.Text = Format(Reader.Item("preco"), "0.00")
                End While
            End Using
            Conn.Close()
        End If
    End Sub
    Private Sub btnCancelar_Click(sender As Object, e As EventArgs) Handles btnCancelar.Click
        btnCancelar.Enabled = False
        btnSalvar.Enabled = False
        DataGridView1.Enabled = True
        clearFields()
        deactivateFields()
        activeButtons()
        getSaidas()
        op = ""
    End Sub
    Private Sub btnExcluir_Click(sender As Object, e As EventArgs) Handles btnExcluir.Click
        If tbRegistro.Text.Length > 0 Then
            delSaida()
        Else
            MessageBox.Show("Selecione uma saída para excluir", "", MessageBoxButtons.OK, MessageBoxIcon.Information)
        End If
    End Sub
    Private Sub btnEditar_Click(sender As Object, e As EventArgs) Handles btnEditar.Click
        If tbRegistro.Text.Length > 0 Then
            op = "edit"
            btnSalvar.Enabled = True
            btnCancelar.Enabled = True
            getEstoqueAtual()
            activeFields()
            deactivateButtons()
        Else
            MessageBox.Show("Selecione uma saída para editar", "", MessageBoxButtons.OK, MessageBoxIcon.Information)
        End If
    End Sub
    Private Sub btnAdicionar_Click(sender As Object, e As EventArgs) Handles btnAdicionar.Click
        op = "add"
        btnSalvar.Enabled = True
        btnCancelar.Enabled = True
        DataGridView1.Enabled = False
        clearFields()
        activeFields()
        deactivateButtons()
    End Sub
    Private Sub btnSalvar_Click(sender As Object, e As EventArgs) Handles btnSalvar.Click
        If op.Equals("add") Then
            addSaida()
        ElseIf op.Equals("edit") Then
            editSaida()
        End If
    End Sub
    Private Sub btnPesquisar_Click(sender As Object, e As EventArgs) Handles btnPesquisar.Click
        searchEntrada()
    End Sub
    Private Function quantidadeProdutoEntrada(produto As String)
        Conn.Open()
        Comm.CommandText = "SELECT SUM(quantidade) AS qt_entrada FROM Entradas WHERE produto = @produto;"
        Comm.Parameters.AddWithValue("@produto", produto)
        Dim qt_entrada As Integer
        Using Reader = Comm.ExecuteReader()
            While Reader.Read()
                If Not DBNull.Value.Equals(Reader.Item("qt_entrada")) Then
                    qt_entrada = Reader.Item("qt_entrada")
                Else
                    qt_entrada = 0
                End If
            End While
        End Using
        Conn.Close()
        Return qt_entrada
    End Function
    Private Function quantidadeProdutoSaida(produto As String)
        Conn.Open()
        Comm.CommandText = "SELECT SUM(quantidade) AS qt_saida FROM Saidas WHERE produto = @produto;"
        Comm.Parameters.AddWithValue("@produto", produto)
        Dim qt_saida As Integer
        Using Reader = Comm.ExecuteReader()
            While Reader.Read()
                If Not DBNull.Value.Equals(Reader.Item("qt_saida")) Then
                    qt_saida = Reader.Item("qt_saida")
                Else
                    qt_saida = 0
                End If
            End While
        End Using
        Conn.Close()
        Return qt_saida
    End Function
    Private Sub getEstoqueAtual()
        Dim selectedItem = cbProduto.SelectedItem
        If Not String.IsNullOrEmpty(selectedItem) And Not op.Equals("") Then
            Dim qt_entrada = quantidadeProdutoEntrada(selectedItem)
            Dim qt_saida = quantidadeProdutoSaida(selectedItem)
            If op.Equals("add") Then
                tbEstoqueAtual.Text = qt_entrada - qt_saida
            ElseIf op.Equals("edit") Then
                tbEstoqueAtual.Text = CType(tbQuandidade.Text, Integer) + qt_entrada - qt_saida
            End If
        Else
            tbEstoqueAtual.Text = ""
        End If
    End Sub
    Private Sub cbProduto_KeyUp(sender As Object, e As KeyEventArgs) Handles cbProduto.KeyUp
        getEstoqueAtual()
    End Sub
    Private Sub cbProduto_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cbProduto.SelectedIndexChanged
        getEstoqueAtual()
    End Sub
End Class