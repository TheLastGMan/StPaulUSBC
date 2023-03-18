@ModelType Web.Models.Common.LastUpdatedModel
@code
    Layout = nothing
End Code

<p class="last-updated">
    @If Model.LastUpdated.hasvalue Then
        @<span>@Html.Localize("Common.LastUpdated.Text") : @(Model.LastUpdated.Value.ToString(model.LastUpdatedFormat))</span>
    End If
</p>