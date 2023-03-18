@ModelType Dictionary(of string, string)
@code
    Layout = Nothing
End Code
<div class="breadcrumb">
    @For Each bc In Model
        @<a href="@(bc.Value)">@(bc.Key)</a>
    Next
</div>