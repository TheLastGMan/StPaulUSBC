@ModelType Web.Models.HonorScore.ScoreView
@Code
    ViewData("Title") = Html.TitleMaker(Html.Localize("HonorScore.ScoreViewGame.URLTitle").ToString, ToString, Model.TypeFULL, Model.CategoryFULL)
    Dim rowcnt As Integer = 0
    'Dim slst = Model.Scores.OrderBy(Function(f) f.FormattedName).ThenBy(Function(f) f.Achieved).ToList
End Code

<h1>@String.Format(Html.Localize("HonorScore.ScoreViewGame.Title").ToHtmlString, Model.Title)</h1>
@Html.Widget("honorscore_scoreviewgame")

@If Model.Scores.Count > 0 Then
    @Html.Pager(Model.PageInfo.CurrentPage, Model.PageInfo.TotalPages, Function(x) Url.Action("Scores", New With {.typeseo = Model.TypeSEO, .catseo = Model.CategorySEO, .page = x}))
End If

<table id="score-view-game" >
    <thead>
        <tr>
            <td>@Html.Localize("HonorScore.ScoreViewGame.NameTitle")</td>
            <td>@Html.Localize("HonorScore.ScoreViewGame.AchievedTitle")</td>
        </tr>
    </thead>
    <tbody>
        @For i As Integer = 1 To Model.Scores.Count
            Dim cs = Model.Scores(i - 1)
            For j As Integer = 1 To cs.Count
                Dim itm = cs(j-1)
                @<tr class="@(IIf(i Mod 2, "odd-line", "even-line"))">
                    <td>
                        @If j = 1 Then
                            @html.ActionLink(itm.FormattedName, "Profile", New With {.id= itm.FormattedName.Replace(", ","-").ToLower}, New With {.style="color:#000;"})
                        End If
                    </td>
                    <td>@(itm.Achieved.ToString(Model.AchievedFormat))</td>
                </tr>
                Next
        Next
        @If Model.Scores.Count = 0 Then
            @<tr class="odd-line">
                <td colspan="2">@Html.Localize("HonorScore.ScoreViewGame.NoData")</td>
             </tr>
        End If
    </tbody>
    <tfoot>
        <tr>
            <td colspan="2">&nbsp;</td>
        </tr>
    </tfoot>
</table>

@html.LastUpdated(Model.LastUpdated)

@If Model.Scores.Count > 0 Then
    @Html.Pager(Model.PageInfo.CurrentPage, Model.PageInfo.TotalPages, Function(x) Url.Action("Scores", New With {.typeseo = Model.TypeSEO, .catseo = Model.CategorySEO, .page = x}))
End If