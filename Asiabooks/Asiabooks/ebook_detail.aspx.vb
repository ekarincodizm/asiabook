Imports System
Imports System.Data
Imports Eordering.BusinessLogic
Imports Eordering.BusinessLogic.PageControl
Imports System.Math

Partial Class ebook_detail
    Inherits System.Web.UI.Page
    Private uCon As uConnect
    Dim class_book_detail As New Class_book_detail
    Private _Utility As clsUtility

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Me.Title = ConfigurationManager.AppSettings("SiteTitle").ToString & "eBook Detail ::"
        Dim strPaht_facebook As String = ""
        Dim strPaht_Twitter As String = ""
        class_client_nation()
        Try
            Session("CachePage") = Nothing
            If Not IsPostBack Then
                Session.Remove("format")
                If Me.Request.QueryString("code") Is Nothing Then
                    Me.Panel5.Visible = True
                Else
                    Session("keyword") = Me.Request.QueryString("code").ToString.Trim
                    Me.Panel5.Visible = False
                    If Not Me.Request.QueryString("format") Is Nothing Then
                        class_book_detail.ebook_format = Me.Request.QueryString("format").ToString.Trim
                    Else
                        class_book_detail.ebook_format = ""
                    End If
                    Me.txt_qty.Attributes.Add("Onkeypress", "num_only()")
                    Me.txt_qty.Attributes.Add("Onmousedown", "return noCopyMouse(event);")
                    Me.txt_qty.Attributes.Add("Onkeydown", "return noCopyKey(event);")
                    Me.txt_qty.Text = "1"
                    Me.binddata()

                    strPaht_facebook = "http://www.facebook.com/share.php?u=https://www.asiabooks.com/browse/BookInfo_New.asp?ProID=" & Me.Request.QueryString("code").ToString.Trim
                    strPaht_Twitter = "http://twitter.com/home?status=https://www.asiabooks.com/browse/BookInfo_New.asp?ProID=" & Me.Request.QueryString("code").ToString.Trim

                    img_facebook.Attributes.Add("OnClick", "window.open('" & strPaht_facebook & "','',''); return false;")
                    imgtweet.Attributes.Add("OnClick", "window.open('" & strPaht_Twitter & "','',''); return false;")
                End If
            End If

            Me.Title = ConfigurationManager.AppSettings("SiteTitle").ToString & "eBook datail ::" + lbltitle.Text + " " + lblisbn.Text + " " + lnkAuthor_Detail.Text + ""
        Catch ex As Exception
            uScript.Alert(Me.Page, Me.GetType, ex.Message.ToString)
        Finally
            strPaht_facebook = Nothing
            strPaht_Twitter = Nothing
        End Try
    End Sub

    Private Sub binddata()
        
        Dim datatable As DataTable = class_ebook_detail()
        If datatable.Rows.Count > 0 Then
            Panel5.Visible = False
            Panel4.Visible = True

            lnkAuthor_Head.Text = datatable.Rows(0).Item("Author").ToString
            lbltitle.Text = datatable.Rows(0).Item("Book_Title").ToString
            lblisbn.Text = datatable.Rows(0).Item("ISBN_13").ToString.Trim
            lnkAuthor_Detail.Text = datatable.Rows(0).Item("Author").ToString
            If lnkAuthor_Detail.Text = "" Or lnkAuthor_Detail.Text = "-" Or lnkAuthor_Detail.Text = "NONE" Then
                lnkAuthor_Detail.Enabled = False
            End If
            If lnkAuthor_Head.Text = "" Or lnkAuthor_Head.Text = "-" Or lnkAuthor_Head.Text = "NONE" Then
                lnkAuthor_Head.Enabled = False
            End If
            lblpublisher.Text = datatable.Rows(0).Item("publisher_Name").ToString
            lblcategory.Text = datatable.Rows(0).Item("Subject_Name").ToString
            lbllanguage.Text = datatable.Rows(0).Item("Language").ToString
            lblsize.Text = datatable.Rows(0).Item("Size").ToString
            If Not lblsize.Text = "-" Then
                lblsize.Text = CDbl(datatable.Rows(0).Item("Size")).ToString("#,###,###.00")
            End If
            lblformat.Text = datatable.Rows(0).Item("eBook_Format").ToString
            lblreader.Text = datatable.Rows(0).Item("reader").ToString
            lblreader_img.Text = datatable.Rows(0).Item("reader_img").ToString
            lblnumber_of_page.Text = datatable.Rows(0).Item("Page_qty").ToString
            If lblnumber_of_page.Text = "0" Or lblnumber_of_page.Text = "" Then
                lblnumber_of_page.Text = "-"
            End If
            lblpublication_date.Text = datatable.Rows(0).Item("Publication_Date").ToString
            lblcopright.Text = datatable.Rows(0).Item("Copy_Rigths").ToString
            lblsynopsis.Text = datatable.Rows(0).Item("Synopsis").ToString
            lblsource.Text = datatable.Rows(0).Item("Source").ToString
            lblBook_Image.Text = datatable.Rows(0).Item("Image").ToString
            hidden_ebook_image.Value = datatable.Rows(0).Item("Image").ToString
            If datatable.Rows(0).Item("other_format").ToString <> "none" Then
                btn_book.PostBackUrl = "~/book_detail_internet.aspx?Title_1=" + datatable.Rows(0).Item("other_format").ToString.Trim
                pan_linkBook.Visible = True
            End If
            Session("format") = datatable.Rows(0).Item("format_num").ToString
            Dim url_image As String = lblBook_Image.Text
            Dim part1 As String = url_image.Substring(0, 3)
            Dim part2 As String = url_image.Substring(3, 3)
            Dim part3 As String = url_image.Substring(6, 3)
            lblBook_Image.Text = (part1 + "/" + part2 + "/" + part3 + "/" + url_image + ".jpg").Trim
            _Utility = New clsUtility
            Imag_Book.ImageUrl = _Utility.GetImagePath_eBook(lblBook_Image.Text.Trim)

            Panel3.Visible = False
            country_not_seal()
            If Not IsPostBack Then
                button_ebook_format()
            End If
            binddata_Relate_Author()
            binddata_Relate_Cat()
            Insert_CustomerView()
            Customer_Reviews()
            Customer_ReviewsDiscussion()
            CheckMember()
        Else
            Panel4.Visible = False
            Panel5.Visible = True
            Response.Redirect("BooksNot_Found.aspx?Meassge=Data not found")
        End If
    End Sub

    Private Sub binddata_Relate_Author()
        Dim datatable As New DataTable
        Dim strsql As String = ""
        Dim country As String = Session("client_nation")
        Dim sp As String = country.Trim.Substring(0, 1)
        Dim territory As String = "ebook_territory_" + sp

        'strsql &= " SELECT top(3) "
		strsql &= " SELECT "
        strsql &= " case search.source when 'Asiabooks' then ROUND(convert(numeric(13,2),search.selling),0) "
        strsql &= " else ROUND(convert(numeric(18,0),(search.selling * isnull(search.exchange_rate,0))),0) "
        strsql &= " end as selling_price "

        strsql &= " , case search.source when 'Asiabooks' then ROUND(convert(numeric(13,2),search.selling),0) "
        strsql &= " else ROUND(convert(numeric(18,0),(search.selling * isnull(search.exchange_rate,0))),0) "
        strsql &= " end as selling_price_ecomn "

        strsql &= " , case when search.other_format is null "
        strsql &= " then 'none' else search.other_format end as other_format "
        strsql &= " , case when len(search.book_title) >= 30 then left(isnull(search.book_title,''), 30) + '...' "
        strsql &= " else isnull(search.book_title,'') end as book_title "
        strsql &= " , case when len(search.author) >= 20 then left(isnull(search.author,''), 20) + '...' "
        strsql &= " else isnull(search.author,'') end as author "

        strsql &= " , search.isbn_13 , search.book_title as book_title_full , search.author as author_full , search.publisher_name , search.image "
        strsql &= " , search.source , search.discount as ecom_discount , search.format_type as ebook_format "

        strsql &= " , isnull(search.synopsis,'') as synopsis "

        strsql &= " FROM "
		'strsql &= " (select distinct ebook.bookid as ebook_id , ebook.isbn_13 , ebook.book_title "
        strsql &= " (select distinct top(3) ebook.bookid as ebook_id , ebook.isbn_13 , ebook.book_title "
        strsql &= " , case ebook.author when '' then '-' else ebook.author end as author "
        strsql &= " , case ebook.publisher_name when '' then '-' else ebook.publisher_name end as publisher_name "
        strsql &= " , convert(numeric(13,2) , ebook.price_org) as selling , ebook.isbn_10 as image  "
        strsql &= " , ebook.supplier_code as source , cast(ebook.on_book as varchar) as other_format "
        strsql &= " , ebook.discount , currency.exchange_rate , ebook.format_type , ebook.synopsis "

        strsql &= " from ebook_store ebook with (nolock) "
        strsql &= " , tbm_syst_organizeindent organize with (nolock) "
        strsql &= " , tbm_syst_currency currency with (nolock) "

        strsql &= " where (ebook.status = 'active' or ebook.status is null) "
        strsql &= " and ebook.supplier_code = organize.org_indent_code and organize.currency_code = currency.currency_code "
        strsql &= " and (convert(numeric(18,2),isnull(ebook.price_org,0)) * convert(numeric(18,2),isnull(ebook.moneytype,0))) > 50 "
        strsql &= " and ebook.author = '" + lnkAuthor_Detail.Text.Trim.Replace("'", "'+char(39)+'") + "' "
        If country = "TH" Then
            strsql &= " and ebook.th <> 0 ) as search "
        Else
            strsql &= " ) as search "
            strsql &= " left join (select distinct bookid as ebook_id , country_code "
            strsql &= " from " + territory + " where country_code = '" + country + "') as territory "
            strsql &= " on search.ebook_id = territory.ebook_id "

            strsql &= " WHERE territory.country_code is null "
        End If
        'strsql &= " ORDER BY NEWID() "
        uCon = New uConnect
        datatable = uFunction.getDataTable(uCon.conn, strsql)

        If datatable.Rows.Count > 0 Then
            
            Me.Panel2.Visible = True
            Me.lvBooks_Author.DataSource = datatable
            Me.lvBooks_Author.DataBind()
        Else
            Me.Panel2.Visible = False
        End If
    End Sub

    Protected Sub lvBooks_Author_ItemDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.ListViewItemEventArgs) Handles lvBooks_Author.ItemDataBound
        If e.Item.ItemType = ListViewItemType.DataItem Then

            Dim imgCustomer_Average As Image = e.Item.FindControl("imgCustomer_Average_Author")
            Dim lblCustomerView As Label = e.Item.FindControl("lblCustomerView_Author")
            Dim lblisbn As Label = e.Item.FindControl("lblisbn_author")
            Dim lblList_Price_H As Label = e.Item.FindControl("lblList_Price_H")
            Dim lblList_Price_D As Label = e.Item.FindControl("lblList_Price_D")
            Dim lblsave_price_L As Label = e.Item.FindControl("lblsave_price_L")
            Dim lblsave_price_C As Label = e.Item.FindControl("lblsave_price_C")
            Dim lblsave_price_R As Label = e.Item.FindControl("lblsave_price_R")
            Dim lblYour_Price As Label = e.Item.FindControl("lblYour_Price")
            Dim lblimage_book As Label = e.Item.FindControl("lblimage_book")
            Dim lblprice_us As Label = e.Item.FindControl("lblprice_us")
            Dim imag_book_cat As Image = e.Item.FindControl("imag_book_cat")

            '/////////promptnow/////////
            Dim url_image As String = lblimage_book.Text.Trim
            Dim part1 As String = url_image.Substring(0, 3)
            Dim part2 As String = url_image.Substring(3, 3)
            Dim part3 As String = url_image.Substring(6, 3)
            lblBook_Image.Text = (part1 + "/" + part2 + "/" + part3 + "/" + url_image + ".jpg").Trim
            _Utility = New clsUtility
            imag_book_cat.ImageUrl = _Utility.GetImagePath_eBook(lblBook_Image.Text.Trim)

            Dim lnkavailable As LinkButton = e.Item.FindControl("lnkavailable")
            Dim images As Image = e.Item.FindControl("images")
            Dim isbn As HiddenField = e.Item.FindControl("hddisbn")
            Dim panel_ebook As Panel = e.Item.FindControl("panel_ebook")
            Dim price As Double

            price = CDbl(lblYour_Price.Text)
            lblprice_us.Text = convert_to_us(price).ToString

            panel_ebook.Visible = False

            If isbn.Value <> "none" Then
                lnkavailable.PostBackUrl = "~/book_detail_internet.aspx?Title_1=" + isbn.Value
                lnkavailable.Visible = True
                images.Visible = True
                panel_ebook.Visible = True
            Else
                panel_ebook.Visible = False
            End If
            '///////promptnow end///////

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
            strsql &= " from tbm_AB_CustomerReview"
            strsql &= " where isbn_13 = '" + lblisbn.Text.Trim + "'"

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
            Else
                dt_view.Clear()
                strsql = ""
                strsql &= " select (CASE WHEN right(isbn_13,2)='00' "
                strsql &= " THEN 99*3/99 "
                strsql &= " ELSE right(isbn_13,2)*3/right(isbn_13,2) END) AS total,"
                strsql &= " (CASE WHEN right(isbn_13,2)='00' "
                strsql &= " THEN '99' "
                strsql &= " ELSE right(isbn_13,2) END) AS No_CustomerView"
                strsql &= " from ebook_store"
                strsql &= " where isbn_13 = '" + lblisbn.Text.Trim + "'"
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
                Else
                    lblCustomerView.Text = "0"
                    imgCustomer_Average.ImageUrl = "~/images/Template/stars0.gif"
                End If
            End If
        End If
    End Sub

    Private Sub binddata_Relate_Cat()
        Dim datatable As New DataTable
        Dim strsql As String = ""
        Dim country As String = Session("client_nation")
        Dim sp As String = country.Trim.Substring(0, 1)
        Dim territory As String = "ebook_territory_" + sp

        strsql = ""
        'strsql &= " SELECT top(3) "
		strsql &= " SELECT "
        strsql &= " case search.source when 'Asiabooks' then ROUND(convert(numeric(13,2),search.selling),0) "
        strsql &= " else ROUND(convert(numeric(18,0),(search.selling * isnull(search.exchange_rate,0))),0) "
        strsql &= " end as selling_price "

        strsql &= " , case search.source when 'Asiabooks' then ROUND(convert(numeric(13,2),search.selling),0) "
        strsql &= " else ROUND(convert(numeric(18,0),(search.selling * isnull(search.exchange_rate,0))),0) "
        strsql &= " end as selling_price_ecomn "

        strsql &= " , case when search.other_format is null "
        strsql &= " then 'none' else search.other_format end as other_format "
        strsql &= " , case when len(search.book_title) >= 30 then left(isnull(search.book_title,''), 30) + '...' "
        strsql &= " else isnull(search.book_title,'') end as book_title "
        strsql &= " , case when len(search.author) >= 20 then left(isnull(search.author,''), 20) + '...' "
        strsql &= " else isnull(search.author,'') end as author "

        strsql &= " , search.isbn_13 , search.book_title as book_title_full , search.author as author_full , search.publisher_name , search.image "
        strsql &= " , search.source , search.discount as ecom_discount , search.format_type as ebook_format "
        strsql &= " , case when cat.description is null then '-' else cat.description end as subject_name " '//// รอข้อมูล category

        strsql &= " FROM "
        'strsql &= " (select distinct ebook.bookid as ebook_id , ebook.isbn_13 , ebook.book_title "
		strsql &= " (select distinct top(3) ebook.bookid as ebook_id , ebook.isbn_13 , ebook.book_title "
        strsql &= " , case ebook.author when '' then '-' else ebook.author end as author "
        strsql &= " , case ebook.publisher_name when '' then '-' else ebook.publisher_name end as publisher_name "
        strsql &= " , convert(numeric(13,2) , ebook.price_org) as selling , ebook.isbn_10 as image  "
        strsql &= " , ebook.supplier_code as source , cast(ebook.on_book as varchar) as other_format "
        strsql &= " , ebook.discount , currency.exchange_rate , ebook.format_type "
        strsql &= " , ebook.catcode as subject_name"

        strsql &= " from ebook_store ebook with (nolock) "
        strsql &= " , tbm_syst_organizeindent organize with (nolock) "
        strsql &= " , tbm_syst_currency currency with (nolock) "

        strsql &= " where (ebook.status = 'active' or ebook.status is null) "
        strsql &= " and ebook.supplier_code = organize.org_indent_code and organize.currency_code = currency.currency_code "
        strsql &= " and (convert(numeric(18,2),isnull(ebook.price_org,0)) * convert(numeric(18,2),isnull(ebook.moneytype,0))) > 0 "
        If country = "TH" Then
            strsql &= " and ebook.th <> 0 ) as search "

            strsql &= " left join (select code , description from ebook_supplier_category where active = 'Y') cat "
            strsql &= " on search.subject_name = cat.code "
        Else
            strsql &= " ) as search "
            strsql &= " left join (select distinct bookid as ebook_id , country_code "
            strsql &= " from " + territory + " where country_code = '" + country + "') as territory "
            strsql &= " on search.ebook_id = territory.ebook_id "

            strsql &= " left join (select code , description from ebook_supplier_category where active = 'Y') cat "
            strsql &= " on search.subject_name = cat.code "

            strsql &= " WHERE territory.country_code is null"
            strsql &= " and cat.description = '" + lblcategory.Text.Trim.Replace("'", "'+char(39)+'") + "' "
        End If
        strsql &= " ORDER BY NEWID() "

        uCon = New uConnect
        datatable = uFunction.getDataTable(uCon.conn, strsql)

        If datatable.Rows.Count > 0 Then
            Panel3.Visible = True
            lvBooks_Cat.DataSource = datatable
            lvBooks_Cat.DataBind()
        Else
            Panel3.Visible = False
        End If
    End Sub

    Protected Sub lvBooks_Cat_ItemDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.ListViewItemEventArgs) Handles lvBooks_Cat.ItemDataBound
        If e.Item.ItemType = ListViewItemType.DataItem Then
            Dim imgCustomer_Average As Image = e.Item.FindControl("imgCustomer_Average_Cat")
            Dim lblCustomerView As Label = e.Item.FindControl("lblCustomerView_Cat")
            Dim lblisbn As Label = e.Item.FindControl("lblisbn_cat")
            Dim lblList_Price_H As Label = e.Item.FindControl("lblList_Price_H")
            Dim lblList_Price_D As Label = e.Item.FindControl("lblList_Price_D")
            Dim lblsave_price_L As Label = e.Item.FindControl("lblsave_price_L")
            Dim lblsave_price_C As Label = e.Item.FindControl("lblsave_price_C")
            Dim lblsave_price_R As Label = e.Item.FindControl("lblsave_price_R")
            Dim lblYour_Price As Label = e.Item.FindControl("lblYour_Price")
            Dim lblimage_book As Label = e.Item.FindControl("lblimage_book")
            Dim lblprice_us As Label = e.Item.FindControl("lblprice_us")
            Dim imag_book_cat As Image = e.Item.FindControl("imag_book_cat")

            '/////////promptnow/////////
            Dim url_image As String = lblimage_book.Text.Trim
            Dim part1 As String = url_image.Substring(0, 3)
            Dim part2 As String = url_image.Substring(3, 3)
            Dim part3 As String = url_image.Substring(6, 3)
            lblBook_Image.Text = (part1 + "/" + part2 + "/" + part3 + "/" + url_image + ".jpg").Trim
            _Utility = New clsUtility
            imag_book_cat.ImageUrl = _Utility.GetImagePath_eBook(lblBook_Image.Text.Trim)

            Dim lnkavailable As LinkButton = e.Item.FindControl("lnkavailable")
            Dim images As Image = e.Item.FindControl("images")
            Dim isbn As HiddenField = e.Item.FindControl("hddisbn")
            Dim panel_ebook As Panel = e.Item.FindControl("panel_ebook")
            Dim price As Double

            price = CDbl(lblYour_Price.Text)
            lblprice_us.Text = convert_to_us(price).ToString

            panel_ebook.Visible = False

            If isbn.Value <> "none" Then
                lnkavailable.PostBackUrl = "~/book_detail_internet.aspx?Title_1=" + isbn.Value
                lnkavailable.Visible = True
                images.Visible = True
                panel_ebook.Visible = True
            Else
                panel_ebook.Visible = False
            End If
            '///////promptnow end///////

            If lblList_Price_D.Text = lblYour_Price.Text Then
                lblList_Price_H.Visible = False
                lblList_Price_D.Visible = False
                lblsave_price_L.Visible = False
                lblsave_price_C.Visible = False
                lblsave_price_R.Visible = False
            Else
                lblList_Price_D.Font.Strikeout = True
            End If
            'Dim urlBook As String = ""
            '_Utility = New clsUtility
            'urlBook = _Utility.GetImagePath(lblimage_book.Text)
            'imag_book_cat.ImageUrl = urlBook

            uCon = New uConnect
            Dim strImageUrl As String = ""
            Dim dt_view As New DataTable
            Dim strsql As String = ""

            strsql = ""
            strsql &= " select case No_CustomerDiscussion when '0' then '0' else ((No_CusReview1*1)+(No_CusReview2*2)+(No_CusReview3*3)+"
            strsql &= " (No_CusReview4*4)+(No_CusReview5*5))/No_CustomerDiscussion end as total,*"
            strsql &= " from dbo.tbm_AB_CustomerReview"
            strsql &= " where isbn_13 = '" + lblisbn.Text.Trim + "'"

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
                    strsql &= " from ebook_store"
                    strsql &= " where isbn_13 = '" + lblisbn.Text.Trim + "'"
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
                strsql &= " from ebook_store"
                strsql &= " where isbn_13 = '" + lblisbn.Text.Trim + "'"
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
                Else
                    lblCustomerView.Text = "0"
                    imgCustomer_Average.ImageUrl = "~/images/Template/stars0.gif"
                End If
            End If
        End If
    End Sub

    Private Sub CheckMember()
        If Not IsNothing(Request.Cookies("myCookie_user")) Then
            Panel_Discussion.Visible = True
            btnAdd_Review.Visible = False
        Else
            Panel_Discussion.Visible = False
            btnAdd_Review.Visible = True
        End If
    End Sub

    Private Sub Customer_ReviewsDiscussion()
        Dim dt_review As New DataTable
        Dim strsql As String = ""

        Try
            uCon = New uConnect
            strsql = " select CusDiscussion,CreateBy,convert(varchar,Created,106) as Created,ReView_Rate "
            strsql &= " from tbm_AB_CustomerReview_Discussion where isbn_13 = '" + lblisbn.Text.Trim + "' and Is_Active = 'Y'"
            dt_review = uFunction.getDataTable(uCon.conn, strsql)
            If dt_review.Rows.Count > 0 Then
                gvCustomer_Reviews.DataSource = dt_review
                gvCustomer_Reviews.DataBind()
            End If
        Catch ex As Exception
            Throw ex
        Finally
            uCon = Nothing
            strsql = Nothing
            dt_review = Nothing
        End Try
    End Sub

    Private Sub Customer_Reviews()
        Try
            uCon = New uConnect

            Dim dt_view As New DataTable
            Dim strsql As String = ""

            strsql = ""
            strsql &= " select case No_CustomerDiscussion when '0' then '0' else ((No_CusReview1*1)+(No_CusReview2*2)+(No_CusReview3*3)+"
            strsql &= " (No_CusReview4*4)+(No_CusReview5*5))/No_CustomerDiscussion end as total,*"
            strsql &= " from tbm_AB_CustomerReview"
            strsql &= " where isbn_13 = '" + lblisbn.Text.Trim + "'"

            dt_view = uFunction.getDataTable(uCon.conn, strsql)
            If dt_view.Rows.Count > 0 Then
                Dim strCustomer_Average As String = ""
                strCustomer_Average = dt_view.Rows(0).Item("total").ToString
                lblview.Text = dt_view.Rows(0).Item("No_CustomerView").ToString

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
            Else
                dt_view.Clear()
                strsql = ""
                strsql &= " select (CASE WHEN right(isbn_13,2)='00' "
                strsql &= " THEN 99*3/99 "
                strsql &= " ELSE right(isbn_13,2)*3/right(isbn_13,2) END) AS total,"
                strsql &= " (CASE WHEN right(isbn_13,2)='00' "
                strsql &= " THEN '99' "
                strsql &= " ELSE right(isbn_13,2) END) AS No_CustomerView"
                strsql &= " from ebook_store"
                strsql &= " where isbn_13 = '" + lblisbn.Text.Trim + "'"
                dt_view = uFunction.getDataTable(uCon.conn, strsql)
                If dt_view.Rows.Count > 0 Then
                    Dim strCustomer_Average As String = ""
                    strCustomer_Average = dt_view.Rows(0).Item("total").ToString
                    lblview.Text = dt_view.Rows(0).Item("No_CustomerView").ToString

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


        Catch ex As Exception
            Throw ex
        Finally
            uCon = Nothing
        End Try
    End Sub

    Private Sub Insert_CustomerView()
        Try
            uCon = New uConnect
            Dim Customer_View As Integer = 0
            Dim strsql As String = ""
            Dim dt_view As New DataTable

            dt_view = uFunction.getDataTable(uCon.conn, "select * from tbm_AB_CustomerReview where isbn_13 = '" + lblisbn.Text + "'")

            If dt_view.Rows.Count > 0 Then
                Customer_View = Val(dt_view.Rows(0).Item("No_CustomerView").ToString) + 1
                strsql = ""
                strsql &= " update tbm_AB_CustomerReview set "
                strsql &= " No_CustomerView = '" + Customer_View.ToString + "'"
                strsql &= " ,Is_Active = 'Y'"
                strsql &= " ,Updated = getdate()"
                strsql &= " ,UpdateBy = '" + Request.ServerVariables("REMOTE_ADDR") + "'"
                strsql &= " where isbn_13 = '" + lblisbn.Text.Trim + "'"
                uFunction.ExecuteDataStringNonTran(uCon.conn, strsql)
            Else
                strsql = ""
                strsql &= " insert tbm_AB_CustomerReview (Isbn_13,No_CustomerView,No_CustomerDiscussion,No_CusReview1,"
                strsql &= " No_CusReview2,No_CusReview3,No_CusReview4,No_CusReview5,Is_Active,Created,CreatedBy) values ("
                strsql &= " '" + lblisbn.Text.Trim + "'"
                strsql &= " ,'1','0','0','0','0','0','0','Y',getdate(),"
                strsql &= " '" + Request.ServerVariables("REMOTE_ADDR") + "')"
                uFunction.ExecuteDataStringNonTran(uCon.conn, strsql)
            End If

        Catch ex As Exception
            Throw ex
        Finally
            uCon = Nothing
        End Try
    End Sub

    Protected Sub btnAdd_Review_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnAdd_Review.Click
        Session("CachePage") = Request.Url.AbsoluteUri

        If Not IsNothing(Request.Cookies("myCookie_user")) Then
            Panel_Discussion.Visible = True
        Else
            Response.Redirect("My_Account.aspx")
        End If
    End Sub

    Protected Sub btnNew_Dis_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnNew_Dis.Click
        Dim strCustomer_Name As String = ""
        Dim strCustomer_Code As String = ""
        Dim strReView_Rate As String = ""
        Dim strsql As String = ""
        Dim strsql_update As String = ""
        Dim strRate_fieldSql As String = ""

        strCustomer_Code = Request.Cookies("myCookie_user")("MemberCode")
        strCustomer_Name = Request.Cookies("myCookie_user")("UserName")
        If txtDetail.Text = "" Then
            uScript.Alert(Me.Page, Me.GetType, "กรุณากรอกข้อมูลด้วยค่ะ")
            Exit Sub
        End If
        If radio1.Checked = False And radio2.Checked = False And radio3.Checked = False And radio4.Checked = False And radio5.Checked = False Then
            uScript.Alert(Me.Page, Me.GetType, "กรุณาเลือก Review Rate ด้วยค่ะ")
            Exit Sub
        End If

        If radio1.Checked = True Then
            strReView_Rate = "1"
            strRate_fieldSql = "No_CusReview1"
        End If
        If radio2.Checked = True Then
            strReView_Rate = "2"
            strRate_fieldSql = "No_CusReview2"
        End If
        If radio3.Checked = True Then
            strReView_Rate = "3"
            strRate_fieldSql = "No_CusReview3"
        End If
        If radio4.Checked = True Then
            strReView_Rate = "4"
            strRate_fieldSql = "No_CusReview4"
        End If
        If radio5.Checked = True Then
            strReView_Rate = "5"
            strRate_fieldSql = "No_CusReview5"
        End If

        Dim dt_view As New DataTable

        Try
            strsql = " insert into tbm_AB_CustomerReview_Discussion (Isbn_13,CusDiscussion,ReView_Rate,Is_Active,Updated,"
            strsql &= " UpdateBy,UpdateByIP,Created,CreateBy,CreateByIP) values ("
            strsql &= " '" + lblisbn.Text.Trim + "',"
            strsql &= " '" + txtDetail.Text.Trim.ToString.Replace("'", "'+Char(39)+'") + "',"
            strsql &= " '" + strReView_Rate + "','Y',getdate(),"
            strsql &= " '" + strCustomer_Name + "',"
            strsql &= " '" + Request.ServerVariables("REMOTE_ADDR") + "',"
            strsql &= " getdate(),"
            strsql &= " '" + strCustomer_Name + "',"
            strsql &= " '" + Request.ServerVariables("REMOTE_ADDR") + "')"

            uCon = New uConnect
            uFunction.ExecuteDataStringNonTran(uCon.conn, strsql)
            dt_view = uFunction.getDataTable(uCon.conn, "select * from tbm_AB_CustomerReview where isbn_13 = '" + lblisbn.Text.Trim + "'")

            If dt_view.Rows.Count > 0 Then
                Dim Customer_View As Integer = 0
                Dim Rate_Count As Integer = 0

                Customer_View = Val(dt_view.Rows(0).Item("No_CustomerDiscussion").ToString) + 1
                Rate_Count = Val(dt_view.Rows(0).Item(strRate_fieldSql).ToString) + 1

                strsql_update = ""
                strsql_update &= " update tbm_AB_CustomerReview set "
                strsql_update &= " No_CustomerDiscussion = '" + Customer_View.ToString + "'"
                strsql_update &= " ,Is_Active = 'Y'"
                strsql_update &= " ," + strRate_fieldSql + " = '" + Rate_Count.ToString + "'"
                strsql_update &= " ,Updated = getdate()"
                strsql_update &= " ,UpdateBy = '" + Request.ServerVariables("REMOTE_ADDR") + "'"
                strsql_update &= " where isbn_13 = '" + lblisbn.Text.Trim + "'"
                uFunction.ExecuteDataStringNonTran(uCon.conn, strsql_update)
            End If
            Customer_Reviews()
            Customer_ReviewsDiscussion()
            txtDetail.Text = ""
        Catch ex As Exception
            uScript.Alert(Me.Page, Me.GetType, ex.Message.ToString)
        Finally
            uCon = Nothing
            dt_view = Nothing
        End Try
    End Sub

    Protected Sub gvCustomer_Reviews_RowDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewRowEventArgs) Handles gvCustomer_Reviews.RowDataBound
        If e.Row.RowType = DataControlRowType.DataRow Then
            Dim lblReView_Rate As Label = DirectCast(e.Row.FindControl("lblReView_Rate"), Label)
            Dim img_start As Image = DirectCast(e.Row.FindControl("img_start"), Image)

            Try
                Select Case lblReView_Rate.Text
                    Case "1"
                        img_start.ImageUrl = "~/images/Template/stars1.gif"
                    Case "2"
                        img_start.ImageUrl = "~/images/Template/stars2.gif"
                    Case "3"
                        img_start.ImageUrl = "~/images/Template/stars3.gif"
                    Case "4"
                        img_start.ImageUrl = "~/images/Template/stars4.gif"
                    Case "5"
                        img_start.ImageUrl = "~/images/Template/stars5.gif"
                End Select
            Catch ex As Exception
                Throw New Exception("gvCustomer Databound : " & ex.Message.ToString)
            Finally
                lblReView_Rate = Nothing
                img_start = Nothing
            End Try
        End If
    End Sub

    Protected Sub img_Msg_OK_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles img_Msg_OK.Click
        Response.Redirect("Special_Order_Form.aspx?MeassgeError=" & lblCheck_Meassge.Text)
    End Sub

    Protected Sub img_Msg_Cancel_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles img_Msg_Cancel.Click
        Response.Redirect("Homepage.aspx")
    End Sub

    Private Sub country_not_seal()
        Dim sql As String = ""
        Dim format As String = Session("format")
        Dim country As String = Session("client_nation")
        Dim isbn As String = Session("keyword")
        Dim datatable As New DataTable
        Dim sqlDB As New SqlDb
        Dim i As Integer

        sql &= " SELECT DISTINCT "
        sql &= " ebook.ebook_id "
        sql &= " , country.fullname "
        sql &= " FROM (select bookid as ebook_id from ebook_store where isbn_13 = " + isbn + " and format_type = " + format + ") as ebook"
        sql &= " , (select bookid as ebook_id , country_code from v_ebook_territory where isbn_13 = " + isbn + ") as v_territory "
        sql &= " , (select shortcode , fullname from ebook_country ) as country "
        sql &= " WHERE ebook.ebook_id = v_territory.ebook_id and v_territory.country_code = country.shortcode and country.fullname is not null "

        datatable = sqlDB.GetDataTable(sql)
        If datatable.Rows.Count > 0 Then
            Dim country_name As String = ""
            Dim first As Integer = 0
            For i = 0 To datatable.Rows.Count - 1
                If first > 0 Then
                    country_name &= " , "
                End If
                If datatable.Rows(i).Item("fullname").ToString <> "" Then
                    country_name &= datatable.Rows(i).Item("fullname").ToString
                    first = 1
                End If
            Next
            lblcountry.Text = country_name
            lbltxt_country.Visible = True
            lblcountry.Visible = True
        Else
            lbltxt_country.Visible = False
            lblcountry.Visible = False
        End If
    End Sub

    Private Sub button_ebook_format()
        Dim sql As String = ""
        Dim country As String = Session("client_nation")
        Dim territory As String = "ebook_territory_" + country.Trim.Substring(0, 1)
        Dim isbn As String = Session("keyword")
        Dim datatable As New DataTable
        Dim sqlDB As New SqlDb
        Dim i As Integer

        sql &= " SELECT "
        sql &= " case ebook.supplier_code when 'Asiabooks' then ROUND(convert(numeric(13,4),ebook.price_org),0) "
        sql &= " else ROUND(convert(numeric(18,4),(ebook.price_org * isnull(currency.exchange_rate,0))),0) end as selling_price "
        sql &= " , ebook.format_type , ebook.bookid as ebook_id , '0' as attributes "

        sql &= " FROM (select * from ebook_store where isbn_13 = " + isbn + " "

        If country = "TH" Then
            sql &= " and th = 1 "
            sql &= " ) as ebook "
        Else
            sql &= " ) as ebook "
            sql &= " left join (select distinct isbn_13 , country_code "
            sql &= " from " + territory + " where country_code = '" + country + "') as territory "
            sql &= " on ebook.isbn_13 = territory.isbn_13 "
        End If

        sql &= " , tbm_syst_organizeindent organize with (nolock) "
        sql &= " , tbm_syst_currency currency with (nolock) "

        sql &= " WHERE ebook.supplier_code = organize.org_indent_code "
        sql &= " and (convert(numeric(18,2),isnull(ebook.price_org,0)) * convert(numeric(18,2),isnull(ebook.moneytype,0))) > 0 "
        sql &= " and organize.currency_code = currency.currency_code "
        If country <> "TH" Then
            sql &= " and territory.country_code is null "
        End If
        sql &= " ORDER BY format_type "

        datatable = sqlDB.GetDataTable(sql)
        If datatable.Rows.Count > 0 Then
            Dim format_name() As String = {"GUY", "DRM-PDF", "PDF", "DRM-EPUB", "EPUB", "LIT", "MP3", "PDB", "MOBI"}
            Dim url_image(8) As String
            url_image(0) = "GUY"
            url_image(1) = "~/images/ebook/epdf.gif"
            url_image(2) = "~/images/ebook/pdf.gif"
            url_image(3) = "~/images/ebook/eepub.gif"
            url_image(4) = "~/images/ebook/epub.gif"
            url_image(5) = "~/images/ebook/lit.gif"
            url_image(6) = "~/images/ebook/mp3.gif"
            url_image(7) = "~/images/ebook/pdb.gif"
            url_image(8) = "~/images/ebook/pdb.gif"
            '**************************************
            If Not Session("ebook_shopping") Is Nothing Then
                Dim dataSession As DataTable = Session("ebook_shopping")
                For Each datarows_ As DataRow In datatable.Rows
                    Dim eBook_ID As String = datarows_.Item("eBook_ID").ToString
                    For Each datarows As DataRow In dataSession.Select("eBook_ID = '" + eBook_ID + "'")
                        datarows_.Item("attributes") = "1"
                    Next
                Next
            End If
            '**************************************
            For i = 0 To datatable.Rows.Count - 1
                Dim attributes As String = datatable.Rows(i).Item("attributes").ToString
                Dim format_type As String = datatable.Rows(i).Item("format_type").ToString
                Dim selling_price As Double = CDbl(datatable.Rows(i).Item("selling_price"))
                Dim selling_us As String = convert_to_us(selling_price)
                If i = 0 Then
                    hidden_img_btn1.Value = format_type
                    img_btn1.Attributes.Add("alt", "CLICK HERE TO VIEW DETAIL OF " + format_name(CInt(format_type)))
                    img_btn1.Attributes.Add("title", "CLICK HERE TO VIEW DETAIL OF " + format_name(CInt(format_type)))
                    img_btn1.ImageUrl = url_image(CInt(format_type))
                    lblprice1.Text = "Your Price : Bt. " + CDbl(selling_price).ToString("##,###")
                    lblus1.Text = selling_us
                    hidden_price1.Value = CDbl(selling_price).ToString("##,###")
                    panformat1.Visible = True
                    panformat1.BorderStyle = BorderStyle.Solid
                    panformat1.BorderWidth = 1
                    If attributes = "1" Then
                        hidden_alert1.Value = "1"
                        'btn_cart1.OnClientClick = "javascript:return confirm('You already have item(s) in shopping cart !! , Do you want to add this item ?');"
                    End If
                End If
                If i = 1 Then
                    hidden_img_btn2.Value = format_type
                    img_btn2.Attributes.Add("alt", "CLICK HERE TO VIEW DETAIL OF " + format_name(CInt(format_type)))
                    img_btn2.Attributes.Add("title", "CLICK HERE TO VIEW DETAIL OF " + format_name(CInt(format_type)))
                    img_btn2.ImageUrl = url_image(CInt(format_type))
                    lblprice2.Text = "Your Price : Bt. " + CDbl(selling_price).ToString("##,###")
                    lblus2.Text = selling_us
                    hidden_price2.Value = CDbl(selling_price).ToString("##,###")
                    panformat2.Visible = True
                    panformat2.BorderStyle = BorderStyle.Solid
                    panformat2.BorderWidth = 1
                    If attributes = "1" Then
                        hidden_alert2.Value = "1"
                        'btn_cart2.OnClientClick = "javascript:return confirm('You already have item(s) in shopping cart !! , Do you want to add this item ?');"
                    End If
                End If
                If i = 2 Then
                    hidden_img_btn3.Value = format_type
                    img_btn3.Attributes.Add("alt", "CLICK HERE TO VIEW DETAIL OF " + format_name(CInt(format_type)))
                    img_btn3.Attributes.Add("title", "CLICK HERE TO VIEW DETAIL OF " + format_name(CInt(format_type)))
                    img_btn3.ImageUrl = url_image(CInt(format_type))
                    lblprice3.Text = "Your Price : Bt. " + CDbl(selling_price).ToString("##,###")
                    lblus3.Text = selling_us
                    hidden_price3.Value = CDbl(selling_price).ToString("##,###")
                    panformat3.Visible = True
                    panformat3.BorderStyle = BorderStyle.Solid
                    panformat3.BorderWidth = 1
                    If attributes = "1" Then
                        hidden_alert3.Value = "1"
                        'btn_cart3.OnClientClick = "javascript:return confirm('You already have item(s) in shopping cart !! , Do you want to add this item ?');"
                    End If
                End If
                If i = 3 Then
                    hidden_img_btn4.Value = format_type
                    img_btn4.Attributes.Add("alt", "CLICK HERE TO VIEW DETAIL OF " + format_name(CInt(format_type)))
                    img_btn4.Attributes.Add("title", "CLICK HERE TO VIEW DETAIL OF " + format_name(CInt(format_type)))
                    img_btn4.ImageUrl = url_image(CInt(format_type))
                    lblprice4.Text = "Your Price : Bt. " + CDbl(selling_price).ToString("##,###")
                    lblus4.Text = selling_us
                    hidden_price4.Value = CDbl(selling_price).ToString("##,###")
                    panformat4.Visible = True
                    panformat4.BorderStyle = BorderStyle.Solid
                    panformat4.BorderWidth = 1
                    If attributes = "1" Then
                        hidden_alert4.Value = "1"
                        'btn_cart4.OnClientClick = "javascript:return confirm('You already have item(s) in shopping cart !! , Do you want to add this item ?');"
                    End If
                End If
                If i = 4 Then
                    hidden_img_btn5.Value = format_type
                    img_btn5.Attributes.Add("alt", "CLICK HERE TO VIEW DETAIL OF " + format_name(CInt(format_type)))
                    img_btn5.Attributes.Add("title", "CLICK HERE TO VIEW DETAIL OF " + format_name(CInt(format_type)))
                    img_btn5.ImageUrl = url_image(CInt(format_type))
                    lblprice5.Text = "Your Price : Bt. " + CDbl(selling_price).ToString("##,###")
                    lblus5.Text = selling_us
                    hidden_price5.Value = CDbl(selling_price).ToString("##,###")
                    panformat5.Visible = True
                    panformat5.BorderStyle = BorderStyle.Solid
                    panformat5.BorderWidth = 1
                    If attributes = "1" Then
                        hidden_alert5.Value = "1"
                        'btn_cart5.OnClientClick = "javascript:return confirm('You already have item(s) in shopping cart !! , Do you want to add this item ?');"
                    End If
                End If
                If i = 5 Then
                    hidden_img_btn6.Value = format_type
                    img_btn6.Attributes.Add("alt", "CLICK HERE TO VIEW DETAIL OF " + format_name(CInt(format_type)))
                    img_btn6.Attributes.Add("title", "CLICK HERE TO VIEW DETAIL OF " + format_name(CInt(format_type)))
                    img_btn6.ImageUrl = url_image(CInt(format_type))
                    lblprice6.Text = "Your Price : Bt. " + CDbl(selling_price).ToString("##,###")
                    lblus6.Text = selling_us
                    hidden_price6.Value = CDbl(selling_price).ToString("##,###")
                    panformat6.Visible = True
                    panformat6.BorderStyle = BorderStyle.Solid
                    panformat6.BorderWidth = 1
                    If attributes = "1" Then
                        hidden_alert6.Value = "1"
                        'btn_cart6.OnClientClick = "javascript:return confirm('You already have item(s) in shopping cart !! , Do you want to add this item ?');"
                    End If
                End If
                If i = 6 Then
                    hidden_img_btn7.Value = format_type
                    img_btn7.Attributes.Add("alt", "CLICK HERE TO VIEW DETAIL OF " + format_name(CInt(format_type)))
                    img_btn7.Attributes.Add("title", "CLICK HERE TO VIEW DETAIL OF " + format_name(CInt(format_type)))
                    img_btn7.ImageUrl = url_image(CInt(format_type))
                    lblprice7.Text = "Your Price : Bt. " + CDbl(selling_price).ToString("##,###")
                    lblus7.Text = selling_us
                    hidden_price7.Value = CDbl(selling_price).ToString("##,###")
                    panformat7.Visible = True
                    panformat7.BorderStyle = BorderStyle.Solid
                    panformat7.BorderWidth = 1
                    If attributes = "1" Then
                        hidden_alert7.Value = "1"
                        'btn_cart7.OnClientClick = "javascript:return confirm('You already have item(s) in shopping cart !! , Do you want to add this item ?');"
                    End If
                End If
                If i = 7 Then
                    hidden_img_btn8.Value = format_type
                    img_btn8.Attributes.Add("alt", "CLICK HERE TO VIEW DETAIL OF " + format_name(CInt(format_type)))
                    img_btn8.Attributes.Add("title", "CLICK HERE TO VIEW DETAIL OF " + format_name(CInt(format_type)))
                    img_btn8.ImageUrl = url_image(CInt(format_type))
                    lblprice8.Text = "Your Price : Bt. " + CDbl(selling_price).ToString("##,###")
                    lblus8.Text = selling_us
                    hidden_price8.Value = CDbl(selling_price).ToString("##,###")
                    panformat8.Visible = True
                    panformat8.BorderStyle = BorderStyle.Solid
                    panformat8.BorderWidth = 1
                    If attributes = "1" Then
                        hidden_alert8.Value = "1"
                        'btn_cart8.OnClientClick = "javascript:return confirm('You already have item(s) in shopping cart !! , Do you want to add this item ?');"
                    End If
                End If
            Next
        End If
    End Sub

    Private Function convert_to_us(ByVal x As Double) As String
        Dim class_book_detail As New Class_book_detail
        Dim price_usd As Double = class_book_detail.callUsd(x)
        Dim strings As String = "US$ " + CDbl(price_usd).ToString("###.##")
        Return strings
    End Function

    Protected Sub img_btn1_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles img_btn1.Click
        Session("format") = hidden_img_btn1.Value.Trim
        binddata()
    End Sub

    Protected Sub img_btn2_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles img_btn2.Click
        Session("format") = hidden_img_btn2.Value.Trim
        binddata()
    End Sub

    Protected Sub img_btn3_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles img_btn3.Click
        Session("format") = hidden_img_btn3.Value.Trim
        binddata()
    End Sub

    Protected Sub img_btn4_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles img_btn4.Click
        Session("format") = hidden_img_btn4.Value.Trim
        binddata()
    End Sub

    Protected Sub img_btn5_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles img_btn5.Click
        Session("format") = hidden_img_btn5.Value.Trim
        binddata()
    End Sub

    Protected Sub img_btn6_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles img_btn6.Click
        Session("format") = hidden_img_btn6.Value.Trim
        binddata()
    End Sub

    Protected Sub img_btn7_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles img_btn7.Click
        Session("format") = hidden_img_btn7.Value.Trim
        binddata()
    End Sub

    Protected Sub img_btn8_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles img_btn8.Click
        Session("format") = hidden_img_btn8.Value.Trim
        binddata()
    End Sub

    Protected Sub lnkAuthor_Head_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lnkAuthor_Head.Click
        Response.Redirect("Book_Search_Author.aspx?Author=" + lnkAuthor_Head.Text.Trim)
    End Sub

    Protected Sub lnkAuthor_Detail_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lnkAuthor_Detail.Click
        Response.Redirect("Book_Search_Author.aspx?Author=" + lnkAuthor_Detail.Text.Trim)
    End Sub

    Protected Sub btn_wish1_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles btn_wish1.Click
        Session("format") = hidden_img_btn1.Value.Trim
        Session("selling_price") = hidden_price1.Value.Trim
        class_wish_list()
    End Sub

    Protected Sub btn_wish2_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles btn_wish2.Click
        Session("format") = hidden_img_btn2.Value.Trim
        Session("selling_price") = hidden_price2.Value.Trim
        class_wish_list()
    End Sub

    Protected Sub btn_wish3_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles btn_wish3.Click
        Session("format") = hidden_img_btn3.Value.Trim
        Session("selling_price") = hidden_price3.Value.Trim
        class_wish_list()
    End Sub

    Protected Sub btn_wish4_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles btn_wish4.Click
        Session("format") = hidden_img_btn4.Value.Trim
        Session("selling_price") = hidden_price4.Value.Trim
        class_wish_list()
    End Sub

    Protected Sub btn_wish5_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles btn_wish5.Click
        Session("format") = hidden_img_btn5.Value.Trim
        Session("selling_price") = hidden_price5.Value.Trim
        class_wish_list()
    End Sub

    Protected Sub btn_wish6_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles btn_wish6.Click
        Session("format") = hidden_img_btn6.Value.Trim
        Session("selling_price") = hidden_price6.Value.Trim
        class_wish_list()
    End Sub

    Protected Sub btn_wish7_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles btn_wish7.Click
        Session("format") = hidden_img_btn7.Value.Trim
        Session("selling_price") = hidden_price7.Value.Trim
        class_wish_list()
    End Sub

    Protected Sub btn_wish8_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles btn_wish8.Click
        Session("format") = hidden_img_btn8.Value.Trim
        Session("selling_price") = hidden_price8.Value.Trim
        class_wish_list()
    End Sub

    Protected Sub btn_cart1_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles btn_cart1.Click
        Session("format_addcart") = hidden_img_btn1.Value.Trim
        If hidden_alert1.Value = "1" Then
            ModalPopupAlertCart.Show()
        Else
            class_addCart(Me.Request.QueryString("code").ToString.Trim, Session("format_addcart").ToString)
        End If
    End Sub

    Protected Sub btn_cart2_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles btn_cart2.Click
        Session("format_addcart") = hidden_img_btn2.Value.Trim
        If hidden_alert2.Value = "1" Then
            ModalPopupAlertCart.Show()
        Else
            class_addCart(Me.Request.QueryString("code").ToString.Trim, Session("format_addcart").ToString)
        End If
    End Sub

    Protected Sub btn_cart3_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles btn_cart3.Click
        Session("format_addcart") = hidden_img_btn3.Value.Trim
        If hidden_alert3.Value = "1" Then
            ModalPopupAlertCart.Show()
        Else
            class_addCart(Me.Request.QueryString("code").ToString.Trim, Session("format_addcart").ToString)
        End If
    End Sub

    Protected Sub btn_cart4_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles btn_cart4.Click
        Session("format_addcart") = hidden_img_btn4.Value.Trim
        If hidden_alert4.Value = "1" Then
            ModalPopupAlertCart.Show()
        Else
            class_addCart(Me.Request.QueryString("code").ToString.Trim, Session("format_addcart").ToString)
        End If
    End Sub

    Protected Sub btn_cart5_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles btn_cart5.Click
        Session("format_addcart") = hidden_img_btn5.Value.Trim
        If hidden_alert5.Value = "1" Then
            ModalPopupAlertCart.Show()
        Else
            class_addCart(Me.Request.QueryString("code").ToString.Trim, Session("format_addcart").ToString)
        End If
    End Sub

    Protected Sub btn_cart6_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles btn_cart6.Click
        Session("format_addcart") = hidden_img_btn6.Value.Trim
        If hidden_alert6.Value = "1" Then
            ModalPopupAlertCart.Show()
        Else
            class_addCart(Me.Request.QueryString("code").ToString.Trim, Session("format_addcart").ToString)
        End If
    End Sub

    Protected Sub btn_cart7_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles btn_cart7.Click
        Session("format_addcart") = hidden_img_btn7.Value.Trim
        If hidden_alert7.Value = "1" Then
            ModalPopupAlertCart.Show()
        Else
            class_addCart(Me.Request.QueryString("code").ToString.Trim, Session("format_addcart").ToString)
        End If
    End Sub

    Protected Sub btn_cart8_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles btn_cart8.Click
        Session("format_addcart") = hidden_img_btn8.Value.Trim
        If hidden_alert8.Value = "1" Then
            ModalPopupAlertCart.Show()
        Else
            class_addCart(Me.Request.QueryString("code").ToString.Trim, Session("format_addcart").ToString)
        End If
    End Sub

    Private Function CreateTable() As DataTable
        Dim datatable As New DataTable

        datatable.Columns.Add("No", System.Type.GetType("System.String"))
        datatable.Columns.Add("ISBN_13", System.Type.GetType("System.String"))
        datatable.Columns.Add("Book_ID", System.Type.GetType("System.String"))
        datatable.Columns.Add("Book_Title", System.Type.GetType("System.String"))
        datatable.Columns.Add("Selling_Price", System.Type.GetType("System.String"))
        datatable.Columns.Add("Quantity", System.Type.GetType("System.String"))
        datatable.Columns.Add("Supplier", System.Type.GetType("System.String"))
        datatable.Columns.Add("Exchange", System.Type.GetType("System.String"))
        datatable.Columns.Add("Exchange_Internet", System.Type.GetType("System.String"))
        datatable.Columns.Add("Discount", System.Type.GetType("System.String"))
        datatable.Columns.Add("Format", System.Type.GetType("System.String"))
        datatable.Columns.Add("Country", System.Type.GetType("System.String"))
        datatable.Columns.Add("Format_Type", System.Type.GetType("System.String"))
        datatable.Columns.Add("Size", System.Type.GetType("System.String"))

        Return datatable
    End Function

    Private Sub class_client_nation()
        If Session("client_nation") Is Nothing Then
            Dim gen As New gen_nation
            gen.ip = Request.UserHostAddress()
            Session("client_nation") = gen.gen_ip_code
        End If
    End Sub

    Private Function class_ebook_detail() As DataTable
        Dim datatable As New DataTable
        Dim isbn As String = Session("keyword")
        Dim country As String = Session("client_nation")
        If country.Length <> 2 Then
            Dim gen As New gen_nation
            gen.ip = Request.UserHostAddress()
            country = gen.gen_ip_code
        End If
        If Not Session("format") Is Nothing Then
            class_book_detail.ebook_format = Session("format")
        End If
        class_book_detail.ebook_isbn = isbn
        class_book_detail.country = country
        class_book_detail.territory = "ebook_territory_" + country.Substring(0, 1)
        Try
            datatable = class_book_detail.ebook_detail
        Catch ex As Exception
            Response.Redirect("Homepage.aspx")
        End Try

        Return datatable
    End Function

    Private Sub class_wish_list()
        Dim data As DataTable = class_ebook_detail()
        Dim datatable As DataTable = New DataTable("datatable")
        Dim datacolumn As DataColumn
        Dim datarow As DataRow

        datacolumn = New DataColumn()
        datacolumn.DataType = System.Type.GetType("System.String")
        datacolumn.ColumnName = "eBook_id"
        datacolumn.AutoIncrement = False
        datacolumn.Caption = "eBook_id"
        datacolumn.ReadOnly = False
        datacolumn.Unique = False
        datatable.Columns.Add(datacolumn)

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
        datacolumn.ColumnName = "Format"
        datacolumn.AutoIncrement = False
        datacolumn.Caption = "Format"
        datacolumn.ReadOnly = False
        datacolumn.Unique = False
        datatable.Columns.Add(datacolumn)

        datacolumn = New DataColumn()
        datacolumn.DataType = System.Type.GetType("System.String")
        datacolumn.ColumnName = "Format_Num"
        datacolumn.AutoIncrement = False
        datacolumn.Caption = "Format_Num"
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
        datacolumn.ColumnName = "Synopsis"
        datacolumn.AutoIncrement = False
        datacolumn.Caption = "Synopsis"
        datacolumn.ReadOnly = False
        datacolumn.Unique = False
        datatable.Columns.Add(datacolumn)

        Dim alert As String = ""
        If Session("ebook_wish_lish") Is Nothing Then
            datarow = datatable.NewRow
            datarow("Image") = hidden_ebook_image.Value.Trim
            datarow("eBook_id") = data.Rows(0).Item("eBook_id").ToString.Trim
            datarow("ISBN_13") = data.Rows(0).Item("ISBN_13").ToString.Trim
            datarow("Book_Title") = data.Rows(0).Item("Book_Title").ToString.Trim
            datarow("Author") = data.Rows(0).Item("Author").ToString.Trim
            datarow("Source") = data.Rows(0).Item("Source").ToString.Trim
            datarow("Selling_Price") = Session("selling_price").ToString.Trim
            datarow("Format") = data.Rows(0).Item("eBook_Format").ToString.Trim
            datarow("Format_Num") = data.Rows(0).Item("Format_Num").ToString.Trim
            datarow("Synopsis") = data.Rows(0).Item("Synopsis").ToString.Trim.Replace("-", "")
            datatable.Rows.Add(datarow)
            Session("ebook_wish_lish") = datatable
        Else
            datatable = Session("ebook_wish_lish")
            Dim id As String = data.Rows(0).Item("eBook_id").ToString.Trim
            For Each a As DataRow In datatable.Rows
                If a.Item("eBook_id").ToString = id Then
                    alert = "alert"
                End If
            Next
            If alert = "" Then
                datarow = datatable.NewRow
                datarow("Image") = hidden_ebook_image.Value.Trim
                datarow("eBook_id") = data.Rows(0).Item("eBook_id").ToString.Trim
                datarow("ISBN_13") = data.Rows(0).Item("ISBN_13").ToString.Trim
                datarow("Book_Title") = data.Rows(0).Item("Book_Title").ToString.Trim
                datarow("Author") = data.Rows(0).Item("Author").ToString.Trim
                datarow("Source") = data.Rows(0).Item("Source").ToString.Trim
                datarow("Selling_Price") = Session("selling_price").ToString.Trim
                datarow("Format") = data.Rows(0).Item("eBook_Format").ToString.Trim
                datarow("Format_Num") = data.Rows(0).Item("Format_Num").ToString.Trim
                datarow("Synopsis") = data.Rows(0).Item("Synopsis").ToString.Trim.Replace("-", "")
                datatable.Rows.Add(datarow)
                Session("ebook_wish_lish") = datatable
            End If
        End If
        If alert = "" Then
            Response.Redirect("Wishlist_internet.aspx")
        Else
            ModalPopupAlert.Show()
        End If
    End Sub

    Private Sub class_addCart(ByVal isbn As String, ByVal format_type As String)
        Dim sqlDB As SqlDb = New SqlDb
        Dim datatable As New DataTable
        Dim sql As String = ""
        Dim alertQuantity As String = "N"
        Dim country As String = Session("client_nation")

        If txt_qty.Text = "" Or txt_qty.Text = "0" Then
            txt_qty.Text = "1"
            alertQuantity = "Y"
        End If

        sql &= " SELECT "
        sql &= " case search.source when 'Asiabooks' then ROUND(convert(numeric(18,4),search.selling),0) "
        sql &= " else ROUND(convert(numeric(18,4),(search.selling * isnull(search.exchange_rate,0))) - "
        sql &= " convert(numeric(18,4),(search.selling * isnull(search.exchange_rate,0) * (search.ecom_discount)) / 100),0) "
        sql &= " end as selling_price "

        sql &= " , search.ebook_id , search.isbn_13 , search.book_title , search.author , search.publisher_name "
        sql &= " , search.image , search.source as supplier , search.discount , search.ebook_format as format , search.format_type "
        sql &= " , search.copy_rigths , search.page_qty , search.size , search.publication_date , search.language "
        sql &= " , search.synopsis , search.size , search.exchange_rate as exchange , search.exchange_internet "
        sql &= " , '-' as subject_name " '//// รอข้อมูล category
        sql &= " , '" + txt_qty.Text + "' as quantity"
        sql &= " , '" + country + "' as country"

        sql &= " FROM "
        sql &= " (select distinct ebook.bookid as ebook_id , ebook.isbn_13 "
        sql &= " , ebook.supplier_code as source , ebook.book_title , ebook.publication_date "
        sql &= " , case ebook.author when '' then '-' else ebook.author end as author "
        sql &= " , case ebook.publisher_name when '' then '-' else ebook.publisher_name end as publisher_name "
        sql &= " , case when right(ebook.publication_date,4) = '0000' then '-' else right(ebook.publication_date,4) end as copy_rigths "
        sql &= " , case when cast(ebook.page_qty as varchar) is null then '-' else cast(ebook.page_qty as varchar) end as page_qty "
        sql &= " , case when cast(ebook.file_size as varchar) is null then '-' else cast(ebook.file_size as varchar) end as size "
        sql &= " , case when ebook.language is null then '-' else ebook.language end as language "
        sql &= " , case when ebook.synopsis is null then '-' else ebook.synopsis end as synopsis "
        sql &= " , convert(numeric(18,4) , ebook.price_org) as selling , ebook.isbn_10 as image , ebook.format_type "
        sql &= " , isnull(ebook.discount_sp,0) as discount , currency.exchange_rate , currency.exchange_rate_internet as exchange_internet , type.type as ebook_format "
        sql &= " , isnull(ebook.discount_sp,0) as ecom_discount "

        sql &= " from ebook_store ebook with (nolock) "
        sql &= " , tbm_syst_organizeindent organize with (nolock) "
        sql &= " , tbm_syst_currency currency with (nolock) "
        sql &= " , ebook_type type with (nolock) "

        sql &= " where ebook.supplier_code = organize.org_indent_code and organize.currency_code = currency.currency_code "
        sql &= " and ebook.format_type = type.formatid "
        sql &= " and ebook.isbn_13 = " + isbn + " "
        sql &= " and ebook.format_type = '" + format_type + "' "
        sql &= " ) as search "

        datatable = sqlDB.GetDataTable(sql)
        Session.Remove("format_addcart")
        If Session("ebook_shopping") Is Nothing Then
            Dim datatableNew As DataTable = CreateTable()
            Dim datarow As DataRow
            datarow = datatableNew.NewRow
            datarow("Book_Title") = datatable.Rows(0).Item("Book_Title").ToString
            datarow("ISBN_13") = datatable.Rows(0).Item("ISBN_13").ToString
            datarow("Book_ID") = datatable.Rows(0).Item("eBook_ID").ToString
            datarow("Selling_Price") = datatable.Rows(0).Item("Selling_Price").ToString
            datarow("Quantity") = datatable.Rows(0).Item("Quantity").ToString
            datarow("Supplier") = datatable.Rows(0).Item("Supplier").ToString
            datarow("Exchange") = datatable.Rows(0).Item("Exchange").ToString
            datarow("Exchange_Internet") = datatable.Rows(0).Item("Exchange_Internet").ToString
            datarow("Discount") = datatable.Rows(0).Item("Discount").ToString
            datarow("Format") = datatable.Rows(0).Item("Format").ToString
            datarow("Country") = datatable.Rows(0).Item("Country").ToString
            datarow("Format_Type") = datatable.Rows(0).Item("Format_Type").ToString
            datarow("Size") = datatable.Rows(0).Item("Size").ToString
            datatableNew.Rows.Add(datarow)

            class_book_detail.dataOld = datatableNew
            class_book_detail.From_ebook = "ebook"
            class_book_detail.Recalcuate()
            Session("ebook_shopping") = class_book_detail.dataCart
            'Session("original_total") = class_book_detail.original_total
            Session("amount_ebook") = class_book_detail.amount_ebook
        Else
            Dim dataSession As DataTable = Session("ebook_shopping")
            Dim datatableNew As DataTable = CreateTable()
            Dim datarow As DataRow
            datarow = datatableNew.NewRow
            datarow("Book_Title") = datatable.Rows(0).Item("Book_Title").ToString
            datarow("ISBN_13") = datatable.Rows(0).Item("ISBN_13").ToString
            datarow("Book_ID") = datatable.Rows(0).Item("eBook_ID").ToString
            datarow("Selling_Price") = datatable.Rows(0).Item("Selling_Price").ToString
            datarow("Quantity") = datatable.Rows(0).Item("Quantity").ToString
            datarow("Supplier") = datatable.Rows(0).Item("Supplier").ToString
            datarow("Exchange") = datatable.Rows(0).Item("Exchange").ToString
            datarow("Exchange_Internet") = datatable.Rows(0).Item("Exchange_Internet").ToString
            datarow("Discount") = datatable.Rows(0).Item("Discount").ToString
            datarow("Format") = datatable.Rows(0).Item("Format").ToString
            datarow("Country") = datatable.Rows(0).Item("Country").ToString
            datarow("Format_Type") = datatable.Rows(0).Item("Format_Type").ToString
            datarow("Size") = datatable.Rows(0).Item("Size").ToString
            datatableNew.Rows.Add(datarow)

            class_book_detail.dataOld = dataSession
            class_book_detail.dataNew = datatableNew
            class_book_detail.From_ebook = "ebook"
            class_book_detail.Recalcuate()
            Session("ebook_shopping") = class_book_detail.dataCart
            'Session("original_total") = class_book_detail.original_total
            Session("amount_ebook") = class_book_detail.amount_ebook
        End If
        Response.Redirect("shoppingCart_Internet.aspx")
    End Sub

    Protected Sub btn_alertClose_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles btn_alertClose.Click
        Response.Redirect("Wishlist_internet.aspx")
    End Sub

    Protected Sub btn_yes_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles btn_yes.Click
        class_addCart(Me.Request.QueryString("code").ToString.Trim, Session("format_addcart").ToString)
    End Sub

    Protected Sub btn_no_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles btn_no.Click
        ModalPopupAlertCart.Hide()
    End Sub
End Class
