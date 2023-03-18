Imports System.Text
Namespace Entity

    Public Class SeasonAverageBowler

        Public Property Id As String = String.Empty
        Public Property LastName As String = String.Empty
        Public Property FirstName As String = String.Empty
        Public Property MI As String = String.Empty
        Public Property Suffix As String = String.Empty

        Public Property SeasonAverages As ICollection(Of SeasonAverage)

        Public ReadOnly Property FullName As String
            Get
                Dim nb As New StringBuilder
                nb.Append(LastName)
                nb.Append(", ")
                nb.Append(FirstName)
                If Not String.IsNullOrEmpty(MI) Then
                    nb.AppendFormat(" {0}", MI)
                End If
                If Not String.IsNullOrEmpty(Suffix) Then
                    nb.AppendFormat(", {0}", Suffix)
                End If
                Return nb.ToString
            End Get
        End Property

    End Class

End Namespace
