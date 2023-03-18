Imports System.Data.Entity.ModelConfiguration
Namespace Map

    Public Class BoardMap : Inherits EntityTypeConfiguration(Of Entity.Board)

        Public Sub New()
            With Me
                .ToTable(Context.DBPrefix & "Board")
                .HasKey(Function(b) b.Id)
                .Property(Function(b) b.Id).HasDatabaseGeneratedOption(DataAnnotations.Schema.DatabaseGeneratedOption.Identity)
                .Property(Function(b) b.FirstName).IsRequired.HasMaxLength(64)
                .Property(Function(b) b.LastName).IsRequired.HasMaxLength(64)
                .Property(Function(b) b.Visible).IsRequired()
                .Property(Function(b) b.AddedUtc).IsRequired()
                .Property(Function(b) b.LastUpdatedUtc).IsRequired()

                .Ignore(Function(b) b.FormattedName)
            End With
        End Sub

    End Class

End Namespace
