@ModelType Web.Models.Award.LocalAwards
@Code
    ViewData("Title") = Html.TitleMaker(Html.Localize("Award.Index.URLTitle").ToString)
End Code

<script>
    $(function () {
        //show or hide award-no-rewards based on a selection
    });
</script>

@Html.Partial("_AwardProcess", New Web.Models.Award.Process With {.CurrentStep = Web.Models.Award.AwardStep.LocalAward, .AwardID = Model.AwardID})
<h2 class="align-center">@Html.Raw(Html.Localize("Award.Progress.LocalAwards").ToHtmlString)</h2>

@Using Html.BeginForm("LocalAwards", "Award", FormMethod.Post, New With {.class="award-form"})
    @Html.HiddenFor(Function(f) f.AwardId)
    For i As Integer = 1 To Model.LocalAwardLst.Count
        Dim index As Integer = i - 1
        @<div class="award-selection-container">
                <div class="award-selection-container-header">
                    @(Model.LocalAwardLst(index).Key)
                    @(Html.HiddenFor(Function(f) f.LocalAwardLst(index).Key))
                </div>
                <div class="award-selection-container-content">
                    @Html.CheckBoxFor(Function(f) f.LocalAwardLst(index).Value)
                    @Html.LabelFor(Function(f) f.LocalAwardLst(index).Key, " ")
                </div>
        </div>
    Next

    If Model.LocalAwardLst.Count = 0 Then
        @<div class="fullbox no-clear">&nbsp;</div>
        @<div class="award-no-rewards">
            @Html.Localize("Award.Form.NoAwards")
         </div>
    End If

    If (Model.AwardTypeId = 1) Then
        @<div class="fullbox no-clear">&nbsp;</div>
        @<div class="fullbox no-clear" id="local-award-choice">
                <h3 class="align-center">@Html.Localize("Award.Form.AdultChoice")</h3>
                @(Html.DropDownListFor(Function(f) f.AwardChoiceId, New SelectList(Model.AwardChoiceLst, "Id", "Name", Model.AwardChoiceId)))
        </div>
    End If

    @Html.Partial("_AwardFormFooter")
End Using
