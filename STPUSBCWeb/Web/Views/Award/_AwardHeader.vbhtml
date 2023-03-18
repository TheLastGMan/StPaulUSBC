@modeltype web.Models.Award.AwardHeader
@code
    Layout=Nothing
End Code

<table style="width:90%; margin:auto; text-align:center;">
    <tr>
        <td style="width:25%;">
            <a href="@Url.Action("Manage")" class="linkbutton submit-gold@(iif(Model = Web.Models.Award.AwardHeader.Award, "-selected", ""))">
                @Html.Localize("Award.AwardHeader.Award")
            </a>
        </td>
        <td style="width:25%;">
            <a href="@Url.Action("AwardType")" class="linkbutton submit-gold@(IIf(Model = Web.Models.Award.AwardHeader.AwardType, "-selected", ""))">
                @Html.Localize("Award.AwardHeader.AwardType")
            </a>
        </td>
        <td style="width:25%;">
            <a href="@Url.Action("AwardOption")" class="linkbutton submit-gold@(IIf(Model = Web.Models.Award.AwardHeader.AwardOption, "-selected", ""))">
                @Html.Localize("Award.AwardHeader.AwardOption")
            </a>
        </td>
        <td>
            <a href="@Url.Action("AwardOptionType")" class="linkbutton submit-gold@(iif(Model = Web.Models.Award.AwardHeader.AwardOptionType, "-selected", ""))">
                @Html.Localize("Award.AwardHeader.AwardOptionType")
            </a>
        </td>
    </tr>
</table>