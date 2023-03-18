Namespace Web
    Public Class HonorScoreController
        Inherits System.Web.Mvc.Controller

        Private _honor As Core.IHonor
        Private _honorcat As Core.IHonorCategory
        Private _honortype As Core.IHonorType

        Public Sub New(H As Core.IHonor, HC As Core.IHonorCategory, HT As Core.IHonorType)
            _honor = H
            _honorcat = HC
            _honortype = HT
        End Sub

        Public Function Index() As ActionResult
            Dim model As New Models.HonorScore.Index With {
                .HonorCategories = _honorcat.GetAll,
                .HonorTypes = _honortype.Table,
                .LastUpdated = _honor.LastUpdated}
            Return View(model)
        End Function

        Public Function Scores(ByVal typeseo As String, ByVal catseo As String, Optional ByVal page As Integer = 1) As ActionResult
            'do not allow any pages less than 1
            If page < 1 Then
                Return RedirectToAction("Scores", New With {.typeseo = typeseo, .catseo = catseo})
            End If

            Dim cat = _honorcat.BySeo(catseo)
            Dim cattype = _honortype.BySeo(typeseo)

            Dim model As Models.HonorScore.ScoreView

            If cat IsNot Nothing AndAlso cattype IsNot Nothing AndAlso (cat.Active And cattype.Active) Then
                Dim perpage As Integer = 20
                Dim grouping = _honor.Score(cat.Id, cattype.Id).OrderBy(Function(f) f.FormattedName).ThenByDescending(Function(f) f.Achieved)
                Dim grplst = grouping.Where(Function(f) f.HonorType.Active And f.HonorCategory.Active)
                Dim grpunique = grplst.GroupBy(Function(f) f.FormattedName)

                model = New Models.HonorScore.ScoreView With {
                    .Title = cattype.Description & " - " & cat.Description,
                    .CategorySEO = catseo,
                    .CategoryFULL = cat.Description,
                    .TypeSEO = typeseo,
                    .TypeFULL = cattype.Description
                }
                model.Scores = grpunique.Skip((page - 1) * perpage).Take(perpage)

                model.PageInfo = New Models.Common.PageInfoModel With {
                    .CurrentPage = page,
                    .ItemsPerPage = perpage,
                    .TotalItems = grpunique.Count
                    }

                'page check, no funny business with page numbers
                If page > model.PageInfo.TotalPages Then
                    Return RedirectToAction("Scores", New With {.typeseo = typeseo, .catseo = catseo, .page = model.PageInfo.TotalPages})
                End If

                If grplst.Count > 0 Then
                    model.LastUpdated = grplst.OrderByDescending(Function(f) f.AddedUtc).Select(Function(f) f.AddedUtc).FirstOrDefault
                End If

                If catseo.EndsWith("s") Then
                    Return View("ScoreViewSeries", model)
                Else
                    Return View("ScoreViewGame", model)
                    'Return View("ScoreViewSeries", model)
                End If
            End If

            Return RedirectToAction("Index")
        End Function

        Public Shadows Function Profile(ByVal id As String) As ActionResult
            Dim prof = _honor.Table.Where(Function(f) f.FormattedName.Equals(id.Replace("-", ", "), StringComparison.InvariantCultureIgnoreCase)).OrderByDescending(Function(f) f.Achieved).ToList
            If prof.Count > 0 Then
                Return View(prof)
            End If
            Return RedirectToAction("Index", "Home")
        End Function

#Region "Manage Scores"

        <Authorize(Roles:="Honor")>
        Function Manage(Optional ByVal hcid As Integer = 0, Optional ByVal htid As Integer = 0) As ActionResult
            Dim model As New Models.HonorScore.ManageModel
            With model
                .Navigation = New Models.HonorScore.ManageHeaderModel With {.ViewId = Models.HonorScore.ManageViewType.Scores}
                .Search = New Models.HonorScore.ChooseScoreModel With {
                    .HonorCategoryId = hcid,
                    .HonorTypeId = htid,
                    .HonorCategorys = _honorcat.GetAll,
                    .HonorTypes = _honortype.GetAll}
            End With

            If hcid + htid = 0 Then
                'grab all
                model.HonorScores = _honor.GetAll()
            ElseIf hcid = 0 Then
                'by type
                model.HonorScores = _honor.ByType(htid)
            ElseIf htid = 0 Then
                'by category
                model.HonorScores = _honor.ByCategory(hcid)
            Else
                'by type and category
                model.HonorScores = _honor.ByTypeCategory(htid, hcid)
            End If

            Return View(model)
        End Function

        <Authorize(Roles:="Honor")>
        Function HonorEdit(Optional ByVal hcid As Integer = 0, Optional ByVal htid As Integer = 0, Optional ByVal id As String = "") As ActionResult
            If id Is Nothing Or id.Length = 0 Then
                Return RedirectToAction("Manage", New With {.htid = htid, .hcid = hcid})
            End If
            Return View(New Models.HonorScore.HonorScoreEditModel With {.Honor = _honor.ById(id), .TypeId = htid, .CategoryId = hcid, .CategoryList = _honorcat.GetAll, .TypeList = _honortype.GetAll})
        End Function

        <Authorize(Roles:="Honor")>
        <HttpPost>
        Function HonorEdit(ByVal model As Models.HonorScore.HonorScoreEditModel) As ActionResult
            Dim honor = _honor.ById(model.Honor.Id.ToString)
            With model.Honor
                honor.LastName = .LastName
                honor.FirstName = .FirstName
                honor.HonorTypeId = .HonorTypeId
                honor.HonorCategoryId = .HonorCategoryId
            End With

            If model.Honor.LastName Is Nothing Or model.Honor.FirstName Is Nothing Then
                ModelState.AddModelError("", "First Name and Last Name are Required")
            End If

            If ModelState.IsValid Then
                _honor.Update(honor)
                Return RedirectToAction("Manage", New With {.htid = model.TypeId, .hcid = model.CategoryId})
            Else
                Return View(model)
            End If
        End Function

        <Authorize(Roles:="Honor")>
        <HttpPost>
        Function HonorDelete(ByVal id As String, ByVal htid As Integer, ByVal hcid As Integer) As PartialViewResult
            Return PartialView("DeleteView", New Models.HonorScore.DeleteModel With {.id = id, .honortype = htid, .honorcategory = hcid, .PostBackForm = "HonorDeleteConfirm", .CancelAction = "Manage"})
        End Function

        <Authorize(Roles:="Honor")>
        <HttpPost>
        Function HonorDeleteConfirm(ByVal model As Models.HonorScore.DeleteModel) As RedirectToRouteResult
            _honor.Delete(_honor.ById(model.id))
            Return RedirectToAction("Manage", New With {.htid = model.honortype, .hcid = model.honorcategory})
        End Function

        <Authorize(Roles:="Honor")>
        Function HonorCreate(Optional ByVal hcid As Integer = 0, Optional ByVal htid As Integer = 0) As ActionResult
            Dim model As New Models.HonorScore.HonorScoreEditModel With {
                                                        .Honor = New Data.Entity.Honor,
                                                        .CategoryId = hcid,
                                                        .TypeId = htid,
                                                        .CategoryList = _honorcat.GetAll,
                                                        .TypeList = _honortype.GetAll}
            Return View(model)
        End Function

        <Authorize(Roles:="Honor")>
        <HttpPost>
        Function HonorCreatePost(ByVal model As Models.HonorScore.HonorScoreEditModel) As ActionResult
            If model.Honor.FirstName Is Nothing Or model.Honor.LastName Is Nothing Then
                ModelState.AddModelError("", "First and Last Name are Required")
            End If

            If ModelState.IsValid Then
                _honor.Create(model.Honor)
                Return RedirectToAction("Manage", New With {.hcid = model.CategoryId, .htid = model.TypeId})
            End If

            With model
                .CategoryList = _honorcat.GetAll()
                .TypeList = _honortype.GetAll()
            End With

            Return View(model)
        End Function

#End Region

#Region "Manage Honor Type"

        <Authorize(Roles:="Honor")>
        Function ManageType() As ActionResult
            Return View(New Models.HonorScore.ManageTypeModel With {.Types = _honortype.GetAll, .Navigation = New Models.HonorScore.ManageHeaderModel With {.ViewId = Models.HonorScore.ManageViewType.HonorType}})
        End Function

        <Authorize(Roles:="Honor")>
        <HttpPost>
        Function TypeCreate(ByVal model As Data.Entity.HonorType) As RedirectToRouteResult
            If model.Description Is Nothing Then
                Return RedirectToAction("ManageType")
            End If

            If model.SEO Is Nothing Then
                model.SEO = model.Description.Substring(0, 1).ToUpper
            End If

            model.SEO = model.SEO.ToUpper
            _honortype.Create(model)
            Return RedirectToAction("ManageType")
        End Function

        <Authorize(Roles:="Honor")>
        <HttpPost>
        Function TypeUpdate(ByVal model As Data.Entity.HonorType) As RedirectToRouteResult
            Dim t = _honortype.ById(model.Id)
            With t
                t.Description = model.Description
                t.SEO = model.SEO.ToUpper
            End With
            _honortype.Update(model)
            Return RedirectToAction("ManageType")
        End Function

        <Authorize(Roles:="Honor")>
        <HttpPost>
        Function TypeDelete(ByVal id As Integer) As RedirectToRouteResult
            If _honor.ByType(id).Count > 0 Then
                _honortype.DeActivate(id)
            Else
                _honortype.Delete(_honortype.ById(id))
            End If

            Return RedirectToAction("ManageType")
        End Function

#End Region

#Region "Manage Honor Category"

        <Authorize(Roles:="Honor")>
        Function ManageCategory() As ActionResult
            Return View(New Models.HonorScore.ManageCategoryModel With {.Categories = _honorcat.GetAll, .Navigation = New Models.HonorScore.ManageHeaderModel With {.ViewId = Models.HonorScore.ManageViewType.Category}})
        End Function

        <Authorize(Roles:="Honor")>
        <HttpPost>
        Function MoveCategory(Optional ByVal order As Integer = 0, Optional ByVal direction As SByte = 0) As RedirectToRouteResult
            Dim cur = _honorcat.Table.Where(Function(f) f.Order = order).FirstOrDefault
            Dim rep = _honorcat.Table.Where(Function(f) f.Order = order + direction).FirstOrDefault

            If cur IsNot Nothing And rep IsNot Nothing Then
                Dim ncur As Integer = rep.Order
                Dim ocur As Integer = cur.Order
                rep.Order = 0
                cur.Order = ncur
                rep.Order = ocur
                _honorcat.Update(rep)
                _honorcat.Update(cur)
            End If

            Return RedirectToAction("ManageCategory")
        End Function

        <Authorize(Roles:="Honor")>
        <HttpPost>
        Function CreateCategory(ByVal model As Data.Entity.HonorCategory) As RedirectToRouteResult
            If model.Description Is Nothing Then
                Return RedirectToAction("ManageCategory")
            End If

            If model.SEO Is Nothing Then
                model.SEO = model.Description.Substring(0, 1).ToUpper
            End If

            model.SEO = model.SEO.ToUpper
            _honorcat.Create(model)

            Return RedirectToAction("ManageCategory")
        End Function

        <Authorize(Roles:="Honor")>
        <HttpPost>
        Function DeleteCategory(ByVal id As Integer) As RedirectToRouteResult
            If _honor.ByCategory(id).Count > 0 Then
                _honorcat.DeActivate(id)
            Else
                _honorcat.Delete(_honorcat.ById(id))
            End If

            Return RedirectToAction("ManageCategory")
        End Function

        <Authorize(Roles:="Honor")>
        <HttpPost>
        Function UpdateCategory(ByVal model As Data.Entity.HonorCategory) As RedirectToRouteResult
            If model.Description IsNot Nothing Then
                If model.SEO Is Nothing Then
                    model.SEO = model.Description.Substring(0, 1)
                End If
                Dim cat = _honorcat.ById(model.Id)
                With cat
                    .Description = model.Description
                    .SEO = model.SEO.ToUpper
                End With
                _honorcat.Update(cat)
            End If

            Return RedirectToAction("ManageCategory")
        End Function

#End Region

    End Class
End Namespace
