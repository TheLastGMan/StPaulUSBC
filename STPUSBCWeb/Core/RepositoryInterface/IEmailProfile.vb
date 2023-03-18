Public Interface IEmailProfile : Inherits ICrudInterface(Of Data.Entity.EmailProfile)

    Function ByName(ByVal name As String) As Data.Entity.EmailProfile
    Function GetAll() As List(Of Data.Entity.EmailProfile)

End Interface
