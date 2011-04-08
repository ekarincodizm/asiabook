Imports Eordering.BusinessLogic
Imports System
Imports System.Data
Imports Eordering.BusinessLogic.PageControl
Imports System.Xml
Imports System.Xml.Linq
Imports System.Linq
Imports System.Globalization

Partial Class Book_SeeMore
    Inherits System.Web.UI.Page
    Private _Utility As New clsUtility
    Private bd As New Class_book_detail

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Me.Title = ConfigurationManager.AppSettings("SiteTitle").ToString & "Book search ::"
        If Not IsPostBack Then
            Try
                Session("BookSeeMoreDataList") = Nothing

                Me.lblPage_Name.Text = Request.QueryString("Page_Name").ToString
                Me.Getdata()
            Catch ex As Exception
                uScript.Alert(Me.Page, Me.GetType, ex.Message.ToString)
            End Try
        End If
    End Sub

    Private Sub Getdata()
        Dim pcontrol As New PageControl
        Dim strSql As String = ""
        Dim strsplit As String()
        Dim strpage_name As String = ""
        Dim strtype As String = ""
        Dim strgroup As String = ""
        Dim DataList As New DataTable

        Try
            strsplit = lblPage_Name.Text.Split("|")
            strpage_name = strsplit(0)
            strtype = strsplit(1)
            strgroup = strsplit(2).Replace("$", "&")

            If strpage_name = "Home" And strtype = "Bestsellers" And strgroup = "" Then
                DataList = Me.GetHome_Best(uXML.BooksBestSeller)

            ElseIf strpage_name = "Home" And strtype = "Bestsellers" And strgroup <> "" Then
                DataList = Me.GetHome_Best_Cat(uXML.BooksBestSeller, strgroup)

            ElseIf strpage_name = "Thailand_Insight" And strtype = "New_Releases" And strgroup = "" Then
                DataList = Me.GetHome_Thailand(uXML.ThailandInside)

            ElseIf strpage_name = "Thailand_Insight" And strtype = "New_Releases" And strgroup <> "" Then
                DataList = Me.GetHome_Thailand_Cat(uXML.ThailandInside, strgroup)

            ElseIf strpage_name = "Thailand_Insight" And strtype = "Recommended" And strgroup = "" Then
                DataList = Me.GetHome_Thailand_Recommended(uXML.BooksBestSeller)

            ElseIf strpage_name = "Thailand_Insight" And strtype = "Thailand_Bestsellers" And strgroup = "" Then
                DataList = Me.GetHome_Thailand_Bestseller(uXML.BooksBestSeller)

            ElseIf strpage_name = "Bestsellers" And strtype = "ThisWeek_Bestsellers" And strgroup = "" Then
                DataList = Me.GetHome_Best(uXML.BooksBestSeller)

            ElseIf strpage_name = "Bestsellers" And strtype = "New_Yourk_Bestseller" And strgroup = "" Then
                DataList = Me.GetBestseller_New_Yourk_Bestseller(uXML.NewYorkUSA)

            ElseIf strpage_name = "Bestsellers" And strtype = "USA_Today_Bestseller" And strgroup = "" Then
                DataList = Me.GetBestseller_USA_Today_Bestseller(uXML.NewYorkUSA)

            ElseIf strpage_name = "Coming_Soon" And strtype = "Next_Week" And strgroup = "" Then
                DataList = Me.GetComming_Soon_NextWeek(uXML.CommingSoonNextWeek)

            ElseIf strpage_name = "Coming_Soon" And strtype = "Next_Month" And strgroup = "" Then
                DataList = Me.GetComming_Soon_NextMonth(uXML.CommingSoon)

            ElseIf strpage_name = "Coming_Soon" And strtype = "Future_Release" And strgroup = "" Then
                DataList = Me.GetComming_Soon_FutureRelease(uXML.CommingSoon)

            ElseIf strpage_name = "Coming_Soon" And strtype = "Top5_PreOrder" And strgroup = "" Then
                DataList = Me.GetComming_Soon_Top5PreOrder(uXML.CommingSoon)

            ElseIf strpage_name = "Coming_Soon" And strtype = "Coming_Soon" And strgroup <> "" Then
                DataList = Me.GetComming_Soon_Cat(uXML.CommingSoon, strgroup)

            ElseIf strpage_name = "Bestsellers" And strtype = "Bestsellers" And strgroup <> "" Then
                DataList = Me.GetHome_Best_Cat(uXML.BooksBestSeller, strgroup)

            ElseIf strpage_name = "Books" And strtype = "Books" And strgroup <> "" Then
                DataList = Me.GetBooks_Cat(uXML.Books, strgroup)

            ElseIf strpage_name = "BookOfTheMonth" And strtype = "BookOfTheMonth" And strgroup = "" Then
                DataList = Me.GetBookOfTheMonth(uXML.BooksOfMonth, strgroup)

            ElseIf strpage_name = "Books" And strtype = "new_releases" And strgroup = "" Then
                DataList = Me.GetBooks_New_Releases(uXML.Books)

            ElseIf strpage_name = "Bargain" And strtype = "Bargain" And strgroup <> "" Then
                DataList = Me.GetBargain(uXML.BargainShockPrice, strgroup)

            ElseIf strpage_name = "Shock_Price" And strtype = "Shock_Price" And strgroup <> "" Then
                DataList = Me.GetShock_Price(uXML.BargainShockPrice, strgroup)

            ElseIf strpage_name = "Masterpage" And strtype = "Menu_Cat" And strgroup <> "" Then
                DataList = Me.GetMasterpage_Cat(uXML.BrownSubCat, strgroup)

            ElseIf strpage_name = "MemberFavioritesCat" And strtype = "Sub_Cat" And strgroup <> "" Then
                DataList = Me.GetMemberFavioritesCat(uXML.BrownSubCat, strgroup)

            ElseIf strpage_name = "Customer_Profile" And strtype = "Sub_Cat" And strgroup <> "" Then
                DataList = Me.GetMemberFavioritesCat(uXML.BrownSubCat, strgroup)

            ElseIf strpage_name = "Magazine" And strtype = "Top5_Magazine" And strgroup = "" Then
                DataList = Me.GetBooks_Top5_Magazine(uXML.Magazine)

            ElseIf strpage_name = "Masterpage" And strtype = "Menu_Cat_Head" And strgroup <> "" Then
                DataList = Me.GetMasterpage_Cat_Head(uXML.BrownSubCat, strgroup)

            ElseIf strpage_name = "Book_NewRelease" And strtype = "This_Week" And strgroup = "" Then
                DataList = Me.GetBook_NewRelease_This_Week(uXML.Book_NewRelease)

            ElseIf strpage_name = "Book_NewRelease" And strtype = "This_Month" And strgroup = "" Then
                DataList = Me.GetBook_NewRelease_This_Month(uXML.Book_NewRelease)

            ElseIf strpage_name = "Book_NewRelease" And strtype = "Featured_Items" And strgroup = "" Then
                DataList = Me.GetBook_NewRelease_Featured_Items(uXML.Book_NewRelease)

            Else
                DataList = Nothing

            End If

            Me.Label_Result.Text = pcontrol.ShowingResultSet(Me.Datagrid.CurrentPageIndex, Me.Datagrid.PageSize, DataList.Rows.Count)

            Datagrid.DataSource = DataList
            Datagrid.DataBind()

            If Not IsNothing(DataList) Then
                If DataList.Rows.Count <= 10 Then
                    Datagrid.PagerStyle.Visible = False
                End If
            End If


            Session("BookSeeMoreDataList") = DataList
        Catch ex As Exception
            Throw ex

        Finally
            DataList = Nothing
            pcontrol = Nothing
            strSql = Nothing
            strsplit = Nothing
            strpage_name = Nothing
            strtype = Nothing
            strgroup = Nothing

        End Try

    End Sub

    Private Function CreateDataTable() As DataTable
        Dim dt As New DataTable

        dt.Columns.Add(New DataColumn("isbn_13", System.Type.GetType("System.String")))
        dt.Columns.Add(New DataColumn("book_title", System.Type.GetType("System.String")))
        dt.Columns.Add(New DataColumn("author", System.Type.GetType("System.String")))
        dt.Columns.Add(New DataColumn("list_price", System.Type.GetType("System.Double")))
        dt.Columns.Add(New DataColumn("your_price", System.Type.GetType("System.Double")))
        dt.Columns.Add(New DataColumn("publisher_name", System.Type.GetType("System.String")))
        dt.Columns.Add(New DataColumn("price_save", System.Type.GetType("System.String")))
        dt.Columns.Add(New DataColumn("price_usd", System.Type.GetType("System.String")))
        dt.Columns.Add(New DataColumn("image", System.Type.GetType("System.String")))

        Return dt
    End Function

    Private Function GetHome_Best(ByVal strfile As String) As DataTable
        Dim xmlDoc As XElement
        Dim dt As New DataTable
        Dim dr As DataRow

        Try
            dt = CreateDataTable()
            xmlDoc = XElement.Load(strfile)

            Dim Items = From c In xmlDoc.Elements("BooksBestSeller") _
                        Where c.Element("type") = "Top10BestSeller_All_AB" _
                        And c.Element("name_display") = "ALL" _
                        Order By Convert.ToInt16(c.Element("orderby").Value) Ascending _
                        Select isbn_13 = c.Element("isbn_13").Value, _
                        book_title = c.Element("book_title").Value, _
                        author = c.Element("author").Value, _
                        list_price = CDbl(c.Element("list_price").Value.ToString).ToString("#,###,##0.00"), _
                        your_price = CDbl(c.Element("your_price").Value.ToString).ToString("#,###,##0.00"), _
                        publisher_name = c.Element("publisher_name").Value, _
                        price_save = "(Save " & c.Element("save_price").Value & "%)", _
                        price_usd = "US$ " & bd.callUsd(uXML.Currency, Convert.ToDouble(c.Element("your_price").Value)), _
                        Image = _Utility.GetImagePath(c.Element("image").Value)

            For Each item In Items
                dr = dt.NewRow
                dr("isbn_13") = item.isbn_13
                dr("book_title") = item.book_title
                dr("author") = item.author
                dr("list_price") = item.list_price
                dr("your_price") = item.your_price
                dr("publisher_name") = item.publisher_name
                dr("price_save") = item.price_save
                dr("price_usd") = item.price_usd
                dr("image") = item.Image

                dt.Rows.Add(dr)
            Next
            Return dt
        Catch ex As Exception
            Throw New Exception("GetHome_Best : " & ex.Message.ToString)
            Return Nothing
        Finally
            xmlDoc = Nothing
            dt = Nothing
            dr = Nothing
        End Try
    End Function
    Private Function GetHome_Best_Cat(ByVal strfile As String, ByVal cat_name As String) As DataTable
        Dim xmlDoc As XElement
        Dim dt As New DataTable
        Dim dr As DataRow

        Try
            dt = CreateDataTable()
            xmlDoc = XElement.Load(strfile)

            Dim Items = From c In xmlDoc.Elements("BooksBestSeller") _
                        Where c.Element("type") = "Top10BestSeller_All_AB" _
                        And c.Element("name_display") = cat_name _
                        Order By Convert.ToInt16(c.Element("OrderNo").Value) Ascending _
                        Select isbn_13 = c.Element("isbn_13").Value, _
                        book_title = c.Element("book_title").Value, _
                        author = c.Element("author").Value, _
                        list_price = CDbl(c.Element("list_price").Value.ToString).ToString("#,###,##0.00"), _
                        your_price = CDbl(c.Element("your_price").Value.ToString).ToString("#,###,##0.00"), _
                        publisher_name = c.Element("publisher_name").Value, _
                        price_save = "(Save " & c.Element("save_price").Value & "%)", _
                        price_usd = "US$ " & bd.callUsd(uXML.Currency, Convert.ToDouble(c.Element("your_price").Value)), _
                        image = _Utility.GetImagePath(c.Element("image").Value)

            For Each Item In Items
                dr = dt.NewRow
                dr("isbn_13") = Item.isbn_13
                dr("book_title") = Item.book_title
                dr("author") = Item.author
                dr("list_price") = Item.list_price
                dr("your_price") = Item.your_price
                dr("publisher_name") = Item.publisher_name
                dr("price_save") = Item.price_save
                dr("price_usd") = Item.price_usd
                dr("image") = Item.image

                dt.Rows.Add(dr)
            Next

            Return dt
        Catch ex As Exception
            Throw New Exception("GetHome_Best_Cat : " & ex.Message.ToString)
            Return Nothing
        Finally
            xmlDoc = Nothing
            dt = Nothing
            dr = Nothing
        End Try
    End Function

    Private Function GetHome_Thailand(ByVal strfile As String) As DataTable
        Dim xmlDoc As XElement
        Dim dt As New DataTable
        Dim dr As DataRow
        Dim dtDate As New DateTime

        Try
            dt = CreateDataTable()
            dtDate = Now.Date.AddDays(-30)
            xmlDoc = XElement.Load(strfile)

            Dim Items = From c In xmlDoc.Elements("ThailandInside") _
                        Where Date.ParseExact(c.Element("br_date").Value.ToString, "dd/MM/yyyy", Nothing) >= dtDate.Date _
                        Order By Convert.ToInt16(c.Element("OrderNo").Value) Ascending _
                        Select isbn_13 = c.Element("isbn_13").Value, _
                        book_title = c.Element("book_title").Value, _
                        author = c.Element("author").Value, _
                        list_price = CDbl(c.Element("list_price").Value.ToString).ToString("#,###,##0.00"), _
                        your_price = CDbl(c.Element("your_price").Value.ToString).ToString("#,###,##0.00"), _
                        publisher_name = c.Element("publisher_name").Value, _
                        price_save = "(Save " & c.Element("save_price").Value & "%)", _
                        price_usd = "US$ " & bd.callUsd(uXML.Currency, Convert.ToDouble(c.Element("your_price").Value)), _
                        image = _Utility.GetImagePath(c.Element("image").Value)

            For Each item In Items
                dr = dt.NewRow
                dr("isbn_13") = item.isbn_13
                dr("book_title") = item.book_title
                dr("author") = item.author
                dr("list_price") = item.list_price
                dr("your_price") = item.your_price
                dr("publisher_name") = item.publisher_name
                dr("price_save") = item.price_save
                dr("price_usd") = item.price_usd
                dr("image") = item.image

                dt.Rows.Add(dr)
            Next
            Return dt
        Catch ex As Exception
            Throw New Exception("GetHome_Thailand : " & ex.Message.ToString)
            Return Nothing
        Finally
            xmlDoc = Nothing
            dt = Nothing
            dr = Nothing
            dtDate = Nothing
        End Try
    End Function
    Private Function GetHome_Thailand_Cat(ByVal strfile As String, ByVal cat_name As String) As DataTable
        Dim xmlDoc As XElement
        Dim dt As New DataTable
        Dim dr As DataRow
        Dim dtDate As New DateTime

        Try
            dt = CreateDataTable()
            dtDate = Now.AddDays(-30)
            xmlDoc = XElement.Load(strfile)

            Dim Items = From c In xmlDoc.Elements("ThailandInside") _
                        Where c.Element("cat_code").Value = cat_name _
                              And Convert.ToInt16(c.Element("saleqty").Value) > 0 _
                        Order By Convert.ToInt16(c.Element("OrderNo").Value) Ascending _
                        Select isbn_13 = c.Element("isbn_13").Value, _
                        book_title = c.Element("book_title").Value, _
                        author = c.Element("author").Value, _
                        list_price = CDbl(c.Element("list_price").Value.ToString).ToString("#,###,##0.00"), _
                        your_price = CDbl(c.Element("your_price").Value.ToString).ToString("#,###,##0.00"), _
                        publisher_name = c.Element("publisher_name").Value, _
                        price_save = "(Save " & c.Element("save_price").Value & "%)", _
                        price_usd = "US$ " & bd.callUsd(uXML.Currency, Convert.ToDouble(c.Element("your_price").Value)), _
                        image = _Utility.GetImagePath(c.Element("image").Value)

            For Each item In Items
                dr = dt.NewRow
                dr("isbn_13") = item.isbn_13
                dr("book_title") = item.book_title
                dr("author") = item.author
                dr("list_price") = item.list_price
                dr("your_price") = item.your_price
                dr("publisher_name") = item.publisher_name
                dr("price_save") = item.price_save
                dr("price_usd") = item.price_usd
                dr("image") = item.image

                dt.Rows.Add(dr)
            Next
            Return dt
        Catch ex As Exception
            Throw New Exception("GetHome_Thailand_Cat : " & ex.Message.ToString)
            Return Nothing
        Finally
            xmlDoc = Nothing
            dt = Nothing
            dr = Nothing
            dtDate = Nothing
        End Try
    End Function
    Private Function GetHome_Thailand_Recommended(ByVal strfile As String) As DataTable
        Dim xmlDoc As XElement
        Dim dt As New DataTable
        Dim dr As DataRow

        Try
            dt = CreateDataTable()
            xmlDoc = XElement.Load(strfile)

            Dim Items = From c In xmlDoc.Elements("BooksBestSeller") _
                        Where c.Element("type") = "ThaiLandInsight_Recommended" _
                        Order By Convert.ToInt16(c.Element("OrderNo").Value) Ascending _
                        Select isbn_13 = c.Element("isbn_13").Value, _
                        book_title = c.Element("book_title").Value, _
                        author = c.Element("author").Value, _
                        list_price = CDbl(c.Element("list_price").Value.ToString).ToString("#,###,##0.00"), _
                        your_price = CDbl(c.Element("your_price").Value.ToString).ToString("#,###,##0.00"), _
                        publisher_name = c.Element("publisher_name").Value, _
                        price_save = "(Save " & c.Element("save_price").Value & "%)", _
                        price_usd = "US$ " & bd.callUsd(uXML.Currency, Convert.ToDouble(c.Element("your_price").Value)), _
                        image = _Utility.GetImagePath(c.Element("image").Value)

            For Each item In Items
                dr = dt.NewRow
                dr("isbn_13") = item.isbn_13
                dr("book_title") = item.book_title
                dr("author") = item.author
                dr("list_price") = item.list_price
                dr("your_price") = item.your_price
                dr("publisher_name") = item.publisher_name
                dr("price_save") = item.price_save
                dr("price_usd") = item.price_usd
                dr("image") = item.image

                dt.Rows.Add(dr)
            Next
            Return dt
        Catch ex As Exception
            Throw New Exception("GetHome_Thailand_Recommended : " & ex.Message.ToString)
            Return Nothing
        Finally
            xmlDoc = Nothing
            dt = Nothing
            dr = Nothing
        End Try
    End Function
    Private Function GetHome_Thailand_Bestseller(ByVal strfile As String) As DataTable
        Dim xmlDoc As XElement
        Dim dt As New DataTable
        Dim dr As DataRow

        Try
            dt = CreateDataTable()
            xmlDoc = XElement.Load(strfile)

            Dim Items = From c In xmlDoc.Elements("BooksBestSeller") _
                        Where c.Element("type") = "Top10BestSeller_All_AB" _
                            And c.Element("type_cat") = "SE. ASIA" _
                            Or c.Element("type_cat") = "TH" _
                        Order By c.Element("type_cat").Value Descending, _
                            Convert.ToInt16(c.Element("orderby").Value) Ascending _
                        Select isbn_13 = c.Element("isbn_13").Value, _
                        book_title = c.Element("book_title").Value, _
                        author = c.Element("author").Value, _
                        list_price = CDbl(c.Element("list_price").Value.ToString).ToString("#,###,##0.00"), _
                        your_price = CDbl(c.Element("your_price").Value.ToString).ToString("#,###,##0.00"), _
                        publisher_name = c.Element("publisher_name").Value, _
                        price_save = "(Save " & c.Element("save_price").Value & "%)", _
                        price_usd = "US$ " & bd.callUsd(uXML.Currency, Convert.ToDouble(c.Element("your_price").Value)), _
                        image = _Utility.GetImagePath(c.Element("image").Value)

            For Each item In Items
                dr = dt.NewRow
                dr("isbn_13") = item.isbn_13
                dr("book_title") = item.book_title
                dr("author") = item.author
                dr("list_price") = item.list_price
                dr("your_price") = item.your_price
                dr("publisher_name") = item.publisher_name
                dr("price_save") = item.price_save
                dr("price_usd") = item.price_usd
                dr("image") = item.image

                dt.Rows.Add(dr)
            Next
            Return dt
        Catch ex As Exception
            Throw New Exception("GetHome_Thailand_Bestseller : " & ex.Message.ToString)
            Return Nothing
        Finally
            xmlDoc = Nothing
            dt = Nothing
            dr = Nothing
        End Try
    End Function

    Private Function GetBestseller_USA_Today_Bestseller(ByVal strfile As String) As DataTable
        Dim xmlDoc As XElement
        Dim dt As New DataTable
        Dim dr As DataRow

        Try
            dt = CreateDataTable()
            xmlDoc = XElement.Load(strfile)

            Dim Items = From c In xmlDoc.Elements("NewYorkUSA") _
                        Where c.Element("type") = "USAToday" _
                        Order By Convert.ToInt16(c.Element("OrderNo").Value) Ascending _
                        Select isbn_13 = c.Element("isbn_13").Value, _
                        book_title = c.Element("book_title").Value, _
                        author = c.Element("author").Value, _
                        list_price = CDbl(c.Element("list_price").Value.ToString).ToString("#,###,##0.00"), _
                        your_price = CDbl(c.Element("your_price").Value.ToString).ToString("#,###,##0.00"), _
                        publisher_name = c.Element("publisher_name").Value, _
                        price_save = "(Save " & c.Element("save_price").Value & "%)", _
                        price_usd = "US$ " & bd.callUsd(uXML.Currency, Convert.ToDouble(c.Element("your_price").Value)), _
                        image = _Utility.GetImagePath(c.Element("image").Value)

            For Each item In Items
                dr = dt.NewRow
                dr("isbn_13") = item.isbn_13
                dr("book_title") = item.book_title
                dr("author") = item.author
                dr("list_price") = item.list_price
                dr("your_price") = item.your_price
                dr("publisher_name") = item.publisher_name
                dr("price_save") = item.price_save
                dr("price_usd") = item.price_usd
                dr("image") = item.image

                dt.Rows.Add(dr)
            Next
            Return dt
        Catch ex As Exception
            Throw New Exception("GetBestseller_USA_Today_Bestseller : " & ex.Message.ToString)
            Return Nothing
        Finally
            xmlDoc = Nothing
            dt = Nothing
            dr = Nothing
        End Try
    End Function
    Private Function GetBestseller_New_Yourk_Bestseller(ByVal strfile As String) As DataTable
        Dim xmlDoc As XElement
        Dim dt As New DataTable
        Dim dr As DataRow

        Try
            dt = CreateDataTable()
            xmlDoc = XElement.Load(strfile)

            Dim Items = From c In xmlDoc.Elements("NewYorkUSA") _
                        Where c.Element("type") = "NewYorkTime" _
                        Order By Convert.ToInt16(c.Element("OrderNo").Value) Ascending _
                        Select isbn_13 = c.Element("isbn_13").Value, _
                        book_title = c.Element("book_title").Value, _
                        author = c.Element("author").Value, _
                        list_price = CDbl(c.Element("list_price").Value.ToString).ToString("#,###,##0.00"), _
                        your_price = CDbl(c.Element("your_price").Value.ToString).ToString("#,###,##0.00"), _
                        publisher_name = c.Element("publisher_name").Value, _
                        price_save = "(Save " & c.Element("save_price").Value & "%)", _
                        price_usd = "US$ " & bd.callUsd(uXML.Currency, Convert.ToDouble(c.Element("your_price").Value)), _
                        image = _Utility.GetImagePath(c.Element("image").Value)

            For Each item In Items
                dr = dt.NewRow
                dr("isbn_13") = item.isbn_13
                dr("book_title") = item.book_title
                dr("author") = item.author
                dr("list_price") = item.list_price
                dr("your_price") = item.your_price
                dr("publisher_name") = item.publisher_name
                dr("price_save") = item.price_save
                dr("price_usd") = item.price_usd
                dr("image") = item.image

                dt.Rows.Add(dr)
            Next
            Return dt
        Catch ex As Exception
            Throw New Exception("GetBestseller_New_Yourk_Bestseller : " & ex.Message.ToString)
            Return Nothing
        Finally
            xmlDoc = Nothing
            dt = Nothing
            dr = Nothing
        End Try
    End Function

    Private Function GetComming_Soon_NextWeek(ByVal strfile As String) As DataTable
        Dim xmlDoc As XElement
        Dim dt As New DataTable
        Dim dr As DataRow

        Try
            dt = CreateDataTable()
            xmlDoc = XElement.Load(strfile)

            Dim Items = From c In xmlDoc.Elements("CommingSoonNextWeek") _
                        Order By Convert.ToInt16(c.Element("OrderNo").Value) Ascending _
                        Select isbn_13 = c.Element("isbn_13").Value, _
                        book_title = c.Element("book_title").Value, _
                        author = c.Element("author").Value, _
                        list_price = CDbl(c.Element("list_price").Value.ToString).ToString("#,###,##0.00"), _
                        your_price = CDbl(c.Element("your_price").Value.ToString).ToString("#,###,##0.00"), _
                        publisher_name = c.Element("publisher_name").Value, _
                        price_save = "(Save " & c.Element("save_price").Value & "%)", _
                        price_usd = "US$ " & bd.callUsd(uXML.Currency, Convert.ToDouble(c.Element("your_price").Value)), _
                        image = _Utility.GetImagePath(c.Element("image").Value)

            For Each item In Items
                dr = dt.NewRow
                dr("isbn_13") = item.isbn_13
                dr("book_title") = item.book_title
                dr("author") = item.author
                dr("list_price") = item.list_price
                dr("your_price") = item.your_price
                dr("publisher_name") = item.publisher_name
                dr("price_save") = item.price_save
                dr("price_usd") = item.price_usd
                dr("image") = item.image

                dt.Rows.Add(dr)
            Next
            Return dt
        Catch ex As Exception
            Throw New Exception("GetComming_Soon_NextWeek : " & ex.Message.ToString)
            Return Nothing
        Finally
            xmlDoc = Nothing
            dt = Nothing
            dr = Nothing
        End Try
    End Function
    Private Function GetComming_Soon_NextMonth(ByVal strfile As String) As DataTable
        Dim xmlDoc As XElement
        Dim dt As New DataTable
        Dim dr As DataRow

        Try
            dt = CreateDataTable()
            xmlDoc = XElement.Load(strfile)

            Dim Items = From c In xmlDoc.Elements("CommingSoon") _
                        Where c.Element("type").Value.ToLower = "nextmonth" _
                        Order By Convert.ToInt16(c.Element("OrderNo").Value) Ascending _
                        Select isbn_13 = c.Element("isbn_13").Value, _
                        book_title = c.Element("book_title").Value, _
                        author = c.Element("author").Value, _
                        list_price = CDbl(c.Element("list_price").Value.ToString).ToString("#,###,##0.00"), _
                        your_price = CDbl(c.Element("your_price").Value.ToString).ToString("#,###,##0.00"), _
                        publisher_name = c.Element("publisher_name").Value, _
                        price_save = "(Save " & c.Element("save_price").Value & "%)", _
                        price_usd = "US$ " & bd.callUsd(uXML.Currency, Convert.ToDouble(c.Element("your_price").Value)), _
                        image = _Utility.GetImagePath(c.Element("image").Value)

            For Each item In Items
                dr = dt.NewRow
                dr("isbn_13") = item.isbn_13
                dr("book_title") = item.book_title
                dr("author") = item.author
                dr("list_price") = item.list_price
                dr("your_price") = item.your_price
                dr("publisher_name") = item.publisher_name
                dr("price_save") = item.price_save
                dr("price_usd") = item.price_usd
                dr("image") = item.image

                dt.Rows.Add(dr)
            Next
            Return dt
        Catch ex As Exception
            Throw New Exception("GetComming_Soon_NextMonth : " & ex.Message.ToString)
            Return Nothing
        Finally
            xmlDoc = Nothing
            dt = Nothing
            dr = Nothing
        End Try
    End Function
    Private Function GetComming_Soon_FutureRelease(ByVal strfile As String) As DataTable
        Dim xmlDoc As XElement
        Dim dt As New DataTable
        Dim dr As DataRow

        Try
            dt = CreateDataTable()
            xmlDoc = XElement.Load(strfile)

            Dim Items = From c In xmlDoc.Elements("CommingSoon") _
                        Where c.Element("type").Value.ToLower = "futurerelease" _
                        Order By Convert.ToInt16(c.Element("OrderNo").Value) Ascending _
                        Select isbn_13 = c.Element("isbn_13").Value, _
                        book_title = c.Element("book_title").Value, _
                        author = c.Element("author").Value, _
                        list_price = CDbl(c.Element("list_price").Value.ToString).ToString("#,###,##0.00"), _
                        your_price = CDbl(c.Element("your_price").Value.ToString).ToString("#,###,##0.00"), _
                        publisher_name = c.Element("publisher_name").Value, _
                        price_save = "(Save " & c.Element("save_price").Value & "%)", _
                        price_usd = "US$ " & bd.callUsd(uXML.Currency, Convert.ToDouble(c.Element("your_price").Value)), _
                        image = _Utility.GetImagePath(c.Element("image").Value)

            For Each item In Items
                dr = dt.NewRow
                dr("isbn_13") = item.isbn_13
                dr("book_title") = item.book_title
                dr("author") = item.author
                dr("list_price") = item.list_price
                dr("your_price") = item.your_price
                dr("publisher_name") = item.publisher_name
                dr("price_save") = item.price_save
                dr("price_usd") = item.price_usd
                dr("image") = item.image

                dt.Rows.Add(dr)
            Next
            Return dt
        Catch ex As Exception
            Throw New Exception("GetComming_Soon_FutureRelease : " & ex.Message.ToString)
            Return Nothing
        Finally
            xmlDoc = Nothing
            dt = Nothing
            dr = Nothing
        End Try
    End Function
    Private Function GetComming_Soon_Top5PreOrder(ByVal strfile As String) As DataTable
        Dim xmlDoc As XElement
        Dim dt As New DataTable
        Dim dr As DataRow

        Try
            dt = CreateDataTable()
            xmlDoc = XElement.Load(strfile)

            Dim Items = From c In xmlDoc.Elements("CommingSoon") _
                        Order By Convert.ToInt16(c.Element("onorderqty").Value) Descending _
                        Select isbn_13 = c.Element("isbn_13").Value, _
                        book_title = c.Element("book_title").Value, _
                        author = c.Element("author").Value, _
                        list_price = CDbl(c.Element("list_price").Value.ToString).ToString("#,###,##0.00"), _
                        your_price = CDbl(c.Element("your_price").Value.ToString).ToString("#,###,##0.00"), _
                        publisher_name = c.Element("publisher_name").Value, _
                        price_save = "(Save " & c.Element("save_price").Value & "%)", _
                        price_usd = "US$ " & bd.callUsd(uXML.Currency, Convert.ToDouble(c.Element("your_price").Value)), _
                        image = _Utility.GetImagePath(c.Element("image").Value)

            For Each item In Items
                dr = dt.NewRow
                dr("isbn_13") = item.isbn_13
                dr("book_title") = item.book_title
                dr("author") = item.author
                dr("list_price") = item.list_price
                dr("your_price") = item.your_price
                dr("publisher_name") = item.publisher_name
                dr("price_save") = item.price_save
                dr("price_usd") = item.price_usd
                dr("image") = item.image

                dt.Rows.Add(dr)
            Next
            Return dt
        Catch ex As Exception
            Throw New Exception("GetComming_Soon_Top5PreOrder : " & ex.Message.ToString)
            Return Nothing
        Finally
            xmlDoc = Nothing
            dt = Nothing
            dr = Nothing
        End Try
    End Function
    Private Function GetComming_Soon_Cat(ByVal strfile As String, ByVal cat_name As String) As DataTable
        Dim xmlDoc As XElement
        Dim dt As New DataTable
        Dim dr As DataRow

        Try
            dt = CreateDataTable()
            xmlDoc = XElement.Load(strfile)

            Dim Items = From c In xmlDoc.Elements("CommingSoon") _
                        Where c.Element("cat_description").Value = cat_name _
                            And CStr(c.Element("type").Value) <> "" _
                        Order By Convert.ToInt16(c.Element("OrderNo").Value) Ascending _
                        Select isbn_13 = c.Element("isbn_13").Value, _
                        book_title = c.Element("book_title").Value, _
                        author = c.Element("author").Value, _
                        list_price = CDbl(c.Element("list_price").Value.ToString).ToString("#,###,##0.00"), _
                        your_price = CDbl(c.Element("your_price").Value.ToString).ToString("#,###,##0.00"), _
                        publisher_name = c.Element("publisher_name").Value, _
                        price_save = "(Save " & c.Element("save_price").Value & "%)", _
                        price_usd = "US$ " & bd.callUsd(uXML.Currency, Convert.ToDouble(c.Element("your_price").Value)), _
                        image = _Utility.GetImagePath(c.Element("image").Value)

            For Each item In Items
                dr = dt.NewRow
                dr("isbn_13") = item.isbn_13
                dr("book_title") = item.book_title
                dr("author") = item.author
                dr("list_price") = item.list_price
                dr("your_price") = item.your_price
                dr("publisher_name") = item.publisher_name
                dr("price_save") = item.price_save
                dr("price_usd") = item.price_usd
                dr("image") = item.image

                dt.Rows.Add(dr)
            Next
            Return dt
        Catch ex As Exception
            Throw New Exception("GetComming_Soon_Cat : " & ex.Message.ToString)
            Return Nothing
        Finally
            xmlDoc = Nothing
            dt = Nothing
            dr = Nothing
        End Try
    End Function

    Private Function GetBooks_Cat(ByVal strfile As String, ByVal cat_name As String) As DataTable
        Dim xmlDoc As XElement
        Dim dt As New DataTable
        Dim dr As DataRow

        Try
            dt = CreateDataTable()
            xmlDoc = XElement.Load(strfile)

            Dim Items = From c In xmlDoc.Elements("Books") _
                        Where c.Element("cat_description").Value = cat_name _
                            And CStr(c.Element("order_type").Value) <> "New-Title" _
                        Order By Convert.ToInt16(c.Element("OrderNo").Value) Ascending _
                        Select isbn_13 = c.Element("isbn_13").Value, _
                        book_title = c.Element("book_title").Value, _
                        author = c.Element("author").Value, _
                        list_price = CDbl(c.Element("list_price").Value.ToString).ToString("#,###,##0.00"), _
                        your_price = CDbl(c.Element("your_price").Value.ToString).ToString("#,###,##0.00"), _
                        publisher_name = c.Element("publisher_name").Value, _
                        price_save = "(Save " & c.Element("save_price").Value & "%)", _
                        price_usd = "US$ " & bd.callUsd(uXML.Currency, Convert.ToDouble(c.Element("your_price").Value)), _
                        image = _Utility.GetImagePath(c.Element("image").Value)

            For Each item In Items
                dr = dt.NewRow
                dr("isbn_13") = item.isbn_13
                dr("book_title") = item.book_title
                dr("author") = item.author
                dr("list_price") = item.list_price
                dr("your_price") = item.your_price
                dr("publisher_name") = item.publisher_name
                dr("price_save") = item.price_save
                dr("price_usd") = item.price_usd
                dr("image") = item.image

                dt.Rows.Add(dr)
            Next
            Return dt
        Catch ex As Exception
            Throw New Exception("GetBooks_Cat : " & ex.Message.ToString)
            Return Nothing
        Finally
            xmlDoc = Nothing
            dt = Nothing
            dr = Nothing
        End Try
    End Function
    Private Function GetBookOfTheMonth(ByVal strfile As String, ByVal cat_name As String) As DataTable
        Dim xmlDoc As XElement
        Dim dt As New DataTable
        Dim dr As DataRow

        Try
            dt = CreateDataTable()
            xmlDoc = XElement.Load(strfile)

            Dim Items = From c In xmlDoc.Elements("BooksOfMonth") _
                        Order By Convert.ToInt16(c.Element("OrderNo").Value) Ascending _
                        Select isbn_13 = c.Element("isbn_13").Value, _
                        book_title = c.Element("book_title").Value, _
                        author = c.Element("author").Value, _
                        list_price = CDbl(c.Element("list_price").Value.ToString).ToString("#,###,##0.00"), _
                        your_price = CDbl(c.Element("your_price").Value.ToString).ToString("#,###,##0.00"), _
                        publisher_name = c.Element("publisher_name").Value, _
                        price_save = "(Save " & c.Element("save_price").Value & "%)", _
                        price_usd = "US$ " & bd.callUsd(uXML.Currency, Convert.ToDouble(c.Element("your_price").Value)), _
                        image = _Utility.GetImagePath(c.Element("image").Value)

            For Each item In Items
                dr = dt.NewRow
                dr("isbn_13") = item.isbn_13
                dr("book_title") = item.book_title
                dr("author") = item.author
                dr("list_price") = item.list_price
                dr("your_price") = item.your_price
                dr("publisher_name") = item.publisher_name
                dr("price_save") = item.price_save
                dr("price_usd") = item.price_usd
                dr("image") = item.image

                dt.Rows.Add(dr)
            Next
            Return dt
        Catch ex As Exception
            Throw New Exception("GetBookOfTheMonth : " & ex.Message.ToString)
            Return Nothing
        Finally
            xmlDoc = Nothing
            dt = Nothing
            dr = Nothing
        End Try
    End Function
    Private Function GetBooks_New_Releases(ByVal strfile As String) As DataTable
        Dim xmlDoc As XElement
        Dim dt As New DataTable
        Dim dr As DataRow

        Try
            dt = CreateDataTable()
            xmlDoc = XElement.Load(strfile)

            Dim Items = From c In xmlDoc.Elements("Books") _
                        Where c.Element("type").Value.ToLower = "newreleases" _
                            And c.Element("order_type").Value.ToLower = "new-title" _
                        Order By Convert.ToInt16(c.Element("OrderNo").Value) Ascending _
                        Select isbn_13 = c.Element("isbn_13").Value, _
                        book_title = c.Element("book_title").Value, _
                        author = c.Element("author").Value, _
                        list_price = CDbl(c.Element("list_price").Value.ToString).ToString("#,###,##0.00"), _
                        your_price = CDbl(c.Element("your_price").Value.ToString).ToString("#,###,##0.00"), _
                        publisher_name = c.Element("publisher_name").Value, _
                        price_save = "(Save " & c.Element("save_price").Value & "%)", _
                        price_usd = "US$ " & bd.callUsd(uXML.Currency, Convert.ToDouble(c.Element("your_price").Value)), _
                        image = _Utility.GetImagePath(c.Element("image").Value)

            For Each item In Items
                dr = dt.NewRow
                dr("isbn_13") = item.isbn_13
                dr("book_title") = item.book_title
                dr("author") = item.author
                dr("list_price") = item.list_price
                dr("your_price") = item.your_price
                dr("publisher_name") = item.publisher_name
                dr("price_save") = item.price_save
                dr("price_usd") = item.price_usd
                dr("image") = item.image

                dt.Rows.Add(dr)
            Next
            Return dt
        Catch ex As Exception
            Throw New Exception("GetBooks_New_Releases : " & ex.Message.ToString)
            Return Nothing
        Finally
            xmlDoc = Nothing
            dt = Nothing
            dr = Nothing
        End Try
    End Function

    Private Function GetBargain(ByVal strfile As String, ByVal cat_name As String) As DataTable
        Dim xmlDoc As XElement
        Dim dt As New DataTable
        Dim dr As DataRow

        Try
            dt = CreateDataTable()
            xmlDoc = XElement.Load(strfile)

            Dim Items = From c In xmlDoc.Elements("BargainShockPrice") _
                        Where c.Element("item_disc_group").Value = cat_name _
                        Order By Convert.ToInt16(c.Element("OrderNo").Value) Ascending _
                        Select isbn_13 = c.Element("isbn_13").Value, _
                        book_title = c.Element("book_title").Value, _
                        author = c.Element("author").Value, _
                        list_price = CDbl(c.Element("list_price").Value.ToString).ToString("#,###,##0.00"), _
                        your_price = CDbl(c.Element("your_price").Value.ToString).ToString("#,###,##0.00"), _
                        publisher_name = c.Element("publisher_name").Value, _
                        price_save = "(Save " & c.Element("save_price").Value & "%)", _
                        price_usd = "US$ " & bd.callUsd(uXML.Currency, Convert.ToDouble(c.Element("your_price").Value)), _
                        image = _Utility.GetImagePath(c.Element("image").Value)

            For Each item In Items
                dr = dt.NewRow
                dr("isbn_13") = item.isbn_13
                dr("book_title") = item.book_title
                dr("author") = item.author
                dr("list_price") = item.list_price
                dr("your_price") = item.your_price
                dr("publisher_name") = item.publisher_name
                dr("price_save") = item.price_save
                dr("price_usd") = item.price_usd
                dr("image") = item.image

                dt.Rows.Add(dr)
            Next
            Return dt
        Catch ex As Exception
            Throw New Exception("GetBargain : " & ex.Message.ToString)
            Return Nothing
        Finally
            xmlDoc = Nothing
            dt = Nothing
            dr = Nothing
        End Try
    End Function
    Private Function GetShock_Price(ByVal strfile As String, ByVal cat_name As String) As DataTable
        Dim xmlDoc As XElement
        Dim dt As New DataTable
        Dim dr As DataRow

        Try
            dt = CreateDataTable()
            xmlDoc = XElement.Load(strfile)

            Dim Items = From c In xmlDoc.Elements("BargainShockPrice") _
                        Where c.Element("item_disc_group").Value = cat_name _
                        Order By Convert.ToInt16(c.Element("OrderNo").Value) Ascending _
                        Select isbn_13 = c.Element("isbn_13").Value, _
                        book_title = c.Element("book_title").Value, _
                        author = c.Element("author").Value, _
                        list_price = CDbl(c.Element("list_price").Value.ToString).ToString("#,###,##0.00"), _
                        your_price = CDbl(c.Element("your_price").Value.ToString).ToString("#,###,##0.00"), _
                        publisher_name = c.Element("publisher_name").Value, _
                        price_save = "(Save " & c.Element("save_price").Value & "%)", _
                        price_usd = "US$ " & bd.callUsd(uXML.Currency, Convert.ToDouble(c.Element("your_price").Value)), _
                        image = _Utility.GetImagePath(c.Element("image").Value)

            For Each item In Items
                dr = dt.NewRow
                dr("isbn_13") = item.isbn_13
                dr("book_title") = item.book_title
                dr("author") = item.author
                dr("list_price") = item.list_price
                dr("your_price") = item.your_price
                dr("publisher_name") = item.publisher_name
                dr("price_save") = item.price_save
                dr("price_usd") = item.price_usd
                dr("image") = item.image

                dt.Rows.Add(dr)
            Next
            Return dt
        Catch ex As Exception
            Throw New Exception("GetShock_Price : " & ex.Message.ToString)
            Return Nothing
        Finally
            xmlDoc = Nothing
            dt = Nothing
            dr = Nothing
        End Try
    End Function

    Private Function GetMasterpage_Cat(ByVal strfile As String, ByVal cat_name As String) As DataTable
        Dim xmlDoc As XElement
        Dim dt As New DataTable
        Dim dr As DataRow

        Try
            dt = CreateDataTable()
            xmlDoc = XElement.Load(strfile)

            Dim Items = From c In xmlDoc.Elements("BrownSubCat") _
                        Where c.Element("cat_code").Value = cat_name _
                        Order By Convert.ToInt16(c.Element("OrderNo").Value) Ascending _
                        Select isbn_13 = c.Element("isbn_13").Value, _
                        book_title = c.Element("book_title").Value, _
                        author = c.Element("author").Value, _
                        list_price = CDbl(c.Element("list_price").Value.ToString).ToString("#,###,##0.00"), _
                        your_price = CDbl(c.Element("your_price").Value.ToString).ToString("#,###,##0.00"), _
                        publisher_name = c.Element("publisher_name").Value, _
                        price_save = "(Save " & c.Element("save_price").Value & "%)", _
                        price_usd = "US$ " & bd.callUsd(uXML.Currency, Convert.ToDouble(c.Element("your_price").Value)), _
                        image = _Utility.GetImagePath(c.Element("image").Value)

            For Each item In Items
                dr = dt.NewRow
                dr("isbn_13") = item.isbn_13
                dr("book_title") = item.book_title
                dr("author") = item.author
                dr("list_price") = item.list_price
                dr("your_price") = item.your_price
                dr("publisher_name") = item.publisher_name
                dr("price_save") = item.price_save
                dr("price_usd") = item.price_usd
                dr("image") = item.image

                dt.Rows.Add(dr)
            Next
            Return dt
        Catch ex As Exception
            Throw New Exception("GetMasterpage_Cat : " & ex.Message.ToString)
            Return Nothing
        Finally
            xmlDoc = Nothing
            dt = Nothing
            dr = Nothing
        End Try
    End Function

    Private Function GetMemberFavioritesCat(ByVal strfile As String, ByVal cat_name As String) As DataTable
        Dim xmlDoc As XElement
        Dim dt As New DataTable
        Dim dr As DataRow

        Try
            dt = CreateDataTable()
            xmlDoc = XElement.Load(strfile)

            Dim Items = From c In xmlDoc.Elements("BrownSubCat") _
                        Where Left(c.Element("cat_code").Value, 1) = cat_name _
                        Order By Convert.ToInt16(c.Element("OrderNo").Value) Ascending _
                        Select isbn_13 = c.Element("isbn_13").Value, _
                        book_title = c.Element("book_title").Value, _
                        author = c.Element("author").Value, _
                        list_price = CDbl(c.Element("list_price").Value.ToString).ToString("#,###,##0.00"), _
                        your_price = CDbl(c.Element("your_price").Value.ToString).ToString("#,###,##0.00"), _
                        publisher_name = c.Element("publisher_name").Value, _
                        price_save = "(Save " & c.Element("save_price").Value & "%)", _
                        price_usd = "US$ " & bd.callUsd(uXML.Currency, Convert.ToDouble(c.Element("your_price").Value)), _
                        image = _Utility.GetImagePath(c.Element("image").Value)

            For Each item In Items
                dr = dt.NewRow
                dr("isbn_13") = item.isbn_13
                dr("book_title") = item.book_title
                dr("author") = item.author
                dr("list_price") = item.list_price
                dr("your_price") = item.your_price
                dr("publisher_name") = item.publisher_name
                dr("price_save") = item.price_save
                dr("price_usd") = item.price_usd
                dr("image") = item.image

                dt.Rows.Add(dr)
            Next
            Return dt
        Catch ex As Exception
            Throw New Exception("GetMasterpage_Cat : " & ex.Message.ToString)
            Return Nothing
        Finally
            xmlDoc = Nothing
            dt = Nothing
            dr = Nothing
        End Try
    End Function

    Private Function GetMasterpage_Cat_Head(ByVal strfile As String, ByVal cat_name As String) As DataTable
        Dim xmlDoc As XElement
        Dim dt As New DataTable
        Dim dr As DataRow

        Try
            dt = CreateDataTable()
            xmlDoc = XElement.Load(strfile)

            Dim Items = From c In xmlDoc.Elements("BrownSubCat") _
                        Where Left(c.Element("cat_code").Value, 1) = cat_name _
                        Order By Convert.ToInt16(c.Element("OrderNo").Value) Ascending _
                        Select isbn_13 = c.Element("isbn_13").Value, _
                        book_title = c.Element("book_title").Value, _
                        author = c.Element("author").Value, _
                        list_price = CDbl(c.Element("list_price").Value.ToString).ToString("#,###,##0.00"), _
                        your_price = CDbl(c.Element("your_price").Value.ToString).ToString("#,###,##0.00"), _
                        publisher_name = c.Element("publisher_name").Value, _
                        price_save = "(Save " & c.Element("save_price").Value & "%)", _
                        price_usd = "US$ " & bd.callUsd(uXML.Currency, Convert.ToDouble(c.Element("your_price").Value)), _
                        image = _Utility.GetImagePath(c.Element("image").Value)

            For Each item In Items
                dr = dt.NewRow
                dr("isbn_13") = item.isbn_13
                dr("book_title") = item.book_title
                dr("author") = item.author
                dr("list_price") = item.list_price
                dr("your_price") = item.your_price
                dr("publisher_name") = item.publisher_name
                dr("price_save") = item.price_save
                dr("price_usd") = item.price_usd
                dr("image") = item.image

                dt.Rows.Add(dr)
            Next
            Return dt
        Catch ex As Exception
            Throw New Exception("GetMasterpage_Cat : " & ex.Message.ToString)
            Return Nothing
        Finally
            xmlDoc = Nothing
            dt = Nothing
            dr = Nothing
        End Try
    End Function

    Private Function GetBook_NewRelease_This_Week(ByVal strfile As String) As DataTable
        Dim xmlDoc As XElement
        Dim dt As New DataTable
        Dim dr As DataRow

        Try
            dt = CreateDataTable()
            xmlDoc = XElement.Load(strfile)

            Dim Items = From c In xmlDoc.Elements("Book_NewRelease") _
                        Where c.Element("type").Value = "ThisWeek" _
                        Order By Convert.ToInt16(c.Element("OrderNo").Value) Ascending _
                        Select isbn_13 = c.Element("isbn_13").Value, _
                        book_title = c.Element("book_title").Value, _
                        author = c.Element("author").Value, _
                        list_price = CDbl(c.Element("list_price").Value.ToString).ToString("#,###,##0.00"), _
                        your_price = CDbl(c.Element("your_price").Value.ToString).ToString("#,###,##0.00"), _
                        publisher_name = c.Element("publisher_name").Value, _
                        price_save = "(Save " & c.Element("save_price").Value & "%)", _
                        price_usd = "US$ " & bd.callUsd(uXML.Currency, Convert.ToDouble(c.Element("your_price").Value)), _
                        image = _Utility.GetImagePath(c.Element("image").Value)

            For Each item In Items
                dr = dt.NewRow
                dr("isbn_13") = item.isbn_13
                dr("book_title") = item.book_title
                dr("author") = item.author
                dr("list_price") = item.list_price
                dr("your_price") = item.your_price
                dr("publisher_name") = item.publisher_name
                dr("price_save") = item.price_save
                dr("price_usd") = item.price_usd
                dr("image") = item.image

                dt.Rows.Add(dr)
            Next
            Return dt
        Catch ex As Exception
            Throw New Exception("GetComming_Soon_FutureRelease : " & ex.Message.ToString)
            Return Nothing
        Finally
            xmlDoc = Nothing
            dt = Nothing
            dr = Nothing
        End Try
    End Function
    Private Function GetBook_NewRelease_This_Month(ByVal strfile As String) As DataTable
        Dim xmlDoc As XElement
        Dim dt As New DataTable
        Dim dr As DataRow

        Try
            dt = CreateDataTable()
            xmlDoc = XElement.Load(strfile)

            Dim Items = From c In xmlDoc.Elements("Book_NewRelease") _
                        Where c.Element("type").Value = "ThisMonth" _
                        Order By Convert.ToInt16(c.Element("OrderNo").Value) Ascending _
                        Select isbn_13 = c.Element("isbn_13").Value, _
                        book_title = c.Element("book_title").Value, _
                        author = c.Element("author").Value, _
                        list_price = CDbl(c.Element("list_price").Value.ToString).ToString("#,###,##0.00"), _
                        your_price = CDbl(c.Element("your_price").Value.ToString).ToString("#,###,##0.00"), _
                        publisher_name = c.Element("publisher_name").Value, _
                        price_save = "(Save " & c.Element("save_price").Value & "%)", _
                        price_usd = "US$ " & bd.callUsd(uXML.Currency, Convert.ToDouble(c.Element("your_price").Value)), _
                        image = _Utility.GetImagePath(c.Element("image").Value)

            For Each item In Items
                dr = dt.NewRow
                dr("isbn_13") = item.isbn_13
                dr("book_title") = item.book_title
                dr("author") = item.author
                dr("list_price") = item.list_price
                dr("your_price") = item.your_price
                dr("publisher_name") = item.publisher_name
                dr("price_save") = item.price_save
                dr("price_usd") = item.price_usd
                dr("image") = item.image

                dt.Rows.Add(dr)
            Next
            Return dt
        Catch ex As Exception
            Throw New Exception("GetComming_Soon_FutureRelease : " & ex.Message.ToString)
            Return Nothing
        Finally
            xmlDoc = Nothing
            dt = Nothing
            dr = Nothing
        End Try
    End Function
    Private Function GetBook_NewRelease_Featured_Items(ByVal strfile As String) As DataTable
        Dim xmlDoc As XElement
        Dim dt As New DataTable
        Dim dr As DataRow

        Try
            dt = CreateDataTable()
            xmlDoc = XElement.Load(strfile)

            Dim Items = From c In xmlDoc.Elements("Book_NewRelease") _
                        Where c.Element("type").Value = "FeaturedItems" _
                        Order By Convert.ToInt16(c.Element("OrderNo").Value) Ascending _
                        Select isbn_13 = c.Element("isbn_13").Value, _
                        book_title = c.Element("book_title").Value, _
                        author = c.Element("author").Value, _
                        list_price = CDbl(c.Element("list_price").Value.ToString).ToString("#,###,##0.00"), _
                        your_price = CDbl(c.Element("your_price").Value.ToString).ToString("#,###,##0.00"), _
                        publisher_name = c.Element("publisher_name").Value, _
                        price_save = "(Save " & c.Element("save_price").Value & "%)", _
                        price_usd = "US$ " & bd.callUsd(uXML.Currency, Convert.ToDouble(c.Element("your_price").Value)), _
                        image = _Utility.GetImagePath(c.Element("image").Value)

            For Each item In Items
                dr = dt.NewRow
                dr("isbn_13") = item.isbn_13
                dr("book_title") = item.book_title
                dr("author") = item.author
                dr("list_price") = item.list_price
                dr("your_price") = item.your_price
                dr("publisher_name") = item.publisher_name
                dr("price_save") = item.price_save
                dr("price_usd") = item.price_usd
                dr("image") = item.image

                dt.Rows.Add(dr)
            Next
            Return dt
        Catch ex As Exception
            Throw New Exception("GetComming_Soon_FutureRelease : " & ex.Message.ToString)
            Return Nothing
        Finally
            xmlDoc = Nothing
            dt = Nothing
            dr = Nothing
        End Try
    End Function

    Protected Sub Datagrid_ItemDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.DataGridItemEventArgs) Handles Datagrid.ItemDataBound
        If e.Item.ItemType = ListItemType.AlternatingItem Or e.Item.ItemType = ListItemType.Item Then
            Dim lblList_Price_H As Label = e.Item.FindControl("lblList_Price_H")
            Dim lblList_Price_D As Label = e.Item.FindControl("lblList_Price_D")
            Dim lblYour_Price_D As Label = e.Item.FindControl("lblYour_Price_D")
            Dim lblSave_Price As Label = e.Item.FindControl("lblSave_Price")

            If lblList_Price_D.Text = lblYour_Price_D.Text Then
                lblList_Price_H.Visible = False
                lblList_Price_D.Visible = False
                lblSave_Price.Visible = False
            Else
                lblList_Price_D.Font.Strikeout = True
            End If

        End If
    End Sub

    Protected Sub Datagrid_PageIndexChanged(ByVal source As Object, ByVal e As System.Web.UI.WebControls.DataGridPageChangedEventArgs) Handles Datagrid.PageIndexChanged
        Dim pcontrol As New PageControl
        Dim dt As New DataTable

        Try
            Me.Datagrid.CurrentPageIndex = e.NewPageIndex

            If Session("BookSeeMoreDataList") Is Nothing Then
                Me.Getdata()
            Else
                dt = Session("BookSeeMoreDataList")

                Me.Label_Result.Text = pcontrol.ShowingResultSet(Me.Datagrid.CurrentPageIndex, Me.Datagrid.PageSize, dt.Rows.Count)
                Me.Datagrid.DataSource = dt
                Me.Datagrid.DataBind()
            End If
        Catch ex As Exception
            uScript.Alert(Me.Page, Me.GetType, ex.Message.ToString)

        Finally
            dt = Nothing
            pcontrol = Nothing
        End Try
    End Sub
    Private Function GetBooks_Top5_Magazine(ByVal strfile As String) As DataTable
        Dim xmlDoc As XElement
        Dim dt As New DataTable
        Dim dr As DataRow

        Try
            dt = CreateDataTable()
            xmlDoc = XElement.Load(strfile)

            Dim Items = From c In xmlDoc.Elements("Magazine") _
                        Order By Convert.ToInt16(c.Element("OrderNo").Value) Ascending _
                        Select isbn_13 = c.Element("isbn_13").Value, _
                        book_title = c.Element("book_title").Value, _
                        author = c.Element("author").Value, _
                        list_price = CDbl(c.Element("list_price").Value.ToString).ToString("#,###,##0.00"), _
                        your_price = CDbl(c.Element("your_price").Value.ToString).ToString("#,###,##0.00"), _
                        publisher_name = c.Element("publisher_name").Value, _
                        price_save = "(Save " & c.Element("save_price").Value & "%)", _
                        price_usd = "US$ " & bd.callUsd(uXML.Currency, Convert.ToDouble(c.Element("your_price").Value)), _
                        image = _Utility.GetImagePath(c.Element("image").Value)

            For Each item In Items
                dr = dt.NewRow
                dr("isbn_13") = item.isbn_13
                dr("book_title") = item.book_title
                dr("author") = item.author
                dr("list_price") = item.list_price
                dr("your_price") = item.your_price
                dr("publisher_name") = item.publisher_name
                dr("price_save") = item.price_save
                dr("price_usd") = item.price_usd
                dr("image") = item.image

                dt.Rows.Add(dr)
            Next
            Return dt
        Catch ex As Exception
            Throw New Exception("GetComming_Soon_Top5PreOrder : " & ex.Message.ToString)
            Return Nothing
        Finally
            xmlDoc = Nothing
            dt = Nothing
            dr = Nothing
        End Try
    End Function
    'Private Function sqlHome_Best_Cat(ByVal cat_name As String) As String
    '    Dim strsql As String = ""
    '    strsql &= " select isbn_13,book_title,author,convert(numeric(18,2),[list price]) as list_price,convert(numeric(18,2),[your price]) as your_price,publisher_name, "
    '    strsql &= " '(Save '+convert(varchar,convert(numeric(18,0),[%Save]))+'%)' as price_save,image "
    '    strsql &= " from v_BooksBestSeller"
    '    strsql &= " WHERE [type]='Top10BestSeller_All_AB' and [Name display]  = '" + cat_name + "'"
    '    strsql &= " order by [orderby] "
    '    Return strsql
    'End Function
    'Private Function sqlHome_Best() As String
    '    Dim strsql As String = ""
    '    strsql &= " select isbn_13,book_title,author,convert(numeric(18,2),[list price]) as list_price,convert(numeric(18,2),[your price]) as your_price,publisher_name, "
    '    strsql &= " '(Save '+convert(varchar,convert(numeric(18,0),[%Save]))+'%)' as price_save,image "
    '    strsql &= " from v_BooksBestSeller"
    '    strsql &= " WHERE [type]='Top10BestSeller_All_AB' and [type_cat]  = 'all'"
    '    strsql &= " order by [orderby] "
    '    Return strsql
    'End Function
    'Private Function sqlHome_Thailand() As String
    '    Dim strsql As String = ""
    '    strsql &= " select isbn_13,book_title,author,convert(numeric(18,2),[list price]) as list_price,convert(numeric(18,2),[your price]) as your_price,publisher_name, "
    '    strsql &= " '(Save '+convert(varchar,convert(numeric(18,0),[%Save]))+'%)' as price_save,image "
    '    strsql &= " from V_ThailandInside"
    '    strsql &= " where br_date >= getdate()-30"
    '    strsql &= " order by br_date desc ,StockQTY desc "
    '    Return strsql
    'End Function
    'Private Function sqlHome_Thailand_Cat(ByVal cat_name As String) As String
    '    Dim strsql As String = ""
    '    strsql &= " select isbn_13,book_title,author,convert(numeric(18,2),[list price]) as list_price,convert(numeric(18,2),[your price]) as your_price,publisher_name, "
    '    strsql &= " '(Save '+convert(varchar,convert(numeric(18,0),[%Save]))+'%)' as price_save,image "
    '    strsql &= " from V_ThailandInside"
    '    strsql &= " where [cat_code] = '" + cat_name + "' and [saleqty] > 0"
    '    strsql &= " order by [saleqty] desc,[stockQTY] desc"
    '    Return strsql
    'End Function
    'Private Function sqlHome_Thailand_Recommended() As String
    '    Dim strsql As String = ""
    '    strsql &= " select isbn_13,book_title,author,convert(numeric(18,2),[list price]) as list_price,convert(numeric(18,2),[your price]) as your_price,publisher_name, "
    '    strsql &= " '(Save '+convert(varchar,convert(numeric(18,0),[%Save]))+'%)' as price_save,image "
    '    strsql &= " from v_BooksBestSeller"
    '    strsql &= " WHERE [type]='ThaiLandInsight_Recommended' "
    '    strsql &= " order by [orderby] "
    '    Return strsql
    'End Function
    'Private Function sqlHome_Thailand_Bestseller() As String
    '    Dim strsql As String = ""
    '    strsql &= " select isbn_13,book_title,author,convert(numeric(18,2),[list price]) as list_price,convert(numeric(18,2),[your price]) as your_price,publisher_name, "
    '    strsql &= " '(Save '+convert(varchar,convert(numeric(18,0),[%Save]))+'%)' as price_save,image "
    '    strsql &= " from v_BooksBestSeller"
    '    strsql &= " WHERE [type]='Top10BestSeller_All_AB' and [type_cat]  in ('SE. ASIA','TH') "
    '    strsql &= " order by [type_cat] desc,[orderby] "
    '    Return strsql
    'End Function
    'Private Function sqlBestseller_USA_Today_Bestseller() As String
    '    Dim strsql As String = ""
    '    strsql &= " select isbn_13,book_title,author,convert(numeric(18,2),[list price]) as list_price,convert(numeric(18,2),[your price]) as your_price,publisher_name, "
    '    strsql &= " '(Save '+convert(varchar,convert(numeric(18,0),[%Save]))+'%)' as price_save,image "
    '    strsql &= " from v_NewYorkUSA"
    '    strsql &= " WHERE [type]= 'USAToday' "
    '    Return strsql
    'End Function
    'Private Function sqlBestseller_New_Yourk_Bestseller() As String
    '    Dim strsql As String = ""
    '    strsql &= " select isbn_13,book_title,author,convert(numeric(18,2),[list price]) as list_price,convert(numeric(18,2),[your price]) as your_price,publisher_name, "
    '    strsql &= " '(Save '+convert(varchar,convert(numeric(18,0),[%Save]))+'%)' as price_save,image "
    '    strsql &= " from v_NewYorkUSA"
    '    strsql &= " WHERE [type]= 'NewYorkTime' "
    '    Return strsql
    'End Function
    'Private Function sqlComing_Soon_NextWeek() As String
    '    Dim strsql As String = ""
    '    strsql &= " select isbn_13,book_title,author,convert(numeric(18,2),[list price]) as list_price,convert(numeric(18,2),[your price]) as your_price,publisher_name, "
    '    strsql &= " '(Save '+convert(varchar,convert(numeric(18,0),[%Save]))+'%)' as price_save,image "
    '    strsql &= " from v_CommingSoon_nextweek"
    '    Return strsql
    'End Function
    'Private Function sqlComing_Soon_NextMonth() As String
    '    Dim strsql As String = ""
    '    strsql &= " select isbn_13,book_title,author,convert(numeric(18,2),[list price]) as list_price,convert(numeric(18,2),[your price]) as your_price,publisher_name, "
    '    strsql &= " '(Save '+convert(varchar,convert(numeric(18,0),[%Save]))+'%)' as price_save,image "
    '    strsql &= " from v_CommingSoon "
    '    strsql &= " WHERE [type] = 'nextmonth' order by  desc"
    '    Return strsql
    'End Function
    'Private Function sqlComing_Soon_FutureRelease() As String
    '    Dim strsql As String = ""
    '    strsql &= " select isbn_13,book_title,author,convert(numeric(18,2),[list price]) as list_price,convert(numeric(18,2),[your price]) as your_price,publisher_name, "
    '    strsql &= " '(Save '+convert(varchar,convert(numeric(18,0),[%Save]))+'%)' as price_save,image "
    '    strsql &= " from v_CommingSoon"
    '    strsql &= " WHERE [type] = 'FutureRelease' order by OnOrderQTY desc"
    '    Return strsql
    'End Function
    'Private Function sqlComing_Soon_Top5PreOrder() As String
    '    Dim strsql As String = ""
    '    strsql &= " select isbn_13,book_title,author,convert(numeric(18,2),[list price]) as list_price,convert(numeric(18,2),[your price]) as your_price,publisher_name, "
    '    strsql &= " '(Save '+convert(varchar,convert(numeric(18,0),[%Save]))+'%)' as price_save,image "
    '    strsql &= " from v_CommingSoon"
    '    strsql &= " order by OnOrderQTY desc"
    '    Return strsql
    'End Function
    'Private Function sqlComing_Soon_Cat(ByVal cat_name As String) As String
    '    Dim strsql As String = ""
    '    strsql &= " select isbn_13,book_title,author,convert(numeric(18,2),[list price]) as list_price,convert(numeric(18,2),[your price]) as your_price,publisher_name, "
    '    strsql &= " '(Save '+convert(varchar,convert(numeric(18,0),[%Save]))+'%)' as price_save,image "
    '    strsql &= " from v_CommingSoon"
    '    strsql &= " where [cat_description] = '" + cat_name + "' and [type] is not null "
    '    strsql &= " order by [onorderqty] desc "
    '    Return strsql
    'End Function
    'Private Function sqlBooks_Cat(ByVal cat_name As String) As String
    '    Dim strsql As String = ""
    '    strsql &= " select isbn_13,book_title,author,convert(numeric(18,2),[list price]) as list_price,convert(numeric(18,2),[your price]) as your_price,publisher_name, "
    '    strsql &= " '(Save '+convert(varchar,convert(numeric(18,0),[%Save]))+'%)' as price_save,image "
    '    strsql &= " from v_book"
    '    strsql &= " where [cat_description] = '" + cat_name + "' and [order type] <> 'New-Title' "
    '    strsql &= " order by saleqty desc,stockqty desc "
    '    Return strsql
    'End Function
    'Private Function sqlBookOfTheMonth() As String
    '    Dim strsql As String = ""
    '    strsql &= " select isbn_13,book_title,author,convert(numeric(18,2),[list price]) as list_price,convert(numeric(18,2),[your price]) as your_price,publisher_name, "
    '    strsql &= " '(Save '+convert(varchar,convert(numeric(18,0),[%Save]))+'%)' as price_save,image "
    '    strsql &= " from V_BOM "
    '    strsql &= " order by [starting_display] desc , orderby"
    '    Return strsql
    'End Function
    'Private Function sqlBooks_new_releases() As String
    '    Dim strsql As String = ""
    '    strsql &= " select isbn_13,book_title,author,convert(numeric(18,2),[list price]) as list_price,convert(numeric(18,2),[your price]) as your_price,publisher_name, "
    '    strsql &= " '(Save '+convert(varchar,convert(numeric(18,0),[%Save]))+'%)' as price_save,image "
    '    strsql &= " from V_Book  "
    '    strsql &= " where [type] = 'NewReleases' and [order type] = 'New-Title' "
    '    strsql &= " order by stockqty desc"
    '    Return strsql
    'End Function
    'Private Function sqlBargain(ByVal cat_name As String) As String
    '    Dim strsql As String = ""
    '    strsql &= " select isbn_13,book_title,author,convert(numeric(18,2),[list price]) as list_price,convert(numeric(18,2),[your price]) as your_price,publisher_name, "
    '    strsql &= " '(Save '+convert(varchar,convert(numeric(18,0),[%Save]))+'%)' as price_save,image "
    '    strsql &= " from v_Bargain_ShockPrice"
    '    strsql &= " where [Item Disc_ Group] = '" + cat_name + "'"
    '    strsql &= " order by [stockqty] desc "
    '    Return strsql
    'End Function
    'Private Function sqlShock_Price(ByVal cat_name As String) As String
    '    Dim strsql As String = ""
    '    strsql &= " select isbn_13,book_title,author,convert(numeric(18,2),[list price]) as list_price,convert(numeric(18,2),[your price]) as your_price,publisher_name, "
    '    strsql &= " '(Save '+convert(varchar,convert(numeric(18,0),[%Save]))+'%)' as price_save,image "
    '    strsql &= " from v_Bargain_ShockPrice"
    '    strsql &= " where [Item Disc_ Group] = '" + cat_name + "'"
    '    strsql &= " order by [stockqty] desc "
    '    Return strsql
    'End Function
    'Private Function sqlMasterpage_Cat(ByVal cat_name As String) As String
    '    Dim strsql As String = ""
    '    strsql &= " select isbn_13,book_title,author,convert(numeric(18,2),[list price]) as list_price,convert(numeric(18,2),[your price]) as your_price,publisher_name, "
    '    strsql &= " '(Save '+convert(varchar,convert(numeric(18,0),[%Save]))+'%)' as price_save,image "
    '    strsql &= " from tbt_Brown_SubCat"
    '    strsql &= " where Cat_Code = '" + cat_name + "'"
    '    Return strsql
    'End Function

    Protected Sub Datagrid_DeleteCommand(ByVal source As Object, ByVal e As System.Web.UI.WebControls.DataGridCommandEventArgs) Handles Datagrid.DeleteCommand
        Dim isbn As String = e.CommandArgument
        Book_WishList(isbn)
    End Sub
    Private Sub Book_WishList(ByVal isbn As String)
        Dim datatable As New DataTable
        bd.keyword_1 = isbn
        bd.sales_channel = "INTERNET"
        datatable = bd._dt_book_detail

        check_stock_book(datatable)
        add_book_to_wish(datatable)
    End Sub

    Private Sub check_stock_book(ByVal datatable As DataTable)
        bd = New Class_book_detail
        Dim isbn As String = datatable.Rows(0).Item("isbn_13").ToString
        Dim source As String = datatable.Rows(0).Item("source").ToString
        Dim weight As String = datatable.Rows(0).Item("weight").ToString

        If weight = "0" Then
            Response.Redirect("BooksNot_Found.aspx?Meassge=Data not weight")
        Else
            If source = "Asiabooks" Then
                bd.Status = "AB"
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
                    bd.Jobber_Status = "INDENT"
                Else
                    bd.Jobber_Status = "AB"

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
                        bd.Jobber_Status = "AB"
                        bd.Status = "AB"
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

            bd.keyword_1 = isbn.Trim
            If Not (IsNumeric("1") And 1 > 0) Then
                ScriptManager.RegisterClientScriptBlock(Me.Page, Me.GetType, "Alert", "alert('Quantity is not Valid');", True)
                Exit Sub
            Else
                bd.keyword_Qty = CInt("1")
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
                    ScriptManager.RegisterClientScriptBlock(Me.Page, Me.GetType, "Alert", "alert('Quantity of ISBN : " + bd.keyword_1 + " is not enough,Please contact staff');", True)
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

End Class
