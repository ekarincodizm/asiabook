Imports System
Imports System.Data
Imports System.Text
Imports System.Data.Sql
Imports System.Collections
Imports System.Data.OleDb
Imports System.Configuration
Imports System.Data.SqlClient
Imports System.Collections.Generic
Imports System.Configuration.Assemblies
Imports System.IO

Imports Microsoft.Win32

Public Class SqlDb
    Private cnn As OleDbConnection
    Private trn As OleDbTransaction
    Private adp As OleDbDataAdapter
    Private IsoLevel As IsolationLevel = IsolationLevel.ReadUncommitted
    'private OleDbCommand cmd ; 

    Private strConnectString As String = ""

    Private Function GetConnectionString() As String

        Dim servername As String = ""
        Dim dbname As String = ""
        Dim userid As String = ""
        Dim password As String = ""

        Dim myTextFile As New StreamReader(System.AppDomain.CurrentDomain.BaseDirectory() & "\config.txt")

        Do While myTextFile.Peek() > -1
            Dim strText() As String = (myTextFile.ReadLine).Split("=")
            Select Case strText(0)
                ' Database
                Case "Server"
                    servername = strText(1)
                Case "DbName"
                    dbname = strText(1)
                Case "User"
                    userid = strText(1)
                Case "Password"
                    password = strText(1)
            End Select
        Loop

        'Dim strServerName As String = Convert.ToString("TEEIBM\SQL2005")
        'Dim strDatabaseName As String = Convert.ToString("ASBKEO")
        'Dim strUserID As String = Convert.ToString("sa")
        'Dim strPassword As String = Convert.ToString("123456")

        Dim strServerName As String = Convert.ToString(servername)
        Dim strDatabaseName As String = Convert.ToString(dbname)
        Dim strUserID As String = Convert.ToString(userid)
        Dim strPassword As String = Convert.ToString(password)
        'Dim strServerName As String = Convert.ToString("192.168.0.1")
        'Dim strDatabaseName As String = Convert.ToString("ASBKEO")
        'Dim strUserID As String = Convert.ToString("sa")
        'Dim strPassword As String = Convert.ToString("123456")

        strConnectString = "Provider=SQLOLEDB;data source=" + strServerName + ";User ID=" + strUserID + ";password=" + strPassword + ";Initial Catalog=" + strDatabaseName + ";Connect Timeout=12000"
        Return strConnectString
    End Function

    Public Sub New()

        Try
            'string strConnectString = ConfigurationSettings.AppSettings["strConnOledb"].ToString(); 

            strConnectString = GetConnectionString()

            cnn = New OleDbConnection(strConnectString)

        Catch ex As Exception
            Throw (New Exception("SqlDb:SqlDb():" + ex.Message))
        End Try
    End Sub

    Public Sub BeginTrans()
        Try
            If cnn.State = ConnectionState.Closed Then
                cnn.Open()

            End If

            'cmd = cnn.CreateCommand(); 
            'cmd.Transaction = trn; 
            trn = cnn.BeginTransaction(IsoLevel)

        Catch ex As Exception
            Throw New Exception("SqlDb:BeginTrans():" + ex.Message)
        End Try
    End Sub

    Public Sub RollbackTrans()
        Try
            trn.Rollback()
            'strTranName 
            If cnn.State = ConnectionState.Open Then
                cnn.Close()
            End If
        Catch ex As Exception
            Throw New Exception("SqlDb:RollbackTrans():" + ex.Message)
        Finally
            trn = Nothing
            cnn.Close()
        End Try
    End Sub

    Public Sub CommitTrans()
        Try
            trn.Commit()
            If cnn.State = ConnectionState.Open Then
                cnn.Close()
            End If
        Catch ex As Exception
            Throw New Exception("SqlDb:CommitTrans():" + ex.Message)
        Finally
            trn = Nothing
            cnn.Close()
        End Try

    End Sub

    Public Function CreateCommand(ByVal StrSQL As String) As OleDbCommand
        If trn Is Nothing Then
            Return New OleDbCommand(StrSQL, New OleDbConnection(strConnectString))
        Else
            Return New OleDbCommand(StrSQL, cnn, trn)
        End If
    End Function

    Public Sub Exec(ByVal str As String)
        Dim cmd As OleDbCommand = CreateCommand(str)
        Try

            cmd.ExecuteNonQuery()
            cmd.CommandTimeout = 120
        Catch ex As Exception
            Throw New Exception("SqlDb:Execute(string):" + ex.Message)
        End Try
    End Sub

    Public Function ExecQuery(ByVal str As String) As DataTable
        Dim cmd As OleDbCommand = CreateCommand(str)

        Try
            adp = Nothing
            adp = New OleDbDataAdapter(cmd)

            Dim dst As New DataSet()
            adp.Fill(dst)
            Return dst.Tables(0)
        Catch ex As Exception
            Throw (New Exception("SqlDb:Query2DataTable(string):" + ex.Message + " "))
        End Try
    End Function
    Public Function GetDataset(ByVal str As String) As DataSet
        Dim cmd As OleDbCommand = CreateCommand(str)

        Try
            adp = Nothing
            adp = New OleDbDataAdapter(cmd)

            Dim dst As New DataSet()
            adp.Fill(dst)
            Return dst
        Catch ex As Exception
            Throw (New Exception("SqlDb:Query2DataTable(string):" + ex.Message + " "))
        End Try

    End Function
    Public Function GetDataRow(ByVal cmd As OleDbCommand) As DataRow
        Try
            adp = Nothing
            adp = New OleDbDataAdapter(cmd)

            Dim dst As New DataSet()
            adp.Fill(dst)
            If dst.Tables(0).Rows.Count = 0 Then
                Return Nothing
            Else
                Return dst.Tables(0).Rows(0)
            End If
        Catch ex As Exception
            Throw New Exception("SqlDb:Query2DataRow(string):" + ex.Message)
        End Try

    End Function

    Public Function GetDataTable(ByVal cmd As OleDbCommand) As DataTable
        Try
            adp = Nothing
            adp = New OleDbDataAdapter(cmd)

            Dim dst As New DataSet()
            adp.Fill(dst)
            Return dst.Tables(0)
        Catch ex As Exception
            Throw (New Exception("SqlDb:Query2DataTable(string):" + ex.Message + " "))
        End Try
    End Function

    Public Function GetDataTable(ByVal str As String) As DataTable
        Dim cmd As OleDbCommand = CreateCommand(str)
        Try
            adp = Nothing
            adp = New OleDbDataAdapter(cmd)
            cmd.CommandTimeout = 500
            Dim dst As New DataSet()
            adp.Fill(dst)
            Return dst.Tables(0)
        Catch ex As Exception
            Throw (New Exception("SqlDb:Query2DataTable(string):" + ex.Message + " "))
        End Try
    End Function

    Public Function ExecReder(ByVal cmd As OleDbCommand) As Object
        Dim drd As OleDbDataReader = cmd.ExecuteReader()
        If drd.Read() Then
            Dim obj As Object = drd.GetValue(0)
            drd.Close()
            Return obj
        End If
        drd.Close()
        Return DBNull.Value
    End Function

    Public Function GetDateTime() As DateTime
        Dim cmd As OleDbCommand = CreateCommand("select getdate()")
        Dim dr As DataRow = GetDataRow(cmd)
        Dim datetime As DateTime = Convert.ToDateTime(dr(0))
        If datetime.Year > 2473 Then
            datetime = datetime.AddYears(-543)
        End If
        Return datetime
    End Function

    Public Function GetDateTime_String() As String
        Dim cmd As OleDbCommand = CreateCommand("select convert(nvarchar(30),getdate(),100)")
        Dim dr As DataRow = GetDataRow(cmd)
        Dim datetime As String = dr(0).ToString()
        Return datetime
    End Function

    Public Function GetDateTime_db() As String
        Dim cmd As OleDbCommand = CreateCommand("select convert(nvarchar(30),getdate(),102)")
        Dim dr As DataRow = GetDataRow(cmd)
        Dim datetime As String = dr(0).ToString().Replace(".", "-")
        Return datetime
    End Function

    Public Property Transaction() As OleDbTransaction
        Get
            Return trn
        End Get
        Set(ByVal value As OleDbTransaction)
            trn = value
        End Set
    End Property
    Public Property Connection() As OleDbConnection
        Get
            Return cnn
        End Get
        Set(ByVal value As OleDbConnection)
            cnn = value
        End Set
    End Property

    Public Property IsolationLevel() As IsolationLevel
        Get
            Return IsoLevel
        End Get
        Set(ByVal value As IsolationLevel)
            IsoLevel = value
        End Set
    End Property

End Class
