Imports FluentValidation
Imports Web.Models.Board
Namespace Validation.Board

    Public Class BoardValidator : Inherits AbstractValidator(Of BoardModel)

        Public Sub New(loc As Core.ILocalization)

            RuleFor(Function(b) b.FirstName).Length(1, 64).WithMessage(loc.Msg("Board.Manage.FirstName.Required"))
            RuleFor(Function(b) b.LastName).Length(1, 64).WithMessage(loc.Msg("Board.Manage.LastName.Required"))

        End Sub

    End Class

End Namespace
