@code
    Layout = Nothing
End Code

@If User.Identity.IsAuthenticated Then
    @<div class="clearblank"></div>
    @<div id="adminlinks">
        <div class="pill-top">
            @Html.Localize("Common.AdminLinks.Title")
        </div>
        <div class="pill-bottom">
            <nav>
                <ul class="ulink">
                    @If User.IsInRole("LinkEditor") Then
                        @<li>@Html.ActionLink("Navigation", "navigation", "Managelink")</li>
                        @<li>@Html.ActionLink("Links", "links", "Managelink")</li>
                    End If
                    @If User.IsInRole("EmailProfile") Then
                        @<li>@Html.ActionLink("E-Mail Profiles", "Manage", "EmailProfile")</li>
                    End If
                    @If User.IsInRole("ContentEditor") Then
                        @<li>@Html.ActionLink("Content", "manage", "Topic")</li>
                        @<li>
                            <a href="@Url.Content("~/Editor/ckfinder/ckfinder.html")" onclick="window.open(this.href, 'FileManager', 'resizable=yes,status=no,location=no,toolbar=no,menubar=no,fullscreen=no,scrollbars=no,dependent=no,width=640,height=480'); return false;">File Manager</a>
                        </li>
                    End If
                </ul>
                <div style="height:1px; background-color:#000; margin:3px 0;">&nbsp;</div>
                <ul class="ulink">
                    @If User.IsInRole("Tournament") Then @<li>@Html.ActionLink("Tournaments", "manage", "Tournament")</li> End If
                    @If User.IsInRole("Honor") Then @<li>@Html.ActionLink("Honor Scores", "manage", "HonorScore")</li> End If
                    @If User.IsInRole("HallOFame") Then @<li>@Html.ActionLink("Hall of Fame", "manage", "HallOfFame")</li> end If
                    @If User.IsInRole("Board") Then @<li>@Html.ActionLink("Board of Directors", "manage", "Board")</li> end If
                    @If User.IsInRole("Award") Then @<li>@Html.ActionLink("Awards", "manage", "Award")</li> end If
                    @If User.IsInRole("Localizer") Then @<li>@Html.ActionLink("Localization", "manage", "Localization")</li> end If
                    @if User.IsInRole("ScoreLoader") Then @<li>@Html.ActionLink("Season Averages", "manage", "SeasonAverage")</li>end If
                </ul>
                <div style="height:1px; background-color:#000; margin:3px 0;">&nbsp;</div>
                <ul class="ulink">
                    @If User.IsInRole("UserAdmin") Then
                        @<li>@Html.ActionLink("Manage Users", "Manage", "Account")</li>
                    End If
                    <li>@Html.ActionLink("Profile", "profile", "Account")</li>
                    <li>@Html.ActionLink("Log Out", "logout", "Account")</li>
                </ul>
            </nav>
        </div>
    </div>
End If

