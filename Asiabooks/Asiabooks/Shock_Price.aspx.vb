Imports System
Imports System.Data

Partial Class Shock_Price
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Me.Title = ConfigurationManager.AppSettings("SiteTitle").ToString & "Shock Price ::"
        If Not IsPostBack Then
            Try
                Me.ucBooks1.cat_name = "Shock_Price|SHOCK199|Only Price 299 B."
                Me.Get_Cat()
            Catch ex As Exception
                uScript.Alert(Me.Page, Me.GetType, ex.Message.ToString)

            End Try

        End If
    End Sub

    Private Function Get_Cat_Xml(ByVal strfile As String) As Object
        Dim xmlDoc As XElement

        Try
            xmlDoc = XElement.Load(strfile)

            Dim Items = From c In xmlDoc.Elements("BargainShockPrice") _
                        Where CStr(c.Element("item_disc_group").Value) Like "SHOCK*" _
                        Order By CStr(c.Element("item_disc_group")) Descending _
                        Select catcode = c.Element("item_disc_group").Value, _
                        catname = Replace(c.Element("item_disc_group").Value, "SHOCK", "Only Bt. ")

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
            Me.ddlCat.DataSource = Me.Get_Cat_Xml(uXML.BargainShockPrice)
            Me.ddlCat.DataBind()

            item.Value = ""
            item.Text = " -- Select by Price Group -- "

            Me.ddlCat.Items.Insert(0, item)
            Me.ddlCat.SelectedIndex = 0
        Catch ex As Exception
            Throw ex
        Finally
            item = Nothing
        End Try
    End Sub

    Protected Sub ddlCat_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ddlCat.SelectedIndexChanged
        If ddlCat.Text <> " -- Select by Price Group -- " Then
            Me.ucBooks1.cat_name = "Shock_Price|" & Me.ddlCat.SelectedValue & "|" & Me.ddlCat.SelectedItem.Text
        Else
            Me.ucBooks1.cat_name = "Shock_Price|BARGAIN40"
        End If
    End Sub
End Class
