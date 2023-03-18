Namespace Web
    Public Class CommonController
        Inherits System.Web.Mvc.Controller

        Private _links As Core.ILink
        Private _hlinks As Core.IHomeLink

        Public Sub New(L As Core.ILink, HL As Core.IHomeLink)
            _links = L
            _hlinks = HL
        End Sub

        <ChildActionOnly>
        Function Links(Optional ByVal seo As String = "") As ActionResult
            Dim model As New Models.Common.LinkModel With {
                .Controller = seo,
                .Links = _hlinks.GetAll()}
            Return PartialView(model)
        End Function

        <ChildActionOnly>
        Function ExtLink() As ActionResult
            Return PartialView(New Models.Common.ExtLinkModel With {.Links = _links.GetAll()})
        End Function

        <ChildActionOnly>
        Function AdminLinks(Optional ByVal seo As String = "") As ActionResult
            Return PartialView(DirectCast(seo, Object))
        End Function

        <ChildActionOnly>
        Function LastUpdated(ByVal updated As DateTime?) As PartialViewResult
            Return PartialView(New Models.Common.LastUpdatedModel With {.LastUpdated = updated})
        End Function

        <ChildActionOnly>
        Function Editor(ByVal id As String, ByVal html As String) As PartialViewResult
            Return PartialView(New Models.Common.EditorModel With {.Id = id, .Html = html})
        End Function

        <ChildActionOnly>
        Function FullScreenLoad() As PartialViewResult
            Return PartialView()
        End Function

        <ChildActionOnly>
        Function BreadCrumb(ByVal title As String) As PartialViewResult
            'set initial data
            Dim ct As String = ""
            Dim url As String = Request.Url.AbsolutePath
            Dim _History As List(Of KeyValuePair(Of String, String)) = History.ToList
            'data check, only add/remove if valid title
            If Not String.IsNullOrEmpty(title) Then
                ct = TrimTitle(title)
                'check if it already exists
                If History.ContainsKey(ct) Then
                    'already has it, remove all after the first instance
                    _History.Reverse()
                    While True
                        If Not _History.First.Key.Equals(ct, StringComparison.InvariantCultureIgnoreCase) Then
                            'remove
                            _History.Remove(_History.Where(Function(f) f.Key = _History.First.Key).First)
                        Else
                            'same
                            Exit While
                        End If
                    End While
                    _History.Reverse()
                Else
                    'add it
                    _History.Add(New KeyValuePair(Of String, String)(ct, url))
                End If
                'trim to the last 6
                _History.Reverse()
                _History = _History.Take(7).ToList
                _History.Reverse()
                History = _History.ToDictionary(Function(f) f.Key, Function(f) f.Value)
            End If
            'return previous 5
            Return PartialView(History)
        End Function

        Private Function TrimTitle(ByRef title As String) As String
            Dim li As Integer = title.LastIndexOf(" - ")
            If li > 1 Then
                title = title.Substring(li + 3).Trim
            End If
            Return title
        End Function

        Private HistoryKey As String = "LinkHistory"
        Private Property History As Dictionary(Of String, String)
            Get
                If Session(HistoryKey) Is Nothing Then
                    Session(HistoryKey) = New Dictionary(Of String, String)
                End If
                Return DirectCast(Session(HistoryKey), Dictionary(Of String, String))
            End Get
            Set(value As Dictionary(Of String, String))
                Session(HistoryKey) = value
            End Set
        End Property

        Function [Error]() As ActionResult
            Return View()
        End Function

    End Class
End Namespace
