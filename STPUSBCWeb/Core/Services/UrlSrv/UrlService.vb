Namespace Services.UrlSrv

    Public Class UrlServices : Implements IUrlService

        ''' <summary>
        ''' strip host if it is the same
        ''' </summary>
        ''' <param name="link">url link to check</param>
        ''' <returns>formatted link</returns>
        ''' <remarks></remarks>
        Public Function FormatLink(ByRef link As String) As String Implements IUrlService.FormatLink
            Dim localhost As String = System.Web.HttpContext.Current.Request.Url.Host
            If Not link.StartsWith("/") Then
                Try
                    Dim url As New Uri(link)
                    If url.Host.Equals(localhost, StringComparison.InvariantCultureIgnoreCase) Then
                        link = url.PathAndQuery
                    End If
                Catch ex As Exception
                    link = "/" & link
                End Try
            End If

            Return link
        End Function

    End Class

End Namespace
