Namespace Models.Board

    Public Class BoardHistoryEditModel

        Public Property BoardHistoryList As New List(Of Data.Entity.BoardHistory)
        Public Property PositionLst As New List(Of Data.Entity.BoardPosition)
        Public Property BoardId As Guid

    End Class

End Namespace
