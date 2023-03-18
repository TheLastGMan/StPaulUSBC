@ModelType Web.Models.HonorScore.ScoreView
@Code
    ViewData("Title") = Html.TitleMaker(Html.Localize("HonorScore.ScoreViewSeries.URLTitle").ToString, Model.TypeFULL, Model.CategoryFULL)
    Dim rowcnt As Integer = 1
    'Dim slst = Model.Scores.OrderBy(Function(f) f.FormattedName).ThenByDescending(Function(f) f.Achieved).ToList
end code

<h1>@String.Format(Html.Localize("HonorScore.ScoreViewSeries.Title").ToHtmlString, Model.Title)</h1>
@Html.Widget("honorscore_scoreviewseries")

@If Model.Scores.Count > 0 Then
    @Html.Pager(Model.PageInfo.CurrentPage, Model.PageInfo.TotalPages, Function(x) Url.Action("Scores", New With {.typeseo = Model.TypeSEO, .catseo = Model.CategorySEO, .page = x}))
End If

@For Each itm In Model.Scores
    'rowcnt += 1
    @<div class="viewcontainer">
        <div class="profilename">
            <h2>@html.ActionLink(itm(0).FormattedName, "Profile", New With {.id= itm(0).FormattedName.Replace(", ","-").ToLower}, New With {.style="color:#000;"})</h2>
        </div>
        <div class="CDE contentcontainer" style="background-color:@(IIf(rowcnt mod 2, "#AAA", "#777"));">
            <div class="scoreview">
                <h3>@Html.Localize("HonorScore.ScoreViewSeries.AchievedTitle")</h3>
                @Html.Raw(String.Join("<br/>", itm.Select(Function(f) f.Achieved.ToString("MMM-dd-yyyy")).ToArray))
            </div>
            <div class="scoreview">
                <h3>@Html.Localize("HonorScore.ScoreViewSeries.GameTitle")</h3>
                @(Html.Raw(String.Join("<br/>", itm.Select(Function(f) Html.GameString(f.Game1, f.Game2, f.Game3)))))
            </div>
            <div class="scoreview">
                <h3>@Html.Localize("HonorScore.ScoreViewSeries.SeriesTitle")</h3>
                @Html.Raw(String.Join("<br/>", itm.Select(Function(f) f.Series).ToArray))
            </div>
        </div>
    </div>    
Next

@Html.LastUpdated(Model.LastUpdated)

@If Model.Scores.Count > 0 Then
    @Html.Pager(Model.PageInfo.CurrentPage, Model.PageInfo.TotalPages, Function(x) Url.Action("Scores", New With {.typeseo = Model.TypeSEO, .catseo = Model.CategorySEO, .page = x}))
End If
