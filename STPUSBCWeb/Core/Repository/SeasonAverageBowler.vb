Namespace Repository

    Public Class SeasonAverageBowler : Implements ISeasonAverageBowler

        Private _context As Data.IDBContext
        Private _entities As Entity.IDbSet(Of Data.Entity.SeasonAverageBowler)

        Private ReadOnly _sa As ISeasonAverage
        Public Sub New(DBC As Data.IDBContext, SA As ISeasonAverage)
            _context = DBC
            _sa = SA
        End Sub

        Public Overloads Function Create(ByRef item As Data.Entity.SeasonAverageBowler) As Boolean Implements ICrudInterface(Of Data.Entity.SeasonAverageBowler).Create
            Try
                Entities.Add(item)
                _context.SaveChanges()
                Return True
            Catch ex As Exception
                Return False
            End Try
        End Function

        Public Function BulkAdd(Entities As IEnumerable(Of Data.Entity.SeasonAverageBowler)) As Boolean Implements ISeasonAverageBowler.BulkAdd
            Return _context.BulkAdd(Entities)
        End Function

        Public Function Delete(ByRef item As Data.Entity.SeasonAverageBowler) As Boolean Implements ICrudInterface(Of Data.Entity.SeasonAverageBowler).Delete
            Try
                Entities.Remove(item)
                _context.SaveChanges()
                Return True
            Catch ex As Exception
                Return False
            End Try
        End Function

        Public ReadOnly Property Entities As Entity.DbSet(Of Data.Entity.SeasonAverageBowler) Implements ICrudInterface(Of Data.Entity.SeasonAverageBowler).Entities
            Get
                If _entities Is Nothing Then
                    _entities = _context.Set(Of Data.Entity.SeasonAverageBowler)()
                End If
                Return _entities
            End Get
        End Property

        Public ReadOnly Property Table As List(Of Data.Entity.SeasonAverageBowler) Implements ICrudInterface(Of Data.Entity.SeasonAverageBowler).Table
            Get
                Return Entities.OrderBy(Function(f) f.LastName).ThenBy(Function(f) f.FirstName).ToList
            End Get
        End Property

        Public Function Update(ByRef item As Data.Entity.SeasonAverageBowler) As Boolean Implements ICrudInterface(Of Data.Entity.SeasonAverageBowler).Update
            Try
                _context.SaveChanges()
                Return True
            Catch ex As Exception
                Return False
            End Try
        End Function

        Public Function ById(ByRef gid As String) As Data.Entity.SeasonAverageBowler Implements ISeasonAverageBowler.ById
            Dim id As String = gid
            Return Entities.Where(Function(f) f.Id.ToString().Equals(id)).FirstOrDefault
        End Function

        Private Function ByIdG(gid As String) As Data.Entity.SeasonAverageBowler
            Return Entities.Where(Function(f) f.Id.Equals(gid)).FirstOrDefault
        End Function

        Public Function DeleteAll() As Boolean Implements ISeasonAverageBowler.DeleteAll
            Try
                Entities.RemoveRange(Table)
                _context.SaveChanges()
                Return True
            Catch ex As Exception
                Return False
            End Try
        End Function

        Public Function LastNameStartsWith(ByRef k As String) As List(Of Data.Entity.SeasonAverageBowler) Implements ISeasonAverageBowler.LastNameStartsWith
            Dim x As String = k.ToLower
            Return Table.Where(Function(f) f.LastName.ToLower.StartsWith(x)).ToList
        End Function

        Public Function Search(ByRef fullname_contains As String, Optional limit As Byte = 15) As IEnumerable(Of SeasonAverageBowlerResult) Implements ISeasonAverageBowler.Search
            Dim fnc As String = fullname_contains.ToLower
            Return Table.Where(Function(f) f.FullName.ToLower.Contains(fnc)).Take(limit).Select(Function(f) New SeasonAverageBowlerResult(f)).ToList()
        End Function

        Public Function Search(ByRef FirstName As String, ByRef LastName As String, ByRef USBCID As String, Optional limit As Byte = 15) As IEnumerable(Of SeasonAverageBowlerResult) Implements ISeasonAverageBowler.Search
            If String.IsNullOrEmpty(USBCID) Then
                'use names
                Return Search(FirstName, LastName, limit)
            Else
                'use id
                Return SearchUSBCID(USBCID, limit)
            End If
        End Function

        Public Function Search(ByRef FirstName As String, ByRef LastName As String, Optional limit As Byte = 15) As IEnumerable(Of SeasonAverageBowlerResult) Implements ISeasonAverageBowler.Search
            Dim FN As String = FirstName
            Dim LN As String = LastName
            Dim ret As IEnumerable(Of Data.Entity.SeasonAverageBowler)
            If String.IsNullOrEmpty(FirstName) And String.IsNullOrEmpty(LastName) Then
                'nothing specified
                ret = New List(Of Data.Entity.SeasonAverageBowler)
                Return ret
            ElseIf String.IsNullOrEmpty(FirstName) Then
                'use last name
                ret = Entities.Where(Function(f) f.LastName.ToLower.StartsWith(LN.ToLower)).Take(limit)
            ElseIf String.IsNullOrEmpty(LastName) Then
                'use first name
                ret = Entities.Where(Function(f) f.FirstName.ToLower.StartsWith(FN.ToLower)).Take(limit)
            Else
                'full name
                FN = FN.ToLower
                LN = LN.ToLower
                ret = Entities.Where(Function(f) f.LastName.ToLower.StartsWith(LN) And f.FirstName.ToLower.StartsWith(FN)).Take(limit)
            End If
            Return ret.OrderBy(Function(f) f.FullName).Select(Function(f) New SeasonAverageBowlerResult(f)).ToList()
        End Function

        Public Function SearchUSBCID(ByRef usbcid As String, Optional limit As Byte = 15) As IEnumerable(Of SeasonAverageBowlerResult) Implements ISeasonAverageBowler.SearchUSBCID
            Dim sab = ByIdG(usbcid)
            If String.IsNullOrEmpty(sab.FullName) Then
                'no results
                Return New List(Of SeasonAverageBowlerResult)
            End If
            Return Entities.AsEnumerable.Where(Function(f) f.Id = sab.Id).Take(limit).Select(Function(f) New SeasonAverageBowlerResult(f)).ToList()
        End Function

        Public Function SearchCount(ByRef fullname_contains As String) As Integer Implements ISeasonAverageBowler.SearchCount
            Dim fnc As String = fullname_contains.ToLower
            Return Table.Where(Function(f) f.FullName.ToLower.Contains(fnc)).Count
        End Function

        Public Overloads Function Create(ByRef item As Data.Entity.SeasonAverageBowler, ByRef save As Boolean) As Boolean Implements ISeasonAverageBowler.Create
            Try
                Entities.Add(item)
                If save Then
                    _context.SaveChanges()
                End If
                Return True
            Catch ex As Exception
                Return False
            End Try
        End Function

        Public Function Save() As Boolean Implements ISeasonAverageBowler.Save
            Try
                _context.SaveChanges()
                Return True
            Catch ex As Exception
                Return False
            End Try
        End Function

    End Class

End Namespace
