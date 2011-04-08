Imports System.Data
Imports System.Linq
Imports System.Xml
Imports System.Xml.Linq

Partial Class Magazine
    Inherits System.Web.UI.Page

    Public Sub getUrl(ByVal imagePath As String)

        Response.Write(Request.Url.Scheme.ToString & Uri.SchemeDelimiter.ToString & _
                       Request.Url.Authority.ToString & _
                       IIf(Request.ApplicationPath.ToString = "/", "", Request.ApplicationPath.ToString) & imagePath)

    End Sub
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Me.Title = ConfigurationManager.AppSettings("SiteTitle").ToString & "Magazine ::"
        If Not Me.IsPostBack Then
            Try
                Me.Get_Cat()

                Me.ucTop5_Magazine1.Top_Name = "Top5_Magazine"
                Me.ucMagazine1.cat_name = "Magazine|MWI00"
                Me.ucMagazine2.cat_name = "Magazine|MMI00"
                Me.ucMagazine3.cat_name = "Magazine|MGI00"
                Me.ucMagazine4.cat_name = "Magazine|MLF00"
                Me.ucMagazine5.Visible = False

            Catch ex As Exception
                uScript.Alert(Me.Page, Me.GetType, ex.Message.ToString)

            End Try

        End If

    End Sub

    Private Function Get_Cat_XML(ByVal strfile As String) As Object
        Dim xmlDoc As XElement

        Try
            xmlDoc = XElement.Load(strfile)

            Dim Items = From c In xmlDoc.Elements("Magazine") _
                        Order By CStr(c.Element("Cat_Description")) Ascending _
                        Select catcode = c.Element("Cat_Code").Value, _
                        catname = c.Element("Cat_Description").Value

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
            Me.ddlCat.DataTextField = "catname"
            Me.ddlCat.DataValueField = "catcode"
            Me.ddlCat.DataSource = Me.Get_Cat_XML(uXML.Magazine)
            Me.ddlCat.DataBind()

            item.Value = ""
            item.Text = " -- Select by Category Group -- "

            Me.ddlCat.Items.Insert(0, item)
            Me.ddlCat.SelectedIndex = 0
        Catch ex As Exception
            Throw ex
        Finally
            item = Nothing
        End Try

    End Sub

    Protected Sub ddlCat_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ddlCat.SelectedIndexChanged
        If ddlCat.Text <> " -- Select by Category Group -- " Then

            Me.ucMagazine1.Visible = False
            Me.ucMagazine2.Visible = False
            Me.ucMagazine3.Visible = False
            Me.ucMagazine4.Visible = False
            Me.ucMagazine5.Visible = True
            Me.ucMagazine5.cat_name = "Magazine|" & Me.ddlCat.SelectedValue
        Else
            Me.ucMagazine5.Visible = False
            Me.ucMagazine1.Visible = True
            Me.ucMagazine2.Visible = True
            Me.ucMagazine3.Visible = True
            Me.ucMagazine4.Visible = True
        End If
    End Sub
End Class
