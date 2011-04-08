Imports Eordering.BusinessLogic
Imports System
Imports System.Data
Imports System.IO
Imports System.Text
Imports System.Web.Mail
Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.Shared

Partial Class Payment_Realtime
    Inherits System.Web.UI.Page
    Dim PaymentService As New ws_payment.paymentservice.PaymentService
    Dim ws_Send_SMS As New Send_SMS.Send_SMS
    Dim Url As String
    Dim uCon As uConnect
    Dim SmtpMail As String = Convert.ToString(ConfigurationSettings.AppSettings("SmtpServer"))
    Dim rpt As New ReportDocument
    Dim PN As New PromptNow
    Private uClass As New uClass

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        Dim TransCode As String = ""
        Dim ResponseCode As String = ""
        Dim Reference As String = ""
        Dim Reference2 As String = ""
        Dim Reference3 As String = ""
        Dim Authorize As String = ""
        Dim UAID As String = ""
        Dim Invoice As String = ""
        Dim Timestamp As String = ""
        Dim Amount As String = ""
        Dim Checksum As String = ""
        Dim CardType As String = ""
        Dim ChecksumCard2 As String = ""
        Dim CC_Country As String = ""

        'If Not IsPostBack Then
        'Url = PaymentService.Payment_KBank("00000031000727000005XXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXX09082800000212092005140410000000150099XXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXKBANKCARDXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXX")

        'Url = PaymentService.Payment_KBank(Request.Form("PMGWRESP"))
        'Url = PaymentService.Payment_KBank_Not_SSL(Request.Form("HOSTRESP").ToString, _
        'Request.Form("REFCODE").ToString, Request.Form("AUTHCODE").ToString, _
        'Request.Form("RETURNINV").ToString, Request.Form("UAID").ToString, _
        'Request.Form("CARDNUMBER").ToString, Request.Form("AMOUNT").ToString, _
        'Request.Form("FILLSPACE").ToString)

        'Response.Redirect(Url)

        If Not IsPostBack Then

            If Not Request.Form("PMGWRESP2") Is Nothing And Request.Form("PMGWRESP2") <> "" Then
                Dim PMGWRESP2 As String = Request.Form("PMGWRESP2").ToString

                GenerateLog("Mail_Payment_PMGWRESP2", "", "", "-", "", "", "https://www.asiabooks.com", "", PMGWRESP2)

                TransCode = PMGWRESP2.Substring(0, 4)
                ResponseCode = PMGWRESP2.Substring(97, 2)
                Reference = PMGWRESP2.Substring(108, 20)
                Reference2 = PMGWRESP2.Substring(128, 20)
                Reference3 = PMGWRESP2.Substring(148, 20)
                Authorize = PMGWRESP2.Substring(99, 6)
                'UAID = PMGWRESP2.Substring(20, 36)
                Invoice = PMGWRESP2.Substring(32, 12)
                Timestamp = PMGWRESP2.Substring(44, 8) & PMGWRESP2.Substring(52, 6)
                Amount = PMGWRESP2.Substring(85, 12)
                Checksum = PMGWRESP2.Substring(58, 19)
                CardType = PMGWRESP2.Substring(105, 3)
                'ChecksumCard2 = PMGWRESP2.Substring(154, 40)
                CC_Country = PMGWRESP2.Substring(687, 45)
            End If

            Dim _strQuery As New StringBuilder
            Dim dt As New DataTable

            uCon = New uConnect

            _strQuery = New StringBuilder
            _strQuery.Append("select distinct a.isbn, e.sku_13, b.isbn_13, a.EBookID, a.orderdtl_no, a.Available_Group_Id, e.country_status, isnull(b.book_title, e.book_title) as book_title, isnull(b.Author, e.Author) as Author, e.supplier_code, e.format_type, a.order_no, a.order_status, convert(decimal(20,2),a.Amount) as Amount, a.orderqty, a.Is_EB_Order_Placed, c.Member_Id, c.customer_name, c.last_name, c.customer_country, ")
            _strQuery.Append("a.Status_LeadTime as leadtime,d.Payment_method_Name,c.Billing_Address,a.Book_Title_Report,convert(numeric(20,2),a.Unitprice) as Unitprice, ")
            _strQuery.Append("case c.payment_method_code when 'CR001' then 'Credit Card' when 'CS001' then 'Counter Service' when 'TF001' then 'Transfer Through Commercial  Bank Account' when 'PP001' then 'PayPal' when 'KE001' then 'Pay at Shop' end as payment ")
            _strQuery.Append(",c.telephone,c.transport_type, c.field2 as branch ,c.ship_to_address , convert(nvarchar,c.adddt,100) as order_date,c.field4 as mailbranch ")
            _strQuery.Append(",c.delivery_cost,c.grand_total,c.transport_type,c.Email,c.customer_name+'  '+ c.last_name as CusName_Lastname ")
            _strQuery.Append(",convert(decimal(8,0),c.Promo_Discount) as Promo_Discount, convert(decimal(20,2),c.Promo_Discount_Amount) as Promo_Discount_Amount ")
            _strQuery.Append("from tbt_asbkeo_cus_orderdtl a left join dbo.tbt_jobber_book_search b on a.isbn = b.isbn_13 ")
            _strQuery.Append("left join dbo.ebook_store e on a.ebookid = e.bookid ")
            _strQuery.Append("inner join tbt_asbkeo_cus_order c on a.order_no = c.order_no inner join tbm_syst_Paymentmethod d ")
            _strQuery.Append("on c.Payment_Method_Code = d.Payment_Method_Code ")
            _strQuery.Append("where a.order_no = '" + Invoice + "' order by a.Available_Group_Id,a.orderdtl_no")

            dt = uFunction.getDataTable(uCon.conn, _strQuery.ToString)

            Dim isAuth As String = ""
            If dt.Rows.Count > 0 Then
                If ResponseCode = "00" Then
                    'UpdateMyEBooks(dt, Invoice)

                    If CheckCCTerritory(Checksum, CC_Country, dt) Then
                        isAuth = "Y"
                    Else
                        isAuth = "N"
                    End If

                End If
            End If

            Try
                _strQuery = New StringBuilder
                _strQuery.Append("insert into [Payment_Status_byKBANK] ")
                _strQuery.Append("([Response Code],[TransCode],[Reference],[Authorize],[UAID],[Invoice] ")
                _strQuery.Append(",[Timestamp],[Amount],[Checksum],[Card Type],[ChecksumCard2] ")
                _strQuery.Append(",[is_active],[created_date],[created_by],[is_authorized]) ")
                _strQuery.Append("values ")
                _strQuery.Append("('" + ResponseCode + "'") '<Response Code, varchar(2),>
                _strQuery.Append(",'" + TransCode + "'")
                _strQuery.Append(",'" + Reference + "'") '<Reference, varchar(12),>
                _strQuery.Append(",'" + Authorize + "'") '<Authorize, varchar(6),>
                _strQuery.Append(",'" + UAID + "'") '<UAID, varchar(36),>
                _strQuery.Append(",'" + Invoice + "'") '<Invoice, varchar(12),>
                _strQuery.Append(",''") '<Timestamp, varchar(14),>
                _strQuery.Append(",'" + Amount + "'") '<Amount, varchar(12),>
                _strQuery.Append(",'" + Checksum + "'") '<Checksum, varchar(40),>
                _strQuery.Append(",'" + CardType + "'") '<Card Type, varchar(20),>
                _strQuery.Append(",''") '<ChecksumCard2, varchar(40),>
                _strQuery.Append(",'Y'") '<is_active, char(1),>
                _strQuery.Append(",getdate()") '<created_date, datetime,>
                _strQuery.Append(",'Administrator'") '<created_by, nvarchar(20),>
                _strQuery.Append(",'" + isAuth + "')")

                GenerateLog("Payment_KBank_Realtime", "", "", Invoice, "", "", "https://www.asiabooks.com", "", "_strQuery=" + _strQuery.ToString)

                uFunction.ExecuteDataStringNonTran(uCon.conn, _strQuery.ToString)

            Catch ex As Exception
                GenerateLog("Payment_KBank_Realtime", "", "", Invoice, "", "", "https://www.asiabooks.com", "", ex.Message.ToString)
                Throw ex
            End Try

            Dim strCode_Promotion As String = ""

            If dt.Rows.Count > 0 Then
                If ResponseCode = "00" Then
                    ReceivePayment(dt, Invoice)

                    '//update promotion cross start
                    Dim dtPromotion As New DataTable
                    dtPromotion.Clear()

                    dtPromotion = uFunction.getDataTable(uCon.conn, "select * from tbm_AB_Promotion_Cross where Order_No_Get = '" + Invoice + "' and status = 'N' and order_status = '1'")
                    If dtPromotion.Rows.Count > 0 Then
                        strCode_Promotion = dtPromotion.Rows(0).Item("Code_Promotion")
                        uFunction.ExecuteDataStringNonTran(uCon.conn, "update tbm_AB_Promotion_Cross set order_status = '2' where Code_Promotion = '" + strCode_Promotion + "'")
                    End If

                    dtPromotion = uFunction.getDataTable(uCon.conn, "select * from tbm_AB_Promotion_Cross where Order_No_Use = '" + Invoice + "' and status = 'N' and order_status = '1'")
                    If dtPromotion.Rows.Count > 0 Then
                        uFunction.ExecuteDataStringNonTran(uCon.conn, "update tbm_AB_Promotion_Cross set order_status = '2',status = 'Y' where Code_Promotion = '" + strCode_Promotion + "'")
                    End If
                    '//update promotion cross end

                    Dim UnAuthEBooks As ArrayList = CheckCCTerritory2(Checksum, CC_Country, dt)
                    UpdateMyEBooks(dt, Invoice, UnAuthEBooks)
                Else
                    CancelPayment(dt, Invoice)
                End If
            End If

            Dim mailMessage As System.Web.Mail.MailMessage = New System.Web.Mail.MailMessage
            Dim _mail As New StringBuilder

            _strQuery = New StringBuilder
            _strQuery.Append("select distinct a.isbn, e.sku_13, b.isbn_13, a.EBookID, a.orderdtl_no, a.Available_Group_Id, e.country_status, isnull(b.book_title, e.book_title) as book_title, isnull(b.Author, e.Author) as Author, e.supplier_code, e.format_type, a.order_no, a.order_status, convert(decimal(20,2),a.Amount) as Amount, a.orderqty, a.Is_EB_Order_Placed, c.Member_Id, c.customer_name, c.last_name, c.customer_country, ")
            _strQuery.Append("a.Status_LeadTime as leadtime,d.Payment_method_Name,c.Billing_Address,a.Book_Title_Report,convert(numeric(20,2),a.Unitprice) as Unitprice, ")
            _strQuery.Append("case c.payment_method_code when 'CR001' then 'Credit Card' when 'CS001' then 'Counter Service' when 'TF001' then 'Transfer Through Commercial  Bank Account' when 'PP001' then 'PayPal' end as payment ")
            _strQuery.Append(",c.telephone,c.transport_type, c.field2 as branch ,c.ship_to_address , convert(nvarchar,c.adddt,100) as order_date,c.field4 as mailbranch ")
            _strQuery.Append(",c.delivery_cost,c.grand_total,c.transport_type,c.Email,c.customer_name+'  '+ c.last_name as CusName_Lastname, c.Ship_To_Name, c.Billing_Name  ")
            _strQuery.Append(",convert(decimal(8,0),c.Promo_Discount) as Promo_Discount, convert(decimal(20,2),c.Promo_Discount_Amount) as Promo_Discount_Amount ")
            _strQuery.Append("from tbt_asbkeo_cus_orderdtl a left join dbo.tbt_jobber_book_search b on a.isbn = b.isbn_13 ")
            _strQuery.Append("left join dbo.ebook_store e on a.ebookid = e.bookid ")
            _strQuery.Append("inner join tbt_asbkeo_cus_order c on a.order_no = c.order_no inner join tbm_syst_Paymentmethod d ")
            _strQuery.Append("on c.Payment_Method_Code = d.Payment_Method_Code ")
            _strQuery.Append("where a.order_no = '" + Invoice + "' order by a.Available_Group_Id,a.orderdtl_no")

            dt = New DataTable
            dt = uFunction.getDataTable(uCon.conn, _strQuery.ToString)

            If dt.Rows.Count > 0 Then
                With dt
                    If ResponseCode = "00" Then

                        'Dim eBookMsgAdd As String = ""
                        'If .Select("Available_Group_Id='4'").Length > 0 Then
                        '    eBookMsgAdd = ", You can download the ordered eBooks at My eBook page of the website."
                        'End If

                        Dim strOrder_No As String = ""
                        'strOrder_No = "101004000007"  
                        Dim strTelephone As String = ""
                        strTelephone = .Rows(0).Item("telephone").ToString
                        strOrder_No = Invoice

                        If strTelephone <> "" Then
                            Dim strSplit As String()
                            Dim strPrice As String = ""
                            strPrice = CDbl(.Rows(0).Item("Grand_Total").ToString).ToString("#,###,##0.00")
                            Dim strTel As String = .Rows(0).Item("telephone").ToString
                            strSplit = strTel.Replace("-", "").Split(" ")
                            If strSplit.Length > 1 Then
                                If Left(strSplit(0), 2) = "08" Then
                                    If strSplit(0).Length = 10 Then
                                        If strCode_Promotion <> "" Then
                                            ws_Send_SMS.CallSend_SMS(Invoice, strSplit(0).ToString, "Promotional code is " + strCode_Promotion + ". Pls show it to get extra 10%.", "d6hojkiyd", "Promotion Cross")
                                        End If
                                        ws_Send_SMS.CallSend_SMS(Invoice, strSplit(0).ToString, "Thank you for your shopping @ Asiabooks.com (via " + strPrice + " Baht)", "d6hojkiyd", "CreditCard Payment")
                                    End If
                                Else
                                    If Left(strSplit(1), 2) = "08" Then
                                        If strSplit(1).Length = 10 Then
                                            If strCode_Promotion <> "" Then
                                                ws_Send_SMS.CallSend_SMS(Invoice, strSplit(1).ToString, "Promotional code is " + strCode_Promotion + ". Pls show it to get extra 10%.", "d6hojkiyd", "Promotion Cross")
                                            End If
                                            ws_Send_SMS.CallSend_SMS(Invoice, strSplit(1).ToString, "Thank you for your shopping @ Asiabooks.com (via " + strPrice + " Baht)", "d6hojkiyd", "CreditCard Payment")
                                        End If
                                    End If
                                End If
                            Else
                                If Left(strSplit(0), 2) = "08" Then
                                    If strSplit(0).Length = 10 Then
                                        If strCode_Promotion <> "" Then
                                            ws_Send_SMS.CallSend_SMS(Invoice, strSplit(0).ToString, "Promotional code is " + strCode_Promotion + ". Pls show it to get extra 10%.", "d6hojkiyd", "Promotion Cross")
                                        End If
                                        ws_Send_SMS.CallSend_SMS(Invoice, strSplit(0).ToString, "Thank you for your shopping @ Asiabooks.com (via " + strPrice + " Baht)", "d6hojkiyd", "CreditCard Payment")
                                    End If
                                End If
                            End If

                        End If


                        rpt.Load(Server.MapPath("~\Report\rpt_Invoid_Customer.rpt"))
                        rpt.SetDataSource(dt)

                        Dim myExportOptions As CrystalDecisions.Shared.ExportOptions
                        Dim myDiskFileDestinationOptions As CrystalDecisions.Shared.DiskFileDestinationOptions
                        Dim myExportFile As String
                        'Dim myReport As New Individuals_Productivity_and_Overall_Attendance()
                        Dim strpath As String = ""
                        strpath = "~\Report\File\" + Invoice + ".pdf"
                        myExportFile = Server.MapPath(strpath)
                        myDiskFileDestinationOptions = New CrystalDecisions.Shared.DiskFileDestinationOptions()
                        myDiskFileDestinationOptions.DiskFileName = myExportFile
                        myExportOptions = rpt.ExportOptions
                        With myExportOptions
                            .DestinationOptions = myDiskFileDestinationOptions
                            .ExportDestinationType = .ExportDestinationType.DiskFile
                            .ExportFormatType = .ExportFormatType.PortableDocFormat
                        End With
                        rpt.Export()


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
                                '_mail.Append("Your payment has been received and your order no." + ORDERNO + "  is already on process. Our staffs will contact to inform you when the book arrives. ")
                                _mail.Append("Your payment has been received and your order no." + Invoice + "  is already on process. Our staffs will contact to inform the delivery tracking number of books when we dispatch.")
                            ElseIf .Rows(0).Item("transport_type").ToString.Trim = "PICK UP AT BRANCH" Then
                                _mail.Append("Your payment has been received and your order no." + Invoice + "  is already on process. Our staffs will contact to inform you when the book arrives. ")
                            Else
                                _mail.Append("Your payment has been received and your order no." + Invoice + "  is already on process.")
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
                                _mail.Append("Your payment has been received and your order no." + Invoice + " is now ready to be downloaded on <a href='" + ConfigurationManager.AppSettings("AB_MyEBook") + "'>MY EBOOK</a> page. (Please click and further download)")
                                _mail.Append("</td></tr>")
                            End If
                        End If

                        '//kung insert promotion cross start
                        If strCode_Promotion <> "" Then
                            _mail.Append("<tr><td style='height: 10px; font-weight: bold; color: #696969;'></td></tr>")
                            _mail.Append("<tr><td style='height: 32px; font-weight: bold; color: #696969;'>Under the promotional campaign of buying book (s) get extra 10% when buy ebooks or when you buy ebooks, you get extra 10% when buy book. Kindly note that your ")
                            _mail.Append("promotional code is " + strCode_Promotion + ". You have got extra 10% on top for the next purchase either at www.asiabooks.com or at bookshops.</td></tr>")
                        End If
                        '//kung insert promotion cross end

                        _mail.Append("<tr><td style='height: 32px; font-weight: bold; color: #000099;'>Please see the receipt as attached.</td></tr>")
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
                        If .Rows(0).Item("transport_type").ToString.Trim = "PICK UP AT BRANCH" Then
                            _mail.Append("<td>Pick up at branch : ").Append(.Rows(0).Item("branch").ToString).Append("</td></tr><tr>")
                        Else
                            _mail.Append("<td>Home Delivery </td></tr><tr>")
                        End If

                        _mail.Append("<td>Paid by (payment method) : ").Append(.Rows(0).Item("payment").ToString).Append("</td></tr><tr>")
                        _mail.Append("<td>Reference : ").Append(.Rows(0).Item("order_no").ToString).Append("</td></tr><tr>")
                        _mail.Append("<td>&nbsp;</td></tr><tr>")
                        '_mail.Append("<td>Please arrange the payment via payment method at your convenience(Credit card, Money Transfer, or Counter Service)  as to complete the order.</td></tr><tr>")
                        '_mail.Append("<td>Asia Books will proceed to order books for you when your payment is received.</td></tr><tr>")
                        _mail.Append("<td>&nbsp;</td></tr><tr>")
                        _mail.Append("<td>Customer Name : ").Append(Replace(.Rows(0).Item("customer_name").ToString, "[MEMBER]", " ")).Append("   ").Append(.Rows(0).Item("last_name").ToString).Append("</td></tr><tr>")
                        _mail.Append("<td>Tel : ").Append(.Rows(0).Item("telephone").ToString).Append("</td></tr><tr>")
                        _mail.Append("<td>E-Mail : ").Append(.Rows(0).Item("Email").ToString).Append("</td></tr><tr>")
                        _mail.Append("<td>Address : ").Append(.Rows(0).Item("ship_to_address").ToString).Append("</td></tr><tr>")
                        _mail.Append("<td>&nbsp;</td></tr>")

                        If .Select("EBookID IS NOT NULL").Length > 0 Then
                            _mail.Append("<td>&nbsp;</td></tr><tr>")
                            _mail.Append("<td>Should you have any problems or questions with ebook (s) downloading from my ebook page, please contact ebooks support via ecommerce@asiabooks.com or 02-715-9000 ext. 8101, 8104, 8106</td></tr><tr>")
                            _mail.Append("<td>&nbsp;</td></tr><tr>")
                        End If

                        '_mail.Append("<tr><td>In case that you select Money Transfer method, please fax pay in slip to our customer service at 02-7159197 to process order.</td></tr>")
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

                        Try
                            'Dim Attachment As System.Web.Mail.MailAttachment
                            'Attachment = New MailAttachment(Server.MapPath("~\Report\File\" + Invoice + ".pdf"))

                            'mailMessage.To = .Rows(0).Item("Email").ToString
                            'mailMessage.From = "eCommerce@asiabooks.com"
                            ''mailMessage.Cc = "jirathep@promptnow.com, phamorn@promptnow.com"
                            'mailMessage.Cc = "eCommerce@asiabooks.com,porntip_m@asiabooks.com,aunnop_k@asiabooks.com,jirathep@promptnow.com,phamorn@promptnow.com,warangkana@promptnow.com"
                            'mailMessage.Subject = "Your order with Asia Books CO.,LTD ref. : " + Invoice
                            'mailMessage.BodyFormat = System.Web.Mail.MailFormat.Html
                            'mailMessage.Body = _mail.ToString
                            'mailMessage.Attachments.Add(Attachment)

                            'System.Web.Mail.SmtpMail.SmtpServer = SmtpMail
                            'mailMessage.Fields.Add("http://schemas.microsoft.com/cdo/configuration/smtpauthenticate", "1")
                            'mailMessage.Fields.Add("http://schemas.microsoft.com/cdo/configuration/sendusername", "eOrdering@asiabooks.com")
                            'mailMessage.Fields.Add("http://schemas.microsoft.com/cdo/configuration/sendpassword", "abs999.")

                            'System.Web.Mail.SmtpMail.Send(mailMessage)

                            Dim strAttchment As String = Server.MapPath("~\Report\File\" + Invoice + ".pdf")
                            Dim strMailTo As String = .Rows(0).Item("Email").ToString
                            Dim strMailCC As String = "eCommerce@asiabooks.com,porntip_m@asiabooks.com,aunnop_k@asiabooks.com"
                            Dim strSubject As String = "Your order with Asia Books CO.,LTD ref. : " + Invoice
                            Dim strBody As String = _mail.ToString

                            uClass.SendMail(strMailTo, strMailCC, strSubject, strBody, strAttchment)

                        Catch ex As Exception
                            GenerateLog("Payment_Realtime_SendMail_Fail", "", "", Invoice, "", "", "https://www.asiabooks.com", "", ex.Message + " " + ex.GetBaseException.ToString)

                            'mailMessage = New System.Web.Mail.MailMessage
                            'mailMessage.From = "eCommerce@asiabooks.com"
                            'mailMessage.To = "eCommerce@asiabooks.com"
                            'mailMessage.Cc = "porntip_m@asiabooks.com,aunnop_k@asiabooks.com"
                            'mailMessage.Subject = "Your order with Asia Books CO.,LTD ref. : " + Invoice
                            'mailMessage.BodyFormat = System.Web.Mail.MailFormat.Html
                            'mailMessage.Body = _mail.ToString

                            'System.Web.Mail.SmtpMail.SmtpServer = SmtpMail
                            'mailMessage.Fields.Add("http://schemas.microsoft.com/cdo/configuration/smtpauthenticate", "1")
                            'mailMessage.Fields.Add("http://schemas.microsoft.com/cdo/configuration/sendusername", "eOrdering@asiabooks.com")
                            'mailMessage.Fields.Add("http://schemas.microsoft.com/cdo/configuration/sendpassword", "abs999.")

                            'System.Web.Mail.SmtpMail.Send(mailMessage)
                        End Try

                    Else
                        _mail.Append("<table WIDTH='700' border='0' align='center'  cellpadding='0' cellspacing='0'>")
                        _mail.Append("<tr>")
                        _mail.Append("<td width='20'><img src='https://www.asiabooks.com/images/payment/top_left.jpg' width='20' height='103' /></td>")
                        _mail.Append("<td background='https://www.asiabooks.com/images/payment/bg_top.jpg'><img src='https://www.asiabooks.com/images/payment/logo.jpg' width='321' height='103' /></td>")
                        _mail.Append("<td width='20'><img src='https://www.asiabooks.com/images/payment/top_right.jpg' width='20' height='103' /></td>")
                        _mail.Append("</tr>")
                        _mail.Append("<tr>")
                        _mail.Append("<td background='https://www.asiabooks.com/images/payment/left.gif'></td>")
                        _mail.Append("<td style='width: 510px;' valign='top'>")

                        _mail.Append("<div style='font-size: 10pt; font-family: Arial'>")
                        _mail.Append("Dear Customer, <br><br>")
                        _mail.Append("&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Thank you for ordering with Asia Books. Sorry that due to system error on the payment method of credit card,   you couldn’t process the payment via credit card on our system temporarily. <br>")
                        _mail.Append("&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Please contact our customer service at 02-7159000 ext: 8103, 3202 to further offer you the service to complete the payment process. We are sorry for any inconvenience caused.<br><br>")
                        _mail.Append("Yours sincerely,<br><br>")
                        _mail.Append("Customer Service<br>")
                        _mail.Append("Asia Books Co., Ltd.")
                        _mail.Append("</div>")

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

                        Try
                            'mailMessage.To = .Rows(0).Item("Email").ToString
                            'mailMessage.From = "eCommerce@asiabooks.com"
                            'mailMessage.Cc = "eCommerce@asiabooks.com,porntip_m@asiabooks.com,aunnop_k@asiabooks.com"
                            'mailMessage.Subject = "Your order with Asia Books CO.,LTD ref. : " + Invoice
                            'mailMessage.BodyFormat = System.Web.Mail.MailFormat.Html
                            'mailMessage.Body = _mail.ToString

                            'System.Web.Mail.SmtpMail.SmtpServer = SmtpMail
                            'mailMessage.Fields.Add("http://schemas.microsoft.com/cdo/configuration/smtpauthenticate", "1")
                            'mailMessage.Fields.Add("http://schemas.microsoft.com/cdo/configuration/sendusername", "eOrdering@asiabooks.com")
                            'mailMessage.Fields.Add("http://schemas.microsoft.com/cdo/configuration/sendpassword", "abs999.")

                            'System.Web.Mail.SmtpMail.Send(mailMessage)

                            Dim strMailTo As String = .Rows(0).Item("Email").ToString
                            Dim strMailCC As String = "eCommerce@asiabooks.com,porntip_m@asiabooks.com,aunnop_k@asiabooks.com"
                            Dim strSubject As String = "Your order with Asia Books CO.,LTD ref. : " + Invoice
                            Dim strBody As String = _mail.ToString

                            uClass.SendMail(strMailTo, strMailCC, strSubject, strBody, "")

                        Catch ex As Exception
                            GenerateLog("Payment_Realtime_SendMail_Fail", "", "", Invoice, "", "", "https://www.asiabooks.com", "", ex.Message + " " + ex.GetBaseException.ToString)

                            'mailMessage = New System.Web.Mail.MailMessage
                            'mailMessage.From = "eCommerce@asiabooks.com"
                            'mailMessage.To = "eCommerce@asiabooks.com"
                            'mailMessage.Cc = "porntip_m@asiabooks.com,aunnop_k@asiabooks.com"
                            'mailMessage.Subject = "Your order with Asia Books CO.,LTD ref. : " + Invoice
                            'mailMessage.BodyFormat = System.Web.Mail.MailFormat.Html
                            'mailMessage.Body = _mail.ToString

                            'System.Web.Mail.SmtpMail.SmtpServer = SmtpMail
                            'mailMessage.Fields.Add("http://schemas.microsoft.com/cdo/configuration/smtpauthenticate", "1")
                            'mailMessage.Fields.Add("http://schemas.microsoft.com/cdo/configuration/sendusername", "eOrdering@asiabooks.com")
                            'mailMessage.Fields.Add("http://schemas.microsoft.com/cdo/configuration/sendpassword", "abs999.")

                            'System.Web.Mail.SmtpMail.Send(mailMessage)
                        End Try
                    End If

                End With
            Else
                'mailMessage.To = "eCommerce@asiabooks.com"
                '_mail.Append("Not have Detail at invoice number : " + Invoice)
                'mailMessage.From = "eCommerce@asiabooks.com"
                'mailMessage.Cc = "eCommerce@asiabooks.com,porntip_m@asiabooks.com,aunnop_k@asiabooks.com"
                'mailMessage.Subject = "Your order with Asia Books CO.,LTD ref. : " + Invoice
                'mailMessage.BodyFormat = System.Web.Mail.MailFormat.Html
                'mailMessage.Body = _mail.ToString

                'System.Web.Mail.SmtpMail.SmtpServer = SmtpMail
                'mailMessage.Fields.Add("http://schemas.microsoft.com/cdo/configuration/smtpauthenticate", "1")
                'mailMessage.Fields.Add("http://schemas.microsoft.com/cdo/configuration/sendusername", "eOrdering@asiabooks.com")
                'mailMessage.Fields.Add("http://schemas.microsoft.com/cdo/configuration/sendpassword", "abs999.")

                'System.Web.Mail.SmtpMail.Send(mailMessage)


                Dim strMailTo As String = "eCommerce@asiabooks.com"
                Dim strMailCC As String = "eCommerce@asiabooks.com,porntip_m@asiabooks.com,aunnop_k@asiabooks.com"
                Dim strSubject As String = "Your order with Asia Books CO.,LTD ref. : " + Invoice
                Dim strBody As String = "Not have Detail at invoice number : " + Invoice

                uClass.SendMail(strMailTo, strMailCC, strSubject, strBody, "")

            End If

        End If
    End Sub

    Private Sub CancelPayment(ByVal dt_eOrdering As DataTable, ByVal OrderNo As String)
        Dim sqlDb As New SqlDb
        Dim _strQuery As New StringBuilder

        If dt_eOrdering.Rows.Count > 0 Then
            With dt_eOrdering

                sqlDb.BeginTrans()

                Try
                    For i As Integer = 0 To .Rows.Count - 1

                        _strQuery = New StringBuilder
                        _strQuery.Append("UPDATE tbt_asbkeo_cus_orderdtl SET ")
                        _strQuery.Append(" Order_Status = 5,")
                        _strQuery.Append(" payment = 'KBANK'")
                        _strQuery.Append(" WHERE Order_No='" & .Rows(i).Item("order_no") & "'")
                        _strQuery.Append(" AND Orderdtl_No='" & .Rows(i).Item("orderdtl_no") & "'")
                        _strQuery.Append(" AND Available_Group_Id='" & .Rows(i).Item("Available_Group_Id") & "'")

                        sqlDb.Exec(_strQuery.ToString)

                    Next

                    sqlDb.CommitTrans()
                Catch ex As Exception
                    sqlDb.RollbackTrans()
                    GenerateLog("CreditCard_CancelPayment", "", "", OrderNo, "", "", "https://www.asiabooks.com", "", ex.Message.ToString)

                    Throw ex
                End Try

            End With
        End If
    End Sub

    Private Sub ReceivePayment(ByVal dt_eOrdering As DataTable, ByVal OrderNo As String)
        Dim sqlDb As New SqlDb
        Dim _strQuery As New StringBuilder

        If dt_eOrdering.Rows.Count > 0 Then
            With dt_eOrdering

                sqlDb.BeginTrans()

                Try
                    For i As Integer = 0 To .Rows.Count - 1

                        _strQuery = New StringBuilder
                        _strQuery.Append("UPDATE tbt_asbkeo_cus_orderdtl SET ")
                        _strQuery.Append(" Order_Status = 2,")
                        _strQuery.Append(" payment = 'KBANK'")
                        _strQuery.Append(" WHERE Order_No='" & .Rows(i).Item("order_no") & "'")
                        _strQuery.Append(" AND Orderdtl_No='" & .Rows(i).Item("orderdtl_no") & "'")
                        _strQuery.Append(" AND Available_Group_Id='" & .Rows(i).Item("Available_Group_Id") & "'")

                        sqlDb.Exec(_strQuery.ToString)

                    Next

                    sqlDb.CommitTrans()
                Catch ex As Exception
                    sqlDb.RollbackTrans()
                    GenerateLog("CreditCard_ReceivePayment", "", "", OrderNo, "", "", "https://www.asiabooks.com", "", ex.Message.ToString)

                    Throw ex
                End Try

            End With
        End If
    End Sub

    Private Sub UpdateMyEBooks(ByVal dt_eOrdering As DataTable, ByVal Invoice As String, ByVal UnAuthEBooks As ArrayList)
        Dim sqlDb As New SqlDb
        Dim _strQuery As New StringBuilder

        If dt_eOrdering.Rows.Count > 0 Then
            With dt_eOrdering

                'Order contains ebook.
                If .Select("Available_Group_Id='4'").Length > 0 Then

                    sqlDb.BeginTrans()

                    Try
                        For Each dr As DataRow In .Select("Available_Group_Id='4'")

                            If dr.Item("Is_EB_Order_Placed").ToString <> "Y" Then

                                For j As Integer = 1 To CInt(dr("orderqty"))

                                    Dim is_cc_unauth As Boolean = False
                                    Dim Remark As String = ""
                                    For i As Integer = 0 To UnAuthEBooks.Count - 1
                                        If dr("EBookID").ToString = UnAuthEBooks(i).ToString Then
                                            is_cc_unauth = True
                                            UnsaleablePayment(Invoice, dr("orderdtl_no"), dr("Available_Group_Id"))
                                            Remark = "Not Saleable"
                                            Exit For
                                        End If
                                    Next

                                    Dim Download_URL As String = ""
                                    If Not is_cc_unauth Then
                                        If dr("supplier_code").ToString.Trim.ToLower.Equals("gardners") Then
                                            Download_URL = PN.GetGardnersDownloadURL(dr("sku_13"), dr("EBookID"), dr("orderdtl_no"), j, dr("format_type"), dr("customer_country"), Invoice)
                                        ElseIf dr("supplier_code").ToString.Trim.ToLower.Equals("ingram") Then
                                            Download_URL = PN.GetIngramDownloadURL(dr("sku_13"), dr("EBookID"), dr("orderdtl_no"), j, Invoice, dr("customer_country"))
                                        End If
                                    End If

                                    Dim OrderNoTx As String = Invoice & dr("orderdtl_no") & j
                                    ' lbl_Amount_ebook_usd.Text = "(US$ " + IIf(usd = "", 0, usd).ToString + ")"
                                    _strQuery = New StringBuilder
                                    _strQuery.Append("insert into [ebook_mylist] ")
                                    _strQuery.Append("([Order_No],[Order_No_Tx],[EBookID],[ISBN],[SKU],[Format_Type],[Supplier_Code],[Member_Id],[Download_URL],[Downloaded_Times],[Enabled_Status],[Tx_Date],[Selling_Price],[Is_CC_Unauth],[Is_Void],[Country_Code],[Is_Free],[IP],[Remark]) ")
                                    _strQuery.Append("values ")
                                    _strQuery.Append("('" & Invoice & "'")
                                    _strQuery.Append(",'" & OrderNoTx & "'")
                                    _strQuery.Append(",'" & dr("EBookID") & "'")
                                    _strQuery.Append(",'" & dr("isbn") & "'")
                                    _strQuery.Append(",'" & dr("sku_13") & "'")
                                    _strQuery.Append("," & dr("format_type"))
                                    _strQuery.Append(",'" & dr("supplier_code") & "'")
                                    _strQuery.Append(",'" & dr("Member_Id") & "'")
                                    _strQuery.Append(",'" & Download_URL & "'")
                                    _strQuery.Append(",'0'")
                                    _strQuery.Append(",'Y'")
                                    _strQuery.Append(",getdate()")
                                    _strQuery.Append("," & dr("Unitprice"))
                                    _strQuery.Append(",'" & IIf(is_cc_unauth, "Y", "N").ToString & "'")
                                    _strQuery.Append(",'" & IIf(is_cc_unauth, "N", "").ToString & "'")
                                    _strQuery.Append(",'" & dr("customer_country") & "'")
                                    _strQuery.Append(",'" & IIf(CDbl(dr("Amount").ToString) = 0, "Y", "N").ToString & "'")
                                    _strQuery.Append(",'" & Request.ServerVariables("REMOTE_ADDR") & "'")
                                    _strQuery.Append(",'" & Remark & "')")
                                    sqlDb.Exec(_strQuery.ToString)

                                    _strQuery = New StringBuilder
                                    _strQuery.Append("UPDATE tbt_asbkeo_cus_orderdtl SET ")
                                    _strQuery.Append("Is_EB_Order_Placed = 'Y' ")
                                    _strQuery.Append("WHERE Order_No = '" & Invoice & "' and Orderdtl_No = '" & dr("orderdtl_no") & "' and Available_Group_Id = '" & dr("Available_Group_Id") & "'")
                                    sqlDb.Exec(_strQuery.ToString)

                                    If Download_URL = "" Then
                                        Dim mailMessage As System.Web.Mail.MailMessage = New System.Web.Mail.MailMessage
                                        Dim _mail As New StringBuilder

                                        Dim br As String = "<br />"
                                        '_mail.Append("Download URL: " & dt.Rows(0).Item("Download_URL").ToString)
                                        _mail.Append("Dear Customer, " & br & br)
                                        _mail.Append("Kindly note the download link of your eBook order no." & Invoice & " (ISBN : " & dr("isbn") & ", " & dr("book_title") & ") cannot be provided. Please contact the system administrator." & br)
                                        _mail.Append("Thank you." & br & br)

                                        _mail.Append("Best regards," & br & br)
                                        _mail.Append("eCommerce Team" & br & br & br)
                                        _mail.Append("ASIA BOOKS CO., LTD." & br)
                                        _mail.Append("65/66, 65/70 Chamnan Phenjati Business Center 7th Floor," & br)
                                        _mail.Append("Rama 9, Huaykwang, Bangkok 10320" & br)
                                        _mail.Append("Tel:  0-2715-9000 ext. 8101, 8104" & br)

                                        Try
                                            'mailMessage.To = dr.Item("Email")
                                            'mailMessage.From = "eCommerce@asiabooks.com"
                                            'mailMessage.Cc = "eCommerce@asiabooks.com,porntip_m@asiabooks.com,aunnop_k@asiabooks.com,jirathep@promptnow.com,phamorn@promptnow.com"
                                            ''mailMessage.Subject = "Our customer downloads eBook as the URL appeared in this email"
                                            'mailMessage.Subject = "Your ordered eBook with Asia Books CO.,LTD ISBN : " + dr.Item("isbn") + " cannot be provided."
                                            'mailMessage.BodyFormat = System.Web.Mail.MailFormat.Html
                                            'mailMessage.Body = _mail.ToString

                                            'System.Web.Mail.SmtpMail.SmtpServer = SmtpMail
                                            'mailMessage.Fields.Add("http://schemas.microsoft.com/cdo/configuration/smtpauthenticate", "1")
                                            'mailMessage.Fields.Add("http://schemas.microsoft.com/cdo/configuration/sendusername", "eOrdering@asiabooks.com")
                                            'mailMessage.Fields.Add("http://schemas.microsoft.com/cdo/configuration/sendpassword", "abs999.")

                                            'System.Web.Mail.SmtpMail.Send(mailMessage)

                                            Dim strMailTo As String = dr.Item("Email")
                                            Dim strMailCC As String = "eCommerce@asiabooks.com,porntip_m@asiabooks.com,aunnop_k@asiabooks.com"
                                            Dim strSubject As String = "Your eBook order with Asia Books CO.,LTD Ref. No." + Invoice + " (ISBN : " + dr.Item("isbn") + ") cannot be provided."
                                            Dim strBody As String = _mail.ToString

                                            uClass.SendMail(strMailTo, strMailCC, strSubject, strBody, "")

                                        Catch ex As Exception
                                            GenerateLog("EmailToGardners(My_Ebook2_Popup)", "", "", Invoice, "", "", "https://www.asiabooks.com", "", ex.Message.ToString + " " + ex.GetBaseException.ToString)
                                        End Try
                                    End If

                                Next
                            End If

                        Next

                        sqlDb.CommitTrans()
                    Catch ex As Exception
                        sqlDb.RollbackTrans()
                        GenerateLog("PaymentRealtime_UpdateMyEBooks", "", "", Invoice, "", "", "https://www.asiabooks.com", "", ex.Message.ToString)
                        Throw ex
                    End Try

                End If

            End With
        End If

    End Sub

    Private Sub UnsaleablePayment(ByVal OrderNo As String, ByVal OrderDtlNo As String, ByVal Available_Group_Id As String)
        Dim sqlDb As New SqlDb
        Dim _strQuery As New StringBuilder

        sqlDb.BeginTrans()
        Try

            _strQuery = New StringBuilder
            _strQuery.Append("UPDATE tbt_asbkeo_cus_orderdtl SET ")
            _strQuery.Append(" Order_Status = 7,")
            _strQuery.Append(" payment = 'KBANK',")
            _strQuery.Append(" Remark = 'Not Saleable'")
            _strQuery.Append(" WHERE Order_No='" & OrderNo & "'")
            _strQuery.Append(" AND Orderdtl_No='" & OrderDtlNo & "'")
            _strQuery.Append(" AND Available_Group_Id='" & Available_Group_Id & "'")

            sqlDb.Exec(_strQuery.ToString)


            sqlDb.CommitTrans()
        Catch ex As Exception
            sqlDb.RollbackTrans()
            GenerateLog("CreditCard_CancelPayment", "", "", OrderNo, "", "", "https://www.asiabooks.com", "", ex.Message.ToString)

            Throw ex
        End Try

    End Sub

    Private Function CheckCCTerritory(ByVal CC As String, ByVal CC_Country As String, ByVal dt_eOrdering As DataTable) As Boolean
        Dim sqlDb As New SqlDb
        'Dim dt_cc_country As DataTable
        Dim dt_ebook_country As DataTable
        Dim _strQuery As New StringBuilder

        Try
            '_strQuery = New StringBuilder
            '_strQuery.Append("select top 1 country_code from ebook_cc ")
            '_strQuery.Append("where cc_number = SUBSTRING('" & CC & "', 1, 4)  ")
            '_strQuery.Append("OR cc_number = SUBSTRING('" & CC & "', 1, 6) order by cc_number desc")

            'dt_cc_country = sqlDb.GetDataTable(_strQuery.ToString)

            'If dt_cc_country.Rows.Count > 0 Then
            'Dim firstCountryCodeChar As String = dt_cc_country.Rows(0)(0).ToString.Substring(0, 1)

            Dim firstCountryCodeChar As String = CC_Country.ToString.Substring(0, 1)
            Dim firstTwoCountryCodeChar As String = CC_Country.ToString.Substring(0, 2)

            If dt_eOrdering.Rows.Count > 0 Then
                For Each dr As DataRow In dt_eOrdering.Select("Available_Group_Id='4'")

                    _strQuery = New StringBuilder
                    _strQuery.Append("SELECT country_code, bookid ")
                    _strQuery.Append(" FROM ebook_territory_" & firstCountryCodeChar)
                    _strQuery.Append(" where bookid = " & dr("EBookID") & " and (country_code = '" & firstTwoCountryCodeChar & "' or country_code = 'ROW') ")

                    dt_ebook_country = sqlDb.GetDataTable(_strQuery.ToString)

                    If dt_ebook_country.Rows.Count > 0 Then
                        Return False
                    End If

                Next
            End If
            'End If
        Catch ex As Exception
            GenerateLog("PaymentStatus_ByKBank_CheckCCTerritory", "", "", "-", "", "", "https://www.asiabooks.com", "", ex.Message & " - " & ex.GetBaseException.ToString)
            Throw ex
        End Try

        Return True
    End Function

    Private Function CheckCCTerritory2(ByVal CC As String, ByVal CC_Country As String, ByVal dt_eOrdering As DataTable) As ArrayList
        Dim UnAuthEBooks As New ArrayList

        Dim sqlDb As New SqlDb
        'Dim dt_cc_country As DataTable
        Dim dt_ebook_country As DataTable
        Dim _strQuery As New StringBuilder

        Try
            '_strQuery = New StringBuilder
            '_strQuery.Append("select top 1 country_code from ebook_cc ")
            '_strQuery.Append("where cc_number = SUBSTRING('" & CC & "', 1, 4)  ")
            '_strQuery.Append("OR cc_number = SUBSTRING('" & CC & "', 1, 6) order by cc_number desc")

            'dt_cc_country = sqlDb.GetDataTable(_strQuery.ToString)

            'If dt_cc_country.Rows.Count > 0 Then
            'Dim firstCountryCodeChar As String = dt_cc_country.Rows(0)(0).ToString.Substring(0, 1)

            Dim firstCountryCodeChar As String = CC_Country.ToString.Substring(0, 1)
            Dim firstTwoCountryCodeChar As String = CC_Country.ToString.Substring(0, 2)

            If dt_eOrdering.Rows.Count > 0 Then
                For Each dr As DataRow In dt_eOrdering.Select("Available_Group_Id='4'")

                    _strQuery = New StringBuilder
                    _strQuery.Append("SELECT country_code ")
                    _strQuery.Append(" FROM ebook_territory_" & firstCountryCodeChar)
                    _strQuery.Append(" where bookid = " & dr("EBookID") & " and (country_code = '" & firstTwoCountryCodeChar & "' or country_code = 'ROW') ")

                    dt_ebook_country = sqlDb.GetDataTable(_strQuery.ToString)

                    If dt_ebook_country.Rows.Count > 0 Then
                        UnAuthEBooks.Add(dr.Item("EBookID"))
                    End If

                Next
            End If
            'End If
        Catch ex As Exception
            GenerateLog("PaymentStatus_ByKBank_CheckCCTerritory", "", "", "-", "", "", "https://www.asiabooks.com", "", ex.Message & " - " & ex.GetBaseException.ToString)
            Throw ex
        End Try

        Return UnAuthEBooks
    End Function

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
End Class
