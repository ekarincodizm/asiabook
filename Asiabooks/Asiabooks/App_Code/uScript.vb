Imports System.Web.UI

Public Class uScript

    Public Shared Sub Alert(ByVal p As Page, ByVal type As System.Type, ByVal msg As String)
        ScriptManager.RegisterClientScriptBlock(p, type, "Alert", "alert('" + msg.Replace("'", "\'").Replace(Environment.NewLine, "\n\r") + "');", True)
    End Sub
    Public Shared Sub Alert(ByVal p As Control, ByVal type As System.Type, ByVal msg As String)
        ScriptManager.RegisterClientScriptBlock(p, type, "Alert", "alert('" + msg.Replace("'", "\'").Replace(Environment.NewLine, "\n\r") + "');", True)
    End Sub

    Public Shared Sub WindowOpen(ByVal p As Page, ByVal type As System.Type, ByVal url As String)
        ScriptManager.RegisterClientScriptBlock(p, type, "Windows Open", "window.open('" + url + "');", True)
    End Sub
    Public Shared Sub WindowOpen(ByVal p As Control, ByVal type As System.Type, ByVal url As String)
        ScriptManager.RegisterClientScriptBlock(p, type, "Windows Open", "window.open('" + url + "');", True)
    End Sub

    Public Shared Sub WindowClose(ByVal p As Page, ByVal type As System.Type)
        ScriptManager.RegisterClientScriptBlock(p, type, "Windows Open", "window.close();", True)
    End Sub
    Public Shared Sub WindowClose(ByVal p As Control, ByVal type As System.Type)
        ScriptManager.RegisterClientScriptBlock(p, type, "Windows Open", "window.close();", True)
    End Sub
End Class
