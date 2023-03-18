Imports System.Data.Entity.ModelConfiguration
Namespace Map

    Public Class AwardTypeMap : Inherits EntityTypeConfiguration(Of Entity.AwardType)

        Public Sub New()
            With Me
                .ToTable(Context.DBPrefix & "AwardType")
                .HasKey(Function(a) a.Id)
                .Property(Function(a) a.Description).IsRequired.HasMaxLength(128)
            End With
        End Sub

    End Class

End Namespace
