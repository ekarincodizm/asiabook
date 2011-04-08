Imports Eordering.BusinessLogic
Imports System.Web.UI
Imports System
Imports System.Data
Imports Eordering.BusinessLogic.PageControl
Imports Microsoft.VisualBasic
Imports System.Web.UI.ClientScriptManager
Imports System.Threading

Partial Class shoppingCart_Internet
    Inherits System.Web.UI.Page
    Dim class_book_detail As New Class_book_detail
    Private uCon As New uConnect
    Public PopupPromotion As Boolean
    Dim count_item As Double = 0

    Private Sub Class_GetData_PromotionDiscount()
        Dim datatable As New DataTable
        datatable = uFunction.getDataTable(uCon.conn, "SELECT buy , discount FROM ebook_promotion WHERE status = 1 AND promotion = 1")
        If datatable.Rows.Count > 0 Then
            Session("discount") = CDbl(datatable.Rows(0).Item("discount")).ToString("##")
            Session("buy_ebook") = datatable.Rows(0).Item("buy").ToString
            lblMsg2.Text = "Enjoy our special promotion Buy " + Session("buy_ebook").ToString + " eBooks get " + Session("discount").ToString + "% discount! "
        Else
            Session("discount") = Nothing
            Session("buy_ebook") = Nothing
            Me.lbltxt_promotion.Visible = False
            Me.lbldiscount.Visible = False
            'If Me.IsPostBack Then
                'Class_eBook_Recalculate()
                'loadData()
            'End If
        End If
    End Sub

    Private Sub Class_GetData_PromotionFree()
        Dim datatable As New DataTable
        datatable = uFunction.getDataTable(uCon.conn, "SELECT buy_book , free_ebook FROM ebook_promotion WHERE status = 1 AND promotion = 2")
        If datatable.Rows.Count > 0 Then
            Session("free") = datatable.Rows(0).Item("free_ebook").ToString
            Session("buy_book") = datatable.Rows(0).Item("buy_book").ToString
            lblMsg1.Text = "Enjoy our special promotion Buy " + Session("buy_book").ToString + " Books get " + Session("free").ToString + " free eBook! "
            If Not Session("discount") Is Nothing Then
                lblMsg3.Text = "Enjoy our special combo promotions <br/>1.Buy " + Session("buy_ebook").ToString + " eBooks get " + Session("discount").ToString + "% discount !  <br/>2.Buy " + Session("buy_book").ToString + " Books get " + Session("free").ToString + " free eBook! "
            End If
        Else
            Session("free") = Nothing
            Session("buy_book") = Nothing
            Session("credits") = Nothing
            Class_clear_free()
        End If
    End Sub

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Me.Title = ConfigurationManager.AppSettings("SiteTitle").ToString & "Shopping Cart ::"
        
        If Not Me.IsPostBack Then
        Class_GetData_PromotionDiscount()
        Class_GetData_PromotionFree()
            Session("Promotions_List") = Nothing
            loadData()
            Me.b_clear_cart.Attributes.Add("onclick", "return confirm('Do you want to Clear Cart?')")
        End If
        If Me.IsPostBack Then
        Promotions()
        End If
    End Sub

    Private Sub loadData()
        Me.In_Branch.DataSource = Session("In_Branch")
        Me.In_Branch.DataBind()
        Me.jobber.DataSource = Session("jobber")
        Me.jobber.DataBind()
        Me.ebook_inCart.DataSource = Session("ebook_shopping")
        Me.ebook_inCart.DataBind()

        If Session("In_Branch") Is Nothing And Session("jobber") Is Nothing Then
            Session.Remove("ebook_promotion")
        End If

        If Not Session("ebook_promotion") Is Nothing Then
            Dim datatable As DataTable = DirectCast(Session("ebook_promotion"), DataTable).Copy
            If datatable.Rows.Count > 0 Then
                Dim rowCount As Integer = 1
                For Each dd As DataRow In datatable.Rows
                    dd.Item("No") = rowCount.ToString
                    rowCount = rowCount + 1
                Next
                Me.DatagridPromotion.DataSource = datatable
                Me.DatagridPromotion.DataBind()
            Else
                Me.DatagridPromotion.DataSource = Session("ebook_promotion")
                Me.DatagridPromotion.DataBind()
            End If
        End If

        '/////////promptnow/////////
        If Me.ebook_inCart.Items.Count = 0 Then
            Me.Label_ebook_inShopping.Visible = True
            Me.Label_ebook_inShopping.Text = "There is no item in you shopping cart"
            Me.ebook_total.Visible = False
            Me.lb_ebook_amount.Text = ""
            Me.lb_ebook_usd.Text = ""
            Me.lbltxt_promotion.Visible = False
            Me.lbldiscount.Visible = False
            Dim dt As New DataTable
            Me.ebook_inCart.DataSource = dt
            Me.ebook_inCart.DataBind()
        Else
            Me.Label_ebook_inShopping.Visible = False
            Me.ebook_total.Visible = True
            Me.ebook_total.Text = "Total Amount"
            Me.lb_ebook_amount.Text = CDbl(Session("amount_ebook")).ToString("#,###.00")
            Me.lb_ebook_usd.Text = "(US$ " + class_book_detail.callUsd(CDbl(Session("amount_ebook"))) + ")"
            ebook_us()
        End If
        '/////////promotion/////////
        If Me.DatagridPromotion.Items.Count = 0 Then
            Dim dt As New DataTable
            Me.DatagridPromotion.DataSource = dt
            Me.DatagridPromotion.DataBind()
        End If

        If Me.In_Branch.Items.Count = 0 Then
            Me.lbl_item_in_shopping1.Visible = True
            Me.lbl_item_in_shopping1.Text = "There is no item in you shopping cart"
            Me.lbl_total_Inbranch.Visible = False
            Me.lbl_Amount_InBranch.Text = ""
            Me.lbl_Amount_InBranch_usd.Text = ""
            Dim dt As New DataTable
            Me.In_Branch.DataSource = dt
            Me.In_Branch.DataBind()
        Else
            Me.lbl_item_in_shopping1.Visible = False
            Me.lbl_total_Inbranch.Visible = True

            Me.lbl_total_Inbranch.Text = "Total Amount"
            Me.lbl_Amount_InBranch.Text = CDbl(Session("amount_Branch")).ToString("#,###.00")
            Me.lbl_Amount_InBranch_usd.Text = "(US$ " + CDbl(class_book_detail.callUsd(Session("amount_Branch"))).ToString("#,###.##") + ")"
            in_branch_total()
        End If

        If Me.jobber.Items.Count = 0 Then
            Me.lbl_item_in_shopping3.Visible = True
            Me.lbl_item_in_shopping3.Text = "There is no item in you shopping cart"
            Me.lbl_total_jobber.Visible = False
            Me.lbl_Amount_Jobber.Text = ""
            Me.lbl_Amount_Jobber_usd.Text = ""
            Dim dt As New DataTable
            Me.jobber.DataSource = dt
            Me.jobber.DataBind()
        Else
            Me.lbl_item_in_shopping3.Visible = False
            Me.lbl_total_jobber.Visible = True
            Me.lbl_total_jobber.Text = "Total Amount"
            Me.lbl_Amount_Jobber.Text = CDbl(Session("amount_Jobber")).ToString("#,###.00")
            Me.lbl_Amount_Jobber_usd.Text = "(US$ " + CDbl(class_book_detail.callUsd(Session("amount_Jobber"))).ToString("#,###.##") + ")"
            jobber_total()
        End If


        '/////////promptnow/////////
        If Me.In_Branch.Items.Count = 0 And Me.jobber.Items.Count = 0 And Me.ebook_inCart.Items.Count = 0 Then
            Me.lblStatus_Head.Text = "Your 0 item (s) in shopping cart."
            Me.btn_proceed.ImageUrl = "~/images/Template/Button/proceed_payment_01.gif"
            Me.img_click_cart.Visible = False
            Me.btn_proceed.Enabled = False
            Me.btn_recalculate.Enabled = False
            Me.lbltxt_promotion.Visible = False
            Me.lbldiscount.Visible = False
            Me.paneltotal_all.Visible = False
        Else
            count_item = CDbl(Me.In_Branch.Items.Count.ToString) + CDbl(jobber.Items.Count.ToString) + CDbl(ebook_inCart.Items.Count.ToString)
            Me.lblStatus_Head.Text = "Your " + count_item.ToString + " item (s) in shopping cart."
            Class_PromotionCheck()
            Dim bookAmount As Integer = Class_ItemAmount_Book()
            Dim ebookAmount As Integer = Class_ItemAmout_eBook()
            Dim totalAmount As Integer = bookAmount + ebookAmount
            Me.paneltotal_all.Visible = True
            Me.b_continue_shopping.Enabled = True
            Me.lblus_all.Text = "(US$ " + CDbl(class_book_detail.callUsd(totalAmount)).ToString("#,###.##") + ")"
            Me.lblfinaltotal.Text = CDbl(totalAmount).ToString("#,###.00")
        End If
    End Sub

    Private Sub in_branch_total()
        Dim gr As DataGridItem
        For Each gr In In_Branch.Items
            '/////////promptnow/////////
            Dim Amount As Label = gr.FindControl("Amount")
            Dim tbxquantity As TextBox = gr.FindControl("Quantity")
            Dim lbl_Amount_in_branch_usd As Label = gr.FindControl("lbl_Amount_in_branch_usd")
            lbl_Amount_in_branch_usd.Text = "(US$ " + class_book_detail.callUsd((Amount.Text)) + ")"
            tbxquantity.Attributes.Add("Onkeypress", "num_only()")
            tbxquantity.Attributes.Add("Onmousedown", "return noCopyMouse(event);")
            tbxquantity.Attributes.Add("Onkeydown", "return noCopyKey(event);")

        Next
    End Sub

    Private Sub jobber_total()
        Dim gr As DataGridItem
        For Each gr In jobber.Items
            '/////////promptnow/////////
            Dim Amount As Label = gr.FindControl("Amount_Jobber")
            Dim tbxquantity As TextBox = gr.FindControl("Quantity_Jobber")
            Dim lbl_Amount_jobber_usd As Label = gr.FindControl("lbl_Amount_jobber_usd")
            lbl_Amount_jobber_usd.Text = "(US$ " + class_book_detail.callUsd(Amount.Text) + ")"
            tbxquantity.Attributes.Add("Onkeypress", "num_only()")
            tbxquantity.Attributes.Add("Onmousedown", "return noCopyMouse(event);")
            tbxquantity.Attributes.Add("Onkeydown", "return noCopyKey(event);")

        Next
    End Sub

    Private Sub ebook_us()
        Dim gr As DataGridItem
        For Each gr In ebook_inCart.Items

            Dim Amount As Label = gr.FindControl("Amount_ebook")
            Dim ebook_usd As Label = gr.FindControl("lbl_Amount_ebook_usd")
            Dim tbxquantity As TextBox = gr.FindControl("Quantity_ebook")

            ebook_usd.Text = "(US$ " + class_book_detail.callUsd(Amount.Text) + ")"
            tbxquantity.Attributes.Add("Onkeypress", "num_only()")
            tbxquantity.Attributes.Add("Onmousedown", "return noCopyMouse(event);")
            tbxquantity.Attributes.Add("Onkeydown", "return noCopyKey(event);")
        Next
    End Sub

    Protected Sub b_clear_cart_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles b_clear_cart.Click
        Dim dt As DataTable
        If Not Session("In_Branch") Is Nothing Then
            dt = Session("In_Branch")
            dt.Clear()
            Session("In_Branch") = dt
        End If
        If Not Session("jobber") Is Nothing Then
            dt = Session("jobber")
            dt.Clear()
            Session("jobber") = dt
        End If
        If Not Session("ebook_shopping") Is Nothing Then
            dt = Session("ebook_shopping")
            dt.Clear()
            Session("ebook_shopping") = dt
            Session("original_total") = Nothing
            Session("amount_ebook") = Nothing
        End If
        Class_clear_free()

        loadData()
        ScriptManager.RegisterClientScriptBlock(Me.Page, Me.GetType, "Alert", "alert('Clear Cart is successful');", True)
    End Sub

    Protected Sub b_continue_shopping_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles b_continue_shopping.Click
        Class_Book_Recalculate()
        Class_eBook_Recalculate()
        Response.Redirect("Homepage.aspx")
    End Sub

    Protected Sub btn_recalculate_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles btn_recalculate.Click
        Class_Book_Recalculate()
        Class_eBook_Recalculate()
        loadData()
        Me.btn_recalculate.ImageUrl = "~/images/Template/Button/recalculate.gif"
        Me.btn_proceed.ImageUrl = "~/images/Template/Button/proceed_payment_02.gif"
        Me.btn_proceed.Enabled = True
    End Sub

    Protected Sub In_Branch_DeleteCommand(ByVal source As Object, ByVal e As System.Web.UI.WebControls.DataGridCommandEventArgs) Handles In_Branch.DeleteCommand
        Dim datatable As DataTable = DirectCast(Session("In_Branch"), DataTable)
        For Each datarows As DataRow In datatable.Select("ISBN_13 = '" + e.CommandArgument + "'")
            datarows.Delete()
        Next
        Session("In_Branch") = datatable
        loadData()
        Class_Book_Recalculate()
        loadData()
    End Sub

    Protected Sub jobber_DeleteCommand(ByVal source As Object, ByVal e As System.Web.UI.WebControls.DataGridCommandEventArgs) Handles jobber.DeleteCommand
        Dim datatable As DataTable = DirectCast(Session("jobber"), DataTable)
        For Each datarows As DataRow In datatable.Select("ISBN_13 = '" + e.CommandArgument + "'")
            datarows.Delete()
        Next
        Session("jobber") = datatable
        loadData()
        Class_Book_Recalculate()
        loadData()
    End Sub

    Protected Sub ebook_inCart_DeleteCommand(ByVal source As Object, ByVal e As System.Web.UI.WebControls.DataGridCommandEventArgs) Handles ebook_inCart.DeleteCommand
        Dim datatable As DataTable = DirectCast(Session("ebook_shopping"), DataTable)
        For Each datarows As DataRow In datatable.Select("eBook_ID = '" + e.CommandArgument + "'")
            datarows.Delete()
        Next
        Session("ebook_shopping") = datatable
        loadData()
        Class_eBook_Recalculate()
        loadData()
    End Sub

    Protected Sub DatagridPromotion_DeleteCommand(ByVal source As Object, ByVal e As System.Web.UI.WebControls.DataGridCommandEventArgs) Handles DatagridPromotion.DeleteCommand
        Dim credits As String = Session("credits")
        Dim datatable As DataTable = DirectCast(Session("ebook_promotion"), DataTable)
        For Each datarows As DataRow In datatable.Select("eBook_ID = '" + e.CommandArgument + "'")
            credits = (CInt(credits) - CInt(datarows.Item("Quantity"))).ToString
            datarows.Delete()
        Next
        Session("credits") = credits
        Session("ebook_promotion") = datatable
        loadData()
    End Sub

    Protected Sub In_Branch_ItemCreated(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.DataGridItemEventArgs) Handles In_Branch.ItemCreated
        If e.Item.ItemType = ListItemType.Item OrElse e.Item.ItemType = ListItemType.AlternatingItem Then
            Dim _myButton As ImageButton = DirectCast(e.Item.FindControl("b_del_In_Branch"), ImageButton)
            _myButton.OnClientClick = "return confirm('Do you want to delete?');"
        End If
    End Sub

    Protected Sub jobber_ItemCreated(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.DataGridItemEventArgs) Handles jobber.ItemCreated
        If e.Item.ItemType = ListItemType.Item OrElse e.Item.ItemType = ListItemType.AlternatingItem Then
            Dim _myButton As ImageButton = DirectCast(e.Item.FindControl("b_del_Jobber"), ImageButton)
            _myButton.OnClientClick = "return confirm('Do you want to delete?');"
        End If
    End Sub

    Protected Sub ebook_inCart_ItemCreated(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.DataGridItemEventArgs) Handles ebook_inCart.ItemCreated
        If e.Item.ItemType = ListItemType.Item OrElse e.Item.ItemType = ListItemType.AlternatingItem Then
            Dim _myButton As ImageButton = DirectCast(e.Item.FindControl("b_ebook_delete"), ImageButton)
            _myButton.OnClientClick = "return confirm('Do you want to delete?');"
        End If
    End Sub

    Protected Sub DatagridPromotion_ItemCreated(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.DataGridItemEventArgs) Handles DatagridPromotion.ItemCreated
        If e.Item.ItemType = ListItemType.Item OrElse e.Item.ItemType = ListItemType.AlternatingItem Then
            Dim _myButton As ImageButton = DirectCast(e.Item.FindControl("b_ebook_free_delete"), ImageButton)
            _myButton.OnClientClick = "return confirm('Do you want to delete?');"
        End If
    End Sub

    Protected Sub btn_proceed_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles btn_proceed.Click
        Class_GetData_PromotionFree()
        'Class_clear_free()
        Class_Book_Recalculate()
        Class_eBook_Recalculate()
        Dim list As DataTable = class_book_detail.Class_listPromotion
        Dim free As String = Session("free")
        Dim credits As String = Session("credits")

        If CInt(free) - CInt(credits) > 0 Then
            If list.Rows.Count > 0 And CInt(free) > 0 Then
                Session("Promotions_List") = list
                Dim buy_book_ As String = Session("buy_book")
                Dim countQuantity As Integer = Class_ItemQuantity_Book()
                If countQuantity >= CInt(buy_book_) Then
                    Promotions()
                    ModalPopupPromotion.Show()
                Else
                    If Not IsNothing(Request.Cookies("myCookie_user")) Then
                        Response.Redirect("Customer_Order_Internet.aspx")
                    Else
                        Response.Redirect("Customer_Information_Internet.aspx")
                    End If
                End If
            Else
                If Not IsNothing(Request.Cookies("myCookie_user")) Then
                    Response.Redirect("Customer_Order_Internet.aspx")
                Else
                    Response.Redirect("Customer_Information_Internet.aspx")
                End If
            End If
        Else
            If Not IsNothing(Request.Cookies("myCookie_user")) Then
                Response.Redirect("Customer_Order_Internet.aspx")
            Else
                Response.Redirect("Customer_Information_Internet.aspx")
            End If
        End If
    End Sub

    Protected Sub Quantity_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs)
        Class_Book_Recalculate()
        loadData()
        loadData()
        Me.btn_recalculate.ImageUrl = "~/images/Template/Button/recalculate_02.gif"
        Me.btn_proceed.ImageUrl = "~/images/Template/Button/proceed_payment_01.gif"
        btn_proceed.Enabled = False
    End Sub

    Protected Sub Quantity_Jobber_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs)
        Class_Book_Recalculate()
        loadData()
        loadData()
        Me.btn_recalculate.ImageUrl = "~/images/Template/Button/recalculate_02.gif"
        Me.btn_proceed.ImageUrl = "~/images/Template/Button/proceed_payment_01.gif"
        btn_proceed.Enabled = False
    End Sub

    Protected Sub Quantity_ebook_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs)
        Class_eBook_Recalculate()
        loadData()
        loadData()
        Me.btn_recalculate.ImageUrl = "~/images/Template/Button/recalculate_02.gif"
        Me.btn_proceed.ImageUrl = "~/images/Template/Button/proceed_payment_01.gif"
        btn_proceed.Enabled = False
    End Sub

    Protected Sub In_Branch_ItemDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.DataGridItemEventArgs) Handles In_Branch.ItemDataBound
        If e.Item.ItemType = ListItemType.AlternatingItem Or e.Item.ItemType = ListItemType.Item Then
            Dim Lead_Time_show As Label = e.Item.FindControl("Lead_Time_show")
            Dim ISBN As Label = e.Item.FindControl("ISBN")
            Dim dt_LeadTime As New DataTable
            Dim strSql As String = ""

            strSql = ""
            strSql &= " select a.isbn_13,datediff(day,getdate(),dateadd(day,30,max([Expected Receipt Date])))"
            strSql &= " as eta from tbm_AB_eCom_Discount_Extra a inner join ETA b "
            strSql &= " on a.isbn_13 = b.itemno where a.isbn_13 ='" + ISBN.Text + "'   and a.[type]='CommingSoon' group by a.isbn_13"

            uCon = New uConnect
            dt_LeadTime.Clear()
            dt_LeadTime = uFunction.getDataTable(uCon.conn, strSql)
            If dt_LeadTime.Rows.Count > 0 Then
                Lead_Time_show.Text = dt_LeadTime.Rows(0).Item("eta").ToString
            Else
                Lead_Time_show.Text = "5-10"
            End If
        End If
    End Sub

    Private Sub Class_Book_Recalculate()
        class_book_detail = New Class_book_detail
        Dim dt_Session_In_Branch As New DataTable
        Dim dr_Session_In_Branch As DataRow

        dt_Session_In_Branch.Columns.Add("No")
        dt_Session_In_Branch.Columns.Add("Book_Title")
        dt_Session_In_Branch.Columns.Add("ISBN_13")
        dt_Session_In_Branch.Columns.Add("Selling_Price")
        dt_Session_In_Branch.Columns.Add("Lead_Time")
        dt_Session_In_Branch.Columns.Add("Weight")
        dt_Session_In_Branch.Columns.Add("Quantity")
        dt_Session_In_Branch.Columns.Add("Amount")
        dt_Session_In_Branch.Columns.Add("Ordstt")
        dt_Session_In_Branch.Columns.Add("To_Org_AB_code")
        dt_Session_In_Branch.Columns.Add("Status")

        For Each gr As DataGridItem In In_Branch.Items
            Dim lblNo As Label = gr.FindControl("NO")
            Dim lblBook_Title As Label = gr.FindControl("Book_Title")
            Dim lblISBN As Label = gr.FindControl("ISBN")
            Dim lblPrice As Label = gr.FindControl("Price")
            Dim lblLead_Time As Label = gr.FindControl("Lead_Time")
            Dim lblWeight As Label = gr.FindControl("Weight")
            Dim txtQuantity As TextBox = gr.FindControl("Quantity")
            Dim lblAmount As Label = gr.FindControl("Amount")
            Dim ordstt_In_Branch As Label = gr.FindControl("ordstt_In_Branch")
            Dim To_Org_AB_Code_In_branch As Label = gr.FindControl("To_Org_AB_Code_In_branch")
            Dim Status_In_branch As Label = gr.FindControl("Status_In_branch")

            If txtQuantity.Text.Trim = "" Or txtQuantity.Text.Trim = "0" Then
                txtQuantity.Text = "1"
            End If

            dr_Session_In_Branch = dt_Session_In_Branch.NewRow
            dr_Session_In_Branch("No") = lblNo.Text
            dr_Session_In_Branch("Book_Title") = lblBook_Title.Text
            dr_Session_In_Branch("ISBN_13") = lblISBN.Text
            dr_Session_In_Branch("Selling_Price") = lblPrice.Text
            dr_Session_In_Branch("Lead_Time") = lblLead_Time.Text
            dr_Session_In_Branch("Weight") = lblWeight.Text
            dr_Session_In_Branch("Quantity") = txtQuantity.Text
            dr_Session_In_Branch("Amount") = lblAmount.Text
            dr_Session_In_Branch("Ordstt") = ordstt_In_Branch.Text
            dr_Session_In_Branch("To_Org_AB_code") = To_Org_AB_Code_In_branch.Text
            dr_Session_In_Branch("Status") = Status_In_branch.Text
            dt_Session_In_Branch.Rows.Add(dr_Session_In_Branch)
        Next

        Dim dt_Session_Jobber As New DataTable
        Dim dr_Session_Jobber As DataRow

        dt_Session_Jobber.Columns.Add("No")
        dt_Session_Jobber.Columns.Add("Book_Title")
        dt_Session_Jobber.Columns.Add("ISBN_13")
        dt_Session_Jobber.Columns.Add("Selling_Price")
        dt_Session_Jobber.Columns.Add("Lead_Time")
        dt_Session_Jobber.Columns.Add("Weight")
        dt_Session_Jobber.Columns.Add("Quantity")
        dt_Session_Jobber.Columns.Add("Amount")
        dt_Session_Jobber.Columns.Add("Ordstt")
        dt_Session_Jobber.Columns.Add("To_Org_AB_code")
        dt_Session_Jobber.Columns.Add("Status")

        For Each gr_Jobber As DataGridItem In jobber.Items
            Dim lblNo As Label = gr_Jobber.FindControl("NO_Jobber")
            Dim lblBook_Title As Label = gr_Jobber.FindControl("Book_Title_Jobber")
            Dim lblISBN As Label = gr_Jobber.FindControl("ISBN_Jobber")
            Dim lblPrice As Label = gr_Jobber.FindControl("Price_Jobber")
            Dim lblLead_Time As Label = gr_Jobber.FindControl("Lead_Time_Jobber")
            Dim lblWeight As Label = gr_Jobber.FindControl("Weight_Jobber")
            Dim txtQuantity As TextBox = gr_Jobber.FindControl("Quantity_Jobber")
            Dim lblAmount As Label = gr_Jobber.FindControl("Amount_Jobber")
            Dim ordstt_jobber As Label = gr_Jobber.FindControl("ordstt_jobber")
            Dim To_Org_AB_Code_jobber As Label = gr_Jobber.FindControl("To_Org_AB_Code_jobber")
            Dim Status_jobber As Label = gr_Jobber.FindControl("Status_jobber")

            If txtQuantity.Text.Trim = "" Or txtQuantity.Text.Trim = "0" Then
                txtQuantity.Text = "1"
            End If

            dr_Session_Jobber = dt_Session_Jobber.NewRow
            dr_Session_Jobber("No") = lblNo.Text
            dr_Session_Jobber("Book_Title") = lblBook_Title.Text
            dr_Session_Jobber("ISBN_13") = lblISBN.Text
            dr_Session_Jobber("Selling_Price") = lblPrice.Text
            dr_Session_Jobber("Lead_Time") = lblLead_Time.Text
            dr_Session_Jobber("Weight") = lblWeight.Text
            dr_Session_Jobber("Quantity") = txtQuantity.Text
            dr_Session_Jobber("Amount") = lblAmount.Text
            dr_Session_Jobber("Ordstt") = ordstt_jobber.Text
            dr_Session_Jobber("To_Org_AB_code") = To_Org_AB_Code_jobber.Text
            dr_Session_Jobber("Status") = Status_jobber.Text
            dt_Session_Jobber.Rows.Add(dr_Session_Jobber)

        Next
        class_book_detail.sales_channel = "INTERNET"
        class_book_detail.keyword_Branch = "HO-Internet"

        class_book_detail.dt_Old_book_In_Branch = dt_Session_In_Branch
        class_book_detail.dt_Old_book_jobber = dt_Session_Jobber
        class_book_detail.keyword_1 = ""
        class_book_detail.keyword_Qty = 0
        'detail.Status = "1"
        class_book_detail.Recalcuate()

        Session("In_Branch") = class_book_detail.dt_book_In_Branch
        Session("jobber") = class_book_detail.dt_book_jobber

        Session("amount_Branch") = class_book_detail.amount_Branch
        Session("amount_Jobber") = class_book_detail.amount_Jobber


        Dim i As Integer
        Dim j As Integer
        Dim qty_in1 As Integer = 0
        Dim qty_in2 As Integer = 0
        Dim qty_other1 As Integer = 0
        Dim qty_other2 As Integer = 0
        Dim qty_jobber1 As Integer = 0
        Dim isbn13_in As String

        ' check in branch
        If Not dt_Session_In_Branch Is Nothing Then
            For i = 0 To dt_Session_In_Branch.Rows.Count - 1
                isbn13_in = dt_Session_In_Branch.Rows(i).Item("ISBN_13").ToString.Trim
                qty_in1 = dt_Session_In_Branch.Rows(i).Item("Quantity")
                If dt_Session_In_Branch.Rows(i).Item("Status").ToString.Trim = "AB" Then
                    Dim sqlDB As SqlDb = New SqlDb
                    Dim dt_stock As New DataTable
                    Dim SqlStr As String = ""
                    SqlStr = SqlStr + " select a.isbn_13,a.org_ab_code,a.qty,(a.qty-b.Minimum_Stock_Internet)-" + qty_in1.ToString + " as total_stock "
                    SqlStr = SqlStr + "	from tbt_jobber_stockab a,dbo.tbm_syst_company b "
                    SqlStr = SqlStr + "	where a.isbn_13 = '" + isbn13_in + "' and a.org_ab_code = 'HO-Internet'"
                    dt_stock = sqlDB.GetDataTable(SqlStr)
                    If dt_stock.Rows.Count > 0 Then
                        'If dt_stock.Rows(0).Item("total_stock") < 0 Then
                        '    ScriptManager.RegisterClientScriptBlock(Me.Page, Me.GetType, "Alert", "alert('There are a few quantity of the ISBN : " + isbn13_in + " in stock, so please contact Customer Service at 02-7159000 \n EXT: 8103, 3202 or Sales Staffs to confirm availability before processing order');", True)
                        '    Exit Sub
                        'End If
                    End If
                End If


                If Not class_book_detail.dt_book_In_Branch Is Nothing Then
                    For j = 0 To class_book_detail.dt_book_In_Branch.Rows.Count - 1
                        If class_book_detail.dt_book_In_Branch.Rows(j).Item("ISBN_13").ToString.Trim = isbn13_in.Trim Then
                            qty_in2 = class_book_detail.dt_book_In_Branch.Rows(j).Item("Quantity")
                        End If
                    Next
                End If
                If Not class_book_detail.dt_book_Other_Branch Is Nothing Then
                    For j = 0 To class_book_detail.dt_book_Other_Branch.Rows.Count - 1
                        If class_book_detail.dt_book_Other_Branch.Rows(j).Item("ISBN_13").ToString.Trim = isbn13_in.Trim Then
                            qty_other1 = class_book_detail.dt_book_Other_Branch.Rows(j).Item("Quantity")
                        End If
                    Next
                End If
                If Not class_book_detail.dt_book_jobber Is Nothing Then
                    For j = 0 To class_book_detail.dt_book_jobber.Rows.Count - 1
                        If class_book_detail.dt_book_jobber.Rows(j).Item("ISBN_13").ToString.Trim = isbn13_in.Trim Then
                            qty_jobber1 = class_book_detail.dt_book_jobber.Rows(j).Item("Quantity")
                        End If
                    Next
                End If
                If CInt(dt_Session_In_Branch.Rows(i).Item("Quantity")) > qty_in2 + qty_other1 + qty_jobber1 Then
                    ScriptManager.RegisterClientScriptBlock(Me.Page, Me.GetType, "Alert", "alert('Quantity of ISBN : " + dt_Session_In_Branch.Rows(i).Item("ISBN_13") + " is not enough,Please input quantity again or Please contact staff');", True)
                    dt_Session_In_Branch.Rows(i).Item("Quantity") = 0
                    Exit Sub
                End If
            Next
        End If
    End Sub

    Private Sub Class_eBook_Recalculate()
        class_book_detail = New Class_book_detail
        Dim datatable As New DataTable
        Dim datarows As DataRow
        Dim i As Integer = 0

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

        For Each gr_ebook As DataGridItem In ebook_inCart.Items
            Dim lblBook_Title As Label = gr_ebook.FindControl("Book_Title_ebook")
            Dim lblISBN As Label = gr_ebook.FindControl("ISBN_ebook")
            Dim lbleBook_ID As Label = gr_ebook.FindControl("eBook_ID_ebook")
            Dim lblPrice As Label = gr_ebook.FindControl("Price_ebook")
            Dim txtQuantity As TextBox = gr_ebook.FindControl("Quantity_ebook")
            Dim lblSupplier As Label = gr_ebook.FindControl("Supplier_ebook")
            Dim lblExchange As Label = gr_ebook.FindControl("Exchange_ebook")
            Dim lblExchange_Internet As Label = gr_ebook.FindControl("Exchange_Internet_ebook")
            Dim lblDiscount As Label = gr_ebook.FindControl("Discount_ebook")
            Dim lblFormat As Label = gr_ebook.FindControl("Format_ebook")
            Dim lblCountry As Label = gr_ebook.FindControl("Country_ebook")
            Dim lblFormat_Type As Label = gr_ebook.FindControl("Format_Type_ebook")
            Dim lblSize_ebook As Label = gr_ebook.FindControl("Size_ebook")

            If txtQuantity.Text.Trim = "" Or txtQuantity.Text.Trim = "0" Then
                txtQuantity.Text = "1"
            End If

            datarows = datatable.NewRow
            datarows("Book_Title") = lblBook_Title.Text
            datarows("ISBN_13") = lblISBN.Text
            datarows("eBook_ID") = lbleBook_ID.Text
            datarows("Selling_Price") = lblPrice.Text
            datarows("Quantity") = txtQuantity.Text
            datarows("Supplier") = lblSupplier.Text
            datarows("Exchange") = lblExchange.Text
            datarows("Exchange_Internet") = lblExchange_Internet.Text
            datarows("Discount") = lblDiscount.Text
            datarows("Format") = lblFormat.Text
            datarows("Country") = lblCountry.Text
            datarows("Format_Type") = lblFormat_Type.Text
            datarows("Size") = lblSize_ebook.Text
            datatable.Rows.Add(datarows)
        Next

        class_book_detail.dataOld = datatable
        class_book_detail.From_ebook = "ebook"
        class_book_detail.Recalcuate()
        Session("ebook_shopping") = class_book_detail.dataCart
        Session("original_total") = class_book_detail.original_total
        Session("amount_ebook") = class_book_detail.amount_ebook
    End Sub

    Private Sub Class_PromotionCheck()
        Dim promotionBoolean As Integer = 0
        Dim credits As String = ""
        Dim free_ As String = ""
        If Not Session("free") Is Nothing Then
            free_ = Session("free")
            Dim buy_book_ As String = Session("buy_book")

            Dim countQuantity As Integer = Class_ItemQuantity_Book()
            If countQuantity >= CInt(buy_book_) Then
                promotionBoolean = promotionBoolean + 1
            Else
                Class_clear_free()
            End If

            If Session("credits") Is Nothing Then
                Session("credits") = "0"
                credits = Session("credits")
            Else
                credits = Session("credits")
            End If
        End If

        If Not Session("discount") Is Nothing Then
            Dim discount_ As String = Session("discount")
            Dim buy_ebook_ As String = Session("buy_ebook")
            Dim discountAmout_ As Double = CDbl(Session("original_total")) - CDbl(Session("amount_ebook"))

            Dim countQuantity As Integer = Class_ItemQuantity_eBook()
            If countQuantity >= CInt(buy_ebook_) Then
                lbldiscount.Text = CDbl(discountAmout_).ToString("#,###.00")
                lbltxt_promotion.Text = "Promotion Discount (" + CInt(discount_).ToString + "%)"
                lbltxt_promotion.Visible = True
                lbldiscount.Visible = True
                promotionBoolean = promotionBoolean + 2
            Else
                lbltxt_promotion.Visible = False
                lbldiscount.Visible = False
            End If
        End If

        If promotionBoolean = 1 Then
            If CInt(free_) - CInt(credits) > 0 Then
                ModalPopupPromotionMsg1.Show()
            Else
                Exit Sub
            End If
        End If
        If promotionBoolean = 2 Then
            ModalPopupPromotionMsg2.Show()
        End If
        If promotionBoolean = 3 Then
            If CInt(free_) - CInt(credits) > 0 Then
                ModalPopupPromotionMsg3.Show()
            Else
                ModalPopupPromotionMsg2.Show()
            End If
        End If
    End Sub

    Private Function Class_ItemQuantity_Book() As Integer
        Dim countQuantity As Integer = 0
        For Each datagrids As DataGridItem In In_Branch.Items
            Dim tbxquantity As TextBox = datagrids.FindControl("Quantity")
            countQuantity = countQuantity + CInt(tbxquantity.Text)
        Next
        For Each datagrids As DataGridItem In jobber.Items
            Dim tbxquantity As TextBox = datagrids.FindControl("Quantity_Jobber")
            countQuantity = countQuantity + CInt(tbxquantity.Text)
        Next
        Return countQuantity
    End Function

    Private Function Class_ItemAmount_Book() As Integer
        Dim bookAmount As Integer = 0
        If Me.In_Branch.Items.Count > 0 Then
            bookAmount = bookAmount + CInt(Me.lbl_Amount_InBranch.Text)
        End If
        If Me.jobber.Items.Count > 0 Then
            bookAmount = bookAmount + CInt(Me.lbl_Amount_Jobber.Text)
        End If
        Return bookAmount
    End Function

    Private Function Class_ItemQuantity_eBook() As Integer
        Dim countQuantity As Integer = 0
        For Each datagrids As DataGridItem In ebook_inCart.Items
            Dim tbxquantity As TextBox = datagrids.FindControl("Quantity_ebook")
            countQuantity = countQuantity + CInt(tbxquantity.Text)
        Next
        Return countQuantity
    End Function

    Private Function Class_ItemAmout_eBook() As Integer
        Dim ebookAmount As Integer = 0
        If Me.ebook_inCart.Items.Count > 0 Then
            ebookAmount = ebookAmount + CInt(Me.lb_ebook_amount.Text)
        End If
        Return ebookAmount
    End Function

    Private Sub Promotions()
        Dim free As String = Session("free")
        Dim credits As String = Session("credits")
        lblcredits.Text = CInt(CInt(free) - CInt(credits)).ToString
        Class_listPromotion()
    End Sub

    Private Sub Class_listPromotion()
        Dim datatable As New DataTable

        If Session("Promotions_List") Is Nothing Then
            datatable = class_book_detail.Class_listPromotion
            Session("Promotions_List") = datatable
        Else
            datatable = Session("Promotions_List")
        End If

        Me.Datagrid.DataSource = datatable
        Me.Datagrid.DataBind()
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
            Dim _Utility As New clsUtility
            Book_Image.ImageUrl = _Utility.GetImagePath_eBook(lblBook_Image.Text.Trim)
        End If
    End Sub

    Protected Sub btn_add_Click(ByVal sender As Object, ByVal e As System.EventArgs)
        Class_GetData_PromotionFree()
        Class_client_nation()
        Dim sqlDB As SqlDb = New SqlDb
        Dim datatable_old As New DataTable
        Dim datatable_new As New DataTable
        Dim temp As New DataTable
        Dim free As String = Session("free")
        Dim credits As String = Session("credits")
        Dim country As String = Session("client_nation")
        Dim quantity As String = ""
        Dim sqlstr As String = ""
        Dim balance As Integer = 0

        '/////////find row////////////
        Dim datatable As DataTable = DirectCast(Session("Promotions_List"), DataTable)
        Dim tablecells As TableCell = sender.Parent
        Dim datagriditems As DataGridItem = tablecells.Parent
        Dim datarows As DataRow = datatable.Rows(datagriditems.ItemIndex)
        Dim eBook_ID As String = datarows("ebook_id").ToString

        '/////// check textbox of quantity////////
        Dim txt_qty As TextBox = datagriditems.FindControl("txt_qty")
        If txt_qty.Text.Trim = "" Or txt_qty.Text.Trim = "0" Then
            quantity = "1"
        Else
            quantity = txt_qty.Text.Trim
        End If
        balance = CInt(quantity) + CInt(credits)

        If balance > CInt(free) Then
            balance = CInt(free) - CInt(credits)
            Session("credits") = CInt(free)
            quantity = balance.ToString
        Else
            Session("credits") = balance
        End If
       
        '//////////sql///////////
        Try
            sqlstr &= "SELECT "
            sqlstr &= " ebook.isbn_13 "
            sqlstr &= " , ebook.bookid as ebook_id "
            sqlstr &= " , ebook.book_title "
            sqlstr &= " , ebook.page "
            sqlstr &= " , ebook.supplier "
            sqlstr &= " , currency.exchange_rate as exchange"
            sqlstr &= " , currency.exchange_rate_internet as exchange_internet"
            sqlstr &= " , ebook.discount"
            sqlstr &= " , ebook_type.type as format"
            sqlstr &= " , ebook.format_type "
            sqlstr &= " , isnull(ebook.size,'-') as size "
            sqlstr &= " , '" + quantity + "' as quantity "
            sqlstr &= " , '" + country + "' as country "
            sqlstr &= " , (selling_price*exchange_rate) as Selling_price "
            '//////////from//////////
            sqlstr &= " FROM "
            sqlstr &= " (select distinct isbn_13 , book_title , page_qty as page , format_type , bookid , cast(file_size as varchar) as size "
            sqlstr &= " ,supplier_code as supplier , discount , convert(numeric(13,2), selling_price) as selling_price "
            sqlstr &= " from ebook_store where bookid = " + eBook_ID + " "
            sqlstr &= " and (status = 'active' or status is null)) ebook "
            '//////////left join//////////
            sqlstr &= " left join ( select distinct currency_code , org_indent_code "
            sqlstr &= " from tbm_syst_organizeindent ) as organize "
            sqlstr &= " on organize.org_indent_code = ebook.supplier "

            sqlstr &= " left join ( select distinct exchange_rate , currency_code "
            sqlstr &= " , exchange_rate_internet from tbm_syst_currency ) as currency "
            sqlstr &= " on organize.currency_code = currency.currency_code "

            sqlstr &= " left join ebook_type on ebook.format_type = ebook_type.formatid "

            datatable_new = sqlDB.GetDataTable(sqlstr)
        Catch ex As Exception
            Throw (New Exception("promotion new session :" + ex.Message))
        End Try

        '////////store data//////////

        datatable = New DataTable
        Dim datarow As DataRow
        datatable.Columns.Add("No", System.Type.GetType("System.String"))
        datatable.Columns.Add("ISBN_13", System.Type.GetType("System.String"))
        datatable.Columns.Add("eBook_ID", System.Type.GetType("System.String"))
        datatable.Columns.Add("Book_Title", System.Type.GetType("System.String"))
        datatable.Columns.Add("Selling_Price", System.Type.GetType("System.String"))
        datatable.Columns.Add("Quantity", System.Type.GetType("System.String"))
        datatable.Columns.Add("Items_Amount", System.Type.GetType("System.String"))
        datatable.Columns.Add("Supplier", System.Type.GetType("System.String"))
        datatable.Columns.Add("Exchange", System.Type.GetType("System.String"))
        datatable.Columns.Add("Exchange_Internet", System.Type.GetType("System.String"))
        datatable.Columns.Add("Discount", System.Type.GetType("System.String"))
        datatable.Columns.Add("Format", System.Type.GetType("System.String"))
        datatable.Columns.Add("Country", System.Type.GetType("System.String"))
        datatable.Columns.Add("Format_Type", System.Type.GetType("System.String"))
        datatable.Columns.Add("Size", System.Type.GetType("System.String"))

        If Session("ebook_promotion") Is Nothing Then
            datarow = datatable.NewRow()
            datarow("No") = "-"
            datarow("ISBN_13") = datatable_new.Rows(0).Item("ISBN_13").ToString
            datarow("eBook_ID") = datatable_new.Rows(0).Item("eBook_ID").ToString
            datarow("Book_Title") = datatable_new.Rows(0).Item("Book_Title").ToString
            datarow("Selling_Price") = CDbl(datatable_new.Rows(0).Item("Selling_Price")).ToString("#,###.####")
            datarow("Quantity") = datatable_new.Rows(0).Item("Quantity").ToString
            datarow("Items_Amount") = "0"
            datarow("Supplier") = datatable_new.Rows(0).Item("Supplier").ToString
            datarow("Exchange") = datatable_new.Rows(0).Item("Exchange").ToString
            datarow("Exchange_Internet") = datatable_new.Rows(0).Item("Exchange_Internet").ToString
            datarow("Discount") = "0"
            datarow("Format") = datatable_new.Rows(0).Item("Format").ToString
            datarow("Format_Type") = datatable_new.Rows(0).Item("Format_Type").ToString
            datarow("Country") = datatable_new.Rows(0).Item("Country").ToString
            datarow("Size") = datatable_new.Rows(0).Item("Size").ToString
            If Not datarow("Size") = "-" Then
                datarow("Size") = CDbl(datatable_new.Rows(0).Item("Size")).ToString("#,###.####")
            End If
            datatable.Rows.Add(datarow)
        Else
            datatable_old = Session("ebook_promotion")
            For Each datarowsOld As DataRow In datatable_old.Rows
                datarow = datatable.NewRow()
                datarow("No") = "-"
                datarow("ISBN_13") = datarowsOld.Item("ISBN_13").ToString
                datarow("eBook_ID") = datarowsOld.Item("eBook_ID").ToString
                datarow("Book_Title") = datarowsOld.Item("Book_Title").ToString
                datarow("Selling_Price") = CDbl(datarowsOld.Item("Selling_Price")).ToString("#,###")
                datarow("Quantity") = datarowsOld.Item("Quantity").ToString
                datarow("Items_Amount") = (CDbl(datarow("Selling_Price")) * CDbl(datarow("Quantity"))).ToString("#,###.####")
                datarow("Supplier") = datarowsOld.Item("Supplier").ToString
                datarow("Exchange") = datarowsOld.Item("Exchange").ToString
                datarow("Exchange_Internet") = datarowsOld.Item("Exchange_Internet").ToString
                datarow("Discount") = "0"
                datarow("Format") = datarowsOld.Item("Format").ToString
                datarow("Format_Type") = datarowsOld.Item("Format_Type").ToString
                datarow("Country") = datarowsOld.Item("Country").ToString
                datarow("Size") = datarowsOld.Item("Size").ToString
                datatable.Rows.Add(datarow)
            Next
            Dim dataDup As String = "N"
            Dim eBooks_ID As String = datatable_new.Rows(0).Item("eBook_ID").ToString
            For Each datarowsData As DataRow In datatable.Select("eBook_ID = '" + eBooks_ID + "'")
                datarowsData.Item("Quantity") = (CInt(datarowsData.Item("Quantity")) + CInt(datatable_new.Rows(0).Item("Quantity"))).ToString
                datarowsData.Item("Items_Amount") = (CDbl(datarowsData.Item("Selling_Price")) * CDbl(datarowsData.Item("Quantity"))).ToString("#,###.####")
                dataDup = "Y"
            Next
            If dataDup = "N" Then
                datarow = datatable.NewRow()
                datarow("No") = "-"
                datarow("ISBN_13") = datatable_new.Rows(0).Item("ISBN_13").ToString
                datarow("eBook_ID") = datatable_new.Rows(0).Item("eBook_ID").ToString
                datarow("Book_Title") = datatable_new.Rows(0).Item("Book_Title").ToString
                datarow("Selling_Price") = CDbl(datatable_new.Rows(0).Item("Selling_Price")).ToString("#,###.####")
                datarow("Quantity") = datatable_new.Rows(0).Item("Quantity").ToString
                datarow("Items_Amount") = (CDbl(datarow("Selling_Price")) * CDbl(datarow("Quantity"))).ToString("#,###.####")
                datarow("Supplier") = datatable_new.Rows(0).Item("Supplier").ToString
                datarow("Exchange") = datatable_new.Rows(0).Item("Exchange").ToString
                datarow("Exchange_Internet") = datatable_new.Rows(0).Item("Exchange_Internet").ToString
                datarow("Discount") = "0"
                datarow("Format") = datatable_new.Rows(0).Item("Format").ToString
                datarow("Format_Type") = datatable_new.Rows(0).Item("Format_Type").ToString
                datarow("Country") = datatable_new.Rows(0).Item("Country").ToString
                datarow("Size") = datatable_new.Rows(0).Item("Size").ToString
                If Not datarow("Size") = "-" Then
                    datarow("Size") = CDbl(datatable_new.Rows(0).Item("Size")).ToString("#,###.####")
                End If
                datatable.Rows.Add(datarow)
            End If
        End If

        Session("ebook_promotion") = datatable
        free = Session("free")
        credits = Session("credits")

        If credits >= free Then
            ModalPopupPromotionThankyouMsg.Show()
        Else
            ModalPopupPromotionGetmoreMsg.Show()
        End If
    End Sub

    Protected Sub btn_next_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles btn_next.Click, btn_cancel.Click
        If Not IsNothing(Request.Cookies("myCookie_user")) Then
            Response.Redirect("Customer_Order_Internet.aspx")
        Else
            Response.Redirect("Customer_Information_Internet.aspx")
        End If
    End Sub

    Private Sub Class_client_nation()
        If Session("client_nation") Is Nothing Then
            Dim gen As New gen_nation
            gen.ip = Request.UserHostAddress()
            Session("client_nation") = gen.gen_ip_code
        End If
    End Sub

    Private Sub Class_clear_free()
        Session.Remove("credits")
        If Not Session("ebook_promotion") Is Nothing Then
            Dim dt As DataTable = Session("ebook_promotion")
            dt.Clear()
            Session("ebook_promotion") = dt
        End If
    End Sub

    Private Sub Class_callPopup()
        Dim free As String = Session("free")
        Dim credits As String = Session("credits")
        lblcredits.Text = CInt(CInt(free) - CInt(credits)).ToString
        ModalPopupPromotion.Show()
    End Sub

    Protected Sub btn_alertThankClose_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles btn_alertThankClose.Click
        If Not IsNothing(Request.Cookies("myCookie_user")) Then
            Response.Redirect("Customer_Order_Internet.aspx")
        Else
            Response.Redirect("Customer_Information_Internet.aspx")
        End If
    End Sub

    Protected Sub btn_alertMoreClose_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles btn_alertMoreClose.Click
        ModalPopupPromotionGetmoreMsg.Hide()
        Class_callPopup()
    End Sub

    Protected Sub btn_closeMsg1_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles btn_closeMsg1.Click
        ModalPopupPromotionMsg1.Hide()
    End Sub

    Protected Sub btn_closeMsg2_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles btn_closeMsg2.Click
        ModalPopupPromotionMsg2.Hide()
    End Sub

    Protected Sub btn_closeMsg3_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles btn_closeMsg3.Click
        ModalPopupPromotionMsg3.Hide()
    End Sub

End Class