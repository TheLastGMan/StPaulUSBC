Namespace Entity

    Public Class AwardType

        Public Property Id As Integer
        Public Property Description As String

        Public Overridable Property AwardName As ICollection(Of AwardName)
    End Class

End Namespace
