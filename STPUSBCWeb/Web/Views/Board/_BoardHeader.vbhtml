@ModelType Integer
@Code
    Layout = Nothing
End Code

<table style="width:100%; text-align:center">
    <tr>
        <td>
            <a href="@Url.Action("Manage")" class="linkbutton submit-gold@(iif(Model = 1, "-selected", ""))">@Html.Localize("Board.BoardHeader.BoardMember")</a>
        </td>
        <td>
            <a href="@Url.Action("ManagePosition")" class="linkbutton submit-gold@(iif(Model = 2, "-selected", ""))">@Html.Localize("Board.BoardHeader.BoardPosition")</a>
        </td>
    </tr>
</table>