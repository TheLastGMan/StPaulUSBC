Imports System.Web.Mvc
Imports System.Net
Imports System.Web

Namespace Filter

    Public Class CustomErrorHandler : Inherits FilterAttribute : Implements IExceptionFilter

        Public Sub OnException(filterContext As ExceptionContext) Implements IExceptionFilter.OnException
            Dim statuscode = TryCast(filterContext.Exception, HttpException)
            Dim sc As Integer = 0
            If statuscode IsNot Nothing Then
                sc = statuscode.GetHttpCode
            End If

            Dim result = CreateActionResult(filterContext, sc)
            filterContext.Result = result

            filterContext.ExceptionHandled = True
            With filterContext.HttpContext.Response
                .Clear()
                .StatusCode = sc
                .TrySkipIisCustomErrors = True
            End With
        End Sub

        Private Function CreateActionResult(ByRef filterContext As ExceptionContext, ByRef statuscode As Integer) As ActionResult
            Dim ctx = New ControllerContext(filterContext.RequestContext, filterContext.Controller)
            Dim codename = DirectCast(statuscode, HttpStatusCode).ToString

            Dim viewname = SelectFirstView(ctx, String.Format("~/Views/Error/{0}.vbhtml", statuscode),
                                                                                    "~/Views/Error/General.vbhtml",
                                                                                    codename,
                                                                                    "Error")
            Dim controller = filterContext.RouteData.Values("controller").ToString
            Dim action = filterContext.RouteData.Values("action").ToString
            Dim model = New HandleErrorInfo(filterContext.Exception, controller, action)
            Dim result As New ViewResult With {
                .ViewName = viewname,
                .ViewData = New ViewDataDictionary(Of HandleErrorInfo)(model)}
            result.ViewData("StatusCode") = statuscode
            Return result
        End Function

        Private Function SelectFirstView(ByRef ctx As ControllerContext, ParamArray viewNames() As String) As String
            Dim lctx As ControllerContext = ctx
            Return viewNames.First(Function(v) ViewExists(lctx, v))
        End Function

        Private Function ViewExists(ByRef ctx As ControllerContext, ByRef view As String)
            Dim res = ViewEngines.Engines.FindView(ctx, view, Nothing)
            Return res.View IsNot Nothing
        End Function

    End Class

End Namespace
