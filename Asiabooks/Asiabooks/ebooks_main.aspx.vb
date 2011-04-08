Imports System
Imports System.Data
Imports Eordering.BusinessLogic
Imports Eordering.BusinessLogic.PageControl
Imports System.Linq
Imports System.Xml
Imports System.Xml.Linq
Partial Class ebooks_main
    Inherits System.Web.UI.Page
    Private bd As New Class_book_detail
    Private _Utility As New clsUtility
    Private uCon As uConnect
    Public javascript1 As String = ""
    Private country As String = ""
    Private min_price As String = "50"

    Public Sub getUrl(ByVal imagePath As String)

        Response.Write(Request.Url.Scheme.ToString & Uri.SchemeDelimiter.ToString & _
                       Request.Url.Authority.ToString & _
                       imagePath)
        'IIf(Request.ApplicationPath.ToString = "/", "", Request.ApplicationPath.ToString) & imagePath)

    End Sub
    Private Function getUrl1(ByVal imagePath As String) As String
        Dim imag1 As String = ""
        imag1 = Request.Url.Scheme.ToString & Uri.SchemeDelimiter.ToString & _
                       Request.Url.Authority.ToString & _
                       IIf(Request.ApplicationPath.ToString = "/", "", Request.ApplicationPath.ToString) & imagePath
        Return imag1
    End Function

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Me.Title = ConfigurationManager.AppSettings("SiteTitle").ToString & "eBooks ::"

        If country = "" Then
            Try
                country = Session("client_nation").ToString()
            Catch ex As Exception
                Dim gen As New gen_nation
                gen.ip = Request.UserHostAddress()
                Session("client_nation") = gen.gen_ip_code
                country = Session("client_nation").ToString()
            End Try
        End If

        If Session("exchange_str") Is Nothing Then
            Try
                Session("exchange_str") = Me.getExchangerate_string()
            Catch ex As Exception

            End Try
        End If

        javascript1 = Session("javascript1")
        If Not IsPostBack Then
            javascript1 = ""
            Session("javascript1") = ""

            Me.Get_Cat()
            Me.Get_feature()

            Dim item_num As Integer = 12
            lblhead1.Text = "Bestselling eBooks"
            lv_ebook1.DataSource = ebook_feature(item_num, 0, 0, "bestselling") ' SqlDataSource_feature
            lv_ebook1.DataBind()

            lblhead2.Text = "New York Times Bestselling"
            lv_ebook2.DataSource = ebook_feature(item_num, 0, 0, "bestselling_nyt")
            lv_ebook2.DataBind()

            'lblhead3.Text = "Awards Winning titles - Now available in eBooks"
            'lv_ebook3.DataSource = ebook_feature(item_num, 0, 0, "feature") 'lv_ebook2.DataSource 'ebook(item_num, 0, 0, " and (convert(numeric(13,2) , ebook.price_thb)/(1-(convert(numeric(13,2) ,ebook.Discount)/100))) <= 350.00")
            'lv_ebook3.DataBind()

            lblhead4.Text = "eBooks under Bt. 350"
            lv_ebook4.DataSource = ebook(item_num, 0, 0, " and (convert(numeric(13,2) , ebook.price_thb)/(1-(convert(numeric(13,2) ,ebook.Discount)/100))) <= 350.00")
            lv_ebook4.DataBind()

            lblhead5.Text = "Thailand and Regional Interest eBooks"
            lv_ebook5.DataSource = ebook_Thailand_and_Regional(item_num, "special_list")
            lv_ebook5.DataBind()

            lblhead6.Text = "The Best Value for International eBooks "
            lv_ebook6.DataSource = ebook_International_bestsellers(item_num, "special_list")
            lv_ebook6.DataBind()

            If lv_ebook1.Items.Count = 12 Then
                Me.lnkMore.HRef = "~/eBook_SeeMore.aspx?catcode=1"
                Me.lnkMore.Visible = True
                Me.imgSeemore.Visible = True

            End If

            If lv_ebook2.Items.Count = 12 Then
                Me.lnkMore2.HRef = "~/eBook_SeeMore.aspx?catcode=2"
                Me.lnkMore2.Visible = True
                Me.imgSeemore2.Visible = True

            End If

            If lv_ebook3.Items.Count = 12 Then

                Me.lnkMore3.HRef = "~/eBook_SeeMore.aspx?catcode=3"
                Me.lnkMore3.Visible = True
                Me.imgSeemore3.Visible = True

            End If

            If lv_ebook4.Items.Count = 12 Then
                Me.lnkMore4.HRef = "~/eBook_SeeMore.aspx?catcode=4"
                Me.lnkMore4.Visible = True
                Me.imgSeemore4.Visible = True

            End If

            If lv_ebook5.Items.Count = 12 Then
                Me.lnkMore5.HRef = "~/eBook_SeeMore.aspx?catcode=5"
                Me.lnkMore5.Visible = True
                Me.imgSeemore5.Visible = True

            End If

            If lv_ebook5.Items.Count = 12 Then
                Me.lnkMore6.HRef = "~/eBook_SeeMore.aspx?catcode=6"
                Me.lnkMore6.Visible = True
                Me.imgSeemore6.Visible = True

            End If
        Else

            Dim cat_condition As String = ""

            If (ddlCat.SelectedIndex > 0) Then
                cat_condition = " and ebook.catcode = '" + ddlCat.SelectedValue + "' "
                Dim item_num As Integer = 12
                Try
                    lv_ebook1.DataSource = ebook(item_num, 0, 0, cat_condition) ' SqlDataSource_feature
                    lv_ebook1.DataBind()
                    lv_ebook2.Visible = False
                    lv_ebook3.Visible = False
                    lv_ebook4.Visible = False
                    lv_ebook5.Visible = False
                    lv_ebook6.Visible = False

                Catch ex As Exception

                End Try

                lblhead1.Text = ddlCat.SelectedItem.Text

                If lv_ebook1.Items.Count = 12 Then
                    If ddlCat.SelectedIndex > 0 Then
                        Me.lnkMore.HRef = "~/eBook_SeeMore.aspx?catcode=" & ddlCat.SelectedValue
                        Me.lnkMore.Visible = True
                        Me.imgSeemore.Visible = True
                    End If

                End If
            Else
                Dim item_num As Integer = 12
                lblhead1.Text = "Bestselling eBooks"
                lv_ebook1.DataSource = ebook_feature(item_num, 0, 0, "bestselling")
                lv_ebook1.DataBind()
                lv_ebook2.Visible = True
                lv_ebook3.Visible = True
                lv_ebook4.Visible = True
                lv_ebook5.Visible = True
                lv_ebook6.Visible = True

                If lv_ebook1.Items.Count = 12 Then
                    Me.lnkMore.HRef = "~/eBook_SeeMore.aspx?catcode=1"
                    Me.lnkMore.Visible = True
                    Me.imgSeemore.Visible = True

                End If

                If lv_ebook2.Items.Count = 12 Then
                    Me.lnkMore2.HRef = "~/eBook_SeeMore.aspx?catcode=2"
                    Me.lnkMore2.Visible = True
                    Me.imgSeemore2.Visible = True

                End If

                If lv_ebook3.Items.Count = 12 Then

                    Me.lnkMore3.HRef = "~/eBook_SeeMore.aspx?catcode=3"
                    Me.lnkMore3.Visible = True
                    Me.imgSeemore3.Visible = True

                End If

                If lv_ebook4.Items.Count = 12 Then
                    Me.lnkMore4.HRef = "~/eBook_SeeMore.aspx?catcode=4"
                    Me.lnkMore4.Visible = True
                    Me.imgSeemore4.Visible = True

                End If

                If lv_ebook5.Items.Count = 12 Then
                    Me.lnkMore5.HRef = "~/eBook_SeeMore.aspx?catcode=5"
                    Me.lnkMore5.Visible = True
                    Me.imgSeemore5.Visible = True

                End If
                If lv_ebook6.Items.Count = 12 Then
                    Me.lnkMore6.HRef = "~/eBook_SeeMore.aspx?catcode=6"
                    Me.lnkMore6.Visible = True
                    Me.imgSeemore6.Visible = True

                End If
            End If


        End If

    End Sub

    Private Sub Get_Cat()
        Dim item As New ListItem
        ddlCat.Items.Clear()
        Try
            SqlDataSource_feature.SelectCommand = "SELECT DISTINCT ebook_supplier_category.Code as catcode,ebook_supplier_category.Description as catname FROM ebook_supplier_category INNER JOIN ebook_map_category ON ebook_supplier_category.Code = ebook_map_category.ebook_cat_code  WHERE ebook_supplier_category.Active = 'Y'"
            ddlCat.DataTextField = "catname"
            ddlCat.DataValueField = "catcode"
            ddlCat.DataSource = SqlDataSource_feature
            ddlCat.DataBind()

            item.Value = ""
            item.Text = " -- Select by Category Group -- "

            ddlCat.Items.Insert(0, item)
        Catch ex As Exception
            Throw ex
        Finally
            item = Nothing
        End Try

    End Sub



    Private Sub Get_feature()

        Dim item_num As Integer = 2

        'Dim dt As New DataTable()
        'dt = Me.CreateDataTable()
        'dt.Rows.Add(ebook(item_num, 1, 0, "").AsEnumerable().Skip(0).Take(2))
        'Dim datetimevalue As New Date() ' The DateTime limit 
        DataList_feature.DataSource = ebook(item_num, 1, 0, "")
        DataList_thismonth.DataSource = ebook(item_num, 1, 14, "")
        DataList_all.DataSource = ebook(item_num, 1, 30, "")

        DataList_feature.DataBind()
        DataList_thismonth.DataBind()
        DataList_all.DataBind()

    End Sub

    Private Function Get_feature_xml(ByVal cat_name As String, ByVal strfile As String) As Object
        Dim xmlDoc As XElement

        Try
            xmlDoc = XElement.Load(strfile)

            Dim Items = From c In xmlDoc.Elements("EBooks") _
                        Where c.Element("type") = "BestSeller_EBooks" _
                        And c.Element("name_display") <> cat_name _
                        Order By Convert.ToInt16(c.Element("orderby").Value) Ascending _
                        Select isbn_13 = c.Element("isbn_13").Value, _
                        image = _Utility.GetImagePath(c.Element("image").Value), _
                        book_title = IIf(c.Element("book_title").Value.Length > 50, Left(c.Element("book_title").Value, 50) & "...", c.Element("book_title").Value), _
                        author = IIf(c.Element("author").Value.Length > 20, Left(c.Element("author").Value, 20) & "...", c.Element("author").Value), _
                        selling_price = CDbl(c.Element("list_price").Value.ToString).ToString("#,###,##0.00"), _
                        your_price = CDbl(c.Element("your_price").Value.ToString).ToString("#,###,##0.00"), _
                        your_price_usd = bd.callUsd(Convert.ToDouble(c.Element("your_price").Value)), _
                        save_price = c.Element("save_price").Value, _
                        book_title_full = c.Element("book_title").Value, _
                        author_full = c.Element("author").Value, _
                        Book_Type = c.Element("Book_Type").Value, _
                        publisher_name = c.Element("publisher_name").Value, _
                        eBook_Format = c.Element("eBook_Format").Value, _
                        Source = c.Element("Source").Value, _
                        Format_Type = c.Element("Format_Type").Value, _
                        Other_Format = c.Element("Other_Format").Value, _
                        Synopsis = c.Element("Synopsis").Value

            Return Items.Take(6)
        Catch ex As Exception
            Throw New Exception("BestSeller_EBooks : " & ex.Message.ToString)
            Return Nothing
        Finally
            xmlDoc = Nothing
        End Try
    End Function

    Protected Sub DataList_feature_ItemDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.DataListItemEventArgs) Handles DataList_feature.ItemDataBound, DataList_thismonth.ItemDataBound, DataList_all.ItemDataBound
        If e.Item.ItemType = ListItemType.Item Or e.Item.ItemType = ListItemType.AlternatingItem Then
            Dim lblList_Price_L As Label = e.Item.FindControl("lblList_Price_L")
            Dim lblList_Price_D As Label = e.Item.FindControl("lblList_Price_D")
            Dim lblYout_Price_L As Label = e.Item.FindControl("lblYout_Price_L")
            Dim lblYout_Price_D As Label = e.Item.FindControl("lblYout_Price_D")
            Dim lblSave_Price As Label = e.Item.FindControl("lblSave_Price")
            Dim lblImage As Image = e.Item.FindControl("Book_Image")
            Dim lbl_synopsis As Label = e.Item.FindControl("lbl_synopsis")
            Dim lblBook_Title As Label = e.Item.FindControl("lblBook_Title")

            If lblBook_Title.Text.Length > 50 Then
                lblBook_Title.Text = lblBook_Title.Text.Substring(0, 50) + "..."
            End If

            Try
                'lblImage.ImageUrl = _Utility.GetImagePath_eBook(lblImage.ImageUrl.ToString())
                lblImage.ImageUrl = _Utility.GetImagePath_eBook(lblImage.ImageUrl.ToString().Substring(0, 3) & "/" & lblImage.ImageUrl.ToString().Substring(3, 3) & "/" & lblImage.ImageUrl.ToString().Substring(6, 3) & "/" & lblImage.ImageUrl.ToString() + ".jpg")

            Catch ex As Exception

            End Try

            If lblList_Price_D.Text = lblYout_Price_D.Text Then
                lblList_Price_D.Visible = False
                lblList_Price_L.Visible = False
                lblSave_Price.Visible = False
            Else
                lblList_Price_D.Font.Strikeout = True
            End If
            Dim lblList_isbn13 As Label = e.Item.FindControl("Label12")

            Dim lnkavailable As LinkButton = e.Item.FindControl("lnkavailable")
            Dim lnkformat1 As ImageButton = e.Item.FindControl("lnkformat1")
            Dim lnkformat2 As ImageButton = e.Item.FindControl("lnkformat2")
            Dim lnkformat3 As ImageButton = e.Item.FindControl("lnkformat3")
            Dim lnkformat4 As ImageButton = e.Item.FindControl("lnkformat4")
            Dim lnkformat5 As ImageButton = e.Item.FindControl("lnkformat5")
            Dim lnkformat6 As ImageButton = e.Item.FindControl("lnkformat6")
            Dim lnkformat7 As ImageButton = e.Item.FindControl("lnkformat7")
            Dim lnkformat8 As ImageButton = e.Item.FindControl("lnkformat8")
            Dim lbltxt_format As Label = e.Item.FindControl("lbltxt_format")
            Dim hdd_ebook_format As Label = e.Item.FindControl("hdd_ebook_format")

            lbltxt_format.Visible = False
            lnkformat1.Enabled = False
            lnkformat2.Enabled = False
            lnkformat3.Enabled = False
            lnkformat4.Enabled = False
            lnkformat5.Enabled = False
            lnkformat6.Enabled = False
            lnkformat7.Enabled = False
            lnkformat8.Enabled = False
            lnkformat1.Visible = False
            lnkformat2.Visible = False
            lnkformat3.Visible = False
            lnkformat4.Visible = False
            lnkformat5.Visible = False
            lnkformat6.Visible = False
            lnkformat7.Visible = False
            lnkformat8.Visible = False
            Dim isbn As String = lblList_isbn13.Text.Trim

            lbltxt_format.Visible = True
            Dim format_name() As String = {"GUY", "DRM-PDF", "PDF", "DRM-EPUB", "EPUB", "LIT", "MP3", "PDB", "MOBI"}
            Dim array() As String = hdd_ebook_format.Text.Split(",")
            Dim i As Integer = 0
            For i = 0 To array.Length - 1
                If array(i) <> "" Then
                    If array(i) = 1 Then
                        lnkformat1.PostBackUrl = "~/ebook_detail.aspx?code=" + isbn + "&format=" + array(i) + ""
                        lnkformat1.Enabled = True
                        lnkformat1.Visible = True
                    End If
                    If array(i) = 2 Then
                        lnkformat2.PostBackUrl = "~/ebook_detail.aspx?code=" + isbn + "&format=" + array(i) + ""
                        lnkformat2.Enabled = True
                        lnkformat2.Visible = True
                    End If
                    If array(i) = 3 Then
                        lnkformat3.PostBackUrl = "~/ebook_detail.aspx?code=" + isbn + "&format=" + array(i) + ""
                        lnkformat3.Enabled = True
                        lnkformat3.Visible = True
                    End If
                    If array(i) = 4 Then
                        lnkformat4.PostBackUrl = "~/ebook_detail.aspx?code=" + isbn + "&format=" + array(i) + ""
                        lnkformat4.Enabled = True
                        lnkformat4.Visible = True
                    End If
                    If array(i) = 5 Then
                        lnkformat5.PostBackUrl = "~/ebook_detail.aspx?code=" + isbn + "&format=" + array(i) + ""
                        lnkformat5.Enabled = True
                        lnkformat5.Visible = True
                    End If
                    If array(i) = 6 Then
                        lnkformat6.PostBackUrl = "~/ebook_detail.aspx?code=" + isbn + "&format=" + array(i) + ""
                        lnkformat6.Enabled = True
                        lnkformat6.Visible = True
                    End If
                    If array(i) = 7 Then
                        lnkformat7.PostBackUrl = "~/ebook_detail.aspx?code=" + isbn + "&format=" + array(i) + ""
                        lnkformat7.Enabled = True
                        lnkformat7.Visible = True
                    End If
                End If
            Next
            'Dim dataItem As Object = DirectCast(e.Item, DataListItem).DataItem
            'dataItem("Synopsis")
            javascript1 = javascript1 + " var display_book" + e.Item.NamingContainer.ID + isbn + "=new  reelslideshow({wrapperid: ""display_book" + e.Item.NamingContainer.ID + isbn + """,	dimensions: [126, 168], 	imagearray: [		[""" + lblImage.ImageUrl.Replace("~/", "") + """, ""ebook_detail.aspx?code=" + isbn + "&format=" + array(0) + """, """", """"],		[""" + lblImage.ImageUrl.Replace("~/", "") + """, ""ebook_detail.aspx?code=" + isbn + "&format=" + array(0) + """, """", """ + lbl_synopsis.Text.Replace("""", "") + """] 	],	displaymode: {type:'auto', pause:5000, cycles:0, wraparound:false},	persist: false,	fadeduration: 500,	descreveal: ""always"",	togglerid: """"});"
            Session("javascript1") = Session("javascript1") + javascript1
        End If
    End Sub



    Protected Sub lv_ebook1_ItemDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.ListViewItemEventArgs) Handles lv_ebook1.ItemDataBound, lv_ebook2.ItemDataBound, lv_ebook3.ItemDataBound, lv_ebook4.ItemDataBound
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
            Dim lblImage As Image = e.Item.FindControl("Book_Image")
            Dim lbl_price_usd As Label = e.Item.FindControl("lbl_price_usd")
            Dim lbl_title As Label = e.Item.FindControl("Label2")

            Dim hdd_ebook_format As Label = e.Item.FindControl("hdd_ebook_format")
            Dim format_name() As String = {"GUY", "DRM-PDF", "PDF", "DRM-EPUB", "EPUB", "LIT", "MP3", "PDB", "MOBI"}
            Dim format_img() As String = {"GUY", "<img src=""images/ebook/epdf.gif"" border=""0"" alt=""CLICK HERE TO VIEW DETAIL OF DRM-PDF"" title=""CLICK HERE TO VIEW DETAIL OF DRM-PDF"">", "<img src=""images/ebook/pdf.gif"" border=""0"" alt=""CLICK HERE TO VIEW DETAIL OF PDF"" title=""CLICK HERE TO VIEW DETAIL OF PDF"">", "<img src=""images/ebook/eepub.gif"" border=""0"" alt=""CLICK HERE TO VIEW DETAIL OF DRM-EPUB"" title=""CLICK HERE TO VIEW DETAIL OF DRM-EPUB"">", "<img src=""images/ebook/epub.gif"" border=""0"" alt=""CLICK HERE TO VIEW DETAIL OF EPUB"" title=""CLICK HERE TO VIEW DETAIL OF EPUB"">", "<img src=""images/ebook/lit.gif"" border=""0"" alt=""CLICK HERE TO VIEW DETAIL OF LIT"" title=""CLICK HERE TO VIEW DETAIL OF LIT"">", "<img src=""images/ebook/mp3.gif"" border=""0"" alt=""CLICK HERE TO VIEW DETAIL OF MP3"" title=""CLICK HERE TO VIEW DETAIL OF MP3"">", "<img src=""images/ebook/pdb.gif"" border=""0"" alt=""CLICK HERE TO VIEW DETAIL OF PDB"" title=""CLICK HERE TO VIEW DETAIL OF PDB"">", "<img src=""images/ebook/mobi.gif"" border=""0"" alt=""CLICK HERE TO VIEW DETAIL OF MOBI"" title=""CLICK HERE TO VIEW DETAIL OF MOBI"">"}
            Dim array() As String = hdd_ebook_format.Text.Split(",")
            Dim i As Integer = 0
            Dim isbn As String = lblisbn.Text
            Dim format_text As String = ""
            For i = 0 To array.Length - 1
                If array(i) <> "" Then
                    format_text &= " <a href=""ebook_detail.aspx?code=" + isbn + "&format=" + array(i) + """>" & format_img(array(i)) & "</a> "
                End If
            Next
            hdd_ebook_format.Text = format_text
            If lbl_title.Text.Length > 50 Then
                lbl_title.Text = lbl_title.Text.Substring(0, 50) + "..."
            End If
            Try
                lblImage.ImageUrl = _Utility.GetImagePath_eBook(lblImage.ImageUrl.ToString().Substring(0, 3) & "/" & lblImage.ImageUrl.ToString().Substring(3, 3) & "/" & lblImage.ImageUrl.ToString().Substring(6, 3) & "/" & lblImage.ImageUrl.ToString() + ".jpg")
                'lblImage.ImageUrl = _Utility.GetImagePath_eBook(lblImage.ImageUrl.ToString())

            Catch ex As Exception

            End Try

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
            strsql &= " select * from dbo.tbm_AB_CustomerReview"
            strsql &= " where isbn_13 = '" + lblisbn.Text.Trim + "'"

            dt_view = uFunction.getDataTable(uCon.conn, strsql)
            If dt_view.Rows.Count > 0 Then
                lblCustomerView.Text = "View : " & dt_view.Rows(0).Item("No_CustomerView").ToString
            Else
                lblCustomerView.Text = "View : 0"
            End If
            imgCustomer_Average.Visible = False

            'strsql = ""
            'strsql &= " select case No_CustomerDiscussion when '0' then '0' else ((No_CusReview1*1)+(No_CusReview2*2)+(No_CusReview3*3)+"
            'strsql &= " (No_CusReview4*4)+(No_CusReview5*5))/No_CustomerDiscussion end as total,*"
            'strsql &= " from dbo.tbm_AB_CustomerReview"
            'strsql &= " where isbn_13 = '" + lblisbn.Text + "'"

            'dt_view = uFunction.getDataTable(uCon.conn, strsql)
            'If dt_view.Rows.Count > 0 Then
            '    Dim strCustomer_Average As String = ""
            '    strCustomer_Average = dt_view.Rows(0).Item("total").ToString
            '    imgCustomer_Average.ImageUrl = "~/images/Template/stars0.gif"
            '    'กรณีคำนวนแล้วได้ 0 ต้องคิดค่าเฉลี่ยเอง

            '    If strCustomer_Average = "0" Then
            '        dt_view.Clear()
            '        strsql = ""
            '        strsql &= " select (CASE WHEN right(isbn_13,2)='00' "
            '        strsql &= " THEN 99*3/99 "
            '        strsql &= " ELSE right(isbn_13,2)*3/right(isbn_13,2) END) AS total,"
            '        strsql &= " (CASE WHEN right(isbn_13,2)='00' "
            '        strsql &= " THEN '99' "
            '        strsql &= " ELSE right(isbn_13,2) END) AS No_CustomerView"
            '        strsql &= " from ebook_store"
            '        strsql &= " where isbn_13 = '" + lblisbn.Text + "'"
            '        dt_view = uFunction.getDataTable(uCon.conn, strsql)
            '        If dt_view.Rows.Count > 0 Then
            '            strCustomer_Average = dt_view.Rows(0).Item("total").ToString
            '            lblCustomerView.Text = dt_view.Rows(0).Item("No_CustomerView").ToString

            '            Select Case strCustomer_Average
            '                Case "1"
            '                    imgCustomer_Average.ImageUrl = "~/images/Template/stars1.gif"
            '                Case "2"
            '                    imgCustomer_Average.ImageUrl = "~/images/Template/stars2.gif"
            '                Case "3"
            '                    imgCustomer_Average.ImageUrl = "~/images/Template/stars3.gif"
            '                Case "4"
            '                    imgCustomer_Average.ImageUrl = "~/images/Template/stars4.gif"
            '                Case "5"
            '                    imgCustomer_Average.ImageUrl = "~/images/Template/stars5.gif"
            '                Case Else
            '                    imgCustomer_Average.ImageUrl = "~/images/Template/stars0.gif"
            '            End Select
            '        End If
            '    Else
            '        lblCustomerView.Text = dt_view.Rows(0).Item("No_CustomerView").ToString
            '        'lblCustomerView.Text = "0"
            '        Select Case strCustomer_Average
            '            Case "1"
            '                imgCustomer_Average.ImageUrl = "~/images/Template/stars1.gif"
            '            Case "2"
            '                imgCustomer_Average.ImageUrl = "~/images/Template/stars2.gif"
            '            Case "3"
            '                imgCustomer_Average.ImageUrl = "~/images/Template/stars3.gif"
            '            Case "4"
            '                imgCustomer_Average.ImageUrl = "~/images/Template/stars4.gif"
            '            Case "5"
            '                imgCustomer_Average.ImageUrl = "~/images/Template/stars5.gif"
            '            Case Else
            '                imgCustomer_Average.ImageUrl = "~/images/Template/stars0.gif"
            '        End Select
            '    End If

            'Else
            '    dt_view.Clear()
            '    strsql = ""
            '    strsql &= " select (CASE WHEN right(isbn_13,2)='00' "
            '    strsql &= " THEN 99*3/99 "
            '    strsql &= " ELSE right(isbn_13,2)*3/right(isbn_13,2) END) AS total,"
            '    strsql &= " (CASE WHEN right(isbn_13,2)='00' "
            '    strsql &= " THEN '99' "
            '    strsql &= " ELSE right(isbn_13,2) END) AS No_CustomerView"
            '    strsql &= " from ebook_store"
            '    strsql &= " where isbn_13 = '" + lblisbn.Text + "'"
            '    dt_view = uFunction.getDataTable(uCon.conn, strsql)
            '    If dt_view.Rows.Count > 0 Then
            '        Dim strCustomer_Average As String = "0"
            '        strCustomer_Average = dt_view.Rows(0).Item("total").ToString
            '        lblCustomerView.Text = dt_view.Rows(0).Item("No_CustomerView").ToString

            '        Select Case strCustomer_Average
            '            Case "1"
            '                imgCustomer_Average.ImageUrl = "~/images/Template/stars1.gif"
            '            Case "2"
            '                imgCustomer_Average.ImageUrl = "~/images/Template/stars2.gif"
            '            Case "3"
            '                imgCustomer_Average.ImageUrl = "~/images/Template/stars3.gif"
            '            Case "4"
            '                imgCustomer_Average.ImageUrl = "~/images/Template/stars4.gif"
            '            Case "5"
            '                imgCustomer_Average.ImageUrl = "~/images/Template/stars5.gif"
            '            Case Else
            '                imgCustomer_Average.ImageUrl = "~/images/Template/stars0.gif"
            '        End Select
            '    Else
            '        lblCustomerView.Text = "0"
            '    End If

            'End If
        End If
    End Sub

    Protected Sub ddlCat_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ddlCat.SelectedIndexChanged
        'Dim catcode As String = Me.Request.QueryString("catcode")
        'SqlDataSource_feature.SelectCommand = "SELECT Code as catcode,Description as catname FROM Category WHERE Active = 'Y' and [Division Code] = 'BOOK' and "
        'ddlCat.SelectedValue = catcode

        'lblhead1.Text = ddlCat.SelectedItem.Text
    End Sub

    Private Function CreateDataTable() As DataTable
        Dim dt As New DataTable

        dt.Columns.Add(New DataColumn("isbn_13", System.Type.GetType("System.String")))
        dt.Columns.Add(New DataColumn("book_title", System.Type.GetType("System.String")))
        dt.Columns.Add(New DataColumn("author", System.Type.GetType("System.String")))
        dt.Columns.Add(New DataColumn("Source", System.Type.GetType("System.String")))
        dt.Columns.Add(New DataColumn("Selling_price", System.Type.GetType("System.String")))
        dt.Columns.Add(New DataColumn("list_price", System.Type.GetType("System.String")))
        dt.Columns.Add(New DataColumn("your_price", System.Type.GetType("System.String")))
        dt.Columns.Add(New DataColumn("your_price_usd", System.Type.GetType("System.String")))
        dt.Columns.Add(New DataColumn("Synopsis", System.Type.GetType("System.String")))
        dt.Columns.Add(New DataColumn("publisher_name", System.Type.GetType("System.String")))
        dt.Columns.Add(New DataColumn("eBook_Format", System.Type.GetType("System.String")))
        dt.Columns.Add(New DataColumn("Book_Type", System.Type.GetType("System.String")))
        dt.Columns.Add(New DataColumn("Format_Type", System.Type.GetType("System.String")))
        dt.Columns.Add(New DataColumn("Other_Format", System.Type.GetType("System.String")))
        dt.Columns.Add(New DataColumn("save_price", System.Type.GetType("System.String")))
        dt.Columns.Add(New DataColumn("image", System.Type.GetType("System.String")))
        dt.Columns.Add(New DataColumn("datenew", System.Type.GetType("System.DateTime")))

        Return dt
    End Function


    Function ebook(ByVal item_num As Integer, ByVal mode As Integer, ByVal day As Integer, ByVal condition As String) As DataTable
        Dim strsql As String = ""
        Dim SqlDb As New SqlDb
        Dim sql_datatable As New DataTable

        Dim datatable As DataTable = New DataTable("datatable")
        Dim datacolumn As New DataColumn
        Dim datarow As DataRow

        datatable = CreateDataTable()

        If (item_num < 1) Then
            item_num = 1
        End If

        strsql &= "select distinct top(" + (item_num).ToString() + ") ebook.isbn_13 "
        strsql &= " from ebook_store ebook with (nolock)"

        If country = "" Then
            Try
                country = Session("client_nation").ToString()
            Catch ex As Exception
                Dim gen As New gen_nation
                gen.ip = Request.UserHostAddress()
                Session("client_nation") = gen.gen_ip_code
                country = Session("client_nation").ToString()
            End Try
        End If

        Dim territory = "ebook_territory_" + country.Substring(0, 1)

        If Not country = "TH" Then
            strsql &= " left join " + territory + " "
            strsql &= " on ebook.bookid = " + territory + ".bookid and " + territory + ".country_code = '" + country + "'"
        End If

        strsql &= " where (ebook.status = 'active') "

        If condition.Length > 0 Then
            strsql &= condition
        End If

        If mode = 1 Then
            If day = 14 Then
                strsql &= " and ebook.datenew < DATEADD(day, -14, GETDATE()) and ebook.datenew > DATEADD(day, -30, GETDATE())"
            ElseIf day = 30 Then
                strsql &= " and ebook.datenew < DATEADD(day, -30, GETDATE()) "
            Else
                strsql &= " and ebook.datenew > DATEADD(day, -7, GETDATE()) and ebook.datenew > DATEADD(day, -14, GETDATE())"
            End If
        End If

        If country = "TH" Then
            strsql &= " and ebook.th = 1 and (convert(numeric(13,2) , ebook.price_thb)/(1-(convert(numeric(13,2) ,ebook.Discount)/100))) > " + min_price + " "
        Else
            strsql &= " and (convert(numeric(13,2) , ebook.price_thb)/(1-(convert(numeric(13,2) ,ebook.Discount)/100)))  > " + min_price + " "
            strsql &= "and case when " + territory + ".country_code is null "
            strsql &= " then 'available' else 'not available' end = 'available' "
        End If


        strsql &= "ORDER BY ebook.isbn_13 desc"

        Try
            sql_datatable = New DataTable
            'Response.Write(strsql + "<br/>")
            sql_datatable = SqlDb.GetDataTable(strsql)
            Dim isbn_13 As String = ""
            If sql_datatable.Rows.Count > 0 Then
                isbn_13 = "("
                Dim first As Integer = 0
                Dim i As Integer = 0

                For i = 0 To sql_datatable.Rows.Count - 1
                    'sql_datatable.Rows(i).Item("ebook_format") = ""
                    If first = 0 Then
                        isbn_13 &= sql_datatable.Rows(i).Item("isbn_13").ToString
                        first = 1
                    Else
                        isbn_13 &= "," + sql_datatable.Rows(i).Item("isbn_13").ToString
                    End If
                Next
                isbn_13 &= ")"
                Dim data_format As New DataTable
                data_format = CreateDataTable()
                If isbn_13 <> "()" Then
                    data_format = get_format_ebook(isbn_13)
                End If
                Dim rownum As Integer = 0
                For i = 0 To sql_datatable.Rows.Count - 1
                    datarow = datatable.NewRow
                    For Each drj As DataRow In data_format.Rows
                        If sql_datatable.Rows(i).Item("isbn_13") = drj.Item("isbn_13") And CDbl(drj.Item("Selling_price")) > min_price Then
                            datarow("ebook_format") &= drj.Item("format_type").ToString + ","
                            datarow("ISBN_13") = drj.Item("ISBN_13").ToString
                            datarow("Book_Title") = drj.Item("Book_Title").ToString
                            datarow("Synopsis") = drj.Item("synopsis").ToString
                            datarow("Author") = drj.Item("Author").ToString
                            datarow("Publisher_Name") = drj.Item("Publisher_Name").ToString
                            datarow("Source") = drj.Item("Source").ToString
                            datarow("Selling_price") = CDbl(drj.Item("Selling_price")).ToString("#,###")
                            datarow("list_price") = CDbl(drj.Item("Selling_price")).ToString("#,###")
                            datarow("your_price") = CDbl(drj.Item("Selling_price")).ToString("#,###")
                            datarow("your_price_usd") = "US$ " & bd.callUsd(Convert.ToDouble(drj.Item("Selling_price").ToString)).ToString
                            datarow("save_price") = CDbl(drj.Item("Selling_price")).ToString("#,###")
                            datarow("Image") = drj.Item("Image").ToString
                            datarow("Book_Type") = "ebook"
                            'datarow("eBook_Format") = drj.Item("eBook_Format").ToString
                            datarow("Format_Type") = drj.Item("Format_Type").ToString
                            datarow("Other_Format") = drj.Item("Other_Format").ToString
                        End If
                    Next
                    datatable.Rows.Add(datarow)
                Next
            Else
                datatable = sql_datatable
            End If
        Catch ex As Exception
            '    Throw (New Exception("Advance Search Error :" + ex.Message))
        Finally
            sql_datatable = Nothing
            SqlDb = Nothing
            strsql = Nothing
            datacolumn = Nothing
            datarow = Nothing
        End Try

        Return datatable
    End Function

    Private Function getExchangerate_string() As String
        Dim res As String = ""
        Dim strsql As String = ""
        strsql = "select tbm_syst_currency.Exchange_Rate,tbm_syst_organizeindent.Org_Indent_Code  from tbm_syst_currency inner join tbm_syst_organizeindent on tbm_syst_currency.Currency_Code = tbm_syst_organizeindent.Currency_Code"
        Dim SqlDb As New SqlDb
        Dim sql_datatable As New DataTable
        sql_datatable = New DataTable
        sql_datatable = SqlDb.GetDataTable(strsql)

        'when 'Gardners' then " + "50.76" + "
        Dim i As Integer
        For i = 0 To sql_datatable.Rows.Count - 1
            res &= " when '" & sql_datatable.Rows(i).Item("Org_Indent_Code").ToString() & "' then " & sql_datatable.Rows(i).Item("Exchange_Rate").ToString()
        Next
        Return res
    End Function


    Function get_format_ebook(ByVal isbn_13 As String) As DataTable
        Dim strsql As String
        Dim SqlDb As New SqlDb
        Dim sql_datatable As New DataTable
        Dim exchange_str As String = ""
        Dim territory = "ebook_territory_" + country.Substring(0, 1)

        If Not Session("exchange_str") Is Nothing Then
            exchange_str = Session("exchange_str").ToString()
        End If

        strsql = ""
        strsql &= " select ebook_store.bookid , ebook_store.isbn_13 , ebook_store.discount, ebook_store.book_title ,ebook_store.synopsis"
        strsql &= " , case ebook_store.author when '' then '-' else ebook_store.author end as author "
        strsql &= " , case ebook_store.publisher_name when '' then '-' else ebook_store.publisher_name end as publisher_name "
        strsql &= " , round((convert(numeric(13,2) , ebook_store.price_org)*case ebook_store.supplier_code when 'AsiaBooks' then 1.00 " + exchange_str + " else 32.38 end),0) as selling_price , ebook_store.isbn_10 as image  "
        strsql &= " , ebook_store.supplier_code as source , cast(ebook_store.on_book as varchar) as other_format "
        strsql &= " , cast(ebook_store.format_type as varchar) as format_type,ebook_store.datenew from ebook_store with (nolock) "
        'If country = "TH" Then
        '    strsql &= " where ebook_store.th = 1 "
        'Else
        '    strsql &= " left join " + territory + " on ebook_store.bookid = " + territory + ".bookid and country_code = '" + country + "' and " + territory + ".isbn_13 in " + isbn_13 + " "
        '    strsql &= "  "
        '    strsql &= " where (ebook_store.status = 'active') "
        '    'strsql &= " and convert(numeric(13,2) , ebook_store.price_org) > 0 "
        '    strsql &= "and case when " + territory + ".country_code is null "
        '    strsql &= " then 'available' else 'not available' end = 'available' "
        'End If
        strsql &= "where ebook_store.isbn_13 in " + isbn_13 + " and ebook_store.status = 'active'"

        Try
            sql_datatable = New DataTable
            'Response.Write(strsql + "<br/>")
            sql_datatable = SqlDb.GetDataTable(strsql)
        Catch ex As Exception
            '    Throw (New Exception("Get Format Error :" + ex.Message))
        Finally
            SqlDb = Nothing
            strsql = Nothing
        End Try

        Return sql_datatable
    End Function

    Function get_format_ebook_International_bestsellers(ByVal isbn_13 As String) As DataTable
        Dim strsql As String
        Dim SqlDb As New SqlDb
        Dim sql_datatable As New DataTable
        Dim exchange_str As String = ""
        Dim territory = "ebook_territory_" + country.Substring(0, 1)


        If Not Session("exchange_str") Is Nothing Then
            exchange_str = Session("exchange_str").ToString()
        End If

        strsql = ""
        strsql &= " select ebook_store.bookid , ebook_store.isbn_13 , ebook_store.discount, "
        strsql &= " ebook_store.book_title ,ebook_store.synopsis ,"
        strsql &= " ebook_special_list.selling_price_eCom,ebook_special_list.eCom_Discount,ebook_special_list.Price_save,ebook_special_list.selling_price as selling_price,"
        strsql &= " case ebook_store.author when '' then '-' else ebook_store.author end as author  ,ebook_store.isbn_10 as image, "
        strsql &= " case ebook_store.publisher_name when '' then '-' else ebook_store.publisher_name end as publisher_name  , "
        'strsql &= " round((convert(numeric(13,2) , ebook_store.price_org)*case ebook_store.supplier_code when 'AsiaBooks' then 1.00 " + exchange_str + " else 32.38 end),0) as selling_price ,  "
        strsql &= " ebook_store.supplier_code as source , cast(ebook_store.on_book as varchar) as other_format  , "
        strsql &= " cast(ebook_store.format_type as varchar) as format_type,ebook_store.datenew "
        strsql &= " from ebook_store with (nolock) left join ebook_special_list "
        strsql &= " on ebook_special_list.isbn_13 = ebook_store.isbn_13"
        strsql &= " where ebook_store.isbn_13 in " + isbn_13
        strsql &= " and ebook_store.status = 'active'"
        strsql &= " order by ebook_special_list.rank"

        Try
            sql_datatable = New DataTable
            sql_datatable = SqlDb.GetDataTable(strsql)
        Catch ex As Exception
            '    Throw (New Exception("Get Format Error :" + ex.Message))
        Finally
            SqlDb = Nothing
            strsql = Nothing
        End Try

        Return sql_datatable
    End Function

    Function ebook_feature(ByVal item_num As Integer, ByVal mode As Integer, ByVal day As Integer, ByVal condition As String) As DataTable
        Dim strsql As String = ""
        Dim SqlDb As New SqlDb
        Dim sql_datatable As New DataTable

        Dim datatable As DataTable = New DataTable("datatable")
        Dim datacolumn As New DataColumn
        Dim datarow As DataRow

        datatable = CreateDataTable()

        If (item_num < 1) Then
            item_num = 1
        End If

        strsql &= "select distinct top(" + (item_num).ToString() + ") ebook.isbn_13,ebook.rank "
        strsql &= " from ebook_" + condition + " ebook with (nolock)"

        If country = "" Then
            Try
                country = Session("client_nation").ToString()
            Catch ex As Exception
                Dim gen As New gen_nation
                gen.ip = Request.UserHostAddress()
                Session("client_nation") = gen.gen_ip_code
                country = Session("client_nation").ToString()
            End Try
        End If

        If country = "TH" Then
            strsql &= " inner join ebook_store on ebook.isbn_13 = ebook_store.isbn_13 and ebook_store.th = 1 and (convert(numeric(13,2) , ebook_store.price_thb)/(1-(convert(numeric(13,2) ,ebook_store.Discount)/100))) > " + min_price + " order by ebook.rank"
        Else
            Dim territory = "ebook_territory_" + country.Substring(0, 1)

            strsql &= " left join " + territory + " "
            strsql &= " on ebook.isbn_13 = " + territory + ".isbn_13 and " + territory + ".country_code = '" + country + "'"
            strsql &= " where case when " + territory + ".country_code is null "
            strsql &= " then 'available' else 'not available' end = 'available' order by ebook.rank"

        End If

        Try
            sql_datatable = New DataTable
            'Response.Write(strsql + "<br/>")
            sql_datatable = SqlDb.GetDataTable(strsql)
            Dim isbn_13 As String = ""
            If sql_datatable.Rows.Count > 0 Then
                isbn_13 = "("
                Dim first As Integer = 0
                Dim i As Integer = 0

                For i = 0 To sql_datatable.Rows.Count - 1
                    'sql_datatable.Rows(i).Item("ebook_format") = ""
                    If first = 0 Then
                        isbn_13 &= sql_datatable.Rows(i).Item("isbn_13").ToString
                        first = 1
                    Else
                        isbn_13 &= "," + sql_datatable.Rows(i).Item("isbn_13").ToString
                    End If
                Next
                isbn_13 &= ")"
                Dim data_format As New DataTable
                data_format = CreateDataTable()
                If isbn_13 <> "()" Then
                    data_format = get_format_ebook(isbn_13)
                End If
                Dim rownum As Integer = 0
                For i = 0 To sql_datatable.Rows.Count - 1
                    datarow = datatable.NewRow
                    For Each drj As DataRow In data_format.Rows
                        If sql_datatable.Rows(i).Item("isbn_13") = drj.Item("isbn_13") And CDbl(drj.Item("Selling_price")) > min_price Then
                            datarow("ebook_format") &= drj.Item("format_type").ToString + ","
                            datarow("ISBN_13") = drj.Item("ISBN_13").ToString
                            datarow("Book_Title") = drj.Item("Book_Title").ToString
                            datarow("Synopsis") = drj.Item("synopsis").ToString
                            datarow("Author") = drj.Item("Author").ToString
                            datarow("Publisher_Name") = drj.Item("Publisher_Name").ToString
                            datarow("Source") = drj.Item("Source").ToString
                            datarow("Selling_price") = CDbl(drj.Item("Selling_price")).ToString("#,###")
                            datarow("list_price") = CDbl(drj.Item("Selling_price")).ToString("#,###")
                            datarow("your_price") = CDbl(drj.Item("Selling_price")).ToString("#,###")
                            datarow("your_price_usd") = "US$ " & bd.callUsd(Convert.ToDouble(drj.Item("Selling_price").ToString)).ToString
                            datarow("save_price") = CDbl(drj.Item("Selling_price")).ToString("#,###")
                            datarow("Image") = drj.Item("Image").ToString
                            datarow("Book_Type") = "ebook"
                            'datarow("eBook_Format") = drj.Item("eBook_Format").ToString
                            datarow("Format_Type") = drj.Item("Format_Type").ToString
                            datarow("Other_Format") = drj.Item("Other_Format").ToString
                        End If
                    Next

                    If Not datarow("Book_Title") = "" Then
                        datatable.Rows.Add(datarow)
                    End If
                Next
            Else
                datatable = sql_datatable
            End If
        Catch ex As Exception
            '    Throw (New Exception("Advance Search Error :" + ex.Message))
        Finally
            sql_datatable = Nothing
            SqlDb = Nothing
            strsql = Nothing
            datacolumn = Nothing
            datarow = Nothing
        End Try

        Return datatable
    End Function

    Function ebook_Thailand_and_Regional(ByVal item_num As Integer, ByVal condition As String) As DataTable
        Dim strsql As String = ""
        Dim SqlDb As New SqlDb
        Dim sql_datatable As New DataTable

        Dim datatable As DataTable = New DataTable("datatable")
        Dim datacolumn As New DataColumn
        Dim datarow As DataRow

        datatable = CreateDataTable()

        If (item_num < 1) Then
            item_num = 1
        End If

        strsql &= "select distinct top(" + (item_num).ToString() + ") ebook.isbn_13,ebook.type_code "
        strsql &= " from ebook_" + condition + " ebook with (nolock)"

        If country = "" Then
            Try
                country = Session("client_nation").ToString()
            Catch ex As Exception
                Dim gen As New gen_nation
                gen.ip = Request.UserHostAddress()
                Session("client_nation") = gen.gen_ip_code
                country = Session("client_nation").ToString()
            End Try
        End If

        If country = "TH" Then
            strsql &= " left join ebook_store on ebook.isbn_13 = ebook_store.isbn_13  "
            strsql &= " and ebook_store.th = 1 and (convert(numeric(13,2) , ebook_store.price_thb)/(1-(convert(numeric(13,2) "
            strsql &= " ,ebook_store.Discount)/100))) > " + min_price + " "
            strsql &= " where ebook.type_code = 'Thailand and Regional' "
            strsql &= " order by ebook.isbn_13 "
        Else
            Dim territory = "ebook_territory_" + country.Substring(0, 1)

            strsql &= " left join " + territory + " "
            strsql &= " on ebook.isbn_13 = " + territory + ".isbn_13 and " + territory + ".country_code = '" + country + "'"
            strsql &= " where ebook.type_code = 'Thailand and Regional' and case when " + territory + ".country_code is null "
            strsql &= " then 'available' else 'not available' end = 'available' order by ebook.isbn_13"

        End If

        Try
            sql_datatable = New DataTable
            sql_datatable = SqlDb.GetDataTable(strsql)
            Dim isbn_13 As String = ""
            If sql_datatable.Rows.Count > 0 Then
                isbn_13 = "("
                Dim first As Integer = 0
                Dim i As Integer = 0

                For i = 0 To sql_datatable.Rows.Count - 1
                    If first = 0 Then
                        isbn_13 &= sql_datatable.Rows(i).Item("isbn_13").ToString
                        first = 1
                    Else
                        isbn_13 &= "," + sql_datatable.Rows(i).Item("isbn_13").ToString
                    End If
                Next
                isbn_13 &= ")"
                Dim data_format As New DataTable
                data_format = CreateDataTable()
                If isbn_13 <> "()" Then
                    data_format = get_format_ebook(isbn_13)
                End If
                Dim rownum As Integer = 0
                For i = 0 To sql_datatable.Rows.Count - 1
                    datarow = datatable.NewRow
                    For Each drj As DataRow In data_format.Rows
                        If sql_datatable.Rows(i).Item("isbn_13") = drj.Item("isbn_13") And CDbl(drj.Item("Selling_price")) > min_price Then
                            datarow("ebook_format") &= drj.Item("format_type").ToString + ","
                            datarow("ISBN_13") = drj.Item("ISBN_13").ToString
                            datarow("Book_Title") = drj.Item("Book_Title").ToString
                            datarow("Synopsis") = drj.Item("synopsis").ToString
                            datarow("Author") = drj.Item("Author").ToString
                            datarow("Publisher_Name") = drj.Item("Publisher_Name").ToString
                            datarow("Source") = drj.Item("Source").ToString
                            datarow("Selling_price") = CDbl(drj.Item("Selling_price")).ToString("#,###")
                            datarow("list_price") = CDbl(drj.Item("Selling_price")).ToString("#,###")
                            datarow("your_price") = CDbl(drj.Item("Selling_price")).ToString("#,###")
                            datarow("your_price_usd") = "US$ " & bd.callUsd(Convert.ToDouble(drj.Item("Selling_price").ToString)).ToString
                            datarow("save_price") = CDbl(drj.Item("Selling_price")).ToString("#,###")
                            datarow("Image") = drj.Item("Image").ToString
                            datarow("Book_Type") = "ebook"
                            datarow("Format_Type") = drj.Item("Format_Type").ToString
                            datarow("Other_Format") = drj.Item("Other_Format").ToString
                        End If
                    Next

                    If Not datarow("Book_Title") = "" Then
                        datatable.Rows.Add(datarow)
                    End If
                Next
            Else
                datatable = sql_datatable
            End If
        Catch ex As Exception
            '    Throw (New Exception("Advance Search Error :" + ex.Message))
        Finally
            sql_datatable = Nothing
            SqlDb = Nothing
            strsql = Nothing
            datacolumn = Nothing
            datarow = Nothing
        End Try

        Return datatable
    End Function

    Function ebook_International_bestsellers(ByVal item_num As Integer, ByVal condition As String) As DataTable
        Dim strsql As String = ""
        Dim SqlDb As New SqlDb
        Dim sql_datatable As New DataTable

        Dim datatable As DataTable = New DataTable("datatable")
        Dim datacolumn As New DataColumn
        Dim datarow As DataRow

        datatable = CreateDataTable()

        If (item_num < 1) Then
            item_num = 1
        End If

        strsql &= "select distinct top(" + (item_num).ToString() + ") ebook.isbn_13,ebook.type_code,ebook.rank "
        strsql &= " from ebook_" + condition + " ebook with (nolock)"

        If country = "" Then
            Try
                country = Session("client_nation").ToString()
            Catch ex As Exception
                Dim gen As New gen_nation
                gen.ip = Request.UserHostAddress()
                Session("client_nation") = gen.gen_ip_code
                country = Session("client_nation").ToString()
            End Try
        End If

        If country = "TH" Then
            strsql &= " left join ebook_store on ebook.isbn_13 = ebook_store.isbn_13  "
            strsql &= " and ebook_store.th = 1 and (convert(numeric(13,2) , ebook_store.price_thb)/(1-(convert(numeric(13,2) "
            strsql &= " ,ebook_store.Discount)/100))) > " + min_price + " "
            strsql &= " where ebook.type_code = 'International bestsellers' "
            strsql &= " order by ebook.rank "
        Else
            Dim territory = "ebook_territory_" + country.Substring(0, 1)

            strsql &= " left join " + territory + " "
            strsql &= " on ebook.isbn_13 = " + territory + ".isbn_13 and " + territory + ".country_code = '" + country + "'"
            strsql &= " where ebook.type_code = 'International bestsellers' and case when " + territory + ".country_code is null "
            strsql &= " then 'available' else 'not available' end = 'available' order by ebook.rank "

        End If

        Try
            sql_datatable = New DataTable
            sql_datatable = SqlDb.GetDataTable(strsql)
            Dim isbn_13 As String = ""
            If sql_datatable.Rows.Count > 0 Then
                isbn_13 = "("
                Dim first As Integer = 0
                Dim i As Integer = 0

                For i = 0 To sql_datatable.Rows.Count - 1
                    If first = 0 Then
                        isbn_13 &= sql_datatable.Rows(i).Item("isbn_13").ToString
                        first = 1
                    Else
                        isbn_13 &= "," + sql_datatable.Rows(i).Item("isbn_13").ToString
                    End If
                Next
                isbn_13 &= ")"
                Dim data_format As New DataTable
                data_format = CreateDataTable()
                If isbn_13 <> "()" Then
                    data_format = get_format_ebook_International_bestsellers(isbn_13)
                End If
                Dim rownum As Integer = 0
                For i = 0 To sql_datatable.Rows.Count - 1
                    datarow = datatable.NewRow
                    For Each drj As DataRow In data_format.Rows
                        If sql_datatable.Rows(i).Item("isbn_13") = drj.Item("isbn_13") And CDbl(drj.Item("Selling_price")) > min_price Then
                            datarow("ebook_format") &= drj.Item("format_type").ToString + ","
                            datarow("ISBN_13") = drj.Item("ISBN_13").ToString
                            datarow("Book_Title") = drj.Item("Book_Title").ToString
                            datarow("Synopsis") = drj.Item("synopsis").ToString
                            datarow("Author") = drj.Item("Author").ToString
                            datarow("Publisher_Name") = drj.Item("Publisher_Name").ToString
                            datarow("Source") = drj.Item("Source").ToString
                            datarow("Selling_price") = CDbl(drj.Item("Selling_price")).ToString("#,###")
                            datarow("list_price") = CDbl(drj.Item("Selling_price")).ToString("#,###")
                            datarow("your_price") = CDbl(drj.Item("selling_price_eCom")).ToString("#,###")
                            datarow("your_price_usd") = "US$ " & bd.callUsd(Convert.ToDouble(drj.Item("selling_price_eCom").ToString)).ToString
                            datarow("save_price") = CDbl(drj.Item("eCom_Discount")).ToString("#,###")
                            datarow("Image") = drj.Item("Image").ToString
                            datarow("Book_Type") = "ebook"
                            datarow("Format_Type") = drj.Item("Format_Type").ToString
                            datarow("Other_Format") = drj.Item("Other_Format").ToString
                        End If
                    Next

                    If Not datarow("Book_Title") = "" Then
                        datatable.Rows.Add(datarow)
                    End If
                Next
            Else
                datatable = sql_datatable
            End If
        Catch ex As Exception
            '    Throw (New Exception("Advance Search Error :" + ex.Message))
        Finally
            sql_datatable = Nothing
            SqlDb = Nothing
            strsql = Nothing
            datacolumn = Nothing
            datarow = Nothing
        End Try

        Return datatable
    End Function

    Protected Sub lv_ebook5_ItemDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.ListViewItemEventArgs) Handles lv_ebook5.ItemDataBound
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
            Dim lblImage As Image = e.Item.FindControl("Book_Image")
            Dim lbl_price_usd As Label = e.Item.FindControl("lbl_price_usd")
            Dim lbl_title As Label = e.Item.FindControl("Label2")

            Dim hdd_ebook_format As Label = e.Item.FindControl("hdd_ebook_format")
            Dim format_name() As String = {"GUY", "DRM-PDF", "PDF", "DRM-EPUB", "EPUB", "LIT", "MP3", "PDB", "MOBI"}
            Dim format_img() As String = {"GUY", "<img src=""images/ebook/epdf.gif"" border=""0"" alt=""CLICK HERE TO VIEW DETAIL OF DRM-PDF"" title=""CLICK HERE TO VIEW DETAIL OF DRM-PDF"">", "<img src=""images/ebook/pdf.gif"" border=""0"" alt=""CLICK HERE TO VIEW DETAIL OF PDF"" title=""CLICK HERE TO VIEW DETAIL OF PDF"">", "<img src=""images/ebook/eepub.gif"" border=""0"" alt=""CLICK HERE TO VIEW DETAIL OF DRM-EPUB"" title=""CLICK HERE TO VIEW DETAIL OF DRM-EPUB"">", "<img src=""images/ebook/epub.gif"" border=""0"" alt=""CLICK HERE TO VIEW DETAIL OF EPUB"" title=""CLICK HERE TO VIEW DETAIL OF EPUB"">", "<img src=""images/ebook/lit.gif"" border=""0"" alt=""CLICK HERE TO VIEW DETAIL OF LIT"" title=""CLICK HERE TO VIEW DETAIL OF LIT"">", "<img src=""images/ebook/mp3.gif"" border=""0"" alt=""CLICK HERE TO VIEW DETAIL OF MP3"" title=""CLICK HERE TO VIEW DETAIL OF MP3"">", "<img src=""images/ebook/pdb.gif"" border=""0"" alt=""CLICK HERE TO VIEW DETAIL OF PDB"" title=""CLICK HERE TO VIEW DETAIL OF PDB"">", "<img src=""images/ebook/mobi.gif"" border=""0"" alt=""CLICK HERE TO VIEW DETAIL OF MOBI"" title=""CLICK HERE TO VIEW DETAIL OF MOBI"">"}
            Dim array() As String = hdd_ebook_format.Text.Split(",")
            Dim i As Integer = 0
            Dim isbn As String = lblisbn.Text
            Dim format_text As String = ""
            For i = 0 To array.Length - 1
                If array(i) <> "" Then
                    format_text &= " <a href=""ebook_detail.aspx?code=" + isbn + "&format=" + array(i) + """>" & format_img(array(i)) & "</a> "
                End If
            Next
            hdd_ebook_format.Text = format_text
            If lbl_title.Text.Length > 50 Then
                lbl_title.Text = lbl_title.Text.Substring(0, 50) + "..."
            End If
            Try
                lblImage.ImageUrl = _Utility.GetImagePath_eBook(lblImage.ImageUrl.ToString().Substring(0, 3) & "/" & lblImage.ImageUrl.ToString().Substring(3, 3) & "/" & lblImage.ImageUrl.ToString().Substring(6, 3) & "/" & lblImage.ImageUrl.ToString() + ".jpg")
                'lblImage.ImageUrl = _Utility.GetImagePath_eBook(lblImage.ImageUrl.ToString())

            Catch ex As Exception

            End Try

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
            strsql &= " select * from dbo.tbm_AB_CustomerReview"
            strsql &= " where isbn_13 = '" + lblisbn.Text.Trim + "'"

            dt_view = uFunction.getDataTable(uCon.conn, strsql)
            If dt_view.Rows.Count > 0 Then
                lblCustomerView.Text = "View : " & dt_view.Rows(0).Item("No_CustomerView").ToString
            Else
                lblCustomerView.Text = "View : 0"
            End If
            imgCustomer_Average.Visible = False


        End If
    End Sub

    Protected Sub lv_ebook6_ItemDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.ListViewItemEventArgs) Handles lv_ebook6.ItemDataBound
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
            Dim lblImage As Image = e.Item.FindControl("Book_Image")
            Dim lbl_price_usd As Label = e.Item.FindControl("lbl_price_usd")
            Dim lbl_title As Label = e.Item.FindControl("Label2")

            Dim hdd_ebook_format As Label = e.Item.FindControl("hdd_ebook_format")
            Dim format_name() As String = {"GUY", "DRM-PDF", "PDF", "DRM-EPUB", "EPUB", "LIT", "MP3", "PDB", "MOBI"}
            Dim format_img() As String = {"GUY", "<img src=""images/ebook/epdf.gif"" border=""0"" alt=""CLICK HERE TO VIEW DETAIL OF DRM-PDF"" title=""CLICK HERE TO VIEW DETAIL OF DRM-PDF"">", "<img src=""images/ebook/pdf.gif"" border=""0"" alt=""CLICK HERE TO VIEW DETAIL OF PDF"" title=""CLICK HERE TO VIEW DETAIL OF PDF"">", "<img src=""images/ebook/eepub.gif"" border=""0"" alt=""CLICK HERE TO VIEW DETAIL OF DRM-EPUB"" title=""CLICK HERE TO VIEW DETAIL OF DRM-EPUB"">", "<img src=""images/ebook/epub.gif"" border=""0"" alt=""CLICK HERE TO VIEW DETAIL OF EPUB"" title=""CLICK HERE TO VIEW DETAIL OF EPUB"">", "<img src=""images/ebook/lit.gif"" border=""0"" alt=""CLICK HERE TO VIEW DETAIL OF LIT"" title=""CLICK HERE TO VIEW DETAIL OF LIT"">", "<img src=""images/ebook/mp3.gif"" border=""0"" alt=""CLICK HERE TO VIEW DETAIL OF MP3"" title=""CLICK HERE TO VIEW DETAIL OF MP3"">", "<img src=""images/ebook/pdb.gif"" border=""0"" alt=""CLICK HERE TO VIEW DETAIL OF PDB"" title=""CLICK HERE TO VIEW DETAIL OF PDB"">", "<img src=""images/ebook/mobi.gif"" border=""0"" alt=""CLICK HERE TO VIEW DETAIL OF MOBI"" title=""CLICK HERE TO VIEW DETAIL OF MOBI"">"}
            Dim array() As String = hdd_ebook_format.Text.Split(",")
            Dim i As Integer = 0
            Dim isbn As String = lblisbn.Text
            Dim format_text As String = ""
            For i = 0 To array.Length - 1
                If array(i) <> "" Then
                    format_text &= " <a href=""ebook_detail.aspx?code=" + isbn + "&format=" + array(i) + """>" & format_img(array(i)) & "</a> "
                End If
            Next
            hdd_ebook_format.Text = format_text
            If lbl_title.Text.Length > 50 Then
                lbl_title.Text = lbl_title.Text.Substring(0, 50) + "..."
            End If
            Try
                lblImage.ImageUrl = _Utility.GetImagePath_eBook(lblImage.ImageUrl.ToString().Substring(0, 3) & "/" & lblImage.ImageUrl.ToString().Substring(3, 3) & "/" & lblImage.ImageUrl.ToString().Substring(6, 3) & "/" & lblImage.ImageUrl.ToString() + ".jpg")
                'lblImage.ImageUrl = _Utility.GetImagePath_eBook(lblImage.ImageUrl.ToString())

            Catch ex As Exception

            End Try

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
            strsql &= " select * from dbo.tbm_AB_CustomerReview"
            strsql &= " where isbn_13 = '" + lblisbn.Text.Trim + "'"

            dt_view = uFunction.getDataTable(uCon.conn, strsql)
            If dt_view.Rows.Count > 0 Then
                lblCustomerView.Text = "View : " & dt_view.Rows(0).Item("No_CustomerView").ToString
            Else
                lblCustomerView.Text = "View : 0"
            End If
            imgCustomer_Average.Visible = False


        End If
    End Sub
End Class
