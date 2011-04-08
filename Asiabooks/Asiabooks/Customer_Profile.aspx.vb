Imports Eordering.BusinessLogic
Imports System.Web.UI
Imports System
Imports System.Data
Imports MycustomDG
Imports Eordering.BusinessLogic.PageControl
Imports Microsoft.VisualBasic
Imports System.Web.UI.ClientScriptManager1
Imports asiabooksmember.member
Imports System.IO
Imports KeiosLogic
Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.Shared

Partial Class Customer_Profile
    Inherits System.Web.UI.Page
    Dim Emember As New Member
    Dim dt_bs_person As DataTable
    Dim dt_bs_address As DataTable
    Dim dt As New DataTable
    Dim sno As Integer = 0
    Dim Co As New Cls_Customer_Order
    Private uCon As uConnect
    Private uClass As New uClass
    Dim PN As New PromptNow
    Private keios As uKeios
    Dim rpt As New ReportDocument

    Protected Sub Alert(ByVal Message As String)
        UI.ScriptManager.RegisterClientScriptBlock(Me.Page, Me.GetType, "Close", "alert('" + Message + "');", True)
    End Sub

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Me.Title = ConfigurationManager.AppSettings("SiteTitle").ToString & "Customer profile ::"
        Dim ds As New DataSet
        If Not Me.IsPostBack Then
            Dim strCatCode As String = ""
            strCatCode = Request.Cookies("myCookie_user")("CatCode")
            If strCatCode <> "" Then
                ucBooks1.cat_name = "Customer_Profile|" + strCatCode
            Else
                ucBooks1.Visible = False
            End If

            Dim dt_nothing As New DataTable
            Me.Datagrid.DataSource = dt_nothing
            Me.Datagrid.DataBind()

            Dim pcontrol As New PageControl
            Try

                If Not IsNothing(Request.Cookies("myCookie_user")) Then
                    BindDate_Keios()

                    Dim member_code As String = Request.Cookies("myCookie_user")("MemberCode")
                    Dim address As String = ""
                    ds = Emember.GetMember(member_code, "2", "ubKPwB6lD2fihnqJycW/TBHP5S9MYMJJ", "asiabooks_emember")

                    lblCustomer_Name.Text = ds.Tables("BS_PERSON").Rows(0).Item("NAME_EN").ToString
                    lblmember_code.Text = member_code
                    lblemail.Text = ds.Tables("BS_PERSON").Rows(0).Item("EMAIL_ADDRESS").ToString
                    lblName_Last.Text = ds.Tables("BS_PERSON").Rows(0).Item("NAME_EN").ToString + "  " + ds.Tables("BS_PERSON").Rows(0).Item("SURNAME_EN").ToString


                    Dim PLACE_NUMBER As String = ds.Tables("BS_ADDRESS").Rows(0).Item("PLACE_NUMBER").ToString()
                    Dim PLACE_NAME As String = ds.Tables("BS_ADDRESS").Rows(0).Item("PLACE_NAME").ToString()
                    Dim ROOM_NUMBER As String = ds.Tables("BS_ADDRESS").Rows(0).Item("ROOM_NUMBER").ToString()
                    Dim MOO As String = ds.Tables("BS_ADDRESS").Rows(0).Item("MOO").ToString()
                    Dim ALLEY As String = ds.Tables("BS_ADDRESS").Rows(0).Item("ALLEY").ToString()
                    Dim ROAD As String = ds.Tables("BS_ADDRESS").Rows(0).Item("ROAD").ToString()
                    Dim DISTRICT As String = ds.Tables("BS_ADDRESS").Rows(0).Item("DISTRICT").ToString()
                    Dim AMPHUR As String = ds.Tables("BS_ADDRESS").Rows(0).Item("AMPHUR").ToString()
                    Dim PROVINCE As String = ds.Tables("BS_ADDRESS").Rows(0).Item("PROVINCE").ToString()
                    Dim ZIPCODE As String = ds.Tables("BS_ADDRESS").Rows(0).Item("ZIPCODE").ToString()
                    Dim COUNTRY As String = ds.Tables("BS_ADDRESS").Rows(0).Item("COUNTRY").ToString()
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
                    If PROVINCE = "" And ZIPCODE = "" And COUNTRY = "" And DISTRICT = "" Then
                        address = "NO ADDRESS"
                    Else

                        address = PLACE_NUMBER + " " + PLACE_NAME + " " + ROOM_NUMBER + MOO + ALLEY + ROAD + DISTRICT + AMPHUR + PROVINCE + ZIPCODE + COUNTRY

                    End If

                    lbladdress.Text = address
                Else
                    Response.Redirect("My_Account.aspx")
                End If

            Catch ex As Exception
                ScriptManager.RegisterClientScriptBlock(Me.Page, Me.GetType, "Alert", _
                "alert('System Error!.,Please try again');", True)
                Exit Sub
            End Try
        End If
    End Sub
    Private Sub bindData()
        Dim startDate As String = uClass.SpritDate(Me.txtStartDate.Text)
        Dim strendDate As String = uClass.SpritDate(Me.txtEndDate.Text)
        Dim sqlCommand As String
        Dim condition As String = ""

        If txtOrder_No.Text <> "" Then
            condition &= " and Order_No='" + txtOrder_No.Text + "'"

        End If

        If txtStartDate.Text <> "" And txtEndDate.Text <> "" Then
            condition &= " and tbt_asbkeo_cus_order.Order_Date between '" + startDate + "' and '" + strendDate + "'"
        Else
            If txtStartDate.Text = "" And txtEndDate.Text <> "" Then
                Alert("กรุณากรอกวันที่เริ่มต้นด้วยค่ะ")
                Exit Sub
            End If
            If txtStartDate.Text <> "" And txtEndDate.Text = "" Then
                Alert("กรุณากรอกวันที่สิ้นสุดด้วยค่ะ")
                Exit Sub
            End If
            If rdio30day.Checked Then
                condition &= " and convert(datetime,tbt_asbkeo_cus_order.Order_Date) >= getdate()-30 "
            End If
            If rdio60day.Checked Then
                condition &= " and convert(datetime,tbt_asbkeo_cus_order.Order_Date) >= getdate()-60 "
            End If
            If rdio90day.Checked Then
                condition &= " and convert(datetime,tbt_asbkeo_cus_order.Order_Date) >= getdate()-90 "
            End If
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
        sqlCommand &= " ON tbt_asbkeo_cus_order.Sales_Channel_Code=tbm_syst_saleschannel.Sales_Channel_Code where tbt_asbkeo_cus_order.Member_Id = '" + Request.Cookies("myCookie_user")("MemberCode") + "' " + condition
        sqlCommand &= " ORDER BY  tbt_asbkeo_cus_order.order_date DESC ,tbt_asbkeo_cus_order.order_no DESC"

        Dim pcontrol As New PageControl
        Dim dt_nothing As New DataTable
        dt.Clear()

        uCon = New uConnect
        dt = uFunction.getDataTable(uCon.conn, sqlCommand)

        If dt.Rows.Count > 0 Then
            Me.Datagrid.DataSource = dt
            Me.Datagrid.DataBind()
            Datagrid.PagerStyle.Visible = True
            Datagrid.ShowFooter = False
            Me.Label_Result.Text = pcontrol.ShowingResultSet(Me.Datagrid.CurrentPageIndex, Me.Datagrid.PageSize, dt.Rows.Count)

        Else
            Me.Datagrid.DataSource = dt_nothing
            Me.Datagrid.DataBind()
            Datagrid.PagerStyle.Visible = False
            Datagrid.ShowFooter = True
            Me.Label_Result.Text = pcontrol.ShowingResultSet(Me.Datagrid.CurrentPageIndex, Me.Datagrid.PageSize, dt_nothing.Rows.Count)

        End If


    End Sub
    Private Function UpdateMyEBooks(ByVal order_no As String, ByVal orderdtl_no As String, ByVal available_group_id As String) As Boolean
        uCon = New uConnect
        Dim strsql As String = ""
        Dim _strQuery As New StringBuilder
        Dim payment As String = ""

        If available_group_id = "4" Then
            Dim SqlStr As String = ""
            SqlStr = "select a.ebookid, a.isbn, a.orderqty, convert(decimal(8,2),a.Amount) as Amount, convert(numeric(18,2),a.Unitprice) as Unitprice, a.Is_EB_Order_Placed, c.Member_Id, c.Email, c.payment_method_code as payment, c.customer_country, e.sku_13, e.book_title, e.supplier_code, e.format_type "
            SqlStr &= "from tbt_asbkeo_cus_orderdtl a "
            SqlStr &= "inner join tbt_asbkeo_cus_order c on a.order_no = c.order_no "
            SqlStr &= "left join ebook_store e on a.ebookid = e.bookid "
            SqlStr &= "where a.order_no = '" & order_no & "' and a.orderdtl_no = '" & orderdtl_no & "' and a.available_group_id = '" & available_group_id & "' "

            Dim dt_ebook As DataTable = uFunction.getDataTable(uCon.conn, SqlStr)
            If dt_ebook.Rows.Count > 0 Then
                payment = dt_ebook.Rows(0).Item("payment").ToString

                If payment = "CS001" Or payment = "TF001" Or payment = "KE001" Then
                    If dt_ebook.Rows(0).Item("Is_EB_Order_Placed").ToString <> "Y" Then

                        Dim sqlDb As New SqlDb
                        Try
                            sqlDb.BeginTrans()

                            Dim Download_URL As String = ""

                            For j As Integer = 1 To CInt(dt_ebook.Rows(0).Item("orderqty"))

                                If dt_ebook.Rows(0).Item("supplier_code").ToString.Trim.ToLower.Equals("gardners") Then
                                    Download_URL = PN.GetGardnersDownloadURL(dt_ebook.Rows(0).Item("sku_13"), dt_ebook.Rows(0).Item("ebookid"), orderdtl_no, j, dt_ebook.Rows(0).Item("format_type"), dt_ebook.Rows(0).Item("customer_country"), order_no)
                                ElseIf dt_ebook.Rows(0).Item("supplier_code").ToString.Trim.ToLower.Equals("ingram") Then
                                    Download_URL = PN.GetIngramDownloadURL(dt_ebook.Rows(0).Item("sku_13"), dt_ebook.Rows(0).Item("ebookid"), orderdtl_no, j, order_no, dt_ebook.Rows(0).Item("customer_country"))
                                End If

                                Dim OrderNoTx As String = order_no & orderdtl_no & j

                                _strQuery = New StringBuilder
                                _strQuery.Append("insert into [ebook_mylist] ")
                                _strQuery.Append("([Order_No],[Order_No_Tx],[EBookID],[ISBN],[SKU],[Format_Type],[Supplier_Code],[Member_Id],[Download_URL],[Downloaded_Times],[Enabled_Status],[Tx_Date],[Selling_Price],[Is_Void],[Country_Code],[Is_Free],[IP]) ")
                                _strQuery.Append("values ")
                                _strQuery.Append("('" & order_no & "'")
                                _strQuery.Append(",'" & OrderNoTx & "'")
                                _strQuery.Append(",'" & dt_ebook.Rows(0).Item("ebookid") & "'")
                                _strQuery.Append(",'" & dt_ebook.Rows(0).Item("isbn") & "'")
                                _strQuery.Append(",'" & dt_ebook.Rows(0).Item("sku_13") & "'")
                                _strQuery.Append("," & dt_ebook.Rows(0).Item("format_type"))
                                _strQuery.Append(",'" & dt_ebook.Rows(0).Item("supplier_code") & "'")
                                _strQuery.Append(",'" & dt_ebook.Rows(0).Item("Member_Id") & "'")
                                _strQuery.Append(",'" & Download_URL & "'")
                                _strQuery.Append(",'0'")
                                _strQuery.Append(",'Y'")
                                _strQuery.Append(",getdate()")
                                _strQuery.Append("," & dt_ebook.Rows(0).Item("Unitprice"))
                                _strQuery.Append(",'" & IIf(Download_URL = "", "N", "").ToString & "'")
                                _strQuery.Append(",'" & dt_ebook.Rows(0).Item("customer_country") & "'")
                                _strQuery.Append(",'" & IIf(CDbl(dt_ebook.Rows(0).Item("Amount").ToString) = 0, "Y", "N").ToString & "'")
                                _strQuery.Append(",'" + Request.ServerVariables("REMOTE_ADDR") + "')")
                                sqlDb.Exec(_strQuery.ToString)

                                If Download_URL = "" Then
                                    'Dim mailMessage As System.Web.Mail.MailMessage = New System.Web.Mail.MailMessage
                                    Dim _mail As New StringBuilder

                                    Dim br As String = "<br />"
                                    _mail.Append("Dear Customer, " & br & br)
                                    _mail.Append("Kindly note the download link of your eBook order no." & order_no & " (ISBN : " & dt_ebook.Rows(0).Item("isbn") & ", " & dt_ebook.Rows(0).Item("book_title") & ") cannot be provided. Please contact the system administrator." & br)
                                    _mail.Append("Thank you." & br & br)

                                    _mail.Append("Best regards," & br & br)
                                    _mail.Append("eCommerce Team" & br & br & br)
                                    _mail.Append("ASIA BOOKS CO., LTD." & br)
                                    _mail.Append("65/66, 65/70 Chamnan Phenjati Business Center 7th Floor," & br)
                                    _mail.Append("Rama 9, Huaykwang, Bangkok 10320" & br)
                                    _mail.Append("Tel:  0-2715-9000 ext. 8101, 8104" & br)

                                    Try
                                        'mailMessage.To = dt_ebook.Rows(0).Item("Email")
                                        'mailMessage.From = "eCommerce@asiabooks.com"
                                        'mailMessage.Cc = "eCommerce@asiabooks.com,porntip_m@asiabooks.com,aunnop_k@asiabooks.com,jirathep@promptnow.com,phamorn@promptnow.com"
                                        'mailMessage.Subject = "Your eBook order with Asia Books CO.,LTD Ref. No." + order_no + " (ISBN : " + dt_ebook.Rows(0).Item("isbn") + ") cannot be provided."

                                        'mailMessage.BodyFormat = System.Web.Mail.MailFormat.Html
                                        'mailMessage.Body = _mail.ToString

                                        'System.Web.Mail.SmtpMail.SmtpServer = SmtpMail
                                        'mailMessage.Fields.Add("http://schemas.microsoft.com/cdo/configuration/smtpauthenticate", "1")
                                        'mailMessage.Fields.Add("http://schemas.microsoft.com/cdo/configuration/sendusername", "eOrdering@asiabooks.com")
                                        'mailMessage.Fields.Add("http://schemas.microsoft.com/cdo/configuration/sendpassword", "abs999.")

                                        'System.Web.Mail.SmtpMail.Send(mailMessage)

                                        Dim strMailTO As String = dt_ebook.Rows(0).Item("Email")
                                        Dim strMailCC As String = "eCommerce@asiabooks.com,porntip_m@asiabooks.com,aunnop_k@asiabooks.com,jirathep@promptnow.com,phamorn@promptnow.com"
                                        Dim strMailSubject As String = "Your eBook order with Asia Books CO.,LTD Ref. No." + order_no + " (ISBN : " + dt_ebook.Rows(0).Item("isbn") + ") cannot be provided."
                                        Dim strMailBody As String = _mail.ToString
                                        uClass.SendMail(strMailTO, strMailCC, strMailSubject, strMailBody, "")


                                    Catch ex As Exception
                                        GenerateLog("EmailToGardners(My_Ebook2_Popup)", "", "", order_no, "", "", "http://www.asiabooks.com", "", ex.Message.ToString + " " + ex.GetBaseException.ToString)
                                    End Try
                                End If
                            Next

                            _strQuery = New StringBuilder
                            _strQuery.Append("UPDATE tbt_asbkeo_cus_orderdtl SET ")
                            _strQuery.Append("Is_EB_Order_Placed = 'Y' ")
                            _strQuery.Append("WHERE Order_No = '" & order_no & "' and Orderdtl_No = '" & orderdtl_no & "' and Available_Group_Id = '" & available_group_id & "'")
                            sqlDb.Exec(_strQuery.ToString)

                            sqlDb.CommitTrans()
                            Return True
                        Catch ex As Exception
                            sqlDb.RollbackTrans()
                            Return False
                            GenerateLog("BO_UpdateMyEBooks", "", "", order_no, "", "", "http://www.asiabooks.com", "", ex.Message.ToString)
                        End Try
                    End If
                End If
            End If
        End If
    End Function
    Public Function GenerateLog(ByVal CallFunation As String, ByVal CallServiceURL As String, ByVal IPAddress As String, ByVal DocumrntNo As String, ByVal MemberNo As String, ByVal Amount As String, ByVal ResultURL As String, ByVal TanksURL As String, ByVal Description As String) As Boolean
        Try
            Dim StrPath As String = Server.MapPath("Log File").ToString & "\"
            Dim StrFileName As String = "Log_BO_" & Format(Now, "yyyyMMdd") & ".txt"
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
            StrValue.Append("; TanksURL ")
            StrValue.Append(TanksURL)
            StrValue.Append("; Description ")
            StrValue.Append(Description)
            StrValue.Append(";")

            CollectionWrite(StrPath, StrFileName, StrValue.ToString)

            Return True

        Catch ex As Exception
            Throw ex
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
    Private Sub BindDate_Keios()
        Dim dt As New DataTable
        Dim strSql As String = ""
        strSql &= " SELECT distinct a.Order_no,a.Keios_Post"
        strSql &= " ,convert(varchar(10),a.Order_Date,103) as Order_Date "
        strSql &= " ,a.Customer_Name+' '+a.Last_Name as Customer_Name, Grand_Total "
        strSql &= " ,a.Sales_Channel_Code,tbm_syst_organizeab.Org_AB_Name "
        strSql &= " ,a.Grand_Total,a.Member_Id ,a.Transport_Type "
        strSql &= " FROM tbt_asbkeo_cus_orderdtl b inner join tbt_asbkeo_cus_order a "
        strSql &= " ON a.order_no = b.order_no LEFT JOIN tbm_syst_organizeab "
        strSql &= " ON a.Address_Org_Ab=tbm_syst_organizeab.Org_AB_code "
        strSql &= " where a.Member_Id = '" + Request.Cookies("myCookie_user")("MemberCode") + "'"
        strSql &= " and isnull(a.Keios_Send_WS,'') <> '' and isnull(a.Keios_Post,'') <> '' and b.order_status = 1"

        uCon = New uConnect
        dt = uFunction.getDataTable(uCon.conn, strSql)
        If dt.Rows.Count > 0 Then
            Panel_Keios.Visible = True
            Datagrid_Keios.DataSource = dt
            Datagrid_Keios.DataBind()

        Else
            Panel_Keios.Visible = False
        End If

    End Sub
    Protected Sub btnSave_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles btnSave.Click
        uCon = New uConnect
        Dim dt As New DataTable
        Dim strSql As String = ""
        keios = New KeiosLogic.uKeios
        Dim strOrderNO As String = Left(lblOrdert_No.Text, 6) & Right(lblOrdert_No.Text, 4)

        If keios.ConfirmPOSToEcom(txtKeios.Text, strOrderNO) = True Then
            uFunction.ExecuteDataStringNonTran(uCon.conn, "update tbt_asbkeo_cus_orderdtl set order_status = 2 where order_no = '" + lblOrdert_No.Text + "'")
            uFunction.ExecuteDataStringNonTran(uCon.conn, "update tbt_asbkeo_cus_order set Keios_Confirm_Post = '" + txtKeios.Text + "' where order_no = '" + lblOrdert_No.Text + "'")
            dt.Clear()
            dt = uFunction.getDataTable(uCon.conn, "select * from tbt_asbkeo_cus_orderdtl where order_no = '" + lblOrdert_No.Text + "'")

            lblChkeBook.Text = "0"
            lblMsgOrder_No.Text = strOrderNO
            For i As Integer = 0 To dt.Rows.Count - 1
                If dt.Rows(i).Item("Available_Group_Id").ToString = "4" Then
                    If UpdateMyEBooks(lblOrdert_No.Text, dt.Rows(i).Item("Orderdtl_No").ToString, dt.Rows(i).Item("Available_Group_Id").ToString) = True Then
                        lblChkeBook.Text = "1"
                    Else

                    End If
                End If
            Next

            mdlPopUp_Keios.Hide()
            mdlPopUp_Msg.Show()

        Else
            mdlPopUp_Keios.Hide()
            mdlPopUp_MsgError.Show()
            'ScriptManager.RegisterClientScriptBlock(Me.Page, Me.GetType, "Alert", "alert('Keios not found');", True)
            'Exit Sub
        End If

    End Sub
    Private Sub SendMail_Invoid(ByVal order_no As String)
        uCon = New uConnect
        Dim strsql As String = ""
        Dim _strQuery As New StringBuilder
        Dim _mail As New StringBuilder

        order_no = lblOrdert_No.Text
        _strQuery = New StringBuilder

        _strQuery.Append("select distinct a.isbn, e.sku_13, b.isbn_13, a.EBookID, a.orderdtl_no, a.Available_Group_Id, isnull(b.book_title, e.book_title) as book_title, isnull(b.Author, e.Author) as Author, a.order_no, a.order_status, convert(decimal(20,2),a.Amount) as Amount, a.orderqty, c.customer_name, c.last_name, ")
        _strQuery.Append("a.Status_LeadTime as leadtime,d.Payment_method_Name,c.Billing_Address,a.Book_Title_Report,convert(numeric(20,2),a.Unitprice) as Unitprice, c.field1 AS PickUP, ")
        _strQuery.Append("case c.payment_method_code when 'CR001' then 'Credit Card' when 'CS001' then 'Counter Service' when 'TF001' then 'Transfer Through Commercial  Bank Account' when 'PP001' then 'PayPal' when 'KE001' then 'Pay at Shop' end as payment ")
        _strQuery.Append(",c.telephone,c.transport_type, c.field2 as branch ,c.ship_to_address , convert(nvarchar,c.adddt,100) as order_date,c.field4 as mailbranch ")
        _strQuery.Append(",c.delivery_cost,c.grand_total,c.transport_type,c.Email,c.customer_name+'  '+ c.last_name as CusName_Lastname, c.Ship_To_Name, c.Billing_Name ")
        _strQuery.Append(",convert(decimal(8,0),c.Promo_Discount) as Promo_Discount, convert(decimal(20,2),c.Promo_Discount_Amount) as Promo_Discount_Amount ")
        _strQuery.Append(",case c.Transport_Type when 'PICK UP AT BRANCH' then 'Pick up at ' +c.field2+' ('+(c.field1)+')' else 'Home' end as Deliver_To ")
        _strQuery.Append("from tbt_asbkeo_cus_orderdtl a left join dbo.tbt_jobber_book_search b on a.isbn = b.isbn_13 ")
        _strQuery.Append("left join dbo.ebook_store e on a.ebookid = e.bookid ")
        _strQuery.Append("inner join tbt_asbkeo_cus_order c on a.order_no = c.order_no inner join tbm_syst_Paymentmethod d ")
        _strQuery.Append("on c.Payment_Method_Code = d.Payment_Method_Code ")
        _strQuery.Append("where c.order_no = '" + order_no + "' order by a.Available_Group_Id,a.orderdtl_no")

        Dim dt As New DataTable

        dt = uFunction.getDataTable(uCon.conn, _strQuery.ToString)

        Dim strPayment_Name As String = ""
        Dim strMailTo As String = ""

        Dim myExportFile As String
        'Dim myReport As New Individuals_Productivity_and_Overall_Attendance()
        Dim strpath As String = ""
        strpath = "~\Report\File\" + order_no + ".pdf"
        myExportFile = Server.MapPath(strpath)

        Dim fFile As New FileInfo(myExportFile)
        If Not fFile.Exists Then
            rpt.Load(Server.MapPath("~\Report\rpt_Invoid_Customer.rpt"))
            rpt.SetDataSource(dt)

            Dim myExportOptions As CrystalDecisions.Shared.ExportOptions
            Dim myDiskFileDestinationOptions As CrystalDecisions.Shared.DiskFileDestinationOptions

            myDiskFileDestinationOptions = New CrystalDecisions.Shared.DiskFileDestinationOptions()
            myDiskFileDestinationOptions.DiskFileName = myExportFile
            myExportOptions = rpt.ExportOptions
            With myExportOptions
                .DestinationOptions = myDiskFileDestinationOptions
                .ExportDestinationType = .ExportDestinationType.DiskFile
                .ExportFormatType = .ExportFormatType.PortableDocFormat
            End With

            rpt.Export()
        End If

        With dt
            _mail.Append("<table WIDTH='720' border='0' align='center'  cellpadding='0' cellspacing='0'>")
            _mail.Append("<tr>")
            _mail.Append("<td width='20'><img src='https://www.asiabooks.com/images/payment/top_left.jpg' width='20' height='103' /></td>")
            _mail.Append("<td background='https://www.asiabooks.com/images/payment/bg_top.jpg'><img src='https://www.asiabooks.com/images/payment/logo.jpg' width='321' height='103' /></td>")
            _mail.Append("<td width='20'><img src='https://www.asiabooks.com/images/payment/top_right.jpg' width='20' height='103' /></td>")
            _mail.Append("</tr>")
            _mail.Append("<tr>")
            _mail.Append("<td background='https://www.asiabooks.com/images/payment/left.gif'></td>")
            _mail.Append("<td style='width: 510px;' valign='top'>")

            _mail.Append("<table width='720' border='0' style='font-size: 10pt; font-family: Arial'>")
            _mail.Append("<tr><td style='height: 32px; font-weight: bold; color: #000099;'>Dear Customer,</td></tr>")

            If .Select("isbn_13 IS NOT NULL").Length > 0 Then
                _mail.Append("<tr><td style='height: 32px; font-weight: bold; color: #000099;'>")
                If .Rows(0).Item("transport_type").ToString = "EMS" Then
                    _mail.Append("Your payment has been received and your order no." + order_no + "  is already on process. Our staffs will contact to inform the delivery tracking number of books when we dispatch.")
                ElseIf InStr(.Rows(0).Item("branch").ToString.ToUpper, "BRANCH") Then
                    _mail.Append("Your payment has been received and your order no." + order_no + "  is already on process. Our staffs will contact to inform you when the book arrives. ")
                Else
                    _mail.Append("Your payment has been received and your order no." + order_no + "  is already on process.")
                End If
                _mail.Append("</td></tr>")

                If .Select("EBookID IS NOT NULL").Length > 0 Then
                    _mail.Append("<tr><td style='height: 32px; font-weight: bold; color: #000099;'>")
                    _mail.Append("On the other hand, your eBooks is ready to be downloaded on <a href='" + ConfigurationManager.AppSettings("AB_MyEBook") + "'>MY EBOOK</a> page. (Kindly click and further download)")
                    _mail.Append("</td></tr>")
                End If
            Else
                If .Select("EBookID IS NOT NULL").Length > 0 Then
                    _mail.Append("<tr><td style='height: 32px; font-weight: bold; color: #000099;'>")
                    _mail.Append("Your payment has been received and your order no." + order_no + " is now ready to be downloaded on <a href='" + ConfigurationManager.AppSettings("AB_MyEBook") + "'>MY EBOOK</a> page. (Please click and further download)")
                    _mail.Append("</td></tr>")
                End If
            End If

            _mail.Append("<tr><td style='height: 32px; font-weight: bold; color: #000099;'>Please find the receipt as attached.</td></tr>")
            _mail.Append("<tr><td style='height: 32px; font-weight: bold; color: #000099;'>Order detail :</td></tr>")
            _mail.Append("<tr><td><table width='720' bordercolor='#666666' border='1' cellpadding='0' cellspacing='0' style='font-size: 10pt; font-family: Arial'>")
            _mail.Append("<tr><td style='color:#339933; width: 10%; font-style: normal; font-weight: bold; height: 18px;' align='center'>ISBN</td>")
            _mail.Append("<td style='color:#339933; width: 18%; font-style: normal; font-weight: bold; height: 18px;' align='center'>Tile</td>")
            _mail.Append("<td style='color:#339933; width: 10%; font-style: normal; font-weight: bold; height: 18px;' align='center'>Author</td>")
            _mail.Append("<td style='color:#339933; width: 8%; font-style: normal; font-weight: bold; height: 18px;' align='center'>Ref</td>")
            _mail.Append("<td style='color:#339933; width: 3%; font-style: normal; font-weight: bold; height: 18px;' align='center'>Qty</td>")
            _mail.Append("<td style='color:#339933; width: 7%; font-style: normal; font-weight: bold; height: 18px;' align='center'>Price</td>")
            _mail.Append("<td style='color:#339933; width: 10%; font-style: normal; font-weight: bold; height: 18px;' align='center'>Status</td></tr>")
            For i As Integer = 0 To .Rows.Count - 1
                _mail.Append("<tr><td align='center' style='width: 10%'>").Append(.Rows(i).Item("isbn").ToString).Append("</td>")
                _mail.Append("<td align='left' style='width: 18%'>&nbsp;").Append(.Rows(i).Item("book_title").ToString).Append("</td>")
                _mail.Append("<td align='left' style='width: 10%'>&nbsp;").Append(.Rows(i).Item("Author").ToString).Append("</td>")
                _mail.Append("<td align='left' style='width: 8%'>&nbsp;").Append(.Rows(i).Item("order_no").ToString).Append("</td>")
                _mail.Append("<td align='center' style='width: 3%'>").Append(.Rows(i).Item("orderqty").ToString).Append("</td>")
                _mail.Append("<td align='center' style='width: 7%'>").Append(CDbl(.Rows(i).Item("Amount").ToString).ToString("#,###,##0.00")).Append("</td>")


                If .Rows(i).Item("EBookID").ToString <> "" Then

                    If .Rows(i).Item("order_status").ToString = "7" Then
                        _mail.Append("<td align='center' style='width: 10%;'><span style='color: red'>Unsaleable eBook due to rights restricted. Our staff will contact you to refund the money soon.</span></td></tr>")
                    Else
                        _mail.Append("<td align='center' style='width: 10%'>eBook</td></tr>")
                    End If

                Else
                    _mail.Append("<td align='center' style='width: 10%'>").Append(.Rows(i).Item("leadtime").ToString).Append("</td></tr>")
                End If

            Next
            _mail.Append("<tr><td align='center' style='width: 10%'>&nbsp;</td>")
            _mail.Append("<td align='left' style='width: 18%'>&nbsp;</td>")
            _mail.Append("<td align='left' style='width: 10%'>&nbsp;</td>")
            _mail.Append("<td align='left' style='width: 8%'>&nbsp;</td>")
            _mail.Append("<td align='center' style='width: 3%'>&nbsp;</td>")
            _mail.Append("<td align='center' style='width: 7%'>&nbsp;</td>")
            _mail.Append("<td align='center' style='width: 10%'>&nbsp;</td></tr>")

            _mail.Append("<tr><td colspan='5' style='font-weight: bold; text-align: right'>Delivery Cost&nbsp;</td>")
            _mail.Append("<td align='center' style='width: 7%'>").Append(.Rows(0).Item("delivery_cost").ToString).Append("</td>")
            _mail.Append("<td align='left' style='width: 10%'>&nbsp;BAHT</td></tr>")

            If Not .Rows(0).Item("Promo_Discount_Amount") Is Nothing And .Rows(0).Item("Promo_Discount_Amount").ToString <> "" Then
                If CDbl(.Rows(0).Item("Promo_Discount_Amount").ToString) > 0 Then

                    _mail.Append("<tr><td colspan='5' style='font-weight: bold; text-align: right'>Promotion Discount" + " (" + .Rows(0).Item("Promo_Discount").ToString + "%)&nbsp;</td>")
                    _mail.Append("<td align='center' style='width: 7%'>").Append(.Rows(0).Item("Promo_Discount_Amount").ToString).Append("</td>")
                    _mail.Append("<td align='left' style='width: 10%'>&nbsp;BAHT</td></tr>")

                End If
            End If

            _mail.Append("<tr><td colspan='5' style='font-weight: bold; text-align: right'>Total&nbsp;</td>")
            _mail.Append("<td align='center' style='width: 7%'>").Append(CDbl(.Rows(0).Item("grand_total").ToString).ToString("#,###,##0.00")).Append("</td>")
            _mail.Append("<td align='left' style='width: 10%'>&nbsp;BAHT</td></tr>")
            _mail.Append("</table></td></tr>")
            _mail.Append("<td>&nbsp;</td></tr><tr>")
            If .Rows(0).Item("transport_type").ToString.ToUpper = "PICK UP AT BRANCH" Then
                _mail.Append("<td>Pick up at branch : ").Append(.Rows(0).Item("branch").ToString).Append("</td></tr><tr>")
            Else
                _mail.Append("<td>Home Delivery </td></tr><tr>")
            End If

            _mail.Append("<td>Paid by (payment method) : ").Append(.Rows(0).Item("payment").ToString).Append("</td></tr><tr>")
            _mail.Append("<td>Reference : ").Append(.Rows(0).Item("order_no").ToString).Append("</td></tr><tr>")
            _mail.Append("<td>&nbsp;</td></tr><tr>")
            _mail.Append("<td>&nbsp;</td></tr><tr>")
            _mail.Append("<td>Customer Name : ").Append(Replace(.Rows(0).Item("customer_name").ToString, "[MEMBER]", " ")).Append("   ").Append(.Rows(0).Item("last_name").ToString).Append("</td></tr><tr>")
            _mail.Append("<td>Tel : ").Append(.Rows(0).Item("telephone").ToString).Append("</td></tr><tr>")
            _mail.Append("<td>E-Mail : ").Append(.Rows(0).Item("Email").ToString).Append("</td></tr><tr>")
            _mail.Append("<td>Address : ").Append(.Rows(0).Item("ship_to_address").ToString).Append("</td></tr><tr>")
            _mail.Append("<td>&nbsp;</td></tr>")
            _mail.Append("<tr><td>&nbsp;</td></tr>")
            _mail.Append("<tr><td>Yours sincerely,</td></tr>")
            _mail.Append("<tr><td>&nbsp;</td></tr>")
            _mail.Append("<tr><td>Customer Service</td></tr>")
            _mail.Append("<tr><td>Asia Books Co., Ltd.</td></tr></table>")

            _mail.Append("<td background='https://www.asiabooks.com/images/payment/right.gif'>&nbsp;</td>")
            _mail.Append("</tr>")
            _mail.Append("<tr>")
            _mail.Append("<td><img src='https://www.asiabooks.com/images/payment/bottom_left.jpg' width='20' height='80' /></td>")
            _mail.Append("<td align='center' bgcolor='#73B017' ")
            _mail.Append("style='color: #FFFFFF; font-weight: bold; FONT-FAMILY: Tahoma; font-size: 10pt;'>Asia ")
            _mail.Append("Books Co.,ltd 65/66,65/70 Chamnan Phenjati Business Center 7th Floor,<br />")
            _mail.Append("Rama 9 road Huaykwang, Huaykwang, Bangkok 10320 Thailand<br />")
            _mail.Append("Customer Service Tel : (662) 715-9000 Fax : (662) 715-9197 www.asiabooks.com</td>")
            _mail.Append("<td><img src='https://www.asiabooks.com/images/payment/bottom_right.jpg' width='20' height='80' /></td>")
            _mail.Append("</tr>")
            _mail.Append("</table>")


            strMailTo = .Rows(0).Item("Email").ToString
            strPayment_Name = .Rows(0).Item("payment").ToString

        End With

        Try

            Dim strAttchment As String = Server.MapPath("~\Report\File\" + order_no + ".pdf")
            Dim strMailCC As String = "eCommerce@asiabooks.com,porntip_m@asiabooks.com,aunnop_k@asiabooks.com"
            Dim strSubject As String = "Your order with Asia Books CO.,LTD ref. : " + order_no + " (Payment By : " + strPayment_Name + ")"
            Dim strBody As String = _mail.ToString

            uClass.SendMail(strMailTo, strMailCC, strSubject, strBody, strAttchment)

        Catch ex As Exception
            GenerateLog("BO_SendMail_Invoid", "", "", order_no, "", "", "https://www.asiabooks.com", "", ex.Message.ToString)
            Try

                Dim strMailCC As String = "porntip_m@asiabooks.com,aunnop_k@asiabooks.com"
                Dim strSubject As String = "Your order with Asia Books CO.,LTD ref. : " + order_no
                Dim strBody As String = _mail.ToString

                uClass.SendMail("eCommerce@asiabooks.com", strMailCC, strSubject, strBody, "")


            Catch ex2 As Exception
                GenerateLog("BO_SendMail_Invoid2", "", "", order_no, "", "", "https://www.asiabooks.com", "", ex2.Message.ToString)
            End Try
        End Try

    End Sub
    Protected Sub Datagrid_Keios_EditCommand(ByVal source As Object, ByVal e As System.Web.UI.WebControls.DataGridCommandEventArgs) Handles Datagrid_Keios.EditCommand
        If e.CommandName.ToString = "Edit" Then
            Dim lbl_OrderNo_Keiod As Label = e.Item.FindControl("lbl_OrderNo_Keiod")
            Dim imgupdate_keios As ImageButton = e.Item.FindControl("imgupdate_keios")

            imgupdate_keios.CommandArgument = e.CommandArgument.ToString()
            lblOrdert_No.Text = e.CommandArgument.ToString()

            mdlPopUp_Keios.Show()
        End If
    End Sub

    Protected Sub Datagrid_Keios_PageIndexChanged(ByVal source As Object, ByVal e As System.Web.UI.WebControls.DataGridPageChangedEventArgs) Handles Datagrid_Keios.PageIndexChanged
        Me.Datagrid_Keios.CurrentPageIndex = e.NewPageIndex
        Me.BindDate_Keios()
    End Sub

    Protected Sub btnCancel1_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles btnCancel1.Click
        If lblChkeBook.Text = "1" Then
            mdlPopUp_Msg.Hide()
            SendMail_Invoid(lblOrdert_No.Text)
            Response.Redirect("My_Ebook.aspx")
        Else
            mdlPopUp_Msg.Hide()
            SendMail_Invoid(lblOrdert_No.Text)
            BindDate_Keios()
        End If

    End Sub

    Protected Sub btnCancel2_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles btnCancel2.Click
        mdlPopUp_MsgError.Hide()
        mdlPopUp_Keios.Show()
    End Sub

    Protected Sub btnEdit_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles btnEdit.Click
        Response.Redirect("Customer_Profile_Edit.aspx?action=Edit&MEMBER_CODE=" + lblmember_code.Text)
    End Sub

    Protected Sub btnView_Detail_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles btnView_Detail.Click
        Response.Redirect("Customer_Tran_Buy_Books.aspx")
    End Sub

    Protected Sub Datagrid_EditCommand(ByVal source As Object, ByVal e As System.Web.UI.WebControls.DataGridCommandEventArgs) Handles Datagrid.EditCommand
        If e.CommandName.ToString = "Edit" Then
            Dim lbl_Sales_Channel_Code As Label = e.Item.FindControl("lbl_Sales_Channel_Code")
            Response.Redirect("Customer_Order_Tracking_Internet.aspx?action=Edit&Order_NO=" + e.CommandArgument.ToString())

        End If
    End Sub

    Protected Sub Datagrid_PageIndexChanged(ByVal source As Object, ByVal e As System.Web.UI.WebControls.DataGridPageChangedEventArgs) Handles Datagrid.PageIndexChanged
        Me.Datagrid.CurrentPageIndex = e.NewPageIndex
        Me.bindData()
    End Sub

    Protected Sub b_search_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles b_search.Click
        Me.bindData()
    End Sub
End Class
