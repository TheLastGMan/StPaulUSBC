Namespace Repository

    Public Class HallOfFame_RecognitionType : Implements IHallOfFame_RecognitionType

        Private _context As Data.IDBContext
        Private _entities As System.Data.Entity.IDbSet(Of Data.Entity.HallOfFame_RecognitionType)

        Public Sub New(DBC As Data.IDBContext)
            _context = DBC
        End Sub

        Public Function Create(ByRef item As Data.Entity.HallOfFame_RecognitionType) As Boolean Implements ICrudInterface(Of Data.Entity.HallOfFame_RecognitionType).Create
            Try
                Entities.Add(item)
                _context.SaveChanges()
                Return True
            Catch ex As Exception
                Return False
            End Try
        End Function

        Public Function Delete(ByRef item As Data.Entity.HallOfFame_RecognitionType) As Boolean Implements ICrudInterface(Of Data.Entity.HallOfFame_RecognitionType).Delete
            'don't delete, only hide
            item.Display = False
            Return Update(item)
        End Function

        Public ReadOnly Property Entities As Entity.DbSet(Of Data.Entity.HallOfFame_RecognitionType) Implements ICrudInterface(Of Data.Entity.HallOfFame_RecognitionType).Entities
            Get
                If _entities Is Nothing Then
                    _entities = _context.Set(Of Data.Entity.HallOfFame_RecognitionType)()
                End If
                Return _entities
            End Get
        End Property

        Public ReadOnly Property Table As List(Of Data.Entity.HallOfFame_RecognitionType) Implements ICrudInterface(Of Data.Entity.HallOfFame_RecognitionType).Table
            Get
                Return Entities.ToList
            End Get
        End Property

        Public Function Update(ByRef item As Data.Entity.HallOfFame_RecognitionType) As Boolean Implements ICrudInterface(Of Data.Entity.HallOfFame_RecognitionType).Update
            Try
                _context.SaveChanges()
                Return True
            Catch ex As Exception
                Return False
            End Try
        End Function

        Public Function ById(ByRef id As Integer) As Data.Entity.HallOfFame_RecognitionType Implements IHallOfFame_RecognitionType.ById
            Dim i As Integer = id
            Return Table.Where(Function(f) f.Id = i).FirstOrDefault
        End Function

        Public Function ByName(ByRef name As String) As Data.Entity.HallOfFame_RecognitionType Implements IHallOfFame_RecognitionType.ByName
            Dim n As String = name
            Return Table.Where(Function(f) f.Description = n).FirstOrDefault
        End Function

        Public Function GetAll() As List(Of Data.Entity.HallOfFame_RecognitionType) Implements IHallOfFame_RecognitionType.GetAll
            Return OnlyVisible(Table)
        End Function

        Private Function OnlyVisible(ByRef lst As List(Of Data.Entity.HallOfFame_RecognitionType)) As List(Of Data.Entity.HallOfFame_RecognitionType)
            Return lst.Where(Function(f) f.Display = True).OrderBy(Function(f) f.Description).ToList
        End Function

        Public Function ByName_StartWith(ByRef name As String) As List(Of Data.Entity.HallOfFame_RecognitionType) Implements IHallOfFame_RecognitionType.ByName_StartWith
            Dim n As String = name
            Return OnlyVisible(Table.Where(Function(f) f.Description.StartsWith(n)).ToList)
        End Function
    End Class

End Namespace
