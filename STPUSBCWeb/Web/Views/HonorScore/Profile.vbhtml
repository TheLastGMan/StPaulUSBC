@modeltype List(Of Data.Entity.Honor)
@Code
    ViewData("Title") = Html.TitleMaker(Html.Localize("HonorScore.Profile.URLTitle").ToString, String.Format("{0} {1}", Model(0).FirstName, Model(0).LastName))
End Code

<h1>@(Model(0).FormattedName)</h1>
<div class="viewcontainer">
    <div class="CDE contentcontainer" style="background-color:#AAA"));">
        <div class="scoreview">
            <h3>@Html.Localize("HonorScore.ScoreViewSeries.AchievedTitle")</h3>
            @(Html.Raw(String.Join("<br/>", Model.Select(Function(f) f.Achieved.ToString("MMM-dd-yyyy")))))
        </div>
        <div class="scoreview">
            <h3>@Html.Localize("HonorScore.ScoreViewSeries.GameTitle")</h3>
            @(Html.Raw(String.Join("<br/>", Model.Select(Function(f) Html.GameString(f.Game1, f.Game2, f.Game3)))))
        </div>
        <div class="scoreview">
            <h3>@Html.Localize("HonorScore.ScoreViewSeries.SeriesTitle")</h3>
            @(Html.Raw(String.Join("<br/>", model.Select(Function(f) f.Series).ToArray)))
        </div>
    </div>
</div>    
<div style="float:left; width:100%; margin-top:10px;">
    @Html.LastUpdated(Model.OrderByDescending(Function(f) f.Achieved).Select(Function(f) f.Achieved).FirstOrDefault)
</div>

