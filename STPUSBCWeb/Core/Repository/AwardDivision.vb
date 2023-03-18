Namespace Repository

    Public Class AwardDivision : Implements IAwardDivision

        Private _context As Data.IDBContext
        Private _entities As Entity.IDbSet(Of Data.Entity.AwardDivision)

        Public Sub New(DBC As Data.IDBContext)
            _context = DBC
        End Sub

        Public Function byId(ByRef id As Integer) As Data.Entity.AwardDivision Implements IAwardDivision.byId
            Dim i As Integer = id
            Return Table.Where(Function(f) f.Id = i).FirstOrDefault
        End Function

        Public Function GetAll() As List(Of Data.Entity.AwardDivision) Implements IAwardDivision.GetAll
            Return Table
        End Function

        Public Function Create(ByRef item As Data.Entity.AwardDivision) As Boolean Implements ICrudInterface(Of Data.Entity.AwardDivision).Create
            Try
                Entities.Add(item)
                _context.SaveChanges()
                Return True
            Catch ex As Exception
                Return False
            End Try
        End Function

        Public Function Delete(ByRef item As Data.Entity.AwardDivision) As Boolean Implements ICrudInterface(Of Data.Entity.AwardDivision).Delete
            Try
                Entities.Remove(item)
                _context.SaveChanges()
                Return True
            Catch ex As Exception
                Return False
            End Try
        End Function

        Public ReadOnly Property Entities As Entity.DbSet(Of Data.Entity.AwardDivision) Implements ICrudInterface(Of Data.Entity.AwardDivision).Entities
            Get
                If _entities Is Nothing Then
                    _entities = _context.Set(Of Data.Entity.AwardDivision)()
                End If
                Return _entities
            End Get
        End Property

        Public ReadOnly Property Table As List(Of Data.Entity.AwardDivision) Implements ICrudInterface(Of Data.Entity.AwardDivision).Table
            Get
                Return Entities.OrderBy(Function(f) f.Description).ToList
            End Get
        End Property

        Public Function Update(ByRef item As Data.Entity.AwardDivision) As Boolean Implements ICrudInterface(Of Data.Entity.AwardDivision).Update
            Try
                _context.SaveChanges()
                Return True
            Catch ex As Exception
                Return False
            End Try
        End Function

        Public Function byDescription(ByRef desc As String) As Data.Entity.AwardDivision Implements IAwardDivision.byDescription
            Dim d As String = desc
            Return Table.Where(Function(f) f.Description.Equals(d)).FirstOrDefault
        End Function

    End Class

End Namespace
