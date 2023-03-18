Imports Web.Models.Tournament
Imports CaptchaMvc.Attributes

Namespace Web
    Public Class TournamentController
        Inherits System.Web.Mvc.Controller

        Private _torn As Core.ITournament
        Private _tornclass As Core.ITournament_Classification
        Private _emailSvc As Core.IEmailService
        Private _emailProfile As Core.IEmailProfile
        Private _localizer As Core.ILocalization

        Public Sub New(TORN As Core.ITournament, TORNCLASS As Core.ITournament_Classification, EMAILSVC As Core.IEmailService, EMAILPROF As Core.IEmailProfile, LOC As Core.ILocalization)
            _torn = TORN
            _tornclass = TORNCLASS
            _emailSvc = EMAILSVC
            _emailProfile = EMAILPROF
            _localizer = LOC
        End Sub

        Function Index() As ActionResult
            Dim model As New Models.Tournament.IndexModel With {.Tournaments = _torn.GetAll()}
            Return View(model)
        End Function

        Function Email(ByVal id As String) As ActionResult
            'quick validate
            If (String.IsNullOrEmpty(id)) Then
                Return RedirectToAction("Index")
            End If

            'load tournament by it's id so we can grab the subject
            Dim tournamentInfo = _torn.ById(id)

            'check if it's a valid id
            If (tournamentInfo Is Nothing OrElse String.IsNullOrEmpty(tournamentInfo.ContactEmail)) Then
                Return RedirectToAction("Index")
            End If

            'setup model and show view
            Dim model As EMailModel = New EMailModel()
            model.TournamentId = tournamentInfo.Id.ToString()
            model.ContactName = tournamentInfo.Contact
            model.Subject = tournamentInfo.EventName

            Return View(model)
        End Function

        <HttpPost>
        <CaptchaVerify("Captcha not valid")>
        <ValidateAntiForgeryToken>
        Function Email(ByVal model As EMailModel) As ActionResult
            'load tournament
            Dim tournamentInfo = _torn.ById(model.TournamentId)

            'validate
            If (tournamentInfo Is Nothing) Then
                ModelState.AddModelError("", "Error finding tournament")
            End If
            If (String.IsNullOrEmpty(model.FromEMail)) Then
                ModelState.AddModelError("", "From EMail is required")
            End If
            If (String.IsNullOrEmpty(model.FromName)) Then
                ModelState.AddModelError("", "From Name is required")
            End If
            If (String.IsNullOrEmpty(model.Body)) Then
                ModelState.AddModelError("", "Message is required")
            End If
            If (Not ModelState.IsValid()) Then
                Return View(model)
            End If

            'load profile
            Dim profileName = _localizer.ReadByKey("Tournament.EMail.SendProfile").Value
            Dim emailProfile = _emailProfile.ByName(profileName)

            ''send email
            model.SendErrorMessage = _emailSvc.SendEmail(emailProfile, model.FromName, tournamentInfo.ContactEmail, tournamentInfo.EventName & " [Tournament]", model.FromEMail, model.Body)
            If (Not String.IsNullOrEmpty(model.SendErrorMessage)) Then
                model.SendError = True
                Return View(model)
            End If

            Return RedirectToAction("Index")
        End Function

        <Authorize(Roles:="Tournament")>
        <ChildActionOnly>
        Function TournamentEmailProfile() As PartialViewResult
            Dim model As New TournamentEmailProfile() With
            {
                .EMailProfiles = _emailProfile.GetAll().Select(Function(f) f.Name).ToList(),
                .Name = _localizer.ReadByKey("Tournament.EMail.SendProfile").Value
            }

            Return PartialView(model)
        End Function

        <Authorize(Roles:="Tournament")>
        <HttpPost>
        <ValidateAntiForgeryToken>
        Function TournamentEmailProfile(ByVal model As TournamentEmailProfile) As ActionResult
            'update e-mail profile
            Dim profile = _localizer.ReadByKey("Tournament.EMail.SendProfile")
            profile.Value = model.Name
            _localizer.Update(profile)

            Return RedirectToAction("Manage")
        End Function

        <Authorize(Roles:="Tournament")>
        Function Manage() As ActionResult
            Dim model As New Models.Tournament.IndexModel With {.Tournaments = _torn.GetAll()}
            Return View(model)
        End Function

        <Authorize(Roles:="Tournament")>
        Function Create() As ActionResult
            Return View(New Models.Tournament.EditModel With {.Tourny = New Data.Entity.Tournament, .TournClassification = _tornclass.GetAll().Where(Function(f) f.Show).ToList})
        End Function

        <Authorize(Roles:="Tournament")>
        <HttpPost>
        Function Create(ByVal model As Models.Tournament.EditModel) As ActionResult
            'validate
            With model.Tourny
                If .EventName Is Nothing Then
                    ModelState.AddModelError("", "Event Name is Required")
                End If
                If .Center Is Nothing Then
                    ModelState.AddModelError("", "Center is Required")
                End If
                If .End_Date.HasValue AndAlso .End_Date.Value < .Start_Date Then
                    ModelState.AddModelError("", "End Date must be after Start Date")
                End If
            End With

            If ModelState.IsValid Then
                model.Tourny.Id = Guid.NewGuid()
                _torn.Create(model.Tourny)
                Return RedirectToAction("Manage")
            End If

            model.TournClassification = _tornclass.GetAll().Where(Function(f) f.Show).ToList
            Return View(model)
        End Function

        <Authorize(Roles:="Tournament")>
        Function Edit(ByVal id As String) As ActionResult
            Return View(New Models.Tournament.EditModel With {.Tourny = _torn.ById(id), .TournClassification = _tornclass.GetAll().Where(Function(f) f.Show).ToList})
        End Function

        <Authorize(Roles:="Tournament")>
        <HttpPost>
        Function Edit(ByVal model As Models.Tournament.EditModel) As ActionResult
            'validate
            With model.Tourny
                .EventUrl = .EventUrl.Trim()
                If .EventName Is Nothing Then
                    ModelState.AddModelError("", "Event Name is Required")
                End If
                If .Center Is Nothing Then
                    ModelState.AddModelError("", "Center is Required")
                End If
                If .End_Date.HasValue AndAlso .End_Date.Value < .Start_Date Then
                    ModelState.AddModelError("", "End Date must be after Start Date")
                End If
                If Not (.EventUrl.StartsWith("/") Or .EventUrl.StartsWith("http://")) Then
                    ModelState.AddModelError("", "Invalid URL")
                End If
            End With

            If ModelState.IsValid Then

                Dim t = _torn.ById(model.Tourny.Id.ToString)
                With t
                    .Center = model.Tourny.Center
                    .Contact = model.Tourny.Contact
                    .ContactEmail = model.Tourny.ContactEmail
                    .End_Date = model.Tourny.End_Date
                    .EventName = model.Tourny.EventName
                    .EventUrl = model.Tourny.EventUrl
                    .RegistrationClose = model.Tourny.RegistrationClose
                    .Start_Date = model.Tourny.Start_Date
                    .Tournament_ClassificationId = model.Tourny.Tournament_ClassificationId
                End With
                _torn.Update(model.Tourny)
                Return RedirectToAction("Manage")
            End If

            model.TournClassification = _tornclass.GetAll().Where(Function(f) f.Show).ToList
            Return View(model)
        End Function

        <Authorize(Roles:="Tournament")>
        <HttpPost>
        Function Delete(ByVal id As String) As RedirectToRouteResult
            _torn.Delete(_torn.ById(id))
            Return RedirectToAction("Manage")
        End Function

    End Class
End Namespace
