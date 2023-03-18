@ModelType web.Models.Topic.PageLinkModel
@code
    Layout = nothing
End Code

@If Model.Pages.Count > 0 Then
    @<div class="clearblank">
    </div>
    @<div id="pages" class="modelpopup">
        <div class="pill-top">
            @Html.Localize("Topic.Links.Title")
        </div>
        <div class="pill-bottom">
            <nav>
                <ul class="ulink">
                    @For Each p In Model.Pages
                        @<li>@(html.RouteLink(p.SeoFriendly, "TopicPageView", New With {.seo = p.seo.ToLower}))</li>
                    Next
                </ul>
            </nav>
        </div>
     </div>
end if