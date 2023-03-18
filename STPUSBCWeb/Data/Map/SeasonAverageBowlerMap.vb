Imports System.Data.Entity.ModelConfiguration
Namespace Map

    Public Class SeasonAverageBowlerMap : Inherits EntityTypeConfiguration(Of Entity.SeasonAverageBowler)

        Public Sub New()
            With Me
                .ToTable(Context.DBPrefix & "SeasonAverageBowler")
                .HasKey(Function(sa) sa.Id)
                .Property(Function(sa) sa.Id).IsRequired().HasMaxLength(32)
                .Property(Function(sa) sa.LastName).IsRequired.HasMaxLength(32)
                .Property(Function(sa) sa.FirstName).IsRequired.HasMaxLength(32)
                .Property(Function(sa) sa.MI).IsOptional.HasMaxLength(32)
                .Property(Function(sa) sa.Suffix).IsOptional.HasMaxLength(8)

                .Ignore(Function(sa) sa.SeasonAverages)
                .Ignore(Function(sa) sa.FullName)
            End With
        End Sub

    End Class

End Namespace