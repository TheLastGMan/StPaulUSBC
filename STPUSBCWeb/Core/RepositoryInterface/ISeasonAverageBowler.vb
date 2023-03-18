Public Interface ISeasonAverageBowler : Inherits ICrudInterface(Of Data.Entity.SeasonAverageBowler)

    Function ById(ByRef gid As String) As Data.Entity.SeasonAverageBowler
    Function LastNameStartsWith(ByRef k As String) As List(Of Data.Entity.SeasonAverageBowler)
    Function Search(ByRef FirstName As String, ByRef LastName As String, ByRef USBCID As String, Optional limit As Byte = 15) As IEnumerable(Of SeasonAverageBowlerResult)
    Function Search(ByRef fullname_contains As String, Optional limit As Byte = 15) As IEnumerable(Of SeasonAverageBowlerResult)
    Function Search(ByRef FirstName As String, ByRef LastName As String, Optional ByVal limit As Byte = 15) As IEnumerable(Of SeasonAverageBowlerResult)
    Function SearchUSBCID(ByRef usbcid As String, Optional ByVal limit As Byte = 15) As IEnumerable(Of SeasonAverageBowlerResult)
    Function SearchCount(ByRef fullname_contains As String) As Integer
    Function DeleteAll() As Boolean
    Function Save() As Boolean
    Function BulkAdd(Entities As IEnumerable(Of Data.Entity.SeasonAverageBowler)) As Boolean
    Overloads Function Create(ByRef item As Data.Entity.SeasonAverageBowler, ByRef save As Boolean) As Boolean

End Interface
