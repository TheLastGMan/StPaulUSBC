@Code
    Layout = nothing
End Code

<div id="searchform">
    @Using Html.BeginForm("SearchPost", "Search")
        @Html.TextBox("q", "", New With {.type="search", .required="required", .placeholder=Html.Localize("Search.SearchBar.SearchPlaceholder")})
        @<span style="width:15px;">&nbsp;</span>
        @<input id="searchsubmit" type="submit" class="submit-ltgold" value="@Html.Localize("Search.SearchBar.SearchSubmit")" />
    End Using
</div>