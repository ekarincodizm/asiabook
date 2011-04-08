
Partial Class uc_dtp
    Inherits System.Web.UI.UserControl
    Public Property Value() As String
        Get
            Return Me.tbxDate1.Text
        End Get
        Set(ByVal value As String)
            Me.tbxDate1.Text = value
        End Set
    End Property


    Public Property Dates() As DateTime
        Get
            Return Me.c.SelectedDate.Value
        End Get
        Set(ByVal value As DateTime)
            Me.tbxDate1.Text = value.Date.ToString("dd/MM/yyyy")
        End Set
    End Property

    Public ReadOnly Property DateQuery() As String
        Get
            Dim year As Integer
            year = Convert.ToInt64(tbxDate1.Text.Substring(6, 4))
            If year > 2473 Then
                year = year - 543
            End If
            Return year.ToString() & "-" & tbxDate1.Text.Substring(3, 2) & "-" & tbxDate1.Text.Substring(0, 2)
        End Get

    End Property

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

    End Sub
End Class


