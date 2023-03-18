@ModelType data.Entity.Board
@Code
    ViewData("Title") = Html.TitleMaker(Html.Localize("Board.Profile.URLTitle").ToString, String.Format("{0} {1}", Model.FirstName, Model.LastName))
    Dim positions = Model.BoardHistory.OrderByDescending(Function(f) f.TermEnd)
End Code

<h1>@Html.Localize("Board.Profile.Title")</h1>
<h1>@(Model.FormattedName)</h1>
<div id="boardcontainer">
    @For i As Integer = 1 To positions.Count
        Dim bp = positions(i - 1)
        @<div class="boardbox @(iif(i mod 2, "odd", "even"))-line">
                <h2>@bp.BoardPosition.Description</h2>
                @bp.TermStart.ToString("MMM-dd-yyyy") to @bp.TermEnd.ToString("MMM-dd-yyyy")
         </div>
    Next
</div>