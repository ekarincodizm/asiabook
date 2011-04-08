Imports Microsoft.VisualBasic
Imports Eordering.BusinessLogic
Imports System
Imports System.Data
Imports System.Configuration

Public Class UserDetail
    Private strDomain As String
    Private strUserPC As String
    Private strPassword As String

    Property Domain()
        Get
            Return strDomain
        End Get
        Set(ByVal value)
            strDomain = value
        End Set
    End Property
    Property UserPC()
        Get
            Return strUserPC
        End Get
        Set(ByVal value)
            strUserPC = value
        End Set
    End Property
    Property Password()
        Get
            Return strPassword
        End Get
        Set(ByVal value)
            strPassword = value
        End Set
    End Property
    Public Function GetEmpId()
        Dim SqlDb As New SqlDb
        Dim dt As New DataTable
        Dim sqlCommand As String
        sqlCommand = "SELECT empcd,password "
        sqlCommand += "FROM tbm_syst_emp WHERE empcd ='" & UserPC & "'"
        sqlCommand += " and domain ='" + Domain + "'"
        dt = SqlDb.GetDataTable(sqlCommand)
        Return dt
    End Function

    Public Function GetEmpIdlogin()
        Dim SqlDb As New SqlDb
        Dim User As String = ""
        Dim dt As New DataTable
        Dim sqlCommand As String
        sqlCommand = "SELECT empcd,department_name,Org_AB_code"
        sqlCommand += " FROM tbm_syst_emp WHERE empcd ='" & UserPC & "'"
        'sqlCommand += " AND password = '" & Password & "'"
        dt = SqlDb.GetDataTable(sqlCommand)
        Return dt
    End Function
    Public Function GetEmpIdloginForStock(ByVal UserName As String, ByVal PassWord As String)
        Dim SqlDb As New SqlDb
        Dim dt As New DataTable
        Dim sqlCommand As String
        sqlCommand = "SELECT sctylvl "
        sqlCommand &= " FROM tbm_syst_emp inner join tbm_syst_scty "
        sqlCommand &= " ON tbm_syst_emp.empcd=tbm_syst_scty.empcd"
        sqlCommand &= " WHERE tbm_syst_emp.empcd='" & UserName & "' "
        sqlCommand &= " AND password = '" & PassWord & "'"
        sqlCommand &= " AND formcd='stock'"

        dt = SqlDb.GetDataTable(sqlCommand)
        Return dt
    End Function

End Class
