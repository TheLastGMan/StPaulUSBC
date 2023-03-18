@ModelType Data.Entity.User
@code
    Layout = Nothing
End Code

<table id="userprofileinfo">
    <thead>
        <tr>
            <td>&nbsp;</td>
            <td></td>
        </tr>
    </thead>
    <tbody>
        <tr class="odd-line">
            <td>@Html.Localize("Account.ProfileView.FirstName") :&nbsp;</td>
            <td>@(model.FirstName)</td>
        </tr>
        <tr class="even-line">
            <td>@Html.Localize("Account.ProfileView.LastName") :&nbsp;</td>
            <td>@(Model.LastName)</td>
        </tr>
        <tr class="odd-line">
            <td>@Html.Localize("Account.ProfileView.UserName") :&nbsp;</td>
            <td>@(model.Username)</td>
        </tr>

        <tr class="even-line">
            <td>@Html.Localize("Account.ProfileView.Password") :&nbsp;</td>
            <td>
                @Using Html.BeginForm("UpdatePassword", "Account")
                    @Html.TextBox("password", "")@<br />
                    @<input type="submit" class="submit-green" value="@Html.Localize("Account.ProfileView.Password.Submit")" />
                End Using
            </td>
        </tr>

        <tr class="even-line">
            <td>@Html.Localize("Account.ProfileView.LastLogin") :&nbsp;</td>
            <td>@(Model.last_login_utc.ToString("MMM-dd-yyyy"))</td>
        </tr>
        <tr class="odd-line">
            <td>@Html.Localize("Account.ProfileView.Created") :&nbsp;</td>
            <td>@(Model.created_utc.ToString("MMM-dd-yyyy"))</td>
        </tr>
        <tr class="even-line">
            <td>@Html.Localize("Account.ProfileView.Active") :&nbsp;</td>
            <td>@(model.active.ToString)</td>
        </tr>
    </tbody>
    <tfoot>
        <tr>
            <td colspan="2">&nbsp;</td>
        </tr>
    </tfoot>
</table>