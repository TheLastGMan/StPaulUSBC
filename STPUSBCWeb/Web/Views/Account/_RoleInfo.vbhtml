@ModelType Dictionary(Of String, Boolean)
@code
    Layout = Nothing
    Dim i As Integer = 0
End Code

<table id="userroleinfo" >
    <thead>
        <tr>
            <td>@Html.Localize("Account.RoleInfo.RoleTitle")</td>
            <td>@Html.Localize("Account.RoleInfo.StatusTitle")</td>
        </tr>
    </thead>
    <tbody>
        @For Each ra In Model
            i += 1
            @<tr class="@(iif(i mod 2, "odd", "even"))-line">
                <td>
                    @(ra.Key) :&nbsp;
                </td>
                <td>
                    @(ra.Value.ToString)
                </td>
             </tr>
        Next
    </tbody>
    <tfoot>
        <tr>
            <td colspan="2">&nbsp;</td>
        </tr>
    </tfoot>
</table>