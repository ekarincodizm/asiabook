Imports Microsoft.VisualBasic
Imports Eordering.BusinessLogic
Imports System
Imports System.Data
Imports System.Net.DNS
Public Class Cls_organizeab
    Private strGroup_Code As String
    Private strOrg_AB_code As String
    Private strOrg_AB_Name As String
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
    Property Group_Code()
        Get
            Return strGroup_Code
        End Get
        Set(ByVal value)
            strGroup_Code = value
        End Set
    End Property

    Property Org_AB_code()
        Get
            Return strOrg_AB_code
        End Get
        Set(ByVal value)
            strOrg_AB_code = value
        End Set
    End Property

    Property Org_AB_Name()
        Get
            Return strOrg_AB_Name
        End Get
        Set(ByVal value)
            strOrg_AB_Name = value
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

        If Group_Code <> "" Then
            condition = " WHERE Group_Code='" + Group_Code + "'"
        End If

        If Org_AB_code <> "0" And Org_AB_code <> "" Then
            If condition.Length = 0 Then
                condition &= " WHERE Org_AB_Code = '" + Org_AB_code + "'"
            Else
                condition &= " AND Org_AB_Code = '" + Org_AB_code + "'"
            End If
        End If

        sqlCommand = "select * from tbm_syst_organizeab" + condition
        dt = sqlDb.GetDataTable(sqlCommand)
        Return dt
    End Function

    Public Sub Add()
        Dim sqlDb As New SqlDb
        Dim sqlCommand As String
        Try


            sqlDb.BeginTrans()
            sqlCommand = "INSERT INTO tbm_syst_organizeab"
            sqlCommand &= "(Group_Code, Org_AB_code,Org_AB_Name,addempcd,addpcnm,adddt)"
            sqlCommand &= " VALUES('" + Group_Code + "',"
            sqlCommand &= "'" + Org_AB_code + "',"
            sqlCommand &= "'" + Org_AB_Name + "',"
            sqlCommand &= "'" + Empcd + "',"
            sqlCommand &= "'" + Pcnm + "',"
            sqlCommand &= "'" + sqlDb.GetDataTable("SELECT convert(varchar(30),getdate(),120)").Rows(0)(0).ToString + "')"
            sqlDb.Exec(sqlCommand)
            sqlDb.CommitTrans()
            message = "Add Organize : " + Org_AB_code + " Group Organize : " + Group_Code + " Successful"
        Catch ex As Exception
            message = "Add Organize: " + Org_AB_code + " Group Organize : " + Group_Code + " UnSuccessful"
            sqlDb.RollbackTrans()
        End Try
    End Sub

    Public Sub Edit()
        Dim sqlDb As New SqlDb
        Dim sqlCommand As String
        Try

            sqlDb.BeginTrans()
            sqlCommand = "UPDATE tbm_syst_organizeab"
            sqlCommand &= " SET Org_AB_Name ='" + Org_AB_Name + "',"
            sqlCommand &= " updempcd='" + Empcd + "',"
            sqlCommand &= " updpcnm='" + Pcnm + "',"
            sqlCommand &= " upddt='" + sqlDb.GetDataTable("SELECT convert(varchar(30),getdate(),120)").Rows(0)(0).ToString + "'"
            sqlCommand &= " WHERE Group_Code ='" + Group_Code + "'"
            sqlCommand &= " AND Org_AB_code='" + Org_AB_code + "'"
            sqlDb.Exec(sqlCommand)
            sqlDb.CommitTrans()
            message = "Update Organize : " + Org_AB_code + " Group Organize : " + Group_Code + " Successful"
        Catch ex As Exception
            message = "Update Organize : " + Org_AB_code + " Group Organize : " + Group_Code + " UnSuccessful"
            sqlDb.RollbackTrans()
        End Try
    End Sub

    Public Sub Delete()
        Dim sqlDb As New SqlDb
        Dim sqlCommand As String
        Try
            sqlDb.BeginTrans()
            sqlCommand = "DELETE tbm_syst_organizeab"
            sqlCommand &= " WHERE Group_Code='" + Group_Code + "'"
            sqlCommand &= " AND Org_AB_code='" + Org_AB_code + "'"

            sqlDb.Exec(sqlCommand)
            sqlDb.CommitTrans()
            message = "Delete Organize : " + Org_AB_code + " Group Organize : " + Group_Code + " Successful"
        Catch ex As Exception
            message = "Delete Organize : " + Org_AB_code + " Group Organize : " + Group_Code + " UnSuccessful"
            sqlDb.RollbackTrans()
        End Try
    End Sub



End Class
