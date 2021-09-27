<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class FormRelatorioEntradas
    Inherits System.Windows.Forms.Form

    'Descartar substituições de formulário para limpar a lista de componentes.
    <System.Diagnostics.DebuggerNonUserCode()>
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Exigido pelo Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'OBSERVAÇÃO: o procedimento a seguir é exigido pelo Windows Form Designer
    'Pode ser modificado usando o Windows Form Designer.  
    'Não o modifique usando o editor de códigos.
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.mkDataInicio = New System.Windows.Forms.MaskedTextBox()
        Me.mkDataFinal = New System.Windows.Forms.MaskedTextBox()
        Me.btPesquisar = New System.Windows.Forms.Button()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.lRegistrosCompras = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.lTotalComprasPeriodo = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.ListView1 = New System.Windows.Forms.ListView()
        Me.registro = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.dataCompra = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.fornecedor = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.produto = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.dataValidade = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.quantidade = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.custo = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.subtotal = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.btGerarPDF = New System.Windows.Forms.Button()
        Me.Panel1.SuspendLayout()
        Me.Panel2.SuspendLayout()
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(297, 9)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(63, 13)
        Me.Label1.TabIndex = 1
        Me.Label1.Text = "Data Início:"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(403, 9)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(58, 13)
        Me.Label2.TabIndex = 3
        Me.Label2.Text = "Data Final:"
        '
        'mkDataInicio
        '
        Me.mkDataInicio.Location = New System.Drawing.Point(300, 25)
        Me.mkDataInicio.Mask = "00/00/0000"
        Me.mkDataInicio.Name = "mkDataInicio"
        Me.mkDataInicio.Size = New System.Drawing.Size(100, 20)
        Me.mkDataInicio.TabIndex = 2
        Me.mkDataInicio.ValidatingType = GetType(Date)
        '
        'mkDataFinal
        '
        Me.mkDataFinal.Location = New System.Drawing.Point(406, 25)
        Me.mkDataFinal.Mask = "00/00/0000"
        Me.mkDataFinal.Name = "mkDataFinal"
        Me.mkDataFinal.Size = New System.Drawing.Size(100, 20)
        Me.mkDataFinal.TabIndex = 4
        Me.mkDataFinal.ValidatingType = GetType(Date)
        '
        'btPesquisar
        '
        Me.btPesquisar.Location = New System.Drawing.Point(325, 51)
        Me.btPesquisar.Name = "btPesquisar"
        Me.btPesquisar.Size = New System.Drawing.Size(75, 23)
        Me.btPesquisar.TabIndex = 9
        Me.btPesquisar.Text = "Pesquisar"
        Me.btPesquisar.UseVisualStyleBackColor = True
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.SystemColors.AppWorkspace
        Me.Panel1.Controls.Add(Me.lRegistrosCompras)
        Me.Panel1.Controls.Add(Me.Label4)
        Me.Panel1.Location = New System.Drawing.Point(12, 84)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(391, 82)
        Me.Panel1.TabIndex = 10
        '
        'lRegistrosCompras
        '
        Me.lRegistrosCompras.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lRegistrosCompras.Location = New System.Drawing.Point(3, 46)
        Me.lRegistrosCompras.Name = "lRegistrosCompras"
        Me.lRegistrosCompras.Size = New System.Drawing.Size(368, 24)
        Me.lRegistrosCompras.TabIndex = 1
        Me.lRegistrosCompras.Text = "0"
        Me.lRegistrosCompras.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'Label4
        '
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(3, 11)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(368, 24)
        Me.Label4.TabIndex = 0
        Me.Label4.Text = "Registros de Compras"
        Me.Label4.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'Panel2
        '
        Me.Panel2.BackColor = System.Drawing.SystemColors.AppWorkspace
        Me.Panel2.Controls.Add(Me.lTotalComprasPeriodo)
        Me.Panel2.Controls.Add(Me.Label5)
        Me.Panel2.Location = New System.Drawing.Point(425, 84)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(390, 82)
        Me.Panel2.TabIndex = 11
        '
        'lTotalComprasPeriodo
        '
        Me.lTotalComprasPeriodo.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lTotalComprasPeriodo.Location = New System.Drawing.Point(3, 47)
        Me.lTotalComprasPeriodo.Name = "lTotalComprasPeriodo"
        Me.lTotalComprasPeriodo.Size = New System.Drawing.Size(368, 23)
        Me.lTotalComprasPeriodo.TabIndex = 2
        Me.lTotalComprasPeriodo.Text = "R$ 0,00"
        Me.lTotalComprasPeriodo.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'Label5
        '
        Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(3, 11)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(368, 24)
        Me.Label5.TabIndex = 1
        Me.Label5.Text = "Total em Compras no Período"
        Me.Label5.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'ListView1
        '
        Me.ListView1.BackColor = System.Drawing.SystemColors.AppWorkspace
        Me.ListView1.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.registro, Me.dataCompra, Me.fornecedor, Me.produto, Me.dataValidade, Me.quantidade, Me.custo, Me.subtotal})
        Me.ListView1.HideSelection = False
        Me.ListView1.Location = New System.Drawing.Point(12, 172)
        Me.ListView1.Name = "ListView1"
        Me.ListView1.Size = New System.Drawing.Size(804, 241)
        Me.ListView1.TabIndex = 12
        Me.ListView1.UseCompatibleStateImageBehavior = False
        Me.ListView1.View = System.Windows.Forms.View.Details
        '
        'registro
        '
        Me.registro.Text = "Registro"
        '
        'dataCompra
        '
        Me.dataCompra.Text = "Data da Compra"
        Me.dataCompra.Width = 92
        '
        'fornecedor
        '
        Me.fornecedor.Text = "Fornecedor"
        Me.fornecedor.Width = 150
        '
        'produto
        '
        Me.produto.Text = "Produto"
        Me.produto.Width = 150
        '
        'dataValidade
        '
        Me.dataValidade.Text = "Data de Validade"
        Me.dataValidade.Width = 100
        '
        'quantidade
        '
        Me.quantidade.Text = "Quantidade"
        Me.quantidade.Width = 67
        '
        'custo
        '
        Me.custo.Text = "Custo Unitário"
        Me.custo.Width = 80
        '
        'subtotal
        '
        Me.subtotal.Text = "Subtotal"
        Me.subtotal.Width = 101
        '
        'btGerarPDF
        '
        Me.btGerarPDF.Location = New System.Drawing.Point(406, 51)
        Me.btGerarPDF.Name = "btGerarPDF"
        Me.btGerarPDF.Size = New System.Drawing.Size(75, 23)
        Me.btGerarPDF.TabIndex = 13
        Me.btGerarPDF.Text = "Exporta PDF"
        Me.btGerarPDF.UseVisualStyleBackColor = True
        '
        'FormRelatorioEntradas
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(827, 462)
        Me.Controls.Add(Me.btGerarPDF)
        Me.Controls.Add(Me.ListView1)
        Me.Controls.Add(Me.Panel2)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.btPesquisar)
        Me.Controls.Add(Me.mkDataFinal)
        Me.Controls.Add(Me.mkDataInicio)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "FormRelatorioEntradas"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Relatório Entradas (Compras)"
        Me.Panel1.ResumeLayout(False)
        Me.Panel2.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Label1 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents mkDataInicio As MaskedTextBox
    Friend WithEvents mkDataFinal As MaskedTextBox
    Friend WithEvents btPesquisar As Button
    Friend WithEvents Panel1 As Panel
    Friend WithEvents Label4 As Label
    Friend WithEvents Panel2 As Panel
    Friend WithEvents Label5 As Label
    Friend WithEvents lRegistrosCompras As Label
    Friend WithEvents lTotalComprasPeriodo As Label
    Friend WithEvents ListView1 As ListView
    Friend WithEvents registro As ColumnHeader
    Friend WithEvents dataCompra As ColumnHeader
    Friend WithEvents fornecedor As ColumnHeader
    Friend WithEvents produto As ColumnHeader
    Friend WithEvents dataValidade As ColumnHeader
    Friend WithEvents quantidade As ColumnHeader
    Friend WithEvents custo As ColumnHeader
    Friend WithEvents subtotal As ColumnHeader
    Friend WithEvents btGerarPDF As Button
End Class
