Public Interface IHonorType : Inherits ICrudInterface(Of Data.Entity.HonorType)

    Function ById(ByRef id As Integer) As Data.Entity.HonorType
    Function BySeo(ByRef seo As String) As Data.Entity.HonorType
    Function IdBySeo(ByRef seo As String) As Integer
    Function GetAll() As List(Of Data.Entity.HonorType)
    Function DeActivate(ByRef id As Integer) As Boolean

End Interface
