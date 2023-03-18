Namespace Repository

    Public Class Link : Implements ILink

        Private _context As Data.IDBContext
        Private _entities As Entity.IDbSet(Of Data.Entity.Link)

        Public Sub New(DBC As Data.IDBContext)
            _context = DBC
        End Sub

        Public Function Create(ByRef item As Data.Entity.Link) As Boolean Implements ICrudInterface(Of Data.Entity.Link).Create
            Try
                item.CreatedUtc = Now.ToUniversalTime
                item.Order = Table.OrderByDescending(Function(f) f.Order).Select(Function(f) f.Order).FirstOrDefault + 1

                Entities.Add(item)
                _context.SaveChanges()
                Return True
            Catch ex As Exception
                Return False
            End Try
        End Function

        Public Function Delete(ByRef item As Data.Entity.Link) As Boolean Implements ICrudInterface(Of Data.Entity.Link).Delete
            Try
                Entities.Remove(item)
                _context.SaveChanges()
                Return True
            Catch ex As Exception
                Return False
            End Try
        End Function

        Public ReadOnly Property Entities As Entity.DbSet(Of Data.Entity.Link) Implements ICrudInterface(Of Data.Entity.Link).Entities
            Get
                If _entities Is Nothing Then
                    _entities = _context.Set(Of Data.Entity.Link)()
                End If
                Return _entities
            End Get
        End Property

        Public ReadOnly Property Table As List(Of Data.Entity.Link) Implements ICrudInterface(Of Data.Entity.Link).Table
            Get
                Return Entities.OrderBy(Function(f) f.Order).ToList
            End Get
        End Property

        Public Function Update(ByRef item As Data.Entity.Link) As Boolean Implements ICrudInterface(Of Data.Entity.Link).Update
            Try
                _context.SaveChanges()
                Return True
            Catch ex As Exception
                Return False
            End Try
        End Function

        Public Function ById(ByRef id As String) As Data.Entity.Link Implements ILink.ById
            Dim lid As String = id
            Return Table.Where(Function(i) i.Id.ToString = lid).FirstOrDefault()
        End Function

        Public Function GetAll(Optional OnlyVisible As Boolean = True) As List(Of Data.Entity.Link) Implements ILink.GetAll
            If OnlyVisible Then
                Return Table.Where(Function(f) f.Visible = True).ToList
            Else
                Return Table
            End If
        End Function

    End Class

End Namespace
