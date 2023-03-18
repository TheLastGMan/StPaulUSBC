Public Interface ITopic : Inherits ICrudInterface(Of Data.Entity.Topic)

    Function ById(ByRef id As String) As Data.Entity.Topic
    Function BySeo(ByRef seo As String) As Data.Entity.Topic
    Function ByTypeSeo(ByRef type As Data.Entity.TopicType, ByRef seo As String) As Data.Entity.Topic
    Function ByType(ByRef type As Data.Entity.TopicType) As List(Of Data.Entity.Topic)
    Function GetAll() As List(Of Data.Entity.Topic)
    Function DeleteById(ByRef id As String) As Boolean

End Interface
