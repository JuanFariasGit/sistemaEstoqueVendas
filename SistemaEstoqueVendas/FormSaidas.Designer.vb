<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FormSaidas
    Inherits System.Windows.Forms.Form

    'Descartar substituições de formulário para limpar a lista de componentes.
    <System.Diagnostics.DebuggerNonUserCode()> _
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
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.cbProdutoPesquisar = New System.Windows.Forms.ComboBox()
        Me.mkDataCompra = New System.Windows.Forms.MaskedTextBox()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.btnPesquisar = New System.Windows.Forms.Button()
        Me.tbRegistro = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.btnSalvar = New System.Windows.Forms.Button()
        Me.btnCancelar = New System.Windows.Forms.Button()
        Me.btnExcluir = New System.Windows.Forms.Button()
        Me.btnEditar = New System.Windows.Forms.Button()
        Me.btnAdicionar = New System.Windows.Forms.Button()
        Me.DataGridView1 = New System.Windows.Forms.DataGridView()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.tbCusto = New System.Windows.Forms.TextBox()
        Me.tbQuantidade = New System.Windows.Forms.Label()
        Me.tbQuandidade = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.cbProduto = New System.Windows.Forms.ComboBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.cbFornecedor = New System.Windows.Forms.ComboBox()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.registro = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.produto = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.quantidade = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.preco = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.total = New System.Windows.Forms.DataGridViewTextBoxColumn()
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(-63, 39)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(49, 13)
        Me.Label6.TabIndex = 48
        Me.Label6.Text = "Registro:"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(-63, 172)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(57, 13)
        Me.Label3.TabIndex = 34
        Me.Label3.Text = "Produto:(*)"
        '
        'cbProdutoPesquisar
        '
        Me.cbProdutoPesquisar.FormattingEnabled = True
        Me.cbProdutoPesquisar.Location = New System.Drawing.Point(432, 23)
        Me.cbProdutoPesquisar.Name = "cbProdutoPesquisar"
        Me.cbProdutoPesquisar.Size = New System.Drawing.Size(335, 21)
        Me.cbProdutoPesquisar.TabIndex = 70
        '
        'mkDataCompra
        '
        Me.mkDataCompra.Enabled = False
        Me.mkDataCompra.Location = New System.Drawing.Point(12, 69)
        Me.mkDataCompra.Mask = "00/00/0000"
        Me.mkDataCompra.Name = "mkDataCompra"
        Me.mkDataCompra.Size = New System.Drawing.Size(100, 20)
        Me.mkDataCompra.TabIndex = 50
        Me.mkDataCompra.ValidatingType = GetType(Date)
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(429, 8)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(47, 13)
        Me.Label8.TabIndex = 69
        Me.Label8.Text = "Produto:"
        '
        'btnPesquisar
        '
        Me.btnPesquisar.Location = New System.Drawing.Point(773, 24)
        Me.btnPesquisar.Name = "btnPesquisar"
        Me.btnPesquisar.Size = New System.Drawing.Size(75, 23)
        Me.btnPesquisar.TabIndex = 71
        Me.btnPesquisar.Text = "Pesquisar"
        Me.btnPesquisar.UseVisualStyleBackColor = True
        '
        'tbRegistro
        '
        Me.tbRegistro.Enabled = False
        Me.tbRegistro.Location = New System.Drawing.Point(12, 25)
        Me.tbRegistro.Name = "tbRegistro"
        Me.tbRegistro.Size = New System.Drawing.Size(100, 20)
        Me.tbRegistro.TabIndex = 68
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(9, 9)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(49, 13)
        Me.Label1.TabIndex = 67
        Me.Label1.Text = "Registro:"
        '
        'btnSalvar
        '
        Me.btnSalvar.Enabled = False
        Me.btnSalvar.Location = New System.Drawing.Point(130, 277)
        Me.btnSalvar.Name = "btnSalvar"
        Me.btnSalvar.Size = New System.Drawing.Size(75, 23)
        Me.btnSalvar.TabIndex = 62
        Me.btnSalvar.Text = "Salvar"
        Me.btnSalvar.UseVisualStyleBackColor = True
        '
        'btnCancelar
        '
        Me.btnCancelar.Enabled = False
        Me.btnCancelar.Location = New System.Drawing.Point(250, 306)
        Me.btnCancelar.Name = "btnCancelar"
        Me.btnCancelar.Size = New System.Drawing.Size(75, 23)
        Me.btnCancelar.TabIndex = 66
        Me.btnCancelar.Text = "Cancelar"
        Me.btnCancelar.UseVisualStyleBackColor = True
        '
        'btnExcluir
        '
        Me.btnExcluir.Location = New System.Drawing.Point(169, 306)
        Me.btnExcluir.Name = "btnExcluir"
        Me.btnExcluir.Size = New System.Drawing.Size(75, 23)
        Me.btnExcluir.TabIndex = 65
        Me.btnExcluir.Text = "Excluir"
        Me.btnExcluir.UseVisualStyleBackColor = True
        '
        'btnEditar
        '
        Me.btnEditar.Location = New System.Drawing.Point(88, 306)
        Me.btnEditar.Name = "btnEditar"
        Me.btnEditar.Size = New System.Drawing.Size(75, 23)
        Me.btnEditar.TabIndex = 64
        Me.btnEditar.Text = "Editar"
        Me.btnEditar.UseVisualStyleBackColor = True
        '
        'btnAdicionar
        '
        Me.btnAdicionar.Location = New System.Drawing.Point(7, 306)
        Me.btnAdicionar.Name = "btnAdicionar"
        Me.btnAdicionar.Size = New System.Drawing.Size(75, 23)
        Me.btnAdicionar.TabIndex = 63
        Me.btnAdicionar.Text = "Adicionar"
        Me.btnAdicionar.UseVisualStyleBackColor = True
        '
        'DataGridView1
        '
        Me.DataGridView1.AllowUserToAddRows = False
        Me.DataGridView1.AllowUserToDeleteRows = False
        Me.DataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DataGridView1.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.registro, Me.produto, Me.quantidade, Me.preco, Me.total})
        Me.DataGridView1.Location = New System.Drawing.Point(339, 53)
        Me.DataGridView1.Name = "DataGridView1"
        Me.DataGridView1.ReadOnly = True
        Me.DataGridView1.Size = New System.Drawing.Size(599, 276)
        Me.DataGridView1.TabIndex = 61
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(11, 231)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(87, 13)
        Me.Label5.TabIndex = 59
        Me.Label5.Text = "Preço Unitário:(*)"
        '
        'tbCusto
        '
        Me.tbCusto.Enabled = False
        Me.tbCusto.Location = New System.Drawing.Point(13, 247)
        Me.tbCusto.Name = "tbCusto"
        Me.tbCusto.Size = New System.Drawing.Size(100, 20)
        Me.tbCusto.TabIndex = 60
        '
        'tbQuantidade
        '
        Me.tbQuantidade.AutoSize = True
        Me.tbQuantidade.Location = New System.Drawing.Point(10, 187)
        Me.tbQuantidade.Name = "tbQuantidade"
        Me.tbQuantidade.Size = New System.Drawing.Size(75, 13)
        Me.tbQuantidade.TabIndex = 57
        Me.tbQuantidade.Text = "Quantidade:(*)"
        '
        'tbQuandidade
        '
        Me.tbQuandidade.Enabled = False
        Me.tbQuandidade.Location = New System.Drawing.Point(12, 203)
        Me.tbQuandidade.Name = "tbQuandidade"
        Me.tbQuandidade.Size = New System.Drawing.Size(100, 20)
        Me.tbQuandidade.TabIndex = 58
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(9, 142)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(57, 13)
        Me.Label2.TabIndex = 53
        Me.Label2.Text = "Produto:(*)"
        '
        'cbProduto
        '
        Me.cbProduto.FormattingEnabled = True
        Me.cbProduto.Location = New System.Drawing.Point(12, 158)
        Me.cbProduto.Name = "cbProduto"
        Me.cbProduto.Size = New System.Drawing.Size(307, 21)
        Me.cbProduto.TabIndex = 54
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(9, 53)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(91, 13)
        Me.Label7.TabIndex = 49
        Me.Label7.Text = "Data da venda:(*)"
        '
        'cbFornecedor
        '
        Me.cbFornecedor.Enabled = False
        Me.cbFornecedor.FormattingEnabled = True
        Me.cbFornecedor.Location = New System.Drawing.Point(12, 113)
        Me.cbFornecedor.Name = "cbFornecedor"
        Me.cbFornecedor.Size = New System.Drawing.Size(307, 21)
        Me.cbFornecedor.TabIndex = 52
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(10, 97)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(57, 13)
        Me.Label9.TabIndex = 51
        Me.Label9.Text = "Clientes:(*)"
        '
        'registro
        '
        Me.registro.HeaderText = "Registro"
        Me.registro.Name = "registro"
        Me.registro.ReadOnly = True
        '
        'produto
        '
        Me.produto.HeaderText = "Produto"
        Me.produto.Name = "produto"
        Me.produto.ReadOnly = True
        Me.produto.Width = 150
        '
        'quantidade
        '
        Me.quantidade.HeaderText = "Quantidade"
        Me.quantidade.Name = "quantidade"
        Me.quantidade.ReadOnly = True
        '
        'preco
        '
        Me.preco.HeaderText = "Preço Unitário"
        Me.preco.Name = "preco"
        Me.preco.ReadOnly = True
        '
        'total
        '
        Me.total.HeaderText = "Total"
        Me.total.Name = "total"
        Me.total.ReadOnly = True
        '
        'FormSaidas
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(950, 339)
        Me.Controls.Add(Me.cbProdutoPesquisar)
        Me.Controls.Add(Me.mkDataCompra)
        Me.Controls.Add(Me.Label8)
        Me.Controls.Add(Me.btnPesquisar)
        Me.Controls.Add(Me.tbRegistro)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.btnSalvar)
        Me.Controls.Add(Me.btnCancelar)
        Me.Controls.Add(Me.btnExcluir)
        Me.Controls.Add(Me.btnEditar)
        Me.Controls.Add(Me.btnAdicionar)
        Me.Controls.Add(Me.DataGridView1)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.tbCusto)
        Me.Controls.Add(Me.tbQuantidade)
        Me.Controls.Add(Me.tbQuandidade)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.cbProduto)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.cbFornecedor)
        Me.Controls.Add(Me.Label9)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.Label3)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "FormSaidas"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Saídas (Vendas)"
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Label6 As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents cbProdutoPesquisar As ComboBox
    Friend WithEvents mkDataCompra As MaskedTextBox
    Friend WithEvents Label8 As Label
    Friend WithEvents btnPesquisar As Button
    Friend WithEvents tbRegistro As TextBox
    Friend WithEvents Label1 As Label
    Friend WithEvents btnSalvar As Button
    Friend WithEvents btnCancelar As Button
    Friend WithEvents btnExcluir As Button
    Friend WithEvents btnEditar As Button
    Friend WithEvents btnAdicionar As Button
    Friend WithEvents DataGridView1 As DataGridView
    Friend WithEvents Label5 As Label
    Friend WithEvents tbCusto As TextBox
    Friend WithEvents tbQuantidade As Label
    Friend WithEvents tbQuandidade As TextBox
    Friend WithEvents Label2 As Label
    Friend WithEvents cbProduto As ComboBox
    Friend WithEvents Label7 As Label
    Friend WithEvents cbFornecedor As ComboBox
    Friend WithEvents Label9 As Label
    Friend WithEvents registro As DataGridViewTextBoxColumn
    Friend WithEvents produto As DataGridViewTextBoxColumn
    Friend WithEvents quantidade As DataGridViewTextBoxColumn
    Friend WithEvents preco As DataGridViewTextBoxColumn
    Friend WithEvents total As DataGridViewTextBoxColumn
End Class
