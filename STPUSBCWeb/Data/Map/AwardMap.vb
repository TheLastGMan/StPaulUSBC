Imports System.ComponentModel.DataAnnotations.Schema
Imports System.Data.Entity.ModelConfiguration

Namespace Map

    Public Class AwardMap : Inherits EntityTypeConfiguration(Of Entity.Award)

        Public Sub New()
            With Me
                .ToTable(Context.DBPrefix & "Award")
                .HasKey(Function(a) a.Id)
                .Property(Function(a) a.Id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity)
                .Property(Function(a) a.Center).IsRequired.HasMaxLength(64)
                .Property(Function(a) a.League).IsRequired.HasMaxLength(64)
                .Property(Function(a) a.DateBowled).IsRequired()
                .Property(Function(a) a.BowlerName).IsRequired.HasMaxLength(64)
                .Property(Function(a) a.USBCID).IsRequired.HasMaxLength(32)
                .Property(Function(a) a.BowlerAverage).IsRequired()
                .Property(Function(a) a.BowlerGames).IsRequired()
                .Property(Function(a) a.Game1).IsRequired()
                .Property(Function(a) a.Game2).IsRequired()
                .Property(Function(a) a.Game3).IsRequired()
                .Property(Function(a) a.Series).IsRequired()
                .Property(Function(a) a.USBCAward).IsRequired.IsMaxLength()
                .Property(Function(a) a.LocalAward).IsRequired.IsMaxLength()
                .Property(Function(a) a.AdultAwardChoice).IsOptional.IsMaxLength()
                .Property(Function(a) a.SecretaryPin).IsRequired.HasMaxLength(32)
                .Property(Function(a) a.SecretaryName).IsRequired.HasMaxLength(64)
                .Property(Function(a) a.SecretaryPhone).IsOptional()
                .Property(Function(a) a.SecretaryEmail).IsOptional().HasMaxLength(128)
                .Property(Function(a) a.Submitted).IsRequired()
                .Property(Function(a) a.Archived).IsRequired()
                .Property(Function(a) a.AddedUTC).IsRequired()

                .Ignore(Function(a) a.USBCAwardList)
                .Ignore(Function(a) a.LocalAwardList)
            End With
        End Sub

    End Class

End Namespace
