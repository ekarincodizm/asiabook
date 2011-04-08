Imports System
Imports System.Data
Imports System.Configuration
Imports System.Collections
Imports System.Web
Imports System.Web.Security
Imports System.Web.UI
Imports System.Web.UI.WebControls
Imports System.Web.UI.WebControls.WebParts
Imports System.Web.UI.HtmlControls
Imports Eordering.BusinessLogic


Partial Class uc_PopEmp
    Inherits System.Web.UI.UserControl
    Dim sqlDB As New SqlDb
    Public Event Change As EventHandler(Of EventArgs)
    Public Property AutoPostBack() As Boolean
        Get
            Return Me.cboEmp.AutoPostBack
        End Get
        Set(ByVal value As Boolean)
            Me.cboEmp.AutoPostBack = value
        End Set
    End Property
    Protected Sub btnSearch_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnSearch.Click
        Dim dt As New DataTable
        dt = sqlDB.GetDataTable("select * from tbm_syst_country" & Me.GetCondition() & " order by Country_Name")
        grdDetail.DataSource = dt
        grdDetail.DataBind()

        Dim gr As GridViewRow
        For Each gr In grdDetail.Rows
            Dim tbx As TextBox = CType(gr.FindControl("tbxId"), TextBox)
            tbx.Attributes.Add("onclick", "selectData" & Me.ClientID & "(this.value," & Me.cboEmp.ClientID & ");")
        Next

    End Sub
    Private Function GetCondition() As String
        If ddlSearch.SelectedValue = "0" Then
            GetCondition = " Where Country_Code Like '%" + Me.tbxSearch.Text + "%'"
        Else
            GetCondition = " Where Country_Name Like '%" + Me.tbxSearch.Text + "%'"
        End If
    End Function

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Me.IsPostBack = False Then



        End If
       
    End Sub
    Public Sub ShowData(ByVal value As String)
        Dim dt As New DataTable
        Dim strstring As String
        strstring = "select distinct country_code,country_name,a.zone_code "
        strstring &= " from tbm_syst_deliverycharge a,tbm_syst_country b"
        strstring &= " where(a.zone_code = b.zone_code)"
        strstring &= " and transport_type='" + value + "'"
        strstring &= " order by Country_Name"
        dt = sqlDB.GetDataTable(strstring)
        Me.cboEmp.DataTextField = "Country_Name"
        Me.cboEmp.DataValueField = "Country_Code"
        Me.cboEmp.DataSource = dt
        Me.cboEmp.DataBind()

        'Dim Item As New ListItem
        'Item.Text = " ----- ALL ----- "
        'Item.Value = "0"
        'cboEmp.Items.Insert(0, Item)

        'cboEmp.SelectedIndex = 0
        Me.grdDetail.DataSource = dt
        Me.grdDetail.DataBind()
        Dim gr As GridViewRow
        For Each gr In grdDetail.Rows
            Dim tbx As TextBox = CType(gr.FindControl("tbxId"), TextBox)
            tbx.Attributes.Add("onclick", "selectData" & Me.ClientID & "(this.value," & Me.cboEmp.ClientID & ");")
        Next

        'If value <> "" Then
        '    cboEmp.SelectedValue = value
        'End If
    End Sub
    Public Property ShowNull() As Boolean
        Get
            If IsDBNull(Me.ViewState("ShowNull")) Then
                Me.ViewState("ShowNull") = True
            End If
            Return Me.ViewState("ShowNull")
        End Get
        Set(ByVal value As Boolean)
            Me.ViewState("ShowNull") = value
        End Set
    End Property

    Public Property Value() As String
        Get
            If Me.cboEmp.SelectedValue = "" Then
                Return "0"
            Else
                Return Me.cboEmp.SelectedValue
            End If
        End Get
        Set(ByVal value As String)
            Me.cboEmp.SelectedValue = value
        End Set
    End Property

    Public Property Text() As String
        Get
            Return Me.cboEmp.SelectedItem.Text
        End Get
        Set(ByVal value As String)
            Me.cboEmp.SelectedItem.Text = value
        End Set
    End Property
    Public Property cboEnabel() As Boolean
        Get
            Return Me.cboEmp.Enabled
        End Get
        Set(ByVal value As Boolean)
            Me.cboEmp.Enabled = value
        End Set
    End Property
    Protected Sub cboEmp_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboEmp.SelectedIndexChanged
        RaiseEvent Change(sender, e)

    End Sub

End Class
