Namespace Models.Localization

    Public Class ManageModel

        Public Property Localization As New List(Of Data.Entity.Localization)

        Public Property Field As SearchField = SearchField.Key
        Public Property Parameter As SearchParameter = SearchParameter.Contains
        Public Property query As String

    End Class

    Public Enum SearchField As Byte
        key = 1
        value = 2
    End Enum

    Public Enum SearchParameter As Byte
        contains = 1
        starts_with = 2
        ends_with = 3
    End Enum

End Namespace
