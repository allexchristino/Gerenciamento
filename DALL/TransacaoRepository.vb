Imports System.Data
Imports Microsoft.Data.SqlClient

Public Class TransacaoRepository

    Public Sub Inserir(numeroCartao As String, valor As Decimal, descricao As String, status As String)

        Dim query As String = "INSERT INTO Transacoes (Numero_Cartao, Valor_Transacao, Descricao, Status_Transacao) " &
                              "VALUES (@NumeroCartao, @Valor, @Descricao, @Status)"

        Using conn As SqlConnection = ConexaoBanco.ObterConexao()
            Using cmd As New SqlCommand(query, conn)
                cmd.Parameters.AddWithValue("@NumeroCartao", numeroCartao)
                cmd.Parameters.AddWithValue("@Valor", valor)
                cmd.Parameters.AddWithValue("@Descricao", descricao)
                cmd.Parameters.AddWithValue("@Status", status)

                conn.Open()
                cmd.ExecuteNonQuery()
            End Using
        End Using
    End Sub

    Public Sub Atualizar(id As Integer, valor As Decimal, status As String)
        Dim query As String = "UPDATE Transacoes SET Valor_Transacao = @Valor, Status_Transacao = @Status " &
                              "WHERE Id_Transacao = @Id"

        Using conn As SqlConnection = ConexaoBanco.ObterConexao()
            Using cmd As New SqlCommand(query, conn)
                cmd.Parameters.AddWithValue("@Valor", valor)
                cmd.Parameters.AddWithValue("@Status", status)
                cmd.Parameters.AddWithValue("@Id", id)

                conn.Open()
                cmd.ExecuteNonQuery()
            End Using
        End Using
    End Sub

    Public Sub Excluir(id As Integer)
        Dim query As String = "DELETE FROM Transacoes WHERE Id_Transacao = @Id"

        Using conn As SqlConnection = ConexaoBanco.ObterConexao()
            Using cmd As New SqlCommand(query, conn)
                cmd.Parameters.AddWithValue("@Id", id)
                conn.Open()
                cmd.ExecuteNonQuery()
            End Using
        End Using
    End Sub

    Public Function ConsultarPaginado(pagina As Integer, tamanhoPagina As Integer, filtroCartao As String, filtroStatus As String, dataInicio As DateTime, dataFim As DateTime) As DataTable
        Dim dt As New DataTable()

        Dim query As String = "
            SELECT Id_Transacao, Numero_Cartao, Valor_Transacao, Data_Transacao, Descricao, Status_Transacao 
            FROM Transacoes 
            WHERE (@Cartao IS NULL OR Numero_Cartao LIKE '%' + @Cartao + '%')
              AND (@Status IS NULL OR Status_Transacao = @Status)
              AND (Data_Transacao >= @DataInicio AND Data_Transacao <= @DataFim)
            ORDER BY Data_Transacao DESC 
            OFFSET @Offset ROWS FETCH NEXT @TamanhoPagina ROWS ONLY"

        Using conn As SqlConnection = ConexaoBanco.ObterConexao()
            Using cmd As New SqlCommand(query, conn)
                cmd.Parameters.AddWithValue("@Cartao", If(String.IsNullOrWhiteSpace(filtroCartao), DBNull.Value, filtroCartao))
                cmd.Parameters.AddWithValue("@Status", If(String.IsNullOrWhiteSpace(filtroStatus) OrElse filtroStatus = "Todos", DBNull.Value, filtroStatus))
                cmd.Parameters.AddWithValue("@DataInicio", dataInicio)
                cmd.Parameters.AddWithValue("@DataFim", dataFim)

                cmd.Parameters.AddWithValue("@Offset", (pagina - 1) * tamanhoPagina)
                cmd.Parameters.AddWithValue("@TamanhoPagina", tamanhoPagina)

                conn.Open()

                Using reader As SqlDataReader = cmd.ExecuteReader()
                    dt.Load(reader)
                End Using
            End Using
        End Using

        Return dt
    End Function

    Public Function ObterStatus(id As Integer) As String
        Dim query As String = "SELECT Status_Transacao FROM Transacoes WHERE Id_Transacao = @Id"

        Using conn As SqlConnection = ConexaoBanco.ObterConexao()
            Using cmd As New SqlCommand(query, conn)
                cmd.Parameters.AddWithValue("@Id", id)
                conn.Open()

                Dim resultado = cmd.ExecuteScalar()
                Return If(resultado IsNot Nothing, resultado.ToString(), String.Empty)
            End Using
        End Using
    End Function


    Public Function ObterDadosParaExportacaoUltimoMes() As SqlDataReader
        Dim conexao As SqlConnection = ConexaoBanco.ObterConexao()

        Dim query As String = "SELECT Id_Transacao, Numero_Cartao, Valor_Transacao, Data_Transacao, Descricao, Status_Transacao " &
                      "FROM Transacoes " &
                      "WHERE Data_Transacao >= DATEADD(month, DATEDIFF(month, 0, GETDATE()) - 1, 0) " &
                      "  AND Data_Transacao < DATEADD(month, DATEDIFF(month, 0, GETDATE()), 0) " &
                      "ORDER BY Data_Transacao DESC"

        Dim comando As New SqlCommand(query, conexao)

        Try
            conexao.Open()
            Return comando.ExecuteReader(CommandBehavior.CloseConnection)
        Catch ex As Exception
            conexao.Dispose()
            Throw
        End Try
    End Function
End Class