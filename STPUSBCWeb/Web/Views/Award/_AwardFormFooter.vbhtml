@code
    Layout = nothing
End Code

<div class="fullbox no-clear">&nbsp;</div>
<div class="fullbox no-clear">
    <input type="submit" name="save" class="submit-green" value="@Html.Localize("Award.Index.SaveSubmit")" />&nbsp;&nbsp;
    <a href="@Url.Action("Index")" class="linkbutton submit-red">@Html.Localize("Award.Index.ResetSubmit")</a>
</div>