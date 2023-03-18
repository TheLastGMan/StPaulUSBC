Imports FluentValidation
Imports Web.Models.Account
Namespace Validation.Account

    Public Class CreateUserValidator : Inherits AbstractValidator(Of UserCreateModel)

        Public Sub New(loc As Core.ILocalization)

            RuleFor(Function(u) u.FirstName).Length(1, 999).WithMessage(loc.Msg("Account.Create.FirstName.Invalid"))
            RuleFor(Function(u) u.LastName).Length(1, 999).WithMessage(loc.Msg("Account.Create.LastName.Invalid"))
            RuleFor(Function(u) u.Username).Length(1, 999).WithMessage(loc.Msg("Account.Create.Username.Invalid"))
            RuleFor(Function(u) u.Password).Length(1, 64).WithMessage(loc.Msg("Account.Create.Password.Invalid"))
            RuleFor(Function(u) u.ConfirmPassword).Equal(Function(u) u.Password).WithMessage(loc.Msg("Account.Create.ConfirmPassword.Invalid"))

        End Sub

    End Class

End Namespace
