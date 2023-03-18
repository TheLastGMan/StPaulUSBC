Namespace Models.HonorScore

    Public Class ManageModel
        Public Property HonorScores As New List(Of Data.Entity.Honor)

        Public Property Navigation As New ManageHeaderModel
        Public Property Search As New ChooseScoreModel

    End Class

End Namespace
