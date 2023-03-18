Public Interface ILink : Inherits ICrudInterface(Of Data.Entity.Link)

    Function ById(ByRef id As String) As Data.Entity.Link
    Function GetAll(Optional ByVal OnlyVisible As Boolean = True) As List(Of Data.Entity.Link)

End Interface
