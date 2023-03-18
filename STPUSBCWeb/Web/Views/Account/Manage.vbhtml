@ModelType List(Of Data.Entity.User)
@Code
    ViewData("Title") = Html.TitleMaker(Html.Localize("Account.Manage.Title").ToString)
End Code

<h1>@Html.Localize("Account.Manage.Title")</h1>
<div class="clearblank4"></div>
<div style="text-align:center;">
    <a href="@Url.Action("Create")" class="linkbutton submit-gold">
        @Html.Localize("Account.Manage.Create")
    </a>
</div>
<table id="manageusers">
    <thead>
        <tr>
            <td>@Html.Localize("Account.Manage.NameTitle")</td>
            <td>@Html.Localize("Account.Manage.UserNameTitle")</td>
            <td class="hidemobile">@Html.Localize("Account.Manage.LastLoginTitle")</td>
            <td>@Html.Localize("Account.Manage.EditTitle")</td>
            <td>@Html.Localize("Account.Manage.LockUnlockTitle")</td>
            <td>@Html.Localize("Account.Manage.ActivationTitle")</td>
        </tr>
    </thead>
    <tbody>
        @For i As Integer = 1 To Model.Count
            Dim up = Model(i - 1)
            @<tr class="@(IIf(i Mod 2, "odd", "even"))-line">
                <td>@String.Format("{0} {1}", up.FirstName, up.LastName)</td>
                <td>@up.Username</td>
                <td class="hidemobile">@(up.last_login_utc.ToString("MMM-dd-yyyy"))</td>
                <td>
                    <a href="@Url.Action("Edit", New With {.id = up.Id})" class="linkbutton submit-green">
                        @Html.Localize("Account.Manage.EditSubmit")
                    </a>
                </td>
                <td>
                    @If Not User.Identity.Name = up.Username Then
                        Using Html.BeginForm("LockChange", "Account")
                    @Html.Hidden("id", up.Id)
                    @Html.Hidden("status", IIf(up.login_count > 3, 0, 4))
                    @<input type="submit" value="@(IIf(up.login_count > 3, Html.Localize("Account.Manage.LockUnlock.UnLock"), Html.Localize("Account.Manage.LockUnlock.Lock")))" class="submit-@(IIf(up.login_count > 0, "", "lt"))gold" />
                        End Using
                    End If
                </td>
                <td>
                    @If Not User.Identity.Name = up.Username Then
                        Using Html.BeginForm("ActivateChange", "Account")
                    @Html.Hidden("id", up.Id)
                    @Html.Hidden("status", Not up.active)
                    @<input type="submit" value="@(IIf(up.active, Html.Localize("Account.Manage.Activation.DeActivate"), Html.Localize("Account.Manage.Activation.Activate")))" class="submit-@(IIf(up.active, "lt", ""))gold" />
                        End Using
                    Else
                    @<span>&nbsp;</span>
                    End If
                </td>
            </tr>
        Next
    </tbody>
    <tfoot>
        <tr>
            <td colspan="6"></td>
        </tr>
    </tfoot>
</table>
