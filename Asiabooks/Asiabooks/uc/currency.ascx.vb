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

    Protected Sub btnSearch_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnSearch.Click
        Dim dt As New DataTable
        dt = sqlDB.GetDataTable("select * from dbo.tbm_syst_currency" & Me.GetCondition())
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
            GetCondition = " Where Currency_Code Like '%" + Me.tbxSearch.Text + "%'"
        Else
            GetCondition = " Where Currency_Code Like '%" + Me.tbxSearch.Text + "%'"
        End If
    End Function

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        'If Me.IsPostBack = False Then
        '    Dim dt As New DataTable
        '    dt = sqlDB.GetDataTable("select * from dbo.tbm_syst_currency")
        '    Me.cboEmp.DataTextField = "Currency_Code"
        '    Me.cboEmp.DataValueField = "Currency_Code"
        '    Me.cboEmp.DataSource = dt
        '    Me.cboEmp.DataBind()
        '    'If ShowNull Then
        '    Dim Item As New ListItem
        '    Item.Text = " ----- ALL ----- "
        '    Item.Value = "0"
        '    cboEmp.Items.Insert(0, Item)
        '    'End If
        '    cboEmp.SelectedIndex = 0


        '    Me.grdDetail.DataSource = dt
        '    Me.grdDetail.DataBind()
        '    Dim gr As GridViewRow
        '    For Each gr In grdDetail.Rows
        '        Dim tbx As TextBox = CType(gr.FindControl("tbxId"), TextBox)
        '        tbx.Attributes.Add("onclick", "selectData" & Me.ClientID & "(this.value," & Me.cboEmp.ClientID & ");")
        '    Next




        'End If
    End Sub
    Public Sub ShowData(ByVal value As String)
        Dim dt As New DataTable
        dt = sqlDB.GetDataTable("select * from dbo.tbm_syst_currency")
        Me.cboEmp.DataTextField = "Currency_Code"
        Me.cboEmp.DataValueField = "Currency_Code"
        Me.cboEmp.DataSource = dt
        Me.cboEmp.DataBind()
        'If ShowNull Then
        Dim Item As New ListItem
        Item.Text = " ----- ALL ----- "
        Item.Value = "0"
        cboEmp.Items.Insert(0, Item)
        'End If
        cboEmp.SelectedIndex = 0


        Me.grdDetail.DataSource = dt
        Me.grdDetail.DataBind()
        Dim gr As GridViewRow
        For Each gr In grdDetail.Rows
            Dim tbx As TextBox = CType(gr.FindControl("tbxId"), TextBox)
            tbx.Attributes.Add("onclick", "selectData" & Me.ClientID & "(this.value," & Me.cboEmp.ClientID & ");")
        Next

        If value <> "" Then
            cboEmp.SelectedValue = value
        End If
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

End Class
