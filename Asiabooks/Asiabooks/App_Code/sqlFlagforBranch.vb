Imports Microsoft.VisualBasic
Imports System
Imports System.Data
Imports System.Data.SqlClient
Imports Eordering.BusinessLogic

Public Class sqlFlagforBranch

    Dim SqlDb As New SqlDb

    Public Function Update_MS_SynopsisForBranch() As Boolean
        Try
            Dim _strQuery As StringBuilder
            SqlDb.BeginTrans()
            _strQuery = New StringBuilder
            _strQuery.Append("Update [MS_SynopsisForBranch] ")
            _strQuery.Append("Set [Month] = convert(varchar,getdate(),106) ")
            '_strQuery.Append("Set [Month] = '01 Feb 2010' ")
            '_strQuery.Append(", Date_Add = '").Append(Now.Date).Append("' ")
            _strQuery.Append(", Date_Add = getdate() ")
            '_strQuery.Append(", Date_Add = '2010-02-01' ")
            _strQuery.Append("where [Month] is null ")
            SqlDb.Exec(_strQuery.ToString)
            SqlDb.CommitTrans()

            Return True
        Catch ex As Exception
            SqlDb.RollbackTrans()
            Throw New Exception("Update Is_Active in table MS_SynopsisForBranch : " & ex.Message)
        End Try
    End Function
    Public Function Update_Month_SynopsisForBranch(ByVal StrDate As String) As Boolean
        Try
            Dim _strQuery As StringBuilder
            SqlDb.BeginTrans()
            _strQuery = New StringBuilder
            _strQuery.Append("Update [MS_SynopsisForBranch] ")
            _strQuery.Append("Set [Month] = '" + StrDate + "' ")
            '_strQuery.Append("Set [Month] = '11 Dec 2009' ")
            _strQuery.Append(", Date_Add = convert(datetime,'" + StrDate + "',103) ")
            _strQuery.Append("where [Month] is null ")
            SqlDb.Exec(_strQuery.ToString)
            SqlDb.CommitTrans()

            Return True
        Catch ex As Exception
            SqlDb.RollbackTrans()
            Throw New Exception("Update Is_Active in table MS_SynopsisForBranch : " & ex.Message)
        End Try
    End Function
    Public Function Delete_MS_SynopsisForBranch(ByVal StrMonth As String) As Boolean
        Try
            Dim _strQuery As StringBuilder
            SqlDb.BeginTrans()
            _strQuery = New StringBuilder
            _strQuery.Append("Delete [MS_SynopsisForBranch] ")
            _strQuery.Append("where [Month] = '" + StrMonth + "' ")
            SqlDb.Exec(_strQuery.ToString)
            SqlDb.CommitTrans()

            Return True
        Catch ex As Exception
            SqlDb.RollbackTrans()
            Throw New Exception("Update Is_Active in table MS_SynopsisForBranch : " & ex.Message)
        End Try
    End Function
    Public Function Check_ISBN(ByRef _dtMaster As DataTable, ByRef _dtNotISBN As DataTable) As Boolean
        Try
            Dim _strQuery As StringBuilder
            Dim _dt As DataTable

            For Each dr As DataRow In _dtMaster.Rows
                _strQuery = New StringBuilder
                _dt = New DataTable
                _strQuery.Append("select [ISBN_13] as 'ISBN',[Book_Title] as 'Title' from [tbm_asbkeo_bookab] ")
                _strQuery.Append("where [ISBN_13]='" & dr("ISBN_13").ToString.Trim & "' ")
                _dt = SqlDb.GetDataTable(_strQuery.ToString)

                If _dt.Rows.Count > 0 Then
                    dr("Is_Active") = "Y"
                Else
                    dr("Is_Active") = "N"
                    Dim drNotISBN As DataRow = _dtNotISBN.NewRow
                    drNotISBN("ISBN") = dr("ISBN_13").ToString.Trim
                    _dtNotISBN.Rows.Add(drNotISBN)
                End If
            Next

            Return True
        Catch ex As Exception
            Return False
            Throw New Exception("Check ISBN : " & ex.Message)
        End Try
    End Function
    Public Function Check_Synop(ByRef _dtMaster As DataTable, ByRef _dtNotSynop As DataTable) As Boolean
        Try
            Dim _strQuery As StringBuilder
            Dim _dt As DataTable

            For Each dr As DataRow In _dtMaster.Select("[Is_Active]='Y'")
                _strQuery = New StringBuilder
                _dt = New DataTable
                _strQuery.Append("select [ISBN_13] as 'ISBN',[Book_Title] as 'Title' from [tbm_asbkeo_bookab] ")
                _strQuery.Append("where [ISBN_13]='" & dr("ISBN_13").ToString.Trim & "' ")
                _strQuery.Append("and [Synopsis]<>'' and [Synopsis]<>'-' ")
                _dt = SqlDb.GetDataTable(_strQuery.ToString)

                If _dt.Rows.Count > 0 Then
                    dr("Is_Active") = "Y"
                Else
                    dr("Is_Active") = "N"
                    Dim drNotSynop As DataRow = _dtNotSynop.NewRow
                    drNotSynop("SyNopISBN") = dr("ISBN_13").ToString.Trim
                    _dtNotSynop.Rows.Add(drNotSynop)
                End If
            Next

            Return True
        Catch ex As Exception
            Return False
            Throw New Exception("Check Synopsis : " & ex.Message)
        End Try
    End Function
    Public Function Insert_MS_SynopsisForBranch(ByVal conn As SqlConnection, ByVal dtMaster As DataTable, ByVal tableName As String) As Boolean
        If conn.State = ConnectionState.Closed Then conn.Open()

        Try
            Using bulkCopy As SqlBulkCopy = New SqlBulkCopy(conn)
                bulkCopy.DestinationTableName = tableName
                Try
                    bulkCopy.WriteToServer(dtMaster)
                    Return True
                Catch ex As Exception
                    Return False
                    Throw New Exception("Insert MS SynopsisForBranch : " & ex.Message)
                End Try
            End Using
        Catch ex As Exception
            Return False
            Throw New Exception("Insert MS SynopsisForBranch : " & ex.Message)
        End Try
    End Function
    Public Function Update_asbkeo_bookab(ByVal dtMaster As DataTable) As Boolean
        Try
            Dim _strQuery As StringBuilder
            SqlDb.BeginTrans()
            For Each dr As DataRow In dtMaster.Select("[Is_Active]='Y'")
                _strQuery = New StringBuilder
                _strQuery.Append("Update [tbm_asbkeo_bookab] ")
                _strQuery.Append("Set [flg_SynopsisForBranch] = '" & dr("flg_SynopsisForBranch").ToString.Trim & "' ")
                _strQuery.Append("WHERE [ISBN_13]='" & dr("ISBN_13").ToString.Trim & "' ")
                SqlDb.Exec(_strQuery.ToString)
            Next
            SqlDb.CommitTrans()

            Return True
        Catch ex As Exception
            SqlDb.RollbackTrans()
            Throw New Exception("Update flg_SynopsisForBranch in table asbkeo_bookab : " & ex.Message)
        End Try
    End Function
End Class
