@ModelType System.Web.Mvc.HandleErrorInfo

@Code
    Layout = "~/Views/Shared/_Layout.vbhtml"
    ViewData("Title") = "Error"
End Code

<style>
    #searchform, .sharelinks {
        display: none;
    }
    #navheader {
        height: 5px;
    }
</style>

<h1>Error</h1>
<div style="min-height:300px;">
    <h2 style="text-align:center;">There was an error while processing your request</h2>
    @If Model IsNot Nothing Then   
        @<p style="padding-left:15px;">
                URL:@(Url.Action(Model.ActionName, Model.ControllerName))
                <br />
                Error : @Model.Exception.Message
        </p>
    End If
</div>