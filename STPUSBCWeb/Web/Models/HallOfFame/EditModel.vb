Namespace Models.HallOfFame

    Public Class EditModel

        Public Property Famer As New Data.Entity.HallOfFame
        Public Property ImageData As New Core.HOF_ProfilePicture
        Public Property Types As New List(Of Data.Entity.HallOfFame_RecognitionType)

    End Class

End Namespace
