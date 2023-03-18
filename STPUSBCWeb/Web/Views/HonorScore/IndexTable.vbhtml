@modelType Web.Models.HonorScore.Index
@Code
     ViewData("Title") = Html.TitleMaker(Html.Localize("HonorScore.Index.URLTitle").ToString)
    Dim i As Integer = 0
End Code

<h1>@Html.Localize("HonorScore.Index.Title")</h1>
@Html.Widget("honorscore_index")
<table id="honorscores" >
    <thead>
        <tr>
            <td>&nbsp;</td>
            <td colspan="@(Math.Max(1, Model.HonorCategories.Count))"></td>
        </tr>
    </thead>
    <tbody>
        @For Each ht In Model.HonorTypes.Where(Function(f) f.Active)
            i += 1
            @<tr class="@(iif(i mod 2, "odd-line", "even-line"))">
                <td>@(ht.Description)</td>
                @For Each hc In Model.HonorCategories.Where(Function(f) f.Active)
                @<td>
                    @If hc.Honor.Where(Function(f) f.HonorTypeId = ht.Id).Count > 0 Then
                        @(Html.ActionLink(hc.Description, "Scores", New With {.catseo = hc.SEO.ToLower, .typeseo = ht.SEO.ToLower}))
                    Else
                        @(hc.Description)
                    End If
                 </td>
                Next
                @If Model.HonorCategories.Where(Function(f) f.Active).Count = 0 Then
                    @<td>@Html.Localize("HonorScore.Index.NoHonorCategory")</td>
                End If
             </tr>
        Next
        @If Model.HonorTypes.Where(Function(f) f.Active).Count = 0 Then
            @<tr class="odd-line">
                <td colspan="@(Math.Max(1, Model.HonorCategories.Count) + 1)">
                    @Html.Localize("HonorScore.Index.NoHonorScores")
                </td>
             </tr>
        End If
    </tbody>
    <tfoot>
        <tr>
            <td colspan="@(Math.Max(1, Model.HonorCategories.Count) + 1)">
                &nbsp;
            </td>
        </tr>
    </tfoot>
</table>
@Html.LastUpdated(Model.LastUpdated)