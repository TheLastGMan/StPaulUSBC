Namespace Repository

    Public Class HonorCategory : Implements IHonorCategory

        Private _entities As Entity.IDbSet(Of Data.Entity.HonorCategory)
        Private _context As Data.IDBContext

        Public Sub New(DBC As Data.IDBContext)
            _context = DBC
        End Sub

        Public Function Create(ByRef item As Data.Entity.HonorCategory) As Boolean Implements ICrudInterface(Of Data.Entity.HonorCategory).Create
            Try
                If BySeo(item.SEO) IsNot Nothing Then
                    item = ById(item.Id)
                    item.Active = True
                Else
                    item.Order = GetNewOrder()
                    Entities.Add(item)
                End If
                _context.SaveChanges()
                Return True
            Catch ex As Exception
                Return False
            End Try
        End Function

        Private Function GetNewOrder() As Integer
            Return (Table.OrderByDescending(Function(f) f.Order).Select(Function(f) f.Order).FirstOrDefault + 1)
        End Function

        Public Function Delete(ByRef item As Data.Entity.HonorCategory) As Boolean Implements ICrudInterface(Of Data.Entity.HonorCategory).Delete
            Try
                Entities.Remove(item)
                _context.SaveChanges()
                Return True
            Catch ex As Exception
                Return False
            End Try
        End Function

        Public ReadOnly Property Entities As Entity.DbSet(Of Data.Entity.HonorCategory) Implements ICrudInterface(Of Data.Entity.HonorCategory).Entities
            Get
                If _entities Is Nothing Then
                    _entities = _context.Set(Of Data.Entity.HonorCategory)()
                End If
                Return _entities
            End Get
        End Property

        Public ReadOnly Property Table As List(Of Data.Entity.HonorCategory) Implements ICrudInterface(Of Data.Entity.HonorCategory).Table
            Get
                Return Entities.ToList
            End Get
        End Property

        Public Function Update(ByRef item As Data.Entity.HonorCategory) As Boolean Implements ICrudInterface(Of Data.Entity.HonorCategory).Update
            Try
                _context.SaveChanges()
                Return True
            Catch ex As Exception
                Return False
            End Try
        End Function

        Public Function ById(ByRef id As Integer) As Data.Entity.HonorCategory Implements IHonorCategory.ById
            Dim lid As Integer = id
            Return Table.Where(Function(f) f.Id = lid).FirstOrDefault()
        End Function

        Public Function HonorsByType(ByRef seo As String) As List(Of Data.Entity.Honor) Implements IHonorCategory.HonorsByType
            Dim lseo As String = seo.ToLower
            Return Table.Where(Function(f) f.SEO.ToLower = lseo).Select(Function(h) h.Honor)
        End Function

        Public Function GetAll() As List(Of Data.Entity.HonorCategory) Implements IHonorCategory.GetAll
            Return Table.OrderBy(Function(f) f.Order).ToList
        End Function

        Public Function BySeo(ByRef seo As String) As Data.Entity.HonorCategory Implements IHonorCategory.BySeo
            Dim lseo As String = seo.ToLower
            Return Table.Where(Function(f) f.SEO.ToLower = lseo).FirstOrDefault
        End Function

        Public Function IdBySeo(ByRef seo As String) As Integer Implements IHonorCategory.IdBySeo
            Dim lseo As String = seo.ToLower
            Dim res = Table.Where(Function(f) f.SEO.ToLower = lseo).FirstOrDefault
            If res IsNot Nothing Then
                Return res.Id
            Else
                Return Nothing
            End If
        End Function

        Public Function DeActivate(ByRef id As Integer) As Boolean Implements IHonorCategory.DeActivate
            Dim cat = ById(id)
            cat.Active = False
            Return Update(cat)
        End Function

    End Class

End Namespace
