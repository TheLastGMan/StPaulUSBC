Namespace Models.Tournament

    Public Class EMailModel
        Public Property TournamentId As String = String.Empty
        Public Property ContactName As String = String.Empty
        Public Property ToEmail As String = String.Empty
        Public Property Subject As String = String.Empty
        Public Property FromEMail As String = String.Empty
        Public Property FromName As String = String.Empty
        Public Property Body As String = String.Empty

        Public Property SendError As Boolean
        Public Property SendErrorMessage As String = String.Empty
    End Class

End Namespace
