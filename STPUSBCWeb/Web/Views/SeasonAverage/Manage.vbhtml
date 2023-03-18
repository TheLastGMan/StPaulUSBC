@ModelType web.Models.SeasonAverage.ManageModel
@Code
    ViewData("Title") = Html.TitleMaker(Html.Localize("SeasonAverage.Manage.Title").ToString)
End Code

<h1>@Html.Localize("SeasonAverage.Manage.Title")</h1>

@If Model.result.Length > 0 Then
    @<h2>@Model.result</h2>
End If

@Using Html.BeginForm("Manage", "SeasonAverage", FormMethod.Post, New With {.enctype = "multipart/form-data"})
    @<table id="seasonaveragemanage">
        <thead>
            <tr>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
            </tr>
        </thead>
        <tbody>
            <tr class="odd-line">
                <td>@Html.Localize("SeasonAverage.Manage.Season") :&nbsp;</td>
                <td>@Html.TextBoxFor(Function(f) f.season)</td>
            </tr>
            <tr class="even-line">
                <td>@Html.Localize("SeasonAverage.Manage.UploadChoice") :&nbsp;</td>
                <td>
                    @Html.RadioButtonFor(Function(f) f.choice, 0)- @Html.Localize("SeasonAverage.Manage.UploadChoice.Purge")<br />
                    @Html.RadioButtonFor(Function(f) f.choice, 1)- @Html.Localize("SeasonAverage.Manage.UploadChoice.Append")
                </td>
            </tr>
            <tr class="odd-line">
                <td>@Html.Localize("SeasonAverage.Manage.File") :&nbsp;</td>
                <td>@Html.TextBox("file", "", New With {.type="file"})</td>
            </tr>
        </tbody>
        <tfoot>
            <tr>
                <td colspan="2" style="text-align:center;">
                    <input type="submit" class="submit-green" value="@Html.Localize("SeasonAverage.Manage.Submit")" />
                </td>
            </tr>
        </tfoot>
     </table>
End Using