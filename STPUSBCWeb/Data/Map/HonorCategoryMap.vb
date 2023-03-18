Imports System.Data.Entity.ModelConfiguration
Namespace Map

    Public Class HonorCategoryMap : Inherits EntityTypeConfiguration(Of Entity.HonorCategory)

        Public Sub New()
            With Me
                .ToTable(Context.DBPrefix & "HonorCategory")
                .HasKey(Function(h) h.Id)
                .Property(Function(h) h.Description).HasMaxLength(32)
                .Property(Function(h) h.SEO).HasMaxLength(16)
                .Property(Function(h) h.Order).IsRequired()
                .Property(Function(h) h.Active).IsRequired()
            End With
        End Sub

    End Class

End Namespace