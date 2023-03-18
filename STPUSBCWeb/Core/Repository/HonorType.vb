Namespace Repository

    Public Class HonorType : Implements IHonorType

        Private _entities As Entity.IDbSet(Of Data.Entity.HonorType)
        Private _context As Data.IDBContext

        Public Sub New(DBC As Data.IDBContext)
            _context = DBC
        End Sub

        Public Function Create(ByRef item As Data.Entity.HonorType) As Boolean Implements ICrudInterface(Of Data.Entity.HonorType).Create
            Try
                If BySeo(item.SEO) IsNot Nothing Then
                    item = ById(item.Id)
                    item.Active = True
                Else
                    item.AddedUtc = Now.ToUniversalTime
                    Entities.Add(item)
                End If

                _context.SaveChanges()
                Return True
            Catch ex As Exception
                Return False
            End Try
        End Function

        Public Function Delete(ByRef item As Data.Entity.HonorType) As Boolean Implements ICrudInterface(Of Data.Entity.HonorType).Delete
            Try
                'do not delete, just deactivate
                Entities.Remove(item)
                _context.SaveChanges()
                Return True
            Catch ex As Exception
                Return False
            End Try
        End Function

        Public ReadOnly Property Entities As Entity.DbSet(Of Data.Entity.HonorType) Implements ICrudInterface(Of Data.Entity.HonorType).Entities
            Get
                If _entities Is Nothing Then
                    _entities = _context.Set(Of Data.Entity.HonorType)()
                End If
                Return _entities
            End Get
        End Property

        Public ReadOnly Property Table As List(Of Data.Entity.HonorType) Implements ICrudInterface(Of Data.Entity.HonorType).Table
            Get
                Return Entities.OrderBy(Function(f) f.Description).ToList
            End Get
        End Property

        Public Function Update(ByRef item As Data.Entity.HonorType) As Boolean Implements ICrudInterface(Of Data.Entity.HonorType).Update
            Try
                _context.SaveChanges()
                Return True
            Catch ex As Exception
                Return False
            End Try
        End Function

        Public Function ById(ByRef id As Integer) As Data.Entity.HonorType Implements IHonorType.ById
            Dim lid As Integer = id
            Return Table.Where(Function(f) f.Id = lid).FirstOrDefault
        End Function

        Public Function BySeo(ByRef seo As String) As Data.Entity.HonorType Implements IHonorType.BySeo
            Dim lseo As String = seo.ToLower
            Return Table.Where(Function(f) f.SEO.ToLower = lseo).FirstOrDefault
        End Function

        Public Function IdBySeo(ByRef seo As String) As Integer Implements IHonorType.IdBySeo
            Dim lseo As String = seo.ToLower
            Dim res = Table.Where(Function(f) f.SEO.ToLower = lseo).FirstOrDefault
            If res IsNot Nothing Then
                Return res.Id
            Else
                Return Nothing
            End If
        End Function

        Public Function GetAll() As List(Of Data.Entity.HonorType) Implements IHonorType.GetAll
            Return Table.OrderBy(Function(f) f.Description).ToList
        End Function

        Public Function DeActivate(ByRef id As Integer) As Boolean Implements IHonorType.DeActivate
            Dim t = ById(id)
            t.Active = False
            Return Update(t)
        End Function

    End Class

End Namespace
