Namespace Models.Tournament

    Public Class IndexModel

        Public Property Tournaments As New List(Of Data.Entity.Tournament)
        Public Property StartDate_Format As String = "MMM-dd-yyyy"
        Public Property EndDate_Format As String = "MMM-dd-yyyy"

    End Class

End Namespace
