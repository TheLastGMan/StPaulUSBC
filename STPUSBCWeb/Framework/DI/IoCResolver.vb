Imports System.Web.MVC
Namespace DI

    Public Class IoCResolver : Inherits DefaultControllerFactory : Implements IDependencyResolver

        Private ReadOnly container As Core.DI.IoC

        Public Sub New(ByRef connection_string As String)
            container = New Core.DI.IoC(connection_string)
        End Sub

        Public Function GetService(serviceType As Type) As Object Implements IDependencyResolver.GetService
            Return container.TryGet(serviceType)
        End Function

        Public Function GetServices(serviceType As Type) As IEnumerable(Of Object) Implements IDependencyResolver.GetServices
            Return container.GetAll(serviceType)
        End Function

        Public Function [Get](Of T As Type)() As T
            Return container.Get(GetType(T))
        End Function

        Protected Overrides Function GetControllerInstance(requestContext As Web.Routing.RequestContext, controllerType As Type) As IController
            If controllerType IsNot Nothing Then
                Return DirectCast(container.Get(controllerType), IController)
            Else
                Return Nothing
            End If
        End Function

    End Class

End Namespace
