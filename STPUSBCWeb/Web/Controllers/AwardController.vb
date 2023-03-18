Imports Framework.Filter
Imports Framework
Imports Web.Models.Award

Namespace Web
    Public Class AwardController
        Inherits System.Web.Mvc.Controller

        Private _award As Core.IAward
        Private _awardcont As Core.IAwardName
        Private _awardivision As Core.IAwardDivision
        Private _awardtype As Core.IAwardType
        Private _loc As Core.ILocalization
        Private _pdf As Core.IPDFCreater
        Private _emailProfile As Core.IEmailProfile
        Private _emailService As Core.IEmailService

        Sub New(AC As Core.IAwardName, AD As Core.IAwardDivision, AT As Core.IAwardType, AST As Core.IAward, LOC As Core.ILocalization, PDF As Core.IPDFCreater, EMAILPROFILE As Core.IEmailProfile, EMAILSVC As Core.IEmailService)
            _awardcont = AC
            _awardivision = AD
            _awardtype = AT
            _award = AST
            _loc = LOC
            _pdf = PDF
            _emailProfile = EMAILPROFILE
            _emailService = EMAILSVC
        End Sub

        Function PrintAward(ByVal id As String) As StreamContentResult
            Dim award = _award.ById(id)
            Dim fileName As String = String.Format("{0}-{1}.pdf", award.BowlerName, award.DateBowled.ToString("ddMMMyyyy"))
            'HttpContext.Response.AddHeader("content-disposition", "inline; filename=" & fileName)

            If award IsNot Nothing Then
                Dim scheme As String = Url.RequestContext.HttpContext.Request.Url.Scheme
                Dim awardUrl As String = Url.Action("PrintAward", "Award", New With {.action = "PrintAward", .id = award.Id.ToString}, scheme)
                Dim stream As IO.MemoryStream = _pdf.AwardForm(award, awardUrl)
                stream.Position = 0
                Return New StreamContentResult(stream.ToArray(), "application/pdf", fileName) With {.Inline = True}
            End If

            Return Nothing
            'Return RedirectToAction("Index", "Home")
            'award/PrintAward/0b635f1f-7b98-451a-bdcb-ab90f7698d0c
        End Function

#Region "Index / Bowler Info"

        Function Index(id As Guid?) As ActionResult
            Dim model As New Models.Award.BowlerInfo

            If id IsNot Nothing Then
                'map award to bowler info
                Dim a As New Data.Entity.Award
                If AwardStatus(id, a) = AwardStat.Good Then
                    model = a.ToBowlerInfo()
                    model.AwardID = a.Id
                End If
            End If

            'fill model with default values
            With model
                .BowlerTypeLst = _awardtype.Table.OrderBy(Function(f) f.Description).ToList
                .CenterLst = _award.CenterList
                .LeagueLst = _award.LeagueList
                .BowlerLst = _award.BowlerList
            End With

            Return View("BowlerInfo", model)
        End Function

        Function BowlerInfo(id As Guid) As RedirectToRouteResult
            'prefilled bowler info
            If Not AwardStatus(id, New Data.Entity.Award) = AwardStat.Good Then
                id = Nothing
            End If
            Return RedirectToAction("Index", New With {.id = id})
        End Function

        <HttpPost>
        <ValidateAntiForgeryToken>
        Function BowlerInfo(model As Models.Award.BowlerInfo) As ActionResult
            Dim award As New Data.Entity.Award
            award = model.ToEntity(award)

            If Not model.AwardID.HasValue Then
                'no award id set, create a new one
                'create and update record, admin Award Manage will automatically cause the deletion of any unfinished forms
                _award.Create(award)
                _award.Update(award)
            End If
            model.AwardID = award.Id

            Return RedirectToAction("USBCAwards", New With {.id = model.AwardID})
        End Function

#End Region

#Region "USBC Awards"

        Function USBCAwards(id As Guid) As ActionResult
            Dim award As New Data.Entity.Award
            If Not AwardStatus(id, award) = AwardStat.Good Then
                Return RedirectToAction("Index")
            End If

            Dim model As New Models.Award.USBCAwards With {
                .AwardId = id,
                .USBCAwardLst = _awardcont.ByDivisionType(1, award.AwardTypeId).Where(Function(f) award.BowlerAverage <= f.AverageHigh).Select(Function(f) New Models.Award.AwardDualValue With {.Key = f.Name, .Value = False}).ToList
            }
            Return View(model)
        End Function

        <HttpPost>
        Function USBCAwards(ByVal model As Models.Award.USBCAwards) As ActionResult
            Dim award As Data.Entity.Award = _award.ById(model.AwardId.ToString)

            'map info to award
            award.USBCAwardList = model.USBCAwardLst.Where(Function(f) f.Value = True).Select(Function(f) f.Key).ToList
            'update
            _award.Update(award)

            Return RedirectToAction("LocalAwards", New With {.id = award.Id})
        End Function

#End Region

#Region "Local Awards"

        Function LocalAwards(id As Guid) As ActionResult
            Dim award As New Data.Entity.Award
            If Not AwardStatus(id, award) = AwardStat.Good Then
                Return RedirectToAction("Index")
            End If

            Dim model As New Models.Award.LocalAwards With {
                .AwardId = award.Id,
                .AwardTypeId = award.AwardTypeId,
                .LocalAwardLst = _awardcont.ByDivisionType(2, award.AwardTypeId).Where(Function(f) award.BowlerAverage <= f.AverageHigh).Select(Function(f) New Models.Award.AwardDualValue With {.Key = f.Name, .Value = False}).ToList,
                .AwardChoiceLst = _awardcont.ByDivision(3)
            }

            Return View(model)
        End Function

        <HttpPost>
        Function LocalAwards(ByVal model As Models.Award.LocalAwards) As ActionResult
            Dim award As Data.Entity.Award = _award.ById(model.AwardId.ToString)

            'map info to award
            award.LocalAwardList = model.LocalAwardLst.Where(Function(f) f.Value = True).Select(Function(f) f.Key).ToList
            If model.AwardChoiceId > 0 Then
                award.AdultAwardChoice = _awardcont.ById(model.AwardChoiceId).Name
            End If

            'update
            _award.Update(award)

            'check for awards
            If (award.USBCAwardList.Count + award.LocalAwardList.Count) = 0 Then
                'need awards, redirect
                Return RedirectToAction("BowlerInfo", New With {.id = award.Id})
            End If

            Return RedirectToAction("SecretaryInfo", New With {.id = award.Id})
        End Function

#End Region

#Region "Secretary Info"

        Function SecretaryInfo(id As Guid) As ActionResult
            Dim award As New Data.Entity.Award
            If Not AwardStatus(id, award) = AwardStat.Good Then
                Return RedirectToAction("Index")
            End If

            Dim model As Models.Award.SecretaryInfo = SavedSecretaryInfo
            If model Is Nothing Then
                model = New Models.Award.SecretaryInfo With {.AwardId = award.Id}
            End If
            model.AwardId = award.Id

            Return View(model)
        End Function

        <HttpPost>
        <ValidateAntiForgeryToken>
        Function SecretaryInfo(ByVal model As Models.Award.SecretaryInfo) As ActionResult
            Dim award As Data.Entity.Award = _award.ById(model.AwardId.ToString)

            'map info to award
            award = model.ToEntity(award)

            'reset pin and save to session
            model.SecretaryPin = ""
            SavedSecretaryInfo = model

            'update
            award.Submitted = True
            _award.Update(award)

            'send award e-mail
            Dim senderProfile As String = _loc.ReadByKey("Award.New.EmailProfileName").Value
            Dim emailProfile = _emailProfile.ByName(senderProfile)
            Dim sendTo As String = _loc.ReadByKey("Award.New.ToEmailAddress").Value
            Dim subject As String = _loc.ReadByKey("Award.New.EmailSubject").Value
            Dim body As String = _loc.ReadByKey("Award.New.EmailTemplate").Value
            Dim scheme As String = Url.RequestContext.HttpContext.Request.Url.Scheme
            Dim awardUrl As String = Url.Action("PrintAwardAdmin", "Award", New With {.action = "PrintAwardAdmin", .id = award.Id.ToString}, scheme)
            body = body.Replace("{URL}", awardUrl)

            'send e-mail, not a big deal if it doesn't send, it's not archived yet
            Dim result As String = _emailService.SendEmail(emailProfile, sendTo, subject, body)
            If (result.Length > 0) Then
                Throw New Exception("E-Mail Failed | " & result)
            End If


            'show final award view
            Return View("AwardFormSuccess", award)
        End Function

#End Region

#Region "Common Functions"

        Private Const SavedSecreturnInfoSession As String = "AwardSecretaryInfo"
        Private Property SavedSecretaryInfo
            Get
                Dim res As Models.Award.SecretaryInfo = DirectCast(Session(SavedSecreturnInfoSession), Models.Award.SecretaryInfo)
                If res Is Nothing Then
                    res = New Models.Award.SecretaryInfo
                    SavedSecretaryInfo = res
                End If
                Return res
            End Get
            Set(value)
                Session(SavedSecreturnInfoSession) = value
            End Set
        End Property

        Private Function HasUSBCAwards(AwardTypeId As Integer, Ave As Short) As Boolean
            Return _awardcont.ByDivisionType(1, AwardTypeId).Where(Function(f) Ave <= f.AverageHigh).Count > 0
        End Function

        Private Function HasLocalAwards(AwardTypeId As Integer, Ave As Short) As Boolean
            Return _awardcont.ByDivisionType(2, AwardTypeId).Where(Function(f) Ave <= f.AverageHigh).Count > 0
        End Function

        Private Function AwardStatus(ByRef id As Guid, ByRef award As Data.Entity.Award) As AwardStat
            award = _award.ById(id.ToString)
            If award Is Nothing Then
                Return AwardStat.DoesNotExist
            End If
            If award.Archived Then
                Return AwardStat.Archived
            End If
            If award.Submitted Then
                Return AwardStat.Submitted
            End If
            Return AwardStat.Good
        End Function

        Private Enum AwardStat As Byte
            DoesNotExist = 0
            Good = 1
            Submitted = 2
            Archived = 3
        End Enum

#End Region

#Region "Manage"

        <Authorize(Roles:="Award")>
        Function Manage() As ActionResult
            'auto remove any unfinished forms
            _award.DeleteOlderThan(7)

            Dim lst As List(Of Models.Award.ManageModel) =
                _award.GetAll(True).OrderBy(Function(f) f.AddedUTC) _
                .Select(Function(f) f.ToManageModel) _
                .ToList()

            Return View(lst)
        End Function

        <Authorize(Roles:="Award")>
        Public Function PrintAwardAdmin(ByVal id As String) As StreamContentResult
            'load award stream first in case there is an error
            Dim awardStream = PrintAward(id)

            'archive award since an admin viewed it
            Dim award = _award.ById(id)
            award.Archived = True
            _award.Update(award)

            'show reward
            Return awardStream
        End Function

        <Authorize(Roles:="Award")>
        <ChildActionOnly>
        Public Function AwardEmailProfile() As PartialViewResult
            Dim model = New AwardEmailProfile() With
            {
                .Name = _loc.ReadByKey("Award.New.EmailProfileName").Value,
                .ToEmailAddress = _loc.ReadByKey("Award.New.ToEmailAddress").Value,
                .EMailProfiles = _emailProfile.GetAll().Select(Function(f) f.Name).ToList()
            }

            Return PartialView(model)
        End Function

        <Authorize(Roles:="Award")>
        <HttpPost>
        <ValidateAntiForgeryToken>
        Public Function AwardEmailProfile(ByVal model As AwardEmailProfile) As ActionResult
            'update e-mail profile
            Dim profile = _loc.ReadByKey("Award.New.EmailProfileName")
            profile.Value = model.Name
            _loc.Update(profile)

            'update sendto e-mail address
            Dim sendToProfile = _loc.ReadByKey("Award.New.ToEmailAddress")
            sendToProfile.Value = model.ToEmailAddress
            _loc.Update(sendToProfile)

            'show manage page
            Return RedirectToAction("Manage")
        End Function

#End Region

#Region "Award Option"

        <Authorize(Roles:="Award")>
        Function AwardOption() As ActionResult
            Dim model As New Models.Award.AwardOptionModel With {
                .AwardOptions = _awardcont.Table.OrderBy(Function(f) f.Name).ToList,
                .Divisions = _awardivision.GetAll,
                .Types = _awardtype.GetAll}
            Return View(model)
        End Function

        <Authorize(Roles:="Award")>
        <HttpPost>
        Function CreateAwardOption(ByVal model As Data.Entity.AwardName) As RedirectToRouteResult
            If Not String.IsNullOrEmpty(model.Name) Then
                _awardcont.Create(model)
            End If
            Return RedirectToAction("AwardOption")
        End Function

        <Authorize(Roles:="Award")>
        <HttpPost>
        Function UpdateAwardOption(ByVal model As Data.Entity.AwardName) As RedirectToRouteResult
            If ModelState.IsValid Then
                Dim award = _awardcont.ById(model.Id)
                With award
                    .Name = model.Name
                    .AverageHigh = model.AverageHigh
                    .Visible = model.Visible
                    .AwardTypeId = model.AwardTypeId
                    .AwardDivisionId = model.AwardDivisionId
                End With
                _awardcont.Update(award)
            End If

            Return RedirectToAction("AwardOption")
        End Function

        <Authorize(Roles:="Award")>
        <HttpPost>
        Function DeleteAwardOption(ByVal id As Integer) As RedirectToRouteResult
            _awardcont.Delete(_awardcont.ById(id))
            Return RedirectToAction("AwardOption")
        End Function

#End Region

#Region "Award Type"

        <Authorize(Roles:="Award")>
        Function AwardType() As ActionResult
            Return View(_awardtype.GetAll)
        End Function

        <Authorize(Roles:="Award")>
        <HttpPost>
        Function UpdateAwardType(ByVal key As Integer, ByVal value As String) As RedirectToRouteResult
            Dim award = _awardtype.byId(key)
            award.Description = value
            Return RedirectToAction("AwardType")
        End Function

#End Region

#Region "Award Division"

        <Authorize(Roles:="Award")>
        Function AwardOptionType() As ActionResult
            Return View(_awardivision.GetAll)
        End Function

        <Authorize(Roles:="Award")>
        <HttpPost>
        Function UpdateAwardDivision(ByVal key As Integer, ByVal value As String) As RedirectToRouteResult
            Dim award = _awardivision.byId(key)
            award.Description = value
            Return RedirectToAction("AwardOptionType")
        End Function

#End Region

    End Class
End Namespace
