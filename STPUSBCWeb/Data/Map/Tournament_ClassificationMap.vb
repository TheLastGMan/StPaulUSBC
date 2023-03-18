Imports System.Data.Entity.ModelConfiguration
Namespace Map

    Public Class Tournament_ClassificationMap : Inherits EntityTypeConfiguration(Of Entity.Tournament_Classification)

        Public Sub New()
            With Me
                .ToTable(Context.DBPrefix & "Tournament_Classification")
                .HasKey(Function(t) t.Id)
                .Property(Function(t) t.Description).IsRequired.HasMaxLength(32)
                .Property(Function(t) t.Show).IsRequired()
            End With
        End Sub

    End Class

End Namespace
