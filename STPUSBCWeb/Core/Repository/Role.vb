Namespace Repository

    Public Class Role : Implements IRole

        Private _context As Data.IDBContext
        Private _entities As Entity.IDbSet(Of Data.Entity.Role)

        Public Sub New(DBC As Data.IDBContext)
            _context = DBC
        End Sub

        Public Function Create(ByRef item As Data.Entity.Role) As Boolean Implements ICrudInterface(Of Data.Entity.Role).Create
            Try
                Entities.Add(item)
                _context.SaveChanges()
                Return True
            Catch ex As Exception
                Return False
            End Try
        End Function

        Public Function Delete(ByRef item As Data.Entity.Role) As Boolean Implements ICrudInterface(Of Data.Entity.Role).Delete
            Try
                Entities.Remove(item)
                _context.SaveChanges()
                Return True
            Catch ex As Exception
                Return False
            End Try
        End Function

        Public ReadOnly Property Entities As Entity.DbSet(Of Data.Entity.Role) Implements ICrudInterface(Of Data.Entity.Role).Entities
            Get
                If _entities Is Nothing Then
                    _entities = _context.Set(Of Data.Entity.Role)()
                End If
                Return _entities
            End Get
        End Property

        Public ReadOnly Property Table As List(Of Data.Entity.Role) Implements ICrudInterface(Of Data.Entity.Role).Table
            Get
                Return Entities.ToList
            End Get
        End Property

        Public Function Update(ByRef item As Data.Entity.Role) As Boolean Implements ICrudInterface(Of Data.Entity.Role).Update
            Try
                _context.SaveChanges()
                Return True
            Catch ex As Exception
                Return False
            End Try
        End Function

        Public Function ById(ByRef id As Integer) As Data.Entity.Role Implements IRole.ById
            Dim i As Integer = id
            Return Table.Where(Function(f) f.Id = i).FirstOrDefault
        End Function

        Public Function ByName(ByRef name As String) As Data.Entity.Role Implements IRole.ByName
            Dim n As String = name
            Return Table.Where(Function(f) f.Name = n).FirstOrDefault
        End Function

    End Class

End Namespace
