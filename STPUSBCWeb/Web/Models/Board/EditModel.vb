Namespace Models.Board

    Public Class EditModel

        'Board Member Profile 
        Public Property Member As New BoardModel

        'Board History Info
        Public Property MemberHistory As New List(Of Data.Entity.BoardHistory)
        'History New
        Public Property BoardHistory As New BoardHistoryModel

        'Board Position DropDown List
        Public Property Positions As New List(Of Data.Entity.BoardPosition)

    End Class

End Namespace
