Public Interface IBoard : Inherits ICrudInterface(Of Data.Entity.Board)

    Function ById(ByRef guid As String) As Data.Entity.Board
    Function LastUpdated() As Date

End Interface
