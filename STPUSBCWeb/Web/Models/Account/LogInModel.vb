Imports System.ComponentModel.DataAnnotations
Imports FluentValidation.Attributes
Namespace Models.Account

    <Validator(GetType(Validation.Account.LogInValidator))>
    Public Class LogInModel

        Public Property Username As String
        Public Property Password As String

    End Class

End Namespace
