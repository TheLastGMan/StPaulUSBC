@ModelType Web.Models.HonorScore.ChooseScoreModel
@code
    Layout = Nothing
End Code

<div class="honorscoreheadercontainer">
    <div style="float:left; width:100%;">
        <h2>@Html.Localize("HonorScore.ScoreHeader.HonorType")</h2>
    </div>
    <div class="floatbox">
        <a href="@Url.Action("Manage", New With {.htid = 0, .hcid = Model.HonorCategoryId})" class="linkbutton submit-ltgold@(IIf(Model.HonorTypeId = 0, "-selected", ""))">
            @Html.Localize("HonorScore.ScoreHeader.AllSubmit")
        </a>
    </div>
    @For Each itm In Model.HonorTypes
        @<div class="floatbox">
            <a href="@(Url.Action("Manage", New With {.htid = itm.Id, .hcid = Model.HonorCategoryId}))" class="linkbutton submit-ltgold@(iif(Model.HonorTypeId = itm.Id, "-selected", ""))">
                @(itm.Description)
            </a>
        </div>
    Next
</div>
<div class="honorscoreheadercontainer">
    <div style="float:left; width:100%;">
        <h2>@Html.Localize("HonorScore.ScoreHeader.HonorCategory")</h2>
    </div>
    <div class="floatbox">
        <a href="@Url.Action("Manage", New With {.htid = Model.HonorTypeId, .hcid = 0})" class="linkbutton submit-ltgold@(IIf(Model.HonorCategoryId = 0, "-selected", ""))">
            @Html.Localize("HonorScore.ScoreHeader.AllSubmit")
        </a>
    </div>
    @For Each itm In Model.HonorCategorys
        @<div class="floatbox">
            <a href="@Url.Action("Manage", New With {.htid = Model.HonorTypeId, .hcid = itm.Id})" class="linkbutton submit-ltgold@(IIf(Model.HonorCategoryId = itm.Id, "-selected", ""))">
                @(itm.Description)
            </a>
        </div>
    Next
</div>
