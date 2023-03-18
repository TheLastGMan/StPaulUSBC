Namespace Repository

    Public Class Tournament : Implements ITournament

        Private _context As Data.IDBContext
        Private _entities As System.Data.Entity.IDbSet(Of Data.Entity.Tournament)

        Public Sub New(DBC As Data.IDBContext)
            _context = DBC
        End Sub

        Public Function Create(ByRef item As Data.Entity.Tournament) As Boolean Implements ICrudInterface(Of Data.Entity.Tournament).Create
            Try
                item.AddedUtc = Now.ToUniversalTime
                Entities.Add(item)
                _context.SaveChanges()
                Return True
            Catch ex As Exception
                Return False
            End Try
        End Function

        Public Function Delete(ByRef item As Data.Entity.Tournament) As Boolean Implements ICrudInterface(Of Data.Entity.Tournament).Delete
            Try
                Entities.Remove(item)
                _context.SaveChanges()
                Return True
            Catch ex As Exception
                Return False
            End Try
        End Function

        Public ReadOnly Property Entities As Entity.DbSet(Of Data.Entity.Tournament) Implements ICrudInterface(Of Data.Entity.Tournament).Entities
            Get
                If _entities Is Nothing Then
                    _entities = _context.Set(Of Data.Entity.Tournament)()
                End If
                Return _entities
            End Get
        End Property

        Public ReadOnly Property Table As List(Of Data.Entity.Tournament) Implements ICrudInterface(Of Data.Entity.Tournament).Table
            Get
                Return Entities.ToList
            End Get
        End Property

        Public Function Update(ByRef item As Data.Entity.Tournament) As Boolean Implements ICrudInterface(Of Data.Entity.Tournament).Update
            Try
                _context.SaveChanges()
                Return True
            Catch ex As Exception
                Return False
            End Try
        End Function

        Public Function GetAll() As List(Of Data.Entity.Tournament) Implements ITournament.GetAll
            Return Table.OrderBy(Function(d) d.Start_Date).ThenBy(Function(c) c.Center).ToList
        End Function

        Public Function ById(ByRef id As String) As Data.Entity.Tournament Implements ITournament.ById
            Dim i As String = id
            Return Table.Where(Function(f) f.Id.ToString = i).firstordefault
        End Function

    End Class

End Namespace
