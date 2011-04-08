Imports System.Data

Partial Class uc_ucSubscribe
    Inherits System.Web.UI.UserControl

    Dim ucon As uConnect

    Private Function GetIP() As String
        Dim ip As String = String.Empty
        ip = Request.ServerVariables("REMOTE_ADDR")
        Return ip
    End Function

    Protected Sub ImageButton17_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles ImageButton17.Click
        Try
            ucon = New uConnect
            Dim strCommand As String
            Dim dtSub As DataTable


            If checkEmail(txtSubscribe.Text.Trim) = False Then
                uScript.Alert(Me.Page, Me.GetType, "Email is incorrect format")
                Exit Sub
            End If

            strCommand = "SELECT * FROM tbm_AB_eNews_Subscribe WHERE eMail_address='" & txtSubscribe.Text.Trim & "'"
            dtSub = uFunction.getDataTable(ucon.conn, strCommand)

            If dtSub.Rows.Count > 0 Then
                strCommand = "UPDATE tbm_AB_eNews_Subscribe SET Is_Active='Y',Updated=GETDATE(),UpadteBy='" & GetIP() & "' " & _
                "WHERE eMail_address='" & txtSubscribe.Text.Trim & "'"
                If uFunction.ExecuteDataStringNonTran(ucon.conn, strCommand) = True Then
                    uScript.Alert(Me.Page, Me.GetType, "Save Complete..")
                End If
            Else
                strCommand = "INSERT INTO tbm_AB_eNews_Subscribe(eMail_address,Is_Active,Created,CreatedBy) " & _
                "VALUES('" & txtSubscribe.Text.Trim & "','Y',getdate(),'" & GetIP() & "')"
                If uFunction.ExecuteDataStringNonTran(ucon.conn, strCommand) = True Then
                    uScript.Alert(Me.Page, Me.GetType, "Save Complete..")
                End If
            End If
        Catch ex As Exception
            uScript.Alert(Me.Page, Me.GetType, ex.Message.ToString())
        Finally
            txtSubscribe.Text = String.Empty
        End Try
    End Sub

    Private Function checkEmail(ByVal email As String) As Boolean
        Dim checkAt As String()
        Dim checkDot As String()

        checkAt = email.Split("@")
        If checkAt.Count = 2 Then
            checkDot = checkAt(1).Split(".")
            If checkDot.Count <> 2 Then
                Return False
            End If
        Else
            Return False
        End If
        Return True
    End Function

    Protected Sub btnSave_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnSave.Click
        If Session(Me.hdSessionNameSubscribe.Value).ToString = Me.txtCaptcha.Text Then
            Dim strCommand As String
            Dim dtCheck As DataTable
            ucon = New uConnect

            Try
                If checkEmail(txtUnSubscribe.Text.Trim) = False Then
                    uScript.Alert(Me.Page, Me.GetType, "Email is incorrect format")
                    Exit Sub
                End If

                strCommand = "SELECT * FROM tbm_AB_eNews_Subscribe WHERE eMail_address='" & txtUnSubscribe.Text.Trim & "'"
                dtCheck = uFunction.getDataTable(ucon.conn, strCommand)

                If (dtCheck.Rows.Count > 0) Then
                    strCommand = "UPDATE tbm_AB_eNews_Subscribe SET Is_Active='N',Updated=GETDATE(),UpadteBy='" & GetIP() & "' " & _
                        "WHERE eMail_address='" & txtUnSubscribe.Text.Trim & "'"
                    If uFunction.ExecuteDataStringNonTran(ucon.conn, strCommand) = True Then
                        uScript.Alert(Me.Page, Me.GetType, "Save Complete..")
                    End If
                Else
                    uScript.Alert(Me.Page, Me.GetType, "Can't find email")
                End If
            Catch ex As Exception
                uScript.Alert(Me.Page, Me.GetType, ex.Message.ToString())
            Finally
                txtUnSubscribe.Text = String.Empty
            End Try
        Else
            uScript.Alert(Me.Page, Me.GetType, "Not match, try again!")
            Session(Me.hdSessionNameSubscribe.Value) = Nothing
            Me.SubscribeCaptcha.InvalidCaptcha = True
            Me.mdlPopupSubscrilbe.Show()
        End If

    End Sub

    Protected Sub btnCancel_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnCancel.Click
        txtUnSubscribe.Text = String.Empty
    End Sub

    Protected Sub lnkRefresh_forgot_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lnkRefresh_forgot.Click
        Me.SubscribeCaptcha.SessionCaptcha = Me.hdSessionNameSubscribe.Value
        Session(Me.hdSessionNameSubscribe.Value) = Nothing
        Me.SubscribeCaptcha.InvalidCaptcha = True
        Me.mdlPopupSubscrilbe.Show()
    End Sub

    Protected Sub lnkPopupUnsub_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lnkPopupUnsub.Click
        Me.hdSessionNameSubscribe.Value = "captchaunsub"
        Me.SubscribeCaptcha.SessionCaptcha = Me.hdSessionNameSubscribe.Value
        Me.SubscribeCaptcha.InvalidCaptcha = True
        Me.mdlPopupSubscrilbe.Show()
    End Sub
End Class
