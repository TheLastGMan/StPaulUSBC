@ModelType Web.Models.Tournament.TournamentEmailProfile
@Code
    Layout = Nothing
End Code

<h1>@Html.Localize("Tournament.EmailProfile.Header")</h1>
@Using Html.BeginForm("TournamentEmailProfile", "Tournament")
    @<table id="manageTournamentEmailProfile">
        <thead>
            <tr>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
            </tr>
        </thead>
        <tbody>
            <tr class="odd-line">
                <td>@Html.Localize("Tournament.EmailProfile.CurrentProfile")</td>
                <td>@Html.DropDownListFor(Function(f) f.Name, Model.EMailProfiles.Select(Function(f) New SelectListItem() With {.Text = f, .Value = f}))</td>
            </tr>
        </tbody>
        <tfoot>
            <tr>
                <td colspan="2">
                    @Html.AntiForgeryToken()
                    <input type="submit" value="@Html.Localize("Tournament.EmailProfile.UpdateButton")" class="submit-gold" />
                </td>
            </tr>
        </tfoot>
    </table>
End Using
