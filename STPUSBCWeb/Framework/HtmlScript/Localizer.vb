Imports System.Web.Mvc
Imports System.Web.Mvc.Html
Imports System.Web.Routing
Imports System.Web.WebPages
Imports System.Text
Imports System.Runtime.CompilerServices
Imports System.Linq.Expressions

Namespace HtmlScript

    Public Module Localizer

        <Extension>
        Public Function FieldNameFor(Of T, TResult)(html As HtmlHelper(Of T), expression As Expression(Of Func(Of T, TResult))) As String
            Return html.ViewData.TemplateInfo.GetFullHtmlFieldName(ExpressionHelper.GetExpressionText(expression))
        End Function

        <Extension>
        Public Function FieldIdFor(Of T, TResult)(html As HtmlHelper(Of T), expression As Expression(Of Func(Of T, TResult))) As String
            Dim id = html.ViewData.TemplateInfo.GetFullHtmlFieldId(ExpressionHelper.GetExpressionText(expression))
            ' because "[" and "]" aren't replaced with "_" in GetFullHtmlFieldId
            Return id.Replace("[", "_").Replace("]", "_")
        End Function

        Public Function Localize(ByRef key As String) As String
            Dim ret = New Core.DI.IoC().Get(GetType(Core.ILocalization)).ReadByKey(key)
            Dim out As String = ""

            If ret IsNot Nothing Then
                out = ret.Value
            End If

            Return out
        End Function

        <Extension>
        Public Function Localize(ByRef T As HtmlHelper, ByRef key As String) As MvcHtmlString

            Dim ret = New Core.DI.IoC().Get(GetType(Core.ILocalization)).ReadByKey(key)
            Dim out As String = ""

            If ret IsNot Nothing Then
                out = ret.Value
            End If

            Return MvcHtmlString.Create(out)
        End Function

        <Extension>
        Public Function Version(ByRef T As HtmlHelper) As MvcHtmlString
            Return MvcHtmlString.Create("17.6.26.0330")
        End Function

        <Extension>
        Public Function TitleMaker(ByRef T As HtmlHelper, ParamArray TitleParts() As String) As String
            Dim nlst = TitleParts.ToList
            nlst.Insert(0, T.Localize("URL.Title.Suffix").ToString)
            Return String.Join(" - ", nlst.ToArray)
        End Function

    End Module

End Namespace
