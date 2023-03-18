Imports FluentValidation
Imports Web.Models.Award
Namespace Validation.Award

    Public Class SecretaryModel : Inherits AbstractValidator(Of SecretaryInfo)

        Public Sub New(loc As Core.ILocalization)
            RuleFor(Function(o) o.SecretaryPin).Length(1, 32).WithMessage(loc.Msg("Award.AwardModel.SecretaryPin.Error"))
            RuleFor(Function(o) o.SecretaryName).Length(1, 64).WithMessage(loc.Msg("Award.AwardModel.SecretaryName.Error"))
            RuleFor(Function(o) o.SecretaryPhone).Matches("1?\W*([2-9][0-8][0-9])\W*([2-9][0-9]{2})\W*([0-9]{4})(\se?x?t?(\d*))?").WithMessage(loc.Msg("Award.AwardModel.SecretaryPhone.Invalid"))
            RuleFor(Function(o) o.SecretaryEmail).EmailAddress.Length(0, 128).WithMessage(loc.Msg("Award.AwardModel.SecretaryEmail.Invalid"))
        End Sub

    End Class

End Namespace

