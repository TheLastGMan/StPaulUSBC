Imports System.Data.Entity.ModelConfiguration
Namespace Map

    Public Class LinkMap : Inherits EntityTypeConfiguration(Of Entity.Link)

        Public Sub New()
            With Me
                .ToTable(Context.DBPrefix & "Link")
                .HasKey(Function(l) l.Id)
                .Property(Function(l) l.Id).HasDatabaseGeneratedOption(DataAnnotations.Schema.DatabaseGeneratedOption.Identity)
                .Property(Function(l) l.Name).IsRequired.HasMaxLength(64)
                .Property(Function(l) l.Url).IsRequired.IsMaxLength()
                .Property(Function(l) l.Order).IsRequired()
                .Property(Function(l) l.CreatedUtc).IsRequired()
            End With
        End Sub

    End Class

End Namespace
