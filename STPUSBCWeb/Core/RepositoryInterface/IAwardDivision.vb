Public Interface IAwardDivision : Inherits ICrudInterface(Of Data.Entity.AwardDivision)

    Function byId(ByRef id As Integer) As Data.Entity.AwardDivision
    Function byDescription(ByRef desc As String) As Data.Entity.AwardDivision
    Function GetAll() As List(Of Data.Entity.AwardDivision)

End Interface
