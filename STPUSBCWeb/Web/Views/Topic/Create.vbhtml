@ModelType Web.Models.Topic.EditModel
@code
    ViewData("Title") = Html.TitleMaker(Html.Localize("Topic.Create.URLTitle").ToString)
End Code

<h1>@Html.Localize("Topic.Create.Title")</h1>
<div>
    <ul>
        <li>@Html.Localize("Topic.Create.Info.Page")</li>
        <li>@Html.Localize("Topic.Create.Info.Topic")</li>
    </ul>
    <br />
    @Html.Localize("Topic.Create.Info.Url").ToHtmlString.Replace("{host}", HttpContext.Current.Request.ServerVariables("HTTP_HOST"))
    <br />
</div>
@Html.ValidationSummary()
@Using Html.BeginForm("Create", "Topic")
    @Html.HiddenFor(Function(f) f.Topic)
    @<table id="ContentEditorCreate" >
        <thead>
            <tr>
                <td>&nbsp;</td>
                <td />
            </tr>
        </thead>
        <tbody>
            <tr class="odd-line">
                <td>@Html.Localize("Topic.Create.SEO") :&nbsp;</td>
                <td>@Html.TextBox("seo", "")</td>
            </tr>
            <tr class="even-line">
                <td>@Html.Localize("Topic.Create.Type") :&nbsp;</td>
                <td>
                    @Html.DropDownList("typex", New SelectList([Enum].GetValues(GetType(Data.Entity.TopicType))).Where(Function(f) Not f.Text = "Widget"))
                </td>
            </tr>
            <tr class="odd-line">
                <td>@Html.Localize("Topic.Create.Active") :&nbsp;</td>
                <td>@Html.CheckBox("active", True)</td>
            </tr>
        </tbody>
        <tfoot>
            <tr>
                <td colspan="2">&nbsp;</td>
            </tr>
        </tfoot>
    </table>
    @<div style="width:95%; text-align:center; margin:0 auto;">
        <h1>@Html.Localize("Topic.Create.Content")</h1>
        @Html.HtmlEditor("htmlcontent", Model.Topic.content)
        <br />
        <input type="submit" value="@Html.Localize("Topic.Create.SaveSubmit")" class="submit-green" />&nbsp;&nbsp;
        <a href="@(Url.Action("Manage", "Topic"))" class="linkbutton submit-red">@Html.Localize("Topic.Create.CancelSubmit")</a>
    </div>
End Using