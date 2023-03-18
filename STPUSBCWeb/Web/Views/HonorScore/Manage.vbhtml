@modelType Web.Models.HonorScore.ManageModel
@Code
    ViewData("Title") = Html.TitleMaker(Html.Localize("HonorScore.Manage.URLTitle").ToString)
End Code

@Html.Partial("_ManageHeader", Model.Navigation)
<div class="clearblank2" style="background-color:#000;"></div>
@Html.Partial("_ScoreHeader", Model.Search)
<div class="clearblank2" style="background-color:#000;"></div>
<h1>@Html.Localize("HonorScore.Manage.Title")</h1>
<div class="clearblank4"></div>
<div style="text-align:center;">
    @If Model.Navigation.ViewId = Web.Models.HonorScore.ManageViewType.Scores Then
        Using Html.BeginForm("HonorCreate", "HonorScore")
            @Html.Hidden("htid", Model.Search.HonorTypeId)
            @Html.Hidden("hcid", Model.Search.HonorCategoryId)
            @<input type="submit" value="@Html.Localize("HonorScore.Manage.CreateSubmit")" class="submit-gold" />
        End Using
    End If
</div>
<table id="managescore">
    <thead>
        <tr>
            <td>@Html.Localize("HonorScore.Manage.HonorTypeTitle")</td>
            <td>@Html.Localize("HonorScore.Manage.HonorCategoryTitle")</td>
            <td>@Html.Localize("HonorScore.Manage.NameTitle")</td>
            <td class="hidemobile">@Html.Localize("HonorScore.Manage.AchievedTitle")</td>
            <td>@Html.Localize("HonorScore.Manage.EditTitle")</td>
            <td>@Html.Localize("HonorScore.Manage.DeleteTitle")</td>
        </tr>
    </thead>
    <tbody>
        @For i As Integer = 1 To Model.HonorScores.Count
            Dim s = Model.HonorScores(i - 1)
            With s
                @<tr class="@(iif(i mod 2, "odd", "even"))-line">
                    <td>@(.HonorType.Description)</td>
                    <td>@(.HonorCategory.Description)</td>
                    <td>@(.FirstName & " " & .LastName)</td>
                    <td class="hidemobile">@(.Achieved.ToString("MMM-dd-yyyy"))</td>
                    <td>
                        <a href="@Url.Action("HonorEdit", "HonorScore", New With {.htid = Model.Search.HonorTypeId, .hcid = Model.Search.HonorCategoryId, .id = s.Id.ToString})", class="linkbutton submit-green">
                            @Html.Localize("HonorScore.Manage.EditSubmit")
                        </a>
                    </td>
                    <td id="@(.Id.ToString)">
                        @Using Ajax.BeginForm("HonorDelete", "HonorScore", New AjaxOptions With {
                                                                            .InsertionMode = InsertionMode.Replace,
                                                                            .UpdateTargetId = s.Id.ToString,
                                                                            .Url = Url.Action("HonorDelete", "HonorScore")})
                            @Html.Hidden("htid", Model.Search.HonorTypeId)
                            @Html.Hidden("hcid", Model.Search.HonorCategoryId)
                            @Html.Hidden("id", .Id.ToString)
                            @<input type="submit" class="submit-red" value="@Html.Localize("HonorScore.Manage.DeleteSubmit")" />
                        End Using
                    </td>
                 </tr>                
            End With
         next
        @If Model.HonorScores.Count = 0 Then
            @<tr class="odd-line">
                <td colspan="6">@Html.Localize("HonorScore.Manage.NoData")</td>
             </tr>
        End If
    </tbody>
    <tfoot>
        <tr>
            <td colspan="6">&nbsp;</td>
        </tr>
    </tfoot>
</table>
