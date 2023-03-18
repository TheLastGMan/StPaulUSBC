Imports System.Data.Entity.ModelConfiguration
Namespace Map

    Public Class SeasonAverageMap : Inherits EntityTypeConfiguration(Of Entity.SeasonAverage)

        Public Sub New()
            With Me
                .ToTable(Context.DBPrefix & "SeasonAverage")
                .HasKey(Function(f) f.Id)
                .Property(Function(sa) sa.SeasonAverageBowler_Id).IsRequired.HasMaxLength(32)
                .Property(Function(sa) sa.Season).IsRequired().HasMaxLength(32)
                .Property(Function(sa) sa.Average).IsRequired()
                .Property(Function(sa) sa.Games).IsRequired()
                .Property(Function(sa) sa.League).IsOptional.HasMaxLength(8)
                .Property(Function(sa) sa.Hand).IsOptional.HasMaxLength(4)
            End With
        End Sub

    End Class

End Namespace