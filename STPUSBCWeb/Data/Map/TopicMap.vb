Imports System.Data.Entity.ModelConfiguration
Namespace Map

    Public Class TopicMap : Inherits EntityTypeConfiguration(Of Entity.Topic)

        Public Sub New()
            With Me
                .ToTable(Context.DBPrefix & "Topic")
                .HasKey(Function(t) t.Id)
                .Property(Function(t) t.Id).HasDatabaseGeneratedOption(DataAnnotations.Schema.DatabaseGeneratedOption.Identity)
                .Property(Function(t) t.seo).HasMaxLength(128).IsRequired()
                .Property(Function(t) t.content).IsMaxLength.IsRequired()
                .Property(Function(t) t.active).IsRequired()
                .Property(Function(t) t.createdutc).IsRequired()
                .Property(Function(t) t.updatedutc).IsRequired()
                .Property(Function(t) t.TopicTypeId).IsRequired()

                .Ignore(Function(t) t.TopicType)
                .Ignore(Function(t) t.SeoFriendly)
            End With
        End Sub

    End Class

End Namespace
