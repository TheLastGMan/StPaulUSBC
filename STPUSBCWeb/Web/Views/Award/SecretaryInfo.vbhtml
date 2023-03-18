@ModelType Web.Models.Award.SecretaryInfo
@Code
    ViewData("Title") = Html.TitleMaker(Html.Localize("Award.Index.URLTitle").ToString)
End Code

@Html.Partial("_AwardProcess", New Web.Models.Award.Process With {.CurrentStep = Web.Models.Award.AwardStep.Secretary, .AwardID = Model.AwardID})
<h2 class="align-center">@Html.Raw(Html.Localize("Award.Progress.SecretaryInfo").ToHtmlString)</h2>

@Using Html.BeginForm("SecretaryInfo", "Award", FormMethod.Post, New With {.class = "award-form"})
    @Html.AntiForgeryToken()
    @Html.HiddenFor(Function(f) f.AwardId)
    @<div class="award">
        <div class="longbox">
            <h3>@Html.Localize("Award.Index.SecretaryName")</h3>
            @Html.TextBoxFor(Function(f) f.SecretaryName, New With {.required="required", .placeholder=Html.Localize("Award.AwardForm.SecretaryName.Placeholder")})
            <br/>@Html.ValidationMessageFor(Function(f) f.SecretaryName)
        </div>
        <div class="longbox">
            <h3>@Html.Localize("Award.Index.SecretaryEmail")</h3>
            @Html.TextBoxFor(Function(f) f.SecretaryEmail, New With {.placeholder=Html.Localize("Award.AwardForm.SecretaryEmail.Placeholder")})
            <br/>@Html.ValidationMessageFor(Function(f) f.SecretaryEmail)
        </div>
        <div class="shortbox">
            <h3>@Html.Localize("Award.Index.SecretaryPin")</h3>
            @Html.TextBoxFor(Function(f) f.SecretaryPin, New With {.required="required", .placeholder=Html.Localize("Award.AwardForm.SecretaryPin.Placeholder")})
            <br/>@Html.ValidationMessageFor(Function(f) f.SecretaryPin)
        </div>
        <div class="shortbox">
            <h3>@Html.Localize("Award.Index.SecretaryPhone")</h3>
            @Html.TextBoxFor(Function(f) f.SecretaryPhone, New With {.placeholder = Html.Localize("Award.AwardForm.SecretaryPhone.Placeholder")})
            <br/>@Html.ValidationMessageFor(Function(f) f.SecretaryPhone)
        </div>
    </div>
    @Html.Partial("_AwardFormFooter")
End Using
