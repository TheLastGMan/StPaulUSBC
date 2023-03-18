Imports System.Threading
Imports System.Web.Hosting
Imports System.Web.Compilation
Imports System.Reflection
Imports System.Web

<Assembly: PreApplicationStartMethod(GetType(Plugin.PluginManager), "Initialize")> 
Namespace Plugin

    Public Class PluginManager

        Private Shared ReadOnly _pluginsPath As String = "~/Plugins"
        Private Shared ReadOnly _pluginsPathInstalled As String = "~/Plugins/bin"

        Public Shared Sub Initialize()
            'load Assemblies in the ~/Plugins/bin folder
            Dim binpath As String = HostingEnvironment.MapPath(_pluginsPathInstalled)
            If IO.Directory.Exists(binpath) Then
                For Each file In New IO.DirectoryInfo(binpath).GetFiles("*.dll", IO.SearchOption.AllDirectories)
                    LoadAssebmly(file)
                Next
            End If

        End Sub

        Private Shared Sub LoadAssebmly(ByRef FI As IO.FileInfo)

            'Dim ignore As String() = {"rpgcor.core.dll", "data.dll", "service.dll", "entityframework.dll"}

            'If Not ignore.Contains(FI.Name.ToLower) Then
            Try
                Dim loadthis = Assembly.Load(AssemblyName.GetAssemblyName(FI.FullName))
                BuildManager.AddReferencedAssembly(loadthis)
            Catch ex As Exception
                Debug.WriteLine("Error For : " & FI.Name)
            End Try

            'End If

        End Sub

        Public Shared Function FindAllPlugins() As List(Of PluginInfo)
            Dim plugim_names_installed = New IO.DirectoryInfo(HostingEnvironment.MapPath(_pluginsPathInstalled)).GetFiles("*.dll", IO.SearchOption.AllDirectories).Select(Function(f) f.Name).ToList

            Dim ValidPlugins As New List(Of PluginInfo)

            For Each file In New IO.DirectoryInfo(HostingEnvironment.MapPath(_pluginsPath)).GetFiles("*.dll", IO.SearchOption.AllDirectories).Where(Function(f) (Not f.FullName.Contains("\bin\")))
                Try
                    Dim pi As New PluginInfo(New TypeFinder().FindClassesOfType(Of IPluginInfo)(Assembly.Load(AssemblyName.GetAssemblyName(file.FullName))))
                    If pi IsNot Nothing Then
                        'add
                        pi.Installed = IIf(plugim_names_installed.Contains(file.Name), True, False)
                        ValidPlugins.Add(pi)
                    End If
                Catch ex As Exception

                End Try
            Next

            Return ValidPlugins
        End Function

    End Class

End Namespace
