Imports Microsoft.VisualBasic
Imports System
Imports System.Data
Imports System.Data.SqlClient
Imports System.Configuration.ConfigurationManager


Public Class clsDataAccess

    Private _Conn As String = ConfigurationManager.ConnectionStrings("ASBKEOConnectionString").ToString
    Private _SqlConnect As SqlConnection
    Private _SqlCommand As SqlCommand
    Private _SqlAdapter As SqlDataAdapter
    Private _CommandBuilder As SqlCommandBuilder
    Private _Transaction As SqlTransaction

    Public Function DataAdapter_Select(ByVal SqlStr As String) As DataTable
        Try
            Dim Dt As New DataTable

            _SqlConnect = New SqlConnection(_Conn)
            _SqlCommand = New SqlCommand(SqlStr.Trim, _SqlConnect)
            _SqlCommand.CommandTimeout = 10000
            _SqlAdapter = New SqlDataAdapter(_SqlCommand)

            _SqlAdapter.Fill(Dt)
            Return Dt

        Catch ex As Exception
            Throw New Exception("Select_DataAdapter : " & ex.Message)
        End Try



    End Function

    Public Function DataAdapter_Insert(ByVal SqlStr As String, ByVal Dt As DataTable) As Boolean
        Try
            Dim result As Integer

            _SqlConnect = New SqlConnection(_Conn)
            _SqlCommand = New SqlCommand(SqlStr.Trim, _SqlConnect)
            _SqlCommand.CommandTimeout = 10000
            _SqlAdapter = New SqlDataAdapter(_SqlCommand)
            _CommandBuilder = New SqlCommandBuilder(_SqlAdapter)

            result = _SqlAdapter.Update(Dt)
            If result > 0 Then
                Return True
            Else
                Return False
            End If

        Catch ex As Exception
            Throw New Exception("Select_DataAdapter : " & ex.Message)
        End Try
    End Function

    Public Function Excute(ByVal StrSql As String, ByRef Result As Integer) As Boolean
        Try

            _SqlConnect = New SqlConnection(_Conn)
            _SqlCommand = New SqlCommand(StrSql.Trim, _SqlConnect)
            _SqlCommand.CommandTimeout = 10000

            If _SqlConnect.State = ConnectionState.Open Then
                _SqlConnect.Close()
            End If

            _SqlConnect.Open()
            _Transaction = _SqlConnect.BeginTransaction()
            _SqlCommand.Transaction = _Transaction
            Result = _SqlCommand.ExecuteNonQuery()
            _Transaction.Commit()
            Return True

        Catch ex As Exception
            _Transaction.Rollback()
            Throw New Exception("Select_DataAdapter : " & ex.Message)
        Finally
            _SqlConnect.Close()
        End Try
    End Function

End Class
