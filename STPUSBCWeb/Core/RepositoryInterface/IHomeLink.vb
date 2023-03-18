Public Interface IHomeLink : Inherits ICrudInterface(Of Data.Entity.HomeLink)

    Function GetAll(Optional ByVal OnlyVisible As Boolean = True) As List(Of Data.Entity.HomeLink)
    Function ById(ByRef guid As String) As Data.Entity.HomeLink

End Interface
