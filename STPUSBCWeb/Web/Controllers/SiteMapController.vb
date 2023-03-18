Namespace Web
    Public Class SiteMapController
        Inherits System.Web.Mvc.Controller

        Private ReadOnly _navigation As Core.IHomeLink
        Private ReadOnly _links As Core.ILink
        Private ReadOnly _pages As Core.ITopic
        Private ReadOnly _hof As Core.IHallOfFame
        Private ReadOnly _honor As Core.IHonor
        Private ReadOnly _torn As Core.ITournament
        Private ReadOnly _board As Core.IBoard
        Private ReadOnly _sitemapgen As Core.ISitemapService

        Public Sub New(SMG As Core.ISitemapService, NAV As Core.IHomeLink, LNK As Core.ILink, PG As Core.ITopic, HOF As Core.IHallOfFame, HON As Core.IHonor, TORN As Core.ITournament, BOARD As Core.IBoard)
            _navigation = NAV
            _links = LNK
            _pages = PG
            _hof = HOF
            _honor = HON
            _torn = TORN
            _board = BOARD
            _sitemapgen = SMG
        End Sub

        Function Index() As ActionResult
            Dim model As New Models.SiteMap.IndexModel With {
                .Links = _links.GetAll,
                .Navigation = _navigation.GetAll,
                .Pages = _pages.Table.Where(Function(f) Not f.TopicType = Data.Entity.TopicType.Widget).OrderBy(Function(f) f.TopicTypeId).ThenByDescending(Function(f) f.updatedutc).ToList,
                .HOF = _hof.GetAll.OrderBy(Function(f) f.LastName).ToList,
                .Honors = _honor.GetAll,
                .Tournaments = _torn.GetAll.Where(Function(f) Not String.IsNullOrEmpty(f.EventUrl)).OrderBy(Function(f) f.EventName).ToList,
                .Board = _board.Table
            }
            Return View(model)
        End Function

        Function Generate(ByVal id As String, Optional ByVal page As String = "") As ActionResult
            Dim XML As String = _sitemapgen.GenerateSitemap(id, page)
            If String.IsNullOrEmpty(XML) Then
                Return HttpNotFound("search provider: " & id & " : or page: " & page & " : not found")
            End If
            Return View("XMLView", DirectCast(XML, Object))
        End Function

    End Class
End Namespace
