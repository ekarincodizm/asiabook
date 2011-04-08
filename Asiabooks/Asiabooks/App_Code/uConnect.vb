Imports System
Imports System.Data
Imports System.Data.SqlClient
Imports System.Configuration

Public Class uConnect

    Public conn As SqlConnection
    Public tr As SqlTransaction

    Public Sub New()
        conn = New SqlConnection(ConfigurationManager.AppSettings("Driv").ToString)

        If conn.State = ConnectionState.Closed Then
            conn.Open()
        End If
    End Sub
    Public Sub New(ByVal driver As String)
        conn = New SqlConnection(driver)

        If conn.State = ConnectionState.Closed Then
            conn.Open()
        End If
    End Sub
End Class
