@ModelType Web.Models.SeasonAverage.IndexModel
@Code
    ViewData("Title") = Html.TitleMaker(Html.Localize("SeasonAverage.Index.Title").ToString)
End Code

<h1>@Html.Localize("SeasonAverage.Index.Title")</h1>
<div id="seasonaverage_header">
    @Using Html.BeginForm("Index", "SeasonAverage", FormMethod.Post, New With {.class = "seasonaverageform"})
        @<fieldset class="average-searchbox">
            <legend>@Html.Localize("SeasonAverage.Index.Name.Title")</legend>
            @Html.Localize("SeasonAverage.Index.SearchText.FirstName") : @(Html.TextBox("FirstName", Model.FirstName))
            <br />
            @Html.Localize("SeasonAverage.Index.SearchText.LastName") : @Html.TextBox("LastName", Model.LastName, New With {.required = "required"})
            <br />
            <input class="submit-ltgold" type="submit" value="@Html.Localize("SeasonAverage.Index.SearchSubmit")" />
        </fieldset>
    End Using
    @Using Html.BeginForm("Index", "SeasonAverage", FormMethod.Post, New With {.class = "seasonaverageform"})
        @<fieldset class="average-searchbox">
            <legend>@Html.Localize("SeasonAverage.Index.USBCID.Title")</legend>
            @Html.Localize("SeasonAverage.Index.SearchText.USBCID") : @(Html.TextBox("USBCID", Model.USBCID, New With {.required = "required"}))
            <br />
            <input name="byid" class="submit-ltgold" type="submit" value="@Html.Localize("SeasonAverage.Index.SearchSubmit")" />
        </fieldset>
    End Using
</div>

@If Model.RanQuery Then
    @<h2 style="text-align:center; margin:10px 0;">
        @code
            Dim searchresulttext As String = Model.LastName & ", " & Model.FirstName
            If Not String.IsNullOrEmpty(Model.USBCID) Then
                searchresulttext = Model.USBCID
            End If
        End Code
        @Html.Localize("SeasonAverage.Index.SearchResultTitle").ToHtmlString.Replace("{0}", searchresulttext)<br />
    </h2>
    @<h3 style="text-align:center;">Top 15 Results</h3>

    @<div id="seasonaverage_searchresults">
        @code
            Dim i As Integer = 0
        End Code
        @For Each bowler As Core.SeasonAverageBowlerResult In Model.SearchResults
            i += 1
            @<div class="@(IIf(i Mod 2, "odd", "even"))-line seasonaveragesearchrow">
                <h3>@bowler.FullName</h3>
                <h4>@bowler.Id</h4>
                <table>
                    <tr>
                        <td>@Html.Localize("SeasonAverage.Index.SearchResult.Season")</td>
                        <td>@Html.Localize("SeasonAverage.Index.SearchResult.GamesTitle")</td>
                        <td>@Html.Localize("SeasonAverage.Index.SearchResult.AverageTitle")</td>
                        <td>@Html.Localize("SeasonAverage.Index.SearchResult.LeagueTitle")</td>
                    </tr>
                    @For k As Integer = 1 To bowler.Averages.Count
                        Dim season As KeyValuePair(Of String, IEnumerable(Of Data.Entity.SeasonAverage)) = bowler.Averages.ElementAt(k - 1)
                        For j As Integer = 1 To season.Value.Count()
                            Dim score As Data.Entity.SeasonAverage = season.Value.ElementAt(j - 1)
                            @<tr class="gridrow CDE">
                                @if j = 1 Then
                                    @<td rowspan="@(season.Value.Count)" class="multirow_column" style="border-bottom:@(IIf(k < bowler.Averages.Count, "1px solid #000", "none"));">
                                        @(season.Key)
                                    </td>
                                End If
                                <td style="@(IIf(j = season.Value.Count() And k < bowler.Averages.Count, "border-bottom:1px solid #000;", ""))">@score.Games</td>
                                <td style="@(IIf(j = season.Value.Count() And k < bowler.Averages.Count, "border-bottom:1px solid #000;", ""))">@score.Average @score.Hand</td>
                                <td style="@(IIf(j = season.Value.Count() And k < bowler.Averages.Count, "border-bottom:1px solid #000;", ""))">@score.League</td>
                            </tr>
                        Next
                    Next
                </table>
            </div>
        Next
        @If Model.SearchResults.Count = 0 Then
            @<h3>@Html.Localize("SeasonAverage.Index.NoSearchResult")</h3>
        End If
    </div>
 End If

