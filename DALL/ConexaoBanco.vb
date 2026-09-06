
Imports System.Configuration
Imports Microsoft.Data.SqlClient

Public Class ConexaoBanco

    Public Shared ReadOnly Property StringConexao As String
        Get
            Dim config As String = ConfigurationManager.ConnectionStrings("GerenciamentoDB")?.ConnectionString
            If String.IsNullOrEmpty(config) Then
                Throw New Exception("A string de conexão 'GerenciamentoDB' não foi encontrada no App.config.")
            End If
            Return config
        End Get
    End Property

    Public Shared Function ObterConexao() As SqlConnection
        Return New SqlConnection(StringConexao)
    End Function

End Class


