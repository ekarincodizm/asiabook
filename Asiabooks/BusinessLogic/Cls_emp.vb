Imports Microsoft.VisualBasic
Imports Eordering.BusinessLogic
Imports System
Imports System.Data
Imports System.Net.DNS
Public Class Cls_emp
    Private strformcd As String
    Private strempcd As String
    Private strAddEmpcd As String
    Private Intsctylvl As Integer
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
    Property formcd()
        Get
            Return strformcd
        End Get
        Set(ByVal value)
            strformcd = value
        End Set
    End Property
    Property empcd()
        Get
            Return strempcd
        End Get
        Set(ByVal value)
            strempcd = value
        End Set
    End Property
    Property sctylvl()
        Get
            Return Intsctylvl
        End Get
        Set(ByVal value)
            Intsctylvl = value
        End Set
    End Property
    Property AddEmpcd()
        Get
            Return strAddEmpcd
        End Get
        Set(ByVal value)
            strAddEmpcd = value
        End Set
    End Property
    Public Function Retreive()
        Dim sqlDb As New SqlDb
        Dim dt As DataTable
        Dim sqlCommand As String


        sqlCommand = "select formcd,formnm,0 as sctylvl from tbm_syst_form "
        dt = sqlDb.GetDataTable(sqlCommand)
        Return dt
    End Function
    Public Function RetreiveEmp()
        Dim sqlDb As New SqlDb
        Dim dt As DataTable
        Dim sqlCommand As String

        sqlCommand = "select * from tbm_syst_scty WHERE empcd = '" + empcd + "'"

        dt = sqlDb.GetDataTable(sqlCommand)
        Return dt
    End Function
    Public Function RetreiveChk()
        Dim sqlDb As New SqlDb
        Dim dt As DataTable
        Dim sqlCommand As String


        sqlCommand = "SELECT b.formcd,b.formnm,isnull(sctylvl,0) as sctylvl "
        sqlCommand &= " FROM tbm_syst_scty a right join tbm_syst_form b"
        sqlCommand &= " on a.formcd=b.formcd"
        sqlCommand &= " and a.empcd = '" + empcd + "'"

        dt = sqlDb.GetDataTable(sqlCommand)
        Return dt
    End Function

    Public Sub Add()
        Dim sqlDb As New SqlDb
        Dim sqlCommand As String
        Try
            sqlDb.BeginTrans()

            sqlCommand = "INSERT INTO tbm_syst_scty(formcd,empcd,sctylvl,addempcd,addpcnm,adddt)"
            sqlCommand &= " VALUES('" + formcd + "',"
            sqlCommand &= "'" + empcd + "',"
            sqlCommand &= "'" + Convert.ToInt16(sctylvl).ToString + "',"
            sqlCommand &= "'" + AddEmpcd + "',"
            sqlCommand &= "'" + Pcnm + "',"
            sqlCommand &= "'" + sqlDb.GetDataTable("SELECT convert(varchar(30),getdate(),120)").Rows(0)(0).ToString + "')"

            sqlDb.Exec(sqlCommand)
            sqlDb.CommitTrans()
            message = "Save Employee Code : " + empcd + " Successful"
        Catch ex As Exception
            message = "Save Employee Code : " + empcd + " UnSuccessful"
            sqlDb.RollbackTrans()
        End Try
    End Sub

    Public Sub Edit()
        Dim sqlDb As New SqlDb
        Dim sqlCommand As String
        Try

            sqlDb.BeginTrans()
            sqlCommand = "UPDATE tbm_syst_scty"
            sqlCommand &= " SET formcd ='" + sctylvl + "',"
            sqlCommand &= " updempcd='" + AddEmpcd + "',"
            sqlCommand &= " updpcnm='" + Pcnm + "',"
            sqlCommand &= " upddt='" + sqlDb.GetDataTable("SELECT convert(varchar(30),getdate(),120)").Rows(0)(0).ToString + "'"
            sqlCommand &= " WHERE formcd ='" + formcd + "'"
            sqlCommand &= " AND empcd='" + empcd + "'"

            sqlDb.Exec(sqlCommand)
            sqlDb.CommitTrans()
            message = "Update Employee Code : " + empcd + " Successful"
        Catch ex As Exception
            message = "Update Employee Code : " + empcd + " UnSuccessful"
            sqlDb.RollbackTrans()
        End Try
    End Sub
    Public Sub Delete()
        Dim sqlDb As New SqlDb
        Dim sqlCommand As String
        Try
            sqlDb.BeginTrans()
            sqlCommand = "DELETE tbm_syst_scty"
            sqlCommand &= " WHERE empcd='" + empcd + "'"

            sqlDb.Exec(sqlCommand)
            sqlDb.CommitTrans()
            message = "Delete Employee Code : " + empcd + " Successful"
        Catch ex As Exception
            message = "Delete Employee Code : " + empcd + " UnSuccessful"
            sqlDb.RollbackTrans()
        End Try
    End Sub
End Class
