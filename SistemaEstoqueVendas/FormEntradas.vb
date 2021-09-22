Imports System.Data.SQLite
Public Class FormEntradas
    Private Gl As New Globais
    Private Conn As New SQLiteConnection("Data Source=" & Gl.caminhoBanco.ToString())
    Private Comm As New SQLiteCommand(Conn)
    Private Sub FormEntradas_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Conn.Open()
        Comm.CommandText = "SELECT registro, codigo, produto FROM Produtos"
        ComboBox1.Items.Clear()
        Using Reader = Comm.ExecuteReader()
            While Reader.Read()
                ComboBox1.Items.Add(Reader.Item("registro").ToString)
            End While
        End Using
        Conn.Close()
    End Sub
End Class