Public Interface ISeasonAverage : Inherits ICrudInterface(Of Data.Entity.SeasonAverage)

    Function DeleteAll() As Boolean
    Function ById(ByRef gid As String) As Data.Entity.SeasonAverage
    Function ByUsbcId(ByVal usbc As String) As List(Of Data.Entity.SeasonAverage)
    Function Save() As Boolean
    Function BulkInsert(Entities As IEnumerable(Of Data.Entity.SeasonAverage)) As Boolean
    Overloads Function Create(ByRef item As Data.Entity.SeasonAverage, ByRef save As Boolean) As Boolean

End Interface
