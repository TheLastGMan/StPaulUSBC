Namespace Repository

    Public Class Localization : Implements ILocalization

        Private _dbc As Data.IDBContext
        Private _entities As System.Data.Entity.IDbSet(Of Data.Entity.Localization)

        Public ReadOnly Property Table As List(Of Data.Entity.Localization) Implements ICrudInterface(Of Data.Entity.Localization).Table
            Get
                Return Entities.ToList
            End Get
        End Property

        Public ReadOnly Property Entities As Entity.DbSet(Of Data.Entity.Localization) Implements ICrudInterface(Of Data.Entity.Localization).Entities
            Get
                If _entities Is Nothing Then
                    _entities = _dbc.Set(Of Data.Entity.Localization)()
                End If
                Return _entities
            End Get
        End Property

        Public Sub New(DBC As Data.IDBContext)
            _dbc = DBC
        End Sub

        Public Function Create(ByRef item As Data.Entity.Localization) As Boolean Implements ICrudInterface(Of Data.Entity.Localization).Create
            Try
                Entities.Add(item)
                _dbc.SaveChanges()
                Return True
            Catch ex As Exception
                Return False
            End Try
        End Function

        Public Function Delete(ByRef item As Data.Entity.Localization) As Boolean Implements ICrudInterface(Of Data.Entity.Localization).Delete
            Try
                Entities.Remove(item)
                _dbc.SaveChanges()
                Return True
            Catch ex As Exception
                Return False
            End Try
        End Function

        Public Function Update(ByRef item As Data.Entity.Localization) As Boolean Implements ICrudInterface(Of Data.Entity.Localization).Update
            Try
                _dbc.SaveChanges()
                Return True
            Catch ex As Exception
                Return False
            End Try
        End Function

        Public Function Exists(ByRef key As String) As Boolean Implements ILocalization.Exists
            Dim loc = ReadByKey(key)
            If loc IsNot Nothing Then
                Return True
            Else
                Return False
            End If
        End Function

        Public Function GetAll() As List(Of Data.Entity.Localization) Implements ILocalization.GetAll
            Return Table
        End Function

        Public Function ReadByKey(ByRef key As String) As Data.Entity.Localization Implements ILocalization.ReadByKey
            Dim lkey As String = key
            Return Table.Where(Function(f) f.Key = lkey).FirstOrDefault
        End Function

        Public Function [Set](ByRef key As String, ByRef value As String) As Boolean Implements ILocalization.Set
            If Exists(key) Then
                'update
                Dim loc = ReadByKey(key)
                If loc IsNot Nothing Then
                    loc.Value = value
                    Return Update(loc)
                Else
                    Return False
                End If
            Else
                'create
                Dim loc As New Data.Entity.Localization With {.Key = key, .Value = value}
                Return Create(loc)
            End If
        End Function

        Public Function DeleteByKey(ByRef key As String) As Boolean Implements ILocalization.DeleteByKey
            Dim loc = ReadByKey(key)
            If loc IsNot Nothing Then
                Return Delete(loc)
            Else
                Return False
            End If
        End Function

        Public Function GetTop(ByRef top As Integer) As List(Of Data.Entity.Localization) Implements ILocalization.GetTop
            Return Table.OrderBy(Function(f) f.Key).Take(top).ToList
        End Function

        Public Function ById(ByRef id As String) As Data.Entity.Localization Implements ILocalization.ById
            Dim i As String = id
            Return Table.Where(Function(f) f.Id.ToString = i).FirstOrDefault
        End Function

        Public Function Msg(ByRef key As String) As String Implements ILocalization.Msg
            Dim ret As String = " "
            Dim val = ReadByKey(key)

            If val IsNot Nothing Then
                ret = val.Value
            End If

            Return ret
        End Function
    End Class

End Namespace
