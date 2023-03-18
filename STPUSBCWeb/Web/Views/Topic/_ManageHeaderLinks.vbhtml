@ModelType integer
@code
    Layout = Nothing
End Code

<table  style="width:300px; text-align:center;">
    <tr>
        <td style="height:30px;">
            <a href="@Url.Action("Manage", "Topic", New With {.seo = 1})" class="linkbutton submit-ltgold@(iif(Model = 1, "-selected",""))">
                @Html.Localize("Topic.ManageHeaderLinks.Widget")
            </a>
        </td>
        <td>
            <a href="@(Url.Action("Manage", "Topic", New With {.seo = 2}))" class="linkbutton submit-ltgold@(IIf(Model = 2, "-selected", ""))">
                @Html.Localize("Topic.ManageHeaderLinks.Topic")
            </a>
        </td>
        <td>
            <a href="@Url.Action("Manage", "Topic", New With {.seo = 3})" class="linkbutton submit-ltgold@(IIf(Model = 3, "-selected", ""))">
                @Html.Localize("Topic.ManageHeaderLinks.Page")
            </a>
        </td>
    </tr>
    <tr>
        <td colspan="3" style="height:30px;">
            <a href="@Url.Action("Create", "Topic")" class="linkbutton submit-gold">
                @Html.Localize("Topic.ManageHeaderLinks.CreateSubmit")
            </a>
        </td>
    </tr>
</table>
