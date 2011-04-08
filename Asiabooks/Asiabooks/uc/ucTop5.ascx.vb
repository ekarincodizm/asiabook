Imports System
Imports System.Data
Imports System.Linq
Imports System.Xml
Imports System.Xml.Linq

Partial Class uc_ucTop5
    Inherits System.Web.UI.UserControl
    Private _Utility As New clsUtility

    Private Sub Getdata_Top(ByVal Top_Name As String)
        Dim DataList As New Object

        Try
            Select Case Top_Name
                Case "Top5_Bestseller"
                    DataList = Top5_Bestseller(uXML.BooksBestSeller)
                    imgHead.ImageUrl = "~/images/Template/head_top.gif"
                    lnkMore.HRef = "~/Book_SeeMore.aspx?Page_Name=Home|Bestsellers|"
                    lblSource_Nielsen.Visible = False

                Case "ThailandInsight_Best"
                    DataList = Top5_Thailand(uXML.BooksBestSeller)
                    imgHead.ImageUrl = "~/images/Template/head_top_thailand_insight.gif"
                    lnkMore.HRef = "~/Book_SeeMore.aspx?Page_Name=Thailand_Insight|Thailand_Bestsellers|"
                    lblSource_Nielsen.Visible = False

                Case "New_Yourk_Bestseller"
                    DataList = Top5_New_Yourk_Bestseller(uXML.NewYorkUSA)
                    imgHead.ImageUrl = "~/images/Template/head_top_new_york.gif"
                    lnkMore.HRef = "~/Bestsellers_SeeMore.aspx?Page_Name=New_Yourk_Bestseller"
                    lblSource_Nielsen.Visible = False

                Case "USA_Today_Bestseller"
                    DataList = Top5_USA_Today_Bestseller(uXML.NewYorkUSA)
                    imgHead.ImageUrl = "~/images/Template/head_top_uk.gif"
                    lnkMore.HRef = "~/Bestsellers_SeeMore.aspx?Page_Name=UK_Today_Bestseller"
                    lblSource_Nielsen.Visible = True

                Case "Top5_PreOrder"
                    DataList = Top5_PreOrder(uXML.CommingSoon)
                    imgHead.ImageUrl = "~/images/Template/head_top_pre_order.gif"
                    lnkMore.HRef = "~/Book_SeeMore.aspx?Page_Name=Coming_Soon|Top5_PreOrder|"
                    lblSource_Nielsen.Visible = False

                Case "Top5_MemberFavioritesCat"
                    Dim strCatCode As String = ""
                    strCatCode = Request.Cookies("myCookie_user")("CatCode")
                    DataList = Top5_MemberFavioritesCat(uXML.BrownSubCat, strCatCode)
                    imgHead.ImageUrl = "~/images/Template/head_top_favorite.gif"
                    lnkMore.HRef = "~/Book_SeeMore.aspx?Page_Name=MemberFavioritesCat|Sub_Cat|" + strCatCode
                    lblSource_Nielsen.Visible = False

                Case "Top5_Magazine"
                    DataList = Top5_Magazine(uXML.Magazine)
                    imgHead.ImageUrl = "~/images/Template/head_top_magazine.gif"
                    lnkMore.HRef = "~/Magazine_SeeMore.aspx?Page_Name=Magazine|Top5_Magazine|"
                    lblSource_Nielsen.Visible = False

                Case Else
                    DataList = Nothing

            End Select
            
            GridBestSellers.DataSource = DataList
            GridBestSellers.DataBind()

        Catch ex As Exception
            Throw ex
        Finally
            DataList = Nothing
        End Try
    End Sub

    Private Function Top5_Bestseller(ByVal strfile As String) As Object
        Dim xmlDoc As XElement

        Try
            xmlDoc = XElement.Load(strfile)

            Dim Items = From c In xmlDoc.Elements("BooksBestSeller") _
                        Where c.Element("type") = "Top10BestSeller_All_AB" _
                        And c.Element("type_cat") = "ALL" _
                        Order By Convert.ToInt16(c.Element("orderby").Value) Ascending _
                        Select isbn_13 = c.Element("isbn_13").Value, _
                        book_title = IIf(c.Element("book_title").Value.Length > 10, Left(c.Element("book_title").Value, 10) & "...", c.Element("book_title").Value), _
                        author = IIf(c.Element("author").Value.Length > 10, Left(c.Element("author").Value, 10) & "...", c.Element("author").Value), _
                        image = c.Element("image").Value, _
                        book_title_full = c.Element("book_title").Value, _
                        author_full = c.Element("author").Value

            Return Items.Take(5)
        Catch ex As Exception
            Throw New Exception("Top5_Bestseller : " & ex.Message.ToString)
            Return Nothing
        Finally
            xmlDoc = Nothing
        End Try

    End Function
    Private Function Top5_Thailand(ByVal strfile As String) As Object
        Dim xmlDoc As XElement

        Try
            xmlDoc = XElement.Load(strfile)

            Dim Items = From c In xmlDoc.Descendants("BooksBestSeller") _
                        Where c.Element("type") = "Top10BestSeller_All_AB" _
                        And c.Element("type_cat") = "SE. ASIA" _
                        Or c.Element("type_cat") = "TH" _
                        Order By c.Element("type_cat").Value Descending, _
                        Convert.ToInt16(c.Element("orderby").Value) Ascending _
                        Select isbn_13 = c.Element("isbn_13").Value, _
                        book_title = IIf(c.Element("book_title").Value.Length > 10, Left(c.Element("book_title").Value, 10) & "...", c.Element("book_title").Value), _
                        author = IIf(c.Element("author").Value.Length > 10, Left(c.Element("author").Value, 10) & "...", c.Element("author").Value), _
                        image = c.Element("image").Value, _
                        book_title_full = c.Element("book_title").Value, _
                        author_full = c.Element("author").Value

            Return Items.Take(5)
        Catch ex As Exception
            Throw New Exception("Top5_Thailand : " & ex.Message.ToString)
            Return Nothing
        Finally
            xmlDoc = Nothing
        End Try

    End Function
    Private Function Top5_New_Yourk_Bestseller(ByVal strfile As String) As Object
        Dim xmlDoc As XElement

        Try
            xmlDoc = XElement.Load(strfile)

            Dim Items = From c In xmlDoc.Descendants("NewYorkUSA") _
                        Where c.Element("type") = "NewYorkTime" _
                        Select isbn_13 = c.Element("isbn_13").Value, _
                        book_title = IIf(c.Element("book_title").Value.Length > 10, Left(c.Element("book_title").Value, 10) & "...", c.Element("book_title").Value), _
                        author = IIf(c.Element("author").Value.Length > 10, Left(c.Element("author").Value, 10) & "...", c.Element("author").Value), _
                        image = c.Element("image").Value, _
                        book_title_full = c.Element("book_title").Value, _
                        author_full = c.Element("author").Value

            Return Items.Take(5)
        Catch ex As Exception
            Throw New Exception("Top5_New_Yourk_Bestseller : " & ex.Message.ToString)
            Return Nothing
        Finally
            xmlDoc = Nothing
        End Try
    End Function
    Private Function Top5_USA_Today_Bestseller(ByVal strfile As String) As Object
        Dim xmlDoc As XElement

        Try
            xmlDoc = XElement.Load(strfile)

            Dim Items = From c In xmlDoc.Descendants("NewYorkUSA") _
                        Where c.Element("type") = "UK Bestsellers" _
                        Select isbn_13 = c.Element("isbn_13").Value, _
                        book_title = IIf(c.Element("book_title").Value.Length > 10, Left(c.Element("book_title").Value, 10) & "...", c.Element("book_title").Value), _
                        author = IIf(c.Element("author").Value.Length > 10, Left(c.Element("author").Value, 10) & "...", c.Element("author").Value), _
                        image = c.Element("image").Value, _
                        book_title_full = c.Element("book_title").Value, _
                        author_full = c.Element("author").Value

            Return Items.Take(5)
        Catch ex As Exception
            Throw New Exception("Top5_Bestseller : " & ex.Message.ToString)
            Return Nothing
        Finally
            xmlDoc = Nothing
        End Try
    End Function
    Private Function Top5_PreOrder(ByVal strfile As String) As Object
        Dim xmlDoc As XElement

        Try
            xmlDoc = XElement.Load(strfile)

            Dim Items = From c In xmlDoc.Descendants("CommingSoon") _
                        Order By Convert.ToInt16(c.Element("onorderqty").Value) Descending _
                        Select isbn_13 = c.Element("isbn_13").Value, _
                        book_title = IIf(c.Element("book_title").Value.Length > 10, Left(c.Element("book_title").Value, 10) & "...", c.Element("book_title").Value), _
                        author = IIf(c.Element("author").Value.Length > 10, Left(c.Element("author").Value, 10) & "...", c.Element("author").Value), _
                        image = c.Element("image").Value, _
                        book_title_full = c.Element("book_title").Value, _
                        author_full = c.Element("author").Value

            Return Items.Take(5)
        Catch ex As Exception
            Throw New Exception("Top5_Bestseller : " & ex.Message.ToString)
            Return Nothing
        Finally
            xmlDoc = Nothing
        End Try
    End Function
    Private Function Top5_MemberFavioritesCat(ByVal strfile As String, ByVal strCatCode As String) As Object

        Dim xmlDoc As XElement

        Try
            xmlDoc = XElement.Load(strfile)

            Dim Items = From c In xmlDoc.Elements("BrownSubCat") _
                        Where Left(c.Element("cat_code").Value, 1) = strCatCode _
                        Order By Convert.ToInt16(c.Element("stockqty").Value) Descending _
                        Select isbn_13 = c.Element("isbn_13").Value, _
                        book_title = IIf(c.Element("book_title").Value.Length > 10, Left(c.Element("book_title").Value, 10) & "...", c.Element("book_title").Value), _
                        author = IIf(c.Element("author").Value.Length > 10, Left(c.Element("author").Value, 10) & "...", c.Element("author").Value), _
                        image = c.Element("image").Value, _
                        book_title_full = c.Element("book_title").Value, _
                        author_full = c.Element("author").Value

            Return Items.Take(5)
        Catch ex As Exception
            Throw New Exception("Top5_MemberFavioritesCat : " & ex.Message.ToString)
            Return Nothing
        Finally
            xmlDoc = Nothing
        End Try
    End Function
    Private Function Top5_Magazine(ByVal strfile As String) As Object
        Dim xmlDoc As XElement

        Try
            xmlDoc = XElement.Load(strfile)

            Dim Items = From c In xmlDoc.Elements("Magazine") _
                        Order By c.Element("isbn_13").Value Ascending _
                        Select isbn_13 = c.Element("isbn_13").Value, _
                        book_title = IIf(c.Element("book_title").Value.Length > 10, Left(c.Element("book_title").Value, 10) & "...", c.Element("book_title").Value), _
                        author = IIf(c.Element("author").Value.Length > 10, Left(c.Element("author").Value, 10) & "...", c.Element("author").Value), _
                        image = c.Element("image").Value, _
                        book_title_full = c.Element("book_title").Value, _
                        author_full = c.Element("author").Value

            Return Items.Take(5)
        Catch ex As Exception
            Throw New Exception("Top5_Bestseller : " & ex.Message.ToString)
            Return Nothing
        Finally
            xmlDoc = Nothing
        End Try

    End Function
    Protected Sub GridBestSellers_RowDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewRowEventArgs) Handles GridBestSellers.RowDataBound
        Try
            If e.Row.RowType = DataControlRowType.DataRow Then
                Dim lblSeq As Label = e.Row.FindControl("lblSeq")
                Dim Book_Image As Image = e.Row.FindControl("Book_Image")
                Dim lblBook_Image As Label = e.Row.FindControl("lblBook_Image")
                Dim lblisbn As Label = e.Row.FindControl("lblisbn")
                Book_Image.ImageUrl = _Utility.GetImagePath(lblBook_Image.Text.Trim)
                lblSeq.Text = e.Row.RowIndex + 1
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

#Region "Property"
    Property Top_Name() As String
        Get
            Return 0
        End Get
        Set(ByVal value As String)
            Getdata_Top(value)
        End Set
    End Property

#End Region

    'Private Function Top5_Bestseller() As String
    '    Dim strsql As String = ""
    '    strsql &= " select top 5  isbn_13, left(book_title,10)+'...'  as book_title ,left(author,10)+'...'  as author ,image "
    '    strsql &= " from v_BooksBestSeller"
    '    strsql &= " WHERE [type]='Top10BestSeller_All_AB' and [type_cat]  = 'all'"
    '    strsql &= " order by [orderby]"
    '    Return strsql
    'End Function
    'Private Function Top5_Thailand() As String
    '    Dim strsql As String = ""
    '    strsql &= " select top 5  isbn_13, left(book_title,10)+'...'  as book_title ,left(author,10)+'...'  as author ,image "
    '    strsql &= " from v_BooksBestSeller"
    '    strsql &= " WHERE [type]='Top10BestSeller_All_AB'"
    '    strsql &= " and [type_cat]  in ('SE. ASIA','TH')"
    '    strsql &= " order by [type_cat] desc ,[orderby]"
    '    Return strsql
    'End Function
    'Private Function Top5_New_Yourk_Bestseller() As String
    '    Dim strsql As String = ""
    '    strsql &= " select top 5  isbn_13, left(book_title,10)+'...'  as book_title ,left(author,10)+'...'  as author ,image"
    '    strsql &= " from v_NewYorkUSA"
    '    strsql &= " WHERE [type]= 'USAToday'"
    '    Return strsql
    'End Function
    'Private Function Top5_USA_Today_Bestseller() As String
    '    Dim strsql As String = ""
    '    strsql &= " select top 5  isbn_13, left(book_title,10)+'...'  as book_title ,left(author,10)+'...'  as author ,image"
    '    strsql &= " from v_NewYorkUSA"
    '    strsql &= " WHERE [type]= 'NewYorkTime'"
    '    Return strsql
    'End Function
    'Private Function Top5_PreOrder() As String
    '    Dim strsql As String = ""
    '    strsql &= " select top 5  isbn_13, left(book_title,10)+'...'  as book_title ,left(author,10)+'...'  as author ,image"
    '    strsql &= " from v_CommingSoon"
    '    strsql &= " order by OnOrderQTY desc"
    '    Return strsql
    'End Function

End Class
