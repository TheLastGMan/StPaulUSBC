Imports System.Data.Entity.ModelConfiguration
Namespace Map

    Public Class AwardNameMap : Inherits EntityTypeConfiguration(Of Entity.AwardName)

        Public Sub New()
            With Me
                .ToTable(Context.DBPrefix & "AwardName")
                .HasKey(Function(a) a.Id)
                .Property(Function(a) a.Id).HasDatabaseGeneratedOption(DataAnnotations.Schema.DatabaseGeneratedOption.Identity)
                .Property(Function(a) a.RowGuid).HasDatabaseGeneratedOption(DataAnnotations.Schema.DatabaseGeneratedOption.Identity)
                .Property(Function(a) a.Name).IsRequired.HasMaxLength(32)
                .Property(Function(a) a.AverageHigh).IsRequired()
                .Property(Function(a) a.Visible).IsRequired()
            End With
        End Sub

    End Class

End Namespace
