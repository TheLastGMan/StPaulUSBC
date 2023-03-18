Public Interface IAward : Inherits ICrudInterface(Of Data.Entity.Award)

    Function ById(ByRef id As String) As Data.Entity.Award
    Function CenterList() As List(Of String)
    Function BowlerList() As List(Of String)
    Function LeagueList() As List(Of String)
    Function DeleteOlderThan(ByVal days As Byte) As Boolean
    Function GetAll(Optional ByVal OnlyVisible As Boolean = True) As List(Of Data.Entity.Award)

End Interface
