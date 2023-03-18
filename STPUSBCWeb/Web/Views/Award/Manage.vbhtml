@ModelType List(Of Web.Models.Award.ManageModel)
@Code
    ViewData("Title") = Html.TitleMaker(Html.Localize("Award.Manage.URLTitle").ToString)
End Code

@Html.Partial("_AwardHeader", Web.Models.Award.AwardHeader.Award)

<h1>@Html.Localize("Award.Manage.Title")</h1>
<table id="awardtable">
    <thead>
        <tr>
            <td>@Html.Localize("Award.Manage.BowlerNameTitle")</td>
            <td>@Html.Localize("Award.Manage.USBCIDTitle")</td>
            <td>@Html.Localize("Award.Manage.SecretaryName")</td>
            <td>@Html.Localize("Award.Manage.SecretaryPin")</td>
            <td>@Html.Localize("Award.Manage.AddedUTCTitle")</td>
            <td>@Html.Localize("Award.Manage.PrintTitle")</td>
        </tr>
    </thead>
    <tbody>
        @For i As Integer = 1 To Model.Count
            Dim award = Model(i - 1)
            @<tr class="@(IIf(i Mod 2, "odd", "even"))-line">
                <td>@award.BowlerName</td>
                <td>@award.USBCID</td>
                <td>@award.SecretaryName</td>
                <td>@award.SecretaryPin</td>
                <td>@award.AddedUTC.ToString("MMM-dd-yyyy")</td>
                <td>
                    <a href="@(Url.Action("PrintAwardAdmin", New With {.id = award.Id.ToString}))" class="linkbutton submit-green" target="_blank">
                        @Html.Localize("Award.Manage.Print")
                    </a>
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

@Html.Action("AwardEmailProfile")
