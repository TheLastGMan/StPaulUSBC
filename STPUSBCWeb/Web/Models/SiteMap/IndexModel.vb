Namespace Models.SiteMap

    Public Class IndexModel

        Public Property Navigation As New List(Of Data.Entity.HomeLink)
        Public Property Links As New List(Of Data.Entity.Link)
        Public Property Pages As New List(Of Data.Entity.Topic)
        Public Property HOF As New List(Of Data.Entity.HallOfFame)
        Public Property Honors As New List(Of Data.Entity.Honor)
        Public Property Tournaments As New List(Of Data.Entity.Tournament)
        Public Property Board As New List(Of Data.Entity.Board)

    End Class

End Namespace