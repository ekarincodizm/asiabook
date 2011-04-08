Imports Eordering.BusinessLogic
Imports System
Imports System.Data
Imports Eordering.BusinessLogic.PageControl
Imports System.Xml
Imports System.Xml.Linq
Imports System.Linq
Imports System.Globalization
Partial Class Magazine_SeeMore
    Inherits System.Web.UI.Page
    Private _Utility As New clsUtility
    Private bd As New Class_book_detail

    Public Sub getUrl(ByVal imagePath As String)

        Response.Write(Request.Url.Scheme.ToString & Uri.SchemeDelimiter.ToString & _
                       Request.Url.Authority.ToString & _
                       IIf(Request.ApplicationPath.ToString = "/", "", Request.ApplicationPath.ToString) & imagePath)

    End Sub
    Private Function getUrl1(ByVal imagePath As String) As String
        Dim imag1 As String = ""
        imag1 = Request.Url.Scheme.ToString & Uri.SchemeDelimiter.ToString & _
                       Request.Url.Authority.ToString & _
                       IIf(Request.ApplicationPath.ToString = "/", "", Request.ApplicationPath.ToString) & imagePath
        Return imag1
    End Function

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Me.Title = ConfigurationManager.AppSettings("SiteTitle").ToString & "Book search ::"
        If Not IsPostBack Then
            Try
                Session("DataList") = Nothing

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

            If strpage_name = "Magazine" And strtype = "Top5_Magazine" And strgroup = "" Then
                DataList = Me.GetBooks_Top5_Magazine(uXML.Magazine)

            ElseIf strpage_name = "Masterpage" And strtype = "Menu_Cat" And strgroup <> "" Then
                DataList = Me.GetMasterpage_Cat(uXML.Magazine, strgroup)

            ElseIf strpage_name = "Magazine" And strtype = "Magazine" And strgroup <> "" Then
                DataList = Me.GetBooks_Magazine(uXML.Magazine, strgroup)

            ElseIf strpage_name = "Masterpage" And strtype = "Menu_Cat_Head" And strgroup <> "" Then
                DataList = Me.GetMasterpage_Cat_Head(uXML.Magazine, strgroup)

            Else
                DataList = Nothing
            End If

            Me.Label_Result.Text = pcontrol.ShowingResultSet(Me.Datagrid.CurrentPageIndex, Me.Datagrid.PageSize, DataList.Rows.Count)

            Datagrid.DataSource = DataList
            Datagrid.DataBind()

            Session("DataList") = DataList
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

            If Session("DataList") Is Nothing Then
                Me.Getdata()
            Else
                dt = Session("DataList")

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
                        Order By c.Element("isbn_13").Value Ascending _
                        Select isbn_13 = c.Element("isbn_13").Value, _
                        book_title = c.Element("book_title").Value, _
                        author = c.Element("author").Value, _
                        list_price = CDbl(c.Element("list_price").Value.ToString).ToString("#,###,##0.00"), _
                        your_price = CDbl(c.Element("your_price").Value.ToString).ToString("#,###,##0.00"), _
                        publisher_name = c.Element("publisher_name").Value, _
                        price_save = "(Save " & c.Element("save_price").Value & "%)", _
                        price_usd = "US$ " & bd.callUsd(uXML.Currency, Convert.ToDouble(c.Element("your_price").Value)), _
                        image = _Utility.GetImagePath_Magazine(c.Element("image").Value)

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
    Private Function GetBooks_Magazine(ByVal strfile As String, ByVal cat_name As String) As DataTable
        Dim xmlDoc As XElement
        Dim dt As New DataTable
        Dim dr As DataRow

        Try
            dt = CreateDataTable()
            xmlDoc = XElement.Load(strfile)

            Dim Items = From c In xmlDoc.Elements("Magazine") _
                        Where c.Element("Cat_Code").Value = cat_name _
                        Order By Convert.ToInt16(c.Element("OrderNo").Value) Ascending _
                        Select isbn_13 = c.Element("isbn_13").Value, _
                        book_title = c.Element("book_title").Value, _
                        author = c.Element("author").Value, _
                        list_price = CDbl(c.Element("list_price").Value.ToString).ToString("#,###,##0.00"), _
                        your_price = CDbl(c.Element("your_price").Value.ToString).ToString("#,###,##0.00"), _
                        publisher_name = c.Element("publisher_name").Value, _
                        price_save = "(Save " & c.Element("save_price").Value & "%)", _
                        price_usd = "US$ " & bd.callUsd(uXML.Currency, Convert.ToDouble(c.Element("your_price").Value)), _
                        image = _Utility.GetImagePath_Magazine(c.Element("image").Value)

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
            Throw New Exception("GetBook Magazine : " & ex.Message.ToString)
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

            Dim Items = From c In xmlDoc.Elements("Magazine") _
                        Where c.Element("Cat_Code").Value = cat_name _
                        Order By Convert.ToInt16(c.Element("OrderNo").Value) Ascending _
                        Select isbn_13 = c.Element("isbn_13").Value, _
                        book_title = c.Element("book_title").Value, _
                        author = c.Element("author").Value, _
                        list_price = CDbl(c.Element("list_price").Value.ToString).ToString("#,###,##0.00"), _
                        your_price = CDbl(c.Element("your_price").Value.ToString).ToString("#,###,##0.00"), _
                        publisher_name = c.Element("publisher_name").Value, _
                        price_save = "(Save " & c.Element("save_price").Value & "%)", _
                        price_usd = "US$ " & bd.callUsd(uXML.Currency, Convert.ToDouble(c.Element("your_price").Value)), _
                        image = _Utility.GetImagePath_Magazine(c.Element("image").Value)

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
                        image = _Utility.GetImagePath_Magazine(c.Element("image").Value)

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


End Class
