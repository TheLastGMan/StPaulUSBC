Namespace Entity

    Public Class BoardHistory

        Public Property Id As Guid
        Public Property TermStart As Date
        Public Property TermEnd As Date

        Public Property BoardPositionId As Integer?
        Public Overridable Property BoardPosition As BoardPosition

        Public Property BoardId As Guid?
        Public Overridable Property Board As Board

    End Class

End Namespace
