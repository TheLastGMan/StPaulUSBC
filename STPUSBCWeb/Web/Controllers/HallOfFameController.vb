Imports Web.Models.HallOfFame
Namespace Web
    Public Class HallOfFameController
        Inherits System.Web.Mvc.Controller

        Private _hof As Core.IHallOfFameService
        Private _hofdb As Core.IHallOfFame
        Private _hofr As Core.IHallOfFame_RecognitionType
        Private _pdf As Core.IPDFCreater

        Public Sub New(HOF As Core.IHallOfFameService, HOFDB As Core.IHallOfFame, HOFR As Core.IHallOfFame_RecognitionType, PDF As Core.IPDFCreater)
            _hof = HOF
            _hofdb = HOFDB
            _hofr = HOFR
            _pdf = PDF
        End Sub

        Function Index(Optional ByVal sort As Core.Services.HallOfFame.SortMethod = Core.Services.HallOfFame.SortMethod.achieveddesc) As ActionResult
            Dim model As New IndexModel With {.hoflist = _hof.BriefList(sort), .SortMethod = sort}
            Return View(model)
        End Function

        Shadows Function Profile(ByVal id As String, Optional ByVal seo As String = "") As ActionResult
            Dim lid As Integer = 0
            Integer.TryParse(id, lid)
            Return View(New ProfileModel With {.Profile = _hofdb.ById(lid), .ImageData = _hof.ProfilePicture(lid)})
        End Function

        Private Shared Property LockMe As New Object
        <NonAction()>
        Private Function FileContents(ByRef path As String, Optional ByVal mappath As Boolean = True) As Byte()
            Dim fp As String = path
            If mappath Then
                fp = Server.MapPath(fp)
            End If

            Dim out As Byte()
            SyncLock LockMe
                Using IOR As New IO.StreamReader(fp)
                    out = New Byte(IOR.BaseStream.Length) {}
                    IOR.BaseStream.Read(out, 0, IOR.BaseStream.Length)
                End Using
            End SyncLock

            Return out
        End Function

        Function Print(ByVal id As String) As ActionResult
            Dim profile = _hofdb.ById(id)
            Dim file As String = String.Format("{0}-{1}", profile.FirstName & " " & profile.LastName, profile.Achieved.ToString("ddMMMyyyy"))
            HttpContext.Response.AddHeader("content-disposition", "inline; filename=" & file & ".pdf")

            If profile IsNot Nothing Then
                Dim stream As IO.MemoryStream = _pdf.HallOfFameProfile(profile)
                Return New FileStreamResult(stream, "application/pdf")
            End If

            Return RedirectToAction("Index", "Home")
            'award/PrintAward/0b635f1f-7b98-451a-bdcb-ab90f7698d0c
        End Function

#Region "Manage Options"

        <Authorize(Roles:="HallOFame")>
        Function Manage() As ActionResult
            Return View(New Models.HallOfFame.ManageModel With {.Famers = _hofdb.GetAll(False)})
        End Function

        <Authorize(Roles:="HallOFame")>
        Function Activate(ByVal id As Integer, ByVal status As Boolean) As RedirectToRouteResult
            _hofdb.ActivateChange(id, status)
            Return RedirectToAction("Manage")
        End Function

        <Authorize(Roles:="HallOFame")>
        Function Create() As ActionResult
            Return View(New Models.HallOfFame.EditModel With {.Famer = New Data.Entity.HallOfFame, .Types = _hofr.GetAll, .ImageData = _hof.ProfilePicture(0)})
        End Function

        <Authorize(Roles:="HallOFame")>
        <HttpPost>
        <ValidateInput(False)>
        Function Create(ByVal model As Models.HallOfFame.EditModel, ByVal htmleditor As String, ByVal profileimage As HttpPostedFileBase) As ActionResult
            With model.Famer
                If .FirstName Is Nothing Then
                    ModelState.AddModelError("", "First Name is Required")
                End If
                If .LastName Is Nothing Then
                    ModelState.AddModelError("", "Last Name is Required")
                End If
                If .Achieved = New Date() Then
                    ModelState.AddModelError("", "Achieved Date is Required")
                End If
                If .HallOfFame_RecognitionTypeId Is Nothing Then
                    ModelState.AddModelError("", "Recognition Type is Required")
                End If
            End With

            If ModelState.IsValid Then
                With model.Famer
                    .WriteUp = htmleditor
                    'picture
                    If profileimage IsNot Nothing Then
                        .PictureMime = profileimage.ContentType.Substring(profileimage.ContentType.LastIndexOf("/") + 1)
                        Dim image() As Byte = New Byte(profileimage.ContentLength) {}
                        .Picture = New Byte(profileimage.ContentLength) {}
                        profileimage.InputStream.Read(.Picture, 0, profileimage.ContentLength)

                        _hof.SaveProfilePicture(.Id, .Picture, .PictureMime)
                    End If
                End With
                _hofdb.Create(model.Famer)
                Return RedirectToAction("Manage")
            Else
                model.Famer.WriteUp = htmleditor
                model.ImageData = _hof.ProfilePicture(model.Famer.Id)
                model.Types = _hofr.GetAll()
                Return View(model)
            End If
        End Function

        <Authorize(Roles:="HallOFame")>
        Function Edit(ByVal id As String) As ActionResult
            Return View(New Models.HallOfFame.EditModel With {.Famer = _hofdb.ById(id), .Types = _hofr.GetAll(), .ImageData = _hof.ProfilePicture(id)})
        End Function

        <Authorize(Roles:="HallOFame")>
        <HttpPost>
        <ValidateInput(False)>
        Function Edit(ByVal model As Models.HallOfFame.EditModel, ByVal htmleditor As String, ByVal profileimage As HttpPostedFileBase) As ActionResult
            With model.Famer
                If .FirstName Is Nothing Then
                    ModelState.AddModelError("", "First Name is Required")
                End If
                If .LastName Is Nothing Then
                    ModelState.AddModelError("", "Last Name is Required")
                End If
                If .Achieved = New Date() Then
                    ModelState.AddModelError("", "Achieved Date is Required")
                End If
                If .HallOfFame_RecognitionTypeId Is Nothing Then
                    ModelState.AddModelError("", "Recognition Type is Required")
                End If
            End With

            If ModelState.IsValid Then
                Dim hof = _hofdb.ById(model.Famer.Id)
                With hof
                    .FirstName = model.Famer.FirstName
                    .LastName = model.Famer.LastName
                    .HallOfFame_RecognitionTypeId = model.Famer.HallOfFame_RecognitionTypeId
                    .USBC_ID = model.Famer.USBC_ID
                    .Deceased = model.Famer.Deceased
                    .Display = model.Famer.Display
                    .Achieved = model.Famer.Achieved
                    .WriteUp = htmleditor
                    'picture
                    If profileimage IsNot Nothing Then
                        .PictureMime = profileimage.ContentType.Substring(profileimage.ContentType.LastIndexOf("/") + 1)
                        Dim image() As Byte = New Byte(profileimage.ContentLength) {}
                        .Picture = New Byte(profileimage.ContentLength) {}
                        profileimage.InputStream.Read(.Picture, 0, profileimage.ContentLength)

                        _hof.SaveProfilePicture(.Id, .Picture, .PictureMime)
                    End If
                    _hofdb.Update(hof)
                End With
                Return RedirectToAction("Manage")
            Else
                model.Famer.WriteUp = htmleditor
                model.Types = _hofr.GetAll()
                Return View(model)
            End If

        End Function

        <Authorize(Roles:="HallOFame")>
        <HttpPost>
        Function Delete(ByVal id As Integer) As PartialViewResult
            Dim model As New Models.HallOfFame.DeleteModel With {
                .CancelAction = "Manage",
                .PostBackForm = "DeleteConfirm",
                .id = id}
            Return PartialView(model)
        End Function

        <Authorize(Roles:="HallOFame")>
        <HttpPost>
        Function DeleteConfirm(ByVal id As Integer) As RedirectToRouteResult
            _hofdb.Delete(_hofdb.ById(id))
            Return RedirectToAction("Manage")
        End Function

#End Region

#Region "Manage Type"

        <Authorize(Roles:="HallOFame")>
        Function ManageType() As ActionResult
            Return View(New Models.HallOfFame.ManageTypeModel With {.Types = _hofr.GetAll})
        End Function

        <Authorize(Roles:="HallOFame")>
        <HttpPost>
        Function CreateType(ByVal model As Data.Entity.HallOfFame_RecognitionType) As RedirectToRouteResult
            If model.Description IsNot Nothing Then
                _hofr.Create(model)
            End If
            Return RedirectToAction("ManageType")
        End Function

        <Authorize(Roles:="HallOFame")>
        <HttpPost>
        Function UpdateType(ByVal model As Data.Entity.HallOfFame_RecognitionType) As RedirectToRouteResult
            If model.Description IsNot Nothing Then
                Dim m = _hofr.ById(model.Id)
                m.Description = model.Description
                m.Display = model.Display
                _hofr.Update(m)
            End If
            Return RedirectToAction("ManageType")
        End Function

        <Authorize(Roles:="HallOFame")>
        <HttpPost>
        Function DeleteType(ByVal id As Integer) As RedirectToRouteResult
            _hofr.Delete(_hofr.ById(id))
            Return RedirectToAction("ManageType")
        End Function

        <Authorize(Roles:="HallOFame")>
        <HttpPost>
        Function DisplayStatusType(ByVal id As Integer, ByVal show As Boolean) As RedirectToRouteResult
            Dim m = _hofr.ById(id)
            m.Display = show
            _hofr.Update(m)
            Return RedirectToRoute("ManageType")
        End Function

#End Region

    End Class

End Namespace
