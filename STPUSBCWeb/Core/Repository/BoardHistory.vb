Namespace Repository

    Public Class BoardHistory : Implements IBoardHistory

        Private _context As Data.IDBContext
        Private _entities As Entity.IDbSet(Of Data.Entity.BoardHistory)

        Public Sub New(DBC As Data.IDBContext)
            _context = DBC
        End Sub

        Public Function Create(ByRef item As Data.Entity.BoardHistory) As Boolean Implements ICrudInterface(Of Data.Entity.BoardHistory).Create
            Try
                Entities.Add(item)
                _context.SaveChanges()
                Return True
            Catch ex As Exception
                Return False
            End Try
        End Function

        Public Function Delete(ByRef item As Data.Entity.BoardHistory) As Boolean Implements ICrudInterface(Of Data.Entity.BoardHistory).Delete
            Try
                Entities.Remove(item)
                _context.SaveChanges()
                Return True
            Catch ex As Exception
                Return False
            End Try
        End Function

        Public ReadOnly Property Entities As Entity.DbSet(Of Data.Entity.BoardHistory) Implements ICrudInterface(Of Data.Entity.BoardHistory).Entities
            Get
                If _entities Is Nothing Then
                    _entities = _context.Set(Of Data.Entity.BoardHistory)()
                End If
                Return _entities
            End Get
        End Property

        Public ReadOnly Property Table As List(Of Data.Entity.BoardHistory) Implements ICrudInterface(Of Data.Entity.BoardHistory).Table
            Get
                Return Entities.OrderByDescending(Function(f) f.TermEnd).ToList
            End Get
        End Property

        Public Function Update(ByRef item As Data.Entity.BoardHistory) As Boolean Implements ICrudInterface(Of Data.Entity.BoardHistory).Update
            Try
                _context.SaveChanges()
                Return True
            Catch ex As Exception
                Return False
            End Try
        End Function

        Public Function ById(ByRef guid As String) As Data.Entity.BoardHistory Implements IBoardHistory.ById
            Dim g As String = guid
            Return Table.Where(Function(f) f.Id.ToString = g).FirstOrDefault
        End Function

        Public Function HigherTermEnd(ByRef min_endterm_year As Short) As List(Of Data.Entity.BoardHistory) Implements IBoardHistory.HigherTermEnd
            Dim mey As Short = min_endterm_year
            Return Table.Where(Function(f) f.TermEnd.Year >= mey).ToList
        End Function

        Public Function BoardTermList(Optional ByVal OnlyShowVisible As Boolean = True) As List(Of Data.Entity.BoardHistory) Implements IBoardHistory.BoardTermList
            Dim n = Now.ToUniversalTime
            Dim res = Table.Where(Function(f) f.TermEnd >= n And f.TermStart <= n)

            If OnlyShowVisible Then
                res = res.Where(Function(f) f.Board.Visible = True)
            End If

            Return res.OrderBy(Function(f) f.BoardPosition.Order).ThenByDescending(Function(f) f.TermEnd).ToList
        End Function

    End Class

End Namespace
