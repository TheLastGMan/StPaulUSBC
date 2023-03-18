Imports System.Data.Entity.ModelConfiguration
Namespace Map

    Public Class HallOfFameMap : Inherits EntityTypeConfiguration(Of Entity.HallOfFame)

        Public Sub New()
            With Me
                .ToTable(Context.DBPrefix & "HallOfFame")
                .HasKey(Function(h) h.Id)
                .Property(Function(h) h.RowGuid).IsRequired()
                .Property(Function(h) h.FirstName).IsRequired.HasMaxLength(128)
                .Property(Function(h) h.LastName).IsRequired.HasMaxLength(128)
                .Property(Function(h) h.Deceased).IsRequired()
                .Property(Function(h) h.Achieved).IsRequired()
                .Property(Function(h) h.USBC_ID).IsOptional.HasMaxLength(24)
                .Property(Function(h) h.Picture).IsOptional().HasColumnType("image")
                .Property(Function(h) h.PictureMime).IsOptional().HasMaxLength(4)
                .Property(Function(h) h.WriteUp).IsRequired.IsMaxLength()
                .Property(Function(h) h.Display).IsRequired()
                .Property(Function(h) h.CreatedUtc).IsRequired()
                .Property(Function(h) h.LastUpdatedUtc).IsRequired()
            End With
        End Sub

    End Class

End Namespace
