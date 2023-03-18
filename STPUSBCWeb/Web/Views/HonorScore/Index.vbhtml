@modelType Web.Models.HonorScore.Index
@Code
    ViewData("Title") = Html.TitleMaker(Html.Localize("HonorScore.Index.URLTitle").ToString)
    Dim i As Integer = 0
End Code

<div class="honorscoreheadercontainer">
    <h1>@Html.Localize("HonorScore.Index.Title")</h1>
    @Html.Widget("honorscore_index")
</div>
@For Each ht In Model.HonorTypes.Where(Function(f) f.Active)
    @<div class="honorscoreheadercontainer">
        <div style="float:left; width:100%;">
            <h2>@(ht.Description)</h2>
        </div>
        @For Each hc In Model.HonorCategories.Where(Function(f) f.Active).OrderByDescending(Function(f) f.Description)
            If hc.Honor.Where(Function(f) f.HonorTypeId = ht.Id).Count > 0 Then
                @<div class="floatbox">
                    @(Html.ActionLink(hc.Description, "Scores", New With {.catseo = hc.SEO.ToLower, .typeseo = ht.SEO.ToLower}, New With {.class = "linkbutton submit-ltgold"}))     
                </div>
            End If
        Next
    </div>
Next

<div class="honorscoreheadercontainer">
    @Html.LastUpdated(Model.LastUpdated)
</div>
