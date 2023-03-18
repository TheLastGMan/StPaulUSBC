@code
    Layout = Nothing
End Code

<div id="footer">
    Copyright &copy; 2012 - @Now.ToUniversalTime.Year | <a href="http://www.rpgcor.com" target="_blank">RPGCor</a> |
    @If User.Identity.IsAuthenticated Then
        @<a href="mailto:ryanpgau@gmail.com?Subject=STPBowl">Ryan Gau</a>
    Else
        @<span>Ryan Gau</span>
    End If
    <br />
    @Html.Localize("Shared.Footer.VersionText") @Html.Version()
</div>