Public Interface ISetting : Inherits ICrudInterface(Of Data.Entity.Setting)

    Function [Get](ByRef key As String) As Data.Entity.Setting
    Function [Set](ByRef key As String, ByRef value As String) As Boolean
    Function ReadByKey(ByRef key As String) As String
    Function Exists(ByRef key As String) As Boolean
    Function DeleteByKey(ByRef key As String) As Boolean
    Function GetAll() As List(Of Data.Entity.Setting)

End Interface
