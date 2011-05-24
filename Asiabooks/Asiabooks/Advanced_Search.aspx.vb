Imports Eordering.BusinessLogic
Imports System
Imports System.Data
Imports Eordering.BusinessLogic.PageControl
Imports System.Xml
Imports System.Xml.Linq
Imports System.Linq
Imports System.Globalization

Partial Class Advanced_Search
    Inherits System.Web.UI.Page
    Private _Utility As New clsUtility
    Private class_book_detail As New Class_book_detail
    Private uCon As uConnect
   
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Me.Title = ConfigurationManager.AppSettings("SiteTitle").ToString & "Advanced Search ::"
        Me.txtIsbn.Attributes.Add("Onkeypress", "num_only()")
    End Sub

    Protected Sub btnSearch_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnSearch.Click
        Try
            Me.binddata()
        Catch ex As Exception
            Response.Redirect("BooksNot_Found.aspx?Meassge=Data not found&p=advance")
        End Try
        ScriptManager.RegisterClientScriptBlock(Me.Page, Me.GetType, "Display", _
        "document.getElementById('div_adsWait').style.display = 'none';", True)
    End Sub

    Private Sub binddata()
        Dim client_nation As String = ""
        Dim equal_ As String = ""
        Dim like_ As String = ""
        Dim equal_2 As String = ""
        Dim like_2 As String = ""
        Dim territory As String = ""
        Dim search_by As String = ""
        Dim SqlStr As String = ""
        Dim keyword As String = ""
        Dim datatable As New DataTable
        Dim pcontrol As PageControl

        'If txtauthor.Text = "" And txtkeyword.Text = "" And txtpub.Text = "" And txttitle.Text = "" And txtIsbn.Text = "" Then
        '    uScript.Alert(Me.Page, Me.GetType, "Please key data")
        '    Exit Sub
        'End If

        If txtauthor.Text = "" And txtkeyword.Text = "" And txttitle.Text = "" And txtIsbn.Text = "" Then
            uScript.Alert(Me.Page, Me.GetType, "Please key data")
            Exit Sub
        End If

        '///// check length /////
        If txtIsbn.Text <> "" Then
            If txtIsbn.Text.Length < 13 Then
                ScriptManager.RegisterClientScriptBlock(Me.Page, Me.GetType, "Alert", _
                "alert('Please key ISBN 13 character'); window.open('Advanced_Search.aspx','_parent');", True)
                Exit Sub
            End If
        End If
        If txttitle.Text <> "" Then
            If txttitle.Text.Length < 5 Then
                ScriptManager.RegisterClientScriptBlock(Me.Page, Me.GetType, "Alert", _
                "alert('Please key Title at least 5 character'); window.open('Advanced_Search.aspx','_parent');", True)
                Exit Sub
            End If
        End If
        If txtauthor.Text <> "" Then
            If txtauthor.Text.Length < 5 Then
                ScriptManager.RegisterClientScriptBlock(Me.Page, Me.GetType, "Alert", _
                "alert('Please key Author at least 5 character'); window.open('Advanced_Search.aspx','_parent');", True)
                Exit Sub
            End If
        End If
        If txtkeyword.Text <> "" Then
            If txtkeyword.Text.Length < 5 Then
                ScriptManager.RegisterClientScriptBlock(Me.Page, Me.GetType, "Alert", _
                "alert('Please key Keyword at least 5 character'); window.open('Advanced_Search.aspx','_parent');", True)
                Exit Sub
            End If
        End If
        'If txtpub.Text <> "" Then
        '    If txtpub.Text.Length < 5 Then
        '        ScriptManager.RegisterClientScriptBlock(Me.Page, Me.GetType, "Alert", _
        '        "alert('Please key Publisher at least 5 character'); window.open('Advanced_Search.aspx','_parent');", True)
        '        Exit Sub
        '    End If
        'End If

        '//// ebook only ////
        If txttype.SelectedValue = "ebook" Then
            If txtIsbn.Text <> "" Then
                equal_ &= "and ebook.isbn_13 = " & Me.txtIsbn.Text.ToString.Trim.Replace("'", "'+Char(39)+'") & ""
                like_ &= "and ebook.isbn_13 = " & Me.txtIsbn.Text.ToString.Trim.Replace("'", "'+Char(39)+'") & ""
            End If
            If txttitle.Text <> "" Then
                equal_ &= "and ebook.book_title = '" & Me.txttitle.Text.ToString.Trim.Replace("'", "'+Char(39)+'") & "'"
                like_ &= "and ebook.book_title like '%" & Me.txttitle.Text.ToString.Trim.Replace("'", "'+Char(39)+'") & "%'"
            End If
            If txtauthor.Text <> "" Then
                equal_ &= "and ebook.author = '" & Me.txtauthor.Text.ToString.Trim.Replace("'", "'+Char(39)+'") & "'"
                like_ &= "and ebook.author like '%" & Me.txtauthor.Text.ToString.Trim.Replace("'", "'+Char(39)+'") & "%'"
            End If
            If txtkeyword.Text <> "" Then
                equal_ &= "and ebook.keyword = '" & Me.txtkeyword.Text.ToString.Trim.Replace("'", "'+Char(39)+'") & "'"
                like_ &= "and contains(ebook.keyword,'" & """" & Me.txtkeyword.Text.ToString.ToUpper.Trim.Replace("'S", "").Replace("'", "") & """" & "') "
            End If
            'If txtpub.Text <> "" Then
            '    equal_ &= "and ebook.publisher_name = '" & Me.txtpub.Text.ToString.Trim.Replace("'", "'+Char(39)+'") & "'"
            '    like_ &= "and ebook.publisher_name like '%" & Me.txtpub.Text.ToString.Trim.Replace("'", "'+Char(39)+'") & "%'"
            'End If
            search_by = "ebook"
        End If
        '//// book only ////
        If txttype.SelectedValue = "book" Then
            If txtIsbn.Text <> "" Then
                equal_ &= "and book.isbn_13 = '" & Me.txtIsbn.Text.ToString.Trim.Replace("'", "'+Char(39)+'") & "'"
                like_ &= "and book.isbn_13 = '" & Me.txtIsbn.Text.ToString.Trim.Replace("'", "'+Char(39)+'") & "'"
            End If
            If txttitle.Text <> "" Then
                equal_ &= "and book.book_title = '" & Me.txttitle.Text.ToString.Trim.Replace("'", "'+Char(39)+'") & "'"
                like_ &= "and book.book_title like '%" & Me.txttitle.Text.ToString.Trim.Replace("'", "'+Char(39)+'") & "%'"
            End If
            If txtauthor.Text <> "" Then
                equal_ &= "and book.author = '" & Me.txtauthor.Text.ToString.Trim.Replace("'", "'+Char(39)+'") & "'"
                like_ &= "and book.author like '%" & Me.txtauthor.Text.ToString.Trim.Replace("'", "'+Char(39)+'") & "%'"
            End If
            If txtkeyword.Text <> "" Then
                equal_ &= "and book.keyword = '" & Me.txtkeyword.Text.ToString.Trim.Replace("'", "'+Char(39)+'") & "'"
                like_ &= "and contains(book.keyword,'" & """" & Me.txtkeyword.Text.ToString.ToUpper.Trim.Replace("'S", "").Replace("'", "") & """" & "') "
            End If
            'If txtpub.Text <> "" Then
            '    equal_ &= "and book.publisher_name = '" & Me.txtpub.Text.ToString.Trim.Replace("'", "'+Char(39)+'") & "'"
            '    like_ &= "and book.publisher_name like '%" & Me.txtpub.Text.ToString.Trim.Replace("'", "'+Char(39)+'") & "%'"
            'End If
            search_by = "book"
        End If
        '//// book&ebook ////
        If txttype.SelectedValue = "all" Then
            If txtIsbn.Text <> "" Then
                equal_ &= "and ebook.isbn_13 = " & Me.txtIsbn.Text.ToString.Trim.Replace("'", "'+Char(39)+'") & ""
                like_ &= "and ebook.isbn_13 = " & Me.txtIsbn.Text.ToString.Trim.Replace("'", "'+Char(39)+'") & ""
                equal_2 &= "and book.isbn_13 = '" & Me.txtIsbn.Text.ToString.Trim.Replace("'", "'+Char(39)+'") & "'"
                like_2 &= "and book.isbn_13 = '" & Me.txtIsbn.Text.ToString.Trim.Replace("'", "'+Char(39)+'") & "'"
            End If
            If txttitle.Text <> "" Then
                equal_ &= "and ebook.book_title = '" & Me.txttitle.Text.ToString.Trim.Replace("'", "'+Char(39)+'") & "'"
                like_ &= "and ebook.book_title like '%" & Me.txttitle.Text.ToString.Trim.Replace("'", "'+Char(39)+'") & "%'"
                equal_2 &= "and book.book_title = '" & Me.txttitle.Text.ToString.Trim.Replace("'", "'+Char(39)+'") & "'"
                like_2 &= "and book.book_title like '%" & Me.txttitle.Text.ToString.Trim.Replace("'", "'+Char(39)+'") & "%'"
            End If
            If txtauthor.Text <> "" Then
                equal_ &= "and ebook.author = '" & Me.txtauthor.Text.ToString.Trim.Replace("'", "'+Char(39)+'") & "'"
                like_ &= "and ebook.author like '%" & Me.txtauthor.Text.ToString.Trim.Replace("'", "'+Char(39)+'") & "%'"
                equal_2 &= "and book.author = '" & Me.txtauthor.Text.ToString.Trim.Replace("'", "'+Char(39)+'") & "'"
                like_2 &= "and book.author like '%" & Me.txtauthor.Text.ToString.Trim.Replace("'", "'+Char(39)+'") & "%'"
            End If
            If txtkeyword.Text <> "" Then
                equal_ &= "and ebook.keyword = '" & Me.txtkeyword.Text.ToString.Trim.Replace("'", "'+Char(39)+'") & "'"
                like_ &= "and contains(ebook.keyword,'" & """" & Me.txtkeyword.Text.ToString.ToUpper.Trim.Replace("'S", "").Replace("'", "") & """" & "') "
                equal_2 &= "and book.keyword = '" & Me.txtkeyword.Text.ToString.Trim.Replace("'", "'+Char(39)+'") & "'"
                like_2 &= "and contains(book.keyword,'" & """" & Me.txtkeyword.Text.ToString.ToUpper.Trim.Replace("'S", "").Replace("'", "") & """" & "') "
            End If
            'If txtpub.Text <> "" Then
            '    equal_ &= "and ebook.publisher_name = '" & Me.txtpub.Text.ToString.Trim.Replace("'", "'+Char(39)+'") & "'"
            '    like_ &= "and ebook.publisher_name like '%" & Me.txtpub.Text.ToString.Trim.Replace("'", "'+Char(39)+'") & "%'"
            '    equal_2 &= "and book.publisher_name = '" & Me.txtpub.Text.ToString.Trim.Replace("'", "'+Char(39)+'") & "'"
            '    like_2 &= "and book.publisher_name like '%" & Me.txtpub.Text.ToString.Trim.Replace("'", "'+Char(39)+'") & "%'"
            'End If
            search_by = "all"
        End If

        If txtIsbn.Text <> "" Then
            keyword &= " ISBN = " + txtIsbn.Text.Trim
        End If
        If txttitle.Text <> "" Then
            keyword &= " Title = " + txttitle.Text.Trim
        End If
        If txtauthor.Text <> "" Then
            keyword &= " Author = " + txtauthor.Text.Trim
        End If
        If txtkeyword.Text <> "" Then
            keyword &= " Keyword = " + txtkeyword.Text.Trim
        End If
        'If txtpub.Text <> "" Then
        '    keyword &= " Publisher = " + txtpub.Text.Trim
        'End If
        Session("keyword") = keyword

        '///// check client nation /////
        If Session("client_nation") Is Nothing Then
            Dim gen As New gen_nation
            gen.ip = Request.UserHostAddress()
            client_nation = gen.gen_ip_code
        Else
            client_nation = Session("client_nation")
        End If

        '///// check flag for territory table /////
        Dim sp As String = client_nation.Trim.Substring(0, 1)
        territory = "ebook_territory_" + sp

        Try
            Dim class_book_search As New Class_book_search
            uCon = New uConnect
            datatable = New DataTable
            pcontrol = New PageControl

            class_book_search.equal_ = equal_
            class_book_search.like_ = like_
            If txttype.SelectedValue = "all" Then
                class_book_search.equal_2 = equal_2
                class_book_search.like_2 = like_2
            End If
            If txtkeyword.Text <> "" Then
                class_book_search.by = "keyword"
            End If
            class_book_search.territory = territory
            class_book_search.country = client_nation
            class_book_search.advance_search_forcus = search_by
            datatable = class_book_search.Advance_Search


            '/////////// use class book_search////////////
            '///////comment by prompt on 30/11/2010///////
            'dt = uFunction.getDataTable(uCon.conn, SqlStr)
            If datatable.Rows.Count > 0 Then
                Session("advancedatagrid") = datatable
                Me.Datagrid.CurrentPageIndex = 0
                Me.Datagrid.DataSource = datatable
                Me.Datagrid.DataBind()
                Me.Label_Result.Text = pcontrol.ShowingResultSet(Me.Datagrid.CurrentPageIndex, Me.Datagrid.PageSize, datatable.Rows.Count)
                lblWording.Visible = False
                Datagrid.PagerStyle.Visible = True
            Else
                'lblWording.Visible = True
                Response.Redirect("BooksNot_Found.aspx?Meassge=Data not found&p=advance")
            End If
        Catch ex As Exception
            Throw ex
        Finally
            uCon = Nothing
            datatable = Nothing
            pcontrol = Nothing
            SqlStr = Nothing
        End Try
    End Sub

    Protected Sub Datagrid_ItemDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.DataGridItemEventArgs) Handles Datagrid.ItemDataBound
        Dim price As Double = 0
        Dim price_usd As Double = 0
        Dim i As Integer

        Try
            If e.Item.ItemType = ListItemType.AlternatingItem Or e.Item.ItemType = ListItemType.Item Then
                Dim Book_Image As Image = e.Item.FindControl("Book_Image")
                Dim lblBook_Image As Label = e.Item.FindControl("lblBook_Image")
                Dim lblList_Price_D As Label = e.Item.FindControl("lblList_Price_D")
                Dim lblList_Price_H As Label = e.Item.FindControl("lblList_Price_H")
                Dim lblYour_Price_D As Label = e.Item.FindControl("lblYour_Price_D")
                Dim lblYour_Price_H As Label = e.Item.FindControl("lblYour_Price_H")
                Dim lblSave_Price_L As Label = e.Item.FindControl("lblSave_Price_L")
                Dim lblSave_Price_C As Label = e.Item.FindControl("lblSave_Price_C")
                Dim lblSave_Price_R As Label = e.Item.FindControl("lblSave_Price_R")
                Dim lbl_price_usd As Label = e.Item.FindControl("lbl_price_usd")
                Dim lblsource As Label = e.Item.FindControl("lblsource")

                '////////////promptnow////////////
                Dim lblBook_Title As Label = e.Item.FindControl("lblBook_Title")
                Dim lblisbn As Label = e.Item.FindControl("Label16")
                Dim lblsupplier As Label = e.Item.FindControl("Label19")
                Dim image_icon As Image = e.Item.FindControl("image_icon")
                Dim hdd_type As HiddenField = e.Item.FindControl("hdd_type")
                Dim hdd_other As HiddenField = e.Item.FindControl("hdd_other")
                Dim hdd_ebook_format As HiddenField = e.Item.FindControl("hdd_ebook_format")
                Dim lnkavailable As LinkButton = e.Item.FindControl("lnkavailable")
                Dim img_btn1 As ImageButton = e.Item.FindControl("btn1")
                Dim img_btn2 As ImageButton = e.Item.FindControl("btn2")
                Dim img_btn3 As ImageButton = e.Item.FindControl("btn3")
                Dim img_btn4 As ImageButton = e.Item.FindControl("btn4")
                Dim img_btn5 As ImageButton = e.Item.FindControl("btn5")
                Dim img_btn6 As ImageButton = e.Item.FindControl("btn6")
                Dim img_btn7 As ImageButton = e.Item.FindControl("btn7")
                Dim img_btn8 As ImageButton = e.Item.FindControl("btn8")
                Dim img_btn9 As ImageButton = e.Item.FindControl("btn9")
                Dim lbltxt_format As Label = e.Item.FindControl("lbltxt_format")
                Dim isbn As String = lblisbn.Text
                lnkavailable.Visible = False
                image_icon.Visible = False
                lbltxt_format.Visible = False

                '///// image /////
                If hdd_type.Value = "ebook" Then
                    _Utility = New clsUtility
                    Book_Image.ImageUrl = _Utility.GetImagePath_eBook(lblBook_Image.Text.Trim)
                Else
                    _Utility = New clsUtility
                    Book_Image.ImageUrl = _Utility.GetImagePath(lblBook_Image.Text.Trim)
                End If
                '///// show available /////
                If txttype.SelectedValue <> "all" Or txtIsbn.Text <> "" Then
                    If hdd_other.Value <> "none" Then
                        If hdd_type.Value = "ebook" Then
                            lnkavailable.Text = "Available On Book"
                            lnkavailable.PostBackUrl = "~/book_detail_internet.aspx?Title_1=" + hdd_other.Value + ""
                            lnkavailable.Visible = True
                            image_icon.Visible = True
                        Else
                            lnkavailable.Text = "Available On eBook"
                            lnkavailable.PostBackUrl = "~/ebook_detail.aspx?code=" + hdd_other.Value + ""
                            lnkavailable.Visible = True
                            image_icon.Visible = True
                        End If
                    End If
                End If
                
                '///// show format /////
                If hdd_type.Value = "ebook" Or hdd_type.Value = "1" Then
                    lbltxt_format.Visible = True

                    Dim format_name() As String = {"GUY", "DRM-PDF", "PDF", "DRM-EPUB", "EPUB", "LIT", "MP3", "PDB", "MOBI", "ASB"}
                    Dim url_image(10) As String
                    url_image(0) = "GUY"
                    url_image(1) = "~/images/ebook/epdf.gif"
                    url_image(2) = "~/images/ebook/pdf.gif"
                    url_image(3) = "~/images/ebook/eepub.gif"
                    url_image(4) = "~/images/ebook/epub.gif"
                    url_image(5) = "~/images/ebook/lit.gif"
                    url_image(6) = "~/images/ebook/mp3.gif"
                    url_image(7) = "~/images/ebook/pdb.gif"
                    url_image(8) = "~/images/ebook/pdb.gif"
                    url_image(9) = "~/images/ebook/asiabook.gif"
                    Dim array() As String = hdd_ebook_format.Value.Split(",")
                    For i = 0 To array.Length - 1
                        If array(i) <> "" Then
                            If i = 0 Then
                                img_btn1.Attributes.Add("alt", "CLICK HERE TO VIEW DETAIL OF " + format_name(CInt(array(i))))
                                img_btn1.Attributes.Add("title", "CLICK HERE TO VIEW DETAIL OF " + format_name(CInt(array(i))))
                                img_btn1.PostBackUrl = "~/ebook_detail.aspx?code=" + isbn + "&format=" + array(i) + ""
                                img_btn1.ImageUrl = url_image(CInt(array(i)))
                                img_btn1.Visible = True
                            End If
                            If i = 1 Then
                                img_btn2.Attributes.Add("alt", "CLICK HERE TO VIEW DETAIL OF " + format_name(CInt(array(i))))
                                img_btn2.Attributes.Add("title", "CLICK HERE TO VIEW DETAIL OF " + format_name(CInt(array(i))))
                                img_btn2.PostBackUrl = "~/ebook_detail.aspx?code=" + isbn + "&format=" + array(i) + ""
                                img_btn2.ImageUrl = url_image(CInt(array(i)))
                                img_btn2.Visible = True
                            End If
                            If i = 2 Then
                                img_btn3.Attributes.Add("alt", "CLICK HERE TO VIEW DETAIL OF " + format_name(CInt(array(i))))
                                img_btn3.Attributes.Add("title", "CLICK HERE TO VIEW DETAIL OF " + format_name(CInt(array(i))))
                                img_btn3.PostBackUrl = "~/ebook_detail.aspx?code=" + isbn + "&format=" + array(i) + ""
                                img_btn3.ImageUrl = url_image(CInt(array(i)))
                                img_btn3.Visible = True
                            End If
                            If i = 3 Then
                                img_btn4.Attributes.Add("alt", "CLICK HERE TO VIEW DETAIL OF " + format_name(CInt(array(i))))
                                img_btn4.Attributes.Add("title", "CLICK HERE TO VIEW DETAIL OF " + format_name(CInt(array(i))))
                                img_btn4.PostBackUrl = "~/ebook_detail.aspx?code=" + isbn + "&format=" + array(i) + ""
                                img_btn4.ImageUrl = url_image(CInt(array(i)))
                                img_btn4.Visible = True
                            End If
                            If i = 4 Then
                                img_btn5.Attributes.Add("alt", "CLICK HERE TO VIEW DETAIL OF " + format_name(CInt(array(i))))
                                img_btn5.Attributes.Add("title", "CLICK HERE TO VIEW DETAIL OF " + format_name(CInt(array(i))))
                                img_btn5.PostBackUrl = "~/ebook_detail.aspx?code=" + isbn + "&format=" + array(i) + ""
                                img_btn5.ImageUrl = url_image(CInt(array(i)))
                                img_btn5.Visible = True
                            End If
                            If i = 5 Then
                                img_btn6.Attributes.Add("alt", "CLICK HERE TO VIEW DETAIL OF " + format_name(CInt(array(i))))
                                img_btn6.Attributes.Add("title", "CLICK HERE TO VIEW DETAIL OF " + format_name(CInt(array(i))))
                                img_btn6.PostBackUrl = "~/ebook_detail.aspx?code=" + isbn + "&format=" + array(i) + ""
                                img_btn6.ImageUrl = url_image(CInt(array(i)))
                                img_btn6.Visible = True
                            End If
                            If i = 6 Then
                                img_btn7.Attributes.Add("alt", "CLICK HERE TO VIEW DETAIL OF " + format_name(CInt(array(i))))
                                img_btn7.Attributes.Add("title", "CLICK HERE TO VIEW DETAIL OF " + format_name(CInt(array(i))))
                                img_btn7.PostBackUrl = "~/ebook_detail.aspx?code=" + isbn + "&format=" + array(i) + ""
                                img_btn7.ImageUrl = url_image(CInt(array(i)))
                                img_btn7.Visible = True
                            End If
                            If i = 7 Then
                                img_btn8.Attributes.Add("alt", "CLICK HERE TO VIEW DETAIL OF " + format_name(CInt(array(i))))
                                img_btn8.Attributes.Add("title", "CLICK HERE TO VIEW DETAIL OF " + format_name(CInt(array(i))))
                                img_btn8.PostBackUrl = "~/ebook_detail.aspx?code=" + isbn + "&format=" + array(i) + ""
                                img_btn8.ImageUrl = url_image(CInt(array(i)))
                                img_btn8.Visible = True
                            End If
                            If i = 8 Then
                                img_btn9.Attributes.Add("alt", "CLICK HERE TO VIEW DETAIL OF " + format_name(CInt(array(i))))
                                img_btn9.Attributes.Add("title", "CLICK HERE TO VIEW DETAIL OF " + format_name(CInt(array(i))))
                                img_btn9.PostBackUrl = "~/ebook_detail.aspx?code=" + isbn + "&format=" + array(i) + ""
                                img_btn9.ImageUrl = url_image(CInt(array(i)))
                                img_btn9.Visible = True
                            End If
                        End If
                    Next

                End If
                '///////////promptnow end////////////

                If lblsource.Text = "Asiabooks" Then
                    price = CDbl(lblYour_Price_D.Text)
                Else
                    price = CDbl(lblList_Price_D.Text)
                End If

                If lblList_Price_D.Text = lblYour_Price_D.Text Then
                    lblList_Price_D.Visible = False
                    lblList_Price_H.Visible = False
                    lblSave_Price_C.Visible = False
                    lblSave_Price_L.Visible = False
                    lblSave_Price_R.Visible = False
                Else
                    lblList_Price_D.Font.Strikeout = True
                End If

                price_usd = class_book_detail.callUsd(price)
                lbl_price_usd.Text = "US$ " + Convert.ToDouble(price_usd).ToString("#,##0.00")

            End If
        Catch ex As Exception
            Throw ex
        Finally
            price = Nothing
            price_usd = Nothing
        End Try
    End Sub

    Protected Sub Datagrid_PageIndexChanged(ByVal source As Object, ByVal e As System.Web.UI.WebControls.DataGridPageChangedEventArgs) Handles Datagrid.PageIndexChanged
        Dim pcontrol As New PageControl
        Dim dt As New DataTable

        Try
            If Session("advancedatagrid") Is Nothing Then
                Me.Datagrid.CurrentPageIndex = e.NewPageIndex
                Me.binddata()
            Else
                dt = Session("advancedatagrid")
                Me.Datagrid.DataSource = dt
                Me.Datagrid.CurrentPageIndex = e.NewPageIndex
                Me.Datagrid.DataBind()

                Me.Label_Result.Text = pcontrol.ShowingResultSet(Me.Datagrid.CurrentPageIndex, Me.Datagrid.PageSize, dt.Rows.Count)
            End If
        Catch ex As Exception
            uScript.Alert(Me.Page, Me.GetType, ex.Message.ToString)
        Finally
            pcontrol = Nothing
            dt = Nothing
        End Try
    End Sub

    Private Sub Book_WishList(ByVal isbn As String)
        Dim datatable As New DataTable
        class_book_detail.keyword_1 = isbn
        class_book_detail.sales_channel = "INTERNET"
        datatable = class_book_detail._dt_book_detail

        check_stock_book(datatable)
        add_book_to_wish(datatable)
    End Sub

    Private Sub check_stock_book(ByVal datatable As DataTable)
        class_book_detail = New Class_book_detail
        Dim isbn As String = datatable.Rows(0).Item("isbn_13").ToString
        Dim source As String = datatable.Rows(0).Item("source").ToString
        Dim weight As String = datatable.Rows(0).Item("weight").ToString

        If weight = "0" Then
            Response.Redirect("BooksNot_Found.aspx?Meassge=Data not weight")
        Else
            If source = "Asiabooks" Then
                class_book_detail.Status = "AB"
                Dim dt_xx As DataTable

                Dim sqlDB As SqlDb = New SqlDb
                Dim dt_stock As New DataTable
                Dim dt_stockJobber As New DataTable
                Dim SqlStr As String = ""

                SqlStr &= " select a.on_hand_qty ,a.on_order_qty from dbo.tbt_jobber_stockindent a,tbm_syst_company b "
                SqlStr &= " where a.isbn_13 = '" + isbn.Trim + "'"
                SqlStr &= " and a.on_hand_qty + a.on_order_qty >  b.Minimum_Stock_Jobber "
                dt_stockJobber.Clear()
                dt_stockJobber = sqlDB.GetDataTable(SqlStr)
                If dt_stockJobber.Rows.Count > 0 Then
                    class_book_detail.Jobber_Status = "INDENT"
                Else
                    class_book_detail.Jobber_Status = "AB"

                    If Session("In_Branch") Is Nothing Then
                        SqlStr = ""
                        SqlStr &= " select a.isbn_13,a.org_ab_code,a.qty,(a.qty-b.Minimum_Stock_Internet)- 1 as total_stock "
                        SqlStr &= "	from tbt_jobber_stockab a,dbo.tbm_syst_company b "
                        SqlStr &= "	where a.isbn_13 = '" + isbn.Trim + "' and org_ab_code = 'HO-Internet'  "
                        SqlStr &= "	and a.qty - 1 >=  b.Minimum_Stock_Internet "
                        dt_stock.Clear()
                        dt_stock = sqlDB.GetDataTable(SqlStr)
                        If dt_stock.Rows.Count > 0 Then
                        Else
                            Response.Redirect("BooksNot_Found.aspx?Meassge=Stock is not available")
                        End If
                    Else
                        Dim aa As String = ""
                        Dim yy As String = ""
                        Dim qty As String = ""
                        dt_xx = Session("In_Branch")
                        For ixx As Integer = 0 To dt_xx.Rows.Count - 1
                            If dt_xx.Rows(ixx).Item("isbn_13").ToString = isbn.Trim Then
                                aa = "1"
                                qty = dt_xx.Rows(ixx).Item("Quantity").ToString
                            End If
                        Next
                        If aa = "1" Then
                            SqlStr = ""
                            SqlStr &= " select a.isbn_13,a.org_ab_code,a.qty,(a.qty-b.Minimum_Stock_Internet)-" + qty + " as total_stock "
                            SqlStr &= "	from tbt_jobber_stockab a,dbo.tbm_syst_company b "
                            SqlStr &= "	where a.isbn_13 = '" + isbn.Trim + "' and org_ab_code = 'HO-Internet'  "
                            SqlStr &= "	and (a.qty-b.Minimum_Stock_Internet)-" + qty + " >=  b.Minimum_Stock_Internet "
                            dt_stock.Clear()
                            dt_stock = sqlDB.GetDataTable(SqlStr)
                            If dt_stock.Rows.Count > 0 Then
                            Else
                                Response.Redirect("BooksNot_Found.aspx?Meassge=Stock is not available")
                            End If
                        Else
                            SqlStr = ""
                            SqlStr &= " select a.isbn_13,a.org_ab_code,a.qty,(a.qty-b.Minimum_Stock_Internet)- 1 as total_stock "
                            SqlStr &= "	from tbt_jobber_stockab a,dbo.tbm_syst_company b "
                            SqlStr &= "	where a.isbn_13 = '" + isbn.Trim + "' and org_ab_code = 'HO-Internet'  "
                            SqlStr &= "	and a.qty - 1 >=  b.Minimum_Stock_Internet "
                            dt_stock.Clear()
                            dt_stock = sqlDB.GetDataTable(SqlStr)
                            If dt_stock.Rows.Count > 0 Then
                            Else
                                Response.Redirect("BooksNot_Found.aspx?Meassge=Stock is not available")
                            End If
                        End If
                    End If

                End If

                SqlStr = ""
                SqlStr &= " select a.isbn_13,a.org_ab_code,a.qty,(a.qty-b.Minimum_Stock_Internet)- 1 as total_stock "
                SqlStr &= "	from tbt_jobber_stockab a,dbo.tbm_syst_company b "
                SqlStr &= "	where a.isbn_13 = '" + isbn.Trim + "' and org_ab_code = 'HO-Internet'  "

                dt_stock.Clear()
                dt_stock = sqlDB.GetDataTable(SqlStr)
                If dt_stock.Rows.Count > 0 Then
                    If Session("In_Branch") Is Nothing Then
                        class_book_detail.Jobber_Status = "AB"
                        class_book_detail.Status = "AB"
                    Else
                        Dim aa As String = ""
                        Dim yy As String = ""
                        dt_xx = Session("In_Branch")
                        For ixx As Integer = 0 To dt_xx.Rows.Count - 1
                            If dt_xx.Rows(ixx).Item("isbn_13").ToString = isbn.Trim And dt_xx.Rows(ixx).Item("Quantity").ToString = dt_stock.Rows(0).Item("qty").ToString Then
                                aa = "1"
                            End If
                        Next
                        If aa = "1" Then
                            class_book_detail.Status = "SPECIAL"

                        Else
                            class_book_detail.Jobber_Status = "AB"
                            class_book_detail.Status = "AB"
                        End If
                    End If

                End If

            Else
                class_book_detail.Jobber_Status = "AB"
                class_book_detail.Status = "INDENT"
            End If


            If Session("sales_channel") Is Nothing Then
                class_book_detail.sales_channel = System.Configuration.ConfigurationManager.AppSettings("UserInternet")
            Else
                class_book_detail.sales_channel = Session("sales_channel").ToString
            End If

            class_book_detail.keyword_1 = isbn.Trim
            If Not (IsNumeric("1") And 1 > 0) Then
                ScriptManager.RegisterClientScriptBlock(Me.Page, Me.GetType, "Alert", "alert('Quantity is not Valid');", True)
                Exit Sub
            Else
                class_book_detail.keyword_Qty = CInt("1")
            End If
            class_book_detail.keyword_Branch = "HO-Internet"
            If Session("In_Branch") Is Nothing Then
                class_book_detail.dt_Old_book_In_Branch = New DataTable
            Else
                class_book_detail.dt_Old_book_In_Branch = Session("In_Branch")
            End If

            If Session("Other_Branch") Is Nothing Then
                class_book_detail.dt_Old_book_Other_Branch = New DataTable
            Else
                class_book_detail.dt_Old_book_Other_Branch = Session("Other_Branch")
            End If

            If Session("jobber") Is Nothing Then
                class_book_detail.dt_Old_book_jobber = New DataTable
            Else
                class_book_detail.dt_Old_book_jobber = Session("jobber")
            End If

            Dim i As Integer = 0

            Dim client_nation As String = ""
            Dim territory As String = ""
            If Session("client_nation") Is Nothing Then
                Dim gen As New gen_nation
                gen.ip = Request.UserHostAddress()
                client_nation = gen.gen_ip_code
            Else
                client_nation = Session("client_nation")
            End If
            '///// check flag for territory table /////
            Dim sp As String = client_nation.Trim.Substring(0, 1)
            territory = "ebook_territory_" + sp
            class_book_detail.country = client_nation
            class_book_detail.territory = territory
            class_book_detail.Recalcuate()

            Dim Flag1 As String = ""
            Dim Flag2 As String = ""
            Dim Flag3 As String = ""
            If Not class_book_detail.dt_book_In_Branch Is Nothing Then
                If class_book_detail.dt_book_In_Branch.Select("ISBN_13='" + class_book_detail.keyword_1.Trim + "'").Length = 0 Then
                    Flag1 = "0"
                Else
                    Flag1 = "1"
                End If
            Else
                Flag1 = "0"
            End If
            If Not class_book_detail.dt_book_Other_Branch Is Nothing Then
                If class_book_detail.dt_book_Other_Branch.Select("ISBN_13='" + class_book_detail.keyword_1.Trim + "'").Length = 0 Then
                    Flag2 = "0"
                Else
                    Flag2 = "1"
                End If
            Else
                Flag2 = "0"
            End If
            If Not class_book_detail.dt_book_jobber Is Nothing Then
                If class_book_detail.dt_book_jobber.Select("ISBN_13='" + class_book_detail.keyword_1.Trim + "'").Length = 0 Then
                    Flag3 = "0"
                Else
                    Flag3 = "1"
                End If
            Else
                Flag3 = "0"
            End If

            If Flag1 = "0" And Flag2 = "0" And Flag3 = "0" Then
                Response.Redirect("BooksNot_Found.aspx?Meassge=Stock is not available")
            Else

                Dim In_branch_qty As Integer = 0
                Dim Other_branch_qty As Integer = 0
                Dim Jobber_qty As Integer = 0
                Dim total_In_branch_qty As Integer = 0
                Dim total_Other_branch_qty As Integer = 0
                Dim total_Jobber_qty As Integer = 0

                If Not class_book_detail.dt_book_In_Branch Is Nothing Then
                    For ix As Integer = 0 To class_book_detail.dt_book_In_Branch.Rows.Count - 1
                        In_branch_qty = class_book_detail.dt_book_In_Branch.Rows(ix).Item("Quantity")
                        total_In_branch_qty = total_In_branch_qty + In_branch_qty
                    Next
                End If
                If Not class_book_detail.dt_book_Other_Branch Is Nothing Then
                    For ix As Integer = 0 To class_book_detail.dt_book_Other_Branch.Rows.Count - 1
                        In_branch_qty = class_book_detail.dt_book_Other_Branch.Rows(ix).Item("Quantity")
                        total_Other_branch_qty = total_Other_branch_qty + In_branch_qty
                    Next
                    'Other_branch_qty = class_book_detail.dt_book_Other_Branch.Rows(0).Item("Quantity")
                End If

                If Not class_book_detail.dt_book_jobber Is Nothing Then
                    For ix As Integer = 0 To class_book_detail.dt_book_jobber.Rows.Count - 1
                        Jobber_qty = class_book_detail.dt_book_jobber.Rows(ix).Item("Quantity")
                        total_Jobber_qty = total_Jobber_qty + Jobber_qty
                    Next
                End If

                If class_book_detail.input_Quantity > total_In_branch_qty + total_Other_branch_qty + total_Jobber_qty Then

                    If Not class_book_detail.dt_book_In_Branch Is Nothing Then
                        If class_book_detail.dt_book_In_Branch.Rows.Count <> 0 Then
                            For i = 0 To class_book_detail.dt_book_In_Branch.Rows.Count - 1
                                If class_book_detail.dt_book_In_Branch.Rows(i).Item("ISBN_13").ToString.Trim = class_book_detail.keyword_1.Trim Then
                                    class_book_detail.dt_book_In_Branch.Rows(i).Delete()
                                End If
                            Next
                        End If
                    End If
                    If Not class_book_detail.dt_book_Other_Branch Is Nothing Then
                        If class_book_detail.dt_book_Other_Branch.Rows.Count <> 0 Then
                            For i = 0 To class_book_detail.dt_book_Other_Branch.Rows.Count - 1
                                If class_book_detail.dt_book_Other_Branch.Rows(i).Item("ISBN_13").ToString.Trim = class_book_detail.keyword_1.Trim Then
                                    class_book_detail.dt_book_Other_Branch.Rows(i).Delete()
                                End If
                            Next
                        End If
                    End If
                    If Not class_book_detail.dt_book_jobber Is Nothing Then
                        If class_book_detail.dt_book_jobber.Rows.Count <> 0 Then
                            For i = 0 To class_book_detail.dt_book_jobber.Rows.Count - 1
                                If class_book_detail.dt_book_jobber.Rows(i).Item("ISBN_13").ToString.Trim = class_book_detail.keyword_1.Trim Then
                                    class_book_detail.dt_book_jobber.Rows(i).Delete()
                                End If
                            Next
                        End If
                    End If
                    ScriptManager.RegisterClientScriptBlock(Me.Page, Me.GetType, "Alert", "alert('Quantity of ISBN : " + class_book_detail.keyword_1 + " is not enough,Please contact staff');", True)
                    Exit Sub
                End If
            End If
        End If
    End Sub

    Private Sub add_book_to_wish(ByVal data As DataTable)
        System.Threading.Thread.Sleep(1000)
        Dim alert As String = ""
        Dim datatable As DataTable = New DataTable("datatable")
        Dim datacolumn As DataColumn
        Dim datarow As DataRow

        datacolumn = New DataColumn()
        datacolumn.DataType = System.Type.GetType("System.String")
        datacolumn.ColumnName = "ISBN_13"
        datacolumn.AutoIncrement = False
        datacolumn.Caption = "ISBN_13"
        datacolumn.ReadOnly = False
        datacolumn.Unique = False
        datatable.Columns.Add(datacolumn)

        datacolumn = New DataColumn()
        datacolumn.DataType = System.Type.GetType("System.String")
        datacolumn.ColumnName = "Book_Title"
        datacolumn.AutoIncrement = False
        datacolumn.Caption = "Book_Title"
        datacolumn.ReadOnly = False
        datacolumn.Unique = False
        datatable.Columns.Add(datacolumn)

        datacolumn = New DataColumn()
        datacolumn.DataType = System.Type.GetType("System.String")
        datacolumn.ColumnName = "Author"
        datacolumn.AutoIncrement = False
        datacolumn.Caption = "Author"
        datacolumn.ReadOnly = False
        datacolumn.Unique = False
        datatable.Columns.Add(datacolumn)

        datacolumn = New DataColumn()
        datacolumn.DataType = System.Type.GetType("System.String")
        datacolumn.ColumnName = "Source"
        datacolumn.AutoIncrement = False
        datacolumn.Caption = "Source"
        datacolumn.ReadOnly = False
        datacolumn.Unique = False
        datatable.Columns.Add(datacolumn)

        datacolumn = New DataColumn()
        datacolumn.DataType = System.Type.GetType("System.String")
        datacolumn.ColumnName = "Selling_Price"
        datacolumn.AutoIncrement = False
        datacolumn.Caption = "Selling_Price"
        datacolumn.ReadOnly = False
        datacolumn.Unique = False
        datatable.Columns.Add(datacolumn)

        datacolumn = New DataColumn()
        datacolumn.DataType = System.Type.GetType("System.String")
        datacolumn.ColumnName = "Image"
        datacolumn.AutoIncrement = False
        datacolumn.Caption = "Image"
        datacolumn.ReadOnly = False
        datacolumn.Unique = False
        datatable.Columns.Add(datacolumn)

        datacolumn = New DataColumn()
        datacolumn.DataType = System.Type.GetType("System.String")
        datacolumn.ColumnName = "Item_Dis_Group"
        datacolumn.AutoIncrement = False
        datacolumn.Caption = "Item_Dis_Group"
        datacolumn.ReadOnly = False
        datacolumn.Unique = False
        datatable.Columns.Add(datacolumn)

        datacolumn = New DataColumn()
        datacolumn.DataType = System.Type.GetType("System.String")
        datacolumn.ColumnName = "Status"
        datacolumn.AutoIncrement = False
        datacolumn.Caption = "Status"
        datacolumn.ReadOnly = False
        datacolumn.Unique = False
        datatable.Columns.Add(datacolumn)

        datacolumn = New DataColumn()
        datacolumn.DataType = System.Type.GetType("System.String")
        datacolumn.ColumnName = "Synopsis"
        datacolumn.AutoIncrement = False
        datacolumn.Caption = "Synopsis"
        datacolumn.ReadOnly = False
        datacolumn.Unique = False
        datatable.Columns.Add(datacolumn)

        If Session("book_wish_lish") Is Nothing Then
            datarow = datatable.NewRow
            datarow("Image") = data.Rows(0).Item("image").ToString.Trim
            datarow("ISBN_13") = data.Rows(0).Item("isbn_13").ToString.Trim
            datarow("Book_Title") = data.Rows(0).Item("book_title").ToString.Trim
            datarow("Author") = data.Rows(0).Item("author").ToString.Trim
            datarow("Source") = data.Rows(0).Item("source").ToString.Trim
            If datarow("Source").ToString = "Asiabooks" Then
                datarow("Selling_Price") = CInt(data.Rows(0).Item("selling_price_ecom")).ToString
            Else
                datarow("Selling_Price") = CInt(data.Rows(0).Item("selling_price")).ToString
            End If
            datarow("Status") = data.Rows(0).Item("stock_status").ToString.Trim
            datarow("Item_Dis_Group") = ""
            Dim synopsis As String = data.Rows(0).Item("synopsis").ToString.Trim
            If synopsis = "-" Then
                datarow("Synopsis") = ""
            Else
                datarow("Synopsis") = synopsis
            End If
            datatable.Rows.Add(datarow)
            Session("book_wish_lish") = datatable
        Else
            datatable = Session("book_wish_lish")
            Dim isbn As String = data.Rows(0).Item("ISBN_13").ToString.Trim
            For Each a As DataRow In datatable.Rows
                If a.Item("ISBN_13").ToString = isbn Then
                    alert = "alert"
                End If
            Next
            If alert = "" Then
                datarow = datatable.NewRow
                datarow("Image") = data.Rows(0).Item("image").ToString.Trim
                datarow("ISBN_13") = data.Rows(0).Item("isbn_13").ToString.Trim
                datarow("Book_Title") = data.Rows(0).Item("book_title").ToString.Trim
                datarow("Author") = data.Rows(0).Item("author").ToString.Trim
                datarow("Source") = data.Rows(0).Item("source").ToString.Trim
                If datarow("Source").ToString = "Asiabooks" Then
                    datarow("Selling_Price") = CInt(data.Rows(0).Item("selling_price_ecom")).ToString
                Else
                    datarow("Selling_Price") = CInt(data.Rows(0).Item("selling_price")).ToString
                End If
                datarow("Status") = data.Rows(0).Item("stock_status").ToString.Trim
                datarow("Item_Dis_Group") = ""
                Dim synopsis As String = data.Rows(0).Item("synopsis").ToString.Trim
                If synopsis = "-" Then
                    datarow("Synopsis") = ""
                Else
                    datarow("Synopsis") = synopsis
                End If
                datatable.Rows.Add(datarow)
                Session("book_wish_lish") = datatable
            End If
        End If

        If alert = "" Then
            Response.Redirect("Wishlist_internet.aspx")
        Else
            ModalPopupAlert.Show()
        End If
    End Sub

    Protected Sub btn_alertClose_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles btn_alertClose.Click
        Response.Redirect("Wishlist_internet.aspx")
    End Sub

    Protected Sub Datagrid_DeleteCommand(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.DataGridCommandEventArgs) Handles Datagrid.DeleteCommand
        Dim datatable As DataTable = Session("advancedatagrid")
        Dim isbn As String = e.CommandArgument
        Dim book_type As String = ""
        Me.Datagrid.EditItemIndex = -1

        For Each dd As DataRow In datatable.Select("isbn_13 = '" + isbn + "'")
            book_type = dd.Item("Book_Type").ToString
            Exit For
        Next

        If book_type = "ebook" Then
            Response.Redirect("~/ebook_detail.aspx?code=" + isbn.Trim + "")
        Else
            Book_WishList(isbn)
        End If
    End Sub
End Class
