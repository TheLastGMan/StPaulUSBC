@ModelType List(of Data.Entity.AwardDivision)
@Code
    ViewData("Title") = Html.TitleMaker(Html.Localize("Award.AwardOptionType.URLTitle").ToString)
End Code

@Html.Partial("_AwardHeader", Web.Models.Award.AwardHeader.AwardOptionType)
<h1>@Html.Localize("Award.AwardDivision.Title")</h1>
<table id="awardtypetable">
    <thead>
        <tr>
            <td>@Html.Localize("Award.AwardDivision.DescriptionTitle")</td>
            <td>@Html.Localize("Award.AwardDivision.UpdateTitle")</td>
        </tr>
    </thead>
    <tbody>
        @For i As Integer = 1 To Model.Count
            Dim m = Model(i-1)
            Using Html.BeginForm("UpdateAwardDivision", "Award")
                @<tr class="@(iif(i mod 2, "odd", "even"))-line">
                    <td>
                        @Html.Hidden("key", m.Id)
                        @Html.TextBox("value", m.Description)
                    </td>
                    <td>
                        <input type="submit" class="submit-green" value="@Html.Localize("Award.AwardDivision.UpdateSubmit")" />
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