
Partial Class GetCaptchaImage
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Me.Response.Cache.SetCacheability(HttpCacheability.NoCache)

        Dim ci As New CaptchaImage(Me.Request.QueryString("code").ToString(), 120, 30, "Tahoma")

        Me.Response.Clear()
        Me.Request.ContentType = "image/jpeg"
        ci.Image.Save(Me.Response.OutputStream, System.Drawing.Imaging.ImageFormat.Jpeg)
        ci.Dispose()
    End Sub
End Class
