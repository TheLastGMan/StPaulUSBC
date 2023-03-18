Imports System.Web.Mvc
Namespace Filter

    Public Class SubmitNameAttribute
        Inherits ActionNameSelectorAttribute

        Private ReadOnly _form As String

        Public Sub New(ByVal form As String)
            _form = form
        End Sub

        Public Overloads Overrides Function IsValidName(controllerContext As ControllerContext, actionName As String, methodInfo As Reflection.MethodInfo) As Boolean
            If actionName.Equals(methodInfo.Name, StringComparison.InvariantCultureIgnoreCase) Then
                Return True
            End If

            If Not actionName.Equals(_form, StringComparison.InvariantCultureIgnoreCase) Then
                Return False
            End If

            Dim request = controllerContext.RequestContext.HttpContext.Request
            Dim ret As Boolean = request(methodInfo.Name) IsNot Nothing
            Return ret
        End Function
    End Class

End Namespace
