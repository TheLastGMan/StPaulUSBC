@modeltype Web.Models.HallOfFame.ManageTypeModel
@Code
    ViewData("Title") = Html.TitleMaker(Html.Localize("HallOfFame.ManageType.URLTitle").ToString)
End Code

@Html.Partial("_HOFHeader", 2)
<div class="clearblank4"></div>
<h1>@Html.Localize("HallOfFame.ManageType.Title")</h1>
<div class="clearblank4"></div>

<table id="hoftype">
    <thead>
        <tr>
            <td>@Html.Localize("HallOfFame.ManageType.DescriptionTitle")</td>
            <td>@Html.Localize("HallOfFame.ManageType.DisplayTitle")</td>
            <td>@Html.Localize("HallOfFame.ManageType.UpdateTitle")</td>
            <td>@Html.Localize("HallOfFame.ManageType.VisibleTitle")</td>
            <td>@Html.Localize("HallOfFame.ManageType.DeleteTitle")</td>
        </tr>
    </thead>
    <tbody>
        <tr class="odd-line">
            @Using Html.BeginForm("CreateType", "HallOfFame")
                @<td>@html.TextBox("Description", "", New With {.required = "required"})</td>
                @<td>@Html.CheckBox("Display", False)</td>
                @<td>
                    <input type="submit" class="submit-green" value="Save" />
                </td>
            End Using
            <td></td>
            <td>
                <a href="@Url.Action("ManageType")" class="linkbutton submit-red">@Html.Localize("HallOfFame.ManageType.ClearSubmit")</a>
            </td>
        </tr>
        @For i As Integer = 1 To Model.Types.Count
            Dim t = Model.Types(i-1)
            @<tr class="@(IIf(i mod 2, "even", "odd"))-line">
                @Using Html.BeginForm("UpdateType", "HallOfFame")
                    @<td>@html.TextBox("Description", t.Description, New With {.required = "required"})</td>
                    @<td>@Html.CheckBox("Display", t.Display)</td>
                    @<td>
                        @Html.Hidden("Id", t.Id)
                        <input type="submit" class="submit-green" value="@Html.Localize("HallOfFame.ManageType.UpdateSubmit")" />
                    </td>
                End using
                @Using Html.BeginForm("DisplayStatusType", "HallOfFame")
                    @<td>
                        @Html.Hidden("Id", t.Id)
                        @Html.Hidden("Display", Not t.Display)
                        <input type="submit" class="submit-@(iif(t.Display, "lt", ""))gold" value="@(IIf(t.Display, Html.Localize("HallOfFame.ManageType.Visible.Yes"), Html.Localize("HallOfFame.ManageType.Visible.No")))" />
                    </td>
                End Using
                @Using Html.BeginForm("DeleteType", "HallOfFame")
                    @<td>
                        @If t.HallOfFame.Count > 0 Then
                            @Html.Hidden("Id", t.Id)
                            @<input type="submit" class="submit-red" value="@Html.Localize("HallOfFame.ManageType.DeleteSubmit")" />                        
                        End If
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