@modeltype Web.Models.HallOfFame.DeleteModel
@code
    Layout = Nothing
End Code
<td>
    @Using Html.BeginForm(Model.PostBackForm, "HallOfFame")
        @<div style="text-align:center;">
            @Html.Localize("HallOfFame.Delete.ConfirmText")<br />
            @Html.Hidden("id", Model.id)
            <input type="submit" value="@Html.Localize("HallOfFame.Delete.Delete.Yes")" class="submit-green" />
            &nbsp;&nbsp;    
            <a href="@(Url.Action(Model.CancelAction, "HallOfFame"))" class="linkbutton submit-red">@Html.Localize("HallOfFame.Delete.Delete.No")</a>
         </div>
    End Using
</td>