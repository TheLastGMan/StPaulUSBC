Imports System.ComponentModel.DataAnnotations
Imports FluentValidation.Attributes
Namespace Models.Account

    <Validator(GetType(Validation.Account.CreateUserValidator))>
     Public Class UserCreateModel

        Public Property Id As Integer
        Public Property FirstName As String
        Public Property LastName As String
        Public Property Username As String
        Public Property Password As String
        Public Property active As Boolean = True

        Public Property ConfirmPassword As String

    End Class

End Namespace
