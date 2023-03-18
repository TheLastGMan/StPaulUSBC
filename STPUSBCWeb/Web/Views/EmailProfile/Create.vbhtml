@ModelType Data.Entity.EmailProfile

@Code
    Dim title As String = Html.Localize("EmailProfile.Edit.Title").ToString()
    ViewData("Title") = title
End Code

<h1>@(title)</h1>
@Html.ValidationSummary()
@Using Html.BeginForm()
    @Html.AntiForgeryToken()
    @<table id="editEmailProfile">
        <thead>
            <tr>
                <td>&nbsp;</td>
                <td></td>
            </tr>
        </thead>
        <tbody>
            <tr class="odd-line">
                <td>@Html.Localize("EmailProfile.Edit.NameTitle") :&nbsp;</td>
                <td>@Html.TextBoxFor(Function(f) f.Name, New With {.required = "required"})</td>
            </tr>
            <tr class="even-line">
                <td>@Html.Localize("EmailProfile.Edit.SendAsTitle") :&nbsp;</td>
                <td>@Html.TextBoxFor(Function(f) f.SendAs, New With {.type = "email"})</td>
            </tr>
            <tr class="odd-line">
                <td>@Html.Localize("EmailProfile.Edit.DisplayNameTitle") :&nbsp;</td>
                <td>@Html.TextBoxFor(Function(f) f.DisplayName)</td>
            </tr>
            <tr class="even-line">
                <td>@Html.Localize("EmailProfile.Edit.SmtpHostTitle") :&nbsp;</td>
                <td>@Html.TextBoxFor(Function(f) f.SmtpHost)</td>
            </tr>
            <tr class="odd-line">
                <td>@Html.Localize("EmailProfile.Edit.SmtpPortTitle") :&nbsp;</td>
                <td>@Html.TextBoxFor(Function(f) f.SmtpPort, New With {.type = "number", .min = "1", .max = "65535"})</td>
            </tr>
            <tr class="even-line">
                <td>@Html.Localize("EmailProfile.Edit.UsernameTitle") :&nbsp;</td>
                <td>@Html.TextBoxFor(Function(f) f.UserName)</td>
            </tr>
            <tr class="odd-line">
                <td>@Html.Localize("EmailProfile.Edit.PasswordTitle") :&nbsp;</td>
                <td>@Html.TextBoxFor(Function(f) f.Password, New With {.type = "password"})</td>
            </tr>
        </tbody>
        <tfoot>
            <tr>
                <td colspan="2">
                    <input type="submit" class="submit-green" value="@Html.Localize("EmailProfile.Edit.UpdateSubmit")" />&nbsp;&nbsp;
                    <a href="@Url.Action("Manage")" class="linkbutton submit-red">@Html.Localize("EmailProfile.Edit.CancelSubmit")</a>
                </td>
            </tr>
        </tfoot>
    </table>
End Using
