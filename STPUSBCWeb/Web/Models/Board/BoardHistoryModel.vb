Imports System.ComponentModel.DataAnnotations
Imports FluentValidation.Attributes
Namespace Models.Board

    <Validator(GetType(Validation.Board.BoardHistoryValidator))>
    Public Class BoardHistoryModel

        Public Property Id As Guid
        Public Property TermStart As Date = New Date
        Public Property TermEnd As Date = New Date
        Public Property BoardPositionId As Integer
        Public Property BoardId As String

    End Class

End Namespace
