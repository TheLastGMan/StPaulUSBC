Namespace Models.HonorScore

    Public Class ScoreView

        Public Property Title As String
        Public Property Scores As IEnumerable(Of IGrouping(Of String, Data.Entity.Honor))
        ' Public Property Scores As New List(Of Data.Entity.Honor)
        Public Property AchievedFormat As String = "MMM-dd-yyyy"
        Public Property LastUpdated As DateTime?

        Public Property CategorySEO As String
        Public Property CategoryFULL As String
        Public Property TypeSEO As String
        Public Property TypeFULL As String
        Public Property PageInfo As New Common.PageInfoModel

    End Class

End Namespace
