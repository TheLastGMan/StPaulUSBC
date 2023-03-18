Imports System.Data.Entity.ModelConfiguration
Namespace Map

    Public Class BoardHistoryMap : Inherits EntityTypeConfiguration(Of Entity.BoardHistory)

        Public Sub New()
            With Me
                .ToTable(Context.DBPrefix & "BoardHistory")
                .HasKey(Function(bh) bh.Id)
                .Property(Function(bh) bh.Id).HasDatabaseGeneratedOption(DataAnnotations.Schema.DatabaseGeneratedOption.Identity)
                .Property(Function(bh) bh.TermStart).IsRequired()
                .Property(Function(bh) bh.TermEnd).IsRequired()
            End With
        End Sub

    End Class

End Namespace
