Namespace Models.Award

    Public Class AwardOptionModel

        Public Property AwardOptions As New List(Of Data.Entity.AwardName)
        Public Property Divisions As New List(Of Data.Entity.AwardDivision)
        Public Property Types As New List(Of Data.Entity.AwardType)

    End Class

End Namespace
