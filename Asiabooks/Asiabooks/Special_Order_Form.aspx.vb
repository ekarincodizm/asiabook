Imports System
Imports System.Data
Imports asiabooksmember.member

Partial Class Special_Order_Form
    Inherits System.Web.UI.Page
    Private uCon As uConnect
    Dim ds As DataSet
    Dim member As New Member
    Private uClass As New uClass
    Dim SmtpMail As String = Convert.ToString(ConfigurationSettings.AppSettings("SmtpServer"))
    Dim UserPassword As String = Convert.ToString(ConfigurationSettings.AppSettings("MailPassword"))
    Dim UserName As String = Convert.ToString(ConfigurationSettings.AppSettings("MailUserID"))
    Public Sub getUrl(ByVal imagePath As String)

        Response.Write(Request.Url.Scheme.ToString & Uri.SchemeDelimiter.ToString & _
                       Request.Url.Authority.ToString & _
                       IIf(Request.ApplicationPath.ToString = "/", "", Request.ApplicationPath.ToString) & imagePath)

    End Sub

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Me.Title = ConfigurationManager.AppSettings("SiteTitle").ToString & "Special Order Form ::"

        If Not Me.IsPostBack Then
            If Not IsNothing(Request.Cookies("myCookie_user")) Then
                txtCus_Name.Text = Request.Cookies("myCookie_user")("UserName")
                customer()
            Else
                txtCus_Name.Text = ""
            End If

            If Request.QueryString("Keyword") Is Nothing Then
                txtKeyword.Text = "-"
            Else
                txtKeyword.Text = Request.QueryString("Keyword").ToString
            End If
            If Request.QueryString("Meassge") Is Nothing Then
                lblMeassge.Text = "-"
            Else
                lblMeassge.Text = Request.QueryString("Meassge").ToString
            End If

            txtQty.Text = "1"
        End If
    End Sub
    Private Sub customer()
        Dim dt_person As New DataTable
        Dim dt_address As New DataTable
        Dim ds As New DataSet
        Dim strMemberCode As String = ""

        Try
            strMemberCode = Request.Cookies("myCookie_user")("MemberCode")

            ds = member.GetMember(strMemberCode, "2", "ubKPwB6lD2fihnqJycW/TBHP5S9MYMJJ", "asiabooks_emember")
            dt_person = ds.Tables("BS_PERSON")


            If dt_person.Rows.Count > 0 Then
                txtCus_Tel.Text = dt_person.Rows(0).Item("TEL").ToString() & ", " & dt_person.Rows(0).Item("MOBILE_TEL").ToString()
                txtCus_Email.Text = dt_person.Rows(0).Item("EMAIL_ADDRESS").ToString()
            End If

        Catch ex As Exception
            ScriptManager.RegisterClientScriptBlock(Me.Page, Me.GetType, "Alert", _
            "alert('System Error!.,Please try again');", True)
            Exit Sub
        End Try
    End Sub
    Protected Sub btnSave_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnSave.Click
        Dim strSql As String = ""
        Dim Customer_Code As String = ""

        If Not IsNothing(Request.Cookies("myCookie_user")) Then
            Customer_Code = Request.Cookies("myCookie_user")("MemberCode")
        Else
            Customer_Code = ""
        End If

        If txtCus_Name.Text = "" Then
            uScript.Alert(Me.Page, Me.GetType, "Please fill in your name.")
            Exit Sub
        End If
        If txtCus_Email.Text = "" Then
            uScript.Alert(Me.Page, Me.GetType, "Please fill in your Email address.")
            Exit Sub
        End If

        If txtCus_Subject.Text = "" Then
            uScript.Alert(Me.Page, Me.GetType, "Please fill in your subject.")
            Exit Sub
        End If

        If txtDetail.Text = "" Then
            uScript.Alert(Me.Page, Me.GetType, "Please fill in your detail.")
            Exit Sub
        End If

        If txtCus_Tel.Text = "" Then
            uScript.Alert(Me.Page, Me.GetType, "Please fill in your Telephone.")
            Exit Sub
        End If

        Dim strID As String = ""
        uCon = New uConnect

        Dim dt_ID As New DataTable
        Dim IntID As Integer = 0

        dt_ID = uFunction.getDataTable(uCon.conn, "select isnull(max(ID),'') as ID from tbm_AB_eComLog_Customer where month(log_created) = month(getdate())")
        If dt_ID.Rows.Count > 0 Then
            If dt_ID.Rows(0).Item("ID").ToString = "" Then
                strID = "eID" & Now.Date.ToString("yy") & Now.Date.ToString("MM") & "00001"
            Else
                Dim xx As String = dt_ID.Rows(0).Item("ID").ToString.Substring(7, 5)
                IntID = Val(xx) + 1

                Select Case IntID.ToString.Length
                    Case "1"
                        strID = "eID" & Now.Date.ToString("yy") & Now.Date.ToString("MM") & "0000" & IntID.ToString
                    Case "2"
                        strID = "eID" & Now.Date.ToString("yy") & Now.Date.ToString("MM") & "000" & IntID.ToString
                    Case "3"
                        strID = "eID" & Now.Date.ToString("yy") & Now.Date.ToString("MM") & "00" & IntID.ToString
                    Case "5"
                        strID = "eID" & Now.Date.ToString("yy") & Now.Date.ToString("MM") & "0" & IntID.ToString
                End Select
            End If
        Else
            strID = "eID" & Now.Date.ToString("yy") & Now.Date.ToString("MM") & "00001"
        End If

        strSql = ""
        strSql &= " insert into tbm_AB_eComLog_Customer([ID],[Customer_code],[CustomerName],[Cus_email],[Cus_Tel]"
        strSql &= " ,[TypeOfIncident_ID],[excepiton_from_web],[Subject],[UserRequest],[Piority_ID],[req_ISBN]"
        strSql &= " ,[req_Title],[req_Author],[req_Keyword],[req_Publisher],[req_QTY]"
        strSql &= " ,[Is_Active],[Created],[CreatedBy])VALUES("
        strSql &= " '" + strID + "'"
        strSql &= " ,'" + Customer_Code + "'"
        strSql &= " ,'" + txtCus_Name.Text.ToString.Replace("'", "'+Char(39)+'") + "'"
        strSql &= " ,'" + txtCus_Email.Text.ToString.Replace("'", "'+Char(39)+'") + "'"
        strSql &= " ,'" + txtCus_Tel.Text + "'"
        strSql &= " ,'2'"
        strSql &= " ,'" + lblMeassge.Text.ToString.Replace("'", "'+Char(39)+'") + "'"
        strSql &= " ,'" + txtCus_Subject.Text.ToString.Replace("'", "'+Char(39)+'") + "'"
        strSql &= " ,'" + txtDetail.Text.ToString.Replace("'", "'+Char(39)+'") + "'"
        strSql &= " ,'1'"
        strSql &= " ,'" + txtIsbn.Text.ToString.Replace("'", "'+Char(39)+'") + "'"
        strSql &= " ,'" + txtTitle.Text.ToString.Replace("'", "'+Char(39)+'") + "'"
        strSql &= " ,'" + txtAuther.Text.ToString.Replace("'", "'+Char(39)+'") + "'"
        strSql &= " ,'" + txtKeyword.Text.ToString.Replace("'", "'+Char(39)+'") + "'"
        strSql &= " ,'" + txtPublisher.Text.ToString.Replace("'", "'+Char(39)+'") + "'"
        strSql &= " ,'" + txtQty.Text.ToString.Replace("'", "'+Char(39)+'") + "'"
        strSql &= " ,'Y'"
        strSql &= " ,getdate()"
        strSql &= " ,'" + Request.ServerVariables("REMOTE_ADDR") + "')"

        uFunction.ExecuteDataStringNonTran(uCon.conn, strSql)


        Dim strHtml As String = ""
        If txtCus_Email.Text <> "" Then
            strHtml = ""
            strHtml &= "<table cellpadding='0' cellspacing='0' style='width:60%'><tr>"
            strHtml &= "<td style='width: 60%; height:20px; font-family:Arial; font-size:9pt; color:#696969'>Dear " + txtCus_Name.Text + "</td></tr>"
            strHtml &= "<tr><td style='width: 60%; height:20px; font-family:Arial; font-size:9pt; color:#696969'>&nbsp;</td></tr>"
            strHtml &= "<tr><td style='width: 60%; height:20px; font-family:Arial; font-size:9pt; color:#696969'>Thank you for your visiting.</td></tr>"
            strHtml &= "<tr><td style='width: 60%; height:20px; font-family:Arial; font-size:9pt; color:#696969'>"
            strHtml &= "Your message had been reached to our ecommerce team. Our staffs will contact to inform you as soon as possible.</td></tr>"
            strHtml &= "<tr><td style='width: 60%; height:20px; font-family:Arial; font-size:9pt; color:#696969'>&nbsp;</td></tr>"
            strHtml &= "<tr><td style='width: 60%; height:20px; font-family:Arial; font-size:9pt; color:#696969'>Yours sincerely,</td></tr>"
            strHtml &= "<tr><td style='width: 60%; height:20px; font-family:Arial; font-size:9pt; color:#696969'>&nbsp;</td></tr>"
            strHtml &= "<tr><td style='width: 60%; height:20px; font-family:Arial; font-size:9pt; color:#696969'>eCommerce Team</td></tr></table>"

            'Sendmail_customer(strHtml, "Special Order", txtCus_Email.Text, "")
            uClass.SendMail_Inquiry(txtCus_Email.Text, "", "Special Order", strHtml, "")
        End If

        strHtml = ""
        strHtml &= "<table cellpadding='0' cellspacing='0' style='width:60%'><tr>"
        strHtml &= "<td style='width: 60%; height:20px; font-family:Arial; font-size:9pt; color:#696969'>Dear eCommerce Team</td></tr>"
        strHtml &= "<tr><td style='width: 60%; height:20px; font-family:Arial; font-size:9pt; color:#696969'>&nbsp;</td></tr>"
        strHtml &= "<tr><td style='width: 60%; height:20px; font-family:Arial; font-size:9pt; color:#696969'>Running Number : " + strID + "</td></tr>"
        strHtml &= "<tr><td style='width: 60%; height:20px; font-family:Arial; font-size:9pt; color:#696969'>&nbsp;</td></tr>"
        strHtml &= "<tr><td style='width: 60%; height:20px; font-family:Arial; font-size:11pt; color:#FF3300; font-weight: bold'>Customer Information</td></tr>"
        strHtml &= "<tr><td style='width: 60%; height:20px; font-family:Arial; font-size:9pt; color:#696969'>Customer Name : " + txtCus_Name.Text + "</td></tr>"
        strHtml &= "<tr><td style='width: 60%; height:20px; font-family:Arial; font-size:9pt; color:#696969'>Email : " + txtCus_Email.Text + "</td></tr>"
        strHtml &= "<tr><td style='width: 60%; height:20px; font-family:Arial; font-size:9pt; color:#696969'>Tel : " + txtCus_Tel.Text + "</td></tr>"
        strHtml &= "<tr><td style='width: 60%; height:20px; font-family:Arial; font-size:9pt; color:#696969'>Subject : " + txtCus_Subject.Text + "</td></tr>"
        strHtml &= "<tr><td style='width: 60%; height:20px; font-family:Arial; font-size:9pt; color:#696969'>Detail : " + txtDetail.Text + "</td></tr>"
        strHtml &= "<tr><td style='width: 60%; height:20px; font-family:Arial; font-size:9pt; color:#696969'>&nbsp;</td></tr>"
        strHtml &= "<tr><td style='width: 60%; height:20px; font-family:Arial; font-size:11pt; color:#FF3300; font-weight: bold'>Inquiry Information</td></tr>"
        strHtml &= "<tr><td style='width: 60%; height:20px; font-family:Arial; font-size:9pt; color:#696969'>Isbn : " + txtIsbn.Text + "</td></tr>"
        strHtml &= "<tr><td style='width: 60%; height:20px; font-family:Arial; font-size:9pt; color:#696969'>Title : " + txtTitle.Text + "</td></tr>"
        strHtml &= "<tr><td style='width: 60%; height:20px; font-family:Arial; font-size:9pt; color:#696969'>Author : " + txtAuther.Text + "</td></tr>"
        strHtml &= "<tr><td style='width: 60%; height:20px; font-family:Arial; font-size:9pt; color:#696969'>Keyword : " + txtKeyword.Text + "</td></tr>"
        strHtml &= "<tr><td style='width: 60%; height:20px; font-family:Arial; font-size:9pt; color:#696969'>Publisher Name : " + txtPublisher.Text + "</td></tr>"
        strHtml &= "<tr><td style='width: 60%; height:20px; font-family:Arial; font-size:9pt; color:#696969'>Quantity of your order : " + txtQty.Text + "</td></tr>"
        strHtml &= "<tr><td style='width: 60%; height:20px; font-family:Arial; font-size:9pt; color:#696969'>&nbsp;</td></tr>"
        strHtml &= "<tr><td style='width: 60%; height:20px; font-family:Arial; font-size:9pt; color:#696969'>Yours sincerely,</td></tr>"
        strHtml &= "<tr><td style='width: 60%; height:20px; font-family:Arial; font-size:9pt; color:#696969'>&nbsp;</td></tr>"
        strHtml &= "<tr><td style='width: 60%; height:20px; font-family:Arial; font-size:9pt; color:#696969'>Webdev Team</td></tr></table>"

        'Sendmail_customer(strHtml, "CUSTOMER INQUIRY REF " + strID.ToString + "", "ecommerce@asiabooks.com", "aunnop_k@asiabooks.com,porntip_m@asiabooks.com")
        uClass.SendMail_Inquiry("ecommerce@asiabooks.com", "aunnop_k@asiabooks.com,porntip_m@asiabooks.com", "CUSTOMER INQUIRY REF " + strID.ToString, strHtml, "")
        mdlPopUp_Meassge.Show()

    End Sub
    Public Function Sendmail_customer(ByVal strhtml As String, ByVal subject As String, ByVal mailto As String, ByVal mailcc As String) As Boolean
        Dim status As Boolean = True
        Try

            Dim mailMessage As System.Web.Mail.MailMessage = New System.Web.Mail.MailMessage
            mailMessage.From = "ecommerce@asiabooks.com"
            mailMessage.To = mailto
            mailMessage.Cc = mailcc
            mailMessage.Subject = subject
            mailMessage.BodyFormat = System.Web.Mail.MailFormat.Html
            mailMessage.Body = strhtml
            System.Web.Mail.SmtpMail.SmtpServer = "61.90.159.15"

            If Me.UserName <> "" Or Me.UserPassword <> "" Then
                mailMessage.Fields.Add("http://schemas.microsoft.com/cdo/configuration/smtpauthenticate", "1")
                mailMessage.Fields.Add("http://schemas.microsoft.com/cdo/configuration/sendusername", UserName)
                mailMessage.Fields.Add("http://schemas.microsoft.com/cdo/configuration/sendpassword", UserPassword)
            End If
            System.Web.Mail.SmtpMail.Send(mailMessage)
            status = True
        Catch ex As Exception
            status = False
        End Try
        Return status
    End Function
    Protected Sub img_Msg_OK_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles img_Msg_OK.Click
        Response.Redirect("Homepage.aspx")
    End Sub
End Class
