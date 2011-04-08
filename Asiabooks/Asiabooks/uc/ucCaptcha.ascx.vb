
Partial Class uc_ucCaptcha
    Inherits System.Web.UI.UserControl

    Property SessionCaptcha() As String
        Get
            Return Me.hdSessionCaptcha.Value
        End Get
        Set(ByVal value As String)
            Me.hdSessionCaptcha.Value = value
        End Set
    End Property

    Property InvalidCaptcha() As Boolean
        Get
            Return True
        End Get
        Set(ByVal value As Boolean)
            If value Then

                Session(Me.hdSessionCaptcha.Value) = Me.GenerateRandomCode()
                Me.imgCaptcha.ImageUrl = "~/GetCaptchaImage.aspx?code=" & Session(Me.hdSessionCaptcha.Value)

            End If
        End Set
    End Property

    Private Function GenerateRandomCode() As String
        Dim s As String = String.Empty
        Dim r As New Random
        Dim flag As Boolean = False

        For i As Integer = 0 To 5
            If r.Next(100) Mod 2 = 0 Then
                s = String.Concat(s, Convert.ToChar(Convert.ToInt32(Math.Floor(26 * r.NextDouble() + 65))))
            Else
                s = String.Concat(s, r.Next(10).ToString)
            End If
        Next

        Return s
    End Function
End Class
