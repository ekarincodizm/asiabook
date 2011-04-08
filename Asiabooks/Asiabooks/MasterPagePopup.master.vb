Imports System.Data
Imports Eordering.BusinessLogic
Imports Eordering.BusinessLogic.PageControl

Partial Class MasterPagePopup
    Inherits System.Web.UI.MasterPage
    Dim uCon As uConnect

    Private Sub SetMenu()
        Dim PageURL As String = Page.Request.Url.Segments(Page.Request.Url.Segments.Length - 1).Trim
        Select Case PageURL
            Case "Homepage.aspx"
                imgHome.Attributes.Clear()
                imgHome.ImageUrl = "images/Template/home_click.jpg"
                Session("Menu_Type") = "BOOK"
            Case "Thailand_Insight.aspx"
                imgThailand_Insight.Attributes.Clear()
                imgThailand_Insight.ImageUrl = "images/Template/thailand_insight_click.jpg"
                Session("Menu_Type") = "BOOK"
            Case "Bestseller.aspx"
                imgBestsellers.Attributes.Clear()
                imgBestsellers.ImageUrl = "images/Template/bestsellers_click.jpg"
                Session("Menu_Type") = "BOOK"
            Case "Coming_Soon.aspx"
                imgComing_Soon.Attributes.Clear()
                imgComing_Soon.ImageUrl = "images/Template/coming_soon_click.jpg"
                Session("Menu_Type") = "BOOK"
            Case "Books.aspx"
                imgBooks.Attributes.Clear()
                imgBooks.ImageUrl = "images/Template/books_click.jpg"
                Session("Menu_Type") = "BOOK"
            Case "shoppingCart_Internet.aspx"
                imgShopping.Attributes.Clear()
                imgShopping.ImageUrl = "images/Template/shopping_cart_click.jpg"
                Session("Menu_Type") = "BOOK"
            Case "Wishlist_internet.aspx"
                imgWish_List.Attributes.Clear()
                imgWish_List.ImageUrl = "images/Template/wish_list_click.jpg"
                Session("Menu_Type") = "BOOK"
            Case "Customer_Tracking_Internet.aspx"
                imgOrder_Status.Attributes.Clear()
                imgOrder_Status.ImageUrl = "images/Template/order_status_click.jpg"
                Session("Menu_Type") = "BOOK"
            Case "Customer_Order_Tracking_Internet.aspx"
                imgOrder_Status.Attributes.Clear()
                imgOrder_Status.ImageUrl = "images/Template/order_status_click.jpg"
                Session("Menu_Type") = "BOOK"
            Case "Store_Event.aspx"
                imgStores_Event.Attributes.Clear()
                imgStores_Event.ImageUrl = "images/Template/stores_event_click.jpg"
                Session("Menu_Type") = "BOOK"
            Case "My_Account.aspx"
                imgMyAccoung.Attributes.Clear()
                imgMyAccoung.ImageUrl = "images/Template/my_account_click.jpg"
                Session("Menu_Type") = "BOOK"
            Case "Customer_Profile.aspx"
                imgMyAccoung.Attributes.Clear()
                imgMyAccoung.ImageUrl = "images/Template/my_account_click.jpg"
                Session("Menu_Type") = "BOOK"
            Case "eBooks.aspx"
                imgeBooks.Attributes.Clear()
                imgeBooks.ImageUrl = "images/Template/ebooks_click.gif"
                Session("Menu_Type") = "EBOOK"
            Case "ebooks_main.aspx"
                imgeBooks.Attributes.Clear()
                imgeBooks.ImageUrl = "images/Template/ebooks_click.gif"
                Session("Menu_Type") = "EBOOK"
            Case "Magazine.aspx"
                imgMagazine.Attributes.Clear()
                imgMagazine.ImageUrl = "images/Template/magazine_click.jpg"
                Session("Menu_Type") = "MAGAZINE"
            Case "Online_Order.aspx"
                imgHelp.Attributes.Clear()
                imgHelp.ImageUrl = "images/Template/help_click.jpg"
                Session("Menu_Type") = "BOOK"
            Case "Store_Event_Detail.aspx"
                imgStores_Event.Attributes.Clear()
                imgStores_Event.ImageUrl = "images/Template/stores_event_click.jpg"
                Session("Menu_Type") = "BOOK"
        End Select

    End Sub
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        SetMenu()

        '/////////promptnow/////////
        '//////// get client ip ////////
        If Session("client_nation") Is Nothing Then
            Dim gen As New gen_nation
            Try
                gen.ip = Request.UserHostAddress()
                Session("client_nation") = gen.gen_ip_code

            Catch ex As Exception
                Session("client_nation") = "TH"
            End Try
        End If
        '///////promptnow end///////

        uCon = New uConnect
        Dim dt As New DataTable
        dt.Clear()
        dt = uFunction.getDataTable(uCon.conn, "select count(*) as count_useronline from ip_address")
        If dt.Rows.Count > 0 Then
            Me.lbUserActive.Text = dt.Rows(0).Item("count_useronline").ToString
        End If
        'SetMenu()
        'Me.lbUserActive.Text = Application("onlineuser").ToString()
        'Me.lbUserVisits.Text = Application("visituser").ToString()

	If Not IsPostBack Then
            ucMenu_Cat1.Menu_Type = Session("Menu_Type")
            CheckMember()

            If Not IsNothing(Request.Cookies("myCookie_user")) Then
                Dim hm As New HtmlMeta
                Dim head As HtmlHead = CType(Page.Header, HtmlHead)
                hm.Name = "DCS.dcsaut"
                hm.Content = Request.Cookies("myCookie_user")("UserName")
                head.Controls.Add(hm)
            Else
                Dim hm As New HtmlMeta
                Dim head As HtmlHead = CType(Page.Header, HtmlHead)
                hm.Name = "DCS.dcsaut"
                hm.Content = ""
                head.Controls.Add(hm)
            End If
        End If


    End Sub
    Private Sub CheckMember()
        If Not IsNothing(Request.Cookies("myCookie_user")) Then
            lnkRegister.Visible = False
            lnkSingIn.Visible = False
            lbl.Visible = True
            lblCustomerName.Visible = True
            lnkSing_Out.Visible = True
            lblCustomerName.Text = Request.Cookies("myCookie_user")("UserName")
            'ImagMyEbook.Visible = True
        Else
            lnkRegister.Visible = True
            lnkSingIn.Visible = True
            lbl.Visible = True
            lblCustomerName.Visible = False
            lnkSing_Out.Visible = False
            'ImagMyEbook.Visible = False
        End If
    End Sub
    Protected Sub imgBestsellers_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles imgBestsellers.Click

        Response.Redirect("Bestseller.aspx")
    End Sub

    Protected Sub imgHome_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles imgHome.Click

        Response.Redirect("Homepage.aspx")
    End Sub

    Protected Sub imgThailand_Insight_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles imgThailand_Insight.Click

        Response.Redirect("Thailand_Insight.aspx")
    End Sub

    Protected Sub imgComing_Soon_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles imgComing_Soon.Click

        Response.Redirect("Coming_Soon.aspx")
    End Sub

    Protected Sub imgBooks_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles imgBooks.Click

        Response.Redirect("Books.aspx")
    End Sub

    Protected Sub imgShopping_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles imgShopping.Click

        Response.Redirect("shoppingCart_Internet.aspx")
    End Sub

    Protected Sub imgWish_List_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles imgWish_List.Click

        Response.Redirect("Wishlist_internet.aspx")
    End Sub

    Protected Sub imgOrder_Status_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles imgOrder_Status.Click

        If Not IsNothing(Request.Cookies("myCookie_user")) Then
            Response.Redirect("Member_Tracking_Order.aspx")
        Else
            Session("CachePage") = "Member_Tracking_Order.aspx"
            Response.Redirect("My_Account.aspx")
        End If
    End Sub

    Protected Sub imgStores_Event_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles imgStores_Event.Click

        Response.Redirect("Store_Event.aspx")
    End Sub

    Protected Sub imgMyAccoung_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles imgMyAccoung.Click

        Response.Redirect("My_Account.aspx")
    End Sub

    Protected Sub lnkSing_Out_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lnkSing_Out.Click

        Response.Redirect("Sing_Out.aspx")
    End Sub

    Protected Sub lnkSingIn_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lnkSingIn.Click

        Response.Redirect("My_Account.aspx")
    End Sub

    Protected Sub lnkRegister_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lnkRegister.Click

        Response.Redirect("My_Account.aspx")
    End Sub

    Protected Sub lnkEdit_Profile_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lnkEdit_Profile.Click

        If Not IsNothing(Request.Cookies("myCookie_user")) Then
            Response.Redirect("Customer_Profile.aspx")
        Else
            Response.Redirect("My_Account.aspx")
        End If
    End Sub

    Protected Sub imgMagazine_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles imgMagazine.Click

        Response.Redirect("Magazine.aspx")
    End Sub

    Protected Sub imgeBooks_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles imgeBooks.Click

        'Response.Redirect("eBooks.aspx")
        'Response.Redirect("ebooks_main.aspx")
        Response.Redirect("landing_page/index.html")
    End Sub

    Protected Sub btnSearch_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles btnSearch.Click
        '/////////promptnow/////////
        '//////// get client ip ////////
        If Session("client_nation") Is Nothing Then
            Dim gen As New gen_nation
            gen.ip = Request.UserHostAddress()
            Session("client_nation") = gen.gen_ip_code
        End If
        '///////promptnow end///////
        Response.Redirect("Book_Search_Internet.aspx?keyword=" + txtFilter.Text + "")
    End Sub

    Protected Sub lnkAdvanced_search_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lnkAdvanced_search.Click

        Response.Redirect("Advanced_Search.aspx")
    End Sub

    Protected Sub imgHelp_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles imgHelp.Click

        Response.Redirect("Help.aspx")
    End Sub

    Protected Sub lnkForgot_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lnkForgot.Click

        Response.Redirect("My_Account.aspx")
    End Sub

    Protected Sub lnkTrack_Order_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lnkTrack_Order.Click

        If Not IsNothing(Request.Cookies("myCookie_user")) Then
            Response.Redirect("Member_Tracking_Order.aspx")
        Else
            Response.Redirect("Customer_Tracking_Internet.aspx")
        End If
    End Sub

    Protected Sub lnkCustomer_Ser_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lnkCustomer_Ser.Click

        Response.Redirect("Online_Order.aspx")
    End Sub

    Protected Sub lnkSite_Map_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lnkSite_Map.Click

        Response.Redirect("SiteMap.aspx")
    End Sub

    Protected Sub lnkShipping_Rate_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lnkShipping_Rate.Click
        Response.Redirect("Shipping_Rates.aspx")
    End Sub

    Protected Sub lnkMember_Ship_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lnkMember_Ship.Click
        Response.Redirect("Member_Ship.aspx")
    End Sub

    Protected Sub ImagMyEbook_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs)
        Response.Redirect("My_Ebook.aspx")
    End Sub
End Class

