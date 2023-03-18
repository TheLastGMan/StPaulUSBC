@ModelType Web.Models.Common.ExtLinkModel
@Code
    Layout = Nothing
End Code

@If Model.Links.Count > 0 Then
    @<div class="clearblank">
    </div>
    @<div id="extlink">
        <div class="pill-top">
            @Html.Localize("Common.ExtLink.Title")
        </div>
        <div class="pill-bottom">
            <nav>
                <ul class="ulink">
                    @For Each li In Model.Links
                        @<li><a href="@(li.Url)" target="_blank">@(li.Name)</a></li>
                    Next
                </ul>
            </nav>
        </div>
    </div>
End If
