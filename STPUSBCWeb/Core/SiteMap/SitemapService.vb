Namespace SiteMap

    Public Class SitemapService : Implements ISitemapService

        Private ReadOnly _TypeFinder As ITypeFinder

        Public Sub New(TypeFinder As ITypeFinder)
            _TypeFinder = TypeFinder
        End Sub

        Public Function GenerateGoogleSitemap(Optional ByRef Page As String = "") As String Implements ISitemapService.GenerateGoogleSitemap
            Return GenerateSitemap("Google")
        End Function

        Public Function GenerateSitemap(ByRef ProviderName As String, Optional ByRef Page As String = "") As String Implements ISitemapService.GenerateSitemap
            Dim PN As String = ProviderName
            Dim provider As ISitemapProvider = _TypeFinder.FindClassesOfType(Of ISitemapProvider)().Where(Function(f) TryCast(Activator.CreateInstance(f), ISitemapProvider) IsNot Nothing).Select(Function(f) DirectCast(Activator.CreateInstance(f), ISitemapProvider)).Where(Function(f) f.Provider.Equals(PN, StringComparison.InvariantCultureIgnoreCase)).FirstOrDefault

            If provider IsNot Nothing Then
                Return provider.GenerateSitemap(Page)
            Else
                Return ""
            End If
        End Function

    End Class

End Namespace
