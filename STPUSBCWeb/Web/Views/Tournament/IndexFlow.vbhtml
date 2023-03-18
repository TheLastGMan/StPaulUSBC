@ModelType Web.Models.Tournament.IndexModel
@Code
    ViewData("Title") = Html.TitleMaker(Html.Localize("Tournament.Index.URLTitle").ToString)
End Code

<h1>Tournaments</h1>
@Html.Widget("tournament_index")

@For Each g In Model.Tournaments.GroupBy(Function(f) f.Start_Date.Month.ToString & f.Start_Date.Year.ToString)
    @<div class="tournament-container">
        <h2>@(g(0).Start_Date.Month) / @(g(0).Start_Date.Year)</h2>
        @For Each t In g
            @<div class="tournament-box" itemscope itemtype="http://data-vocabulary.org/Event">
                <div style="visibility:hidden" itemprop="eventType">Tournament</div>
                <div class="name">
                    <a href="@(t.EventUrl)" target="_blank" itemprop="url"><span itemprop="summary">@(t.EventName)</span></a>
                </div>
                <div class="classification">
                    @(t.Tournament_Classification.Description)
                </div>
                <div class="location" itemprop="location">@(t.Center)</div>
                <div class="contact">
                    @If Not String.IsNullOrEmpty(t.ContactEmail) Then
                        @<a href="mailto:@(t.ContactEmail)?subject=@(t.EventName.Trim().Replace(" ", "%20"))%20Tournament" target="_blank">@(t.Contact)</a>
                    Else
                        @(t.Contact)
                    End If
                </div>
                <div class="dates">
                    <time itemprop="startDate" datetime="@(t.Start_Date.ToString())">@(t.Start_Date.ToString(Model.StartDate_Format))</time>
                    @If t.End_Date.HasValue Then
                        @<br />@Html.Raw("to")@<br />
                        @<time itemprop="endDate" datetime="@(t.End_Date.ToString())">@(t.End_Date.Value.ToString(Model.EndDate_Format))</time>
                    End If
                </div>
            </div>
        Next
    </div>
Next
