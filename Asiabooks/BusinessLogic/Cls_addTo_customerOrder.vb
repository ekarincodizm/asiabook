Imports Microsoft.VisualBasic
Imports Eordering.BusinessLogic
Imports System
Imports System.Data
Imports System.Configuration
Imports System.Net.DNS
Imports System.IO
Public Class Cls_addTo_customerOrder

    Dim strMessage As String
    Dim DateNow As String
    Dim OrgCode_cr As String
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
    Private strDelivery_Available As String
    Private strDelivery_special As String
    Private strGrand_Total As String
    Private strDeposit_Amount As String
    Private strBalance As String
    Private strShip_to_name As String
    Private strShip_to_address As String
    Private strTransport_Type As String
    Private strZONEcode As String
    Private strZone As String
    Private strCountry_Code As String
    Private strBilling_Name As String
    Private strBilling_Address As String
    Private strGift_Flag As String
    Private strGift_From As String
    Private strGift_to As String
    Private strGift_Message As String
    Private strPayment_Method_Code As String
    Private strPayment_Type As String
    Private strSales_Channel_Code As String
    Private strExchange_Rate As String
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
    Private strLast_Name As String
    Private strEmpcd As String
    Private strPcnm As String
    Private strPickUpCode As String
    Private strPickUpName As String
    Private strPickUpAddress As String
    Private strPickUpEmail As String
    Private strEmail As String
    Private strcurrency_code As String
    Private strcover_price As String
    Private strdiscount_report As String
    Private strbook_title_report As String
    Private strexchange_rate_detail As String

    Property Message()
        Get
            Return strMessage
        End Get
        Set(ByVal value)
            strMessage = value
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
    Property Last_Name()
        Get
            Return strLast_Name
        End Get
        Set(ByVal value)
            strLast_Name = value
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
    Property Delivery_Available()
        Get
            Return strDelivery_Available
        End Get
        Set(ByVal value)
            strDelivery_Available = value
        End Set
    End Property
    Property Delivery_special()
        Get
            Return strDelivery_special
        End Get
        Set(ByVal value)
            strDelivery_special = value
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
    Property Zone()
        Get
            Return strZone
        End Get
        Set(ByVal value)
            strZone = value
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
    Property Exchange_Rate()
        Get
            Return strExchange_Rate
        End Get
        Set(ByVal value)
            strExchange_Rate = value
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
    Property Empcd()
        Get
            Return strEmpcd
        End Get
        Set(ByVal value)
            strEmpcd = value
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
    Property Exchange_Rate_Detail()
        Get
            Return strexchange_rate_detail
        End Get
        Set(ByVal value)
            strexchange_rate_detail = value
        End Set
    End Property

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
    'Public Function ZoneChange()
    '    Dim sqlDb As New SqlDb
    '    Dim dt As DataTable
    '    Dim sqlCommand As String
    '    Dim condition As String = ""

    '    sqlCommand = " SELECT Zone_Code"
    '    sqlCommand &= " FROM  tbm_syst_country"
    '    sqlCommand &= " WHERE country_code='" + Country_Code + "'"

    '    dt = sqlDb.GetDataTable(sqlCommand)
    '    Return dt
    'End Function
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
    Public Function AddCustomerOrder() As Boolean
        Dim sqlDb As New SqlDb
        Dim sqlCommand As String
        Dim dt As DataTable
        Dim OrgCode_co As String
        Dim NO As Integer
        Dim straddorgab As String
        Try
            DateNow = sqlDb.GetDataTable("SELECT CONVERT(VARCHAR(10),GETDATE(),120)").Rows(0)(0).ToString
            Dim adddt As String = sqlDb.GetDataTable("select convert(varchar(30),getdate(),120)").Rows(0)(0).ToString
            If CartNo <> "" Then
                OrgCode_cr = sqlDb.GetDataTable("SELECT Org_Ab_Code FROM tbt_asbkeo_cart WHERE CartNo='" + CartNo + "'").Rows(0)(0).ToString
            Else
                Message = "Add  Unsuccessful, Cart No. is not valid"
            End If

            straddorgab = "SELECT TOP(1) right(order_no,5) as order_no"
            straddorgab &= " FROM tbt_asbkeo_cus_order "
            straddorgab &= " WHERE Address_Org_Ab='" + OrgCode_cr + "'"
            straddorgab &= " AND Order_Date='" + DateNow + "'"
            straddorgab &= " ORDER BY order_no DESC"
            dt = sqlDb.GetDataTable(straddorgab)

            If dt.Rows.Count <> 0 Then
                OrgCode_co = dt.Rows(0).Item("order_no").ToString()
                NO = Convert.ToInt16(OrgCode_co) + 1
                If Sales_Channel_Code = ConfigurationSettings.AppSettings("UserInternet").ToString Then
                    Order_No = Convert.ToDateTime(DateNow).ToString("yyMMdd") + NO.ToString("000000")
                Else
                    Order_No = OrgCode_cr + Convert.ToDateTime(DateNow).ToString("yyMMdd") + "CO" + NO.ToString("00000")
                End If
            Else
                If Sales_Channel_Code = ConfigurationSettings.AppSettings("UserInternet").ToString Then
                    Order_No = Convert.ToDateTime(DateNow).ToString("yyMMdd") + "000001"
                Else
                    Order_No = OrgCode_cr + Convert.ToDateTime(DateNow).ToString("yyMMdd") + "CO" + "00001"
                End If
            End If
            sqlDb.BeginTrans()
            sqlCommand = "INSERT INTO tbt_asbkeo_cus_order"
            sqlCommand &= "(Order_No,Order_Date,Member_Id,Customer_Name,Last_Name,Telephone,"
            sqlCommand &= "Total_Amount,Total_Weight,Max_Leadtime,Delivery_Cost,"
            sqlCommand &= "Delivery_Available,Delivery_special,Grand_Total,"
            sqlCommand &= "Deposit_Amount,Balance,Ship_to_name,Ship_to_address,Transport_Type,Zone,"
            sqlCommand &= "Country_Code,Billing_Name,Billing_Address,Gift_Flag,Gift_From,Gift_To,Gift_Message,"
            sqlCommand &= "Payment_Method_Code,Payment_Type,Sales_Channel_Code,Address_Org_Ab,"
            sqlCommand &= "Exchange_Rate,addempcd,addpcnm,adddt,field1,field2,field3,field4,Email)"
            sqlCommand &= " VALUES('" + Order_No + "',"
            sqlCommand &= " '" + DateNow + "',"
            sqlCommand &= " '" + Member_Id + "',"
            sqlCommand &= " '" + Customer_Name.ToString.Replace("'", "'+Char(39)+'") + "',"
            sqlCommand &= " '" + Last_Name.ToString.Replace("'", "'+Char(39)+'") + "',"
            sqlCommand &= " '" + Telephone + "',"
            sqlCommand &= " " + CDbl(Total_Amount).ToString + ","
            sqlCommand &= " " + CDbl(Total_Weight).ToString + ","
            sqlCommand &= " " + CInt(Max_Leadtime).ToString + ","
            sqlCommand &= " " + CDbl(Delivery_Cost).ToString + ","
            sqlCommand &= " " + CDbl(Delivery_Available).ToString + ","
            sqlCommand &= " " + CDbl(Delivery_special).ToString + ","
            sqlCommand &= " " + CDbl(Grand_Total).ToString + ","
            sqlCommand &= " " + CDbl(Deposit_Amount).ToString + ","
            sqlCommand &= " " + CDbl(Balance).ToString + ","
            sqlCommand &= " '" + Ship_to_name.ToString.Replace("'", "'+Char(39)+'") + "',"
            sqlCommand &= " '" + Ship_to_address.ToString.Replace("'", "'+Char(39)+'") + "',"
            sqlCommand &= " '" + Transport_Type + "',"
            sqlCommand &= " '" + Zone + "',"
            sqlCommand &= " '" + Country_Code + "',"
            sqlCommand &= " '" + Billing_Name.ToString.Replace("'", "'+Char(39)+'") + "',"
            sqlCommand &= " '" + Billing_Address.ToString.Replace("'", "'+Char(39)+'") + "',"
            sqlCommand &= " '" + Gift_Flag + "',"
            sqlCommand &= " '" + Gift_From.ToString.Replace("'", "'+Char(39)+'") + "',"
            sqlCommand &= " '" + Gift_to.ToString.Replace("'", "'+Char(39)+'") + "',"
            sqlCommand &= " '" + Gift_Message.ToString.Replace("'", "'+Char(39)+'") + "',"
            sqlCommand &= " '" + Payment_Method_Code + "',"
            sqlCommand &= " '" + Payment_Type + "',"
            sqlCommand &= " '" + Sales_Channel_Code + "',"
            sqlCommand &= " '" + OrgCode_cr + "',"
            sqlCommand &= " " + CDbl(Exchange_Rate).ToString + ","
            sqlCommand &= " '" + Empcd + "',"
            sqlCommand &= " '" + Pcnm + "',"
            sqlCommand &= " '" + adddt + "',"
            sqlCommand &= " '" + PickUpCode.ToString.Replace("'", "'+Char(39)+'") + "',"
            sqlCommand &= " '" + PickUpName.ToString.Replace("'", "'+Char(39)+'") + "',"
            sqlCommand &= " '" + PickUpAddress.ToString.Replace("'", "'+Char(39)+'") + "',"
            sqlCommand &= " '" + PickUpEmail.ToString.Replace("'", "'+Char(39)+'") + "',"
            sqlCommand &= " '" + Email.ToString.Replace("'", "'+Char(39)+'") + "')"
            'WriteError("", sqlCommand, "")
            sqlDb.Exec(sqlCommand)

            sqlDb.CommitTrans()
            Return True
            'Message = "Add  Successful"
        Catch ex As Exception
            sqlDb.RollbackTrans()
            Message &= ", " + ex.Message
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
            sqlCommand &= "Weight,Leadtime,Unitprice,Discount,Orderqty,Amount,CartNo,Cartdtlno,"
            sqlCommand &= "Order_Status,addempcd,addpcnm,jobber,adddt,currency_code,Cover_Price,Discount_Report,Book_Title_Report,Exchange_Rate)"
            sqlCommand &= " VALUES('" + Order_No + "',"
            sqlCommand &= " '" + Orderdtl_No + "',"
            sqlCommand &= " '" + Available_Group_Id + "',"
            sqlCommand &= " '" + ISBN + "',"
            sqlCommand &= " " + CDbl(Weight).ToString + ","
            sqlCommand &= " " + CInt(Leadtime).ToString + ","
            sqlCommand &= " " + CDbl(Unitprice).ToString + ","
            sqlCommand &= " " + CDbl(Discount).ToString + ","
            sqlCommand &= " " + CDbl(Orderqty).ToString + ","
            sqlCommand &= " " + CDbl(Amount).ToString + ","
            sqlCommand &= " '" + CartNo + "',"
            sqlCommand &= " '" + Cartdtlno + "',"
            sqlCommand &= " '1',"
            sqlCommand &= " '" + Empcd + "',"
            sqlCommand &= " '" + Pcnm + "',"
            sqlCommand &= " '" + Jobber + "',"
            sqlCommand &= " '" + sqlDb.GetDataTable("SELECT CONVERT(VARCHAR(30),GETDATE(),120)").Rows(0)(0).ToString + "',"
            sqlCommand &= " '" + Currency_Code + "',"
            sqlCommand &= " '" + CDbl(Cover_Price).ToString + "',"
            sqlCommand &= " '" + CDbl(Discount_Report).ToString + "',"
            sqlCommand &= " '" + Book_Title_Report.Replace("'", "'+Char(39)+'") + "',"
            sqlCommand &= " '" + CDbl(Exchange_Rate_Detail).ToString + "')"
            'WriteError("", sqlCommand, "")
            sqlDb.Exec(sqlCommand)
            sqlDb.CommitTrans()
            Message = "Add  Successful"
        Catch ex As Exception
            sqlDb.RollbackTrans()
            message = ex.Message
        End Try
    End Sub
    Public Sub AddError()

        Dim sqlDb As New SqlDb
        Dim sqlCommand As String
        Try

            sqlDb.BeginTrans()
            sqlCommand = "UPDATE tbt_asbkeo_cus_orderdtl"
            sqlCommand &= " SET Order_Status='5',"
            sqlCommand &= " Remark='payment web service error',"
            sqlCommand &= " upddt='" + sqlDb.GetDataTable("SELECT CONVERT(VARCHAR(30),GETDATE(),120)").Rows(0)(0).ToString + "',"
            sqlCommand &= " updempcd='" + Empcd + "',"
            sqlCommand &= " updpcnm= '" + Pcnm + "'"
            sqlCommand &= " WHERE Order_No='" + Order_No + "'"
            sqlCommand &= " UPDATE tbt_asbkeo_cartdetail"
            sqlCommand &= " SET Ordstt='2',"
            sqlCommand &= " upddt='" + sqlDb.GetDataTable("SELECT CONVERT(VARCHAR(30),GETDATE(),120)").Rows(0)(0).ToString + "',"
            sqlCommand &= " updemp='" + Empcd + "',"
            sqlCommand &= " updpcnm= '" + Pcnm + "'"
            sqlCommand &= " WHERE CartNo='" + CartNo + "'"
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
        objStreamWriter.WriteLine(str)

        ' Close the stream   
        objStreamWriter.Close()





    End Sub
End Class
