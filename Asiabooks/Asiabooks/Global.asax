<%@ Application Language="VB" %>
<%@ Import Namespace="Eordering.BusinessLogic" %>
<%@ Import Namespace="System.Data" %>

<script runat="server">

    Sub Application_Start(ByVal sender As Object, ByVal e As EventArgs)
        ' Code that runs on application startup
        Application("onlineuser") = 0
    End Sub
    
    Sub Application_End(ByVal sender As Object, ByVal e As EventArgs)
        ' Code that runs on application shutdown
    End Sub
        
    Sub Application_Error(ByVal sender As Object, ByVal e As EventArgs)
        ' Code that runs when an unhandled error occurs
    End Sub

    Sub Session_Start(ByVal sender As Object, ByVal e As EventArgs)
        ' Code that runs when a new session is started
        Dim uVisited As New Cls_Visited
        Dim ucon As New uConnect
        Dim dt As New DataTable
                
        Application.Lock()
        Application("onlineuser") = Convert.ToInt16(Application("onlineuser").ToString) + 1
        Session("ipaddress") = Request.UserHostAddress.ToString
        
        If Request.UserHostAddress.ToString <> "172.20.0.254" Or Request.UserHostAddress.ToString <> "66.249.69.175" _
           Or Request.UserHostAddress.ToString <> "66.249.69.143" Or Request.UserHostAddress.ToString <> "66.249.69.79" _
           Or Request.UserHostAddress.ToString <> "67.195.115.215" Or Request.UserHostAddress.ToString <> "66.249.69.235" _
           Or Request.UserHostAddress.ToString <> "66.249.69.137" Or Request.UserHostAddress.ToString <> "66.249.68.164" _
           Or Request.UserHostAddress.ToString <> "66.249.69.137" Or Request.UserHostAddress.ToString <> "74.125.152.80" _
           Or Request.UserHostAddress.ToString <> "67.195.112.166" Then
            dt.Clear()
            dt = uFunction.getDataTable(ucon.conn, "select * from ip_address where SessionID = '" + Session.SessionID + "'")
            If dt.Rows.Count = 0 Then
                uFunction.ExecuteDataStringNonTran(ucon.conn, uIPAddress.InsertTransIP(Request.UserHostAddress, Session.SessionID))
            End If
        End If
        
        Application("visituser") = uVisited.WriteCouterVisit()
        
        ucon.conn.Close()
        ucon = Nothing
        
        Application.UnLock()
    End Sub

    Sub Session_End(ByVal sender As Object, ByVal e As EventArgs)
        ' Code that runs when a session ends. 
        ' Note: The Session_End event is raised only when the sessionstate mode
        ' is set to InProc in the Web.config file. If session mode is set to StateServer 
        ' or SQLServer, the event is not raised.
        Dim ucon As New uConnect
        
        Application.Lock()
        uFunction.ExecuteDataStringNonTran(ucon.conn, "delete ip_address where SessionID = '" + Session.SessionID + "'")
        Application("onlineuser") = Convert.ToInt16(Application("onlineuser").ToString) - 1
        Application.UnLock()
    End Sub
       
</script>