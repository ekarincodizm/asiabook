Imports System
Imports System.Data
Imports System.Data.SqlClient
Imports System.IO
Imports System.Text
Imports System.Collections.Hashtable

Public Class uFunction
    Public Shared Function getDataTable(ByVal conn As SqlConnection, ByVal vsql As String) As DataTable
        Dim comm As New SqlCommand
        Dim ds As New DataSet
        Dim da As SqlDataAdapter

        If conn.State = ConnectionState.Closed Then conn.Open()

        Try
            With comm
                .CommandType = CommandType.Text
                .CommandText = vsql
                .CommandTimeout = 9999
                .Connection = conn

                da = New SqlDataAdapter(comm)
                da.Fill(ds, "Table1")
                If (Not ds Is Nothing) Then
                    Return ds.Tables("Table1")
                Else
                    Return Nothing
                End If
            End With
        Catch ex As Exception
            Throw ex
        Finally
            ds = Nothing
            comm = Nothing
            conn.Close()
        End Try
    End Function
    Public Shared Sub getDataSet(ByVal conn As SqlConnection, ByVal vsql As String, ByRef ds As DataSet, ByVal NameDS As String)
        Dim comm As New SqlCommand
        Dim da As New SqlDataAdapter

        ds = New DataSet

        If conn.State = ConnectionState.Closed Then conn.Open()

        Try
            With comm
                .CommandType = CommandType.Text
                .CommandText = vsql
                .CommandTimeout = 9999
                .Connection = conn

                da = New SqlDataAdapter(comm)
                If NameDS = "" Then
                    da.Fill(ds, "Table1")
                Else
                    da.Fill(ds, NameDS)
                End If
            End With
        Catch ex As Exception
            Throw ex
        Finally
            ds = Nothing
            comm = Nothing
            conn.Close()
        End Try
    End Sub
    Public Shared Sub ExecuteDataString(ByVal conn As SqlConnection, ByVal tr As SqlTransaction, ByVal vsql As String)
        Dim comm As New SqlCommand

        Try
            With comm
                .CommandType = CommandType.Text
                .CommandText = vsql
                .CommandTimeout = 99999
                .Transaction = tr
                .Connection = conn
                .ExecuteNonQuery()
            End With
        Catch ex As Exception
            Throw ex
        Finally
            comm = Nothing
        End Try
    End Sub
    Public Shared Sub ExecuteDataObject(ByVal con As SqlConnection, ByVal TR_temp As SqlTransaction, ByVal vPara() As Object, ByVal vsql As String)
        Dim comm As New SqlCommand

        Try
            With comm
                .CommandType = CommandType.Text
                .CommandTimeout = 99999
                .CommandText = vsql
                .Connection = con
                .Transaction = TR_temp
                .Parameters.Clear()
                For i As Integer = 0 To vPara.Length - 1
                    .Parameters.AddWithValue("@v" & Convert.ToString(i), vPara(i))
                Next
                .ExecuteNonQuery()
            End With
        Catch ex As Exception
            Throw ex
        Finally
            comm = Nothing
        End Try
    End Sub
    Public Shared Sub ExecuteDataProd(ByVal con As SqlConnection, ByVal TR_temp As SqlTransaction, _
                                      ByVal myHT As Hashtable, ByVal vProdname As String)
        Dim comm As SqlCommand
        Dim de As DictionaryEntry

        comm = New SqlCommand(vProdname, con)
        Try
            With comm
                .CommandType = CommandType.StoredProcedure
                .CommandTimeout = 99999
                .Transaction = TR_temp
                .Parameters.Clear()
                For Each de In myHT
                    .Parameters.AddWithValue(de.Key, de.Value)
                Next de

                .ExecuteNonQuery()
            End With
        Catch ex As Exception
            Throw ex
        Finally
            comm = Nothing
            de = Nothing
        End Try
    End Sub
    Public Shared Function ExecuteDataStringNonTran(ByVal conn As SqlConnection, ByVal vsql As String) As Boolean
        Dim comm As New SqlCommand

        If conn.State = ConnectionState.Closed Then conn.Open()

        Try
            With comm
                .CommandType = CommandType.Text
                .CommandText = vsql
                .CommandTimeout = 99999
                .Connection = conn
                .ExecuteNonQuery()
                Return True
            End With
        Catch ex As Exception
            Return False
            Throw ex
        Finally
            comm = Nothing
            conn.Close()
        End Try
    End Function
End Class
