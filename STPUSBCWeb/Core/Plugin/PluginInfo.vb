Namespace Plugin

    Public Class PluginInfo

        Public Property Group As String
        Public Property DisplayName As String
        Public Property Version As String
        Public Property Author As String
        Public Property DisplayOrder As Byte

        'custom properties
        Public Property Installed As Boolean = False
        Public Property FileName As String

        Public Sub New(ByRef PI As IPluginInfo)
            With PI
                Group = .Group
                DisplayName = .DisplayName
                Version = .Version
                Author = .Version
                DisplayOrder = .DisplayOrder
            End With
        End Sub

    End Class

End Namespace
