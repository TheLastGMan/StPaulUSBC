Imports System.Data.Entity.ModelConfiguration
Namespace Map

    Public Class HonorTypeMap : Inherits EntityTypeConfiguration(Of Entity.HonorType)

        Public Sub New()
            With Me
                .ToTable(Context.DBPrefix & "HonorType")
                .HasKey(Function(h) h.Id)
                .Property(Function(h) h.Description).IsRequired.HasMaxLength(64)
                .Property(Function(h) h.AddedUtc).IsRequired()
                .Property(Function(h) h.SEO).IsRequired().HasMaxLength(16)
                .Property(Function(h) h.Active).IsRequired()
            End With
        End Sub

    End Class

End Namespace