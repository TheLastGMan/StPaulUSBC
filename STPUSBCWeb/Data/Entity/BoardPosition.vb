Namespace Entity

    Public Class BoardPosition

        Public Property Id As Integer
        Public Property Description As String
        Public Property Visible As Boolean = True
        Public Property Order As Short

        Public Overridable Property BoardHistory As ICollection(Of BoardHistory)

    End Class

End Namespace
