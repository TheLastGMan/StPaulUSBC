@ModelType Web.Models.Topic.EditModel
@code
    ViewData("Title") = Html.TitleMaker(Html.Localize("Topic.Edit.URLTitle").ToString, Model.Topic.seo)
    Dim ttx As String = ""
    If Model.Topic.TopicTypeId > 1 Then
        ttx = IIf(Model.Topic.TopicTypeId = 2, "Topic", "Page")  
    End If
End Code

<h1>@Html.Localize("Topic.Edit.Title").ToHtmlString.Replace("{seo}", Model.Topic.seo)</h1>
@If Model.Topic.TopicTypeId > 1 Then
    @<div>
        @Html.Localize("Topic.Edit.LinkText").ToHtmlString.Replace("{topic}", ttx)
    </div>
    @<br />
    @<div class="CDE" style="padding-left:25px; line-height:1.5em;">
        @String.Format(Html.Localize("Topic.Edit.Link").ToHtmlString, HttpContext.Current.Request.ServerVariables("HTTP_HOST"), Model.Topic.seo)
    </div>
End If
@Using Html.BeginForm("Update", "Topic")
    @<div style="text-align:center;">
        @Html.HiddenFor(Function(f) f.Topic.seo)
        <br />
        @Html.HtmlEditor("htmlcontent", Model.Topic.content)
        <br />
        <input type="submit" value="@Html.Localize("Topic.Edit.SaveSubmit")" class="submit-green" />&nbsp;&nbsp;
        <a href="@(Url.Action("Manage", "Topic"))" class="linkbutton submit-red">@Html.Localize("Topic.Edit.CancelSubmit")</a>
    </div>
End Using
@Html.LastUpdated(Model.Topic.updatedutc)