Imports Eordering.BusinessLogic
Imports System
Imports System.Data
Imports Eordering.BusinessLogic.PageControl

Partial Class book_detail_internet
    Inherits System.Web.UI.Page
    Private uCon As uConnect
    Dim bd As New Class_book_detail
    Dim wish_list As New Cls_wish_list
    Private _Utility As clsUtility

    Private Sub class_checkBook()
        If Not Me.Request.QueryString("Book_type") Is Nothing Then
            Dim redirect_ As String = Me.Request.QueryString("Book_type").ToString.Trim
            Dim isbn_ As String = Me.Request.QueryString("Title_1").ToString.Trim
            If redirect_ <> "0" And redirect_.ToLower <> "book" Then
                If redirect_ = "ebook" Then
                    Response.Redirect("~/ebook_detail.aspx?code=" + isbn_ + "")
                Else
                    Response.Redirect("~/ebook_detail.aspx?code=" + isbn_ + "&format=" + redirect_ + "")
                End If
            End If
        End If
    End Sub

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim strPaht_facebook As String = ""
        Dim strPaht_Twitter As String = ""
        Me.Title = ConfigurationManager.AppSettings("SiteTitle").ToString & "Book Detail ::"
        class_checkBook()
        'Try
        Session("CachePage") = Nothing
        If Not Me.IsPostBack Then
            If Me.Request.QueryString("Title_1") Is Nothing Then
                Me.Panel5.Visible = True
            Else
                If Left(Request.QueryString("Title_1"), 3) = "MAG" Then
                    Response.Redirect("Magazine_Detail_Internet.aspx?Title_1=" + Request.QueryString("Title_1") + "")
                End If
                Me.Panel5.Visible = False

                Session("keyword") = Me.Request.QueryString("Title_1").ToString.Trim
                bd.keyword_1 = Me.Request.QueryString("Title_1").ToString.Trim
                Me.txt_qty.Attributes.Add("Onkeypress", "num_only()")
                Me.txt_qty.Attributes.Add("Onmousedown", "return noCopyMouse(event);")
                Me.txt_qty.Attributes.Add("Onkeydown", "return noCopyKey(event);")
                Me.txt_qty.Text = "1"
                Me.binddata()

                strPaht_facebook = "http://www.facebook.com/share.php?u=https://www.asiabooks.com/browse/BookInfo_New.asp?ProID=" & Me.Request.QueryString("Title_1").ToString.Trim
                strPaht_Twitter = "http://twitter.com/home?status=https://www.asiabooks.com/browse/BookInfo_New.asp?ProID=" & Me.Request.QueryString("Title_1").ToString.Trim

                img_facebook.Attributes.Add("OnClick", "window.open('" & strPaht_facebook & "','',''); return false;")
                imgtweet.Attributes.Add("OnClick", "window.open('" & strPaht_Twitter & "','',''); return false;")
            End If
        End If
        Me.Title = ConfigurationManager.AppSettings("SiteTitle").ToString & "Book datail ::" + lbltitle.Text + " " + lblisbn.Text.Trim + " " + lnkAuthor_Detail.Text + ""
        'Catch ex As Exception
        'uScript.Alert(Me.Page, Me.GetType, ex.Message.ToString)
        'Finally
        strPaht_facebook = Nothing
        strPaht_Twitter = Nothing
        'End Try
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
            strsql &= " '" + txtDetail.Text.ToString.Replace("'", "'+Char(39)+'") + "',"
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
            strsql &= " select * from dbo.tbm_AB_CustomerReview"
            strsql &= " where isbn_13 = '" + lblisbn.Text.Trim + "'"

            dt_view = uFunction.getDataTable(uCon.conn, strsql)
            If dt_view.Rows.Count > 0 Then
                lblview.Text = dt_view.Rows(0).Item("No_CustomerView").ToString
            Else
                lblview.Text = "0"
            End If
            imgCustomer_Average.Visible = False

            'strsql = ""
            'strsql &= " select case No_CustomerDiscussion when '0' then '0' else ((No_CusReview1*1)+(No_CusReview2*2)+(No_CusReview3*3)+"
            'strsql &= " (No_CusReview4*4)+(No_CusReview5*5))/No_CustomerDiscussion end as total,*"
            'strsql &= " from dbo.tbm_AB_CustomerReview"
            'strsql &= " where isbn_13 = '" + lblisbn.Text.Trim + "'"

            'dt_view = uFunction.getDataTable(uCon.conn, strsql)
            'If dt_view.Rows.Count > 0 Then
            '    Dim strCustomer_Average As String = ""
            '    strCustomer_Average = dt_view.Rows(0).Item("total").ToString
            '    lblview.Text = dt_view.Rows(0).Item("No_CustomerView").ToString

            '    Select Case strCustomer_Average
            '        Case "1"
            '            imgCustomer_Average.ImageUrl = "~/images/Template/stars1.gif"
            '        Case "2"
            '            imgCustomer_Average.ImageUrl = "~/images/Template/stars2.gif"
            '        Case "3"
            '            imgCustomer_Average.ImageUrl = "~/images/Template/stars3.gif"
            '        Case "4"
            '            imgCustomer_Average.ImageUrl = "~/images/Template/stars4.gif"
            '        Case "5"
            '            imgCustomer_Average.ImageUrl = "~/images/Template/stars5.gif"
            '        Case Else
            '            imgCustomer_Average.ImageUrl = "~/images/Template/stars0.gif"
            '    End Select
            'Else
            '    dt_view.Clear()
            '    strsql = ""
            '    strsql &= " select (CASE WHEN right(isbn_13,2)='00' "
            '    strsql &= " THEN 99*3/99 "
            '    strsql &= " ELSE right(isbn_13,2)*3/right(isbn_13,2) END) AS total,"
            '    strsql &= " (CASE WHEN right(isbn_13,2)='00' "
            '    strsql &= " THEN '99' "
            '    strsql &= " ELSE right(isbn_13,2) END) AS No_CustomerView"
            '    strsql &= " from tbt_jobber_book_search"
            '    strsql &= " where isbn_13 = '" + lblisbn.Text.Trim + "'"
            '    dt_view = uFunction.getDataTable(uCon.conn, strsql)
            '    If dt_view.Rows.Count > 0 Then
            '        Dim strCustomer_Average As String = ""
            '        strCustomer_Average = dt_view.Rows(0).Item("total").ToString
            '        lblview.Text = dt_view.Rows(0).Item("No_CustomerView").ToString

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

            'End If


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

            dt_view = uFunction.getDataTable(uCon.conn, "select * from tbm_AB_CustomerReview where isbn_13 = '" + lblisbn.Text.Trim + "'")

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

    Private Sub binddata()
        Dim dt As New DataTable
        Dim price As Double = 0
        Dim price_usd As Double = 0
        Dim imag As String = ""
        Dim strbook_title As String = ""
        Dim client_nation As String = ""
        Dim territory As String = ""

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

        bd.country = client_nation
        bd.territory = territory
        bd.sales_channel = "INTERNET"
        dt = bd._dt_book_detail_new
        Panel_Available.Visible = False
        If dt.Rows.Count > 0 Then
            Panel5.Visible = False
            Panel4.Visible = True
            'strbook_title = dt.Rows(0).Item("book_title").ToString.ToUpper
            'If Right(strbook_title, 5) = ", THE" Then
            '    If Left(strbook_title, 3) = "THE" Then
            '        lbltitle.Text = dt.Rows(0).Item("book_title").ToString
            '    Else
            '        lbltitle.Text = "THE " + " " + strbook_title.Replace(", THE", "")
            '    End If
            'ElseIf Right(strbook_title, 4) = ", AN" Then
            '    If Left(strbook_title, 2) = "AN" Then
            '        lbltitle.Text = dt.Rows(0).Item("book_title").ToString
            '    Else
            '        lbltitle.Text = "AN " + " " + strbook_title.Replace(", AN", "")
            '    End If
            'ElseIf Right(strbook_title, 3) = ", A" Then
            '    If Left(strbook_title, 1) = "A" Then
            '        lbltitle.Text = dt.Rows(0).Item("book_title").ToString
            '    Else
            '        lbltitle.Text = "A " + " " + strbook_title.Replace(", A", "")
            '    End If
            'Else
            '    lbltitle.Text = dt.Rows(0).Item("book_title").ToString
            'End If
            lnkAuthor_Head.Text = dt.Rows(0).Item("Author").ToString
            lbltitle.Text = dt.Rows(0).Item("book_title").ToString
            lblisbn.Text = dt.Rows(0).Item("ISBN_13").ToString.Trim
            lnkAuthor_Detail.Text = dt.Rows(0).Item("Author").ToString
            If lnkAuthor_Detail.Text = "" Or lnkAuthor_Detail.Text = "-" Or lnkAuthor_Detail.Text = "NONE" Then
                lnkAuthor_Detail.Enabled = False
            End If
            If lnkAuthor_Head.Text = "" Or lnkAuthor_Head.Text = "-" Or lnkAuthor_Head.Text = "NONE" Then
                lnkAuthor_Head.Enabled = False
            End If
            lblpublisher.Text = dt.Rows(0).Item("publisher_Name").ToString
            lblcategory.Text = dt.Rows(0).Item("Subject_Name").ToString
            lbllanguage.Text = dt.Rows(0).Item("Language").ToString
            lblsize.Text = dt.Rows(0).Item("Size").ToString
            lblweight.Text = dt.Rows(0).Item("Weight").ToString
            lblbinding.Text = dt.Rows(0).Item("binding_description").ToString
            lblnumber_of_page.Text = dt.Rows(0).Item("Page_qty").ToString
            lblpublication_date.Text = dt.Rows(0).Item("Publication_Date").ToString
            lblcopright.Text = dt.Rows(0).Item("Copyrights_Date").ToString
            lblavailable_status.Text = dt.Rows(0).Item("Stock_status").ToString
            lblsynopsis.Text = dt.Rows(0).Item("Synopsis").ToString
            lblsource.Text = dt.Rows(0).Item("source").ToString
            lblBook_Image.Text = dt.Rows(0).Item("image").ToString
            hidden_ebook_id.Value = dt.Rows(0).Item("other_format").ToString
            If hidden_ebook_id.Value = "" Or hidden_ebook_id.Value = "not available" Then
                pan_linkeBook.Visible = False
            Else
                btn_ebook.PostBackUrl = "~/ebook_detail.aspx?code=" + hidden_ebook_id.Value.Trim + ""
                pan_linkeBook.Visible = True
            End If
            _Utility = New clsUtility
            Imag_Book.ImageUrl = _Utility.GetImagePath(lblBook_Image.Text.Trim)

            If lblsource.Text = "Asiabooks" Then
                If lblavailable_status.Text = "Available in Asia Books/Bookazine" Then
                    lblavailable_status.Visible = False
                    Panel_Available.Visible = True
                    Get_StockShop("AB")
                    Get_StockShop("BZ")
                End If

                lbllist_price.Text = CInt(dt.Rows(0).Item("selling_price")).ToString
                lblyour_price.Text = CInt(dt.Rows(0).Item("selling_price_eCom")).ToString
                lblsave_price.Text = "(Save " + CInt(dt.Rows(0).Item("eCom_Discount")).ToString + "%)"
                price = CDbl(lblyour_price.Text)
                price_usd = bd.callUsd(price) ' convert bath to USD
                lbl_price_usd.Text = "US$ " + Convert.ToDouble(price_usd).ToString("#,##0.00")

                If lbllist_price.Text = lblyour_price.Text Then
                    Label4.Visible = False
                    lbllist_price.Visible = False
                    lblsave_price.Visible = False
                    lblyour_price.Visible = True
                    Label8.Visible = True
                Else
                    lbllist_price.Font.Strikeout = True
                End If

                Panel3.Visible = True
                binddata_Relate_Cat()
                lblItem_Dis_Group.Text = dt.Rows(0).Item("Item Disc_ Group").ToString()
            Else
                lblyour_price.Text = CInt(dt.Rows(0).Item("selling_price")).ToString
                price = CDbl(lblyour_price.Text)
                price_usd = bd.callUsd(price) ' convert bath to USD
                lbl_price_usd.Text = "US$ " + Convert.ToDouble(price_usd).ToString("#,##0.00")
                Label4.Visible = False
                lbllist_price.Visible = False
                lblsave_price.Visible = False

                Panel3.Visible = False
            End If

            binddata_Relate_Author()
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
    Private Sub Get_StockShop(ByVal strGroup_Code As String)
        Dim dt_stock As New DataTable
        Dim strSql As String = ""
        strSql = ""
        strSql &= " select a.isbn_13,qty,on_order_qty,b.Org_AB_Name,b.Group_Code,a.Org_AB_Code,b.field2 as Tel  "
        strSql &= " from tbt_jobber_stockab a inner join tbm_syst_organizeab b "
        strSql &= " on a.Org_AB_code = b.Org_AB_code"
        strSql &= " and Org_AB_Name not in ('HO-Internet','HO-Good')"
        strSql &= " and b.status <> 'N' and a.isbn_13 = '" + lblisbn.Text.Trim + "' and left(b.Org_AB_Code,2) = '" + strGroup_Code + "' and a.qty > 0 "

        uCon = New uConnect
        dt_stock = uFunction.getDataTable(uCon.conn, strSql)
        If dt_stock.Rows.Count > 0 Then
            gvStock.DataSource = dt_stock
            gvStock.DataBind()
            If strGroup_Code = "AB" Then
                lnkStock_Ab.Visible = True
                lblAsiabooks.Visible = False
            End If
            If strGroup_Code = "BZ" Then
                lnkStock_BZ.Visible = True
                lblBookazine.Visible = False
            End If
        Else
            If strGroup_Code = "AB" Then
                lnkStock_Ab.Visible = False
                lblAsiabooks.Visible = True
            End If
            If strGroup_Code = "BZ" Then
                lnkStock_BZ.Visible = False
                lblBookazine.Visible = True
            End If
        End If

    End Sub
    Private Sub binddata_Relate_Cat()
        Dim dt_Relate As New DataTable
        Dim strSql As String = ""

        strSql &= " 	select top(3) a.isbn_13,a.image,  "
        strSql &= " 	(CASE WHEN LEN(a.book_title) >= 30 "
        strSql &= " 	THEN Left(Isnull(a.book_title,''), 30)+'...' "
        strSql &= " 	ELSE Isnull(a.book_title,'') END) AS book_title,a.book_title as book_title_full "
        strSql &= " 	,(CASE WHEN LEN(a.author) >= 20 "
        strSql &= " 	THEN Left(Isnull(a.author,''),20)+'...' "
        strSql &= " 	ELSE Isnull(a.author,'') END) AS author,a.author as author_full "
        strSql &= " 	,convert(numeric(18,2),a.selling_price) as selling_price "
        strSql &= " 	,convert(numeric(18,2),a.selling_price_eCom) as your_price  "
        strSql &= " 	,qty,convert(numeric(18,0),a.eCom_Discount) as save_price "
        strSql &= " 	from tbt_jobber_book_search as a "
        strSql &= " 	inner join tbt_jobber_stockab as b "
        strSql &= " 	on a.isbn_13 = b.isbn_13"
        strSql &= " 	where Subject_Name = '" + lblcategory.Text + "' and a.source = 'Asiabooks'"
        strSql &= " 	and b.qty >= 5 and b.org_ab_code = 'HO-Internet' and a.isbn_13 <> '" + lblisbn.Text.Trim + "'"
        strSql &= " 	order by b.qty desc,Maintenance_Date desc"

        uCon = New uConnect
        dt_Relate = uFunction.getDataTable(uCon.conn, strSql)

        If dt_Relate.Rows.Count > 0 Then
            Panel3.Visible = True
            lvBooks_Cat.DataSource = dt_Relate
            lvBooks_Cat.DataBind()

        Else
            Panel3.Visible = False
        End If


    End Sub
    Private Sub binddata_Relate_Author()
        Dim dt_Relate As New DataTable
        Dim SqlStr As String = ""

        SqlStr = SqlStr + "  select top(3) "
        SqlStr = SqlStr + "  case source when 'Asiabooks' then "
        SqlStr = SqlStr + "  ROUND(convert(numeric(13,2),tbt_jobber_book_search.selling),0) "
        SqlStr = SqlStr + "  else "
        SqlStr = SqlStr + "  ROUND(convert(numeric(18,2),(tbt_jobber_book_search.selling*(isnull(CR.exchange_rate,0)+ "
        SqlStr = SqlStr + "  ((tbm_syst_company.Buffer_Rate/100) * isnull(CR.exchange_rate,0))) "
        SqlStr = SqlStr + "  +tbt_jobber_book_search.selling*(isnull(CR.exchange_rate,0)+((tbm_syst_company.Buffer_Rate/100) * "
        SqlStr = SqlStr + "  isnull(CR.exchange_rate,0))) * Mark_UP/100)),0) end as Selling_price ,"

        SqlStr = SqlStr + "  case source when 'Asiabooks' then "
        SqlStr = SqlStr + "  ROUND(convert(numeric(13,2),tbt_jobber_book_search.selling_price_eCom),0) "
        SqlStr = SqlStr + "  else "
        SqlStr = SqlStr + "  ROUND(convert(numeric(18,2),(tbt_jobber_book_search.selling*(isnull(CR.exchange_rate,0)+ "
        SqlStr = SqlStr + "  ((tbm_syst_company.Buffer_Rate/100) * isnull(CR.exchange_rate,0))) "
        SqlStr = SqlStr + "  +tbt_jobber_book_search.selling*(isnull(CR.exchange_rate,0)+((tbm_syst_company.Buffer_Rate/100) * "
        SqlStr = SqlStr + "  isnull(CR.exchange_rate,0))) * Mark_UP/100)),0) end as Selling_price_eComN "


        SqlStr = SqlStr + " , *  "
        SqlStr = SqlStr + "  from "
        SqlStr = SqlStr + "  ( "
        SqlStr = SqlStr + "  select tbt_jobber_book_search.image, "
        SqlStr = SqlStr + "  (CASE WHEN LEN(tbt_jobber_book_search.Book_Title) >= 30 "
        SqlStr = SqlStr + "  THEN Left(Isnull(tbt_jobber_book_search.Book_Title,''), 30)+'...' "
        SqlStr = SqlStr + "  ELSE Isnull(tbt_jobber_book_search.Book_Title,'') END) AS book_title,tbt_jobber_book_search.Book_Title as book_title_full"
        SqlStr = SqlStr + "  ,(CASE WHEN LEN(isnull(tbt_jobber_book_search.Author,'NONE')) >= 20 "
        SqlStr = SqlStr + "  THEN Left(Isnull(tbt_jobber_book_search.Author,'NONE'),20)+'...' "
        SqlStr = SqlStr + "  ELSE Isnull(tbt_jobber_book_search.Author,'') END) AS author,tbt_jobber_book_search.Author as author_full"
        SqlStr = SqlStr + "  ,tbt_jobber_book_search.ISBN_13 "
        SqlStr = SqlStr + "  ,case when tbt_jobber_book_search.Publisher_name='' then '-' "
        SqlStr = SqlStr + "  else tbt_jobber_book_search.Publisher_name end as Publisher_name,tbt_jobber_book_search.[Size] "
        SqlStr = SqlStr + "  ,convert(numeric(13,2),tbt_jobber_book_search.Weight) as Weight "
        SqlStr = SqlStr + "  ,tbt_jobber_book_search.binding_description "
        SqlStr = SqlStr + "  ,case when convert(varchar(10),tbt_jobber_book_search.Page_qty)='0' THEN '-' "
        SqlStr = SqlStr + "  else convert(varchar(10),tbt_jobber_book_search.Page_qty)end as Page_qty "
        SqlStr = SqlStr + "  ,case when tbt_jobber_book_search.Subject_Name='' then '-' "
        SqlStr = SqlStr + "  else tbt_jobber_book_search.Subject_Name end as Subject_Name "
        SqlStr = SqlStr + "  ,case when tbt_jobber_book_search.Stock_status='' then '-' "
        SqlStr = SqlStr + "  else tbt_jobber_book_search.Stock_status end as stock_status "
        SqlStr = SqlStr + "  ,case when right(tbt_jobber_book_search.Publication_Date,4)='0000' then '-' "
        SqlStr = SqlStr + "  else right(tbt_jobber_book_search.Publication_Date,4) end as Publication_Date "
        SqlStr = SqlStr + "  ,source,Selling_Price as selling"
        SqlStr = SqlStr + "  , selling_price_eCom ,convert(numeric(18,0),eCom_Discount) as save_price,price_save"
        SqlStr = SqlStr + "  ,discount,tbt_jobber_book_search.field1 "
        SqlStr = SqlStr + "  from tbt_jobber_book_search with (nolock)"
        SqlStr = SqlStr + "  where tbt_jobber_book_search.field3 ='' and tbt_jobber_book_search.Language_Name = 'English' and isnull(tbt_jobber_book_search.Author,'') not in ('','-') "
        SqlStr = SqlStr + "  and Selling_Price>0 and tbt_jobber_book_search.Author = '" + lnkAuthor_Detail.Text.Replace("'", "'+char(39)+'") + "' and tbt_jobber_book_search.isbn_13 <> '" + lblisbn.Text.Trim + "'"
        SqlStr = SqlStr + "  ) as tbt_jobber_book_search "
        SqlStr = SqlStr + "  left join (select mark_up,From_Pub_Discount,to_Pub_Discount,sales_channel_code "
        SqlStr = SqlStr + "  from tbm_syst_saleschannel with (nolock))as tbm_syst_saleschannel "
        SqlStr = SqlStr + "  on tbt_jobber_book_search.discount>=tbm_syst_saleschannel.From_Pub_Discount "
        SqlStr = SqlStr + "  and tbt_jobber_book_search.discount<=tbm_syst_saleschannel.to_Pub_Discount "
        SqlStr = SqlStr + "  and tbm_syst_saleschannel.sales_channel_code='INTERNET' "
        SqlStr = SqlStr + "  left join (select a.Org_indent_code,b.currency_code,b.exchange_rate "
        SqlStr = SqlStr + "  from tbm_syst_organizeindent A with (nolock),tbm_syst_currency B with (nolock) "
        SqlStr = SqlStr + "  where a.currency_code = b.currency_code) CR On tbt_jobber_book_search.source =CR.Org_indent_code "
        SqlStr = SqlStr + "  ,(select Buffer_Rate from tbm_syst_company with (nolock)) as tbm_syst_company "
        SqlStr = SqlStr + "  order by stock_status  "

        uCon = New uConnect
        dt_Relate = uFunction.getDataTable(uCon.conn, SqlStr)

        If dt_Relate.Rows.Count > 0 Then
            Me.Panel2.Visible = True
            Me.lvBooks_Author.DataSource = dt_Relate
            Me.lvBooks_Author.DataBind()

        Else
            Me.Panel2.Visible = False
        End If

    End Sub

    Private Sub add_to_cart()
        If txt_qty.Text = "" Or txt_qty.Text = "0" Then
            txt_qty.Text = "1"
        Else
            Dim quantity As Integer = CInt(txt_qty.Text)
            txt_qty.Text = quantity.ToString
        End If

        If lblweight.Text = 0 Then
            Response.Redirect("BooksNot_Found.aspx?Meassge=Data not weight")
            'lblCheck_Meassge.Text = "There are few quantities of the ISBN " + lblisbn.Text + " in stock, so please contact Customer Service or Sales Staffs at 02-7159000 EXT: 8103, 8102"
            'mdlPopUp_CheckMeassge.Show()
            'ScriptManager.RegisterClientScriptBlock(Me.Page, Me.GetType, "Alert", "alert(' There are few quantities of the ISBN " + lblisbn.Text + " in stock, so please contact Customer Service or Sales Staffs at 02-7159000 EXT: 8103, 8102 ');", True)
            'Exit Sub
        Else
            If lblsource.Text = "Asiabooks" Then
                bd.Status = "AB"
                Dim dt_xx As DataTable

                Dim sqlDB As SqlDb = New SqlDb
                Dim dt_stock As New DataTable
                Dim dt_stockJobber As New DataTable
                Dim SqlStr As String = ""

                SqlStr = SqlStr + " select a.on_hand_qty ,a.on_order_qty from dbo.tbt_jobber_stockindent a,tbm_syst_company b "
                SqlStr = SqlStr + " where a.isbn_13 = '" + lblisbn.Text.Trim + "'"
                SqlStr = SqlStr + " and a.on_hand_qty + a.on_order_qty >  b.Minimum_Stock_Jobber "
                dt_stockJobber.Clear()
                dt_stockJobber = sqlDB.GetDataTable(SqlStr)
                If dt_stockJobber.Rows.Count > 0 Then
                    bd.Jobber_Status = "INDENT"
                Else
                    bd.Jobber_Status = "AB"

                    If Session("In_Branch") Is Nothing Then
                        SqlStr = ""
                        SqlStr = SqlStr + " select a.isbn_13,a.org_ab_code,a.qty,(a.qty-b.Minimum_Stock_Internet)-" + txt_qty.Text + " as total_stock "
                        SqlStr = SqlStr + "	from tbt_jobber_stockab a,dbo.tbm_syst_company b "
                        SqlStr = SqlStr + "	where a.isbn_13 = '" + lblisbn.Text.Trim + "' and org_ab_code = 'HO-Internet'  "
                        SqlStr = SqlStr + "	and a.qty -" + txt_qty.Text + " >=  b.Minimum_Stock_Internet "
                        dt_stock.Clear()
                        dt_stock = sqlDB.GetDataTable(SqlStr)
                        If dt_stock.Rows.Count > 0 Then
                        Else
                            Response.Redirect("BooksNot_Found.aspx?Meassge=Stock is not available")
                            'lblCheck_Meassge.Text = "There are a few quantity of the ISBN : " + lblisbn.Text + " in stock, so please contact Customer Service at 02-7159000 \n EXT: 8103, 8102 or Sales Staffs to confirm availability before processing order"
                            'mdlPopUp_CheckMeassge.Show()
                            'ScriptManager.RegisterClientScriptBlock(Me.Page, Me.GetType, "Alert", "alert('There are a few quantity of the ISBN : " + lblisbn.Text + " in stock, so please contact Customer Service at 02-7159000 \n EXT: 8103, 8102 or Sales Staffs to confirm availability before processing order');", True)
                            'Exit Subt Sub
                        End If
                    Else
                        Dim aa As String = ""
                        Dim yy As String = ""
                        Dim qty As String = ""
                        dt_xx = Session("In_Branch")
                        For ixx As Integer = 0 To dt_xx.Rows.Count - 1
                            If dt_xx.Rows(ixx).Item("isbn_13").ToString = lblisbn.Text.Trim Then
                                aa = "1"
                                qty = dt_xx.Rows(ixx).Item("Quantity").ToString
                            End If
                        Next
                        If aa = "1" Then
                            SqlStr = ""
                            SqlStr = SqlStr + " select a.isbn_13,a.org_ab_code,a.qty,(a.qty-b.Minimum_Stock_Internet)-" + qty + " as total_stock "
                            SqlStr = SqlStr + "	from tbt_jobber_stockab a,dbo.tbm_syst_company b "
                            SqlStr = SqlStr + "	where a.isbn_13 = '" + lblisbn.Text.Trim + "' and org_ab_code = 'HO-Internet'  "
                            SqlStr = SqlStr + "	and (a.qty-b.Minimum_Stock_Internet)-" + qty + " >=  b.Minimum_Stock_Internet "
                            dt_stock.Clear()
                            dt_stock = sqlDB.GetDataTable(SqlStr)
                            If dt_stock.Rows.Count > 0 Then
                            Else
                                Response.Redirect("BooksNot_Found.aspx?Meassge=Stock is not available")
                                'lblCheck_Meassge.Text = "There are a few quantity of the ISBN : " + lblisbn.Text + " in stock, so please contact Customer Service at 02-7159000 \n EXT: 8103, 8102 or Sales Staffs to confirm availability before processing order"
                                'mdlPopUp_CheckMeassge.Show()
                                'ScriptManager.RegisterClientScriptBlock(Me.Page, Me.GetType, "Alert", "alert('There are a few quantity of the ISBN : " + lblisbn.Text + " in stock, so please contact Customer Service at 02-7159000 \n EXT: 8103, 8102 or Sales Staffs to confirm availability before processing order');", True)
                                'Exit Sub
                            End If
                        Else

                            'SqlStr = SqlStr + " select a.isbn_13,a.org_ab_code,a.qty,(a.qty-b.Minimum_Stock_Internet)-" + txt_qty.Text + " as total_stock "
                            'SqlStr = SqlStr + "	from tbt_jobber_stockab a,dbo.tbm_syst_company b "
                            'SqlStr = SqlStr + "	where a.isbn_13 = '" + lblisbn.Text + "' and org_ab_code = 'HO-Internet'  "
                            'SqlStr = SqlStr + "	and (a.qty-b.Minimum_Stock_Internet)-" + txt_qty.Text + " >=  b.Minimum_Stock_Internet "
                            SqlStr = ""
                            SqlStr = SqlStr + " select a.isbn_13,a.org_ab_code,a.qty,(a.qty-b.Minimum_Stock_Internet)-" + txt_qty.Text + " as total_stock "
                            SqlStr = SqlStr + "	from tbt_jobber_stockab a,dbo.tbm_syst_company b "
                            SqlStr = SqlStr + "	where a.isbn_13 = '" + lblisbn.Text.Trim + "' and org_ab_code = 'HO-Internet'  "
                            SqlStr = SqlStr + "	and a.qty -" + txt_qty.Text + " >=  b.Minimum_Stock_Internet "
                            dt_stock.Clear()
                            dt_stock = sqlDB.GetDataTable(SqlStr)
                            If dt_stock.Rows.Count > 0 Then
                            Else
                                Response.Redirect("BooksNot_Found.aspx?Meassge=Stock is not available")
                                'lblCheck_Meassge.Text = "There are a few quantity of the ISBN : " + lblisbn.Text + " in stock, so please contact Customer Service at 02-7159000 \n EXT: 8103, 8102 or Sales Staffs to confirm availability before processing order"
                                'mdlPopUp_CheckMeassge.Show()
                                'ScriptManager.RegisterClientScriptBlock(Me.Page, Me.GetType, "Alert", "alert('There are a few quantity of the ISBN : " + lblisbn.Text + " in stock, so please contact Customer Service at 02-7159000 \n EXT: 8103, 8102 or Sales Staffs to confirm availability before processing order');", True)
                                'Exit Sub
                            End If
                        End If
                    End If

                End If

                SqlStr = ""
                SqlStr = SqlStr + " select a.isbn_13,a.org_ab_code,a.qty,(a.qty-b.Minimum_Stock_Internet)-" + txt_qty.Text + " as total_stock "
                SqlStr = SqlStr + "	from tbt_jobber_stockab a,dbo.tbm_syst_company b "
                SqlStr = SqlStr + "	where a.isbn_13 = '" + lblisbn.Text.Trim + "' and org_ab_code = 'HO-Internet'  "
                'and (a.qty-b.Minimum_Stock_Internet)-" + txt_qty.Text + " >=  b.Minimum_Stock_Internet "

                dt_stock.Clear()
                dt_stock = sqlDB.GetDataTable(SqlStr)
                If dt_stock.Rows.Count > 0 Then
                    If Session("In_Branch") Is Nothing Then
                        bd.Jobber_Status = "AB"
                        bd.Status = "AB"
                    Else
                        Dim aa As String = ""
                        Dim yy As String = ""
                        dt_xx = Session("In_Branch")
                        For ixx As Integer = 0 To dt_xx.Rows.Count - 1
                            If dt_xx.Rows(ixx).Item("isbn_13").ToString = lblisbn.Text.Trim And dt_xx.Rows(ixx).Item("Quantity").ToString = dt_stock.Rows(0).Item("qty").ToString Then
                                aa = "1"
                            End If
                        Next
                        If aa = "1" Then
                            bd.Status = "SPECIAL"

                        Else
                            bd.Jobber_Status = "AB"
                            bd.Status = "AB"
                        End If
                    End If

                End If

            Else
                bd.Jobber_Status = "AB"
                bd.Status = "INDENT"
            End If


            If Session("sales_channel") Is Nothing Then
                'bd.sales_channel = "ab"
                'Me.Response.Redirect("default.aspx")
                bd.sales_channel = System.Configuration.ConfigurationManager.AppSettings("UserInternet")
            Else
                bd.sales_channel = Session("sales_channel").ToString
            End If

            bd.keyword_1 = Me.Request.QueryString("Title_1").ToString.Trim

            If Not (IsNumeric(txt_qty.Text) And txt_qty.Text > 0) Then
                ScriptManager.RegisterClientScriptBlock(Me.Page, Me.GetType, "Alert", "alert('Quantity is not Valid');", True)
                Exit Sub
            Else
                bd.keyword_Qty = CInt(txt_qty.Text)
            End If
            'bd.Status = "1"
            bd.keyword_Branch = "HO-Internet"
            If Session("In_Branch") Is Nothing Then
                ' No such value in session state, take appropriate action.
                bd.dt_Old_book_In_Branch = New DataTable
            Else
                bd.dt_Old_book_In_Branch = Session("In_Branch")
            End If

            If Session("Other_Branch") Is Nothing Then
                ' No such value in session state, take appropriate action.
                bd.dt_Old_book_Other_Branch = New DataTable
            Else
                bd.dt_Old_book_Other_Branch = Session("Other_Branch")
            End If

            If Session("jobber") Is Nothing Then
                ' No such value in session state, take appropriate action.
                bd.dt_Old_book_jobber = New DataTable
            Else
                bd.dt_Old_book_jobber = Session("jobber")
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
            bd.country = client_nation
            bd.territory = territory
            bd.Recalcuate()


            Session("In_Branch") = bd.dt_book_In_Branch
            Session("Other_Branch") = bd.dt_book_Other_Branch
            Session("jobber") = bd.dt_book_jobber
            Session("amount_Branch") = bd.amount_Branch
            Session("amount_Other_Branch") = bd.amount_Other_Branch
            Session("amount_Jobber") = bd.amount_Jobber

            binddata()

            Dim Flag1 As String = ""
            Dim Flag2 As String = ""
            Dim Flag3 As String = ""
            If Not bd.dt_book_In_Branch Is Nothing Then
                If bd.dt_book_In_Branch.Select("ISBN_13='" + bd.keyword_1.Trim + "'").Length = 0 Then
                    Flag1 = "0"
                Else
                    Flag1 = "1"
                End If
            Else
                Flag1 = "0"
            End If
            If Not bd.dt_book_Other_Branch Is Nothing Then
                If bd.dt_book_Other_Branch.Select("ISBN_13='" + bd.keyword_1.Trim + "'").Length = 0 Then
                    Flag2 = "0"
                Else
                    Flag2 = "1"
                End If
            Else
                Flag2 = "0"
            End If
            If Not bd.dt_book_jobber Is Nothing Then
                If bd.dt_book_jobber.Select("ISBN_13='" + bd.keyword_1.Trim + "'").Length = 0 Then
                    Flag3 = "0"
                Else
                    Flag3 = "1"
                End If
            Else
                Flag3 = "0"
            End If

            If Flag1 = "0" And Flag2 = "0" And Flag3 = "0" Then
                Response.Redirect("BooksNot_Found.aspx?Meassge=Stock is not available")
                'lblCheck_Meassge.Text = "There are a few quantity of the ISBN : " + lblisbn.Text + " in stock, so please contact Customer Service at 02-7159000 \n EXT: 8103, 8102 or Sales Staffs to confirm availability before processing order"
                'mdlPopUp_CheckMeassge.Show()
                'ScriptManager.RegisterClientScriptBlock(Me.Page, Me.GetType, "Alert", "alert('There are a few quantity of the ISBN : " + lblisbn.Text + " in stock, so please contact Customer Service at 02-7159000 \n EXT: 8103, 8102 or Sales Staffs to confirm availability before processing order');", True)
                'Exit Subt Sub
            Else

                Dim In_branch_qty As Integer = 0
                Dim Other_branch_qty As Integer = 0
                Dim Jobber_qty As Integer = 0
                Dim total_In_branch_qty As Integer = 0
                Dim total_Other_branch_qty As Integer = 0
                Dim total_Jobber_qty As Integer = 0

                If Not bd.dt_book_In_Branch Is Nothing Then
                    For ix As Integer = 0 To bd.dt_book_In_Branch.Rows.Count - 1
                        In_branch_qty = bd.dt_book_In_Branch.Rows(ix).Item("Quantity")
                        total_In_branch_qty = total_In_branch_qty + In_branch_qty
                    Next
                End If
                If Not bd.dt_book_Other_Branch Is Nothing Then
                    For ix As Integer = 0 To bd.dt_book_Other_Branch.Rows.Count - 1
                        In_branch_qty = bd.dt_book_Other_Branch.Rows(ix).Item("Quantity")
                        total_Other_branch_qty = total_Other_branch_qty + In_branch_qty
                    Next
                    'Other_branch_qty = bd.dt_book_Other_Branch.Rows(0).Item("Quantity")
                End If

                If Not bd.dt_book_jobber Is Nothing Then
                    For ix As Integer = 0 To bd.dt_book_jobber.Rows.Count - 1
                        Jobber_qty = bd.dt_book_jobber.Rows(ix).Item("Quantity")
                        total_Jobber_qty = total_Jobber_qty + Jobber_qty
                    Next
                    'Jobber_qty = bd.dt_book_jobber.Rows(0).Item("Quantity")
                End If

                'If bd.input_Quantity > In_branch_qty + Other_branch_qty + Jobber_qty Then
                If bd.input_Quantity > total_In_branch_qty + total_Other_branch_qty + total_Jobber_qty Then

                    If Not bd.dt_book_In_Branch Is Nothing Then
                        If bd.dt_book_In_Branch.Rows.Count <> 0 Then
                            For i = 0 To bd.dt_book_In_Branch.Rows.Count - 1
                                If bd.dt_book_In_Branch.Rows(i).Item("ISBN_13").ToString.Trim = bd.keyword_1.Trim Then
                                    bd.dt_book_In_Branch.Rows(i).Delete()
                                End If
                            Next
                        End If
                    End If
                    If Not bd.dt_book_Other_Branch Is Nothing Then
                        If bd.dt_book_Other_Branch.Rows.Count <> 0 Then
                            For i = 0 To bd.dt_book_Other_Branch.Rows.Count - 1
                                If bd.dt_book_Other_Branch.Rows(i).Item("ISBN_13").ToString.Trim = bd.keyword_1.Trim Then
                                    bd.dt_book_Other_Branch.Rows(i).Delete()
                                End If
                            Next
                        End If
                    End If
                    If Not bd.dt_book_jobber Is Nothing Then
                        If bd.dt_book_jobber.Rows.Count <> 0 Then
                            For i = 0 To bd.dt_book_jobber.Rows.Count - 1
                                If bd.dt_book_jobber.Rows(i).Item("ISBN_13").ToString.Trim = bd.keyword_1.Trim Then
                                    bd.dt_book_jobber.Rows(i).Delete()
                                End If
                            Next
                        End If
                    End If
                    Response.Redirect("BooksNot_Found.aspx?Meassge=Stock is not available")
                    'lblCheck_Meassge.Text = "Quantity of ISBN : " + bd.keyword_1 + " is not enough,Please contact staff"
                    'mdlPopUp_CheckMeassge.Show()
                    'ScriptManager.RegisterClientScriptBlock(Me.Page, Me.GetType, "Alert", "alert('Quantity of ISBN : " + bd.keyword_1 + " is not enough,Please contact staff');", True)
                    'Exit Sub
                End If

                If lblavailable_status.Text = "On order with Publisher and will be available when the book is supplied by Publisher" Then
                    lblPopUp.Text = "This book is not yet published. We will reserve the copy for you once it is available. Confirm to proceed the order."

                    mdlPopupCheck_Promotion.Show()
                    Exit Sub
                End If


                If lblItem_Dis_Group.Text <> "" Then
                    If Left(lblItem_Dis_Group.Text.ToString, 5) = "SHOCK" Or Left(lblItem_Dis_Group.Text.ToString, 5) = "BARGA" Then
                        lblPopUp.Text = "Book’s condition is Fair, which is a worn book that has complete text pages, however, binding, jacket (if any), etc., may also be worn. All defects must be noted."
                        lblPopUp2.Text = "Minimum order value must be Bt. 200."
                        mdlPopupCheck_Promotion.Show()
                        Exit Sub
                        'Else
                        '    Response.Redirect("shoppingCart_Internet.aspx")
                    End If
                    'Else
                    '    Response.Redirect("shoppingCart_Internet.aspx")
                End If
            End If
        End If

        Dim alert As String = bd.alert
        If alert = "alert" Then
            ScriptManager.RegisterClientScriptBlock(Me.Page, Me.GetType, "Alert", _
            "alert('You already have item(s) in shopping cart !!'); window.location='shoppingCart_Internet.aspx';", True)
        Else
            Response.Redirect("shoppingCart_Internet.aspx")
        End If

    End Sub
    Protected Sub btnadd_to_cart_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles btnadd_to_cart.Click
        '////// alert quantity//////
        'If txt_qty.Text.Trim = "" Or txt_qty.Text.Trim = "0" Then
        '    ScriptManager.RegisterClientScriptBlock(Me.Page, Me.GetType, "Alert", _
        '    "alert('Please input the new value of quantity '); window.open('ebook_detail.aspx','_parent');", True)
        '    Exit Sub
        'End If
        add_to_cart()
    End Sub
    '//////promptnow////////
    Protected Sub imgwish_list_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles imgwish_list.Click
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

        check_stock_book()

        If Session("book_wish_lish") Is Nothing Then
            datarow = datatable.NewRow
            datarow("Image") = lblBook_Image.Text.Trim
            datarow("ISBN_13") = lblisbn.Text.Trim
            datarow("Book_Title") = lbltitle.Text.Trim
            datarow("Author") = lnkAuthor_Detail.Text.Trim
            datarow("Source") = lblsource.Text.Trim
            datarow("Selling_Price") = lblyour_price.Text.Trim
            datarow("Status") = lblavailable_status.Text.Trim
            datarow("Item_Dis_Group") = lblItem_Dis_Group.Text.Trim
            Dim synopsis As String = lblsynopsis.Text.Trim
            If synopsis = "-" Then
                datarow("Synopsis") = ""
            Else
                datarow("Synopsis") = synopsis
            End If
            datatable.Rows.Add(datarow)
            Session("book_wish_lish") = datatable
        Else
            datatable = Session("book_wish_lish")
            Dim isbn As String = lblisbn.Text.Trim
            For Each a As DataRow In datatable.Rows
                If a.Item("ISBN_13").ToString = isbn Then
                    alert = "alert"
                End If
            Next
            If alert = "" Then
                datarow = datatable.NewRow
                datarow("Image") = lblBook_Image.Text.Trim
                datarow("ISBN_13") = lblisbn.Text.Trim
                datarow("Book_Title") = lbltitle.Text.Trim
                datarow("Author") = lnkAuthor_Detail.Text.Trim
                datarow("Source") = lblsource.Text.Trim
                datarow("Selling_Price") = lblyour_price.Text.Trim
                datarow("Status") = lblavailable_status.Text.Trim
                datarow("Item_Dis_Group") = lblItem_Dis_Group.Text.Trim
                Dim synopsis As String = lblsynopsis.Text.Trim
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

    Protected Sub img_add_to_cart_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles img_add_to_cart.Click
        Response.Redirect("shoppingCart_Internet.aspx")
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
            Dim price As Double = 0
            Dim price_usd As Double = 0

            price = 0
            price_usd = 0
            price = CDbl(lblYour_Price.Text)
            price_usd = bd.callUsd(price) ' convert bath to USD
            lblprice_us.Text = price_usd.ToString

            If lblList_Price_D.Text = lblYour_Price.Text Then
                lblList_Price_H.Visible = False
                lblList_Price_D.Visible = False
                lblsave_price_L.Visible = False
                lblsave_price_C.Visible = False
                lblsave_price_R.Visible = False
            Else
                lblList_Price_D.Font.Strikeout = True
            End If
            Dim urlBook As String = ""
            _Utility = New clsUtility
            urlBook = _Utility.GetImagePath(lblimage_book.Text)
            imag_book_cat.ImageUrl = urlBook

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
            'strsql &= " where isbn_13 = '" + lblisbn.Text.Trim + "'"

            'dt_view = uFunction.getDataTable(uCon.conn, strsql)
            'If dt_view.Rows.Count > 0 Then
            '    Dim strCustomer_Average As String = ""
            '    strCustomer_Average = dt_view.Rows(0).Item("total").ToString
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
            '        strsql &= " from tbt_jobber_book_search"
            '        strsql &= " where isbn_13 = '" + lblisbn.Text.Trim + "'"
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
            '    strsql &= " from tbt_jobber_book_search"
            '    strsql &= " where isbn_13 = '" + lblisbn.Text.Trim + "'"
            '    dt_view = uFunction.getDataTable(uCon.conn, strsql)
            '    If dt_view.Rows.Count > 0 Then
            '        Dim strCustomer_Average As String = ""
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
            '    End If

            'End If
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
            Dim price As Double = 0
            Dim price_usd As Double = 0

            price = 0
            price_usd = 0
            price = CDbl(lblYour_Price.Text)
            price_usd = bd.callUsd(price) ' convert bath to USD
            lblprice_us.Text = price_usd.ToString

            If lblList_Price_D.Text = lblYour_Price.Text Then
                lblList_Price_H.Visible = False
                lblList_Price_D.Visible = False
                lblsave_price_L.Visible = False
                lblsave_price_C.Visible = False
                lblsave_price_R.Visible = False
            Else
                lblList_Price_D.Font.Strikeout = True
            End If
            Dim urlBook As String = ""
            _Utility = New clsUtility
            urlBook = _Utility.GetImagePath(lblimage_book.Text)
            imag_book_cat.ImageUrl = urlBook

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
            'strsql &= " where isbn_13 = '" + lblisbn.Text.Trim + "'"

            'dt_view = uFunction.getDataTable(uCon.conn, strsql)
            'If dt_view.Rows.Count > 0 Then
            '    Dim strCustomer_Average As String = ""
            '    strCustomer_Average = dt_view.Rows(0).Item("total").ToString
            '    lblCustomerView.Text = dt_view.Rows(0).Item("No_CustomerView").ToString

            '    Select Case strCustomer_Average
            '        Case "1"
            '            imgCustomer_Average.ImageUrl = "~/images/Template/stars1.gif"
            '        Case "2"
            '            imgCustomer_Average.ImageUrl = "~/images/Template/stars2.gif"
            '        Case "3"
            '            imgCustomer_Average.ImageUrl = "~/images/Template/stars3.gif"
            '        Case "4"
            '            imgCustomer_Average.ImageUrl = "~/images/Template/stars4.gif"
            '        Case "5"
            '            imgCustomer_Average.ImageUrl = "~/images/Template/stars5.gif"
            '        Case Else
            '            imgCustomer_Average.ImageUrl = "~/images/Template/stars0.gif"
            '    End Select
            'Else
            '    dt_view.Clear()
            '    strsql = ""
            '    strsql &= " select (CASE WHEN right(isbn_13,2)='00' "
            '    strsql &= " THEN 99*3/99 "
            '    strsql &= " ELSE right('" + lblisbn.Text.Trim.Replace(" ", "") + "',2)*3/right('" + lblisbn.Text.Trim.Replace(" ", "") + "',2) END) AS total,"
            '    strsql &= " (CASE WHEN right('" + lblisbn.Text.Trim.Replace(" ", "") + "',2)='00' "
            '    strsql &= " THEN '99' "
            '    strsql &= " ELSE right('" + lblisbn.Text.Trim.Replace(" ", "") + "',2) END) AS No_CustomerView"
            '    strsql &= " from tbt_jobber_book_search"
            '    strsql &= " where isbn_13 = '" + lblisbn.Text.Trim + "'"
            '    dt_view = uFunction.getDataTable(uCon.conn, strsql)
            '    If dt_view.Rows.Count > 0 Then
            '        Dim strCustomer_Average As String = ""
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
            '    End If
            'End If
        End If
    End Sub

    Protected Sub img_Msg_OK_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles img_Msg_OK.Click
        Response.Redirect("Special_Order_Form.aspx?MeassgeError=" & lblCheck_Meassge.Text)
    End Sub

    Protected Sub img_Msg_Cancel_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles img_Msg_Cancel.Click
        Response.Redirect("Homepage.aspx")
    End Sub

    Protected Sub lnkStock_Ab_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lnkStock_Ab.Click
        lblAvailable_Stock.Text = "Available at Asia Books’ shops :"
        lblGroup_Code.Text = "AB"
        Get_StockShop("AB")
        mdlStock.Show()
    End Sub

    Protected Sub lnkStock_BZ_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lnkStock_BZ.Click
        lblAvailable_Stock.Text = "Available at Bookazine’s Shops :"
        lblGroup_Code.Text = "BZ"
        Get_StockShop("BZ")
        mdlStock.Show()
    End Sub

    Protected Sub gvStock_PageIndexChanging(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewPageEventArgs) Handles gvStock.PageIndexChanging
        gvStock.PageIndex = e.NewPageIndex
        Get_StockShop(lblGroup_Code.Text)
    End Sub

    Protected Sub lnkAuthor_Head_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lnkAuthor_Head.Click
        Response.Redirect("Book_Search_Author.aspx?Author=" + lnkAuthor_Head.Text)
    End Sub

    Protected Sub lnkAuhot_Detail_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lnkAuthor_Detail.Click
        Response.Redirect("Book_Search_Author.aspx?Author=" + lnkAuthor_Detail.Text)
    End Sub

    Private Sub check_stock_book()
        If lblweight.Text = "0" Then
            Response.Redirect("BooksNot_Found.aspx?Meassge=Data not weight")
        Else
            If lblsource.Text = "Asiabooks" Then
                bd.Status = "AB"
                Dim dt_xx As DataTable

                Dim sqlDB As SqlDb = New SqlDb
                Dim dt_stock As New DataTable
                Dim dt_stockJobber As New DataTable
                Dim SqlStr As String = ""

                SqlStr &= " select a.on_hand_qty ,a.on_order_qty from dbo.tbt_jobber_stockindent a,tbm_syst_company b "
                SqlStr &= " where a.isbn_13 = '" + lblisbn.Text.Trim + "'"
                SqlStr &= " and a.on_hand_qty + a.on_order_qty >  b.Minimum_Stock_Jobber "
                dt_stockJobber.Clear()
                dt_stockJobber = sqlDB.GetDataTable(SqlStr)
                If dt_stockJobber.Rows.Count > 0 Then
                    bd.Jobber_Status = "INDENT"
                Else
                    bd.Jobber_Status = "AB"

                    If Session("In_Branch") Is Nothing Then
                        SqlStr = ""
                        SqlStr &= " select a.isbn_13,a.org_ab_code,a.qty,(a.qty-b.Minimum_Stock_Internet)-" + txt_qty.Text + " as total_stock "
                        SqlStr &= "	from tbt_jobber_stockab a,dbo.tbm_syst_company b "
                        SqlStr &= "	where a.isbn_13 = '" + lblisbn.Text.Trim + "' and org_ab_code = 'HO-Internet'  "
                        SqlStr &= "	and a.qty -" + txt_qty.Text + " >=  b.Minimum_Stock_Internet "
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
                            If dt_xx.Rows(ixx).Item("isbn_13").ToString = lblisbn.Text.Trim Then
                                aa = "1"
                                qty = dt_xx.Rows(ixx).Item("Quantity").ToString
                            End If
                        Next
                        If aa = "1" Then
                            SqlStr = ""
                            SqlStr &= " select a.isbn_13,a.org_ab_code,a.qty,(a.qty-b.Minimum_Stock_Internet)-" + qty + " as total_stock "
                            SqlStr &= "	from tbt_jobber_stockab a,dbo.tbm_syst_company b "
                            SqlStr &= "	where a.isbn_13 = '" + lblisbn.Text.Trim + "' and org_ab_code = 'HO-Internet'  "
                            SqlStr &= "	and (a.qty-b.Minimum_Stock_Internet)-" + qty + " >=  b.Minimum_Stock_Internet "
                            dt_stock.Clear()
                            dt_stock = sqlDB.GetDataTable(SqlStr)
                            If dt_stock.Rows.Count > 0 Then
                            Else
                                Response.Redirect("BooksNot_Found.aspx?Meassge=Stock is not available")
                            End If
                        Else
                            SqlStr = ""
                            SqlStr &= " select a.isbn_13,a.org_ab_code,a.qty,(a.qty-b.Minimum_Stock_Internet)-" + txt_qty.Text + " as total_stock "
                            SqlStr &= "	from tbt_jobber_stockab a,dbo.tbm_syst_company b "
                            SqlStr &= "	where a.isbn_13 = '" + lblisbn.Text.Trim + "' and org_ab_code = 'HO-Internet'  "
                            SqlStr &= "	and a.qty -" + txt_qty.Text + " >=  b.Minimum_Stock_Internet "
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
                SqlStr &= " select a.isbn_13,a.org_ab_code,a.qty,(a.qty-b.Minimum_Stock_Internet)-" + txt_qty.Text + " as total_stock "
                SqlStr &= "	from tbt_jobber_stockab a,dbo.tbm_syst_company b "
                SqlStr &= "	where a.isbn_13 = '" + lblisbn.Text.Trim + "' and org_ab_code = 'HO-Internet'  "

                dt_stock.Clear()
                dt_stock = sqlDB.GetDataTable(SqlStr)
                If dt_stock.Rows.Count > 0 Then
                    If Session("In_Branch") Is Nothing Then
                        bd.Jobber_Status = "AB"
                        bd.Status = "AB"
                    Else
                        Dim aa As String = ""
                        Dim yy As String = ""
                        dt_xx = Session("In_Branch")
                        For ixx As Integer = 0 To dt_xx.Rows.Count - 1
                            If dt_xx.Rows(ixx).Item("isbn_13").ToString = lblisbn.Text.Trim And dt_xx.Rows(ixx).Item("Quantity").ToString = dt_stock.Rows(0).Item("qty").ToString Then
                                aa = "1"
                            End If
                        Next
                        If aa = "1" Then
                            bd.Status = "SPECIAL"

                        Else
                            bd.Jobber_Status = "AB"
                            bd.Status = "AB"
                        End If
                    End If

                End If

            Else
                bd.Jobber_Status = "AB"
                bd.Status = "INDENT"
            End If


            If Session("sales_channel") Is Nothing Then
                bd.sales_channel = System.Configuration.ConfigurationManager.AppSettings("UserInternet")
            Else
                bd.sales_channel = Session("sales_channel").ToString
            End If

            bd.keyword_1 = Me.Request.QueryString("Title_1").ToString.Trim

            If Not (IsNumeric(txt_qty.Text) And txt_qty.Text > 0) Then
                ScriptManager.RegisterClientScriptBlock(Me.Page, Me.GetType, "Alert", "alert('Quantity is not Valid');", True)
                Exit Sub
            Else
                bd.keyword_Qty = CInt(txt_qty.Text)
            End If
            bd.keyword_Branch = "HO-Internet"
            If Session("In_Branch") Is Nothing Then
                bd.dt_Old_book_In_Branch = New DataTable
            Else
                bd.dt_Old_book_In_Branch = Session("In_Branch")
            End If

            If Session("Other_Branch") Is Nothing Then
                bd.dt_Old_book_Other_Branch = New DataTable
            Else
                bd.dt_Old_book_Other_Branch = Session("Other_Branch")
            End If

            If Session("jobber") Is Nothing Then
                bd.dt_Old_book_jobber = New DataTable
            Else
                bd.dt_Old_book_jobber = Session("jobber")
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
            bd.country = client_nation
            bd.territory = territory
            bd.Recalcuate()

            Dim Flag1 As String = ""
            Dim Flag2 As String = ""
            Dim Flag3 As String = ""
            If Not bd.dt_book_In_Branch Is Nothing Then
                If bd.dt_book_In_Branch.Select("ISBN_13='" + bd.keyword_1.Trim + "'").Length = 0 Then
                    Flag1 = "0"
                Else
                    Flag1 = "1"
                End If
            Else
                Flag1 = "0"
            End If
            If Not bd.dt_book_Other_Branch Is Nothing Then
                If bd.dt_book_Other_Branch.Select("ISBN_13='" + bd.keyword_1.Trim + "'").Length = 0 Then
                    Flag2 = "0"
                Else
                    Flag2 = "1"
                End If
            Else
                Flag2 = "0"
            End If
            If Not bd.dt_book_jobber Is Nothing Then
                If bd.dt_book_jobber.Select("ISBN_13='" + bd.keyword_1.Trim + "'").Length = 0 Then
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

                If Not bd.dt_book_In_Branch Is Nothing Then
                    For ix As Integer = 0 To bd.dt_book_In_Branch.Rows.Count - 1
                        In_branch_qty = bd.dt_book_In_Branch.Rows(ix).Item("Quantity")
                        total_In_branch_qty = total_In_branch_qty + In_branch_qty
                    Next
                End If
                If Not bd.dt_book_Other_Branch Is Nothing Then
                    For ix As Integer = 0 To bd.dt_book_Other_Branch.Rows.Count - 1
                        In_branch_qty = bd.dt_book_Other_Branch.Rows(ix).Item("Quantity")
                        total_Other_branch_qty = total_Other_branch_qty + In_branch_qty
                    Next
                    'Other_branch_qty = bd.dt_book_Other_Branch.Rows(0).Item("Quantity")
                End If

                If Not bd.dt_book_jobber Is Nothing Then
                    For ix As Integer = 0 To bd.dt_book_jobber.Rows.Count - 1
                        Jobber_qty = bd.dt_book_jobber.Rows(ix).Item("Quantity")
                        total_Jobber_qty = total_Jobber_qty + Jobber_qty
                    Next
                End If

                If bd.input_Quantity > total_In_branch_qty + total_Other_branch_qty + total_Jobber_qty Then

                    If Not bd.dt_book_In_Branch Is Nothing Then
                        If bd.dt_book_In_Branch.Rows.Count <> 0 Then
                            For i = 0 To bd.dt_book_In_Branch.Rows.Count - 1
                                If bd.dt_book_In_Branch.Rows(i).Item("ISBN_13").ToString.Trim = bd.keyword_1.Trim Then
                                    bd.dt_book_In_Branch.Rows(i).Delete()
                                End If
                            Next
                        End If
                    End If
                    If Not bd.dt_book_Other_Branch Is Nothing Then
                        If bd.dt_book_Other_Branch.Rows.Count <> 0 Then
                            For i = 0 To bd.dt_book_Other_Branch.Rows.Count - 1
                                If bd.dt_book_Other_Branch.Rows(i).Item("ISBN_13").ToString.Trim = bd.keyword_1.Trim Then
                                    bd.dt_book_Other_Branch.Rows(i).Delete()
                                End If
                            Next
                        End If
                    End If
                    If Not bd.dt_book_jobber Is Nothing Then
                        If bd.dt_book_jobber.Rows.Count <> 0 Then
                            For i = 0 To bd.dt_book_jobber.Rows.Count - 1
                                If bd.dt_book_jobber.Rows(i).Item("ISBN_13").ToString.Trim = bd.keyword_1.Trim Then
                                    bd.dt_book_jobber.Rows(i).Delete()
                                End If
                            Next
                        End If
                    End If
                    Response.Redirect("BooksNot_Found.aspx?Meassge=Stock is not available")
                End If

                If lblavailable_status.Text = "On order with Publisher and will be available when the book is supplied by Publisher" Then
                    lblPopUp.Text = "This book is not yet published. We will reserve the copy for you once it is available. Confirm to proceed the order."

                    mdlPopupCheck_Promotion.Show()
                    Exit Sub
                End If


                If lblItem_Dis_Group.Text <> "" Then
                    If Left(lblItem_Dis_Group.Text.ToString, 5) = "SHOCK" Or Left(lblItem_Dis_Group.Text.ToString, 5) = "BARGA" Then
                        lblPopUp.Text = "Book’s condition is Fair, which is a worn book that has complete text pages, however, binding, jacket (if any), etc., may also be worn. All defects must be noted."
                        lblPopUp2.Text = "Minimum order value must be Bt. 200."
                        mdlPopupCheck_Promotion.Show()
                        Exit Sub
                    End If
                End If
            End If
        End If
    End Sub

    Protected Sub btn_alertClose_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles btn_alertClose.Click
        Response.Redirect("Wishlist_internet.aspx")
    End Sub
End Class
