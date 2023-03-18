
Imports Core.Services.Bowling

Public Class SeasonAverageBowlerResult : Inherits Data.Entity.SeasonAverageBowler
    Private Shared ReadOnly _sa As ISeasonAverage = New DI.IoC().Get(GetType(ISeasonAverage))

    Public Sub New(ByRef Bowler As Data.Entity.SeasonAverageBowler)
        With Me
            .FirstName = Bowler.FirstName
            .LastName = Bowler.LastName
            .Id = Bowler.Id
            .MI = Bowler.MI
            .Suffix = Bowler.Suffix
            SeasonAverages = _sa.ByUsbcId(Bowler.Id)
        End With
    End Sub

    Public ReadOnly Property Averages As Dictionary(Of String, IEnumerable(Of Data.Entity.SeasonAverage))
        Get
            Return SeasonAverages.GroupBy(Function(f) f.Season).ToDictionary(Function(f) f.Key, Function(g) g.ToList().AsEnumerable())
        End Get
    End Property

End Class
