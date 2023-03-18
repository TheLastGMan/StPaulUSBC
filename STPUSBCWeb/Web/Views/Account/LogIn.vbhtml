@ModelType web.Models.Account.LogInModel
@Code
    ViewData("Title") = Html.TitleMaker(Html.Localize("Account.LogIn.URLTitle").ToString)
End Code

<h1>Log In</h1>
@Html.Widget("account_login")
<table id="login">
    <thead>
        <tr>
            <td>&nbsp;</td>
            <td></td>
        </tr>
    </thead>
    @Using Html.BeginForm()
        @Html.AntiForgeryToken()
        @<tbody>
            <tr class="odd-line">
                <td>@Html.Localize("Account.LogIn.UserName") :&nbsp;</td>
                <td>
                    @Html.TextBoxFor(Function(f) f.Username, New With {.required = "required", .placeholder = Html.Localize("Account.LogIn.UserName")})
                    @Html.ValidationMessageFor(Function(f) f.Username)
                </td>
            </tr>
            <tr class="even-line">
                <td>@Html.Localize("Account.LogIn.Password") :&nbsp;</td>
                <td>
                    @Html.TextBoxFor(Function(f) f.Password, New With {.type = "password", .required = "required", .placeholder = Html.Localize("Account.LogIn.Password")})
                    @Html.ValidationMessageFor(Function(f) f.Password)
                </td>
            </tr>
            <tr class="odd-line">
                <td colspan="2" style="text-align:center;">
                    <input type="submit" value="@Html.Localize("Account.LogIn.LogInSubmit")" class="submit-ltgold" />
                </td>
            </tr>
        </tbody>        
    End Using
    <tfoot>
        <tr>
            <td colspan="2"></td>
        </tr>
    </tfoot>
</table>
@Html.ValidationSummary(true)