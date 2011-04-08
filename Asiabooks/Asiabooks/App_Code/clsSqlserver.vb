Imports Microsoft.VisualBasic
Imports System.Data
Imports System.Data.SqlClient
Public Class clsSqlserver
    Private _con As SqlConnection
    Private _com As SqlCommand
    Private _Ad As SqlDataAdapter
    Private _dt As DataTable
    Private _arrParam() As Object
    Private _arrParamName() As Object
    Public Sub New()
        Try
            _con = New SqlConnection(System.Configuration.ConfigurationManager.AppSettings("Driv").ToString)
            OpenConnect()
        Catch ex As Exception
        End Try
    End Sub
    Private Sub OpenConnect()
        Try
            If _con.State = ConnectionState.Closed Then _con.Open()
        Catch ex As Exception

        End Try

    End Sub
    Public Function GetDataTable(ByVal Sql As String, ByRef dt As DataTable) As Boolean
        Try
            _com = New SqlCommand(Sql, _con)
            _com.CommandTimeout = 1000000
            _Ad = New SqlDataAdapter(_com)
            _Ad.Fill(dt)
            Return True
        Catch ex As Exception
            Return False
        End Try
    End Function
    Public Function CopyToDataSource(ByVal dt As DataTable, ByVal tableName As String) As Boolean
        Try
            Using bulkCopy As SqlBulkCopy = New SqlBulkCopy(_con)
                bulkCopy.DestinationTableName = tableName
                Try
                    bulkCopy.WriteToServer(dt)
                Catch ex As Exception
                    Console.WriteLine(ex.Message)
                End Try
            End Using
        Catch ex As Exception

        End Try
    End Function
    Public Function ExcuCommand(ByVal vSqlCommand As String) As Boolean
        Dim sSql As String = vSqlCommand
        Dim i As Integer
        If _con.State = ConnectionState.Closed Then _con.Open()

        'CreateConn()
        If _com Is Nothing Then _com = New SqlCommand
        Try
            '   If _Tran Is Nothing Then
            _com.Connection = _con
            '  _Tran = _Conn.BeginTransaction
            '  _command.Transaction = _Tran
            '  End If

            'Add parameter
            If Not IsNothing(_arrParam) Then
                For i = 1 To _arrParam.GetUpperBound(0)
                    If IsNothing(_arrParam.GetValue(i)) Then
                        _arrParam(i) = ""
                    End If
                    sSql = Replace(sSql, _arrParamName(i), _arrParam.GetValue(i))

                Next
            End If

            If InStr(sSql, "@notequl@") > 0 Then
                sSql = Replace(sSql, "@notequl@", " <> ")
            End If

            _com.CommandText = sSql
            If _com.ExecuteNonQuery() > 0 Then
                Return True
            Else
                Return False
            End If
            'Return True
        Catch ex As Exception
            'Return ex.Message()
            'Throw ex
            ' _Tran.Rollback()
            ' _Tran = Nothing
            Return False
        Finally
            _com = Nothing
            _con.Close()
        End Try

    End Function

    'Public Function ExcuCommand(ByVal vSqlCommand As String) As Boolean
    '    Dim sSql As String = vSqlCommand
    '    Dim i As Integer

    '    'CreateConn()
    '    If _com Is Nothing Then _com = New SqlCommand
    '    Try
    '        _com.Connection = _con

    '        If Not IsNothing(_arrParam) Then
    '            For i = 1 To _arrParam.GetUpperBound(0)
    '                If IsNothing(_arrParam.GetValue(i)) Then
    '                    _arrParam(i) = ""
    '                End If
    '                sSql = Replace(sSql, _arrParamName(i), _arrParam.GetValue(i))

    '            Next
    '        End If

    '        If InStr(sSql, "@notequl@") > 0 Then
    '            sSql = Replace(sSql, "@notequl@", " <> ")
    '        End If

    '        _com.CommandText = sSql
    '        If _com.ExecuteNonQuery() > 0 Then
    '            Return True
    '        Else
    '            Return False
    '        End If
    '    Catch ex As Exception

    '        Return False
    '    End Try

    'End Function
End Class
