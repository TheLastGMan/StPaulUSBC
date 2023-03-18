Public Interface ITournament_Classification : Inherits ICrudInterface(Of Data.Entity.Tournament_Classification)

    Function ById(ByRef id As Integer) As Data.Entity.Tournament_Classification
    Function GetAll() As List(Of Data.Entity.Tournament_Classification)

End Interface
