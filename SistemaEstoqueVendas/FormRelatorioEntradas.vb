Imports System.Data.SQLite
Imports iTextSharp
Imports iTextSharp.text
Imports iTextSharp.text.pdf
Imports System.IO
Imports System
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
        Comm.CommandText = "SELECT p.codigo, f.identificador, e.fornecedor, e.produto, e.dataCompra, e.dataVencimento , e.quantidade, e.custo FROM Entradas e 
                            INNER JOIN Produtos p ON p.produto = e.produto INNER JOIN Fornecedores f ON e.fornecedor = f.nome WHERE e.dataCompra >= @dataInicio AND e.dataCompra <= @dataFinal"
        Comm.Parameters.AddWithValue("@dataInicio", dataInicio)
        Comm.Parameters.AddWithValue("@dataFinal", dataFinal)
        Using Reader = Comm.ExecuteReader()
            While Reader.Read()
                Dim total = Reader.Item("quantidade") * Reader.Item("custo")
                Dim dataCompra = String.Join("/", Reader.Item("dataCompra").ToString.Split("-").Reverse())
                Dim dataVencimento = String.Join("/", Reader.Item("dataVencimento").ToString.Split("-").Reverse())
                Dim items(8) As String

                items(0) = dataCompra
                items(1) = Reader.Item("codigo").ToString
                items(2) = Reader.Item("produto").ToString
                items(3) = dataVencimento
                items(4) = Reader.Item("quantidade").ToString
                items(5) = "R$ " & Reader.Item("custo").ToString
                items(6) = "R$ " & Format(total, "0.00")
                items(7) = Reader.Item("fornecedor").ToString
                items(8) = Reader.Item("identificador").ToString

                Dim l As New ListViewItem(items)
                ListView1.Items.Add(l)
            End While
        End Using
        Conn.Close()
    End Sub
    Private Sub btPesquisar_Click(sender As Object, e As EventArgs) Handles btPesquisar.Click
        getRegistrosCompras()
        getTotalEmComprasPeriodo()
        getEntradas()
    End Sub
    Private Sub btGerarPDF_Click(sender As Object, e As EventArgs) Handles btGerarPDF.Click
        Dim sfd As New SaveFileDialog
        sfd.Filter = "Pdf File |*.pdf"
        If (sfd.ShowDialog().Equals(DialogResult.OK)) Then
            Dim arquivo = New FileStream(sfd.FileName, FileMode.Create)
            Dim doc = New Document(PageSize.A4)
            Dim wri = PdfWriter.GetInstance(doc, arquivo)

            Dim f1 = New iTextSharp.text.Font(iTextSharp.text.Font.FontFamily.TIMES_ROMAN, 20, iTextSharp.text.Font.BOLD, BaseColor.BLUE)
            Dim p1 = New Paragraph("RELATÓRIO DE ENTRADAS (COMPRAS)", f1)

            p1.Alignment = Element.ALIGN_CENTER

            Dim t As New PdfPTable(9)

            Dim f2 = New iTextSharp.text.Font(iTextSharp.text.Font.FontFamily.TIMES_ROMAN, 8)

            t.SpacingBefore = 20
            t.WidthPercentage = 100

            t.AddCell(New Paragraph("Data da Compra", f2))
            t.AddCell(New Paragraph("Código", f2))
            t.AddCell(New Paragraph("Produto", f2))
            t.AddCell(New Paragraph("Data de Vencimento", f2))
            t.AddCell(New Paragraph("Quantidade", f2))
            t.AddCell(New Paragraph("Custo Unitário", f2))
            t.AddCell(New Paragraph("Total", f2))
            t.AddCell(New Paragraph("Fornecedor", f2))
            t.AddCell(New Paragraph("CPF / CNPJ", f2))

            Dim dataInicio = String.Join("-", mkDataInicio.Text.Split("/").Reverse())
            Dim dataFinal = String.Join("-", mkDataFinal.Text.Split("/").Reverse())

            Conn.Open()
            Comm.CommandText = "SELECT p.codigo, f.identificador, e.fornecedor, e.produto, e.dataCompra, e.dataVencimento , e.quantidade, e.custo FROM Entradas e 
                                INNER JOIN Produtos p ON p.produto = e.produto INNER JOIN Fornecedores f ON e.fornecedor = f.nome WHERE e.dataCompra >= @dataInicio AND e.dataCompra <= @dataFinal"
            Comm.Parameters.AddWithValue("@dataInicio", dataInicio)
            Comm.Parameters.AddWithValue("@dataFinal", dataFinal)

            Using Reader = Comm.ExecuteReader()
                While Reader.Read()
                    Dim total = Reader.Item("quantidade") * Reader.Item("custo")
                    Dim dataCompra = String.Join("/", Reader.Item("dataCompra").ToString.Split("-").Reverse())
                    Dim dataVencimento = String.Join("/", Reader.Item("dataVencimento").ToString.Split("-").Reverse())
                    Dim items(8) As String

                    t.AddCell(New Paragraph(dataCompra, f2))
                    t.AddCell(New Paragraph(Reader.Item("codigo").ToString, f2))
                    t.AddCell(New Paragraph(Reader.Item("produto").ToString, f2))
                    t.AddCell(New Paragraph(dataVencimento, f2))
                    t.AddCell(New Paragraph(Reader.Item("quantidade").ToString, f2))
                    t.AddCell(New Paragraph("R$ " & Reader.Item("custo").ToString, f2))
                    t.AddCell(New Paragraph("R$ " & Format(total, "0.00"), f2))
                    t.AddCell(New Paragraph(Reader.Item("fornecedor").ToString, f2))
                    t.AddCell(New Paragraph(Reader.Item("identificador").ToString, f2))
                End While
            End Using
            Conn.Close()

            doc.Open()
            doc.Add(p1)
            doc.Add(t)
            doc.Close()

            MessageBox.Show("PDF exportado com sucesso", "", MessageBoxButtons.OK, MessageBoxIcon.Information)
        End If
    End Sub
End Class