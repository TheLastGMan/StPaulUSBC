Namespace Models.HonorScore

    Public Class HonorScoreEditModel

        Public Property Honor As New Data.Entity.Honor
        Public Property TypeId As Integer
        Public Property CategoryId As Integer

        Public Property TypeList As List(Of Data.Entity.HonorType)
        Public Property CategoryList As List(Of Data.Entity.HonorCategory)

    End Class

End Namespace
