@ModelType Web.Models.Award.AwardModel
@Code
    ViewData("Title") = Html.TitleMaker(Html.Localize("Award.Index.URLTitle").ToString)
End Code

<h1>@Html.Localize("Award.Index.Title")</h1>
@Html.Widget("award_index")

@Html.Partial("AwardForm", Model)