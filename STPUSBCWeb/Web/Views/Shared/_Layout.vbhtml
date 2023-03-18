@code
    Layout = "~/Views/Shared/_LayoutBasic.vbhtml"
End Code

<div id="container">
    @Html.Partial("_Header")
    <div id="content">
        @RenderBody
    </div>
    @Html.Partial("_Footer")
    @Html.Action("GoogleAnalytics", "Widget")
</div>