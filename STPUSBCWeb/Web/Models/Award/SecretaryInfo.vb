Imports System.ComponentModel.DataAnnotations
Imports FluentValidation.Attributes
Namespace Models.Award

    <Validator(GetType(Validation.Award.SecretaryModel))>
    Public Class SecretaryInfo

        Public Property AwardId As Guid

        Public Property SecretaryName As String
        Public Property SecretaryEmail As String
        Public Property SecretaryPin As String
        Public Property SecretaryPhone As String

    End Class

End Namespace
