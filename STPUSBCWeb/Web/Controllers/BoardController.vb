Namespace Web
    Public Class BoardController
        Inherits System.Web.Mvc.Controller

        Private _board As Core.IBoard
        Private _boardpos As Core.IBoardPosition
        Private _boardhist As Core.IBoardHistory

        Public Sub New(B As Core.IBoard, BP As Core.IBoardPosition, HIST As Core.IBoardHistory)
            _board = B
            _boardpos = BP
            _boardhist = HIST
        End Sub

        Function Index() As ActionResult
            Dim model As New Models.Board.IndexModel With {.BoardHistory = _boardhist.BoardTermList()}

            If model.BoardHistory.Count > 0 Then
                model.LastUpdated = model.BoardHistory.OrderByDescending(Function(f) f.Board.LastUpdatedUtc).Select(Function(f) f.Board.LastUpdatedUtc).First
            End If

            Return View(model)
        End Function

        Shadows Function Profile(ByVal id As String) As ActionResult
            Return View(_board.ById(id))
        End Function

#Region "Manage"

        <Authorize(Roles:="Board")>
        Function Manage() As ActionResult
            Dim model As New Models.Board.ManageModel With {.Members = _board.Table.OrderByDescending(Function(f) f.Visible).ThenBy(Function(f) f.FormattedName).ToList, .Positions = _boardpos.Table}

            If model.Members.Count > 0 Then
                model.LastUpdated = model.Members.OrderByDescending(Function(f) f.LastUpdatedUtc).Select(Function(f) f.LastUpdatedUtc).First
            End If

            Return View(model)
        End Function

        <Authorize(Roles:="Board")>
        <HttpPost>
        Function ShowChange(ByVal id As String, ByVal visible As Boolean) As RedirectToRouteResult
            Dim m = _board.ById(id)
            m.Visible = visible
            _board.Update(m)
            Return RedirectToAction("Manage")
        End Function

        <Authorize(Roles:="Board")>
        Function Edit(ByVal id As String) As ActionResult
            Dim model = _board.ById(id)
            If model Is Nothing Then
                Return RedirectToAction("Manage")
            End If
            Return View(New Models.Board.EditModel With {.Member = _board.ById(id).ToModel, .Positions = _boardpos.Table.Where(Function(f) f.Visible).ToList, .MemberHistory = _boardhist.Table.OrderBy(Function(f) f.TermEnd).Where(Function(f) f.BoardId = .Member.Id).ToList})
        End Function

        <Authorize(Roles:="Board")>
        <HttpPost>
        Function Edit(ByVal model As Models.Board.EditModel, ByVal notathing As String) As ActionResult
            If ModelState.IsValid Then
                With model.Member
                    If ModelState.IsValid Then
                        Dim m = _board.ById(.Id.ToString)
                        model.Member.ToEntity(m)
                        _board.Update(m)
                        Return RedirectToAction("Manage")
                    End If
                End With
            End If

            model.Positions = _boardpos.Table.Where(Function(f) f.Visible).ToList
            Return View(model)
        End Function

        <Authorize(Roles:="Board")>
        Function Create() As ActionResult
            Dim model As New Models.Board.EditModel With {
                .Member = New Models.Board.BoardModel,
                .Positions = _boardpos.Table.Where(Function(f) f.Visible).ToList
            }
            Return View(model)
        End Function

        <Authorize(Roles:="Board")>
        <HttpPost>
        <ValidateInput(False)>
        Function Create(ByVal model As Models.Board.EditModel) As ActionResult
            If ModelState.IsValid Then

                With model.Member
                    Dim entity = model.Member.ToEntity
                    _board.Create(entity)
                    Return RedirectToAction("Edit", New With {.id = entity.Id.ToString})

                End With

            End If

            model.Positions = _boardpos.Table.Where(Function(f) f.Visible).ToList
            Return View(model)
        End Function

        <Authorize(Roles:="Board")>
        <HttpPost>
        Function Delete(ByVal id As String) As PartialViewResult
            Return PartialView(DirectCast(id, Object))
        End Function

        <Authorize(Roles:="Board")>
        <HttpPost>
        Function DeleteConfirm(ByVal id As String) As RedirectToRouteResult
            _board.Delete(_board.ById(id))
            Return RedirectToAction("Manage")
        End Function

        <Authorize(Roles:="Board")>
        <HttpPost>
        Function DeleteHistory(ByVal bid As Guid, ByVal hid As String) As ActionResult
            _boardhist.Delete(_boardhist.ById(hid))
            If IsAjax() Then
                Return PartialView("BoardHistory", BoardHistoryEditModel(bid))
            End If
            Return RedirectToAction("Edit", New With {.id = bid})
        End Function

        <Authorize(Roles:="Board")>
        <HttpPost>
        Function CreateHistory(ByVal boardhistory As Models.Board.BoardHistoryModel, ByVal BoardId As Guid) As ActionResult
            If ModelState.IsValid Then
                _boardhist.Create(boardhistory.ToEntity)
            End If
            If IsAjax() Then
                 Return PartialView("BoardHistory", BoardHistoryEditModel(BoardId))
            End If
            Return RedirectToAction("Edit", New With {.id = boardhistory.BoardId})
        End Function

        <Authorize(Roles:="Board")>
        <HttpPost>
        Function UpdateHistory(ByVal boardhistory As Models.Board.BoardHistoryModel) As RedirectToRouteResult
            If ModelState.IsValid Then
                Dim bh = _boardhist.ById(boardhistory.Id.ToString)
                boardhistory.ToEntity(bh)
                _boardhist.Update(bh)
            End If
            Return RedirectToAction("Edit", New With {.id = boardhistory.BoardId})
        End Function

        <NonAction>
        Private Function BoardHistoryEditModel(ByVal boardid As Guid) As Models.Board.BoardHistoryEditModel
            Dim model As New Models.Board.BoardHistoryEditModel With {
                .BoardId = boardid,
                .PositionLst = _boardpos.Table.OrderBy(Function(f) f.Order).ToList,
                .BoardHistoryList = _boardhist.Table().OrderBy(Function(f) f.TermEnd).Where(Function(f) f.BoardId = .BoardId).ToList}
            Return model
        End Function

#End Region

#Region "Position Management"

        <Authorize(Roles:="Board")>
        Function ManagePosition() As ActionResult
            Return View(New Models.Board.ManagePositionModel With {.Positions = _boardpos.Table})
        End Function

        <Authorize(Roles:="Board")>
        <HttpPost>
        Function CreatePosition(ByVal model As Data.Entity.BoardPosition) As RedirectToRouteResult
            _boardpos.Create(model)
            Return RedirectToAction("ManagePosition")
        End Function

        <Authorize(Roles:="Board")>
        <HttpPost>
        Function DeletePosition(ByVal id As Integer) As RedirectToRouteResult
            _boardpos.Delete(_boardpos.ById(id))
            Return RedirectToAction("ManagePosition")
        End Function

        <Authorize(Roles:="Board")>
        <HttpPost>
        Function UpdatePosition(ByVal model As Data.Entity.BoardPosition) As RedirectToRouteResult
            Dim pos = _boardpos.ById(model.Id)
            With pos
                .Description = model.Description
            End With
            _boardpos.Update(pos)
            Return RedirectToAction("ManagePosition")
        End Function

        <Authorize(Roles:="Board")>
        <HttpPost>
        Function PositionDisplayChange(ByVal id As Integer, ByVal display As Boolean) As RedirectToRouteResult
            Dim bp = _boardpos.ById(id)
            bp.Visible = display
            _boardpos.Update(bp)
            Return RedirectToAction("ManagePosition")
        End Function

        <Authorize(Roles:="Board")>
        <HttpPost>
        Function PositionOrderMove(ByVal order As Integer, ByVal direction As SByte) As RedirectToRouteResult
            Dim cur = _boardpos.Table.Where(Function(f) f.Order = order).FirstOrDefault
            Dim rep = _boardpos.Table.Where(Function(f) f.Order = order + direction).FirstOrDefault
            If cur IsNot Nothing AndAlso rep IsNot Nothing Then
                Dim npos = rep.Order
                Dim opos = cur.Order
                rep.Order = 0
                cur.Order = npos
                rep.Order = opos
                _boardpos.Update(rep)
                _boardpos.Update(cur)
            End If
            Return RedirectToAction("ManagePosition")
        End Function

#End Region

        <NonAction>
        Private Function IsAjax() As Boolean
            Return HttpContext.Request.IsAjaxRequest()
        End Function

    End Class
End Namespace
