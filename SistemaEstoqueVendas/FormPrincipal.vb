Public Class FormPrincipal
    Private Sub ClientesToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ClientesToolStripMenuItem.Click
        Dim formClientes = New FormClientes()
        formClientes.ShowDialog()
    End Sub
    Private Sub FornecedoresToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles FornecedoresToolStripMenuItem.Click
        Dim formFornecedores = New FormFornecedores()
        formFornecedores.ShowDialog()
    End Sub
    Private Sub ProdutosToolStripMenuItem1_Click(sender As Object, e As EventArgs) Handles ProdutosToolStripMenuItem1.Click
        Dim formProdutos = New FormProdutos()
        formProdutos.ShowDialog()
    End Sub
    Private Sub EntradaToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles EntradaToolStripMenuItem.Click
        Dim formEntradas = New FormEntradas()
        formEntradas.ShowDialog()
    End Sub
    Private Sub EntradasToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles EntradasToolStripMenuItem.Click
        Dim formRelatorioEntradas = New FormRelatorioEntradas()
        formRelatorioEntradas.ShowDialog()
    End Sub
    Private Sub SaídaToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles SaídaToolStripMenuItem.Click
        Dim formSaidas = New FormSaidas()
        formSaidas.ShowDialog()
    End Sub
End Class
