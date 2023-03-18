Public Class AccountService : Implements IAccountService

    Private _user As Core.IUser
    Private _userrole As Core.IUserRole
    Private _role As Core.IRole
    Private _sec As IEncryption

    Public Sub New(USR As Core.IUser, SEC As IEncryption, USRROLE As Core.IUserRole, ROLE As Core.IRole)
        _user = USR
        _sec = SEC
        _userrole = USRROLE
        _role = ROLE
    End Sub

    Public Function LogIn(ByRef username As String, ByRef password As String) As LogInResult Implements IAccountService.LogIn
        Dim u As String = username
        Dim usr = _user.ByUsername(u)
        If usr Is Nothing Then
            Return LogInResult.Invalid_Username
        Else
            'user exists, check if locked out
            If Not usr.active Then
                Return LogInResult.Failed
            ElseIf usr.login_count > 3 Then
                Return LogInResult.Locked_Out
            Else
                Dim chkpwd As String = _sec.Encrypt(password, usr.Username)
                If usr.Password = chkpwd Then
                    usr.last_login_utc = Now.ToUniversalTime
                    _user.Update(usr)
                    Return LogInResult.Success
                Else
                    IncrementLogInCount(u)
                    Return LogInResult.Invalid_Password
                End If
            End If
        End If
        'catch all
        Return LogInResult.Failed
    End Function

    Public Function IncrementLogInCount(ByRef username As String) As Boolean Implements IAccountService.IncrementLogInCount
        Dim u As String = username
        Dim usr = _user.ByUsername(u)
        If usr Is Nothing Then
            Return False
        Else
            usr.login_count += 1
            Return _user.Update(usr)
        End If
    End Function

    Public Function ResetLogInCount(ByRef username As String) As Boolean Implements IAccountService.ResetLogInCount
        Dim u As String = username
        Dim usr = _user.ByUsername(u)
        If usr Is Nothing Then
            Return False
        Else
            usr.login_count = 0
            Return _user.Update(usr)
        End If
    End Function

    Public Function ManageRoles(ByRef id As Integer, ByRef userroles As Dictionary(Of String, Boolean)) As Boolean Implements IAccountService.ManageRoles
        'remove roles
        For Each itm In _userrole.ByUserId(id)
            _userrole.Delete(_userrole.ByUserRole(id, itm.Id))
        Next
        'add roles
        For Each itm In userroles.Where(Function(f) f.Value = True)
            _userrole.Create(New Data.Entity.UserRole With {.UserId = id,
                                                            .RoleId = _role.ByName(itm.Key).Id
                                                            })
        Next
        Return True
    End Function

    Public Function UpdatePassword(ByRef id As Integer, ByRef password As String) As Boolean Implements IAccountService.UpdatePassword
        Dim u = _user.ById(id)
        If Not String.IsNullOrEmpty(password) AndAlso Not u.Password = password Then
            u.Password = _sec.Encrypt(password, u.Username)
        End If
        Return _user.Update(u)
    End Function

End Class
