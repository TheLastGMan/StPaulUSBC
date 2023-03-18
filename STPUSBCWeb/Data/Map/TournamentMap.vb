Imports System.Data.Entity.ModelConfiguration
Namespace Map

    Public Class TournamentMap : Inherits EntityTypeConfiguration(Of Entity.Tournament)

        Public Sub New()
            With Me
                .ToTable(Context.DBPrefix & "Tournament")
                .HasKey(Function(t) t.Id)
                .Property(Function(t) t.Id).HasDatabaseGeneratedOption(DataAnnotations.Schema.DatabaseGeneratedOption.Identity)
                .Property(Function(t) t.EventName).IsRequired.HasMaxLength(64)
                .Property(Function(t) t.EventUrl).IsOptional.HasMaxLength(256)
                .Property(Function(t) t.Center).IsRequired.HasMaxLength(64)
                .Property(Function(t) t.Contact).IsOptional.HasMaxLength(64)
                .Property(Function(t) t.ContactEmail).IsOptional.HasMaxLength(256)
                .Property(Function(t) t.Start_Date).IsRequired()
                .Property(Function(t) t.End_Date).IsOptional()
                .Property(Function(t) t.RegistrationClose).IsOptional()
                .Property(Function(t) t.AddedUtc).IsOptional()
                '.Property(Function(t) t.RegistrationLink).HasMaxLength(256).IsOptional()
                '.Property(Function(t) t.IsFull).IsRequired()
                '.Property(Function(t) t.WriteUp).IsMaxLength().IsOptional()
            End With
        End Sub

    End Class

End Namespace
