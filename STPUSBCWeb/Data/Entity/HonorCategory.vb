Namespace Entity

    Public Class HonorCategory

        Public Property Id As Integer
        Public Property Description As String
        Public Property SEO As String
        Public Property Order As Byte
        Public Property Active As Boolean = True

        Public Overridable Property Honor As ICollection(Of Honor)

    End Class

End Namespace
