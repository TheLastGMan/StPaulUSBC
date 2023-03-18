Namespace Entity

    Public Class User

        Public Property Id As Integer
        Public Property RowGuid As Guid = Guid.NewGuid
        Public Property FirstName As String
        Public Property LastName As String
        Public Property Username As String
        Public Property Password As String
        Public Property login_count As Integer = 0
        Public Property created_utc As DateTime
        Public Property last_login_utc As DateTime = Now.ToUniversalTime
        Public Property active As Boolean = True

    End Class

End Namespace
