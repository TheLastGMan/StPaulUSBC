Namespace Repository

    Public Class AwardName : Implements IAwardName

        Private _entities As Entity.IDbSet(Of Data.Entity.AwardName)
        Private _context As Data.IDBContext

        Public Sub New(DBC As Data.IDBContext)
            _context = DBC
        End Sub

        Public Function ByGuid(ByRef guid As String) As Data.Entity.AwardName Implements IAwardName.ByGuid
            Dim g As String = guid
            Return Table.Where(Function(f) f.RowGuid.ToString = g).FirstOrDefault
        End Function

        Public Function ById(ByRef id As Integer) As Data.Entity.AwardName Implements IAwardName.ById
            Dim i As Integer = id
            Return Table.Where(Function(f) f.Id = i).FirstOrDefault()
        End Function

        Public Function Create(ByRef item As Data.Entity.AwardName) As Boolean Implements ICrudInterface(Of Data.Entity.AwardName).Create
            Try
                Entities.Add(item)
                _context.SaveChanges()
                Return True
            Catch ex As Exception
                Return False
            End Try
        End Function

        Public Function Delete(ByRef item As Data.Entity.AwardName) As Boolean Implements ICrudInterface(Of Data.Entity.AwardName).Delete
            Try
                Entities.Remove(item)
                _context.SaveChanges()
                Return True
            Catch ex As Exception
                Return False
            End Try
        End Function

        Public ReadOnly Property Entities As Entity.DbSet(Of Data.Entity.AwardName) Implements ICrudInterface(Of Data.Entity.AwardName).Entities
            Get
                If _entities Is Nothing Then
                    _entities = _context.Set(Of Data.Entity.AwardName)()
                End If
                Return _entities
            End Get
        End Property

        Public ReadOnly Property Table As List(Of Data.Entity.AwardName) Implements ICrudInterface(Of Data.Entity.AwardName).Table
            Get
                Return Entities.ToList
            End Get
        End Property

        Public Function Update(ByRef item As Data.Entity.AwardName) As Boolean Implements ICrudInterface(Of Data.Entity.AwardName).Update
            Try
                _context.SaveChanges()
                Return True
            Catch ex As Exception
                Return False
            End Try
        End Function

        Public Function ByDivision(ByRef division As Integer) As List(Of Data.Entity.AwardName) Implements IAwardName.ByDivision
            Dim d As Integer = division
            Return Table.Where(Function(f) f.AwardDivisionId = d).OrderBy(Function(f) f.Name).ToList
        End Function

        Public Function ByDivisionType(ByRef division As Integer, ByRef type As Integer) As List(Of Data.Entity.AwardName) Implements IAwardName.ByDivisionType
            Dim d As Integer = division
            Dim t As Integer = type
            Return Table.Where(Function(f) f.AwardDivisionId = d And f.AwardTypeId = t).OrderBy(Function(f) f.Name).ToList
        End Function

    End Class

End Namespace
