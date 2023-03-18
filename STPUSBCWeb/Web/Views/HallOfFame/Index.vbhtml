@ModelType Web.Models.HallOfFame.IndexModel
@Code
    Dim column As String = ""

    Dim namesort As String = "icon"
    Dim achievedsort As String = "icon"
    Dim recognitionsort As String = "icon"
    Select Case Model.SortMethod
        Case Core.Services.HallOfFame.SortMethod.NameASC
            namesort = "up"
            column = Html.Localize("HallOfFame.Index.NameASC").ToString
        Case Core.Services.HallOfFame.SortMethod.namedesc
            namesort = "down"
            column = Html.Localize("HallOfFame.Index.NameDESC").ToString
        Case Core.Services.HallOfFame.SortMethod.AchievedASC
            achievedsort = "up"
            column = Html.Localize("HallOfFame.Index.AchievedASC").ToString
        Case Core.Services.HallOfFame.SortMethod.AchievedDESC
            achievedsort = "down"
            column = Html.Localize("HallOfFame.Index.AchievedDESC").ToString
        Case Core.Services.HallOfFame.SortMethod.RecognitionASC
            recognitionsort = "up"
            column = Html.Localize("HallOfFame.Index.RecognitionASC").ToString
        Case Else
            recognitionsort = "down"
            column = Html.Localize("HallOfFame.Index.RecognitionDESC").ToString
    End Select
    ViewData("Title") = Html.TitleMaker(Html.Localize("HallOfFame.Index.URLTitle").ToString)
End Code
<h1>@Html.Localize("HallOfFame.Index.Title")</h1>
@Html.Widget("halloffame_index")

<table class="HallOfFameTable" >
    <thead>
        <tr>
            <td>
                @Html.Localize("HallOfFame.Index.NameTitle")
                <a class="sort-icon" href="@(Url.Action("Index", New With {.sort = IIf(Model.SortMethod = Core.Services.HallOfFame.SortMethod.nameasc, Core.Services.HallOfFame.SortMethod.namedesc, Core.Services.HallOfFame.SortMethod.nameasc)}))">
                    <img src="@(Url.Content("~/content/images/sort-" & namesort & ".png"))" alt="@Html.Localize("HallOfFame.Index.SortImageAlt")" />
                </a>
            </td>
            <td>
                @Html.Localize("HallOfFame.Index.AchievedTitle")
                <a class="sort-icon" href="@(Url.Action("Index", New With {.sort = IIf(Model.SortMethod = Core.Services.HallOfFame.SortMethod.achievedasc, Core.Services.HallOfFame.SortMethod.achieveddesc, Core.Services.HallOfFame.SortMethod.achievedasc)}))">
                    <img src="@(Url.Content("~/content/images/sort-" & achievedsort & ".png"))" alt="@Html.Localize("HallOfFame.Index.SortImageAlt")" />
                </a>
            </td>
            <td>
                @Html.Localize("HallOfFame.Index.RecognitionTitle")
                <a class="sort-icon" href="@(Url.Action("Index", New With {.sort = IIf(Model.SortMethod = Core.Services.HallOfFame.SortMethod.RecognitionASC, Core.Services.HallOfFame.SortMethod.RecognitionDESC, Core.Services.HallOfFame.SortMethod.RecognitionASC)}))">
                    <img src="@(Url.Content("~/content/images/sort-" & recognitionsort & ".png"))" alt="@Html.Localize("HallOfFame.Index.SortImageAlt")" />
                </a>
            </td>
        </tr>
    </thead>
    <tbody>
        @For i As Integer = 1 To Model.hoflist.Count
            Dim u = Model.hoflist(i - 1)
            @<tr class="@(iif(i mod 2, "odd-line", "even-line"))">
                <td>
                    <a href="@HttpUtility.UrlDecode(Url.RouteUrl("HallOfFame_Profile", New With {.id = u.id.ToString, .seo = HttpUtility.HtmlDecode((u.First_Name & "_" & u.Last_Name).ToLower)}))">@u.FullName</a>
                    @If u.Deceased Then
                        @<span class="deceased"> (Deceased)</span>
                    End If
                </td>
                <td style="text-align:center;">@(u.Awareded.ToString(Model.AchievedFormat))</td>
                <td style="text-align:center;">@(u.RecognitionName)</td>
             </tr>
        Next
        @If Model.hoflist.Count = 0 Then
            @<tr class="odd-line">
                <td colspan="3" style="text-align:center;">@Html.Localize("HallOfFame.Index.NoData")</td>
             </tr>
        End If
    </tbody>
    <tfoot>
        <tr>
            <td colspan="3">&nbsp;</td>
        </tr>
    </tfoot>
</table>