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
        Me.DataGridView1 = New System.Windows.Forms.DataGridView()
        Me.registro = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.nome = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.identificador = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.tbPesquisar = New System.Windows.Forms.TextBox()
        Me.btnPesquisar = New System.Windows.Forms.Button()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.tbRegistro = New System.Windows.Forms.TextBox()
        Me.btnSalvar = New System.Windows.Forms.Button()
        Me.btnCancelar = New System.Windows.Forms.Button()
        Me.Label8 = New System.Windows.Forms.Label()
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'tbNome
        '
        Me.tbNome.Enabled = False
        Me.tbNome.Location = New System.Drawing.Point(12, 65)
        Me.tbNome.Name = "tbNome"
        Me.tbNome.Size = New System.Drawing.Size(335, 20)
        Me.tbNome.TabIndex = 4
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(10, 49)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(120, 13)
        Me.Label1.TabIndex = 3
        Me.Label1.Text = "Nome / Razão social:(*)"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(10, 93)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(78, 13)
        Me.Label2.TabIndex = 5
        Me.Label2.Text = "CPF / CNPJ:(*)"
        '
        'tbIdentificador
        '
        Me.tbIdentificador.Enabled = False
        Me.tbIdentificador.Location = New System.Drawing.Point(12, 109)
        Me.tbIdentificador.Name = "tbIdentificador"
        Me.tbIdentificador.Size = New System.Drawing.Size(335, 20)
        Me.tbIdentificador.TabIndex = 6
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(10, 138)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(56, 13)
        Me.Label3.TabIndex = 7
        Me.Label3.Text = "Endereço:"
        '
        'tbEndereco
        '
        Me.tbEndereco.Enabled = False
        Me.tbEndereco.Location = New System.Drawing.Point(12, 154)
        Me.tbEndereco.Name = "tbEndereco"
        Me.tbEndereco.Size = New System.Drawing.Size(335, 53)
        Me.tbEndereco.TabIndex = 8
        Me.tbEndereco.Text = ""
        '
        'mkCelular
        '
        Me.mkCelular.Enabled = False
        Me.mkCelular.Location = New System.Drawing.Point(118, 235)
        Me.mkCelular.Mask = "(99) 0 0000-0000"
        Me.mkCelular.Name = "mkCelular"
        Me.mkCelular.Size = New System.Drawing.Size(100, 20)
        Me.mkCelular.TabIndex = 12
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(115, 219)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(99, 13)
        Me.Label4.TabIndex = 11
        Me.Label4.Text = "Celular / Whatsapp"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(62, 214)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(0, 13)
        Me.Label5.TabIndex = 9
        '
        'mkTelefone
        '
        Me.mkTelefone.Enabled = False
        Me.mkTelefone.Location = New System.Drawing.Point(12, 235)
        Me.mkTelefone.Mask = "(99) 0000-0000"
        Me.mkTelefone.Name = "mkTelefone"
        Me.mkTelefone.Size = New System.Drawing.Size(100, 20)
        Me.mkTelefone.TabIndex = 10
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(9, 219)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(49, 13)
        Me.Label6.TabIndex = 9
        Me.Label6.Text = "Telefone"
        '
        'tbEmail
        '
        Me.tbEmail.Enabled = False
        Me.tbEmail.Location = New System.Drawing.Point(12, 282)
        Me.tbEmail.Name = "tbEmail"
        Me.tbEmail.Size = New System.Drawing.Size(335, 20)
        Me.tbEmail.TabIndex = 14
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(9, 266)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(38, 13)
        Me.Label7.TabIndex = 13
        Me.Label7.Text = "E-mail:"
        '
        'btnAdicionar
        '
        Me.btnAdicionar.Location = New System.Drawing.Point(17, 337)
        Me.btnAdicionar.Name = "btnAdicionar"
        Me.btnAdicionar.Size = New System.Drawing.Size(75, 23)
        Me.btnAdicionar.TabIndex = 16
        Me.btnAdicionar.Text = "Adicionar"
        Me.btnAdicionar.UseVisualStyleBackColor = True
        '
        'btnEditar
        '
        Me.btnEditar.Location = New System.Drawing.Point(98, 337)
        Me.btnEditar.Name = "btnEditar"
        Me.btnEditar.Size = New System.Drawing.Size(75, 23)
        Me.btnEditar.TabIndex = 17
        Me.btnEditar.Text = "Editar"
        Me.btnEditar.UseVisualStyleBackColor = True
        '
        'btnExcluir
        '
        Me.btnExcluir.Location = New System.Drawing.Point(179, 337)
        Me.btnExcluir.Name = "btnExcluir"
        Me.btnExcluir.Size = New System.Drawing.Size(75, 23)
        Me.btnExcluir.TabIndex = 18
        Me.btnExcluir.Text = "Excluir"
        Me.btnExcluir.UseVisualStyleBackColor = True
        '
        'DataGridView1
        '
        Me.DataGridView1.AllowUserToAddRows = False
        Me.DataGridView1.AllowUserToDeleteRows = False
        Me.DataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DataGridView1.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.registro, Me.nome, Me.identificador})
        Me.DataGridView1.Location = New System.Drawing.Point(366, 56)
        Me.DataGridView1.Name = "DataGridView1"
        Me.DataGridView1.ReadOnly = True
        Me.DataGridView1.Size = New System.Drawing.Size(549, 304)
        Me.DataGridView1.TabIndex = 23
        '
        'registro
        '
        Me.registro.HeaderText = "Registro (Nº)"
        Me.registro.Name = "registro"
        Me.registro.ReadOnly = True
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
        'tbPesquisar
        '
        Me.tbPesquisar.Location = New System.Drawing.Point(449, 26)
        Me.tbPesquisar.Name = "tbPesquisar"
        Me.tbPesquisar.Size = New System.Drawing.Size(335, 20)
        Me.tbPesquisar.TabIndex = 21
        Me.tbPesquisar.Text = "" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10)
        '
        'btnPesquisar
        '
        Me.btnPesquisar.Location = New System.Drawing.Point(790, 24)
        Me.btnPesquisar.Name = "btnPesquisar"
        Me.btnPesquisar.Size = New System.Drawing.Size(75, 23)
        Me.btnPesquisar.TabIndex = 22
        Me.btnPesquisar.Text = "Pesquisar"
        Me.btnPesquisar.UseVisualStyleBackColor = True
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(11, 10)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(70, 13)
        Me.Label9.TabIndex = 1
        Me.Label9.Text = "Registro (Nº):"
        '
        'tbRegistro
        '
        Me.tbRegistro.Enabled = False
        Me.tbRegistro.Location = New System.Drawing.Point(13, 26)
        Me.tbRegistro.Name = "tbRegistro"
        Me.tbRegistro.Size = New System.Drawing.Size(75, 20)
        Me.tbRegistro.TabIndex = 2
        '
        'btnSalvar
        '
        Me.btnSalvar.Enabled = False
        Me.btnSalvar.Location = New System.Drawing.Point(140, 308)
        Me.btnSalvar.Name = "btnSalvar"
        Me.btnSalvar.Size = New System.Drawing.Size(75, 23)
        Me.btnSalvar.TabIndex = 15
        Me.btnSalvar.Text = "Salvar"
        Me.btnSalvar.UseVisualStyleBackColor = True
        '
        'btnCancelar
        '
        Me.btnCancelar.Enabled = False
        Me.btnCancelar.Location = New System.Drawing.Point(260, 337)
        Me.btnCancelar.Name = "btnCancelar"
        Me.btnCancelar.Size = New System.Drawing.Size(75, 23)
        Me.btnCancelar.TabIndex = 19
        Me.btnCancelar.Text = "Cancelar"
        Me.btnCancelar.UseVisualStyleBackColor = True
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(446, 9)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(188, 13)
        Me.Label8.TabIndex = 20
        Me.Label8.Text = "Nome / Razão Social ou CPF / CNPJ:" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10)
        '
        'FormClientes
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(927, 371)
        Me.Controls.Add(Me.Label8)
        Me.Controls.Add(Me.btnSalvar)
        Me.Controls.Add(Me.Label9)
        Me.Controls.Add(Me.tbRegistro)
        Me.Controls.Add(Me.btnPesquisar)
        Me.Controls.Add(Me.tbPesquisar)
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
        Me.MinimizeBox = False
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
    Friend WithEvents DataGridView1 As DataGridView
    Friend WithEvents tbPesquisar As TextBox
    Friend WithEvents btnPesquisar As Button
    Friend WithEvents Label9 As Label
    Friend WithEvents tbRegistro As TextBox
    Friend WithEvents btnSalvar As Button
    Friend WithEvents btnCancelar As Button
    Friend WithEvents Label8 As Label
    Friend WithEvents registro As DataGridViewTextBoxColumn
    Friend WithEvents nome As DataGridViewTextBoxColumn
    Friend WithEvents identificador As DataGridViewTextBoxColumn
End Class
