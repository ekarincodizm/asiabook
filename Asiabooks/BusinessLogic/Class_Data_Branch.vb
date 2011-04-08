Imports Microsoft.VisualBasic
Imports Eordering.BusinessLogic
Imports System
Imports System.Data
Public Class Class_Data_Branch

    Public sales_channal As String

    Public header As String
    Public keyword As String
    Public ID As Integer
    Public image As String
    Public Book_Title As String
    Public Author As String
    Public isbn_13 As String
    Public Publisher_name As String
    Public Size As String
    Public Weight As Double
    Public binding_description As String
    Public Page_qty As Integer
    Public Subject_name As String
    Public Stock_status As String
    Public Publication_Date As String
    Public Selling_Price As Double

    Public dt_Branch_AB As DataTable
    Public dt_Branch_BO As DataTable
    Public dt_Branch_BZ As DataTable
    Public dt_Branch_KPS As DataTable
    Public dt_Branch_HO As DataTable

End Class
