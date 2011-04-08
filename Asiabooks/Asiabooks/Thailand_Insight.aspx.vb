Imports Eordering.BusinessLogic
Imports System
Imports System.Data
Imports Eordering.BusinessLogic.PageControl
Imports System.Linq
Imports System.Xml
Imports System.Xml.Linq

Partial Class Thailand_Insight
    Inherits System.Web.UI.Page
    Dim bd As New Class_book_detail

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
        Me.Title = ConfigurationManager.AppSettings("SiteTitle").ToString & "Thailand in Sight ::"
        If Not IsPostBack Then
            Try
                Me.Get_Cat()
                Me.UcTop5_1.Top_Name = "ThailandInsight_Best"
                Me.Ucfeatured1.Featured_Name = "featured_thailand"
                Me.UcHotnew_Tilte1.Book_Slide = "New_Releases"
                Me.UcBooks1.cat_name = "Thailand_Insight|F"
                Me.UcBooks2.cat_name = "Thailand_Insight|T"
                Me.UcBooks3.Visible = False
            Catch ex As Exception
                uScript.Alert(Me.Page, Me.GetType, ex.Message.ToString)

            End Try
        End If

        lnkMore.HRef = "~/Book_SeeMore.aspx?Page_Name=Thailand_Insight|New_Releases|"
    End Sub

    Private Function Get_Cat_XML(ByVal strfile As String) As Object
        Dim xmlDoc As XElement

        Try
            xmlDoc = XElement.Load(strfile)

            Dim Items = From c In xmlDoc.Elements("ThailandInside") _
                        Where CInt(c.Element("saleqty").Value) > 0 _
                        Order By c.Element("cat_description").Value Ascending _
                        Select catcode = c.Element("cat_code").Value, _
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
            Me.ddlCat.DataTextField = "catname"
            Me.ddlCat.DataValueField = "catcode"
            Me.ddlCat.DataSource = Me.Get_Cat_XML(uXML.ThailandInside)
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
        If Me.ddlCat.Text <> " -- Select by Category Group -- " Then
            Me.UcBooks1.Visible = False
            Me.UcBooks2.Visible = False
            Me.UcBooks3.Visible = True
            Me.UcBooks3.cat_name = "Thailand_Insight|" & Me.ddlCat.SelectedValue
        Else
            Me.UcBooks3.Visible = False
            Me.UcBooks1.Visible = True
            Me.UcBooks2.Visible = True

        End If
    End Sub
End Class
