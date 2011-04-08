Imports System
Imports System.Data
Imports System.Configuration
Imports System.Web
Imports System.Web.Security
Imports System.Web.UI
Imports System.Web.UI.WebControls
Imports System.Web.UI.WebControls.WebParts
Imports System.Web.UI.HtmlControls
Imports System.IO

Imports System.Security.AccessControl
Imports System.Net

''' <summary> 
''' Summary description for ExportExcelFile 
''' </summary> 

Public Class uExportFile
    Sub New()

    End Sub
    Public Sub Export(ByVal dt As Data.DataTable, ByVal page As Page, ByVal filename As String)
        Dim gv As New GridView()
        gv.DataSource = dt
        gv.DataBind()
        page.Response.ClearContent()
        page.Response.AddHeader("content-disposition", "attachment;filename=" + filename)
        page.Response.Charset = ""
        page.Response.ContentType = "application/vnd.xls"
        Dim stringWriter As New IO.StringWriter()
        Dim htmlwriter As HtmlTextWriter = New Html32TextWriter(stringWriter)
        gv.HeaderStyle.Font.Size = 10
        gv.BorderStyle = BorderStyle.Inset
        gv.RenderControl(htmlwriter)
        page.Response.Write(stringWriter.ToString())
        page.Response.[End]()
        gv = Nothing
    End Sub
    Public Sub Export(ByVal gv As GridView, ByVal page As Page, ByVal filename As String)
        page.Response.ClearContent()
        page.Response.AddHeader("content-disposition", "attachment;filename=" + filename)
        page.Response.Charset = ""
        page.Response.ContentType = "application/vnd.xls"
        Dim stringWriter As New IO.StringWriter()
        Dim htmlwriter As HtmlTextWriter = New Html32TextWriter(stringWriter)
        gv.HeaderStyle.Font.Size = 10
        gv.BorderStyle = BorderStyle.Inset
        gv.RenderControl(htmlwriter)
        page.Response.Write(stringWriter.ToString())
        page.Response.[End]()
        gv = Nothing
    End Sub
    Public Sub Export(ByVal dg As DataGrid, ByVal page As Page, ByVal filename As String)
        page.Response.ClearContent()
        page.Response.AddHeader("content-disposition", "attachment;filename=" + filename)
        page.Response.Charset = "windows-874"
        page.Response.ContentType = "application/vnd.xls"
        Dim stringWriter As New IO.StringWriter()
        Dim htmlwriter As HtmlTextWriter = New Html32TextWriter(stringWriter)
        dg.HeaderStyle.Font.Size = 10
        dg.BorderStyle = BorderStyle.Inset
        dg.RenderControl(htmlwriter)
        page.Response.Write(stringWriter.ToString())
        page.Response.[End]()
        dg = Nothing
    End Sub
    Public Function ExportHtmlToExcel(ByVal response As HttpResponse, ByVal filename As String, ByVal strExport As String) As Boolean
        Try
            response.ClearContent()
            response.AddHeader("Content-Disposition", "Attachment;Filename=" + filename + "")
            response.Cache.SetCacheability(HttpCacheability.NoCache)
            response.ContentType = "application/vnd.ms-excel"
            Dim sw As New StringWriter()
            Dim htw As New HtmlTextWriter(sw)
            Dim frm As New HtmlForm
            frm.Attributes("runat") = "server"

            response.Write(strExport)
            response.End()
            Return True
        Catch ex As Exception
            Throw ex
            Return False
        End Try
    End Function
    Public Function ExportHtmlToExcel(ByVal response As HttpResponse, ByVal filename As String, ByVal strExport As StringBuilder) As Boolean
        Try
            response.ClearContent()
            response.AddHeader("Content-Disposition", "Attachment;Filename=" + filename + "")
            response.Cache.SetCacheability(HttpCacheability.NoCache)
            response.ContentType = "application/vnd.ms-excel"
            Dim sw As New StringWriter(strExport)
            Dim htw As New HtmlTextWriter(sw)
            Dim frm As New HtmlForm
            frm.Attributes("runat") = "server"

            response.Write(sw.ToString)
            response.End()
            Return True
        Catch ex As Exception
            Throw ex
            Return False
        End Try
    End Function
End Class