Namespace Models.Common

    Public Class PageInfoModel

        Public Property CurrentPage As Integer
        Public Property TotalItems As Integer
        Public Property ItemsPerPage As Integer

        Public ReadOnly Property TotalPages As Integer
            Get
                Return Math.Ceiling(TotalItems / ItemsPerPage)
            End Get
        End Property

    End Class

End Namespace
