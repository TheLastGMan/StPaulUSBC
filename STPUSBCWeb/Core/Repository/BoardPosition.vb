Namespace Repository

    Public Class BoardPosition : Implements IBoardPosition

        Private _context As Data.IDBContext
        Private _entities As Entity.IDbSet(Of Data.Entity.BoardPosition)

        Public Sub New(DBC As Data.IDBContext)
            _context = DBC
        End Sub

        Public Function ById(ByRef id As Integer) As Data.Entity.BoardPosition Implements IBoardPosition.ById
            Dim lid As Integer = id
            Return Table.Where(Function(f) f.Id = lid).firstordefault()
        End Function

        Public Function Create(ByRef item As Data.Entity.BoardPosition) As Boolean Implements ICrudInterface(Of Data.Entity.BoardPosition).Create
            Try
                item.Order = GetNewInsertPosition()
                Entities.Add(item)
                _context.SaveChanges()
                Return True
            Catch ex As Exception
                Return False
            End Try
        End Function

        Private Function GetNewInsertPosition() As Integer
            Return (Table.OrderByDescending(Function(f) f.Order).Select(Function(f) f.Order).FirstOrDefault + 1)
        End Function

        Public Function Delete(ByRef item As Data.Entity.BoardPosition) As Boolean Implements ICrudInterface(Of Data.Entity.BoardPosition).Delete
            Try
                Entities.Remove(item)
                _context.SaveChanges()
                Return True
            Catch ex As Exception
                Return False
            End Try
        End Function

        Public ReadOnly Property Entities As Entity.DbSet(Of Data.Entity.BoardPosition) Implements ICrudInterface(Of Data.Entity.BoardPosition).Entities
            Get
                If _entities Is Nothing Then
                    _entities = _context.Set(Of Data.Entity.BoardPosition)()
                End If
                Return _entities
            End Get
        End Property

        Public ReadOnly Property Table As List(Of Data.Entity.BoardPosition) Implements ICrudInterface(Of Data.Entity.BoardPosition).Table
            Get
                Return Entities.OrderBy(Function(f) f.Order).ToList
            End Get
        End Property

        Public Function Update(ByRef item As Data.Entity.BoardPosition) As Boolean Implements ICrudInterface(Of Data.Entity.BoardPosition).Update
            Try
                _context.SaveChanges()
                Return True
            Catch ex As Exception
                Return False
            End Try
        End Function
    End Class

End Namespace
