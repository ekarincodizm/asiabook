Imports Microsoft.VisualBasic
Imports Eordering.BusinessLogic
Imports System
Imports System.Data
Imports System.Configuration
Public Class UserDetail
    Public Function GetEmpId(ByVal UserName As String, ByVal domain As String)
        Dim SqlDb As New SqlDb
        Dim dt As DataTable
        Dim sqlCommand As String
        sqlCommand = "SELECT * FROM tbm_syst_emp WHERE empcd ='" & UserName & "'"
        sqlCommand += " and domain ='" + domain + "'"
        dt = SqlDb.GetDataTable(sqlCommand)
        Return dt
    End Function
    Public Function GetEmpIdlogin(ByVal UserName As String, ByVal PassWord As String)
        Dim SqlDb As New SqlDb
        Dim User As String = ""
        Dim dt As DataTable = SqlDb.GetDataTable("SELECT * FROM tbm_syst_emp WHERE empcd='" & UserName & "' AND password = '" & PassWord & "'")
        Return dt
    End Function
    'Public Function GetPermition(ByVal FormName As String) As Boolean
    '    Dim status As String = ""
    '    Dim SqlDb As New SqlDb
    '    Dim dt As DataTable = SqlDb.GetDataTable("SELECT  * FROM  v_secure WHERE formcd = '" & FormName & "'")
    '    If dt.Rows.Count = 0 Then
    '        Return False
    '    Else
    '        If dt.Rows(0)("sctylvl") = "0" Then
    '            Return True
    '        Else
    '            Return False
    '        End If
    '    End If
    'End Function
    'Public Function GetEmpName(ByVal UserName As String) As String
    '    Dim SqlDb As New SqlDb
    '    Dim User As String = ""
    '    Dim dt As DataTable = SqlDb.GetDataTable("SELECT * FROM tbm_syst_emp WHERE empcd='" & UserName & "'")
    '    If dt.Rows.Count > 0 Then
    '        User = dt.Rows(0)(1).ToString
    '    Else
    '        User = ""
    '    End If
    '    Return User
    'End Function
End Class

