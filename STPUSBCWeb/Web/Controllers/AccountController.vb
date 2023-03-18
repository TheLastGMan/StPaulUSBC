Imports Web.Models.Account
Namespace Web
    Public Class AccountController
        Inherits System.Web.Mvc.Controller

        Private _account As Core.IAccountService
        Private _user As Core.IUser
        Private _role As Core.IRole
        Private _usrrole As Core.IUserRole
        Private _loc As Core.ILocalization
        Private _sec As Core.IEncryption

        Public Sub New(AC As Core.IAccountService, USR As Core.IUser, ROLE As Core.IRole, USRROLE As Core.IUserRole, ENC As Core.IEncryption, LOC As Core.ILocalization)
            _account = AC
            _user = USR
            _role = ROLE
            _usrrole = USRROLE
            _loc = LOC
            _sec = ENC
        End Sub

        Function LogIn() As ActionResult
            Response.Cache.SetCacheability(HttpCacheability.NoCache)
            If User.Identity.IsAuthenticated Then
                'already logged in, redirect
                Return RedirectToAction("", "Home")
            End If

            Return View(New LogInModel)
        End Function

        <HttpPost>
        <ValidateAntiForgeryToken>
        Function LogIn(ByVal model As LogInModel) As ActionResult
            If ModelState.IsValid Then
                'check login
                Select Case _account.LogIn(model.Username, model.Password)
                    Case Core.LogInResult.Failed
                        ModelState.AddModelError("", _loc.Msg("Account.LogIn.Failed"))
                    Case Core.LogInResult.Invalid_Password
                        ModelState.AddModelError("", _loc.Msg("Account.LogIn.InvalidPassword"))
                    Case Core.LogInResult.Invalid_Username
                        ModelState.AddModelError("", _loc.Msg("Account.LogIn.InvalidUsername"))
                    Case Core.LogInResult.Locked_Out
                        ModelState.AddModelError("", _loc.Msg("Account.LogIn.LockedOut"))
                    Case Core.LogInResult.Success
                        FormsAuthentication.SetAuthCookie(model.Username, True)
                        Dim redirectUrl As String = FormsAuthentication.GetRedirectUrl(model.Username, True)
                        If (Url.IsLocalUrl(redirectUrl)) Then
                            Return Redirect(redirectUrl)
                        Else
                            Return RedirectToRoute("Default")
                        End If
                End Select
            Else
                ModelState.AddModelError("", _loc.Msg("Account.LogIn.ErrorDefault"))
            End If
            'else validation errors
            Return View(model)
        End Function

        Function LogOut() As ActionResult
            FormsAuthentication.SignOut()
            Return RedirectToAction("", "Home")
        End Function

        <Authorize>
        Shadows Function Profile() As ActionResult
            Dim model As New Models.Account.ProfileModel

            With model
                .User = _user.ByUsername(User.Identity.Name)
                .Roles = _role.Table.OrderBy(Function(f) f.Name).ToDictionary(Function(f) f.Name, Function(f) User.IsInRole(f.Name))
            End With

            Return View(model)
        End Function

        <Authorize>
        <HttpPost>
        Function UpdatePassword(ByVal password As String) As ActionResult
            Dim u = _user.ByUsername(User.Identity.Name)
            _account.UpdatePassword(u.Id, password)
            Return RedirectToAction("Profile")
        End Function

        <Authorize(Roles:="UserAdmin")>
        Function Manage() As ActionResult
            Return View(_user.Table.OrderBy(Function(f) f.Username).ToList)
        End Function

        <HttpPost>
        <Authorize(Roles:="UserAdmin")>
        Function LockChange(ByVal id As Integer, ByVal status As Byte) As RedirectToRouteResult
            Dim u = _user.ById(id)
            u.login_count = status
            _user.Update(u)
            Return RedirectToAction("Manage")
        End Function

        <HttpPost>
        <Authorize(Roles:="UserAdmin")>
        Function ActivateChange(ByVal id As Integer, ByVal status As Boolean) As RedirectToRouteResult
            Dim u = _user.ById(id)
            u.active = status
            _user.Update(u)
            Return RedirectToAction("Manage")
        End Function

        <Authorize(Roles:="UserAdmin")>
        Function Edit(ByVal id As Integer) As ActionResult
            Dim u = _user.ById(id)

            If u.Username = User.Identity.Name Then
                Return RedirectToAction("Profile")
            End If

            If u IsNot Nothing Then
                Dim model As New Models.Account.EditModel
                model.User = u
                model.RoleList = _role.Table.OrderBy(Function(f) f.Name).Select(Function(f) New Models.Account.EditUserRole With {
                                                                                    .RoleKey = f.Name,
                                                                                    .InRole = IIf(_usrrole.ByUserRole(u.Id, f.Id) Is Nothing, False, True)
                                                                                }).ToList
                Return View(model)
            End If

            Return RedirectToAction("Manage")
        End Function

        <Authorize(Roles:="UserAdmin")>
        <HttpPost>
        Function Edit(ByVal model As Models.Account.EditModel) As ActionResult
            If String.IsNullOrEmpty(model.User.FirstName) Then
                ModelState.AddModelError("", "First Name is Required")
            End If
            If String.IsNullOrEmpty(model.User.LastName) Then
                ModelState.AddModelError("", "Last Name is Required")
            End If

            If ModelState.IsValid Then
                Dim u = _user.ById(model.User.Id)
                With u
                    .FirstName = model.User.FirstName
                    .LastName = model.User.LastName
                    .active = model.User.active
                End With
                _user.Update(u)
                _account.UpdatePassword(model.User.Id, model.User.Password)
                _account.ManageRoles(model.User.Id, model.RoleList.ToDictionary(Function(f) f.RoleKey, Function(f) f.InRole))
                Return RedirectToAction("Manage")
            End If

            Return View(model)
        End Function

        <Authorize(Roles:="UserAdmin")>
        Function Create() As ActionResult
            Dim model As New Models.Account.CreateModel
            model.User = New Models.Account.UserCreateModel
            model.RoleList = _role.Table.OrderBy(Function(f) f.Name).Select(Function(f) New Models.Account.EditUserRole With {
                                                                                .RoleKey = f.Name,
                                                                                .InRole = False}).ToList
            Return View(model)
        End Function

        <Authorize(Roles:="UserAdmin")>
        <HttpPost>
        Function Create(ByVal model As Models.Account.CreateModel) As ActionResult

            If ModelState.IsValid Then
                model.User.Password = _sec.Encrypt(model.User.Password, model.User.Username)
                _user.Create(model.User.ToEntity)
                _account.ManageRoles(model.User.Id, model.RoleList.ToDictionary(Function(f) f.RoleKey, Function(f) f.InRole))
                Return RedirectToAction("Manage")
            End If

            Return View(model)
        End Function

    End Class
End Namespace
