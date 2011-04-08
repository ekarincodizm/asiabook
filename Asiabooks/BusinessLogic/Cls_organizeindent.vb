Imports Microsoft.VisualBasic
Imports Eordering.BusinessLogic
Imports System
Imports System.Data
Imports System.Net.DNS
Public Class Cls_organizeindent
    Private strOrg_Indent_Code As String
    Private strOrg_Indent_Name As String
    Private strAir_Freight_Rate As String
    Private strCurrency_Code As String
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
    Property Org_Indent_Code()
        Get
            Return strOrg_Indent_Code
        End Get
        Set(ByVal value)
            strOrg_Indent_Code = value
        End Set
    End Property

    Property Org_Indent_Name()
        Get
            Return strOrg_Indent_Name
        End Get
        Set(ByVal value)
            strOrg_Indent_Name = value
        End Set
    End Property

    Property Air_Freight_Rate()
        Get
            Return strAir_Freight_Rate
        End Get
        Set(ByVal value)
            strAir_Freight_Rate = value
        End Set
    End Property

    Property Currency_Code()
        Get
            Return strCurrency_Code
        End Get
        Set(ByVal value)
            strCurrency_Code = value
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

        If Org_Indent_Code <> "" Then
            condition = " WHERE Org_Indent_Code='" + Org_Indent_Code + "'"
        End If

        If Org_Indent_Name <> "0" And Org_Indent_Name <> "" Then
            If condition.Length = 0 Then
                condition &= " WHERE Org_Indent_Name = '" + Org_Indent_Name + "'"
            Else
                condition &= " AND Org_Indent_Name = '" + Org_Indent_Name + "'"
            End If
        End If

        If Air_Freight_Rate <> "0" And Air_Freight_Rate <> "" Then
            If condition.Length = 0 Then
                condition &= " WHERE Air_Freight_Rate = '" + Air_Freight_Rate + "'"
            Else
                condition &= " AND Air_Freight_Rate = '" + Air_Freight_Rate + "'"
            End If
        End If

        If Currency_Code <> "0" And Currency_Code <> "" Then
            If condition.Length = 0 Then
                condition &= " WHERE Currency_Code = '" + Currency_Code + "'"
            Else
                condition &= " AND Currency_Code = '" + Currency_Code + "'"
            End If
        End If

        sqlCommand = "select * from tbm_syst_organizeindent" + condition
        dt = sqlDb.GetDataTable(sqlCommand)
        Return dt
    End Function

    Public Sub Add()
        Dim sqlDb As New SqlDb
        Dim sqlCommand As String
        Try


            sqlDb.BeginTrans()
            sqlCommand = "INSERT INTO tbm_syst_organizeindent"
            sqlCommand &= "(Org_Indent_Code,Org_Indent_Name, Air_Freight_Rate,Currency_Code,addempcd,addpcnm,adddt)"
            sqlCommand &= " VALUES('" + Org_Indent_Code + "',"
            sqlCommand &= "'" + Org_Indent_Name + "',"
            sqlCommand &= "'" + Air_Freight_Rate + "',"
            sqlCommand &= "'" + Currency_Code + "',"
            sqlCommand &= "'" + Empcd + "',"
            sqlCommand &= "'" + Pcnm + "',"
            sqlCommand &= "'" + sqlDb.GetDataTable("SELECT convert(varchar(30),getdate(),120)").Rows(0)(0).ToString + "')"
            sqlDb.Exec(sqlCommand)
            sqlDb.CommitTrans()
            message = "Add Organize Indent : " + Org_Indent_Code + " Successful"
        Catch ex As Exception
            message = "Add Organize Indent : " + Org_Indent_Code + " UnSuccessful"
            sqlDb.RollbackTrans()
        End Try
    End Sub

    Public Sub Edit()
        Dim sqlDb As New SqlDb
        Dim sqlCommand As String
        Try

            sqlDb.BeginTrans()
            sqlCommand = "UPDATE tbm_syst_organizeindent"
            sqlCommand &= " SET Org_Indent_Name ='" + Org_Indent_Name + "',"
            sqlCommand &= " Currency_Code ='" + Currency_Code + "',"
            sqlCommand &= " Air_Freight_Rate ='" + Air_Freight_Rate + "',"
            sqlCommand &= " updempcd='" + Empcd + "',"
            sqlCommand &= " updpcnm='" + Pcnm + "',"
            sqlCommand &= " upddt='" + sqlDb.GetDataTable("SELECT convert(varchar(30),getdate(),120)").Rows(0)(0).ToString + "'"
            sqlCommand &= " WHERE Org_Indent_Code ='" + Org_Indent_Code + "'"
            sqlDb.Exec(sqlCommand)
            sqlDb.CommitTrans()
            message = "Update Organize Indent : " + Org_Indent_Code + " Successful"
        Catch ex As Exception
            message = "Update Organize Indent : " + Org_Indent_Code + " UnSuccessful"
            sqlDb.RollbackTrans()
        End Try
    End Sub

    Public Sub Delete()
        Dim sqlDb As New SqlDb
        Dim sqlCommand As String
        Try
            sqlDb.BeginTrans()
            sqlCommand = "DELETE tbm_syst_organizeindent"
            sqlCommand &= " WHERE Org_Indent_Code='" + Org_Indent_Code + "'"

            sqlDb.Exec(sqlCommand)
            sqlDb.CommitTrans()
            message = "Delete Organize Indent : " + Org_Indent_Code + " Successful"
        Catch ex As Exception
            message = "Delete Organize Indent : " + Org_Indent_Code + " UnSuccessful"
            sqlDb.RollbackTrans()
        End Try
    End Sub

End Class
