Namespace Entity

    Public Class Tournament
        Public Property Id As Guid

        Public Property EventName As String
        Public Property EventUrl As String
        Public Property Center As String

        Public Property Contact As String
        Public Property ContactEmail As String

        Public Property Start_Date As DateTime
        Public Property End_Date As DateTime?
        Public Property RegistrationClose As DateTime?
        Public Property AddedUtc As DateTime = Now.ToUniversalTime

        Public Property Tournament_ClassificationId As Integer?
        Public Overridable Property Tournament_Classification As Tournament_Classification

        'New Columns
        'Public Property RegistrationLink As String = ""
        'Public Property IsFull As Boolean
        'Public Property WriteUp As String = ""

    End Class

End Namespace
