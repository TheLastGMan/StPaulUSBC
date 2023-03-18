Imports System.Data.Entity.ModelConfiguration

Namespace Map

    Public Class HallOfFame_RecognitionTypeMap : Inherits EntityTypeConfiguration(Of Entity.HallOfFame_RecognitionType)

        Public Sub New()
            With Me
                .ToTable(Context.DBPrefix & "HallOfFame_RecognitionType")
                .HasKey(Function(h) h.Id)
                .Property(Function(h) h.Description).IsRequired.HasMaxLength(64)
                .Property(Function(h) h.Display).IsRequired()
            End With
        End Sub

    End Class

End Namespace
