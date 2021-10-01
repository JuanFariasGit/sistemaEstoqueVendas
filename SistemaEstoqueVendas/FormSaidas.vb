Imports System.Data.SQLite
Public Class FormSaidas
    Private op As String
    Private Gl As New Globais
    Private Conn As New SQLiteConnection("Data Source=" & Gl.caminhoBanco.ToString())
    Private Comm As New SQLiteCommand(Conn)
    Private Sub FormSaidas_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        getProdutos()
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
        If Not String.IsNullOrEmpty(selectedItem) Then
            Dim qt_entrada = quantidadeProdutoEntrada(selectedItem)
            Dim qt_saida = quantidadeProdutoSaida(selectedItem)
            tbEstoqueAtual.Text = qt_entrada - qt_saida
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
End Class