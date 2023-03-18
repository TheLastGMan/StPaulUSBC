@ModelType Web.Models.Award.AwardEmailProfile
@Code
    Layout = Nothing
End Code

<h1>@Html.Localize("Award.EmailProfile.Header")</h1>
@Using Html.BeginForm("AwardEmailProfile", "Award")
    @<table id="manageEmailProfile">
        <thead>
            <tr>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
            </tr>
        </thead>
        <tbody>
            <tr class="odd-line">
                <td>@Html.Localize("Award.EmailProfile.CurrentProfile")</td>
                <td>@Html.DropDownListFor(Function(f) f.Name, Model.EMailProfiles.Select(Function(f) New SelectListItem() With {.Text = f, .Value = f}))</td>
            </tr>
            <tr class="even-line">
                <td>@Html.Localize("Award.EmailProfile.SendToAddress")</td>
                <td>@Html.TextBoxFor(Function(model) model.ToEmailAddress)</td>
            </tr>
        </tbody>
        <tfoot>
            <tr>
                <td colspan="2">
                    @Html.AntiForgeryToken()
                    <input type="submit" value="@Html.Localize("Award.EmailProfile.UpdateButton")" class="submit-gold" />
                </td>
            </tr>
        </tfoot>
    </table>
End Using
