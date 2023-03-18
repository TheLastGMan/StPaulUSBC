Namespace Entity

    Public Class SeasonAverage
        Public Property Id As Guid = Guid.NewGuid()
        Public Property SeasonAverageBowler_Id As String = String.Empty
        Public Property Season As String = String.Empty
        Public Property Average As Short = 0
        Public Property Games As Short = 0
        Public Property League As String = String.Empty
        Public Property Hand As String = String.Empty
    End Class

End Namespace
