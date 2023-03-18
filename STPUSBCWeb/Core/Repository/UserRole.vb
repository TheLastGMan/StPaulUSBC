Namespace Repository

    Public Class UserRole : Implements IUserRole

        Private _context As Data.IDBContext
        Private _entities As Entity.IDbSet(Of Data.Entity.UserRole)

        Public Sub New(DBC As Data.IDBContext)
            _context = DBC
        End Sub

        Public Function Create(ByRef item As Data.Entity.UserRole) As Boolean Implements ICrudInterface(Of Data.Entity.UserRole).Create
            Try
                Entities.Add(item)
                _context.SaveChanges()
                Return True
            Catch ex As Exception
                Return False
            End Try
        End Function

        Public Function Delete(ByRef item As Data.Entity.UserRole) As Boolean Implements ICrudInterface(Of Data.Entity.UserRole).Delete
            Try
                Entities.Remove(item)
                _context.SaveChanges()
                Return True
            Catch ex As Exception
                Return False
            End Try
        End Function

        Public ReadOnly Property Entities As Entity.DbSet(Of Data.Entity.UserRole) Implements ICrudInterface(Of Data.Entity.UserRole).Entities
            Get
                If _entities Is Nothing Then
                    _entities = _context.Set(Of Data.Entity.UserRole)()
                End If
                Return _entities
            End Get
        End Property

        Public ReadOnly Property Table As List(Of Data.Entity.UserRole) Implements ICrudInterface(Of Data.Entity.UserRole).Table
            Get
                Return Entities.ToList
            End Get
        End Property

        Public Function Update(ByRef item As Data.Entity.UserRole) As Boolean Implements ICrudInterface(Of Data.Entity.UserRole).Update
            Try
                _context.SaveChanges()
                Return True
            Catch ex As Exception
                Return False
            End Try
        End Function

        Public Function ByRoleId(ByRef id As Integer) As List(Of Data.Entity.User) Implements IUserRole.ByRoleId
            Dim i As Integer = id
            Return Table.Where(Function(f) f.RoleId = i).Select(Function(f) f.User).ToList
        End Function

        Public Function ByUserId(ByRef id As Integer) As List(Of Data.Entity.Role) Implements IUserRole.ByUserId
            Dim i As Integer = id
            Return Table.Where(Function(f) f.UserId = i).Select(Function(f) f.Role).ToList
        End Function

        Public Function ByUserRole(ByRef uid As Integer, ByRef rid As Integer) As Data.Entity.UserRole Implements IUserRole.ByUserRole
            Dim u As Integer = uid
            Dim r As Integer = rid
            Return Table.Where(Function(f) f.UserId = u And f.RoleId = r).FirstOrDefault
        End Function

    End Class

End Namespace
