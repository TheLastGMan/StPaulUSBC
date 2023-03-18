Imports System.ComponentModel.DataAnnotations
Imports FluentValidation.Attributes
Namespace Models.Award

    <Validator(GetType(Validation.Award.BowlerModel))>
    Public Class BowlerInfo

        Public Property Center As String
        Public Property League As String
        Public Property BowlerName As String
        Public Property USBCID As String
        Public Property AwardTypeId As Integer = 1
        Public Property DateBowled As Date = Now
        Public Property BowlerGames As Byte = 1
        Public Property BowlerAverage As Short
        Public Property Game1 As Short
        Public Property Game2 As Short
        Public Property Game3 As Short
        Public Property Series As Short

        Public Property CenterLst As New List(Of String)
        Public Property LeagueLst As New List(Of String)
        Public Property BowlerLst As New List(Of String)
        Public Property BowlerTypeLst As New List(Of Data.Entity.AwardType)

        Public Property AwardID As Guid?

    End Class

End Namespace
