Namespace Entity

    Public Class Honor

        Public Property Id As Guid
        Public Property LastName As String
        Public Property FirstName As String
        Public Property Achieved As DateTime
        Public Property Series As Short = -1
        Public Property Game1 As Short = -1
        Public Property Game2 As Short = -1
        Public Property Game3 As Short = -1
        Public Property AddedUtc As DateTime = Now.ToUniversalTime

        Public Property HonorTypeId As Integer?
        Public Overridable Property HonorType As HonorType

        Public Property HonorCategoryId As Integer?
        Public Overridable Property HonorCategory As HonorCategory

        Public ReadOnly Property FormattedName As String
            Get
                Return LastName & ", " & FirstName
            End Get
        End Property

        Public ReadOnly Property GameSum As Short
            Get
                Return Game1 + Game2 + Game3
            End Get
        End Property

    End Class

End Namespace
