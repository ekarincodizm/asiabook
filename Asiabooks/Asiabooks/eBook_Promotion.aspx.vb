Imports Eordering.BusinessLogic
Imports System
Imports System.Data
Imports Eordering.BusinessLogic.PageControl
Imports System.Xml
Imports System.Xml.Linq
Imports System.Linq
Imports System.Globalization
Partial Class eBook_Promotion
    Inherits System.Web.UI.Page
    Private _Utility As New clsUtility

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not Me.IsPostBack Then
            Dim cbd As New Class_book_detail
            datalist_promotion()
            Session("getfree") = cbd.promotion_getfree
            If Session("check_add") Is Nothing Then
                Dim check_add As Integer = 0
                Dim free As Integer = Session("getfree")
                Session("check_add") = check_add
                Dim credits As Integer = free - check_add
                lblcredits.Text = credits.ToString
            Else
                Dim check_add As Integer = Session("check_add")
                Dim free As Integer = Session("getfree")
                If check_add >= free Then
                    If Not IsNothing(Request.Cookies("myCookie_user")) Then
                        Response.Redirect("Customer_Order_Internet.aspx")
                    Else
                        Response.Redirect("Customer_Information_Internet.aspx")
                    End If
                End If
                Dim credits As Integer = free - check_add
                lblcredits.Text = credits.ToString
            End If
        End If
    End Sub
    Private Sub datalist_promotion()
        Dim cbs As New Class_book_search
        Dim datatable As New DataTable
        Dim i As Integer
        If Not Session("format_focus") Is Nothing Then
            Dim focus As String = Session("format_focus")
            Dim sp() As String = focus.Split(",")
            Dim a As Integer = sp.Length - 2
            focus = "("
            For i = 0 To a
                If sp(i) <> "" Then
                    If i < a Then
                        focus &= sp(i) + ","
                    End If
                    If i = a Then
                        focus &= sp(i)
                    End If
                End If
            Next
            focus &= ")"
            cbs.keyword = focus
        End If
        datatable = cbs.list_promotion
        If datatable.Rows.Count > 0 Then
            Session("datatable") = datatable
            Me.Datagrid.DataSource = datatable
            Me.Datagrid.DataBind()
            Me.Datagrid.CurrentPageIndex = 0
        Else
            If Not IsNothing(Request.Cookies("myCookie_user")) Then
                Response.Redirect("Customer_Order_Internet.aspx")
            Else
                Response.Redirect("Customer_Information_Internet.aspx")
            End If
        End If
    End Sub

    Protected Sub Datagrid_ItemDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.DataGridItemEventArgs) Handles Datagrid.ItemDataBound
        If e.Item.ItemType = ListItemType.AlternatingItem Or e.Item.ItemType = ListItemType.Item Then
            Dim Book_Image As Image = e.Item.FindControl("Book_Image")
            Dim lblBook_Image As Label = e.Item.FindControl("lblBook_Image")
            Dim tbx_qty As TextBox = e.Item.FindControl("txt_qty")

            tbx_qty.Attributes.Add("Onkeypress", "num_only()")
            tbx_qty.Attributes.Add("Onmousedown", "return noCopyMouse(event);")
            tbx_qty.Attributes.Add("Onkeydown", "return noCopyKey(event);")
            Dim url_image As String = lblBook_Image.Text
            Dim part1 As String = url_image.Substring(0, 3)
            Dim part2 As String = url_image.Substring(3, 3)
            Dim part3 As String = url_image.Substring(6, 3)
            lblBook_Image.Text = (part1 + "/" + part2 + "/" + part3 + "/" + url_image + ".jpg").Trim
            Book_Image.ImageUrl = _Utility.GetImagePath_eBook(lblBook_Image.Text.Trim)
        End If
    End Sub

    Protected Sub Datagrid_PageIndexChanged(ByVal source As Object, ByVal e As System.Web.UI.WebControls.DataGridPageChangedEventArgs) Handles Datagrid.PageIndexChanged
        Dim datatable As New DataTable
        datatable = Session("datatable")
        Me.Datagrid.DataSource = datatable
        Me.Datagrid.CurrentPageIndex = e.NewPageIndex
        Me.Datagrid.DataBind()
    End Sub

    Protected Sub btn_add_Click(ByVal sender As Object, ByVal e As System.EventArgs)
        Dim sqlDB As SqlDb = New SqlDb
        Dim datatable_old As New DataTable
        Dim datatable_new As New DataTable
        Dim temp As New DataTable
        Dim country As String = ""

        '/////////find row////////////
        Dim dt As DataTable = DirectCast(Session("datatable"), DataTable)
        Dim cell As TableCell = sender.Parent
        Dim dgItem As DataGridItem = cell.Parent
        Dim dr As DataRow = dt.Rows(dgItem.ItemIndex)
        Dim ebook_id As String = dr("ebook_id").ToString

        '/////// check textbox of quantity////////
        Dim txt_qty As TextBox = dgItem.FindControl("txt_qty")
        Dim quantity As String = ""
        If txt_qty.Text.Trim <> "" Then
            quantity &= CInt(txt_qty.Text.Trim).ToString
            If quantity = "0" Then
                quantity = "1"
            End If
        Else
            quantity = "1"
        End If

        '////////new check quantity//////
        'Dim textbox_quantity As TextBox = dgItem.FindControl("txt_qty")
        'If textbox_quantity.Text.Trim = "" Or textbox_quantity.Text.Trim = "0" Then
        '    ScriptManager.RegisterClientScriptBlock(Me.Page, Me.GetType, "Alert", _
        '    "alert('Please input the new value of quantity '); window.open('eBook_Promotion.aspx','_parent');", True)
        '    Exit Sub
        'Else
        '    quantity = textbox_quantity.Text.Trim
        'End If

        '///////check credit////////
        Dim check_add As Integer = Session("check_add")
        Dim getfree As Integer = Session("getfree")
        If getfree > check_add Then
            If quantity >= getfree Then
                quantity = getfree - check_add
                check_add += quantity
                Session("check_add") = check_add
            Else
                check_add += quantity
                Session("check_add") = check_add
            End If
        Else
            If Not IsNothing(Request.Cookies("myCookie_user")) Then
                Response.Redirect("Customer_Order_Internet.aspx")
            Else
                Response.Redirect("Customer_Information_Internet.aspx")
            End If
        End If

        '////// get client country///////
        If Session("client_nation") Is Nothing Then
            Dim gen As New gen_nation
            gen.ip = Request.UserHostAddress()
            country = gen.gen_ip_code
        Else
            country = Session("client_nation")
        End If

        '//////////sql///////////
        Try
            Dim sql As String = ""

            sql &= "SELECT DISTINCT "

            sql &= " ebook.isbn_13 "
            sql &= " , ebook.bookid as ebook_id "
            sql &= " , ebook.book_title "
            sql &= " , ebook.page "
            sql &= " , ebook.supplier "
            sql &= " , currency.exchange_rate as exchange"
            sql &= " , currency.exchange_rate_internet as exchange_internet"
            sql &= " , ebook.discount"
            sql &= " , ebook_type.type as format"
            sql &= " , ebook.format_type "
            sql &= " , isnull(ebook.size,'-') as size "
            sql &= " , '" + quantity + "' as quantity "
            sql &= " , '" + country + "' as country "
            'sql &= ", '1' as book_type "
            sql &= " , 'free' as Selling_price "
            '//////////from//////////
            sql &= " FROM "
            sql &= " (select distinct isbn_13 , book_title , page_qty as page , format_type , bookid , cast(file_size as varchar) as size "
            sql &= " ,supplier_code as supplier , discount , convert(numeric(13,2), selling_price) as selling_price "
            sql &= " from ebook_store where bookid = " + ebook_id + " "
            sql &= " and (status = 'active' or status is null)) ebook "
            '//////////left join//////////

            sql &= " left join ( select distinct currency_code , org_indent_code "
            sql &= " from tbm_syst_organizeindent ) as organize "
            sql &= " on organize.org_indent_code = ebook.supplier "

            sql &= " left join ( select distinct exchange_rate , currency_code "
            sql &= " , exchange_rate_internet from tbm_syst_currency ) as currency "
            sql &= " on organize.currency_code = currency.currency_code "

            sql &= " left join ebook_type on ebook.format_type = ebook_type.formatid "

            datatable_new = sqlDB.GetDataTable(sql)
        Catch ex As Exception
            Throw (New Exception("promotion new session :" + ex.Message))
        End Try

        '////////store data//////////

        Dim datatable As DataTable = New DataTable("datatable")
        Dim datacolumn As DataColumn
        Dim datarow As DataRow

        datacolumn = New DataColumn()
        datacolumn.DataType = System.Type.GetType("System.String")
        datacolumn.ColumnName = "No"
        datacolumn.AutoIncrement = False
        datacolumn.Caption = "No"
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
        datacolumn.ColumnName = "eBook_ID"
        datacolumn.AutoIncrement = False
        datacolumn.Caption = "eBook_ID"
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
        datacolumn.ColumnName = "Quantity"
        datacolumn.AutoIncrement = False
        datacolumn.Caption = "Quantity"
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
        datacolumn.ColumnName = "Items_Amount"
        datacolumn.AutoIncrement = False
        datacolumn.Caption = "Items_Amount"
        datacolumn.ReadOnly = False
        datacolumn.Unique = False
        datatable.Columns.Add(datacolumn)

        datacolumn = New DataColumn()
        datacolumn.DataType = System.Type.GetType("System.String")
        datacolumn.ColumnName = "Supplier"
        datacolumn.AutoIncrement = False
        datacolumn.Caption = "Supplier"
        datacolumn.ReadOnly = False
        datacolumn.Unique = False
        datatable.Columns.Add(datacolumn)

        datacolumn = New DataColumn()
        datacolumn.DataType = System.Type.GetType("System.String")
        datacolumn.ColumnName = "Exchange"
        datacolumn.AutoIncrement = False
        datacolumn.Caption = "Exchange"
        datacolumn.ReadOnly = False
        datacolumn.Unique = False
        datatable.Columns.Add(datacolumn)

        datacolumn = New DataColumn()
        datacolumn.DataType = System.Type.GetType("System.String")
        datacolumn.ColumnName = "Exchange_Internet"
        datacolumn.AutoIncrement = False
        datacolumn.Caption = "Exchange_Internet"
        datacolumn.ReadOnly = False
        datacolumn.Unique = False
        datatable.Columns.Add(datacolumn)

        datacolumn = New DataColumn()
        datacolumn.DataType = System.Type.GetType("System.String")
        datacolumn.ColumnName = "Discount"
        datacolumn.AutoIncrement = False
        datacolumn.Caption = "Discount"
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
        datacolumn.ColumnName = "Format_Type"
        datacolumn.AutoIncrement = False
        datacolumn.Caption = "Format_Type"
        datacolumn.ReadOnly = False
        datacolumn.Unique = False
        datatable.Columns.Add(datacolumn)

        datacolumn = New DataColumn()
        datacolumn.DataType = System.Type.GetType("System.String")
        datacolumn.ColumnName = "Country"
        datacolumn.AutoIncrement = False
        datacolumn.Caption = "Country"
        datacolumn.ReadOnly = False
        datacolumn.Unique = False
        datatable.Columns.Add(datacolumn)

        datacolumn = New DataColumn()
        datacolumn.DataType = System.Type.GetType("System.String")
        datacolumn.ColumnName = "Size"
        datacolumn.AutoIncrement = False
        datacolumn.Caption = "Size"
        datacolumn.ReadOnly = False
        datacolumn.Unique = False
        datatable.Columns.Add(datacolumn)

        Dim i As Integer

        If Session("ebook_shopping") Is Nothing Then
            For i = 0 To datatable_new.Rows.Count - 1
                datarow = datatable.NewRow()
                datarow("No") = (i + 1).ToString()
                datarow("ISBN_13") = datatable_new.Rows(i).Item("ISBN_13").ToString()
                datarow("eBook_ID") = datatable_new.Rows(i).Item("eBook_ID").ToString()
                datarow("Book_Title") = datatable_new.Rows(i).Item("Book_Title").ToString()
                datarow("Selling_Price") = datatable_new.Rows(i).Item("Selling_Price").ToString()
                datarow("Quantity") = datatable_new.Rows(i).Item("Quantity").ToString()
                datarow("Items_Amount") = datatable_new.Rows(i).Item("Selling_Price").ToString()
                datarow("Supplier") = datatable_new.Rows(i).Item("Supplier").ToString()
                datarow("Exchange") = datatable_new.Rows(i).Item("Exchange").ToString()
                datarow("Exchange_Internet") = datatable_new.Rows(i).Item("Exchange_Internet").ToString()
                datarow("Discount") = "0"
                'datarow("Discount") = datatable_new.Rows(i).Item("Discount").ToString()
                datarow("Format") = datatable_new.Rows(i).Item("Format").ToString()
                datarow("Format_Type") = datatable_new.Rows(i).Item("Format_Type").ToString()
                datarow("Country") = datatable_new.Rows(i).Item("Country").ToString()
                datarow("Size") = datatable_new.Rows(i).Item("Size").ToString()
                datatable.Rows.Add(datarow)
            Next
            Session("ebook_shopping") = datatable
        Else
            datatable_old = Session("ebook_shopping")

            For i = 0 To datatable_old.Rows.Count - 1
                datarow = datatable.NewRow()
                datarow("No") = (i + 1).ToString()
                datarow("ISBN_13") = datatable_old.Rows(i).Item("ISBN_13").ToString()
                datarow("eBook_ID") = datatable_old.Rows(i).Item("eBook_ID").ToString()
                datarow("Book_Title") = datatable_old.Rows(i).Item("Book_Title").ToString()
                datarow("Selling_Price") = datatable_old.Rows(i).Item("Selling_Price").ToString()
                datarow("Quantity") = datatable_old.Rows(i).Item("Quantity").ToString()
                If datarow("Selling_Price").ToString = "free" Then
                    datarow("Items_Amount") = datarow("Selling_Price").ToString()
                Else
                    Dim item_amount As Double = CDbl(datarow("Quantity")) * CDbl(datarow("Selling_Price"))
                    datarow("Items_Amount") = item_amount.ToString()
                End If
                datarow("Supplier") = datatable_old.Rows(i).Item("Supplier").ToString()
                datarow("Exchange") = datatable_old.Rows(i).Item("Exchange").ToString()
                datarow("Exchange_Internet") = datatable_old.Rows(i).Item("Exchange_Internet").ToString()
                datarow("Discount") = datatable_old.Rows(i).Item("Discount").ToString()
                datarow("Format") = datatable_old.Rows(i).Item("Format").ToString()
                datarow("Format_Type") = datatable_old.Rows(i).Item("Format_Type").ToString()
                datarow("Country") = datatable_old.Rows(i).Item("Country").ToString()
                datarow("Size") = datatable_old.Rows(i).Item("Size").ToString()
                datatable.Rows.Add(datarow)
            Next

            Dim x As Integer = i + 1
            For i = 0 To datatable_new.Rows.Count - 1
                datarow = datatable.NewRow()
                datarow("No") = (x + i).ToString()
                datarow("ISBN_13") = datatable_new.Rows(i).Item("ISBN_13").ToString()
                datarow("eBook_ID") = datatable_new.Rows(i).Item("eBook_ID").ToString()
                datarow("Book_Title") = datatable_new.Rows(i).Item("Book_Title").ToString()
                datarow("Selling_Price") = datatable_new.Rows(i).Item("Selling_Price").ToString()
                datarow("Quantity") = datatable_new.Rows(i).Item("Quantity").ToString()
                datarow("Items_Amount") = datatable_new.Rows(i).Item("Selling_Price").ToString()
                datarow("Supplier") = datatable_new.Rows(i).Item("Supplier").ToString()
                datarow("Exchange") = datatable_new.Rows(i).Item("Exchange").ToString()
                datarow("Exchange_Internet") = datatable_new.Rows(i).Item("Exchange_Internet").ToString()
                datarow("Discount") = "0"
                'datarow("Discount") = datatable_new.Rows(i).Item("Discount").ToString()
                datarow("Format") = datatable_new.Rows(i).Item("Format").ToString()
                datarow("Format_Type") = datatable_new.Rows(i).Item("Format_Type").ToString()
                datarow("Country") = datatable_new.Rows(i).Item("Country").ToString()
                datarow("Size") = datatable_new.Rows(i).Item("Size").ToString()
                datatable.Rows.Add(datarow)
            Next
            Dim j As Integer
            Dim temptable As DataTable = datatable
            For i = 0 To temptable.Rows.Count - 1
                For j = (i + 1) To temptable.Rows.Count - 1
                    If temptable.Rows(i).Item("eBook_ID") = temptable.Rows(j).Item("eBook_ID") Then
                        If temptable.Rows(i).Item("Selling_Price") = "free" Then
                            Dim qty_i As String = temptable.Rows(i).Item("Quantity").ToString()
                            Dim qty_j As String = temptable.Rows(j).Item("Quantity").ToString()
                            Dim qty_new As Integer = CInt(qty_i) + CInt(qty_j)
                            datatable.Rows(i).Item("Quantity") = qty_new.ToString()
                            datatable.Rows(j).Delete()
                        End If
                    End If
                Next
            Next
            Session("ebook_shopping") = datatable
        End If

        If Session("check_add") Is Nothing Then
        Else
            Dim credit As Integer = Session("check_add")
            Dim free As Integer = Session("getfree")
            If credit = free Then
                If Not IsNothing(Request.Cookies("myCookie_user")) Then
                    Response.Redirect("Customer_Order_Internet.aspx")
                Else
                    Response.Redirect("Customer_Information_Internet.aspx")
                End If
            Else
                Response.Redirect("eBook_Promotion.aspx")
            End If
        End If
    End Sub
End Class
