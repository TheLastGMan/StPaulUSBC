@ModelType Data.Entity.Award

@Code
    Layout = "~/Views/Shared/_Layout.vbhtml"
    
    Dim title As String = Html.Localize("Award.PrintAward.Title").ToHtmlString
    title = title.Replace("{Center}", Model.Center)
    title = title.Replace("{League}", Model.League)
    title = title.Replace("{BowlerName}", Model.BowlerName)
    title = title.Replace("{DateBowled}", Model.DateBowled.ToString("MMM-dd-yyyy"))
    title = title.Replace("{SecretaryName}", Model.SecretaryName)
End Code

@Html.AutoPrint()

<h1>
    @Html.Raw(title)
</h1>

@Html.Partial("_AwardSummary", Model)