@ModelType Web.Models.Manage.NavigationModel
@Code
    ViewData("Title") = Html.TitleMaker(Html.Localize("ManageLink.Navigation.URLTitle").ToString)
End Code

<h1>@Html.Localize("ManageLink.Navigation.Title")</h1>
<table id="managenavigation">
    <thead>
        <tr>
            <td>@Html.Localize("ManageLink.Navigation.DisplayTitle")</td>
            <td>@Html.Localize("ManageLink.Navigation.UpdateTitle")</td>
            <td>@Html.Localize("ManageLink.Navigation.VisibleTitle")</td>
            <td colspan="2" class="hidemobile">@Html.Localize("ManageLink.Navigation.OrderTitle")</td>
        </tr>
    </thead>
    <tbody>
        @For i As Integer = 1 To Model.Links.Count
            Dim item = Model.Links(i - 1)
        @<tr class="@(iif(i mod 2, "odd-line", "even-line"))">
            @Using Html.BeginForm("NavigationUpdate", "ManageLink")
        @<td>
            @Html.TextBox("display_text", item.DisplayText, New With {.required = "required", .placeholder = "Display Text"})
        </td>
        @<td>
            @Html.Hidden("id", item.Id.ToString)
            <input type="submit" class="submit-green" value="@Html.Localize("ManageLink.Navigation.UpdateSubmit")" />
        </td>
            End Using
            <td style="text-align:center;">
                @Using Html.BeginForm("NavigationStatusChange", "ManageLink")
                    @Html.Hidden("id", item.Id.ToString)
                    @Html.Hidden("display", Not item.Visible)
                    @<input type="submit" value="@(IIf(item.Visible, "Hide", "Show"))" class="submit-@(iif(item.Visible,"lt",""))gold" />
                End Using
            </td>
            <td class="hidemobile">
                @If (item.Order > Model.Links(0).Order) Then
                    Using Html.BeginForm("NavigationMove", "ManageLink")
                    @Html.Hidden("id", item.Id.ToString)
                    @Html.Hidden("order", item.Order)
                    @Html.Hidden("direction", -1)
                    @<input type="submit" class="submit-ltgold" value="@Html.Localize("ManageLink.Navigation.Order.Up")" />
                    End Using
                End If
            </td>
            <td class="hidemobile">
                @If (item.Order < Model.Links(Model.Links.Count - 1).Order) Then
                    Using Html.BeginForm("NavigationMove", "ManageLink")
                    @Html.Hidden("id", item.Id.ToString)
                    @Html.Hidden("order", item.Order)
                    @Html.Hidden("direction", 1)
                    @<input type="submit" class="submit-ltgold" value="@Html.Localize("ManageLink.Navigation.Order.Down")" />
                    End Using
                End If
            </td>
        </tr>
        Next
    </tbody>
    <tfoot>
        <tr>
            <td colspan="5">&nbsp;</td>
        </tr>
    </tfoot>
</table>
