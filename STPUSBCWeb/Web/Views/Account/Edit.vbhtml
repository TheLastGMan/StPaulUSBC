@ModelType Web.Models.Account.EditModel

@Code
    Dim title As String = String.Format(Html.Localize("Account.Edit.Title").ToHtmlString, Model.User.Username)
    ViewData("Title") = Html.TitleMaker(title)
End Code

<h1>@(title)</h1>
@Html.ValidationSummary()
@Using Html.BeginForm()
    @Html.HiddenFor(Function(f) f.User.id)
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
                    @Html.Localize("Account.Edit.Profile")
                </td>
            </tr>
            <tr class="odd-line">
                <td>@Html.Localize("Account.Edit.FirstName") :&nbsp;</td>
                <td>@Html.TextBoxFor(Function(f) f.User.FirstName)</td>
            </tr>
            <tr class="even-line">
                <td>@Html.Localize("Account.Edit.LastName") :&nbsp;</td>
                <td>@Html.TextBoxFor(Function(f) f.User.LastName)</td>
            </tr>
            <tr class="odd-line">
                <td>@Html.Localize("Account.Edit.password") :&nbsp;</td>
                <td>@Html.TextBoxFor(Function(f) f.User.password, New With {.type="password", .Value=""})</td>
            </tr>
            <tr class="even-line">
                <td>@Html.Localize("Account.Edit.active") :&nbsp;</td>
                <td>@Html.CheckBoxFor(Function(f) f.User.active)</td>
            </tr>
            <tr class="submit-ltgold">
                <td colspan="2" style="text-align:center;">
                    @Html.Localize("Account.Edit.Roles")
                </td>
            </tr>
            @For j As Integer = 1 To Model.RoleList.Count
                Dim itm = Model.RoleList(j-1)
                @<tr class="@(iif(j mod 2, "odd", "even"))-line">
                    <td>@(itm.RoleKey) :&nbsp;</td>
                    <td>
                        @Html.HiddenFor(Function(f) f.RoleList(j-1).RoleKey)
                        @Html.CheckBoxFor(Function(f) f.RoleList(j-1).InRole)
                    </td>
                 </tr>
            Next
        </tbody>
        <tfoot>
            <tr>
                <td colspan="2">
                    <input type="submit" class="submit-green" value="@Html.Localize("Account.Edit.UpdateSubmit")" />&nbsp;&nbsp;
                    <a href="@Url.Action("Manage")" class="linkbutton submit-red">@Html.Localize("Account.Edit.CancelSubmit")</a>
                </td>
            </tr>
        </tfoot>
    </table>
end using
