Imports Microsoft.VisualBasic

Public Class uIPAddress
    Public Shared Function InsertTransIP(ByVal ipaddress As String, ByVal sessionID As String) As String
        Dim _strQuery As New StringBuilder

        _strQuery.Append("INSERT INTO [ip_address]")
        _strQuery.Append("([IP_Address]")
        _strQuery.Append(",[SessionID]")
        _strQuery.Append(",[Created])")
        _strQuery.Append("VALUES")
        _strQuery.Append("('" & ipaddress & "'")
        _strQuery.Append(",'" & sessionID & "'")
        _strQuery.Append(",getdate())")

        Return _strQuery.ToString
    End Function
End Class
