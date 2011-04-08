Imports Microsoft.VisualBasic
Imports Eordering.BusinessLogic
Imports System
Imports System.Data
Imports System.Configuration
Imports System.Net.DNS
Public Class Cls_PO
    Public message As String
    Public Order_Date_From As String
    Public Order_Date_To As String
    Public Customer_Name As String
    Private strOrder_No As String
    Private strAddress_Org_Ab As String
    Private strCustomer_Name As String
    Private strOrder_Status As String
    Private strISBN As String
    Private strBook_Title As String
    Private strPo_No As String
    Private strUnitprice As String
    Private strRemark As String
    Private strOrderdtl_No As String
    Private strAvailable_Group_Id As String
    Private strEmpcd As String
    Private strPcnm As String
    Private strPayment As String

    Property Pcnm()
        Get
            Return strPcnm
        End Get
        Set(ByVal value)
            strPcnm = value
        End Set
    End Property
    Property Order_No()
        Get
            Return strOrder_No
        End Get
        Set(ByVal value)
            strOrder_No = value
        End Set
    End Property
    Property Address_Org_Ab()
        Get
            Return strAddress_Org_Ab
        End Get
        Set(ByVal value)
            strAddress_Org_Ab = value
        End Set
    End Property
    Property Order_Status()
        Get
            Return strOrder_Status
        End Get
        Set(ByVal value)
            strOrder_Status = value
        End Set
    End Property
    Property Payment()
        Get
            Return strPayment
        End Get
        Set(ByVal value)
            strPayment = value
        End Set
    End Property
    Property ISBN()
        Get
            Return strISBN
        End Get
        Set(ByVal value)
            strISBN = value
        End Set
    End Property
    Property Book_Title()
        Get
            Return strBook_Title
        End Get
        Set(ByVal value)
            strBook_Title = value
        End Set
    End Property
    Property Po_No()
        Get
            Return strPo_No
        End Get
        Set(ByVal value)
            strPo_No = value
        End Set
    End Property
    Property Unitprice()
        Get
            Return strUnitprice
        End Get
        Set(ByVal value)
            strUnitprice = value
        End Set
    End Property
    Property Remark()
        Get
            Return strRemark
        End Get
        Set(ByVal value)
            strRemark = value
        End Set
    End Property
    Property Orderdtl_No()
        Get
            Return strOrderdtl_No
        End Get
        Set(ByVal value)
            strOrderdtl_No = value
        End Set
    End Property
    Property Available_Group_Id()
        Get
            Return strAvailable_Group_Id
        End Get
        Set(ByVal value)
            strAvailable_Group_Id = value
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
    Public Function RetreiveCoDetail_HOInternet()
        Dim sqlDb As New SqlDb
        Dim dt As DataTable
        Dim sqlCommand As String
        Dim condition As String = ""

        Dim Order_Date_From_Arr(2) As String
        Dim Order_Date_From_Convert As String
        Dim Order_Date_To_Arr(2) As String
        Dim Order_Date_To_Convert As String




        If Order_No <> "" Then
            condition = " AND b.Order_No='" + Order_No + "'"
        End If
        If Customer_Name <> "" Then
            condition &= " AND Customer_Name+Last_Name like '%" + Customer_Name + "%'"
        End If

        If Order_Status <> "0" Then
            condition &= " AND Order_Status = '" + Order_Status + "'"
        End If
        If ISBN <> "" Then
            condition &= " AND ISBN like '%" + ISBN + "%'"
        End If

        If Book_Title <> "" Then
            condition &= " AND a.Book_Title_Report like '%" + Book_Title + "%'"
        End If

        If Address_Org_Ab <> "0" Then
            condition &= " AND Address_Org_Ab = '" + Address_Org_Ab + "'"
        End If

        If Order_Date_From <> "" Then
            Order_Date_From_Arr = Order_Date_From.ToString.Split("/")
            Order_Date_From_Convert = Order_Date_From_Arr(2) & "/" & Order_Date_From_Arr(1) & "/" & Order_Date_From_Arr(0)
            condition &= " AND Order_Date >= '" + Order_Date_From_Convert + "'"

        End If

        If Order_Date_To <> "" Then
            Order_Date_To_Arr = Order_Date_To.ToString.Split("/")
            Order_Date_To_Convert = Order_Date_To_Arr(2) & "/" & Order_Date_To_Arr(1) & "/" & Order_Date_To_Arr(0)

            condition &= " AND Order_Date<='" + Order_Date_To_Convert + "'"
        End If
        sqlCommand = " SELECT  a.Order_No,isnull(Po_No,'') as Po_No,Orderdtl_No,"
        sqlCommand &= " Customer_Name+' '+Last_Name as Customer_Name,"
        sqlCommand &= " a.Book_Title_Report,ISBN,Address_Org_Ab,"
        sqlCommand &= " case Order_Status when '1' then 'Waiting for Payment' "
        sqlCommand &= " when '2' then 'Payment Received'"
        sqlCommand &= " when '3' then 'On Process'"
        sqlCommand &= " when '4' then 'Order Delivered'"
        'tom+u.2009-06-09 k.Orapin Request
        sqlCommand &= " when '6' then 'Finished'"
        sqlCommand &= " when '7' then 'Not Saleable'"
        'sqlCommand &= " when '6' then 'Shipped'"
        sqlCommand &= " else 'Order Cancelled'"
        sqlCommand &= "end as Order_Status,"
        sqlCommand &= " convert(varchar(10),Order_Date,103) as Order_Date,"
        sqlCommand &= " isnull(convert(varchar(10),Deliver_Date,103),'') as Deliver_Date,"
        sqlCommand &= " isnull(convert(varchar(10),Job_Date,103),'') as Job_Date,"
        sqlCommand &= " isnull(convert(varchar(10),Complete_Date,103),'') as Complete_Date,"
        sqlCommand &= " isnull(Jobber,'') as Jobber ,b.Grand_Total,isnull(a.Remark,'') as Remark,case a.payment when '--Select--' then '' else a.payment end as payment "
        sqlCommand &= " FROM tbt_asbkeo_cus_orderdtl a,tbt_asbkeo_cus_order b"
        'sqlCommand &= " ,tbt_jobber_book_search c"
        sqlCommand &= " WHERE a.Order_No = b.Order_No" + condition
        ' sqlCommand &= " AND a.isbn=c.isbn_13" + condition
        sqlCommand &= " ORDER BY b.order_date desc ,a.Order_No desc"
        dt = sqlDb.GetDataTable(sqlCommand)

        Return dt

    End Function
    Public Function RetreiveCoDetail()
        Dim sqlDb As New SqlDb
        Dim dt As DataTable
        Dim sqlCommand As String
        Dim condition As String = ""

        Dim Order_Date_From_Arr(2) As String
        Dim Order_Date_From_Convert As String
        Dim Order_Date_To_Arr(2) As String
        Dim Order_Date_To_Convert As String




        If Order_No <> "" Then
            condition = " AND b.Order_No='" + Order_No + "'"
        End If
        If Customer_Name <> "" Then
            condition &= " AND Customer_Name+Last_Name like '%" + Customer_Name + "%'"
        End If

        If Order_Status <> "0" Then
            condition &= " AND Order_Status = '" + Order_Status + "'"
        End If
        If ISBN <> "" Then
            condition &= " AND ISBN like '%" + ISBN + "%'"
        End If

        If Book_Title <> "" Then
            condition &= " AND Book_Title like '%" + Book_Title + "%'"
        End If

        If Address_Org_Ab <> "0" Then
            condition &= " AND Address_Org_Ab = '" + Address_Org_Ab + "'"
        End If

        If Order_Date_From <> "" Then
            Order_Date_From_Arr = Order_Date_From.ToString.Split("/")
            Order_Date_From_Convert = Order_Date_From_Arr(2) & "/" & Order_Date_From_Arr(1) & "/" & Order_Date_From_Arr(0)
            condition &= " AND Order_Date >= '" + Order_Date_From_Convert + "'"

        End If

        If Order_Date_To <> "" Then
            Order_Date_To_Arr = Order_Date_To.ToString.Split("/")
            Order_Date_To_Convert = Order_Date_To_Arr(2) & "/" & Order_Date_To_Arr(1) & "/" & Order_Date_To_Arr(0)

            condition &= " AND Order_Date<='" + Order_Date_To_Convert + "'"
        End If
        sqlCommand = " SELECT  a.Order_No,isnull(Po_No,'') as Po_No,Orderdtl_No,"
        sqlCommand &= " Customer_Name+' '+Last_Name as Customer_Name,"
        sqlCommand &= " Book_Title_Report,ISBN,Address_Org_Ab,"
        sqlCommand &= " case Order_Status when '1' then 'ON ORDERING PROCESS' "
        sqlCommand &= " when '2' then 'ON SHIPPING PROCESS'"
        sqlCommand &= " when '3' then 'SHIPPED OUT'"
        sqlCommand &= " when '4' then 'BACKORDER/OUT OF STOCK'"
        'tom+u.2009-06-09 k.Orapin Request
        'sqlCommand &= " when '5' then 'Out of  Stock'"
        'sqlCommand &= " when '6' then 'Shipped'"
        sqlCommand &= " else 'CANCELLED'"
        sqlCommand &= "end as Order_Status,"
        sqlCommand &= " convert(varchar(10),Order_Date,103) as Order_Date,"
        sqlCommand &= " isnull(convert(varchar(10),Deliver_Date,103),'') as Deliver_Date,"
        sqlCommand &= " isnull(convert(varchar(10),Job_Date,103),'') as Job_Date,"
        sqlCommand &= " isnull(convert(varchar(10),Complete_Date,103),'') as Complete_Date,"
        sqlCommand &= " isnull(Jobber,'') as Jobber"
        sqlCommand &= " FROM tbt_asbkeo_cus_orderdtl a,tbt_asbkeo_cus_order b"
        'sqlCommand &= " tbt_jobber_book_search c"
        sqlCommand &= " WHERE a.Order_No = b.Order_No" + condition
        'sqlCommand &= " AND a.isbn=c.isbn_13"
        sqlCommand &= " AND Address_Org_Ab <> 'HO-Internet' ORDER BY a.Order_No,Orderdtl_No"
        dt = sqlDb.GetDataTable(sqlCommand)

        Return dt

    End Function
    Public Function Retreive()
        Dim sqlDb As New SqlDb
        Dim dt As DataTable
        Dim sqlCommand As String
        Dim condition As String = ""
        sqlCommand = "SELECT Customer_Name+' '+Last_Name as Customer_Name,Org_AB_Name,"
        sqlCommand &= "convert(varchar(10),Order_Date,103) as Order_Date,"
        sqlCommand &= "isnull(a.addempcd,'') as addempcd,Sales_Channel_Name"
        sqlCommand &= " FROM tbt_asbkeo_cus_order a,tbm_syst_organizeab b,"
        sqlCommand &= "tbt_asbkeo_cus_orderdtl c,tbm_syst_saleschannel d"
        sqlCommand &= " WHERE(a.Address_Org_Ab = b.Org_AB_code)"
        sqlCommand &= " AND a.Order_No=c.Order_no"
        sqlCommand &= " AND a.Sales_Channel_Code=d.Sales_Channel_Code"
        sqlCommand &= " AND a.Order_No='" + Order_No + "'"
        sqlCommand &= " ORDER BY a.Order_No"

        dt = sqlDb.GetDataTable(sqlCommand)

        Return dt

    End Function
    Public Function RetreivePoDetail()
        Dim sqlDb As New SqlDb
        Dim dt As DataTable
        Dim sqlCommand As String
        Dim condition As String = ""

        sqlCommand = "SELECT Orderdtl_No,isnull(Po_No,'') as Po_No ,"
        sqlCommand &= "Order_Status,Book_Title_Report,ISBN,Orderqty,"
        sqlCommand &= "isnull(convert(varchar(10),Complete_Date,103),'') as Complete_Date,"
        sqlCommand &= "Unitprice,isnull(Discount,0) as Discount,"
        sqlCommand &= "isnull(Jobber,'') as Jobber,isnull(Remark,'') as Remark,"
        sqlCommand &= "isnull(convert(varchar(10),Job_Date,103),'') as Job_Date"
        sqlCommand &= ",Available_Group_Id,isnull(payment,'') as payment"
        sqlCommand &= " FROM tbt_asbkeo_cus_orderdtl "
        sqlCommand &= " WHERE  "
        sqlCommand &= " Order_No='" + Order_No + "'"
        sqlCommand &= " ORDER BY Orderdtl_No"

        dt = sqlDb.GetDataTable(sqlCommand)

        Return dt

    End Function
    Public Sub UpdateCo()
        Dim sqlDb As New SqlDb
        Dim sqlCommand As String
        Try
            sqlDb.BeginTrans()
            sqlCommand = "UPDATE tbt_asbkeo_cus_orderdtl"
            sqlCommand &= " SET  Po_No='" + Po_No + "',"
            sqlCommand &= "Order_Status='" + Order_Status + "',"
            sqlCommand &= "ISBN='" + ISBN + "',"
            sqlCommand &= "Unitprice='" + CDbl(Unitprice).ToString + "',"
            sqlCommand &= " updempcd='" + Empcd + "',"
            sqlCommand &= " updpcnm='" + Pcnm + "',"
            sqlCommand &= " upddt='" + sqlDb.GetDataTable("SELECT convert(varchar(30),getdate(),120)").Rows(0)(0).ToString + "',"
            sqlCommand &= " Remark='" + Remark + "',"
            sqlCommand &= " payment='" + Payment + "'"
            sqlCommand &= " WHERE Order_No='" + Order_No + "'"
            sqlCommand &= " AND Orderdtl_No='" + Orderdtl_No + "'"
            sqlCommand &= " AND Available_Group_Id='" + Available_Group_Id + "'"
            sqlDb.Exec(sqlCommand)
            sqlDb.CommitTrans()
            message = "UPDATE Customer Order : " + Order_No + " Successful"
        Catch ex As Exception
            sqlDb.RollbackTrans()
            message = ex.Message
        End Try
    End Sub
    Public Function CheckIsbn()
        Dim sqlDb As New SqlDb
        Dim dt As DataTable
        Dim sqlCommand As String
        Dim condition As String = ""
        sqlCommand = "SELECT * From tbt_jobber_book_search"
        sqlCommand &= " WHERE ISBN_13 ='" + ISBN + "'"
        dt = sqlDb.GetDataTable(sqlCommand)

        Return dt

    End Function


End Class
