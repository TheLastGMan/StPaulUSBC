@modeltype Data.Entity.Award

@Html.Partial("_AwardProcess", New Web.Models.Award.Process With {.CurrentStep = Web.Models.Award.AwardStep.Complete, .AwardID = Model.Id})
<h2 class="align-center">@Html.Raw(Html.Localize("Award.Progress.FormComplete").ToHtmlString)</h2>
@Html.Widget("award_awardformsuccess")

<div style="text-align:center;">
    <a href="@(Url.Action("PrintAward", New With {.id = model.Id.tostring}))" class="linkbutton submit-green" onclick="window.open(this.href,'PrintAward','width=760,height=700,resizable=yes,scrollbars=yes,status=no,toolbar=no,location=no'); return false;">
        @Html.Localize("Award.AwardSummary.Print")
    </a>
</div>

@Html.Partial("_AwardSummary", Model)