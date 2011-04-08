Imports System.Drawing
Imports System.Drawing.Drawing2D
Imports System.Drawing.Graphics
Imports System.Drawing.Imaging
Imports System.Random
Imports Microsoft.VisualBasic

Public Class CaptchaImage
    Private _width As Integer
    Private _height As Integer
    Private _familyName As FontFamily
    Private _text As String

    ' เนื่องจากต้องคืนค่าเป็นรูปภาพจึงต้องกำหนดให้มี Property Image 
    ' เพื่อให้สามารถนำไปเรียกใช้งานได้ 
    Private _image As Bitmap

    Public ReadOnly Property Image() As Bitmap
        Get
            Return _image
        End Get
    End Property

    Private Sub GenerateGraphic()
        ' สร้างภาพแบบ Bitmap ขึ้นมาใหม่เพื่อใช้เป็นภาพพื้นฐานของ Captcha ของเรา 
        Dim bitmap As New Bitmap(_width, _height, PixelFormat.Format32bppPArgb)

        ' สร้าง Object กราฟิกขึ้นมาเพื่อใช้วาดสิ่งต่างๆ เช่น ชุดอักษรหรือเอฟเฟคลงบนภาพ 
        Dim g As Graphics = Graphics.FromImage(bitmap)
        g.SmoothingMode = Drawing2D.SmoothingMode.AntiAlias

        Dim rect As New Rectangle(0, 0, _width, _height)

        ' เริ่มจากการลงสีพื้นหลัง เราใช้ HatchBrush ในการกำหนด Pattern ในการวาด เช่น 
        ' ในตัวอย่างคือ การวาด Pattern เป็นตารางโดยใช้สีเทาอ่อนบนพื้นสีขาว 
        Dim hatchBrush As New HatchBrush(HatchStyle.DiagonalCross, Color.LightGreen, Color.White)
        g.FillRectangle(hatchBrush, rect)

        ' ต่อมาคือการสร้างฟอนท์และปรับขนาดของฟอนท์ 
        Dim size As SizeF
        Dim fontSize As Single = rect.Height + 1
        Dim font As Font

        Do
            fontSize = fontSize - 1
            font = New Font(_familyName, fontSize, FontStyle.Bold)
            size = g.MeasureString(_text, font)
        Loop While (size.Width > rect.Width)

        ' ปรับรูปแบบของการจัดวางชุดอักษร 
        Dim format As New StringFormat()
        format.Alignment = StringAlignment.Center
        format.LineAlignment = StringAlignment.Center

        ' สร้างเส้นพาร์ทจากชุดอักษร และบิดเพื่อให้ชุดอักษรอ่านได้ยากขึ้น 
        Dim path As New GraphicsPath()
        path.AddString(_text, font.FontFamily, CInt(font.Style), font.Size, rect, format)

        Dim v As Single = 4.0F
        Dim r As New Random
        Dim points As PointF() = {New PointF(r.Next(rect.Width) / v, r.Next(rect.Height) / v), _
                                  New PointF(rect.Width - r.Next(rect.Width) / v, r.Next(rect.Height) / v), _
                                  New PointF(r.Next(rect.Width) / v, rect.Height - r.Next(rect.Height) / v), _
                                  New PointF(rect.Width - r.Next(rect.Width) / v, rect.Height - r.Next(rect.Height) / v)}

        Dim matrix As New Matrix()
        matrix.Translate(0.0F, 0.0F)
        path.Warp(points, rect, matrix, WarpMode.Perspective, 0.0F)

        ' จากนั้นจึงวาดชุดอักษรลงบนภาพตามพาร์ทที่ได้ โดยใช้ Pattern 
        ' ช่วยให้ชุดอักษรมี Texture ที่ทำให้อ่านยากขึ้น 
        hatchBrush = New HatchBrush(HatchStyle.LargeConfetti, Color.Green, Color.DarkOliveGreen)
        g.FillPath(HatchBrush, path)

        ' เติมจุดบนภาพแบบสุ่มโดยทั่ว เพื่อเพิ่มความยากในการอ่าน 
        ' อาจเปลี่ยนเป็นแบบอื่นหรือไม่ใช้ได้ตามต้องการ 

        Dim m As Integer = Math.Max(rect.Width, rect.Height)

        For i As Integer = 0 To CInt(rect.Width * rect.Height / 30.0F)
            Dim x As Integer = r.Next(rect.Width)
            Dim y As Integer = r.Next(rect.Height)
            Dim w As Integer = r.Next(m / 50)
            Dim h As Integer = r.Next(m / 50)

            g.FillEllipse(hatchBrush, x, y, w, h)
        Next

        ' เมื่อทุกอย่างสำเร็จเรียบร้อย ให้ล้าง Object ที่ไม่ใช้ออกจากหน่วยความจำ 
        font.Dispose()
        HatchBrush.Dispose()
        g.Dispose()

        ' หลังจากนั้นจึงนำค่ารูปภาพที่ได้ไปใส่ไว้ใน Property เพื่อรอการใช้งานต่อไป 
        _image = bitmap
    End Sub

    ' กำหนดรูปแบบของฟอนท์ที่จะใช้งาน ถ้าไม่มีฟอนท์แบบนั้นในเครื่อง 
    ' ก็ให้ใช้ฟอนท์ปรกติของเครื่องแทน 
    Private Sub SetFamilyName(ByVal familyName As String)
        Try
            Dim font As New Font(familyName, 10.0F)
            _familyName = font.FontFamily
            font.Dispose()
        Catch ex As Exception
            _familyName = FontFamily.GenericSansSerif
        End Try
    End Sub

    ' Constructor ของคลาสทำหน้าที่กำหนดค่าต่างๆที่จำเป็น 
    ' และสร้างกราฟิกไว้ใน Property Image เพื่อให้โปรแกรมอื่นสามารถเรียกใช้งานได้ 
    Sub New(ByVal text As String, ByVal width As Integer, ByVal height As Integer, ByVal familyName As String)
        _text = text
        _width = width
        _height = height

        Me.SetFamilyName(familyName)
        Me.GenerateGraphic()
    End Sub

    Public Sub Dispose()
        GC.SuppressFinalize(Me)
        Me.Dispose(True)
    End Sub

    Protected Sub Dispose(ByVal disposing As Boolean)
        If disposing Then
            _image.Dispose()
        End If
    End Sub

End Class
