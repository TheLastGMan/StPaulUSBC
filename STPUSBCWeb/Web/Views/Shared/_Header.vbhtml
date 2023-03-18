@code
    Layout = Nothing
End Code

<div id="header">
    <table style="height:100%; margin:auto;">
        <tr>
            <td>
                <a href="@Url.Action("", "Home")"><img style="height:100px; margin-right:25px; margin-left:5px;" src="@Url.Content("~/content/images/usbc_assoclogo.png")" alt="Association Logo" /></a>
            </td>
            <td class="title-text">
                @Html.Localize("Shared.Header.Line1")
                <span style="color:red;"><br /><i>@Html.Localize("Shared.Header.Line2")</i></span>
            </td>
            <td class="hidemobile">
                <a href="http://www.bowl.com"><img style="height:100px; margin-left:15px; margin-right:5px;" src="@Url.Content("~/content/images/usbc_logo.jpg")" alt="Logo" /></a>
            </td>
        </tr>
    </table>
    <div id="navheader">
        @Html.Action("SearchBar", "Search")
        @Html.Action("ShareLinks", "Widget")
    </div>
    @Html.Action("BreadCrumb", "Common", New With {.title = ViewData("Title")})
</div>