@ModelType Web.Models.Award.USBCAwards
@Code
    ViewData("Title") = Html.TitleMaker(Html.Localize("Award.Index.URLTitle").ToString)
End Code

@Html.Partial("_AwardProcess", New Web.Models.Award.Process With {.CurrentStep = Web.Models.Award.AwardStep.USBCAward, .AwardID = Model.AwardID})
<h2 class="align-center">@Html.Raw(Html.Localize("Award.Progress.USBCAwards").ToHtmlString)</h2>

@Using Html.BeginForm("USBCAwards", "Award", FormMethod.Post, New With {.class="award-form"})
    @Html.HiddenFor(Function(f) f.AwardId)

    For i As Integer = 1 To Model.USBCAwardLst.Count
        Dim index As Integer = i - 1
        @<div class="award-selection-container">
                <div class="award-selection-container-header">
                    @(Model.USBCAwardLst(index).Key)
                    @(Html.HiddenFor(Function(f) f.USBCAwardLst(index).Key))
                </div>
                <div class="award-selection-container-content">
                    @Html.CheckBoxFor(Function(f) f.USBCAwardLst(index).Value)
                    @Html.LabelFor(Function(f) f.USBCAwardLst(index).Key, " ")
                </div>
        </div>
    Next
    
    If Model.USBCAwardLst.Count = 0 Then
        @<div class="award-no-rewards">
            @Html.Localize("Award.Form.NoAwards")
         </div>
    End If

    @Html.Partial("_AwardFormFooter")
End Using
