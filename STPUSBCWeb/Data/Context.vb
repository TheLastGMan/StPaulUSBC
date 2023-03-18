Imports System.Reflection
Imports System.Data.Entity
Imports System.Data.Entity.ModelConfiguration
Imports System.Data.Entity.Infrastructure
Imports EntityFramework.BulkInsert.Extensions

Public Class Context : Inherits DbContext : Implements IDBContext

    Public Shared ReadOnly DBPrefix As String = "STPUSBC_"

    Public Sub New(nameOrConnectionString As String)
        MyBase.New(nameOrConnectionString)
    End Sub

    Protected Overrides Sub OnModelCreating(modelBuilder As DbModelBuilder)
        Dim configType As System.Type = GetType(Map.LocalizationMap)
        Dim typestoregister = Assembly.GetAssembly(configType).GetTypes() _
                              .Where(Function(t) Not String.IsNullOrEmpty(t.Namespace)) _
                              .Where(Function(type) type.BaseType IsNot Nothing AndAlso type.BaseType.IsGenericType AndAlso type.BaseType.GetGenericTypeDefinition() = GetType(EntityTypeConfiguration(Of )))

        For Each t In typestoregister
            Dim configInstance = Activator.CreateInstance(t)
            modelBuilder.Configurations.Add(configInstance)
        Next

        MyBase.OnModelCreating(modelBuilder)
    End Sub

    Public ReadOnly Property CreateDatabaseScript As String
        Get
            Return DirectCast(Me, IObjectContextAdapter).ObjectContext.CreateDatabaseScript
        End Get
    End Property

    Public Function ExecuteSqlCommand(ByRef sql As String, ByRef timeout As Integer?, ParamArray parameters() As String) As Integer Implements IDBContext.ExecuteSqlCommand
        Dim previousTimeout? As Integer = Nothing
        If (timeout.HasValue) Then
            'store previous timeout
            previousTimeout = DirectCast(Me, IObjectContextAdapter).ObjectContext.CommandTimeout
            DirectCast(Me, IObjectContextAdapter).ObjectContext.CommandTimeout = timeout
        End If

        Dim result = Me.Database.ExecuteSqlCommand(sql, parameters)

        If timeout.HasValue Then
            'set previous timeout back
            DirectCast(Me, IObjectContextAdapter).ObjectContext.CommandTimeout = previousTimeout
        End If

        Return result
    End Function

    Public Function SqlQuery(Of TElement)(ByRef sql As String, ParamArray parameters() As String) As IEnumerable(Of TElement) Implements IDBContext.SqlQuery
        Return Me.Database.SqlQuery(Of TElement)(sql, parameters)
    End Function

    Public Overloads Function SaveChanges() As Integer Implements IDBContext.SaveChanges
        Return MyBase.SaveChanges()
    End Function

    Public Overloads Function [Set](Of TEntity As Class)() As IDbSet(Of TEntity) Implements IDBContext.Set
        Return MyBase.Set(Of TEntity)()
    End Function

    Public Function BulkAdd(Of TEntity As Class)(Entities As IEnumerable(Of TEntity)) As Boolean Implements IDBContext.BulkAdd
        Try
            Me.BulkInsert(Of TEntity)(Entities, New BulkInsertOptions() With {.BatchSize = 1000, .TimeOut = 300})
            Return True
        Catch ex As Exception
            Return False
        End Try
    End Function

End Class
