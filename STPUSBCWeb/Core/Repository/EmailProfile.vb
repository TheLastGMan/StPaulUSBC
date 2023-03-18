Imports System.Data.Entity
Imports Data.Entity

Namespace Repository

    Public Class EmailProfile : Implements IEmailProfile

        Private _context As Data.IDBContext
        Private _entities As Entity.IDbSet(Of Data.Entity.EmailProfile)

        Public Sub New(DBC As Data.IDBContext)
            _context = DBC
        End Sub

        Public Function Create(ByRef item As Data.Entity.EmailProfile) As Boolean Implements ICrudInterface(Of Data.Entity.EmailProfile).Create
            Try
                Entities.Add(item)
                _context.SaveChanges()
                Return True
            Catch ex As Exception
                Return False
            End Try
        End Function

        Public Function Delete(ByRef item As Data.Entity.EmailProfile) As Boolean Implements ICrudInterface(Of Data.Entity.EmailProfile).Delete
            Try
                Entities.Remove(item)
                _context.SaveChanges()
                Return True
            Catch ex As Exception
                Return False
            End Try
        End Function

        Public ReadOnly Property Entities As Entity.DbSet(Of Data.Entity.EmailProfile) Implements ICrudInterface(Of Data.Entity.EmailProfile).Entities
            Get
                If _entities Is Nothing Then
                    _entities = _context.Set(Of Data.Entity.EmailProfile)()
                End If
                Return _entities
            End Get
        End Property

        Public ReadOnly Property Table As List(Of Data.Entity.EmailProfile) Implements ICrudInterface(Of Data.Entity.EmailProfile).Table
            Get
                Return Entities.ToList
            End Get
        End Property

        Public Function Update(ByRef item As Data.Entity.EmailProfile) As Boolean Implements ICrudInterface(Of Data.Entity.EmailProfile).Update
            Try
                _context.SaveChanges()
                Return True
            Catch ex As Exception
                Return False
            End Try
        End Function

        Public Function ByName(name As String) As Data.Entity.EmailProfile Implements IEmailProfile.ByName
            Return Entities.FirstOrDefault(Function(f) f.Name.Equals(name))
        End Function

        Public Function GetAll() As List(Of Data.Entity.EmailProfile) Implements IEmailProfile.GetAll
            Return Table()
        End Function
    End Class

End Namespace
