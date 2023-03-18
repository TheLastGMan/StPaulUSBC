Namespace Entity

    Public Class UserRole

        Public Property Id As Guid = Guid.NewGuid
        Public Property UserId As Integer?
        Public Property RoleId As Integer?

        Public Overridable Property User As Entity.User
        Public Overridable Property Role As Entity.Role

    End Class

End Namespace

