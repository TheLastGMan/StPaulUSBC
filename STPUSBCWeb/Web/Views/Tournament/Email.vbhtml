@ModelType Web.Models.Tournament.EMailModel
@Code
    ViewData("Title") = Html.TitleMaker(Html.Localize("Tournament.Index.URLTitle").ToString(), Model.Subject)
End Code

<h1>Tournament Contact - @Model.Subject</h1>

@Html.ValidationSummary()

@If (Not Model.SendError) Then
    Using Html.BeginForm()
        @Html.AntiForgeryToken()
        @Html.HiddenFor(Function(f) f.TournamentId)
        @<table id="tournament-email">
            <thead>
                <tr>
                    <td>&nbsp;</td>
                    <td>&nbsp;</td>
                </tr>
            </thead>
            <tbody>
                <tr class="odd-line">
                    <td>@Html.Localize("Tournament.EMail.To"): </td>
                    <td>@Model.ContactName</td>
                </tr>
                <tr class="even-line">
                    <td>@Html.Localize("Tournament.EMail.FromName"): </td>
                    <td>@Html.TextBoxFor(Function(f) f.FromName, New With {.required = "required"})</td>
                </tr>
                <tr class="odd-line">
                    <td>
                        @Html.Localize("Tournament.EMail.FromEMail"):&nbsp;
                        <br />
                        @Html.Localize("Tournament.EMail.FromEMailDescription")
                    </td>
                    <td>@Html.TextBoxFor(Function(f) f.FromEMail, New With {.type = "email", .required = "required"})</td>
                </tr>
                <tr class="even-line">
                    <td>@Html.Localize("Tournament.EMail.Subject"): </td>
                    <td>@Model.Subject Tournament</td>
                </tr>
                <tr class="odd-line" id="message-body">
                    <td>@Html.Localize("Tournament.EMail.Body"): </td>
                    <td>@Html.TextAreaFor(Function(f) f.Body, New With {.required = "required"})</td>
                </tr>
                <tr class="even-line">
                    <td>@Html.Localize("Tournament.EMail.Security"): </td>
                    <td>@CaptchaMvc.HtmlHelpers.CaptchaHelper.Captcha(MyBase.Html, Localize("Tournament.EMail.Captcha.RefreshLine"), Localize("Tournament.EMail.Captcha.InputLine"), 6, Localize("Tournament.EMail.Captcha.RequiredLine"), True)</td>
                </tr>
                <tr class="odd-line">
                    <td colspan="2" style="text-align: center;">
                        <input type="submit" class="submit-ltgold" value="@Html.Localize("Tournament.EMail.Submit")" />
                    </td>
                </tr>
            </tbody>
            <tfoot>
                <tr>
                    <td colspan="5">&nbsp;</td>
                </tr>
            </tfoot>
        </table>
    End Using
Else
    @<p>
        Error: @Model.SendErrorMessage
        <br /><br />
        @Html.Localize("Tournament.EMail.SendError") <a href="mailto:@(Model.ToEmail)?subject=@(Model.Subject.Replace(" ", "%20")) [Tournament]&body=@(Model.Body)">@Model.ContactName</a>
    </p>
End If

