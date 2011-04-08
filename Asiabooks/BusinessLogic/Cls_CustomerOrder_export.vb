Imports Microsoft.VisualBasic
Imports Eordering.BusinessLogic
Imports System
Imports System.Data
Imports System.Configuration
Public Class Cls_CustomerOrder_export
    Dim DateNow As String
    Private strOrder_No As String
    Private strAvailable_Group_Id As String
    Private strPayment_method_Code As String
    Private strPayment_type As String
    Private strForm As String
    Public Exchange_Rate As String
    Property Order_No()
        Get
            Return strOrder_No
        End Get
        Set(ByVal value)
            strOrder_No = value
        End Set
    End Property
    Property Payment_method_Code()
        Get
            Return strPayment_method_Code
        End Get
        Set(ByVal value)
            strPayment_method_Code = value
        End Set
    End Property
    Property Payment_type()
        Get
            Return strPayment_type
        End Get
        Set(ByVal value)
            strPayment_type = value
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
    Property Form()
        Get
            Return strForm
        End Get
        Set(ByVal value)
            strForm = value
        End Set
    End Property
    Public Function RetreiveCus_order()
        Dim sqlDb As New SqlDb
        Dim dt As DataTable
        Dim sqlCommand As String

        Dim dtEx As New DataTable
        Dim sqlEx As String
        sqlEx = "SELECT isnull(Exchange_Rate,0) as Exchange_Rate FROM tbt_asbkeo_cus_order WHERE Order_No='" + Order_No + "'"
        dtEx = sqlDb.GetDataTable(sqlEx)
        If dtEx.Rows.Count > 0 Then
            Exchange_Rate = dtEx.Rows(0).Item("Exchange_Rate").ToString
        Else
            Exchange_Rate = 0
        End If

        sqlCommand = " SELECT a.Order_No,convert(varchar(10),a.Order_Date,103) as Order_Date,a.Customer_Name,a.Last_Name,a.Telephone "
        sqlCommand += " ,a.Ship_To_Name,a.Ship_To_Address,a.Total_Weight,a.Max_Leadtime,a.Total_Amount "
        sqlCommand += " ,a.Delivery_Cost,a.Grand_Total,a.Deposit_Amount,a.Balance,a.Transport_Type,isnull(a.Email,'') as Email "
        sqlCommand += " ,a.Country_Code,b.Country_Name,isnull(a.field2,'') as field2,isnull(a.Email,'') as Email,isnull(a.Ref_Cus_No,'') as Ref_Cart_No,isnull(a.Billing_Name,'') as Billing_Name "
        sqlCommand += " ,isnull(a.Billing_Address,'') as Billing_Address,isnull(a.Gift_Flag,'') as Gift_Flag"
        sqlCommand += " ,isnull(a.Gift_From,'') as Gift_From,isnull(a.Gift_to,'') as Gift_to "
        sqlCommand += " ,isnull(a.Gift_Message,'') as Gift_Message "
        sqlCommand += " ,isnull(a.Delivery_Available,0.00) as Delivery_Available,isnull(a.Delivery_special,0.00) as Delivery_special "
        sqlCommand += " ,isnull(Deposit_Amount,0.00) as Deposit_Amount"
        sqlCommand += " ,isnull(Payment_Method_Code,'') as Payment_Method_Code "
        sqlCommand += " ,isnull(Payment_type,'') as Payment_type "


        If Exchange_Rate <> 0 Then
            sqlCommand &= ",Total_Amount/" + Exchange_Rate + " as Total_Amount_USD"
            sqlCommand &= ",Delivery_Cost/" + Exchange_Rate + " as Delivery_Cost_USD"
            sqlCommand &= ",Delivery_Available/" + Exchange_Rate + " as Delivery_Available_USD"
            sqlCommand &= ",Delivery_special/" + Exchange_Rate + " as Delivery_special_USD"
            sqlCommand &= ",Grand_Total/" + Exchange_Rate + " as Grand_Total_USD"
            sqlCommand &= ",Deposit_Amount/" + Exchange_Rate + " as Deposit_Amount_USD"
            sqlCommand &= ",Balance/" + Exchange_Rate + " as Balance_USD"
        Else
            sqlCommand &= ",'0.00' as Total_Amount_USD"
            sqlCommand &= ",'0.00' as Delivery_Cost_USD"
            sqlCommand &= ",'0.00' as Delivery_Available_USD"
            sqlCommand &= ",'0.00' as Delivery_special_USD"
            sqlCommand &= ",'0.00' as Grand_Total_USD"
            sqlCommand &= ",'0.00' as Deposit_Amount_USD"
            sqlCommand &= ",'0.00' as Balance_USD"
        End If

        sqlCommand += " From tbt_asbkeo_cus_order as a left join tbm_syst_country as b "
        sqlCommand += " on a.Country_Code = b.Country_Code "
        sqlCommand += " and a.zone=b.Zone_Code"
        sqlCommand += " where a.Order_No = '" + Order_No + "'"
        dt = sqlDb.GetDataTable(sqlCommand)
        Return dt
    End Function
    Public Function RetreiveCus_order_PickUpAsBranch()
        Dim sqlDb As New SqlDb
        Dim dt As DataTable
        Dim sqlCommand As String

        Dim dtEx As New DataTable
        Dim sqlEx As String
        sqlEx = "SELECT isnull(Exchange_Rate,0) as Exchange_Rate FROM tbt_asbkeo_cus_order WHERE Order_No='" + Order_No + "'"
        dtEx = sqlDb.GetDataTable(sqlEx)
        If dtEx.Rows.Count > 0 Then
            Exchange_Rate = dtEx.Rows(0).Item("Exchange_Rate").ToString
        Else
            Exchange_Rate = 0
        End If

        sqlCommand = " SELECT Order_No,convert(varchar(10),Order_Date,103) as Order_Date,Customer_Name,Last_Name,Telephone "
        sqlCommand += " ,Ship_To_Name,Ship_To_Address,Total_Weight,Max_Leadtime,Total_Amount "
        sqlCommand += " ,Delivery_Cost,Grand_Total,Deposit_Amount,Balance,Transport_Type "
        sqlCommand += " ,Country_Code,isnull(field2,'') as Country_Name,isnull(Billing_Name,'') as Billing_Name,isnull(Email,'') as Email "
        sqlCommand += " ,isnull(Billing_Address,'') as Billing_Address,isnull(Gift_Flag,'') as Gift_Flag"
        sqlCommand += " ,isnull(Gift_From,'') as Gift_From,isnull(Gift_to,'') as Gift_to "
        sqlCommand += " ,isnull(Gift_Message,'') as Gift_Message "
        sqlCommand += " ,isnull(Delivery_Available,0.00) as Delivery_Available,isnull(Delivery_special,0.00) as Delivery_special "
        sqlCommand += " ,isnull(Deposit_Amount,0.00) as Deposit_Amount"
        sqlCommand += " ,isnull(Payment_Method_Code,'') as Payment_Method_Code "
        sqlCommand += " ,isnull(Payment_type,'') as Payment_type "


        If Exchange_Rate <> 0 Then
            sqlCommand &= ",Total_Amount/" + Exchange_Rate + " as Total_Amount_USD"
            sqlCommand &= ",Delivery_Cost/" + Exchange_Rate + " as Delivery_Cost_USD"
            sqlCommand &= ",Delivery_Available/" + Exchange_Rate + " as Delivery_Available_USD"
            sqlCommand &= ",Delivery_special/" + Exchange_Rate + " as Delivery_special_USD"
            sqlCommand &= ",Grand_Total/" + Exchange_Rate + " as Grand_Total_USD"
            sqlCommand &= ",Deposit_Amount/" + Exchange_Rate + " as Deposit_Amount_USD"
            sqlCommand &= ",Balance/" + Exchange_Rate + " as Balance_USD"
        Else
            sqlCommand &= ",'0.00' as Total_Amount_USD"
            sqlCommand &= ",'0.00' as Delivery_Cost_USD"
            sqlCommand &= ",'0.00' as Delivery_Available_USD"
            sqlCommand &= ",'0.00' as Delivery_special_USD"
            sqlCommand &= ",'0.00' as Grand_Total_USD"
            sqlCommand &= ",'0.00' as Deposit_Amount_USD"
            sqlCommand &= ",'0.00' as Balance_USD"
        End If

        sqlCommand += " From tbt_asbkeo_cus_order "
        'sqlCommand += " on a.Country_Code = b.Country_Code "
        'sqlCommand += " and a.zone=b.Zone_Code"
        sqlCommand += " where Order_No = '" + Order_No + "'"
        dt = sqlDb.GetDataTable(sqlCommand)
        Return dt
    End Function
    Public Function RetreiveCus_order_emp()
        Dim sqlDb As New SqlDb
        Dim dt As DataTable
        Dim sqlCommand As String

        'Exchange_Rate = sqlDb.GetDataTable("SELECT isnull(Exchange_Rate,0) FROM tbt_asbkeo_cus_order WHERE Order_No='" + Order_No + "'").Rows(0)(0).ToString

        sqlCommand = " SELECT a.Order_No,convert(varchar(10),a.Order_Date,103) as Order_Date,a.Customer_Name,a.Last_Name,a.Telephone "
        sqlCommand += " ,a.Ship_To_Name,a.Ship_To_Address,a.Total_Weight,a.Max_Leadtime,a.Total_Amount "
        sqlCommand += " ,a.Delivery_Cost,a.Grand_Total,a.Deposit_Amount,a.Balance,a.Transport_Type "
        sqlCommand += " ,a.Country_Code,b.Country_Name,a.field2,isnull(a.Billing_Name,'') as Billing_Name "
        sqlCommand += " ,isnull(a.Billing_Address,'') as Billing_Address,isnull(a.Gift_Flag,'') as Gift_Flag"
        sqlCommand += " ,isnull(a.Gift_From,'') as Gift_From,isnull(a.Gift_to,'') as Gift_to "
        sqlCommand += " ,isnull(a.Gift_Message,'') as Gift_Message "
        sqlCommand += " ,isnull(a.Delivery_Available,0.00) as Delivery_Available,isnull(a.Delivery_special,0.00) as Delivery_special "
        sqlCommand += " ,isnull(Deposit_Amount,0.00) as Deposit_Amount"
        sqlCommand += " ,isnull(Payment_Method_Code,'') as Payment_Method_Code "
        sqlCommand += " ,isnull(Payment_type,'') as Payment_type,a.Ref_Cus_No as Ref_Cart_No ,isnull(a.Email,'') as Email "
        sqlCommand += " From tbt_asbkeo_cus_order as a left join tbm_syst_country as b "
        sqlCommand += " on a.Country_Code = b.Country_Code "
        sqlCommand += " and a.zone=b.Zone_Code"
        sqlCommand += " where a.Order_No = '" + Order_No + "'"
        dt = sqlDb.GetDataTable(sqlCommand)
        Return dt
    End Function
    Public Function RetreiveCus_order_detail()
        Dim sqlDb As New SqlDb
        Dim dt As New DataTable
        Dim sqlCommand As String
        Dim dtEx As New DataTable
        Dim sqlEx As String
        sqlEx = "SELECT isnull(Exchange_Rate,0) as Exchange_Rate FROM tbt_asbkeo_cus_order WHERE Order_No='" + Order_No + "'"
        dtEx = sqlDb.GetDataTable(sqlEx)
        If dtEx.Rows.Count > 0 Then
            Exchange_Rate = dtEx.Rows(0).Item("Exchange_Rate").ToString
        Else
            Exchange_Rate = 0
        End If

        sqlCommand = " SELECT Orderdtl_No,Book_Title_Report,ISBN,Weight,Unitprice,Orderqty,Amount "

        sqlCommand &= " ,case Order_Status when '1' then 'ON ORDERING PROCESS' "
        sqlCommand &= " when '2' then 'ON SHIPPING PROCESS'"
        sqlCommand &= " when '3' then 'SHIPPED OUT'"
        sqlCommand &= " when '4' then 'BACKORDER/OUT OF STOCK'"
        'tom+u.2009-06-09 k.Orapin Request
        'sqlCommand &= " when '5' then 'Out of  Stock'"
        'sqlCommand &= " when '6' then 'Shipped'"
        sqlCommand &= " else 'CANCELLED'"
        sqlCommand += " end as Order_Status"
        sqlCommand += " ,isnull(Discount,0) as Discount"
        If Exchange_Rate <> 0 Then
            sqlCommand &= " ,Amount/" + Exchange_Rate + " as USD"
        Else
            sqlCommand &= " ,'0.00' as USD"
        End If
        sqlCommand += " From tbt_asbkeo_cus_orderdtl "
        'sqlCommand += " left join (select distinct isbn_13,Book_Title from tbt_jobber_book_search) as b "
        'sqlCommand += " on a.ISBN = b.ISBN_13 "
        sqlCommand += " where Order_No = '" + Order_No + "'"
        If Available_Group_Id <> "" Then
            sqlCommand += " and Available_Group_Id = '" + Available_Group_Id + "'"
        End If
        sqlCommand += " order by Orderdtl_No"
        dt = sqlDb.GetDataTable(sqlCommand)
        Return dt
    End Function
    Public Function RetreiveCus_order_detail_internet()
        Dim sqlDb As New SqlDb
        Dim dt As New DataTable
        Dim sqlCommand As String
        Dim dtEx As New DataTable
        Dim sqlEx As String
        sqlEx = "SELECT isnull(Exchange_Rate,0) as Exchange_Rate FROM tbt_asbkeo_cus_order WHERE Order_No='" + Order_No + "'"
        dtEx = sqlDb.GetDataTable(sqlEx)
        If dtEx.Rows.Count > 0 Then
            Exchange_Rate = dtEx.Rows(0).Item("Exchange_Rate").ToString
        Else
            Exchange_Rate = 0
        End If

        sqlCommand = " SELECT Orderdtl_No,Book_Title_Report,ISBN,Weight,Unitprice,Orderqty,Amount "

        sqlCommand &= " ,case Order_Status when '1' then 'Waiting for Payment' "
        sqlCommand &= " when '2' then 'Payment Received'"
        sqlCommand &= " when '3' then 'On Process'"
        sqlCommand &= " when '4' then 'Order Delivered'"
        'tom+u.2009-06-09 k.Orapin Request
        sqlCommand &= " when '6' then 'Finished'"
        sqlCommand &= " when '7' then 'Not Saleable'"
        'sqlCommand &= " when '6' then 'Shipped'"
        sqlCommand &= " else 'Order Cancelled'"
        sqlCommand &= "end as Order_Status,"
        sqlCommand += " ,isnull(Discount,0) as Discount"
        If Exchange_Rate <> 0 Then
            sqlCommand &= " ,Amount/" + Exchange_Rate + " as USD"
        Else
            sqlCommand &= " ,'0.00' as USD"
        End If
        sqlCommand += " From tbt_asbkeo_cus_orderdtl "
        'sqlCommand += " left join (select distinct isbn_13,Book_Title from tbt_jobber_book_search) as b "
        'sqlCommand += " on a.ISBN = b.ISBN_13 "
        sqlCommand += " where Order_No = '" + Order_No + "'"
        If Available_Group_Id <> "" Then
            sqlCommand += " and Available_Group_Id = '" + Available_Group_Id + "'"
        End If
        sqlCommand += " order by Orderdtl_No"
        dt = sqlDb.GetDataTable(sqlCommand)
        Return dt
    End Function
    Public Function RetreiveCus_order_detail_emp()
        Dim sqlDb As New SqlDb
        Dim dt As DataTable
        Dim sqlCommand As String


        sqlCommand = " SELECT Orderdtl_No,Book_Title_Report,ISBN,Weight,Unitprice,Orderqty,Amount "
        sqlCommand &= " ,case Order_Status when '1' then 'ON ORDERING PROCESS' "
        sqlCommand &= " when '2' then 'ON SHIPPING PROCESS'"
        sqlCommand &= " when '3' then 'SHIPPED OUT'"
        sqlCommand &= " when '4' then 'BACKORDER/OUT OF STOCK'"
        'tom+u.2009-06-09 k.Orapin Request
        'sqlCommand &= " when '5' then 'Out of  Stock'"
        'sqlCommand &= " when '6' then 'Shipped'"
        sqlCommand &= " else 'CANCELLED'"
        sqlCommand += " end as Order_Status"
        sqlCommand += " ,isnull(Discount,0) as Discount"
        sqlCommand += " From tbt_asbkeo_cus_orderdtl "
        'sqlCommand += " left join (select distinct isbn_13,Book_Title from tbt_jobber_book_search) as b "
        'sqlCommand += " on a.ISBN = b.ISBN_13 "
        sqlCommand += " where Order_No = '" + Order_No + "'"
        If Available_Group_Id <> "" Then
            sqlCommand += " and Available_Group_Id = '" + Available_Group_Id + "'"
        End If
        sqlCommand += " order by Orderdtl_No"
        dt = sqlDb.GetDataTable(sqlCommand)
        Return dt
    End Function
    Public Function RetreiveCus_order_total()
        Dim sqlDb As New SqlDb
        Dim dt As DataTable
        Dim sqlCommand As String
        Dim dtEx As New DataTable
        Dim sqlEx As String
        sqlEx = "SELECT isnull(Exchange_Rate,0) as Exchange_Rate FROM tbt_asbkeo_cus_order WHERE Order_No='" + Order_No + "'"
        dtEx = sqlDb.GetDataTable(sqlEx)
        If dtEx.Rows.Count > 0 Then
            Exchange_Rate = dtEx.Rows(0).Item("Exchange_Rate").ToString
        Else
            Exchange_Rate = 0
        End If

        sqlCommand = " SELECT max(Leadtime) as Leadtime,sum(weight) as total_weight_group,sum(amount)as total_amount_group "
        If Exchange_Rate <> 0 Then
            sqlCommand &= " ,sum(amount)/" + Exchange_Rate + " as total_amount_group_USD"
        Else
            sqlCommand &= " ,'0.00' as total_amount_group_USD"
        End If
        sqlCommand += " From tbt_asbkeo_cus_orderdtl "
        sqlCommand += " where Order_No = '" + Order_No + "'"
        If Available_Group_Id <> "" Then
            sqlCommand += " and Available_Group_Id = '" + Available_Group_Id + "'"
        End If
        dt = sqlDb.GetDataTable(sqlCommand)
        Return dt
    End Function
    Public Function RetreiveCus_order_paymentMethod()
        Dim sqlDb As New SqlDb
        Dim dt As DataTable
        Dim sqlCommand As String
        sqlCommand = " SELECT Payment_method_Name,Payment_type"
        sqlCommand += " From tbm_syst_Paymentmethod "
        sqlCommand += " where Payment_method_Code = '" + Payment_method_Code + "'"
        sqlCommand += " and Payment_type ='" + Payment_type + "'"
        dt = sqlDb.GetDataTable(sqlCommand)
        Return dt
    End Function
End Class
