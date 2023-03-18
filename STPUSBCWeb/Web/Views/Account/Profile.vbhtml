@ModelType web.Models.Account.ProfileModel
@Code
    ViewData("Title") = Html.TitleMaker(Html.Localize("Account.Profile.URLTitle").ToString, String.Format("{0} {1}", Model.User.FirstName, Model.User.LastName))
End Code

<table id="userprofile" >
    <thead>
        <tr>
            <td>@Html.Localize("Account.LogIn.Profile")</td>
            <td>@Html.Localize("Account.LogIn.Profile")</td>
        </tr>
    </thead>
    <tbody>
        <tr class="submit-ltgold">
            <td>
                @Html.Partial("_ProfileTable", Model.User)
            </td>
            <td>
                @Html.Partial("_RoleInfo", Model.Roles)
            </td>
        </tr>
    </tbody>
    <tfoot>
        <tr>
            <td colspan="2">&nbsp;</td>
        </tr>
    </tfoot>
</table>