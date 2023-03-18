@ModelType Web.Models.Topic.ManageModel
@code
    ViewData("Title") = Html.TitleMaker(Html.Localize("Topic.Manage.URLTitle").ToString)
End Code

<h1>@Html.Localize("Topic.Manage.Title")</h1>
<div>
    <ul>
        <li>@Html.Localize("Topic.Manage.Info.Page").ToHtmlString.Replace("{host}", HttpContext.Current.Request.ServerVariables("HTTP_HOST"))</li>
        <li>@Html.Localize("Topic.Manage.Info.Topic").ToHtmlString.Replace("{host}", HttpContext.Current.Request.ServerVariables("HTTP_HOST"))</li>
    </ul>
</div>
@Html.Partial("_ManageHeaderLinks", model.seoid)
<table  id="topic_table">
    <thead>
        <tr>
            <td>@Html.Localize("Topic.Manage.TopicTypeTitle")</td>
            <td>@Html.Localize("Topic.Manage.NameTitle")</td>
            <td class="hidemobile">@Html.Localize("Topic.Manage.UpdatedTitle")</td>
            <td>@Html.Localize("Topic.Manage.EditTitle")</td>
            <td>@Html.Localize("Topic.Manage.DeleteTitle")</td>
        </tr>
    </thead>
    <tbody>
        @For i As Integer = 1 To Model.Topics.Count
            Dim li As Integer = i
            Dim t = Model.Topics(i - 1)
            @<tr class="@(IIf(i mod 2, "odd-line", "even-line"))" id="@(t.seo.Replace(" ", "_"))">
                <td>@(t.TopicType)</td>
                <td style="text-align:left; padding-left:5px;">@(t.SeoFriendly)</td>
                <td class="hidemobile">@(t.updatedutc.ToString(Model.UpdatedFormat))</td>
                <td>
                    <form action="@Url.Action("Edit", "Topic", New With {.seo = t.seo})">
                        <input type="submit" class="submit-green" value="@Html.Localize("Topic.Manage.EditSubmit")" />
                    </form>
                </td>
                @If (t.TopicType = Data.Entity.TopicType.Widget) Then
                    @<td />
                Else
                    @<td id="topic_delete">
                        @Using Ajax.BeginForm("Delete", "Topic", "Delete", New AjaxOptions With {
                                                .HttpMethod = "post",
                                                .InsertionMode = InsertionMode.Replace,
                                                .UpdateTargetId = String.Format("{0}", t.seo.Replace(" ", "_"))})
                            @Html.Hidden("seodisplay", t.seo)
                            @Html.Hidden("seo", Url.RequestContext.RouteData.Values("seo").ToString())
                            @<input type="submit" value="@Html.Localize("Topic.Manage.DeleteSubmit")" class="submit-red" />
                        End Using
                    </td>
                End If
            </tr>
        Next
        @If Model.Topics.Count = 0 Then
            @<tr class="odd-line">
                <td colspan="6">
                    @Html.Localize("Topic.Manage.NoData")
                </td>
            </tr>
        End If
    </tbody>
    <tfoot>
        <tr>
            <td colspan="6">&nbsp;</td>
        </tr>
    </tfoot>
</table>
@Html.LastUpdated(Model.LastUpdated)