@ModelType Web.Models.Board.BoardHistoryEditModel
@Code
    Layout = Nothing
End Code
@Html.DateField({"TermStart", "TermEnd"})

<div id="boardhistorycontainer">
    <table id="boardhistory">
        <thead>
            <tr>
                <td>@Html.Localize("Board.Edit.BoardPosition")</td>
                <td>@Html.Localize("Board.Edit.TermStart")</td>
                <td>@Html.Localize("Board.Edit.TermEnd")</td>
                <td>@Html.Localize("Board.Edit.UpdateDeleteTitle")</td>
            </tr>
        </thead>
        <tbody>
            @For i As Integer = 1 To Model.BoardHistoryList.Count
                Dim bh = Model.BoardHistoryList(i-1)
                @<tr class="@(iif(i mod 2, "odd", "even"))-line">
                        <td>@(Model.PositionLst.Where(Function(f) f.Id = bh.BoardPositionId).select(Function(f) f.Description).first)</td>
                        <td>@bh.TermStart.ToString("MM/dd/yyyy")</td>
                        <td>@bh.TermEnd.ToString("MM/dd/yyyy")</td>                   
                        <td>
                            @Using Ajax.BeginForm("DeleteHistory", "Board", New AjaxOptions With {
                                                                                                                            .Url = Url.Action("DeleteHistory"),
                                                                                                                            .UpdateTargetId = "boardhistorycontainer"})
                                @Html.Hidden("hid", bh.Id.ToString)
                                @Html.Hidden("bid", bh.BoardId)
                                @<input type="submit" class="submit-red" value="@Html.Localize("Board.BoardHistory.DeleteSubmit")" />                        
                            End Using
                        </td>
                    </tr>
            Next
                @Using Ajax.BeginForm("CreateHistory", "Board", New AjaxOptions With {
                                                                                                                .Url = Url.Action("CreateHistory"),
                                                                                                                .UpdateTargetId = "boardhistorycontainer"})
                @<tr class="submit-ltgold">
                    <td>@(Html.DropDownList("BoardPositionId", New SelectList(Model.PositionLst, "Id", "Description")))</td>
                    <td>@(Html.TextBox("TermStart", New date.ToString("MM/dd/yyyy")))</td>
                    <td>@(html.TextBox("TermEnd", New date.ToString("MM/dd/yyyy")))</td>
                    <td colspan="2">
                        @Html.Hidden("BoardId", Model.BoardId)
                        <input type="submit" class="submit-green" value="@Html.Localize("Board.BoardHistory.CreateSubmit")" />
                    </td>
                </tr>            
            End Using
        </tbody>
        <tfoot>
            <tr>
                <td colspan="4">&nbsp;</td>
            </tr>
        </tfoot>
    </table>
</div>