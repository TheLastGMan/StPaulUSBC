Namespace Repository

    Public Class Topic : Implements ITopic

        Private _context As Data.IDBContext
        Private _entities As Entity.IDbSet(Of Data.Entity.Topic)

        Public Sub New(DBC As Data.IDBContext)
            _context = DBC
        End Sub

        Public Function Create(ByRef item As Data.Entity.Topic) As Boolean Implements ICrudInterface(Of Data.Entity.Topic).Create
            item.createdutc = Now.ToUniversalTime
            Try
                'check seo
                Dim search = BySeo(item.seo)
                If search IsNot Nothing Then
                    Return False
                End If
                Entities.Add(item)
                _context.SaveChanges()
                Return True
            Catch ex As Exception
                Return False
            End Try
        End Function

        Public Function Delete(ByRef item As Data.Entity.Topic) As Boolean Implements ICrudInterface(Of Data.Entity.Topic).Delete
            Try
                Entities.Remove(item)
                _context.SaveChanges()
                Return True
            Catch ex As Exception
                Return False
            End Try
        End Function

        Public ReadOnly Property Entities As Entity.DbSet(Of Data.Entity.Topic) Implements ICrudInterface(Of Data.Entity.Topic).Entities
            Get
                If _entities Is Nothing Then
                    _entities = _context.Set(Of Data.Entity.Topic)()
                End If
                Return _entities
            End Get
        End Property

        Public ReadOnly Property Table As List(Of Data.Entity.Topic) Implements ICrudInterface(Of Data.Entity.Topic).Table
            Get
                Return Entities.ToList
            End Get
        End Property

        Public Function Update(ByRef item As Data.Entity.Topic) As Boolean Implements ICrudInterface(Of Data.Entity.Topic).Update
            Try
                item.updatedutc = Now.ToUniversalTime
                _context.SaveChanges()
                Return True
            Catch ex As Exception
                Return False
            End Try
        End Function

        Public Function ById(ByRef id As String) As Data.Entity.Topic Implements ITopic.ById
            Dim lid As String = id
            Return Table.Where(Function(f) f.Id.ToString = lid).FirstOrDefault
        End Function

        Public Function ByType(ByRef type As Data.Entity.TopicType) As List(Of Data.Entity.Topic) Implements ITopic.ByType
            Dim t As Byte = Byte.Parse(type)
            Return Table.Where(Function(f) f.TopicTypeId = t).OrderBy(Function(f) f.seo).ToList
        End Function

        Public Function ByTypeSeo(ByRef type As Data.Entity.TopicType, ByRef seo As String) As Data.Entity.Topic Implements ITopic.ByTypeSeo
            Dim t As Byte = Byte.Parse(type)
            Dim lseo As String = seo
            Return Table.Where(Function(f) f.TopicTypeId = t And f.seo.Equals(lseo, StringComparison.InvariantCultureIgnoreCase)).FirstOrDefault()
        End Function

        Public Function GetAll() As List(Of Data.Entity.Topic) Implements ITopic.GetAll
            Return Table.OrderBy(Function(f) f.TopicTypeId).ThenBy(Function(f) f.seo).ToList
        End Function

        Public Function BySeo(ByRef seo As String) As Data.Entity.Topic Implements ITopic.BySeo
            Dim s As String = seo.ToLower
            Return Table.Where(Function(f) f.seo.ToLower = s).FirstOrDefault
        End Function

        Public Function DeleteById(ByRef id As String) As Boolean Implements ITopic.DeleteById
            Dim i As String = id
            Return Delete(Table.Where(Function(f) f.Id.ToString = i).firstordefault)
        End Function
    End Class

End Namespace
