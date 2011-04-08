Imports System
Imports System.Data
Imports System.Linq
Imports System.Xml
Imports System.Xml.Linq

Partial Class uc_ucTop5_Magazine
    Inherits System.Web.UI.UserControl
    Private _Utility As New clsUtility

    Private Sub Getdata_Top(ByVal Top_Name As String)
        Dim DataList As New Object

        Try
            Select Case Top_Name
                Case "Top5_Magazine"
                    DataList = Top5_Magazine(uXML.Magazine)
                    imgHead.ImageUrl = "~/images/Template/head_top_magazine.gif"
                    lnkMore.HRef = "~/Magazine_SeeMore.aspx?Page_Name=Magazine|Top5_Magazine|"

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

    Private Function Top5_Magazine(ByVal strfile As String) As Object
        Dim xmlDoc As XElement

        Try
            xmlDoc = XElement.Load(strfile)

            Dim Items = From c In xmlDoc.Elements("Magazine") _
                        Order By c.Element("isbn_13").Value Ascending _
                        Select isbn_13 = c.Element("isbn_13").Value, _
                        book_title = IIf(c.Element("book_title").Value.Length > 10, Left(c.Element("book_title").Value, 10) & "...", c.Element("book_title").Value), _
                        author = IIf(c.Element("publisher_name").Value.Length > 10, Left(c.Element("author").Value, 10) & "...", c.Element("publisher_name").Value), _
                        image = c.Element("image").Value, _
                        book_title_full = c.Element("book_title").Value, _
                        author_full = c.Element("publisher_name").Value

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
                If lblBook_Image.Text = "no_image.jpg" Then
                    Book_Image.ImageUrl = "~/images_book/no_magazine.jpg"
                Else
                    Book_Image.ImageUrl = _Utility.GetImagePath(lblBook_Image.Text.Trim)
                End If

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

End Class
