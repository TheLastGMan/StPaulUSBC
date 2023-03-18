Namespace Models.Award

    Public Class LocalAwards

        Public Property AwardId As Guid
        Public Property AwardTypeId As Integer

        Public Property LocalAwardLst As New List(Of AwardDualValue)
        Public Property AwardChoiceId As Integer
        Public Property AwardChoiceLst As New List(Of Data.Entity.AwardName)

    End Class

End Namespace
