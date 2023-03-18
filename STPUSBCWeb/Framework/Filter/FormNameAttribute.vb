Imports System.Web.Mvc
Namespace Filter

    Public Class FormNameAttribute
        Inherits FilterAttribute
        Implements IActionFilter

        Private ReadOnly _name As String
        Private ReadOnly _actionParameter As String

        Public Sub New(ByVal name As String, ByVal actionParameter As String)
            _name = name
            _actionParameter = actionParameter
        End Sub

        Public Sub OnActionExecuted(filterContext As Web.Mvc.ActionExecutedContext) Implements Web.Mvc.IActionFilter.OnActionExecuted

        End Sub

        Public Sub OnActionExecuting(filterContext As Web.Mvc.ActionExecutingContext) Implements Web.Mvc.IActionFilter.OnActionExecuting
            Dim formvalue = filterContext.RequestContext.HttpContext.Request.Form(_name)
            filterContext.ActionParameters(_actionParameter) = Not String.IsNullOrEmpty(formvalue)
        End Sub

    End Class

End Namespace
