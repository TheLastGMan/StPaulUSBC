Imports Web.Models.Account
Imports Web.Models.EmailProfile

Namespace Web
    Public Class EmailProfileController
        Inherits System.Web.Mvc.Controller

        Private _loc As Core.ILocalization
        Private _settings As Core.ISetting
        Private _emailProfile As Core.IEmailProfile

        Public Sub New(ByVal Loc As Core.ILocalization, ByVal Setting As Core.ISetting, ByVal EmailProfile As Core.IEmailProfile)
            _loc = Loc
            _settings = Setting
            _emailProfile = EmailProfile
        End Sub

        <Authorize(Roles:="EmailProfile")>
        Public Function Manage() As ActionResult
            Dim model = New EmailManage()
            model.Profiles = _emailProfile.GetAll()
            model.ActiveProfiles.Add(_loc.ReadByKey("Award.New.EmailProfileName").Value)
            model.ActiveProfiles.Add(_loc.ReadByKey("Tournament.EMail.SendProfile").Value)

            Return View(model)
        End Function

        <Authorize(Roles:="EmailProfile")>
        Public Function Edit(ByVal id As String) As ActionResult
            Dim model = _emailProfile.ByName(id)
            Return View(model)
        End Function

        <Authorize(Roles:="EmailProfile")>
        <HttpPost>
        <ValidateAntiForgeryToken>
        Public Function Edit(ByVal model As Data.Entity.EmailProfile) As ActionResult
            Dim dbModel = _emailProfile.ByName(model.Name)
            dbModel.SendAs = model.SendAs
            dbModel.DisplayName = model.DisplayName
            dbModel.SmtpHost = model.SmtpHost
            dbModel.SmtpPort = model.SmtpPort
            dbModel.UserName = model.UserName
            dbModel.Password = model.Password

            _emailProfile.Update(dbModel)
            Return RedirectToAction("Manage")
        End Function

        <Authorize(Roles:="EmailProfile")>
        Public Function Create() As ActionResult
            Return View(New Data.Entity.EmailProfile())
        End Function

        <Authorize(Roles:="EmailProfile")>
        <HttpPost>
        <ValidateAntiForgeryToken>
        Public Function Create(ByVal model As Data.Entity.EmailProfile) As ActionResult
            _emailProfile.Create(model)
            Return RedirectToAction("Manage")
        End Function

        <Authorize(Roles:="EmailProfile")>
        <HttpPost>
        <ValidateAntiForgeryToken>
        Public Function Delete(ByVal id As String) As ActionResult
            Dim model = _emailProfile.ByName(id)

            'validate this is not the current profile
            'delete if it's not
            Dim curProfile = _loc.ReadByKey("Award.New.EmailProfileName").Value
            If (Not model.Name.Equals(curProfile)) Then
                _emailProfile.Delete(model)
            End If

            Return RedirectToAction("Manage")
        End Function

    End Class
End Namespace
