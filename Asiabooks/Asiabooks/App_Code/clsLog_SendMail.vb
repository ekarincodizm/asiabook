Imports Microsoft.VisualBasic

Public Class clsLog_SendMail
    Public Shared Function InsertLog_SendMail(ByVal Description As String, ByVal Mail_To As String, ByVal Status As String, ByVal Meassge_Error As String, ByVal CreateBy As String, ByVal Order_No As String) As String
        Dim _strQuery As New StringBuilder

        _strQuery.Append("INSERT INTO [tbm_AB_LogSend_Mail]")
        _strQuery.Append("([Description],[Mail_To],[Status]")
        _strQuery.Append(",[Meassge_Error],[Order_No]")
        _strQuery.Append(",[Created],[CreateBy])")
        _strQuery.Append("VALUES")
        _strQuery.Append("('" & Description & "'")
        _strQuery.Append(",'" & Mail_To & "'")
        _strQuery.Append(",'" & Status & "'")
        _strQuery.Append(",'" & Meassge_Error & "'")
        _strQuery.Append(",'" & Order_No & "'")
        _strQuery.Append(",getdate()")
        _strQuery.Append(",'" & CreateBy & "')")

        Return _strQuery.ToString
    End Function
End Class
