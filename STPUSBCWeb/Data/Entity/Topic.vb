Namespace Entity

    Public Class Topic

        Public Property Id As Guid = Guid.NewGuid
        Private Property _seo As String
        Public Property content As String
        Public Property active As Boolean = True
        Public Property createdutc As DateTime
        Public Property updatedutc As DateTime = Now.ToUniversalTime

        Public Property seo As String
            Get
                Return _seo
            End Get
            Set(value As String)
                _seo = value
                For Each c In _seo.ToCharArray
                    Dim cval As Integer = Asc(c)
                    If (cval >= 33 And cval <= 47) Or _
                       (cval >= 58 And cval <= 64) Or _
                       (cval >= 91 And cval <= 94) Or _
                       (cval = 96) Or (cval >= 123) Then
                        _seo = _seo.Replace(c, " ")
                    End If
                Next
                _seo = _seo.Replace(" ", "-")
            End Set
        End Property

        Public Property TopicTypeId As Byte
        Public Property TopicType As TopicType
            Get
                Return DirectCast(TopicTypeId, TopicType)
            End Get
            Set(value As TopicType)
                TopicTypeId = Byte.Parse(value)
            End Set
        End Property

        Public ReadOnly Property SeoFriendly As String
            Get
                Return seo.Replace("-", " ")
            End Get
        End Property


    End Class

    Public Enum TopicType As Byte
        Widget = 1
        Topic = 2
        Page = 3
    End Enum

End Namespace
