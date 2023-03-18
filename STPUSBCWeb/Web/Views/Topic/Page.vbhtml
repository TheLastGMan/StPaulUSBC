@ModelType Web.Models.Topic.PageModel
@code
     ViewData("Title") = Html.TitleMaker("Page", Model.Title.Replace("-"," "))
 End Code
<div class="Topic-Content">
    @Html.Raw(model.RawContent)
</div>
@Html.LastUpdated(Model.LastUpdated)