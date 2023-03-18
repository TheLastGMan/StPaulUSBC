@ModelType Web.Models.Common.EditorModel
@code
    Layout = nothing
End Code

<script src="@Url.Content("~/Editor/ckeditor.js")"></script>
<script src="@Url.Content("~/Editor/ckfinder/ckfinder.js")"></script>
<textarea id="@(model.Id)" name="@(model.Id)">
    @Html.Raw(Model.Html)
</textarea>
<script>
    var editor = CKEDITOR.replace('@(model.Id)');
    CKFinder.setupCKEditor(editor, '@(url.Content("~/Editor/ckfinder/"))');
</script>