Imports System
Imports System.Data

Partial Class Utility_BooksList
    Inherits System.Web.UI.Page

    Private Dt As New DataTable
    Private DtRight As New DataTable
    Private DtLeft As New DataTable

    Private SqlCommand As New clsSqlCommand
    Private Utility As New clsUtility

    Private Sub BindData()
        Try
            Session("DtRight") = DtRight
            Session("DtLeft") = DtLeft

            If Not IsNothing(DtLeft) Or DtLeft.Rows.Count > 0 Then
                Me.GridView_Left.Visible = True
                Me.GridView_Left.DataSource = DtLeft
                Me.GridView_Left.DataBind()
            Else
                Me.GridView_Left.Visible = False
            End If

            If Not IsNothing(DtRight) Or DtRight.Rows.Count > 0 Then
                Me.GridView_Right.Visible = True
                Me.GridView_Right.DataSource = DtRight
                Me.GridView_Right.DataBind()
            Else
                Me.GridView_Right.Visible = False
            End If

        Catch ex As Exception
            Throw New Exception("BindData : " & ex.Message)
        End Try
    End Sub

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Try
            If Not IsPostBack Then
                Me.Dt = SqlCommand.Select_SpecialBook_NewArrival

                If Not IsNothing(Dt) Or Dt.Rows.Count > 0 Then
                    For Each Dc As DataColumn In Me.Dt.Columns
                        Me.DtLeft.Columns.Add(Dc.ColumnName)
                        Me.DtRight.Columns.Add(Dc.ColumnName)
                    Next
                Else
                    Exit Sub
                End If

                If Me.Dt.Rows.Count > Me.GridView_Left.PageSize Then
                    For i As Integer = 0 To Me.GridView_Left.PageSize - 1
                        Me.DtLeft.ImportRow(Me.Dt.Rows(i))
                    Next

                    For i As Integer = Me.GridView_Left.PageSize To Me.Dt.Rows.Count - 1
                        Me.DtRight.ImportRow(Me.Dt.Rows(i))
                    Next
                Else
                    For i As Integer = 0 To Me.Dt.Rows.Count - 1
                        Me.DtLeft.ImportRow(Me.Dt.Rows(i))
                    Next
                End If

                If Me.DtRight.Rows.Count > 0 Then
                    For Each Dr As DataRow In Me.DtRight.Rows
                        If Dr("Book_Title").ToString.Length > 45 Then
                            Dr("Book_Title") = Left(Dr("Book_Title"), 45) & "..."
                        End If
                    Next
                End If

                Me.BindData()

            Else
                DtRight = Session("DtRight")
                DtLeft = Session("DtLeft")
            End If
        Catch ex As Exception
            ScriptManager.RegisterClientScriptBlock(Me.Page, Me.GetType, "Alert", "alert('" & ex.Message & "');", True)
        End Try
    End Sub

End Class
