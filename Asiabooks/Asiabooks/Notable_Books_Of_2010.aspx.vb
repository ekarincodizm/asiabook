Imports System
Imports System.Data
Imports System.Text

Partial Class Notable_Books_Of_2010
    Inherits System.Web.UI.Page
    Dim uCon As uConnect
    Private _Utility As New clsUtility

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Me.Title = ConfigurationManager.AppSettings("SiteTitle").ToString & "100 Notable Books of 2010 ::"
        If Not IsPostBack Then
            GetFiction()
            GetNonFiction()
        End If
    End Sub
    Private Sub GetFiction()
        Dim dt As New DataTable
        uCon = New uConnect

        Dim strsql As String = ""
        strsql = "select isbn_13,left(book_title,30) as book_title,image, "
        strsql &= "left(synopsis,150) as synopsis,author from a_Notable_Books_Of_2010 "
        strsql &= "where type = 'FICTION & POETRY' "

        dt = uFunction.getDataTable(uCon.conn, strsql)
        DL_Fiction.DataSource = dt
        DL_Fiction.DataBind()
    End Sub
    Private Sub GetNonFiction()
        Dim dt As New DataTable
        uCon = New uConnect

        Dim strsql As String = ""
        strsql = "select isbn_13,left(book_title,30) as book_title,image, "
        strsql &= "left(synopsis,150) as synopsis,author from a_Notable_Books_Of_2010 "
        strsql &= "where type = 'NONFICTION'  "

        dt = uFunction.getDataTable(uCon.conn, strsql)
        DL_NonFiction.DataSource = dt
        DL_NonFiction.DataBind()
    End Sub

    Protected Sub DL_Fiction_ItemDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.DataListItemEventArgs) Handles DL_Fiction.ItemDataBound
        If e.Item.ItemType = ListItemType.Item Or _
             e.Item.ItemType = ListItemType.AlternatingItem Then

            Dim Book_Image As Image = e.Item.FindControl("Book_Image_Fiction")
            Dim lblImage_Fiction As Label = e.Item.FindControl("lblImage_Fiction")

            Book_Image.ImageUrl = _Utility.GetImagePath(lblImage_Fiction.Text.Trim)

        End If
    End Sub

    Protected Sub DL_NonFiction_ItemDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.DataListItemEventArgs) Handles DL_NonFiction.ItemDataBound
        If e.Item.ItemType = ListItemType.Item Or _
           e.Item.ItemType = ListItemType.AlternatingItem Then

            Dim Book_Image As Image = e.Item.FindControl("Book_Image_NonFiction")
            Dim lblImage_NonFiction As Label = e.Item.FindControl("lblImage_NonFiction")

            Book_Image.ImageUrl = _Utility.GetImagePath(lblImage_NonFiction.Text.Trim)

        End If
    End Sub
End Class
