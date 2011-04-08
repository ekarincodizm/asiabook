Imports System.Data
Imports System.Text

Partial Class StoreDetail
    Inherits System.Web.UI.Page

    Dim ucon As uConnect

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Me.Title = ConfigurationManager.AppSettings("SiteTitle").ToString & "Store & Event ::"
        Dim id As String
        If Not (IsPostBack) Then
            id = Request.QueryString("ID")
            If String.IsNullOrEmpty(id) = False Then
                BindData(CInt(id))
            End If
        End If
    End Sub

    Private Sub BindData(ByVal id As Integer)
        ucon = New uConnect
        Dim strCommand As String
        Dim dtStore As DataTable
        Try
            strCommand = "SELECT * FROM tbm_AB_StoreAndEvent WHERE ID=" & id
            dtStore = uFunction.getDataTable(ucon.conn, strCommand)

            If (dtStore.Rows.Count > 0) Then
                Image2.ImageUrl = dtStore.Rows(0)("Large_Image_Path")
                lblSubject.Text = dtStore.Rows(0)("Subject")
                lblFullDetail.Text = dtStore.Rows(0)("Full_Detail")
            End If

        Catch ex As Exception
            uScript.Alert(Me.Page, Me.GetType, ex.Message.ToString)
        End Try
    End Sub
End Class
