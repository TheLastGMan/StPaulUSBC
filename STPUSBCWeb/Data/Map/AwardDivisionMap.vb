Imports System.Data.Entity.ModelConfiguration
Namespace Map

    Public Class AwardDivisionMap : Inherits EntityTypeConfiguration(Of Entity.AwardDivision)

        Public Sub New()
            With Me
                .ToTable(Context.DBPrefix & "AwardDivision")
                .HasKey(Function(a) a.Id)
                .Property(Function(a) a.Description).IsRequired.HasMaxLength(128)
            End With
        End Sub

    End Class

End Namespace
