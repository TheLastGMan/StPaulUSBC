Namespace Repository

    Public Class HomeLink : Implements IHomeLink

        Private _entities As Entity.IDbSet(Of Data.Entity.HomeLink)
        Private _context As Data.IDBContext

        Public Sub New(DBC As Data.IDBContext)
            _context = DBC
        End Sub

        Public Function Create(ByRef item As Data.Entity.HomeLink) As Boolean Implements ICrudInterface(Of Data.Entity.HomeLink).Create
            Try
                Entities.Add(item)
                _context.SaveChanges()
                Return True
            Catch ex As Exception
                Return False
            End Try
        End Function

        Public Function Delete(ByRef item As Data.Entity.HomeLink) As Boolean Implements ICrudInterface(Of Data.Entity.HomeLink).Delete
            'do not delete, just don't show
            item.Visible = False
            Return Update(item)
        End Function

        Public ReadOnly Property Entities As Entity.DbSet(Of Data.Entity.HomeLink) Implements ICrudInterface(Of Data.Entity.HomeLink).Entities
            Get
                If _entities Is Nothing Then
                    _entities = _context.Set(Of Data.Entity.HomeLink)()
                End If
                Return _entities
            End Get
        End Property

        Public ReadOnly Property Table As List(Of Data.Entity.HomeLink) Implements ICrudInterface(Of Data.Entity.HomeLink).Table
            Get
                Return Entities.OrderBy(Function(f) f.Order).ToList()
            End Get
        End Property

        Public Function Update(ByRef item As Data.Entity.HomeLink) As Boolean Implements ICrudInterface(Of Data.Entity.HomeLink).Update
            Try
                _context.SaveChanges()
                Return True
            Catch ex As Exception
                Return False
            End Try
        End Function

        Public Function GetAll(Optional ByVal OnlyVisible As Boolean = True) As List(Of Data.Entity.HomeLink) Implements IHomeLink.GetAll
            If OnlyVisible Then
                Return Table.Where(Function(f) f.Visible = True).ToList
            End If
            Return Table
        End Function

        Public Function ById(ByRef guid As String) As Data.Entity.HomeLink Implements IHomeLink.ById
            Dim g As String = guid
            Return Table.Where(Function(f) f.Id.ToString = g).FirstOrDefault
        End Function
    End Class

End Namespace