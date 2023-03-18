@ModelType List(of Data.Entity.AwardType)
@Code
    ViewData("Title") = Html.TitleMaker(Html.Localize("Award.AwardType.URLTitle").ToString)
End Code

@Html.Partial("_AwardHeader", Web.Models.Award.AwardHeader.AwardType)
<h1>@Html.Localize("Award.AwardType.Title")</h1>
<table id="awardtypetable">
    <thead>
        <tr>
            <td>@Html.Localize("Award.AwardType.DescriptionTitle")</td>
            <td>@Html.Localize("Award.AwardType.UpdateTitle")</td>
        </tr>
    </thead>
    <tbody>
        @For i As Integer = 1 To Model.Count
            Dim m = Model(i - 1)
            Using Html.BeginForm("UpdateAwardType", "Award")
                @<tr class="@(iif(i Mod 2, "odd", "even"))-line">>
                    <td>
                        @Html.Hidden("key", m.Id)
                        @Html.TextBox("value", m.Description)
                    </td>
                    <td>
                        <input type="submit" class="submit-green" value="@Html.Localize("Award.AwardType.UpdateSubmit")" />
                    </td>
                </tr>
            End Using
        Next
    </tbody>
    <tfoot>
        <tr>
            <td colspan="2"></td>
        </tr>
    </tfoot>
</table>
