Public Interface IHonorCategory : Inherits ICrudInterface(Of Data.Entity.HonorCategory)

    Function HonorsByType(ByRef seo As String) As List(Of Data.Entity.Honor)
    Function ById(ByRef id As Integer) As Data.Entity.HonorCategory
    Function BySeo(ByRef seo As String) As Data.Entity.HonorCategory
    Function IdBySeo(ByRef seo As String) As Integer
    Function GetAll() As List(Of Data.Entity.HonorCategory)
    Function DeActivate(ByRef id As Integer) As Boolean

End Interface
