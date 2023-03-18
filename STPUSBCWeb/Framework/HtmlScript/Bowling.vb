Imports System.Web.Mvc
Imports System.Web.Mvc.Html
Imports System.Web.Routing
Imports System.Web.WebPages
Imports System.Text
Imports System.Runtime.CompilerServices

Namespace HtmlScript

    Public Module Bowling

        <Extension>
        Public Function GameString(ByRef T As HtmlHelper, ByRef Game1 As String, ByRef Game2 As String, ByRef Game3 As String) As MvcHtmlString
            Dim G1, G2, G3 As String
            G1 = IIf(Game1 < 0, "?", Game1)
            G2 = IIf(Game2 < 0, "?", Game2)
            G3 = IIf(Game3 < 0, "?", Game3)
            G1 = G1.PadLeft(3, " ")
            G2 = G2.PadLeft(3, " ")
            G3 = G3.PadLeft(3, " ")
            Return MvcHtmlString.Create(String.Format("{0} - {1} - {2}", G1, G2, G3).Replace(" ", "&nbsp;"))
        End Function

    End Module

End Namespace