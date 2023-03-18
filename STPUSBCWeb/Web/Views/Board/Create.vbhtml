@ModelType Web.Models.Board.EditModel
@Code
    ViewData("Title") = Html.TitleMaker(Html.Localize("Board.Create.URLTitle").ToString)
End Code
@Html.DateField({"Member_TermStart", "Member_TermEnd"})

<h1>@Html.Localize("Board.Create.Title")</h1>
<div class="clearblank4"></div>
@Html.ValidationSummary()
<div class="clearblank4"></div>
@Using Html.BeginForm()
    @<table id="createboard">
        <thead>
            <tr>
                <td>&nbsp;</td>
                <td></td>
            </tr>
        </thead>
        <tbody>
            <tr class="odd-line">
                <td>@Html.Localize("Board.Create.FirstName") :&nbsp;</td>
                <td>@Html.TextBoxFor(Function(f) f.Member.FirstName, New With {.required = "required"})</td>
            </tr>
            <tr class="even-line">
                <td>@Html.Localize("Board.Create.LastName") :&nbsp;</td>
                <td>@Html.TextBoxFor(function(f) f.Member.LastName)</td>
            </tr>
            <tr class="odd-line">
                <td>@Html.Localize("Board.Create.Visible") :&nbsp;</td>
                <td>@Html.CheckBoxFor(Function(f) f.Member.Visible)</td>
            </tr>
        </tbody>
        <tfoot>
            <tr>
                <td colspan="2">
                    @Html.HiddenFor(Function(f) f.Member.Id)
                    <input type="submit" class="submit-green" value="@Html.Localize("Board.Create.Create")" />&nbsp;&nbsp;
                    <a href="@Url.Action("Manage")" class="linkbutton submit-red">@Html.Localize("Board.Create.Cancel")</a>
                </td>
            </tr>
        </tfoot>
    </table>
end using