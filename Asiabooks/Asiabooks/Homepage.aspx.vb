Imports System.Data
Imports System.Linq
Imports System.Xml
Imports System.Xml.Linq

Partial Class Homepage
    Inherits System.Web.UI.Page

    Public Sub getUrl(ByVal imagePath As String)

        Response.Write(Request.Url.Scheme.ToString & Uri.SchemeDelimiter.ToString & _
                       Request.Url.Authority.ToString & _
                       IIf(Request.ApplicationPath.ToString = "/", "", Request.ApplicationPath.ToString) & imagePath)

    End Sub

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Me.Title = ConfigurationManager.AppSettings("SiteTitle").ToString & "Books, Textbooks, eBooks, Magazines, Books on Thailand, Book Thailand, Books Thailand ::"

        If Not Me.IsPostBack Then
            Try
             

                Me.Get_Cat()

                Me.ucTop51.Top_Name = "Top5_Bestseller"
                Me.UcHotnew_Tilte1.Book_Slide = "Hot_New_Title"
                Me.UcBooks1.cat_name = "Home|Fiction & Literature"
                Me.UcBooks2.cat_name = "Home|Non-Fiction"
                Me.UcBooks3.cat_name = "Home|Children's Books"
                Me.UcBooks4.Visible = False

            Catch ex As Exception
                uScript.Alert(Me.Page, Me.GetType, ex.Message.ToString)

            End Try

        End If

        lnkMore.HRef = "~/Book_SeeMore.aspx?Page_Name=Home|Bestsellers|"
    End Sub

    Private Function Get_Cat_XML(ByVal strfile As String) As Object
        Dim xmlDoc As XElement

        Try
            xmlDoc = XElement.Load(strfile)

            Dim Items = From c In xmlDoc.Elements("BooksBestSeller") _
                        Where c.Element("type_cat") <> "ALL" _
                        And c.Element("name_display") <> "" _
                        And c.Element("type") = "Top10BestSeller_All_AB" _
                        And c.Element("type_cat") <> "" _
                        Order By CStr(c.Element("name_display")) Ascending _
                        Select catcode = c.Element("name_display").Value, _
                        catname = c.Element("name_display").Value

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
            Me.ddlCat.DataSource = Me.Get_Cat_XML(uXML.BooksBestSeller)
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

            Me.UcBooks1.Visible = False
            Me.UcBooks2.Visible = False
            Me.UcBooks3.Visible = False
            Me.UcBooks4.Visible = True
            Me.UcBooks4.cat_name = "Home|" & Me.ddlCat.SelectedValue
        Else
            Me.UcBooks4.Visible = False
            Me.UcBooks1.Visible = True
            Me.UcBooks2.Visible = True
            Me.UcBooks3.Visible = True

        End If
    End Sub

End Class
