Imports System.Data.SQLite
Public Class FormClientes
    Private op As String
    Private Gl As New Globais
    Private Conn As New SQLiteConnection("Data Source=" & Gl.caminhoBanco.ToString())
    Private Comm As New SQLiteCommand(Conn)
    Private Sub FormClientes_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        getClientes()
    End Sub
    Private Sub getClientes()
        DataGridView1.Rows.Clear()
        Conn.Open()
        Comm.CommandText = "SELECT registro, nome, identificador FROM Clientes"
        Using Reader = Comm.ExecuteReader()
            While Reader.Read()
                DataGridView1.Rows.Add(Reader.Item("registro").ToString,
                                               Reader.Item("nome").ToString,
                                               Reader.Item("identificador").ToString)
            End While
        End Using
        Conn.Close()
    End Sub
    Private Sub searchCliente()
        Dim searchValue = tbPesquisar.Text.Trim()
        DataGridView1.Rows.Clear()
        Conn.Open()
        Comm.CommandText = "SELECT registro, nome, identificador FROM Clientes WHERE nome LIKE @searchValue OR identificador LIKE @searchValue"
        Comm.Parameters.AddWithValue("@searchValue", "%" & searchValue & "%")
        Using Reader = Comm.ExecuteReader()
            While Reader.Read()
                DataGridView1.Rows.Add(Reader.Item("registro").ToString,
                                               Reader.Item("nome").ToString,
                                               Reader.Item("identificador").ToString)
            End While
        End Using
        Conn.Close()
    End Sub
    Private Sub addCliente()
        If tbNome.Text.Length > 0 And tbIdentificador.Text.Length > 0 Then
            Dim nome = tbNome.Text.Trim
            Dim identificador = tbIdentificador.Text.Trim
            Dim endereco = tbEndereco.Text.Trim
            Dim telefone = mkTelefone.Text.Trim
            Dim celular = mkCelular.Text.Trim
            Dim email = tbEmail.Text.Trim
            Try
                Conn.Open()
                Comm.CommandText = "INSERT INTO Clientes VALUES (Null, @nome, @identificador, @endereco, @telefone, @celular, @email)"
                Comm.Parameters.AddWithValue("@nome", nome)
                Comm.Parameters.AddWithValue("@identificador", identificador)
                Comm.Parameters.AddWithValue("@endereco", endereco)
                Comm.Parameters.AddWithValue("@telefone", telefone)
                Comm.Parameters.AddWithValue("@celular", celular)
                Comm.Parameters.AddWithValue("@email", email)
                Comm.ExecuteNonQuery()
            Catch ex As Exception
                Dim mesagem = ex.Message
                If mesagem.EndsWith("Clientes.nome") Then
                    MessageBox.Show("Já existe um cliente com esse Nome / Razão social", "", MessageBoxButtons.OK, MessageBoxIcon.Error)
                ElseIf mesagem.EndsWith("Clientes.identificador") Then
                    MessageBox.Show("Já existe um cliente com esse CPF / CNPJ", "", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Else
                    MessageBox.Show("Erro ao adicionar: " & ex.Message, "", MessageBoxButtons.OK, MessageBoxIcon.Error)
                End If
            Finally
                Conn.Close()
            End Try
            op = ""
            btnSalvar.Enabled = False
            btnCancelar.Enabled = False
            DataGridView1.Enabled = True
            deactivateFields()
            clearFields()
            activeButtons()
            getClientes()
        Else
            MessageBox.Show("Preencha os campos obrigatórios (*)", "", MessageBoxButtons.OK, MessageBoxIcon.Information)
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
            Dim registro = tbRegistro.Text
            Try
                Conn.Open()
                Comm.CommandText = "UPDATE Clientes Set nome = @nome, 
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
                Dim mesagem = ex.Message
                If mesagem.EndsWith("Clientes.nome") Then
                    MessageBox.Show("Já existe um cliente com esse Nome / Razão social", "", MessageBoxButtons.OK, MessageBoxIcon.Error)
                ElseIf mesagem.EndsWith("Clientes.identificador") Then
                    MessageBox.Show("Já existe um cliente com esse CPF / CNPJ", "", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Else
                    MessageBox.Show("Erro ao atualizar: " & ex.Message, "", MessageBoxButtons.OK, MessageBoxIcon.Error)
                End If
            Finally
                Conn.Close()
            End Try
            op = ""
            btnSalvar.Enabled = False
            btnCancelar.Enabled = False
            deactivateFields()
            clearFields()
            activeButtons()
            getClientes()
        Else
            MessageBox.Show("Preencha os campos obrigatórios (*)", "", MessageBoxButtons.OK, MessageBoxIcon.Information)
        End If
    End Sub
    Private Sub delCliente()
        Dim dialog = MessageBox.Show("Deseja realmente excluir ?", "", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
        If dialog = DialogResult.Yes Then
            Dim registro = tbRegistro.Text
            Try
                Conn.Open()
                Comm.CommandText = "DELETE FROM Clientes WHERE registro = @registro"
                Comm.Parameters.AddWithValue("@registro", registro)
                Comm.ExecuteNonQuery()
            Catch ex As Exception
                MessageBox.Show("Erro ao excluir: " & ex.Message, "", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Finally
                Conn.Close()
            End Try
            clearFields()
            getClientes()
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
    End Sub
    Private Sub activeFields()
        tbNome.Enabled = True
        tbIdentificador.Enabled = True
        tbEndereco.Enabled = True
        mkTelefone.Enabled = True
        mkCelular.Enabled = True
        tbEmail.Enabled = True
        tbNome.Focus()
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
            Conn.Open()
            Comm.CommandText = "SELECT * FROM Clientes WHERE registro = @registro"
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
            Conn.Close()
        End If
    End Sub
    Private Sub btnCancelar_Click(sender As Object, e As EventArgs) Handles btnCancelar.Click
        btnCancelar.Enabled = False
        btnSalvar.Enabled = False
        DataGridView1.Enabled = True
        clearFields()
        deactivateFields()
        activeButtons()
        getClientes()
    End Sub
    Private Sub btnExcluir_Click(sender As Object, e As EventArgs) Handles btnExcluir.Click
        If tbRegistro.Text.Length > 0 Then
            delCliente()
        Else
            MessageBox.Show("Selecione um cliente para excluir", "", MessageBoxButtons.OK, MessageBoxIcon.Information)
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
            MessageBox.Show("Selecione um cliente para editar", "", MessageBoxButtons.OK, MessageBoxIcon.Information)
        End If
    End Sub
    Private Sub btnAdicionar_Click(sender As Object, e As EventArgs) Handles btnAdicionar.Click
        op = "add"
        btnSalvar.Enabled = True
        btnCancelar.Enabled = True
        DataGridView1.Enabled = False
        activeFields()
        deactivateButtons()
        clearFields()
    End Sub
    Private Sub btnSalvar_Click(sender As Object, e As EventArgs) Handles btnSalvar.Click
        If op.Equals("add") Then
            addCliente()
        ElseIf op.Equals("edit") Then
            editCliente()
        End If
    End Sub
    Private Sub btnPesquisar_Click(sender As Object, e As EventArgs) Handles btnPesquisar.Click
        searchCliente()
    End Sub
End Class