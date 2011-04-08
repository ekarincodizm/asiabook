Imports Microsoft.VisualBasic
Imports Eordering.BusinessLogic
Imports System
Imports System.Data
Imports System.Net.DNS
Public Class Cls_saleschannel
    Private strSales_Channel_Code As String
    Private strSales_Channel_Name As String
    Private strMark_Up As String
    Private strFrom_Pub_Discount As String
    Private strTo_Pub_Discount As String
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
    Property Sales_Channel_Code()
        Get
            Return strSales_Channel_Code
        End Get
        Set(ByVal value)
            strSales_Channel_Code = value
        End Set
    End Property
    Property Sales_Channel_Name()
        Get
            Return strSales_Channel_Name
        End Get
        Set(ByVal value)
            strSales_Channel_Name = value
        End Set
    End Property
    Property Mark_Up()
        Get
            Return strMark_Up
        End Get
        Set(ByVal value)
            strMark_Up = value
        End Set
    End Property
    Property From_Pub_Discount()
        Get
            Return strFrom_Pub_Discount
        End Get
        Set(ByVal value)
            strFrom_Pub_Discount = value
        End Set
    End Property
    Property To_Pub_Discount()
        Get
            Return strTo_Pub_Discount
        End Get
        Set(ByVal value)
            strTo_Pub_Discount = value
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

        If Sales_Channel_Code <> "" Then
            condition = "WHERE Sales_Channel_Code='" + Sales_Channel_Code + "'"
        End If

        If From_Pub_Discount <> "" Then
            If condition.Length = 0 Then
                condition &= "WHERE From_Pub_Discount = " + CDbl(From_Pub_Discount).ToString + ""
            Else
                condition &= "AND From_Pub_Discount = " + CDbl(From_Pub_Discount).ToString + ""
            End If
        End If

        If To_Pub_Discount <> "" Then
            If condition.Length = 0 Then
                condition &= "WHERE To_Pub_Discount = '" + CDbl(To_Pub_Discount).ToString + "'"
            Else
                condition &= "AND To_Pub_Discount = '" + CDbl(To_Pub_Discount).ToString + "'"
            End If
        End If

       
        sqlCommand = " SELECT *  From tbm_syst_saleschannel " + condition
        dt = sqlDb.GetDataTable(sqlCommand)
        Return dt
    End Function
    Public Sub Add()
        Dim sqlDb As New SqlDb
        Dim sqlCommand As String
        Try

            sqlDb.BeginTrans()
            sqlCommand = "INSERT INTO tbm_syst_saleschannel "
            sqlCommand &= " (Sales_Channel_Code,Sales_Channel_Name,Mark_Up,From_Pub_Discount,"
            sqlCommand &= " To_Pub_Discount,addempcd,addpcnm,adddt)"
            sqlCommand &= " VALUES('" + Sales_Channel_Code + "',"
            sqlCommand &= "'" + Sales_Channel_Name + "',"
            sqlCommand &= "'" + CDbl(Mark_Up).ToString + "',"
            sqlCommand &= "'" + CDbl(From_Pub_Discount).ToString + "',"
            sqlCommand &= "'" + CDbl(To_Pub_Discount).ToString + "',"
            sqlCommand &= "'" + Empcd + "',"
            sqlCommand &= "'" + Pcnm + "',"
            sqlCommand &= "'" + sqlDb.GetDataTable("SELECT convert(varchar(30),getdate(),120)").Rows(0)(0).ToString + "')"
            sqlDb.Exec(sqlCommand)
            sqlDb.CommitTrans()

            message = "Add Sales Channel Code : " + Sales_Channel_Code
            message &= " From Supplier Discount : " + CDbl(From_Pub_Discount).ToString
            message &= " To Supplier Discount : " + CDbl(To_Pub_Discount).ToString
            message &= " Successful"
        Catch ex As Exception
            message = "Add Sales Channel Code : " + Sales_Channel_Code
            message &= " From Supplier Discount : " + CDbl(From_Pub_Discount).ToString
            message &= " To Supplier Discount : " + CDbl(To_Pub_Discount).ToString
            message &= " UnSuccessful"
            'message = ex.Message
            sqlDb.RollbackTrans()
        End Try
    End Sub
    Public Sub Edit()
        Dim sqlDb As New SqlDb
        Dim sqlCommand As String
        Try

            sqlDb.BeginTrans()
            sqlCommand = "UPDATE tbm_syst_saleschannel "
            sqlCommand &= " SET Sales_Channel_Name ='" + Sales_Channel_Name + "',"
            sqlCommand &= " Mark_Up='" + CDbl(Mark_Up).ToString + "',"
            sqlCommand &= " updempcd='" + Empcd + "',"
            sqlCommand &= " updpcnm='" + Pcnm + "',"
            sqlCommand &= " upddt='" + sqlDb.GetDataTable("SELECT convert(varchar(30),getdate(),120)").Rows(0)(0).ToString + "'"
            sqlCommand &= " WHERE Sales_Channel_Code='" + Sales_Channel_Code + "'"
            sqlCommand &= " and From_Pub_Discount='" + CDbl(From_Pub_Discount).ToString + "'"
            sqlCommand &= " and To_Pub_Discount='" + CDbl(To_Pub_Discount).ToString + "'"

            sqlDb.Exec(sqlCommand)
            sqlDb.CommitTrans()
            message = "Update Sales Channel Code : " + Sales_Channel_Code
            message &= " From Supplier Discount : " + CDbl(From_Pub_Discount).ToString
            message &= " To Supplier Discount : " + CDbl(To_Pub_Discount).ToString
            message &= " Successful"

        Catch ex As Exception
            message = "Update Sales Channel Code : " + Sales_Channel_Code
            message &= " From Supplier Discount : " + CDbl(From_Pub_Discount).ToString
            message &= " To Supplier Discount : " + CDbl(To_Pub_Discount).ToString
            message &= " UnSuccessful"
            sqlDb.RollbackTrans()
        End Try
    End Sub
    Public Sub Delete()
        Dim sqlDb As New SqlDb
        Dim sqlCommand As String
        Try
            sqlDb.BeginTrans()
            sqlCommand = "DELETE tbm_syst_saleschannel "
            sqlCommand &= " WHERE Sales_Channel_Code='" + Sales_Channel_Code + "'"
            sqlCommand &= " and From_Pub_Discount='" + CDbl(From_Pub_Discount).ToString + "'"
            sqlCommand &= " and To_Pub_Discount='" + CDbl(To_Pub_Discount).ToString + "'"


            sqlDb.Exec(sqlCommand)
            sqlDb.CommitTrans()
            message = " Delete Sales Channel Code : " + Sales_Channel_Code
            message &= " From Supplier Discount : " + CDbl(From_Pub_Discount).ToString
            message &= " To Supplier Discount : " + CDbl(To_Pub_Discount).ToString
            message &= " Successful"
        Catch ex As Exception
            message = "Delete Sales Channel Code : " + Sales_Channel_Code
            message &= " From Supplier Discount : " + CDbl(From_Pub_Discount).ToString
            message &= " To Supplier Discount : " + CDbl(To_Pub_Discount).ToString
            message &= " UnSuccessful"
            sqlDb.RollbackTrans()
        End Try
    End Sub
End Class
