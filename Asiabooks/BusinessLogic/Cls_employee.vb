Imports Microsoft.VisualBasic
Imports Eordering.BusinessLogic
Imports System
Imports System.Data
Public Class Cls_employee
    Private strEmpcd As String
    Private strEmpnm As String
    Private strPassword As String
    Private strOrg_AB_code As String
    Private strDepartment_Name As String
    Private strAddrno As String
    Private strPost As String
    Private strEmail As String
    Private strPhone As String
    Private strMoblie As String
    Private strFax As String
    Private strRemark As String
    Private strOrg_AB_Name As String

    Public message As String
    Property empcd()
        Get
            Return strEmpcd
        End Get
        Set(ByVal value)
            strEmpcd = value
        End Set
    End Property
    Property empnm()
        Get
            Return strEmpnm
        End Get
        Set(ByVal value)
            strEmpnm = value
        End Set
    End Property
    Property password()
        Get
            Return strPassword
        End Get
        Set(ByVal value)
            strPassword = value
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
    Property Department_Name()
        Get
            Return strDepartment_Name
        End Get
        Set(ByVal value)
            strDepartment_Name = value
        End Set
    End Property
    Property addrno()
        Get
            Return strAddrno
        End Get
        Set(ByVal value)
            strAddrno = value
        End Set
    End Property
    Property post()
        Get
            Return strPost
        End Get
        Set(ByVal value)
            strPost = value
        End Set
    End Property
    Property email()
        Get
            Return strEmail
        End Get
        Set(ByVal value)
            strEmail = value
        End Set
    End Property
    Property phone()
        Get
            Return strPhone
        End Get
        Set(ByVal value)
            strPhone = value
        End Set
    End Property
    Property moblie()
        Get
            Return strMoblie
        End Get
        Set(ByVal value)
            strMoblie = value
        End Set
    End Property
    Property fax()
        Get
            Return strFax
        End Get
        Set(ByVal value)
            strFax = value
        End Set
    End Property
    Property remark()
        Get
            Return strRemark
        End Get
        Set(ByVal value)
            strRemark = value
        End Set
    End Property
    Public Function Retreive()
        Dim sqlDb As New SqlDb
        Dim dt As DataTable
        Dim sqlCommand As String
        Dim condition As String = ""
        If empcd <> "0" And empcd <> "" Then
            condition = "WHERE empcd='" + empcd + "'"
        End If

        If Org_AB_code <> "0" And Org_AB_code <> "" Then
            If condition.Length = "0" Then
                condition &= " WHERE e.Org_AB_code = '" + Org_AB_code + "'"
            Else
                condition &= " AND e.Org_AB_code = '" + Org_AB_code + "'"
            End If
        End If

        If Department_Name <> "0" And Department_Name <> "" Then
            If condition.Length = "0" Then
                condition &= " WHERE e.Department_Name = '" + Department_Name + "'"
            Else
                condition &= " AND e.Department_Name = '" + Department_Name + "'"
            End If
        End If

        sqlCommand = " select e.*,o.Org_AB_Name "
        sqlCommand &= "from tbm_syst_emp e "
        sqlCommand &= "	left join tbm_syst_organizeab o"
        sqlCommand &= " on e.Org_AB_code = o.Org_AB_code " + condition
        dt = sqlDb.GetDataTable(sqlCommand)
        Return dt
    End Function
End Class
