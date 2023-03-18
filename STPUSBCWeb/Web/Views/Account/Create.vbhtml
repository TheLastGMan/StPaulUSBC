@ModelType Web.Models.Account.CreateModel

@Code
    Dim title As String = String.Format(Html.Localize("Account.Create.Title").ToHtmlString, Model.User.Username)
    ViewData("Title") = Html.TitleMaker(title)
End Code

<h2>@(title)</h2>
@Using Html.BeginForm()
    @html.HiddenFor(Function(f) f.User.Id)
    @<table id="editprofile">
        <thead>
            <tr>
                <td>&nbsp;</td>
                <td></td>
            </tr>
        </thead>
        <tbody>
            <tr class="submit-ltgold">
                <td colspan="2" style="text-align:center;">
                    @Html.Localize("Account.Create.Profile")
                </td>
            </tr>
            <tr class="odd-line">
                <td>@Html.Localize("Account.Create.FirstName") :&nbsp;</td>
                <td>@Html.TextBoxFor(Function(f) f.User.FirstName)<br/>
                    @html.ValidationMessageFor(Function(f) f.User.FirstName)
                </td>
            </tr>
            <tr class="even-line">
                <td>@Html.Localize("Account.Create.LastName") :&nbsp;</td>
                <td>@Html.TextBoxFor(Function(f) f.User.LastName)<br/>
                    @html.ValidationMessageFor(Function(f) f.User.LastName)
                </td>
            </tr>
            <tr class="odd-line">
                <td>@Html.Localize("Account.Create.Username") :&nbsp;</td>
                <td>@Html.TextBoxFor(Function(f) f.User.Username)<br/>
                    @html.ValidationMessageFor(Function(f) f.User.Username)
                </td>
            </tr>
            <tr class="even-line">
                <td>@Html.Localize("Account.Create.password") :&nbsp;</td>
                <td>@Html.TextBoxFor(Function(f) f.User.password, New With {.type="password", .Value=""})<br/>
                    @html.ValidationMessageFor(Function(f) f.User.Password)
                </td>
            </tr>
            <tr class="odd-line">
                <td>@Html.Localize("Account.Create.passwordconfirm") :&nbsp;</td>
                <td>@Html.TextBoxFor(Function(f) f.User.ConfirmPassword, New With {.type = "password", .Value = ""})<br/>
                    @Html.ValidationMessageFor(Function(f) f.User.ConfirmPassword)
                </td>
            </tr>
            <tr class="even-line">
                <td>@Html.Localize("Account.Create.active") :&nbsp;</td>
                <td>@Html.CheckBoxFor(Function(f) f.User.active)</td>
            </tr>
            <tr class="submit-ltgold">
                <td colspan="2" style="text-align:center;">
                    @Html.Localize("Account.Create.Roles")
                </td>
            </tr>
            @For j As Integer = 1 To Model.RoleList.Count
                    Dim lj As Integer = j
                    Dim itm = Model.RoleList(j - 1)
                @<tr class="@(iif(j mod 2, "odd", "even"))-line">
                    <td>@(itm.RoleKey) :&nbsp;</td>
                    <td>
                        @Html.HiddenFor(Function(f) f.RoleList(lj - 1).RoleKey)
                        @Html.CheckBoxFor(Function(f) f.RoleList(lj - 1).InRole)
                    </td>
                 </tr>
            Next
        </tbody>
        <tfoot>
            <tr>
                <td colspan="2">
                    <input type="submit" class="submit-green" value="@Html.Localize("Account.Create.UpdateSubmit")" />&nbsp;&nbsp;
                    <a href="@Url.Action("Manage")" class="linkbutton submit-red">@Html.Localize("Account.Create.CancelSubmit")</a>
                </td>
            </tr>
        </tfoot>
    </table>
end using
