@ModelType Web.Models.HallOfFame.EditModel
@Code
    'Dim fullname As String = String.Format("{0} {1}", Model.Famer.FirstName, Model.Famer.LastName)
    ViewData("Title") = Html.TitleMaker(Html.Localize("HallOfFame.Create.URLTitle").ToString)
End Code
@Html.DateField("Famer_Achieved")

<h1>@Html.Localize("HallOfFame.Create.Title")</h1>
<div class="clearblank4"></div>
@Html.ValidationSummary()
@Using Html.BeginForm("Create", "HallOfFame", FormMethod.Post, New With {.enctype = "multipart/form-data"})
    @<table id="edithof" >
        <thead>
            <tr>
                <td>&nbsp;</td>
                <td></td>
            </tr>
        </thead>
        <tbody>
            <tr class="odd-line">
                <td>@Html.Localize("HallOfFame.Create.FirstName") :&nbsp;</td>
                <td>@Html.TextBoxFor(Function(f) f.Famer.FirstName, New With {.required="required"})</td>
            </tr>
            <tr class="even-line">
                <td>@Html.Localize("HallOfFame.Create.LastName") :&nbsp;</td>
                <td>@Html.TextBoxFor(Function(f) f.Famer.LastName, New With {.required="required"})</td>
            </tr>
            <tr class="odd-line">
                <td>@Html.Localize("HallOfFame.Create.RecognitionType") :&nbsp;</td>
                <td>@Html.DropDownListFor(Function(f) f.Famer.HallOfFame_RecognitionTypeId, New SelectList(Model.Types, "Id", "Description", Model.Famer.HallOfFame_RecognitionTypeId))</td>
            </tr>
            <tr class="even-line">
                <td>@Html.Localize("HallOfFame.Create.USBCID") :&nbsp;</td>
                <td>@Html.TextBoxFor(Function(f) f.Famer.USBC_ID)</td>
            </tr>
            <tr class="odd-line">
                <td>@Html.Localize("HallOfFame.Create.Deceased") :&nbsp;</td>
                <td>@Html.CheckBoxFor(Function(f) f.Famer.Deceased)</td>
            </tr>
            <tr class="even-line">
                <td>@Html.Localize("HallOfFame.Create.Display") :&nbsp;</td>
                <td>@Html.CheckBoxFor(Function(f) f.Famer.Display)</td>
            </tr>
            <tr class="odd-line">
                <td>@Html.Localize("HallOfFame.Create.Achieved") :&nbsp;</td>
                <td>@Html.TextBoxFor(Function(f) f.Famer.Achieved, New With {.required="required", .Value = Model.Famer.Achieved.ToString("MM/dd/yyyy")})</td>
            </tr>
            <tr class="even-line">
                <td>@Html.Localize("HallOfFame.Create.ProfileImage") :&nbsp;</td>
                <td>
                    @Html.TextBox("profileimage", "", New With {.type="file"})<br />
                    <i>Images will be scaled down to a height of 200px</i>
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
    @<h2 style="text-align:center">@Html.Localize("HallOfFame.Create.WriteUpTitle")</h2>
    @<div>
        @Html.HtmlEditor("htmleditor", Model.Famer.WriteUp)
    </div>
    @<div style="text-align:center;">
        @Html.HiddenFor(Function(f) f.Famer.Id)
        <div class="clearblank4"></div>
        <input type="submit" value="@Html.Localize("HallOfFame.Create.CreateSubmit")" class="submit-green" />&nbsp;&nbsp;
        <a href="@Url.Action("Manage")" class="linkbutton submit-red">@Html.Localize("HallOfFame.Create.CancelSubmit")</a>
     </div>
end using
