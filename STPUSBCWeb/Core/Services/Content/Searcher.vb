Namespace Services.Content

    Public Class Searcher : Implements ISearcher

        Private _halloffame As IHallOfFame
        Private _honor As IHonor
        Private _torn As ITournament
        Private _board As IBoard
        Private _boardhist As IBoardHistory
        Private _links As ILink
        Private _topics As ITopic
        Private _loc As ILocalization

        Public Sub New(HOF As IHallOfFame, HON As IHonor, TORN As ITournament, BOARD As IBoard, BOARDHIST As IBoardHistory, LINK As ILink, TOPIC As ITopic, LOC As ILocalization)
            _halloffame = HOF
            _honor = HON
            _torn = TORN
            _board = BOARD
            _boardhist = BOARDHIST
            _links = LINK
            _topics = TOPIC
            _loc = LOC
        End Sub

        Public Function Search(ByVal q As String) As List(Of SearchResult) Implements ISearcher.Search
            Dim ret As New List(Of SearchResult)
            Dim helper = New System.Web.Mvc.UrlHelper(System.Web.HttpContext.Current.Request.RequestContext)

            For Each itm In _halloffame.Table.Where(Function(f) SContains(f.WriteUp, q) Or SContains(f.FirstName, q) Or SContains(f.LastName, q))
                Dim res As New SearchResult With {
                    .Title = String.Format("{0} {1}", itm.FirstName, itm.LastName),
                    .Description = ShortDesc(itm.WriteUp),
                    .Division = _loc.Msg("Searcher.Search.Division.HallOfFame"),
                    .url = helper.RouteUrl("HallOfFame_Profile", New With {.id = itm.Id, .seo = System.Web.HttpUtility.UrlEncode(itm.FirstName & "_" & itm.LastName)})}
                ret.Add(res)
            Next

            'Tournaments
            For Each itm In _torn.Table.Where(Function(f) SContains(f.EventName, q) Or (Not String.IsNullOrEmpty(f.Contact) AndAlso SContains(f.Contact, q)))
                Dim res As New SearchResult With {
                    .Title = itm.EventName,
                    .Description = String.Format(_loc.Msg("Searcher.Search.TournamentFormat"), itm.EventName, itm.Contact, itm.Start_Date.ToString("MMM-dd-yyyy")),
                    .Division = _loc.Msg("Searcher.Search.Division.Tournament"),
                    .url = itm.EventUrl}
                ret.Add(res)
            Next

            'Links
            For Each itm In _links.Table.Where(Function(f) SContains(f.Name, q))
                Dim res As New SearchResult With {
                    .Title = itm.Name,
                    .Description = ShortDesc(itm.Url),
                    .url = itm.Url}
                ret.Add(res)
            Next

            'Board
            For Each itm In _board.Table.Where(Function(f) SContains(f.FormattedName, q))
                Dim lp = _boardhist.Table.OrderByDescending(Function(f) f.TermEnd).Where(Function(f) f.BoardId = itm.Id).First
                Dim res As New SearchResult With {
                    .Title = itm.FormattedName,
                    .Description = String.Format(_loc.Msg("Searcher.Search.BoardFormat"), lp.BoardPosition.Description, lp.TermStart.ToString("MMM-dd-yyyy"), lp.TermEnd.ToString("MMM-dd-yyyy")),
                    .url = helper.RouteUrl("BoardProfile", New With {.id = itm.Id.ToString})}
                ret.Add(res)
            Next

            'Topics
            For Each itm In _topics.Table.Where(Function(f) (SContains(f.content, q) Or SContains(f.SeoFriendly, q)) And Not f.TopicType = Data.Entity.TopicType.Widget)
                Dim res As New SearchResult With {
                    .Title = itm.SeoFriendly,
                    .Description = ShortDesc(itm.content),
                    .url = helper.RouteUrl("TopicPageView", New With {.seo = itm.seo})}
                ret.Add(res)
            Next

            Return ret
        End Function

        Private Function ShortDesc(ByRef desc As String) As String
            Dim repval As String = desc
            'strip stylesheets
            repval = Text.RegularExpressions.Regex.Replace(repval, "<style\b[^<]*(?:(?!</style>)<[^<]*)*</style>", String.Empty)
            'strip scripts
            repval = Text.RegularExpressions.Regex.Replace(repval, "<script\b[^<]*(?:(?!</script>)<[^<]*)*</script>", String.Empty)
            'strip block types
            repval = Text.RegularExpressions.Regex.Replace(repval, "<(.|\n)*?>", String.Empty)

            Return repval.Substring(0, Math.Min(250, repval.Length))
        End Function

        Private Function SContains(ByRef search As String, ByRef query As String) As Boolean
            Return search.ToLower.Contains(query.ToLower)
        End Function

    End Class

    Public Structure SearchResult
        Public Property Title As String
        Public Property url As String
        Public Property Division As String
        Public Property Description As String
    End Structure

End Namespace
