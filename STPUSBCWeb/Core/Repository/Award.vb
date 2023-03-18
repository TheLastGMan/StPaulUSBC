Namespace Repository

    Public Class Award : Implements IAward

        Private _context As Data.IDBContext
        Private _entities As Entity.IDbSet(Of Data.Entity.Award)

        Public Sub New(DBC As Data.IDBContext)
            _context = DBC
        End Sub

        Public Function CenterList() As List(Of String) Implements IAward.CenterList
            Return Table.Where(Function(f) Not String.IsNullOrEmpty(f.Center)).Select(Function(f) f.Center.ToLower).Distinct().ToList
        End Function

        Public Function GetAll(Optional ByVal OnlyVisible As Boolean = True) As List(Of Data.Entity.Award) Implements IAward.GetAll
            Dim resp = Table.OrderByDescending(Function(f) f.DateBowled).ToList
            If OnlyVisible Then
                resp = resp.Where(Function(f) f.Archived = False And f.Submitted = True).ToList
            End If
            Return resp
        End Function

        Public Function Create(ByRef item As Data.Entity.Award) As Boolean Implements ICrudInterface(Of Data.Entity.Award).Create
            Try
                item.AddedUTC = Now.ToUniversalTime
                Entities.Add(item)
                _context.SaveChanges()
                Return True
            Catch ex As Exception
                Return False
            End Try
        End Function

        Public Function Delete(ByRef item As Data.Entity.Award) As Boolean Implements ICrudInterface(Of Data.Entity.Award).Delete
            Try
                Entities.Remove(item)
                _context.SaveChanges()
                Return True
            Catch ex As Exception
                Return False
            End Try
        End Function

        Public ReadOnly Property Entities As Entity.DbSet(Of Data.Entity.Award) Implements ICrudInterface(Of Data.Entity.Award).Entities
            Get
                If _entities Is Nothing Then
                    _entities = _context.Set(Of Data.Entity.Award)()
                End If
                Return _entities
            End Get
        End Property

        Public ReadOnly Property Table As List(Of Data.Entity.Award) Implements ICrudInterface(Of Data.Entity.Award).Table
            Get
                Return Entities.OrderByDescending(Function(f) f.AddedUTC).ToList
            End Get
        End Property

        Public Function Update(ByRef item As Data.Entity.Award) As Boolean Implements ICrudInterface(Of Data.Entity.Award).Update
            Try
                _context.SaveChanges()
                Return True
            Catch ex As Exception
                Return False
            End Try
        End Function

        Public Function BowlerList() As List(Of String) Implements IAward.BowlerList
            Return Table.Where(Function(f) Not String.IsNullOrEmpty(f.BowlerName)).Select(Function(f) f.BowlerName.ToLower).Distinct().ToList
        End Function

        Public Function ById(ByRef id As String) As Data.Entity.Award Implements IAward.ById
            Dim i As String = id
            Return Table.Where(Function(f) f.Id.ToString = i).FirstOrDefault
        End Function

        Public Function LeagueList() As List(Of String) Implements IAward.LeagueList
            Return Table.Where(Function(f) Not String.IsNullOrEmpty(f.League)).Select(Function(f) f.League.ToLower).Distinct().ToList
        End Function

        Public Function DeleteOlderThan(days As Byte) As Boolean Implements IAward.DeleteOlderThan
            Try
                Table.Where(Function(f) f.Submitted = False And f.AddedUTC < DateTime.UtcNow.AddDays(-1 * days)).ToList.ForEach(Function(f) Delete(f))
                Return _context.SaveChanges()
            Catch ex As Exception
                Return False
            End Try
        End Function

    End Class

End Namespace
