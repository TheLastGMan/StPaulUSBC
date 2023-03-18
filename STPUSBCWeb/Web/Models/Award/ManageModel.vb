Namespace Models.Award

    Public Class ManageModel

        Public Property Id As Guid

        Public Property BowlerName As String
        Public Property USBCID As String
        Public Property AddedUTC As DateTime
        Public Property SecretaryName As String
        Public Property SecretaryPin As String

        Public Property _confirmarchive As Boolean = False

    End Class

End Namespace
