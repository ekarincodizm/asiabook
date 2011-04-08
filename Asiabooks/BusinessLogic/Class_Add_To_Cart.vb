Imports Microsoft.VisualBasic
Imports Eordering.BusinessLogic
Imports System
Imports System.IO
Imports System.Data
Imports System.Configuration
Imports System.Net.Dns

Public Class Class_Add_To_Cart
    Public CartNo As String
    Public dt_In_Branch As DataTable
    Public dt_Other_Branch As DataTable
    Public dt_Jobber As DataTable
    Public amount_Branch As Double
    Public amount_other_Branch As Double
    Public amount_Jobber As Double
    Public keyword_Branch As String
    Public keyword_sales_channel As String
    Private strEmpcd As String
    Private strPcnm As String
    Public strmessage As String

    Property message()
        Get
            Return strmessage
        End Get
        Set(ByVal value)
            strmessage = value
        End Set
    End Property
    Property Pcnm()
        Get
            Return strPcnm
        End Get
        Set(ByVal value)
            strPcnm = value
        End Set
    End Property
    Property _dt_In_Branch()
        Get
            Return dt_In_Branch
        End Get
        Set(ByVal value)
            dt_In_Branch = value
        End Set
    End Property
    Property _CartNo()
        Get
            Return CartNo
        End Get
        Set(ByVal value)
            CartNo = value
        End Set
    End Property
    Property _dt_Other_Branch()
        Get
            Return dt_Other_Branch
        End Get
        Set(ByVal value)
            dt_Other_Branch = value
        End Set
    End Property
    Property _dt_Jobber()
        Get
            Return dt_Jobber
        End Get
        Set(ByVal value)
            dt_Jobber = value
        End Set
    End Property
    Property _amount_Branch()
        Get
            Return amount_Branch
        End Get
        Set(ByVal value)
            amount_Branch = value
        End Set
    End Property
    Property _amount_other_Branch()
        Get
            Return amount_other_Branch
        End Get
        Set(ByVal value)
            amount_other_Branch = value
        End Set
    End Property
    Property _amount_Jobber()
        Get
            Return amount_Jobber
        End Get
        Set(ByVal value)
            amount_Jobber = value
        End Set
    End Property

    Property _keyword_Branch()
        Get
            Return keyword_Branch
        End Get
        Set(ByVal value)
            keyword_Branch = value
        End Set
    End Property
    Property _keyword_sales_channel()
        Get
            Return keyword_sales_channel
        End Get
        Set(ByVal value)
            keyword_sales_channel = value
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
    Public Function Input_Data() As Boolean
        Dim SqlDb As SqlDb = New SqlDb
        Dim SqlStr As String = ""
        Dim dt_CartNO As New DataTable
        Dim Keyword As String = ""

        Dim i As New Integer
        Dim YYMMDD As String = SqlDb.GetDataTable("select convert(varchar(30),getdate(),12)").Rows(0)(0).ToString
        Dim adddt As String = SqlDb.GetDataTable("select convert(varchar(30),getdate(),120)").Rows(0)(0).ToString
        Dim cartdate As String = SqlDb.GetDataTable("select convert(varchar(10),getdate(),120)").Rows(0)(0).ToString

        If CartNo Is Nothing Then
            Keyword = keyword_Branch + YYMMDD + "CR"
            SqlStr = "select isnull(right(max(CartNo),5),0) From Tbt_asbkeo_cart where CartNo like '" + Keyword + "%'"
            dt_CartNO = SqlDb.GetDataTable(SqlStr)
            If dt_CartNO.Rows.Count > 0 Then
                CartNo = Keyword + Convert.ToInt16(CInt(dt_CartNO.Rows(0).Item(0).ToString) + 1).ToString("00000")
            Else
                CartNo = Keyword + "00001"
            End If

        End If

        Try
            SqlDb.BeginTrans()
            SqlStr = ""
            SqlStr = SqlStr + "insert into tbt_asbkeo_cart(cartno,cartdate,Amount_Available,Amount_Other,Amount_Special,Sales_Channel_code"
            If (ConfigurationSettings.AppSettings("UserInternet") = keyword_sales_channel _
                  Or ConfigurationSettings.AppSettings("UserDirectSale") = keyword_sales_channel) Then
                SqlStr = SqlStr + ",field1"
            End If
            SqlStr = SqlStr + ",Org_ab_code,addemp,addpcnm,adddt)"
            SqlStr = SqlStr + " values ('" + CartNo + "','" + cartdate + "'," + CStr(amount_Branch) + "," + CStr(amount_other_Branch) + "," + CStr(amount_Jobber) + ",'" + keyword_sales_channel + "'"

            If (ConfigurationSettings.AppSettings("UserInternet") = keyword_sales_channel _
                              Or ConfigurationSettings.AppSettings("UserDirectSale") = keyword_sales_channel) Then
                SqlStr = SqlStr + ",1"
            End If
            SqlStr = SqlStr + ",'" + keyword_Branch + "','" + Empcd + "','" + Pcnm + "','" + adddt + "')"
            'WriteError("Test Data", SqlStr, CartNo)
            SqlDb.Exec(SqlStr)


            If Not (dt_In_Branch Is Nothing) Then
                For i = 0 To dt_In_Branch.Rows.Count - 1
                    SqlStr = ""
                    SqlStr = SqlStr + "insert into tbt_asbkeo_cartdetail(cartno,cartdtlno,ISBN,unitprice,leadtime,"
                    SqlStr = SqlStr + "weight,cartqty,Amount,Available_group_Id,Org_other_code,ordstt,"
                    SqlStr = SqlStr + "addemp,addpcnm,adddt,Status)"
                    SqlStr = SqlStr + " values ('" + CartNo + "',"
                    SqlStr = SqlStr + "'" + dt_In_Branch.Rows(i).Item(0).ToString + "'"
                    SqlStr = SqlStr + ",'" + dt_In_Branch.Rows(i).Item(2).ToString + "'"
                    SqlStr = SqlStr + "," + dt_In_Branch.Rows(i).Item(3).ToString + ""

                    ' leadtime internet = 5
                    If (ConfigurationSettings.AppSettings("UserInternet") = keyword_sales_channel) Then
                        SqlStr = SqlStr + ",5"
                    Else
                        SqlStr = SqlStr + "," + dt_In_Branch.Rows(i).Item(4).ToString + ""
                    End If
                    SqlStr = SqlStr + "," + dt_In_Branch.Rows(i).Item(5).ToString + ""
                    SqlStr = SqlStr + "," + dt_In_Branch.Rows(i).Item(6).ToString + ""
                    SqlStr = SqlStr + "," + dt_In_Branch.Rows(i).Item(7).ToString + ""
                    SqlStr = SqlStr + ",'1'"
                    SqlStr = SqlStr + ",'" + keyword_Branch + "'"

                    ' ordstt Internet = 2
                    If (ConfigurationSettings.AppSettings("UserInternet") = keyword_sales_channel _
                    Or ConfigurationSettings.AppSettings("UserDirectSale") = keyword_sales_channel) Then
                        SqlStr = SqlStr + ",'2'"
                    Else
                        SqlStr = SqlStr + ",'0'"
                    End If
                    SqlStr = SqlStr + ",'" + Empcd + "'"
                    SqlStr = SqlStr + ",'" + Pcnm + "'"
                    SqlStr = SqlStr + ",'" + adddt + "'"
                    SqlStr = SqlStr + ",'" + dt_In_Branch.Rows(i).Item("Status").ToString + "')"
                    'WriteError("Test Data", SqlStr, CartNo)
                    SqlDb.Exec(SqlStr)

                Next
            End If
            If Not (dt_Other_Branch Is Nothing) Then
                For i = 0 To dt_Other_Branch.Rows.Count - 1
                    SqlStr = ""
                    SqlStr = SqlStr + "insert into tbt_asbkeo_cartdetail(cartno,cartdtlno,ISBN,unitprice,"
                    SqlStr = SqlStr + "leadtime,weight,cartqty,Amount,Available_group_Id,Org_other_code,"
                    SqlStr = SqlStr + "ordstt,addemp,addpcnm,adddt,Status)"
                    SqlStr = SqlStr + " values ('" + CartNo + "',"
                    SqlStr = SqlStr + "'" + dt_Other_Branch.Rows(i).Item(0).ToString + "'"
                    SqlStr = SqlStr + ",'" + dt_Other_Branch.Rows(i).Item(2).ToString + "'"
                    SqlStr = SqlStr + "," + dt_Other_Branch.Rows(i).Item(3).ToString + ""
                    SqlStr = SqlStr + "," + dt_Other_Branch.Rows(i).Item(4).ToString + ""
                    SqlStr = SqlStr + "," + dt_Other_Branch.Rows(i).Item(5).ToString + ""
                    SqlStr = SqlStr + "," + dt_Other_Branch.Rows(i).Item(6).ToString + ""
                    SqlStr = SqlStr + "," + dt_Other_Branch.Rows(i).Item(7).ToString + ""
                    SqlStr = SqlStr + ",'2'"
                    SqlStr = SqlStr + ",'" + dt_Other_Branch.Rows(i).Item(9).ToString + "'"
                    SqlStr = SqlStr + ",'0'"
                    SqlStr = SqlStr + ",'" + Empcd + "'"
                    SqlStr = SqlStr + ",'" + Pcnm + "'"
                    SqlStr = SqlStr + ",'" + adddt + "'"
                    SqlStr = SqlStr + ",'" + dt_Other_Branch.Rows(i).Item("Status").ToString + "')"
                    'WriteError("Test Data", SqlStr, CartNo)
                    SqlDb.Exec(SqlStr)

                Next
            End If
            If Not (dt_Jobber Is Nothing) Then
                For i = 0 To dt_Jobber.Rows.Count - 1
                    SqlStr = ""
                    SqlStr = SqlStr + "insert into tbt_asbkeo_cartdetail(cartno,cartdtlno,ISBN,unitprice,"
                    SqlStr = SqlStr + "leadtime,weight,cartqty,Amount,Available_group_Id,Org_other_code,"
                    SqlStr = SqlStr + "ordstt,addemp,addpcnm,adddt,Status)"
                    SqlStr = SqlStr + " values ('" + CartNo + "',"
                    SqlStr = SqlStr + "'" + dt_Jobber.Rows(i).Item(0).ToString + "'"
                    SqlStr = SqlStr + ",'" + dt_Jobber.Rows(i).Item(2).ToString + "'"
                    SqlStr = SqlStr + "," + dt_Jobber.Rows(i).Item(3).ToString + ""
                    SqlStr = SqlStr + "," + dt_Jobber.Rows(i).Item(4).ToString + ""
                    SqlStr = SqlStr + "," + dt_Jobber.Rows(i).Item(5).ToString + ""
                    SqlStr = SqlStr + "," + dt_Jobber.Rows(i).Item(6).ToString + ""
                    SqlStr = SqlStr + "," + dt_Jobber.Rows(i).Item(7).ToString + ""
                    SqlStr = SqlStr + ",'3'"
                    SqlStr = SqlStr + ",'" + dt_Jobber.Rows(i).Item(9).ToString + "'"
                    ' SqlStr = SqlStr + ",'Ingram'"

                    ' ordstt Internet = 2
                    If (ConfigurationSettings.AppSettings("UserInternet") = keyword_sales_channel _
                    Or ConfigurationSettings.AppSettings("UserDirectSale") = keyword_sales_channel) Then
                        SqlStr = SqlStr + ",'2'"
                    Else
                        SqlStr = SqlStr + ",'0'"
                    End If
                    SqlStr = SqlStr + ",'" + Empcd + "'"
                    SqlStr = SqlStr + ",'" + Pcnm + "'"
                    SqlStr = SqlStr + ",'" + adddt + "'"
                    SqlStr = SqlStr + ",'" + dt_Jobber.Rows(i).Item("Status").ToString + "')"
                    'WriteError("Test Data", SqlStr, CartNo)
                    SqlDb.Exec(SqlStr)
                Next
            End If
            SqlDb.CommitTrans()
            Return True
        Catch ex As Exception
            SqlDb.RollbackTrans()
            message = "Error:Data is not Insert" + ex.Message
            Return False
        End Try

    End Function
    Public Sub Delete()
        Dim sqlDb As New SqlDb
        Dim sqlCommand As String
        Try
            sqlDb.BeginTrans()
            sqlCommand = "DELETE tbt_asbkeo_cart "
            sqlCommand &= " WHERE cartno='" + CartNo + "'"
            sqlDb.Exec(sqlCommand)

            sqlCommand = ""
            sqlCommand = "DELETE tbt_asbkeo_cartdetail "
            sqlCommand &= " WHERE cartno='" + CartNo + "'"
            sqlDb.Exec(sqlCommand)

            sqlDb.CommitTrans()
        Catch ex As Exception

            sqlDb.RollbackTrans()
        End Try
    End Sub
    Public Sub WriteError(ByVal message As String, ByVal str As String, ByVal cartno As String)

        ' Open a file for writing   
        Dim FILENAME As String = "ErrorLog.csv"

        ' Get a StreamReader class that can be used to read the file   
        Dim objStreamWriter As StreamWriter
        objStreamWriter = File.AppendText(FILENAME)

        ' Append the the end of the string, "A user viewed this demo at: "   
        ' followed by the current date and time   
        objStreamWriter.WriteLine(cartno + "," + """" + str + """")

        ' Close the stream   
        objStreamWriter.Close()
    End Sub

End Class
