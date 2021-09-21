Public Class FormPrincipal
    Private Sub ClientesToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ClientesToolStripMenuItem.Click
        FormClientes.Show()
    End Sub
    Private Sub FornecedoresToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles FornecedoresToolStripMenuItem.Click
        FormFornecedores.Show()
    End Sub
    Private Sub ProdutosToolStripMenuItem1_Click(sender As Object, e As EventArgs) Handles ProdutosToolStripMenuItem1.Click
        FormProdutos.Show()
    End Sub
    Private Sub EntradaToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles EntradaToolStripMenuItem.Click
        FormEntradas.Show()
    End Sub
End Class
