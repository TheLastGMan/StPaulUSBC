@modeltype Web.Models.HonorScore.ManageHeaderModel
@code
    Layout = Nothing    
End Code

<table style="width:75%; text-align:center;">
    <tr>
        <td>
            <a href="@Url.Action("Manage")" class="linkbutton submit-gold@(IIf(Model.ViewId = Web.Models.HonorScore.ManageViewType.Scores,"-selected",""))">
                @Html.Localize("HonorScore.ManageHeader.Score")
            </a>
        </td>
        <td>
            <a href="@Url.Action("ManageCategory")" class="linkbutton submit-gold@(IIf(Model.ViewId = Web.Models.HonorScore.ManageViewType.Category, "-selected", ""))">
                @Html.Localize("HonorScore.ManageHeader.Category")
            </a>
        </td>
        <td>
            <a href="@Url.Action("ManageType")" class="linkbutton submit-gold@(IIf(Model.ViewId = Web.Models.HonorScore.ManageViewType.HonorType,"-selected",""))">
                @Html.Localize("HonorScore.ManageHeader.Type")
            </a>
        </td>
    </tr>
</table>
