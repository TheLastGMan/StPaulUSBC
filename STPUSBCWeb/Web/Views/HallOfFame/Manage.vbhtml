@modeltype web.Models.HallOfFame.ManageModel
@Code
    ViewData("Title") = Html.TitleMaker(Html.Localize("HallOfFame.Manage.URLTitle").ToString)
End Code

@Html.Partial("_HOFHeader", 1)
<div class="clearblank4"></div>
<h1>Manage Hall Of Fame</h1>
<div class="clearblank4"></div>
<div style="text-align:center;">
    <a href="@Url.Action("Create")" class="linkbutton submit-gold">@Html.Localize("HallOfFame.Manage.CreateSubmit")</a>
</div>
<div class="clearblank4"></div>
<table id="halloffame" >
    <thead>
        <tr>
            <td>@Html.Localize("HallOfFame.Manage.NameTitle")</td>
            <td class="hidemobile">@Html.Localize("HallOfFame.Manage.DeceasedTitle")</td>
            <td class="hidemobile">@Html.Localize("HallOfFame.Manage.AchievedTitle")</td>
            <td>@Html.Localize("HallOfFame.Manage.RecognitionTitle")</td>
            <td>@Html.Localize("HallOfFame.Manage.VisibleTitle")</td>
            <td>@Html.Localize("HallOfFame.Manage.EditTitle")</td>
            <td>@Html.Localize("HallOfFame.Manage.DeleteTitle")</td>
        </tr>
    </thead>
    <tbody>
        @For i As Integer = 1 To Model.Famers.Count
            Dim t = Model.Famers(i - 1)
            @<tr class="@(iif(i mod 2, "odd", "even"))-line">
                <td>@(t.FirstName) @(t.LastName)</td>
                <td class="hidemobile">@(iif(t.Deceased, "Y", "N"))</td>
                <td class="hidemobile">@(t.Achieved.ToString("MMM-dd-yyyy"))</td>
                <td>@(t.HallOfFame_RecognitionType.Description)</td>
                <td>
                     @Using Html.BeginForm("Activate", "HallOfFame")
                        @Html.Hidden("id", t.Id)
                        @Html.Hidden("status", IIf(t.Display, False, True))
                        @<input type="submit" class="submit-@(IIf(t.Display, "ltgold", "gold"))" value="@(IIf(t.Display, Html.Localize("HallOfFame.Manage.Visible.Yes"), Html.Localize("HallOfFame.Manage.Visible.No")))" />
                     End Using
                </td>
                <td>
                    <a href="@Url.Action("Edit", New With {.id = t.Id})" class="linkbutton submit-green">@Html.Localize("HallOfFame.Manage.EditSubmit")</a>
                </td>
                <td id="@(t.RowGuid.ToString)">
                    @Using Ajax.BeginForm("Delete", "HallOfFame", New AjaxOptions With {
                                                                        .UpdateTargetId = t.RowGuid.ToString,
                                                                        .Url = Url.Action("Delete", "HallOfFame")})
                        @Html.Hidden("id", t.Id)
                        @<input type="submit" value="@Html.Localize("HallOfFame.Manage.DeleteSubmit")" class="submit-red" />
                    End Using
                </td>
            </tr>
        Next
    </tbody>
    <tfoot>
        <tr>
            <td colspan="7">&nbsp;</td>
        </tr>
    </tfoot>
</table>
