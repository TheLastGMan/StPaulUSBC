@modelType Web.Models.Topic.DeleteModel
@code
    Layout = Nothing
End Code
<td colspan="3">
    <div style="width:33%; float:left;">
        @Html.Localize("Topic.Delete.ConfirmText")
    </div>
</td>
<td>
    <div style="width:33%; float:left;">
        @Using Html.BeginForm("DeleteYes", "Topic")
            @Html.HiddenFor(Function(f) f.seo)
            @Html.HiddenFor(Function(f) f.seodisplay)
            @<input type="submit" value="@Html.Localize("Topic.Delete.Delete.Yes")" class="submit-green" />
        End Using
    </div>
</td>
<td>
    <div style="width:33%; float:left;">
        <form action="@Url.Action("Manage", "Topic")">
            <input type="submit" value="@Html.Localize("Topic.Delete.Delete.No")" class="submit-red" />
        </form>
    </div>
</td>