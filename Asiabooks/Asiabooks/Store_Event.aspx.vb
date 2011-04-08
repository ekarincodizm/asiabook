Imports System.Data

Partial Class Store_Event
    Inherits System.Web.UI.Page
    Private uCon As uConnect

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
        Me.Title = ConfigurationManager.AppSettings("SiteTitle").ToString & "Store & Event ::"
        If Not IsPostBack Then
            GetPromotion()
            GetgvEvent()
            Get_BranchAB()
            Get_BranchBZ()
        End If
    End Sub
    Private Sub Get_BranchAB()
        Dim dt_ab As New DataTable
        Dim strsql As String = ""
        uCon = New uConnect
        dt_ab.Clear()
        dt_ab = uFunction.getDataTable(uCon.conn, "select * from tbm_syst_organizeab where Group_Code = 'AB' and zone = 'Central' and status <> 'N' order by province,org_ab_name")
        If dt_ab.Rows.Count > 0 Then
            gvAB_Central.DataSource = dt_ab
            gvAB_Central.DataBind()
        End If
        dt_ab.Clear()
        dt_ab = uFunction.getDataTable(uCon.conn, "select * from tbm_syst_organizeab where Group_Code = 'AB' and zone = 'Northeast' and status <> 'N' order by province,org_ab_name")
        If dt_ab.Rows.Count > 0 Then
            gvAB_Northeast.DataSource = dt_ab
            gvAB_Northeast.DataBind()
        End If
        dt_ab.Clear()
        dt_ab = uFunction.getDataTable(uCon.conn, "select * from tbm_syst_organizeab where Group_Code = 'AB' and zone = 'Southern' and status <> 'N' order by province,org_ab_name")
        If dt_ab.Rows.Count > 0 Then
            gvAB_Southern.DataSource = dt_ab
            gvAB_Southern.DataBind()
        End If
        dt_ab.Clear()
        dt_ab = uFunction.getDataTable(uCon.conn, "select * from tbm_syst_organizeab where Group_Code = 'AB' and zone = 'Northern' and status <> 'N' order by province,org_ab_name")
        If dt_ab.Rows.Count > 0 Then
            gvAB_Nothern.DataSource = dt_ab
            gvAB_Nothern.DataBind()
        End If

        dt_ab.Clear()
        dt_ab = uFunction.getDataTable(uCon.conn, "select count(*) as total from tbm_syst_organizeab where Group_Code = 'AB' and status <> 'N'")
        If dt_ab.Rows.Count > 0 Then
            lblTotal_ShopAB.Text = dt_ab.Rows(0).Item("total").ToString
        End If
    End Sub
    Private Sub Get_BranchBZ()
        Dim dt_bz As New DataTable
        Dim strsql As String = ""
        uCon = New uConnect
        dt_bz.Clear()
        dt_bz = uFunction.getDataTable(uCon.conn, "select * from tbm_syst_organizeab where Group_Code = 'BZ' and zone = 'Central' and status <> 'N' order by province,org_ab_name")
        If dt_bz.Rows.Count > 0 Then
            gvBZ_Central.DataSource = dt_bz
            gvBZ_Central.DataBind()
        End If
        dt_bz.Clear()
        dt_bz = uFunction.getDataTable(uCon.conn, "select * from tbm_syst_organizeab where Group_Code = 'BZ' and zone = 'Northern' and status <> 'N' order by province,org_ab_name")
        If dt_bz.Rows.Count > 0 Then
            gvBZ_Northern.DataSource = dt_bz
            gvBZ_Northern.DataBind()
        End If
        dt_bz.Clear()
        dt_bz = uFunction.getDataTable(uCon.conn, "select * from tbm_syst_organizeab where Group_Code = 'BZ' and zone = 'Southern' and status <> 'N' order by province,org_ab_name")
        If dt_bz.Rows.Count > 0 Then
            gvBZ_Southern.DataSource = dt_bz
            gvBZ_Southern.DataBind()
        End If

        dt_bz.Clear()
        dt_bz = uFunction.getDataTable(uCon.conn, "select count(*) as total from tbm_syst_organizeab where Group_Code = 'BZ' and status <> 'N' ")
        If dt_bz.Rows.Count > 0 Then
            lblTotal_ShopBZ.Text = dt_bz.Rows(0).Item("total").ToString
        End If
    End Sub
    Private Sub GetPromotion()
        uCon = New uConnect
        Dim strCommand As New StringBuilder
        Dim dtStore As New DataTable

        Try
            strCommand.Append("SELECT tbm_AB_StoreAndEvent.* ")
            strCommand.Append("FROM tbm_AB_Type_StoreEvent INNER JOIN tbm_AB_StoreAndEvent ")
            strCommand.Append("ON tbm_AB_Type_StoreEvent.Type_StoreEvent_ID = tbm_AB_StoreAndEvent.Type_StoreEvent_ID ")
            strCommand.Append("WHERE tbm_AB_Type_StoreEvent.Is_Active='Y' AND tbm_AB_StoreAndEvent.Is_Active='Y' AND AllTime_Display='Y' AND Type_Code = 'Promotion' ")
            strCommand.Append("UNION ")
            strCommand.Append("SELECT tbm_AB_StoreAndEvent.* ")
            strCommand.Append("FROM tbm_AB_Type_StoreEvent INNER JOIN tbm_AB_StoreAndEvent ")
            strCommand.Append("ON tbm_AB_Type_StoreEvent.Type_StoreEvent_ID = tbm_AB_StoreAndEvent.Type_StoreEvent_ID ")
            strCommand.Append("WHERE tbm_AB_Type_StoreEvent.Is_Active='Y' AND tbm_AB_StoreAndEvent.Is_Active='Y' AND AllTime_Display='N'")
            strCommand.Append("AND Type_Code = 'Promotion' AND Starting_date_Display >= GETDATE() AND Ending_date_Display <= GETDATE() order by created desc")
            dtStore = uFunction.getDataTable(uCon.conn, strCommand.ToString())

            If (dtStore.Rows.Count > 0) Then
                gvPromotion.DataSource = dtStore
                gvPromotion.DataBind()
            End If
        Catch ex As Exception
            uScript.Alert(Me.Page, Me.GetType, ex.Message.ToString)
        End Try
    End Sub
    Private Sub GetgvEvent()
        uCon = New uConnect
        Dim strCommand As New StringBuilder
        Dim dtStore As New DataTable

        Try
            strCommand.Append("SELECT tbm_AB_StoreAndEvent.* ")
            strCommand.Append("FROM tbm_AB_Type_StoreEvent INNER JOIN tbm_AB_StoreAndEvent ")
            strCommand.Append("ON tbm_AB_Type_StoreEvent.Type_StoreEvent_ID = tbm_AB_StoreAndEvent.Type_StoreEvent_ID ")
            strCommand.Append("WHERE tbm_AB_Type_StoreEvent.Is_Active='Y' AND tbm_AB_StoreAndEvent.Is_Active='Y' AND AllTime_Display='Y' AND Type_Code = 'Event' ")
            strCommand.Append("UNION ")
            strCommand.Append("SELECT tbm_AB_StoreAndEvent.* ")
            strCommand.Append("FROM tbm_AB_Type_StoreEvent INNER JOIN tbm_AB_StoreAndEvent ")
            strCommand.Append("ON tbm_AB_Type_StoreEvent.Type_StoreEvent_ID = tbm_AB_StoreAndEvent.Type_StoreEvent_ID ")
            strCommand.Append("WHERE tbm_AB_Type_StoreEvent.Is_Active='Y' AND tbm_AB_StoreAndEvent.Is_Active='Y' AND AllTime_Display='N'")
            strCommand.Append("AND Type_Code = 'Event' AND Starting_date_Display >= GETDATE() AND Ending_date_Display <= GETDATE() order by created desc")
            dtStore = uFunction.getDataTable(uCon.conn, strCommand.ToString())

            If (dtStore.Rows.Count > 0) Then
                gvEvent.DataSource = dtStore
                gvEvent.DataBind()
            End If
        Catch ex As Exception
            uScript.Alert(Me.Page, Me.GetType, ex.Message.ToString)
        End Try
    End Sub

    Protected Sub lnkWarehouse_Thai_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lnkWarehouse_Thai.Click
        mdlPopupMap_Thai.Show()
    End Sub

    Protected Sub lnkWarehouse_Eng_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lnkWarehouse_Eng.Click
        mdlPopupMap_En.Show()
    End Sub

    Protected Sub lnkHeadOffice_Thai_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lnkHeadOffice_Thai.Click
        mdlPopupMapHO_Th.Show()
    End Sub

    Protected Sub lnkHeadOffice_Eng_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lnkHeadOffice_Eng.Click
        mdlPopupMapHO_En.Show()
    End Sub

End Class
