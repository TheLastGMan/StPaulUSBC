@modeltype web.Models.HonorScore.ManageCategoryModel
@Code
    ViewData("Title") = Html.TitleMaker(Html.Localize("HonorScore.ManageCategory.URLTitle").ToString)
End Code

@Html.Partial("_ManageHeader", Model.Navigation)
<h1>@Html.Localize("HonorScore.ManageCategory.Title")</h1>
<p>@Html.Localize("HonorScore.ManageCategory.Info")</p>
<table id="managecategories" >
    <thead>
        <tr>
            <td>@Html.Localize("HonorScore.ManageCategory.DescriptionTitle")</td>
            <td>@Html.Localize("HonorScore.ManageCategory.SEOTitle")</td>
            <td>@Html.Localize("HonorScore.ManageCategory.SaveTitle")</td>
            <td colspan="2" class="hidemobile">@Html.Localize("HonorScore.ManageCategory.OrderTitle")</td>
            <td>@Html.Localize("HonorScore.ManageCategory.DeleteTitle")</td>
        </tr>
    </thead>
    <tbody>
        @Using Html.BeginForm("CreateCategory", "HonorScore")
            @<tr class="odd-line">
                <td>@Html.TextBox("Description", "", New With {.required = "required"})</td>
                <td>@Html.TextBox("SEO", "", New With {.required = "required"})</td>
                <td>
                    <input type="submit" class="submit-green" value="@Html.Localize("HonorScore.ManageCategory.SaveSubmit")" />
                </td>
                <td colspan="2" class="hidemobile"></td>
                <td>
                    <a href="@Url.Action("ManageType")" class="linkbutton submit-red">
                        @Html.Localize("HonorScore.ManageCategory.ResetSubmit")
                    </a>
                </td>
            </tr>
        end using
        @For i As Integer = 1 To Model.Categories.Count
            Dim t = Model.Categories(i - 1)
            @<tr class="@(IIf(t.Active, iif(i mod 2, "even", "odd") & "-line", "submit-red"))">
                @Using Html.BeginForm("UpdateCategory", "HonorScore")
                    @<td>@html.TextBox("Description", t.Description, New With {.required="required"})</td>
                    @<td>@Html.TextBox("SEO", t.SEO, New With {.required = "required"})</td>
                    @<td>
                        @Html.Hidden("Id", t.Id)
                        <input type="submit" class="submit-green" value="@Html.Localize("HonorScore.ManageCategory.UpdateSubmit")" />
                    </td>
                end using
                <td class="hidemobile">
                    @If t.Order > Model.Categories(0).Order Then
                        Using Html.BeginForm("MoveCategory", "HonorScore")
                            @Html.Hidden("order", t.Order)
                            @Html.Hidden("direction", -1)
                            @<input type="submit" class="submit-ltgold" value="@Html.Localize("HonorScore.ManageCategory.Move.Up")" />
                        End Using
                    Else
                        @<span>&nbsp;</span>
                    End If
                </td>
                <td class="hidemobile">
                    @If t.Order < Model.Categories(Model.Categories.Count - 1).Order Then
                        Using Html.BeginForm("MoveCategory", "HonorScore")
                            @Html.Hidden("order", t.Order)
                            @Html.Hidden("direction", 1)
                            @<input type="submit" class="submit-ltgold" value="@Html.Localize("HonorScore.ManageCategory.Move.Down")" />
                        End Using
                    Else
                        @<span>&nbsp;</span>
                    End If
                </td>
                @Using Html.BeginForm(IIf(t.Active, "Delete", "Create") & "Category", "HonorScore")
                    @<td>
                        @Html.Hidden("Id", t.Id)
                        @Html.Hidden("Description", t.Description)
                        @Html.Hidden("SEO", t.SEO)
                        <input type="submit" class="submit-@(iif(t.Active, "red", "green"))" value="@(IIf(t.Active, "Delete", "Activate"))" />
                    </td>
                End Using
             </tr>
        Next
    </tbody>
    <tfoot>
        <tr>
            <td colspan="99">&nbsp;</td>
        </tr>
    </tfoot>
</table>
