@ModelType String
@code
    Layout = nothing
End Code

@Using Html.BeginForm("DeleteConfirm", "Board")
    @<td>
        @Html.Localize("Board.Delete.ConfirmText")<br />
        <input type="submit" class="submit-green" value="@Html.Localize("Board.Delete.Yes")" />&nbsp;&nbsp;
        @Html.Hidden("id", Model)
        <a href="@Url.Action("Manage")" class="linkbutton submit-red">@Html.Localize("Board.Delete.No")</a>
     </td>
End Using