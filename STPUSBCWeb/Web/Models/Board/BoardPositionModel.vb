Imports System.ComponentModel.DataAnnotations
Imports FluentValidation.Attributes
Namespace Models.Board

    <Validator(GetType(Validation.Board.BoardPositionValidator))>
    Public Class BoardPositionModel

        Public Property Id As Integer
        Public Property Description As String
        Public Property Visible As Boolean = True
        Public Property Order As Short

    End Class

End Namespace
