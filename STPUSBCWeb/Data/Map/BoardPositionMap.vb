Imports System.Data.Entity.ModelConfiguration
Namespace Map

    Public Class BoardPositionMap : Inherits EntityTypeConfiguration(Of Entity.BoardPosition)

        Public Sub New()
            With Me
                .ToTable(Context.DBPrefix & "BoardPosition")
                .HasKey(Function(bp) bp.Id)
                .Property(Function(bp) bp.Description).IsRequired.HasMaxLength(64)
                .Property(Function(bp) bp.Visible).IsRequired()
                .Property(Function(bp) bp.Order).IsRequired()
            End With
        End Sub

    End Class

End Namespace
