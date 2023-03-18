@ModelType Web.Models.Board.ManagePositionModel
@Code
    ViewData("Title") = Html.TitleMaker(Html.Localize("Board.ManagePosition.URLTitle").ToString)
End Code

@Html.Partial("_BoardHeader", 2)
<div class="clearblank4"></div>
<h1>@Html.Localize("Board.ManagePosition.Title")</h1>
<div class="clearblank4"></div>
<table id="boardpositions">
    <thead>
        <tr>
            <td>@Html.Localize("Board.ManagePosition.DescriptionTitle")</td>
            <td>@Html.Localize("Board.ManagePosition.UpdateTitle")</td>
            <td>@Html.Localize("Board.ManagePosition.VisibleTitle")</td>
            <td colspan="2" class="hidemobile">@Html.Localize("Board.ManagePosition.OrderTitle")</td>
            <td>@Html.Localize("Board.ManagePosition.DeleteTitle")</td>
        </tr>
    </thead>
    <tbody>
        @Using Html.BeginForm("CreatePosition", "Board")
            @<tr class="odd-line">
                <td>@Html.TextBox("Description", "", New With {.required="required"})</td>
                <td>@Html.CheckBox("Visible", True)</td>
                <td>
                    <input type="submit" class="submit-green" value="@Html.Localize("Board.ManagePosition.CreateSubmit")" />
                </td>
                <td colspan="2" class="hidemobile"></td>
                <td>
                    <a href="@Url.Action("ManagePosition")" class="linkbutton submit-red">@Html.Localize("Board.ManagePosition.ResetSubmit")</a>
                </td>
             </tr>
        End Using
        @For i As Integer = 1 To model.Positions.count
            Dim p = model.Positions(i - 1)
            @<tr class="@(iif(i mod 2, "even", "odd"))-line">
                @Using Html.BeginForm("UpdatePosition", "Board")
                    @<td>@Html.TextBox("Description", p.Description, New With {.required = "required"})</td>
                    @<td>
                        @Html.Hidden("id", p.Id)
                        <input type="submit" class="submit-green" value="@Html.Localize("Board.ManagePosition.UpdateSubmit")" />
                    </td>                
                End Using
                @Using Html.BeginForm("PositionDisplayChange", "Board")
                    @<td>
                        @Html.Hidden("id", p.Id)
                        @Html.Hidden("display", Not p.Visible)
                        <input type="submit" class="submit-@(IIf(p.Visible, "lt", ""))gold" value="@IIf(p.Visible, Html.Localize("Board.ManagePosition.Visible.True"), Html.Localize("Board.ManagePosition.Visible.False"))" />
                    </td>
                End Using
                <td class="hidemobile">
                    @If p.Order < Model.Positions(Model.Positions.Count - 1).Order Then
                        Using Html.BeginForm("PositionOrderMove", "Board")
                            @Html.Hidden("order", p.Order)
                            @Html.Hidden("direction", 1)
                            @<input type="submit" class="submit-ltgold" value="@Html.Localize("Board.ManagePosition.Move.Down")" />
                        End Using
                    End If
                </td>
                <td class="hidemobile">
                    @If p.Order > Model.Positions(0).Order Then
                        Using Html.BeginForm("PositionOrderMove", "Board")
                            @Html.Hidden("order", p.Order)
                            @Html.Hidden("direction", -1)
                            @<input type="submit" class="submit-ltgold" value="@Html.Localize("Board.ManagePosition.Move.Up")" />
                        End Using
                    End If
                </td>
                <td>
                    @If p.BoardHistory.Count = 0 Then
                        Using Html.BeginForm("DeletePosition", "Board")
                            @Html.Hidden("id", p.Id)
                            @<input type="submit" class="submit-red" value="@Html.Localize("Board.ManagePosition.DeleteSubmit")" />
                        End Using
                    Else
                        @<span>@Html.Localize("Board.ManagePosition.Delete.Active")</span>
                    End If
                </td>
             </tr>
         Next
    </tbody>
    <tfoot>
        <tr>
            <td colspan="6">&nbsp;</td>
        </tr>
    </tfoot>
</table>
