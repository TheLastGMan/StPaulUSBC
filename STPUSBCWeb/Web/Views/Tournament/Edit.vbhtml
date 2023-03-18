@ModelType web.Models.Tournament.EditModel
@Code
    ViewData("Title") = Html.TitleMaker(Html.Localize("Tournament.Edit.URLTitle").ToString, Model.Tourny.EventName)
End Code

@Html.DateField({"Tourny_Start_Date", "Tourny_End_Date", "Tourny_RegistrationClose"})                                          

<h1>Edit Tournament</h1>
<h2 style="text-align:center; margin:0;">(@(model.Tourny.EventName))</h2>
<div style="line-height:0.5em;">&nbsp;</div>
    @Html.ValidationSummary()
<div style="line-height:0.5em;">&nbsp;</div>
@Using Html.BeginForm()
    @Html.HiddenFor(Function(f) f.Tourny.Id)

    Dim sd5 As String = Model.Tourny.Start_Date.ToString("yyyy-MM-dd")
    Dim ed5 As String = ""
    Dim rd5 As String = ""
    If Model.Tourny.End_Date.HasValue Then
        ed5 = Model.Tourny.End_Date.Value.ToString("yyyy-MM-dd")
    End If
    If Model.Tourny.RegistrationClose.HasValue Then
        rd5 = Model.Tourny.RegistrationClose.Value.ToString("yyyy-MM-dd")
    End If
    
    @<table id="EditTournament"  >
        <thead>
            <tr>
                <td>&nbsp;</td>
                <td></td>
            </tr>
        </thead>
        <tbody>
            <tr class="odd-line">
                <td>@Html.Localize("Tournament.Edit.EventName") :&nbsp;</td>
                <td>@Html.TextBoxFor(Function(f) f.Tourny.EventName, New With {.required = "required"})</td>
            </tr>
            <tr class="even-line">
                <td>@Html.Localize("Tournament.Edit.EventUrl") :&nbsp;</td>
                <td>@Html.TextBoxFor(Function(f) f.Tourny.EventUrl)</td>
            </tr>
            <tr class="odd-line">
                <td>@Html.Localize("Tournament.Edit.TournamentClassification") :&nbsp;</td>
                <td>@Html.DropDownListFor(Function(f) f.Tourny.Tournament_ClassificationId, New SelectList(Model.TournClassification, "Id", "Description"), New With {.style="width:175px;padding:3px 0;"})</td>
            </tr>
            <tr class="even-line">
                <td>@Html.Localize("Tournament.Edit.Center") :&nbsp;</td>
                <td>@Html.TextBoxFor(Function(f) f.Tourny.Center)</td>
            </tr>
            <tr class="odd-line">
                <td>@Html.Localize("Tournament.Edit.Contact") :&nbsp;</td>
                <td>@Html.TextBoxFor(Function(f) f.Tourny.Contact)</td>
            </tr>
            <tr class="even-line">
                <td>@Html.Localize("Tournament.Edit.ContactEmail") :&nbsp;</td>
                <td>@Html.TextBoxFor(Function(f) f.Tourny.ContactEmail, New With {.type = "email", .placeholder = "theiremail@exmaple.com"})</td>
            </tr>
            <tr class="odd-line">
                <td>@Html.Localize("Tournament.Edit.StartDate") :&nbsp;</td>
                <td>@Html.TextBoxFor(Function(f) f.Tourny.Start_Date, New With {.type = "date", .placeholder = "yyyy-mm-dd", .required = "required", .Value = sd5})</td>
            </tr>
            <tr class="even-line">
                <td>@Html.Localize("Tournament.Edit.EndDate") :&nbsp;</td>
                <td>@Html.TextBoxFor(Function(f) f.Tourny.End_Date, New With {.type = "date", .placeholder = "yyyy-mm-dd", .Value = ed5})</td>
            </tr>
            <tr class="odd-line">
                <td>@Html.Localize("Tournament.Edit.RegistrationClose") :&nbsp;</td>
                <td>@Html.TextBoxFor(Function(f) f.Tourny.RegistrationClose, New With {.type = "date", .placeholder = "yyyy-mm-dd", .Value = rd5})</td>
            </tr>
        </tbody>
        <tfoot>
            <tr>
                <td colspan="2">
                    <input type="submit" class="submit-green" value="@Html.Localize("Tournament.Edit.EditSubmit")" />&nbsp;&nbsp;
                    <a href="@(Url.Action("Manage"))" class="linkbutton submit-red">@Html.Localize("Tournament.Edit.Cancel")</a>
                </td>
            </tr>
        </tfoot>
    </table>
End Using
