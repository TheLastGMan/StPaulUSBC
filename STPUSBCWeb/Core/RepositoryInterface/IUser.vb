Public Interface IUser : Inherits ICrudInterface(Of Data.Entity.User)

    Function ByUsername(ByRef username As String) As Data.Entity.User
    Function ByUsernamePassword(ByRef username As String, ByRef password As String) As Data.Entity.User
    Function ById(ByRef id As Integer) As Data.Entity.User

End Interface
