Namespace Entity

    Public Class HallOfFame

        Public Property Id As Integer
        Public Property RowGuid As Guid = Guid.NewGuid
        Public Property FirstName As String
        Public Property LastName As String
        Public Property Deceased As Boolean = False
        Public Property Achieved As DateTime
        Public Property USBC_ID As String
        Public Property Picture As Byte()
        Public Property PictureMime As String
        Public Property WriteUp As String = ""
        Public Property Display As Boolean = True
        Public Property CreatedUtc As DateTime
        Public Property LastUpdatedUtc As DateTime = Now.ToUniversalTime

        Public Property HallOfFame_RecognitionTypeId As Integer?
        Public Overridable Property HallOfFame_RecognitionType As HallOfFame_RecognitionType
    End Class

End Namespace
