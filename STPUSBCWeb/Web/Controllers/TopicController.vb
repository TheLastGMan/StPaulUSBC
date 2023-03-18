Namespace Web

    Public Class TopicController
        Inherits System.Web.Mvc.Controller

        Private _topic As Core.ITopic
        Private _urlsrv As Core.IUrlService

        Public Sub New(T As Core.ITopic, URLSRVC As Core.IUrlService)
            _topic = T
            _urlsrv = URLSRVC
        End Sub

        <ChildActionOnly>
        Function Widget(ByVal seo As String) As PartialViewResult
            'like topic but contained within a page
            Return PartialView(DetermineTopicModel(_topic.ByTypeSeo(Data.Entity.TopicType.Widget, seo), seo))
        End Function

        Function Topic(ByVal seo As String) As ActionResult
            Return View("Page", DetermineTopicModel(_topic.ByTypeSeo(Data.Entity.TopicType.Topic, seo), seo))
        End Function

        Function Page(ByVal seo As String) As ActionResult
            'same as topic, but show up in Pages Tab
            Return View(DetermineTopicModel(_topic.ByTypeSeo(Data.Entity.TopicType.Page, seo), seo))
        End Function

        Function SEOS(ByVal seo As String) As ActionResult
            'same as everything else but, searches by seo tag
            Return View("Page", DetermineTopicModel(_topic.BySeo(seo), seo))
        End Function

        <NonAction>
        Private Function DetermineTopicModel(ByRef topic As Data.Entity.Topic, ByRef search_term As String) As Models.Topic.PageModel
            Dim model As New Models.Topic.PageModel
            If topic IsNot Nothing Then
                model.Title = topic.seo
                model.RawContent = topic.content
                model.LastUpdated = topic.updatedutc
            Else
                model.RawContent = "<h1>" & search_term & "</h1><h1>Page Not Found</h1>"
            End If
            Return model
        End Function

        <ChildActionOnly>
        Function Links() As ActionResult
            'return pages
            Dim model As New Models.Topic.PageLinkModel With {.Pages = _topic.ByType(Data.Entity.TopicType.Page).Where(Function(f) f.active).ToList}
            Return View(model)
        End Function

#Region "Management Options"

        <Authorize(Roles:="ContentEditor")>
        Function Manage(Optional ByVal seo As Integer = 1) As ActionResult
            Dim model As New Models.Topic.ManageModel With {.Topics = _topic.ByType(seo), .seoid = seo}
            If model.Topics.Count > 0 Then
                model.LastUpdated = model.Topics.OrderByDescending(Function(f) f.updatedutc).Select(Function(f) f.updatedutc).First
            End If

            Return View(model)
        End Function

        <Authorize(Roles:="ContentEditor")>
        Function Create() As ActionResult
            Dim model As New Models.Topic.EditModel With {.Topic = New Data.Entity.Topic}
            Return View(model)
        End Function

        <Authorize(Roles:="ContentEditor")>
        <HttpPost>
        <ValidateInput(False)>
        Function Create(ByVal seo As String, ByVal typex As String, ByVal htmlcontent As String, ByVal active As Boolean) As ActionResult
            Dim topic As New Data.Entity.Topic With {.seo = seo, .TopicTypeId = [Enum].Parse(GetType(Data.Entity.TopicType), typex), .content = htmlcontent, .active = active}
            Dim model As New Models.Topic.EditModel With {.Topic = topic}

            If topic.seo.Length = 0 Then
                ModelState.AddModelError("", "Name is Required")
                Return View(model)
            ElseIf _topic.BySeo(topic.seo) IsNot Nothing Then
                ModelState.AddModelError("", "Name Already Exists")
                Return View(model)
            ElseIf topic.TopicTypeId = Data.Entity.TopicType.Widget Then
                ModelState.AddModelError("", "Widgets Can Not Be Created")
                Return View(model)
            End If

            _topic.Create(topic)
            Return RedirectToAction("Manage", New With {.seo = topic.TopicTypeId})
        End Function

        <Authorize(Roles:="ContentEditor")>
        Function Edit(ByVal seo As String) As ActionResult
            Dim model As New Models.Topic.EditModel With {.Topic = _topic.BySeo(seo)}
            Return View(model)
        End Function

        <Authorize(Roles:="ContentEditor")>
        <HttpPost>
        Function Delete(ByVal seo As String, ByVal seodisplay As String) As ActionResult
            Return View(New Models.Topic.DeleteModel With {.seo = seo, .seodisplay = seodisplay})
        End Function

        <Authorize(Roles:="ContentEditor")>
        <HttpPost>
        Function DeleteYes(ByVal model As Models.Topic.DeleteModel) As RedirectToRouteResult
            _topic.Delete(_topic.BySeo(model.seodisplay))
            Return RedirectToAction("Manage", New With {.seo = model.seo})
        End Function

        <Authorize(Roles:="ContentEditor")>
        <HttpPost>
        <ValidateInput(False)>
        Function Update(ByVal model As Models.Topic.EditModel, ByVal htmlcontent As String) As ActionResult
            Dim t = _topic.BySeo(model.Topic.seo)
            t.content = htmlcontent
            _topic.Update(t)
            Return RedirectToAction("Manage")
        End Function

#End Region

    End Class
End Namespace
