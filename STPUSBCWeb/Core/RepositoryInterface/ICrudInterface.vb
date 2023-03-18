Public Interface ICrudInterface(Of T As Class)

    Function Create(ByRef item As T) As Boolean
    Function Update(ByRef item As T) As Boolean
    Function Delete(ByRef item As T) As Boolean

    ReadOnly Property Table As List(Of T)
    ReadOnly Property Entities As System.Data.Entity.DbSet(Of T)

End Interface
