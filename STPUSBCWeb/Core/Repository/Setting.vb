Namespace Repository

    Public Class Setting : Implements ISetting

        Private _dbc As Data.IDBContext
        Private _entities As System.Data.Entity.IDbSet(Of Data.Entity.Setting)

        Public ReadOnly Property Table As List(Of Data.Entity.Setting) Implements ICrudInterface(Of Data.Entity.Setting).Table
            Get
                Return Entities.ToList
            End Get
        End Property

        Public ReadOnly Property Entities As Entity.DbSet(Of Data.Entity.Setting) Implements ICrudInterface(Of Data.Entity.Setting).Entities
            Get
                If _entities Is Nothing Then
                    _entities = _dbc.Set(Of Data.Entity.Setting)()
                End If
                Return _entities
            End Get
        End Property

        Public Sub New(DBC As Data.IDBContext)
            _dbc = DBC
        End Sub

        Public Function Create(ByRef item As Data.Entity.Setting) As Boolean Implements ICrudInterface(Of Data.Entity.Setting).Create
            Try
                Entities.Add(item)
                _dbc.SaveChanges()
                Return True
            Catch ex As Exception
                Return False
            End Try
        End Function

        Public Function Delete(ByRef item As Data.Entity.Setting) As Boolean Implements ICrudInterface(Of Data.Entity.Setting).Delete
            Try
                Entities.Remove(item)
                _dbc.SaveChanges()
                Return True
            Catch ex As Exception
                Return False
            End Try
        End Function

        Public Function Update(ByRef item As Data.Entity.Setting) As Boolean Implements ICrudInterface(Of Data.Entity.Setting).Update
            Try
                _dbc.SaveChanges()
                Return True
            Catch ex As Exception
                Return False
            End Try
        End Function

        Public Function Exists(ByRef key As String) As Boolean Implements ISetting.Exists
            Try
                Dim entity As String = ReadByKey(key)
                If Not String.IsNullOrEmpty(entity) Then
                    Return True
                Else
                    Return False
                End If
            Catch ex As Exception
                Return False
            End Try
        End Function

        Public Function [Get](ByRef key As String) As Data.Entity.Setting Implements ISetting.Get
            Dim lkey As String = key
            Return Table.Where(Function(f) f.Key = lkey).FirstOrDefault
        End Function

        Public Function ReadByKey(ByRef key As String) As String Implements ISetting.ReadByKey
            Dim res As Data.Entity.Setting = [Get](key)
            If res IsNot Nothing Then
                Return res.Value
            Else
                Return ""
            End If
        End Function

        Public Function [Set](ByRef key As String, ByRef value As String) As Boolean Implements ISetting.Set
            If Exists(key) Then
                'update
                Dim res As Data.Entity.Setting = [Get](key)
                res.Value = value
                Return Update(res)
            Else
                'create
                Dim res As New Data.Entity.Setting
                With res
                    .Key = key
                    .Value = value
                End With
                Return Create(res)
            End If
        End Function

        Public Function DeleteByKey(ByRef key As String) As Boolean Implements ISetting.DeleteByKey
            Dim res As Data.Entity.Setting = [Get](key)
            If res IsNot Nothing Then
                Return Delete(res)
            Else
                Return False
            End If
        End Function

        Public Function GetAll() As List(Of Data.Entity.Setting) Implements ISetting.GetAll
            Return Table
        End Function
    End Class

End Namespace
