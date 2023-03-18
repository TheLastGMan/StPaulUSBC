Public Class HOF_BriefModel

    Public Property id As Integer
    Public Property Deceased As Boolean
    Public Property First_Name As String
    Public Property Last_Name As String
    Public Property USBC_ID As String
    Public Property Awareded As DateTime
    Public Property RecognitionName As String

    Public ReadOnly Property FullName As String
        Get
            Return Last_Name & ", " & First_Name
        End Get
    End Property
End Class
