Imports System.Data.Entity.ModelConfiguration
Namespace Map

    Public Class UserMap : Inherits EntityTypeConfiguration(Of Entity.User)

        Public Sub New()
            With Me
                .ToTable(Context.DBPrefix & "User")
                .HasKey(Function(u) u.Id)
                .Property(Function(u) u.Id).HasDatabaseGeneratedOption(DataAnnotations.Schema.DatabaseGeneratedOption.Identity)
                .Property(Function(u) u.RowGuid).IsRequired().HasDatabaseGeneratedOption(DataAnnotations.Schema.DatabaseGeneratedOption.Identity)
                .Property(Function(u) u.FirstName).IsRequired.HasMaxLength(64)
                .Property(Function(u) u.LastName).IsRequired.HasMaxLength(64)
                .Property(Function(u) u.Username).IsRequired.HasMaxLength(64)
                .Property(Function(u) u.Password).IsRequired.HasMaxLength(192)
                .Property(Function(u) u.login_count).IsRequired()
                .Property(Function(u) u.created_utc).IsRequired()
                .Property(Function(u) u.last_login_utc).IsOptional()
                .Property(Function(u) u.active).IsRequired()
            End With
        End Sub

    End Class

End Namespace
