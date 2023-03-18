Namespace Repository

    Public Class Tournament_Classification : Implements ITournament_Classification

        Private _context As Data.IDBContext
        Private _entities As System.Data.Entity.IDbSet(Of Data.Entity.Tournament_Classification)

        Public Sub New(DBC As Data.IDBContext)
            _context = DBC
        End Sub

        Public Function Create(ByRef item As Data.Entity.Tournament_Classification) As Boolean Implements ICrudInterface(Of Data.Entity.Tournament_Classification).Create
            Try
                _entities.Add(item)
                _context.SaveChanges()
                Return True
            Catch ex As Exception
                Return False
            End Try
        End Function

        Public Function Delete(ByRef item As Data.Entity.Tournament_Classification) As Boolean Implements ICrudInterface(Of Data.Entity.Tournament_Classification).Delete
            'don't delete, just hide
            item.Show = False
            Return Update(item)
        End Function

        Public ReadOnly Property Entities As Entity.DbSet(Of Data.Entity.Tournament_Classification) Implements ICrudInterface(Of Data.Entity.Tournament_Classification).Entities
            Get
                If _entities Is Nothing Then
                    _entities = _context.Set(Of Data.Entity.Tournament_Classification)()
                End If
                Return _entities
            End Get
        End Property

        Public ReadOnly Property Table As List(Of Data.Entity.Tournament_Classification) Implements ICrudInterface(Of Data.Entity.Tournament_Classification).Table
            Get
                Return Entities.ToList
            End Get
        End Property

        Public Function Update(ByRef item As Data.Entity.Tournament_Classification) As Boolean Implements ICrudInterface(Of Data.Entity.Tournament_Classification).Update
            Try
                _context.SaveChanges()
                Return True
            Catch ex As Exception
                Return False
            End Try
        End Function

        Public Function ById(ByRef id As Integer) As Data.Entity.Tournament_Classification Implements ITournament_Classification.ById
            Dim lid As Integer = id
            Return Table.Where(Function(f) f.Id = lid).FirstOrDefault
        End Function

        Public Function GetAll() As List(Of Data.Entity.Tournament_Classification) Implements ITournament_Classification.GetAll
            Return Table.OrderBy(Function(f) f.Description).ToList
        End Function
    End Class

End Namespace
