Public Interface IUserRole : Inherits ICrudInterface(Of Data.Entity.UserRole)

    Function ByUserId(ByRef id As Integer) As List(Of Data.Entity.Role)
    Function ByRoleId(ByRef id As Integer) As List(Of Data.Entity.User)
    Function ByUserRole(ByRef uid As Integer, ByRef rid As Integer) As Data.Entity.UserRole

End Interface
