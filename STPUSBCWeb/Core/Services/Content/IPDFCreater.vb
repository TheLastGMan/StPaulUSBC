Public Interface IPDFCreater

    Function HallOfFameProfile(ByRef profile As Data.Entity.HallOfFame) As System.IO.MemoryStream
    Function AwardForm(ByRef award As Data.Entity.Award, ByVal reportUrl As String) As System.IO.MemoryStream

End Interface
