Imports Microsoft.VisualBasic
Imports Eordering.BusinessLogic
Imports System
Imports System.Data
Imports System.Net.DNS
Public Class Cls_company
    Private strCompany_Code As String
    Private strCompany_Name As String
    Private strCompany_Address As String
    Private strCompany_Tel As String
    Private strCompany_Fax As String
    Private strCompany_Email As String
    Private strCompany_www As String
    Private strBuffer_Rate As String
    Private strVat As String
    Private strImport_Tax As String
    Private strMinimum_Stock_Branch As String
    Private strMinimum_Stock_Jobber As String
    Private strMinimum_Stock_Internet As String
    Private strMinimum_Percentage_Payment As String
    Private strMax_Row_Page_Staff As String
    Private strMax_Row_Page_User As String
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
    Property Company_Code()
        Get
            Return strCompany_Code
        End Get
        Set(ByVal value)
            strCompany_Code = value
        End Set
    End Property
    Property Company_Name()
        Get
            Return strCompany_Name
        End Get
        Set(ByVal value)
            strCompany_Name = value
        End Set
    End Property
    Property Company_Address()
        Get
            Return strCompany_Address
        End Get
        Set(ByVal value)
            strCompany_Address = value
        End Set
    End Property
    Property Company_Tel()
        Get
            Return strCompany_Tel
        End Get
        Set(ByVal value)
            strCompany_Tel = value
        End Set
    End Property
    Property Company_Fax()
        Get
            Return strCompany_Fax
        End Get
        Set(ByVal value)
            strCompany_Fax = value
        End Set
    End Property
    Property Company_Email()
        Get
            Return strCompany_Email
        End Get
        Set(ByVal value)
            strCompany_Email = value
        End Set
    End Property
    Property Company_www()
        Get
            Return strCompany_www
        End Get
        Set(ByVal value)
            strCompany_www = value
        End Set
    End Property
    Property Buffer_Rate()
        Get
            Return strBuffer_Rate
        End Get
        Set(ByVal value)
            strBuffer_Rate = value
        End Set
    End Property
    Property Vat()
        Get
            Return strVat
        End Get
        Set(ByVal value)
            strVat = value
        End Set
    End Property
    Property Import_Tax()
        Get
            Return strImport_Tax
        End Get
        Set(ByVal value)
            strImport_Tax = value
        End Set
    End Property
    Property Minimum_Stock_Branch()
        Get
            Return strMinimum_Stock_Branch
        End Get
        Set(ByVal value)
            strMinimum_Stock_Branch = value
        End Set
    End Property
    Property Minimum_Stock_Jobber()
        Get
            Return strMinimum_Stock_Jobber
        End Get
        Set(ByVal value)
            strMinimum_Stock_Jobber = value
        End Set
    End Property
    Property Minimum_Stock_Internet()
        Get
            Return strMinimum_Stock_Internet
        End Get
        Set(ByVal value)
            strMinimum_Stock_Internet = value
        End Set
    End Property
    Property Minimum_Percentage_Payment()
        Get
            Return strMinimum_Percentage_Payment
        End Get
        Set(ByVal value)
            strMinimum_Percentage_Payment = value
        End Set
    End Property
    Property Max_Row_Page_Staff()
        Get
            Return strMax_Row_Page_Staff
        End Get
        Set(ByVal value)
            strMax_Row_Page_Staff = value
        End Set
    End Property
    Property Max_Row_Page_User()
        Get
            Return strMax_Row_Page_User
        End Get
        Set(ByVal value)
            strMax_Row_Page_User = value
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
        If Company_Code <> "" Then
            condition = "WHERE Company_Code='" + Company_Code + "'"
        End If
        sqlCommand = " SELECT *  From tbm_syst_company " + condition
        dt = sqlDb.GetDataTable(sqlCommand)
        Return dt
    End Function
    Public Sub Edit()
        Dim sqlDb As New SqlDb
        Dim sqlCommand As String
        Try
            sqlDb.BeginTrans()
            sqlCommand = "UPDATE tbm_syst_company "
            sqlCommand &= " SET Company_Name ='" + Company_Name + "',"
            sqlCommand &= " Company_Address ='" + Company_Address + "',"
            sqlCommand &= " Company_Tel ='" + Company_Tel + "',"
            sqlCommand &= " Company_Fax ='" + Company_Fax + "',"
            sqlCommand &= " Company_Email ='" + Company_Email + "',"
            sqlCommand &= " Company_www ='" + Company_www + "',"
            sqlCommand &= " Buffer_Rate ='" + CDbl(Buffer_Rate).ToString + "',"
            sqlCommand &= " Vat ='" + CDbl(Vat).ToString + "',"
            sqlCommand &= " Import_Tax ='" + CDbl(Import_Tax).ToString + "',"
            sqlCommand &= " Minimum_Stock_Branch ='" + Minimum_Stock_Branch + "',"
            sqlCommand &= " Minimum_Stock_Jobber ='" + Minimum_Stock_Jobber + "',"
            sqlCommand &= " Minimum_Stock_Internet ='" + Minimum_Stock_Internet + "',"
            sqlCommand &= " Minimum_Percentage_Payment ='" + CDbl(Minimum_Percentage_Payment).ToString + "',"
            sqlCommand &= " Max_Row_Page_Staff ='" + Max_Row_Page_Staff + "',"
            sqlCommand &= " Max_Row_Page_User ='" + Max_Row_Page_User + "',"
            sqlCommand &= " updempcd ='" + Empcd + "',"
            sqlCommand &= " updpcnm ='" + Pcnm + "',"
            sqlCommand &= " upddt='" + sqlDb.GetDataTable("SELECT convert(varchar(30),getdate(),120)").Rows(0)(0).ToString + "'"
            sqlCommand &= " WHERE Company_Code='" + Company_Code + "'"

            sqlDb.Exec(sqlCommand)
            sqlDb.CommitTrans()
            message = "Update Company Code : " + Company_Code + " Successful"
        Catch ex As Exception
            message = "Update Currency Code : " + Company_Code + " UnSuccessful"
            message = ex.Message
            sqlDb.RollbackTrans()
        End Try
    End Sub
End Class
