Namespace Entity

    Public Class HonorType

        Public Property Id As Integer
        Public Property Description As String
        Public Property AddedUtc As DateTime = Now.ToUniversalTime
        Public Property SEO As String
        Public Property Active As Boolean = True

        Public Overridable Property Honor As ICollection(Of Honor)

    End Class

End Namespace
