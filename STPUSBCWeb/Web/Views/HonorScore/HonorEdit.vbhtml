@ModelType Web.Models.HonorScore.HonorScoreEditModel
@Code
    ViewData("Title") = Html.TitleMaker(Html.Localize("HonorScore.HonorEdit.URLTitle").ToString)
End Code

<h1>@String.Format(Html.Localize("HonorScore.HonorEdit.Title").ToHtmlString, Model.Honor.FormattedName)</h1>
@Using Html.BeginForm("HonorEdit", "HonorScore")  
    @<table id="edithonor" >
        <thead>
            <tr>
                <td>&nbsp;</td>
                <td></td>
            </tr>
        </thead>
            @With Model.Honor
                @<tbody>
                    <tr class="odd-line">
                        <td>@Html.Localize("HonorScore.HonorEdit.FirstName") :&nbsp;</td>
                        <td>@Html.TextBoxFor(Function(f) f.Honor.FirstName, New With {.required="required"})</td>
                    </tr>
                    <tr class="even-line">
                        <td>@Html.Localize("HonorScore.HonorEdit.LastName") :&nbsp;</td>
                        <td>@Html.TextBoxFor(Function(f) f.Honor.LastName, New With {.required = "required"})</td>
                    </tr>
                    <tr class="odd-line">
                        <td>@Html.Localize("HonorScore.HonorEdit.HonorType") :&nbsp;</td>
                        <td>@(html.DropDownListFor(Function(f) f.Honor.HonorTypeId, New SelectList(Model.TypeList, "Id", "Description", .HonorTypeId)))</td>
                    </tr>
                    <tr class="even-line">
                        <td>@Html.Localize("HonorScore.HonorEdit.HonorCategory") :&nbsp;</td>
                        <td>@(html.DropDownListFor(Function(f) f.Honor.HonorCategoryId, New SelectList(model.CategoryList, "Id", "Description", .HonorCategoryId)))</td>
                    </tr>
                    <tr class="odd-line">
                        <td>@Html.Localize("HonorScore.HonorEdit.Game1") :&nbsp;</td>
                        <td>@(.game1)</td>
                    </tr>
                    <tr class="even-line">
                        <td>@Html.Localize("HonorScore.HonorEdit.Game2") :&nbsp;</td>
                        <td>@(.Game2)</td>
                    </tr>
                    <tr class="odd-line">
                        <td>@Html.Localize("HonorScore.HonorEdit.Game3") :&nbsp;</td>
                        <td>@(.Game3)</td>
                    </tr>
                    <tr class="even-line">
                        <td>@Html.Localize("HonorScore.HonorEdit.Series") :&nbsp;</td>
                        <td>@(.Series)</td>
                    </tr>
                    <tr class="odd-line">
                        <td>@Html.Localize("HonorScore.HonorEdit.Achieved") :&nbsp;</td>
                        <td>@(.Achieved.ToString("MMM-dd-yyyy"))</td>
                    </tr>
                    <tr class="even-line">
                        <td>@Html.Localize("HonorScore.HonorEdit.Added") :&nbsp;</td>
                        <td>@(.AddedUtc.ToString("MMM-dd-yyyy"))</td>
                    </tr>
                </tbody>
            End With
        <tfoot>
            <tr>
                <td colspan="2" style="line-height:1.0em;">
                    @Html.HiddenFor(Function(f) f.Honor.Id)
                    @Html.HiddenFor(Function(f) f.CategoryId)
                    @Html.HiddenFor(Function(f) f.TypeId)
                    <input type="submit" class="submit-green" value="@Html.Localize("HonorScore.HonorEdit.SaveSubmit")" />&nbsp;&nbsp;
                    <a href="@(url.Action("Manage", New With {.hcid = Model.CategoryId, .htid = Model.TypeId}))" class="linkbutton submit-red">
                        @Html.Localize("HonorScore.HonorEdit.CancelSubmit")
                    </a>
                </td>
            </tr>
        </tfoot>
    </table>
end using
