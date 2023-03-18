Namespace Web
    Public Class ErrorsController
        Inherits System.Web.Mvc.Controller

        '
        ' GET: /Errors

        <HandleError>
        Function Main() As ActionResult
            Return View()
        End Function

    End Class
End Namespace
