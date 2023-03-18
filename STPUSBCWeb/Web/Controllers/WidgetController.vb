Namespace Web
    Public Class WidgetController
        Inherits System.Web.Mvc.Controller

        <ChildActionOnly>
        Function GoogleAnalytics() As PartialViewResult
            Dim ga As String = System.Web.Configuration.WebConfigurationManager.AppSettings("GoogleAnalytic")
            Return PartialView(DirectCast(ga, Object))
        End Function

        <ChildActionOnly>
        Function ShareLinks() As PartialViewResult
            Return PartialView()
        End Function

    End Class
End Namespace
