Imports System.Data
Imports System.IO
Imports System.Text
Imports Microsoft.Data.SqlClient

Public Class TransacaoService
    Private ReadOnly _repository As New TransacaoRepository()

    Public Sub Cadastrar(cartao As String, valor As Decimal, descricao As String, status As String)
        If String.IsNullOrWhiteSpace(cartao) OrElse cartao.Length <> 16 Then
            Throw New ArgumentException("O número do cartão deve conter exatamente 16 dígitos.")
        End If
        If valor <= 0 Then
            Throw New ArgumentException("O valor da transação deve ser estritamente positivo.")
        End If

        _repository.Inserir(cartao, valor, descricao, status)
    End Sub

    Public Sub Editar(id As Integer, valor As Decimal, status As String)
        Dim statusAtual As String = _repository.ObterStatus(id)

        If statusAtual.Equals("Aprovada", StringComparison.OrdinalIgnoreCase) Then
            Throw New InvalidOperationException("Transações com status 'Aprovada' não podem ser editadas por motivos de compliance.")
        End If

        _repository.Atualizar(id, valor, status)
    End Sub

    Public Sub Remover(id As Integer)
        Try
            _repository.Excluir(id)
        Catch ex As Exception
            RegistrarLogErro($"Erro ao tentar excluir a transação ID {id}. Detalhes técnicos: {ex.Message}")
            Throw New ApplicationException("Não foi possível excluir a transação no momento. O erro foi registrado no log do sistema.")
        End Try
    End Sub

    Public Function Consultar(pagina As Integer, tamanhoPagina As Integer, filtroCartao As String, filtroStatus As String, dataInicio As DateTime, dataFim As DateTime) As DataTable
        Return _repository.ConsultarPaginado(pagina, tamanhoPagina, filtroCartao, filtroStatus, dataInicio, dataFim)
    End Function


    Public Sub ExportarRelatorioCSV(caminhoArquivo As String)
        Try
            Using reader As SqlDataReader = _repository.ObterDadosParaExportacaoUltimoMes()
                Using writer As New StreamWriter(caminhoArquivo, False, New System.Text.UTF8Encoding(True))

                    Dim cabecalhos As New List(Of String)
                    For i As Integer = 0 To reader.FieldCount - 1
                        cabecalhos.Add(reader.GetName(i))
                    Next
                    writer.WriteLine(String.Join(";", cabecalhos))

                    While reader.Read()
                        Dim linha As New List(Of String)
                        For i As Integer = 0 To reader.FieldCount - 1
                            linha.Add(reader.GetValue(i).ToString())
                        Next
                        writer.WriteLine(String.Join(";", linha))
                    End While
                End Using
            End Using

        Catch ex As Exception
            RegistrarLogErro($"Falha na exportação de arquivo CSV: {ex.Message}")
            Throw New ApplicationException("Ocorreu um erro ao gerar o arquivo de exportação. Verifique se o arquivo não está aberto em outro programa.")
        End Try
    End Sub

    Private Sub RegistrarLogErro(mensagem As String)
        Try
            Dim caminhoLog As String = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "erros_sistema.log")
            Dim textoLog As String = $"[{DateTime.Now:dd/MM/yyyy HH:mm:ss}] {mensagem}{Environment.NewLine}"
            File.AppendAllText(caminhoLog, textoLog)
        Catch
            ' Falha silenciosa: se o sistema não tiver permissão para escrever o log, 
            ' ele não deve travar a aplicação inteira do usuário.
        End Try
    End Sub

End Class
