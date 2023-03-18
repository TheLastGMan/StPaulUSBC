Namespace Repository

    Public Class User : Implements IUser

        Private _context As Data.IDBContext
        Private _entities As Entity.IDbSet(Of Data.Entity.User)

        Public Sub New(DBC As Data.IDBContext)
            _context = DBC
        End Sub

        Public Function Create(ByRef item As Data.Entity.User) As Boolean Implements ICrudInterface(Of Data.Entity.User).Create
            Try
				item.created_utc = Now.ToUniversalTime
                Entities.Add(item)
                _context.SaveChanges()
                Return True
            Catch ex As Exception
                Return False
            End Try
        End Function

        Public Function Delete(ByRef item As Data.Entity.User) As Boolean Implements ICrudInterface(Of Data.Entity.User).Delete
            Try
                Entities.Remove(item)
                _context.SaveChanges()
                Return True
            Catch ex As Exception
                Return False
            End Try
        End Function

        Public ReadOnly Property Entities As Entity.DbSet(Of Data.Entity.User) Implements ICrudInterface(Of Data.Entity.User).Entities
            Get
                If _entities Is Nothing Then
                    _entities = _context.Set(Of Data.Entity.User)()
                End If
                Return _entities
            End Get
        End Property

        Public ReadOnly Property Table As List(Of Data.Entity.User) Implements ICrudInterface(Of Data.Entity.User).Table
            Get
                Return Entities.ToList
            End Get
        End Property

        Public Function Update(ByRef item As Data.Entity.User) As Boolean Implements ICrudInterface(Of Data.Entity.User).Update
            Try
                _context.SaveChanges()
                Return True
            Catch ex As Exception
                Return False
            End Try
        End Function

        Public Function ById(ByRef id As Integer) As Data.Entity.User Implements IUser.ById
            Dim i As Integer = id
            Return Table.Where(Function(F) F.Id = i).FirstOrDefault
        End Function

        Public Function ByUsername(ByRef username As String) As Data.Entity.User Implements IUser.ByUsername
            Dim u As String = username
            Return Table.Where(Function(f) f.Username = u).FirstOrDefault
        End Function

        Public Function ByUsernamePassword(ByRef username As String, ByRef password As String) As Data.Entity.User Implements IUser.ByUsernamePassword
            Dim u As String = username
            Dim p As String = password
            Return Table.Where(Function(f) f.Username = u And f.Password = p).FirstOrDefault
        End Function

    End Class

End Namespace
