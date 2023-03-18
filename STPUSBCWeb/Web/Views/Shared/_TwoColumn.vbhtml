@Code
    Layout = "~/Views/Shared/_Layout.vbhtml"
    'check for different SEO name
    Dim seo_navigation As String = Url.RequestContext.RouteData.Values("controller").ToString()
End code

<script type="text/javascript">
    $(function () {
        var visible = $("#MobileNav").css("visibility");
        if (visible == "visible")
            $("#LeftColumn").hide();

        $("#MobileNav").click(function () {
            $("#LeftColumn").toggle("slide");
        });
    });
</script>
<div id="MobileNav">
    <div style="height:2.5px;">&nbsp;</div>
    <div style="height:5px; background-color:#777; width:75%; margin:auto;">&nbsp;</div>
    <div style="height:5px;">&nbsp;</div>
    <div style="height:5px; background-color:#777; width:75%; margin:auto;">&nbsp;</div>
    <div style="height:5px;">&nbsp;</div>
    <div style="height:5px; background-color:#777; width:75%; margin:auto;">&nbsp;</div>
    <div style="height:2.5px;">&nbsp;</div>
</div>
<div id="LeftColumn" style="z-index:998;">
    @Html.Action("Links", "Common", New With {.seo = seo_navigation})
    @Html.Action("ExtLink", "Common")
    @Html.Action("Links", "Topic", New With {.seo = seo_navigation})
    @Html.Action("AdminLinks", "Common", New With {.seo = seo_navigation})
    @If IsSectionDefined("AdminPart") Then
        @<div class="clearblank">
        </div>
        @RenderSection("AdminPart")
    End If
    <div class="clearblank">
    </div>
</div>
<div id="CenterColumn">
    @RenderBody()
</div>
