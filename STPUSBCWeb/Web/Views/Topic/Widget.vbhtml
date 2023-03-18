@ModelType Web.Models.Topic.PageModel
@code
    Layout = Nothing
    ViewData("Title") = Html.TitleMaker("St. Paul USBC Association", "Page", Model.Title)
End Code
<p>
    @Html.Raw(Model.RawContent)
</p>