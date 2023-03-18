@ModelType Core.Services.Content.SearchResult
@Code
    Layout = Nothing
End Code

<h3>
    <a href="@Model.url.ToLower" target="_self">@Model.Title</a>
</h3>
@If Not String.IsNullOrEmpty(Model.Division) Then
    @<h4>
        (@Model.Division)
    </h4>    
End If
<div>
    @Html.Raw(Model.Description)
</div>