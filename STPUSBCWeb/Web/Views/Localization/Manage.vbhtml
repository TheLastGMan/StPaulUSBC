@ModelType Web.Models.Localization.ManageModel
@Code
    ViewData("Title") = Html.TitleMaker(Html.Localize("Localization.Manage.URLTitle").ToString)
End Code

<h1>@Html.Localize("Localization.Manage.Title")</h1>     
<div class="clearblank4"></div>
@Using Html.BeginForm()
    @<table style="margin:auto; text-align:center;">
        <tr>
            <td colspan="3" style="font-size:2.0em;">@Html.Localize("Localization.Manage.SearchTitle")</td>
        </tr>
        <tr>
            <td>@Html.Localize("Localization.Manage.SearchFieldTitle")</td>
            <td>@Html.Localize("Localization.Manage.SearchTypeTitle")</td>
            <td>@Html.Localize("Localization.Manage.SearchForTitle")</td>
        </tr>
        <tr>
            <td>
                @Html.DropDownListFor(Function(f) f.Field, New SelectList([Enum].GetNames(GetType(Web.Models.Localization.SearchField)), model.Field))
            </td>
            <td>
                @Html.DropDownListFor(Function(f) f.Parameter, New SelectList([enum].GetNames(GetType(Web.Models.Localization.SearchParameter)), Model.Parameter))
            </td>
            <td colspan="3">
                @Html.TextBoxFor(Function(f) f.query)
            </td>
        </tr>
        <tr>
            <td colspan="3">
                <input type="submit" class="submit-ltgold" value="@Html.Localize("Localization.Manage.SearchSubmit")" />
            </td>
        </tr>
    </table>
End Using
<table id="localization">
    <thead>
        <tr>
            <td>@Html.Localize("Localization.Manage.KeyTitle")</td>
            <td>@Html.Localize("Localization.Manage.ValueTitle")</td>
            <td>@Html.Localize("Localization.Manage.UpdateTitle")</td>
        </tr>
    </thead>
    <tbody>
        @For i As Integer = 1 To Model.Localization.Count
            Dim l = Model.Localization(i - 1)
            Using Html.BeginForm("Update", "Localization")
                @<tr class="@(IIf(i mod 2, "odd", "even"))-line">
                    <td>
                        @Html.Hidden("id", l.Id.ToString)
                        @(l.Key)
                    </td>
                    <td>
                        @Html.TextBox("Value", l.Value)
                    </td>
                    <td>
                        @Html.HiddenFor(Function(f) f.query)
                        @Html.HiddenFor(Function(f) f.Field)
                        @Html.HiddenFor(Function(f) f.Parameter)
                        <input type="submit" class="submit-green" value="@Html.Localize("Localization.Manage.UpdateSubmit")" />
                    </td>
                </tr>
            End Using
        Next
        @If Model.Localization.Count = 0 Then
            @<tr class="odd-line">
                <td colspan="3">@Html.Localize("Localization.Manage.NoData")</td>
             </tr>
        End If
    </tbody>
    <tfoot>
        <tr>
            <td colspan="3"></td>
        </tr>
    </tfoot>
</table>