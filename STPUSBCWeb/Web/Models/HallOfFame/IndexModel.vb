Namespace Models.HallOfFame

    Public Class IndexModel

        Public Property hoflist As List(Of Core.HOF_BriefModel)
        Public Property AchievedFormat As String = "yyyy"

        Public Property SortMethod As Core.Services.HallOfFame.SortMethod

    End Class

End Namespace
