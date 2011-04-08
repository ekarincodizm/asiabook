Imports Eordering.BusinessLogic
Imports System.Web.UI
Imports System
Imports System.Data
Imports MycustomDG
Imports Eordering.BusinessLogic.PageControl
Imports System.Data.OleDb
Imports System.Threading
Imports System.Globalization

Partial Class Shipping_Rates
    Inherits System.Web.UI.Page
    Private uCon As uConnect

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Me.Title = ConfigurationManager.AppSettings("SiteTitle").ToString & "Shipping Rate ::"
        If Not IsPostBack Then
            Get_Country()
        End If
    End Sub
    Private Sub Get_Country()
        Dim item As New ListItem
        Dim strsql As String = ""
        Dim dt As New DataTable
        Try
            uCon = New uConnect
            dt = uFunction.getDataTable(uCon.conn, "select * from tbm_syst_country order by country_name")
            Me.ddlCountry.DataTextField = "Country_Name"
            Me.ddlCountry.DataValueField = "Country_Code"
            Me.ddlCountry.DataSource = dt
            Me.ddlCountry.DataBind()
            binddata()
            'item.Value = "0"
            'item.Text = " -- Select Country -- "

            'Me.ddlCountry.Items.Insert(0, item)
            'Me.ddlCountry.SelectedIndex = 0
        Catch ex As Exception
            Throw ex
        Finally
            item = Nothing
            dt = Nothing
            uCon = Nothing
        End Try
    End Sub
    Private Sub binddata()
        Dim dt As DataTable
        Dim sqlCommand As String
        Dim condition As String = ""
        Dim pcontrol As New PageControl

        If ddlCountry.SelectedValue <> 0 Then
            If condition.Length = 0 Then
                condition &= "WHERE Country_Code = '" + ddlCountry.SelectedValue + "'"
            Else
                condition &= "AND Country_Code = '" + ddlCountry.SelectedValue + "'"
            End If
        End If

        sqlCommand = "  SELECT Transport_Type,tbm_syst_deliverycharge.Zone_Code,"
        sqlCommand &= " Weight,To_Weight,Charge_Rate,"
        sqlCommand &= " Fuel_Surcharge,Country_Code,Country_Name  "
        sqlCommand &= " From tbm_syst_deliverycharge"
        sqlCommand &= " left join tbm_syst_country"
        sqlCommand &= " on tbm_syst_deliverycharge.Zone_Code=tbm_syst_country.Zone_code " + condition
        sqlCommand &= " ORDER BY Country_Name,Weight"

        Try
            uCon = New uConnect
            dt = uFunction.getDataTable(uCon.conn, sqlCommand)
            If dt.Rows.Count > 0 Then
                Datagrid.DataSource = dt
                Datagrid.DataBind()

                Datagrid.PagerStyle.Visible = True
                Datagrid.ShowFooter = False
            Else

                Datagrid.PagerStyle.Visible = False
                Datagrid.ShowFooter = True
            End If

            Me.Label_Result.Text = pcontrol.ShowingResultSet(Me.Datagrid.CurrentPageIndex, Me.Datagrid.PageSize, dt.Rows.Count)

        Catch ex As Exception
            Throw ex
        Finally
            uCon = Nothing
            dt = Nothing
        End Try
    End Sub

    Protected Sub ddlCountry_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ddlCountry.SelectedIndexChanged
        binddata()
    End Sub

    Protected Sub Datagrid_PageIndexChanged(ByVal source As Object, ByVal e As System.Web.UI.WebControls.DataGridPageChangedEventArgs) Handles Datagrid.PageIndexChanged
        Me.Datagrid.CurrentPageIndex = e.NewPageIndex
        binddata()
    End Sub
End Class
