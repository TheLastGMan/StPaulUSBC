@ModelType Web.Models.SiteMap.IndexModel
@Code
    ViewData("Title") = Html.TitleMaker(Html.Localize("SiteMap.Index.URLTitle").ToString)
End Code

<h1>@Html.Localize("SiteMap.Index.Title")</h1>
<div class="sitemap">
    <div id="accordion">
        <h2>@Html.Localize("SiteMap.Index.NavigationTitle")</h2>
        <div>
            @For Each itm In Model.Navigation
                @<div class="sitemapbox">
                    @Html.ActionLink(itm.DisplayText, itm.View, itm.Controller)
                 </div>
            Next
        </div>

        <h2>@Html.Localize("SiteMap.Index.Tournament")</h2>
        <div>
            @For Each itm In Model.Tournaments
                @<div class="sitemapbox">
                    <a href="@itm.EventUrl">@itm.EventName</a>
                 </div> 
            Next
        </div>

        <h2>@Html.Localize("SiteMap.Index.Board")</h2>
        <div>
            @For Each itm In Model.Board
                @<div class="sitemapbox">
                    @Html.ActionLink(itm.FormattedName, "Profile", "Board", New With {.id = itm.Id.ToString}, nothing)
                 </div>
            Next
        </div>

        <h2>@Html.Localize("SiteMap.Index.Pages")</h2>
        <div>
            @For Each itm In Model.Pages
                @<div class="sitemapbox">
                    @(Html.RouteLink(itm.SeoFriendly, "TopicPageView", New With {.seo = itm.seo}))
                 </div>
            Next
        </div>

        <h2>@Html.Localize("SiteMap.Index.LinkTitle")</h2>
        <div>
            @For Each itm In Model.Links
                @<div class="sitemapbox">
                    <a href="@itm.Url">@itm.Name</a>
                 </div>
            Next
        </div>

        <h2>@Html.Localize("SiteMap.Index.HallOfFame")</h2>
        <div>
            @For Each itm In Model.HOF
                @<div class="sitemapbox">
                    @(Html.ActionLink(String.Format("{0} {1}", itm.FirstName, itm.LastName), "Profile", "HallOfFame", New With {.id = itm.Id, .seo = System.Web.httputility.UrlEncode(itm.FirstName & "_" & itm.LastName).ToLower}, New With {.target = "_parent"}))
                 </div>
            Next
        </div>

        <h2>@Html.Localize("SiteMap.Index.HonorScore")</h2>
        <div>
            @For Each itm In Model.Honors.orderby(Function(f) f.FormattedName).GroupBy(Function(f) f.FormattedName)
                @<div class="sitemapbox">
                    @Html.ActionLink(String.Format("{0} {1}", itm(0).FirstName, itm(0).LastName), "Profile", "HonorScore", New With {.id = itm(0).FormattedName.Replace(", ","-").ToLower}, New With {.target = "_parent"})
                 </div>
            next
        </div>

    </div>
</div>