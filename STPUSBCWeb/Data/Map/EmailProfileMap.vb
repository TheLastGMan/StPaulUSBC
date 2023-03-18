Imports System.Data.Entity.ModelConfiguration
Namespace Map

    Public Class EmailProfileMap : Inherits EntityTypeConfiguration(Of Entity.EmailProfile)

        Public Sub New()
            With Me
                .ToTable(Context.DBPrefix & "EmailProfile")
                .HasKey(Function(ep) ep.Name)
                .Property(Function(ep) ep.Name).IsRequired().HasMaxLength(64)
                .Property(Function(ep) ep.UserName).IsRequired().HasMaxLength(128)
                .Property(Function(ep) ep.Password).IsRequired().HasMaxLength(64)
                .Property(Function(ep) ep.SmtpHost).IsRequired().HasMaxLength(128)
                .Property(Function(ep) ep.SendAs).IsRequired().HasMaxLength(128)
                .Property(Function(ep) ep.SmtpPort).IsRequired()
                .Property(Function(ep) ep.DisplayName).IsRequired().HasMaxLength(64)
            End With
        End Sub

    End Class

End Namespace
