@ModelType Web.Models.Board.IndexModel
@Code
    ViewData("Title") = Html.TitleMaker(Html.Localize("Board.Index.URLTitle").ToString)
End Code

<h1>@Html.Localize("Board.Index.Title")</h1>
@Html.Widget("board_index")
<br />
<div id="boardcontainer">
@For Each board_desc In Model.BoardHistory.Select(Function(f) f.BoardPosition.Description).Distinct
    @<h2>@(board_desc)</h2>
    Dim lst = Model.BoardHistory.Where(Function(f) f.BoardPosition.Description = board_desc).OrderByDescending(Function(f) f.TermEnd).ThenBy(Function(f) f.Board.FormattedName).Select(Function(f) f.Board.Id).Distinct
    For i As Integer = 1 To lst.Count
        Dim bp = Model.BoardHistory.Where(Function(f) f.BoardId = lst(i-1)).OrderByDescending(Function(f) f.TermEnd).FirstOrDefault
        @<div class="boardbox @(iif(i mod 2, "odd", "even"))-line">
            <h3>@(Html.ActionLink(bp.Board.FormattedName, "Profile", New With {.id = bp.BoardId.ToString}))</h3>
            @(bp.TermStart.ToString(Model.TermFormat)) to @(bp.TermEnd.ToString(Model.TermFormat))
         </div>
    Next
Next
</div>
@If Model.BoardHistory.Count = 0 Then
    @<h2 style="text-align:center;">@Html.Localize("Board.Index.NoData")</h2>
End If

<div style="float:left; width:100%;">
    @Html.LastUpdated(Model.LastUpdated)
</div>
