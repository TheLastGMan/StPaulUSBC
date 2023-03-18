Public Interface ITournament : Inherits ICrudInterface(Of Data.Entity.Tournament)

    Function ById(ByRef id As String) As Data.Entity.Tournament
    Function GetAll() As List(Of Data.Entity.Tournament)

End Interface
