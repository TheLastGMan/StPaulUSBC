Namespace Models.Board

    Public Class IndexModel

        Public Property BoardHistory As List(Of Data.Entity.BoardHistory)
        Public Property LastUpdated As DateTime?
        Public Property TermFormat As String = "MMM-yyyy"

    End Class

End Namespace
