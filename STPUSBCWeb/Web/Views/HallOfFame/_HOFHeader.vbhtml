@ModelType integer
@code
    Layout = Nothing
End Code

<table style="width:80%; text-align:center;">
    <tr>
        <td>
            <a href="@Url.Action("Manage")" class="linkbutton submit-gold@(IIf(Model = 1, "-selected", ""))">@Html.Localize("HallOfFame.HOFHeader.HallOfFame")</a>
        </td>
        <td>
            <a href="@Url.Action("ManageType")" class="linkbutton submit-gold@(IIf(Model = 2, "-selected", ""))">@Html.Localize("HallOfFame.HOFHeader.RecognitionType")</a>
        </td>
    </tr>
</table>