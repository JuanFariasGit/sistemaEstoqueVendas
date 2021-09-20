Public Class FormFornecedores
    Private op As String
    Private Sub FormFornecedores_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        getFornecedores()
        tbPesquisar.Select()
    End Sub
    Private Sub getFornecedores()
        DataGridView1.Rows.Clear()
        Using Conn As New System.Data.SQLite.SQLiteConnection("Data Source=C:\Users\Juan Farias\projetos\VB .NET\SistemaEstoqueVendas\Banco\SistemaEstoqueVendas.db")
            Conn.Open()
            Using Comm As New System.Data.SQLite.SQLiteCommand(Conn)
                Comm.CommandText = "SELECT * FROM Fornecedores"
                Using Reader = Comm.ExecuteReader()
                    While Reader.Read()
                        DataGridView1.Rows.Add(Reader.Item("registro").ToString,
                                               Reader.Item("nome").ToString,
                                               Reader.Item("identificador").ToString)
                    End While
                End Using
            End Using
        End Using
    End Sub
    Private Sub searchFornecedor()
        Dim searchValue = tbPesquisar.Text.Trim()
        DataGridView1.Rows.Clear()
        Using Conn As New System.Data.SQLite.SQLiteConnection("Data Source=C:\Users\Juan Farias\projetos\VB .NET\SistemaEstoqueVendas\Banco\SistemaEstoqueVendas.db")
            Conn.Open()
            Using Comm As New System.Data.SQLite.SQLiteCommand(Conn)
                Comm.CommandText = "SELECT * FROM Fornecedores WHERE nome LIKE @searchValue OR identificador LIKE @searchValue"
                Comm.Parameters.AddWithValue("@searchValue", "%" + searchValue + "%")
                Using Reader = Comm.ExecuteReader()
                    While Reader.Read()
                        DataGridView1.Rows.Add(Reader.Item("registro").ToString,
                                               Reader.Item("nome").ToString,
                                               Reader.Item("identificador").ToString)
                    End While
                End Using
            End Using
        End Using
    End Sub
    Private Sub addFornecedor()
        If tbNome.Text.Length > 0 And tbIdentificador.Text.Length > 0 Then
            Dim nome = tbNome.Text.Trim
            Dim identificador = tbIdentificador.Text.Trim
            Dim endereco = tbEndereco.Text.Trim
            Dim telefone = mkTelefone.Text.Trim
            Dim celular = mkCelular.Text.Trim
            Dim email = tbEmail.Text.Trim
            Using Conn As New System.Data.SQLite.SQLiteConnection("Data Source=C:\Users\Juan Farias\projetos\VB .NET\SistemaEstoqueVendas\Banco\SistemaEstoqueVendas.db")
                Conn.Open()
                Using Comm As New System.Data.SQLite.SQLiteCommand(Conn)
                    Try
                        Comm.CommandText = "INSERT INTO Fornecedores VALUES (Null, @nome, @identificador, @endereco, @telefone, @celular, @email)"
                        Comm.Parameters.AddWithValue("@nome", nome)
                        Comm.Parameters.AddWithValue("@identificador", identificador)
                        Comm.Parameters.AddWithValue("@endereco", endereco)
                        Comm.Parameters.AddWithValue("@telefone", telefone)
                        Comm.Parameters.AddWithValue("@celular", celular)
                        Comm.Parameters.AddWithValue("@email", email)
                        Comm.ExecuteNonQuery()
                    Catch ex As Exception
                        MessageBox.Show("Erro ao adicionar: " & ex.Message)
                    End Try
                End Using
            End Using
            op = ""
            btnSalvar.Enabled = False
            btnCancelar.Enabled = False
            deactivateFields()
            clearFields()
            activeButtons()
            getFornecedores()
        Else
            MessageBox.Show("Preacha os campos obrigatórios (*)")
        End If
    End Sub
    Private Sub editFornecedor()
        If tbNome.Text.Length > 0 And tbIdentificador.Text.Length > 0 Then
            Dim nome = tbNome.Text.Trim
            Dim identificador = tbIdentificador.Text.Trim
            Dim endereco = tbEndereco.Text.Trim
            Dim telefone = mkTelefone.Text.Trim
            Dim celular = mkCelular.Text.Trim
            Dim email = tbEmail.Text.Trim
            Dim registro = tbRegistro.Text
            Using Conn As New System.Data.SQLite.SQLiteConnection("Data Source=C:\Users\Juan Farias\projetos\VB .NET\SistemaEstoqueVendas\Banco\SistemaEstoqueVendas.db")
                Conn.Open()
                Using Comm As New System.Data.SQLite.SQLiteCommand(Conn)
                    Try
                        Comm.CommandText = "UPDATE Fornecedores Set nome = @nome, 
                                            identificador = @identificador, 
                                            endereco = @endereco, 
                                            telefone = @telefone, 
                                            celular = @celular, 
                                            email = @email WHERE registro = @registro"
                        Comm.Parameters.AddWithValue("@nome", nome)
                        Comm.Parameters.AddWithValue("@identificador", identificador)
                        Comm.Parameters.AddWithValue("@endereco", endereco)
                        Comm.Parameters.AddWithValue("@telefone", telefone)
                        Comm.Parameters.AddWithValue("@celular", celular)
                        Comm.Parameters.AddWithValue("@email", email)
                        Comm.Parameters.AddWithValue("@registro", registro)
                        Comm.ExecuteNonQuery()
                    Catch ex As Exception
                        MessageBox.Show("Erro ao adicionar: " & ex.Message)
                    End Try
                End Using
            End Using
            op = ""
            btnSalvar.Enabled = False
            btnCancelar.Enabled = False
            deactivateFields()
            clearFields()
            activeButtons()
            getFornecedores()
        Else
            MessageBox.Show("Preacha os campos obrigatórios (*)")
        End If
    End Sub
    Private Sub delFornecedor()
        Dim dialog = MessageBox.Show("Deseja realmente excluir ?", "", MessageBoxButtons.YesNo)
        If dialog = DialogResult.Yes Then
            Dim registro = tbRegistro.Text
            Using Conn As New System.Data.SQLite.SQLiteConnection("Data Source=C:\Users\Juan Farias\projetos\VB .NET\SistemaEstoqueVendas\Banco\SistemaEstoqueVendas.db")
                Conn.Open()
                Using Comm As New System.Data.SQLite.SQLiteCommand(Conn)
                    Comm.CommandText = "DELETE FROM Fornecedores WHERE registro = @registro"
                    Comm.Parameters.AddWithValue("@registro", registro)
                    Comm.ExecuteNonQuery()
                End Using
            End Using
            clearFields()
            getFornecedores()
        End If
    End Sub
    Private Sub clearFields()
        tbRegistro.Clear()
        tbNome.Clear()
        tbIdentificador.Clear()
        tbEndereco.Clear()
        mkTelefone.Clear()
        mkCelular.Clear()
        tbEmail.Clear()
        tbNome.Select()
    End Sub
    Private Sub activeFields()
        tbNome.Enabled = True
        tbIdentificador.Enabled = True
        tbEndereco.Enabled = True
        mkTelefone.Enabled = True
        mkCelular.Enabled = True
        tbEmail.Enabled = True
    End Sub
    Private Sub deactivateFields()
        tbNome.Enabled = False
        tbIdentificador.Enabled = False
        tbEndereco.Enabled = False
        mkTelefone.Enabled = False
        mkCelular.Enabled = False
        tbEmail.Enabled = False
    End Sub
    Private Sub activeButtons()
        btnAdicionar.Enabled = True
        btnEditar.Enabled = True
        btnExcluir.Enabled = True
    End Sub
    Private Sub deactivateButtons()
        btnAdicionar.Enabled = False
        btnEditar.Enabled = False
        btnExcluir.Enabled = False
    End Sub
    Private Sub DataGridView1_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView1.CellClick
        If e.RowIndex <> -1 Then
            Dim selectedRow = DataGridView1.Rows(e.RowIndex)
            Dim registro = selectedRow.Cells("registro").Value
            Using Conn As New System.Data.SQLite.SQLiteConnection("Data Source=C:\Users\Juan Farias\projetos\VB .NET\SistemaEstoqueVendas\Banco\SistemaEstoqueVendas.db")
                Conn.Open()
                Using Comm As New System.Data.SQLite.SQLiteCommand(Conn)
                    Comm.CommandText = "SELECT * FROM Fornecedores WHERE registro = @registro"
                    Comm.Parameters.AddWithValue("@registro", registro)
                    Using Reader = Comm.ExecuteReader()
                        While Reader.Read()
                            tbRegistro.Text = Reader.Item("registro").ToString()
                            tbNome.Text = Reader.Item("nome").ToString()
                            tbIdentificador.Text = Reader.Item("identificador").ToString
                            tbEndereco.Text = Reader.Item("endereco").ToString
                            mkTelefone.Text = Reader.Item("telefone").ToString
                            mkCelular.Text = Reader.Item("celular").ToString
                            tbEmail.Text = Reader.Item("email").ToString
                        End While
                    End Using
                End Using
            End Using
        End If
    End Sub
    Private Sub btnCancelar_Click(sender As Object, e As EventArgs) Handles btnCancelar.Click
        btnCancelar.Enabled = False
        btnSalvar.Enabled = False
        clearFields()
        deactivateFields()
        activeButtons()
        getFornecedores()
    End Sub
    Private Sub btnExcluir_Click(sender As Object, e As EventArgs) Handles btnExcluir.Click
        If tbRegistro.Text.Length > 0 Then
            delFornecedor()
        Else
            MessageBox.Show("Selecione um Fornecedor para excluir")
        End If
    End Sub
    Private Sub btnEditar_Click(sender As Object, e As EventArgs) Handles btnEditar.Click
        If tbRegistro.Text.Length > 0 Then
            op = "edit"
            btnSalvar.Enabled = True
            btnCancelar.Enabled = True
            activeFields()
            deactivateButtons()
        Else
            MessageBox.Show("Selecione um Fornecedor para editar")
        End If
    End Sub
    Private Sub btnAdicionar_Click(sender As Object, e As EventArgs) Handles btnAdicionar.Click
        op = "add"
        btnSalvar.Enabled = True
        btnCancelar.Enabled = True
        activeFields()
        deactivateButtons()
        clearFields()
    End Sub
    Private Sub btnSalvar_Click(sender As Object, e As EventArgs) Handles btnSalvar.Click
        If op.Equals("add") Then
            addFornecedor()
        ElseIf op.Equals("edit") Then
            editFornecedor()
        End If
    End Sub
    Private Sub btnPesquisar_Click(sender As Object, e As EventArgs) Handles btnPesquisar.Click
        searchFornecedor()
    End Sub
End Class