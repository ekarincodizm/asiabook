Imports Eordering.BusinessLogic
Imports System
Imports System.Data
Imports System.IO
Imports System.Text
Imports System.Web.Mail
Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.Shared

Partial Class Mail_Payment
    Inherits System.Web.UI.Page
    Dim PaymentService As New ws_payment.paymentservice.PaymentService
    Dim ws_Send_SMS As New Send_SMS.Send_SMS
    Dim Url As String
    Dim uCon As uConnect
    Dim PN As New PromptNow

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
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

        If Not IsPostBack Then
            'Url = PaymentService.Payment_KBank("00000031000727000005XXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXX09082800000212092005140410000000150099XXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXKBANKCARDXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXX")

            'Url = PaymentService.Payment_KBank(Request.Form("PMGWRESP"))
            'Url = PaymentService.Payment_KBank_Not_SSL(Request.Form("HOSTRESP").ToString, _
            'Request.Form("REFCODE").ToString, Request.Form("AUTHCODE").ToString, _
            'Request.Form("RETURNINV").ToString, Request.Form("UAID").ToString, _
            'Request.Form("CARDNUMBER").ToString, Request.Form("AMOUNT").ToString, _
            'Request.Form("FILLSPACE").ToString)

            'Response.Redirect(Url)
            
            ResponseCode = Request.Form("HOSTRESP").ToString
            Reference = Request.Form("REFCODE").ToString
            Authorize = Request.Form("AUTHCODE").ToString
            UAID = Request.Form("UAID").ToString
            Invoice = Request.Form("RETURNINV").ToString
            'Timestamp = PMGWRESP.Substring(68, 14)
            Amount = Request.Form("AMOUNT").ToString
            Checksum = Request.Form("CARDNUMBER").ToString
            'CardType = PMGWRESP.Substring(134, 20)
            CardType = Request.Form("FILLSPACE").ToString


            Dim mailMessage As System.Web.Mail.MailMessage = New System.Web.Mail.MailMessage
            Dim _mail As New StringBuilder
            Dim _strQuery As New StringBuilder
            Dim dt As New DataTable

            uCon = New uConnect

            _strQuery = New StringBuilder
            _strQuery.Append("select distinct a.isbn, e.sku_13, b.isbn_13, a.EBookID, a.orderdtl_no, a.Available_Group_Id, e.country_status, isnull(b.book_title, e.book_title) as book_title, isnull(b.Author, e.Author) as Author, e.supplier_code, e.format_type, a.order_no, convert(decimal(20,2),a.Amount) as Amount, a.orderqty, a.Is_EB_Order_Placed, c.Member_Id, c.customer_name, c.last_name, c.customer_country, ")
            _strQuery.Append("a.Status_LeadTime as leadtime,d.Payment_method_Name,c.Billing_Address,a.Book_Title_Report,convert(numeric(20,2),a.Unitprice) as Unitprice, ")
            _strQuery.Append("case c.payment_method_code when 'CR001' then 'Credit Card' when 'CS001' then 'Counter Service' when 'TF001' then 'Transfer Through Commercial  Bank Account' when 'PP001' then 'PayPal' end as payment ")
            _strQuery.Append(",c.telephone,c.transport_type, c.field2 as branch ,c.ship_to_address , convert(nvarchar,c.adddt,100) as order_date,c.field4 as mailbranch ")
            _strQuery.Append(",c.delivery_cost,c.grand_total,c.transport_type,c.Email,c.customer_name+'  '+ c.last_name as CusName_Lastname ")
            _strQuery.Append(",convert(decimal(8,0),c.Promo_Discount) as Promo_Discount, convert(decimal(20,2),c.Promo_Discount_Amount) as Promo_Discount_Amount ")
            _strQuery.Append("from tbt_asbkeo_cus_orderdtl a left join dbo.tbt_jobber_book_search b on a.isbn = b.isbn_13 ")
            _strQuery.Append("left join dbo.ebook_store e on a.ebookid = e.bookid ")
            _strQuery.Append("inner join tbt_asbkeo_cus_order c on a.order_no = c.order_no inner join tbm_syst_Paymentmethod d ")
            _strQuery.Append("on c.Payment_Method_Code = d.Payment_Method_Code ")
            _strQuery.Append("where a.order_no = '" + Invoice + "' order by a.Available_Group_Id,a.orderdtl_no")

            dt = uFunction.getDataTable(uCon.conn, _strQuery.ToString)

            Dim x As String = _strQuery.ToString

            'Try
            '    _strQuery = New StringBuilder
            '    _strQuery.Append("insert into [Payment_Status_byKBANK] ")
            '    _strQuery.Append("([Response Code],[Reference],[Authorize],[UAID],[Invoice] ")
            '    _strQuery.Append(",[Timestamp],[Amount],[Checksum],[Card Type],[ChecksumCard2] ")
            '    _strQuery.Append(",[is_active],[created_date],[created_by]) ")
            '    _strQuery.Append("values ")
            '    _strQuery.Append("('" + ResponseCode + "'") '<Response Code, varchar(2),>
            '    _strQuery.Append(",'" + Reference + "'") '<Reference, varchar(12),>
            '    _strQuery.Append(",'" + Authorize + "'") '<Authorize, varchar(6),>
            '    _strQuery.Append(",'" + UAID + "'") '<UAID, varchar(36),>
            '    _strQuery.Append(",'" + Invoice + "'") '<Invoice, varchar(12),>
            '    _strQuery.Append(",''") '<Timestamp, varchar(14),>
            '    _strQuery.Append(",'" + Amount + "'") '<Amount, varchar(12),>
            '    _strQuery.Append(",'" + Checksum + "'") '<Checksum, varchar(40),>
            '    _strQuery.Append(",'" + CardType + "'") '<Card Type, varchar(20),>
            '    _strQuery.Append(",''") '<ChecksumCard2, varchar(40),>
            '    _strQuery.Append(",'Y'") '<is_active, char(1),>
            '    _strQuery.Append(",getdate()") '<created_date, datetime,>
            '    _strQuery.Append(",'Administrator')") '<created_by, nvarchar(20),>

            '    uFunction.ExecuteDataStringNonTran(uCon.conn, _strQuery.ToString)

            'Catch ex As Exception
            '    GenerateLog("Payment_KBank_Not_SSL", "", "", Invoice, "", "", "https://www.asiabooks.com", "", ex.Message.ToString)
            '    Throw ex
            'End Try

            Dim isAuth As String = ""
            If dt.Rows.Count > 0 Then
                If ResponseCode = "00" Then
                    'ReceivePayment(dt, Invoice)
                    'UpdateMyEBooks(dt, Invoice)
                Else
                    'CancelPayment(dt, Invoice)
                End If
            End If

            Dim Url As String = ConfigurationManager.AppSettings("CC_ResultPage").ToString & "?ResponseCode=" & ResponseCode & "&Invoice=" & Invoice
            ScriptManager.RegisterClientScriptBlock(Me.Page, Me.GetType, "Alert", " window.open('" + Url + "','_parent');", True)

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

    Private Sub UpdateMyEBooks(ByVal dt_eOrdering As DataTable, ByVal Invoice As String)
        Dim sqlDb As New SqlDb
        Dim _strQuery As New StringBuilder

        If dt_eOrdering.Rows.Count > 0 Then
            With dt_eOrdering

                'Order contains ebook.
                If .Select("Available_Group_Id='4'").Length > 0 Then

                    SqlDb.BeginTrans()

                    Try
                        For Each dr As DataRow In .Select("Available_Group_Id='4'")

                            If dr.Item("Is_EB_Order_Placed").ToString <> "Y" Then

                                For j As Integer = 1 To CInt(dr("orderqty"))

                                    Dim Download_URL As String = ""

                                    GenerateLog("PaymentStatus_ByKBank_UpdateMyEBooks", "", "", Invoice, "", "", "https://www.asiabooks.com", "", "supplier_code=" & dr("supplier_code"))

                                    If dr("supplier_code").ToString.Trim.ToLower.Equals("gardners") Then
                                        Download_URL = PN.GetGardnersDownloadURL(dr("sku_13"), dr("EBookID"), dr("orderdtl_no"), j, dr("format_type"), dr("customer_country"), Invoice)
                                    ElseIf dr("supplier_code").ToString.Trim.ToLower.Equals("ingram") Then
                                        Download_URL = PN.GetIngramDownloadURL(dr("sku_13"), dr("EBookID"), dr("orderdtl_no"), j, Invoice, dr("customer_country"))
                                    End If

                                    Dim OrderNoTx As String = Invoice & dr("orderdtl_no") & j

                                    _strQuery = New StringBuilder
                                    _strQuery.Append("insert into [ebook_mylist] ")
                                    _strQuery.Append("([Order_No],[Order_No_Tx],[EBookID],[Supplier_Code],[Member_Id],[Download_URL],[Downloaded_Times],[Enabled_Status],[Tx_Date]) ")
                                    _strQuery.Append("values ")
                                    _strQuery.Append("('" & Invoice & "'")
                                    _strQuery.Append(",'" & OrderNoTx & "'")
                                    _strQuery.Append(",'" & dr("EBookID") & "'")
                                    _strQuery.Append(",'" & dr("supplier_code") & "'")
                                    _strQuery.Append(",'" & dr("Member_Id") & "'")
                                    _strQuery.Append(",'" & Download_URL & "'")
                                    _strQuery.Append(",'0'")
                                    _strQuery.Append(",'Y'")
                                    _strQuery.Append(",getdate())")
                                    sqlDb.Exec(_strQuery.ToString)


                                    _strQuery = New StringBuilder
                                    _strQuery.Append("UPDATE tbt_asbkeo_cus_orderdtl SET ")
                                    _strQuery.Append("Is_EB_Order_Placed = 'Y' ")
                                    _strQuery.Append("WHERE Order_No = '" & Invoice & "' and Orderdtl_No = '" & dr("orderdtl_no") & "' and Available_Group_Id = '" & dr("Available_Group_Id") & "'")
                                    sqlDb.Exec(_strQuery.ToString)

                                Next
                            End If

                        Next

                        SqlDb.CommitTrans()
                    Catch ex As Exception
                        SqlDb.RollbackTrans()
                        GenerateLog("PaymentStatus_ByKBank_UpdateMyEBooks", "", "", Invoice, "", "", "https://www.asiabooks.com", "", ex.Message.ToString)
                        Throw ex
                    End Try

                End If

            End With
        End If

    End Sub

    'Private Function CheckCCTerritory(ByVal CC As String, ByVal CC_Country As String, ByVal dt_eOrdering As DataTable) As Boolean
    '    Dim sqlDb As New SqlDb
    '    'Dim dt_cc_country As DataTable
    '    Dim dt_ebook_country As DataTable
    '    Dim _strQuery As New StringBuilder

    '    Try
    '        '_strQuery = New StringBuilder
    '        '_strQuery.Append("select top 1 country_code from ebook_cc ")
    '        '_strQuery.Append("where cc_number = SUBSTRING('" & CC & "', 1, 4)  ")
    '        '_strQuery.Append("OR cc_number = SUBSTRING('" & CC & "', 1, 6) order by cc_number desc")

    '        'dt_cc_country = sqlDb.GetDataTable(_strQuery.ToString)

    '        'If dt_cc_country.Rows.Count > 0 Then
    '        'Dim firstCountryCodeChar As String = dt_cc_country.Rows(0)(0).ToString.Substring(0, 1)

    '        Dim firstCountryCodeChar As String = CC_Country.ToString.Substring(0, 1)
    '        Dim firstTwoCountryCodeChar As String = CC_Country.ToString.Substring(0, 2)

    '        If dt_eOrdering.Rows.Count > 0 Then
    '            For Each dr As DataRow In dt_eOrdering.Select("Available_Group_Id='4'")

    '                _strQuery = New StringBuilder
    '                _strQuery.Append("SELECT country_code ")
    '                _strQuery.Append(" FROM ebook_territory_" & firstCountryCodeChar)
    '                _strQuery.Append(" where bookid = " & dr("EBookID") & " and (country_code = '" & firstTwoCountryCodeChar & "' or country_code = 'ROW') ")

    '                dt_ebook_country = sqlDb.GetDataTable(_strQuery.ToString)

    '                If dt_ebook_country.Rows.Count > 0 Then
    '                    Return False
    '                End If

    '            Next
    '        End If
    '        'End If
    '    Catch ex As Exception
    '        GenerateLog("PaymentStatus_ByKBank_CheckCCTerritory", "", "", "-", "", "", "https://www.asiabooks.com", "", ex.Message & " - " & ex.GetBaseException.ToString)
    '        Throw ex
    '    End Try

    '    Return True
    'End Function

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
