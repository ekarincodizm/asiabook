Imports System
Imports System.Data
Imports System.Data.SqlClient
Imports System.IO
Imports System.Text
Imports System.Data.OleDb

Partial Class Update_Data_WebAsiabooks
    Inherits System.Web.UI.Page
    Private uCon As uConnect
    Private Dt As New DataTable
    Private clsSql As New sqlImageFileControl

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Me.Title = ConfigurationManager.AppSettings("SiteTitle").ToString & "Update data web asiabooks ::"
    End Sub

    Protected Sub btnSave_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles btnSave.Click
        If Me.fuText1.HasFile = True Then
            If UpdateRecommend() = False Then
                ScriptManager.RegisterClientScriptBlock(Me.Page, Me.GetType, "Alert", "alert('Can not insert data excel for web asiabooks');", True)
                Exit Sub
            Else
                Panel1.Visible = False
                ScriptManager.RegisterClientScriptBlock(Me.Page, Me.GetType, "Alert", "alert('Update data complete');", True)
                Exit Sub
            End If
        End If
    End Sub
    Private Function UpdateRecommend() As Boolean
        Try

            Dim FileFullName As String = Me.fuText1.PostedFile.FileName
            Dim extension As String = System.IO.Path.GetExtension(FileFullName)
            Dim FileName As String = System.IO.Path.GetFileName(FileFullName)
            Dim FilesPath As String = Server.MapPath("Upload\" & FileName)
            CheckAndRenameFile(FilesPath)
            If extension.ToLower = ".xls" Then
                Me.fuText1.PostedFile.SaveAs(FilesPath)
                BackUp_Table()

                If Me.Read_Data_Excel(FilesPath) = False Then
                    ScriptManager.RegisterClientScriptBlock(Me.Page, Me.GetType, "Alert", "alert('Can not read excel file');", True)
                    Exit Function
                End If
            Else
                ScriptManager.RegisterClientScriptBlock(Me.Page, Me.GetType, "Alert", "alert('Please use text file or excel file');", True)
                Exit Function
            End If
            Return True

        Catch ex As Exception
            ScriptManager.RegisterClientScriptBlock(Me.Page, Me.GetType, "Alert", "alert('" & ex.Message & "');", True)
        End Try
    End Function
    Private Function BackUp_Table() As Boolean
        Try
            uCon = New uConnect

            Dim strTable_Name As String = ""
            strTable_Name = "[tbm_AB_BestSeller_" & Format(Now, "yyyyMMdd") & "]"

            uFunction.ExecuteDataStringNonTran(uCon.conn, "drop table " + strTable_Name + "")

            Dim _strQuery As New StringBuilder

            _strQuery.Append("	CREATE TABLE [dbo].").Append(strTable_Name.ToString).Append("(")
            _strQuery.Append("	[ID] [int] IDENTITY(1,1) NOT NULL,")
            _strQuery.Append("	[OrderBy] [int] NULL,")
            _strQuery.Append("	[Barcode] [varchar](20) COLLATE Thai_CI_AS NULL,")
            _strQuery.Append("	[UnitPrice] [float] NULL,")
            _strQuery.Append("	[Discount] [float] NULL,")
            _strQuery.Append("	[Category] [varchar](20) COLLATE Thai_CI_AS NULL,")
            _strQuery.Append("	[Language] [varchar](20) COLLATE Thai_CI_AS NULL,")
            _strQuery.Append("	[New Title] [varchar](20) COLLATE Thai_CI_AS NULL,")
            _strQuery.Append("	[Type] [varchar](100) COLLATE Thai_CI_AS NULL,")
            _strQuery.Append("	[Type_CAT] [varchar](100) COLLATE Thai_CI_AS NULL,")
            _strQuery.Append("	[Name Display] [varchar](200) COLLATE Thai_CI_AS NULL,")
            _strQuery.Append("	[tmp_Title] [varchar](200) COLLATE Thai_CI_AS NULL,")
            _strQuery.Append("	[tmp_Author] [varchar](200) COLLATE Thai_CI_AS NULL,")
            _strQuery.Append("	[tmp_Publisher] [varchar](200) COLLATE Thai_CI_AS NULL,")
            _strQuery.Append("	[Starting_Display] [datetime] NULL,")
            _strQuery.Append("	[Ending_Display] [datetime] NULL,")
            _strQuery.Append("	[Description] [varchar](255) COLLATE Thai_CI_AS NULL,")
            _strQuery.Append("	[IS_active] [char](1) COLLATE Thai_CI_AS NULL,")
            _strQuery.Append("	[Updated] [datetime] NULL,")
            _strQuery.Append("	[UpdateBy] [varchar](20) COLLATE Thai_CI_AS NULL,")
            _strQuery.Append("	[Created] [datetime] NULL,")
            _strQuery.Append("	[CreateBy] [varchar](20) COLLATE Thai_CI_AS NULL")
            _strQuery.Append("	) ON [PRIMARY];")

            _strQuery.Append("insert ").Append(strTable_Name.ToString).Append(" ([OrderBy]")
            _strQuery.Append(",[Barcode],[UnitPrice],[Discount],[Category],[Language],[New Title],[Type],[Type_CAT]")
            _strQuery.Append(",[Name Display],[tmp_Title],[tmp_Author],[tmp_Publisher],[Starting_Display],[Ending_Display]")
            _strQuery.Append(",[Description],[IS_active],[Updated],[UpdateBy],[Created],[CreateBy])")
            _strQuery.Append("select [OrderBy]")
            _strQuery.Append(",[Barcode],[UnitPrice],[Discount],[Category],[Language],[New Title],[Type],[Type_CAT]")
            _strQuery.Append(",[Name Display],[tmp_Title],[tmp_Author],[tmp_Publisher],[Starting_Display],[Ending_Display]")
            _strQuery.Append(",[Description],[IS_active],[Updated],[UpdateBy],[Created],[CreateBy] ")
            _strQuery.Append("from tbm_AB_BestSeller")

            If uFunction.ExecuteDataStringNonTran(uCon.conn, _strQuery.ToString) = False Then
                Return False
            Else
                Return True
            End If

        Catch ex As Exception
            Return False
        End Try

    End Function
    Private Sub CheckAndRenameFile(ByVal filePath As String)
        Dim fi As New FileInfo(filePath)
        Dim destfile As String = fi.DirectoryName & "\" & Path.GetFileNameWithoutExtension(fi.FullName) & "_" & Format(Now, "yyyyMMdd_HHmm") & fi.Extension
        If fi.Exists Then
            'มีไฟล์อยู่ใน Folder นั้นแล้ว
            File.Move(fi.FullName, destfile)
        End If
    End Sub
    Private Function Read_Data_Excel(ByVal FilePart As String) As Boolean
        Try
            uCon = New uConnect

            Dim strSql As String = ""
            Dim strConn As String = "Provider=Microsoft.Jet.OLEDB.4.0; Data Source=" & FilePart & "; Extended Properties=Excel 8.0;"
            Dim dtExcel As New DataTable
            Dim myData As New OleDbDataAdapter("SELECT * FROM [Sheet1$]", strConn)
            myData.TableMappings.Add("Table", "ExcelTest")
            myData.Fill(dtExcel)

            uFunction.ExecuteDataStringNonTran(uCon.conn, "truncate table tbm_AB_BestSeller")
            'uFunction.ExecuteDataStringNonTran(uCon_Eor.conn, "truncate table tbm_AB_BestSeller")

            For i As Integer = 0 To dtExcel.Rows.Count - 1
                With dtExcel.Rows(i)
                    If .Item(1).ToString.Trim.Replace("'", "") <> "" Then
                        strSql = ""
                        strSql &= " insert into tbm_AB_BestSeller ([OrderBy]"
                        strSql &= " ,[Barcode],[UnitPrice],[Discount],[Category],[Language],[New Title],[Type],[Type_CAT]"
                        strSql &= " ,[Name Display],[tmp_Title],[tmp_Author],[tmp_Publisher],[Starting_Display],[Ending_Display]"
                        strSql &= " ,[Description],[IS_active],[Updated],[UpdateBy],[Created],[CreateBy]) values ( "
                        strSql &= " '" + .Item(0).ToString.Trim.Replace("'", "") + "'"
                        strSql &= " ,'" + .Item(1).ToString.Trim.Replace("'", "") + "'"
                        strSql &= " ,'" + .Item(2).ToString.Trim.Replace("'", "") + "'"
                        If .Item(3).ToString.Trim.Replace("'", "") = "" Then
                            strSql &= " ,NULL"
                        Else
                            strSql &= " ,'" + .Item(3).ToString.Trim.Replace("'", "") + "'"
                        End If
                        strSql &= " ,'" + .Item(4).ToString.Trim.Replace("'", "") + "'"
                        strSql &= " ,'" + .Item(5).ToString.Trim.Replace("'", "") + "'"
                        strSql &= " ,'" + .Item(6).ToString.Trim.Replace("'", "") + "'"
                        strSql &= " ,'" + .Item(7).ToString.Trim.Replace("'", "") + "'"
                        strSql &= " ,'" + .Item(8).ToString.Trim.Replace("'", "'+Char(39)+'") + "'"
                        strSql &= " ,'" + .Item(9).ToString.Trim.Replace("'", "'+Char(39)+'") + "'"
                        strSql &= " ,'" + .Item(10).ToString.Trim.Replace("'", "'+Char(39)+'") + "'"
                        strSql &= " ,'" + .Item(11).ToString.Trim.Replace("'", "'+Char(39)+'") + "'"
                        strSql &= " ,'" + .Item(12).ToString.Trim.Replace("'", "'+Char(39)+'") + "'"
                        strSql &= " ,'" + .Item(13).ToString.Trim.Replace("'", "") + "'"
                        strSql &= " ,'" + .Item(14).ToString.Trim.Replace("'", "") + "'"
                        strSql &= " ,'" + .Item(15).ToString.Trim.Replace("'", "") + "'"
                        strSql &= " ,'Y'"
                        strSql &= " ,getdate()"
                        strSql &= " ,'" + Session("logonuser") + "'"
                        strSql &= " ,getdate()"
                        strSql &= " ,'" + Session("logonuser") + "')"

                        uFunction.ExecuteDataStringNonTran(uCon.conn, strSql)
                    End If


                End With
            Next

            uFunction.ExecuteDataStringNonTran(uCon.conn, "update tbm_AB_XmlConfig set is_status = 'N'")

            Return True

        Catch ex As Exception
            Throw New Exception("ReadData : " & ex.Message)
        End Try
    End Function

    Protected Sub btnOK_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles btnOK.Click
        If txtUserName.Text.ToUpper = "UPDATEWEB" And txtPassword.Text.ToUpper = "ECOMMERCE" Then
            txtPassword.Text = ""
            txtUserName.Text = ""
            Panel1.Visible = True
        Else
            Panel1.Visible = False
            ScriptManager.RegisterClientScriptBlock(Me.Page, Me.GetType, "Alert", "alert('Login is unsuccessful because your password is incorrect. Please try again.');", True)
            Exit Sub
        End If
    End Sub
End Class
