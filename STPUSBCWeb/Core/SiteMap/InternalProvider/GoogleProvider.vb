Imports System.Xml.Serialization

Namespace SiteMap.InternalProvider

    Public Class GoogleProvider : Implements ISitemapProvider

        Private Const ItemsPerFile As Short = 31415
        Private Const FileFormat As String = "{0}-{1}"

        Private ReadOnly _navigation As Core.IHomeLink
        Private ReadOnly _pages As Core.ITopic
        Private ReadOnly _hof As Core.IHallOfFame
        Private ReadOnly _honor As Core.IHonor
        Private ReadOnly _torn As Core.ITournament
        Private ReadOnly _board As Core.IBoard

        Public Sub New()
            Dim IoC As New Core.DI.IoC()
            _navigation = IoC.Get(GetType(Core.IHomeLink))
            _pages = IoC.Get(GetType(Core.ITopic))
            _hof = IoC.Get(GetType(Core.IHallOfFame))
            _honor = IoC.Get(GetType(Core.IHonor))
            _torn = IoC.Get(GetType(Core.ITournament))
            _board = IoC.Get(GetType(Core.IBoard))
        End Sub

        Public Function GenerateSitemap(Optional ByRef Page As String = "") As String Implements ISitemapProvider.GenerateSitemap
            Dim helper = New System.Web.Mvc.UrlHelper(System.Web.HttpContext.Current.Request.RequestContext)
            Dim host As String = System.Web.HttpContext.Current.Request.Url.Host
            Dim localhost As String = "http://" & host
            If String.IsNullOrEmpty(Page) Then
                'generate base xml
                Dim output As New sitemapindex()
                output.sitemap = New List(Of sitemap)

                Dim baseurl As String = localhost & helper.RouteUrl("SiteMapGenerator", New With {.id = "Google"}).ToLower

                'navigation
                For i As UShort = 1 To Math.Ceiling(_navigation.GetAll.Count / ItemsPerFile)
                    Dim E As New sitemap()
                    E.loc = GenerateFileName(baseurl, "navigation", i)
                    E.lastmod = New DateTime(Now.Year, Now.Month, 1)
                    output.sitemap.Add(E)
                Next

                'pages
                For i As UShort = 1 To Math.Ceiling(_pages.Table.Where(Function(f) Not f.TopicType = Data.Entity.TopicType.Widget).Count / ItemsPerFile)
                    Dim E As New sitemap()
                    E.loc = GenerateFileName(baseurl, "page", i)
                    E.lastmod = _pages.GetAll.OrderByDescending(Function(f) f.updatedutc).Select(Function(f) f.updatedutc).FirstOrDefault
                    output.sitemap.Add(E)
                Next

                'hall of fame
                For i As UShort = 1 To Math.Ceiling(_hof.GetAll.Count / ItemsPerFile)
                    Dim E As New sitemap()
                    E.loc = GenerateFileName(baseurl, "halloffame", i)
                    E.lastmod = _hof.GetAll.OrderByDescending(Function(f) f.LastUpdatedUtc).Select(Function(f) f.LastUpdatedUtc).FirstOrDefault
                    output.sitemap.Add(E)
                Next

                'honor
                For i As UShort = 1 To Math.Ceiling(_honor.GetAll.Count / ItemsPerFile)
                    Dim E As New sitemap()
                    E.loc = GenerateFileName(baseurl, "honorscore", i)
                    E.lastmod = _honor.GetAll.OrderByDescending(Function(f) f.AddedUtc).Select(Function(f) f.AddedUtc).FirstOrDefault
                    output.sitemap.Add(E)
                Next

                'tournaments
                For i As UShort = 1 To Math.Ceiling(_torn.GetAll.Count / ItemsPerFile)
                    Dim E As New sitemap()
                    E.loc = GenerateFileName(baseurl, "tournament", i)
                    E.lastmod = _torn.GetAll.OrderByDescending(Function(f) f.Start_Date).Select(Function(f) f.Start_Date).FirstOrDefault
                    output.sitemap.Add(E)
                Next

                'board members
                For i As UShort = 1 To Math.Ceiling(_board.Entities.Count / ItemsPerFile)
                    Dim E As New sitemap()
                    E.loc = GenerateFileName(baseurl, "boardmember", i)
                    E.lastmod = _board.Entities.OrderByDescending(Function(f) f.LastUpdatedUtc).Select(Function(f) f.LastUpdatedUtc).FirstOrDefault
                    output.sitemap.Add(E)
                Next

                Dim ret As String = Serialize(Of sitemapindex)(output)

                Return ret
            Else
                'page specific
                Dim output As New urlset()
                output.url = New List(Of url)
                'get filename/number
                Dim file_name As String = Page.Split("-").GetValue(0)
                Dim file_number As UShort = Page.Split("-").GetValue(1)
                Dim file_skipindex As UShort = file_number - 1
                'load file
                Select Case file_name
                    Case "navigation"
                        Dim lst As IEnumerable(Of Data.Entity.HomeLink) = _navigation.GetAll.Skip(file_skipindex * ItemsPerFile).Take(ItemsPerFile)
                        For Each l In lst
                            Dim E As New url()
                            E.loc = localhost & helper.Action(l.View, l.Controller)
                            E.priority = 1.0
                            E.changefreq = changefreq.weekly
                            E.lastmod = DateTime.Now.AddDays((-1) * Now.DayOfWeek).Date
                            output.url.Add(E)
                        Next
                    Case "page"
                        Dim lst As IEnumerable(Of Data.Entity.Topic) = _pages.Table.Where(Function(f) Not f.TopicType = Data.Entity.TopicType.Widget).Skip(file_skipindex * ItemsPerFile).Take(ItemsPerFile)
                        For Each p In lst
                            Dim E As New url()
                            E.loc = localhost & helper.RouteUrl("TopicPageView", New With {.seo = p.seo})
                            E.priority = 0.8
                            E.changefreq = changefreq.monthly
                            E.lastmod = p.updatedutc
                            output.url.Add(E)
                        Next
                    Case "halloffame"
                        Dim lst As IEnumerable(Of Data.Entity.HallOfFame) = _hof.GetAll().Skip(file_skipindex * ItemsPerFile).Take(ItemsPerFile)
                        For Each hof In lst
                            Dim E As New url()
                            E.loc = localhost & helper.Action("Profile", "HallOfFame", New With {.id = hof.Id, .seo = System.Web.HttpUtility.UrlEncode(hof.FirstName & "_" & hof.LastName).ToLower})
                            E.priority = 0.4
                            E.changefreq = changefreq.yearly
                            E.lastmod = hof.LastUpdatedUtc
                            output.url.Add(E)
                        Next
                    Case "honorscore"
                        Dim lst As IEnumerable(Of Data.Entity.Honor) = _honor.GetAll.Skip(file_skipindex * ItemsPerFile).Take(ItemsPerFile)
                        For Each hs In lst
                            Dim E As New url()
                            E.loc = localhost & helper.Action("Profile", "HonorScore", New With {.id = hs.FormattedName.Replace(", ", "-").ToLower})
                            E.priority = 0.4
                            E.changefreq = changefreq.monthly
                            E.lastmod = hs.AddedUtc
                            output.url.Add(E)
                        Next
                    Case "tournament"
                        Dim lst As IEnumerable(Of Data.Entity.Tournament) = _torn.Entities.OrderBy(Function(f) f.Start_Date).Where(Function(f) f.EventUrl.StartsWith("/")).OrderBy(Function(f) f.Start_Date).Skip(file_skipindex * ItemsPerFile).Take(ItemsPerFile)
                        For Each t In lst
                            Dim E As New url()
                            E.loc = localhost & t.EventUrl
                            E.priority = 0.6
                            E.changefreq = changefreq.monthly
                            E.lastmod = t.Start_Date
                            output.url.Add(E)
                        Next
                    Case "boardmember"
                        Dim lst As IEnumerable(Of Data.Entity.Board) = _board.Entities.OrderByDescending(Function(f) f.LastUpdatedUtc).Skip(file_skipindex * ItemsPerFile).Take(ItemsPerFile)
                        For Each bm In lst
                            Dim E As New url()
                            E.loc = localhost & helper.Action("Profile", "Board", New With {.id = bm.Id.ToString})
                            E.priority = 0.4
                            E.changefreq = changefreq.yearly
                            E.lastmod = bm.LastUpdatedUtc
                            output.url.Add(E)
                        Next
                End Select

                Dim ret As String = Serialize(Of urlset)(output)

                Return ret
            End If
        End Function

        Private Function Serialize(Of T As Class)(ByRef content As T) As String
            Dim S As New XmlSerializer(GetType(T))
            Dim ret As String = ""
            Using MS As New IO.MemoryStream
                S.Serialize(MS, content)
                Dim rettmp(MS.Length) As Byte
                MS.Position = 0
                MS.Read(rettmp, 0, MS.Length)
                ret = System.Text.UTF8Encoding.UTF8.GetString(rettmp)
            End Using
            Return ret
        End Function

        Private Function GenerateFileName(ByRef baseurl As String, ByRef filename As String, ByVal filenumber As UShort) As String
            Return baseurl & IIf(Not baseurl.EndsWith("/"), "/", "") & String.Format(FileFormat, filename, filenumber.ToString)
        End Function

        Public ReadOnly Property Provider As String Implements ISitemapProvider.Provider
            Get
                Return "Google"
            End Get
        End Property

    End Class

    <XmlRoot(namespace:="http://www.sitemaps.org/schemas/sitemap/0.9")>
    Public Class sitemapindex

        <XmlElement>
        Public Property sitemap As List(Of sitemap)

    End Class

    <XmlRoot(namespace:="http://www.sitemaps.org/schemas/sitemap/0.9")>
    Public Class urlset

        <XmlElement>
        Public Property url As List(Of url)

    End Class

    Public Class sitemap

        <XmlElement>
        Public Property loc As String

        <XmlElement>
        Public Property lastmod As DateTime?
            Get
                Return DateTime.Parse(_lastmod).ToUniversalTime
            End Get
            Set(value As DateTime?)
                If value.HasValue Then
                    _lastmod = FormatDate(value)
                End If
            End Set
        End Property
        Private Property _lastmod As String

        Private Function FormatDate(ByRef DT As DateTime) As String
            Return DT.ToString("yyyy-MM-dd") & "T" & DT.ToString("hh:mm") & "+00:00"
        End Function

    End Class

    Public Class url : Inherits sitemap

        <XmlElement>
        Public Property changefreq As changefreq?

        <XmlElement>
        Public Property priority As String

    End Class

    Public Enum changefreq As Byte
        always
        hourly
        daily
        weekly
        monthly
        yearly
        never
    End Enum

End Namespace
