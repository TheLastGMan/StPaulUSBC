Imports System.ComponentModel.DataAnnotations
Imports FluentValidation.Attributes
Namespace Models.Board

    <Validator(GetType(Validation.Board.BoardValidator))>
    Public Class BoardModel

        Public Property Id As Guid
        Public Property FirstName As String
        Public Property LastName As String
        Public Property Visible As Boolean = True

    End Class

End Namespace
