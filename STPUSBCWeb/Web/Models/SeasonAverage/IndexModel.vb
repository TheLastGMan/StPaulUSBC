Namespace Models.SeasonAverage

    Public Class IndexModel

        Public Property SearchResults As New List(Of Core.SeasonAverageBowlerResult)
        Public Property TotalSearchResults As Integer

        'Search Fields
        Public Property FirstName As String
        Public Property LastName As String
        Public Property USBCID As String
        Public Property RanQuery As Boolean

    End Class

End Namespace
