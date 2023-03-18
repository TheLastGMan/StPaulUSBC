Namespace Web
    Public Class SearchController
        Inherits System.Web.Mvc.Controller

        Private _search As Core.ISearcher

        Public Sub New(SEARCH As Core.ISearcher)
            _search = SEARCH
        End Sub

        Function Index(Optional ByVal q As String = "") As ActionResult
            Dim res = HttpUtility.UrlDecode(q)
            Return View(_search.Search(res))
        End Function

        <HttpPost>
        <ValidateInput(False)>
        Function SearchPost(ByVal q As String) As RedirectToRouteResult
            Dim query As String = HttpUtility.UrlEncode(q)
            Return RedirectToAction("Index", New With {.q = query})
        End Function

        <ChildActionOnly>
        Function SearchBar() As PartialViewResult
            Return PartialView("SearchBar")
        End Function

    End Class
End Namespace
