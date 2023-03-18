Namespace RoleProvider

    Public Class RoleManager : Inherits System.Web.Security.RoleProvider

        Private _rp As Core.IUserRole
        Private _um As Core.IUser
        Private _rm As Core.IRole

        Public Sub New()
            Dim IOC As New Core.DI.IoC
            _rp = IOC.Get(GetType(Core.IUserRole))
            _um = IOC.Get(GetType(Core.IUser))
            _rm = IOC.Get(GetType(Core.IRole))
        End Sub

        Public Overrides Sub AddUsersToRoles(usernames() As String, roleNames() As String)
            For Each u As String In usernames
                Dim uid As Integer = _um.ByUsername(u).Id
                For Each r As String In roleNames
                    Try
                        Dim ur As New Data.Entity.UserRole With {
                                                .RoleId = _rm.ByName(r).Id,
                                                .UserId = uid}
                        _rp.Create(ur)
                    Catch ex As Exception
                        'could not add, do nothing for now
                    End Try
                Next
            Next
        End Sub

        Public Overrides Property ApplicationName As String = "STPUSBC"

        Public Overrides Sub CreateRole(roleName As String)
            Dim r As New Data.Entity.Role With {
                .Name = roleName}
            _rm.Create(r)
        End Sub

        Public Overrides Function DeleteRole(roleName As String, throwOnPopulatedRole As Boolean) As Boolean
            Dim rc As Integer = _rm.Table.Where(Function(f) f.Name = roleName).Count
            If rc > 0 Then
                Return False
            Else
                Return _rm.Delete(_rm.ByName(roleName))
            End If
        End Function

        Public Overrides Function FindUsersInRole(roleName As String, usernameToMatch As String) As String()
            Dim rid As Integer = _rm.ById(roleName).Id
            Return _rp.ByRoleId(rid).Select(Function(F) F.Username).ToArray
        End Function

        Public Overrides Function GetAllRoles() As String()
            Return _rm.Table.OrderBy(Function(f) f.Name).Select(Function(f) f.Name).ToArray
        End Function

        Public Overrides Function GetRolesForUser(username As String) As String()
            Dim u = _um.ByUsername(username)
            Dim res = _rp.ByUserId(u.Id)
            Return res.Select(Function(f) f.Name).ToArray
        End Function

        Public Overrides Function GetUsersInRole(roleName As String) As String()
            Dim rid As Integer = _rm.ByName(roleName).Id
            Return _rp.ByRoleId(rid).Select(Function(f) f.Username).ToArray
        End Function

        Public Overrides Function IsUserInRole(username As String, roleName As String) As Boolean
            Return IIf(GetRolesForUser(username).Contains(roleName), True, False)
        End Function

        Public Overrides Sub RemoveUsersFromRoles(usernames() As String, roleNames() As String)
            For Each u In usernames
                Dim uid As Integer = _um.ByUsername(u).Id
                For Each r In roleNames
                    Dim rid As Integer = _rm.ByName(r).Id
                    _rp.Delete(_rp.ByUserRole(uid, rid))
                Next
            Next
        End Sub

        Public Overrides Function RoleExists(roleName As String) As Boolean
            Dim res = _rm.ByName(roleName)
            If res IsNot Nothing Then
                Return True
            Else
                Return False
            End If
        End Function

    End Class

End Namespace
