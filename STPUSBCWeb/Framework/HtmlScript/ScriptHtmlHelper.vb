Imports System.Web.Mvc
Imports System.Web.Mvc.Html
Imports System.Web.Routing
Imports System.Web.WebPages
Imports System.Text
Imports System.Runtime.CompilerServices

Namespace HtmlScript

    Public Module ScriptHtmlHelper

        <Extension>
        Public Function Widget(ByRef Html As HtmlHelper, seo As String) As MvcHtmlString
            Return Html.Action("Widget", "Topic", New With {.seo = seo})
        End Function

        <Extension>
        Public Function HtmlEditor(ByRef Html As HtmlHelper, ByRef id As String, ByRef content As String) As MvcHtmlString
            Return Html.Action("Editor", "Common", New With {.id = id, .html = content})
        End Function

        <Extension>
        Public Function LastUpdated(ByRef Html As HtmlHelper, ByRef updated As DateTime?) As MvcHtmlString
            Return Html.Action("LastUpdated", "Common", New With {.updated = updated})
        End Function

        <Extension>
        Public Function FullScreenLoad(ByRef T As HtmlHelper) As MvcHtmlString
            Return T.Action("FullScreenLoad", "Common")
        End Function

        <Extension>
        Public Function Pager(ByRef T As HtmlHelper, ByRef currentpage As Integer, ByRef totalpages As Integer, ByRef pageUrl As Func(Of Integer, String)) As MvcHtmlString
            'do not show pager if only one page
            If totalpages = 1 Then
                Return MvcHtmlString.Create("")
            End If

            Dim result As New StringBuilder

            result.Append("<div class=""pager"">")
            'back links
            If (currentpage - 5) > 1 Then
                Dim tag As New TagBuilder("a")
                tag.MergeAttribute("href", pageUrl(1))
                tag.InnerHtml = "<<"
                result.Append(tag)
            End If
            If currentpage > 1 Then
                Dim tag As New TagBuilder("a")
                tag.MergeAttribute("href", pageUrl(currentpage - 1))
                tag.InnerHtml = "<"
                result.Append(tag)
            End If

            Dim page_start As Integer = Math.Max(currentpage - 5, 1)
            Dim page_end As Integer = Math.Min(currentpage + 5, totalpages)
            For i As Integer = page_start To page_end
                Dim tb As New TagBuilder("a")
                tb.MergeAttribute("href", pageUrl(i))
                tb.InnerHtml = i
                If i = currentpage Then
                    tb.AddCssClass("selected")
                End If
                result.Append(tb.ToString)
            Next

            'Next Links
            If currentpage < totalpages Then
                Dim tag As New TagBuilder("a")
                tag.MergeAttribute("href", pageUrl(currentpage + 1))
                tag.InnerHtml = ">"
                result.Append(tag)
            End If
            If (currentpage + 5) < totalpages Then
                Dim tag As New TagBuilder("a")
                tag.MergeAttribute("href", pageUrl(totalpages))
                tag.InnerHtml = ">>"
                result.Append(tag)
            End If
            result.Append("</div>")

            Return MvcHtmlString.Create(result.ToString)
        End Function

        <Extension>
        Public Function AutoComplete(ByRef Html As HtmlHelper, ByRef textboxid As String, ByRef autocompleteitems() As String) As MvcHtmlString
            Dim tb As New TagBuilder("script")
            tb.MergeAttribute("type", "text/javascript")

            Dim lst As New List(Of String)
            For Each s As String In autocompleteitems
                lst.Add(s.Replace("'", "").Replace("  ", " ").Trim())
            Next

            Dim SB As New StringBuilder
            SB.AppendLine("$(function() {")
            SB.AppendFormat("var {0}_autocomplete = [", textboxid)
            SB.AppendLine("'" & String.Join("', '", lst.Distinct().ToArray) & "'];")
            SB.AppendFormat("$('#{0}').autocomplete(<source: {1}>);", textboxid, textboxid & "_autocomplete")
            SB.AppendLine("});")

            tb.InnerHtml = SB.ToString.Replace("<", "{").Replace(">", "}")
            Return MvcHtmlString.Create(tb.ToString)
        End Function

        <Extension>
        Public Function Accordion(ByRef T As HtmlHelper, ByRef ids() As String) As MvcHtmlString
            Dim tb As New TagBuilder("script")
            tb.MergeAttribute("type", "text/javascript")

            For i As Integer = 1 To ids.Count
                ids(i - 1) = String.Format("#{0}", ids(i - 1))
            Next

            Dim sb As New StringBuilder()
            sb.AppendLine("")
            SB.AppendLine("$(function () {")
            sb.AppendLine("$('" & String.Join(", ", ids) & "').accordion();")
            SB.AppendLine("});")

            tb.InnerHtml = sb.ToString

            Return MvcHtmlString.Create(tb.ToString)
        End Function

        <Extension>
        Public Function Tabs(ByRef T As HtmlHelper, ByRef id As String) As MvcHtmlString
            Dim tb As New TagBuilder("script")
            tb.MergeAttribute("type", "text/javascript")
            Dim sb As New StringBuilder
            With sb
                .AppendLine("")
                .AppendLine("$(function() {")
                .AppendFormat("$('#{0}').tabs();", id)
                .AppendLine("});")
            End With

            tb.InnerHtml = sb.ToString
            Return MvcHtmlString.Create(tb.ToString)
        End Function

        <Extension>
        Public Function DateField(ByRef Html As HtmlHelper, ParamArray dateboxids() As String) As MvcHtmlString
            Dim local As String() = dateboxids
            For i As Integer = 1 To local.Length
                local(i - 1) = "#" & local(i - 1)
            Next
            Dim ids As String = String.Join(", ", local)

            Dim tb As New TagBuilder("script")
            tb.MergeAttribute("type", "text/javascript")

            Dim SB As New StringBuilder
            With SB
                .AppendLine("$(function(){")
                '.AppendLine("if (!Modernizr.inputtypes.date) {")
                .AppendFormat("$('{0}').datepicker();", ids)
                '.AppendLine("};")
                .AppendLine("});")
            End With

            tb.InnerHtml = SB.ToString
            Return MvcHtmlString.Create(tb.ToString)
        End Function

        <Extension>
        Public Function NumericField(ByRef T As HtmlHelper, ByRef min As Integer, ByRef max As Integer, ParamArray numericids() As String) As MvcHtmlString
            For i As Integer = 1 To numericids.Length
                numericids(i - 1) = "#" & numericids(i - 1)
            Next

            Dim tb As New TagBuilder("script")
            tb.MergeAttribute("type", "text/javascript")

            Dim sb As New StringBuilder()
            With sb
                .AppendLine("")
                .AppendLine("$(function(){")
                .AppendLine("if (!Modernizr.inputtypes.number) {")
                .AppendFormat("$('{0}').spinner([min: {1}, max: {2}]);", String.Join(", ", numericids), min, max)
                .AppendLine("};")
                .AppendLine("});")
            End With

            tb.InnerHtml = sb.ToString.Replace("[", "{").Replace("]", "}")
            Return MvcHtmlString.Create(tb.ToString)
        End Function

        <Extension>
        Public Function AutoPrint(ByRef T As HtmlHelper) As MvcHtmlString
            Dim tb As New TagBuilder("script")
            tb.MergeAttribute("type", "text/javascript")

            Dim sb As New StringBuilder
            With sb
                sb.AppendLine("")
                sb.AppendLine("$(function () {")
                sb.AppendLine("window.print();")
                sb.AppendLine("});")
            End With

            tb.InnerHtml = sb.ToString
            Return MvcHtmlString.Create(tb.ToString)
        End Function

    End Module

End Namespace
