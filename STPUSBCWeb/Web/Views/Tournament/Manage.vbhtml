@ModelType Web.Models.Tournament.IndexModel
@Code
    ViewData("Title") = Html.TitleMaker(Html.Localize("Tournament.Manage.URLTitle").ToString)
End Code

<h1>@Html.Localize("Tournament.Manage.Title")</h1>
<div style="text-align:center; margin:3px 0;">
    <a href="@Url.Action("Create")" class="linkbutton submit-gold">@Html.Localize("Tournament.Manage.CreateSubmit")</a>
</div>
<table id="ManageTournaments" >
    <thead>
        <tr>
            <td>@Html.Localize("Tournament.Manage.TournamentClassificationTitle")</td>
            <td>@Html.Localize("Tournament.Manage.EventTitle")</td>
            <td>@Html.Localize("Tournament.Manage.CenterTitle")</td>
            <td>@Html.Localize("Tournament.Manage.ContactTitle")</td>
            <td class="hidemobile">@Html.Localize("Tournament.Manage.DateTitle")</td>
            <td>@Html.Localize("Tournament.Manage.EditTitle")</td>
            <td>@Html.Localize("Tournament.Manage.DeleteTitle")</td>
        </tr>
    </thead>
    <tbody>
        @For i As Integer = 1 To Model.Tournaments.Count
            Dim t = Model.Tournaments(i - 1)
            @<tr class="@(IIf(i Mod 2, "odd", "even"))-line">
                <td>@(t.Tournament_Classification.Description)</td>
                <td>@(t.EventName)</td>
                <td>@(t.Center)</td>
                <td>@(t.Contact)</td>
                <td class="hidemobile">
                    @(t.Start_Date.ToString(Model.StartDate_Format))
                    @If t.End_Date.HasValue Then
                        @<span> @Html.Localize("Tournament.Manage.DateSeparator") @(t.End_Date.Value.ToString(Model.EndDate_Format))</span>
                    End If
                </td>
                <td>
                    <form action="@Url.Action("Edit", New With {.id = t.Id.ToString})">
                        <input type="submit" class="submit-ltgold" value="@Html.Localize("Tournament.Manage.EditSubmit")" />
                    </form>
                </td>
                <td>
                    @Using Html.BeginForm("Delete", "Tournament")
                        @Html.Hidden("id", t.Id.ToString)
                        @<input type="submit" class="submit-red" value="@Html.Localize("Tournament.Manage.DeleteSubmit")" />
                    End Using
                </td>
            </tr>
        Next
    </tbody>
    <tfoot>
        <tr>
            <td colspan="99">&nbsp;</td>
        </tr>
    </tfoot>
</table>

@Html.Action("TournamentEmailProfile")