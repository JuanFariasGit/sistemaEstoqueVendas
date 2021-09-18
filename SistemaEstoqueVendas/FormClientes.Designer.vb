<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class FormClientes
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
        Me.tbNome = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.tbIdentificador = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.tbEndereco = New System.Windows.Forms.RichTextBox()
        Me.mkCelular = New System.Windows.Forms.MaskedTextBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.mkTelefone = New System.Windows.Forms.MaskedTextBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.tbEmail = New System.Windows.Forms.TextBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.btnAdicionar = New System.Windows.Forms.Button()
        Me.btnEditar = New System.Windows.Forms.Button()
        Me.btnExcluir = New System.Windows.Forms.Button()
        Me.btnCancelar = New System.Windows.Forms.Button()
        Me.DataGridView1 = New System.Windows.Forms.DataGridView()
        Me.nome = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.identificador = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.TextBox1 = New System.Windows.Forms.TextBox()
        Me.btnPesquisar = New System.Windows.Forms.Button()
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'tbNome
        '
        Me.tbNome.Location = New System.Drawing.Point(12, 28)
        Me.tbNome.Name = "tbNome"
        Me.tbNome.Size = New System.Drawing.Size(335, 20)
        Me.tbNome.TabIndex = 0
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(10, 12)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(120, 13)
        Me.Label1.TabIndex = 1
        Me.Label1.Text = "Nome / Razão social:(*)"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(10, 56)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(78, 13)
        Me.Label2.TabIndex = 3
        Me.Label2.Text = "CPF / CNPJ:(*)"
        '
        'tbIdentificador
        '
        Me.tbIdentificador.Location = New System.Drawing.Point(12, 72)
        Me.tbIdentificador.Name = "tbIdentificador"
        Me.tbIdentificador.Size = New System.Drawing.Size(335, 20)
        Me.tbIdentificador.TabIndex = 2
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(10, 101)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(56, 13)
        Me.Label3.TabIndex = 5
        Me.Label3.Text = "Endereço:"
        '
        'tbEndereco
        '
        Me.tbEndereco.Location = New System.Drawing.Point(12, 117)
        Me.tbEndereco.Name = "tbEndereco"
        Me.tbEndereco.Size = New System.Drawing.Size(335, 53)
        Me.tbEndereco.TabIndex = 6
        Me.tbEndereco.Text = ""
        '
        'mkCelular
        '
        Me.mkCelular.Location = New System.Drawing.Point(118, 198)
        Me.mkCelular.Mask = "(99) 0 0000-0000"
        Me.mkCelular.Name = "mkCelular"
        Me.mkCelular.Size = New System.Drawing.Size(100, 20)
        Me.mkCelular.TabIndex = 10
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(115, 182)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(99, 13)
        Me.Label4.TabIndex = 8
        Me.Label4.Text = "Celular / Whatsapp"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(62, 177)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(0, 13)
        Me.Label5.TabIndex = 9
        '
        'mkTelefone
        '
        Me.mkTelefone.Location = New System.Drawing.Point(12, 198)
        Me.mkTelefone.Mask = "(99) 0000-0000"
        Me.mkTelefone.Name = "mkTelefone"
        Me.mkTelefone.Size = New System.Drawing.Size(100, 20)
        Me.mkTelefone.TabIndex = 7
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(9, 182)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(49, 13)
        Me.Label6.TabIndex = 11
        Me.Label6.Text = "Telefone"
        '
        'tbEmail
        '
        Me.tbEmail.Location = New System.Drawing.Point(12, 245)
        Me.tbEmail.Name = "tbEmail"
        Me.tbEmail.Size = New System.Drawing.Size(335, 20)
        Me.tbEmail.TabIndex = 12
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(9, 229)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(38, 13)
        Me.Label7.TabIndex = 13
        Me.Label7.Text = "E-mail:"
        '
        'btnAdicionar
        '
        Me.btnAdicionar.Location = New System.Drawing.Point(21, 271)
        Me.btnAdicionar.Name = "btnAdicionar"
        Me.btnAdicionar.Size = New System.Drawing.Size(75, 23)
        Me.btnAdicionar.TabIndex = 16
        Me.btnAdicionar.Text = "Adicionar"
        Me.btnAdicionar.UseVisualStyleBackColor = True
        '
        'btnEditar
        '
        Me.btnEditar.Enabled = False
        Me.btnEditar.Location = New System.Drawing.Point(102, 271)
        Me.btnEditar.Name = "btnEditar"
        Me.btnEditar.Size = New System.Drawing.Size(75, 23)
        Me.btnEditar.TabIndex = 17
        Me.btnEditar.Text = "Editar"
        Me.btnEditar.UseVisualStyleBackColor = True
        '
        'btnExcluir
        '
        Me.btnExcluir.Enabled = False
        Me.btnExcluir.Location = New System.Drawing.Point(183, 271)
        Me.btnExcluir.Name = "btnExcluir"
        Me.btnExcluir.Size = New System.Drawing.Size(75, 23)
        Me.btnExcluir.TabIndex = 18
        Me.btnExcluir.Text = "Excluir"
        Me.btnExcluir.UseVisualStyleBackColor = True
        '
        'btnCancelar
        '
        Me.btnCancelar.Enabled = False
        Me.btnCancelar.Location = New System.Drawing.Point(264, 271)
        Me.btnCancelar.Name = "btnCancelar"
        Me.btnCancelar.Size = New System.Drawing.Size(75, 23)
        Me.btnCancelar.TabIndex = 19
        Me.btnCancelar.Text = "Cancelar"
        Me.btnCancelar.UseVisualStyleBackColor = True
        '
        'DataGridView1
        '
        Me.DataGridView1.AllowUserToAddRows = False
        Me.DataGridView1.AllowUserToDeleteRows = False
        Me.DataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DataGridView1.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.nome, Me.identificador})
        Me.DataGridView1.Location = New System.Drawing.Point(366, 56)
        Me.DataGridView1.Name = "DataGridView1"
        Me.DataGridView1.ReadOnly = True
        Me.DataGridView1.Size = New System.Drawing.Size(446, 322)
        Me.DataGridView1.TabIndex = 22
        '
        'nome
        '
        Me.nome.HeaderText = "Cliente"
        Me.nome.Name = "nome"
        Me.nome.ReadOnly = True
        Me.nome.Width = 200
        '
        'identificador
        '
        Me.identificador.HeaderText = "CPF / CNJPJ"
        Me.identificador.Name = "identificador"
        Me.identificador.ReadOnly = True
        Me.identificador.Width = 200
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(380, 14)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(68, 13)
        Me.Label8.TabIndex = 22
        Me.Label8.Text = "CPF / CNPJ:"
        '
        'TextBox1
        '
        Me.TextBox1.Location = New System.Drawing.Point(382, 28)
        Me.TextBox1.Name = "TextBox1"
        Me.TextBox1.Size = New System.Drawing.Size(335, 20)
        Me.TextBox1.TabIndex = 20
        '
        'btnPesquisar
        '
        Me.btnPesquisar.Location = New System.Drawing.Point(723, 26)
        Me.btnPesquisar.Name = "btnPesquisar"
        Me.btnPesquisar.Size = New System.Drawing.Size(75, 23)
        Me.btnPesquisar.TabIndex = 21
        Me.btnPesquisar.Text = "Pesquisar"
        Me.btnPesquisar.UseVisualStyleBackColor = True
        '
        'FormClientes
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(822, 382)
        Me.Controls.Add(Me.btnPesquisar)
        Me.Controls.Add(Me.Label8)
        Me.Controls.Add(Me.TextBox1)
        Me.Controls.Add(Me.DataGridView1)
        Me.Controls.Add(Me.btnCancelar)
        Me.Controls.Add(Me.btnExcluir)
        Me.Controls.Add(Me.btnEditar)
        Me.Controls.Add(Me.btnAdicionar)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.tbEmail)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.mkTelefone)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.mkCelular)
        Me.Controls.Add(Me.tbEndereco)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.tbIdentificador)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.tbNome)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.MaximizeBox = False
        Me.Name = "FormClientes"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Clientes"
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents tbNome As TextBox
    Friend WithEvents Label1 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents tbIdentificador As TextBox
    Friend WithEvents Label3 As Label
    Friend WithEvents tbEndereco As RichTextBox
    Friend WithEvents mkCelular As MaskedTextBox
    Friend WithEvents Label4 As Label
    Friend WithEvents Label5 As Label
    Friend WithEvents mkTelefone As MaskedTextBox
    Friend WithEvents Label6 As Label
    Friend WithEvents tbEmail As TextBox
    Friend WithEvents Label7 As Label
    Friend WithEvents btnAdicionar As Button
    Friend WithEvents btnEditar As Button
    Friend WithEvents btnExcluir As Button
    Friend WithEvents btnCancelar As Button
    Friend WithEvents DataGridView1 As DataGridView
    Friend WithEvents Label8 As Label
    Friend WithEvents TextBox1 As TextBox
    Friend WithEvents btnPesquisar As Button
    Friend WithEvents nome As DataGridViewTextBoxColumn
    Friend WithEvents identificador As DataGridViewTextBoxColumn
End Class
