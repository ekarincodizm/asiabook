Imports Eordering.BusinessLogic
Imports System
Imports System.Data
Imports Eordering.BusinessLogic.PageControl
Imports System.Linq
Imports System.Xml
Imports System.Xml.Linq

Partial Class uc_ucfeatured
    Inherits System.Web.UI.UserControl
    Dim bd As New Class_book_detail
    Private _Utility As New clsUtility

    Private Sub Get_Featured(ByVal Featured_Name As String)
        Dim Datalist As New Object

        Try
            Select Case Featured_Name
                Case "featured_thailand"
                    lblHead.Text = "RECOMMENDED TITLES"

                    Datalist = Me.Top2_BestSeller(uXML.BooksBestSeller)
                    lnkMore.HRef = "~/Book_SeeMore.aspx?Page_Name=Thailand_Insight|Recommended|"

                Case "new_releases"
                    lblHead.Text = "Featured Items"
                    Datalist = Me.Top2_Book(uXML.Books)
                    lnkMore.HRef = "~/Book_SeeMore.aspx?Page_Name=Books|new_releases|"

                Case Else
                    Datalist = Nothing

            End Select

            Me.DataList1.DataSource = Datalist
            Me.DataList1.DataBind()
        Catch ex As Exception
            Throw ex
        Finally
            Datalist = Nothing
        End Try
    End Sub

    Private Function Top2_BestSeller(ByVal strfile As String) As Object
        Dim xmlDoc As XElement

        Try
            xmlDoc = XElement.Load(strfile)

            Dim Items = From c In xmlDoc.Elements("BooksBestSeller") _
                        Where c.Element("type") = "ThaiLandInsight_Recommended" _
                        Order By Convert.ToInt16(c.Element("OrderNo").Value) Ascending _
                        Select isbn_13 = c.Element("isbn_13").Value, _
                        image = _Utility.GetImagePath(c.Element("image").Value), _
                        book_title = IIf(c.Element("book_title").Value.Length > 30, Left(c.Element("book_title").Value, 30) & "...", c.Element("book_title").Value), _
                        publisher_name = c.Element("publisher_name").Value, _
                        author = IIf(c.Element("author").Value.Length > 20, Left(c.Element("author").Value, 20) & "...", c.Element("author").Value), _
                        list_price = c.Element("list_price").Value, _
                        your_price = c.Element("your_price").Value, _
                        price_usd = "US$ " & bd.callUsd(uXML.Currency, Convert.ToDouble(c.Element("your_price").Value)), _
                        save_price = "(Save " & c.Element("save_price").Value & "%)"

            Return Items.Take(2)
        Catch ex As Exception
            Throw New Exception("Top2_BestSeller : " & ex.Message.ToString)
            Return Nothing
        Finally
            xmlDoc = Nothing
        End Try
    End Function
    Private Function Top2_Book(ByVal strfile As String) As Object
        Dim xmlDoc As XElement

        Try
            xmlDoc = XElement.Load(strfile)

            Dim Items = From c In xmlDoc.Elements("Books") _
                        Where c.Element("order_type") = "New-Title" _
                              And c.Element("type") = "NewReleases" _
                        Order By Convert.ToInt16(c.Element("OrderNo").Value) Ascending _
                        Select isbn_13 = c.Element("isbn_13").Value, _
                        image = _Utility.GetImagePath(c.Element("image").Value), _
                        book_title = IIf(c.Element("book_title").Value.Length > 30, Left(c.Element("book_title").Value, 30) & "...", c.Element("book_title").Value), _
                        author = IIf(c.Element("author").Value.Length > 20, Left(c.Element("author").Value, 20) & "...", c.Element("author").Value), _
                        publisher_name = c.Element("publisher_name").Value, _
                        list_price = c.Element("list_price").Value, _
                        your_price = c.Element("your_price").Value, _
                        price_usd = "US$ " & bd.callUsd(uXML.Currency, Convert.ToDouble(c.Element("your_price").Value)), _
                        save_price = "(Save " & c.Element("save_price").Value & "%)"

            Return Items.Take(2)
        Catch ex As Exception
            Throw New Exception("Top2_Book : " & ex.Message.ToString)
            Return Nothing
        Finally
            xmlDoc = Nothing
        End Try
    End Function

#Region "Property"

    Property Featured_Name() As String
        Get
            Return 0
        End Get
        Set(ByVal value As String)
            Get_Featured(value)
        End Set
    End Property

#End Region

    Protected Sub DataList1_ItemDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.DataListItemEventArgs) Handles DataList1.ItemDataBound
        If e.Item.ItemType = ListItemType.Item Or e.Item.ItemType = ListItemType.AlternatingItem Then
            Dim lblList_Price_L As Label = e.Item.FindControl("lblList_Price_L")
            Dim lblList_Price_D As Label = e.Item.FindControl("lblList_Price_D")
            Dim lblYout_Price_L As Label = e.Item.FindControl("lblYout_Price_L")
            Dim lblYout_Price_D As Label = e.Item.FindControl("lblYout_Price_D")
            Dim lblSave_Price As Label = e.Item.FindControl("lblSave_Price")

            If lblList_Price_D.Text = lblYout_Price_D.Text Then
                lblList_Price_D.Visible = False
                lblList_Price_L.Visible = False
                lblSave_Price.Visible = False
            Else
                lblList_Price_D.Font.Strikeout = True
            End If
        End If
    End Sub
End Class
