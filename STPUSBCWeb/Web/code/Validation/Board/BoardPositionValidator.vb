Imports FluentValidation
Imports Web.Models.Board
Namespace Validation.Board

    Public Class BoardPositionValidator : Inherits AbstractValidator(Of BoardPositionModel)

        Public Sub New(loc As Core.ILocalization)

            RuleFor(Function(b) b.Description).Length(1, 64).WithMessage(loc.Msg("Board.Position.Description.Required"))

        End Sub

    End Class

End Namespace
