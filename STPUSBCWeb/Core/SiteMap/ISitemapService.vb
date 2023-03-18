Public Interface ISitemapService

    Function GenerateSitemap(ByRef ProviderName As String, Optional ByRef Page As String = "") As String
    Function GenerateGoogleSitemap(Optional ByRef Page As String = "") As String

End Interface
