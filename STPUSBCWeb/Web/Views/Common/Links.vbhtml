@modeltype Web.Models.Common.LinkModel
@code
    Layout = nothing
End Code

@If Model.Links.Count > 0 Then
    @<div id="navigation">
        <div class="pill-top">
            @Html.Localize("Common.Links.Title")
        </div>
        <div class="pill-bottom">
            <nav>
                <ul class="ulink">
                    @For Each link In Model.Links
                        @<li @(IIf(model.Controller.ToLower = link.Controller.ToLower, "class=selected", ""))>@(Html.ActionLink(link.DisplayText, link.View, link.Controller))</li>
                    Next
                </ul>
            </nav>
        </div>
     </div>
End If

