@Modeltype web.Models.Board.ManageModel
@code
    ViewData("Title") = Html.TitleMaker(Html.Localize("Board.Manage.URLTitle").ToString)
End Code

@Html.Partial("_BoardHeader", 1)
<div class="clearblank4"></div>
<h1>@Html.Localize("Board.Manage.Title")</h1>
<div class="clearblank4"></div>
<div style="text-align:center;">
    <a href="@Url.Action("Create")" class="linkbutton submit-gold">@Html.Localize("Board.Manage.CreateSubmit")</a>
</div>
<div class="clearblank4"></div>
<table id="manageboard">
    <thead>
        <tr>
            <td>@Html.Localize("Board.Manage.NameTitle")</td>
            <td>@Html.Localize("Board.Manage.BoardPositionTitle")</td>
            <td class="hidemobile">@Html.Localize("Board.Manage.AddedTitle")</td>
            <td>@Html.Localize("Board.Manage.EditTitle")</td>
            <td>@Html.Localize("Board.Manage.UpdateTitle")</td>
            <td>@Html.Localize("Board.Manage.DeleteTitle")</td>
        </tr>
    </thead>
    <tbody>
        @For i As Integer = 1 To Model.Members.Count
            Dim m = Model.Members(i - 1)
            Dim lp = m.BoardHistory.OrderByDescending(function(f) f.TermEnd).FirstOrDefault
            @<tr class="@(iif(i mod 2, "odd", "even"))-line">
                <td>@m.FirstName @m.LastName</td>
                <td>
                    @If lp IsNot Nothing Then
                        @<span>
                            @lp.BoardPosition.Description <br />
                            @lp.TermStart.Year-@lp.TermEnd.Year
                         </span>
                    End If
                </td>
                <td class="hidemobile">@m.AddedUtc.ToString("MMM-dd-yyyy")</td>
                <td>
                    @Using Html.BeginForm("ShowChange", "Board")
                        @Html.Hidden("id", m.Id.ToString)
                        @Html.Hidden("visible", Not m.Visible)
                        @<input type="submit" class="submit-@(iif(m.Visible, "lt", ""))gold" value="@(IIf(m.Visible, Html.Localize("Board.Manage.Visible.True"), Html.Localize("Board.Manage.Visible.False")))" />
                    End Using
                </td>
                <td>
                    <a href="@Url.Action("Edit", New With {.id = m.Id.ToString})" class="linkbutton submit-green">@Html.Localize("Board.Manage.EditSubmit")</a>
                </td>
                <td id="@(m.Id.ToString)">
                    @Using Ajax.BeginForm("Delete", "Board", New AjaxOptions With {
                                                                    .Url=Url.Action("Delete", "Board"),
                                                                    .UpdateTargetId=m.Id.ToString})
                        @Html.Hidden("id", m.Id.ToString)
                        @<input type="submit" class="submit-red" value="@Html.Localize("Board.Manage.DeleteSubmit")" />
                    End Using
                </td>
             </tr>
        Next
    </tbody>
    <tfoot>
        <tr>
            <td colspan="8">&nbsp;</td>
        </tr>
    </tfoot>
</table>
@Html.LastUpdated(Model.LastUpdated)