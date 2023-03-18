Namespace Web
    Public Class RSSController
        Inherits System.Web.Mvc.Controller

        Private _rss As Core.IRSSGen

        Public Sub New(RSS As Core.IRSSGen)
            _rss = RSS
        End Sub

        Function Index() As ActionResult
            Return View()
        End Function

        Function HallOfFame() As ActionResult
            Return View("XMLView", DirectCast(_rss.HallOfFame(), Object))
        End Function

        Function Tournament() As ActionResult
            Return View("XMLView", DirectCast(_rss.Tournament(), Object))
        End Function

        Function Board() As ActionResult
            Return View("XMLView", DirectCast(_rss.Board(), Object))
        End Function

    End Class
End Namespace
