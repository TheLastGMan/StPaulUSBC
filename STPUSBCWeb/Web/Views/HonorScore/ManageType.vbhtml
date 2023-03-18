@ModelType web.Models.HonorScore.ManageTypeModel
@Code
    ViewData("Title") = Html.TitleMaker(Html.Localize("HonorScore.ManageType.URLTitle").ToString)
End Code

@Html.Partial("_ManageHeader", Model.Navigation)
<h1>@Html.Localize("HonorScore.ManageType.Title")</h1>
<div>@Html.Localize("HonorScore.ManageType.Info")</div>
<table id="managehonortype" >
    <thead>
        <tr>
            <td>@Html.Localize("HonorScore.ManageType.DescriptionTitle")</td>
            <td>@Html.Localize("HonorScore.ManageType.SEOTitle")</td>
            <td class="hidemobile">@Html.Localize("HonorScore.ManageType.AddedTitle")</td>
            <td>@Html.Localize("HonorScore.ManageType.SaveTitle")</td>
            <td>@Html.Localize("HonorScore.ManageType.DeleteTitle")</td>
        </tr>
    </thead>
    <tbody>
        @Using Html.BeginForm("TypeCreate", "HonorScore")
            @<tr class="odd-line">
                <td>@Html.TextBox("Description", "", New With {.required = "required"})</td>
                <td>@Html.TextBox("SEO", "", New With {.required = "required"})</td>
                <td class="hidemobile">@(Now.ToUniversalTime.ToString("MMM-dd-yyyy"))</td>
                <td>
                    <input type="submit" class="submit-green" value="@Html.Localize("HonorScore.ManageType.SaveSubmit")" />
                </td>
                <td>
                    <a href="@Url.Action("ManageType")" class="linkbutton submit-red">
                        @Html.Localize("HonorScore.ManageType.ResetSubmit")
                    </a>
                </td>
             </tr>
        End Using
        @For i As Integer = 1 To Model.Types.Count
            Dim t = Model.Types(i - 1)
            @<tr class="@(IIf(t.Active, iif(i mod 2, "even", "odd") & "-line", "submit-red"))">
                @Using Html.BeginForm("TypeUpdate", "HonorScore")
                    @<td>@html.TextBox("Description", t.Description, New With {.required="required"})</td>
                    @<td>@Html.TextBox("SEO", t.SEO, New With {.required = "required"})</td>
                    @<td class="hidemobile">@(t.AddedUtc.ToString("MMM-dd-yyyy"))</td>
                    @<td>
                        @Html.Hidden("Id", t.Id)
                        <input type="submit" class="submit-green" value="@Html.Localize("HonorScore.ManageType.UpdateSubmit")" />
                    </td>
                end using
                @Using Html.BeginForm("Type" & IIf(t.Active, "Delete", "Create"), "HonorScore")
                    @<td>
                        @Html.Hidden("Id", t.Id)
                        @Html.Hidden("SEO", t.SEO)
                        @Html.Hidden("Description", t.Description)
                        <input type="submit" class="submit-@(iif(t.Active, "red", "green"))" value="@(IIf(t.Active, "Delete", "Activate"))" />
                    </td>
                End Using
             </tr>
        Next
    </tbody>
    <tfoot>
        <tr>
            <td colspan="5">&nbsp;</td>
        </tr>
    </tfoot>
</table>