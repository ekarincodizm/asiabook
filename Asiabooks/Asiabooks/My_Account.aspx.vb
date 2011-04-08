Imports Eordering.BusinessLogic
Imports System.Web.UI
Imports System
Imports System.Data
Imports MycustomDG
Imports Eordering.BusinessLogic.PageControl
Imports Microsoft.VisualBasic
Imports asiabooksmember.member

Partial Class My_Account
    Inherits System.Web.UI.Page
    Dim email_pass As String
    Dim dt_bs_person As DataTable
    Dim dt_bs_address As DataTable
    Dim ds As DataSet
    Dim member As Member
    Dim member_code As String
    Dim message As String
    Dim Emember As Cls_Member
    Private uCon As uConnect

    Private Sub setDefault()
        Me.tbx_email.Attributes.Add("onkeydown", "if(event.which || event.keyCode){if ((event.which == 13) || (event.keyCode == 13)) {document.getElementById('" + b_search.UniqueID + "').click();return false;}} else {return true}; ")
        Me.tbx_pass.Attributes.Add("onkeydown", "if(event.which || event.keyCode){if ((event.which == 13) || (event.keyCode == 13)) {document.getElementById('" + b_search.UniqueID + "').click();return false;}} else {return true}; ")

        Me.tbx_name.Attributes.Add("onkeydown", "if(event.which || event.keyCode){if ((event.which == 13) || (event.keyCode == 13)) {document.getElementById('" + b_add.UniqueID + "').click();return false;}} else {return true}; ")
        Me.tbx_surname.Attributes.Add("onkeydown", "if(event.which || event.keyCode){if ((event.which == 13) || (event.keyCode == 13)) {document.getElementById('" + b_add.UniqueID + "').click();return false;}} else {return true}; ")
        Me.tbx_email1.Attributes.Add("onkeydown", "if(event.which || event.keyCode){if ((event.which == 13) || (event.keyCode == 13)) {document.getElementById('" + b_add.UniqueID + "').click();return false;}} else {return true}; ")
        Me.tbx_pass1.Attributes.Add("onkeydown", "if(event.which || event.keyCode){if ((event.which == 13) || (event.keyCode == 13)) {document.getElementById('" + b_add.UniqueID + "').click();return false;}} else {return true}; ")
        Me.tbx_contpass.Attributes.Add("onkeydown", "if(event.which || event.keyCode){if ((event.which == 13) || (event.keyCode == 13)) {document.getElementById('" + b_add.UniqueID + "').click();return false;}} else {return true}; ")

        Me.hdSessiongRegister.Value = "captcharegis"
        Me.captchaRegister.SessionCaptcha = Me.hdSessiongRegister.Value
        Me.captchaRegister.InvalidCaptcha = True

        'Me.hdSessiongForgot_MemberCode.Value = "captchaforgot_member_code"
        'Me.captcha_forgotmember_code.SessionCaptcha = Me.hdSessiongForgot_MemberCode.Value
        'Me.captcha_forgotmember_code.InvalidCaptcha = True

    End Sub
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Me.Title = ConfigurationManager.AppSettings("SiteTitle").ToString & "My account ::"

        If Not Me.IsPostBack Then
            Try
                Me.setDefault()

                If Not IsNothing(Request.Cookies("myCookie_user")) Then
                    Response.Redirect("Customer_Profile.aspx")
                End If
            Catch ex As Exception

            End Try
        End If

    End Sub
    Private Sub setCookie(ByVal MemberCode As String, ByVal UserName As String, ByVal CatCode As String)
        Dim userCookie As New HttpCookie("myCookie_user")

        userCookie.Values.Add("MemberCode", MemberCode)
        userCookie.Values.Add("UserName", UserName)
        userCookie.Values.Add("CatCode", CatCode)
        userCookie.Expires = Now.Date.AddDays(7)

        Response.Cookies.Add(userCookie)

    End Sub

    Protected Sub b_search_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles b_search.Click
        Dim chkStatus As Integer = 0

        If Me.tbx_email.Text = "" Then
            ScriptManager.RegisterClientScriptBlock(Me.Page, Me.GetType, "Alert", "alert('Please fill in  your Email address.');", True)
            tbx_email.Focus()
            Exit Sub
        End If
        If Me.tbx_pass.Text = "" Then
            ScriptManager.RegisterClientScriptBlock(Me.Page, Me.GetType, "Alert", "alert('Please fill in your password.');", True)
            tbx_pass.Focus()
            Exit Sub
        End If

        Try
            member = New Member
            uCon = New uConnect

            email_pass = Me.tbx_email.Text.Trim
            ds = member.GetMember(email_pass, 1, "ubKPwB6lD2fihnqJycW/TBHP5S9MYMJJ", tbx_pass.Text.Trim)
            dt_bs_person = ds.Tables("BS_PERSON")
            Session("BS_PERSON") = ds.Tables("BS_PERSON")

            If dt_bs_person.Rows.Count > 0 Then
                Session("member_code") = dt_bs_person.Rows(0).Item("MEMBER_CODE").ToString()

                Dim dt_cat As New DataTable
                dt_cat = uFunction.getDataTable(uCon.conn, "select * from tbm_AB_Member_HitCat where member_code = '" + dt_bs_person.Rows(0).Item("MEMBER_CODE").ToString() + "'")
                If dt_cat.Rows.Count > 0 Then
                    setCookie(dt_bs_person.Rows(0).Item("MEMBER_CODE").ToString(), dt_bs_person.Rows(0).Item("NAME_EN").ToString(), dt_cat.Rows(0).Item("hitCat").ToString)
                Else
                    setCookie(dt_bs_person.Rows(0).Item("MEMBER_CODE").ToString(), dt_bs_person.Rows(0).Item("NAME_EN").ToString(), "")
                End If

                If "INTERNET" = ConfigurationManager.AppSettings("UserInternet").ToString Then
                    If Session("CachePage") Is Nothing Then
                        Response.Redirect("Customer_Profile.aspx")
                    Else
                        Response.Redirect(Session("CachePage"))
                    End If

                End If
            Else
                uScript.Alert(Me.Page, Me.GetType, "Login is unsuccessful because your password is incorrect. Please try again.")
            End If
        Catch ex As Exception
            uScript.Alert(Me.Page, Me.GetType, "System Error!.,Please try again")
        Finally
            member = Nothing
            uCon = Nothing
        End Try
    End Sub

    Protected Sub b_add_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles b_add.Click
        If Session(Me.hdSessiongRegister.Value).ToString = Me.txtCaptchaRegis.Text Then
            Dim check_return_add As String
            Dim pipe As Array
            Dim dt_cat As New DataTable

            Try
                If Me.tbx_name.Text = "" Then
                    message = "Please fill in your first name."
                    uScript.Alert(Me.Page, Me.GetType, message)
                    Exit Sub
                End If
                If Me.tbx_surname.Text = "" Then
                    message = "Please fill in your last name."
                    uScript.Alert(Me.Page, Me.GetType, message)
                    Exit Sub
                End If
                If Me.tbx_email1.Text = "" Then
                    message = "Please fill in your e-mail address."
                    uScript.Alert(Me.Page, Me.GetType, message)
                    Exit Sub
                End If
                If Me.tbx_tel.Text = "" Then
                    message = "Please fill in your telephone or mobile."
                    uScript.Alert(Me.Page, Me.GetType, message)
                    Exit Sub
                End If
                If Me.tbx_pass1.Text = "" Then
                    message = "Please fill in your password."
                    uScript.Alert(Me.Page, Me.GetType, message)
                    Exit Sub
                End If
                If Me.tbx_contpass.Text = "" Then
                    message = "Please fill in your confirm password."
                    uScript.Alert(Me.Page, Me.GetType, message)
                    Exit Sub
                End If
                If tbx_contpass.Text <> tbx_pass1.Text Then
                    message = "your password was incorrect. Please try again."
                    uScript.Alert(Me.Page, Me.GetType, message)
                    tbx_contpass.Focus()
                    Exit Sub
                End If

                member = New Member
                Emember = New Cls_Member

                Emember.MEMBER_CODE = ""
                Emember.BS_V_NAME_PREFIX_ID = "200000"
                Emember.NEWS_VIA_EMAIL = "N"
                Emember.NEWS_VIA_SMS = "N"
                Emember.NEWS_VIA_LETTER = "N"
                Emember.NATIONALITY = "470041"
                Emember.NAME_EN = Me.tbx_name.Text
                Emember.SURNAME_EN = Me.tbx_surname.Text
                Emember.NAME_TH = ""
                Emember.SURNAME_TH = ""
                Emember.BIRTHDAY = ""
                Emember.MOBILE_TEL = ""
                Emember.TEL = Me.tbx_tel.Text
                Emember.EMAIL_ADDRESS = Me.tbx_email1.Text
                Emember.CITIZEN_NO = ""
                Emember.PASSPORT_NO = ""
                Emember.NUM_CHILD = "0"

                Emember.PLACE_NAME_H = ""
                Emember.ROOM_NUMBER_H = ""
                Emember.PLACE_NUMBER_H = ""
                Emember.MOO_H = ""
                Emember.ALLEY_H = ""
                Emember.ROAD_H = ""
                Emember.DISTRICT_H = ""
                Emember.AMPHUR_H = ""
                Emember.PROVINCE_H = ""
                Emember.ZIPCODE_H = ""
                Emember.COUNTRY_H = ""

                Emember.PLACE_NAME_O = ""
                Emember.ROOM_NUMBER_O = ""
                Emember.PLACE_NUMBER_O = ""
                Emember.MOO_O = ""
                Emember.ALLEY_O = ""
                Emember.ROAD_O = ""
                Emember.DISTRICT_O = ""
                Emember.AMPHUR_O = ""
                Emember.PROVINCE_O = ""
                Emember.ZIPCODE_O = ""
                Emember.COUNTRY_O = ""

                Emember.PLACE_NAME_S = ""
                Emember.ROOM_NUMBER_S = ""
                Emember.PLACE_NUMBER_S = ""
                Emember.MOO_S = ""
                Emember.ALLEY_S = ""
                Emember.ROAD_S = ""
                Emember.DISTRICT_S = ""
                Emember.AMPHUR_S = ""
                Emember.PROVINCE_S = ""
                Emember.ZIPCODE_S = ""
                Emember.COUNTRY_S = ""

                ds = Emember.Post_Member

                check_return_add = member.PostMember("A", ds, "ubKPwB6lD2fihnqJycW/TBHP5S9MYMJJ", tbx_email1.Text, tbx_pass1.Text, True)
                pipe = check_return_add.Split("|")
                If pipe(0) = "True" Then ' if ·Õèãªé§Ò¹¨ÃÔ§
                    Session("member_code") = pipe(1)
                    ds = member.GetMember(Me.tbx_email1.Text, "3", "ubKPwB6lD2fihnqJycW/TBHP5S9MYMJJ", "asiabooks_emember")
                    Session("BS_PERSON") = ds.Tables("BS_PERSON")


                    uCon = New uConnect
                    dt_cat = uFunction.getDataTable(uCon.conn, "select * from tbm_AB_Member_HitCat where member_code = '" + ds.Tables("BS_PERSON").Rows(0).Item("MEMBER_CODE").ToString() + "'")

                    If dt_cat.Rows.Count > 0 Then
                        setCookie(ds.Tables("BS_PERSON").Rows(0).Item("MEMBER_CODE").ToString(), _
                                  ds.Tables("BS_PERSON").Rows(0).Item("NAME_EN").ToString(), _
                                  dt_cat.Rows(0).Item("hitCat").ToString)

                    Else
                        setCookie(ds.Tables("BS_PERSON").Rows(0).Item("MEMBER_CODE").ToString(), _
                                  ds.Tables("BS_PERSON").Rows(0).Item("NAME_EN").ToString(), "")

                    End If

                    If Session("CachePage") Is Nothing Then
                        Response.Redirect("Customer_Profile.aspx")
                    Else
                        Response.Redirect(Session("CachePage"))
                    End If
                Else
                    uScript.Alert(Me.Page, Me.GetType, "Your registration is unsuccessful because " + pipe(1).ToString)
                End If



            Catch ex As Exception
                uScript.Alert(Me.Page, Me.GetType, "System Error!.,Please try again")

            Finally
                uCon = Nothing
                check_return_add = Nothing
                pipe = Nothing
                dt_cat = Nothing
                Emember = Nothing
                member = Nothing
            End Try
        Else
            uScript.Alert(Me.Page, Me.GetType, "Not match, try again!")
            Session(Me.hdSessiongRegister.Value) = Nothing
            Me.captchaRegister.InvalidCaptcha = True
        End If
    End Sub

    Protected Sub lnkRefresh_Register_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lnkRefresh_Register.Click
        Session(Me.hdSessiongRegister.Value) = Nothing
        Me.captchaRegister.InvalidCaptcha = True
    End Sub

    Protected Sub img_Meassge_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles img_Meassge.Click
        Response.Redirect("My_Account.aspx")
    End Sub

    Protected Sub lnkPopup_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lnkPopup.Click
        Me.txtmail_forgot.Text = ""
        Me.txtCaptcha.Text = ""

        Me.hdSessionNameForgotPass.Value = "captchaforgot"
        Me.ForgotCaptcha.SessionCaptcha = Me.hdSessionNameForgotPass.Value
        Me.ForgotCaptcha.InvalidCaptcha = True
        Me.mdlPopupForgotPass.Show()
    End Sub
    Protected Sub lnkRefresh_forgot_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lnkRefresh_forgot.Click

        Me.ForgotCaptcha.SessionCaptcha = Me.hdSessionNameForgotPass.Value
        Session(Me.hdSessionNameForgotPass.Value) = Nothing
        Me.ForgotCaptcha.InvalidCaptcha = True
        Me.mdlPopupForgotPass.Show()
    End Sub
    Protected Sub b_Forgot_Pass_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles b_Forgot_Pass.Click
        If Session(Me.hdSessionNameForgotPass.Value).ToString = Me.txtCaptcha.Text Then
            Dim i As Integer = 0
            Dim forgot As String = ""
            Dim pipe As Array = Nothing

            i = i + 1
            If i = 1 Then
                If txtmail_forgot.Text = "" And txtmember_code_forgot.Text = "" Then
                    uScript.Alert(Me.Page, Me.GetType, "Email is not valid")
                    tbx_email.Focus()

                Else
                    Try
                        member = New Member
                        If txtmail_forgot.Text <> "" Then
                            forgot = member.GetPassword(txtmail_forgot.Text, 1, "ubKPwB6lD2fihnqJycW/TBHP5S9MYMJJ")
                        End If
                        If txtmember_code_forgot.Text <> "" Then
                            forgot = member.GetPassword(txtmember_code_forgot.Text, 2, "ubKPwB6lD2fihnqJycW/TBHP5S9MYMJJ")
                        End If

                        pipe = forgot.Split("|")

                        If pipe(0) = "True" Then
                            'Send User And Password To eMail
                            If pipe(1) = "Mail" Then
                                'uScript.Alert(Me.Page, Me.GetType, "Password already sent to your email.,Please check password in your email.")
                                txtmail_forgot.Text = ""
                                txtCaptcha.Text = ""
                                If InStr(pipe(2).ToString, "@") Then
                                    lblemail_member.Text = pipe(2).ToString
                                    mdlPopupForgotPass.Hide()
                                    mdlPopUp_Meassge.Show()
                                Else
                                    uScript.Alert(Me.Page, Me.GetType, "For More Information, Please contact Staff. \n (Monday-Friday 8.30 am.- 5.30 pm.) Tel: (662) 715-9000 ext. 8102, 8103")
                                    Me.ForgotCaptcha.InvalidCaptcha = True
                                    Me.mdlPopupForgotPass.Show()
                                End If

                                'Password For Login is Customer Frist Name
                            ElseIf pipe(1) = "Name" Then
                                'uScript.Alert(Me.Page, Me.GetType, "Please use your first name [English] is password for login. \n\n For More Information, Please contact Staff. \n (Monday-Friday 8.30 am.- 5.30 pm.) Tel: (662) 715-9000 ext. 8102, 8103")
                                uScript.Alert(Me.Page, Me.GetType, "For More Information, Please contact Staff. \n (Monday-Friday 8.30 am.- 5.30 pm.) Tel: (662) 715-9000 ext. 8102, 8103")
                                Me.ForgotCaptcha.InvalidCaptcha = True
                                Me.mdlPopupForgotPass.Show()
                            Else
                                uScript.Alert(Me.Page, Me.GetType, "For More Information, Please contact Staff. \n (Monday-Friday 8.30 am.- 5.30 pm.) Tel: (662) 715-9000 ext. 8102, 8103")
                                Me.ForgotCaptcha.InvalidCaptcha = True
                                Me.mdlPopupForgotPass.Show()
                            End If

                        ElseIf pipe(0) = "False" Then
                            uScript.Alert(Me.Page, Me.GetType, "Your Email is not found. Please input new email.")
                            Me.ForgotCaptcha.InvalidCaptcha = True
                            Me.mdlPopupForgotPass.Show()
                        End If
                    Catch ex As Exception
                        uScript.Alert(Me.Page, Me.GetType, "System Error!.,Please try again")
                        Exit Sub
                    End Try
                End If
            End If

        Else
            uScript.Alert(Me.Page, Me.GetType, "Not match, try again!")
            Session(Me.hdSessionNameForgotPass.Value) = Nothing
            Me.ForgotCaptcha.InvalidCaptcha = True
            Me.mdlPopupForgotPass.Show()

        End If
    End Sub

    'Protected Sub btnForgot_Member_Code_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles btnForgot_Member_Code.Click
    '    If Session(Me.hdSessiongForgot_MemberCode.Value).ToString = Me.txtCaptcha_forgotMember_Code.Text Then
    '        Dim i As Integer = 0
    '        Dim forgot As String = ""
    '        Dim pipe As Array = Nothing

    '        i = i + 1
    '        If i = 1 Then
    '            If txtmember_code_forgot0.Text = "" Then
    '                uScript.Alert(Me.Page, Me.GetType, "Email is not valid")
    '                tbx_email.Focus()

    '            Else
    '                Try
    '                    member = New Member

    '                    If txtmember_code_forgot0.Text <> "" Then
    '                        forgot = member.GetPassword(txtmember_code_forgot0.Text, 2, "ubKPwB6lD2fihnqJycW/TBHP5S9MYMJJ")
    '                    End If

    '                    pipe = forgot.Split("|")

    '                    If pipe(0) = "True" Then
    '                        'Send User And Password To eMail
    '                        If pipe(1) = "Mail" Then
    '                            'uScript.Alert(Me.Page, Me.GetType, "Password already sent to your email.,Please check password in your email.")
    '                            txtmail_forgot.Text = ""
    '                            txtCaptcha_forgotMember_Code.Text = ""
    '                            lblemail_member.Text = pipe(2).ToString
    '                            mdlPopUp_Meassge.Show()

    '                            'Password For Login is Customer Frist Name
    '                        ElseIf pipe(1) = "Name" Then
    '                            uScript.Alert(Me.Page, Me.GetType, "Please use your first name [English] is password for login. \n\n For More Information, Please contact Staff. \n (Monday-Friday 8.30 am.- 5.30 pm.) Tel: (662) 715-9000 ext. 8103, 3202")
    '                            Me.captcha_forgotmember_code.InvalidCaptcha = True
    '                        Else
    '                            uScript.Alert(Me.Page, Me.GetType, "For More Information, Please contact Staff. \n (Monday-Friday 8.30 am.- 5.30 pm.) Tel: (662) 715-9000 ext. 8103, 3202")
    '                            Me.captcha_forgotmember_code.InvalidCaptcha = True
    '                        End If

    '                    ElseIf pipe(0) = "False" Then
    '                        uScript.Alert(Me.Page, Me.GetType, "Your Email is not found. Please input new email.")
    '                        Me.captcha_forgotmember_code.InvalidCaptcha?= True
    '                    End If
    '                Catch ex As Exception
    '                    uScript.Alert(Me.Page, Me.GetType, "System Error!.,Please try again")
    '                    Exit Sub
    '                End Try
    '            End If
    '        End If

    '    Else
    '        uScript.Alert(Me.Page, Me.GetType, "Not match, try again!")
    '        Session(Me.hdSessiongForgot_MemberCode.Value) = Nothing
    '        Me.captcha_forgotmember_code.InvalidCaptcha = True

    '    End If
    'End Sub

    'Protected Sub lnkRefresh_forgotMemberCode_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lnkRefresh_forgotMemberCode.Click
    '    Session(Me.hdSessiongForgot_MemberCode.Value) = Nothing
    '    Me.captcha_forgotmember_code.InvalidCaptcha = True
    'End Sub
End Class
