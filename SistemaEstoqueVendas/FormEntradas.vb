Imports System.Data.SQLite
Public Class FormEntradas
    Private op As String
    Private Gl As New Globais
    Private Conn As New SQLiteConnection("Data Source=" & Gl.caminhoBanco.ToString())
    Private Comm As New SQLiteCommand(Conn)
    Private Sub FormEntradas_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        getFornecedores()
        getProdutos()
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
    Private Sub addEntrada()
        If mkDataCompra.Text.Length > 0 And cbFornecedor.Text.Length > 0 And cbProduto.Text.Length > 0 And tbQuandidade.Text.Length > 0 And tbPreco.Text.Length > 0 Then
            Dim dataCompra = mkDataCompra.Text.Trim
            Dim fornecedor = cbFornecedor.Text.Trim
            Dim produto = cbProduto.Text.Trim
            Dim dataVencimento = mkDataVencimento.Text.Trim
            Dim quantidade = tbQuandidade.Text.Trim
            Dim preco = tbPreco.Text.Trim
            Try
                Conn.Open()
                Comm.CommandText = "INSERT INTO Entradas VALUES (Null, @dataCompra, @fornecedor, @produto, @dataVencimento, @quantidade, @preco)"
                Comm.Parameters.AddWithValue("@dataCompra", dataCompra)
                Comm.Parameters.AddWithValue("@fornecedor", fornecedor)
                Comm.Parameters.AddWithValue("@produto", produto)
                Comm.Parameters.AddWithValue("@dataVencimento", dataVencimento)
                Comm.Parameters.AddWithValue("@quantidade", quantidade)
                Comm.Parameters.AddWithValue("@preco", preco)
                Comm.ExecuteNonQuery()
            Catch ex As Exception
                MessageBox.Show("Erro ao adicionar: " & ex.Message)
            End Try
        End If
    End Sub
    Private Sub clearFields()
        tbRegistro.Clear()
        mkDataCompra.Clear()
        cbFornecedor.SelectedIndex = -1
        cbProduto.SelectedIndex = -1
        mkDataVencimento.Clear()
        tbQuandidade.Clear()
        tbPreco.Clear()
        mkDataCompra.Select()
    End Sub
    Private Sub activeFields()
        mkDataCompra.Enabled = True
        cbFornecedor.Enabled = True
        cbProduto.Enabled = True
        mkDataVencimento.Enabled = True
        tbQuandidade.Enabled = True
        mkDataCompra.Enabled = True
        tbPreco.Enabled = True
    End Sub
    Private Sub deactivateFields()
        mkDataCompra.Enabled = False
        cbFornecedor.Enabled = False
        cbProduto.Enabled = False
        mkDataVencimento.Enabled = False
        tbQuandidade.Enabled = False
        mkDataCompra.Enabled = False
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
                    tbPreco.Text = Reader.Item("preco").ToString
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
        End If
    End Sub
End Class