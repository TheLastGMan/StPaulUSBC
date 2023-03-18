@ModelType list(of Core.Services.Content.SearchResult)
@Code
    ViewData("Title") = Html.TitleMaker(Html.Localize("Search.Index.URLTitle").ToString)
End Code

<h1>@Html.Localize("Search.Index.Title")</h1>
<br />
<div class="searchcontainer">
    @For Each s In Model
        @Html.Partial("_SearchItem", s)
    Next
    @If Model.Count = 0 Then
        @<h2>@Html.Localize("Search.Index.NoResult")</h2>
    End If
</div>