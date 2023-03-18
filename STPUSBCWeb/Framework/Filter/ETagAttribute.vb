Imports System.Web.Mvc
Imports System.Web
Imports System.Security.Cryptography

Namespace Filter

    Public Class ETagAttribute : Inherits ActionFilterAttribute

        Public Overrides Sub OnActionExecuting(filterContext As ActionExecutingContext)
            Try
                filterContext.HttpContext.Response.Filter = New ETagFilter(filterContext.HttpContext.Response, filterContext.RequestContext.HttpContext.Request)
            Catch ex As Exception
                'not supported
                Dim exm = ex.Message
            End Try
        End Sub

    End Class

    Public Class ETagFilter : Inherits IO.MemoryStream

        Private _response As HttpResponseBase = Nothing
        Private _request As HttpRequestBase = Nothing
        Private _filter As IO.Stream = Nothing

        Public Sub New(ByRef response As HttpResponseBase, ByRef request As HttpRequestBase)
            _response = response
            _request = request
            _filter = response.Filter
        End Sub

        Private Function GetToken(ByRef stream As IO.Stream) As String
            Dim checksum As Byte() = MD5.Create().ComputeHash(stream)
            Return Convert.ToBase64String(checksum)
        End Function

        Public Overrides Sub Write(bufferdata() As Byte, offset As Integer, count As Integer)
            Dim data As Byte() = New Byte(count) {}
            Buffer.BlockCopy(bufferdata, offset, data, 0, count)
            Dim token = GetToken(New IO.MemoryStream(data))

            Dim clientToken = _request.Headers("If-None-Match")

            If Not token.Equals(clientToken) Then
                _response.Headers("ETag") = token
                _filter.Write(data, 0, count)
            Else
                With _response
                    .SuppressContent = True
                    .StatusCode = 304
                    .StatusDescription = "Not Modified"
                    .Headers("Content-Length") = 0
                End With
            End If

        End Sub

    End Class

End Namespace
