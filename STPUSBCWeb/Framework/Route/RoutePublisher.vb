Imports Core.Plugin
Namespace Route

    Public Class RoutePublisher : Implements IRoutePublisher

        Public Sub RegisterRoutes(ByRef routes As Web.Routing.RouteCollection) Implements IRoutePublisher.RegisterRoutes

            Dim routeProviderTypes = New TypeFinder().FindClassesOfType(Of IRouteProvider)()
            Dim routeProviders As New List(Of IRouteProvider)

            For Each providertype In routeProviderTypes
                routeProviders.Add(DirectCast(Activator.CreateInstance(providertype), IRouteProvider))
            Next

            For Each r In routeProviders.OrderByDescending(Function(rp) rp.Priority).ToList
                r.RegisterRoutes(routes)
            Next

        End Sub

    End Class

End Namespace

