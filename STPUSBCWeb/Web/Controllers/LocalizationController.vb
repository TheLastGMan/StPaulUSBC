Namespace Web
    Public Class LocalizationController
        Inherits System.Web.Mvc.Controller

        Private _localization As Core.ILocalization

        Public Sub New(LOC As Core.ILocalization)
            _localization = LOC
        End Sub

        <Authorize(Roles:="Localizer")>
        Function Manage(Optional ByVal field As Models.Localization.SearchField = Models.Localization.SearchField.key, Optional ByVal parameter As Models.Localization.SearchParameter = Models.Localization.SearchParameter.contains, Optional ByVal q As String = "") As ActionResult
            q = q.ToLower
            Dim model As New Models.Localization.ManageModel With {
                .Field = field,
                .Parameter = parameter,
                .query = q}

            If q.Trim.Length > 0 Then
                Select Case field
                    Case Models.Localization.SearchField.key
                        Select Case parameter
                            Case Models.Localization.SearchParameter.contains
                                model.Localization = _localization.Table.Where(Function(f) f.Key.ToLower.Contains(q)).ToList
                            Case Models.Localization.SearchParameter.starts_with
                                model.Localization = _localization.Table.Where(Function(f) f.Key.ToLower.StartsWith(q)).ToList
                            Case Models.Localization.SearchParameter.ends_with
                                model.Localization = _localization.Table.Where(Function(f) f.Key.ToLower.EndsWith(q)).ToList
                        End Select
                    Case Models.Localization.SearchField.value
                        Select Case parameter
                            Case Models.Localization.SearchParameter.contains
                                model.Localization = _localization.Table.Where(Function(f) f.Value.ToLower.Contains(q)).ToList
                            Case Models.Localization.SearchParameter.starts_with
                                model.Localization = _localization.Table.Where(Function(f) f.Value.ToLower.StartsWith(q)).ToList
                            Case Models.Localization.SearchParameter.ends_with
                                model.Localization = _localization.Table.Where(Function(f) f.Value.ToLower.EndsWith(q)).ToList
                        End Select
                End Select
                model.Localization = model.Localization.OrderBy(Function(f) f.Key).Take(25).ToList
            Else
                model.Localization = _localization.GetTop(25)
            End If
            Return View(model)
        End Function

        <Authorize(Roles:="Localizer")>
        <HttpPost>
        Function Manage(ByVal model As Models.Localization.ManageModel) As RedirectToRouteResult
            'Return Manage(Integer.Parse(model.Field), Integer.Parse(model.Parameter), model.query.Trim())
            Return RedirectToAction("Manage", New With {.field = model.Field, .parameter = model.Parameter, .q = model.query.TrimEnd(" ")})
        End Function

        <Authorize(Roles:="Localizer")>
        <HttpPost>
        Function Update(ByVal id As String, ByVal value As String, ByVal model As Models.Localization.ManageModel) As RedirectToRouteResult
            Dim loc = _localization.ById(id)
            loc.Value = value
            _localization.Update(loc)
            Return RedirectToAction("Manage", New With {.field = Integer.Parse(model.Field), .parameter = Integer.Parse(model.Parameter), .search = value})
        End Function

    End Class
End Namespace
