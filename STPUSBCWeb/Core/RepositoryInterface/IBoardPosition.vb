Public Interface IBoardPosition : Inherits ICrudInterface(Of Data.Entity.BoardPosition)

    Function ById(ByRef id As Integer) As Data.Entity.BoardPosition

End Interface
