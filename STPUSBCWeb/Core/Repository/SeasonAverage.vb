Namespace Repository

    Public Class SeasonAverage : Implements ISeasonAverage

        Private _context As Data.IDBContext
        Private _entities As Entity.IDbSet(Of Data.Entity.SeasonAverage)

        Public Sub New(DBC As Data.IDBContext)
            _context = DBC
        End Sub

        Public Overloads Function Create(ByRef item As Data.Entity.SeasonAverage) As Boolean Implements ICrudInterface(Of Data.Entity.SeasonAverage).Create
            Try
                Entities.Add(item)
                _context.SaveChanges()
                Return True
            Catch ex As Exception
                Return False
            End Try
        End Function

        Function BulkInsert(Entities As IEnumerable(Of Data.Entity.SeasonAverage)) As Boolean Implements ISeasonAverage.BulkInsert
            Return _context.BulkAdd(Entities)
        End Function

        Public Function Delete(ByRef item As Data.Entity.SeasonAverage) As Boolean Implements ICrudInterface(Of Data.Entity.SeasonAverage).Delete
            Try
                Entities.Remove(item)
                _context.SaveChanges()
                Return True
            Catch ex As Exception
                Return False
            End Try
        End Function

        Public ReadOnly Property Entities As Entity.DbSet(Of Data.Entity.SeasonAverage) Implements ICrudInterface(Of Data.Entity.SeasonAverage).Entities
            Get
                If _entities Is Nothing Then
                    _entities = _context.Set(Of Data.Entity.SeasonAverage)()
                End If
                Return _entities
            End Get
        End Property

        Public ReadOnly Property Table As List(Of Data.Entity.SeasonAverage) Implements ICrudInterface(Of Data.Entity.SeasonAverage).Table
            Get
                Return Entities.OrderByDescending(Function(f) f.Average).ToList
            End Get
        End Property

        Public Function Update(ByRef item As Data.Entity.SeasonAverage) As Boolean Implements ICrudInterface(Of Data.Entity.SeasonAverage).Update
            Try
                _context.SaveChanges()
                Return True
            Catch ex As Exception
                Return False
            End Try
        End Function

        Public Function ByUsbcId(ByVal usbc As String) As List(Of Data.Entity.SeasonAverage) Implements ISeasonAverage.ByUsbcId
            Return Entities.Where(Function(f) f.SeasonAverageBowler_Id = usbc).OrderByDescending(Function(f) f.Season).ThenByDescending(Function(f) f.Average).ToList
        End Function

        Public Function DeleteAll() As Boolean Implements ISeasonAverage.DeleteAll
            Try
                Entities.RemoveRange(Table)
                _context.SaveChanges()
                Return True
            Catch ex As Exception
                Return False
            End Try
        End Function

        Public Function ById(ByRef gid As String) As Data.Entity.SeasonAverage Implements ISeasonAverage.ById
            Dim id As String = gid
            Return Entities.Where(Function(f) f.SeasonAverageBowler_Id = id).FirstOrDefault
        End Function

        Public Overloads Function Create(ByRef item As Data.Entity.SeasonAverage, ByRef save As Boolean) As Boolean Implements ISeasonAverage.Create
            Try
                Entities.Add(item)
                If save Then
                    _context.SaveChanges()
                End If
                Return True
            Catch ex As Exception
                Return False
            End Try
        End Function

        Public Function Save() As Boolean Implements ISeasonAverage.Save
            Try
                _context.SaveChanges()
                Return True
            Catch ex As Exception
                Return False
            End Try
        End Function

    End Class

End Namespace
