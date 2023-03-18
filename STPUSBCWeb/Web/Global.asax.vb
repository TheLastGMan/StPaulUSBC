' Note: For instructions on enabling IIS6 or IIS7 classic mode,
' visit http://go.microsoft.com/?LinkId=9394802
Imports System.Data.Entity
Imports System.Data.Entity.Infrastructure

Public Class MvcApplication
    Inherits System.Web.HttpApplication

    Shared Sub RegisterGlobalFilters(ByVal filters As GlobalFilterCollection)
        filters.Add(New HandleErrorAttribute(), 1)
        filters.Add(New Framework.Filter.CustomErrorHandler(), 2)
        filters.Add(New Framework.Filter.ETagAttribute(), 3)
    End Sub

    Shared Sub RegisterRoutes(ByVal routes As RouteCollection)
        routes.IgnoreRoute("{resource}.axd/{*pathInfo}")

        Dim pub As New Framework.Route.RoutePublisher()
        pub.RegisterRoutes(routes)

        ' MapRoute takes the following parameters, in order:
        ' (1) Route name
        ' (2) URL with parameters
        ' (3) Parameter defaults
        routes.MapRoute("ErrorMap",
            "error",
            New With {.controller = "Common", .action = "Error"})

        routes.MapRoute(
            "Default",
            "{controller}/{action}/{id}",
            New With {.controller = "Home", .action = "Index", .id = UrlParameter.Optional}
        )

        'Errors
        routes.MapRoute("Error",
                  "{*url}",
                  New With {.controller = "Common", .action = "Error"})

    End Sub

    Sub Application_Start()
        AreaRegistration.RegisterAllAreas()

        ' Use LocalDB for Entity Framework by default
        'Database.DefaultConnectionFactory = New SqlConnectionFactory("Data Source=(localdb)\v11.0; Integrated Security=True; MultipleActiveResultSets=True")

        'Dependency Resolver
        Dim constr As String = ConfigurationManager.ConnectionStrings("Context").ConnectionString
        Dim NJ = New Framework.DI.IoCResolver(constr)
        DependencyResolver.SetResolver(NJ)
        ControllerBuilder.Current.SetControllerFactory(NJ)
        RPGMapperConfig.MapSetup()

        DataAnnotationsModelValidatorProvider.AddImplicitRequiredAttributeForValueTypes = False
        ModelValidatorProviders.Providers.Add(New FluentValidation.Mvc.FluentValidationModelValidatorProvider(New Framework.DI.RPGValidatorFactory))

#If Not DEBUG Then
        RegisterGlobalFilters(GlobalFilters.Filters)
#End If

        RegisterRoutes(RouteTable.Routes)
    End Sub

    Sub Application_Error()
        Dim ex = Server.GetLastError
        Dim path As String = Server.MapPath("~/uploads/files/errorlog/")
        IO.Directory.CreateDirectory(path)
        Dim filename As String = String.Format("{0}.{1}", Now.ToUniversalTime.ToString("MMM-dd-yyyy-hhmmssffff"), "log")
        Dim filepath As String = IO.Path.Combine(path, filename)
        Using SW As New IO.StreamWriter(filepath, False)
            SW.WriteLine("---Message---")
            SW.WriteLine(ex.Message)
            SW.WriteLine("---Stack Trace---")
            SW.WriteLine(ex.StackTrace)
        End Using

#If Not DEBUG Then
        Server.TransferRequest("/error")
#End If

    End Sub

End Class
