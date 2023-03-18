@modeltype Web.Models.Award.AwardOptionModel
@Code
    ViewData("Title") = Html.TitleMaker(Html.Localize("Award.AwardOption.URLTitle").ToString)
    
End Code
@Html.NumericField(0, 300, {"AverageHigh", "AverageHigh"})

@Html.Partial("_AwardHeader", Web.Models.Award.AwardHeader.AwardOption)
<h1>@Html.Localize("Award.AwardOption.Title")</h1>
<table id="awardoptiontable">
    <thead>
        <tr>
            <td>@Html.Localize("Award.AwardOption.AwardTitle")</td>
            <td>@Html.Localize("Award.AwardOption.DivisionTitle")</td>
            <td>@Html.Localize("Award.AwardOption.TypeTitle")</td>
            <td>@Html.Localize("Award.AwardOption.AverageTitle")</td>
            <td>@Html.Localize("Award.AwardOption.VisibleTitle")</td>
            <td>@Html.Localize("Award.AwardOption.UpdateTitle")</td>
            <td>@Html.Localize("Award.AwardOption.DeleteTitle")</td>
        </tr>
    </thead>
    <tbody>
        @Using Html.BeginForm("CreateAwardOption", "Award")
            @<tr class="submit-ltgold">
                <td>@Html.TextBox("Name", "", New With {.required="required"})</td>
                <td>@(Html.DropDownList("AwardDivisionId", New SelectList(Model.Divisions, "Id", "Description", 1)))</td>
                <td>@(Html.DropDownList("AwardTypeId", New SelectList(Model.Types, "Id", "Description", 1)))</td>
                <td>@Html.TextBox("AverageHigh", 0, New With {.type = "number", .required = "required", .min = "0", .max = "300"})</td>
                <td>@Html.CheckBox("Visible", true)</td>
                <td>
                    <input type="submit" class="submit-green" value="@Html.Localize("Award.AwardOption.CreateSubmit")" />
                </td>
                <td>&nbsp;&nbsp;</td>
            </tr>            
        End Using
        @For i As Integer = 1 To Model.AwardOptions.Count
            Dim lv As Integer = i
            Dim m = Model.AwardOptions(i - 1)
            @<tr class="@(IIf(i Mod 2, "odd", "even"))-line">
                @Using Html.BeginForm("UpdateAwardOption", "Award")
                    @<td>@Html.TextBox("Name", m.Name, New With {.required="required"})</td>
                    @<td>@(Html.DropDownList("AwardDivisionId", New SelectList(Model.Divisions, "Id", "Description", m.AwardDivisionId)))</td>
                    @<td>@(Html.DropDownList("AwardTypeId", New SelectList(Model.Types, "Id", "Description", m.AwardTypeId)))</td>
                    @<td>@Html.TextBox("AverageHigh", m.AverageHigh, New With {.type = "number", .required = "required", .min = "0", .max = "300"})</td>
                    @<td>@Html.CheckBox("Visible", m.Visible)</td>
                    @<td>
                        @Html.Hidden("Id", m.Id)
                        <input type="submit" class="submit-green" value="@Html.Localize("Award.AwardOption.UpdateSubmit")" />
                    </td>
                End Using
                <td>
                    @Using Html.BeginForm("DeleteAwardOption", "Award")
                            @Html.Hidden("Id", m.Id)
                            @<input type="submit" class="submit-red" value="@Html.Localize("Award.AwardOption.DeleteSubmit")" />
                        End Using
                </td>
            </tr>                 
        Next
    </tbody>
    <tfoot>
        <tr>
            <td colspan="7"></td>
        </tr>
    </tfoot>
</table>