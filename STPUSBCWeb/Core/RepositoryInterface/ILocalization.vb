Public Interface ILocalization : Inherits ICrudInterface(Of Data.Entity.Localization)

    Function ReadByKey(ByRef key As String) As Data.Entity.Localization
    Function GetAll() As List(Of Data.Entity.Localization)
    Function Exists(ByRef key As String) As Boolean
    Function [Set](ByRef key As String, ByRef value As String) As Boolean
    Function DeleteByKey(ByRef key As String) As Boolean
    Function GetTop(ByRef top As Integer) As List(Of Data.Entity.Localization)
    Function ById(ByRef id As String) As Data.Entity.Localization
    Function Msg(ByRef key As String) As String

End Interface
