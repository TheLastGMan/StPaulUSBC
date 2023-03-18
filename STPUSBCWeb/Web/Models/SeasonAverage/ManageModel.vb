Imports System.ComponentModel.DataAnnotations
Namespace Models.SeasonAverage

    Public Class ManageModel

        <Required>
        Public Property choice As UploadChoice
        <Required>
        <StringLength(16)>
        Public Property season As String
        <Required>
        Public Property file As HttpPostedFileBase

        Public Property result As String = ""

    End Class

    Public Enum UploadChoice As Byte
        purge = 0
        append = 1
    End Enum

End Namespace
