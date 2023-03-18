Public Interface IBoardHistory : Inherits ICrudInterface(Of Data.Entity.BoardHistory)

    Function ById(ByRef guid As String) As Data.Entity.BoardHistory
    Function HigherTermEnd(ByRef min_endterm_year As Short) As List(Of Data.Entity.BoardHistory)
    Function BoardTermList(Optional ByVal OnlyVisible As Boolean = True) As List(Of Data.Entity.BoardHistory)

End Interface