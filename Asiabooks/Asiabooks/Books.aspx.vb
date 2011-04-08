Imports System
Imports System.Data

Partial Class Books
    Inherits System.Web.UI.Page
    Private _Utility As New clsUtility
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
        Me.Title = ConfigurationManager.AppSettings("SiteTitle").ToString & "Books ::"
        If Not IsPostBack Then
            Try
                'Me.Ucfeatured1.Featured_Name = "new_releases"
                Me.UcBooks1.cat_name = "Books|Fiction & Literature"
                Me.UcBooks2.cat_name = "Books|Children’s Books"
                Me.UcBooks3.cat_name = "Home|Non-Fiction"

                Me.Get_ThisWeek()
                Me.Get_ThisMonth()
                Me.Get_Featured_Items()

                Me.ucBooks4.Visible = False
                Me.Get_Cat()
            Catch ex As Exception
                uScript.Alert(Me.Page, Me.GetType, ex.Message.ToString)
            End Try
        End If

        lnkMore_ThisWeek.HRef = "~/Book_SeeMore.aspx?Page_Name=Book_NewRelease|This_Week|"
        lnkMore_ThisMonth.HRef = "~/Book_SeeMore.aspx?Page_Name=Book_NewRelease|This_Month|"
        lnkMore_Featured_Items.HRef = "~/Book_SeeMore.aspx?Page_Name=Book_NewRelease|Featured_Items|"
    End Sub

    Private Function Get_Cat_XML(ByVal strfile As String) As Object
        Dim xmlDoc As XElement

        Try
            xmlDoc = XElement.Load(strfile)

            Dim Items = From c In xmlDoc.Elements("Books") _
                        Where c.Element("type") <> "NewReleases" _
                        And c.Element("order_type") <> "New-Title" _
                        And c.Element("cat_description") <> "" _
                        Order By CStr(c.Element("cat_description")) Ascending _
                        Select catcode = c.Element("cat_description").Value, _
                        catname = c.Element("cat_description").Value

            Return Items.Distinct
        Catch ex As Exception
            Throw New Exception("Get_Cat_XML : " & ex.Message.ToString)
            Return Nothing
        Finally
            xmlDoc = Nothing
        End Try
    End Function
    Private Sub Get_Cat()
        Dim item As New ListItem

        Try
            ddlCat.DataTextField = "catname"
            ddlCat.DataValueField = "catcode"
            ddlCat.DataSource = Me.Get_Cat_XML(uXML.Books)
            ddlCat.DataBind()

            item.Value = ""
            item.Text = " -- Select by Category Group -- "

            ddlCat.Items.Insert(0, item)
        Catch ex As Exception
            Throw ex
        Finally
            item = Nothing
        End Try
    End Sub

    Protected Sub ddlCat_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ddlCat.SelectedIndexChanged
        If ddlCat.Text <> " -- Select by Category Group -- " Then
            Me.UcBooks1.Visible = False
            Me.UcBooks2.Visible = False
            Me.UcBooks3.Visible = False
            Me.ucBooks4.Visible = True
            Me.ucBooks4.cat_name = "Books|" & Me.ddlCat.SelectedValue
        Else
            Me.ucBooks4.Visible = False
            Me.UcBooks1.Visible = True
            Me.UcBooks2.Visible = True
            Me.UcBooks3.Visible = True
        End If
    End Sub
    Private Sub Get_ThisWeek()
        Try
            Me.dtlThis_Week.DataSource = Me.GetThis_Week_XML(uXML.Book_NewRelease)
            Me.dtlThis_Week.DataBind()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
    Private Sub Get_ThisMonth()
        Try
            Me.dtlThis_Month.DataSource = Me.GetThis_Month_XML(uXML.Book_NewRelease)
            Me.dtlThis_Month.DataBind()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
    Private Sub Get_Featured_Items()
        Try
            Me.dtlFeatured_Items.DataSource = Me.GetFeatured_Items_XML(uXML.Book_NewRelease)
            Me.dtlFeatured_Items.DataBind()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
    Private Function GetThis_Week_XML(ByVal strfile As String) As Object
        Dim xmlDoc As XElement

        Try
            xmlDoc = XElement.Load(strfile)

            Dim Items = From c In xmlDoc.Elements("Book_NewRelease") _
                        Where c.Element("type").Value = "ThisWeek" _
                        Order By Convert.ToInt16(c.Element("OrderNo").Value) Ascending _
                        Select isbn_13 = c.Element("isbn_13").Value, _
                        book_title = IIf(c.Element("book_title").Value.Length > 20, Left(c.Element("book_title").Value, 20) & "...", c.Element("book_title").Value), _
                        author = IIf(c.Element("author").Value.Length > 20, Left(c.Element("author").Value, 20) & "...", c.Element("author").Value), _
                        image = _Utility.GetImagePath(c.Element("image").Value)

            Return Items.Take(3)
        Catch ex As Exception
            Throw New Exception("Get_Month_XML : " & ex.Message.ToString)
            Return Nothing
        Finally
            xmlDoc = Nothing
        End Try
    End Function
    Private Function GetThis_Month_XML(ByVal strfile As String) As Object
        Dim xmlDoc As XElement

        Try
            xmlDoc = XElement.Load(strfile)

            Dim Items = From c In xmlDoc.Elements("Book_NewRelease") _
                        Where c.Element("type").Value = "ThisMonth" _
                        Order By Convert.ToInt16(c.Element("OrderNo").Value) Ascending _
                        Select isbn_13 = c.Element("isbn_13").Value, _
                        book_title = IIf(c.Element("book_title").Value.Length > 20, Left(c.Element("book_title").Value, 20) & "...", c.Element("book_title").Value), _
                        author = IIf(c.Element("author").Value.Length > 20, Left(c.Element("author").Value, 20) & "...", c.Element("author").Value), _
                        image = _Utility.GetImagePath(c.Element("image").Value)

            Return Items.Take(3)
        Catch ex As Exception
            Throw New Exception("Get_Month_XML : " & ex.Message.ToString)
            Return Nothing
        Finally
            xmlDoc = Nothing
        End Try
    End Function
    Private Function GetFeatured_Items_XML(ByVal strfile As String) As Object
        Dim xmlDoc As XElement

        Try
            xmlDoc = XElement.Load(strfile)

            Dim Items = From c In xmlDoc.Elements("Book_NewRelease") _
                        Where c.Element("type").Value = "FeaturedItems" _
                        Order By Convert.ToInt16(c.Element("OrderNo").Value) Ascending _
                        Select isbn_13 = c.Element("isbn_13").Value, _
                        book_title = IIf(c.Element("book_title").Value.Length > 20, Left(c.Element("book_title").Value, 20) & "...", c.Element("book_title").Value), _
                        author = IIf(c.Element("author").Value.Length > 20, Left(c.Element("author").Value, 20) & "...", c.Element("author").Value), _
                        image = _Utility.GetImagePath(c.Element("image").Value)

            Return Items.Take(3)
        Catch ex As Exception
            Throw New Exception("Get_Month_XML : " & ex.Message.ToString)
            Return Nothing
        Finally
            xmlDoc = Nothing
        End Try
    End Function
End Class
