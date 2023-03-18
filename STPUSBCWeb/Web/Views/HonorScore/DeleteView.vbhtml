@ModelType Web.Models.HonorScore.DeleteModel
@code
    Layout = Nothing
End Code

<td id="@Model.id" style="text-align:center">
    @Using Html.BeginForm(Model.PostBackForm, "HonorScore")
        @<div>
            @Html.Localize("HonorScore.DeleteView.ConfirmText")<br />
            @Html.HiddenFor(Function(f) f.honorcategory)
            @Html.HiddenFor(Function(f) f.honortype)
            @Html.HiddenFor(Function(f) f.id)
            <input type="submit" class="submit-green" value="@Html.Localize("HonorScore.DeleteView.Delete.Yes")" />
            <div class="clearblank4"></div>
            <a href="@(Url.Action(Model.CancelAction, New With {.htid = Model.honortype, .hcid = Model.honorcategory}))" class="linkbutton submit-red">
                @Html.Localize("HonorScore.DeleteView.Delete.No")
            </a>
         </div>
    End Using
</td>