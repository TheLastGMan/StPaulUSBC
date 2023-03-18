@ModelType Web.Models.Tournament.IndexModel
@Code
    ViewData("Title") = Html.TitleMaker(Html.Localize("Tournament.Index.URLTitle").ToString)
End Code

<h1>Tournaments</h1>
@Html.Widget("tournament_index")

<table id="tournament">
    <thead>
        <tr>
            <td>@Html.Localize("Tournament.Index.TournamentClassificationTitle")</td>
            <td>@Html.Localize("Tournament.Index.EventTitle")</td>
            <td>@Html.Localize("Tournament.Index.ContactTitle")</td>
            <td>@Html.Localize("Tournament.Index.CenterTitle")</td>
            <td>@Html.Localize("Tournament.Index.DateTitle")</td>
        </tr>
    </thead>
    <tbody>
        @For i As Integer = 1 To Model.Tournaments.Count
            Dim t = Model.Tournaments(i - 1)
            With t
                @<tr class="@(IIf(i Mod 2, "odd-line", "even-line"))">
                    <td>@(.Tournament_Classification.Description)</td>
                    <td>
                        @If Not String.IsNullOrEmpty(.EventUrl) AndAlso .EventUrl.Length > 0 Then
                            @<a href="@(.EventUrl)" target="_blank">@(.EventName)</a>
                        Else
                            @(.EventName)
                        End If
                    </td>
                    <td>
                        @If Not String.IsNullOrEmpty(.ContactEmail) AndAlso .ContactEmail.Length > 0 Then
                            @Html.ActionLink(.Contact, "Email", New With {.id = t.Id.ToString()})
                        Else
                            @(.Contact)
                        End If
                    </td>
                    <td>@(.Center)</td>
                    <td>
                        @(.Start_Date.ToString(Model.StartDate_Format))
                        @If .End_Date.HasValue Then
                        @<span> to @(.End_Date.Value.ToString(Model.EndDate_Format))</span>
                        End If
                    </td>
                </tr>
            End With
        Next
        @If Model.Tournaments.Count = 0 Then
            @<tr class="odd-line">
                <td colspan="5" style="text-align:center;">@Html.Localize("Tournament.Index.NoData")</td>
            </tr>
        End If
    </tbody>
    <tfoot>
        <tr>
            <td colspan="5">&nbsp;</td>
        </tr>
    </tfoot>
</table>
