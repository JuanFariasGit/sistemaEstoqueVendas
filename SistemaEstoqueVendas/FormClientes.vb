Public Class FormClientes
    Private op As String
    Private Sub FormClientes_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        getClientes()
    End Sub
    Private Sub getClientes()
        DataGridView1.Rows.Clear()
        Using Conn As New System.Data.SQLite.SQLiteConnection("Data Source=C:\Users\Juan Farias\projetos\VB .NET\SistemaEstoqueVendas\Banco\SistemaEstoqueVendas.db")
            Conn.Open()
            Using Comm As New System.Data.SQLite.SQLiteCommand(Conn)
                Comm.CommandText = "SELECT * FROM Clientes"
                Using Reader = Comm.ExecuteReader()
                    While Reader.Read()
                        DataGridView1.Rows.Add(Reader.Item("codigo").ToString,
                                               Reader.Item("nome").ToString,
                                               Reader.Item("identificador").ToString)
                    End While
                End Using
            End Using
        End Using
    End Sub
    Private Sub searchCliente()
        Dim searchValue = tbPesquisar.Text.Trim()
        DataGridView1.Rows.Clear()
        Using Conn As New System.Data.SQLite.SQLiteConnection("Data Source=C:\Users\Juan Farias\projetos\VB .NET\SistemaEstoqueVendas\Banco\SistemaEstoqueVendas.db")
            Conn.Open()
            Using Comm As New System.Data.SQLite.SQLiteCommand(Conn)
                Comm.CommandText = "SELECT * FROM Clientes WHERE nome LIKE @searchValue OR identificador LIKE @identificador"
                Comm.Parameters.AddWithValue("@searchValue", "%" + searchValue + "%")
                Comm.Parameters.AddWithValue("@identificador", "%" + searchValue + "%")
                Using Reader = Comm.ExecuteReader()
                    While Reader.Read()
                        DataGridView1.Rows.Add(Reader.Item("codigo").ToString,
                                               Reader.Item("nome").ToString,
                                               Reader.Item("identificador").ToString)
                    End While
                End Using
            End Using
        End Using
    End Sub
    Private Sub addCliente()
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
                        Comm.CommandText = "INSERT INTO Clientes VALUES (Null, @nome, @identificador, @endereco, @telefone, @celular, @email)"
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
            deactivateFields()
            clearFields()
            getClientes()
        Else
            MessageBox.Show("Preacha os campos obrigatórios (*)")
        End If
    End Sub
    Private Sub editCliente()
        If tbNome.Text.Length > 0 And tbIdentificador.Text.Length > 0 Then
            Dim nome = tbNome.Text.Trim
            Dim identificador = tbIdentificador.Text.Trim
            Dim endereco = tbEndereco.Text.Trim
            Dim telefone = mkTelefone.Text.Trim
            Dim celular = mkCelular.Text.Trim
            Dim email = tbEmail.Text.Trim
            Dim codigo = tbCodigo.Text
            Using Conn As New System.Data.SQLite.SQLiteConnection("Data Source=C:\Users\Juan Farias\projetos\VB .NET\SistemaEstoqueVendas\Banco\SistemaEstoqueVendas.db")
                Conn.Open()
                Using Comm As New System.Data.SQLite.SQLiteCommand(Conn)
                    Try
                        Comm.CommandText = "UPDATE Clientes Set nome = @nome, 
                                            identificador = @identificador, 
                                            endereco = @endereco, 
                                            telefone = @telefone, 
                                            celular = @celular, 
                                            email = @email WHERE codigo = @codigo"
                        Comm.Parameters.AddWithValue("@nome", nome)
                        Comm.Parameters.AddWithValue("@identificador", identificador)
                        Comm.Parameters.AddWithValue("@endereco", endereco)
                        Comm.Parameters.AddWithValue("@telefone", telefone)
                        Comm.Parameters.AddWithValue("@celular", celular)
                        Comm.Parameters.AddWithValue("@email", email)
                        Comm.Parameters.AddWithValue("@codigo", codigo)
                        Comm.ExecuteNonQuery()
                    Catch ex As Exception
                        MessageBox.Show("Erro ao adicionar: " & ex.Message)
                    End Try
                End Using
            End Using
            deactivateFields()
            clearFields()
            getClientes()
        Else
            MessageBox.Show("Preacha os campos obrigatórios (*)")
        End If
    End Sub
    Private Sub delCliente()
        Dim dialog = MessageBox.Show("Deseja realmente excluir ?", "", MessageBoxButtons.YesNo)
        If dialog = DialogResult.Yes Then
            Dim codigo = tbCodigo.Text
            Using Conn As New System.Data.SQLite.SQLiteConnection("Data Source=C:\Users\Juan Farias\projetos\VB .NET\SistemaEstoqueVendas\Banco\SistemaEstoqueVendas.db")
                Conn.Open()
                Using Comm As New System.Data.SQLite.SQLiteCommand(Conn)
                    Comm.CommandText = "DELETE FROM Clientes WHERE codigo = @codigo"
                    Comm.Parameters.AddWithValue("@codigo", codigo)
                    Comm.ExecuteNonQuery()
                End Using
            End Using
            clearFields()
            getClientes()
        End If
    End Sub
    Private Sub clearFields()
        tbCodigo.Clear()
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
    Private Sub DataGridView1_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView1.CellClick
        If e.RowIndex <> -1 Then
            Dim selectedRow = DataGridView1.Rows(e.RowIndex)
            Dim codigo = selectedRow.Cells("codigo").Value
            Using Conn As New System.Data.SQLite.SQLiteConnection("Data Source=C:\Users\Juan Farias\projetos\VB .NET\SistemaEstoqueVendas\Banco\SistemaEstoqueVendas.db")
                Conn.Open()
                Using Comm As New System.Data.SQLite.SQLiteCommand(Conn)
                    Comm.CommandText = "SELECT * FROM Clientes WHERE codigo = @codigo"
                    Comm.Parameters.AddWithValue("@codigo", codigo)
                    Using Reader = Comm.ExecuteReader()
                        While Reader.Read()
                            tbCodigo.Text = Reader.Item("codigo").ToString()
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
        clearFields()
        deactivateFields()
        getClientes()
    End Sub
    Private Sub btnExcluir_Click(sender As Object, e As EventArgs) Handles btnExcluir.Click
        If tbCodigo.Text.Length > 0 Then
            delCliente()
        Else
            MessageBox.Show("Selecione um cliente para excluir")
        End If
    End Sub
    Private Sub btnEditar_Click(sender As Object, e As EventArgs) Handles btnEditar.Click
        If tbCodigo.Text.Length > 0 Then
            op = "edit"
            btnCancelar.Enabled = True
            activeFields()
        Else
            MessageBox.Show("Selecione um cliente para editar")
        End If
    End Sub
    Private Sub btnAdicionar_Click(sender As Object, e As EventArgs) Handles btnAdicionar.Click
        op = "add"
        btnCancelar.Enabled = True
        activeFields()
        clearFields()
    End Sub
    Private Sub btnSalvar_Click(sender As Object, e As EventArgs) Handles btnSalvar.Click
        If op.Equals("add") Then
            addCliente()
        ElseIf op.Equals("edit") Then
            editCliente()
        End If
        op = ""
        btnCancelar.Enabled = False
    End Sub

    Private Sub btnPesquisar_Click(sender As Object, e As EventArgs) Handles btnPesquisar.Click
        searchCliente()
    End Sub
End Class