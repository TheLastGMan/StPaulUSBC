Imports FluentValidation
Imports Web.Models.Award
Namespace Validation.Award

    Public Class BowlerModel : Inherits AbstractValidator(Of BowlerInfo)

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

        End Sub

    End Class

End Namespace

