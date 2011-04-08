Imports Microsoft.VisualBasic
Imports System.IO
Imports System.Security.Cryptography

Public Class EndcodeDecode
    Public Shared Function Encrypt(ByVal argInString As String) As String
        Dim strOut As String
        Dim textConverter As New Text.ASCIIEncoding
        Dim rc2CSP As New System.Security.Cryptography.RC2CryptoServiceProvider
        Dim encrypted() As Byte
        Dim toEncrypt() As Byte
        Dim key() As Byte
        Dim IV() As Byte


        'Get the key and IV.
        key = textConverter.GetBytes("1234567890123456")
        IV = textConverter.GetBytes("12345678")
        'key = textConverter.GetBytes("A0s8i6A5b11O6o5K5s2")
        'IV = textConverter.GetBytes("AsiAbOoKs")


        'Get an encryptor.
        Dim encryptor As ICryptoTransform = rc2CSP.CreateEncryptor(key, IV)

        'Encrypt the data.
        Dim msEncrypt As New IO.MemoryStream
        Dim csEncrypt As New CryptoStream(msEncrypt, encryptor, CryptoStreamMode.Write)

        'Convert the data to a byte array.
        If (argInString.Length > 19) Then
            Return "Error"
        Else
            argInString = argInString.PadRight(19, " ")
        End If
        toEncrypt = textConverter.GetBytes(argInString)

        'Write all data to the crypto stream and flush it.
        csEncrypt.Write(toEncrypt, 0, toEncrypt.Length)
        csEncrypt.FlushFinalBlock()

        'Get encrypted array of bytes.
        encrypted = msEncrypt.ToArray()
        strOut = Convert.ToBase64String(encrypted)
        Return strOut
    End Function
    Public Shared Function Decrypt(ByVal argInString As String) As String
        Try
            Dim strOut As String
            Dim textConverter As New Text.ASCIIEncoding
            Dim rc2CSP As New RC2CryptoServiceProvider
            Dim fromEncrypt() As Byte
            Dim encrypted() As Byte
            Dim key() As Byte
            Dim IV() As Byte


            'Get the key and IV.
            key = textConverter.GetBytes("1234567890123456")
            IV = textConverter.GetBytes("12345678")
            'key = textConverter.GetBytes("A0s8i6A5b11O6o5K5s2")
            'IV = textConverter.GetBytes("AsiAbOoKs")


            Dim decryptor As ICryptoTransform = rc2CSP.CreateDecryptor(key, IV)

            encrypted = Convert.FromBase64String(argInString)
            'Now decrypt the previously encrypted message using the decryptor
            ' obtained in the above step.
            Dim msDecrypt As New MemoryStream(encrypted)
            Dim csDecrypt As New CryptoStream(msDecrypt, decryptor, CryptoStreamMode.Read)

            fromEncrypt = New Byte(encrypted.Length) {}

            'Read the data out of the crypto stream.
            csDecrypt.Read(fromEncrypt, 0, fromEncrypt.Length)

            'Convert the byte array back into a string.
            strOut = textConverter.GetString(fromEncrypt, 0, 19)

            Return strOut.Trim
        Catch ex As Exception
            Throw ex
        End Try

    End Function

End Class
