Imports System.Web.Mvc
Imports System.Net.Mime

Public Class StreamContentResult : Inherits FileContentResult

    Public Sub New(ByVal fileContents As Byte(), ByVal contentType As String, ByVal fileName As String)
        MyBase.New(fileContents, contentType)
        FileDownloadName = fileName
    End Sub

    Public Property Inline As Boolean

    Public Overrides Sub ExecuteResult(context As ControllerContext)
        If context Is Nothing Then
            Throw New ArgumentException("context is not set")
        End If

        Dim Response = context.HttpContext.Response
        If Not String.IsNullOrEmpty(FileDownloadName) Then
            Dim CDisp As String = New ContentDisposition() With {.FileName = FileDownloadName, .Inline = Inline}.ToString()
            context.HttpContext.Response.ContentType = ContentType
            context.HttpContext.Response.AddHeader("Content-Disposition", CDisp)
            context.HttpContext.Response.AddHeader("Content-Length", FileContents.Length)
        End If

        WriteFile(Response)
    End Sub

End Class
