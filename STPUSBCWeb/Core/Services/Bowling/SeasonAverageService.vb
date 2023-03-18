Imports iTextSharp.text
Imports iTextSharp.text.pdf.parser
Imports System.Text

Namespace Services.Bowling

    Public Class SeasonAverageService : Implements ISeasonAverageService

        Private _sab As Core.ISeasonAverageBowler
        Private _sa As Core.ISeasonAverage

        Public Sub New(SAB As Core.ISeasonAverageBowler, SA As Core.ISeasonAverage)
            _sab = SAB
            _sa = SA
        End Sub

        ''' <summary>
        ''' Last Name, First Name, MI, Suffix, (USBC Id, Average, Game, Hand, League Id)
        ''' </summary>
        ''' <param name="full_file_location"></param>
        ''' <param name="season"></param>
        ''' <returns></returns>
        ''' <remarks>items in () are required, all items are required for the first row</remarks>
        Public Function ParseCVSScores(ByRef full_file_location As String, ByVal season As String) As Boolean Implements ISeasonAverageService.ParseCVSScores
            Dim LastBowler As Data.Entity.SeasonAverageBowler = Nothing

            'insert new season
            Dim bowlers As New List(Of Data.Entity.SeasonAverageBowler)
            Dim averages As New List(Of Data.Entity.SeasonAverage)

            Using FR As New System.IO.StreamReader(full_file_location, True)
                Dim line As String = String.Empty
                Dim header As Boolean = True
                While True
                    line = FR.ReadLine()
                    If (String.IsNullOrEmpty(line)) Then
                        Exit While
                    ElseIf header Then
                        header = False
                        Continue While
                    End If

                    Dim parts As String() = line.Split(",")
                    If (Not String.IsNullOrEmpty(parts(0))) Then
                        'new bowler
                        Dim bowler = New Data.Entity.SeasonAverageBowler()
                        With bowler
                            .LastName = parts(0)
                            .FirstName = parts(1)
                            .MI = parts(2)
                            .Suffix = parts(3)
                            .Id = parts(4)
                        End With
                        LastBowler = bowler
                        bowlers.Add(bowler)
                    End If

                    'create league
                    Dim league = New Data.Entity.SeasonAverage()
                    With league
                        .SeasonAverageBowler_Id = parts(4)
                        .Average = parts(5)
                        .Games = parts(6)
                        .Hand = parts(7)
                        .League = parts(8)
                        .Season = season
                    End With
                    averages.Add(league)
                End While
            End Using

            'remove bowlers that already exist
            Dim bowlerIds As String() = _sab.Entities.Select(Function(f) f.Id).ToArray()
            bowlers = bowlers.Where(Function(f) Not bowlerIds.Contains(f.Id)).ToList()

            If Not (_sab.BulkAdd(bowlers) AndAlso _sa.BulkInsert(averages)) Then
                Return False
            End If

            Return True
        End Function

    End Class

End Namespace
