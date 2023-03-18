@ModelType Web.Models.HallOfFame.ProfileModel
@code
    ViewData("Title") = Html.TitleMaker("Hall Of Fame Profile", String.Format("{0} {1}", Model.Profile.FirstName, Model.Profile.LastName))
End Code

@If Model.Profile Is Nothing Then
    @<h2 style="text-align:center;">@Html.Localize("HallOfFame.Profile.NotFound")</h2>
Else
    With Model.Profile
        @<div id="profile" style="text-align:center;">
            <div>
                <img src="@Model.ImageData.URL" alt="Profile Picture" />
            </div>
            <h2>@(.FirstName) @(.LastName)
                @If .Deceased Then
                    @<br />
                    @<span class="deceased">@Html.Localize("HallOfFame.Profile.Deceased")</span>
                End If
            </h2>
            <h3>
                @(.HallOfFame_RecognitionType.Description)<br />
                @(.Achieved.ToString(Model.AchievedFormat))
            </h3>
        </div>
        @<div style="padding:5px 0; border-top:1px solid black;">
            @Html.Raw(.WriteUp)
        </div>
        @Html.LastUpdated(Model.Profile.LastUpdatedUtc)
    End With
End If
