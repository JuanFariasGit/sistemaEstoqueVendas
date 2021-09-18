Public Class FormClientes
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
                        DataGridView1.Rows.Add(Reader.Item("nome").ToString,
                                               Reader.Item("identificador").ToString)
                    End While
                End Using
            End Using
        End Using
    End Sub
    Private Sub clearFields()
        tbNome.Clear()
        tbIdentificador.Clear()
        tbEndereco.Clear()
        mkTelefone.Clear()
        mkCelular.Clear()
        tbEmail.Clear()
        tbNome.Select()
    End Sub
    Private Sub btnAdicionar_Click(sender As Object, e As EventArgs) Handles btnAdicionar.Click
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
                        Comm.CommandText = "INSERT INTO Clientes VALUES (@nome, @identificador, @endereco, @telefone, @celular, @email)"
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
            clearFields()
            getClientes()
        Else
            MessageBox.Show("Preacha os campos obrigatórios (*)")
        End If
    End Sub
    Private Sub DataGridView1_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView1.CellClick
        If e.RowIndex <> -1 Then
            Dim selectedRow = DataGridView1.Rows(e.RowIndex)
            Dim identificador = selectedRow.Cells(1).Value
            Using Conn As New System.Data.SQLite.SQLiteConnection("Data Source=C:\Users\Juan Farias\projetos\VB .NET\SistemaEstoqueVendas\Banco\SistemaEstoqueVendas.db")
                Conn.Open()
                Using Comm As New System.Data.SQLite.SQLiteCommand(Conn)
                    Comm.CommandText = "SELECT * FROM Clientes WHERE identificador = @identificador"
                    Comm.Parameters.AddWithValue("@identificador", identificador)
                    Using Reader = Comm.ExecuteReader()
                        While Reader.Read()
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
            btnAdicionar.Enabled = False
            btnEditar.Enabled = True
            btnExcluir.Enabled = True
            btnCancelar.Enabled = True
        End If
    End Sub
    Private Sub btnCancelar_Click(sender As Object, e As EventArgs) Handles btnCancelar.Click
        btnAdicionar.Enabled = True
        btnEditar.Enabled = False
        btnExcluir.Enabled = False
        btnCancelar.Enabled = False
        clearFields()
        getClientes()
    End Sub
    Private Sub btnExcluir_Click(sender As Object, e As EventArgs) Handles btnExcluir.Click
        Dim dialog = MessageBox.Show("Deseja realmente excluir ?", "", MessageBoxButtons.YesNo)
        If dialog = DialogResult.Yes Then
            Dim identificador = tbIdentificador.Text.Trim
            If identificador.Length > 0 Then
                Using Conn As New System.Data.SQLite.SQLiteConnection("Data Source=C:\Users\Juan Farias\projetos\VB .NET\SistemaEstoqueVendas\Banco\SistemaEstoqueVendas.db")
                    Conn.Open()
                    Using Comm As New System.Data.SQLite.SQLiteCommand(Conn)
                        Comm.CommandText = "DELETE FROM Clientes WHERE identificador = @identificador"
                        Comm.Parameters.AddWithValue("@identificador", identificador)
                        Comm.ExecuteNonQuery()
                    End Using
                End Using
                btnAdicionar.Enabled = True
                btnEditar.Enabled = False
                btnExcluir.Enabled = False
                btnCancelar.Enabled = False
                clearFields()
                getClientes()
            Else
                MessageBox.Show("Informe o CPF / CNPJ")
            End If
        End If
    End Sub
End Class