Imports System.ComponentModel.DataAnnotations
Imports FluentValidation.Attributes
Namespace Models.Account

    Public Class EditModel

        Public Property RoleList As New List(Of EditUserRole)
        Public Property User As Data.Entity.User

    End Class

    Public Class CreateModel
        Public Property RoleList As New List(Of EditUserRole)
        Public Property User As New UserCreateModel
    End Class

    Public Structure EditUserRole
        Public Property RoleKey As String
        Public Property InRole As Boolean
    End Structure

End Namespace
