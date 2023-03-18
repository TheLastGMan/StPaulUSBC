Imports Core
Public Interface ISitemapProvider

    ReadOnly Property Provider As String
    Function GenerateSitemap(Optional ByRef Page As String = "") As String

End Interface
