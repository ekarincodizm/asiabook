Imports Eordering.BusinessLogic
Imports System.Data
Imports MycustomDG
Imports Eordering.BusinessLogic.PageControl
Imports Microsoft.VisualBasic
Imports asiabooksmember.member
Partial Class Customer_Profile_Edit
    Inherits System.Web.UI.Page
    Dim member_code As String
    Dim member As New member
    Dim message As String
    Dim Emember As New Cls_Member
    Dim Security As New Cls_security
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Me.Title = ConfigurationManager.AppSettings("SiteTitle").ToString & "Customer edit profile ::"
        If Not Me.IsPostBack Then

            title_code_eng()
            title_code_thai()
            Me.ViewState("action") = Me.Request.QueryString("action").ToString()
            If Me.ViewState("action").ToString() = "Edit" Then
                member_code = Me.Request.QueryString("MEMBER_CODE").ToString()
                ClearTextBox(Me)
                showData()

            End If
            System.Threading.Thread.Sleep(100)
            'ClsStd.myPopCalendar(Page, imgRec, Uc_date_birth.ClientID)
        End If

    End Sub
    Private Sub title_code_eng()
        Dim sqlDB As SqlDb = New SqlDb
        Dim dt As DataTable = New DataTable
        Dim item As New ListItem
        dt = sqlDB.GetDataTable("SELECT distinct title_code as code,title_name_en as name FROM  tbm_asbkeo_title order by title_code")
        cbo_tilte_eng.DataTextField = "name"
        cbo_tilte_eng.DataValueField = "code"
        cbo_tilte_eng.DataSource = dt
        cbo_tilte_eng.DataBind()
        item.Value = ""
        item.Text = " ----- Select ----- "
        cbo_tilte_eng.Items.Insert(0, item)
    End Sub
    Private Sub title_code_thai()
        Dim sqlDB As SqlDb = New SqlDb
        Dim dt As DataTable = New DataTable
        Dim item As New ListItem
        Dim sqlcommand As String

        sqlcommand = "SELECT distinct title_code as code,title_name_thai as name "
        sqlcommand &= " FROM  tbm_asbkeo_title  "
        sqlcommand &= " WHERE title_code='" + Me.cbo_tilte_eng.SelectedItem.Value + "'"
        sqlcommand &= " order by title_code"
        dt = sqlDB.GetDataTable(sqlcommand)
        cbo_tilte_thai.DataTextField = "name"
        cbo_tilte_thai.DataValueField = "code"
        cbo_tilte_thai.DataSource = dt
        cbo_tilte_thai.DataBind()
        'item.Value = ""
        'item.Text = " ----- Select ----- "
        'cbo_tilte_thai.Items.Insert(0, item)
    End Sub
    Private Sub showData()
        Dim dt_member As DataTable
        Dim dt_address As DataTable
        Dim ds As New DataSet
        Dim sqldb As New SqlDb
        Dim i As Integer
        Dim j As Integer
        Dim bs_person_id As String

        If Not member_code Is Nothing Then

            ds = member.GetMember(member_code, "2", "ubKPwB6lD2fihnqJycW/TBHP5S9MYMJJ", "asiabooks_emember")
            dt_member = ds.Tables("BS_PERSON")
            dt_address = ds.Tables("BS_ADDRESS")
            If dt_member.Rows.Count > 0 Then
                For i = i To dt_member.Rows.Count - 1
                    If member_code = dt_member.Rows(i).Item("MEMBER_CODE").ToString() Then

                        Dim title_eng As String
                        title_eng = dt_member.Rows(i).Item("PREFIX_name_en").ToString()
                        Call check_title_eng(title_eng)

                        'Dim title_thai As String
                        'title_thai = dt_member.Rows(i).Item("PREFIX_name_en").ToString()
                        'Call check_title_thai(title_thai)
                        title_code_thai()
                        Me.tbx_name_eng.Text = dt_member.Rows(i).Item("NAME_EN").ToString()
                        Me.tbx_surname_eng.Text = dt_member.Rows(i).Item("SURNAME_EN").ToString()

                        'check name and surname(Thai)-------------------------------------------------------------------
                        If dt_member.Rows(i).Item("NAME_TH").ToString() = "" Then
                            Me.tbx_name_thai.Text = dt_member.Rows(i).Item("NAME_EN").ToString()
                        Else
                            Me.tbx_name_thai.Text = dt_member.Rows(i).Item("NAME_TH").ToString()
                        End If

                        If dt_member.Rows(i).Item("SURNAME_TH").ToString() = "" Then
                            Me.tbx_surname_thai.Text = dt_member.Rows(i).Item("SURNAME_EN").ToString()
                        Else
                            Me.tbx_surname_thai.Text = dt_member.Rows(i).Item("SURNAME_TH").ToString()
                        End If
                        'check name and surname(Thai)-------------------------------------------------------------------
                        'Dim birth As Date = 
                        Me.Uc_date_birth.Value = Convert.ToDateTime(dt_member.Rows(i).Item("BIRTHDAY")).ToString("dd/MM/yyyy")



                        'Me.tbx_age.Text = dt_member.Rows(i).Item("AGE").ToString()
                        Me.tbx_mobile.Text = dt_member.Rows(i).Item("MOBILE_TEL").ToString()
                        Me.tbx_tel.Text = dt_member.Rows(i).Item("TEL").ToString()
                        Me.tbx_email.Text = dt_member.Rows(i).Item("EMAIL_ADDRESS").ToString()
                        'check ------------------------------------------------------------------------------------
                        Dim chk_email As String
                        Dim chk_sms As String
                        Dim chk_mail As String
                        chk_email = dt_member.Rows(i).Item("NEWS_VIA_EMAIL").ToString()
                        If chk_email.ToString = "Y" Then
                            Me.chk_email.Checked = True
                        Else
                            Me.chk_email.Checked = False
                        End If
                        chk_sms = dt_member.Rows(i).Item("NEWS_VIA_SMS").ToString()
                        If chk_sms.ToString = "Y" Then
                            Me.chk_sms.Checked = True
                        Else
                            Me.chk_sms.Checked = False
                        End If
                        chk_mail = dt_member.Rows(i).Item("NEWS_VIA_LETTER").ToString()
                        If chk_mail.ToString = "Y" Then
                            Me.chk_mail.Checked = True
                        Else
                            Me.chk_mail.Checked = False
                        End If
                        'check ------------------------------------------------------------------------------------
                        Me.tbx_id_number.Text = dt_member.Rows(i).Item("CITIZEN_NO").ToString()
                        'Dim nationality As String
                        'nationality = dt_member.Rows(i).Item("NATIONALITY").ToString()
                        'Call check_nationality(nationality)
                        Me.cbo_nationality.SelectedValue = dt_member.Rows(i).Item("NATIONALITY").ToString()
                        'Me.tbx_nationality.Text = dt_member.Rows(i).Item("COUNTRY").ToString()
                        Me.tbx_id_passport.Text = dt_member.Rows(i).Item("PASSPORT_NO").ToString()
                        Me.tbx_children.Text = dt_member.Rows(i).Item("NUM_CHILD").ToString()

                        bs_person_id = dt_member.Rows(i).Item("BS_PERSON_ID").ToString()

                        For j = 0 To dt_address.Rows.Count - 1
                            If bs_person_id = dt_address.Rows(j).Item("BS_PERSON_ID").ToString() Then
                                If j = 0 Then
                                    Me.tbx_place_name_1.Text = dt_address.Rows(j).Item("PLACE_NAME").ToString()
                                    Me.tbx_room_number_1.Text = dt_address.Rows(j).Item("ROOM_NUMBER").ToString()
                                    Me.tbx_place_number_1.Text = dt_address.Rows(j).Item("PLACE_NUMBER").ToString()
                                    Me.tbx_moo_1.Text = dt_address.Rows(j).Item("MOO").ToString()
                                    Me.tbx_alley_1.Text = dt_address.Rows(j).Item("ALLEY").ToString()
                                    Me.tbx_road_1.Text = dt_address.Rows(j).Item("ROAD").ToString()
                                    Me.tbx_district_1.Text = dt_address.Rows(j).Item("DISTRICT").ToString()
                                    Me.tbx_amphur_1.Text = dt_address.Rows(j).Item("AMPHUR").ToString()
                                    Me.tbx_province_1.Text = dt_address.Rows(j).Item("PROVINCE").ToString()
                                    Me.tbx_zipcode_1.Text = dt_address.Rows(j).Item("ZIPCODE").ToString()
                                    Me.tbx_country_1.Text = dt_address.Rows(j).Item("COUNTRY").ToString()

                                End If
                                If j = 1 Then
                                    Me.tbx_place_name_2.Text = dt_address.Rows(j).Item("PLACE_NAME").ToString()
                                    Me.tbx_room_number_2.Text = dt_address.Rows(j).Item("ROOM_NUMBER").ToString()
                                    Me.tbx_place_number_2.Text = dt_address.Rows(j).Item("PLACE_NUMBER").ToString()
                                    Me.tbx_moo_2.Text = dt_address.Rows(j).Item("MOO").ToString()
                                    Me.tbx_alley_2.Text = dt_address.Rows(j).Item("ALLEY").ToString()
                                    Me.tbx_road_2.Text = dt_address.Rows(j).Item("ROAD").ToString()
                                    Me.tbx_district_2.Text = dt_address.Rows(j).Item("DISTRICT").ToString()
                                    Me.tbx_amphur_2.Text = dt_address.Rows(j).Item("AMPHUR").ToString()
                                    Me.tbx_province_2.Text = dt_address.Rows(j).Item("PROVINCE").ToString()
                                    Me.tbx_zipcode_2.Text = dt_address.Rows(j).Item("ZIPCODE").ToString()
                                    Me.tbx_country_2.Text = dt_address.Rows(j).Item("COUNTRY").ToString()

                                End If
                                If j = 2 Then
                                    Me.tbx_place_name_3.Text = dt_address.Rows(j).Item("PLACE_NAME").ToString()
                                    Me.tbx_room_number_3.Text = dt_address.Rows(j).Item("ROOM_NUMBER").ToString()
                                    Me.tbx_place_number_3.Text = dt_address.Rows(j).Item("PLACE_NUMBER").ToString()
                                    Me.tbx_moo_3.Text = dt_address.Rows(j).Item("MOO").ToString()
                                    Me.tbx_alley_3.Text = dt_address.Rows(j).Item("ALLEY").ToString()
                                    Me.tbx_road_3.Text = dt_address.Rows(j).Item("ROAD").ToString()
                                    Me.tbx_district_3.Text = dt_address.Rows(j).Item("DISTRICT").ToString()
                                    Me.tbx_amphur_3.Text = dt_address.Rows(j).Item("AMPHUR").ToString()
                                    Me.tbx_province_3.Text = dt_address.Rows(j).Item("PROVINCE").ToString()
                                    Me.tbx_zipcode_3.Text = dt_address.Rows(j).Item("ZIPCODE").ToString()
                                    Me.tbx_country_3.Text = dt_address.Rows(j).Item("COUNTRY").ToString()
                                End If

                            End If

                        Next

                    End If

                Next
            End If
        End If
    End Sub

    Public Sub check_title_eng(ByVal title As String)
        Dim count As Int16
        count = 0
        If cbo_tilte_eng.Items.Count <> 0 Then
            For Each Item As Object In cbo_tilte_eng.Items
                If title = Item.Text Then
                    Me.cbo_tilte_eng.SelectedIndex = count
                    Exit For
                End If
                count = count + 1
            Next
        End If
    End Sub

    Public Sub check_title_thai(ByVal title As String)
        Dim count As Int16
        count = 0
        If cbo_tilte_thai.Items.Count <> 0 Then
            For Each Item As Object In cbo_tilte_thai.Items
                If title = Item.Text Then
                    Me.cbo_tilte_thai.SelectedIndex = count
                    Exit For
                End If
                count = count + 1
            Next
        End If
    End Sub

    Public Sub ClearTextBox(ByVal root As Control)

        For Each ctrl As Control In root.Controls

            ClearTextBox(ctrl)

            If TypeOf ctrl Is TextBox Then

                CType(ctrl, TextBox).Text = String.Empty

            End If

        Next ctrl

    End Sub
    Protected Sub b_add_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles b_add.Click
        Dim ds As New DataSet
        Try
            If Me.cbo_tilte_eng.Text = "" Then
                'ScriptManager.RegisterClientScriptBlock(Me.Page, Me.GetType, "Alert", "alert('Please Select Title English');", True)
                Me.cbo_tilte_eng.SelectedValue = "200000"
                'Me.cbo_tilte_eng.Focus()
                'Exit Sub
            End If
            If Me.tbx_name_eng.Text = "" Then
                ScriptManager.RegisterClientScriptBlock(Me.Page, Me.GetType, "Alert", "alert('Please fill your name in English.');", True)
                Me.tbx_name_eng.Focus()
                Exit Sub
            End If
            If Me.tbx_surname_eng.Text = "" Then
                ScriptManager.RegisterClientScriptBlock(Me.Page, Me.GetType, "Alert", "alert('Please fill your surname in English.');", True)
                Me.tbx_surname_eng.Focus()
                Exit Sub
            End If
            If Uc_date_birth.Value = "" Then
                Me.Uc_date_birth.Value = "01/01/1900"
                'ScriptManager.RegisterClientScriptBlock(Me.Page, Me.GetType, "Alert", "alert('Please Select Date Of Birth');", True)
                'Uc_date_birth.Focus()
                'Exit Sub
            End If
            If Me.tbx_mobile.Text = "" Then
                ScriptManager.RegisterClientScriptBlock(Me.Page, Me.GetType, "Alert", "alert('Please fill in your mobile phone number.');", True)
                Me.tbx_mobile.Focus()
                Exit Sub
            End If
            If Me.tbx_children.Text = "" Then
                Me.tbx_children.Text = "0"
            End If
            If Me.cbo_nationality.Text = "0" Then
                Me.cbo_nationality.SelectedValue = "470041"
                'Exit Sub
            End If
            If Me.tbx_tel.Text = "" Then
                ScriptManager.RegisterClientScriptBlock(Me.Page, Me.GetType, "Alert", "alert('Please fill in your telephone number.');", True)
                Me.tbx_tel.Focus()
                Exit Sub
            End If
            If Me.tbx_place_name_1.Text = "" Then
                Me.tbx_place_name_1.Text = ""
                'ScriptManager.RegisterClientScriptBlock(Me.Page, Me.GetType, "Alert", "alert('Please Input Place Name For Address1');", True)
                'Me.tbx_place_name_1.Focus()
                ''Exit Sub
            End If
            If Me.tbx_room_number_1.Text = "" Then
                Me.tbx_room_number_1.Text = ""
                'ScriptManager.RegisterClientScriptBlock(Me.Page, Me.GetType, "Alert", "alert('Please Input Room Nunber For Address1');", True)
                'Me.tbx_room_number_1.Focus()
                ''Exit Sub
            End If
            If Me.tbx_place_number_1.Text = "" Then
                Me.tbx_place_number_1.Text = ""
                'ScriptManager.RegisterClientScriptBlock(Me.Page, Me.GetType, "Alert", "alert('Please Input Place Number For Address1');", True)
                'Me.tbx_place_number_1.Focus()
                '' Exit Sub
            End If
            If Me.tbx_moo_1.Text = "" Then
                Me.tbx_moo_1.Text = ""
                'ScriptManager.RegisterClientScriptBlock(Me.Page, Me.GetType, "Alert", "alert('Please Input Moo For Address1');", True)
                'Me.tbx_moo_1.Focus()
                'Exit Sub
            End If
            If Me.tbx_alley_1.Text = "" Then
                Me.tbx_alley_1.Text = ""
                'ScriptManager.RegisterClientScriptBlock(Me.Page, Me.GetType, "Alert", "alert('Please Input Alley For Address1');", True)
                'Me.tbx_alley_1.Focus()
                'Exit Sub
            End If
            If Me.tbx_road_1.Text = "" Then
                tbx_road_1.Text = ""
                'ScriptManager.RegisterClientScriptBlock(Me.Page, Me.GetType, "Alert", "alert('Please Input Road For Address1');", True)
                'Me.tbx_road_1.Focus()
                'Exit Sub
            End If
            If Me.tbx_district_1.Text = "" Then
                Me.tbx_district_1.Text = ""
                'ScriptManager.RegisterClientScriptBlock(Me.Page, Me.GetType, "Alert", "alert('Please Input District For Address1');", True)
                'Me.tbx_district_1.Focus()
                'Exit Sub
            End If
            If Me.tbx_amphur_1.Text = "" Then
                Me.tbx_amphur_1.Text = ""
                'ScriptManager.RegisterClientScriptBlock(Me.Page, Me.GetType, "Alert", "alert('Please Input Amphur For Address1');", True)
                'Me.tbx_amphur_1.Focus()
                'Exit Sub
            End If
            If Me.tbx_province_1.Text = "" Then
                Me.tbx_province_1.Text = ""
                'ScriptManager.RegisterClientScriptBlock(Me.Page, Me.GetType, "Alert", "alert('Please Input Province For Address1');", True)
                'Me.tbx_province_1.Focus()
                'Exit Sub
            End If
            If Me.tbx_zipcode_1.Text = "" Then
                Me.tbx_zipcode_1.Text = ""
                'ScriptManager.RegisterClientScriptBlock(Me.Page, Me.GetType, "Alert", "alert('Please Input Zipcode For Address1');", True)
                'Me.tbx_zipcode_1.Focus()
                'Exit Sub
            End If
            If Me.tbx_country_1.Text = "" Then
                Me.tbx_country_1.Text = ""
                'ScriptManager.RegisterClientScriptBlock(Me.Page, Me.GetType, "Alert", "alert('Please Input Country For Address1');", True)
                'Me.tbx_country_1.Focus()
                'Exit Sub
            End If

            If Me.ViewState("action").ToString() = "Add" Then
                Emember.MEMBER_CODE = ""
            Else
                Emember.MEMBER_CODE = Me.Request.QueryString("MEMBER_CODE").ToString()
            End If
            Emember.BS_V_NAME_PREFIX_ID = Me.cbo_tilte_eng.SelectedItem.Value
            Emember.NEWS_VIA_EMAIL = IIf(Me.chk_email.Checked, "Y", "N")
            Emember.NEWS_VIA_SMS = IIf(Me.chk_sms.Checked, "Y", "N")
            Emember.NEWS_VIA_LETTER = IIf(Me.chk_mail.Checked, "Y", "N")
            Emember.NATIONALITY = Me.cbo_nationality.SelectedItem.Value
            Emember.NAME_EN = Me.tbx_name_eng.Text
            Emember.SURNAME_EN = Me.tbx_surname_eng.Text
            Emember.NAME_TH = Me.tbx_name_thai.Text
            Emember.SURNAME_TH = Me.tbx_surname_thai.Text
            Emember.BIRTHDAY = ClsStd.DateQuery(Uc_date_birth.Value)
            'Emember.BIRTHDAY = Me.UcCalendar1.DateQuery
            Emember.MOBILE_TEL = Me.tbx_mobile.Text
            Emember.TEL = Me.tbx_tel.Text
            Emember.EMAIL_ADDRESS = Me.tbx_email.Text
            Emember.CITIZEN_NO = Me.tbx_id_number.Text
            Emember.PASSPORT_NO = Me.tbx_id_passport.Text
            Emember.NUM_CHILD = Me.tbx_children.Text

            Emember.PLACE_NAME_H = Me.tbx_place_name_1.Text
            Emember.ROOM_NUMBER_H = Me.tbx_room_number_1.Text
            Emember.PLACE_NUMBER_H = Me.tbx_place_number_1.Text
            Emember.MOO_H = Me.tbx_moo_1.Text
            Emember.ALLEY_H = Me.tbx_alley_1.Text
            Emember.ROAD_H = Me.tbx_road_1.Text
            Emember.DISTRICT_H = Me.tbx_district_1.Text
            Emember.AMPHUR_H = Me.tbx_amphur_1.Text
            Emember.PROVINCE_H = Me.tbx_province_1.Text
            Emember.ZIPCODE_H = Me.tbx_zipcode_1.Text
            Emember.COUNTRY_H = Me.tbx_country_1.Text

            Emember.PLACE_NAME_O = Me.tbx_place_name_2.Text
            Emember.ROOM_NUMBER_O = Me.tbx_room_number_2.Text
            Emember.PLACE_NUMBER_O = Me.tbx_place_number_2.Text
            Emember.MOO_O = Me.tbx_moo_2.Text
            Emember.ALLEY_O = Me.tbx_alley_2.Text
            Emember.ROAD_O = Me.tbx_road_2.Text
            Emember.DISTRICT_O = Me.tbx_district_2.Text
            Emember.AMPHUR_O = Me.tbx_amphur_2.Text
            Emember.PROVINCE_O = Me.tbx_province_2.Text
            Emember.ZIPCODE_O = Me.tbx_zipcode_2.Text
            Emember.COUNTRY_O = Me.tbx_country_2.Text

            Emember.PLACE_NAME_S = Me.tbx_place_name_3.Text
            Emember.ROOM_NUMBER_S = Me.tbx_room_number_3.Text
            Emember.PLACE_NUMBER_S = Me.tbx_place_number_3.Text
            Emember.MOO_S = Me.tbx_moo_3.Text
            Emember.ALLEY_S = Me.tbx_alley_3.Text
            Emember.ROAD_S = Me.tbx_road_3.Text
            Emember.DISTRICT_S = Me.tbx_district_3.Text
            Emember.AMPHUR_S = Me.tbx_amphur_3.Text
            Emember.PROVINCE_S = Me.tbx_province_3.Text
            Emember.ZIPCODE_S = Me.tbx_zipcode_3.Text
            Emember.COUNTRY_S = Me.tbx_country_3.Text


            ds = Emember.Post_Member

            Dim check_return_add As String
            Dim check_return_edit As String
            Dim add As Array
            Dim edit As Array
            If Me.ViewState("action").ToString() = "Add" Then
                check_return_add = member.PostMember("A", ds, "ubKPwB6lD2fihnqJycW/TBHP5S9MYMJJ", "", "", False)
                add = check_return_add.Split("|")
                If add(0) = "True" Then ' if ที่ใช้งานจริง
                    Session.Remove("member_code")
                    Session.Remove("dt_bs_person")
                    Session("member_code") = add(1)
                    ScriptManager.RegisterClientScriptBlock(Me.Page, Me.GetType, "Alert", _
                        "alert('Your registration is successful. Your member code is " + add(1) + " \n Welcome to customer order.');" _
                        & "window.location.href='Customer_Order_Internet.aspx';", True)
                    'If Session("sales_channel") = ConfigurationSettings.AppSettings("UserDirectSale") Then
                    '    ScriptManager.RegisterClientScriptBlock(Me.Page, Me.GetType, "Alert", _
                    '    "alert('Your registration is successful. Your member code is " + add(1) + " \n Welcome to customer order.');", True)
                    '    '& "window.location.href='Customer_Order_Directsales.aspx';", True)

                    'ElseIf Session("sales_channel") = ConfigurationSettings.AppSettings("UserInternet") Then
                    '    ScriptManager.RegisterClientScriptBlock(Me.Page, Me.GetType, "Alert", _
                    '    "alert('Your registration is successful. Your member code is " + add(1) + " \n Welcome to customer order.');" _
                    '    & "window.location.href='Customer_Order_Internet.aspx';", True)

                    'Else
                    '    ScriptManager.RegisterClientScriptBlock(Me.Page, Me.GetType, "Alert", _
                    '    "alert('Your registration is successful. Your member code is " + add(1) + " \n Welcome to customer order.');", True)
                    '    '& "window.location.href='member_search.aspx';", True)

                    'End If
                Else
                    ScriptManager.RegisterClientScriptBlock(Me.Page, Me.GetType, "Alert", _
                    "alert('Your registration is unsuccessful because " + add(1) + "');", True)
                    Exit Sub
                End If

            Else

                check_return_edit = member.PostMember("U", ds, "ubKPwB6lD2fihnqJycW/TBHP5S9MYMJJ", "", "", False)
                edit = check_return_edit.Split("|")
                If edit(0) = "True" Then
                    Session.Remove("member_code")
                    Session.Remove("dt_bs_person")
                    Session("member_code") = edit(1)

                    If Not IsNothing(Request.QueryString("Page_Order")) Then
                        ScriptManager.RegisterClientScriptBlock(Me.Page, Me.GetType, "Alert", _
                           "alert('Your update on membership details was successful.  Your member code is  " + edit(1) + " \n Welcome to Customer order.');" _
                           & "window.location.href='Customer_Order_Internet.aspx';", True)

                    Else
                        ScriptManager.RegisterClientScriptBlock(Me.Page, Me.GetType, "Alert", _
                           "alert('Your update on membership details was successful.  Your member code is  " + edit(1) + " \n Welcome to Customer order.');" _
                           & "window.location.href='Customer_Profile.aspx';", True)

                    End If



                    'If Session("sales_channel") = ConfigurationSettings.AppSettings("UserDirectSale") Then
                    '    ScriptManager.RegisterClientScriptBlock(Me.Page, Me.GetType, "Alert", _
                    '    "alert('Your update on membership details was successful.  Your member code is  " + edit(1) + " \n Welcome to Customer order.');", True)
                    '    '& "window.location.href='Customer_Order_Directsales.aspx';", True)
                    'ElseIf Session("sales_channel") = ConfigurationSettings.AppSettings("UserInternet") Then
                    '    ScriptManager.RegisterClientScriptBlock(Me.Page, Me.GetType, "Alert", _
                    '    "alert('Your update on membership details was successful.  Your member code is  " + edit(1) + " \n Welcome to Customer order.');" _
                    '    & "window.location.href='Customer_Order_Internet_Internet.aspx';", True)
                    'Else
                    '    ScriptManager.RegisterClientScriptBlock(Me.Page, Me.GetType, "Alert", _
                    '    "alert('Your update on membership details was successful.  Your member code is  " + edit(1) + " \n Welcome to Customer order.');", True)
                    '    '& "window.location.href='Customer_Order_emp.aspx';", True)
                    'End If

                Else
                    ScriptManager.RegisterClientScriptBlock(Me.Page, Me.GetType, "Alert", _
                    "alert('Your update on membership was unsuccessful because " + edit(1) + "');", True)
                    Exit Sub
                End If
            End If

        Catch ex As Exception
            ScriptManager.RegisterClientScriptBlock(Me.Page, Me.GetType, "Alert", _
            "alert('System Error!.,Please try again.');", True)
            Exit Sub
        End Try
    End Sub

    Public Shared Function valid_email(ByVal email_str As String) As Boolean
        'CHECK FOR EMAIL FORMAT - THIS PATTERN REQUIRES MORE THEN 1 CHARACHTER PRECEDING THE @ SYMBOL??
        Dim reg_exp As New Regex("^[\w][\w\.-]*[\w]@[\w][\w\.-]*[\w]\.[a-zA-Z][a-zA-Z\.]*[a-zA-Z]$")
        valid_email = reg_exp.IsMatch(email_str)
    End Function

    Protected Sub cbo_tilte_eng_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs)
        title_code_thai()
    End Sub


    Protected Sub chk_add2_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles chk_add2.CheckedChanged
        Dim chk_add2 As String
        chk_add2 = IIf(Me.chk_add2.Checked, "Y", "N")
        If chk_add2 = "Y" Then
            Me.tbx_place_name_2.Text = Me.tbx_place_name_1.Text
            Me.tbx_room_number_2.Text = Me.tbx_room_number_1.Text
            Me.tbx_place_number_2.Text = Me.tbx_place_number_1.Text
            Me.tbx_moo_2.Text = Me.tbx_moo_1.Text
            Me.tbx_alley_2.Text = Me.tbx_alley_1.Text
            Me.tbx_road_2.Text = Me.tbx_road_1.Text
            Me.tbx_district_2.Text = Me.tbx_district_1.Text
            Me.tbx_amphur_2.Text = Me.tbx_amphur_1.Text
            Me.tbx_province_2.Text = Me.tbx_province_1.Text
            Me.tbx_zipcode_2.Text = Me.tbx_zipcode_1.Text
            Me.tbx_country_2.Text = Me.tbx_country_1.Text
        Else
            Me.tbx_place_name_2.Text = ""
            Me.tbx_room_number_2.Text = ""
            Me.tbx_place_number_2.Text = ""
            Me.tbx_moo_2.Text = ""
            Me.tbx_alley_2.Text = ""
            Me.tbx_road_2.Text = ""
            Me.tbx_district_2.Text = ""
            Me.tbx_amphur_2.Text = ""
            Me.tbx_province_2.Text = ""
            Me.tbx_zipcode_2.Text = ""
            Me.tbx_country_2.Text = ""
        End If
    End Sub


    Protected Sub rdoCurrent_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles rdoCurrent.CheckedChanged
        Me.tbx_place_name_3.Text = Me.tbx_place_name_1.Text
        Me.tbx_room_number_3.Text = Me.tbx_room_number_1.Text
        Me.tbx_place_number_3.Text = Me.tbx_place_number_1.Text
        Me.tbx_moo_3.Text = Me.tbx_moo_1.Text
        Me.tbx_alley_3.Text = Me.tbx_alley_1.Text
        Me.tbx_road_3.Text = Me.tbx_road_1.Text
        Me.tbx_district_3.Text = Me.tbx_district_1.Text
        Me.tbx_amphur_3.Text = Me.tbx_amphur_1.Text
        Me.tbx_province_3.Text = Me.tbx_province_1.Text
        Me.tbx_zipcode_3.Text = Me.tbx_zipcode_1.Text
        Me.tbx_country_3.Text = Me.tbx_country_1.Text
    End Sub

    Protected Sub rdoOffice_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles rdoOffice.CheckedChanged
        Me.tbx_place_name_3.Text = Me.tbx_place_name_2.Text
        Me.tbx_room_number_3.Text = Me.tbx_room_number_2.Text
        Me.tbx_place_number_3.Text = Me.tbx_place_number_2.Text
        Me.tbx_moo_3.Text = Me.tbx_moo_2.Text
        Me.tbx_alley_3.Text = Me.tbx_alley_2.Text
        Me.tbx_road_3.Text = Me.tbx_road_2.Text
        Me.tbx_district_3.Text = Me.tbx_district_2.Text
        Me.tbx_amphur_3.Text = Me.tbx_amphur_2.Text
        Me.tbx_province_3.Text = Me.tbx_province_2.Text
        Me.tbx_zipcode_3.Text = Me.tbx_zipcode_2.Text
        Me.tbx_country_3.Text = Me.tbx_country_2.Text
    End Sub

End Class
