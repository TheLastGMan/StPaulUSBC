Public Class RoutePublisher : Implements Framework.IRouteProvider

    Public ReadOnly Property Priority As Integer Implements Framework.IRouteProvider.Priority
        Get
            Return 0
        End Get
    End Property

    Public Sub RegisterRoutes(ByRef routes As RouteCollection) Implements Framework.IRouteProvider.RegisterRoutes
        With routes
            'Ignore Folders
            .IgnoreRoute("{*favicon}", New With {.favicon = "(.*/)?favicon.ico(/.*)?"})
            .IgnoreRoute("editor/{*pathInfo}")
            .IgnoreRoute("uploads/{*pathInfo}")
            .IgnoreRoute("content/{*pathInfo}")
            .IgnoreRoute("images/{*pathInfo}")
            .IgnoreRoute("scripts/{*pathInfo}")

            'Account
            .MapRoute("LogIn",
                      "myusbc",
                      New With {.controller = "Account", .action = "LogIn"})

            .MapRoute("LogOut",
                      "logout",
                      New With {.controller = "Account", .action = "LogOut"})

            'Award
            .MapRoute("AwardDefault",
                      "award/{action}/{id}",
                      New With {.controller = "Award", .action = "Index", .id = UrlParameter.Optional})

            'E-Mail Profile
            .MapRoute("EmailProfile",
                      "emails/{action}/{id}",
                      New With {.controller = "EmailProfile", .action = "Index", .id = UrlParameter.Optional})

            'Hall Of Fame
            .MapRoute("HallOfFame_Profile",
                      "hof/p/{id}/{seo}",
                      New With {.controller = "HallOfFame", .action = "Profile", .seo = UrlParameter.Optional}, New With {.id = "\d{0,}"})

            .MapRoute("HallOfFame",
                      "hof/{action}/{id}",
                      New With {.controller = "HallOfFame", .action = "Index", .id = UrlParameter.Optional})

            'Honor Scores
            .MapRoute("HonorScores_Short",
                      "honors/s/{typeseo}/{catseo}/{page}",
                      New With {.controller = "HonorScore", .Action = "Scores", .page = UrlParameter.Optional}, New With {.page = "\d{0,}"})

            .MapRoute("HonorScoreProfile",
                      "honors/p/{id}",
                      New With {.controller = "HonorScore", .action = "Profile"})

            .MapRoute("HonorScoreManageView",
                      "honors/manage/{htid}/{hcid}",
                      New With {.controller = "HonorScore", .action = "Manage", .htid = UrlParameter.Optional, .hcid = UrlParameter.Optional, .id = UrlParameter.Optional})

            .MapRoute("HonorScoreManageViewEdit",
                      "honors/edit/{htid}/{hcid}/{id}",
                      New With {.controller = "HonorScore", .action = "HonorEdit", .htid = UrlParameter.Optional, .hcid = UrlParameter.Optional, .id = UrlParameter.Optional})

            .MapRoute("HonorScoreDefault",
                      "honors/{action}/{id}",
                      New With {.controller = "HonorScore", .action = "Index", .id = UrlParameter.Optional})

            'Topic
            .MapRoute("TopicPageView",
                      "page/{seo}",
                      New With {.controller = "Topic", .action = "SEOS"})

            .MapRoute("TopicDefault",
                      "topic/{action}/{seo}",
                      New With {.controller = "Topic", .action = "Manage"})

            'Localization
            .MapRoute("LocalizationSearch",
                      "localization/manage/{field}/{parameter}",
                      New With {.controller = "Localization", .action = "Manage", .field = UrlParameter.Optional, .parameter = UrlParameter.Optional, .search = UrlParameter.Optional})

            'Tournament Default
            .MapRoute("Tournament",
                      "tournament/{action}/{id}",
                      New With {.controller = "Tournament", .action = "Index", .id = UrlParameter.Optional})

            'Search
            .MapRoute("Search",
                      "s",
                      New With {.controller = "Search", .action = "Index"})

            'Board
            .MapRoute("BoardProfile",
                      "board/p/{id}",
                      New With {.controller = "Board", .action = "Profile"})

            .MapRoute("BoardDefault",
                      "board/{action}/{id}",
                      New With {.controller = "Board", .action = "Index", .id = UrlParameter.Optional})

            'SiteMap
            .MapRoute("SiteMapGenerate",
                      "smg/{id}",
                      New With {.controller = "SiteMap", .action = "Generate"})
            .MapRoute("SiteMapGenerator",
                     "smg/{id}/{page}",
                     New With {.controller = "SiteMap", .action = "Generate", .page = UrlParameter.Optional})
            .MapRoute("SiteMap",
                      "sitemap/{action}/{id}",
                      New With {.controller = "SiteMap", .action = "Index", .id = UrlParameter.Optional})


            'Season Average
            .MapRoute("SeasonAverage",
                      "aves/{action}/{id}",
                      New With {.controller = "SeasonAverage", .action = "Index", .id = UrlParameter.Optional})

            'RSS
            .MapRoute("RSSDefault",
                      "rss/{action}/{id}",
                      New With {.controller = "RSS", .action = "Index", .id = UrlParameter.Optional})

        End With
    End Sub

End Class
