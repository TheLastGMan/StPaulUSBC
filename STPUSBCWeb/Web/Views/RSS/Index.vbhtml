@Code
    ViewData("Title") = Html.TitleMaker(Html.Localize("RSS.Index.Title").ToString)
End Code

<h1>@Html.Localize("RSS.Index.Title")</h1>

<div class="rssfeed">
    <div class="floatbox">
        @Html.ActionLink(Html.Localize("RSS.Index.HallOfFame.Title").ToHtmlString, "HallOfFame".ToLower)
        <br />
        <img src="@Url.Content("~/content/images/RSS-icon.png")" alt="@Html.Localize("RSS.Index.HallOfFame.Title")" />
    </div>
    <div class="floatbox">
        @Html.ActionLink(Html.Localize("RSS.Index.Tournament.Title").ToHtmlString, "Tournament".ToLower)
        <br />
        <img src="@Url.Content("~/content/images/RSS-icon.png")" alt="@Html.Localize("RSS.Index.Tournament.Title")" />
    </div>
    <div class="floatbox">
        @Html.ActionLink(Html.Localize("RSS.Index.Board.Title").ToHtmlString, "Board".ToLower)
        <br />
        <img src="@Url.Content("~/content/images/RSS-icon.png")" alt="@Html.Localize("RSS.Index.Board.Title")" />
    </div>
</div>
