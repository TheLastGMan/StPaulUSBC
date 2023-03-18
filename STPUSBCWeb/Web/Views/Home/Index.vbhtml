@Code
    ViewData("Title") = Html.TitleMaker(Html.Localize("Home.Index.URLTitle").ToString)
End Code

@Html.Widget("home_index")
