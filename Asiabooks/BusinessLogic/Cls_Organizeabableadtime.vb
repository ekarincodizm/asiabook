Imports Microsoft.VisualBasic
Imports Eordering.BusinessLogic
Imports System
Imports System.Data
Imports System.Net.DNS
Public Class Cls_Organizeabableadtime
    Private strFrom_Org_AB_Code As String
    Private strTo_Org_AB_Code As String
    Private strLead_Time As String
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
    Property From_Org_AB_Code()
        Get
            Return strFrom_Org_AB_Code
        End Get
        Set(ByVal value)
            strFrom_Org_AB_Code = value
        End Set
    End Property

    Property To_Org_AB_Code()
        Get
            Return strTo_Org_AB_Code
        End Get
        Set(ByVal value)
            strTo_Org_AB_Code = value
        End Set
    End Property

    Property Lead_Time()
        Get
            Return strLead_Time
        End Get
        Set(ByVal value)
            strLead_Time = value
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

        If From_Org_AB_Code <> "0" And From_Org_AB_Code <> "" Then
            condition = " WHERE From_Org_AB_Code='" + From_Org_AB_Code + "'"
        End If

        If To_Org_AB_Code <> "0" And To_Org_AB_Code <> "" Then
            If condition.Length = "0" Then
                condition &= " WHERE To_Org_AB_Code = '" + To_Org_AB_Code + "'"
            Else
                condition &= " AND To_Org_AB_Code = '" + To_Org_AB_Code + "'"
            End If
        End If

        If Lead_Time <> "" Then
            If condition.Length = "0" Then
                condition &= " WHERE Lead_Time = '" + Lead_Time + "'"
            Else
                condition &= " AND Lead_Time = '" + Lead_Time + "'"
            End If
        End If

        sqlCommand = "select * from dbo.tbm_syst_organizeabableadtime" + condition
        dt = sqlDb.GetDataTable(sqlCommand)
        Return dt
    End Function

    Public Sub Add()
        Dim sqlDb As New SqlDb
        Dim sqlCommand As String
        Try


            sqlDb.BeginTrans()
            sqlCommand = "INSERT INTO tbm_syst_organizeabableadtime"
            sqlCommand &= "(From_Org_AB_Code, To_Org_AB_Code,Lead_Time,addempcd,addpcnm,adddt)"
            sqlCommand &= " VALUES('" + From_Org_AB_Code + "',"
            sqlCommand &= "'" + To_Org_AB_Code + "',"
            sqlCommand &= "'" + Lead_Time + "',"
            sqlCommand &= "'" + Empcd + "',"
            sqlCommand &= "'" + Pcnm + "',"
            sqlCommand &= "'" + sqlDb.GetDataTable("SELECT convert(varchar(30),getdate(),120)").Rows(0)(0).ToString + "')"
            sqlDb.Exec(sqlCommand)
            sqlDb.CommitTrans()
            message = "Add From Organize : " + From_Org_AB_Code + " To Organize : " + To_Org_AB_Code + " Successful"
        Catch ex As Exception
            message = "Add From Organize : " + From_Org_AB_Code + " To Organize : " + To_Org_AB_Code + " UnSuccessful"
            sqlDb.RollbackTrans()
        End Try
    End Sub

    Public Sub Edit()
        Dim sqlDb As New SqlDb
        Dim sqlCommand As String
        Try

            sqlDb.BeginTrans()
            sqlCommand = "UPDATE tbm_syst_organizeabableadtime"
            sqlCommand &= " SET Lead_Time='" + Lead_Time + "',"
            sqlCommand &= " updempcd='" + Empcd + "',"
            sqlCommand &= " updpcnm='" + Pcnm + "',"
            sqlCommand &= " upddt='" + sqlDb.GetDataTable("SELECT convert(varchar(30),getdate(),120)").Rows(0)(0).ToString + "'"
            sqlCommand &= " WHERE From_Org_AB_Code='" + From_Org_AB_Code + "'"
            sqlCommand &= " AND To_Org_AB_Code='" + To_Org_AB_Code + "'"
            sqlDb.Exec(sqlCommand)
            sqlDb.CommitTrans()
            message = "Update From Organize : " + From_Org_AB_Code + " To Organize : " + To_Org_AB_Code + " Successful"
        Catch ex As Exception
            message = "Update From Organize : " + From_Org_AB_Code + " To Organize : " + To_Org_AB_Code + " UnSuccessful"
            sqlDb.RollbackTrans()
        End Try
    End Sub

    Public Sub Delete()
        Dim sqlDb As New SqlDb
        Dim sqlCommand As String
        Try
            sqlDb.BeginTrans()
            sqlCommand = "DELETE tbm_syst_organizeabableadtime"
            sqlCommand &= " WHERE From_Org_AB_Code='" + From_Org_AB_Code + "'"
            sqlCommand &= " AND To_Org_AB_Code='" + To_Org_AB_Code + "'"

            sqlDb.Exec(sqlCommand)
            sqlDb.CommitTrans()
            message = "Delete From Organize : " + From_Org_AB_Code + " To Organize : " + To_Org_AB_Code + " Successful"
        Catch ex As Exception
            message = "Delete From Organize : " + From_Org_AB_Code + " To Organize : " + From_Org_AB_Code + " UnSuccessful"
            sqlDb.RollbackTrans()
        End Try
    End Sub













End Class
