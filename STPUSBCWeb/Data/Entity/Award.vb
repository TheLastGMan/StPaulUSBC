Namespace Entity

    Public Class Award

        Public Property Id As Guid

        Public Property AwardTypeId As Integer?
        Public Overridable Property AwardType As AwardType

        Public Property USBCAward As String = ""
        Public Property LocalAward As String = ""
        Public Property AdultAwardChoice As String = ""

        Public Property Center As String = ""
        Public Property League As String = ""
        Public Property BowlerName As String = ""
        Public Property DateBowled As Date = Now
        Public Property USBCID As String = ""
        Public Property BowlerAverage As Short
        Public Property BowlerGames As Byte = 1
        Public Property Game1 As Short
        Public Property Game2 As Short
        Public Property Game3 As Short
        Public Property Series As Short
        Public Property SecretaryPin As String = ""
        Public Property SecretaryName As String = ""
        Public Property SecretaryPhone As String
        Public Property SecretaryEmail As String = ""
        Public Property Archived As Boolean = False
        Public Property AddedUTC As DateTime = DateTime.UtcNow
        Public Property Submitted As Boolean = False

        Public Property USBCAwardList As List(Of String)
            Get
                Dim retlst As New List(Of String)
                For Each itm In USBCAward.Split("|")
                    Dim val = itm.Replace("{[<=>]}", "|")
                    If Not String.IsNullOrEmpty(val) Then
                        retlst.Add(val)
                    End If
                Next
                Return retlst
            End Get
            Set(value As List(Of String))
                Dim newlst As New List(Of String)
                For Each itm In value
                    newlst.Add(itm.Replace("|", "{[<=>]}"))
                Next
                USBCAward = String.Join("|", newlst.ToArray)
            End Set
        End Property

        Public Property LocalAwardList As List(Of String)
            Get
                Dim retlst As New List(Of String)
                For Each itm In LocalAward.Split("|")
                    Dim val = itm.Replace("{[<=>]}", "|")
                    If Not String.IsNullOrEmpty(val) Then
                        retlst.Add(val)
                    End If
                Next
                Return retlst
            End Get
            Set(value As List(Of String))
                Dim newlst As New List(Of String)
                For Each itm In value
                    newlst.Add(itm.Replace("|", "{[<=>]}"))
                Next
                LocalAward = String.Join("|", newlst.ToArray)
            End Set
        End Property

    End Class

End Namespace
