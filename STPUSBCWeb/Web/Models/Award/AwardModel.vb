Imports System.ComponentModel.DataAnnotations
Imports FluentValidation.Attributes
Namespace Models.Award

    <Validator(GetType(Validation.Award.AwardModelValidator))>
    Public Class AwardModel

        Public Property Center As String
        Public Property League As String
        Public Property AwardTypeId As Integer = 1
        Public Property BowlerName As String
        Public Property DateBowled As Date = Now
        Public Property USBCID As String
        Public Property BowlerAverage As Short
        Public Property BowlerGames As Byte = 1
        Public Property Game1 As Short = 0
        Public Property Game2 As Short = 0
        Public Property Game3 As Short = 0
        Public Property Series As Short = 0

        Public Property USBCAwards As New List(Of Data.Entity.AwardName)
        Public Property LocalAwards As New List(Of Data.Entity.AwardName)
        Public Property AdultAwardChoiceId As Integer?

        Public Property SecretaryPin As String
        Public Property SecretaryName As String
        Public Property SecretaryPhone As String
        Public Property SecretaryEmail As String

        'drop down options
        Public Property CenterLst As New List(Of String)
        Public Property LeagueLst As New List(Of String)
        Public Property USBCAwardId As Integer
        Public Property USBCAwardLst As New List(Of Data.Entity.AwardName)
        Public Property LocalAwardId As Integer
        Public Property LocalAwardLst As New List(Of Data.Entity.AwardName)
        Public Property AwardChoiceLst As New List(Of Data.Entity.AwardName)
        Public Property BowlerTypeLst As New List(Of Data.Entity.AwardType)
    End Class

    Public Enum AwardStep As Byte
        BowlerInfo = 1
        USBCAward = 2
        LocalAward = 3
        Secretary = 4
        Complete = 5
    End Enum

End Namespace
