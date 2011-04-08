Imports Eordering.BusinessLogic
Imports System.Web.UI
Imports System
Imports System.Data
Imports MycustomDG
Imports Eordering.BusinessLogic.PageControl
Imports Microsoft.VisualBasic
Imports System.Math

Partial Class Wishlist_internet
    Inherits System.Web.UI.Page
    Dim sno As Integer = 0
    Public message As String
    Private uCon As uConnect

    '/////////promptnow/////////
    Dim _Utility As clsUtility
    Dim ebooks_id As String = ""
    Dim source As String = ""
    Dim isbn_13 As String = ""
    Dim disc As String = ""
    Dim status As String = ""
    Dim alert As String = ""
    '///////promptnow end///////

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Me.Title = ConfigurationManager.AppSettings("SiteTitle").ToString & "Wishlist ::"

        If Not Me.IsPostBack Then
            clear_free()
            Dim datatable As New DataTable
            datatable = Session("book_wish_lish")
            If Not IsNothing(Request.Cookies("myCookie_user")) Then
                binddataMember(datatable)
                'binddata(datatable)
            Else
                binddata(datatable)
            End If

        End If
    End Sub
    Private Sub binddataMember(ByVal datatable As DataTable)
        Dim dtMember_Book As New DataTable
        Dim dtMember_eBook As New DataTable

        Dim strSql As String = ""
        Dim strMember As String = Request.Cookies("myCookie_user")("MemberCode")
        Dim pcontrol As New PageControl
        datatable = Session("book_wish_lish")

        uCon = New uConnect
        If Not IsNothing(datatable) Then
            For i As Integer = 0 To datatable.Rows.Count - 1
                strSql = ""
                strSql &= " insert into tbm_AB_AddWishlist (ISBN_13,eBook_id,Book_Title,Author,Source,Selling_Price,Format,Format_Num,Image,Item_Dis_Group,Status,Synopsis,Member_Code,Created,CreateBy) values ("
                strSql &= " '" + datatable.Rows(i).Item("ISBN_13").ToString + "','',"
                strSql &= " '" + datatable.Rows(i).Item("Book_Title").Replace("'", "'+Char(39)+'") + "',"
                strSql &= " '" + datatable.Rows(i).Item("Author").Replace("'", "'+Char(39)+'") + "',"
                strSql &= " '" + datatable.Rows(i).Item("Source").ToString + "',"
                strSql &= " " + CDbl(datatable.Rows(i).Item("Selling_Price").ToString).ToString + ",'','',"
                strSql &= " '" + datatable.Rows(i).Item("Image").ToString + "',"
                strSql &= " '" + datatable.Rows(i).Item("Item_Dis_Group").ToString + "',"
                strSql &= " '" + datatable.Rows(i).Item("Status").Replace("'", "'+Char(39)+'") + "',"
                strSql &= " '" + datatable.Rows(i).Item("Synopsis").Replace("'", "'+Char(39)+'") + "',"
                strSql &= " '" + strMember + "',getdate(),"
                strSql &= " '" + strMember + "')"
                If uFunction.ExecuteDataStringNonTran(uCon.conn, strSql) = False Then

                End If
            Next
        End If

        dtMember_Book.Clear()
        dtMember_Book = uFunction.getDataTable(uCon.conn, "select ISBN_13,Book_Title,Author,Source,Selling_Price,Image,Item_Dis_Group,Status,Synopsis from tbm_AB_AddWishlist where Member_Code = '" + strMember + "' and Item_Dis_Group  <> 'eBook'")
        Session("book_wish_lish") = dtMember_Book
        Me.Datagrid_book.DataSource = dtMember_Book
        Me.Datagrid_book.DataBind()
        If Datagrid_book.Items.Count <> 0 Then
            Me.lblStatus_Header.Text = "There are currently " + dtMember_Book.Rows.Count.ToString + " item(s) in your Wish List."
            'Me.Label_Result.Text = pcontrol.ShowingResultSet(Me.Datagrid_book.CurrentPageIndex, Me.Datagrid_book.PageSize, datatable.Rows.Count)
            Me.Label_Result.Visible = False
        Else
            Me.Datagrid_book.Visible = False
            Me.Label2.Visible = False
        End If


        Dim datatable_ebook As New DataTable
        datatable_ebook = Session("ebook_wish_lish")

        If Not IsNothing(datatable_ebook) Then
            For i As Integer = 0 To datatable_ebook.Rows.Count - 1
                strSql = ""
                strSql &= " insert into tbm_AB_AddWishlist (ISBN_13,eBook_id,Book_Title,Author,Source,Selling_Price,Format,Format_Num,Image,Item_Dis_Group,Status,Synopsis,Member_Code,Created,CreateBy) values ("
                strSql &= " '" + datatable_ebook.Rows(i).Item("ISBN_13").ToString + "',"
                strSql &= " '" + datatable_ebook.Rows(i).Item("eBook_id").ToString + "',"
                strSql &= " '" + datatable_ebook.Rows(i).Item("Book_Title").Replace("'", "'+Char(39)+'") + "',"
                strSql &= " '" + datatable_ebook.Rows(i).Item("Author").Replace("'", "'+Char(39)+'") + "',"
                strSql &= " '" + datatable_ebook.Rows(i).Item("Source").ToString + "',"
                strSql &= " " + CDbl(datatable_ebook.Rows(i).Item("Selling_Price").ToString).ToString + ","
                strSql &= " '" + datatable_ebook.Rows(i).Item("Format").ToString + "',"
                strSql &= " '" + datatable_ebook.Rows(i).Item("Format_Num").ToString + "',"
                strSql &= " '" + datatable_ebook.Rows(i).Item("Image").ToString + "',"
                strSql &= " 'eBook','',"
                strSql &= " '" + datatable_ebook.Rows(i).Item("Synopsis").Replace("'", "'+Char(39)+'") + "',"
                strSql &= " '" + strMember + "',getdate(),"
                strSql &= " '" + strMember + "')"
                If uFunction.ExecuteDataStringNonTran(uCon.conn, strSql) = False Then

                End If
            Next
        End If

        dtMember_eBook.Clear()
        dtMember_eBook = uFunction.getDataTable(uCon.conn, "select eBook_id,ISBN_13,Book_Title,Author,Source,Selling_Price,Format,Format_Num,Image,Item_Dis_Group,Synopsis from tbm_AB_AddWishlist where Member_Code = '" + strMember + "' and Item_Dis_Group = 'eBook'")
        Session("ebook_wish_lish") = dtMember_eBook

        Me.Datagrid_ebook.DataSource = dtMember_eBook
        Me.Datagrid_ebook.DataBind()
        If Datagrid_ebook.Items.Count <> 0 Then

            'Me.Label_Result.Text = pcontrol.ShowingResultSet(Me.Datagrid_ebook.CurrentPageIndex, Me.Datagrid_ebook.PageSize, datatble.Rows.Count)
            Me.Label_Result.Visible = False
            ebook_image()
        Else
            Me.Datagrid_ebook.Visible = False
            Me.Label1.Visible = False
        End If

        If Datagrid_book.Items.Count = 0 And Datagrid_ebook.Items.Count = 0 Then
            Me.lblStatus_Header.Text = "There is 0 item in the wish list."
            Me.Label_Result.Text = "Showing 0 of 0 records"
            Me.btn_add_all.Visible = False
            Me.btn_del_all.Visible = False
        Else
            Me.lblStatus_Header.Text = "There are currently " + CInt(Datagrid_book.Items.Count + Datagrid_ebook.Items.Count).ToString + " item(s) in your Wish List."
            Me.btn_add_all.Visible = True
            Me.btn_del_all.Visible = True
        End If
    End Sub
    Private Sub binddata(ByVal datatable As DataTable)
        Dim pcontrol As New PageControl
        datatable = Session("book_wish_lish")
        Me.Datagrid_book.DataSource = datatable
        Me.Datagrid_book.DataBind()
        If Datagrid_book.Items.Count <> 0 Then
            Me.lblStatus_Header.Text = "There are currently " + datatable.Rows.Count.ToString + " item(s) in your Wish List."
            'Me.Label_Result.Text = pcontrol.ShowingResultSet(Me.Datagrid_book.CurrentPageIndex, Me.Datagrid_book.PageSize, datatable.Rows.Count)
            Me.Label_Result.Visible = False
        Else
            Me.Datagrid_book.Visible = False
            Me.Label2.Visible = False
        End If

        Dim datatble As New DataTable
        datatble = Session("ebook_wish_lish")
        Me.Datagrid_ebook.DataSource = datatble
        Me.Datagrid_ebook.DataBind()
        If Datagrid_ebook.Items.Count <> 0 Then

            'Me.Label_Result.Text = pcontrol.ShowingResultSet(Me.Datagrid_ebook.CurrentPageIndex, Me.Datagrid_ebook.PageSize, datatble.Rows.Count)
            Me.Label_Result.Visible = False
            ebook_image()
        Else
            Me.Datagrid_ebook.Visible = False
            Me.Label1.Visible = False
        End If

        If Datagrid_book.Items.Count = 0 And Datagrid_ebook.Items.Count = 0 Then
            Me.lblStatus_Header.Text = "There is 0 item in the wish list."
            Me.Label_Result.Text = "Showing 0 of 0 records"
            Me.btn_add_all.Visible = False
            Me.btn_del_all.Visible = False
        Else
            Me.lblStatus_Header.Text = "There are currently " + CInt(Datagrid_book.Items.Count + Datagrid_ebook.Items.Count).ToString + " item(s) in your Wish List."
            Me.btn_add_all.Visible = True
            Me.btn_del_all.Visible = True
        End If
    End Sub

    Protected Sub Datagrid_book_DeleteCommand(ByVal source As Object, ByVal e As System.Web.UI.WebControls.DataGridCommandEventArgs) Handles Datagrid_book.DeleteCommand
        Dim datatable As DataTable = DirectCast(Session("book_wish_lish"), DataTable)
        Dim dr As DataRow = datatable.Rows(e.Item.ItemIndex)
        isbn_13 = dr("ISBN_13").ToString
        datatable.Rows.Remove(dr)
        Datagrid_book.EditItemIndex = -1

        If Not IsNothing(Request.Cookies("myCookie_user")) Then
            uCon = New uConnect
            uFunction.ExecuteDataStringNonTran(uCon.conn, "delete tbm_AB_AddWishlist where ISBN_13='" + isbn_13 + "' and Member_Code = '" + Request.Cookies("myCookie_user")("MemberCode") + "'  and Item_Dis_Group <> 'eBook' ")
        End If

        binddata(datatable)

        Response.Redirect("Wishlist_internet.aspx")
    End Sub

    Protected Sub Datagrid_ebook_DeleteCommand(ByVal source As Object, ByVal e As System.Web.UI.WebControls.DataGridCommandEventArgs) Handles Datagrid_ebook.DeleteCommand
        Dim datatable As DataTable = DirectCast(Session("ebook_wish_lish"), DataTable)
        Dim dr As DataRow = datatable.Rows(e.Item.ItemIndex)
        isbn_13 = dr("ISBN_13").ToString
        datatable.Rows.Remove(dr)
        Datagrid_ebook.EditItemIndex = -1

        If Not IsNothing(Request.Cookies("myCookie_user")) Then
            uCon = New uConnect
            uFunction.ExecuteDataStringNonTran(uCon.conn, "delete tbm_AB_AddWishlist where ISBN_13='" + isbn_13 + "' and Member_Code = '" + Request.Cookies("myCookie_user")("MemberCode") + "'  and Item_Dis_Group = 'eBook' ")
        End If

        binddata(datatable)

        Response.Redirect("Wishlist_internet.aspx")
    End Sub

    Protected Sub Datagrid_book_ItemCreated(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.DataGridItemEventArgs) Handles Datagrid_book.ItemCreated
        If e.Item.ItemType = ListItemType.Item OrElse e.Item.ItemType = ListItemType.AlternatingItem Then
            Dim _myButton As ImageButton = DirectCast(e.Item.FindControl("b_del"), ImageButton)
            _myButton.OnClientClick = "return confirm('Do you want to delete?');"
        End If
    End Sub

    Protected Sub Datagrid_ebook_ItemCreated(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.DataGridItemEventArgs) Handles Datagrid_ebook.ItemCreated
        If e.Item.ItemType = ListItemType.Item OrElse e.Item.ItemType = ListItemType.AlternatingItem Then
            Dim _myButton As ImageButton = DirectCast(e.Item.FindControl("b_del"), ImageButton)
            _myButton.OnClientClick = "return confirm('Do you want to delete?');"
        End If
    End Sub

    Protected Sub b_continue_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles b_continue.Click
        Session("book_wish_lish") = Session("book_wish_lish")
        Response.Redirect("Homepage.aspx")
    End Sub
    '/////////promptnow/////////
    Protected Sub btn_buy_book_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs)
        Dim datatable As DataTable = DirectCast(Session("book_wish_lish"), DataTable)

        Dim cell As TableCell = sender.Parent
        Dim dgItem As DataGridItem = cell.Parent
        Dim dr As DataRow = datatable.Rows(dgItem.ItemIndex)

        source = dr("Source").ToString
        isbn_13 = dr("ISBN_13").ToString
        disc = dr("Item_Dis_Group").ToString
        status = dr("Status").ToString

        datatable.Rows.Remove(dr)
        Datagrid_book.EditItemIndex = -1
        If Not IsNothing(Request.Cookies("myCookie_user")) Then
            uCon = New uConnect
            uFunction.ExecuteDataStringNonTran(uCon.conn, "delete tbm_AB_AddWishlist where ISBN_13='" + isbn_13 + "' and Member_Code = '" + Request.Cookies("myCookie_user")("MemberCode") + "'  and Item_Dis_Group <> 'eBook' ")
        End If
        binddata(datatable)

        Add_to_cart()
    End Sub

    Protected Sub btn_buy_ebook_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs)
        Dim datatable As DataTable = DirectCast(Session("ebook_wish_lish"), DataTable)

        Dim cell As TableCell = sender.Parent
        Dim dgItem As DataGridItem = cell.Parent
        Dim dr As DataRow = datatable.Rows(dgItem.ItemIndex)

        ebooks_id = dr("eBook_id").ToString

        datatable.Rows.Remove(dr)
        Datagrid_book.EditItemIndex = -1
        binddata(datatable)

        If Not IsNothing(Request.Cookies("myCookie_user")) Then
            uCon = New uConnect
            uFunction.ExecuteDataStringNonTran(uCon.conn, "delete tbm_AB_AddWishlist where ISBN_13='" + ebooks_id + "' and Member_Code = '" + Request.Cookies("myCookie_user")("MemberCode") + "'  and Item_Dis_Group = 'eBook' ")
        End If

        Add_to_cart()
    End Sub
    '/////////promptnow/////////
    Protected Sub btn_add_all_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles btn_add_all.Click
        Dim datatable_book As DataTable = DirectCast(Session("book_wish_lish"), DataTable)
        Dim datatable_ebook As DataTable = DirectCast(Session("ebook_wish_lish"), DataTable)
        Dim datagrid_item As DataGridItem
        uCon = New uConnect

        For Each datagrid_item In Datagrid_book.Items
            Dim checkbox As CheckBox = datagrid_item.FindControl("cbx")
            Dim zitem_disc As Label = datagrid_item.FindControl("lbl_item_disc")
            Dim zisbn_13 As Label = datagrid_item.FindControl("lbl_isbn_13")
            Dim zsource As Label = datagrid_item.FindControl("lbl_source")
            Dim zstatus As Label = datagrid_item.FindControl("lbl_status")

            If checkbox.Checked = True Then
                isbn_13 = zisbn_13.Text.Trim
                source = zsource.Text.Trim
                disc = zitem_disc.Text.Trim
                status = zstatus.Text.Trim
                book_cart()
                For Each mm As DataRow In datatable_book.Select("isbn_13 = '" + isbn_13 + "'")
                    If Not IsNothing(Request.Cookies("myCookie_user")) Then
                        uFunction.ExecuteDataStringNonTran(uCon.conn, "delete tbm_AB_AddWishlist where ISBN_13='" + isbn_13 + "' and Member_Code = '" + Request.Cookies("myCookie_user")("MemberCode") + "'  and Item_Dis_Group <> 'eBook'")
                    Else
                        mm.Delete()
                    End If

                Next
            End If
        Next

        For Each datagrid_item In Datagrid_ebook.Items
            Dim checkbox As CheckBox = datagrid_item.FindControl("cbx")
            Dim zebook_id_ As Label = datagrid_item.FindControl("lbl_eBook_ID")

            If checkbox.Checked = True Then
                If zebook_id_.Text.Trim <> "" Then
                    ebooks_id = zebook_id_.Text.Trim
                    ebook_cart()
                    For Each mm As DataRow In datatable_ebook.Select("eBook_id = '" + ebooks_id + "'")
                        If Not IsNothing(Request.Cookies("myCookie_user")) Then
                            uFunction.ExecuteDataStringNonTran(uCon.conn, "delete tbm_AB_AddWishlist where ISBN_13='" + ebooks_id + "' and Member_Code = '" + Request.Cookies("myCookie_user")("MemberCode") + "'  and Item_Dis_Group = 'eBook'")
                        Else
                            mm.Delete()
                        End If

                    Next
                End If
            End If
        Next

        Session("book_wish_lish") = datatable_book
        Session("ebook_wish_lish") = datatable_ebook

        If alert <> "" Then
            'ScriptManager.RegisterClientScriptBlock(Me.Page, Me.GetType, "Alert", _
            '"alert('You already have item(s) in shopping cart !!'); window.location='shoppingCart_Internet.aspx';", True)
            ModalPopupAlert.Show()
        Else
            Response.Redirect("shoppingCart_Internet.aspx")
        End If
    End Sub

    Protected Sub btn_del_all_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles btn_del_all.Click
        Dim datatable_book As DataTable = DirectCast(Session("book_wish_lish"), DataTable)
        Dim datatable_ebook As DataTable = DirectCast(Session("ebook_wish_lish"), DataTable)
        Dim datagrid_item As DataGridItem
        uCon = New uConnect

        For Each datagrid_item In Datagrid_book.Items
            Dim checkbox As CheckBox = datagrid_item.FindControl("cbx")
            Dim zisbn_13 As Label = datagrid_item.FindControl("lbl_isbn_13")
            If checkbox.Checked = True Then
                For Each mm As DataRow In datatable_book.Select("isbn_13 = " + zisbn_13.Text.Trim + "")
                    If Not IsNothing(Request.Cookies("myCookie_user")) Then
                        uFunction.ExecuteDataStringNonTran(uCon.conn, "delete tbm_AB_AddWishlist where ISBN_13='" + zisbn_13.Text + "' and Member_Code = '" + Request.Cookies("myCookie_user")("MemberCode") + "'  and Item_Dis_Group <> 'eBook'")
                    Else
                        mm.Delete()
                    End If
                Next
            End If
        Next
        For Each datagrid_item In Datagrid_ebook.Items
            Dim checkbox As CheckBox = datagrid_item.FindControl("cbx")
            Dim zebook_id As Label = datagrid_item.FindControl("lbl_eBook_ID")
            Dim lbl_ISBN_13 As Label = datagrid_item.FindControl("lbl_ISBN_13")

            If checkbox.Checked = True Then
                For Each mm As DataRow In datatable_ebook.Select("eBook_id = " + zebook_id.Text.Trim + "")
                    If Not IsNothing(Request.Cookies("myCookie_user")) Then
                        uFunction.ExecuteDataStringNonTran(uCon.conn, "delete tbm_AB_AddWishlist where ISBN_13='" + lbl_ISBN_13.Text + "' and Member_Code = '" + Request.Cookies("myCookie_user")("MemberCode") + "'  and Item_Dis_Group = 'eBook'")
                    Else
                        mm.Delete()

                    End If

                Next
            End If
        Next

        Session("book_wish_lish") = datatable_book
        Session("ebook_wish_lish") = datatable_ebook
        Response.Redirect("Wishlist_internet.aspx")
    End Sub

    '/////////promptnow/////////
    Private Sub Add_to_cart()

        If ebooks_id <> "" Then
            ebook_cart()
            If alert <> "" Then
                alert = ""
                'ScriptManager.RegisterClientScriptBlock(Me.Page, Me.GetType, "Alert", _
                '"alert('You already have item(s) in shopping cart !!'); window.location='shoppingCart_Internet.aspx';", True)
                ModalPopupAlert.Show()
            Else
                Response.Redirect("shoppingCart_Internet.aspx")
            End If
        Else
            book_cart()
            If alert <> "" Then
                alert = ""
                'ScriptManager.RegisterClientScriptBlock(Me.Page, Me.GetType, "Alert", _
                '"alert('You already have item(s) in shopping cart !!'); window.location='shoppingCart_Internet.aspx';", True)
                ModalPopupAlert.Show()
            Else
                Response.Redirect("shoppingCart_Internet.aspx")
            End If
        End If
    End Sub

    '/////////promptnow/////////
    Private Sub ebook_cart()
        Dim sqlDB As SqlDb = New SqlDb
        Dim datatable As New DataTable
        Dim sql, country As String
        Dim Class_book_detail As New Class_book_detail

        If Session("client_nation") Is Nothing Then
            Dim gen As New gen_nation
            gen.ip = Request.UserHostAddress()
            country = gen.gen_ip_code
        Else
            country = Session("client_nation")
        End If

        sql &= " SELECT "
        sql &= " case search.source when 'Asiabooks' then ROUND(convert(numeric(13,2),search.selling),0) "
        sql &= " else ROUND(convert(numeric(18,2),(search.selling * isnull(search.exchange_rate,0))),0) end as selling_price "

        sql &= " , search.ebook_id , search.isbn_13 , search.book_title , search.author , search.publisher_name "
        sql &= " , search.image , search.source as supplier , search.discount , search.ebook_format as format , search.format_type "
        sql &= " , search.copy_rigths , search.page_qty , search.size , search.publication_date , search.language "
        sql &= " , search.synopsis , search.size , search.exchange_rate as exchange , search.exchange_internet "
        sql &= " , '-' as subject_name " '//// รอข้อมูล category
        sql &= " , '1' as quantity"
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
        sql &= " , convert(numeric(13,2) , ebook.price_org) as selling , ebook.isbn_10 as image , ebook.format_type "
        sql &= " , '0' as discount , currency.exchange_rate , currency.exchange_rate_internet as exchange_internet , type.type as ebook_format "

        sql &= " from ebook_store ebook with (nolock) "
        sql &= " , tbm_syst_organizeindent organize with (nolock) "
        sql &= " , tbm_syst_currency currency with (nolock) "
        sql &= " , ebook_type type with (nolock) "

        sql &= " where ebook.supplier_code = organize.org_indent_code and organize.currency_code = currency.currency_code "
        sql &= " and ebook.format_type = type.formatid "
        sql &= " and ebook.bookid = " + ebooks_id + " "
        sql &= " ) as search "

        datatable = sqlDB.GetDataTable(sql)
        If Session("ebook_shopping") Is Nothing Then
            Dim datatableNew As DataTable = CreateTable()
            Dim datarow As DataRow
            datarow = datatableNew.NewRow
            datarow("Book_Title") = datatable.Rows(0).Item("Book_Title").ToString
            datarow("ISBN_13") = datatable.Rows(0).Item("ISBN_13").ToString
            datarow("eBook_ID") = datatable.Rows(0).Item("eBook_ID").ToString
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
            Session("original_total") = class_book_detail.original_total
            Session("amount_ebook") = class_book_detail.amount_ebook
        Else
            Dim dataSession As DataTable = Session("ebook_shopping")
            Dim eBook_ID As String = datatable.Rows(0).Item("eBook_ID").ToString
            For Each ss As DataRow In dataSession.Select("eBook_ID = '" + eBook_ID + "'")
                alert = "alert"
            Next
            Dim datatableNew As DataTable = CreateTable()
            Dim datarow As DataRow
            datarow = datatableNew.NewRow
            datarow("Book_Title") = datatable.Rows(0).Item("Book_Title").ToString
            datarow("ISBN_13") = datatable.Rows(0).Item("ISBN_13").ToString
            datarow("eBook_ID") = datatable.Rows(0).Item("eBook_ID").ToString
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
            Session("original_total") = class_book_detail.original_total
            Session("amount_ebook") = class_book_detail.amount_ebook
        End If
    End Sub

    '/////////promptnow/////////
    Private Sub book_cart()
        Dim SqlStr As String = ""
        Dim sqlDB As SqlDb = New SqlDb
        Dim dt_stock As New DataTable
        Dim dt_stockJobber As New DataTable
        Dim dt_xx As DataTable
        Dim bd As New Class_book_detail

        If source = "Asiabooks" Then
            bd.Status = "AB"
            SqlStr &= " select a.on_hand_qty ,a.on_order_qty from dbo.tbt_jobber_stockindent a,tbm_syst_company b "
            SqlStr &= " where a.isbn_13 = '" + isbn_13 + "'"
            SqlStr &= " and a.on_hand_qty + a.on_order_qty >  b.Minimum_Stock_Jobber "
            dt_stockJobber.Clear()
            dt_stockJobber = SqlDb.GetDataTable(SqlStr)

            If dt_stockJobber.Rows.Count > 0 Then
                bd.Jobber_Status = "INDENT"
            Else
                bd.Jobber_Status = "AB"

                If Session("In_Branch") Is Nothing Then
                    SqlStr = ""
                    SqlStr &= " select a.isbn_13,a.org_ab_code,a.qty,(a.qty-b.Minimum_Stock_Internet)-1 as total_stock "
                    SqlStr &= "	from tbt_jobber_stockab a,dbo.tbm_syst_company b "
                    SqlStr &= "	where a.isbn_13 = '" + isbn_13 + "' and org_ab_code = 'HO-Internet'  "
                    SqlStr &= "	and a.qty - 1 >=  b.Minimum_Stock_Internet "
                    dt_stock.Clear()
                    dt_stock = sqlDB.GetDataTable(SqlStr)
                    '///////promptnow//////////
                    'If dt_stock.Rows.Count > 0 Then
                    'Else
                    '    Response.Redirect("BooksNot_Found.aspx?Meassge=Stock is not available")
                    'End If
                Else
                    Dim aa As String = ""
                    Dim yy As String = ""
                    Dim qty As String = ""
                    dt_xx = Session("In_Branch")
                    For ixx As Integer = 0 To dt_xx.Rows.Count - 1
                        If dt_xx.Rows(ixx).Item("isbn_13").ToString = isbn_13 Then
                            aa = "1"
                            qty = dt_xx.Rows(ixx).Item("Quantity").ToString
                        End If
                    Next
                    If aa = "1" Then
                        SqlStr = ""
                        SqlStr &= " select a.isbn_13,a.org_ab_code,a.qty,(a.qty-b.Minimum_Stock_Internet)-1 as total_stock "
                        SqlStr &= "	from tbt_jobber_stockab a,dbo.tbm_syst_company b "
                        SqlStr &= "	where a.isbn_13 = '" + isbn_13 + "' and org_ab_code = 'HO-Internet'  "
                        SqlStr &= "	and (a.qty-b.Minimum_Stock_Internet)-1 >=  b.Minimum_Stock_Internet "
                        dt_stock.Clear()
                        dt_stock = SqlDb.GetDataTable(SqlStr)
                        '///////promptnow//////////
                        'If dt_stock.Rows.Count > 0 Then
                        'Else
                        '    Response.Redirect("BooksNot_Found.aspx?Meassge=Stock is not available")
                        'End If
                    Else
                        SqlStr = ""
                        SqlStr &= " select a.isbn_13,a.org_ab_code,a.qty,(a.qty-b.Minimum_Stock_Internet)-1 as total_stock "
                        SqlStr &= "	from tbt_jobber_stockab a,dbo.tbm_syst_company b "
                        SqlStr &= "	where a.isbn_13 = '" + isbn_13 + "' and org_ab_code = 'HO-Internet'  "
                        SqlStr &= "	and a.qty -1 >=  b.Minimum_Stock_Internet "
                        dt_stock.Clear()
                        dt_stock = sqlDB.GetDataTable(SqlStr)
                        '///////promptnow//////////
                        'If dt_stock.Rows.Count > 0 Then
                        'Else
                        '    Response.Redirect("BooksNot_Found.aspx?Meassge=Stock is not available")
                        'End If
                    End If
                End If
            End If
            SqlStr = ""
            SqlStr &= " select a.isbn_13,a.org_ab_code,a.qty,(a.qty-b.Minimum_Stock_Internet)-1 as total_stock "
            SqlStr &= "	from tbt_jobber_stockab a,dbo.tbm_syst_company b "
            SqlStr &= "	where a.isbn_13 = '" + isbn_13 + "' and org_ab_code = 'HO-Internet'  "
            dt_stock.Clear()
            dt_stock = SqlDb.GetDataTable(SqlStr)

            If dt_stock.Rows.Count > 0 Then
                If Session("In_Branch") Is Nothing Then
                    bd.Jobber_Status = "AB"
                    bd.Status = "AB"
                Else
                    Dim aa As String = ""
                    Dim yy As String = ""
                    dt_xx = Session("In_Branch")
                    For ixx As Integer = 0 To dt_xx.Rows.Count - 1
                        If dt_xx.Rows(ixx).Item("isbn_13").ToString = isbn_13 And dt_xx.Rows(ixx).Item("Quantity").ToString = dt_stock.Rows(0).Item("qty").ToString Then
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

        bd.keyword_1 = isbn_13

        If Not (1 > 0) Then
            ScriptManager.RegisterClientScriptBlock(Me.Page, Me.GetType, "Alert", "alert('Quantity is not Valid');", True)
            Exit Sub
        Else
            bd.keyword_Qty = 1
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
            '///////promptnow//////////
            'Response.Redirect("BooksNot_Found.aspx?Meassge=Stock is not available")
            '//////////////////////////
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
            uCon = New uConnect
            If bd.input_Quantity > total_In_branch_qty + total_Other_branch_qty + total_Jobber_qty Then

                If Not bd.dt_book_In_Branch Is Nothing Then
                    If bd.dt_book_In_Branch.Rows.Count <> 0 Then
                        For i = 0 To bd.dt_book_In_Branch.Rows.Count - 1
                            If bd.dt_book_In_Branch.Rows(i).Item("ISBN_13").ToString.Trim = bd.keyword_1.Trim Then
                                If Not IsNothing(Request.Cookies("myCookie_user")) Then
                                    uFunction.ExecuteDataStringNonTran(uCon.conn, "delete tbm_AB_AddWishlist where ISBN_13='" + bd.dt_book_In_Branch.Rows(i).Item("ISBN_13").ToString.Trim + "' and Member_Code = '" + Request.Cookies("myCookie_user")("MemberCode") + "'  and Item_Dis_Group <> 'eBook'")
                                Else
                                    bd.dt_book_In_Branch.Rows(i).Delete()
                                End If

                            End If
                        Next
                    End If
                End If
                If Not bd.dt_book_Other_Branch Is Nothing Then
                    If bd.dt_book_Other_Branch.Rows.Count <> 0 Then
                        For i = 0 To bd.dt_book_Other_Branch.Rows.Count - 1
                            If bd.dt_book_Other_Branch.Rows(i).Item("ISBN_13").ToString.Trim = bd.keyword_1.Trim Then
                                If Not IsNothing(Request.Cookies("myCookie_user")) Then
                                    uFunction.ExecuteDataStringNonTran(uCon.conn, "delete tbm_AB_AddWishlist where ISBN_13='" + bd.dt_book_Other_Branch.Rows(i).Item("ISBN_13").ToString.Trim + "' and Member_Code = '" + Request.Cookies("myCookie_user")("MemberCode") + "'  and Item_Dis_Group <> 'eBook'")
                                Else
                                    bd.dt_book_Other_Branch.Rows(i).Delete()
                                End If
                            End If
                        Next
                    End If
                End If
                If Not bd.dt_book_jobber Is Nothing Then
                    If bd.dt_book_jobber.Rows.Count <> 0 Then
                        For i = 0 To bd.dt_book_jobber.Rows.Count - 1
                            If bd.dt_book_jobber.Rows(i).Item("ISBN_13").ToString.Trim = bd.keyword_1.Trim Then
                                If Not IsNothing(Request.Cookies("myCookie_user")) Then
                                    uFunction.ExecuteDataStringNonTran(uCon.conn, "delete tbm_AB_AddWishlist where ISBN_13='" + bd.dt_book_jobber.Rows(i).Item("ISBN_13").ToString.Trim + "' and Member_Code = '" + Request.Cookies("myCookie_user")("MemberCode") + "'  and Item_Dis_Group <> 'eBook'")
                                Else
                                    bd.dt_book_jobber.Rows(i).Delete()
                                End If
                            End If
                        Next
                    End If
                End If
                '///////promptnow//////////
                'Response.Redirect("BooksNot_Found.aspx?Meassge=Stock is not available")
                '//////////////////////////
                'lblCheck_Meassge.Text = "Quantity of ISBN : " + bd.keyword_1 + " is not enough,Please contact staff"
                'mdlPopUp_CheckMeassge.Show()
                'ScriptManager.RegisterClientScriptBlock(Me.Page, Me.GetType, "Alert", "alert('Quantity of ISBN : " + bd.keyword_1 + " is not enough,Please contact staff');", True)
                'Exit Sub
            End If

            If status = "On order with Publisher and will be available when the book is supplied by Publisher" Then
                lblPopUp.Text = "This book is not yet published. We will reserve the copy for you once it is available. Confirm to proceed the order."

                ' mdlPopupCheck_Promotion.Show()
                Exit Sub
            End If


            If disc <> "" Then
                If Left(disc, 5) = "SHOCK" Or Left(disc, 5) = "BARGA" Then
                    lblPopUp.Text = "Book’s condition is Fair, which is a worn book that has complete text pages, however, binding, jacket (if any), etc., may also be worn. All defects must be noted."
                    lblPopUp2.Text = "Minimum order value must be Bt. 200."
                    'mdlPopupCheck_Promotion.Show()
                    Exit Sub
                End If
            End If
        End If
        Dim a As String = bd.alert
        If a <> "" Then
            alert = a
        End If
    End Sub

    Private Sub ebook_image()
        For Each datagrid_item As DataGridItem In Datagrid_ebook.Items
            Dim image As Image = datagrid_item.FindControl("img_Image")
            Dim lblimage As Label = datagrid_item.FindControl("lbl_image")

            Dim url_image As String = lblimage.Text
            Dim part1 As String = url_image.Substring(0, 3)
            Dim part2 As String = url_image.Substring(3, 3)
            Dim part3 As String = url_image.Substring(6, 3)
            lblimage.Text = (part1 + "/" + part2 + "/" + part3 + "/" + url_image + ".jpg").Trim
            _Utility = New clsUtility
            image.ImageUrl = _Utility.GetImagePath_eBook(lblimage.Text.Trim)
        Next
    End Sub

    Private Sub clear_free()
        If Not Session("ebook_shopping") Is Nothing Then
            Session.Remove("postback_promotion")
            Session.Remove("check_add")
            Dim datatable As DataTable = Session("ebook_shopping")
            If Not datatable Is Nothing Then
                For Each gg As DataRow In datatable.Select("Selling_Price = '0'")
                    gg.Delete()
                Next
                Session.Remove("check_add")
            End If
            Session("ebook_shopping") = datatable
        End If
    End Sub

    Private Function CreateTable() As DataTable
        Dim datatable As New DataTable

        datatable.Columns.Add("No", System.Type.GetType("System.String"))
        datatable.Columns.Add("ISBN_13", System.Type.GetType("System.String"))
        datatable.Columns.Add("eBook_ID", System.Type.GetType("System.String"))
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

    Protected Sub btn_alertClose_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles btn_alertClose.Click
        Response.Redirect("shoppingCart_Internet.aspx")
    End Sub
End Class
