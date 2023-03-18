@ModelType Web.Models.Award.Process
@Code
    Layout = Nothing
    
    'small logic for display type [Previous | Current | Inactive]
    Const INA As String = "inactive"
    Const CUR As String = "current"
    Const PRV As String = "previous"
    
    Dim statuses As String() = {CUR, INA, INA, INA, INA}
    Select Case Model.CurrentStep
        Case Web.Models.Award.AwardStep.USBCAward
            statuses = {PRV, CUR, INA, INA, INA}
        Case Web.Models.Award.AwardStep.LocalAward
            statuses = {PRV, PRV, CUR, INA, INA}
        Case Web.Models.Award.AwardStep.Secretary
            statuses = {PRV, PRV, PRV, CUR, INA}
        Case Web.Models.Award.AwardStep.Complete
            statuses = {PRV, PRV, PRV, PRV, CUR}
    End Select
    
    Dim BI As string = statuses(0)
    Dim UA As String = statuses(1)
    Dim LA as String = statuses(2)
    Dim SI As String = statuses(3)
    Dim CO As String = statuses(4)
    
End Code

<div id="award-process">
    <div class="award-process-box award-process-status-@(BI)">
        <a href="@(Url.Action("BowlerInfo", New With {.id=Model.AwardID}))" style="color:#000;">
            @Html.Raw(Html.Localize("Award.Progress.BowlerInfo").ToHtmlString)
        </a>
    </div>
    <div class="award-process-box award-process-status-@(UA)">
        @If UA = "previous" Then
            @<a href="@Url.Action("USBCAwards", New With {.id = Model.AwardID})">
                @Html.Raw(Html.Localize("Award.Progress.USBCAwards").ToHtmlString)
             </a>
        Else
            @Html.Raw(Html.Localize("Award.Progress.USBCAwards").ToHtmlString)
        End If
    </div>
    <div class="award-process-box award-process-status-@(LA)">
        @If LA = "previous" Then
            @<a href="@Url.Action("LocalAwards", New With {.id=Model.AwardID})">
                @Html.Raw(Html.Localize("Award.Progress.LocalAwards").ToHtmlString)
             </a>
        Else
            @Html.Raw(Html.Localize("Award.Progress.LocalAwards").ToHtmlString)
        End If
    </div>
    <div class="award-process-box award-process-status-@(SI)">
        @If SI = "previous" Then
            @<a href="@Url.Action("SecretaryInfo", New With {.id=Model.AwardID})">
                 @Html.Raw(Html.Localize("Award.Progress.SecretaryInfo").ToHtmlString)
             </a>
        Else
            @Html.Raw(Html.Localize("Award.Progress.SecretaryInfo").ToHtmlString)
        End If
    </div>
    <div class="award-process-box award-process-status-@(CO)">
            @Html.Raw(Html.Localize("Award.Progress.FormComplete").ToHtmlString)
    </div>
</div>