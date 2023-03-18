Public Interface IAccountService

    Function LogIn(ByRef username As String, ByRef password As String) As LogInResult
    Function ResetLogInCount(ByRef username As String) As Boolean
    Function IncrementLogInCount(ByRef username As String) As Boolean
    Function UpdatePassword(ByRef id As Integer, ByRef password As String) As Boolean
    Function ManageRoles(ByRef id As Integer, ByRef userroles As Dictionary(Of String, Boolean)) As Boolean

End Interface
