Imports System.Data.Entity.ModelConfiguration
Namespace Map

    Public Class SettingMap : Inherits EntityTypeConfiguration(Of Entity.Setting)

        Public Sub New()
            With Me
                .ToTable(Context.DBPrefix & "Setting")
                .HasKey(Function(s) s.Id)
                .Property(Function(s) s.Key).IsRequired.HasMaxLength(256)
                .Property(Function(s) s.Value).IsRequired.HasMaxLength(1024)
            End With
        End Sub

    End Class

End Namespace
