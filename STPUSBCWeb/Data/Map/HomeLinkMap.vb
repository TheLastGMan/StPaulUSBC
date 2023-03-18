Imports System.Data.Entity.ModelConfiguration
Namespace Map

    Public Class HomeLinkMap : Inherits EntityTypeConfiguration(Of Entity.HomeLink)

        Public Sub New()
            With Me
                .ToTable(Context.DBPrefix & "HomeLink")
                .HasKey(Function(h) h.Id)
                .Property(Function(h) h.Id).HasDatabaseGeneratedOption(DataAnnotations.Schema.DatabaseGeneratedOption.Identity)
                .Property(Function(h) h.DisplayText).IsRequired.HasMaxLength(32)
                .Property(Function(h) h.View).IsRequired.HasMaxLength(16)
                .Property(Function(h) h.Controller).IsRequired.HasMaxLength(32)
                .Property(Function(h) h.Order).IsRequired()
                .Property(Function(h) h.View).IsRequired()
            End With
        End Sub

    End Class

End Namespace
