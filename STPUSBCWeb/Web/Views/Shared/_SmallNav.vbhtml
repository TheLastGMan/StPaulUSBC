@Code
    Layout = nothing
End Code

@If (User.Identity.IsAuthenticated) Then
    @<div id="admintab" class="showmobile">
        @Html.Action("AdminLinks", "Common")
     </div>
End If