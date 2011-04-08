Imports Eordering.BusinessLogic
Imports System
Imports System.Data
Imports Eordering.BusinessLogic.PageControl
Imports System.Linq
Imports System.Xml
Imports System.Xml.Linq

Partial Class uc_ucBooks
    Inherits System.Web.UI.UserControl
    Private bd As New Class_book_detail
    Private _Utility As New clsUtility
    Private uCon As uConnect

    Private Sub binddata_book(ByVal cat_name As String)
        Dim str_para As String()
        Dim strpage_name As String = ""
        Dim strcat_name As String = ""
        Dim Datalist As New Object

        Try
            str_para = cat_name.Split("|")
            strpage_name = str_para(0)
            strcat_name = str_para(1)

            Select Case strpage_name
                Case "Home"
                    Datalist = Me.Top6_Home(strcat_name, uXML.BooksBestSeller)

                    Me.lblhead.Visible = True
                    Me.lblhead.Text = str_para(1)
                    Me.lblcat_name.Visible = False
                    Me.lnkMore.HRef = "~/Book_SeeMore.aspx?Page_Name=Home|Bestsellers|" + strcat_name.Replace("&", "$") + ""

                Case "Bestsellers"
                    Datalist = Me.Top6_Home(strcat_name, uXML.BooksBestSeller)

                    Me.lblhead.Visible = True
                    Me.lblhead.Text = "BESTSELLERS IN "
                    Me.lblcat_name.Text = strcat_name
                    Me.lblcat_name.Visible = True
                    Me.lnkMore.HRef = "~/Book_SeeMore.aspx?Page_Name=Bestsellers|Bestsellers|" + strcat_name.Replace("&", "$") + ""

                Case "Thailand_Insight"
                    Datalist = Me.Top6_Thailand(strcat_name, uXML.ThailandInside)

                    Me.lblhead.Visible = True
                    Me.lblhead.Text = "THAILAND INSIGHT ON "
                    Me.lblcat_name.Visible = True
                    Me.lblcat_name.Text = Me.Top1_Thailand_Desc(strcat_name, uXML.ThailandInside)
                    Me.lnkMore.HRef = "~/Book_SeeMore.aspx?Page_Name=Thailand_Insight|New_Releases|" + strcat_name.Replace("&", "$") + ""

                Case "Books"
                    Datalist = Me.Top6_Book(strcat_name, uXML.Books)

                    Me.lblhead.Visible = True
                    Me.lblhead.Text = str_para(1)
                    Me.lblcat_name.Visible = False
                    Me.lnkMore.HRef = "~/Book_SeeMore.aspx?Page_Name=Books|Books|" + strcat_name.Replace("&", "$") + ""

                Case "Coming_Soon"
                    Datalist = Me.Top6_ComingSoon(strcat_name, uXML.CommingSoon)
                    Me.lblhead.Visible = True
                    Me.lblhead.Text = "COMING SOON IN "
                    Me.lblcat_name.Visible = True
                    Me.lblcat_name.Text = Me.Top1_ComingSoon_Desc(strcat_name, uXML.CommingSoon)
                    Me.lnkMore.HRef = "~/Book_SeeMore.aspx?Page_Name=Coming_Soon|Coming_Soon|" + strcat_name.Replace("&", "$") + ""

                Case "Bargain"
                    Datalist = Me.Top6_BargainShockPrice(strcat_name, uXML.BargainShockPrice)
                    lblhead.Visible = True
                    lblhead.Text = str_para(2)
                    lblcat_name.Visible = False
                    lnkMore.HRef = "~/Book_SeeMore.aspx?Page_Name=Bargain|Bargain|" + strcat_name.Replace("&", "$") + ""

                Case "Shock_Price"
                    Datalist = Me.Top6_BargainShockPrice(strcat_name, uXML.BargainShockPrice)
                    lblhead.Visible = True
                    lblhead.Text = str_para(2)
                    lblcat_name.Visible = False
                    lnkMore.HRef = "~/Book_SeeMore.aspx?Page_Name=Shock_Price|Shock_Price|" + strcat_name.Replace("&", "$") + ""

                Case "Customer_Profile"
                    Datalist = Me.Top6_MemberFavioritesCat(strcat_name, uXML.BrownSubCat)
                    Dim dt_cat As New DataTable
                    uCon = New uConnect
                    dt_cat = uFunction.getDataTable(uCon.conn, "select * from dbo.Category where Active = 'Y' and code = '" + strcat_name + "'")
                    If dt_cat.Rows.Count > 0 Then
                        lblhead.Visible = True
                        lblhead.Text = dt_cat.Rows(0).Item("Description").ToString
                    Else
                        lblhead.Visible = False
                    End If

                    lblcat_name.Visible = False
                    lnkMore.HRef = "~/Book_SeeMore.aspx?Page_Name=Customer_Profile|Sub_Cat|" + strcat_name.Replace("&", "$") + ""

                Case "Magazine"
                    Datalist = Me.Top6_Magazine(strcat_name, uXML.Magazine)
                    Me.lblhead.Visible = False
                    'Me.lblhead.Text = "COMING SOON IN "
                    Me.lblcat_name.Visible = True
                    Me.lblcat_name.Text = Me.Top1_Magazine_Desc(strcat_name, uXML.Magazine)
                    Me.lnkMore.HRef = "~/Magazine_SeeMore.aspx?Page_Name=Magazine|Magazine|" + strcat_name.Replace("&", "$") + ""

                Case "Magazine_Detail"
                    Datalist = Me.Top6_Magazine_Datil(uXML.Magazine)
                    Me.lblhead.Visible = False
                    Me.lblcat_name.Visible = False
                    Me.lnkMore.HRef = "~/Magazine_SeeMore.aspx?Page_Name=Magazine|Magazine|" + strcat_name.Replace("&", "$") + ""

                Case "Bestsellers_UK"
                    Datalist = Me.GetBestsellers_UK(strcat_name, uXML.NewYorkUSA)
                    Me.lblhead.Visible = True
                    Me.lblhead.Text = "UK Bestsellers "
                    Me.lblcat_name.Visible = True
                    Me.lblcat_name.Text = "(" + strcat_name + ")"
                    Me.lnkMore.Visible = False
                    Me.imgSeemore.Visible = False

                Case "Bestsellers_NewYorkTime"
                    Datalist = Me.GetBestsellers_NewYorkTime(strcat_name, uXML.NewYorkUSA)
                    Me.lblhead.Visible = True
                    Me.lblhead.Text = "New York Times "
                    Me.lblcat_name.Visible = True
                    Me.lblcat_name.Text = "(" + strcat_name + ")"
                    Me.lnkMore.Visible = False
                    Me.imgSeemore.Visible = False

                Case Else
                    Datalist = Nothing

            End Select

            Me.lvBooks.DataSource = Datalist
            Me.lvBooks.DataBind()
        Catch ex As Exception
            Throw ex
        Finally
            str_para = Nothing
            strpage_name = Nothing
            strcat_name = Nothing
            Datalist = Nothing
        End Try
    End Sub
  
    Private Function Top6_Home(ByVal cat_name As String, ByVal strfile As String) As Object
        Dim xmlDoc As XElement

        Try
            xmlDoc = XElement.Load(strfile)

            Dim Items = From c In xmlDoc.Elements("BooksBestSeller") _
                        Where c.Element("type") = "Top10BestSeller_All_AB" _
                        And c.Element("name_display") = cat_name _
                        Order By Convert.ToInt16(c.Element("OrderNo").Value) Ascending _
                        Select isbn_13 = c.Element("isbn_13").Value, _
                        image = _Utility.GetImagePath_Book(c.Element("image").Value), _
                        book_title = IIf(c.Element("book_title").Value.Length > 50, Left(c.Element("book_title").Value, 50) & "...", c.Element("book_title").Value), _
                        author = IIf(c.Element("author").Value.Length > 20, Left(c.Element("author").Value, 20) & "...", c.Element("author").Value), _
                        selling_price = CDbl(c.Element("list_price").Value.ToString).ToString("#,###,##0.00"), _
                        your_price = CDbl(c.Element("your_price").Value.ToString).ToString("#,###,##0.00"), _
                        price_usd = bd.callUsd(uXML.Currency, Convert.ToDouble(c.Element("your_price").Value)), _
                        save_price = c.Element("save_price").Value, _
                        book_title_full = c.Element("book_title").Value, _
                        author_full = c.Element("author").Value

            Return Items.Take(6)
        Catch ex As Exception
            Throw New Exception("Top6_Home : " & ex.Message.ToString)
            Return Nothing
        Finally
            xmlDoc = Nothing
        End Try
    End Function

    Private Function Top6_Thailand(ByVal cat_name As String, ByVal strfile As String) As Object
        Dim xmlDoc As XElement

        Try
            xmlDoc = XElement.Load(strfile)

            Dim Items = From c In xmlDoc.Elements("ThailandInside") _
                        Where Convert.ToInt16(c.Element("saleqty").Value) > 0 _
                              And c.Element("cat_code") = cat_name _
                        Order By Convert.ToInt16(c.Element("OrderNo").Value) Ascending _
                        Select isbn_13 = c.Element("isbn_13").Value, _
                        image = _Utility.GetImagePath_Book(c.Element("image").Value), _
                        book_title = IIf(c.Element("book_title").Value.Length > 50, Left(c.Element("book_title").Value, 50) & "...", c.Element("book_title").Value), _
                        author = IIf(c.Element("author").Value.Length > 20, Left(c.Element("author").Value, 20) & "...", c.Element("author").Value), _
                        selling_price = CDbl(c.Element("list_price").Value.ToString).ToString("#,###,##0.00"), _
                        your_price = CDbl(c.Element("your_price").Value.ToString).ToString("#,###,##0.00"), _
                        price_usd = bd.callUsd(uXML.Currency, Convert.ToDouble(c.Element("your_price").Value)), _
                        save_price = c.Element("save_price").Value, _
                        book_title_full = c.Element("book_title").Value, _
                        author_full = c.Element("author").Value

            Return Items.Take(6)
        Catch ex As Exception
            Throw New Exception("Top6_Thailand : " & ex.Message.ToString)
            Return Nothing
        Finally
            xmlDoc = Nothing
        End Try
    End Function
    Private Function Top1_Thailand_Desc(ByVal cat_name As String, ByVal strfile As String) As String
        Dim xmlDoc As XElement

        Try
            xmlDoc = XElement.Load(strfile)

            Dim Items = From c In xmlDoc.Elements("ThailandInside") _
                        Where Convert.ToInt16(c.Element("saleqty").Value) > 0 _
                              And c.Element("cat_code") = cat_name _
                        Order By Convert.ToInt16(c.Element("OrderNo").Value) Ascending _
                        Select isbn_13 = c.Element("isbn_13").Value, _
                        cat_description = c.Element("cat_description").Value

            Return Items.First.cat_description.ToString
        Catch ex As Exception
            Throw New Exception("Top1_Thailand_Desc : " & ex.Message.ToString)
            Return ""
        Finally
            xmlDoc = Nothing
        End Try
    End Function

    Private Function Top6_Book(ByVal cat_name As String, ByVal strfile As String) As Object
        Dim xmlDoc As XElement

        Try
            xmlDoc = XElement.Load(strfile)

            Dim Items = From c In xmlDoc.Elements("Books") _
                        Where c.Element("order_type") <> "New-Title" _
                              And c.Element("cat_description") = cat_name _
                        Order By Convert.ToInt16(c.Element("OrderNo").Value) Ascending _
                        Select isbn_13 = c.Element("isbn_13").Value, _
                        image = _Utility.GetImagePath_Book(c.Element("image").Value), _
                        book_title = IIf(c.Element("book_title").Value.Length > 50, Left(c.Element("book_title").Value, 50) & "...", c.Element("book_title").Value), _
                        author = IIf(c.Element("author").Value.Length > 20, Left(c.Element("author").Value, 20) & "...", c.Element("author").Value), _
                        selling_price = CDbl(c.Element("list_price").Value.ToString).ToString("#,###,##0.00"), _
                        your_price = CDbl(c.Element("your_price").Value.ToString).ToString("#,###,##0.00"), _
                        price_usd = bd.callUsd(uXML.Currency, Convert.ToDouble(c.Element("your_price").Value)), _
                        save_price = c.Element("save_price").Value, _
                        book_title_full = c.Element("book_title").Value, _
                        author_full = c.Element("author").Value

            Return Items.Take(6)
        Catch ex As Exception
            Throw New Exception("Top6_Book : " & ex.Message.ToString)
            Return Nothing
        Finally
            xmlDoc = Nothing
        End Try
    End Function

    Private Function Top6_ComingSoon(ByVal cat_name As String, ByVal strfile As String) As Object
        Dim xmlDoc As XElement

        Try
            xmlDoc = XElement.Load(strfile)

            Dim Items = From c In xmlDoc.Elements("CommingSoon") _
                        Where c.Element("type") <> "" _
                              And c.Element("cat_description") = cat_name _
                        Order By Convert.ToInt16(c.Element("OrderNo").Value) Ascending _
                        Select isbn_13 = c.Element("isbn_13").Value, _
                        image = _Utility.GetImagePath_Book(c.Element("image").Value), _
                        book_title = IIf(c.Element("book_title").Value.Length > 50, Left(c.Element("book_title").Value, 50) & "...", c.Element("book_title").Value), _
                        author = IIf(c.Element("author").Value.Length > 20, Left(c.Element("author").Value, 20) & "...", c.Element("author").Value), _
                        selling_price = CDbl(c.Element("list_price").Value.ToString).ToString("#,###,##0.00"), _
                        your_price = CDbl(c.Element("your_price").Value.ToString).ToString("#,###,##0.00"), _
                        price_usd = bd.callUsd(uXML.Currency, Convert.ToDouble(c.Element("your_price").Value)), _
                        save_price = c.Element("save_price").Value, _
                        book_title_full = c.Element("book_title").Value, _
                        author_full = c.Element("author").Value

            Return Items.Take(6)
        Catch ex As Exception
            Throw New Exception("Top6_ComingSoon : " & ex.Message.ToString)
            Return Nothing
        Finally
            xmlDoc = Nothing
        End Try
    End Function
    Private Function Top1_ComingSoon_Desc(ByVal cat_name As String, ByVal strfile As String) As String
        Dim xmlDoc As XElement

        Try
            xmlDoc = XElement.Load(strfile)

            Dim Items = From c In xmlDoc.Elements("CommingSoon") _
                        Where c.Element("type") <> "" _
                              And c.Element("cat_description") = cat_name _
                        Order By Convert.ToInt16(c.Element("OrderNo").Value) Ascending _
                        Select isbn_13 = c.Element("isbn_13").Value, _
                        cat_description = c.Element("cat_description").Value

            Return Items.First.cat_description.ToString
        Catch ex As Exception
            Throw New Exception("Top1_ComingSoon_Desc : " & ex.Message.ToString)
            Return ""
        Finally
            xmlDoc = Nothing
        End Try
    End Function

    Private Function Top6_Magazine(ByVal cat_name As String, ByVal strfile As String) As Object
        Dim xmlDoc As XElement

        Try
            xmlDoc = XElement.Load(strfile)

            Dim Items = From c In xmlDoc.Elements("Magazine") _
                        Where c.Element("Cat_Code") = cat_name _
                        Order By Convert.ToInt16(c.Element("OrderNo").Value) Ascending _
                        Select isbn_13 = c.Element("isbn_13").Value, _
                        image = _Utility.GetImagePath_Book(c.Element("image").Value), _
                        book_title = IIf(c.Element("book_title").Value.Length > 50, Left(c.Element("book_title").Value, 50) & "...", c.Element("book_title").Value), _
                        author = IIf(c.Element("author").Value.Length > 20, Left(c.Element("author").Value, 20) & "...", c.Element("author").Value), _
                        selling_price = CDbl(c.Element("list_price").Value.ToString).ToString("#,###,##0.00"), _
                        your_price = CDbl(c.Element("your_price").Value.ToString).ToString("#,###,##0.00"), _
                        price_usd = bd.callUsd(uXML.Currency, Convert.ToDouble(c.Element("your_price").Value)), _
                        save_price = c.Element("save_price").Value, _
                        book_title_full = c.Element("book_title").Value, _
                        author_full = c.Element("author").Value

            Return Items.Take(6)
        Catch ex As Exception
            Throw New Exception("Top6_Magazine : " & ex.Message.ToString)
            Return Nothing
        Finally
            xmlDoc = Nothing
        End Try
    End Function
    Private Function Top6_Magazine_Datil(ByVal strfile As String) As Object
        Dim xmlDoc As XElement

        Try
            xmlDoc = XElement.Load(strfile)

            Dim Items = From c In xmlDoc.Elements("Magazine") _
                        Order By Convert.ToInt16(c.Element("OrderNo").Value) Ascending _
                        Select isbn_13 = c.Element("isbn_13").Value, _
                        image = _Utility.GetImagePath_Book(c.Element("image").Value), _
                        book_title = IIf(c.Element("book_title").Value.Length > 50, Left(c.Element("book_title").Value, 50) & "...", c.Element("book_title").Value), _
                        author = IIf(c.Element("author").Value.Length > 20, Left(c.Element("author").Value, 20) & "...", c.Element("author").Value), _
                        selling_price = CDbl(c.Element("list_price").Value.ToString).ToString("#,###,##0.00"), _
                        your_price = CDbl(c.Element("your_price").Value.ToString).ToString("#,###,##0.00"), _
                        price_usd = bd.callUsd(uXML.Currency, Convert.ToDouble(c.Element("your_price").Value)), _
                        save_price = c.Element("save_price").Value, _
                        book_title_full = c.Element("book_title").Value, _
                        author_full = c.Element("author").Value

            Return Items.Take(6)
        Catch ex As Exception
            Throw New Exception("Top6_Magazine : " & ex.Message.ToString)
            Return Nothing
        Finally
            xmlDoc = Nothing
        End Try
    End Function
    Private Function Top1_Magazine_Desc(ByVal cat_name As String, ByVal strfile As String) As String
        Dim xmlDoc As XElement

        Try
            xmlDoc = XElement.Load(strfile)

            Dim Items = From c In xmlDoc.Elements("Magazine") _
                        Where c.Element("Cat_Code") = cat_name _
                        Order By Convert.ToInt16(c.Element("OrderNo").Value) Ascending _
                        Select isbn_13 = c.Element("isbn_13").Value, _
                        cat_description = c.Element("Cat_Description").Value

            Return Items.First.cat_description.ToString
        Catch ex As Exception
            Throw New Exception("Top1_Magazine_Desc : " & ex.Message.ToString)
            Return ""
        Finally
            xmlDoc = Nothing
        End Try
    End Function

    Private Function Top6_BargainShockPrice(ByVal cat_name As String, ByVal strfile As String) As Object
        Dim xmlDoc As XElement

        Try
            xmlDoc = XElement.Load(strfile)

            Dim Items = From c In xmlDoc.Elements("BargainShockPrice") _
                        Where c.Element("item_disc_group") = cat_name _
                        Order By Convert.ToInt16(c.Element("OrderNo").Value) Ascending _
                        Select isbn_13 = c.Element("isbn_13").Value, _
                        image = _Utility.GetImagePath_Book(c.Element("image").Value), _
                        book_title = IIf(c.Element("book_title").Value.Length > 50, Left(c.Element("book_title").Value, 50) & "...", c.Element("book_title").Value), _
                        author = IIf(c.Element("author").Value.Length > 20, Left(c.Element("author").Value, 20) & "...", c.Element("author").Value), _
                        selling_price = CDbl(c.Element("list_price").Value.ToString).ToString("#,###,##0.00"), _
                        your_price = CDbl(c.Element("your_price").Value.ToString).ToString("#,###,##0.00"), _
                        price_usd = bd.callUsd(uXML.Currency, Convert.ToDouble(c.Element("your_price").Value)), _
                        save_price = c.Element("save_price").Value, _
                        book_title_full = c.Element("book_title").Value, _
                        author_full = c.Element("author").Value

            Return Items.Take(6)
        Catch ex As Exception
            Throw New Exception("Top6_BargainShockPrice : " & ex.Message.ToString)
            Return Nothing
        Finally
            xmlDoc = Nothing
        End Try
    End Function
    Private Function Top6_MemberFavioritesCat(ByVal cat_name As String, ByVal strfile As String) As Object
        Dim xmlDoc As XElement

        Try
            xmlDoc = XElement.Load(strfile)

            Dim Items = From c In xmlDoc.Elements("BrownSubCat") _
                        Where Left(c.Element("cat_code").Value, 1) = cat_name _
                        Order By Convert.ToInt16(c.Element("OrderNo").Value) Ascending _
                        Select isbn_13 = c.Element("isbn_13").Value, _
                        image = _Utility.GetImagePath_Book(c.Element("image").Value), _
                        book_title = IIf(c.Element("book_title").Value.Length > 50, Left(c.Element("book_title").Value, 50) & "...", c.Element("book_title").Value), _
                        author = IIf(c.Element("author").Value.Length > 20, Left(c.Element("author").Value, 20) & "...", c.Element("author").Value), _
                        selling_price = CDbl(c.Element("list_price").Value.ToString).ToString("#,###,##0.00"), _
                        your_price = CDbl(c.Element("your_price").Value.ToString).ToString("#,###,##0.00"), _
                        price_usd = bd.callUsd(uXML.Currency, Convert.ToDouble(c.Element("your_price").Value)), _
                        save_price = c.Element("save_price").Value, _
                        book_title_full = c.Element("book_title").Value, _
                        author_full = c.Element("author").Value

            Return Items.Take(6)
        Catch ex As Exception
            Throw New Exception("Top6_BargainShockPrice : " & ex.Message.ToString)
            Return Nothing
        Finally
            xmlDoc = Nothing
        End Try
    End Function

    Private Function GetBestsellers_UK(ByVal cat_name As String, ByVal strfile As String) As Object
        Dim xmlDoc As XElement

        Try
            xmlDoc = XElement.Load(strfile)

            Dim Items = From c In xmlDoc.Elements("NewYorkUSA") _
                        Where CStr(c.Element("type")) = "UK Bestsellers" _
                        And CStr(c.Element("type_cat")) = cat_name _
                        Order By Convert.ToInt16(c.Element("OrderNo").Value) Ascending _
                        Select isbn_13 = c.Element("isbn_13").Value, _
                        image = _Utility.GetImagePath_Book(c.Element("image").Value), _
                        book_title = IIf(c.Element("book_title").Value.Length > 50, Left(c.Element("book_title").Value, 50) & "...", c.Element("book_title").Value), _
                        author = IIf(c.Element("author").Value.Length > 20, Left(c.Element("author").Value, 20) & "...", c.Element("author").Value), _
                        selling_price = CDbl(c.Element("list_price").Value.ToString).ToString("#,###,##0.00"), _
                        your_price = IIf(c.Element("your_price").Value = "0.00", CDbl(c.Element("list_price").Value.ToString).ToString("#,###,##0.00"), CDbl(c.Element("your_price").Value.ToString).ToString("#,###,##0.00")), _
                        price_usd = IIf(c.Element("your_price").Value = "0.00", bd.callUsd(uXML.Currency, Convert.ToDouble(c.Element("list_price").Value)), bd.callUsd(uXML.Currency, Convert.ToDouble(c.Element("your_price").Value))), _
                        save_price = c.Element("save_price").Value, _
                        book_title_full = c.Element("book_title").Value, _
                        author_full = c.Element("author").Value

            Return Items.Take(6)
        Catch ex As Exception
            Throw New Exception("Top6_BargainShockPrice : " & ex.Message.ToString)
            Return Nothing
        Finally
            xmlDoc = Nothing
        End Try
    End Function

    Private Function GetBestsellers_NewYorkTime(ByVal cat_name As String, ByVal strfile As String) As Object
        Dim xmlDoc As XElement

        Try
            xmlDoc = XElement.Load(strfile)

            Dim Items = From c In xmlDoc.Elements("NewYorkUSA") _
                        Where c.Element("type") = "NewYorkTime" _
                        And c.Element("type_cat") = cat_name _
                        Order By Convert.ToInt16(c.Element("OrderNo").Value) Ascending _
                        Select isbn_13 = c.Element("isbn_13").Value, _
                        image = _Utility.GetImagePath_Book(c.Element("image").Value), _
                        book_title = IIf(c.Element("book_title").Value.Length > 50, Left(c.Element("book_title").Value, 50) & "...", c.Element("book_title").Value), _
                        author = IIf(c.Element("author").Value.Length > 20, Left(c.Element("author").Value, 20) & "...", c.Element("author").Value), _
                        selling_price = CDbl(c.Element("list_price").Value.ToString).ToString("#,###,##0.00"), _
                        your_price = IIf(c.Element("your_price").Value = "0.00", CDbl(c.Element("list_price").Value.ToString).ToString("#,###,##0.00"), CDbl(c.Element("your_price").Value.ToString).ToString("#,###,##0.00")), _
                        price_usd = IIf(c.Element("your_price").Value = "0.00", bd.callUsd(uXML.Currency, Convert.ToDouble(c.Element("list_price").Value)), bd.callUsd(uXML.Currency, Convert.ToDouble(c.Element("your_price").Value))), _
                        save_price = c.Element("save_price").Value, _
                        book_title_full = c.Element("book_title").Value, _
                        author_full = c.Element("author").Value

            Return Items.Take(6)
        Catch ex As Exception
            Throw New Exception("Top6_BargainShockPrice : " & ex.Message.ToString)
            Return Nothing
        Finally
            xmlDoc = Nothing
        End Try
    End Function

#Region "Property"

    Property cat_name() As String
        Get
            Return 0
        End Get
        Set(ByVal value As String)
            binddata_book(value)
        End Set
    End Property
#End Region

    'Private Function sqlHome(ByVal cat_name As String) As String
    '    Dim strsql As String = ""
    '    strsql &= " select top(6) isbn_13, left(book_title,50)+'...'  as book_title ,left(author,10)+'...'  as author ,image,"
    '    strsql &= " convert(numeric(18,2), [List Price]) as selling_price, convert(numeric(18,2), [Your Price]) as [Your Price] "
    '    strsql &= " ,convert(numeric(18,0),[%Save]) as [%Save] "
    '    strsql &= " from v_BooksBestSeller"
    '    strsql &= " WHERE [type]='Top10BestSeller_All_AB'"
    '    strsql &= " and [Name display]  = '" + cat_name + "'"
    '    strsql &= " order by [orderby]"
    '    Return strsql
    'End Function
    'Private Function sqlThailand(ByVal cat_name As String) As String
    '    Dim strsql As String = ""
    '    strsql &= " select top(6) isbn_13, left(book_title,50)+'...'  as book_title ,left(author,10)+'...'  as author ,image,cat_description,"
    '    strsql &= " convert(numeric(18,2), [List Price]) as selling_price, convert(numeric(18,2), [Your Price]) as [Your Price],convert(numeric(18,0),[%Save]) as [%Save]"
    '    strsql &= " from v_ThailandInside "
    '    strsql &= " WHERE "
    '    strsql &= " [cat_code]  = '" + cat_name + "' and [saleqty] > 0"
    '    strsql &= " order by [saleqty] desc,[stockQTY] desc"
    '    Return strsql
    'End Function
    'Private Function sqlBooks_Cat(ByVal cat_name As String) As String
    '    Dim strsql As String = ""
    '    strsql &= " select top(6) isbn_13, left(book_title,50)+'...'  as book_title ,left(author,10)+'...'  as author ,image,cat_description,"
    '    strsql &= " convert(numeric(18,2), [List Price]) as selling_price, convert(numeric(18,2), [Your Price]) as [Your Price],convert(numeric(18,0),[%Save]) as [%Save]"
    '    strsql &= " from v_book"
    '    strsql &= " WHERE "
    '    strsql &= " [cat_description]  = '" + cat_name + "' and [order type] <> 'New-Title'"
    '    strsql &= " order by saleqty desc,stockqty desc"
    '    Return strsql
    'End Function
    'Private Function sqlComing_Soon(ByVal cat_name As String) As String
    '    Dim strsql As String = ""
    '    strsql &= " select top(6) isbn_13, left(book_title,50)+'...'  as book_title ,left(author,10)+'...'  as author ,image,cat_description,"
    '    strsql &= " convert(numeric(18,2), [List Price]) as selling_price, convert(numeric(18,2), [Your Price]) as [Your Price],convert(numeric(18,0),[%Save]) as [%Save]"
    '    strsql &= " from v_CommingSoon"
    '    strsql &= " WHERE "
    '    strsql &= " [cat_description]  = '" + cat_name + "' and [type] is not null "
    '    strsql &= " order by [onorderqty] desc"
    '    Return strsql
    'End Function
    'Private Function sqlBargain(ByVal cat_name As String) As String
    '    Dim strsql As String = ""
    '    strsql &= " select top(6) isbn_13, left(book_title,50)+'...'  as book_title ,left(author,10)+'...'  as author ,image,cat_description,"
    '    strsql &= " convert(numeric(18,2), [List Price]) as selling_price, convert(numeric(18,2), [Your Price]) as [Your Price],convert(numeric(18,0),[%Save]) as [%Save]"
    '    strsql &= " from v_Bargain_ShockPrice"
    '    strsql &= " WHERE "
    '    strsql &= "  [Item Disc_ Group]  = '" + cat_name + "' "
    '    strsql &= " order by [stockqty] desc"
    '    Return strsql
    'End Function

    'Protected Sub lvBooks_ItemDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.ListViewItemEventArgs) Handles lvBooks.ItemDataBound
    '    If e.Item.ItemType = ListViewItemType.DataItem Then
    '        Dim img As Image = DirectCast(e.Item.FindControl("img1"), Image)

    '        img.Attributes.Add("onmouseover", "this.style.zoom='200%';this.style.zIndex='999';") '"this.style.height='240px';this.style.width='164px';")
    '        img.Attributes.Add("onmouseout", "this.style.zoom='100%';this.style.zIndex='0';") '"this.style.height='120px';this.style.width='82px';")

    '    End If
    'End Sub

    Protected Sub lvBooks_ItemDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.ListViewItemEventArgs) Handles lvBooks.ItemDataBound

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
            strsql &= " where isbn_13 = '" + lblisbn.Text + "'"

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
            '    'กรณีคำนวนแล้วได้ 0 ต้องคิดค่าเฉลี่ยเอง

            '    If strCustomer_Average = "0" Then
            '        dt_view.Clear()
            '        strsql = ""
            '        strsql &= " select (CASE WHEN right(ltrim(rtrim(isbn_13)),2)='00' "
            '        strsql &= " THEN 99*3/99 "
            '        strsql &= " ELSE right(ltrim(rtrim(isbn_13)),2)*3/right(ltrim(rtrim(isbn_13)),2) END) AS total,"
            '        strsql &= " (CASE WHEN right(ltrim(rtrim(isbn_13)),2)='00' "
            '        strsql &= " THEN '99' "
            '        strsql &= " ELSE right(ltrim(rtrim(isbn_13)),2) END) AS No_CustomerView"
            '        strsql &= " from tbt_jobber_book_search"
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
            '    strsql &= " select (CASE WHEN right(ltrim(rtrim(isbn_13)),2)='00' "
            '    strsql &= " THEN 99*3/99 "
            '    strsql &= " ELSE right(ltrim(rtrim(isbn_13)),2)*3/right(ltrim(rtrim(isbn_13)),2) END) AS total,"
            '    strsql &= " (CASE WHEN right(ltrim(rtrim(isbn_13)),2)='00' "
            '    strsql &= " THEN '99' "
            '    strsql &= " ELSE right(ltrim(rtrim(isbn_13)),2) END) AS No_CustomerView"
            '    strsql &= " from tbt_jobber_book_search"
            '    strsql &= " where isbn_13 = '" + lblisbn.Text + "'"
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
End Class
