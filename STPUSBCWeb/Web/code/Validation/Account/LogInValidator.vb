Imports FluentValidation
Imports Web.Models.Account
Namespace Validation.Account

    Public Class LogInValidator : Inherits AbstractValidator(Of LogInModel)

        Public Sub New(loc As Core.ILocalization)

            RuleFor(Function(o) o.Username).NotEmpty.WithMessage(loc.Msg("Account.LogIn.UserName.Error"))
            RuleFor(Function(o) o.Username).Length(5, 64).WithMessage(loc.Msg("Account.LogIn.UserName.Invalid"))
            RuleFor(Function(o) o.Password).NotEmpty.WithMessage(loc.Msg("Account.LogIn.PassWord.Error"))
            RuleFor(Function(o) o.Password).Length(5, 64).WithMessage(loc.Msg("Account.Login.Password.Invalid"))

        End Sub

    End Class

End Namespace
