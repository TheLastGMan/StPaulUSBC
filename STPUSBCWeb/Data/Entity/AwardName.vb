Namespace Entity

    Public Class AwardName

        Public Property Id As Integer
        Public Property RowGuid As Guid
        Public Property Name As String
        Public Property AverageHigh As Short
        Public Property Visible As Boolean = True

        Public Property AwardTypeId As Integer?
        Public Property AwardType As AwardType

        Public Property AwardDivisionId As Integer?
        Public Overridable Property AwardDivision As AwardDivision

    End Class

End Namespace
