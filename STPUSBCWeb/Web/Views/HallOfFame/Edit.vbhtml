@ModelType Web.Models.HallOfFame.EditModel
@Code
    Dim fullname As String = String.Format("{0} {1}", Model.Famer.FirstName, Model.Famer.LastName)
    ViewData("Title") = Html.TitleMaker(Html.Localize("HallOfFame.Edit.URLTitle").ToString, fullname)
End Code
@Html.DateField("Famer_Achieved")

<h1>@(String.Format(Html.Localize("HallOfFame.Edit.Title").ToHtmlString, fullname))</h1>
<div class="clearblank4"></div>
@Html.ValidationSummary()
@Using Html.BeginForm("Edit", "HallOfFame", FormMethod.Post, New With {.enctype = "multipart/form-data"})
    @<table id="edithof" >
        <thead>
            <tr>
                <td>&nbsp;</td>
                <td></td>
            </tr>
        </thead>
        <tbody>
            <tr class="odd-line">
                <td>@Html.Localize("HallOfFame.Edit.FirstName") :&nbsp;</td>
                <td>@Html.TextBoxFor(Function(f) f.Famer.FirstName, New With {.required="required"})</td>
            </tr>
            <tr class="even-line">
                <td>@Html.Localize("HallOfFame.Edit.LastName") :&nbsp;</td>
                <td>@Html.TextBoxFor(Function(f) f.Famer.LastName, New With {.required="required"})</td>
            </tr>
            <tr class="odd-line">
                <td>@Html.Localize("HallOfFame.Edit.RecognitionType") :&nbsp;</td>
                <td>@Html.DropDownListFor(Function(f) f.Famer.HallOfFame_RecognitionTypeId, New SelectList(Model.Types, "Id", "Description", Model.Famer.HallOfFame_RecognitionTypeId))</td>
            </tr>
            <tr class="even-line">
                <td>@Html.Localize("HallOfFame.Edit.USBCID") :&nbsp;</td>
                <td>@Html.TextBoxFor(Function(f) f.Famer.USBC_ID)</td>
            </tr>
            <tr class="odd-line">
                <td>@Html.Localize("HallOfFame.Edit.Deceased") :&nbsp;</td>
                <td>@Html.CheckBoxFor(Function(f) f.Famer.Deceased)</td>
            </tr>
            <tr class="even-line">
                <td>@Html.Localize("HallOfFame.Edit.Display") :&nbsp;</td>
                <td>@Html.CheckBoxFor(Function(f) f.Famer.Display)</td>
            </tr>
            <tr class="odd-line">
                <td>@Html.Localize("HallOfFame.Edit.Achieved") :&nbsp;</td>
                <td>@Html.TextBoxFor(Function(f) f.Famer.Achieved, New With {.required="required", .Value = Model.Famer.Achieved.ToString("MM/dd/yyyy")})</td>
            </tr>
            <tr class="even-line">
                <td>@Html.Localize("HallOfFame.Edit.ProfileImage") :&nbsp;</td>
                <td>
                    @Html.TextBox("profileimage", "", New With {.type="file"})<br />
                    <i>@Html.Localize("HallOfFame.Edit.ProfileImage.Info")</i>
                </td>
            </tr>
            <tr class="submit-ltgold">
                <td colspan="2" style="text-align:center;">
                    <img src="@Model.ImageData.URL" alt="Profile Picture" />
                </td>
            </tr>
        </tbody>
        <tfoot>
            <tr>
                <td colspan="2">&nbsp;</td>
            </tr>
        </tfoot>
    </table>
    @<h2 style="text-align:center">@Html.Localize("HallOfFame.Edit.WriteUpTitle")</h2>
    @<div>
        @Html.HtmlEditor("htmleditor", Model.Famer.WriteUp)
    </div>
    @<div style="text-align:center;">
        @Html.HiddenFor(Function(f) f.Famer.Id)
        <div class="clearblank4"></div>
        <input type="submit" value="@Html.Localize("HallOfFame.Edit.SaveSubmit")" class="submit-green" />&nbsp;&nbsp;
        <a href="@Url.Action("Manage")" class="linkbutton submit-red">@Html.Localize("HallOfFame.Edit.CancelSubmit")</a>
     </div>
end using
