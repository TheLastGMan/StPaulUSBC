<!DOCTYPE html>
<!--<html lang="en" manifest ="@(Url.Content("~/offline.appcache.na"))">-->
<html lang="en">
<head>
    <meta charset="utf-8" />
    <meta name="viewport" content="initial-scale=1.0,width=device-width" />
    <title>@ViewData("Title")</title>

    <link rel="icon" type="image/png" href="@Url.Content("~/content/favicon.png")" />
    <link rel="shortcut icon" type="image/vnd.microsoft.icon" href="@Url.Content("~/content/favicon.ico")" />

    <link rel="stylesheet" type="text/css" href="@Url.Content("~/content/usbc.min.css")" />
    <link rel="stylesheet" type="text/css" href="@Url.Content("~/content/mobile.min.css")" media="screen and (max-device-width: 715px), screen and (max-width: 715px)" />
@If Not Request.IsLocal Then
    @<script type="text/javascript" src="//ajax.googleapis.com/ajax/libs/jquery/1.8.0/jquery.min.js"></script>
    @<script type="text/javascript" src="//ajax.aspnetcdn.com/ajax/jquery.ui/1.10.0/jquery-ui.min.js"></script>
Else
    @<script type="text/javascript" src="@Url.Content("~/scripts/jquery-1.8.0.min.js")"></script>
    @<script type="text/javascript" src="@Url.Content("~/scripts/jquery-ui-1.10.0.custom.min.js")"></script>
End If
    <script type="text/javascript" src="@Url.Content("~/scripts/commonbundle.min.js")"></script>
</head>
<body>
    @RenderBody()
</body>
</html>