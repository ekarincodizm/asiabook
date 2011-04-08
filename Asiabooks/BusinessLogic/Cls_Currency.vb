Imports Microsoft.VisualBasic
Imports Eordering.BusinessLogic
Imports System
Imports System.Data
Imports System.Net.DNS
Public Class Cls_Currency
    Private strCurrency_Code As String
    Private strCurrency_Name As String
    Private strExchange_Rate As String
    Private strMaintenance_Date As String
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
    Property Currency_Code()
        Get
            Return strCurrency_Code
        End Get
        Set(ByVal value)
            strCurrency_Code = value
        End Set
    End Property


    Property Currency_Name()
        Get
            Return strCurrency_Name
        End Get
        Set(ByVal value)
            strCurrency_Name = value
        End Set
    End Property

    Property Exchange_Rate()
        Get
            Return strExchange_Rate
        End Get
        Set(ByVal value)
            strExchange_Rate = value
        End Set
    End Property

    Property Maintenance_Date()
        Get
            Return strMaintenance_Date
        End Get
        Set(ByVal value)
            strMaintenance_Date = value
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
        Dim bufferrate As String = sqlDb.GetDataTable("SELECT Buffer_Rate/100 FROM tbm_syst_company").Rows(0)(0).ToString
        If Currency_Code <> "" Then
            condition = "WHERE Currency_Code='" + Currency_Code + "'"
        End If

        If Currency_Name <> "" Then
            If condition.Length = 0 Then
                condition &= "WHERE Currency_Name like '%" + Currency_Name + "%'"
            Else
                condition &= "AND Currency_Name like '%" + Currency_Name + "%'"
            End If
        End If
        sqlCommand = " SELECT Currency_Code,Currency_Name,Exchange_Rate,Convert(nvarchar,Maintenance_Date,103) as Maintenance_Date,Exchange_Rate+(" + bufferrate + "*Exchange_Rate) as excbuf From tbm_syst_currency " + condition
        dt = sqlDb.GetDataTable(sqlCommand)
        Return dt
    End Function
    Public Sub Add()
        Dim sqlDb As New SqlDb
        Dim sqlCommand As String
        Dim MaintenanceArr(2) As String
        Dim MaintenanceConvert As String
        Try



            MaintenanceArr = Maintenance_Date.ToString.Split("/")
            MaintenanceConvert = MaintenanceArr(2) & "-" & MaintenanceArr(1) & "-" & MaintenanceArr(0)
           


            sqlDb.BeginTrans()
            sqlCommand = "INSERT INTO tbm_syst_currency"
            sqlCommand &= "(Currency_Code, Currency_Name,Exchange_Rate,Maintenance_Date,"
            sqlCommand &= "addempcd,addpcnm,adddt)"
            sqlCommand &= " VALUES('" + Currency_Code + "',"
            sqlCommand &= "'" + Currency_Name + "',"
            sqlCommand &= "'" + CDbl(Exchange_Rate).ToString + "',"
            'sqlCommand &= "'" + sqlDb.GetDataTable("SELECT convert(varchar(10),getdate(),120)").Rows(0)(0).ToString + "',"
            sqlCommand &= "'" + MaintenanceConvert + "',"
            sqlCommand &= "'" + Empcd + "',"
            sqlCommand &= "'" + Pcnm + "',"
            sqlCommand &= "'" + sqlDb.GetDataTable("SELECT convert(varchar(30),getdate(),120)").Rows(0)(0).ToString + "')"
            sqlDb.Exec(sqlCommand)
            sqlDb.CommitTrans()
            message = "Add Currency Code : " + Currency_Code + " Successful"
        Catch ex As Exception
            message = "Add Currency Code : " + Currency_Code + " UnSuccessful, " + ex.Message
            sqlDb.RollbackTrans()
        End Try
    End Sub
    Public Sub Edit()
        Dim sqlDb As New SqlDb
        Dim sqlCommand As String
        Try

            sqlDb.BeginTrans()
            sqlCommand = "UPDATE tbm_syst_currency"
            sqlCommand &= " SET Currency_Name='" + Currency_Name + "',"
            sqlCommand &= " Exchange_Rate='" + CDbl(Exchange_Rate).ToString + "',"
            sqlCommand &= " Maintenance_Date= Convert(Datetime,'" + Maintenance_Date + "',103),"
            sqlCommand &= " updempcd='" + Empcd + "',"
            sqlCommand &= " updpcnm='" + Pcnm + "',"
            sqlCommand &= " upddt='" + sqlDb.GetDataTable("SELECT convert(varchar(30),getdate(),120)").Rows(0)(0).ToString + "'"
            sqlCommand &= " WHERE Currency_Code='" + Currency_Code + "'"
            sqlDb.Exec(sqlCommand)
            sqlDb.CommitTrans()
            message = "Update Currency Code : " + Currency_Code + " Successful"
        Catch ex As Exception
            message = "Update Currency Code : " + Currency_Code + " UnSuccessful"
            sqlDb.RollbackTrans()
        End Try
    End Sub
    Public Sub Delete()
        Dim sqlDb As New SqlDb
        Dim sqlCommand As String
        Try
            sqlDb.BeginTrans()
            sqlCommand = "DELETE tbm_syst_currency"
            sqlCommand &= " WHERE Currency_Code='" + Currency_Code + "'"
            sqlDb.Exec(sqlCommand)
            sqlDb.CommitTrans()
            message = "Delete Currency Code : " + Currency_Code + " Successful"
        Catch ex As Exception
            message = "Delete Currency Code : " + Currency_Code + " UnSuccessful"
            sqlDb.RollbackTrans()
        End Try
    End Sub
End Class
