Namespace Web

    <Authorize(Roles:="LinkEditor")>
    Public Class ManageLinkController
        Inherits System.Web.Mvc.Controller

        Private _hl As Core.ILink
        Private _nl As Core.IHomeLink
        Private _urlsrv As Core.IUrlService

        Public Sub New(HL As Core.ILink, NL As Core.IHomeLink, URLSRV As Core.IUrlService)
            _hl = HL
            _nl = NL
            _urlsrv = URLSRV
        End Sub

#Region "Navigation"

        <Authorize(Roles:="LinkEditor")>
        Function Navigation() As ActionResult
            Return View(New Models.Manage.NavigationModel With {.Links = _nl.GetAll(False)})
        End Function

        <Authorize(Roles:="LinkEditor")>
        <HttpPost>
        Function NavigationStatusChange(ByVal id As String, ByVal display As Boolean) As RedirectToRouteResult
            Dim nav = _nl.ById(id)
            nav.Visible = display
            _nl.Update(nav)
            Return RedirectToAction("Navigation")
        End Function

        <Authorize(Roles:="LinkEditor")>
        <HttpPost>
        Function NavigationUpdate(ByVal id As String, ByVal display_text As String, ByVal visible As Boolean) As RedirectToRouteResult
            If display_text IsNot Nothing AndAlso display_text.Length > 0 Then
                Dim nav = _nl.ById(id)
                With nav
                    .DisplayText = display_text
                    .Visible = visible
                End With
                _nl.Update(nav)
            End If
            Return RedirectToAction("Navigation")
        End Function

        <Authorize(Roles:="LinkEditor")>
        <HttpPost>
        Function NavigationMove(ByVal id As String, ByVal order As Integer, ByVal direction As SByte) As RedirectToRouteResult
            Dim cur = _nl.ById(id)
            Dim rep = _nl.Table.Where(Function(f) f.Order = order + direction).FirstOrDefault

            If Not cur Is Nothing AndAlso rep IsNot Nothing Then
                'both have a value, update
                Dim co As Integer = cur.Order
                rep.Order = -1
                cur.Order = order + direction
                rep.Order = co
                _nl.Update(cur)
                _nl.Update(rep)
            End If

            Return RedirectToAction("Navigation")
        End Function

#End Region

#Region "External Links"

        <Authorize(Roles:="LinkEditor")>
        Function Links() As ActionResult
            Return View(New Models.Manage.LinksModel With {.Links = _hl.GetAll(False)})
        End Function

        <Authorize(Roles:="LinkEditor")>
        <HttpPost>
        Function LinkDelete(ByVal Id As String) As RedirectToRouteResult
            _hl.Delete(_hl.ById(Id))
            Return RedirectToAction("Links")
        End Function

        <Authorize(Roles:="LinkEditor")>
        <HttpPost>
        Function LinkMove(ByVal model As Data.Entity.Link, ByVal direction As SByte) As RedirectToRouteResult
            Dim cur = _hl.ById(model.Id.ToString)
            Dim rep = _hl.Table.Where(Function(f) f.Order = model.Order + direction).FirstOrDefault

            If Not cur Is Nothing AndAlso rep IsNot Nothing Then
                'both have a value, update
                Dim co As Integer = cur.Order
                rep.Order = -1
                cur.Order = model.Order + direction
                rep.Order = co
                _hl.Update(cur)
                _hl.Update(rep)
            End If

            Return RedirectToAction("Links")
        End Function

        <Authorize(Roles:="LinkEditor")>
        <HttpPost>
        Function LinkUpdate(ByVal model As Data.Entity.Link) As RedirectToRouteResult
            Dim cur = _hl.ById(model.Id.ToString)
            With cur
                .Name = model.Name
                .Url = _urlsrv.FormatLink(model.Url)
                .Visible = model.Visible
            End With
            _hl.Update(cur)
            Return RedirectToAction("Links")
        End Function

        <Authorize(Roles:="LinkEditor")>
        <HttpPost>
        Function LinkCreate(ByVal model As Data.Entity.Link) As RedirectToRouteResult
            If model.Name IsNot Nothing AndAlso model.Name.Length > 0 AndAlso model.Url IsNot Nothing AndAlso model.Url.Length > 0 Then
                model.Url = _urlsrv.FormatLink(model.Url)
                _hl.Create(model)
            End If
            Return RedirectToAction("Links")
        End Function

#End Region

    End Class
End Namespace
