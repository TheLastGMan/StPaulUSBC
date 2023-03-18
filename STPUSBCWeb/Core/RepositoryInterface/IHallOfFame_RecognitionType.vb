Public Interface IHallOfFame_RecognitionType : Inherits ICrudInterface(Of Data.Entity.HallOfFame_RecognitionType)

    Function ById(ByRef id As Integer) As Data.Entity.HallOfFame_RecognitionType
    Function ByName(ByRef name As String) As Data.Entity.HallOfFame_RecognitionType
    Function GetAll() As List(Of Data.Entity.HallOfFame_RecognitionType)
    Function ByName_StartWith(ByRef name As String) As List(Of Data.Entity.HallOfFame_RecognitionType)

End Interface
