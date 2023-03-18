@ModelType Web.Models.EmailProfile.EmailManage
@Code
    ViewData("Title") = Html.TitleMaker(Html.Localize("EmailProfile.Manage.Title").ToString)
End Code

<h1>@Html.Localize("EmailProfile.Manage.Title")</h1>
<div class="clearblank4"></div>
<div style="text-align:center;">
    <a href="@Url.Action("Create")" class="linkbutton submit-gold">
        @Html.Localize("EmailProfile.Manage.Create")
    </a>
</div>
<table id="manageEmailProfile">
    <thead>
        <tr>
            <td>@Html.Localize("EmailProfile.Manage.NameTitle")</td>
            <td>@Html.Localize("EmailProfile.Manage.SendAsTitle")</td>
            <td>@Html.Localize("EmailProfile.Manage.DisplayNameTitle")</td>
            <td>&nbsp;</td>
        </tr>
    </thead>
    <tbody>
        @For i As Integer = 1 To Model.Profiles.Count
            Dim ep As Data.Entity.EmailProfile = Model.Profiles(i - 1)
            @<tr class="@(IIf(i Mod 2, "odd", "even"))-line">
                <td>
                    <a href="@Url.Action("Edit", New With {.id = ep.Name})" Class="linkbutton submit-green">
                        @ep.Name
                    </a>
                </td>
                <td>@ep.SendAs</td>
                <td>@ep.DisplayName</td>
                <td>
                    @If Not (Model.ActiveProfiles.Contains(ep.Name)) Then
                        Using Html.BeginForm("Delete", "EmailProfile")
                            @Html.AntiForgeryToken()
                            @Html.Hidden("id", ep.Name)
                            @<input type="submit" class="submit-red" value="@Html.Localize("EmailProfile.Manage.DeleteSubmit")" />
                        End Using
                    End If
                </td>
            </tr>
        Next
    </tbody>
    <tfoot>
        <tr>
            <td colspan="4"></td>
        </tr>
    </tfoot>
</table>
