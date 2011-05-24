Imports Eordering.BusinessLogic
Imports System.Web.UI
Imports System
Imports System.Data
Imports MycustomDG
Imports Eordering.BusinessLogic.PageControl
Imports Microsoft.VisualBasic
Imports asiabooksmember.member
Imports ws_payment.PaymentService
Imports System.Math
Imports System.Web.Mail
Imports System.Configuration
Imports System.IO
Imports KeiosLogic

Partial Class Customer_Order_Internet
    Inherits System.Web.UI.Page
    Private _Utility As New clsUtility
    Private uClass As New uClass
    Dim dt As New DataTable
    Dim bd As New Class_book_detail
    'Dim cart As New Cls_Cart
    Dim cus_order As New Cls_addTo_customerOrder
    Dim discount_customer As Double
    Dim discount As String
    'Dim Member_Id As String
    Dim member_code As String
    Dim Exchange_Rate As String
    Dim member As New Member
    Dim str As String
    Dim PaymentService As New ws_payment.paymentservice.PaymentService
    Dim Url As String
    Dim MessagePayment As String = ConfigurationSettings.AppSettings("ErrorMessagePayment").ToString
    Dim telephone As String
    Dim mobile As String
    Dim clsPromotion As New clsGenCode_Promotion
    Dim ws_Send_SMS As New Send_SMS.Send_SMS

    Dim strPickUpCode As String
    Dim strPickUpName As String
    Dim strPickUpAddress As String
    Dim strPickUpEmail As String
    Dim SmtpMail As String = Convert.ToString(ConfigurationSettings.AppSettings("SmtpServer"))
    Dim UserPassword As String = Convert.ToString(ConfigurationSettings.AppSettings("MailPassword"))
    Dim UserName As String = Convert.ToString(ConfigurationSettings.AppSettings("MailUserID"))
    Dim mailto As String = Convert.ToString(ConfigurationSettings.AppSettings("to"))
    Dim mailcc As String = Convert.ToString(ConfigurationSettings.AppSettings("cc"))
    Dim mailinformation As String = Convert.ToString(ConfigurationSettings.AppSettings("MailInformation"))
    Dim MailFrom As String = Convert.ToString(ConfigurationSettings.AppSettings("MailFrom"))

    'Dim Mailtemp As String = System.AppDomain.CurrentDomain.BaseDirectory() & ConfigurationSettings.AppSettings("MailTemplate")
    Dim Co As New Cls_Customer_Order
    Dim dtOrder As New DataTable
    Dim CartNo As String
    Dim CartNo_Cus As String
    Dim dt_In_Branch As DataTable
    Dim dt_Other_Branch As DataTable
    Dim dt_Jobber As DataTable
    Dim dt_Ebook As DataTable
    Dim dt_ebook_merged As DataTable
    Dim amount_Branch As Double
    Dim amount_other_Branch As Double
    Dim amount_Jobber As Double
    Dim amount_Ebook As Double
    Dim keyword_Branch As String
    Dim keyword_sales_channel As String
    Dim Empcd As String
    Dim Pcnm As String
    Dim message As String
    Dim Author As String
    Dim DateNow As String
    Dim OrgCode_cr As String
    Dim Branch_Code As String
    Dim Order_No As String
    Dim Order_Date As String
    Dim Member_Id As String
    Dim Customer_Name As String
    Dim Total_Amount As String
    Dim Total_Weight As String
    Dim Max_Leadtime As String
    Dim Delivery_Cost As String
    Dim Delivery_Available As String
    Dim Delivery_special As String
    Dim Grand_Total As String
    Dim Deposit_Amount As String
    Dim Balance As String
    Dim Ship_to_name As String
    Dim Ship_to_address As String
    Dim Transport_Type As String
    Dim ZONEcode As String
    Dim Zone As String
    Dim Country_Code As String
    Dim Billing_Name As String
    Dim Billing_Address As String
    Dim Gift_Flag As String
    Dim Gift_From As String
    Dim Gift_to As String
    Dim Gift_Message As String
    Dim Payment_Method_Code As String
    Dim Payment_Type As String
    Dim Sales_Channel_Code As String
    Dim Orderdtl_No As String
    Dim Available_Group_Id As String
    Dim ISBN As String
    Dim Weight As String
    Dim Leadtime As String
    Dim Unitprice As String
    Dim Orderqty As String
    Dim Amount As String
    Dim Cartdtlno As String
    Dim Order_Status As String
    Dim Deliver_Date As String
    Dim Complete_Date As String
    Dim Job_Date As String
    Dim Po_No As String
    Dim Remark As String
    Dim Last_Name As String
    Dim PickUpCode As String
    Dim PickUpName As String
    Dim PickUpAddress As String
    Dim PickUpEmail As String
    Dim Email As String
    Dim currency_code As String
    Dim cover_price As String
    Dim discount_report As String
    Dim book_title_report As String
    Dim exchange_rate_detail As String
    Dim exchange_rate_internet As String
    Dim Jobber_Name As String
    Dim PaymentDesc As New StringBuilder
    Dim ZONE_code As String
    Dim strSQL_ISBN As String = ""
    Dim EBook_Id As String
    Dim promo_discount As Double
    Dim promo_discount_amount As Double
    Dim strAumphur As String = ""
    Dim strProvince As String = ""
    Dim strCountry As String = ""
    Dim strZipCode As String = ""

    Private keios As uKeios
    Private uCon As uConnect

    Protected Sub Alert(ByVal Message As String)
        UI.ScriptManager.RegisterClientScriptBlock(Me.Page, Me.GetType, "Close", "alert('" + Message + "');", True)
    End Sub

    Public Sub getUrl(ByVal imagePath As String)

        Response.Write(Request.Url.Scheme.ToString & Uri.SchemeDelimiter.ToString & _
                       Request.Url.Authority.ToString & _
                       IIf(Request.ApplicationPath.ToString = "/", "", Request.ApplicationPath.ToString) & imagePath)

    End Sub
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Me.Title = ConfigurationManager.AppSettings("SiteTitle").ToString & "Customer Order ::"
        Dim sqlDb As New SqlDb

        Session("ModalPopup") = Nothing

        member_code = Request.Cookies("myCookie_user")("MemberCode")

        If member_code.Length = 10 And member_code <> "1100002869" Then
            b_edit.Visible = True
        Else
            b_edit.Visible = False
        End If

        If Not Me.IsPostBack Then
            getTransport_Type()
            cbo_payment_type.Width = 100
            uc_country.ShowData("")

            getPayment()
            customer()

            Me.In_Branch.DataSource = Session("In_Branch")
            Me.In_Branch.DataBind()
            Me.jobber.DataSource = Session("jobber")
            Me.jobber.DataBind()           
            'Me.ebook.DataSource = Session("ebook_shopping")
            'Me.ebook.DataSource = Session("ebook_promotion")
            'Me.ebook.DataBind()

            Dim dt_ebook As New DataTable
            If Not Session("ebook_shopping") Is Nothing Then
                dt_ebook = DirectCast(Session("ebook_shopping"), DataTable).Copy
            End If
            
            Dim dt_promo_ebook As New DataTable
            If Not Session("PROMOTION") Is Nothing Then
                dt_promo_ebook = DirectCast(Session("PROMOTION"), DataTable).Copy
            End If

            Dim max_ebook_no As Integer = 0
            If Not dt_ebook Is Nothing Then
                If dt_ebook.Rows.Count > 0 Then
                    max_ebook_no = CInt(dt_ebook.Rows(dt_ebook.Rows.Count - 1).Item("No"))
                End If
            End If

            If Not dt_promo_ebook Is Nothing Then
                For i As Integer = 0 To dt_promo_ebook.Rows.Count - 1
                    dt_promo_ebook.Rows(i).Item("No") = max_ebook_no + (i + 1)
                    'dt_promo_ebook.Rows(i).Item("Selling_Price") = "0"
                    dt_promo_ebook.Rows(i).Item("Items_Amount") = "0"
                Next

                dt_ebook.Merge(dt_promo_ebook)
            End If

            dt_ebook_merged = dt_ebook
            Session("ebook_merged") = dt_ebook

            If dt_ebook_merged.Rows.Count > 0 Then
                Me.ebook.DataSource = dt_ebook_merged
                Me.ebook.DataBind()
            End If


            ' check data in In_Branch  
            If Me.In_Branch.Items.Count = 0 Then
                Me.P_In_Branch.Visible = False
                Me.P_In_branch_1.Visible = False
            Else
                in_branch_total()
                Me.P_In_Branch.Visible = True
                Me.P_In_branch_1.Visible = True
            End If

            ' check data in jobber
            If Me.jobber.Items.Count = 0 Then
                Me.P_jobber.Visible = False
                Me.P_jobber1.Visible = False
            Else
                jobber_total()
                Me.P_jobber.Visible = True
                Me.P_jobber1.Visible = True
            End If

            ' check data in ebook
            If Me.ebook.Items.Count = 0 Then
                Me.P_ebook.Visible = False
                Me.P_ebook1.Visible = False
                Me.P_ebook_promo.Visible = False
            Else
                ebook_total()
                Me.P_ebook.Visible = True
                Me.P_ebook1.Visible = True
            End If

            lbl_total_amount.Text = (CDbl(checkNullTo0(lbl_InBranch_total.Text)) + CDbl(checkNullTo0(lbl_jobber_total.Text)) + CDbl(checkNullTo0(lbl_ebook_total.Text))).ToString("#,###,##0.00")
            lbl_total_amount_usd.Text = "(US$ " + bd.callUsd(lbl_total_amount.Text) + ")" ' convert bath to USD
            lbl_h_Order_Date.Text = sqlDb.GetDataTable("SELECT CONVERT(VARCHAR(10),GETDATE(),103)").Rows(0)(0).ToString

            tbx_name.Enabled = False
            tbx_name.BackColor = Drawing.Color.LightGray
            tbx_Address.Enabled = False
            tbx_Address.BackColor = Drawing.Color.LightGray
            tbx_name_bill.Enabled = False
            tbx_name_bill.BackColor = Drawing.Color.LightGray
            tbx_Address_bill.Enabled = False
            tbx_Address_bill.BackColor = Drawing.Color.LightGray

            tbx_name_gift_from.Enabled = False
            tbx_name_gift_from.BackColor = Drawing.Color.LightGray
            tbx_name_gift_to.Enabled = False
            tbx_name_gift_to.BackColor = Drawing.Color.LightGray
            tbx_message_gift.Enabled = False
            tbx_message_gift.BackColor = Drawing.Color.LightGray
            b_export.Enabled = False
            'Show_Organizeab()
            cbo_organizeab.Visible = True
            cbo_county.Visible = False


            Dim Datalist As New Object
            Datalist = Me.GetBestsellers_ConfirmOrder(uXML.BooksBestSeller)
            Me.lvBooks.DataSource = Datalist
            Me.lvBooks.DataBind()

            'only ebook in a cart
            If Me.In_Branch.Items.Count = 0 And Me.jobber.Items.Count = 0 Then
                Me.cbo_Transport_Type.Enabled = False
                Me.cbo_county.Enabled = False
                Me.cbo_organizeab.Enabled = False

                Me.rad_address1.Enabled = False
                Me.rad_address2.Enabled = False
                Me.rad_address3.Enabled = False
                Me.rad_address4.Enabled = False

                Me.chk_gift.Enabled = False
                Me.b_edit.Enabled = False

                lbl_grand_total.Text = (CDbl(checkNullTo0(Me.lbl_total_amount.Text))).ToString("#,###,##0.00")
                lbl_grand_total_usd.Text = "(US$ " + bd.callUsd(lbl_grand_total.Text) + ")"
            End If

            If CDbl(checkNullTo0(lbl_InBranch_total.Text)) + CDbl(checkNullTo0(lbl_jobber_total.Text)) > 0 And CDbl(checkNullTo0(lbl_ebook_total.Text) > 0) Then
                lblCheck_Digit.Text = "3"
            Else
                If CDbl(checkNullTo0(lbl_InBranch_total.Text)) + CDbl(checkNullTo0(lbl_jobber_total.Text)) > 0 Then
                    lblCheck_Digit.Text = "1"
                End If
                If CDbl(checkNullTo0(lbl_ebook_total.Text)) > 0 Then
                    lblCheck_Digit.Text = "2"
                End If
            End If

        End If
        Me.b_export.Attributes.Add("onclick", "window.open('Customer_Order_Tracking_Internet_export.aspx')")

    End Sub
    Private Sub Show_Organizeab()
        Dim sqlDB As SqlDb = New SqlDb
        Dim dt_temp1 As DataTable
        Dim item As New ListItem
        dt_temp1 = sqlDB.GetDataTable("select org_ab_code ,org_ab_name from dbo.tbm_syst_organizeab where group_code not in ('Intransit','HO-Good','HO','WS','KPG','DS','BZCM-AP') and status <> 'N' order by org_ab_name ")
        cbo_organizeab.DataTextField = "org_ab_name"
        cbo_organizeab.DataValueField = "org_ab_code"
        cbo_organizeab.DataSource = dt_temp1
        cbo_organizeab.DataBind()
        item.Value = ""
        item.Text = " -- SELECT -- "
        tbx_Zone.Text = ""
        cbo_organizeab.Items.Insert(0, item)

    End Sub
    Private Sub customer()
        Dim dt_person As New DataTable
        Dim dt_address As New DataTable
        Dim bs_person_id As String
        Dim address As String
        Dim i As Integer
        Dim j As Integer
        Dim ds As New DataSet
        Try


            If Not member_code Is Nothing Then

                ds = member.GetMember(member_code, "2", "ubKPwB6lD2fihnqJycW/TBHP5S9MYMJJ", "asiabooks_emember")


                dt_person = ds.Tables("BS_PERSON")
                dt_address = ds.Tables("BS_ADDRESS")

                If dt_person.Rows.Count > 0 Then
                    For i = 0 To dt_person.Rows.Count - 1
                        If member_code = dt_person.Rows(i).Item("MEMBER_CODE").ToString() Then
                            If dt_person.Rows(i).Item("MEMBER_CODE").ToString.Length = "10" Then
                                discount_customer = 0
                            Else
                                discount = dt_person.Rows(i).Item("DISCOUNT").ToString()
                                discount_customer = CDbl(discount.Substring(0, discount.IndexOf("%")))
                            End If

                            lbl_h_telephone.Text = dt_person.Rows(i).Item("TEL").ToString() + " " + _
                                                    dt_person.Rows(i).Item("MOBILE_TEL").ToString()
                            Session("telephone") = dt_person.Rows(i).Item("TEL").ToString()
                            Session("mobile") = dt_person.Rows(i).Item("MOBILE_TEL").ToString()
                            Me.lbl_h_customer_name.Text = dt_person.Rows(i).Item("Name_EN").ToString()
                            Me.lbl_h_Last_Name.Text = dt_person.Rows(i).Item("SURName_EN").ToString()
                            Session("CUSTOMER_NAME") = Me.lbl_h_customer_name.Text + " " + lbl_h_Last_Name.Text
                            lblemail.Text = dt_person.Rows(i).Item("EMAIL_ADDRESS").ToString()
                            If lblemail.Text = "" Then
                                lblemail.Text = "-"
                            End If
                            bs_person_id = dt_person.Rows(i).Item("BS_PERSON_ID").ToString()
                            address = ""
                            lbl_address1.Text = ""
                            lbl_address2.Text = ""
                            lbl_address3.Text = ""
                            For j = 0 To dt_address.Rows.Count - 1
                                Dim PLACE_NUMBER As String = dt_address.Rows(j).Item("PLACE_NUMBER").ToString()
                                Dim PLACE_NAME As String = dt_address.Rows(j).Item("PLACE_NAME").ToString()
                                Dim ROOM_NUMBER As String = dt_address.Rows(j).Item("ROOM_NUMBER").ToString()
                                Dim MOO As String = dt_address.Rows(j).Item("MOO").ToString()
                                Dim ALLEY As String = dt_address.Rows(j).Item("ALLEY").ToString()
                                Dim ROAD As String = dt_address.Rows(j).Item("ROAD").ToString()
                                Dim DISTRICT As String = dt_address.Rows(j).Item("DISTRICT").ToString()
                                Dim AMPHUR As String = dt_address.Rows(j).Item("AMPHUR").ToString()
                                Dim PROVINCE As String = dt_address.Rows(j).Item("PROVINCE").ToString()
                                Dim ZIPCODE As String = dt_address.Rows(j).Item("ZIPCODE").ToString()
                                Dim COUNTRY As String = dt_address.Rows(j).Item("COUNTRY").ToString()

                                If i = 0 Then
                                    lblamphur1.Text = dt_address.Rows(j).Item("AMPHUR").ToString()
                                    lblprovince1.Text = dt_address.Rows(j).Item("PROVINCE").ToString()
                                    lblcountry1.Text = dt_address.Rows(j).Item("COUNTRY").ToString()
                                    lblzipcode1.Text = dt_address.Rows(j).Item("ZIPCODE").ToString()
                                End If
                                If i = 1 Then
                                    lblamphur2.Text = dt_address.Rows(j).Item("AMPHUR").ToString()
                                    lblprovince2.Text = dt_address.Rows(j).Item("PROVINCE").ToString()
                                    lblcountry2.Text = dt_address.Rows(j).Item("COUNTRY").ToString()
                                    lblzipcode2.Text = dt_address.Rows(j).Item("ZIPCODE").ToString()
                                End If
                                If i = 2 Then
                                    lblamphur3.Text = dt_address.Rows(j).Item("AMPHUR").ToString()
                                    lblprovince3.Text = dt_address.Rows(j).Item("PROVINCE").ToString()
                                    lblcountry3.Text = dt_address.Rows(j).Item("COUNTRY").ToString()
                                    lblzipcode3.Text = dt_address.Rows(j).Item("ZIPCODE").ToString()
                                End If

                                If PLACE_NUMBER = "-" Or PLACE_NUMBER = "" Then
                                    PLACE_NUMBER = ""
                                End If
                                If PLACE_NAME = "-" Or PLACE_NAME = "" Then
                                    PLACE_NAME = ""
                                End If
                                If ROOM_NUMBER = "-" Or ROOM_NUMBER = "" Then
                                    ROOM_NUMBER = ""
                                End If
                                If MOO = "-" Or MOO = "" Then
                                    MOO = ""
                                Else
                                    MOO = " MOO " + MOO
                                End If
                                If ALLEY = "-" Or ALLEY = "" Then
                                    ALLEY = ""
                                Else
                                    ALLEY = " SOI " + ALLEY
                                End If
                                If ROAD = "-" Or ROAD = "" Then
                                    ROAD = ""
                                Else
                                    ROAD = " ROAD " + ROAD
                                End If
                                If DISTRICT = "-" Or DISTRICT = "" Then
                                    DISTRICT = ""
                                Else
                                    DISTRICT = " SUB DISTRICT " + DISTRICT
                                End If
                                If AMPHUR = "-" Or AMPHUR = "" Then
                                    AMPHUR = ""
                                Else
                                    AMPHUR = " DISTRICT " + AMPHUR
                                End If
                                If PROVINCE = "-" Or PROVINCE = "" Then
                                    PROVINCE = ""
                                Else
                                    PROVINCE = " PROVINCE " + PROVINCE
                                End If
                                If ZIPCODE = "-" Or ZIPCODE = "-" Then
                                    ZIPCODE = ""
                                End If
                                If COUNTRY = "-" Or COUNTRY = "" Then
                                    COUNTRY = ""
                                End If


                                If bs_person_id = dt_address.Rows(j).Item("BS_PERSON_ID").ToString() Then
                                    If PROVINCE = "" And ZIPCODE = "" And COUNTRY = "" And DISTRICT = "" Then
                                        address = ""
                                    Else
                                        'address = dt_address.Rows(j).Item("PLACE_NUMBER").ToString() + " " + _
                                        '            dt_address.Rows(j).Item("PLACE_NAME").ToString() + " " + _
                                        '            dt_address.Rows(j).Item("ROOM_NUMBER").ToString() + " MOO " + _
                                        '            dt_address.Rows(j).Item("MOO").ToString() + " SOI " + _
                                        '            dt_address.Rows(j).Item("ALLEY").ToString() + " ROAD " + _
                                        '            dt_address.Rows(j).Item("ROAD").ToString() + " SUB DISTRICT " + _
                                        '            dt_address.Rows(j).Item("DISTRICT").ToString() + " DISTRICT " + _
                                        '            dt_address.Rows(j).Item("AMPHUR").ToString() + " PROVINCE " + _
                                        '            dt_address.Rows(j).Item("PROVINCE").ToString() + " " + _
                                        '            dt_address.Rows(j).Item("ZIPCODE").ToString() + " " + _
                                        '            dt_address.Rows(j).Item("COUNTRY").ToString()

                                        address = PLACE_NUMBER + " " + PLACE_NAME + " " + ROOM_NUMBER + MOO + ALLEY + ROAD + DISTRICT + AMPHUR + PROVINCE + ZIPCODE + COUNTRY

                                    End If
                                    If j = 0 Then
                                        If address.Trim <> "" Then
                                            lbl_address1.Text = address
                                        Else
                                            lbl_address1.Text = "NO ADDRESS"
                                        End If
                                    ElseIf j = 1 Then
                                        If address.Trim <> "" Then
                                            lbl_address2.Text = address
                                        Else
                                            lbl_address2.Text = "NO ADDRESS"
                                        End If
                                    ElseIf j = 2 Then
                                        If address.Trim <> "" Then
                                            lbl_address3.Text = address
                                        Else
                                            lbl_address3.Text = "NO ADDRESS"
                                        End If
                                    End If
                                End If
                            Next
                        End If
                    Next

                End If
            End If
        Catch ex As Exception
            ScriptManager.RegisterClientScriptBlock(Me.Page, Me.GetType, "Alert", _
            "alert('System Error!.,Please try again');", True)
            Exit Sub
        End Try
    End Sub
    
    Function findDiscountFlag(ByVal ISBN As String) As String
        Dim flag As String
        Dim sqlDB As SqlDb = New SqlDb
        flag = sqlDB.GetDataTable("SELECT discountflg FROM  tbm_asbkeo_bookab where ISBN_13 = '" + ISBN + "' ").Rows(0)(0).ToString
        Return flag
    End Function
    Private Sub in_branch_total()
        Dim gr As DataGridItem
        Dim amount_Inbranch As Double = 0
        Dim amount_Inbranch_usd As Double = 0
        Dim Total_Weight As Double = 0
        Dim amount_total As Double = 0
        Dim amount_total_usd As Double = 0
        Dim Int_LeadTime As Integer = 0
        Dim strLead_Time As Integer = 0
        Dim dt_LeadTime As New DataTable
        Dim strSql_Discount As String = ""
        Dim dt_Discount As New DataTable

        For Each gr In In_Branch.Items
            Dim lbl_ISBN_Inbranch As Label = gr.FindControl("lbl_ISBN_Inbranch")
            Dim lbl_Amount_Inbranch As Label = gr.FindControl("lbl_Amount_Inbranch")
            Dim lbl_discount_Inbranch As Label = gr.FindControl("lbl_discount_Inbranch")
            Dim lbl_Weight_Inbranch As Label = gr.FindControl("lbl_Weight_Inbranch")
            Dim lbl_Amount_in_branch_usd As Label = gr.FindControl("lbl_Amount_in_branch_usd")

            strSQL_ISBN &= " And CStr(c.Element(""isbn_13"")) <> """ + lbl_ISBN_Inbranch.Text + """"

            Dim discountFlag_Inbranch As String = findDiscountFlag(lbl_ISBN_Inbranch.Text)
            If discountFlag_Inbranch = "Y" Then 'ลดไม่ได้
                amount_Inbranch = CDbl(lbl_Amount_Inbranch.Text)
                strSql_Discount = ""
                strSql_Discount &= " select isbn_13,cast(convert(int,eCom_discount) as varchar) as discount"
                strSql_Discount &= " from tbm_asbkeo_bookab with (nolock)"
                strSql_Discount &= " where isbn_13 = '" + lbl_ISBN_Inbranch.Text + "'"

                uCon = New uConnect
                dt_Discount.Clear()
                dt_Discount = uFunction.getDataTable(uCon.conn, strSql_Discount)
                If dt_Discount.Rows.Count > 0 Then
                    lbl_discount_Inbranch.Text = dt_Discount.Rows(0).Item("discount").ToString
                Else
                    lbl_discount_Inbranch.Text = "0"
                End If

            Else
                If discount_customer = 10.0 Then
                    discount_customer = 5.0
                End If
                amount_Inbranch = CDbl(lbl_Amount_Inbranch.Text) - (CDbl(lbl_Amount_Inbranch.Text) * discount_customer / 100)

                strSql_Discount = ""
                strSql_Discount &= " select isbn_13,cast(convert(int,eCom_discount) as varchar) as discount"
                strSql_Discount &= " from tbm_asbkeo_bookab with (nolock)"
                strSql_Discount &= " where isbn_13 = '" + lbl_ISBN_Inbranch.Text + "'"

                uCon = New uConnect
                dt_Discount.Clear()
                dt_Discount = uFunction.getDataTable(uCon.conn, strSql_Discount)
                If dt_Discount.Rows.Count > 0 Then
                    If discount_customer = 5.0 Then
                        lbl_discount_Inbranch.Text = dt_Discount.Rows(0).Item("discount").ToString + "% + On Top " + discount_customer.ToString
                    Else
                        lbl_discount_Inbranch.Text = dt_Discount.Rows(0).Item("discount").ToString
                    End If

                Else
                    lbl_discount_Inbranch.Text = discount_customer
                End If

            End If

            amount_Inbranch_usd = bd.callUsd(amount_Inbranch) ' convert bath to USD

            ' input data in label
            lbl_Amount_Inbranch.Text = Convert.ToDouble(amount_Inbranch).ToString("#,###,##0.00")
            lbl_Amount_in_branch_usd.Text = "(US$ " + Convert.ToDouble(amount_Inbranch_usd).ToString("#,##0.00") + ")"

            Total_Weight += CDbl(lbl_Weight_Inbranch.Text)
            amount_total += amount_Inbranch
            amount_total_usd += amount_Inbranch_usd

            Dim strSql As String = ""

            strSql = ""
            strSql &= " select a.isbn_13,datediff(day,getdate(),dateadd(day,30,max([Expected Receipt Date])))"
            strSql &= " as eta from tbm_AB_eCom_Discount_Extra a inner join ETA b "
            strSql &= " on a.isbn_13 = b.itemno where a.isbn_13 ='" + lbl_ISBN_Inbranch.Text + "'   and a.[type]='CommingSoon' group by a.isbn_13"

            uCon = New uConnect
            dt_LeadTime.Clear()
            dt_LeadTime = uFunction.getDataTable(uCon.conn, strSql)
            If dt_LeadTime.Rows.Count > 0 Then
                strLead_Time = CInt(dt_LeadTime.Rows(0).Item("eta"))
            Else
                strLead_Time = 10
            End If

            If Int_LeadTime < strLead_Time Then
                Int_LeadTime = strLead_Time
            End If
        Next
        lbl_InBranch_Total_Weight.Text = Total_Weight.ToString("#,###,##0.00")
        lbl_InBranch_max_leadtime.Text = Int_LeadTime.ToString
        lbl_InBranch_total.Text = amount_total.ToString("#,###,##0.00")
        lbl_InBranch_total_usd.Text = "(US$ " + amount_total_usd.ToString("#,###,##0.00") + ")"
    End Sub

    Private Sub jobber_total()
        Dim gr As DataGridItem
        Dim amount_jobber As Double = 0
        Dim amount_jobber_usd As Double = 0
        Dim Total_Weight As Double = 0
        Dim max_leadtime As Integer = 0
        Dim max_leadtime_old As Integer = 0
        Dim amount_total As Double = 0
        Dim amount_total_usd As Double = 0


        For Each gr In jobber.Items
            Dim lbl_Amount_jobber As Label = gr.FindControl("lbl_Amount_jobber")
            Dim lbl_discount_jobber As Label = gr.FindControl("lbl_discount_jobber")
            Dim lbl_Weight_jobber As Label = gr.FindControl("lbl_Weight_jobber")
            Dim lbl_leadTime_Jobber As Label = gr.FindControl("lbl_leadTime_Jobber")
            Dim lbl_Amount_jobber_usd As Label = gr.FindControl("lbl_Amount_jobber_usd")
            Dim lbl_ISBN_jobber As Label = gr.FindControl("lbl_ISBN_jobber")

            strSQL_ISBN &= " And CStr(c.Element(""isbn_13"")) <> """ + lbl_ISBN_jobber.Text + """"

            ' Dim discountFlag_jobber As String = findDiscountFlag(lbl_ISBN_Inbranch.Text)
            'If discountFlag_jobber <> "NET" Then
            '    amount_jobber = CDbl(lbl_Amount_jobber.Text)
            '    lbl_discount_jobber.Text = "0"
            'Else
            '   amount_jobber = CDbl(lbl_Amount_jobber.Text) - (CDbl(lbl_Amount_jobber.Text) * discount_customer / 100)
            '   lbl_discount_jobber.Text = discount_customer
            'End If
            amount_jobber = CDbl(lbl_Amount_jobber.Text)
            lbl_discount_jobber.Text = "0"
            amount_jobber_usd = bd.callUsd(amount_jobber) ' convert bath to USD

            ' input data in label
            lbl_Amount_jobber.Text = Convert.ToDouble(amount_jobber).ToString("#,###,##0.00")
            lbl_Amount_jobber_usd.Text = "(US$ " + Convert.ToDouble(amount_jobber_usd).ToString("#,##0.00") + ")"

            'find Max leadtime
            If lbl_leadTime_Jobber.Text > max_leadtime_old Then
                max_leadtime = lbl_leadTime_Jobber.Text
            Else
                max_leadtime = max_leadtime_old
            End If
            max_leadtime_old = lbl_leadTime_Jobber.Text

            Total_Weight += CDbl(lbl_Weight_jobber.Text)
            amount_total += amount_jobber
            amount_total_usd += amount_jobber_usd
        Next
        lbl_jobber_Total_Weight.Text = Total_Weight.ToString("#,###,##0.00")
        lbl_jobber_max_leadtime.Text = max_leadtime
        lbl_jobber_total.Text = amount_total.ToString("#,###,##0.00")
        lbl_jobber_total_usd.Text = "(US$ " + amount_total_usd.ToString("#,###,##0.00") + ")"
    End Sub

    Private Sub ebook_total()
        Dim gr As DataGridItem
        Dim amount_ebook As Double = 0
        Dim amount_ebook_usd As Double = 0
        Dim amount_total As Double = 0
        Dim amount_total_usd As Double = 0

        If discount_customer <> 0.0 Then

            For Each gr In ebook.Items()
                Dim lbl_ISBN_ebook As Label = gr.FindControl("lbl_ISBN_ebook")
                Dim lbl_Amount_ebook As Label = gr.FindControl("lbl_Amount_ebook")
                Dim lbl_Amount_ebook_usd As Label = gr.FindControl("lbl_Amount_ebook_usd")
                Dim lbl_discount_ebook As Label = gr.FindControl("lbl_discount_ebook")


                If lbl_Amount_ebook.Text <> "0" Then
                    amount_ebook = CDbl(lbl_Amount_ebook.Text) - (CDbl(lbl_Amount_ebook.Text) * discount_customer / 100)
                    'amount_ebook_usd = bd.callUsd(amount_ebook) ' convert bath to USD

                    Dim strdiscount_ebook As String = ""
                    If lbl_discount_ebook.Text = "0" Then
                        strdiscount_ebook = "On Top 5"
                    Else
                        strdiscount_ebook = lbl_discount_ebook.Text & "% + On Top 5"
                    End If

                    lbl_discount_ebook.Text = strdiscount_ebook

                    lbl_Amount_ebook.Text = Convert.ToDouble(amount_ebook).ToString("#,###,##0.00")
                    'lbl_Amount_ebook_usd.Text = "(US$ " + Convert.ToDouble(amount_ebook_usd).ToString("#,##0.00") + ")"
                    Dim usd As String = bd.callUsd(amount_ebook).ToString
                    lbl_Amount_ebook_usd.Text = "(US$ " + IIf(usd = "", 0, usd).ToString + ")"

                    amount_total += amount_ebook
                    amount_total_usd += amount_ebook_usd
                End If

            Next

            Session("amount_ebook") = amount_total
            lbl_ebook_total.Text = amount_total.ToString("#,###,##0.00")
            lbl_ebook_total_usd.Text = "(US$ " + amount_total_usd.ToString("#,###,##0.00") + ")"

        Else

            For Each gr In ebook.Items()
                Dim lbl_ISBN_ebook As Label = gr.FindControl("lbl_ISBN_ebook")
                Dim lbl_Amount_ebook As Label = gr.FindControl("lbl_Amount_ebook")
                Dim lbl_Amount_ebook_usd As Label = gr.FindControl("lbl_Amount_ebook_usd")
                Dim lbl_discount_ebook As Label = gr.FindControl("lbl_discount_ebook")

                Dim usd As String = bd.callUsd(lbl_Amount_ebook.Text).ToString
                lbl_Amount_ebook_usd.Text = "(US$ " + IIf(usd = "", 0, usd).ToString + ")"

            Next
            If Session("amount_ebook") Is Nothing Then
            Else
                lbl_ebook_total.Text = CDbl(Session("amount_ebook")).ToString("#,##0.00")
                Try
                    lbl_ebook_total_usd.Text = "(US$ " + CDbl(bd.callUsd(Session("amount_ebook"))).ToString("#,##0.00") + ")"
                Catch ex As Exception
                    lbl_ebook_total_usd.Text = "(US$ 0)"
                End Try
            End If

        End If

        If Not Session("DISCOUNT") Is Nothing Then
            Dim discount As Integer = Session("DISCOUNT")
            If discount > 0 Then
                Me.lblpromo_discount.Text = Session("PROMOTION_NAME")
                Me.lbldiscount.Text = discount.ToString("#,##0.00")
                Me.P_ebook_promo.Visible = True
            Else
                Me.P_ebook_promo.Visible = False
            End If
        End If


        'uCon = New uConnect
        'Dim dt_Promo_Discount As New DataTable
        'dt_Promo_Discount = uFunction.getDataTable(uCon.conn, "select convert(decimal(8,0), discount) as discount from ebook_promotion WHERE status = 1 AND promotion = 1")
        'If dt_Promo_Discount.Rows.Count > 0 Then
        '    Dim discount As Double = 0.0
        '    discount = CDbl(Session("original_total")) - CDbl(Session("amount_ebook"))
        '    Me.lblpromo_discount.Text = "Promotion Discount (" + dt_Promo_Discount.Rows(0).Item("discount").ToString + "%)"
        '    Me.lbldiscount.Text = discount.ToString("#,##0.00")
        '    If discount > 0 Then
        '        promo_discount = CDbl(dt_Promo_Discount.Rows(0).Item("discount").ToString)
        '        promo_discount_amount = discount
        '        Me.P_ebook_promo.Visible = True
        '    Else
        '        Me.P_ebook_promo.Visible = False
        '    End If
        'Else
        '    Me.P_ebook_promo.Visible = False
        'End If

    End Sub

    Protected Sub b_change_book_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles b_change_book.Click
        'Dim dt_Session_ebook As DataTable = DirectCast(Session("ebook_shopping"), DataTable)

        'If Not dt_Session_ebook Is Nothing Then

        '    Try
        '        For Each dr As DataRow In dt_Session_ebook.Select("Selling_Price='0'")
        '            dr.Delete()
        '        Next
        '    Catch ex As Exception
        '    End Try

        'End If

        'Session("ebook_shopping") = dt_Session_ebook

        Response.Redirect("shoppingCart_Internet.aspx")
    End Sub

    Private Sub getTransport_Type()
        Dim strsql As String = ""

        If Session("client_nation") = "TH" Or Session("client_nation") = "ZZ" Then
            strsql = "SELECT distinct Transport_Type as code FROM  tbm_syst_deliverycharge where Transport_Type <> 'none' "
        Else
            strsql = "SELECT distinct Transport_Type as code FROM  tbm_syst_deliverycharge where Transport_Type <> 'none' and Transport_Type = 'AIRMAIL REGISTERED'"
        End If

        Dim sqlDB As SqlDb = New SqlDb
        Dim dt_temp1 As DataTable
        Dim item As New ListItem
        dt_temp1 = sqlDB.GetDataTable(strsql)
        cbo_Transport_Type.DataTextField = "code"
        cbo_Transport_Type.DataValueField = "code"
        cbo_Transport_Type.DataSource = dt_temp1
        cbo_Transport_Type.DataBind()
        item.Value = ""
        item.Text = " -- SELECT -- "
        tbx_Zone.Text = ""
        cbo_Transport_Type.Items.Insert(0, item)
    End Sub
    Private Sub getcountry()
        Dim sqlDB As SqlDb = New SqlDb
        Dim dt_temp1 As DataTable
        Dim item As New ListItem
        dt_temp1 = sqlDB.GetDataTable("select distinct country_code,country_name,a.zone_code from tbm_syst_deliverycharge a,tbm_syst_country b where(a.zone_code = b.zone_code) and transport_type ='" + cbo_Transport_Type.SelectedValue + "' order by Country_Name")
        cbo_county.DataTextField = "Country_Name"
        cbo_county.DataValueField = "Country_Code"
        cbo_county.DataSource = dt_temp1
        cbo_county.DataBind()
        item.Value = ""
        item.Text = " -- SELECT -- "
        tbx_Zone.Text = ""
        'cbo_Transport_Type.Items.Insert(0, item)
        'cbo_county.Items.Insert(0, item)
    End Sub
    Private Sub Check_Tramsport_Type()
        If cbo_Transport_Type.SelectedValue = "EMS" And CDbl(lbl_total_amount.Text) >= 700 Then
            lblEnjoy.Text = "Free delivery to be applied ONLY for purchasing at Bt. 700 up. (Feb 1, 2011 onwards)"
            mdlPopUp_Enjoy.Show()
            'ScriptManager.RegisterClientScriptBlock(Me.Page, Me.GetType, "Alert", "alert('Enjoy our Special promotion, Free delivery to your home address in Thailand.');", True)
        End If

        If cbo_Transport_Type.SelectedValue = "AIRMAIL REGISTERED" Then
            getcountry()
            cbo_organizeab.Visible = False
            cbo_county.Visible = True
            'uc_country.Visible = True
            lbl_Day.Text = "International address 10-15 days lead time of delivery"
            Transport_Type = cbo_Transport_Type.SelectedValue
            Country_Code = cbo_county.SelectedValue
            dt = ZoneChange()
            tbx_Zone.Text = dt.Rows(0).Item("Zone_Code").ToString

        ElseIf cbo_Transport_Type.SelectedValue = "EMS" Then
            getcountry()
            cbo_organizeab.Visible = False
            cbo_county.Visible = True
            'uc_country.Visible = True
            lbl_Day.Text = " Domestic 2-4 days lead time of delivery"
            Transport_Type = cbo_Transport_Type.SelectedValue
            Country_Code = cbo_county.SelectedValue
            dt = ZoneChange()
            tbx_Zone.Text = dt.Rows(0).Item("Zone_Code").ToString

        ElseIf cbo_Transport_Type.SelectedValue = "PICK UP AT BRANCH" Then
            cbo_organizeab.Visible = True
            cbo_county.Visible = False
            Show_Organizeab()
            'cbo_organizeab.Visible = True
            'uc_country.Visible = False
            lbl_Day.Text = ""
            lblEnjoy.Text = "We are now preparing  your order, we will contact you once it is ready to be pick up at branch you selected."
            lblEnjoy.Font.Bold = True
            mdlPopUp_Enjoy.Show()
        End If
        Calculator()
    End Sub
    Protected Sub cbo_Transport_Type_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cbo_Transport_Type.SelectedIndexChanged
        'uc_country.ShowData(cbo_Transport_Type.SelectedValue)
        Check_Tramsport_Type()
    End Sub
    Protected Sub uc_country_Change(ByVal sender As Object, ByVal e As System.EventArgs) Handles uc_country.Change
        If cbo_Transport_Type.SelectedValue <> "" _
        And (CDbl(checkNullTo0(lbl_InBranch_Total_Weight.Text)) + CDbl(checkNullTo0(lbl_jobber_Total_Weight.Text))) <> 0 _
        And uc_country.Value <> 0 Then
            Transport_Type = cbo_Transport_Type.SelectedValue
            Country_Code = uc_country.Value
            dt = ZoneChange()
            If dt.Rows.Count > 0 Then
                tbx_Zone.Text = dt.Rows(0).Item("Zone_Code").ToString
            End If
            'tbx_Zone.Text = dt.Rows(0).Item("Zone_Code").ToString
            Calculator()
        End If
    End Sub
    Private Sub Calculator()
        If cbo_Transport_Type.SelectedValue = "EMS" Then
            If Me.In_Branch.Items.Count <> 0 Then ' check delivery Inbranch
                Try
                    If CDbl(lbl_total_amount.Text) >= 700 Then
                        Me.lbl_InBranch_delivery_cost.Text = "0.00"
                        Me.lbl_jobber_delivery_cost_usd.Text = "(US$ 0.00)"
                    Else
                        Transport_Type = cbo_Transport_Type.SelectedValue
                        ZONE_code = tbx_Zone.Text
                        Total_Weight = CDbl(checkNullTo0(lbl_InBranch_Total_Weight.Text))
                        dt = Delivery()

                        If dt.Rows.Count <> 0 Then
                            Me.lbl_InBranch_delivery_cost.Text = Convert.ToDouble(Ceiling(dt.Rows(0).Item("delivery"))).ToString("#,###,##0.00")
                            Me.lbl_InBranch_delivery_cost_usd.Text = "(US$ " + bd.callUsd(lbl_InBranch_delivery_cost.Text) + ")"
                        Else
                            Me.lbl_InBranch_delivery_cost.Text = "0.00"
                            Me.lbl_jobber_delivery_cost_usd.Text = "(US$ 0.00)"
                        End If
                    End If

                Catch ex As Exception
                    Me.lbl_InBranch_delivery_cost.Text = "0.00"
                    Me.lbl_jobber_delivery_cost_usd.Text = "(US$ 0.00)"
                End Try
            End If

            If Me.jobber.Items.Count <> 0 Then  ' check delivery jobber
                Try
                    If CDbl(lbl_total_amount.Text) >= 700 Then
                        Me.lbl_jobber_delivery_cost.Text = "0.00"
                        Me.lbl_jobber_delivery_cost_usd.Text = "(US$ 0.00)"
                    Else
                        Transport_Type = cbo_Transport_Type.SelectedValue
                        ZONE_code = tbx_Zone.Text
                        Total_Weight = CDbl(checkNullTo0(lbl_jobber_Total_Weight.Text))
                        dt = Delivery()

                        If dt.Rows.Count <> 0 Then
                            Me.lbl_jobber_delivery_cost.Text = Convert.ToDouble(dt.Rows(0).Item("delivery")).ToString("#,###,##0.00")
                            Me.lbl_jobber_delivery_cost_usd.Text = "(US$ " + bd.callUsd(lbl_jobber_delivery_cost.Text) + ")"
                        Else
                            Me.lbl_jobber_delivery_cost.Text = "0.00"
                            Me.lbl_jobber_delivery_cost_usd.Text = "(US$ 0.00)"
                        End If
                    End If

                Catch ex As Exception
                    Me.lbl_jobber_delivery_cost.Text = "0.00"
                    Me.lbl_jobber_delivery_cost_usd.Text = "(US$ 0.00)"
                End Try
            End If
        Else
            If Me.In_Branch.Items.Count <> 0 Then ' check delivery Inbranch
                Try
                    Transport_Type = cbo_Transport_Type.SelectedValue
                    ZONE_code = tbx_Zone.Text
                    Total_Weight = CDbl(checkNullTo0(lbl_InBranch_Total_Weight.Text))
                    If Total_Weight > 30 Then
                        dt = Delivery_More()
                        If dt.Rows.Count <> 0 Then
                            Me.lbl_InBranch_delivery_cost.Text = Convert.ToDouble(Ceiling(dt.Rows(0).Item("delivery"))).ToString("#,###,##0.00")
                            Me.lbl_InBranch_delivery_cost_usd.Text = "(US$ " + bd.callUsd(lbl_InBranch_delivery_cost.Text) + ")"
                        Else
                            Me.lbl_InBranch_delivery_cost.Text = "0.00"
                            Me.lbl_jobber_delivery_cost_usd.Text = "(US$ 0.00)"
                        End If
                    Else
                        dt = Delivery()
                        If dt.Rows.Count <> 0 Then
                            Me.lbl_InBranch_delivery_cost.Text = Convert.ToDouble(Ceiling(dt.Rows(0).Item("delivery"))).ToString("#,###,##0.00")
                            Me.lbl_InBranch_delivery_cost_usd.Text = "(US$ " + bd.callUsd(lbl_InBranch_delivery_cost.Text) + ")"
                        Else
                            Me.lbl_InBranch_delivery_cost.Text = "0.00"
                            Me.lbl_jobber_delivery_cost_usd.Text = "(US$ 0.00)"
                        End If
                    End If

                Catch ex As Exception
                    Me.lbl_InBranch_delivery_cost.Text = "0.00"
                    Me.lbl_jobber_delivery_cost_usd.Text = "(US$ 0.00)"
                End Try
            End If

            If Me.jobber.Items.Count <> 0 Then  ' check delivery jobber
                Try
                    Transport_Type = cbo_Transport_Type.SelectedValue
                    ZONE_code = tbx_Zone.Text
                    Total_Weight = CDbl(checkNullTo0(lbl_jobber_Total_Weight.Text))
                    If Total_Weight > 30 Then
                        dt = Delivery_More()
                        If dt.Rows.Count <> 0 Then
                            Me.lbl_jobber_delivery_cost.Text = Convert.ToDouble(dt.Rows(0).Item("delivery")).ToString("#,###,##0.00")
                            Me.lbl_jobber_delivery_cost_usd.Text = "(US$ " + bd.callUsd(lbl_jobber_delivery_cost.Text) + ")"
                        Else
                            Me.lbl_jobber_delivery_cost.Text = "0.00"
                            Me.lbl_jobber_delivery_cost_usd.Text = "(US$ 0.00)"
                        End If
                    Else
                        dt = Delivery()
                        If dt.Rows.Count <> 0 Then
                            Me.lbl_jobber_delivery_cost.Text = Convert.ToDouble(dt.Rows(0).Item("delivery")).ToString("#,###,##0.00")
                            Me.lbl_jobber_delivery_cost_usd.Text = "(US$ " + bd.callUsd(lbl_jobber_delivery_cost.Text) + ")"
                        Else
                            Me.lbl_jobber_delivery_cost.Text = "0.00"
                            Me.lbl_jobber_delivery_cost_usd.Text = "(US$ 0.00)"
                        End If
                    End If

                Catch ex As Exception
                    Me.lbl_jobber_delivery_cost.Text = "0.00"
                    Me.lbl_jobber_delivery_cost_usd.Text = "(US$ 0.00)"
                End Try
            End If

        End If
        'If lbl_jobber_Total_Weight.Text <> "0.00" And lbl_InBranch_Total_Weight.Text <> "0.00" Then
        lbl_delivery_cost.Text = (CDbl(checkNullTo0(Me.lbl_InBranch_delivery_cost.Text)) + CDbl(checkNullTo0(Me.lbl_jobber_delivery_cost.Text))).ToString("#,###,##0.00")
        lbl_delivery_cost_usd.Text = "(US$ " + bd.callUsd(lbl_delivery_cost.Text) + ")"

        lbl_grand_total.Text = (CDbl(checkNullTo0(Me.lbl_delivery_cost.Text)) + CDbl(checkNullTo0(Me.lbl_total_amount.Text))).ToString("#,###,##0.00")
        lbl_grand_total_usd.Text = "(US$ " + bd.callUsd(lbl_grand_total.Text) + ")"


    End Sub
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
    Function checkNullTo0(ByVal data)
        If IsDBNull(data) Or data Is Nothing Or data = "" Then
            data = 0
        Else
            data = data
        End If
        Return Convert.ToDouble(data)
    End Function

    Private Sub getPayment()
        Dim sqlDB As SqlDb = New SqlDb
        Dim dt_temp1 As DataTable
        Dim item As New ListItem
        dt_temp1 = sqlDB.GetDataTable("select  distinct payment_method_name as name ,payment_method_code as code from  tbm_syst_Paymentmethod where Payment_method_Code <> 'MN001' ")
        rdobtnPayment.DataTextField = "name"
        rdobtnPayment.DataValueField = "code"
        rdobtnPayment.DataSource = dt_temp1
        rdobtnPayment.DataBind()

        'item.Value = ""
        'item.Text = " -- SELECT -- "
        'tbx_Zone.Text = ""
        'rdobtnPayment.Items.Insert(0, item)
        getPayment_type()
    End Sub
    Private Sub getPayment_type()
        Dim sqlDB As SqlDb = New SqlDb
        Dim dt_temp1 As DataTable
        Dim item As New ListItem

        dt_temp1 = sqlDB.GetDataTable("SELECT Payment_type as type FROM tbm_syst_Paymentmethod where Payment_method_Code = '" + rdobtnPayment.SelectedValue + "'")
        cbo_payment_type.DataTextField = "type"
        cbo_payment_type.DataValueField = "type"
        cbo_payment_type.DataSource = dt_temp1
        cbo_payment_type.DataBind()

    End Sub

    Protected Sub rad_address1_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles rad_address1.CheckedChanged
        checkAddressOther()
    End Sub
    Protected Sub rad_address2_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles rad_address2.CheckedChanged
        checkAddressOther()
    End Sub
    Protected Sub rad_address3_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles rad_address3.CheckedChanged
        checkAddressOther()
    End Sub
    Protected Sub rad_address4_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles rad_address4.CheckedChanged
        checkAddressOther()
    End Sub
    Private Sub checkAddressOther()
        If Me.rad_address4.Checked Then
            tbx_name.Enabled = True
            tbx_Address.Enabled = True
            tbx_amphur.Enabled = True
            tbx_province.Enabled = True
            tbx_country.Enabled = True
            tbx_zipcode.Enabled = True
            tbx_name.BackColor = Drawing.Color.White
            tbx_Address.BackColor = Drawing.Color.White
        Else
            tbx_name.Enabled = False
            tbx_Address.Enabled = False
            tbx_amphur.Enabled = False
            tbx_province.Enabled = False
            tbx_country.Enabled = False
            tbx_zipcode.Enabled = False
            tbx_name.BackColor = Drawing.Color.LightGray
            tbx_Address.BackColor = Drawing.Color.LightGray
        End If
    End Sub
    Private Sub checkBillAddressOther()
        If Me.rad_bill_sameAddress1.Checked Then
            tbx_name_bill.Enabled = True
            tbx_Address_bill.Enabled = True
            tbx_name_bill.BackColor = Drawing.Color.White
            tbx_Address_bill.BackColor = Drawing.Color.White
        Else
            tbx_name_bill.Enabled = False
            tbx_Address_bill.Enabled = False
            tbx_name_bill.BackColor = Drawing.Color.LightGray
            tbx_Address_bill.BackColor = Drawing.Color.LightGray
        End If
    End Sub
    Protected Sub rad_bill_sameAddress_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles rad_bill_sameAddress.CheckedChanged
        checkBillAddressOther()
    End Sub
    Protected Sub rad_bill_sameAddress1_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles rad_bill_sameAddress1.CheckedChanged
        checkBillAddressOther()
    End Sub
    Protected Sub chk_gift_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs)
        If Me.chk_gift.Checked Then
            tbx_name_gift_from.Enabled = True
            tbx_name_gift_to.Enabled = True
            tbx_message_gift.Enabled = True
            tbx_name_gift_from.BackColor = Drawing.Color.White
            tbx_name_gift_to.BackColor = Drawing.Color.White
            tbx_message_gift.BackColor = Drawing.Color.White
        Else
            tbx_name_gift_from.Enabled = False
            tbx_name_gift_to.Enabled = False
            tbx_message_gift.Enabled = False
            tbx_name_gift_from.BackColor = Drawing.Color.LightGray
            tbx_name_gift_to.BackColor = Drawing.Color.LightGray
            tbx_message_gift.BackColor = Drawing.Color.LightGray
        End If
    End Sub
    Private Sub Check_Address()


    End Sub

    Public Sub RemoveSession()
        b_confirm_order.Enabled = False
        b_confirm_order.ImageUrl = "~/images/bt-customer2.jpg"
        b_change_book.Enabled = False
        b_change_book.ImageUrl = "~/images/bt_chg_bk_ord2.jpg"
        b_export.Enabled = True
        'Panel1.Enabled = False
        Session.Remove("In_Branch")
        Session.Remove("Other_Branch")
        Session.Remove("jobber")
        Session.Remove("ebook_shopping")
        Session.Remove("ebook_promotion")
        Session.Remove("amount_Branch")
        Session.Remove("amount_other_Branch")
        Session.Remove("amount_Jobber")
        Session.Remove("member_code")
        Session.Remove("Order_No")
        Session.Remove("IP")
    End Sub
    Public Sub SendMail()
        'getOrder()

        'Sendmail_customer(StyleMail_Information, "You have got customer's special order reference no : " & Me.lbl_h_order_no.Text, mailinformation, "jirathep@promptnow.com")
        uClass.SendMail(mailinformation, "", "You have got customer's special order reference no : " & Me.lbl_h_order_no.Text, StyleMail_Information, "")

        If Me.cbo_Transport_Type.SelectedValue = "PICK UP AT BRANCH" Then
            'Sendmail_customer(StyleMail_Customer, "Your order with ASIA BOOKS CO., LTD. Ref. : " & Me.lbl_h_order_no.Text, lblemail.Text, mailinformation)
            uClass.SendMail(lblemail.Text, mailinformation, "Your order with ASIA BOOKS CO., LTD. Ref. : " & Me.lbl_h_order_no.Text, StyleMail_Customer, "")
        Else
            'Sendmail_customer(StyleMail_Customer_Home, "Your order with ASIA BOOKS CO., LTD. Ref. : " & Me.lbl_h_order_no.Text, lblemail.Text, mailinformation)
            uClass.SendMail(lblemail.Text, mailinformation, "Your order with ASIA BOOKS CO., LTD. Ref. : " & Me.lbl_h_order_no.Text, StyleMail_Customer_Home, "")
        End If

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

    Public Function SaveData() As Boolean
        Dim SqlDb As SqlDb = New SqlDb
        Dim SqlStr As String = ""
        Dim dt_CartNO As New DataTable
        Dim Keyword As String = ""

        Dim i As New Integer
        Dim YYMMDD As String = SqlDb.GetDataTable("select convert(varchar(30),getdate(),12)").Rows(0)(0).ToString
        Dim adddt As String = SqlDb.GetDataTable("select convert(varchar(30),getdate(),120)").Rows(0)(0).ToString
        Dim cartdate As String = SqlDb.GetDataTable("select convert(varchar(10),getdate(),120)").Rows(0)(0).ToString

        Dim sqlCommand As String
        Dim OrgCode_co As String
        Dim NO As Integer
        Dim straddorgab As String

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
                    SqlStr = SqlStr + "addemp,addpcnm,adddt,status)"
                    SqlStr = SqlStr + " values ('" + CartNo + "',"
                    SqlStr = SqlStr + "'" + dt_In_Branch.Rows(i).Item(0).ToString + "'"
                    SqlStr = SqlStr + ",'" + dt_In_Branch.Rows(i).Item(2).ToString + "'"
                    SqlStr = SqlStr + "," + CDbl(dt_In_Branch.Rows(i).Item(3).ToString).ToString + ""

                    ' leadtime internet = 5
                    If (ConfigurationSettings.AppSettings("UserInternet") = keyword_sales_channel) Then
                        Dim strSql As String = ""
                        Dim dt_LeadTime As New DataTable
                        strSql = ""
                        strSql &= " select a.isbn_13,datediff(day,getdate(),dateadd(day,30,max([Expected Receipt Date])))"
                        strSql &= " as eta from tbm_AB_eCom_Discount_Extra a inner join ETA b "
                        strSql &= " on a.isbn_13 = b.itemno where a.isbn_13 ='" + dt_In_Branch.Rows(i).Item(2).ToString + "'   and a.[type]='CommingSoon' group by a.isbn_13"

                        uCon = New uConnect
                        dt_LeadTime.Clear()
                        dt_LeadTime = uFunction.getDataTable(uCon.conn, strSql)
                        If dt_LeadTime.Rows.Count > 0 Then
                            SqlStr = SqlStr + ",'" + (dt_LeadTime.Rows(0).Item("eta")).ToString + "'"
                        Else
                            SqlStr = SqlStr + ",5"
                        End If

                    Else
                        SqlStr = SqlStr + "," + dt_In_Branch.Rows(i).Item(4).ToString + ""
                    End If
                    SqlStr = SqlStr + "," + CDbl(dt_In_Branch.Rows(i).Item(5).ToString).ToString + ""
                    SqlStr = SqlStr + "," + dt_In_Branch.Rows(i).Item(6).ToString + ""
                    SqlStr = SqlStr + "," + CDbl(dt_In_Branch.Rows(i).Item(7).ToString).ToString + ""
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
                    SqlStr = SqlStr + ",'" + dt_In_Branch.Rows(i).Item("status").ToString + "')"
                    'WriteError("Test Data", SqlStr, CartNo)
                    SqlDb.Exec(SqlStr)

                Next
            End If
            If Not (dt_Other_Branch Is Nothing) Then
                For i = 0 To dt_Other_Branch.Rows.Count - 1
                    SqlStr = ""
                    SqlStr = SqlStr + "insert into tbt_asbkeo_cartdetail(cartno,cartdtlno,ISBN,unitprice,"
                    SqlStr = SqlStr + "leadtime,weight,cartqty,Amount,Available_group_Id,Org_other_code,"
                    SqlStr = SqlStr + "ordstt,addemp,addpcnm,adddt,status)"
                    SqlStr = SqlStr + " values ('" + CartNo + "',"
                    SqlStr = SqlStr + "'" + dt_Other_Branch.Rows(i).Item(0).ToString + "'"
                    SqlStr = SqlStr + ",'" + dt_Other_Branch.Rows(i).Item(2).ToString + "'"
                    SqlStr = SqlStr + "," + dt_Other_Branch.Rows(i).Item(3).ToString + ""
                    SqlStr = SqlStr + "," + dt_Other_Branch.Rows(i).Item(4).ToString + ""
                    SqlStr = SqlStr + "," + dt_Other_Branch.Rows(i).Item(5).ToString + ""
                    SqlStr = SqlStr + "," + dt_Other_Branch.Rows(i).Item(6).ToString + ""
                    SqlStr = SqlStr + "," + dt_Other_Branch.Rows(i).Item(7).ToString + ""

                    Dim strSql As String = ""
                    Dim dt_LeadTime As New DataTable
                    strSql = ""
                    strSql &= " select a.isbn_13,datediff(day,getdate(),dateadd(day,30,max([Expected Receipt Date])))"
                    strSql &= " as eta from tbm_AB_eCom_Discount_Extra a inner join ETA b "
                    strSql &= " on a.isbn_13 = b.itemno where a.isbn_13 ='" + dt_Other_Branch.Rows(i).Item(2).ToString + "'  and a.[type]='CommingSoon' group by a.isbn_13"

                    uCon = New uConnect
                    dt_LeadTime.Clear()
                    dt_LeadTime = uFunction.getDataTable(uCon.conn, strSql)
                    If dt_LeadTime.Rows.Count > 0 Then
                        SqlStr = SqlStr + ",'" + (dt_LeadTime.Rows(0).Item("eta")).ToString + "'"
                    Else
                        SqlStr = SqlStr + ",'2'"
                    End If

                    SqlStr = SqlStr + ",'" + dt_Other_Branch.Rows(i).Item(9).ToString + "'"
                    SqlStr = SqlStr + ",'0'"
                    SqlStr = SqlStr + ",'" + Empcd + "'"
                    SqlStr = SqlStr + ",'" + Pcnm + "'"
                    SqlStr = SqlStr + ",'" + adddt + "'"
                    SqlStr = SqlStr + ",'" + dt_Other_Branch.Rows(i).Item("status").ToString + "')"
                    'WriteError("Test Data", SqlStr, CartNo)
                    SqlDb.Exec(SqlStr)

                Next
            End If
            If Not (dt_Jobber Is Nothing) Then
                For i = 0 To dt_Jobber.Rows.Count - 1
                    SqlStr = ""
                    SqlStr = SqlStr + "insert into tbt_asbkeo_cartdetail(cartno,cartdtlno,ISBN,unitprice,"
                    SqlStr = SqlStr + "leadtime,weight,cartqty,Amount,Available_group_Id,Org_other_code,"
                    SqlStr = SqlStr + "ordstt,addemp,addpcnm,adddt,status)"
                    SqlStr = SqlStr + " values ('" + CartNo + "',"
                    SqlStr = SqlStr + "'" + dt_Jobber.Rows(i).Item(0).ToString + "'"
                    SqlStr = SqlStr + ",'" + dt_Jobber.Rows(i).Item(2).ToString + "'"
                    SqlStr = SqlStr + "," + CDbl(dt_Jobber.Rows(i).Item(3).ToString).ToString + ""
                    SqlStr = SqlStr + "," + CDbl(dt_Jobber.Rows(i).Item(4).ToString).ToString + ""
                    SqlStr = SqlStr + "," + CDbl(dt_Jobber.Rows(i).Item(5).ToString).ToString + ""
                    SqlStr = SqlStr + "," + dt_Jobber.Rows(i).Item(6).ToString + ""
                    SqlStr = SqlStr + "," + CDbl(dt_Jobber.Rows(i).Item(7).ToString).ToString + ""
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
                    SqlStr = SqlStr + ",'" + dt_Jobber.Rows(i).Item("status").ToString + "')"
                    'WriteError("Test Data", SqlStr, CartNo)
                    SqlDb.Exec(SqlStr)
                Next
            End If
            If Not (dt_Ebook Is Nothing) Then
                For i = 0 To dt_Ebook.Rows.Count - 1
                    SqlStr = ""
                    SqlStr = SqlStr + "insert into tbt_asbkeo_cartdetail(cartno,cartdtlno,ISBN,unitprice,"
                    SqlStr = SqlStr + "cartqty,Amount,Available_group_Id,Org_other_code,ordstt,"
                    SqlStr = SqlStr + "addemp,addpcnm,adddt,status)"
                    SqlStr = SqlStr + " values ('" + CartNo + "',"
                    SqlStr = SqlStr + "'" + dt_Ebook.Rows(i).Item("No").ToString + "'"
                    SqlStr = SqlStr + ",'" + dt_Ebook.Rows(i).Item("ISBN_13").ToString + "'"
                    SqlStr = SqlStr + "," + CDbl(dt_Ebook.Rows(i).Item("Selling_Price").ToString).ToString + ""

                    ' leadtime internet = 5
                    'If (ConfigurationSettings.AppSettings("UserInternet") = keyword_sales_channel) Then
                    '    Dim strSql As String = ""
                    '    Dim dt_LeadTime As New DataTable
                    '    strSql = ""
                    '    strSql &= " select a.isbn_13,datediff(day,getdate(),dateadd(day,30,max([Expected Receipt Date])))"
                    '    strSql &= " as eta from tbm_AB_eCom_Discount_Extra a inner join ETA b "
                    '    strSql &= " on a.isbn_13 = b.itemno where a.isbn_13 ='" + dt_Ebook.Rows(i).Item(2).ToString + "'   and a.[type]='CommingSoon' group by a.isbn_13"

                    '    uCon = New uConnect
                    '    dt_LeadTime.Clear()
                    '    dt_LeadTime = uFunction.getDataTable(uCon.conn, strSql)
                    '    If dt_LeadTime.Rows.Count > 0 Then
                    '        SqlStr = SqlStr + ",'" + (dt_LeadTime.Rows(0).Item("eta")).ToString + "'"
                    '    Else
                    '        SqlStr = SqlStr + ",5"
                    '    End If

                    'Else
                    '    SqlStr = SqlStr + "," + dt_Ebook.Rows(i).Item(4).ToString + ""
                    'End If

                    SqlStr = SqlStr + "," + dt_Ebook.Rows(i).Item("Quantity").ToString + ""
                    SqlStr = SqlStr + "," + CDbl(dt_Ebook.Rows(i).Item("Items_Amount")).ToString() + ""
                    SqlStr = SqlStr + ",'4'"
                    SqlStr = SqlStr + ",'eBook'"
                    'SqlStr = SqlStr + ",'" + keyword_Branch + "'"
                    'SqlStr = SqlStr + "," + dt_Ebook.Rows(i).Item(6).ToString + ""
                    'SqlStr = SqlStr + ",'1'"


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
                    SqlStr = SqlStr + ",'EBOOK')"
                    'SqlStr = SqlStr + ",'" + dt_Ebook.Rows(i).Item("status").ToString + "')"
                    'WriteError("Test Data", SqlStr, CartNo)
                    SqlDb.Exec(SqlStr)

                Next
            End If

            DateNow = SqlDb.GetDataTable("SELECT CONVERT(VARCHAR(10),GETDATE(),120)").Rows(0)(0).ToString
            If CartNo <> "" Then
                OrgCode_cr = SqlDb.GetDataTable("SELECT Org_Ab_Code FROM tbt_asbkeo_cart WHERE CartNo='" + CartNo + "'").Rows(0)(0).ToString
            Else
                message = "Add  Unsuccessful, Cart No. is not valid"
            End If

            straddorgab = "SELECT TOP(1) right(order_no,5) as order_no"
            straddorgab &= " FROM tbt_asbkeo_cus_order "
            straddorgab &= " WHERE Address_Org_Ab='" + OrgCode_cr + "'"
            straddorgab &= " AND Order_Date='" + DateNow + "'"
            straddorgab &= " ORDER BY order_no DESC"
            dt.Clear()
            dt = SqlDb.GetDataTable(straddorgab)
            CartNo_Cus = Right(CartNo, 5)

            If CartNo_Cus <> "" Then
                OrgCode_co = CartNo_Cus
                NO = CartNo_Cus
                'NO = Convert.ToInt16(OrgCode_co) + 1
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


            'GenerateLog("CustOrdInt_SaveData", "", "", Order_No, "", "", "https://www.asiabooks.com", "", "Desired Order_No=" & Order_No)

            Dim Customer_Country As String = Session("client_nation")
            'Dim temp As New DataTable
            'temp = Session("client_nation")
            'Dim Customer_Country As String = temp.Rows(0).Item("shortcode").ToUpper.ToString()


            sqlCommand = ""
            sqlCommand = "INSERT INTO tbt_asbkeo_cus_order"
            sqlCommand &= "(Order_No,Order_Date,Member_Id,Customer_Name,Last_Name,Telephone,"
            sqlCommand &= "Total_Amount,Total_Weight,Max_Leadtime,Delivery_Cost,"
            sqlCommand &= "Delivery_Available,Delivery_special,Grand_Total,"
            sqlCommand &= "Deposit_Amount,Balance,Ship_to_name,Ship_to_address,Transport_Type,Zone,"
            sqlCommand &= "Country_Code,Billing_Name,Billing_Address,Gift_Flag,Gift_From,Gift_To,Gift_Message,"
            sqlCommand &= "Payment_Method_Code,Payment_Type,Sales_Channel_Code,Address_Org_Ab,"
            sqlCommand &= "Exchange_Rate,addempcd,addpcnm,adddt,field1,field2,field3,field4,Email,Customer_Country,Amphur,Province,ZipCode,Country,Promo_Discount,Promo_Discount_Amount)"
            sqlCommand &= " VALUES('" + Order_No + "',"
            sqlCommand &= " '" + DateNow + "',"
            sqlCommand &= " '" + Member_Id + "',"
            sqlCommand &= " '" + Customer_Name.ToString.Replace("'", "'+Char(39)+'") + "',"
            sqlCommand &= " '" + Last_Name.ToString.Replace("'", "'+Char(39)+'") + "',"
            sqlCommand &= " '" + telephone + "',"
            sqlCommand &= " " + CDbl(Total_Amount).ToString + ","
            sqlCommand &= " " + CDbl(Total_Weight).ToString + ","
            sqlCommand &= " " + CInt(IIf(Max_Leadtime = "", 0, Max_Leadtime)).ToString + ","
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
            sqlCommand &= " '" + Email.ToString.Replace("'", "'+Char(39)+'") + "',"
            sqlCommand &= " '" + Customer_Country + "',"
            sqlCommand &= " '" + strAumphur.ToString.Replace("'", "'+Char(39)+'") + "',"
            sqlCommand &= " '" + strProvince.ToString.Replace("'", "'+Char(39)+'") + "',"
            sqlCommand &= " '" + strZipCode.ToString + "',"
            sqlCommand &= " '" + strCountry.ToString.Replace("'", "'+Char(39)+'") + "',"
            sqlCommand &= " " & promo_discount & ","
            sqlCommand &= " " & promo_discount_amount & ")"

            'WriteError("", sqlCommand, "")
            SqlDb.Exec(sqlCommand)
            Dim dt_Branch_detail As New DataTable

            If Me.In_Branch.Items.Count > 0 Then
                Dim gr As DataGridItem
                For Each gr In In_Branch.Items
                    Dim lbl_ItemNo As Label = gr.FindControl("lbl_No_Inbranch")
                    Dim lbl_isbn As Label = gr.FindControl("lbl_ISBN_Inbranch")
                    Dim lbl_weight As Label = gr.FindControl("lbl_Weight_Inbranch")
                    Dim lbl_price As Label = gr.FindControl("lbl_Price_Inbranch")
                    Dim lbl_discount As Label = gr.FindControl("lbl_discount_Inbranch")
                    Dim lbl_qty As Label = gr.FindControl("lbl_quantity_Inbranch")
                    Dim lbl_amount As Label = gr.FindControl("lbl_Amount_Inbranch")
                    Dim lbl_Book_Title_Inbranch As Label = gr.FindControl("lbl_Book_Title_Inbranch")
                    Dim lbl_Status As Label = gr.FindControl("lbl_Status")

                    Orderdtl_No = lbl_ItemNo.Text
                    Cartdtlno = lbl_ItemNo.Text

                    ISBN = lbl_isbn.Text
                    Weight = lbl_weight.Text
                    Unitprice = CDbl(lbl_price.Text).ToString("#,###,##0.00")
                    discount = lbl_discount.Text
                    Orderqty = lbl_qty.Text
                    Amount = CDbl(lbl_amount.Text).ToString("#,###,##0.00")
                    Available_Group_Id = "1"
                    currency_code = "BAHT"
                    cover_price = 0
                    discount_report = 0
                    Jobber_Name = "AB AVAILABLE"
                    book_title_report = lbl_Book_Title_Inbranch.Text
                    exchange_rate_detail = 1
                    exchange_rate_internet = 1

                    dt_Branch_detail.Clear()
                    SqlStr = ""
                    SqlStr = SqlStr + "select * from tbt_jobber_stockab"
                    SqlStr = SqlStr + "	where isbn_13 = '" + lbl_isbn.Text + "' and Org_AB_code = 'HO-Internet' "
                    Dim on_order_qty As String = ""
                    Dim on_hand_qty As String = ""
                    dt_Branch_detail = SqlDb.GetDataTable(SqlStr)
                    If dt_Branch_detail.Rows.Count > 0 Then
                        on_hand_qty = dt_Branch_detail.Rows(0).Item("qty").ToString
                        on_order_qty = dt_Branch_detail.Rows(0).Item("on_order_qty").ToString
                    Else
                        on_hand_qty = 0
                        on_order_qty = 0
                    End If

                    'Start หา Item Discount Group
                    Dim strItem_Dis As String = ""
                    Dim dtItem_Dis As New DataTable
                    dtItem_Dis.Clear()
                    SqlStr = ""
                    SqlStr &= " select a.isbn_13, a.type ,b.author from tbm_AB_eCom_Discount_Extra a, tbm_asbkeo_bookab b "
                    SqlStr &= " where a.isbn_13 = b.isbn_13 and a.isbn_13 = '" + ISBN + "'"
                    dtItem_Dis = SqlDb.GetDataTable(SqlStr)
                    If dtItem_Dis.Rows.Count > 0 Then
                        strItem_Dis = dtItem_Dis.Rows(0).Item("type").ToString
                        Author = dtItem_Dis.Rows(0).Item("author").ToString
                    Else
                        dtItem_Dis.Clear()
                        SqlStr = ""
                        SqlStr &= " select isbn_13,isnull([Item Disc_ Group],'') as type,author from tbt_jobber_book_search where isbn_13 = '" + ISBN + "'"
                        dtItem_Dis = SqlDb.GetDataTable(SqlStr)
                        If dtItem_Dis.Rows.Count > 0 Then
                            Author = dtItem_Dis.Rows(0).Item("author").ToString
                            strItem_Dis = dtItem_Dis.Rows(0).Item("type").ToString
                        Else
                            Author = dtItem_Dis.Rows(0).Item("author").ToString
                            strItem_Dis = ""
                        End If
                    End If
                    'End หา Item Discount Group

                    'Start หา status ของ leadtime
                    Dim strSql As String = ""
                    Dim strStatus_LeadTime As String = ""
                    If Left(ISBN, 3) = "MAG" Then
                        Leadtime = "5"
                        strStatus_LeadTime = "First issue could be taken to 2-4 weeks after placing an order. The delivery is depended on your location and the magazine you have subscribed."
                    Else
                        Dim dt_LeadTime As New DataTable
                        strSql = ""
                        strSql &= " select a.isbn_13,datediff(day,getdate(),dateadd(day,30,max([Expected Receipt Date])))"
                        strSql &= " as eta from tbm_AB_eCom_Discount_Extra a inner join ETA b "
                        strSql &= " on a.isbn_13 = b.itemno where a.isbn_13 ='" + ISBN.ToString + "'  and a.[type]='CommingSoon' group by a.isbn_13"

                        uCon = New uConnect
                        dt_LeadTime.Clear()
                        dt_LeadTime = uFunction.getDataTable(uCon.conn, strSql)
                        If dt_LeadTime.Rows.Count > 0 Then
                            Leadtime = dt_LeadTime.Rows(0).Item("eta").ToString
                            strStatus_LeadTime = "On-order with publishers and will be available once the book is published and supplied."
                        Else
                            Leadtime = "5"
                            strStatus_LeadTime = "Available at Asia Books with 5 days of delivery lead time"
                        End If
                    End If
                    'End หา status ของ leadtime

                    Remark = ""
                    sqlCommand = ""
                    sqlCommand = "INSERT INTO tbt_asbkeo_cus_orderdtl"
                    sqlCommand &= "(Order_No,Orderdtl_No,Available_Group_Id,ISBN,"
                    sqlCommand &= "Weight,Leadtime,Unitprice,Discount,Orderqty,Amount,CartNo,Cartdtlno,"
                    sqlCommand &= "Order_Status,addempcd,addpcnm,jobber,adddt,currency_code,Cover_Price,"
                    sqlCommand &= "Discount_Report,Book_Title_Report,Exchange_Rate,payment,on_hand_qty,"
                    sqlCommand &= "on_order_qty,Exchange_Rate_Internet,Status,[Item Disc_ Group],Status_LeadTime,Remark,Author_Report)"
                    sqlCommand &= " VALUES('" + Order_No + "',"
                    sqlCommand &= " '" + Orderdtl_No + "',"
                    sqlCommand &= " '" + Available_Group_Id + "',"
                    sqlCommand &= " '" + ISBN + "',"
                    sqlCommand &= " " + CDbl(Weight).ToString + ","
                    sqlCommand &= " " + CInt(Leadtime).ToString + ","
                    sqlCommand &= " " + CDbl(Unitprice).ToString + ","
                    sqlCommand &= " '" + discount.ToString + "',"
                    sqlCommand &= " " + CDbl(Orderqty).ToString + ","
                    sqlCommand &= " " + CDbl(Amount).ToString + ","
                    sqlCommand &= " '" + CartNo + "',"
                    sqlCommand &= " '" + Cartdtlno + "',"
                    sqlCommand &= " '1',"
                    sqlCommand &= " '" + Empcd + "',"
                    sqlCommand &= " '" + Pcnm + "',"
                    sqlCommand &= " '" + Jobber_Name + "',"
                    sqlCommand &= " '" + SqlDb.GetDataTable("SELECT CONVERT(VARCHAR(30),GETDATE(),120)").Rows(0)(0).ToString + "',"
                    sqlCommand &= " '" + currency_code + "',"
                    sqlCommand &= " '" + CDbl(cover_price).ToString + "',"
                    sqlCommand &= " '" + CDbl(discount_report).ToString + "',"
                    sqlCommand &= " '" + lbl_Book_Title_Inbranch.Text.Replace("'", "'+Char(39)+'") + "',"
                    sqlCommand &= " '" + CDbl(exchange_rate_detail).ToString + "',"
                    sqlCommand &= " '--Select--',"
                    sqlCommand &= " " + CDbl(on_hand_qty).ToString + ","
                    sqlCommand &= " " + CDbl(on_order_qty).ToString + ","
                    sqlCommand &= " '" + CDbl(exchange_rate_internet).ToString + "',"
                    sqlCommand &= " '" + lbl_Status.Text + "',"
                    sqlCommand &= " '" + strItem_Dis + "',"
                    sqlCommand &= " '" + strStatus_LeadTime + "',"
                    sqlCommand &= " '" + Remark + "',"
                    sqlCommand &= " '" + Author.ToString.Replace("'", "'+Char(39)+'") + "')"

                    'WriteError("", sqlCommand, "")
                    SqlDb.Exec(sqlCommand)
                    If PaymentDesc.Length = 0 Then
                        PaymentDesc.Append("ISBN : " & lbl_isbn.Text.Trim)
                    ElseIf PaymentDesc.Length + lbl_isbn.Text.Trim.Length < 255 Then
                        PaymentDesc.Append(", " & lbl_isbn.Text.Trim)
                    End If

                Next
            End If

            Dim dt_jobber_detail As New DataTable

            If Me.jobber.Items.Count > 0 Then
                Dim gr As DataGridItem
                For Each gr In jobber.Items
                    Dim lbl_ItemNo As Label = gr.FindControl("lbl_No_jobber")
                    Dim lbl_isbn As Label = gr.FindControl("lbl_ISBN_jobber")
                    Dim lbl_weight As Label = gr.FindControl("lbl_Weight_jobber")
                    Dim lbl_price As Label = gr.FindControl("lbl_Price_jobber")
                    Dim lbl_discount As Label = gr.FindControl("lbl_discount_jobber")
                    Dim lbl_qty As Label = gr.FindControl("lbl_quantity_jobber")
                    Dim lbl_amount As Label = gr.FindControl("lbl_Amount_jobber")
                    Dim lbl_leadTime As Label = gr.FindControl("lbl_leadTime_Jobber")
                    Dim lbl_To_Org_AB_Code_jobber As Label = gr.FindControl("To_Org_AB_Code_jobber")
                    Dim lbl_Book_Title_jobber As Label = gr.FindControl("lbl_Book_Title_jobber")
                    Dim lbl_Status As Label = gr.FindControl("lbl_Status_Jobber")

                    Orderdtl_No = lbl_ItemNo.Text
                    Cartdtlno = lbl_ItemNo.Text

                    ISBN = lbl_isbn.Text
                    Weight = lbl_weight.Text
                    Leadtime = lbl_leadTime.Text
                    Unitprice = CDbl(lbl_price.Text).ToString("#,###,##0.00")
                    discount = lbl_discount.Text
                    Orderqty = lbl_qty.Text
                    Amount = CDbl(lbl_amount.Text).ToString("#,###,##0.00")
                    Available_Group_Id = "3"
                    dt_jobber_detail.Clear()
                    SqlStr = ""
                    SqlStr = SqlStr + "select a.isbn_13,a.book_title,b.currency_code,a.Cover_Price,a.Discount as Discount_Report,a.field1 as Exchange_Rate"
                    SqlStr = SqlStr + "	,c.on_hand_qty,c.on_order_qty"
                    SqlStr = SqlStr + "	from tbm_jobber_book_indent a,tbm_syst_organizeindent b"
                    SqlStr = SqlStr + "	,tbt_jobber_stockindent c"
                    SqlStr = SqlStr + "	where a.org_indent_code = b.org_indent_code"
                    SqlStr = SqlStr + "	and a.org_indent_code = c.org_indent_code"
                    SqlStr = SqlStr + "	and a.isbn_13 = c.isbn_13"
                    SqlStr = SqlStr + "	and a.isbn_13 = '" + lbl_isbn.Text + "'"
                    SqlStr = SqlStr + "	and a.org_indent_code = '" + lbl_To_Org_AB_Code_jobber.Text + "'"
                    Dim on_order_qty As String = ""
                    Dim on_hand_qty As String = ""
                    exchange_rate_detail = SqlDb.GetDataTable("select exchange_rate from dbo.tbm_syst_currency a, dbo.tbm_syst_organizeindent b where a.currency_code = b.currency_code and org_indent_code = '" + lbl_To_Org_AB_Code_jobber.Text + "'").Rows(0)(0).ToString
                    exchange_rate_internet = SqlDb.GetDataTable("select exchange_rate_internet from dbo.tbm_syst_currency a, dbo.tbm_syst_organizeindent b where a.currency_code = b.currency_code and org_indent_code = '" + lbl_To_Org_AB_Code_jobber.Text + "'").Rows(0)(0).ToString

                    dt_jobber_detail = SqlDb.GetDataTable(SqlStr)
                    If dt_jobber_detail.Rows.Count > 0 Then
                        currency_code = dt_jobber_detail.Rows(0).Item("currency_code").ToString
                        cover_price = dt_jobber_detail.Rows(0).Item("Cover_Price").ToString
                        discount_report = dt_jobber_detail.Rows(0).Item("Discount_Report").ToString
                        'exchange_rate_detail = dt_jobber_detail.Rows(0).Item("Exchange_Rate").ToString
                        Jobber_Name = lbl_To_Org_AB_Code_jobber.Text
                        on_hand_qty = dt_jobber_detail.Rows(0).Item("on_hand_qty").ToString
                        on_order_qty = dt_jobber_detail.Rows(0).Item("on_order_qty").ToString
                    Else
                        currency_code = "BAHT"
                        cover_price = 0
                        discount_report = 0
                        Jobber_Name = "AB AVAILABLE"
                        'exchange_rate_detail = 0
                        on_hand_qty = "0"
                        on_order_qty = "0"
                    End If

                    Remark = ""
                    book_title_report = lbl_Book_Title_jobber.Text
                    sqlCommand = "INSERT INTO tbt_asbkeo_cus_orderdtl"
                    sqlCommand &= "(Order_No,Orderdtl_No,Available_Group_Id,ISBN,"
                    sqlCommand &= "Weight,Leadtime,Unitprice,Discount,Orderqty,Amount,CartNo,Cartdtlno,"
                    sqlCommand &= "Order_Status,addempcd,addpcnm,jobber,adddt,currency_code,Cover_Price,"
                    sqlCommand &= "Discount_Report,Book_Title_Report,Exchange_Rate,payment,"
                    sqlCommand &= "on_hand_qty,on_order_qty,Exchange_Rate_Internet,Status,Status_LeadTime,Remark)"
                    sqlCommand &= " VALUES('" + Order_No + "',"
                    sqlCommand &= " '" + Orderdtl_No + "',"
                    sqlCommand &= " '" + Available_Group_Id + "',"
                    sqlCommand &= " '" + ISBN + "',"
                    sqlCommand &= " " + CDbl(Weight).ToString + ","
                    sqlCommand &= " " + CInt(Leadtime).ToString + ","
                    sqlCommand &= " " + CDbl(Unitprice).ToString + ","
                    sqlCommand &= " '" + discount.ToString + "',"
                    sqlCommand &= " " + CDbl(Orderqty).ToString + ","
                    sqlCommand &= " " + CDbl(Amount).ToString + ","
                    sqlCommand &= " '" + CartNo + "',"
                    sqlCommand &= " '" + Cartdtlno + "',"
                    sqlCommand &= " '1',"
                    sqlCommand &= " '" + Empcd + "',"
                    sqlCommand &= " '" + Pcnm + "',"
                    sqlCommand &= " '" + Jobber_Name + "',"
                    sqlCommand &= " '" + SqlDb.GetDataTable("SELECT CONVERT(VARCHAR(30),GETDATE(),120)").Rows(0)(0).ToString + "',"
                    sqlCommand &= " '" + currency_code + "',"
                    sqlCommand &= " '" + CDbl(cover_price).ToString + "',"
                    sqlCommand &= " '" + CDbl(discount_report).ToString + "',"
                    sqlCommand &= " '" + lbl_Book_Title_jobber.Text.Replace("'", "'+Char(39)+'") + "',"
                    sqlCommand &= " '" + CDbl(exchange_rate_detail).ToString + "',"
                    sqlCommand &= " '--Select--',"
                    sqlCommand &= " " + CDbl(on_hand_qty).ToString + ","
                    sqlCommand &= " " + CDbl(on_order_qty).ToString + ","
                    sqlCommand &= " " + CDbl(exchange_rate_internet).ToString + ","
                    sqlCommand &= " '" + lbl_Status.Text + "',"
                    sqlCommand &= " 'Not available at Asia Books but will be placed speical order with Publishers with 25-45 Days lead time of delivery',"
                    sqlCommand &= " '" + Remark + "')"

                    'WriteError("", sqlCommand, "")
                    SqlDb.Exec(sqlCommand)

                    If PaymentDesc.Length = 0 Then
                        PaymentDesc.Append("ISBN : " & lbl_isbn.Text.Trim)
                    ElseIf PaymentDesc.Length + lbl_isbn.Text.Trim.Length < 255 Then
                        PaymentDesc.Append(", " & lbl_isbn.Text.Trim)
                    End If

                Next
            End If

            Dim dt_ebook_detail As New DataTable

            If Me.ebook.Items.Count > 0 Then
                Dim gr As DataGridItem
                For Each gr In ebook.Items
                    Dim lbl_ItemNo As Label = gr.FindControl("lbl_No_ebook")
                    Dim lbl_BookID As Label = gr.FindControl("lbl_Book_ID")
                    Dim lbl_isbn As Label = gr.FindControl("lbl_ISBN_ebook")
                    'Dim lbl_weight As Label = gr.FindControl("lbl_Weight_ebook")
                    Dim lbl_price As Label = gr.FindControl("lbl_Price_ebook")
                    'Dim lbl_discount As Label = gr.FindControl("lbl_discount_ebook")
                    Dim lbl_qty As Label = gr.FindControl("lbl_quantity_ebook")
                    Dim lbl_amount As Label = gr.FindControl("lbl_Amount_ebook")
                    'Dim lbl_leadTime As Label = gr.FindControl("lbl_leadTime_ebook")
                    'Dim lbl_To_Org_AB_Code_ebook As Label = gr.FindControl("To_Org_AB_Code_ebook")
                    Dim lbl_Book_Title_ebook As Label = gr.FindControl("lbl_Book_Title_ebook")
                    'Dim lbl_Status As Label = gr.FindControl("lbl_Status_ebook")
                    Dim lbl_Exchange As Label = gr.FindControl("lbl_Exchange")
                    Dim lbl_Exchange_Internet As Label = gr.FindControl("lbl_Exchange_Internet")

                    Orderdtl_No = lbl_ItemNo.Text
                    Cartdtlno = lbl_ItemNo.Text

                    ISBN = lbl_isbn.Text
                    Weight = "0"
                    Leadtime = "0"
                    Unitprice = CDbl(lbl_price.Text).ToString("#,###,##0.00")
                    'discount = lbl_discount.Text
                    discount = "0"
                    Orderqty = lbl_qty.Text
                    Amount = CDbl(lbl_amount.Text).ToString("#,###,##0.00")
                    Available_Group_Id = "4"
                    dt_ebook_detail.Clear()
                    'SqlStr = ""
                    'SqlStr = SqlStr + "select a.isbn_13,a.book_title,b.currency_code,a.Cover_Price,a.Discount as Discount_Report,a.field1 as Exchange_Rate"
                    'SqlStr = SqlStr + "	,c.on_hand_qty,c.on_order_qty"
                    'SqlStr = SqlStr + "	from tbm_jobber_book_indent a,tbm_syst_organizeindent b"
                    'SqlStr = SqlStr + "	,tbt_jobber_stockindent c"
                    'SqlStr = SqlStr + "	where a.org_indent_code = b.org_indent_code"
                    'SqlStr = SqlStr + "	and a.org_indent_code = c.org_indent_code"
                    'SqlStr = SqlStr + "	and a.isbn_13 = c.isbn_13"
                    'SqlStr = SqlStr + "	and a.isbn_13 = '" + lbl_isbn.Text + "'"
                    'SqlStr = SqlStr + "	and a.org_indent_code = '" + lbl_To_Org_AB_Code_ebook.Text + "'"
                    Dim on_order_qty As String = "0"
                    Dim on_hand_qty As String = "0"
                    'exchange_rate_detail = SqlDb.GetDataTable("select exchange_rate from dbo.tbm_syst_currency a, dbo.tbm_syst_organizeindent b where a.currency_code = b.currency_code and org_indent_code = '" + lbl_To_Org_AB_Code_ebook.Text + "'").Rows(0)(0).ToString
                    'exchange_rate_internet = SqlDb.GetDataTable("select exchange_rate_internet from dbo.tbm_syst_currency a, dbo.tbm_syst_organizeindent b where a.currency_code = b.currency_code and org_indent_code = '" + lbl_To_Org_AB_Code_ebook.Text + "'").Rows(0)(0).ToString

                    exchange_rate_detail = 1
                    exchange_rate_internet = 1

                    'dt_ebook_detail = SqlDb.GetDataTable(SqlStr)
                    'If dt_ebook_detail.Rows.Count > 0 Then
                    '    currency_code = dt_ebook_detail.Rows(0).Item("currency_code").ToString
                    '    cover_price = dt_ebook_detail.Rows(0).Item("Cover_Price").ToString
                    '    discount_report = dt_ebook_detail.Rows(0).Item("Discount_Report").ToString
                    '    'exchange_rate_detail = dt_ebook_detail.Rows(0).Item("Exchange_Rate").ToString
                    '    Jobber_Name = lbl_To_Org_AB_Code_ebook.Text
                    '    on_hand_qty = dt_ebook_detail.Rows(0).Item("on_hand_qty").ToString
                    '    on_order_qty = dt_ebook_detail.Rows(0).Item("on_order_qty").ToString
                    'Else
                    '    currency_code = "BAHT"
                    '    cover_price = 0
                    '    discount_report = 0
                    '    Jobber_Name = "AB AVAILABLE"
                    '    'exchange_rate_detail = 0
                    '    on_hand_qty = "0"
                    '    on_order_qty = "0"
                    'End If

                    'lbl_Status.Text = "EBOOK"
                    currency_code = "BAHT"
                    cover_price = 0
                    discount_report = 0
                    Jobber_Name = "EBOOK"
                    on_hand_qty = "0"
                    on_order_qty = "0"


                    book_title_report = lbl_Book_Title_ebook.Text
                    sqlCommand = "INSERT INTO tbt_asbkeo_cus_orderdtl"
                    sqlCommand &= "(Order_No,Orderdtl_No,Available_Group_Id,ISBN,"
                    sqlCommand &= "Weight,Leadtime,Unitprice,Discount,Orderqty,Amount,CartNo,Cartdtlno,"
                    sqlCommand &= "Order_Status,addempcd,addpcnm,jobber,adddt,currency_code,Cover_Price,"
                    sqlCommand &= "Discount_Report,Book_Title_Report,Exchange_Rate,payment,"
                    sqlCommand &= "on_hand_qty,on_order_qty,Exchange_Rate_Internet,Status,Status_LeadTime,EBookID,[Item Disc_ Group])"
                    sqlCommand &= " VALUES('" + Order_No + "',"
                    sqlCommand &= " '" + Orderdtl_No + "',"
                    sqlCommand &= " '" + Available_Group_Id + "',"
                    sqlCommand &= " '" + ISBN + "',"
                    sqlCommand &= " " + CDbl(Weight).ToString + ","
                    sqlCommand &= " " + CInt(Leadtime).ToString + ","
                    sqlCommand &= " " + CDbl(Unitprice).ToString + ","
                    sqlCommand &= " '" + discount.ToString + "',"
                    sqlCommand &= " " + CDbl(Orderqty).ToString + ","
                    sqlCommand &= " " + CDbl(Amount).ToString + ","
                    sqlCommand &= " '" + CartNo + "',"
                    sqlCommand &= " '" + Cartdtlno + "',"
                    sqlCommand &= " '1',"
                    sqlCommand &= " '" + Empcd + "',"
                    sqlCommand &= " '" + Pcnm + "',"
                    sqlCommand &= " '" + Jobber_Name + "',"
                    sqlCommand &= " '" + SqlDb.GetDataTable("SELECT CONVERT(VARCHAR(30),GETDATE(),120)").Rows(0)(0).ToString + "',"
                    sqlCommand &= " '" + currency_code + "',"
                    sqlCommand &= " '" + CDbl(cover_price).ToString + "',"
                    sqlCommand &= " '" + CDbl(discount_report).ToString + "',"
                    sqlCommand &= " '" + lbl_Book_Title_ebook.Text.Replace("'", "'+Char(39)+'") + "',"
                    sqlCommand &= " '" + CDbl(lbl_Exchange.Text).ToString + "',"
                    sqlCommand &= " '--Select--',"
                    sqlCommand &= " " + CDbl(on_hand_qty).ToString + ","
                    sqlCommand &= " " + CDbl(on_order_qty).ToString + ","
                    sqlCommand &= " " + CDbl(lbl_Exchange_Internet.Text).ToString + ","
                    sqlCommand &= " 'EBOOK',"
                    sqlCommand &= " '',"
                    sqlCommand &= " '" + lbl_BookID.Text + "',"
                    If Amount.ToString = "0.00" Then
                        sqlCommand &= " 'Free eBook')"
                    Else
                        sqlCommand &= " 'eBook')"
                    End If


                    'WriteError("", sqlCommand, "")
                    SqlDb.Exec(sqlCommand)

                    If PaymentDesc.Length = 0 Then
                        PaymentDesc.Append("ISBN : " & lbl_isbn.Text.Trim)
                    ElseIf PaymentDesc.Length + lbl_isbn.Text.Trim.Length < 255 Then
                        PaymentDesc.Append(", " & lbl_isbn.Text.Trim)
                    End If

                Next
            End If

            Me.lbl_h_order_no.Text = Order_No
            Session("Order_No") = Me.lbl_h_order_no.Text

            SqlDb.CommitTrans()
            message = "Add  Successful"
            Return True
        Catch ex As Exception
            SqlDb.RollbackTrans()
            message = "Error:Data is not Insert" + ex.Message
            GenerateLog("SaveData", "", "", Order_No, "", "", "https://www.asiabooks.com", "", ex.Message & " - " & ex.GetBaseException.ToString)

            Return False
            'SqlDb.BeginTrans()
            'Dim strlog As String
            'strlog = "insert into tbm_syst_log (Service,logdt,logjobber,logfile,logmessage,"
            'strlog &= "addempcd,addpcnm,adddt,field10) "
            'strlog &= "values('Proceed','" + cartdate + "','','shopping_cart.aspx','" + ex.Message.ToString.Replace("'", "") + "',"
            'strlog &= "'" + Empcd + "','" + Pcnm + "','" + adddt + "','" + CartNo + "')"
            'SqlDb.Exec(strlog)
            'SqlDb.CommitTrans()
        End Try
    End Function
    Protected Sub b_export_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles b_export.Click
        Session("Order_No") = Me.lbl_h_order_no.Text
        'ScriptManager.RegisterClientScriptBlock(Me.Page, Me.GetType, "Alert", "window.open('Customer_Order_Tracking_Internet_export.aspx');", True)

    End Sub

    Protected Sub b_edit_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles b_edit.Click
        Response.Redirect("Customer_Profile_Edit.aspx?action=Edit&Page_Order=Customer_Order&MEMBER_CODE=" + member_code.ToString())
    End Sub

    Protected Sub cbo_organizeab_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs)
        Dim sqlDB As SqlDb = New SqlDb
        Dim dt As DataTable
        dt = sqlDB.GetDataTable("select * from tbm_syst_organizeab where Org_AB_Code = '" + cbo_organizeab.SelectedValue + "'")
        strPickUpCode = dt.Rows(0).Item("Org_AB_Code").ToString
        strPickUpName = dt.Rows(0).Item("Org_AB_Name").ToString
        strPickUpAddress = dt.Rows(0).Item("field2").ToString
        strPickUpEmail = dt.Rows(0).Item("field4").ToString
    End Sub
    Private Sub getOrder()
        Dim sqlDB As SqlDb = New SqlDb
        dtOrder = sqlDB.GetDataTable(Get_Order)
    End Sub
    Public Function Sendmail_customer(ByVal strhtml As String, ByVal subject As String, ByVal mailto As String, ByVal mailcc As String) As Boolean
        Dim status As Boolean = True
        Try
            uCon = New uConnect

            Dim mailMessage As System.Web.Mail.MailMessage = New System.Web.Mail.MailMessage
            mailMessage.From = MailFrom
            mailMessage.To = mailto
            mailMessage.Cc = mailcc
            mailMessage.Subject = subject
            mailMessage.BodyFormat = System.Web.Mail.MailFormat.Html
            mailMessage.Body = strhtml
            System.Web.Mail.SmtpMail.SmtpServer = SmtpMail

            If Me.UserName <> "" Or Me.UserPassword <> "" Then
                mailMessage.Fields.Add("http://schemas.microsoft.com/cdo/configuration/smtpauthenticate", "1")
                mailMessage.Fields.Add("http://schemas.microsoft.com/cdo/configuration/sendusername", UserName)
                mailMessage.Fields.Add("http://schemas.microsoft.com/cdo/configuration/sendpassword", UserPassword)
            End If
            System.Web.Mail.SmtpMail.Send(mailMessage)

            'uFunction.ExecuteDataStringNonTran(uCon.conn, clsLog_SendMail.InsertLog_SendMail("Send mail confirm order ", mailto, "Y", "", lbl_h_customer_name.Text + " " + lbl_h_Last_Name.Text, lbl_h_order_no.Text))

            status = True
        Catch ex As Exception
            uFunction.ExecuteDataStringNonTran(uCon.conn, clsLog_SendMail.InsertLog_SendMail("Send mail confirm order ", mailto, "N", ex.ToString, lbl_h_customer_name.Text + " " + lbl_h_Last_Name.Text, lbl_h_order_no.Text))

            status = False
        End Try
        Return status
    End Function
    Private Function Get_Order() As String
        Dim _sql As New StringBuilder
        _sql.Append("select distinct a.isbn, b.isbn_13, a.EBookID, isnull(b.book_title, e.book_title) as book_title, isnull(b.Author, e.Author) as Author, a.order_no, convert(decimal(20,2),a.Amount) as Amount, a.orderqty, c.customer_name, c.last_name, ")
        '_sql.Append("case a.leadtime when '5' then 'Available at Asia Books with  5 days of  delivery lead time' else 'Not available at Asia Books but will be placed speical order with Publishers with 25-45 Days lead time of delivery' end as leadtime,")
        _sql.Append("Status_LeadTime as leadtime,")
        _sql.Append("f.Payment_method_Name as payment ")
        _sql.Append(",c.telephone,c.transport_type, c.field2 as branch ,c.ship_to_address , convert(nvarchar,c.adddt,100) as order_date,c.field4 as mailbranch ")
        _sql.Append(",c.delivery_cost,c.grand_total,c.transport_type  ")
        _sql.Append(",convert(decimal(8,0),c.Promo_Discount) as Promo_Discount, convert(decimal(20,2),c.Promo_Discount_Amount) as Promo_Discount_Amount ")
        _sql.Append("from tbt_asbkeo_cus_orderdtl a left join dbo.tbt_jobber_book_search b on a.isbn = b.isbn_13 ")
        _sql.Append("left join dbo.ebook_store e on a.ebookid = e.bookid ")
        _sql.Append("inner join tbt_asbkeo_cus_order c on a.order_no = c.order_no ")
        _sql.Append("inner join tbm_syst_Paymentmethod f on c.Payment_Method_Code = f.Payment_Method_Code ")
        _sql.Append("where a.order_no = '" + Me.Session("Order_No") + "' ")
        '_sql.Append("order by a.Available_Group_Id,a.orderdtl_no ")
        Return _sql.ToString
    End Function

    Private Function StyleMail_Information() As String
        getOrder()
        'Me.Session("Order_No")

        Dim _mail As New StringBuilder
        If dtOrder.Rows.Count > 0 Then
            Dim customername As String = Replace(dtOrder.Rows(0).Item("customer_name").ToString, "[MEMBER]", " ") + "  " + dtOrder.Rows(0).Item("last_name").ToString
            _mail.Append(" <table border='0' cellpadding='0' width='100%' style='font-size: 10pt; font-family: Arial'><tr>")
            _mail.Append(" <td>Customer’s details : <strong>").Append(customername).Append("</strong></td></tr><tr>")
            _mail.Append(" <td>Order Reference : <strong>").Append(dtOrder.Rows(0).Item("order_no").ToString).Append("</strong></td></tr><tr>")
            _mail.Append(" <td>PAID BY : <strong>").Append(dtOrder.Rows(0).Item("payment").ToString).Append("</strong></td></tr><tr><td>&nbsp;</td></tr><tr>")
            _mail.Append(" <td><table width='80%' bordercolor='#666666' border='1' cellpadding='0' cellspacing='0' style='font-size: 9pt; font-family: Arial'><tr>")
            _mail.Append(" <td style='font-weight: bold; color: white; background-color: #339933; width: 10%; text-align: center;'>EAN/ISBN</td>")
            _mail.Append(" <td style='font-weight: bold; color: white; background-color: #339933; width: 25%; text-align: center;'>Title</td>")
            _mail.Append(" <td style='font-weight: bold; color: white; background-color: #339933; width: 10%; text-align: center;'>Author</td>")
            _mail.Append(" <td style='font-weight: bold; color: white; background-color: #339933; width: 10%; text-align: center;'>Ref</td>")
            _mail.Append(" <td style='font-weight: bold; color: white; background-color: #339933; width: 6%; text-align: center;'>Price</td>")
            _mail.Append(" <td style='font-weight: bold; color: white; background-color: #339933; width: 4%; text-align: center;'>Qty</td>")
            _mail.Append(" <td style='font-weight: bold; color: white; height: 18px; background-color: #339933; text-align: center;'>Remark</td></tr>")
            For i As Integer = 0 To dtOrder.Rows.Count - 1
                _mail.Append(" <tr><td style='width: 10%' align='center'>").Append(dtOrder.Rows(i).Item("isbn").ToString).Append("</td>")
                _mail.Append(" <td style='width: 25%' align='left'>&nbsp;").Append(dtOrder.Rows(i).Item("book_title").ToString).Append("</td>")
                _mail.Append(" <td style='width: 10%' align='left'>&nbsp;").Append(dtOrder.Rows(i).Item("Author").ToString).Append("</td>")
                _mail.Append(" <td style='width: 10%' align='center'>").Append(dtOrder.Rows(i).Item("order_no").ToString).Append("</td>")
                _mail.Append(" <td align='center' style='width: 6%'>").Append(CDbl(dtOrder.Rows(i).Item("Amount").ToString).ToString("#,###,##0.00")).Append("</td>")
                _mail.Append(" <td style='width: 4%' align='center'>").Append(dtOrder.Rows(i).Item("orderqty").ToString).Append("</td>")

                If dtOrder.Rows(i).Item("EBookID").ToString <> "" Then
                    _mail.Append("<td style='width: 5%' align='left'>(eBook)</td></tr>")
                Else
                    _mail.Append(" <td style='width: 5%' align='left'>").Append(dtOrder.Rows(i).Item("leadtime").ToString).Append("</td></tr>")
                End If


            Next
            _mail.Append(" <tr><td align='center' style='width: 10%'>&nbsp;</td>")
            _mail.Append(" <td align='left' style='width: 25%'>&nbsp;</td>")
            _mail.Append(" <td align='left' style='width: 10%'>&nbsp;</td>")
            _mail.Append(" <td align='center' style='width: 10%'>&nbsp;</td>")
            _mail.Append(" <td align='center' style='width: 6%'>&nbsp;</td>")
            _mail.Append(" <td align='center' style='width: 4%'>&nbsp;</td>")
            _mail.Append(" <td align='center' style='width: 5%'>&nbsp;</td></tr>")
            _mail.Append(" <tr><td align='center' style='width: 10%'></td>")
            _mail.Append(" <td align='left' style='width: 25%'></td>")
            _mail.Append(" <td align='left' style='width: 10%'></td>")
            _mail.Append(" <td align='center' style='width: 10%'></td>")
            _mail.Append(" <td align='center' style='width: 6%'></td>")
            _mail.Append(" <td align='center' style='width: 4%'></td>")
            _mail.Append(" <td align='center' style='width: 5%'></td></tr>")
            _mail.Append(" <tr><td align='center' colspan='4' style='font-weight: bold; text-align: right'>Delivery Cost&nbsp;</td>")
            _mail.Append(" <td align='center' style='width: 6%'>").Append(dtOrder.Rows(0).Item("delivery_cost").ToString).Append("</td>")
            _mail.Append(" <td align='center' style='width: 4%'>&nbsp;BAHT</td>")
            _mail.Append(" <td align='center' style='width: 5%'></td></tr>")

            If Not dtOrder.Rows(0).Item("Promo_Discount_Amount") Is Nothing And dtOrder.Rows(0).Item("Promo_Discount_Amount").ToString <> "" Then
                If CDbl(dtOrder.Rows(0).Item("Promo_Discount_Amount").ToString) > 0 Then
                    _mail.Append(" <tr><td align='center' colspan='4' style='font-weight: bold; text-align: right'>Promotion Discount" + " (" + dtOrder.Rows(0).Item("Promo_Discount").ToString + "%)&nbsp;</td>")
                    _mail.Append(" <td align='center' style='width: 6%'>").Append(dtOrder.Rows(0).Item("Promo_Discount_Amount").ToString).Append("</td>")
                    _mail.Append(" <td align='center' style='width: 4%'>&nbsp;BAHT</td>")
                    _mail.Append(" <td align='center' style='width: 5%'></td></tr>")
                End If
            End If

            _mail.Append(" <tr><td align='center' colspan='4' style='font-weight: bold; text-align: right'>Total&nbsp;</td>")
            _mail.Append(" <td align='center' style='width: 6%'>").Append(CDbl(dtOrder.Rows(0).Item("grand_total").ToString).ToString("#,###,##0.00")).Append("</td>")
            _mail.Append(" <td align='center' style='width: 4%'>&nbsp;BAHT</td>")
            _mail.Append(" <td align='center' style='width: 5%'></td></tr>")
            _mail.Append(" </table></td></tr><tr><td>&nbsp;</td></tr><tr>")
            _mail.Append(" <td>&nbsp;</td></tr></table>")
        End If

        Return _mail.ToString
    End Function
    Private Function StyleMail_Customer() As String
        getOrder()
        Dim customername As String = Replace(dtOrder.Rows(0).Item("customer_name").ToString, "[MEMBER]", " ") + "   " + dtOrder.Rows(0).Item("last_name").ToString

        Dim _mail As New StringBuilder
        If dtOrder.Rows.Count > 0 Then
            _mail.Append("<table width='100%' border='0' style='font-size: 10pt; font-family: Arial'><tr>")
            _mail.Append("<td style='height: 32px; font-weight: bold; color: #000099;'>Thank you for ordering with Asia Books.</td></tr><tr>")
            _mail.Append("<td style='height: 32px; font-weight: bold; color: #000099;'>Order detail :</td></tr><tr>")
            _mail.Append("<td><table width='80%' bordercolor='#666666' border='1' cellpadding='0' cellspacing='0' style='font-size: 9pt; font-family: Arial'><tr bgcolor='#666666'>")
            _mail.Append("<td align='center'style='color: white; background-color: #339933; width: 10%; font-style: normal; font-weight: bold; height: 18px;'>ISBN</td>")
            _mail.Append("<td style='color: white; background-color: #339933; width: 30%; font-style: normal; font-weight: bold; height: 18px;' align='center'>Tile</td>")
            _mail.Append("<td style='color: white; background-color: #339933; width: 5%; font-style: normal; font-weight: bold; height: 18px;' align='center'>Qty</td>")
            _mail.Append("<td style='color: white; background-color: #339933; width: 7%; font-style: normal; font-weight: bold; height: 18px;' align='center'>Price</td>")
            _mail.Append("<td style='color: white; background-color: #339933; width: 13%; font-style: normal; font-weight: bold; height: 18px;' align='center'>Status</td></tr>")
            For i As Integer = 0 To dtOrder.Rows.Count - 1
                _mail.Append("<tr><td align='center' style='width: 10%'>").Append(dtOrder.Rows(i).Item("isbn").ToString).Append("</td>")
                _mail.Append("<td align='left' style='width: 30%'>&nbsp;").Append(dtOrder.Rows(i).Item("book_title").ToString).Append("</td>")
                _mail.Append("<td align='center' style='width: 5%'>").Append(dtOrder.Rows(i).Item("orderqty").ToString).Append("</td>")
                _mail.Append("<td align='center' style='width: 7%'>").Append(CDbl(dtOrder.Rows(i).Item("Amount").ToString).ToString("#,###,##0.00")).Append("</td>")

                If dtOrder.Rows(i).Item("EBookID").ToString <> "" Then
                    _mail.Append("<td align='left' title='WIDTH:13%'>eBook</td></tr>")
                Else
                    _mail.Append("<td align='left' title='WIDTH:13%'>").Append(dtOrder.Rows(i).Item("leadtime").ToString).Append("</td></tr>")
                End If

            Next
            _mail.Append("<tr><td align='center' style='width: 10%'>&nbsp;</td>")
            _mail.Append("<td align='right' style='width: 30%'>&nbsp;</td>")
            _mail.Append("<td align='center' style='width: 5%'>&nbsp;</td>")
            _mail.Append("<td align='center' style='width: 7%'>&nbsp;</td>")
            _mail.Append("<td align='center' style='width: 13%'>&nbsp;</td></tr>")
            _mail.Append("<tr><td align='center' style='width: 10%'></td>")
            _mail.Append("<td align='right' style='width: 30%'></td>")
            _mail.Append("<td align='center' style='width: 5%'></td>")
            _mail.Append("<td align='center' style='width: 7%'></td>")
            _mail.Append("<td align='center' style='width: 13%'></td></tr>")
            _mail.Append("<tr><td colspan='3' style='font-weight: bold; text-align: right'>Delivery Cost&nbsp;</td>")
            _mail.Append("<td align='center' style='width: 7%'>").Append(dtOrder.Rows(0).Item("delivery_cost").ToString).Append("</td>")
            _mail.Append("<td align='left' style='width: 13%'>&nbsp;BAHT</td></tr>")

            If Not dtOrder.Rows(0).Item("Promo_Discount_Amount") Is Nothing And dtOrder.Rows(0).Item("Promo_Discount_Amount").ToString <> "" Then
                If CDbl(dtOrder.Rows(0).Item("Promo_Discount_Amount").ToString) > 0 Then
                    _mail.Append("<tr><td colspan='3' style='font-weight: bold; text-align: right'>Promotion Discount" + " (" + dtOrder.Rows(0).Item("Promo_Discount").ToString + "%)&nbsp;</td>")
                    _mail.Append("<td align='center' style='width: 7%'>").Append(dtOrder.Rows(0).Item("Promo_Discount_Amount").ToString).Append("</td>")
                    _mail.Append("<td align='left' style='width: 13%'>&nbsp;BAHT</td></tr>")
                End If
            End If

            _mail.Append("<tr><td colspan='3' style='font-weight: bold; text-align: right'>Total&nbsp;</td>")
            _mail.Append("<td align='center' style='width: 7%'>").Append(CDbl(dtOrder.Rows(0).Item("grand_total").ToString).ToString("#,###,##0.00")).Append("</td>")
            _mail.Append("<td align='left' style='width: 13%'>&nbsp;BAHT</td></tr>")
            _mail.Append("</table></td></tr><tr>")
            _mail.Append("<td>&nbsp;</td></tr><tr>")
            _mail.Append("<td>Pick up at branch : ").Append(dtOrder.Rows(0).Item("branch").ToString).Append("</td></tr><tr>")
            _mail.Append("<td>Paid by (payment method) : ").Append(dtOrder.Rows(0).Item("payment").ToString).Append("</td></tr><tr>")
            _mail.Append("<td>Reference : ").Append(dtOrder.Rows(0).Item("order_no").ToString).Append("</td></tr><tr>")

            If Me.rdobtnPayment.SelectedValue = "KE001" Then
                _mail.Append("<tr>")
                _mail.Append("<td>&nbsp;</td>")
                _mail.Append("</tr>")

                If dtOrder.Select("EBookID IS NOT NULL").Length > 0 Then
                    _mail.Append("<tr><td>Once the payment is completed, you will receive the e-mail to confirm that your eBook is ready to be downloaded on <a href='" + ConfigurationManager.AppSettings("AB_MyEBook") + "'>MY EBOOK</a> page.</td></tr>")
                Else
                    _mail.Append("<tr>")
                    _mail.Append("<td>Our Staffs will contact to inform when the books are ready to be picked up at ").Append(dtOrder.Rows(0).Item("branch").ToString).Append(". ")
                    _mail.Append("For your convenience, please print the payment form or inform the payment code (19 digits) to pay at the counter as to complete order.</td>")
                    _mail.Append("</tr>")
                End If

                _mail.Append("<tr>")
                _mail.Append("<td>&nbsp;</td>")
                _mail.Append("</tr>")

            Else
                _mail.Append("<td>&nbsp;</td></tr>")
                _mail.Append("<tr><td>Please arrange the payment via payment method at your convenience(Credit card, Money Transfer, or Counter Service)  as to complete the order.</td></tr>")

                If dtOrder.Select("isbn_13 IS NOT NULL").Length > 0 Then
                    _mail.Append("<tr><td>Asia Books will proceed to order books for you when your payment is received.</td></tr>")
                    _mail.Append("<tr><td>&nbsp;</td></tr>")

                    If dtOrder.Select("EBookID IS NOT NULL").Length > 0 Then
                        _mail.Append("<tr><td>On the other hand, for eBooks, you will receive the e-mail to confirm that your eBook is ready to be downloaded on <a href='" + ConfigurationManager.AppSettings("AB_MyEBook") + "'>MY EBOOK</a> page when we receive your payment.</td></tr>")
                        _mail.Append("<tr><td>&nbsp;</td></tr>")
                    End If
                Else
                    If dtOrder.Select("EBookID IS NOT NULL").Length > 0 Then
                        _mail.Append("<tr><td>Once the payment is completed, you will receive the e-mail to confirm that your eBook is ready to be downloaded on <a href='" + ConfigurationManager.AppSettings("AB_MyEBook") + "'>MY EBOOK</a> page.</td></tr>")
                        _mail.Append("<tr><td>&nbsp;</td></tr>")
                    End If
                End If

            End If

            _mail.Append("<tr><td>Customer Name : ").Append(Replace(dtOrder.Rows(0).Item("customer_name").ToString, "[MEMBER]", " ")).Append("   ").Append(dtOrder.Rows(0).Item("last_name").ToString).Append("</td></tr><tr>")
            _mail.Append("<td>Tel : ").Append(dtOrder.Rows(0).Item("telephone").ToString).Append("</td></tr><tr>")
            _mail.Append("<td>E-Mail : ").Append(lblemail.Text).Append("</td></tr><tr>")
            _mail.Append("<td>Address : ").Append(dtOrder.Rows(0).Item("ship_to_address").ToString).Append("</td>")
            _mail.Append("</tr>")

            _mail.Append("<tr>")
            _mail.Append("<td>&nbsp;</td>")
            _mail.Append("</tr>")

            If Me.rdobtnPayment.SelectedValue <> "KE001" Then
                _mail.Append("<tr>")
                _mail.Append("<td>In case that you select Money Transfer method, please fax pay in slip to our customer service at 02-7159197 to process order.</td>")
                _mail.Append("</tr>")
            End If

            'UR1012-0144
            If Me.rdobtnPayment.SelectedValue = "TF001" Then
                _mail.Append("<tr>")
                _mail.Append("<td>&nbsp;</td>")
                _mail.Append("</tr>")

                _mail.Append("<tr>")
                _mail.Append("<td>Transfer Through Commercial Bank Account</td>")
                _mail.Append("</tr>")
                _mail.Append("<tr>")
                _mail.Append("<td>Account Name: Asia Books Co., Ltd.</td>")
                _mail.Append("</tr>")
                _mail.Append("<tr>")
                _mail.Append("<td>Type of Account: Saving Account</td>")
                _mail.Append("</tr>")
                _mail.Append("<tr>")
                _mail.Append("<td>Choose any of the Commercial Banks you prefer:</td>")
                _mail.Append("</tr>")
                _mail.Append("<tr>")
                _mail.Append("<td>1. Kasikornbank, Sukhumvit 57 branch, Account No. 046-2-92435-6</td>")
                _mail.Append("</tr>")
                _mail.Append("<tr>")
                _mail.Append("<td>2. SCB, Bangkapi-Sukhumvit 45 branch, Account No. 009-2-78629-8</td>")
                _mail.Append("</tr>")
            End If

            _mail.Append("<tr>")
            _mail.Append("<td>&nbsp;</td>")
            _mail.Append("</tr>")

            _mail.Append("<tr>")
            _mail.Append("<td>Yours sincerely,</td>")
            _mail.Append("</tr>")
            _mail.Append("</table>")
        End If

        Return _mail.ToString
    End Function
    Private Function StyleMail_Customer_Home() As String
        getOrder()
        Dim customername As String = Replace(dtOrder.Rows(0).Item("customer_name").ToString, "[MEMBER]", " ") + "   " + dtOrder.Rows(0).Item("last_name").ToString

        Dim _mail As New StringBuilder
        If dtOrder.Rows.Count > 0 Then
            _mail.Append("<table width='100%' border='0' style='font-size: 10pt; font-family: Arial'><tr>")
            _mail.Append("<td style='height: 32px; font-weight: bold; color: #000099;'>Thank you for ordering with Asia Books.</td></tr><tr>")
            _mail.Append("<td style='height: 32px; font-weight: bold; color: #000099;'>Order detail :</td></tr><tr>")
            _mail.Append("<td><table width='80%' bordercolor='#666666' border='1' cellpadding='0' cellspacing='0' style='font-size: 9pt; font-family: Arial'><tr bgcolor='#666666'>")
            _mail.Append("<td align='center'style='color: white; background-color: #339933; width: 10%; font-style: normal; font-weight: bold; height: 18px;'>ISBN</td>")
            _mail.Append("<td style='color: white; background-color: #339933; width: 30%; font-style: normal; font-weight: bold; height: 18px;' align='center'>Tile</td>")
            _mail.Append("<td style='color: white; background-color: #339933; width: 5%; font-style: normal; font-weight: bold; height: 18px;' align='center'>Qty</td>")
            _mail.Append("<td style='color: white; background-color: #339933; width: 7%; font-style: normal; font-weight: bold; height: 18px;' align='center'>Price</td>")
            _mail.Append("<td style='color: white; background-color: #339933; width: 13%; font-style: normal; font-weight: bold; height: 18px;' align='center'>Status</td></tr>")
            For i As Integer = 0 To dtOrder.Rows.Count - 1
                _mail.Append("<tr><td align='center' style='width: 10%'>").Append(dtOrder.Rows(i).Item("isbn").ToString).Append("</td>")
                _mail.Append("<td align='left' style='width: 30%'>&nbsp;").Append(dtOrder.Rows(i).Item("book_title").ToString).Append("</td>")
                _mail.Append("<td align='center' style='width: 5%'>").Append(dtOrder.Rows(i).Item("orderqty").ToString).Append("</td>")
                _mail.Append("<td align='center' style='width: 7%'>").Append(CDbl(dtOrder.Rows(i).Item("Amount").ToString).ToString("#,###,##0.00")).Append("</td>")

                If dtOrder.Rows(i).Item("EBookID").ToString <> "" Then
                    _mail.Append("<td align='left' title='WIDTH:13%'>eBook</td></tr>")
                Else
                    _mail.Append("<td align='left' title='WIDTH:13%'>").Append(dtOrder.Rows(i).Item("leadtime").ToString).Append("</td></tr>")
                End If

            Next
            _mail.Append("<tr><td align='center' style='width: 10%'>&nbsp;</td>")
            _mail.Append("<td align='right' style='width: 30%'>&nbsp;</td>")
            _mail.Append("<td align='center' style='width: 5%'>&nbsp;</td>")
            _mail.Append("<td align='center' style='width: 7%'>&nbsp;</td>")
            _mail.Append("<td align='center' style='width: 13%'>&nbsp;</td></tr>")
            _mail.Append("<tr><td align='center' style='width: 10%'></td>")
            _mail.Append("<td align='right' style='width: 30%'></td>")
            _mail.Append("<td align='center' style='width: 5%'></td>")
            _mail.Append("<td align='center' style='width: 7%'></td>")
            _mail.Append("<td align='center' style='width: 13%'></td></tr>")
            _mail.Append("<tr><td colspan='3' style='font-weight: bold; text-align: right'>Delivery Cost&nbsp;</td>")
            _mail.Append("<td align='center' style='width: 7%'>").Append(dtOrder.Rows(0).Item("delivery_cost").ToString).Append("</td>")
            _mail.Append("<td align='left' style='width: 13%'>&nbsp;BAHT</td></tr>")

            If Not dtOrder.Rows(0).Item("Promo_Discount_Amount") Is Nothing And dtOrder.Rows(0).Item("Promo_Discount_Amount").ToString <> "" Then
                If CDbl(dtOrder.Rows(0).Item("Promo_Discount_Amount").ToString) > 0 Then
                    _mail.Append("<tr><td colspan='3' style='font-weight: bold; text-align: right'>Promotion Discount" + " (" + dtOrder.Rows(0).Item("Promo_Discount").ToString + "%)&nbsp;</td>")
                    _mail.Append("<td align='center' style='width: 7%'>").Append(dtOrder.Rows(0).Item("Promo_Discount_Amount").ToString).Append("</td>")
                    _mail.Append("<td align='left' style='width: 13%'>&nbsp;BAHT</td></tr>")
                End If
            End If

            _mail.Append("<tr><td colspan='3' style='font-weight: bold; text-align: right'>Total&nbsp;</td>")
            _mail.Append("<td align='center' style='width: 7%'>").Append(CDbl(dtOrder.Rows(0).Item("grand_total").ToString).ToString("#,###,##0.00")).Append("</td>")
            _mail.Append("<td align='left' style='width: 13%'>&nbsp;BAHT</td></tr>")
            _mail.Append("</table></td></tr><tr>")
            _mail.Append("<td>&nbsp;</td></tr><tr>")
            _mail.Append("<td>Home Delivery</td></tr><tr>")
            _mail.Append("<td>Paid by (payment method) : ").Append(dtOrder.Rows(0).Item("payment").ToString).Append("</td></tr><tr>")
            _mail.Append("<td>Reference : ").Append(dtOrder.Rows(0).Item("order_no").ToString).Append("</td></tr><tr>")

            If Me.rdobtnPayment.SelectedValue = "KE001" Then
                _mail.Append("<tr>")
                _mail.Append("<td>&nbsp;</td>")
                _mail.Append("</tr>")

                If dtOrder.Select("EBookID IS NOT NULL").Length > 0 Then
                    _mail.Append("<tr><td>On the other hand, for eBooks, you will receive the e-mail to confirm that your eBook is ready to be downloaded on <a href='" + ConfigurationManager.AppSettings("AB_MyEBook") + "'>MY EBOOK</a> page.</td></tr>")

                Else
                    _mail.Append("<tr>")
                    _mail.Append("<td>For your convenience, please print the payment form or inform the payment code (19 digits) to pay at Asia Books shop.")
                    _mail.Append("We will proceed your order when the payment is received.</td>")
                    _mail.Append("</tr>")
                End If

                _mail.Append("<tr>")
                _mail.Append("<td>&nbsp;</td>")
                _mail.Append("</tr>")

            Else
                _mail.Append("<td>&nbsp;</td></tr>")
                _mail.Append("<tr><td>Please arrange the payment via payment method at your convenience(Credit card, Money Transfer, or Counter Service) as to complete the order.</td></tr>")

                If dtOrder.Select("isbn_13 IS NOT NULL").Length > 0 Then

                    _mail.Append("<tr><td>Asia Books will proceed to order books for you when your payment is received.</td></tr>")
                    _mail.Append("<tr><td>&nbsp;</td></tr>")

                    If dtOrder.Select("EBookID IS NOT NULL").Length > 0 Then
                        _mail.Append("<tr><td>On the other hand, for eBooks, you will receive the e-mail to confirm that your eBook is ready to be downloaded on <a href='" + ConfigurationManager.AppSettings("AB_MyEBook") + "'>MY EBOOK</a> page when we receive your payment.</td></tr>")
                        _mail.Append("<tr><td>&nbsp;</td></tr>")
                    End If
                Else
                    If dtOrder.Select("EBookID IS NOT NULL").Length > 0 Then
                        _mail.Append("<tr><td>Once the payment is completed, you will receive the e-mail to confirm that your eBook is ready to be downloaded on <a href='" + ConfigurationManager.AppSettings("AB_MyEBook") + "'>MY EBOOK</a> page.</td></tr>")
                        _mail.Append("<tr><td>&nbsp;</td></tr>")
                    End If
                End If

            End If

            _mail.Append("<tr><td>Customer Name : ").Append(Replace(dtOrder.Rows(0).Item("customer_name").ToString, "[MEMBER]", " ")).Append("   ").Append(dtOrder.Rows(0).Item("last_name").ToString).Append("</td></tr><tr>")
            _mail.Append("<td>Tel : ").Append(dtOrder.Rows(0).Item("telephone").ToString).Append("</td></tr><tr>")
            _mail.Append("<td>E-Mail : ").Append(lblemail.Text).Append("</td></tr><tr>")
            _mail.Append("<td>Address : ").Append(dtOrder.Rows(0).Item("ship_to_address").ToString).Append("</td></tr><tr>")

            _mail.Append("<tr>")
            _mail.Append("<td>&nbsp;</td>")
            _mail.Append("</tr>")

            If Me.rdobtnPayment.SelectedValue <> "KE001" Then
                _mail.Append("<tr>")
                _mail.Append("<td>In case that you select Money Transfer method, please fax pay in slip to our customer service at 02-7159197 to process order.</td>")
                _mail.Append("</tr>")
            End If
            'UR1012-0144
            If Me.rdobtnPayment.SelectedValue = "TF001" Then
                _mail.Append("<tr>")
                _mail.Append("<td>&nbsp;</td>")
                _mail.Append("</tr>")

                _mail.Append("<tr>")
                _mail.Append("<td>Transfer Through Commercial Bank Account</td>")
                _mail.Append("</tr>")
                _mail.Append("<tr>")
                _mail.Append("<td>Account Name: Asia Books Co., Ltd.</td>")
                _mail.Append("</tr>")
                _mail.Append("<tr>")
                _mail.Append("<td>Type of Account: Saving Account</td>")
                _mail.Append("</tr>")
                _mail.Append("<tr>")
                _mail.Append("<td>Choose any of the Commercial Banks you prefer:</td>")
                _mail.Append("</tr>")
                _mail.Append("<tr>")
                _mail.Append("<td>1. Kasikornbank, Sukhumvit 57 branch, Account No. 046-2-92435-6</td>")
                _mail.Append("</tr>")
                _mail.Append("<tr>")
                _mail.Append("<td>2. SCB, Bangkapi-Sukhumvit 45 branch, Account No. 009-2-78629-8</td>")
                _mail.Append("</tr>")
            End If
            _mail.Append("<tr><td>&nbsp;</td></tr>")

            _mail.Append("<tr><td>Yours sincerely,</td></tr></table>")
        End If

        Return _mail.ToString
    End Function

    Protected Sub cbo_county_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs)
        If cbo_Transport_Type.SelectedValue <> "" _
       And (CDbl(checkNullTo0(lbl_InBranch_Total_Weight.Text)) + CDbl(checkNullTo0(lbl_jobber_Total_Weight.Text))) <> 0 _
       And cbo_county.SelectedValue <> 0 Then
            Transport_Type = cbo_Transport_Type.SelectedValue
            Country_Code = cbo_county.SelectedValue
            dt = ZoneChange()
            If dt.Rows.Count > 0 Then
                tbx_Zone.Text = dt.Rows(0).Item("Zone_Code").ToString
            End If
            'tbx_Zone.Text = dt.Rows(0).Item("Zone_Code").ToString
            Calculator()
        End If
    End Sub
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
    Protected Sub rdobtnPayment_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles rdobtnPayment.SelectedIndexChanged
        getPayment_type()
        If rdobtnPayment.SelectedValue = "CS001" Then
            Panel2.Visible = True
            Panel3.Visible = False
        ElseIf rdobtnPayment.SelectedValue = "CR001" Then
            Panel2.Visible = False
            Panel3.Visible = False
        ElseIf rdobtnPayment.SelectedValue = "TF001" Then
            Panel2.Visible = False
            Panel3.Visible = False
        ElseIf rdobtnPayment.SelectedValue = "PP001" Then
            Panel2.Visible = False
            Panel3.Visible = False
        ElseIf rdobtnPayment.SelectedValue = "KE001" Then
            Panel2.Visible = False
            Panel3.Visible = True
        End If
    End Sub

    Private Sub confirm_order()
        'Check_Address()
        If cbo_Transport_Type.SelectedValue = "AIRMAIL REGISTERED" Or cbo_Transport_Type.SelectedValue = "EMS" Then
            If rad_address1.Checked = True Then
                If lbl_address1.Text = "NO ADDRESS" Then
                    ScriptManager.RegisterClientScriptBlock(Me.Page, Me.GetType, "Alert", "alert('Please fill in the shipping address details at the field shipping address first. ');", True)
                    Exit Sub
                End If
            End If
            If rad_address2.Checked = True Then
                If lbl_address2.Text = "NO ADDRESS" Then
                    ScriptManager.RegisterClientScriptBlock(Me.Page, Me.GetType, "Alert", "alert('Please fill in the shipping address details at the field shipping address first. ');", True)
                    Exit Sub
                End If
            End If
            If rad_address3.Checked = True Then
                If lbl_address3.Text = "NO ADDRESS" Then
                    ScriptManager.RegisterClientScriptBlock(Me.Page, Me.GetType, "Alert", "alert('Please fill in the shipping address details at the field shipping address first. ');", True)
                    Exit Sub
                End If
            End If
            If rad_address4.Checked = True Then
                If tbx_name.Text = "" And tbx_Address.Text = "" Then
                    ScriptManager.RegisterClientScriptBlock(Me.Page, Me.GetType, "Alert", "alert('Please fill in the shipping address details at the field shipping address first. ');", True)
                    Exit Sub
                End If
            End If
        End If


        Dim Input_To_Table As New Class_Add_To_Cart
        Dim sqlDB As SqlDb = New SqlDb
        Dim dt_Session_In_Branch As DataTable = DirectCast(Session("In_Branch"), DataTable)
        Dim dt_Session_jobber As DataTable = DirectCast(Session("jobber"), DataTable)
        Dim dt_Session_ebook_merged As DataTable = DirectCast(Session("ebook_merged"), DataTable)
        Dim tel As String

        'If cbo_Transport_Type.SelectedValue = "AIRMAIL REGISTERED" Or cbo_Transport_Type.SelectedValue = "EMS" And lbl_InBranch_Total_Weight.Text = 0 Then
        '    ScriptManager.RegisterClientScriptBlock(Me.Page, Me.GetType, "Alert", "alert('As there is no weight information of the book(s), please contact our Customer service at 02-7159000 to confirm order and postage charge.');", True)
        '    Exit Sub
        'Else
        If cbo_Transport_Type.SelectedValue = "PICK UP AT BRANCH" And cbo_organizeab.SelectedValue = "" Then
            'lblEnjoy.Text = "Please select the branch where you like to pick up."
            'mdlPopUp_Enjoy.Show()
            ScriptManager.RegisterClientScriptBlock(Me.Page, Me.GetType, "Alert", "alert('Please select the branch where you like to pick up.');", True)
            cbo_organizeab.Focus()
            Exit Sub
        End If

        'If lbl_InBranch_Total_Weight.Text = 0 Then
        '    ScriptManager.RegisterClientScriptBlock(Me.Page, Me.GetType, "Alert", _
        '    "alert('Please coutact staff Tel 02-7159000 e-mail information@asiabooks.com');", True)
        'Else


        uCon = New uConnect
        Dim dt_Promo_Discount As New DataTable
        dt_Promo_Discount = uFunction.getDataTable(uCon.conn, "select discount from ebook_promotion WHERE status = 1 AND promotion = 1")
        If dt_Promo_Discount.Rows.Count > 0 Then
            Dim discount As Double = 0.0
            discount = CDbl(Session("original_total")) - CDbl(Session("amount_ebook"))
            promo_discount = CDbl(dt_Promo_Discount.Rows(0).Item("discount").ToString)
            promo_discount_amount = discount
        End If

        Try


            ' insert To table cart & table cartDetail
            dt_In_Branch = dt_Session_In_Branch
            dt_Jobber = dt_Session_jobber
            'dt_Ebook = dt_Session_ebook
            dt_Ebook = dt_Session_ebook_merged

            keyword_Branch = "HO-Internet"
            keyword_sales_channel = "INTERNET"

            If Not Session("amount_Branch") Is Nothing Then
                amount_Branch = Session("amount_Branch").ToString
            End If
            If Not Session("amount_other_Branch") Is Nothing Then
                amount_other_Branch = Session("amount_other_Branch").ToString
            End If
            If Not Session("amount_Jobber") Is Nothing Then
                amount_Jobber = Session("amount_Jobber").ToString
            End If
            If Not Session("amount_ebook") Is Nothing Then
                amount_Ebook = Session("amount_ebook").ToString
            End If

            Empcd = "Internet"
            Pcnm = Page.Request.ServerVariables("REMOTE_ADDR")

            ' insert To table customerOrder & table customerOrderDetail
            If Me.cbo_Transport_Type.SelectedValue = "PICK UP AT BRANCH" Then
                dt = sqlDB.GetDataTable("select * from tbm_syst_organizeab where Org_AB_Code = '" + cbo_organizeab.SelectedValue + "'")
                strPickUpCode = dt.Rows(0).Item("Org_AB_Code").ToString
                strPickUpName = dt.Rows(0).Item("Org_AB_Name").ToString
                strPickUpAddress = dt.Rows(0).Item("field2").ToString
                strPickUpEmail = dt.Rows(0).Item("field4").ToString
                PickUpCode = Me.strPickUpCode
                PickUpName = Me.strPickUpName
                PickUpAddress = Me.strPickUpAddress
                PickUpEmail = Me.strPickUpEmail
            Else
                PickUpCode = ""
                PickUpName = ""
                PickUpAddress = ""
                PickUpEmail = ""
            End If
            CartNo = CartNo

            Order_Date = Me.lbl_h_Order_Date.Text
            'cus_order.Member_Id = Me.Request.QueryString("MEMBER_CODE").ToString()
            Member_Id = member_code
            Customer_Name = Me.lbl_h_customer_name.Text
            Last_Name = Me.lbl_h_Last_Name.Text
            telephone = Me.lbl_h_telephone.Text
            Total_Amount = Me.lbl_total_amount.Text
            Total_Weight = (CDbl(checkNullTo0(lbl_InBranch_Total_Weight.Text)) + CDbl(checkNullTo0(lbl_jobber_Total_Weight.Text))).ToString("#,###,##0.00")
            If CInt(checkNullTo0(Me.lbl_InBranch_max_leadtime.Text)) > CInt(checkNullTo0(Me.lbl_jobber_max_leadtime.Text)) Then
                Max_Leadtime = Me.lbl_InBranch_max_leadtime.Text
            Else
                Max_Leadtime = Me.lbl_jobber_max_leadtime.Text
            End If
            Delivery_Cost = CDbl(checkNullTo0(Me.lbl_delivery_cost.Text)).ToString("#,###,##0.00")
            Delivery_Available = CDbl(checkNullTo0(Me.lbl_InBranch_delivery_cost.Text)).ToString("#,###,##0.00")
            Delivery_special = CDbl(checkNullTo0(Me.lbl_jobber_delivery_cost.Text)).ToString("#,###,##0.00")
            Grand_Total = CDbl(checkNullTo0(Me.lbl_grand_total.Text)).ToString("#,###,##0.00")
            Deposit_Amount = "0.00"
            Balance = "0.00"

            If rad_address1.Checked = True Then
                Ship_to_name = lbl_h_customer_name.Text + " " + lbl_h_Last_Name.Text
                Ship_to_address = Me.lbl_address1.Text
                strAumphur = lblamphur1.Text
                strProvince = lblprovince1.Text
                strCountry = lblcountry1.Text
                strZipCode = lblzipcode1.Text

            ElseIf rad_address2.Checked = True Then
                Ship_to_name = lbl_h_customer_name.Text + " " + lbl_h_Last_Name.Text
                Ship_to_address = Me.lbl_address2.Text
                strAumphur = lblamphur2.Text
                strProvince = lblprovince2.Text
                strCountry = lblcountry2.Text
                strZipCode = lblzipcode2.Text

            ElseIf rad_address3.Checked = True Then
                Ship_to_name = lbl_h_customer_name.Text + " " + lbl_h_Last_Name.Text
                Ship_to_address = Me.lbl_address3.Text
                strAumphur = lblamphur3.Text
                strProvince = lblprovince3.Text
                strCountry = lblcountry3.Text
                strZipCode = lblzipcode3.Text

            ElseIf rad_address4.Checked = True Then
                Ship_to_name = Me.tbx_name.Text
                Ship_to_address = Me.tbx_Address.Text & " " & tbx_amphur.Text & " " & tbx_province.Text & " " & tbx_country.Text & " " & tbx_zipcode.Text

                strAumphur = tbx_amphur.Text
                strProvince = tbx_province.Text
                strCountry = tbx_country.Text
                strZipCode = tbx_zipcode.Text

            End If

            If Me.In_Branch.Items.Count > 0 Or Me.jobber.Items.Count Then
                If Me.cbo_Transport_Type.SelectedValue <> "" Then
                    Transport_Type = Me.cbo_Transport_Type.SelectedValue
                Else
                    'lblEnjoy.Text = "Please select the shipping type."
                    'mdlPopUp_Enjoy.Show()
                    ScriptManager.RegisterClientScriptBlock(Me.Page, Me.GetType, "Alert", "alert('Please select the shipping type.');", True)
                    cbo_Transport_Type.Focus()
                    Exit Sub
                End If
            End If

            Zone = tbx_Zone.Text
            Country_Code = Me.cbo_county.SelectedValue


            If rad_bill_sameAddress.Checked = True Then
                Billing_Name = Ship_to_name
                Billing_Address = Ship_to_address
            ElseIf rad_bill_sameAddress1.Checked = True Then
                Billing_Name = Me.tbx_name_bill.Text
                Billing_Address = Me.tbx_Address_bill.Text
            End If

            If Me.chk_gift.Checked = True Then
                Gift_Flag = "1"
            Else
                Gift_Flag = "0"
            End If

            Gift_From = Me.tbx_name_gift_from.Text
            Gift_to = Me.tbx_name_gift_to.Text
            Gift_Message = Me.tbx_message_gift.Text



            If cbo_payment_type.SelectedValue = "" Then
                'lblEnjoy.Text = "Please select the Payment type."
                'mdlPopUp_Enjoy.Show()
                ScriptManager.RegisterClientScriptBlock(Me.Page, Me.GetType, "Alert", "alert('Please select the Payment type.');", True)
                cbo_payment_type.Focus()
                Exit Sub
            Else
                Payment_Type = Me.cbo_payment_type.SelectedValue
            End If
            If rdobtnPayment.SelectedValue = "" Then
                'lblEnjoy.Text = "Please select the Payment name."
                'mdlPopUp_Enjoy.Show()
                ScriptManager.RegisterClientScriptBlock(Me.Page, Me.GetType, "Alert", "alert('Please select the Payment name.');", True)
                Exit Sub
            Else
                Payment_Method_Code = Me.rdobtnPayment.SelectedValue
            End If
            'tel = "0027159000"

            Sales_Channel_Code = "INTERNET"
            Exchange_Rate = sqlDB.GetDataTable("SELECT Exchange_Rate FROM tbm_syst_currency WHERE Currency_Code = 'USD'").Rows(0)(0).ToString
            Empcd = "Internet"
            Pcnm = Page.Request.ServerVariables("REMOTE_ADDR")
            Email = lblemail.Text


            If SaveData() = False Then
                ScriptManager.RegisterClientScriptBlock(Me.Page, Me.GetType, "Alert", "alert('System Error:" + message + "');", True)
                Exit Sub
            Else
                Dim strsql As String = ""

                If lblCheck_Confirm_Code_Promotion.Text = "1" Then

                    If lblChkData_Table_Promotion.Text = "0" Then 'ยังไม่มีข้อมูลใน table promotion (ได้ promotion ผ่านหน้าร้าน มาใช้บน web)
                        strsql = ""
                        strsql &= " insert into tbm_AB_Promotion_Cross (Code_Promotion,Order_No_Get,Order_No_Use,Status,Is_Void,Order_Status,Created,CreateBy) values ("
                        strsql &= " '" + lblCode_Promotion.Text.Trim + "',"
                        strsql &= " '" + Order_No + "',"
                        strsql &= " '" + Order_No + "',"
                        strsql &= " 'Y','N','1',"
                        strsql &= " getdate(),"
                        strsql &= " '" + HttpContext.Current.Request.ServerVariables("REMOTE_ADDR") + "')"
                        uFunction.ExecuteDataStringNonTran(uCon.conn, strsql)

                    Else
                        strsql = ""
                        strsql &= " update tbm_AB_Promotion_Cross set"
                        strsql &= " Order_No_Use = '" + Order_No + "'"
                        strsql &= " ,Updated = getdate()"
                        strsql &= " ,status = 'Y'"
                        strsql &= " ,UpdateBy = '" + HttpContext.Current.Request.ServerVariables("REMOTE_ADDR") + "'"
                        strsql &= " where Code_Promotion = '" + lblCode_Promotion.Text + "'"
                        uFunction.ExecuteDataStringNonTran(uCon.conn, strsql)
                    End If

                    Method_Payment()
                Else

                    lblPromotion_Cross.Text = clsPromotion.GenCode_Promotion_Cross(Order_No, lblCheck_Digit.Text)

                    strsql = ""
                    strsql &= " insert into tbm_AB_Promotion_Cross (Code_Promotion,Order_No_Get,Status,Is_Void,Order_Status,Created,CreateBy) values ("
                    strsql &= " '" + lblPromotion_Cross.Text.Trim + "',"
                    strsql &= " '" + Order_No + "',"
                    strsql &= " 'N','N','1',"
                    strsql &= " getdate(),"
                    strsql &= " '" + HttpContext.Current.Request.ServerVariables("REMOTE_ADDR") + "')"
                    uFunction.ExecuteDataStringNonTran(uCon.conn, strsql)

                    Method_Payment()
                    'mdlPopUp_ShowCode_Promotion.Show()
                End If
                
            End If

        Catch ex As Exception

            ScriptManager.RegisterClientScriptBlock(Me.Page, Me.GetType, "Alert", "alert('System Error: " + message + "');", True)
            GenerateLog("confirm_order", "", "", Order_No, "", "", "https://www.asiabooks.com", "", ex.Message + " " + ex.GetBaseException.ToString)

            Exit Sub
        End Try
    End Sub
    Public Sub SendSMS()
        If lbl_h_telephone.Text <> "" Then
            Dim strSplit As String()
            Dim strPrice As String = ""
            Dim strTel As String = lbl_h_telephone.Text
            strSplit = strTel.Replace("-", "").Split(" ")
            If strSplit.Length > 1 Then
                If Left(strSplit(0), 2) = "08" Then
                    If strSplit(0).Length = 10 Then
                        ws_Send_SMS.CallSend_SMS(lbl_h_order_no.Text, strSplit(0).ToString, "Promotional code is " + lblPromotion_Cross.Text + ". Pls show it to get extra 10%.", "d6hojkiyd", "Promotion Cross")
                    End If
                Else
                    If Left(strSplit(1), 2) = "08" Then
                        If strSplit(1).Length = 10 Then
                            ws_Send_SMS.CallSend_SMS(lbl_h_order_no.Text, strSplit(1).ToString, "Promotional code is " + lblPromotion_Cross.Text + ". Pls show it to get extra 10%.", "d6hojkiyd", "Promotion Cross")
                        End If
                    End If
                End If
            Else
                If Left(strSplit(0), 2) = "08" Then
                    If strSplit(0).Length = 10 Then
                        ws_Send_SMS.CallSend_SMS(lbl_h_order_no.Text, strSplit(0).ToString, "Promotional code is " + lblPromotion_Cross.Text + ". Pls show it to get extra 10%.", "d6hojkiyd", "Promotion Cross")
                    End If
                End If
            End If

        End If
    End Sub

    Public Sub Method_Payment()
        Dim Order_No As String = lbl_h_order_no.Text
        Dim CartDateArr(2) As String
        Dim CartDateConvert As String
        CartDateArr = lbl_h_Order_Date.Text.ToString.Split("/")
        CartDateConvert = CartDateArr(1) & "/" & CartDateArr(0) & "/" & CartDateArr(2)
        'CartDateConvert = CartDateArr(1) & "/" & CartDateArr(0) & "/" & CartDateArr(2) 'เครื่อง Production
        'CartDateConvert = CartDateArr(0) & "/" & CartDateArr(1) & "/" & CartDateArr(2) 'เครื่อง Test
        'CartDateConvert = CartDateArr(1) & "/" & CartDateArr(0) & "/" & CartDateArr(2)+543
        Try

            If Me.rdobtnPayment.SelectedValue = "CR001" Then

                If cbo_payment_type.SelectedValue = "BAHT" Then
                    Url = PaymentService.PaymentCreditCard_Kung(Request.Url.ToString, _
                    Page.Request.ServerVariables("REMOTE_ADDR"), Convert.ToDecimal(lbl_grand_total.Text).ToString("0.00"), _
                    True, ConfigurationManager.AppSettings("CC_ThanksURL"), PaymentDesc.ToString, Order_No)

                Else
                    Url = PaymentService.PaymentCreditCard_Kung(Request.Url.ToString, _
                    Page.Request.ServerVariables("REMOTE_ADDR"), Convert.ToDecimal(bd.callUsd(lbl_grand_total.Text)).ToString("0.00"), _
                    False, ConfigurationManager.AppSettings("CC_ThanksURL"), PaymentDesc.ToString, Order_No)
                End If
                SendMail()
                RemoveSession()
                ScriptManager.RegisterClientScriptBlock(Me.Page, Me.GetType, "Alert", " window.open('" + Url + "','_parent');", True)

            ElseIf Me.rdobtnPayment.SelectedValue = "PP001" Then

                Dim Country_Code As String = Session("client_nation")

                If cbo_payment_type.SelectedValue = "BAHT" Then
                    Url = PaymentService.PaymentPayPal(Request.Url.ToString, _
                    Page.Request.ServerVariables("REMOTE_ADDR"), Convert.ToDecimal(lbl_grand_total.Text).ToString("0.00"), _
                    True, ConfigurationManager.AppSettings("PayPal_ReturnURL").ToString(), _
                    ConfigurationManager.AppSettings("PayPal_CancelURL").ToString(), _
                    ConfigurationManager.AppSettings("PayPal_ThanksURL").ToString(), PaymentDesc.ToString, Order_No, Country_Code)

                Else
                    Url = PaymentService.PaymentPayPal(Request.Url.ToString, _
                    Page.Request.ServerVariables("REMOTE_ADDR"), Convert.ToDecimal(bd.callUsd(lbl_grand_total.Text)).ToString("0.00"), _
                    False, ConfigurationManager.AppSettings("PayPal_ReturnURL").ToString(), _
                    ConfigurationManager.AppSettings("PayPal_CancelURL").ToString(), _
                    ConfigurationManager.AppSettings("PayPal_ThanksURL").ToString(), PaymentDesc.ToString, Order_No, Country_Code)
                End If
                SendMail()
                RemoveSession()

                ScriptManager.RegisterClientScriptBlock(Me.Page, Me.GetType, "Alert", " window.open('" + Url + "','_parent');", True)

            ElseIf Me.rdobtnPayment.SelectedValue = "CS001" Then
                Dim CheckOrderNo As String
                CheckOrderNo = "0" + Right(Order_No, 9)
                Url = PaymentService.PaymentCounterService(Request.Url.ToString, _
                    Page.Request.ServerVariables("REMOTE_ADDR"), CartDateConvert, Order_No, _
                   Member_Id, Convert.ToDecimal(lbl_grand_total.Text).ToString("0.00"), CheckOrderNo, "02", "Order By www.Asiabooks.com - สั่งซื้อสินค้าจาก www.Asiabooks.com") '"Payment By Counter Service")
                If Url.Trim = "" Then
                    AddError()
                    ScriptManager.RegisterClientScriptBlock(Me.Page, Me.GetType, "Alert", _
             "alert('Customer Order No : " + Order_No + "');", True)
                Else
                    SendMail()
                    RemoveSession()
                    Response.Redirect(Url)
                End If
            ElseIf Me.rdobtnPayment.SelectedValue = "TF001" Then

                Url = PaymentService.PaymentBankTransfer(Request.Url.ToString, _
                    Page.Request.ServerVariables("REMOTE_ADDR"), CartDateConvert, Order_No, _
                     Member_Id, Convert.ToDecimal(lbl_grand_total.Text).ToString("0.00"), _
                     "Order By www.Asiabooks.com - สั่งซื้อสินค้าจาก www.Asiabooks.com") '"Payment By Bank Transfer")

                If Url.Trim = "" Then
                    AddError()
                    ScriptManager.RegisterClientScriptBlock(Me.Page, Me.GetType, "Alert", _
             "alert('Customer Order No : " + Order_No + "');", True)
                Else
                    SendMail()
                    RemoveSession()
                    Response.Redirect(Url)
                End If
            ElseIf Me.rdobtnPayment.SelectedValue = "KE001" Then
                Dim strOrderNO As String = ""
                Dim strAmount As String = ""
                strAmount = lbl_grand_total.Text.Replace(".", "").Replace(",", "")

                strOrderNO = Left(Order_No, 6) & Right(Order_No, 4)
                For i As Integer = strAmount.Length To 6
                    strAmount = "0" & strAmount
                Next

                keios = New uKeios
                Dim strKeios As String = keios.PaidEcomToPOS(strOrderNO, strAmount)
                Dim strSql As String = ""

                strSql = ""
                strSql &= " update tbt_asbkeo_cus_order set"
                strSql &= " Keios_Send_WS = '" + strOrderNO & strAmount + "',"
                strSql &= " Keios_Post = '" + strKeios + "'"
                strSql &= " where Order_No = '" + Order_No + "'"
                uFunction.ExecuteDataStringNonTran(uCon.conn, strSql)
                SendMail()
                RemoveSession()
                Response.Redirect("Keios_Post.aspx?Order_No=" & Order_No & "&Keios=" & strKeios)

            End If

        Catch ex As Exception
            cus_order.AddError()
            ScriptManager.RegisterClientScriptBlock(Me.Page, Me.GetType, "Alert", "alert('" + MessagePayment + "');", True)

        End Try

        'If message <> "Add  Successful" Then
        '    ScriptManager.RegisterClientScriptBlock(Me.Page, Me.GetType, "Alert", "alert('System Error:" + message + "');", True)
        '    Exit Sub
        'Else

        'End If
    End Sub

    Protected Sub b_confirm_order_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles b_confirm_order.Click
        If rdobtnPayment.SelectedValue = "CS001" Then
            lblCheck_Meassge.Text = "Thank you for your order. For us to process your order, please fax us the transfer slip (of money transfer) or counter service form when you completed the payment to E-commerce Dept at fax no. 02-715-9197 or scan it and e-mail us at ecommerce@asiabooks.com "
            mdlPopup_Meassge.Show()
        ElseIf rdobtnPayment.SelectedValue = "CR001" Then
            confirm_order()
        ElseIf rdobtnPayment.SelectedValue = "TF001" Then
            lblCheck_Meassge.Text = "Thank you for your order. For us to process your order, please fax us the transfer slip (of money transfer) or counter service form when you completed the payment to E-commerce Dept at fax no. 02-715-9197 or scan it and e-mail us at ecommerce@asiabooks.com "
            mdlPopup_Meassge.Show()
        ElseIf rdobtnPayment.SelectedValue = "PP001" Then
            confirm_order()
        ElseIf rdobtnPayment.SelectedValue = "KE001" Then
            lblCheck_Meassge.Text = "Thank you for your order. For your convenience, please print the payment form or inform the payment code (19 digits) to pay at Asia Books shop you selected. "
            mdlPopup_Meassge.Show()
        Else
            confirm_order()
        End If

    End Sub

    Protected Sub img_comfirm_check_pro_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles img_comfirm_check_pro.Click
        confirm_order()
    End Sub

    Protected Sub img_Enjoy_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles img_Enjoy.Click
        Check_Tramsport_Type()
    End Sub
    Private Function GetBestsellers_ConfirmOrder(ByVal strfile As String) As Object
        Dim xmlDoc As XElement
        Dim xxx As String = "9780143011989"
        Dim BasicGroups As String() = New String() {"9780143011989", "Node2"}

        Try
            xmlDoc = XElement.Load(strfile)

            Dim Items = From c In xmlDoc.Elements("BooksBestSeller") _
                        Order By Convert.ToInt16(c.Element("saleQty").Value) Ascending _
                        Select isbn_13 = c.Element("isbn_13").Value, _
                        image = _Utility.GetImagePath_Book(c.Element("image").Value), _
                        book_title = IIf(c.Element("book_title").Value.Length > 50, Left(c.Element("book_title").Value, 50) & "...", c.Element("book_title").Value), _
                        author = IIf(c.Element("author").Value.Length > 20, Left(c.Element("author").Value, 20) & "...", c.Element("author").Value), _
                        selling_price = CDbl(c.Element("list_price").Value.ToString).ToString("#,###,##0.00"), _
                        your_price = IIf(c.Element("your_price").Value = "0.00", CDbl(c.Element("list_price").Value.ToString).ToString("#,###,##0.00"), CDbl(c.Element("your_price").Value.ToString).ToString("#,###,##0.00")), _
                        price_usd = IIf(c.Element("your_price").Value = "0.00", bd.callUsd(uXML.Currency, Convert.ToDouble(c.Element("list_price").Value)), bd.callUsd(uXML.Currency, Convert.ToDouble(c.Element("your_price").Value))), _
                        save_price = c.Element("save_price").Value, _
                        book_title_full = c.Element("book_title").Value, _
                        author_full = c.Element("author").Value

            Return Items.Take(5)
        Catch ex As Exception
            Throw New Exception("Top6_BargainShockPrice : " & ex.Message.ToString)
            Return Nothing
        Finally
            xmlDoc = Nothing
        End Try
    End Function

    Protected Sub lvBooks_ItemDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.ListViewItemEventArgs) Handles lvBooks.ItemDataBound
        If e.Item.ItemType = ListViewItemType.DataItem Then

            Dim imgCustomer_Average As Image = e.Item.FindControl("imgCustomer_Average")
            Dim lblCustomerView As Label = e.Item.FindControl("lblCustomerView")
            Dim lblisbn As Label = e.Item.FindControl("lblisbn")
            Dim lblList_Price_H As Label = e.Item.FindControl("lblList_Price_H")
            Dim lblList_Price_D As Label = e.Item.FindControl("lblList_Price_D")
            Dim lblsave_price_L As Label = e.Item.FindControl("lblsave_price_L")
            Dim lblsave_price_C As Label = e.Item.FindControl("lblsave_price_C")
            Dim lblsave_price_R As Label = e.Item.FindControl("lblsave_price_R")
            Dim lblYour_Price As Label = e.Item.FindControl("lblYour_Price")

            If lblList_Price_D.Text = lblYour_Price.Text Then
                lblList_Price_H.Visible = False
                lblList_Price_D.Visible = False
                lblsave_price_L.Visible = False
                lblsave_price_C.Visible = False
                lblsave_price_R.Visible = False
            Else
                lblList_Price_D.Font.Strikeout = True
            End If

            uCon = New uConnect
            Dim strImageUrl As String = ""
            Dim dt_view As New DataTable
            Dim strsql As String = ""

            strsql = ""
            strsql &= " select case No_CustomerDiscussion when '0' then '0' else ((No_CusReview1*1)+(No_CusReview2*2)+(No_CusReview3*3)+"
            strsql &= " (No_CusReview4*4)+(No_CusReview5*5))/No_CustomerDiscussion end as total,*"
            strsql &= " from dbo.tbm_AB_CustomerReview"
            strsql &= " where isbn_13 = '" + lblisbn.Text + "'"

            dt_view = uFunction.getDataTable(uCon.conn, strsql)
            If dt_view.Rows.Count > 0 Then
                Dim strCustomer_Average As String = ""
                strCustomer_Average = dt_view.Rows(0).Item("total").ToString
                'กรณีคำนวนแล้วได้ 0 ต้องคิดค่าเฉลี่ยเอง

                If strCustomer_Average = "0" Then
                    dt_view.Clear()
                    strsql = ""
                    strsql &= " select (CASE WHEN right(isbn_13,2)='00' "
                    strsql &= " THEN 99*3/99 "
                    strsql &= " ELSE right(isbn_13,2)*3/right(isbn_13,2) END) AS total,"
                    strsql &= " (CASE WHEN right(isbn_13,2)='00' "
                    strsql &= " THEN '99' "
                    strsql &= " ELSE right(isbn_13,2) END) AS No_CustomerView"
                    strsql &= " from tbt_jobber_book_search"
                    strsql &= " where isbn_13 = '" + lblisbn.Text + "'"
                    dt_view = uFunction.getDataTable(uCon.conn, strsql)
                    If dt_view.Rows.Count > 0 Then
                        strCustomer_Average = dt_view.Rows(0).Item("total").ToString
                        lblCustomerView.Text = dt_view.Rows(0).Item("No_CustomerView").ToString

                        Select Case strCustomer_Average
                            Case "1"
                                imgCustomer_Average.ImageUrl = "~/images/Template/stars1.gif"
                            Case "2"
                                imgCustomer_Average.ImageUrl = "~/images/Template/stars2.gif"
                            Case "3"
                                imgCustomer_Average.ImageUrl = "~/images/Template/stars3.gif"
                            Case "4"
                                imgCustomer_Average.ImageUrl = "~/images/Template/stars4.gif"
                            Case "5"
                                imgCustomer_Average.ImageUrl = "~/images/Template/stars5.gif"
                            Case Else
                                imgCustomer_Average.ImageUrl = "~/images/Template/stars0.gif"
                        End Select
                    End If
                Else
                    lblCustomerView.Text = dt_view.Rows(0).Item("No_CustomerView").ToString

                    Select Case strCustomer_Average
                        Case "1"
                            imgCustomer_Average.ImageUrl = "~/images/Template/stars1.gif"
                        Case "2"
                            imgCustomer_Average.ImageUrl = "~/images/Template/stars2.gif"
                        Case "3"
                            imgCustomer_Average.ImageUrl = "~/images/Template/stars3.gif"
                        Case "4"
                            imgCustomer_Average.ImageUrl = "~/images/Template/stars4.gif"
                        Case "5"
                            imgCustomer_Average.ImageUrl = "~/images/Template/stars5.gif"
                        Case Else
                            imgCustomer_Average.ImageUrl = "~/images/Template/stars0.gif"
                    End Select
                End If

            Else
                dt_view.Clear()
                strsql = ""
                strsql &= " select (CASE WHEN right(isbn_13,2)='00' "
                strsql &= " THEN 99*3/99 "
                strsql &= " ELSE right(isbn_13,2)*3/right(isbn_13,2) END) AS total,"
                strsql &= " (CASE WHEN right(isbn_13,2)='00' "
                strsql &= " THEN '99' "
                strsql &= " ELSE right(isbn_13,2) END) AS No_CustomerView"
                strsql &= " from tbt_jobber_book_search"
                strsql &= " where isbn_13 = '" + lblisbn.Text + "'"
                dt_view = uFunction.getDataTable(uCon.conn, strsql)
                If dt_view.Rows.Count > 0 Then
                    Dim strCustomer_Average As String = ""
                    strCustomer_Average = dt_view.Rows(0).Item("total").ToString
                    lblCustomerView.Text = dt_view.Rows(0).Item("No_CustomerView").ToString

                    Select Case strCustomer_Average
                        Case "1"
                            imgCustomer_Average.ImageUrl = "~/images/Template/stars1.gif"
                        Case "2"
                            imgCustomer_Average.ImageUrl = "~/images/Template/stars2.gif"
                        Case "3"
                            imgCustomer_Average.ImageUrl = "~/images/Template/stars3.gif"
                        Case "4"
                            imgCustomer_Average.ImageUrl = "~/images/Template/stars4.gif"
                        Case "5"
                            imgCustomer_Average.ImageUrl = "~/images/Template/stars5.gif"
                        Case Else
                            imgCustomer_Average.ImageUrl = "~/images/Template/stars0.gif"
                    End Select
                End If

            End If
        End If
    End Sub

    Public Function GenerateLog(ByVal CallFunation As String, ByVal CallServiceURL As String, ByVal IPAddress As String, ByVal DocumrntNo As String, ByVal MemberNo As String, ByVal Amount As String, ByVal ResultURL As String, ByVal TanksURL As String, ByVal Description As String) As Boolean
        Try
            Dim StrPath As String = Server.MapPath("Log File").ToString & "\"
            Dim StrFileName As String = "Log_eOrdering_" & Format(Now, "yyyyMMdd") & ".txt"
            Dim StrValue As New StringBuilder

            StrValue.Append(Format(Now, "dd/MM/yyyy") & " " & Format(Now, "hh:mm:ss"))
            StrValue.Append("; CallFunation ")
            StrValue.Append(CallFunation)
            StrValue.Append("; CallServiceURL ")
            StrValue.Append(CallServiceURL)
            StrValue.Append("; IPAddress ")
            StrValue.Append(IPAddress)
            StrValue.Append("; DocumrntNo ")
            StrValue.Append(DocumrntNo)
            StrValue.Append("; MemberNo ")
            StrValue.Append(MemberNo)
            StrValue.Append("; Amount ")
            StrValue.Append(Amount)
            'StrValue.Append("; ResultURL ")
            'StrValue.Append(ResultURL)
            StrValue.Append("; TanksURL ")
            StrValue.Append(TanksURL)
            StrValue.Append("; Description ")
            StrValue.Append(Description)
            StrValue.Append(";")

            'Dim sw As StreamWriter = New StreamWriter(StrPath.Replace("PaymentMethod\", "") & StrFileName, True, Encoding.GetEncoding(874))
            ' '' Add some text to the file.
            'sw.WriteLine(StrValue.ToString)
            'sw.Close()
            'StrValue.Remove(0, StrValue.Length)
            CollectionWrite(StrPath.Replace("PaymentMethod\", ""), StrFileName, StrValue.ToString)

            Return True

        Catch ex As Exception
            'Throw ex
            Return False
        End Try
    End Function

    Public Function CollectionWrite(ByVal strPath As String, ByVal strName As String, ByVal error_message As String) As Boolean
        Try
            Dim i As Integer = 0
            Dim fso As New StreamWriter(strPath & "\" & strName, True)
            fso.WriteLine(error_message)
            fso.Close()
            fso = Nothing
        Catch ex As Exception
        End Try
    End Function

    Protected Sub ebook_ItemDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.DataGridItemEventArgs) Handles ebook.ItemDataBound
        If e.Item.ItemType = ListItemType.Item Or e.Item.ItemType = ListItemType.AlternatingItem Then
            Dim lbl_Amount_ebook As Label = e.Item.FindControl("lbl_Amount_ebook")

            If lbl_Amount_ebook.Text = "0" Then
                Dim lbl_Price_ebook As Label = e.Item.FindControl("lbl_Price_ebook")
                lbl_Price_ebook.Visible = False

                Dim lbl_Price_ebook_free As Label = e.Item.FindControl("lbl_Price_ebook_free")
                lbl_Price_ebook_free.Visible = True
            Else
                Dim lbl_Price_ebook As Label = e.Item.FindControl("lbl_Price_ebook")
                lbl_Price_ebook.Visible = True

                Dim lbl_Price_ebook_free As Label = e.Item.FindControl("lbl_Price_ebook_free")
                lbl_Price_ebook_free.Visible = False
            End If

        End If
    End Sub

    Protected Sub btnCross_POS_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles btnCross_POS.Click
        mdlPopUp_ConfirmCode_Promotion.Show()
    End Sub

    Protected Sub btnCheckCode_Promotion_Cross_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles btnCheckCode_Promotion_Cross.Click
        Dim strCode_Promotion As String
        Dim strsql As String = ""
        strCode_Promotion = txtConfirm_Promotion.Text.Replace("-", "").Replace(" ", "")
        lblCode_Promotion.Text = strCode_Promotion
        uCon = New uConnect
        Dim dtChk_Code As New DataTable

        If lblCheck_Pro_Use.Text <> "1" Then
            If strCode_Promotion.ToString.ToUpper = "COMMART2011" Then
                lblCode_Promotion.Text = strCode_Promotion.ToString.ToUpper
                lblCheck_Confirm_Code_Promotion.Text = "1"
                lblChkData_Table_Promotion.Text = "0"

                in_branch_total_Promotion()
                jobber_total_Promotion()
                ebook_total_Promotion()

                lbl_total_amount.Text = (CDbl(checkNullTo0(lbl_InBranch_total.Text)) + CDbl(checkNullTo0(lbl_jobber_total.Text)) + CDbl(checkNullTo0(lbl_ebook_total.Text))).ToString("#,###,##0.00")
                lbl_total_amount_usd.Text = "(US$ " + bd.callUsd(lbl_total_amount.Text) + ")" ' convert bath to USD
                lbl_grand_total.Text = (CDbl(checkNullTo0(Me.lbl_delivery_cost.Text)) + CDbl(checkNullTo0(Me.lbl_total_amount.Text))).ToString("#,###,##0.00")
                lbl_grand_total_usd.Text = "(US$ " + bd.callUsd(lbl_grand_total.Text) + ")"

                lblCheck_Pro_Use.Text = "1"
            Else
                If strCode_Promotion.Length = 16 Then
                    dt = uFunction.getDataTable(uCon.conn, "select * from tbm_AB_Promotion_Cross where Code_Promotion = '" + strCode_Promotion + "'")

                    If dt.Rows.Count > 0 Then
                        lblChkData_Table_Promotion.Text = "1"

                        If dt.Rows(0).Item("status") = "N" And dt.Rows(0).Item("is_void") = "N" And dt.Rows(0).Item("order_status") = "2" Then
                            If clsPromotion.CheckDigisCode_Promotion_Cross(Right(strCode_Promotion, 1), strCode_Promotion.ToString.Trim) = True Then

                                lblCheck_Confirm_Code_Promotion.Text = "1"
                                Dim strCheckDigit As String = ""
                                strCheckDigit = Right(strCode_Promotion, 1)

                                If strCheckDigit = "1" Then
                                    If lblCheck_Digit.Text = "2" Or lblCheck_Digit.Text = "3" Then
                                        in_branch_total_Promotion()
                                        jobber_total_Promotion()
                                        ebook_total_Promotion()

                                        lblCheck_Pro_Use.Text = "1"
                                    Else
                                        lblMsg_Promotion.Text = "This promotion cannot be applied because no eBook has been ordered."
                                        mdlPopUp_ConfirmCode_Promotion.Hide()
                                        mdlPopUp_Msg_Promotion.Show()
                                    End If
                                End If
                                If strCheckDigit = "2" Then
                                    If lblCheck_Digit.Text = "1" Or lblCheck_Digit.Text = "3" Then
                                        in_branch_total_Promotion()
                                        jobber_total_Promotion()
                                        ebook_total_Promotion()

                                        lblCheck_Pro_Use.Text = "1"
                                    Else
                                        lblMsg_Promotion.Text = "This promotion cannot be applied because no Book has been ordered."
                                        mdlPopUp_ConfirmCode_Promotion.Hide()
                                        mdlPopUp_Msg_Promotion.Show()
                                    End If
                                End If
                                If strCheckDigit = "3" Then
                                    in_branch_total_Promotion()
                                    jobber_total_Promotion()
                                    ebook_total_Promotion()

                                    lblCheck_Pro_Use.Text = "1"
                                End If

                                lbl_total_amount.Text = (CDbl(checkNullTo0(lbl_InBranch_total.Text)) + CDbl(checkNullTo0(lbl_jobber_total.Text)) + CDbl(checkNullTo0(lbl_ebook_total.Text))).ToString("#,###,##0.00")
                                lbl_total_amount_usd.Text = "(US$ " + bd.callUsd(lbl_total_amount.Text) + ")" ' convert bath to USD
                                lbl_grand_total.Text = (CDbl(checkNullTo0(Me.lbl_delivery_cost.Text)) + CDbl(checkNullTo0(Me.lbl_total_amount.Text))).ToString("#,###,##0.00")
                                lbl_grand_total_usd.Text = "(US$ " + bd.callUsd(lbl_grand_total.Text) + ")"
                            Else
                                lblCheck_Confirm_Code_Promotion.Text = "0"
                                lblChkData_Table_Promotion.Text = "0"

                                lblMsg_Promotion.Text = "Code is not correct. Please try again."
                                mdlPopUp_ConfirmCode_Promotion.Hide()
                                mdlPopUp_Msg_Promotion.Show()
                            End If
                        Else
                            lblCheck_Confirm_Code_Promotion.Text = "0"
                            lblChkData_Table_Promotion.Text = "0"

                            lblMsg_Promotion.Text = "Sorry. This code had been used already."
                            mdlPopUp_ConfirmCode_Promotion.Hide()
                            mdlPopUp_Msg_Promotion.Show()
                        End If
                    Else
                        'กรณีได้ Code มาจากหน้าร้าน
                        If clsPromotion.CheckDigisCode_Promotion_Cross(Right(strCode_Promotion, 1), strCode_Promotion.ToString.Trim) = True Then
                            lblChkData_Table_Promotion.Text = "0"
                            lblCheck_Confirm_Code_Promotion.Text = "1"
                            Dim strCheckDigit As String = ""
                            strCheckDigit = Right(strCode_Promotion, 1)

                            If strCheckDigit = "1" Then
                                If lblCheck_Digit.Text = "2" Or lblCheck_Digit.Text = "3" Then
                                    in_branch_total_Promotion()
                                    jobber_total_Promotion()
                                    ebook_total_Promotion()
                                Else
                                    lblMsg_Promotion.Text = "This promotion cannot be applied because no eBook has been ordered."
                                    mdlPopUp_ConfirmCode_Promotion.Hide()
                                    mdlPopUp_Msg_Promotion.Show()
                                End If
                            End If
                            If strCheckDigit = "2" Then
                                If lblCheck_Digit.Text = "1" Or lblCheck_Digit.Text = "3" Then
                                    in_branch_total_Promotion()
                                    jobber_total_Promotion()
                                    ebook_total_Promotion()
                                Else
                                    lblMsg_Promotion.Text = "This promotion cannot be applied because no Book has been ordered."
                                    mdlPopUp_ConfirmCode_Promotion.Hide()
                                    mdlPopUp_Msg_Promotion.Show()
                                End If
                            End If
                            If strCheckDigit = "3" Then
                                in_branch_total_Promotion()
                                jobber_total_Promotion()
                                ebook_total_Promotion()
                            End If

                            lbl_total_amount.Text = (CDbl(checkNullTo0(lbl_InBranch_total.Text)) + CDbl(checkNullTo0(lbl_jobber_total.Text)) + CDbl(checkNullTo0(lbl_ebook_total.Text))).ToString("#,###,##0.00")
                            lbl_total_amount_usd.Text = "(US$ " + bd.callUsd(lbl_total_amount.Text) + ")" ' convert bath to USD
                            lbl_grand_total.Text = (CDbl(checkNullTo0(Me.lbl_delivery_cost.Text)) + CDbl(checkNullTo0(Me.lbl_total_amount.Text))).ToString("#,###,##0.00")
                            lbl_grand_total_usd.Text = "(US$ " + bd.callUsd(lbl_grand_total.Text) + ")"

                        Else
                            lblCheck_Confirm_Code_Promotion.Text = "0"
                            lblChkData_Table_Promotion.Text = "0"

                            lblMsg_Promotion.Text = "Code is not correct. Please try again."
                            mdlPopUp_ConfirmCode_Promotion.Hide()
                            mdlPopUp_Msg_Promotion.Show()
                        End If

                    End If
                Else
                    lblCheck_Confirm_Code_Promotion.Text = "0"
                    lblChkData_Table_Promotion.Text = "0"

                    lblMsg_Promotion.Text = "Code is not correct. Please try again."
                    mdlPopUp_ConfirmCode_Promotion.Hide()
                    mdlPopUp_Msg_Promotion.Show()
                End If

            End If
        Else

            lblCheck_Confirm_Code_Promotion.Text = "1"
            lblChkData_Table_Promotion.Text = "0"

            lblMsg_Promotion.Text = "This promotion had been used already. It cannot be applied for this order."
            mdlPopUp_ConfirmCode_Promotion.Hide()
            mdlPopUp_Msg_Promotion.Show()

        End If
        

    End Sub

    Protected Sub btnCode_Promotion_Cross_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles btnCode_Promotion_Cross.Click
        Method_Payment()
    End Sub
    Private Sub in_branch_total_Promotion()
        Dim gr As DataGridItem
        Dim amount_Inbranch As Double = 0
        Dim amount_Inbranch_usd As Double = 0
        Dim amount_total As Double = 0
        Dim amount_total_usd As Double = 0
        Dim dt_CheckAB As New DataTable
        Dim strsql As String = ""

        For Each gr In In_Branch.Items
            Dim lbl_ISBN_Inbranch As Label = gr.FindControl("lbl_ISBN_Inbranch")
            Dim lbl_Amount_Inbranch As Label = gr.FindControl("lbl_Amount_Inbranch")
            Dim lbl_discount_Inbranch As Label = gr.FindControl("lbl_discount_Inbranch")
            Dim lbl_Weight_Inbranch As Label = gr.FindControl("lbl_Weight_Inbranch")
            Dim lbl_Amount_in_branch_usd As Label = gr.FindControl("lbl_Amount_in_branch_usd")

            strsql = ""
            strsql &= "  select [division code] as divison_code,a.isbn_13,discountflg ,isnull(b.[type],'') as [type]"
            strsql &= "  from tbm_asbkeo_bookab a left join tbm_AB_eCom_Discount_Extra b"
            strsql &= "  on a.isbn_13 = b.isbn_13 where a.isbn_13 = '" + lbl_ISBN_Inbranch.Text + "'"

            uCon = New uConnect
            dt_CheckAB.Clear()
            dt_CheckAB = uFunction.getDataTable(uCon.conn, strsql)

            If dt_CheckAB.Rows.Count > 0 Then
                Dim discountFlag_Inbranch As String = dt_CheckAB.Rows(0).Item("discountflg")
                Dim division_code As String = dt_CheckAB.Rows(0).Item("divison_code")
                Dim strComminson As String = dt_CheckAB.Rows(0).Item("type")

                If division_code = "NON-BOOK" Or strComminson = "CommingSoon" Or strComminson = "CommingSoon_nextweek" Then
                    amount_Inbranch = CDbl(lbl_Amount_Inbranch.Text)
                    amount_Inbranch_usd = bd.callUsd(amount_Inbranch) ' convert bath to USD

                    Dim strdiscount_in_branch As String = ""
                    strdiscount_in_branch = lbl_discount_Inbranch.Text
                    lbl_discount_Inbranch.Text = strdiscount_in_branch

                Else
                    amount_Inbranch = CDbl(lbl_Amount_Inbranch.Text) - (CDbl(lbl_Amount_Inbranch.Text) * 10 / 100)
                    amount_Inbranch_usd = bd.callUsd(amount_Inbranch) ' convert bath to USD

                    Dim strdiscount_in_branch As String = ""
                    strdiscount_in_branch = lbl_discount_Inbranch.Text & "% + 10"
                    lbl_discount_Inbranch.Text = strdiscount_in_branch

                End If
            End If

            ' input data in label
            lbl_Amount_Inbranch.Text = Convert.ToDouble(amount_Inbranch).ToString("#,###,##0.00")
            lbl_Amount_in_branch_usd.Text = "(US$ " + Convert.ToDouble(amount_Inbranch_usd).ToString("#,##0.00") + ")"

            Total_Weight += CDbl(lbl_Weight_Inbranch.Text)
            amount_total += amount_Inbranch
            amount_total_usd += amount_Inbranch_usd

        Next
        lbl_InBranch_total.Text = amount_total.ToString("#,###,##0.00")
        lbl_InBranch_total_usd.Text = "(US$ " + amount_total_usd.ToString("#,###,##0.00") + ")"
    End Sub

    Private Sub jobber_total_Promotion()
        Dim gr As DataGridItem
        Dim amount_jobber As Double = 0
        Dim amount_jobber_usd As Double = 0
        Dim Total_Weight As Double = 0
        Dim amount_total As Double = 0
        Dim amount_total_usd As Double = 0


        For Each gr In jobber.Items
            Dim lbl_Amount_jobber As Label = gr.FindControl("lbl_Amount_jobber")
            Dim lbl_Amount_jobber_usd As Label = gr.FindControl("lbl_Amount_jobber_usd")
            Dim lbl_ISBN_jobber As Label = gr.FindControl("lbl_ISBN_jobber")
            Dim lbl_discount_jobber As Label = gr.FindControl("lbl_discount_jobber")

            amount_jobber = CDbl(lbl_Amount_jobber.Text) - (CDbl(lbl_Amount_jobber.Text) * 10 / 100)
            amount_jobber_usd = bd.callUsd(amount_jobber) ' convert bath to USD

            Dim strdiscount_jobber As String = ""
            strdiscount_jobber = lbl_discount_jobber.Text & "% + 10"
            lbl_discount_jobber.Text = strdiscount_jobber

            lbl_Amount_jobber.Text = Convert.ToDouble(amount_jobber).ToString("#,###,##0.00")
            lbl_Amount_jobber_usd.Text = "(US$ " + Convert.ToDouble(amount_jobber_usd).ToString("#,##0.00") + ")"

            amount_total += amount_jobber
            amount_total_usd += amount_jobber_usd
        Next
        lbl_jobber_total.Text = amount_total.ToString("#,###,##0.00")
        lbl_jobber_total_usd.Text = "(US$ " + amount_total_usd.ToString("#,###,##0.00") + ")"
    End Sub

    Private Sub ebook_total_Promotion()
        Dim gr As DataGridItem
        Dim amount_ebook As Double = 0
        Dim amount_ebook_usd As Double = 0
        Dim amount_total As Double = 0
        Dim amount_total_usd As Double = 0

        For Each gr In ebook.Items()
            Dim lbl_ISBN_ebook As Label = gr.FindControl("lbl_ISBN_ebook")
            Dim lbl_Amount_ebook As Label = gr.FindControl("lbl_Amount_ebook")
            Dim lbl_Amount_ebook_usd As Label = gr.FindControl("lbl_Amount_ebook_usd")
            Dim lbl_discount_ebook As Label = gr.FindControl("lbl_discount_ebook")

            If lbl_Amount_ebook.Text <> "0" Then
                amount_ebook = CDbl(lbl_Amount_ebook.Text) - (CDbl(lbl_Amount_ebook.Text) * 10 / 100)
                'amount_ebook_usd = bd.callUsd(amount_ebook) ' convert bath to USD

                Dim strdiscount_ebook As String = ""
                If lbl_discount_ebook.Text = "0" Then
                    strdiscount_ebook = "10"
                Else
                    strdiscount_ebook = lbl_discount_ebook.Text & "% + 10"
                End If

                lbl_discount_ebook.Text = strdiscount_ebook

                lbl_Amount_ebook.Text = Convert.ToDouble(amount_ebook).ToString("#,###,##0.00")
                'lbl_Amount_ebook_usd.Text = "(US$ " + Convert.ToDouble(amount_ebook_usd).ToString("#,##0.00") + ")"
                Dim usd As String = bd.callUsd(amount_ebook).ToString
                lbl_Amount_ebook_usd.Text = "(US$ " + IIf(usd = "", 0, usd).ToString + ")"

                amount_total += amount_ebook
                amount_total_usd += amount_ebook_usd
            End If

        Next
        lbl_ebook_total.Text = amount_total.ToString("#,###,##0.00")
        lbl_ebook_total_usd.Text = "(US$ " + amount_total_usd.ToString("#,###,##0.00") + ")"

        uCon = New uConnect
        Dim dt_Promo_Discount As New DataTable
        dt_Promo_Discount = uFunction.getDataTable(uCon.conn, "select convert(decimal(8,0), discount) as discount from ebook_promotion WHERE status = 1 AND promotion = 1")
        If dt_Promo_Discount.Rows.Count > 0 Then
            Dim discount As Double = 0.0
            discount = CDbl(Session("original_total")) - CDbl(Session("amount_ebook"))
            Me.lblpromo_discount.Text = "Promotion Discount (" + dt_Promo_Discount.Rows(0).Item("discount").ToString + "%)"
            Me.lbldiscount.Text = discount.ToString("#,##0.00")
            If discount > 0 Then
                promo_discount = CDbl(dt_Promo_Discount.Rows(0).Item("discount").ToString)
                promo_discount_amount = discount
                Me.P_ebook_promo.Visible = True
            Else
                Me.P_ebook_promo.Visible = False
            End If
        Else
            Me.P_ebook_promo.Visible = False
        End If

    End Sub
End Class
