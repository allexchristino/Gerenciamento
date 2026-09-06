Imports System.Windows.Forms

Public Class frmTransacoes
    Private ReadOnly _service As New TransacaoService()

    Private _paginaAtual As Integer = 1
    Private Const _tamanhoPagina As Integer = 50

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        cbFiltroStatus.Items.AddRange(New String() {"Todos", "Aprovada", "Pendente", "Cancelada"})
        cbFiltroStatus.SelectedIndex = 0

        CarregarMalha()
    End Sub

    Private Sub CarregarMalha()
        Try
            Dim dt = _service.Consultar(
                _paginaAtual,
                _tamanhoPagina,
                txtFiltroCartao.Text.Trim(),
                cbFiltroStatus.Text,
                dtpInicio.Value.Date,
                dtpFim.Value.Date.AddDays(1).AddTicks(-1)
            )
            dgvTransacoes.DataSource = dt
            ConfigurarColunasGrid()

            lblPagina.Text = $"Página: {_paginaAtual}"
            btnPaginaAnterior.Enabled = (_paginaAtual > 1)
            Dim atingiuLimitePagina As Boolean = (dt.Rows.Count = _tamanhoPagina)
            btnProximaPagina.Enabled = atingiuLimitePagina
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Erro ao carregar dados", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Sub

    Private Sub ConfigurarColunasGrid()

        dgvTransacoes.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill

        If dgvTransacoes.Columns("Id_Transacao") IsNot Nothing Then
            dgvTransacoes.Columns("Id_Transacao").HeaderText = "ID"
            dgvTransacoes.Columns("Id_Transacao").FillWeight = 40
        End If

        If dgvTransacoes.Columns("Numero_Cartao") IsNot Nothing Then
            dgvTransacoes.Columns("Numero_Cartao").HeaderText = "Número do Cartão"
            dgvTransacoes.Columns("Numero_Cartao").FillWeight = 120
        End If

        If dgvTransacoes.Columns("Valor_Transacao") IsNot Nothing Then
            dgvTransacoes.Columns("Valor_Transacao").HeaderText = "Valor (R$)"
            dgvTransacoes.Columns("Valor_Transacao").FillWeight = 80

            dgvTransacoes.Columns("Valor_Transacao").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        End If

        If dgvTransacoes.Columns("Data_Transacao") IsNot Nothing Then
            dgvTransacoes.Columns("Data_Transacao").HeaderText = "Data da Transação"
            dgvTransacoes.Columns("Data_Transacao").FillWeight = 90
        End If

        If dgvTransacoes.Columns("Descricao") IsNot Nothing Then
            dgvTransacoes.Columns("Descricao").HeaderText = "Descrição / Histórico"
            dgvTransacoes.Columns("Descricao").FillWeight = 180
        End If

        If dgvTransacoes.Columns("Status_Transacao") IsNot Nothing Then
            dgvTransacoes.Columns("Status_Transacao").HeaderText = "Status"
            dgvTransacoes.Columns("Status_Transacao").FillWeight = 80
            dgvTransacoes.Columns("Status_Transacao").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
        End If
    End Sub

    Private Sub btnFiltrar_Click(sender As Object, e As EventArgs) Handles btnFiltrar.Click
        _paginaAtual = 1
        CarregarMalha()
    End Sub

    Private Sub btnCadastrar_Click(sender As Object, e As EventArgs) Handles btnCadastrar.Click
        Dim formCadastro As New frmCadastro()
        If formCadastro.ShowDialog() = DialogResult.OK Then
            CarregarMalha()
        End If
    End Sub

    Private Sub btnEditar_Click(sender As Object, e As EventArgs) Handles btnEditar.Click
        If dgvTransacoes.CurrentRow Is Nothing Then
            MessageBox.Show("Selecione uma transação para editar.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Return
        End If

        Dim id = Convert.ToInt32(dgvTransacoes.CurrentRow.Cells("Id_Transacao").Value)
        Dim cartao = dgvTransacoes.CurrentRow.Cells("Numero_Cartao").Value.ToString()
        Dim valor = dgvTransacoes.CurrentRow.Cells("Valor_Transacao").Value.ToString()
        Dim desc = dgvTransacoes.CurrentRow.Cells("Descricao").Value.ToString()
        Dim status = dgvTransacoes.CurrentRow.Cells("Status_Transacao").Value.ToString()

        Dim formEdicao As New frmCadastro(id, cartao, valor, desc, status)
        If formEdicao.ShowDialog() = DialogResult.OK Then
            CarregarMalha()
        End If
    End Sub

    Private Sub btnExcluir_Click(sender As Object, e As EventArgs) Handles btnExcluir.Click

        If dgvTransacoes.CurrentRow Is Nothing Then
            MessageBox.Show("Selecione uma transação para excluir.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Return
        End If

        Dim idSelecionado As Integer = Convert.ToInt32(dgvTransacoes.CurrentRow.Cells("Id_Transacao").Value)

        Dim confirmacao = MessageBox.Show($"Deseja realmente excluir a transação ID {idSelecionado}?", "Confirmação", MessageBoxButtons.YesNo, MessageBoxIcon.Question)

        If confirmacao = DialogResult.Yes Then
            Try
                _service.Remover(idSelecionado)
                MessageBox.Show("Excluída com sucesso!", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information)
                CarregarMalha()
            Catch ex As Exception
                MessageBox.Show(ex.Message, "Erro na Exclusão", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
        End If
    End Sub

    Private Sub btnExportar_Click(sender As Object, e As EventArgs) Handles btnExportar.Click
        Try
            Using sfd As New SaveFileDialog()
                sfd.Filter = "Arquivo CSV (*.csv)|*.csv"
                sfd.FileName = $"Transacoes_{DateTime.Now:yyyyMMdd}.csv"

                If sfd.ShowDialog() = DialogResult.OK Then
                    _service.ExportarRelatorioCSV(sfd.FileName)
                    MessageBox.Show("Relatório exportado com sucesso!", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information)
                End If
            End Using
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Erro na Exportação", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub btnPaginaAnterior_Click(sender As Object, e As EventArgs) Handles btnPaginaAnterior.Click
        If _paginaAtual > 1 Then
            _paginaAtual -= 1
            CarregarMalha()
        End If
    End Sub

    Private Sub btnProximaPagina_Click(sender As Object, e As EventArgs) Handles btnProximaPagina.Click
        _paginaAtual += 1
        CarregarMalha()
    End Sub

    Private Sub dgvTransacoes_CellFormatting(sender As Object, e As DataGridViewCellFormattingEventArgs) Handles dgvTransacoes.CellFormatting
        If dgvTransacoes.Columns(e.ColumnIndex).Name = "Status_Transacao" AndAlso e.Value IsNot Nothing Then
            Dim status As String = e.Value.ToString()
            If status = "Aprovada" Then
                e.CellStyle.BackColor = Color.LightGreen
            ElseIf status = "Cancelada" Then
                e.CellStyle.BackColor = Color.LightCoral
            ElseIf status = "Pendente" Then
                e.CellStyle.BackColor = Color.LightYellow
            End If
        End If
        If dgvTransacoes.Columns(e.ColumnIndex).Name = "Numero_Cartao" AndAlso e.Value IsNot Nothing Then
            Dim cartaoOriginal As String = e.Value.ToString()

            If cartaoOriginal.Length = 16 Then

                Dim parteInicio As String = cartaoOriginal.Substring(0, 4)
                Dim parteFim As String = cartaoOriginal.Substring(12, 4)

                e.Value = $"{parteInicio} ******** {parteFim}"
                e.FormattingApplied = True
            End If
        End If
    End Sub
End Class
