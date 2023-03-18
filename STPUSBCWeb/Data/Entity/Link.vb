Namespace Entity

    Public Class Link

        Public Property Id As Guid
        Public Property Name As String
        Public Property Url As String
        Public Property Visible As Boolean = True
        Public Property Order As Short
        Public Property CreatedUtc As DateTime = Now.ToUniversalTime

    End Class

End Namespace
