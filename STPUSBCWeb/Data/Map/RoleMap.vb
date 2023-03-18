Imports System.Data.Entity.ModelConfiguration
Namespace Map

    Public Class RoleMap : Inherits EntityTypeConfiguration(Of Entity.Role)

        Public Sub New()
            With Me
                .ToTable(Context.DBPrefix & "Role")
                .HasKey(Function(r) r.Id)
                .Property(Function(r) r.RowGuid).HasDatabaseGeneratedOption(DataAnnotations.Schema.DatabaseGeneratedOption.Computed)
                .Property(Function(r) r.Name).IsRequired.HasMaxLength(128)
            End With
        End Sub

    End Class

End Namespace
