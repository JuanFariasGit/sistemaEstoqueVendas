Imports System.Data.SQLite
Public Class FormEntradas
    Private op As String
    Private Gl As New Globais
    Private Conn As New SQLiteConnection("Data Source=" & Gl.caminhoBanco.ToString())
    Private Comm As New SQLiteCommand(Conn)
    Private Sub FormEntradas_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        getFornecedores()
        getProdutos()
        getEntradas()
    End Sub
    Private Sub getFornecedores()
        Conn.Open()
        Comm.CommandText = "SELECT nome FROM Fornecedores"
        cbFornecedor.Items.Clear()
        Using Reader = Comm.ExecuteReader()
            While Reader.Read()
                cbFornecedor.Items.Add(Reader.Item("nome").ToString)
            End While
        End Using
        Conn.Close()
    End Sub
    Private Sub getProdutos()
        Conn.Open()
        Comm.CommandText = "SELECT produto FROM Produtos"
        cbProduto.Items.Clear()
        Using Reader = Comm.ExecuteReader()
            While Reader.Read()
                cbProduto.Items.Add(Reader.Item("produto").ToString)
            End While
        End Using
        Conn.Close()
    End Sub
    Private Sub getEntradas()
        DataGridView1.Rows.Clear()
        Conn.Open()
        Comm.CommandText = "SELECT registro, produto, quantidade, custo FROM Entradas"
        Using Reader = Comm.ExecuteReader()
            While Reader.Read()
                Dim subtotal = Reader.Item("quantidade") * Reader.Item("custo")
                DataGridView1.Rows.Add(Reader.Item("registro").ToString,
                                       Reader.Item("produto").ToString,
                                       Reader.Item("quantidade").ToString,
                                       Reader.Item("custo").ToString,
                                       "R$ " & Format(subtotal, "0.00"))
            End While
        End Using
        Conn.Close()
    End Sub
    Private Sub searchEntrada()
        Dim searchValue = tbPesquisar.Text.Trim()
        DataGridView1.Rows.Clear()
        Conn.Open()
        Comm.CommandText = "SELECT registro, produto, quantidade, custo FROM Entradas WHERE produto LIKE @searchValue"
        Comm.Parameters.AddWithValue("@searchValue", "%" & searchValue & "%")
        Using Reader = Comm.ExecuteReader()
            While Reader.Read()
                Dim subtotal = Convert.ToInt32(Reader.Item("quantidade")) * Convert.ToDouble(Reader.Item("custo"))
                DataGridView1.Rows.Add(Reader.Item("registro").ToString,
                                       Reader.Item("produto").ToString,
                                       Reader.Item("quantidade").ToString,
                                       Reader.Item("custo").ToString,
                                       "R$ " & Format(subtotal, "0.00"))
            End While
        End Using
        Conn.Close()
    End Sub
    Private Sub addEntrada()
        If mkDataCompra.Text.Length > 0 And cbFornecedor.Text.Length > 0 And cbProduto.Text.Length > 0 And tbQuandidade.Text.Length > 0 And tbCusto.Text.Length > 0 Then
            Dim dataCompra = mkDataCompra.Text.Trim
            Dim fornecedor = cbFornecedor.Text.Trim
            Dim produto = cbProduto.Text.Trim
            Dim dataVencimento = mkDataVencimento.Text.Trim
            Dim quantidade = tbQuandidade.Text.Trim
            Dim custo = tbCusto.Text.Trim
            Try
                Conn.Open()
                Comm.CommandText = "INSERT INTO Entradas VALUES (Null, @produto, @fornecedor, @dataCompra, @dataVencimento, @quantidade, @custo)"
                Comm.Parameters.AddWithValue("@dataCompra", dataCompra)
                Comm.Parameters.AddWithValue("@fornecedor", fornecedor)
                Comm.Parameters.AddWithValue("@produto", produto)
                Comm.Parameters.AddWithValue("@dataVencimento", dataVencimento)
                Comm.Parameters.AddWithValue("@quantidade", quantidade)
                Comm.Parameters.AddWithValue("@custo", Replace(custo, ",", "."))
                Comm.ExecuteNonQuery()
            Catch ex As Exception
                MessageBox.Show("Erro ao adicionar: " & ex.Message)
            Finally
                Conn.Close()
            End Try
            btnCancelar.Enabled = False
            btnSalvar.Enabled = False
            DataGridView1.Enabled = True
            clearFields()
            deactivateFields()
            activeButtons()
            getEntradas()
        Else
            MessageBox.Show("Preacha os campos obrigatórios (*)")
        End If
    End Sub
    Private Sub editEntrada()
        If mkDataCompra.Text.Length > 0 And cbFornecedor.Text.Length > 0 And cbProduto.Text.Length > 0 And tbQuandidade.Text.Length > 0 And tbCusto.Text.Length > 0 Then
            Dim dataCompra = mkDataCompra.Text.Trim
            Dim fornecedor = cbFornecedor.Text.Trim
            Dim produto = cbProduto.Text.Trim
            Dim dataVencimento = mkDataVencimento.Text.Trim
            Dim quantidade = tbQuandidade.Text.Trim
            Dim custo = tbCusto.Text.Trim
            Dim registro = tbRegistro.Text
            Try
                Conn.Open()
                Comm.CommandText = "UPDATE Entradas SET produto = @produto, 
                                    fornecedor = @fornecedor, 
                                    dataCompra = @dataCompra, 
                                    dataVencimento = @dataVencimento, 
                                    quantidade = @quantidade, 
                                    custo = @custo WHERE registro = @registro"
                Comm.Parameters.AddWithValue("@dataCompra", dataCompra)
                Comm.Parameters.AddWithValue("@fornecedor", fornecedor)
                Comm.Parameters.AddWithValue("@produto", produto)
                Comm.Parameters.AddWithValue("@dataVencimento", dataVencimento)
                Comm.Parameters.AddWithValue("@quantidade", quantidade)
                Comm.Parameters.AddWithValue("@custo", Replace(custo, ",", "."))
                Comm.Parameters.AddWithValue("@registro", registro)
                Comm.ExecuteNonQuery()
            Catch ex As Exception
                MessageBox.Show("Erro ao atualizar: " & ex.Message)
            Finally
                Conn.Close()
            End Try
            btnCancelar.Enabled = False
            btnSalvar.Enabled = False
            DataGridView1.Enabled = True
            clearFields()
            deactivateFields()
            activeButtons()
            getEntradas()
        Else
            MessageBox.Show("Preacha os campos obrigatórios (*)")
        End If
    End Sub
    Private Sub delEntrada()
        Dim dialog = MessageBox.Show("Deseja realmente excluir ?", "", MessageBoxButtons.YesNo)
        If dialog = DialogResult.Yes Then
            Dim registro = tbRegistro.Text
            Try
                Conn.Open()
                Comm.CommandText = "DELETE FROM Entradas WHERE registro = @registro"
                Comm.Parameters.AddWithValue("@registro", registro)
                Comm.ExecuteNonQuery()
            Catch ex As Exception
                MessageBox.Show("Erro ao excluir: " & ex.Message)
            Finally
                Conn.Close()
            End Try
            clearFields()
            getEntradas()
        End If
    End Sub
    Private Sub clearFields()
        tbRegistro.Clear()
        mkDataCompra.Clear()
        cbFornecedor.SelectedIndex = -1
        cbProduto.SelectedIndex = -1
        mkDataVencimento.Clear()
        tbQuandidade.Clear()
        tbCusto.Clear()
        mkDataCompra.Select()
    End Sub
    Private Sub activeFields()
        mkDataCompra.Enabled = True
        cbFornecedor.Enabled = True
        cbProduto.Enabled = True
        mkDataVencimento.Enabled = True
        tbQuandidade.Enabled = True
        mkDataCompra.Enabled = True
        tbCusto.Enabled = True
    End Sub
    Private Sub deactivateFields()
        mkDataCompra.Enabled = False
        cbFornecedor.Enabled = False
        cbProduto.Enabled = False
        mkDataVencimento.Enabled = False
        tbQuandidade.Enabled = False
        mkDataCompra.Enabled = False
        tbCusto.Enabled = False
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
            Comm.CommandText = "SELECT * FROM Entradas WHERE registro = @registro"
            Comm.Parameters.AddWithValue("@registro", registro)
            Using Reader = Comm.ExecuteReader()
                While Reader.Read()
                    tbRegistro.Text = Reader.Item("registro").ToString()
                    mkDataCompra.Text = Reader.Item("dataCompra").ToString()
                    cbFornecedor.Text = Reader.Item("fornecedor").ToString
                    cbProduto.Text = Reader.Item("produto").ToString
                    mkDataVencimento.Text = Reader.Item("dataVencimento").ToString
                    tbQuandidade.Text = Reader.Item("quantidade").ToString
                    tbCusto.Text = Reader.Item("custo").ToString
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
    End Sub
    Private Sub btnExcluir_Click(sender As Object, e As EventArgs) Handles btnExcluir.Click
        delEntrada()
    End Sub
    Private Sub btnEditar_Click(sender As Object, e As EventArgs) Handles btnEditar.Click
        op = "edit"
        btnSalvar.Enabled = True
        btnCancelar.Enabled = True
        activeFields()
        deactivateButtons()
    End Sub
    Private Sub btnAdicionar_Click(sender As Object, e As EventArgs) Handles btnAdicionar.Click
        op = "add"
        btnSalvar.Enabled = True
        btnCancelar.Enabled = True
        DataGridView1.Enabled = False
        activeFields()
        deactivateButtons()
        clearFields()
    End Sub
    Private Sub btnSalvar_Click(sender As Object, e As EventArgs) Handles btnSalvar.Click
        If op.Equals("add") Then
            addEntrada()
        ElseIf op.Equals("edit") Then
            editEntrada()
        End If
    End Sub
    Private Sub btnPesquisar_Click(sender As Object, e As EventArgs) Handles btnPesquisar.Click
        searchEntrada()
    End Sub
End Class