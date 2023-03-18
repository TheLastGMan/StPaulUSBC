Namespace Entity

    Public Class Board

        Public Property Id As Guid = Guid.NewGuid
        Public Property FirstName As String
        Public Property LastName As String
        Public Property Visible As Boolean = True
        Public Property AddedUtc As DateTime
        Public Property LastUpdatedUtc As DateTime = Now.ToUniversalTime

        Public Overridable Property BoardHistory As ICollection(Of BoardHistory)

        Public ReadOnly Property FormattedName As String
            Get
                Return FirstName & " " & LastName
            End Get
        End Property
    End Class

End Namespace
