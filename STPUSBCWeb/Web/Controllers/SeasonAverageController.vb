Namespace Web
    Public Class SeasonAverageController
        Inherits System.Web.Mvc.Controller

        Private _seasonavesrvc As Core.ISeasonAverageService
        Private _sab As Core.ISeasonAverageBowler
        Private _sa As Core.ISeasonAverage
        Private _loc As Core.ILocalization

        Public Sub New(SAS As Core.ISeasonAverageService, SAB As Core.ISeasonAverageBowler, SA As Core.ISeasonAverage, LOC As Core.ILocalization)
            _seasonavesrvc = SAS
            _sab = SAB
            _sa = SA
            _loc = LOC
        End Sub

#Region "Search Feature"

        Function Index(ByVal fn As String, ByVal ln As String, ByVal bid As String, Optional ByVal limit As Byte = 15) As ActionResult
            'set model data
            Dim model As New Models.SeasonAverage.IndexModel
            With model
                .FirstName = fn
                .LastName = ln
                .USBCID = bid
            End With

            'if bowler id is set, (override and load by id)
            If Not String.IsNullOrEmpty(model.USBCID) Then
                'search by id
                model.SearchResults = _sab.SearchUSBCID(model.USBCID, limit).ToList
                model.RanQuery = True
            ElseIf Not String.IsNullOrEmpty(model.LastName) Then
                'search by name
                model.SearchResults = _sab.Search(model.FirstName, model.LastName, limit).ToList
                model.RanQuery = True
            End If
            model.TotalSearchResults = model.SearchResults.Count

            'show page
            Return View(model)
        End Function

        <HttpPost>
        Function Index(ByVal id As Models.SeasonAverage.IndexModel, ByVal formc As FormCollection) As ActionResult
            Return RedirectToAction("Index", New With {.ln = id.LastName, .fn = id.FirstName, .bid = id.USBCID})
        End Function

#End Region

        <Authorize(Roles:="ScoreLoader")>
        Function Manage() As ActionResult
            Return View(New Models.SeasonAverage.ManageModel)
        End Function

        <HttpPost>
        <Authorize(Roles:="ScoreLoader")>
        Function Manage(ByVal model As Models.SeasonAverage.ManageModel) As ActionResult
            If model.file.FileName.EndsWith(".csv") Then
                Dim path As String = Server.MapPath("~/uploads/files/")
                Dim fullpath As String = IO.Path.Combine(path, model.file.FileName.Substring(model.file.FileName.LastIndexOfAny({"\", "/"}) + 1) & ".tmp")
                model.file.SaveAs(fullpath)

                If model.choice = Models.SeasonAverage.UploadChoice.purge Then
                    _sa.DeleteAll()
                    _sab.DeleteAll()
                End If

                If _seasonavesrvc.ParseCVSScores(fullpath, model.season) Then
                    model.result = _loc.Msg("SeasonAverage.Manage.UploadResult.Success")
                Else
                    model.result = _loc.Msg("SeasonAverage.Manage.Fail")
                End If

                Try
                    IO.File.Delete(fullpath)
                Catch ex As Exception

                End Try
            Else
                model.result = "Invalid File Type (" & model.file.FileName.Substring(model.file.FileName.LastIndexOf(".")) & ") detected, please upload a CSV file"
            End If

            Return View(model)
        End Function

    End Class
End Namespace
