Namespace Models.Account

    Public Class ProfileModel

        Public Property User As New Data.Entity.User
        Public Property Roles As New Dictionary(Of String, Boolean)

    End Class

End Namespace
