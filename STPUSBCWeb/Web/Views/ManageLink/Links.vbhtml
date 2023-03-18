@ModelType web.Models.Manage.LinksModel
@Code
    ViewData("Title") = Html.TitleMaker(Html.Localize("ManageLink.Links.URLTitle").ToString)
End Code

<h1>@Html.Localize("ManageLink.Links.Title")</h1>
<table id="ManageLinks"  style="text-align:center;">
    <thead>
        <tr>
            <td>@Html.Localize("ManageLink.Links.NameTitle")</td>
            <td>@Html.Localize("ManageLink.Links.UrlTitle")</td>
            <td>@Html.Localize("ManageLink.Links.VisibleTitle")</td>
            <td>@Html.Localize("ManageLink.Links.CreateTitle")</td>
            <td colspan="2" class="hidemobile">@Html.Localize("ManageLink.Links.OrderTitle")</td>
            <td>@Html.Localize("ManageLink.Links.DeleteTitle")</td>
        </tr>
    </thead>
    <tbody>
        <tr class="even-line">
            @Using Html.BeginForm("LinkCreate", "ManageLink")
                @<td>
                    @Html.TextBox("Name", "", New With {.required = "required", .placeholder = "Display Text"})
                    </td>
                @<td>
                    @Html.TextBox("Url", "", New With {.required = "required", .placeholder = "Url Link"})
                </td>
                @<td>
                    @Html.CheckBox("Visible", False)
                </td>
                @<td>
                    <input type="submit" class="submit-green" value="@Html.Localize("ManageLink.Links.CreateSubmit")" />
                </td>
            End Using
            <td colspan="2" class="hidemobile" />
            <td>
                <form action="@Url.Action("Links")">
                    <input type="submit" class="submit-red" value="@Html.Localize("ManageLink.Links.ResetSubmit")" />
                </form>
            </td>
        </tr>
        @For i As Integer = 1 To Model.Links.Count
            Dim item = Model.Links(i-1)
            @<tr class="@(IIf(i mod 2, "odd-line", "even-line"))">
                @Using Html.BeginForm("LinkUpdate", "ManageLink")
                    @<td>@Html.TextBox("Name", item.Name, New With {.required = "required", .placeholder = "Display Text"})</td>
                    @<td>@Html.TextBox("Url", item.Url, New With {.required = "required", .placeholder = "Url Link"})</td>
                    @<td>@Html.CheckBox("Visible", item.Visible)</td>
                    @<td>
                        @Html.Hidden("Id", item.Id)
                        <input type="submit" class="submit-green" value="@Html.Localize("ManageLink.Links.UpdateSubmit")" />
                    </td>
                End Using
                <td class="hidemobile">
                    @If (item.Order > Model.Links(0).Order) Then
                        Using Html.BeginForm("LinkMove", "ManageLink")
                            @Html.Hidden("Id", item.Id)
                            @Html.Hidden("Order", item.Order)
                            @Html.Hidden("direction", -1)
                            @<input type="submit" class="submit-ltgold" value="@Html.Localize("ManageLink.Links.Order.Up")" />
                        End Using
                    End If
                </td>
                <td class="hidemobile">
                    @If (item.Order < Model.Links(Model.Links.Count - 1).Order) Then
                        Using Html.BeginForm("LinkMove", "ManageLink")
                            @Html.Hidden("Id", item.Id)
                            @Html.Hidden("Order", item.Order)
                            @Html.Hidden("direction", 1)
                            @<input type="submit" class="submit-ltgold" value="@Html.Localize("ManageLink.Links.Order.Down")" />
                        End Using
                    End If
                </td>
                <td>
                    @Using Html.BeginForm("LinkDelete", "ManageLink")
                        @Html.Hidden("Id", item.Id)
                        @<input type="submit" class="submit-red" value="@Html.Localize("ManageLink.Links.DeleteSubmit")" />
                    End Using
                </td>
             </tr>
         Next
    </tbody>
    <tfoot>
        <tr>
            <td colspan="7">&nbsp;</td>
        </tr>
    </tfoot>
</table>
