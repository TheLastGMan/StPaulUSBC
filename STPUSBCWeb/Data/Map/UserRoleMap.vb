Imports System.Data.Entity.ModelConfiguration
Namespace Map

    Public Class UserRoleMap : Inherits EntityTypeConfiguration(Of Entity.UserRole)

        Public Sub New()
            With Me
                .ToTable(Context.DBPrefix & "UserRole")
                .HasKey(Function(ur) ur.Id)
                .Property(Function(ur) ur.Id).HasDatabaseGeneratedOption(DataAnnotations.Schema.DatabaseGeneratedOption.Identity)
            End With
        End Sub

    End Class

End Namespace
