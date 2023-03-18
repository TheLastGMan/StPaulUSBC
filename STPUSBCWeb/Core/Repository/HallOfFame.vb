Namespace Repository

    Public Class HallOfFame : Implements IHallOfFame

        Private _context As Data.IDBContext
        Private _entities As System.Data.Entity.IDbSet(Of Data.Entity.HallOfFame)

        Public Sub New(DBC As Data.IDBContext)
            _context = DBC
        End Sub

        Public Function Create(ByRef item As Data.Entity.HallOfFame) As Boolean Implements ICrudInterface(Of Data.Entity.HallOfFame).Create
            Try
                item.CreatedUtc = Now.ToUniversalTime
                Entities.Add(item)
                _context.SaveChanges()
                Return True
            Catch ex As Exception
                Return False
            End Try
        End Function

        Public Function Delete(ByRef item As Data.Entity.HallOfFame) As Boolean Implements ICrudInterface(Of Data.Entity.HallOfFame).Delete
            'don't delete, just don't show
            Try
                Entities.Remove(item)
                _context.SaveChanges()
                Return True
            Catch ex As Exception
                Return False
            End Try
        End Function

        Public ReadOnly Property Entities As Entity.DbSet(Of Data.Entity.HallOfFame) Implements ICrudInterface(Of Data.Entity.HallOfFame).Entities
            Get
                If _entities Is Nothing Then
                    _entities = _context.Set(Of Data.Entity.HallOfFame)()
                End If
                Return _entities
            End Get
        End Property

        Public ReadOnly Property Table As List(Of Data.Entity.HallOfFame) Implements ICrudInterface(Of Data.Entity.HallOfFame).Table
            Get
                Return Entities.ToList
            End Get
        End Property

        Public Function Update(ByRef item As Data.Entity.HallOfFame) As Boolean Implements ICrudInterface(Of Data.Entity.HallOfFame).Update
            Try
                item.LastUpdatedUtc = Now.ToUniversalTime
                _context.SaveChanges()
                Return True
            Catch ex As Exception
                Return False
            End Try
        End Function

        Public Function Achieved_Range(ByRef start_date As Date, ByRef end_date As Date) As List(Of Data.Entity.HallOfFame) Implements IHallOfFame.Achieved_Range
            Dim sd As DateTime = start_date
            Dim ed As DateTime = end_date
            Return OnlyVisible(Entities.Where(Function(f) f.Achieved >= sd And f.Achieved <= ed).ToList)
        End Function

        Public Function ByGuid(ByRef guid As String) As Data.Entity.HallOfFame Implements IHallOfFame.ByGuid
            Dim g As String = guid
            Return Table.Where(Function(f) f.RowGuid.ToString = g).FirstOrDefault
        End Function

        Public Function ById(ByRef id As Integer) As Data.Entity.HallOfFame Implements IHallOfFame.ById
            Dim i As Integer = id
            Return Table.Where(Function(f) f.Id = i).FirstOrDefault
        End Function

        Public Function DeleteById(ByRef id As Integer) As Boolean Implements IHallOfFame.DeleteById
            Dim hof = ById(id)
            If hof IsNot Nothing Then
                Return Delete(hof)
            Else
                Return False
            End If
        End Function

        Public Function GetBy_USBCId(ByRef usbc As String) As Data.Entity.HallOfFame Implements IHallOfFame.GetBy_USBCId
            Dim u As String = usbc
            Return Table.Where(Function(f) f.USBC_ID = u).FirstOrDefault
        End Function

        Public Function Search_LastName_BeginsWith(ByRef lname As String) As List(Of Data.Entity.HallOfFame) Implements IHallOfFame.Search_LastName_BeginsWith
            Dim l As String = lname
            Return OnlyVisible(Table.Where(Function(f) f.LastName.StartsWith(l)).ToList)
        End Function

        Private Function OnlyVisible(ByRef lst As List(Of Data.Entity.HallOfFame)) As List(Of Data.Entity.HallOfFame)
            Return lst.Where(Function(f) f.Display = True).OrderBy(Function(f) f.LastName).ToList
        End Function

        Public Function GetAll(Optional IsOnlyVisible As Boolean = True) As List(Of Data.Entity.HallOfFame) Implements IHallOfFame.GetAll
            If IsOnlyVisible Then
                Return OnlyVisible(Table)
            Else
                Return Table
            End If
        End Function

        Public Function ActivateChange(ByRef id As Integer, ByRef status As Boolean) As Boolean Implements IHallOfFame.ActivateChange
            Dim hof = ById(id)
            hof.Display = status
            Return Update(hof)
        End Function

    End Class

End Namespace
