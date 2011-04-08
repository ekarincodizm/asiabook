Imports System
Imports System.Data

Partial Class Coming_Soon
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
        Me.Title = ConfigurationManager.AppSettings("SiteTitle").ToString & "Coming Soon ::"
        If Not IsPostBack Then
            Try
                Me.Get_Cat()
                Me.ucTop51.Top_Name = "Top5_PreOrder"
                Me.Get_NextWeek()
                Me.Get_Month()
                Me.Get_Releases()
                Me.UcBooks1.cat_name = "Coming_Soon|Fiction & Literature"
                Me.UcBooks2.cat_name = "Coming_Soon|Traveling"
                Me.UcBooks3.cat_name = "Coming_Soon|Children’s Books"
                Me.UcBooks4.Visible = False

            Catch ex As Exception
                uScript.Alert(Me.Page, Me.GetType, ex.Message.ToString)

            End Try

        End If

        lnkMore_NextWeek.HRef = "~/Book_SeeMore.aspx?Page_Name=Coming_Soon|Next_Week|"
        lnkMore_NextMonth.HRef = "~/Book_SeeMore.aspx?Page_Name=Coming_Soon|Next_Month|"
        lnkMore_Releases.HRef = "~/Book_SeeMore.aspx?Page_Name=Coming_Soon|Future_Release|"
    End Sub

    Private Function Get_NextWeek_XML(ByVal strfile As String) As Object
        Dim xmlDoc As XElement

        Try
            xmlDoc = XElement.Load(strfile)

            Dim Items = From c In xmlDoc.Elements("CommingSoonNextWeek") _
                        Order By Convert.ToInt16(c.Element("OrderNo").Value) Ascending _
                        Select isbn_13 = c.Element("isbn_13").Value, _
                        book_title = IIf(c.Element("book_title").Value.Length > 20, Left(c.Element("book_title").Value, 20) & "...", c.Element("book_title").Value), _
                        author = IIf(c.Element("author").Value.Length > 20, Left(c.Element("author").Value, 20) & "...", c.Element("author").Value), _
                        image = _Utility.GetImagePath(c.Element("image").Value)

            Return Items.Take(3)
        Catch ex As Exception
            Throw New Exception("Get_NextWeek_XML : " & ex.Message.ToString)
            Return Nothing
        Finally
            xmlDoc = Nothing
        End Try
    End Function
    Private Sub Get_NextWeek()
        Try
            Me.dtlNext_Week.DataSource = Me.Get_NextWeek_XML(uXML.CommingSoonNextWeek)
            Me.dtlNext_Week.DataBind()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Function Get_Month_XML(ByVal strfile As String) As Object
        Dim xmlDoc As XElement

        Try
            xmlDoc = XElement.Load(strfile)

            Dim Items = From c In xmlDoc.Elements("CommingSoon") _
                        Where c.Element("type").Value.ToLower = "nextmonth" _
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
    Private Sub Get_Month()
        Try
            dtlNext_Month.DataSource = Me.Get_Month_XML(uXML.CommingSoon)
            dtlNext_Month.DataBind()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Function Get_Releases_XML(ByVal strfile As String) As Object
        Dim xmlDoc As XElement

        Try
            xmlDoc = XElement.Load(strfile)

            Dim Items = From c In xmlDoc.Elements("CommingSoon") _
                        Where c.Element("type").Value.ToLower = "futurerelease" _
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
    Private Sub Get_Releases()
        Try
            Me.dtlNext_releases.DataSource = Me.Get_Releases_XML(uXML.CommingSoon)
            Me.dtlNext_releases.DataBind()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Function Get_Cat_XML(ByVal strfile As String) As Object
        Dim xmlDoc As XElement

        Try
            xmlDoc = XElement.Load(strfile)

            Dim Items = From c In xmlDoc.Elements("CommingSoon") _
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
            ddlCat.DataSource = Me.Get_Cat_XML(uXML.CommingSoon)
            ddlCat.DataBind()

            item.Value = ""
            item.Text = " -- SELECT -- "

            ddlCat.Items.Insert(0, item)
        Catch ex As Exception
            Throw ex
        Finally
            item = Nothing
        End Try
    End Sub

    Protected Sub ddlCat_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ddlCat.SelectedIndexChanged
        If ddlCat.Text <> " -- SELECT -- " Then

            UcBooks1.Visible = False
            UcBooks2.Visible = False
            UcBooks3.Visible = False
            UcBooks4.Visible = True
            UcBooks4.cat_name = "Coming_Soon|" & ddlCat.SelectedValue
        Else
            UcBooks4.Visible = False
            UcBooks1.Visible = True
            UcBooks2.Visible = True
            UcBooks3.Visible = True

        End If
    End Sub
End Class
