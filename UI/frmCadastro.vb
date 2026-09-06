Imports System.Windows.Forms

Public Class frmCadastro
    Private ReadOnly _service As New TransacaoService()
    Private _idTransacao As Integer = 0 ' Se for 0, é Inserção. Se > 0, é Edição.

    Public Sub New()
        InitializeComponent()
        cbStatus.Items.AddRange(New String() {"Pendente", "Aprovada", "Cancelada"})
        cbStatus.SelectedIndex = 0
    End Sub

    Public Sub New(id As Integer, cartao As String, valor As String, descricao As String, status As String)
        InitializeComponent()
        cbStatus.Items.AddRange(New String() {"Pendente", "Aprovada", "Cancelada"})

        _idTransacao = id
        txtCartao.Text = cartao
        txtValor.Text = valor
        txtDescricao.Text = descricao
        cbStatus.Text = status

        If status = "Aprovada" Then
            btnSalvar.Enabled = False
            lblAviso.Text = "Transações aprovadas não podem ser alteradas."
        End If
    End Sub

    Private Sub btnSalvar_Click(sender As Object, e As EventArgs) Handles btnSalvar.Click
        Try
            Dim valor As Decimal = Convert.ToDecimal(txtValor.Text)

            If _idTransacao = 0 Then
                _service.Cadastrar(txtCartao.Text, valor, txtDescricao.Text, cbStatus.Text)
                MessageBox.Show("Cadastrado com sucesso!", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Else
                _service.Editar(_idTransacao, valor, cbStatus.Text)
                MessageBox.Show("Atualizado com sucesso!", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information)
            End If

            Me.DialogResult = DialogResult.OK
            Me.Close()
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        End Try
    End Sub
End Class