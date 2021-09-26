Imports System.Data.SQLite
Public Class FormProdutos
    Private op As String
    Private Gl As New Globais
    Private Conn As New SQLiteConnection("Data Source=" & Gl.caminhoBanco.ToString())
    Private Comm As New SQLiteCommand(Conn)
    Private Sub FormProdutos_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        getProdutos()
    End Sub
    Private Sub getProdutos()
        DataGridView1.Rows.Clear()
        Conn.Open()
        Comm.CommandText = "SELECT registro, codigo, produto FROM Produtos"
        Using Reader = Comm.ExecuteReader()
            While Reader.Read()
                DataGridView1.Rows.Add(Reader.Item("registro").ToString,
                                               Reader.Item("codigo").ToString,
                                               Reader.Item("produto").ToString)
            End While
        End Using
        Conn.Close()
    End Sub
    Private Sub searchProduto()
        Dim searchValue = tbPesquisar.Text.Trim()
        DataGridView1.Rows.Clear()
        Conn.Open()
        Comm.CommandText = "SELECT registro, codigo, produto FROM Produtos WHERE codigo LIKE @searchValue OR produto LIKE @searchValue"
        Comm.Parameters.AddWithValue("@searchValue", "%" & searchValue & "%")
        Using Reader = Comm.ExecuteReader()
            While Reader.Read()
                DataGridView1.Rows.Add(Reader.Item("registro").ToString,
                                               Reader.Item("codigo").ToString,
                                               Reader.Item("produto").ToString)
            End While
        End Using
        Conn.Close()
    End Sub
    Private Sub addProduto()
        If tbCodigo.Text.Length > 0 And tbProduto.Text.Length > 0 And tbEstoqueMinimo.Text.Length > 0 And tbEstoqueMaximo.Text.Length > 0 Then
            Dim codigo = tbCodigo.Text.Trim
            Dim produto = tbProduto.Text.Trim
            Dim unidadeMedida = tbUnidadeMedida.Text.Trim
            Dim estoqueMinimo = tbEstoqueMinimo.Text.Trim
            Dim estoqueMaximo = tbEstoqueMaximo.Text.Trim
            Try
                Conn.Open()
                Comm.CommandText = "INSERT INTO Produtos VALUES (Null, @codigo, @produto, @unidadeMedida, @estoqueMinimo, @estoqueMaximo)"
                Comm.Parameters.AddWithValue("@codigo", codigo)
                Comm.Parameters.AddWithValue("@produto", produto)
                Comm.Parameters.AddWithValue("@unidadeMedida", unidadeMedida)
                Comm.Parameters.AddWithValue("@estoqueMinimo", estoqueMinimo)
                Comm.Parameters.AddWithValue("@estoqueMaximo", estoqueMaximo)
                Comm.ExecuteNonQuery()
            Catch ex As Exception
                Dim mesagem = ex.Message
                If mesagem.EndsWith("Produtos.produto") Then
                    MessageBox.Show("Já existe um produto com esse Nome")
                ElseIf mesagem.EndsWith("Produtos.codigo") Then
                    MessageBox.Show("Já existe um produto com esse Código")
                Else
                    MessageBox.Show("Erro ao adicionar: " & ex.Message)
                End If
            Finally
                Conn.Close()
            End Try
            op = ""
            btnSalvar.Enabled = False
            btnCancelar.Enabled = False
            DataGridView1.Enabled = True
            deactivateFields()
            clearFields()
            activeButtons()
            getProdutos()
        Else
            MessageBox.Show("Preacha os campos obrigatórios (*)")
        End If
    End Sub
    Private Sub aditProduto()
        If tbCodigo.Text.Length > 0 And tbProduto.Text.Length > 0 And tbEstoqueMinimo.Text.Length > 0 And tbEstoqueMaximo.Text.Length > 0 Then
            Dim codigo = tbCodigo.Text.Trim
            Dim produto = tbProduto.Text.Trim
            Dim unidadeMedida = tbUnidadeMedida.Text.Trim
            Dim estoqueMinimo = tbEstoqueMinimo.Text.Trim
            Dim estoqueMaximo = tbEstoqueMaximo.Text.Trim
            Dim registro = tbRegistro.Text
            Try
                Conn.Open()
                Comm.CommandText = "UPDATE Produtos Set codigo = @codigo, 
                                            produto = @produto, 
                                            unidadeMedida = @unidadeMedida, 
                                            estoqueMinimo = @estoqueMinimo, 
                                            estoqueMaximo = @estoqueMaximo WHERE registro = @registro"
                Comm.Parameters.AddWithValue("@codigo", codigo)
                Comm.Parameters.AddWithValue("@produto", produto)
                Comm.Parameters.AddWithValue("@unidadeMedida", unidadeMedida)
                Comm.Parameters.AddWithValue("@estoqueMinimo", estoqueMinimo)
                Comm.Parameters.AddWithValue("@estoqueMaximo", estoqueMaximo)
                Comm.Parameters.AddWithValue("@registro", registro)
                Comm.ExecuteNonQuery()
            Catch ex As Exception
                Dim mesagem = ex.Message
                If mesagem.EndsWith("Produtos.produto") Then
                    MessageBox.Show("Já existe um produto com esse Nome")
                ElseIf mesagem.EndsWith("Produtos.codigo") Then
                    MessageBox.Show("Já existe um produto com esse Código")
                Else
                    MessageBox.Show("Erro ao atualizar: " & ex.Message)
                End If
            Finally
                Conn.Close()
            End Try
            op = ""
            btnSalvar.Enabled = False
            btnCancelar.Enabled = False
            deactivateFields()
            clearFields()
            activeButtons()
            getProdutos()
        Else
            MessageBox.Show("Preacha os campos obrigatórios (*)")
        End If
    End Sub
    Private Sub delProduto()
        Dim dialog = MessageBox.Show("Deseja realmente excluir ?", "", MessageBoxButtons.YesNo)
        If dialog = DialogResult.Yes Then
            Dim registro = tbRegistro.Text
            Try
                Conn.Open()
                Comm.CommandText = "DELETE FROM Produtos WHERE registro = @registro"
                Comm.Parameters.AddWithValue("@registro", registro)
                Comm.ExecuteNonQuery()
            Catch ex As Exception
                MessageBox.Show("Erro ao excluir: " & ex.Message)
            Finally
                Conn.Close()
            End Try
            clearFields()
            getProdutos()
        End If
    End Sub
    Private Sub clearFields()
        tbRegistro.Clear()
        tbCodigo.Clear()
        tbProduto.Clear()
        tbUnidadeMedida.Clear()
        tbEstoqueMinimo.Clear()
        tbEstoqueMaximo.Clear()
    End Sub
    Private Sub activeFields()
        tbCodigo.Enabled = True
        tbProduto.Enabled = True
        tbUnidadeMedida.Enabled = True
        tbEstoqueMinimo.Enabled = True
        tbEstoqueMaximo.Enabled = True
        tbCodigo.Focus()
    End Sub
    Private Sub deactivateFields()
        tbCodigo.Enabled = False
        tbProduto.Enabled = False
        tbUnidadeMedida.Enabled = False
        tbEstoqueMinimo.Enabled = False
        tbEstoqueMaximo.Enabled = False
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
            Comm.CommandText = "SELECT * FROM Produtos WHERE registro = @registro"
            Comm.Parameters.AddWithValue("@registro", registro)
            Using Reader = Comm.ExecuteReader()
                While Reader.Read()
                    tbRegistro.Text = Reader.Item("registro").ToString()
                    tbCodigo.Text = Reader.Item("codigo").ToString()
                    tbProduto.Text = Reader.Item("produto").ToString
                    tbUnidadeMedida.Text = Reader.Item("unidadeMedida").ToString
                    tbEstoqueMinimo.Text = Reader.Item("estoqueMinimo").ToString
                    tbEstoqueMaximo.Text = Reader.Item("estoqueMaximo").ToString
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
        getProdutos()
    End Sub
    Private Sub btnExcluir_Click(sender As Object, e As EventArgs) Handles btnExcluir.Click
        If tbRegistro.Text.Length > 0 Then
            delProduto()
        Else
            MessageBox.Show("Selecione um produto para excluir")
        End If
    End Sub
    Private Sub btnEditar_Click(sender As Object, e As EventArgs) Handles btnEditar.Click
        If tbRegistro.Text.Length > 0 Then
            op = "edit"
            btnSalvar.Enabled = True
            btnCancelar.Enabled = True
            activeFields()
            deactivateButtons()
        Else
            MessageBox.Show("Selecione um produto para editar")
        End If
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
            addProduto()
        ElseIf op.Equals("edit") Then
            aditProduto()
        End If
    End Sub
    Private Sub btnPesquisar_Click(sender As Object, e As EventArgs) Handles btnPesquisar.Click
        searchProduto()
    End Sub
End Class