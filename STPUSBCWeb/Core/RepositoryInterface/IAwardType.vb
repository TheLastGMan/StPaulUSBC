Public Interface IAwardType : Inherits ICrudInterface(Of Data.Entity.AwardType)

    Function byId(ByRef id As Integer) As Data.Entity.AwardType
    Function byDescription(ByRef desc As String) As Data.Entity.AwardType
    Function GetAll() As List(Of Data.Entity.AwardType)

End Interface