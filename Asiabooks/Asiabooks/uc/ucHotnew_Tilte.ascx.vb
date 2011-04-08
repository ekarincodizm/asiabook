Imports System
Imports System.Data

Partial Class uc_ucHotnew_Tilte
    Inherits System.Web.UI.UserControl
    Private _Utility As New clsUtility

    Private Sub Get_Slide(ByVal book_name As String)
        Dim DataList As New Object

        Try
            Select Case book_name
                Case "Hot_New_Title"
                    DataList = Top10_Hotnew(uXML.BooksBestSeller)

                Case "New_Releases"
                    DataList = Top10_New_Releases(uXML.ThailandInside)

                Case "ThisWeek_Bestseller"
                    DataList = Top10_Hotnew(uXML.BooksBestSeller)

                Case Else
                    DataList = Nothing

            End Select

            Me.DataList.DataSource = DataList
            Me.DataList.DataBind()
        Catch ex As Exception

        End Try
        
    End Sub

    Private Function Top10_Hotnew(ByVal strfile As String) As Object
        Dim xmlDoc As XElement

        Try
            xmlDoc = XElement.Load(strfile)

            Dim Items = From c In xmlDoc.Elements("BooksBestSeller") _
                        Where c.Element("type") = "Top10BestSeller_All_AB" _
                        And c.Element("type_cat") = "ALL" _
                        And c.Element("image") <> "no_image.jpg" _
                        Order By Convert.ToInt16(c.Element("OrderNo").Value) Ascending _
                        Select isbn_13 = c.Element("isbn_13").Value, _
                        book_title = c.Element("book_title").Value, _
                        author = c.Element("author").Value, _
                        publisher_name = c.Element("publisher_name").Value, _
                        list_price = c.Element("list_price").Value, _
                        your_price = c.Element("your_price").Value, _
                        save_price = c.Element("save_price").Value, _
                        Image = c.Element("image").Value

            Return Items.Take(10)
        Catch ex As Exception
            Throw New Exception("Top10_Hotnew : " & ex.Message.ToString)
            Return Nothing
        Finally
            xmlDoc = Nothing

        End Try
    End Function
    Private Function Top10_New_Releases(ByVal strfile As String) As Object
        Dim xmlDoc As XElement
        Dim dtDate As New DateTime

        Try
            dtDate = Now.AddDays(-30)
            xmlDoc = XElement.Load(strfile)

            Dim Items = From c In xmlDoc.Elements("ThailandInside") _
                        Where Date.ParseExact(c.Element("br_date").Value.ToString, "dd/MM/yyyy", Nothing) >= dtDate.Date _
                        And c.Element("image") <> "no_image.jpg" _
                        Order By Convert.ToInt16(c.Element("OrderNo").Value) Ascending _
                        Select isbn_13 = c.Element("isbn_13").Value, _
                        book_title = c.Element("book_title").Value, _
                        author = c.Element("author").Value, _
                        publisher_name = c.Element("publisher_name").Value, _
                        list_price = c.Element("list_price").Value, _
                        your_price = c.Element("your_price").Value, _
                        save_price = c.Element("save_price").Value, _
                        Image = c.Element("image").Value

            Return Items.Take(10)
        Catch ex As Exception
            Throw New Exception("Top10_New_Releases : " & ex.Message.ToString)
            Return Nothing
        Finally
            xmlDoc = Nothing
            dtDate = Nothing
        End Try
    End Function

    Private Function getUrl1(ByVal imagePath As String) As String
        Dim imag1 As String = ""
        imag1 = Request.Url.Scheme.ToString & Uri.SchemeDelimiter.ToString & _
                       Request.Url.Authority.ToString & _
                       IIf(Request.ApplicationPath.ToString = "/", "", Request.ApplicationPath.ToString) & imagePath
        Return imag1
    End Function
    Protected Sub DataList_ItemDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.DataListItemEventArgs) Handles DataList.ItemDataBound
        Try
            If e.Item.ItemType = ListItemType.Item Or e.Item.ItemType = ListItemType.AlternatingItem Then
                Dim strhtml As String = ""
                Dim imgadd_to_cart As String = ""
                imgadd_to_cart = getUrl1("/images/Template/add_to_cart.jpg")
                Dim Book_Image As Image = e.Item.FindControl("Book_Image")
                Dim lblBook_Image As Label = e.Item.FindControl("lblBook_Image")
                Dim lblisbn As Label = e.Item.FindControl("lblisbn")
                Dim lbltitle As Label = e.Item.FindControl("lbltitle")
                Dim lblauthor As Label = e.Item.FindControl("lblauthor")
                Dim lblpub_name As Label = e.Item.FindControl("lblpub_name")
                Dim lbllist_price As Label = e.Item.FindControl("lbllist_price")
                Dim lblyour_price As Label = e.Item.FindControl("lblyour_price")
                Dim lblsave_price As Label = e.Item.FindControl("lblsave_price")

                strhtml &= "	<table>"

                strhtml &= "    <tr>"
                strhtml &= "	<td>Title : " + lbltitle.Text + "</td>"
                strhtml &= "	</tr>"

                strhtml &= "	<tr>"
                strhtml &= "	<td>Author : " + lblauthor.Text + "</td>"
                strhtml &= "	</tr>"

                strhtml &= "	<tr>"
                strhtml &= "	<td>Publisher Name : " + lblpub_name.Text + "</td>"
                strhtml &= "	</tr>"

                strhtml &= "	<tr>"
                strhtml &= "	<td></td>"
                strhtml &= "	</tr>"

                strhtml &= "	<tr>"
                strhtml &= "	<td>List Price : " + lbllist_price.Text + "</td>"
                strhtml &= "	</tr>"

                strhtml &= "	<tr>"
                strhtml &= "	<td>Your Price : " + lblyour_price.Text + "</td>"
                strhtml &= "	</tr>"

                strhtml &= "	<tr>"
                strhtml &= "	<td>(Save Price " + lblsave_price.Text + "%)</td>"
                strhtml &= "	</tr>"

                strhtml &= "	</table>"

                Book_Image.Attributes.Add("onmouseOver", "ddrivetip('" + strhtml + "', 300)")
                Book_Image.Attributes.Add("onmouseOut", "hideddrivetip()")

                Book_Image.ImageUrl = _Utility.GetImagePath(lblBook_Image.Text.Trim)
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

#Region "Property"
    Property Book_Slide() As String
        Get
            Return 0
        End Get
        Set(ByVal value As String)
            Get_Slide(value)
        End Set
    End Property

#End Region

    'Public Function sql_Hotnew() As String
    '    Dim strsql As String = ""
    '    strsql &= " select top 10 isbn_13,book_title,author,publisher_name,[list price] as list_price,[your price] as your_price, "
    '    strsql &= " [%Save] as save_price,image"
    '    strsql &= " from v_BooksBestSeller WHERE [type]='Top10BestSeller_All_AB'"
    '    strsql &= " and [type_cat]  = 'all' "
    '    strsql &= " order by [orderby] "
    '    Return strsql.ToString
    'End Function

    'Public Function sql_New_Releases() As String
    '    Dim strsql As String = ""
    '    strsql &= " select top 10 isbn_13,book_title,author,publisher_name,[list price] as list_price "
    '    strsql &= " ,[your price] as your_price,[%Save] as save_price,image "
    '    strsql &= " from V_ThailandInside "
    '    strsql &= " where br_date >= getdate()-30 "
    '    strsql &= " order by StockQTY,br_date desc "
    '    Return strsql.ToString
    'End Function

End Class
