Public Interface IAwardName : Inherits ICrudInterface(Of Data.Entity.AwardName)

    Function ById(ByRef id As Integer) As Data.Entity.AwardName
    Function ByGuid(ByRef guid As String) As Data.Entity.AwardName
    Function ByDivision(ByRef division As Integer) As List(Of Data.Entity.AwardName)
    Function ByDivisionType(ByRef division As Integer, ByRef type As Integer) As List(Of Data.Entity.AwardName)

End Interface
