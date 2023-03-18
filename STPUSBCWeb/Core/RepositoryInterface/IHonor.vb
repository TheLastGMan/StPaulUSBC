Public Interface IHonor : Inherits ICrudInterface(Of Data.Entity.Honor)

    Function ById(ByRef id As String) As Data.Entity.Honor
    Function GetAll() As List(Of Data.Entity.Honor)
    Function ByType(ByRef typeid As Integer) As List(Of Data.Entity.Honor)
    Function ByCategory(ByRef catid As Integer) As List(Of Data.Entity.Honor)
    Function ByTypeCategory(ByRef typeid As Integer, ByRef catid As Integer) As List(Of Data.Entity.Honor)
    Function Score(ByRef catid As Integer, ByRef typeid As Integer) As List(Of Data.Entity.Honor)
    Function LastUpdated() As DateTime?

End Interface
