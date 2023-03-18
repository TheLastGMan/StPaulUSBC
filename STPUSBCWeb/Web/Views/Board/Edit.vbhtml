@ModelType Web.Models.Board.EditModel

@Code
    ViewData("Title") = Html.TitleMaker(Html.Localize("Board.Edit.URLTitle").ToString)
End Code

<h1>@Html.Localize("Board.Edit.Title")</h1>
<div class="clearblank4"></div>
@Html.ValidationSummary()
<div class="clearblank4"></div>

<div id="tabs-1">
@Using Html.BeginForm()
    @<table id="editboard">
        <thead>
            <tr>
                <td>&nbsp;</td>
                <td></td>
            </tr>
        </thead>
        <tbody>
            <tr class="odd-line">
                <td>@Html.Localize("Board.Edit.FirstName") :&nbsp;</td>
                <td>@Html.TextBoxFor(Function(f) f.Member.FirstName, New With {.required = "required"})</td>
            </tr>
            <tr class="even-line">
                <td>@Html.Localize("Board.Edit.LastName") :&nbsp;</td>
                <td>@Html.TextBoxFor(function(f) f.Member.LastName)</td>
            </tr>
            <tr class="even-line">
                <td>@Html.Localize("Board.Edit.Visible") :&nbsp;</td>
                <td>@Html.CheckBoxFor(Function(f) f.Member.Visible)</td>
            </tr>
        </tbody>
        <tfoot>
            <tr>
                <td colspan="2">
                    @Html.HiddenFor(Function(f) f.Member.Id)
                    <input type="submit" class="submit-green" value="@Html.Localize("Board.Edit.Edit")" />
                </td>
            </tr>
        </tfoot>
    </table>
End Using
</div>
<div style="text-align:center;">
    <a href="@Url.Action("Manage")" class="linkbutton submit-red">@Html.Localize("Board.Edit.Cancel")</a>
</div>
<div id="tabs-2">
    @Html.Partial("BoardHistory", New Web.Models.Board.BoardHistoryEditModel With {.BoardHistoryList = Model.MemberHistory.OrderBy(Function(f) f.TermEnd).ToList, .PositionLst = Model.Positions, .BoardId = Model.Member.Id})
</div>