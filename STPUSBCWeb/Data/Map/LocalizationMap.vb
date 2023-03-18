Imports System.Data.Entity.ModelConfiguration
Namespace Map

    Public Class LocalizationMap : Inherits EntityTypeConfiguration(Of Entity.Localization)

        Public Sub New()
            With Me
                .ToTable(Context.DBPrefix & "Localization")
                .HasKey(Function(l) l.Id)
                .Property(Function(l) l.Id).HasDatabaseGeneratedOption(DataAnnotations.Schema.DatabaseGeneratedOption.Identity)
                .Property(Function(l) l.Key).IsRequired.HasMaxLength(256)
                .Property(Function(l) l.Value).IsRequired.HasMaxLength(1024)
            End With
        End Sub

    End Class

End Namespace
