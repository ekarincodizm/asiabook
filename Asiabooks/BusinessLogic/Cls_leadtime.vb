Imports Microsoft.VisualBasic
Imports Eordering.BusinessLogic
Imports System
Imports System.Data
Imports System.Net.DNS
Public Class Cls_leadtime
    Private strFreight_Type As String
    Private strStock_status As String
    Private strLead_Time_day As String
    Private strEmpcd As String
    Public message As String
    Private strPcnm As String
    Property Pcnm()
        Get
            Return strPcnm
        End Get
        Set(ByVal value)
            strPcnm = value
        End Set
    End Property
    Property Freight_Type()
        Get
            Return strFreight_Type
        End Get
        Set(ByVal value)
            strFreight_Type = value
        End Set
    End Property
    Property Stock_status()
        Get
            Return strStock_status
        End Get
        Set(ByVal value)
            strStock_status = value
        End Set
    End Property
    Property Lead_Time_day()
        Get
            Return strLead_Time_day
        End Get
        Set(ByVal value)
            strLead_Time_day = value
        End Set
    End Property
    Property Empcd()
        Get
            Return strEmpcd
        End Get
        Set(ByVal value)
            strEmpcd = value
        End Set
    End Property
    Public Function Retreive()
        Dim sqlDb As New SqlDb
        Dim dt As DataTable
        Dim sqlCommand As String
        Dim condition As String = ""
        If Freight_Type <> "" Then
            condition = "WHERE Freight_Type='" + Freight_Type + "'"
        End If

        If Stock_status <> "" Then
            If condition.Length = 0 Then
                condition &= "WHERE Stock_status = '" + Stock_status + "'"
            Else
                condition &= "AND Stock_status = '" + Stock_status + "'"
            End If
        End If

        If Lead_Time_day <> "" Then
            If condition.Length = 0 Then
                condition &= "WHERE Lead_Time_day like '%" + Lead_Time_day + "%'"
            Else
                condition &= "AND Lead_Time_day like '%" + Lead_Time_day + "%'"
            End If
        End If

        sqlCommand = " SELECT * From tbm_syst_leadtime " + condition
        dt = sqlDb.GetDataTable(sqlCommand)
        Return dt
    End Function
    Public Sub Add()
        Dim sqlDb As New SqlDb
        Dim sqlCommand As String
        Try

            sqlDb.BeginTrans()
            sqlCommand = "INSERT INTO tbm_syst_leadtime "
            sqlCommand &= " (Freight_Type,Stock_status,Lead_Time_day,addempcd,addpcnm,adddt)"
            sqlCommand &= " VALUES('" + Freight_Type + "',"

            sqlCommand &= "'" + Stock_status + "',"
            sqlCommand &= "'" + Lead_Time_day + "',"
            sqlCommand &= "'" + Empcd + "',"
            sqlCommand &= "'" + Pcnm + "',"
            sqlCommand &= "'" + sqlDb.GetDataTable("SELECT convert(varchar(30),getdate(),120)").Rows(0)(0).ToString + "')"
            sqlDb.Exec(sqlCommand)
            sqlDb.CommitTrans()
            message = "Add Freight Type  : " + Freight_Type
            message &= " Stock status : " + Stock_status
            message &= " Successful"
        Catch ex As Exception
            message = "Add Freight Type  : " + Freight_Type
            message &= " Stock status : " + Stock_status
            message &= " UnSuccessful"
            sqlDb.RollbackTrans()
        End Try
    End Sub
    Public Sub Edit()
        Dim sqlDb As New SqlDb
        Dim sqlCommand As String
        Try

            sqlDb.BeginTrans()
            sqlCommand = "UPDATE tbm_syst_leadtime "
            sqlCommand &= " SET Lead_Time_day ='" + Lead_Time_day + "',"
            sqlCommand &= " updempcd='" + Empcd + "',"
            sqlCommand &= " updpcnm='" + Pcnm + "',"
            sqlCommand &= " upddt='" + sqlDb.GetDataTable("SELECT convert(varchar(30),getdate(),120)").Rows(0)(0).ToString + "'"
            sqlCommand &= " WHERE Freight_Type='" + Freight_Type + "'"
            sqlCommand &= " and Stock_status='" + Stock_status + "'"
            sqlDb.Exec(sqlCommand)
            sqlDb.CommitTrans()
            message = "Update Freight Type  : " + Freight_Type
            message &= " Stock status : " + Stock_status
            message &= " Successful"
        Catch ex As Exception
            message = "Update Freight Type  : " + Freight_Type
            message &= " Stock status : " + Stock_status
            message &= " UnSuccessful"
            sqlDb.RollbackTrans()
        End Try
    End Sub
    Public Sub Delete()
        Dim sqlDb As New SqlDb
        Dim sqlCommand As String
        Try
            sqlDb.BeginTrans()
            sqlCommand = "DELETE tbm_syst_leadtime "
            sqlCommand &= " WHERE Freight_Type='" + Freight_Type + "'"
            sqlCommand &= " and Stock_status='" + Stock_status + "'"

            sqlDb.Exec(sqlCommand)
            sqlDb.CommitTrans()
            message = "Delete Freight Type  : " + Freight_Type
            message &= " Stock status : " + Stock_status
            message &= " Successful"
        Catch ex As Exception
            message = "Delete Freight Type  : " + Freight_Type
            message &= " Stock status : " + Stock_status
            message &= " UnSuccessful"
            sqlDb.RollbackTrans()
        End Try
    End Sub
End Class
