Imports Eordering.BusinessLogic
Imports System
Imports System.Data
Imports Eordering.BusinessLogic.PageControl
Imports System.Linq
Imports System.Xml
Imports System.Xml.Linq

Partial Class Bestsellers_SeeMore
    Inherits System.Web.UI.Page
    Private bd As New Class_book_detail
    Private _Utility As New clsUtility
    Private uCon As uConnect

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Me.Title = ConfigurationManager.AppSettings("SiteTitle").ToString & "Bestsellers ::"

        If Not IsPostBack Then
            Dim dt As New DataTable

            If Request.QueryString("Page_Name") = "UK_Today_Bestseller" Then
                dt = GetUK_Bestsellers(uXML.NewYorkUSA)

                For i As Integer = 0 To dt.Rows.Count - 1
                    Select Case i.ToString
                        Case "0"
                            ucBooks1.Visible = True
                            ucBooks1.cat_name = "Bestsellers_UK|" & dt.Rows(i).Item("type_cat")
                        Case "1"
                            ucBooks2.Visible = True
                            ucBooks2.cat_name = "Bestsellers_UK|" & dt.Rows(i).Item("type_cat")
                        Case "2"
                            ucBooks3.Visible = True
                            ucBooks3.cat_name = "Bestsellers_UK|" & dt.Rows(i).Item("type_cat")
                        Case "3"
                            ucBooks4.Visible = True
                            ucBooks4.cat_name = "Bestsellers_UK|" & dt.Rows(i).Item("type_cat")
                        Case "4"
                            ucBooks5.Visible = True
                            ucBooks5.cat_name = "Bestsellers_UK|" & dt.Rows(i).Item("type_cat")
                        Case "5"
                            ucBooks6.Visible = True
                            ucBooks6.cat_name = "Bestsellers_UK|" & dt.Rows(i).Item("type_cat")
                    End Select
                Next

            End If

            If Request.QueryString("Page_Name") = "New_Yourk_Bestseller" Then
                dt = GetNewYorkTime_Bestsellers(uXML.NewYorkUSA)
                For i As Integer = 0 To dt.Rows.Count - 1
                    Select Case i.ToString
                        Case "0"
                            ucBooks1.Visible = True
                            ucBooks1.cat_name = "Bestsellers_NewYorkTime|" & dt.Rows(i).Item("type_cat")
                        Case "1"
                            ucBooks2.Visible = True
                            ucBooks2.cat_name = "Bestsellers_NewYorkTime|" & dt.Rows(i).Item("type_cat")
                        Case "2"
                            ucBooks3.Visible = True
                            ucBooks3.cat_name = "Bestsellers_NewYorkTime|" & dt.Rows(i).Item("type_cat")
                        Case "3"
                            ucBooks4.Visible = True
                            ucBooks4.cat_name = "Bestsellers_NewYorkTime|" & dt.Rows(i).Item("type_cat")
                        Case "4"
                            ucBooks5.Visible = True
                            ucBooks5.cat_name = "Bestsellers_NewYorkTime|" & dt.Rows(i).Item("type_cat")
                        Case "5"
                            ucBooks6.Visible = True
                            ucBooks6.cat_name = "Bestsellers_NewYorkTime|" & dt.Rows(i).Item("type_cat")
                    End Select
                Next
            End If
        End If
    End Sub
    Private Function CreateDataTable() As DataTable
        Dim dt As New DataTable

        dt.Columns.Add(New DataColumn("type_cat", System.Type.GetType("System.String")))
        dt.Columns.Add(New DataColumn("type", System.Type.GetType("System.String")))

        Return dt
    End Function

    Private Function GetNewYorkTime_Bestsellers(ByVal strfile As String) As DataTable
        Dim xmlDoc As XElement
        Dim dt As New DataTable
        Dim dr As DataRow

        Try
            dt = CreateDataTable()
            xmlDoc = XElement.Load(strfile)

            Dim Items = From c In xmlDoc.Elements("NewYorkUSA") _
                        Where c.Element("type") = "NewYorkTime" _
                        Select type_cat = c.Element("type_cat").Value, _
                        type = c.Element("type").Value

            For Each item In Items.Distinct
                dr = dt.NewRow
                dr("type_cat") = item.type_cat
                dr("type") = item.type

                dt.Rows.Add(dr)
            Next
            Return dt
        Catch ex As Exception
            Throw New Exception("GetHome_Best : " & ex.Message.ToString)
            Return Nothing
        Finally
            xmlDoc = Nothing
            dt = Nothing
            dr = Nothing
        End Try
    End Function
   
    Private Function GetUK_Bestsellers(ByVal strfile As String) As DataTable
        Dim xmlDoc As XElement
        Dim dt As New DataTable
        Dim dr As DataRow

        Try
            dt = CreateDataTable()
            xmlDoc = XElement.Load(strfile)

            Dim Items = From c In xmlDoc.Elements("NewYorkUSA") _
                        Where c.Element("type") = "UK Bestsellers" _
                        Select type_cat = c.Element("type_cat").Value, _
                        type = c.Element("type").Value

            For Each item In Items.Distinct
                dr = dt.NewRow
                dr("type_cat") = item.type_cat
                dr("type") = item.type

                dt.Rows.Add(dr)
            Next
            Return dt
        Catch ex As Exception
            Throw New Exception("GetHome_Best : " & ex.Message.ToString)
            Return Nothing
        Finally
            xmlDoc = Nothing
            dt = Nothing
            dr = Nothing
        End Try
    End Function

End Class
