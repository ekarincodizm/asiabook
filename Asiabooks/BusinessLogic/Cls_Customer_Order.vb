Imports Microsoft.VisualBasic
Imports Eordering.BusinessLogic
Imports System
Imports System.Data
Imports System.Configuration
Imports System.Net.DNS
Public Class Cls_Customer_Order

    Dim message As String
    Dim DateNow As String
    Dim OrgCode_cr As String
    Public form As String
    Public Exchange_Rate As String
    Public maxleadtime1 As String
    Public maxleadtime2 As String
    Public totalweight1 As String
    Public totalweight2 As String
    Public totalamount1 As String
    Public totalamount1_usd As String
    Public totalamount2 As String
    Public totalamount2_usd As String
    Public totalamount3 As String
    Public totalamount3_usd As String
    Public delivertycost1 As String
    Public delivertycost1_usd As String
    Public delivertycost2 As String
    Public delivertycost2_usd As String
    Public promo_discount As String
    Public promo_discount_amount As String
    Public Branch_Code As String
    Private strOrder_No As String
    Private strOrder_Date As String
    Private strCartNo As String
    Private strMember_Id As String
    Private strCustomer_Name As String
    Private strTelephone As String
    Private strTotal_Amount As String
    Private strTotal_Weight As String
    Private strMax_Leadtime As String
    Private strDelivery_Cost As String
    Private strGrand_Total As String
    Private strDeposit_Amount As String
    Private strBalance As String
    Private strShip_to_name As String
    Private strShip_to_address As String
    Private strTransport_Type As String
    Private strZONEcode As String
    Private strcountryname As String
    Private strZone As String
    Private strBilling_Name As String
    Private strBilling_Address As String
    Private strGift_Flag As String
    Private strGift_From As String
    Private strGift_to As String
    Private strGift_Message As String
    Private strPayment_Method_Code As String
    Private strPayment_Type As String
    Private strSales_Channel_Code As String
    Private strOrderdtl_No As String
    Private strAvailable_Group_Id As String
    Private strISBN As String
    Private strWeight As String
    Private strLeadtime As String
    Private strUnitprice As String
    Private strDiscount As String
    Private strOrderqty As String
    Private strAmount As String
    Private strCartdtlno As String
    Private strOrder_Status As String
    Private strDeliver_Date As String
    Private strComplete_Date As String
    Private strJobber As String
    Private strJob_Date As String
    Private strPo_No As String
    Private strRemark As String
    Private strCountry_Code As String
    Private strMinimum_Percentage_Payment As String
    Public strMember_Code As String
    Private strLast_Name As String
    Private strEmpcd As String
    Private strPcnm As String
    Private strPickUpCode As String
    Private strPickUpName As String
    Private strPickUpAddress As String
    Private strPickUpEmail As String
    Private strRef_Cart As String
    Private strEmail As String
    Private strcurrency_code As String
    Private strcover_price As String
    Private strdiscount_report As String
    Private strbook_title_report As String
    Private strexchange_rate_detail As String

    Property Order_No()
        Get
            Return strOrder_No
        End Get
        Set(ByVal value)
            strOrder_No = value
        End Set
    End Property
    Property Order_Date()
        Get
            Return strOrder_Date
        End Get
        Set(ByVal value)
            strOrder_Date = value
        End Set
    End Property
    Property CartNo()
        Get
            Return strCartNo
        End Get
        Set(ByVal value)
            strCartNo = value
        End Set
    End Property
    Property Member_Id()
        Get
            Return strMember_Id
        End Get
        Set(ByVal value)
            strMember_Id = value
        End Set
    End Property
    Property Customer_Name()
        Get
            Return strCustomer_Name
        End Get
        Set(ByVal value)
            strCustomer_Name = value
        End Set
    End Property
    Property Telephone()
        Get
            Return strTelephone
        End Get
        Set(ByVal value)
            strTelephone = value
        End Set
    End Property
    Property Total_Amount()
        Get
            Return strTotal_Amount
        End Get
        Set(ByVal value)
            strTotal_Amount = value
        End Set
    End Property
    Property Total_Weight()
        Get
            Return strTotal_Weight
        End Get
        Set(ByVal value)
            strTotal_Weight = value
        End Set
    End Property
    Property Max_Leadtime()
        Get
            Return strMax_Leadtime
        End Get
        Set(ByVal value)
            strMax_Leadtime = value
        End Set
    End Property
    Property Delivery_Cost()
        Get
            Return strDelivery_Cost
        End Get
        Set(ByVal value)
            strDelivery_Cost = value
        End Set
    End Property
    Property Grand_Total()
        Get
            Return strGrand_Total
        End Get
        Set(ByVal value)
            strGrand_Total = value
        End Set
    End Property
    Property Deposit_Amount()
        Get
            Return strDeposit_Amount
        End Get
        Set(ByVal value)
            strDeposit_Amount = value
        End Set
    End Property
    Property Balance()
        Get
            Return strBalance
        End Get
        Set(ByVal value)
            strBalance = value
        End Set
    End Property
    Property Ship_to_name()
        Get
            Return strShip_to_name
        End Get
        Set(ByVal value)
            strShip_to_name = value
        End Set
    End Property
    Property Ship_to_address()
        Get
            Return strShip_to_address
        End Get
        Set(ByVal value)
            strShip_to_address = value
        End Set
    End Property
    Property Transport_Type()
        Get
            Return strTransport_Type
        End Get
        Set(ByVal value)
            strTransport_Type = value
        End Set
    End Property
    Property ZONE_code()
        Get
            Return strZONEcode
        End Get
        Set(ByVal value)
            strZONEcode = value
        End Set
    End Property
    Property Country_Name()
        Get
            Return strcountryname
        End Get
        Set(ByVal value)
            strcountryname = value
        End Set
    End Property
    Property Zone()
        Get
            Return strZone
        End Get
        Set(ByVal value)
            strZone = value
        End Set
    End Property
    Property Billing_Name()
        Get
            Return strBilling_Name
        End Get
        Set(ByVal value)
            strBilling_Name = value
        End Set
    End Property
    Property Billing_Address()
        Get
            Return strBilling_Address
        End Get
        Set(ByVal value)
            strBilling_Address = value
        End Set
    End Property
    Property Gift_Flag()
        Get
            Return strGift_Flag
        End Get
        Set(ByVal value)
            strGift_Flag = value
        End Set
    End Property
    Property Gift_From()
        Get
            Return strGift_From
        End Get
        Set(ByVal value)
            strGift_From = value
        End Set
    End Property
    Property Gift_to()
        Get
            Return strGift_to
        End Get
        Set(ByVal value)
            strGift_to = value
        End Set
    End Property
    Property Gift_Message()
        Get
            Return strGift_Message
        End Get
        Set(ByVal value)
            strGift_Message = value
        End Set
    End Property
    Property Payment_Method_Code()
        Get
            Return strPayment_Method_Code
        End Get
        Set(ByVal value)
            strPayment_Method_Code = value
        End Set
    End Property
    Property Payment_Type()
        Get
            Return strPayment_Type
        End Get
        Set(ByVal value)
            strPayment_Type = value
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
    Property ISBN()
        Get
            Return strISBN
        End Get
        Set(ByVal value)
            strISBN = value
        End Set
    End Property
    Property Weight()
        Get
            Return strWeight
        End Get
        Set(ByVal value)
            strWeight = value
        End Set
    End Property
    Property Leadtime()
        Get
            Return strLeadtime
        End Get
        Set(ByVal value)
            strLeadtime = value
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
    Property Discount()
        Get
            Return strDiscount
        End Get
        Set(ByVal value)
            strDiscount = value
        End Set
    End Property
    Property Orderqty()
        Get
            Return strOrderqty
        End Get
        Set(ByVal value)
            strOrderqty = value
        End Set
    End Property
    Property Amount()
        Get
            Return strAmount
        End Get
        Set(ByVal value)
            strAmount = value
        End Set
    End Property
    Property Cartdtlno()
        Get
            Return strCartdtlno
        End Get
        Set(ByVal value)
            strCartdtlno = value
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
    Property Deliver_Date()
        Get
            Return strDeliver_Date
        End Get
        Set(ByVal value)
            strDeliver_Date = value
        End Set
    End Property
    Property Complete_Date()
        Get
            Return strComplete_Date
        End Get
        Set(ByVal value)
            strComplete_Date = value
        End Set
    End Property
    Property Jobber()
        Get
            Return strJobber
        End Get
        Set(ByVal value)
            strJobber = value
        End Set
    End Property
    Property Job_Date()
        Get
            Return strJob_Date
        End Get
        Set(ByVal value)
            strJob_Date = value
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

    Property Remark()
        Get
            Return strRemark
        End Get
        Set(ByVal value)
            strRemark = value
        End Set
    End Property

    Property Country_Code()
        Get
            Return strCountry_Code
        End Get
        Set(ByVal value)
            strCountry_Code = value
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
    Property Member_Code()
        Get
            Return strMember_Code
        End Get
        Set(ByVal value)
            strMember_Code = value
        End Set
    End Property
    Property Last_Name()
        Get
            Return strLast_Name
        End Get
        Set(ByVal value)
            strLast_Name = value
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
    Property Pcnm()
        Get
            Return strPcnm
        End Get
        Set(ByVal value)
            strPcnm = value
        End Set
    End Property
    Property PickUpCode()
        Get
            Return strPickUpCode
        End Get
        Set(ByVal value)
            strPickUpCode = value
        End Set
    End Property
    Property PickUpName()
        Get
            Return strPickUpName
        End Get
        Set(ByVal value)
            strPickUpName = value
        End Set
    End Property
    Property PickUpAddress()
        Get
            Return strPickUpAddress
        End Get
        Set(ByVal value)
            strPickUpAddress = value
        End Set
    End Property
    Property PickUpEmail()
        Get
            Return strPickUpEmail
        End Get
        Set(ByVal value)
            strPickUpEmail = value
        End Set
    End Property
    Property Ref_Cart()
        Get
            Return strRef_Cart
        End Get
        Set(ByVal value)
            strRef_Cart = value
        End Set
    End Property
    Property Email()
        Get
            Return strEmail
        End Get
        Set(ByVal value)
            strEmail = value
        End Set
    End Property
    Property Currency_Code()
        Get
            Return strcurrency_code
        End Get
        Set(ByVal value)
            strcurrency_code = value
        End Set
    End Property
    Property Cover_Price()
        Get
            Return strcover_price
        End Get
        Set(ByVal value)
            strcover_price = value
        End Set
    End Property
    Property Discount_Report()
        Get
            Return strdiscount_report
        End Get
        Set(ByVal value)
            strdiscount_report = value
        End Set
    End Property
    Property Book_Title_Report()
        Get
            Return strbook_title_report
        End Get
        Set(ByVal value)
            strbook_title_report = value
        End Set
    End Property
    Property Exchang_Rate_Detail()
        Get
            Return strexchange_rate_detail
        End Get
        Set(ByVal value)
            strexchange_rate_detail = value
        End Set
    End Property
    Public Function Retrive_SpecialOrder()
        Dim sqlDb As New SqlDb
        Dim dt As DataTable
        Dim sqlCommand As String
        Dim condition As String = ""
        Dim datenow As String = sqlDb.GetDataTable("SELECT convert(varchar(10),getdate(),120)").Rows(0)(0).ToString

        Dim CartDateArr(2) As String

        If Order_No <> "" Then
            condition &= " and Order_No='" + Order_No + "'"

        End If

        If Customer_Name <> "" And Last_Name <> "" Then
            condition &= " and Customer_Name='" + Customer_Name + "' AND Last_Name='" + Last_Name + "'"

        End If


        'If Customer_Name <> "" And Last_Name <> "" Then
        '    condition &= " WHERE Customer_Name='" + Customer_Name + "' AND Last_Name='" + Last_Name + "'"

        'End If

        'If CartNo <> "" Then
        '    'condition = " AND a.cartNo= '" + Org_AB_Code + "'+'" + sqlDb.GetDataTable("select convert(varchar(10),getdate(),12)").Rows(0)(0).ToString + "'" + _
        '    '            "+" + "'CR'" + "+" + "'" + Convert.ToInt16(CartNo).ToString("00000") + "'"
        '    condition = " AND a.cartNo= '" + CartNo + "'"
        'End If
        ''If CartDate <> "" Then
        ''    CartDateArr = CartDate.ToString.Split("/")
        ''    CartDateConvert = CartDateArr(2) & "-" & CartDateArr(1) & "-" & CartDateArr(0)
        ''    condition &= " AND CartDate >= '" + CartDateConvert + "'" + _
        ''                "  AND CartDate <= '" + CartDateConvert + "'"
        ''End If

        sqlCommand = " SELECT  a.CartNo,b.ISBN,Book_Title,Unitprice,Cartqty,b.weight,b.amount"
        sqlCommand &= ",CASE WHEN Available_Group_id='1' THEN 'In Branch' "
        sqlCommand &= " WHEN Available_Group_id='2' THEN 'Other Branch' ELSE 'Special Order' "
        sqlCommand &= " END as Available_Group_id"
        sqlCommand &= ",CASE WHEN Available_Group_id='1' or Available_Group_id='2'  THEN tbm_syst_organizeab.org_ab_name "
        sqlCommand &= " ELSE tbm_syst_organizeindent.org_indent_name END as branch_name"
        sqlCommand &= " FROM tbt_asbkeo_cart a,tbt_asbkeo_cartdetail b"
        sqlCommand &= " left join tbm_syst_organizeab on b.org_other_code=tbm_syst_organizeab.org_ab_code"
        sqlCommand &= " left join tbm_syst_organizeindent on b.org_other_code=tbm_syst_organizeindent.org_indent_code,"
        sqlCommand &= "(select distinct isbn_13,Book_Title from tbt_jobber_book_search) as  c"
        sqlCommand &= " WHERE a.CartNo=b.CartNo "
        sqlCommand &= " AND Ordstt<>'1'"
        sqlCommand &= " AND Sales_Channel_Code='INTERNET'"
        sqlCommand &= " AND a.org_ab_code='HO-Internet'"
        sqlCommand &= " AND b.ISBN=c.ISBN_13" + condition
        sqlCommand &= " order by a.CartNo DESC,Org_Other_Code,cartdtlno "
        dt = sqlDb.GetDataTable(sqlCommand)
        Return dt
    End Function
    Public Function Retreive()
        Dim sqlDb As New SqlDb
        Dim dt As DataTable
        Dim sqlCommand As String
        Dim condition As String = ""

        If Order_No <> "" Then
            condition &= " where Order_No='" + Order_No + "'"

        End If

        If Customer_Name <> "" And Last_Name <> "" Then
            condition &= " WHERE Customer_Name='" + Customer_Name + "' AND Last_Name='" + Last_Name + "'"

        End If

        sqlCommand = "SELECT tbt_asbkeo_cus_order.Order_no"
        sqlCommand &= ",convert(varchar(10),tbt_asbkeo_cus_order.Order_Date,103) as Order_Date"
        sqlCommand &= ",tbt_asbkeo_cus_order.Customer_Name+' '+tbt_asbkeo_cus_order.Last_Name as Customer_Name"
        sqlCommand &= ",tbt_asbkeo_cus_order.Sales_Channel_Code,tbm_syst_organizeab.Org_AB_Name"
        sqlCommand &= ",Sales_Channel_Name,tbt_asbkeo_cus_order.Grand_Total,tbt_asbkeo_cus_order.Member_Id"
        sqlCommand &= " FROM tbt_asbkeo_cus_order LEFT JOIN tbm_syst_organizeab"
        sqlCommand &= " ON tbt_asbkeo_cus_order.Address_Org_Ab=tbm_syst_organizeab.Org_AB_code"
        sqlCommand &= " LEFT JOIN (select distinct Sales_Channel_Code,Sales_Channel_Name "
        sqlCommand &= " from tbm_syst_saleschannel)  as tbm_syst_saleschannel"
        sqlCommand &= " ON tbt_asbkeo_cus_order.Sales_Channel_Code=tbm_syst_saleschannel.Sales_Channel_Code" + condition
        sqlCommand &= " ORDER BY  tbt_asbkeo_cus_order.order_date DESC ,tbt_asbkeo_cus_order.order_no DESC"

        dt = sqlDb.GetDataTable(sqlCommand)

        Return dt

    End Function
    Public Function Retreive_Login(ByVal dt_person As DataTable)
        Dim sqlDb As New SqlDb
        Dim dt As DataTable
        Dim sqlCommand As String
        Dim condition As String = ""

        'If dt_person.Rows(0).Item("NAME_TH").ToString <> "" And dt_person.Rows(0).Item("SURNAME_TH").ToString <> "" Then
        '    condition &= " WHERE Customer_Name='" + dt_person.Rows(0).Item("NAME_TH").ToString + "' AND Last_Name='" + dt_person.Rows(0).Item("SURNAME_TH").ToString + "'"

        'End If
        'If dt_person.Rows(0).Item("NAME_EN").ToString <> "" And dt_person.Rows(0).Item("NAME_EN").ToString <> "" Then
        '    condition &= " WHERE Customer_Name='" + dt_person.Rows(0).Item("NAME_EN").ToString + "' AND Last_Name='" + dt_person.Rows(0).Item("SURNAME_EN").ToString + "' and Order_Date >= getdate()-14 and tbt_asbkeo_cus_order.Sales_Channel_Code = 'INTERNET' "
        'End If
        If dt_person.Rows(0).Item("MEMBER_CODE").ToString <> "" Then
            condition &= " WHERE Member_Id ='" + dt_person.Rows(0).Item("MEMBER_CODE").ToString + "' and Order_Date >= getdate()-14 and tbt_asbkeo_cus_order.Sales_Channel_Code = 'INTERNET' "
        End If

        'If Order_No <> "" Then
        '    condition &= " where Order_No='" + Order_No + "'"

        'End If

        'If Customer_Name <> "" And Last_Name <> "" Then
        '    condition &= " WHERE Customer_Name='" + dt_person.Rows(0).Item("NAME_TH").ToString + "' AND Last_Name='" + dt_person.Rows(0).Item("SURNAME_TH").ToString + "'"

        'End If

        sqlCommand = "SELECT tbt_asbkeo_cus_order.Order_no"
        sqlCommand &= ",convert(varchar(10),tbt_asbkeo_cus_order.Order_Date,103) as Order_Date"
        sqlCommand &= ",tbt_asbkeo_cus_order.Customer_Name+' '+tbt_asbkeo_cus_order.Last_Name as Customer_Name"
        sqlCommand &= ",tbt_asbkeo_cus_order.Sales_Channel_Code,tbm_syst_organizeab.Org_AB_Name"
        sqlCommand &= ",Sales_Channel_Name"
        sqlCommand &= " FROM tbt_asbkeo_cus_order LEFT JOIN tbm_syst_organizeab"
        sqlCommand &= " ON tbt_asbkeo_cus_order.Address_Org_Ab=tbm_syst_organizeab.Org_AB_code"
        sqlCommand &= " LEFT JOIN (select distinct Sales_Channel_Code,Sales_Channel_Name "
        sqlCommand &= " from tbm_syst_saleschannel)  as tbm_syst_saleschannel"
        sqlCommand &= " ON tbt_asbkeo_cus_order.Sales_Channel_Code=tbm_syst_saleschannel.Sales_Channel_Code" + condition
        sqlCommand &= " ORDER BY  tbt_asbkeo_cus_order.order_date DESC ,tbt_asbkeo_cus_order.order_no DESC"

        dt = sqlDb.GetDataTable(sqlCommand)

        Return dt

    End Function

    Public Function RetreiveCoEmp()
        Dim sqlDb As New SqlDb
        Dim dt As DataTable
        Dim sqlCommand As String
        Dim condition As String = ""

        sqlCommand = "SELECT convert(varchar(10),Order_Date,103) as Order_Date,"
        sqlCommand &= " Customer_Name, Last_Name, Telephone,isnull(Billing_Name,'') as Billing_Name,"
        sqlCommand &= " isnull(Billing_Address,'') as Billing_Address,isnull(Gift_Flag,'') as Gift_Flag,"
        sqlCommand &= " isnull(Gift_From,'') as Gift_From,isnull(Gift_to,'') as Gift_to,"
        sqlCommand &= " isnull(Gift_Message,'') as Gift_Message,Total_Weight,Total_Amount,"
        sqlCommand &= " isnull(Deposit_Amount,0) as Deposit_Amount,"
        sqlCommand &= " Max_Leadtime, Delivery_Cost,Grand_Total,"
        sqlCommand &= " isnull(Delivery_Available,0) as Delivery_Available,"
        sqlCommand &= " isnull(Delivery_special,0) as Delivery_special,"
        sqlCommand &= " Balance,isnull(Ship_to_name,'') as Ship_to_name,"
        sqlCommand &= " isnull(Ship_to_address,'') as Ship_to_address, Transport_Type, Country_Name,isnull(a.field2,'') as field2,a.Ref_Cus_No as Ref_Cart_No,isnull(a.Email,'') as Email"
        sqlCommand &= " FROM tbt_asbkeo_cus_order a,tbm_syst_country b"
        sqlCommand &= " WHERE(a.Country_Code = b.Country_Code)"
        sqlCommand &= " AND a.ZONE=b.ZONE_code"
        sqlCommand &= " AND Order_No='" + Order_No + "'"

        dt = sqlDb.GetDataTable(sqlCommand)

        Return dt

    End Function
    Public Function RetreiveCoEmp_PickUpAsBranch()
        Dim sqlDb As New SqlDb
        Dim dt As DataTable
        Dim sqlCommand As String
        Dim condition As String = ""

        sqlCommand = "SELECT convert(varchar(10),Order_Date,103) as Order_Date,"
        sqlCommand &= " Customer_Name, Last_Name, Telephone,isnull(Billing_Name,'') as Billing_Name,"
        sqlCommand &= " isnull(Billing_Address,'') as Billing_Address,isnull(Gift_Flag,'') as Gift_Flag,"
        sqlCommand &= " isnull(Gift_From,'') as Gift_From,isnull(Gift_to,'') as Gift_to,"
        sqlCommand &= " isnull(Gift_Message,'') as Gift_Message,Total_Weight,Total_Amount,"
        sqlCommand &= " isnull(Deposit_Amount,0) as Deposit_Amount,"
        sqlCommand &= " Max_Leadtime, Delivery_Cost,Grand_Total,"
        sqlCommand &= " isnull(Delivery_Available,0) as Delivery_Available,"
        sqlCommand &= " isnull(Delivery_special,0) as Delivery_special,"
        sqlCommand &= " Balance,isnull(Ship_to_name,'') as Ship_to_name,isnull(Email,'') as Email,"
        sqlCommand &= " isnull(Ship_to_address,'') as Ship_to_address, Transport_Type,field2 as Country_Name,Ref_Cus_No as Ref_Cart_No"
        sqlCommand &= " FROM tbt_asbkeo_cus_order"
        sqlCommand &= " WHERE"
        sqlCommand &= " Order_No='" + Order_No + "'"

        dt = sqlDb.GetDataTable(sqlCommand)

        Return dt

    End Function
    Public Function RetreiveCo()
        Dim sqlDb As New SqlDb
        Dim dt As DataTable
        Dim sqlCommand As String
        Dim condition As String = ""

        Dim Exchange_Rate As String = sqlDb.GetDataTable("SELECT isnull(Exchange_Rate,0) FROM tbt_asbkeo_cus_order WHERE Order_No='" + Order_No + "'").Rows(0)(0).ToString

        sqlCommand = "SELECT convert(varchar(10),Order_Date,103) as Order_Date,"
        sqlCommand &= " Customer_Name, Last_Name, Telephone,isnull(Billing_Name,'') as Billing_Name,"
        sqlCommand &= " isnull(Billing_Address,'') as Billing_Address,isnull(Gift_Flag,'') as Gift_Flag,"
        sqlCommand &= " isnull(Gift_From,'') as Gift_From,isnull(Gift_to,'') as Gift_to,"
        sqlCommand &= " isnull(Gift_Message,'') as Gift_Message,Payment_method_Name,a.Payment_Type,"
        sqlCommand &= " Total_Weight,Total_Amount,"
        sqlCommand &= " isnull(Deposit_Amount,0) as Deposit_Amount,"
        If Exchange_Rate <> 0 Then
            sqlCommand &= "Total_Amount/" + Exchange_Rate + " as Total_Amount_USD,"
            sqlCommand &= "Delivery_Cost/" + Exchange_Rate + " as Delivery_Cost_USD,"
            sqlCommand &= "Grand_Total/" + Exchange_Rate + " as Grand_Total_USD,"
            sqlCommand &= "Deposit_Amount/" + Exchange_Rate + " as Deposit_Amount_USD,"
        Else
            sqlCommand &= "'0' as Total_Amount_USD,"
            sqlCommand &= "'0' as Delivery_Cost_USD,"
            sqlCommand &= "'0' as Grand_Total_USD,"
            sqlCommand &= "'0' as Deposit_Amount_USD,"
        End If
        sqlCommand &= " Max_Leadtime, Delivery_Cost, "
        sqlCommand &= " isnull(Delivery_Available,0) as Delivery_Available,"
        sqlCommand &= " isnull(Delivery_special,0) as Delivery_special,"

        sqlCommand &= " Grand_Total,"
        sqlCommand &= " Balance,isnull(Ship_to_name,'') as Ship_to_name,"
        sqlCommand &= " isnull(Ship_to_address,'') as Ship_to_address, Transport_Type, Country_Name,a.Member_Id,isnull(a.Email,'') as Email"
        sqlCommand &= " FROM tbt_asbkeo_cus_order a,tbm_syst_country b,tbm_syst_Paymentmethod c"
        sqlCommand &= " WHERE(a.Country_Code = b.Country_Code)"
        sqlCommand += " and a.zone=b.Zone_Code"
        sqlCommand &= " AND a.Payment_Method_Code=c.Payment_method_Code"
        sqlCommand &= " AND a.Payment_Type=c.Payment_Type"
        sqlCommand &= " AND a.ZONE=b.ZONE_code"
        sqlCommand &= " AND Order_No='" + Order_No + "'"

        dt = sqlDb.GetDataTable(sqlCommand)

        Return dt

    End Function
    Public Function RetreiveCo_PickUpAsBranch()
        Dim sqlDb As New SqlDb
        Dim dt As DataTable
        Dim sqlCommand As String
        Dim condition As String = ""

        Dim Exchange_Rate As String = sqlDb.GetDataTable("SELECT isnull(Exchange_Rate,0) FROM tbt_asbkeo_cus_order WHERE Order_No='" + Order_No + "'").Rows(0)(0).ToString

        sqlCommand = "SELECT convert(varchar(10),Order_Date,103) as Order_Date,"
        sqlCommand &= " Customer_Name, Last_Name, Telephone,isnull(Billing_Name,'') as Billing_Name,"
        sqlCommand &= " isnull(Billing_Address,'') as Billing_Address,isnull(Gift_Flag,'') as Gift_Flag,"
        sqlCommand &= " isnull(Gift_From,'') as Gift_From,isnull(Gift_to,'') as Gift_to,"
        sqlCommand &= " isnull(Gift_Message,'') as Gift_Message,Payment_method_Name,a.Payment_Type,"
        sqlCommand &= " Total_Weight,Total_Amount,"
        sqlCommand &= " isnull(Deposit_Amount,0) as Deposit_Amount,"
        If Exchange_Rate <> 0 Then
            sqlCommand &= "Total_Amount/" + Exchange_Rate + " as Total_Amount_USD,"
            sqlCommand &= "Delivery_Cost/" + Exchange_Rate + " as Delivery_Cost_USD,"
            sqlCommand &= "Grand_Total/" + Exchange_Rate + " as Grand_Total_USD,"
            sqlCommand &= "Deposit_Amount/" + Exchange_Rate + " as Deposit_Amount_USD,"
        Else
            sqlCommand &= "'0' as Total_Amount_USD,"
            sqlCommand &= "'0' as Delivery_Cost_USD,"
            sqlCommand &= "'0' as Grand_Total_USD,"
            sqlCommand &= "'0' as Deposit_Amount_USD,"
        End If
        sqlCommand &= " Max_Leadtime, Delivery_Cost, "
        sqlCommand &= " isnull(Delivery_Available,0) as Delivery_Available,"
        sqlCommand &= " isnull(Delivery_special,0) as Delivery_special,"

        sqlCommand &= " Grand_Total,"
        sqlCommand &= " Balance,isnull(Ship_to_name,'') as Ship_to_name,"
        sqlCommand &= " isnull(Ship_to_address,'') as Ship_to_address, Transport_Type,a.Member_Id,isnull(a.field2,'') as Country_Name,isnull(a.Email,'') as Email"
        sqlCommand &= " FROM tbt_asbkeo_cus_order a,tbm_syst_country b,tbm_syst_Paymentmethod c"
        sqlCommand &= " WHERE"
        sqlCommand &= " a.Payment_Method_Code=c.Payment_method_Code"
        sqlCommand &= " AND a.Payment_Type=c.Payment_Type"
        sqlCommand &= " AND Order_No='" + Order_No + "'"

        dt = sqlDb.GetDataTable(sqlCommand)

        Return dt

    End Function
    Public Function RetreiveCoDirecSale()
        Dim sqlDb As New SqlDb
        Dim dt As DataTable
        Dim sqlCommand As String
        Dim condition As String = ""
        Dim dtEx As New DataTable
        Dim sqlEx As String

        sqlEx = "SELECT isnull(Exchange_Rate,0) as Exchange_Rate FROM tbt_asbkeo_cus_order WHERE Order_No='" + Order_No + "'"
        dtEx = sqlDb.GetDataTable(sqlEx)
        If dtEx.Rows.Count > 0 Then
            Exchange_Rate = dtEx.Rows(0).Item("Exchange_Rate").ToString
        Else
            Exchange_Rate = 0
        End If
        sqlCommand = "SELECT convert(varchar(10),Order_Date,103) as Order_Date,"
        sqlCommand &= " Customer_Name, Last_Name, Telephone,isnull(Billing_Name,'') as Billing_Name,"
        sqlCommand &= " isnull(Billing_Address,'') as Billing_Address,isnull(Gift_Flag,'') as Gift_Flag,"
        sqlCommand &= " isnull(Gift_From,'') as Gift_From,isnull(Gift_to,'') as Gift_to,"
        sqlCommand &= " isnull(Gift_Message,'') as Gift_Message,"
        sqlCommand &= " Total_Weight,Total_Amount,"
        sqlCommand &= " isnull(Deposit_Amount,0) as Deposit_Amount,isnull(Balance,0) as Balance,"
        If Exchange_Rate <> 0 Then
            sqlCommand &= "Total_Amount/" + Exchange_Rate + " as Total_Amount_USD,"
            sqlCommand &= "Delivery_Cost/" + Exchange_Rate + " as Delivery_Cost_USD,"
            sqlCommand &= "Grand_Total/" + Exchange_Rate + " as Grand_Total_USD,"
            sqlCommand &= "Deposit_Amount/" + Exchange_Rate + " as Deposit_Amount_USD,"
            sqlCommand &= "Balance/" + Exchange_Rate + " as Balance_USD,"
        Else
            sqlCommand &= "'0' as Total_Amount_USD,"
            sqlCommand &= "'0' as Delivery_Cost_USD,"
            sqlCommand &= "'0' as Grand_Total_USD,"
            sqlCommand &= "'0' as Deposit_Amount_USD,"
            sqlCommand &= "'0' as Balance_USD,"
        End If
        sqlCommand &= " Max_Leadtime, Delivery_Cost, "
        sqlCommand &= " isnull(Delivery_Available,0) as Delivery_Available,"
        sqlCommand &= " isnull(Delivery_special,0) as Delivery_special,"

        sqlCommand &= " Grand_Total,"
        sqlCommand &= " isnull(Ship_to_name,'') as Ship_to_name,"
        sqlCommand &= " isnull(Ship_to_address,'') as Ship_to_address, Transport_Type, Country_Name ,isnull(a.field2,'') as field2,isnull(a.Email,'') as Email"
        sqlCommand &= " FROM tbt_asbkeo_cus_order a,tbm_syst_country b"
        sqlCommand &= " WHERE(a.Country_Code = b.Country_Code)"
        sqlCommand += " and a.zone=b.Zone_Code"
        sqlCommand &= " AND a.ZONE=b.ZONE_code"
        sqlCommand &= " AND Order_No='" + Order_No + "'"

        dt = sqlDb.GetDataTable(sqlCommand)

        Return dt

    End Function
    Public Function RetreiveCoDirecSale_PickUpAsBranch()
        Dim sqlDb As New SqlDb
        Dim dt As DataTable
        Dim sqlCommand As String
        Dim condition As String = ""
        Dim dtEx As New DataTable
        Dim sqlEx As String

        sqlEx = "SELECT isnull(Exchange_Rate,0) as Exchange_Rate FROM tbt_asbkeo_cus_order WHERE Order_No='" + Order_No + "'"
        dtEx = sqlDb.GetDataTable(sqlEx)
        If dtEx.Rows.Count > 0 Then
            Exchange_Rate = dtEx.Rows(0).Item("Exchange_Rate").ToString
        Else
            Exchange_Rate = 0
        End If
        sqlCommand = "SELECT convert(varchar(10),Order_Date,103) as Order_Date,"
        sqlCommand &= " Customer_Name, Last_Name, Telephone,isnull(Billing_Name,'') as Billing_Name,"
        sqlCommand &= " isnull(Billing_Address,'') as Billing_Address,isnull(Gift_Flag,'') as Gift_Flag,"
        sqlCommand &= " isnull(Gift_From,'') as Gift_From,isnull(Gift_to,'') as Gift_to,"
        sqlCommand &= " isnull(Gift_Message,'') as Gift_Message,"
        sqlCommand &= " Total_Weight,Total_Amount,"
        sqlCommand &= " isnull(Deposit_Amount,0) as Deposit_Amount,isnull(Balance,0) as Balance,"
        If Exchange_Rate <> 0 Then
            sqlCommand &= "Total_Amount/" + Exchange_Rate + " as Total_Amount_USD,"
            sqlCommand &= "Delivery_Cost/" + Exchange_Rate + " as Delivery_Cost_USD,"
            sqlCommand &= "Grand_Total/" + Exchange_Rate + " as Grand_Total_USD,"
            sqlCommand &= "Deposit_Amount/" + Exchange_Rate + " as Deposit_Amount_USD,"
            sqlCommand &= "Balance/" + Exchange_Rate + " as Balance_USD,"
        Else
            sqlCommand &= "'0' as Total_Amount_USD,"
            sqlCommand &= "'0' as Delivery_Cost_USD,"
            sqlCommand &= "'0' as Grand_Total_USD,"
            sqlCommand &= "'0' as Deposit_Amount_USD,"
            sqlCommand &= "'0' as Balance_USD,"
        End If
        sqlCommand &= " Max_Leadtime, Delivery_Cost, "
        sqlCommand &= " isnull(Delivery_Available,0) as Delivery_Available,"
        sqlCommand &= " isnull(Delivery_special,0) as Delivery_special,"

        sqlCommand &= " Grand_Total,"
        sqlCommand &= " isnull(Ship_to_name,'') as Ship_to_name,"
        sqlCommand &= " isnull(Ship_to_address,'') as Ship_to_address, Transport_Type, isnull(a.field2,'') as field2,isnull(Email,'') as Email"
        sqlCommand &= " FROM tbt_asbkeo_cus_order"
        sqlCommand &= " WHERE"
        'sqlCommand += " and a.zone=b.Zone_Code"
        'sqlCommand &= " AND a.ZONE=b.ZONE_code"
        sqlCommand &= " Order_No='" + Order_No + "'"

        dt = sqlDb.GetDataTable(sqlCommand)

        Return dt

    End Function
    Public Function RetreiveCoDetail()
        Dim sqlDb As New SqlDb
        Dim dt As DataTable
        Dim sqlCommand As String
        Dim condition As String = ""




        sqlCommand = " SELECT Orderdtl_No,ISBN,Weight,Unitprice,Orderqty,"
        sqlCommand &= " Amount,Book_Title_Report,"
        sqlCommand &= " case Order_Status when '1' then 'ON ORDERING PROCESS' "
        sqlCommand &= " when '2' then 'ON SHIPPING PROCESS'"
        sqlCommand &= " when '3' then 'SHIPPED OUT'"
        sqlCommand &= " when '4' then 'BACKORDER/OUT OF STOCK'"
        'tom+u.2009-06-09 k.Orapin Request
        'sqlCommand &= " when '5' then 'Out of  Stock'"
        'sqlCommand &= " when '6' then 'Shipped'"
        sqlCommand &= " else 'CANCELLED'"
        sqlCommand &= " end as Order_Status"
        sqlCommand &= " FROM tbt_asbkeo_cus_orderdtl "
        'sqlCommand &= "(select distinct isbn_13,Book_Title from tbt_jobber_book_search) b"
        sqlCommand &= " WHERE "
        sqlCommand &= " Order_No='" + Order_No + "'"
        sqlCommand &= " ORDER BY Orderdtl_No"

        dt = sqlDb.GetDataTable(sqlCommand)

        Return dt

    End Function
    Public Function RetreiveCoAviable()
        Dim sqlDb As New SqlDb
        Dim dt As DataTable
        Dim sqlCommand As String
        Dim condition As String = ""

        Dim dtEx As New DataTable
        Dim sqlEx As String
        sqlEx = "SELECT isnull(Exchange_Rate,0) as Exchange_Rate FROM tbt_asbkeo_cus_order WHERE Order_No='" + Order_No + "'"
        dtEx = sqlDb.GetDataTable(sqlEx)
        If dtEx.Rows.Count > 0 Then
            Exchange_Rate = dtEx.Rows(0).Item("Exchange_Rate").ToString
        Else
            Exchange_Rate = 0
        End If
        sqlCommand = " SELECT Orderdtl_No,ISBN,Weight,Unitprice,Orderqty,"
        sqlCommand &= " case Order_Status when '1' then 'ON ORDERING PROCESS' "
        sqlCommand &= " when '2' then 'ON SHIPPING PROCESS'"
        sqlCommand &= " when '3' then 'SHIPPED OUT'"
        sqlCommand &= " when '4' then 'BACKORDER/OUT OF STOCK'"
        'tom+u.2009-06-09 k.Orapin Request
        'sqlCommand &= " when '5' then 'Out of  Stock'"
        'sqlCommand &= " when '6' then 'Shipped'"
        sqlCommand &= " else 'CANCELLED'"
        sqlCommand &= " end as Order_Status,"
        sqlCommand &= " Amount,Book_Title_Report,isnull(Discount,0) as Discount,"

        If Exchange_Rate <> 0 Then
            sqlCommand &= " Amount/" + Exchange_Rate + " as USD"
        Else
            sqlCommand &= "'0' as USD"
        End If
        sqlCommand &= " FROM tbt_asbkeo_cus_orderdtl"
        'sqlCommand &= "(select distinct isbn_13,Book_Title from tbt_jobber_book_search) b"
        sqlCommand &= " WHERE "
        sqlCommand &= " Order_No='" + Order_No + "'"
        sqlCommand &= " AND Available_Group_Id='1'"
        sqlCommand &= " ORDER BY Orderdtl_No"

        dt = sqlDb.GetDataTable(sqlCommand)

        Return dt

    End Function
    Public Function RetreiveCoAviable_Internet()
        Dim sqlDb As New SqlDb
        Dim dt As DataTable
        Dim sqlCommand As String
        Dim condition As String = ""

        Dim dtEx As New DataTable
        Dim sqlEx As String
        sqlEx = "SELECT isnull(Exchange_Rate,0) as Exchange_Rate FROM tbt_asbkeo_cus_order WHERE Order_No='" + Order_No + "'"
        dtEx = sqlDb.GetDataTable(sqlEx)
        If dtEx.Rows.Count > 0 Then
            Exchange_Rate = dtEx.Rows(0).Item("Exchange_Rate").ToString
        Else
            Exchange_Rate = 0
        End If
        sqlCommand = " SELECT Orderdtl_No,ISBN,Weight,Unitprice,Orderqty,"
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
        sqlCommand &= " Amount,Book_Title_Report,isnull(Discount,0) as Discount,isnull([EMS TRACKING NO.],'') as EMS_Tracking,"

        If Exchange_Rate <> 0 Then
            sqlCommand &= " Amount/" + Exchange_Rate + " as USD"
        Else
            sqlCommand &= "'0' as USD"
        End If
        sqlCommand &= " FROM tbt_asbkeo_cus_orderdtl "
        'sqlCommand &= "(select distinct isbn_13,Book_Title from tbt_jobber_book_search) b"
        sqlCommand &= " WHERE  "
        sqlCommand &= " Order_No='" + Order_No + "'"
        sqlCommand &= " AND Available_Group_Id='1'"
        sqlCommand &= " ORDER BY cast(Orderdtl_No as integer)"

        dt = sqlDb.GetDataTable(sqlCommand)

        Return dt

    End Function
    Public Function RetreiveCoOutofStock()
        Dim sqlDb As New SqlDb
        Dim dt As DataTable
        Dim sqlCommand As String
        Dim condition As String = ""
        Dim dtEx As New DataTable
        Dim sqlEx As String
        sqlEx = "SELECT isnull(Exchange_Rate,0) as Exchange_Rate FROM tbt_asbkeo_cus_order WHERE Order_No='" + Order_No + "'"
        dtEx = sqlDb.GetDataTable(sqlEx)
        If dtEx.Rows.Count > 0 Then
            Exchange_Rate = dtEx.Rows(0).Item("Exchange_Rate").ToString
        Else
            Exchange_Rate = 0
        End If

        sqlCommand = " SELECT Orderdtl_No,ISBN,Weight,Unitprice,Orderqty,"
        sqlCommand &= " Amount,Book_Title_Report,isnull(Discount,0) as Discount ,"
        sqlCommand &= " case Order_Status when '1' then 'ON ORDERING PROCESS' "
        sqlCommand &= " when '2' then 'ON SHIPPING PROCESS'"
        sqlCommand &= " when '3' then 'SHIPPED OUT'"
        sqlCommand &= " when '4' then 'BACKORDER/OUT OF STOCK'"
        'tom+u.2009-06-09 k.Orapin Request
        'sqlCommand &= " when '5' then 'Out of  Stock'"
        'sqlCommand &= " when '6' then 'Shipped'"
        sqlCommand &= " else 'CANCELLED'"
        sqlCommand &= " end as Order_Status,"
        If Exchange_Rate <> 0 Then
            sqlCommand &= " Amount/" + Exchange_Rate + " as USD"
        Else
            sqlCommand &= "'0' as USD"
        End If
        sqlCommand &= " FROM tbt_asbkeo_cus_orderdtl "
        'sqlCommand &= " (select distinct isbn_13,Book_Title from tbt_jobber_book_search) b"
        sqlCommand &= " WHERE  "
        sqlCommand &= " Order_No='" + Order_No + "'"
        sqlCommand &= " AND Available_Group_Id='3'"
        sqlCommand &= " ORDER BY Orderdtl_No"

        dt = sqlDb.GetDataTable(sqlCommand)

        Return dt

    End Function
    Public Function RetreiveCoOutofStock_Interner()
        Dim sqlDb As New SqlDb
        Dim dt As DataTable
        Dim sqlCommand As String
        Dim condition As String = ""
        Dim dtEx As New DataTable
        Dim sqlEx As String
        sqlEx = "SELECT isnull(Exchange_Rate,0) as Exchange_Rate FROM tbt_asbkeo_cus_order WHERE Order_No='" + Order_No + "'"
        dtEx = sqlDb.GetDataTable(sqlEx)
        If dtEx.Rows.Count > 0 Then
            Exchange_Rate = dtEx.Rows(0).Item("Exchange_Rate").ToString
        Else
            Exchange_Rate = 0
        End If

        sqlCommand = " SELECT Orderdtl_No,ISBN,Weight,Unitprice,Orderqty,"
        sqlCommand &= " Amount,Book_Title_Report,isnull(Discount,0) as Discount,isnull([EMS TRACKING NO.],'') as EMS_Tracking,"
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
        If Exchange_Rate <> 0 Then
            sqlCommand &= " Amount/" + Exchange_Rate + " as USD"
        Else
            sqlCommand &= "'0' as USD"
        End If
        sqlCommand &= " FROM tbt_asbkeo_cus_orderdtl "
        'sqlCommand &= " (select distinct isbn_13,Book_Title from tbt_jobber_book_search) b"
        sqlCommand &= " WHERE "
        sqlCommand &= " Order_No='" + Order_No + "'"
        sqlCommand &= " AND Available_Group_Id='3'"
        sqlCommand &= " ORDER BY cast(Orderdtl_No as integer)"

        dt = sqlDb.GetDataTable(sqlCommand)

        Return dt

    End Function
    Public Function RetreiveCoEBook()
        Dim sqlDb As New SqlDb
        Dim dt As DataTable
        Dim sqlCommand As String
        Dim condition As String = ""

        Dim dtEx As New DataTable
        Dim sqlEx As String
        sqlEx = "SELECT isnull(Exchange_Rate,0) as Exchange_Rate FROM tbt_asbkeo_cus_order WHERE Order_No='" + Order_No + "'"
        dtEx = sqlDb.GetDataTable(sqlEx)
        If dtEx.Rows.Count > 0 Then
            Exchange_Rate = dtEx.Rows(0).Item("Exchange_Rate").ToString
        Else
            Exchange_Rate = 0
        End If
        sqlCommand = " SELECT Orderdtl_No,ISBN,Weight,Unitprice,Orderqty,"
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
        sqlCommand &= " Amount,Book_Title_Report,isnull(Discount,0) as Discount,"

        If Exchange_Rate <> 0 Then
            sqlCommand &= " Amount/" + Exchange_Rate + " as USD"
        Else
            sqlCommand &= "'0' as USD"
        End If
        sqlCommand &= " FROM tbt_asbkeo_cus_orderdtl "
        'sqlCommand &= "(select distinct isbn_13,Book_Title from tbt_jobber_book_search) b"
        sqlCommand &= " WHERE  "
        sqlCommand &= " Order_No='" + Order_No + "'"
        sqlCommand &= " AND Available_Group_Id='4'"
        sqlCommand &= " ORDER BY cast(Orderdtl_No as integer)"

        dt = sqlDb.GetDataTable(sqlCommand)

        Return dt

    End Function
    Public Sub TotalOutofAviable()
        Dim sqlDb As New SqlDb
        Exchange_Rate = sqlDb.GetDataTable("SELECT isnull(Exchange_Rate,0) FROM tbt_asbkeo_cus_order WHERE Order_No='" + Order_No + "'").Rows(0)(0).ToString
        Me.maxleadtime1 = sqlDb.GetDataTable("SELECT max(Leadtime) as Leadtime FROM tbt_asbkeo_cus_orderdtl WHERE Order_No='" + Order_No + "' AND Available_Group_Id='1'").Rows(0)(0).ToString
        Me.totalweight1 = sqlDb.GetDataTable("SELECT sum(weight) as weight FROM tbt_asbkeo_cus_orderdtl WHERE Order_No='" + Order_No + "' AND Available_Group_Id='1'").Rows(0)(0).ToString
        Me.totalamount1 = sqlDb.GetDataTable("SELECT sum(amount) as amount FROM tbt_asbkeo_cus_orderdtl WHERE Order_No='" + Order_No + "' AND Available_Group_Id='1'").Rows(0)(0).ToString
        Me.delivertycost1 = sqlDb.GetDataTable("SELECT Delivery_Available FROM tbt_asbkeo_cus_order WHERE Order_No='" + Order_No + "'").Rows(0)(0).ToString
    End Sub
    Public Sub TotalOutofStock()
        Dim sqlDb As New SqlDb
        Exchange_Rate = sqlDb.GetDataTable("SELECT isnull(Exchange_Rate,0) FROM tbt_asbkeo_cus_order WHERE Order_No='" + Order_No + "'").Rows(0)(0).ToString
        Me.maxleadtime2 = sqlDb.GetDataTable("SELECT max(Leadtime) as Leadtime FROM tbt_asbkeo_cus_orderdtl WHERE Order_No='" + Order_No + "' AND Available_Group_Id='3'").Rows(0)(0).ToString
        Me.totalweight2 = sqlDb.GetDataTable("SELECT sum(weight) as weight FROM tbt_asbkeo_cus_orderdtl WHERE Order_No='" + Order_No + "' AND Available_Group_Id='3'").Rows(0)(0).ToString
        Me.totalamount2 = sqlDb.GetDataTable("SELECT sum(amount) as amount FROM tbt_asbkeo_cus_orderdtl WHERE Order_No='" + Order_No + "' AND Available_Group_Id='3'").Rows(0)(0).ToString
        Me.delivertycost2 = sqlDb.GetDataTable("SELECT Delivery_special FROM tbt_asbkeo_cus_order WHERE Order_No='" + Order_No + "'").Rows(0)(0).ToString

    End Sub
    Public Sub TotalEBook()
        Dim sqlDb As New SqlDb
        Exchange_Rate = sqlDb.GetDataTable("SELECT isnull(Exchange_Rate,0) FROM tbt_asbkeo_cus_order WHERE Order_No='" + Order_No + "'").Rows(0)(0).ToString
        'Me.maxleadtime2 = sqlDb.GetDataTable("SELECT max(Leadtime) as Leadtime FROM tbt_asbkeo_cus_orderdtl WHERE Order_No='" + Order_No + "' AND Available_Group_Id='4'").Rows(0)(0).ToString
        'Me.totalweight2 = sqlDb.GetDataTable("SELECT sum(weight) as weight FROM tbt_asbkeo_cus_orderdtl WHERE Order_No='" + Order_No + "' AND Available_Group_Id='4'").Rows(0)(0).ToString
        Me.totalamount3 = sqlDb.GetDataTable("SELECT sum(amount) as amount FROM tbt_asbkeo_cus_orderdtl WHERE Order_No='" + Order_No + "' AND Available_Group_Id='4'").Rows(0)(0).ToString
        'Me.delivertycost2 = sqlDb.GetDataTable("SELECT Delivery_special FROM tbt_asbkeo_cus_order WHERE Order_No='" + Order_No + "'").Rows(0)(0).ToString
        Me.promo_discount = sqlDb.GetDataTable("SELECT convert(decimal(8,0), Promo_Discount) as Promo_Discount FROM tbt_asbkeo_cus_order WHERE Order_No='" + Order_No + "'").Rows(0)(0).ToString
        Me.promo_discount_amount = sqlDb.GetDataTable("SELECT isnull(Promo_Discount_Amount,0) FROM tbt_asbkeo_cus_order WHERE Order_No='" + Order_No + "'").Rows(0)(0).ToString
    End Sub
    Public Function BranchName()
        Dim sqlDb As New SqlDb
        Dim dt As DataTable
        Dim sqlCommand As String
        Dim condition As String = ""

        sqlCommand = " SELECT Org_AB_Name"
        sqlCommand &= " FROM  tbm_syst_organizeab"
        sqlCommand &= " WHERE Org_AB_code='" + Branch_Code + "'"

        dt = sqlDb.GetDataTable(sqlCommand)

        Return dt

    End Function
    Public Function Delivery()
        Dim sqlDb As New SqlDb
        Dim dt As DataTable
        Dim sqlCommand As String
        Dim condition As String = ""

        sqlCommand = " SELECT (Charge_Rate+(Charge_Rate*(Fuel_Surcharge/100)))+"
        sqlCommand &= " ((Charge_Rate+(Charge_Rate*(Fuel_Surcharge/100)))*tbm_syst_company.vat)/100 as delivery"
        sqlCommand &= " FROM  tbm_syst_deliverycharge,tbm_syst_company"
        sqlCommand &= " WHERE Transport_Type='" + Transport_Type + "'"
        sqlCommand &= " AND Zone_Code='" + ZONE_code + "' "
        sqlCommand &= " AND Weight<=" + (CDbl(Total_Weight) * 1000).ToString + " "
        sqlCommand &= " AND To_Weight>=" + (CDbl(Total_Weight) * 1000).ToString + " "

        dt = sqlDb.GetDataTable(sqlCommand)

        Return dt

    End Function

    Public Function Delivery_More()
        Dim sqlDb As New SqlDb
        Dim dt As DataTable
        Dim sqlCommand As String
        Dim condition As String = ""

        sqlCommand = " SELECT ((Charge_Rate+(Charge_Rate*(Fuel_Surcharge/100)))+ "
        sqlCommand &= " ((Charge_Rate+(Charge_Rate*(Fuel_Surcharge/100)))*tbm_syst_company.vat)/100) * " + Total_Weight + " as delivery"
        sqlCommand &= " FROM  tbm_syst_deliverycharge,tbm_syst_company"
        sqlCommand &= " WHERE Transport_Type='" + Transport_Type + "'"
        sqlCommand &= " AND Zone_Code='" + ZONE_code + "' "
        sqlCommand &= " AND Weight <= " + (CDbl(Total_Weight) * 1000).ToString + " "
        sqlCommand &= " AND To_Weight>=" + (CDbl(Total_Weight) * 1000).ToString + " "

        dt = sqlDb.GetDataTable(sqlCommand)
        Return dt
    End Function
    Public Function Country()
        Dim sqlDb As New SqlDb
        Dim dt As DataTable
        Dim sqlCommand As String
        Dim condition As String = ""

        If Country_Code <> "" Then
            condition = " AND Country_Code='" + Country_Code + "'"
        End If
        If Country_Name <> "" Then
            condition = " AND country_name like'%" + Country_Name + "%'"
        End If
        sqlCommand = " SELECT distinct country_code,country_name,a.zone_code "
        sqlCommand &= " FROM  tbm_syst_deliverycharge a,tbm_syst_country b"
        sqlCommand &= " WHERE a.zone_code = b.zone_code"
        sqlCommand &= " AND transport_type='" + Transport_Type + "'" + condition


        dt = sqlDb.GetDataTable(sqlCommand)

        Return dt

    End Function
    Public Function ZoneChange()
        Dim sqlDb As New SqlDb
        Dim dt As DataTable
        Dim sqlCommand As String
        Dim condition As String = ""

        sqlCommand = " Select  tbm_syst_deliverycharge.ZONE_code "
        sqlCommand &= "from tbm_syst_deliverycharge left join tbm_syst_country "
        sqlCommand &= " on  tbm_syst_deliverycharge.ZONE_code=tbm_syst_country.ZONE_code"
        sqlCommand &= " where Transport_Type='" + Transport_Type + "'"
        sqlCommand &= " and  country_code='" + Me.Country_Code + "'"


        dt = sqlDb.GetDataTable(sqlCommand)
        Return dt
    End Function
    Public Function Deposit()
        Dim sqlDb As New SqlDb
        Dim dt As DataTable
        Dim sqlCommand As String
        Dim condition As String = ""

        sqlCommand = " SELECT Minimum_Percentage_Payment"
        sqlCommand &= " FROM  tbm_syst_company"
        dt = sqlDb.GetDataTable(sqlCommand)
        Return dt
    End Function
    Public Function Group_Code()
        Dim sqlDb As New SqlDb
        Dim dt As DataTable
        Dim sqlCommand As String
        Dim condition As String = ""

        sqlCommand = " SELECT tbm_syst_organizeab.Group_Code"
        sqlCommand &= " FROM tbt_asbkeo_cus_order inner join tbm_syst_organizeab"
        sqlCommand &= " ON  tbt_asbkeo_cus_order.Address_Org_Ab=tbm_syst_organizeab.Org_AB_code"
        sqlCommand &= " WHERE order_no='" + Order_No + "'"

        dt = sqlDb.GetDataTable(sqlCommand)
        Return dt
    End Function
    Public Function Report()
        Dim sqlDb As New SqlDb
        Dim dt As DataTable
        Dim sqlCommand As String
        Dim condition As String = ""
        Dim Path As String = ConfigurationSettings.AppSettings("PicLogo").ToString

        sqlCommand = " SELECT  tbt_asbkeo_cus_order.Order_No, convert(varchar(10),Order_Date,103) as Order_Date, "
        sqlCommand &= "tbt_asbkeo_cus_order.Member_Id, tbt_asbkeo_cus_order.Customer_Name, "
        sqlCommand &= "tbt_asbkeo_cus_order.Last_Name, tbt_asbkeo_cus_order.Telephone,tbt_asbkeo_cus_order.Ref_Cus_No, "
        sqlCommand &= "tbt_asbkeo_cus_order.Total_Amount, tbt_asbkeo_cus_order.Total_Weight, "
        sqlCommand &= "tbt_asbkeo_cus_order.Max_Leadtime, tbt_asbkeo_cus_order.Delivery_Cost, "
        sqlCommand &= "tbt_asbkeo_cus_order.Delivery_Available, tbt_asbkeo_cus_order.Delivery_special, "
        sqlCommand &= "tbt_asbkeo_cus_order.Grand_Total, tbt_asbkeo_cus_order.Deposit_Amount, "
        sqlCommand &= "tbt_asbkeo_cus_order.Balance, tbt_asbkeo_cus_order.Ship_To_Name, "
        sqlCommand &= "tbt_asbkeo_cus_order.Ship_To_Address,tbt_asbkeo_cus_order.Transport_Type, "
        sqlCommand &= "tbt_asbkeo_cus_order.Billing_Name, tbt_asbkeo_cus_order.Billing_Address, "
        sqlCommand &= "tbt_asbkeo_cus_order.Gift_Flag,tbt_asbkeo_cus_order.Gift_From, tbt_asbkeo_cus_order.Gift_To, "
        sqlCommand &= "tbt_asbkeo_cus_order.Gift_Message, tbt_asbkeo_cus_order.Payment_Method_Code, "
        sqlCommand &= "tbt_asbkeo_cus_order.Payment_Type, tbt_asbkeo_cus_order.Sales_Channel_Code, "
        sqlCommand &= "tbt_asbkeo_cus_order.Address_Org_Ab, tbt_asbkeo_cus_order.Exchange_Rate, "
        sqlCommand &= "tbm_syst_country.Country_Name, tbt_asbkeo_cus_orderdtl.Orderdtl_No, "
        sqlCommand &= "tbt_asbkeo_cus_order.field1 as PickUpCode,tbt_asbkeo_cus_order.field2 as PickUpName, "
        sqlCommand &= "tbt_asbkeo_cus_order.field3 as PickUpAddress,tbt_asbkeo_cus_order.field4 as PickUpEmail, "
        sqlCommand &= "tbt_asbkeo_cus_orderdtl.Available_Group_Id, tbt_asbkeo_cus_orderdtl.ISBN, "
        sqlCommand &= "tbt_asbkeo_cus_orderdtl.Weight, tbt_asbkeo_cus_orderdtl.Leadtime, "
        sqlCommand &= "tbt_asbkeo_cus_orderdtl.Unitprice, "
        'tbt_asbkeo_cus_orderdtl.Discount, ""
        sqlCommand &= "case isnull(convert(numeric(18,2),tbt_asbkeo_cus_orderdtl.Discount),0) when 0 then isnull(convert(varchar,tbt_asbkeo_cus_orderdtl.Discount_Report),0) else tbt_asbkeo_cus_orderdtl.Discount end as Discount , "
        sqlCommand &= "tbt_asbkeo_cus_orderdtl.Orderqty, tbt_asbkeo_cus_orderdtl.Amount, "
        sqlCommand &= "tbt_asbkeo_cus_orderdtl.Cartno, tbt_asbkeo_cus_orderdtl.Cartdtlno, "
        sqlCommand &= "tbt_asbkeo_cus_orderdtl.Deliver_Date, tbt_asbkeo_cus_orderdtl.Order_Status, "
        sqlCommand &= "tbt_asbkeo_cus_orderdtl.Complete_Date, tbt_asbkeo_cus_orderdtl.Jobber, "
        sqlCommand &= "tbt_asbkeo_cus_orderdtl.Job_Date, tbt_asbkeo_cus_orderdtl.Po_No, "
        sqlCommand &= "tbt_asbkeo_cus_orderdtl.Remark, tbt_jobber_book_search.Book_Title, "
        sqlCommand &= "tbm_syst_organizeab.Group_Code,tbm_syst_organizeab.field2,tbm_syst_organizeab.field1, "
        sqlCommand &= "tbm_syst_organizeab.Org_AB_code,tbm_syst_organizeab.Org_AB_Name , "
        sqlCommand &= "case isnull(tbt_asbkeo_cus_orderdtl.Status,'') when 'SPECIAL' then '*****' else '' end as Status "
        sqlCommand &= " FROM tbt_asbkeo_cus_order LEFT JOIN tbm_syst_country"
        sqlCommand &= " ON tbm_syst_country.Country_Code = tbt_asbkeo_cus_order.Country_Code "
        sqlCommand &= "     and tbt_asbkeo_cus_order.zone=tbm_syst_country.zone_code"
        sqlCommand &= " LEFT JOIN tbt_asbkeo_cus_orderdtl "
        sqlCommand &= " ON tbt_asbkeo_cus_order.Order_No = tbt_asbkeo_cus_orderdtl.Order_No"
        sqlCommand &= " LEFT JOIN (select distinct isbn_13,Book_Title from tbt_jobber_book_search)  as tbt_jobber_book_search"
        sqlCommand &= " ON tbt_asbkeo_cus_orderdtl.ISBN = tbt_jobber_book_search.ISBN_13"
        sqlCommand &= " LEFT JOIN tbm_syst_organizeab ON tbt_asbkeo_cus_order.Address_Org_Ab=tbm_syst_organizeab.Org_AB_code "
        sqlCommand &= " WHERE tbt_asbkeo_cus_order.Order_No='" + Order_No + "'"
        dt = sqlDb.GetDataTable(sqlCommand)
        Return dt
    End Function
    Public Sub GenOrderNo()

        Dim dt As DataTable
        Dim sqlDb As New SqlDb
        Dim OrgCode_co As String
        Dim NO As Integer
        Dim straddorgab As String
        DateNow = sqlDb.GetDataTable("SELECT CONVERT(VARCHAR(10),GETDATE(),120)").Rows(0)(0).ToString
        OrgCode_cr = sqlDb.GetDataTable("SELECT Org_Ab_Code FROM tbt_asbkeo_cart WHERE CartNo='" + CartNo + "'").Rows(0)(0).ToString

        straddorgab = "SELECT TOP(1) right(order_no,5) as order_no"
        straddorgab &= " FROM tbt_asbkeo_cus_order "
        straddorgab &= " WHERE Address_Org_Ab='" + OrgCode_cr + "'"
        straddorgab &= " AND Order_Date='" + DateNow + "'"
        straddorgab &= " ORDER BY order_no DESC"
        dt = SqlDb.GetDataTable(straddorgab)

        If dt.Rows.Count <> 0 Then
            OrgCode_co = dt.Rows(0).Item("order_no").ToString()
            NO = Convert.ToInt16(OrgCode_co) + 1
            Order_No = OrgCode_cr + Convert.ToDateTime(DateNow).ToString("yyMMdd") + "CO" + NO.ToString("00000")
        Else
            Order_No = OrgCode_cr + Convert.ToDateTime(DateNow).ToString("yyMMdd") + "CO" + "00001"
        End If

    End Sub
    Public Function AddCustomerOrder() As Boolean
        Dim dt As DataTable
        Dim dt_ex As DataTable
        Dim sqlDb As New SqlDb
        Dim sqlCommand As String
        Dim OrgCode_co As String
        Dim NO As Integer
        Dim straddorgab As String
        Dim Exchange_rate As Double
        Dim strexchange As String
        DateNow = sqlDb.GetDataTable("SELECT CONVERT(VARCHAR(10),GETDATE(),120)").Rows(0)(0).ToString
        OrgCode_cr = sqlDb.GetDataTable("SELECT Org_Ab_Code FROM tbt_asbkeo_cart WHERE CartNo='" + CartNo + "'").Rows(0)(0).ToString

        straddorgab = "SELECT TOP(1) right(order_no,5) as order_no"
        straddorgab &= " FROM tbt_asbkeo_cus_order "
        straddorgab &= " WHERE Address_Org_Ab='" + OrgCode_cr + "'"
        straddorgab &= " AND Order_Date='" + DateNow + "'"
        straddorgab &= " ORDER BY order_no DESC"
        dt = sqlDb.GetDataTable(straddorgab)

        If dt.Rows.Count <> 0 Then
            OrgCode_co = dt.Rows(0).Item("order_no").ToString()
            NO = Convert.ToInt16(OrgCode_co) + 1
            Order_No = OrgCode_cr + Convert.ToDateTime(DateNow).ToString("yyMMdd") + "CO" + NO.ToString("00000")
        Else
            Order_No = OrgCode_cr + Convert.ToDateTime(DateNow).ToString("yyMMdd") + "CO" + "00001"
        End If

        strexchange = "SELECT Exchange_Rate FROM tbm_syst_currency WHERE Currency_Code='USD'"
        dt_ex = sqlDb.GetDataTable(strexchange)
        If dt_ex.Rows.Count > 0 Then
            Exchange_rate = dt_ex.Rows(0).Item("Exchange_Rate").ToString
        Else
            Exchange_rate = 0
        End If

        Try
            sqlDb.BeginTrans()
            sqlCommand = "INSERT INTO tbt_asbkeo_cus_order"
            sqlCommand &= "(Order_No,Order_Date,Address_Org_Ab,Total_Amount,Exchange_Rate,"
            sqlCommand &= "Total_Weight,Max_Leadtime,Delivery_Cost,Grand_Total,"
            sqlCommand &= "Deposit_Amount,Balance,Transport_Type,Zone,adddt,"
            sqlCommand &= "Customer_Name,Telephone,Country_Code,Last_Name,"
            sqlCommand &= "Ship_to_name,Ship_to_address,Sales_Channel_Code,addempcd,addpcnm,Member_Id,field1,field2,field3,field4,Ref_Cus_No,Email)"
            sqlCommand &= " VALUES('" + Order_No + "',"
            sqlCommand &= " '" + sqlDb.GetDataTable("SELECT CONVERT(VARCHAR(10),GETDATE(),120)").Rows(0)(0).ToString + "',"
            sqlCommand &= " '" + OrgCode_cr + "',"
            sqlCommand &= " '" + CDbl(Total_Amount).ToString + "',"
            sqlCommand &= " '" + CDbl(Exchange_rate).ToString + "',"
            sqlCommand &= " '" + CDbl(Total_Weight).ToString + "',"
            sqlCommand &= " '" + CInt(Max_Leadtime).ToString + "',"
            sqlCommand &= " '" + CDbl(Delivery_Cost).ToString + "',"
            sqlCommand &= " '" + CDbl(Grand_Total).ToString + "',"
            sqlCommand &= " '" + CDbl(Deposit_Amount).ToString + "',"
            sqlCommand &= " '" + CDbl(Balance).ToString + "',"
            sqlCommand &= " '" + Transport_Type + "',"
            sqlCommand &= " '" + Zone + "',"
            sqlCommand &= " '" + sqlDb.GetDataTable("SELECT CONVERT(VARCHAR(30),GETDATE(),120)").Rows(0)(0).ToString + "',"
            sqlCommand &= " '" + Customer_Name.ToString.Replace("'", "'+Char(39)+'") + "',"
            sqlCommand &= " '" + Telephone + "',"
            sqlCommand &= " '" + Country_Code + "',"
            sqlCommand &= " '" + Last_Name.ToString.Replace("'", "'+Char(39)+'") + "',"
            sqlCommand &= " '" + Ship_to_name.ToString.Replace("'", "'+Char(39)+'") + "',"
            sqlCommand &= " '" + Ship_to_address.ToString.Replace("'", "'+Char(39)+'") + "',"
            sqlCommand &= " '" + sqlDb.GetDataTable("SELECT Sales_Channel_Code FROM tbt_asbkeo_cart WHERE CartNo='" + CartNo + "'").Rows(0)(0).ToString + "',"
            sqlCommand &= " '" + Empcd + "',"
            sqlCommand &= " '" + Pcnm + "',"
            sqlCommand &= " '" + Member_Code + "',"
            sqlCommand &= " '" + PickUpCode + "',"
            sqlCommand &= " '" + PickUpName.ToString.Replace("'", "'+Char(39)+'") + "',"
            sqlCommand &= " '" + PickUpAddress.ToString.Replace("'", "'+Char(39)+'") + "',"
            sqlCommand &= " '" + PickUpEmail.ToString.Replace("'", "'+Char(39)+'") + "',"
            sqlCommand &= " '" + Ref_Cart + "',"
            sqlCommand &= " '" + Email.ToString.Replace("'", "'+Char(39)+'") + "')"
            sqlDb.Exec(sqlCommand)
            sqlDb.CommitTrans()
            message = "Add  Successful"
            Return True
        Catch ex As Exception
            sqlDb.RollbackTrans()
            message = ex.Message
            Return False
        End Try
    End Function
    Public Sub AddCustomerOrderDetail()
        Dim sqlDb As New SqlDb
        Dim sqlCommand As String
        Try

            sqlDb.BeginTrans()
            sqlCommand = "INSERT INTO tbt_asbkeo_cus_orderdtl"
            sqlCommand &= "(Order_No,Orderdtl_No,Available_Group_Id,ISBN,"
            sqlCommand &= "Weight,Unitprice,Orderqty,Amount,CartNo,Cartdtlno,"
            sqlCommand &= "Order_Status,adddt,Leadtime,addempcd,jobber,addpcnm,currency_code,Cover_Price,Discount_Report,Book_Title_Report,Exchange_Rate)"
            sqlCommand &= " VALUES('" + Order_No + "',"
            sqlCommand &= " '" + Orderdtl_No + "',"
            sqlCommand &= " '" + Available_Group_Id + "',"
            sqlCommand &= " '" + ISBN + "',"
            sqlCommand &= " '" + CDbl(Weight).ToString + "',"
            sqlCommand &= " '" + CDbl(Unitprice).ToString + "',"
            sqlCommand &= " '" + CDbl(Orderqty).ToString + "',"
            sqlCommand &= " '" + CDbl(Amount).ToString + "',"
            sqlCommand &= " '" + CartNo + "',"
            sqlCommand &= " '" + Cartdtlno + "',"
            sqlCommand &= " '1',"
            sqlCommand &= " '" + sqlDb.GetDataTable("SELECT CONVERT(VARCHAR(30),GETDATE(),120)").Rows(0)(0).ToString + "',"
            sqlCommand &= " '" + sqlDb.GetDataTable("SELECT Leadtime FROM  tbt_asbkeo_cartdetail WHERE CartNo='" + CartNo + "' AND Cartdtlno='" + Cartdtlno + "' AND Available_Group_id='" + Available_Group_Id + "'").Rows(0)(0).ToString + "',"
            sqlCommand &= " '" + Empcd + "',"
            sqlCommand &= " '" + Jobber + "',"
            sqlCommand &= " '" + Pcnm + "',"
            sqlCommand &= " '" + Currency_Code + "',"
            sqlCommand &= " '" + CDbl(Cover_Price).ToString + "',"
            sqlCommand &= " '" + CDbl(Discount_Report).ToString + "',"
            sqlCommand &= " '" + Book_Title_Report.Replace("'", "'+Char(39)+'") + "',"
            sqlCommand &= " '" + CDbl(Exchang_Rate_Detail).ToString + "')"
            sqlDb.Exec(sqlCommand)
            sqlDb.CommitTrans()
            message = "Add  Successful"
        Catch ex As Exception
            sqlDb.RollbackTrans()
            message = ex.Message
        End Try
    End Sub
   
   
End Class
