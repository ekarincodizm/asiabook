Imports System
Imports System.Data
Imports System.Linq
Imports System.Xml
Imports System.Xml.Linq

Partial Class Bestseller
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Me.Title = ConfigurationManager.AppSettings("SiteTitle").ToString & "Bestsellers ::"
        If Not IsPostBack Then
            Try
                Me.UcHotnew_Tilte1.Book_Slide = "ThisWeek_Bestseller"
                Me.UcTop5_1.Top_Name = "New_Yourk_Bestseller"
                Me.UcTop5_2.Top_Name = "USA_Today_Bestseller"
                Me.UcBooks1.cat_name = "Home|General Interest"
                Me.UcBooks2.cat_name = "Home|Art & Design"
                Me.UcBooks3.cat_name = "Home|Thailand & Southeast Asia"
                Me.UcBooks4.Visible = False
                Me.Get_Cat()

            Catch ex As Exception
                uScript.Alert(Me.Page, Me.GetType, ex.Message.ToString)
            End Try
        End If

        lnkMore.HRef = "~/Book_SeeMore.aspx?Page_Name=Bestsellers|ThisWeek_Bestsellers|"
    End Sub

    Private Function Get_Cat_XML(ByVal strfile As String) As Object
        Dim xmlDoc As XElement

        Try
            xmlDoc = XElement.Load(strfile)

            Dim Items = From c In xmlDoc.Elements("BooksBestSeller") _
                        Where c.Element("type_cat") <> "ALL" _
                        And c.Element("name_display") <> "" _
                        And c.Element("name_display") <> "" _
                        And c.Element("type") = "Top10BestSeller_All_AB" _
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
            Me.UcBooks4.cat_name = "Bestsellers|" & Me.ddlCat.SelectedValue

        Else
            Me.UcBooks4.Visible = False
            Me.UcBooks1.Visible = True
            Me.UcBooks2.Visible = True
            Me.UcBooks3.Visible = True

        End If
    End Sub

End Class
