Namespace Models.Topic

    Public Class ManageModel

        Public Property Topics As New List(Of Data.Entity.Topic)
        Public Property LastUpdated As DateTime?
        Public Property UpdatedFormat As String = "MMM-dd-yyyy"
        Public Property seoid As Integer = 1

    End Class

End Namespace
