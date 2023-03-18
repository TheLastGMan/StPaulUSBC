Namespace Entity

    Public Class HallOfFame_RecognitionType

        Public Property Id As Integer
        Public Property Description As String
        Public Property Display As Boolean = True

        Public Overridable Property HallOfFame As ICollection(Of HallOfFame)
    End Class

End Namespace
