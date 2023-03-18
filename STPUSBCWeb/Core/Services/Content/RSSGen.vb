Imports RSSGenerator
Imports RSSGenerator.Template
Namespace Services.Content

    Public Class RSSGen : Implements IRSSGen

        Private _halloffame As IHallOfFame
        Private _boardhist As IBoardHistory
        Private _honor As IHonor
        Private _torn As ITournament
        Private _loc As ILocalization

        Public Sub New(HOF As IHallOfFame, BOARDHIST As IBoardHistory, HONOR As IHonor, TORN As ITournament, LOC As ILocalization)
            _halloffame = HOF
            _boardhist = BOARDHIST
            _honor = HONOR
            _torn = TORN
            _loc = LOC
        End Sub

        Function Board() As String Implements IRSSGen.Board
            Dim table = _boardhist.Table.OrderByDescending(Function(f) f.TermEnd)
            Dim uniquemembers = table.Select(Function(f) f.BoardId).Distinct

            Dim helper = New System.Web.Mvc.UrlHelper(System.Web.HttpContext.Current.Request.RequestContext)
            Dim body = New Channel(_loc.Msg("RSS.Feed.Board.Title"), helper.RouteUrl("HallOfFame"), _loc.Msg("RSS.Feed.Board.Description"))

            With body
                .copyright = "2012 - " & Now.Year.ToString & " | Ryan Gau"
                .ttl = 15
                .lastBuildDate = table.OrderByDescending(Function(f) f.Board.LastUpdatedUtc).Select(Function(f) f.Board.LastUpdatedUtc).FirstOrDefault
                .pubDate = .lastBuildDate
            End With

            For Each itm In uniquemembers
                Dim bh = table.OrderByDescending(Function(f) f.TermEnd).Where(Function(f) f.BoardId = itm).FirstOrDefault
                Dim desc As String = String.Format(_loc.Msg("RSS.Board.BoardFormat"), bh.BoardPosition.Description, bh.TermStart.ToString("MMM-dd-yyyy"), bh.TermEnd.ToString("MMM-dd-yyyy"))
                Dim channel As New ChannelItem(bh.Board.FormattedName, helper.RouteUrl("BoardProfile", New With {.id = itm.ToString}), desc)
                channel.pubDate = bh.Board.LastUpdatedUtc
                body.Items.Add(channel)
            Next

            Return body.Make.RSSFeed
        End Function

        Function HallOfFame() As String Implements IRSSGen.HallOfFame
            Dim table = _halloffame.GetAll(True).OrderByDescending(Function(f) f.Achieved).ThenBy(Function(f) f.LastName)

            Dim helper = New System.Web.Mvc.UrlHelper(System.Web.HttpContext.Current.Request.RequestContext)
            Dim body = New Channel(_loc.Msg("RSS.Feed.HallOfFame.Title"), helper.RouteUrl("HallOfFame"), _loc.Msg("RSS.Feed.HallOfFame.Description"))

            With body
                .copyright = "2012 - " & Now.Year.ToString & " | Ryan Gau"
                .ttl = 15
                .lastBuildDate = table.OrderByDescending(Function(f) f.LastUpdatedUtc).Select(Function(f) f.LastUpdatedUtc).FirstOrDefault
                .pubDate = .lastBuildDate
            End With

            For Each itm In table
                Dim channel As New ChannelItem(itm.FirstName & " " & itm.LastName, helper.RouteUrl("HallOfFame_Profile", New With {.id = itm.Id, .seo = System.Web.HttpUtility.UrlEncode(itm.FirstName & "_" & itm.LastName)}), itm.WriteUp)
                channel.pubDate = itm.LastUpdatedUtc
                body.Items.Add(channel)
            Next

            Return body.Make().RSSFeed
        End Function

        Public Function Honor() As String Implements IRSSGen.Honor
            Dim table = _honor.GetAll().GroupBy(Function(f) f.FormattedName)

            Dim helper = New System.Web.Mvc.UrlHelper(System.Web.HttpContext.Current.Request.RequestContext)
            Dim body = New Channel(_loc.Msg("RSS.Feed.Honor.Title"), helper.RouteUrl("HallOfFame"), _loc.Msg("RSS.Feed.Honor.Description"))

            With body
                .copyright = "2012 - " & Now.Year.ToString & " | Ryan Gau"
                .ttl = 15
                .lastBuildDate = Now.ToUniversalTime
                .pubDate = .lastBuildDate
            End With

            Return body.Make.RSSFeed
        End Function

        Public Function Tournament() As String Implements IRSSGen.Tournament
            Dim table = _torn.Table.OrderByDescending(Function(f) f.Start_Date).Where(Function(f) Not String.IsNullOrEmpty(f.EventUrl))

            Dim helper = New System.Web.Mvc.UrlHelper(System.Web.HttpContext.Current.Request.RequestContext)
            Dim body = New Channel(_loc.Msg("RSS.Feed.Tournament.Title"), helper.RouteUrl("Tournament"), _loc.Msg("RSS.Feed.Tournament.Description"))

            With body
                .copyright = "2012 - " & Now.Year.ToString & " | Ryan Gau"
                .ttl = 15
                .lastBuildDate = table.OrderByDescending(Function(f) f.AddedUtc).Select(Function(f) f.AddedUtc).FirstOrDefault
                .pubDate = .lastBuildDate
            End With

            For Each itm In table
                Dim channel As New ChannelItem(itm.EventName, itm.EventUrl, itm.Start_Date.ToString("MMM-dd-yyyy") & vbCrLf & "Contact : [" & itm.Contact & "] at [" & itm.ContactEmail & "]")
                channel.pubDate = itm.AddedUtc
                body.Items.Add(channel)
            Next

            Return body.Make.RSSFeed
        End Function

    End Class

End Namespace
