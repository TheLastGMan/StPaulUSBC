Public Interface IRole : Inherits ICrudInterface(Of Data.Entity.Role)

    Function ById(ByRef id As Integer) As Data.Entity.Role
    Function ByName(ByRef name As String) As Data.Entity.Role

End Interface
