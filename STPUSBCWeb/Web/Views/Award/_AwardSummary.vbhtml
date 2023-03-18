@ModelType Data.Entity.Award

@Code
    Layout = nothing
End Code

<table id="printaward">
    <thead>
        <tr>
            <td>&nbsp;</td>
            <td></td>
        </tr>
    </thead>
    <tbody>
        <tr>
            <td>@Html.Localize("Award.PrintAward.ID"):&nbsp;</td>
            <td>@(Model.Id.ToString)</td>
        </tr>
        <tr>
            <td>@Html.Localize("Award.PrintAward.DateBowled"):&nbsp;</td>
            <td>@(model.DateBowled.ToString("MMM-dd-yyyy"))</td>
        </tr>
        <tr>
            <td>@Html.Localize("Award.PrintAward.AwardType"):&nbsp;</td>
            <td>@(Model.AwardType.Description)</td>
        </tr>
        <tr>
            <td>@Html.Localize("Award.PrintAward.BowlerName"):&nbsp;</td>
            <td>@(model.BowlerName)</td>
        </tr>
        <tr>
            <td>@Html.Localize("Award.PrintAward.USBCID"):&nbsp;</td>
            <td>@(model.USBCID)</td>
        </tr>
        <tr>
            <td>@Html.Localize("Award.PrintAward.Center"):&nbsp;</td>
            <td>@(model.Center)</td>
        </tr>
        <tr>
            <td>@Html.Localize("Award.PrintAward.League"):&nbsp;</td>
            <td>@(model.League)</td>
        </tr>
        <tr>
            <td>@Html.Localize("Award.PrintAward.BowlerAverage"):&nbsp;</td>
            <td>@(model.BowlerAverage)</td>
        </tr>
        <tr>
            <td>@Html.Localize("Award.PrintAward.BowlerGames"):&nbsp;</td>
            <td>@(model.BowlerGames)</td>
        </tr>
        <tr>
            <td>@Html.Localize("Award.PrintAward.Game1"):&nbsp;</td>
            <td>@(model.Game1)</td>
        </tr>
        <tr>
            <td>@Html.Localize("Award.PrintAward.Game2"):&nbsp;</td>
            <td>@(model.Game2)</td>
        </tr>
        <tr>
            <td>@Html.Localize("Award.PrintAward.Game3"):&nbsp;</td>
            <td>@(model.Game3)</td>
        </tr>
        <tr>
            <td>@Html.Localize("Award.PrintAward.Series"):&nbsp;</td>
            <td>@(model.Series)</td>
        </tr>
        @If Model.USBCAwardList.Count > 0 Then
            @<tr>
                    <td>@Html.Localize("Award.PrintAward.USBCAward"):&nbsp;</td>
                    <td>
                        @(Html.Raw(String.Join("<br/>", Model.USBCAwardList.ToArray)))
                    </td>
                </tr>
        End If
        @If Model.LocalAwardList.Count > 0 Then
            @<tr>
                <td>@Html.Localize("Award.PrintAward.LocalAward"):&nbsp;</td>
                <td>
                    @(Html.Raw(String.Join("<br/>", Model.LocalAwardList.ToArray)))
                </td>
            </tr>
            If Model.AwardTypeId = 1 Then
                @<tr>
                    <td>@Html.Localize("Award.PrintAward.LocalAwardChoice"):&nbsp;</td>
                    <td>@(model.AdultAwardChoice)</td>
                </tr>            
            End If
        End If
        <tr>
            <td colspan="2" style="text-align:center; font-weight:bold">
                <h2>@Html.Localize("Award.PrintAward.SecretaryAreaTitle")</h2>
            </td>
        </tr>
        <tr>
            <td>@Html.Localize("Award.PrintAward.SecretaryName"):&nbsp;</td>
            <td>@(model.SecretaryName)</td>
        </tr>
        @If User.IsInRole("Award") Then
            @<tr>
                <td>@Html.Localize("Award.PrintAward.SecretaryPin"):&nbsp;</td>
                <td>@(model.SecretaryPin)</td>
            </tr>            
        End If
        @If Not String.IsNullOrEmpty(Model.SecretaryPhone) Then
            @<tr>
                    <td>@Html.Localize("Award.PrintAward.SecretaryPhone"):&nbsp;</td>
                    <td>@(model.SecretaryPhone)</td>
                </tr>
        End If
        @If Not String.IsNullOrEmpty(Model.SecretaryEmail) Then
            @<tr>
                    <td>@Html.Localize("Award.PrintAward.SecretaryEmail"):&nbsp;</td>
                    <td>@(Model.SecretaryEmail)</td>
                </tr>            
        End If
    </tbody>
    <tfoot>
        <tr>
            <td colspan="2">&nbsp;</td>
        </tr>
    </tfoot>
</table>
