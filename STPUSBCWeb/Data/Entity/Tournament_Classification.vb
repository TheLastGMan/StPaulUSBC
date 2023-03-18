Namespace Entity

    Public Class Tournament_Classification

        Public Property Id As Integer
        Public Property Description As String
        Public Property Show As Boolean = True

        Public Overridable Property Tournament As ICollection(Of Tournament)
    End Class

End Namespace
