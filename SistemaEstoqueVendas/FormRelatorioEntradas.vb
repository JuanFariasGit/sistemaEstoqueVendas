Imports System.Data.SQLite
Public Class FormRelatorioEntradas
    Private Gl As New Globais
    Private Conn As New SQLiteConnection("Data Source=" & Gl.caminhoBanco.ToString())
    Private Comm As New SQLiteCommand(Conn)
    Private Sub getRegistrosCompras()
        Dim dataInicio = String.Join("-", mkDataInicio.Text.Split("/").Reverse())
        Dim dataFinal = String.Join("-", mkDataFinal.Text.Split("/").Reverse())
        Conn.Open()
        Comm.CommandText = "SELECT COUNT(registro) AS c FROM Entradas WHERE dataCompra >= @dataInicio AND dataCompra <= @dataFinal"
        Comm.Parameters.AddWithValue("@dataInicio", dataInicio)
        Comm.Parameters.AddWithValue("@dataFinal", dataFinal)
        Using Reader = Comm.ExecuteReader()
            While Reader.Read()
                lRegistrosCompras.Text = Reader.Item("c")
            End While
        End Using
        Conn.Close()
    End Sub
    Private Sub getTotalEmComprasPeriodo()
        Dim dataInicio = String.Join("-", mkDataInicio.Text.Split("/").Reverse())
        Dim dataFinal = String.Join("-", mkDataFinal.Text.Split("/").Reverse())
        Conn.Open()
        Comm.CommandText = "SELECT SUM(quantidade * custo) AS total FROM Entradas WHERE dataCompra >= @dataInicio AND dataCompra <= @dataFinal"
        Comm.Parameters.AddWithValue("@dataInicio", dataInicio)
        Comm.Parameters.AddWithValue("@dataFinal", dataFinal)
        Using Reader = Comm.ExecuteReader()
            While Reader.Read()
                If Not DBNull.Value.Equals(Reader.Item("total")) Then
                    lTotalComprasPeriodo.Text = "R$" & Format(Reader.Item("total"), "0.00")
                Else
                    lTotalComprasPeriodo.Text = "R$ 0.00"
                End If
            End While
        End Using
        Conn.Close()
    End Sub
    Private Sub getEntradas()
        ListView1.Items.Clear()
        Dim dataInicio = String.Join("-", mkDataInicio.Text.Split("/").Reverse())
        Dim dataFinal = String.Join("-", mkDataFinal.Text.Split("/").Reverse())
        Conn.Open()
        Comm.CommandText = "SELECT * FROM Entradas WHERE dataCompra >= @dataInicio AND dataCompra <= @dataFinal"
        Comm.Parameters.AddWithValue("@fornecedor", fornecedor)
        Comm.Parameters.AddWithValue("@produto", produto)
        Using Reader = Comm.ExecuteReader()
            While Reader.Read()
                Dim subtotal = Reader.Item("quantidade") * Reader.Item("custo")
                Dim dataCompra = String.Join("/", Reader.Item("dataCompra").ToString.Split("-").Reverse())
                Dim dataVencimento = String.Join("/", Reader.Item("dataVencimento").ToString.Split("-").Reverse())
                Dim items(8) As String

                items(0) = Reader.Item("registro").ToString
                items(1) = dataCompra
                items(2) = Reader.Item("fornecedor").ToString
                items(3) = Reader.Item("produto").ToString
                items(4) = dataVencimento
                items(5) = Reader.Item("quantidade").ToString
                items(6) = Reader.Item("custo").ToString
                items(7) = "R$ " & Format(subtotal, "0.00")

                Dim l As New ListViewItem(items)
                ListView1.Items.Add(l)
            End While
        End Using
        Conn.Close()
    End Sub
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        getRegistrosCompras()
        getTotalEmComprasPeriodo()
        getEntradas()
    End Sub
End Class