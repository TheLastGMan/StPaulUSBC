Namespace Repository

    Public Class Honor : Implements IHonor

        Private _entities As Entity.IDbSet(Of Data.Entity.Honor)
        Private _context As Data.IDBContext

        Public Sub New(DBC As Data.IDBContext)
            _context = DBC
        End Sub

        Public Function Create(ByRef item As Data.Entity.Honor) As Boolean Implements ICrudInterface(Of Data.Entity.Honor).Create
            Try
                item.AddedUtc = Now.ToUniversalTime
                Entities.Add(item)
                _context.SaveChanges()
                Return True
            Catch ex As Exception
                Return False
            End Try
        End Function

        Public Function Delete(ByRef item As Data.Entity.Honor) As Boolean Implements ICrudInterface(Of Data.Entity.Honor).Delete
            Try
                Entities.Remove(item)
                _context.SaveChanges()
                Return True
            Catch ex As Exception
                Return False
            End Try
        End Function

        Public ReadOnly Property Entities As Entity.DbSet(Of Data.Entity.Honor) Implements ICrudInterface(Of Data.Entity.Honor).Entities
            Get
                If _entities Is Nothing Then
                    _entities = _context.Set(Of Data.Entity.Honor)()
                End If
                Return _entities
            End Get
        End Property

        Public ReadOnly Property Table As List(Of Data.Entity.Honor) Implements ICrudInterface(Of Data.Entity.Honor).Table
            Get
                Return Entities.ToList
            End Get
        End Property

        Public Function Update(ByRef item As Data.Entity.Honor) As Boolean Implements ICrudInterface(Of Data.Entity.Honor).Update
            Try
                _context.SaveChanges()
                Return True
            Catch ex As Exception
                Return False
            End Try
        End Function

        Public Function ById(ByRef id As String) As Data.Entity.Honor Implements IHonor.ById
            Dim lid As String = id
            Return Table.Where(Function(f) f.Id.ToString = lid).FirstOrDefault
        End Function

        Public Function ByType(ByRef typeid As Integer) As List(Of Data.Entity.Honor) Implements IHonor.ByType
            Dim tid As Integer = typeid
            Return CommonOrder(Table.Where(Function(f) f.HonorTypeId = tid).OrderBy(Function(f) f.FormattedName).ToList())
        End Function

        Public Function ByCategory(ByRef catid As Integer) As List(Of Data.Entity.Honor) Implements IHonor.ByCategory
            Dim cid As Integer = catid
            Return CommonOrder(Table.Where(Function(f) f.HonorCategoryId = cid).OrderBy(Function(f) f.FormattedName).ToList)
        End Function

        Public Function Score(ByRef catid As Integer, ByRef typeid As Integer) As List(Of Data.Entity.Honor) Implements IHonor.Score
            Dim cid As Integer = catid
            Dim tid As Integer = typeid
            Return Table.Where(Function(f) f.HonorCategoryId = cid And f.HonorTypeId = tid).OrderBy(Function(f) f.FormattedName).ThenBy(Function(f) f.Achieved).ToList
        End Function

        Public Function LastUpdated() As Date? Implements IHonor.LastUpdated
            Dim res = Table.OrderByDescending(Function(f) f.AddedUtc).Take(1).FirstOrDefault()
            If res IsNot Nothing Then
                Return res.AddedUtc
            Else
                Return Nothing
            End If
        End Function

        Public Function ByTypeCategory(ByRef typeid As Integer, ByRef catid As Integer) As List(Of Data.Entity.Honor) Implements IHonor.ByTypeCategory
            Dim tid As Integer = typeid
            Dim cid As Integer = catid
            Return CommonOrder(Table.Where(Function(f) f.HonorTypeId = tid And f.HonorCategoryId = cid).OrderBy(Function(f) f.HonorType.Description).ThenBy(Function(f) f.HonorCategory.Description).ToList)
        End Function

        Public Function GetAll() As List(Of Data.Entity.Honor) Implements IHonor.GetAll
            Return CommonOrder(Table)
        End Function

        Private Function CommonOrder(ByRef lst As List(Of Data.Entity.Honor)) As List(Of Data.Entity.Honor)
            Return lst.OrderBy(Function(f) f.HonorType.Description).ThenBy(Function(f) f.HonorCategory.Description) _
                .ThenBy(Function(f) f.LastName).ThenByDescending(Function(f) f.Achieved).ToList
        End Function

    End Class

End Namespace
