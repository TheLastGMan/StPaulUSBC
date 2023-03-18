Namespace Repository

    Public Class Board : Implements IBoard

        Private _context As Data.IDBContext
        Private _entities As Entity.IDbSet(Of Data.Entity.Board)

        Public Sub New(DBC As Data.IDBContext)
            _context = DBC
        End Sub

        Public Function ById(ByRef guid As String) As Data.Entity.Board Implements IBoard.ById
            Dim lguid As String = guid
            Return Table.Where(Function(f) f.Id.ToString = lguid).FirstOrDefault
        End Function

        Public Function Create(ByRef item As Data.Entity.Board) As Boolean Implements ICrudInterface(Of Data.Entity.Board).Create
            Try
                item.AddedUtc = Now.ToUniversalTime
                Entities.Add(item)
                _context.SaveChanges()
                Return True
            Catch ex As Exception
                Return False
            End Try
        End Function

        Public Function Delete(ByRef item As Data.Entity.Board) As Boolean Implements ICrudInterface(Of Data.Entity.Board).Delete
            'don't delete, just do not show
            item.Visible = False
            Return Update(item)
        End Function

        Public ReadOnly Property Entities As Entity.DbSet(Of Data.Entity.Board) Implements ICrudInterface(Of Data.Entity.Board).Entities
            Get
                If _entities Is Nothing Then
                    _entities = _context.Set(Of Data.Entity.Board)()
                End If
                Return _entities
            End Get
        End Property

        Public ReadOnly Property Table As List(Of Data.Entity.Board) Implements ICrudInterface(Of Data.Entity.Board).Table
            Get
                Return Entities.ToList.OrderByDescending(Function(f) f.Visible).ThenBy(Function(f) f.FormattedName).ToList
            End Get
        End Property

        Public Function Update(ByRef item As Data.Entity.Board) As Boolean Implements ICrudInterface(Of Data.Entity.Board).Update
            Try
                item.LastUpdatedUtc = Now.ToUniversalTime
                _context.SaveChanges()
                Return True
            Catch ex As Exception
                Return False
            End Try
        End Function

        Public Function LastUpdated() As Date Implements IBoard.LastUpdated
            Return Table.OrderByDescending(Function(f) f.LastUpdatedUtc).Select(Function(f) f.LastUpdatedUtc).FirstOrDefault
        End Function

    End Class

End Namespace
