Imports FluentValidation
Imports Web.Models.Board
Namespace Validation.Board

    Public Class BoardHistoryValidator : Inherits AbstractValidator(Of BoardHistoryModel)

        Public Sub New(loc As Core.ILocalization)

            RuleFor(Function(b) b.TermStart).GreaterThan(New Date).WithMessage(loc.Msg("Board.History.TermStart.Invalid"))
            RuleFor(Function(b) b.TermEnd).GreaterThan(New Date).WithMessage(loc.Msg("Board.History.TermEnd.Invalid"))

        End Sub

    End Class

End Namespace
