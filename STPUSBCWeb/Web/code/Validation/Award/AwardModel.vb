Imports FluentValidation
Imports Web.Models.Award
Namespace Validation.Award

    Public Class AwardModelValidator : Inherits AbstractValidator(Of AwardModel)

        Public Sub New(loc As Core.ILocalization)

            RuleFor(Function(o) o.Center).Length(1, 64).WithMessage(loc.Msg("Award.AwardModel.Center.Error"))
            RuleFor(Function(o) o.League).Length(1, 64).WithMessage(loc.Msg("Award.AwardModel.League.Error"))
            RuleFor(Function(o) o.BowlerName).Length(1, 64).WithMessage(loc.Msg("Award.AwardModel.BowlerName.Error"))
            RuleFor(Function(o) o.DateBowled).GreaterThan(New Date).WithMessage(loc.Msg("Award.AwardModel.DateBowled.Error"))
            RuleFor(Function(o) o.USBCID).Matches("[0-9]{1,}-[0-9]{1,}").WithMessage(loc.Msg("Award.AwardModel.USBCID.Invalid"))
            RuleFor(Function(o) o.USBCID).Length(1, 32).WithMessage(loc.Msg("Award.AwardModel.USBCID.Error"))
            RuleFor(Function(o) o.BowlerAverage).InclusiveBetween(0, 300).WithMessage(loc.Msg("Award.AwardModel.BowlerAverage.Error"))
            RuleFor(Function(o) o.BowlerGames).InclusiveBetween(1, 255).WithMessage(loc.Msg("Award.AwardModel.BowlerGames.Error"))
            RuleFor(Function(o) o.Game1).InclusiveBetween(0, 300).WithMessage(loc.Msg("Award.AwardModel.Game1.Error"))
            RuleFor(Function(o) o.Game2).InclusiveBetween(0, 300).WithMessage(loc.Msg("Award.AwardModel.Game2.Error"))
            RuleFor(Function(o) o.Game3).InclusiveBetween(0, 300).WithMessage(loc.Msg("Award.AwardModel.Game3.Error"))
            RuleFor(Function(o) o.Series).InclusiveBetween(1, 900).WithMessage(loc.Msg("Award.AwardModel.Series.Error"))

            RuleFor(Function(o) o.SecretaryPin).Length(1, 32).WithMessage(loc.Msg("Award.AwardModel.SecretaryPin.Error"))
            RuleFor(Function(o) o.SecretaryName).Length(1, 64).WithMessage(loc.Msg("Award.AwardModel.SecretaryName.Error"))
            RuleFor(Function(o) o.SecretaryPhone).Matches("1?\W*([2-9][0-8][0-9])\W*([2-9][0-9]{2})\W*([0-9]{4})(\se?x?t?(\d*))?").WithMessage(loc.Msg("Award.AwardModel.SecretaryPhone.Invalid"))
            RuleFor(Function(o) o.SecretaryEmail).EmailAddress.Length(0, 128).WithMessage(loc.Msg("Award.AwardModel.SecretaryEmail.Invalid"))

        End Sub

    End Class

End Namespace
