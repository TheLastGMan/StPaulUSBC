Public Interface IDBContext

    Function SqlQuery(Of TElement)(ByRef sql As String, ByVal ParamArray parameters() As String) As IEnumerable(Of TElement)

    Function ExecuteSqlCommand(ByRef sql As String, ByRef timeout? As Integer, ByVal ParamArray parameters() As String) As Integer

    Function [Set](Of TEntity As Class)() As System.Data.Entity.IDbSet(Of TEntity)

    Function BulkAdd(Of TEntity As Class)(Entities As IEnumerable(Of TEntity)) As Boolean

    Function SaveChanges() As Integer

End Interface
