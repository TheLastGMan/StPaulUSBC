Imports System.Data.Entity.ModelConfiguration
Namespace Map

    Public Class HonorMap : Inherits EntityTypeConfiguration(Of Entity.Honor)

        Public Sub New()
            With Me
                .ToTable(Context.DBPrefix & "Honor")
                .HasKey(Function(h) h.Id)
                .Property(Function(h) h.Id).HasDatabaseGeneratedOption(DataAnnotations.Schema.DatabaseGeneratedOption.Identity)
                .Property(Function(h) h.LastName).IsRequired.HasMaxLength(64)
                .Property(Function(h) h.FirstName).IsRequired.HasMaxLength(64)
                .Property(Function(h) h.Series).IsOptional()
                .Property(Function(h) h.Game1).IsOptional()
                .Property(Function(h) h.Game2).IsOptional()
                .Property(Function(h) h.Game3).IsOptional()
                .Property(Function(h) h.AddedUtc).IsRequired()

                .Ignore(Function(h) h.FormattedName)
                .Ignore(Function(h) h.GameSum)
            End With
        End Sub

    End Class

End Namespace
