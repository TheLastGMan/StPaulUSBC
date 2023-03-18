Imports System.Web.Mvc
Namespace Filter

    Public Class AJAXOnlyAttribute
        Inherits System.Web.Mvc.ActionMethodSelectorAttribute

        Public Sub New()

        End Sub

        Public Overrides Function IsValidForRequest(controllerContext As ControllerContext, methodInfo As Reflection.MethodInfo) As Boolean
            Dim ajaxreq As Boolean = controllerContext.HttpContext.Request.IsAjaxRequest
            Return ajaxreq
        End Function

    End Class

End Namespace
