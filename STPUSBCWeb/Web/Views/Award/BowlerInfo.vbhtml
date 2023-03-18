@ModelType web.Models.Award.BowlerInfo
@Code
    ViewData("Title") = Html.TitleMaker(Html.Localize("Award.Index.URLTitle").ToString)
End Code

@Html.DateField(Html.FieldIdFor(Function(f) f.DateBowled))
@Html.NumericField(1, 255, Html.FieldIdFor(Function(f) f.BowlerGames))
@Html.NumericField(0, 900, Html.FieldIdFor(Function(f) f.Series))
@Html.AutoComplete(Html.FieldIdFor(Function(f) f.Center), Model.CenterLst.ToArray)
@Html.AutoComplete(Html.FieldIdFor(Function(f) f.League), Model.LeagueLst.ToArray)

<script type="text/javascript">

    $(function(){

        var g1n = '#' + '@(Html.FieldIdFor(Function(f) f.Game1))';
        var g2n = '#' + '@(Html.FieldIdFor(Function(f) f.Game2))';
        var g3n = '#' + '@(Html.FieldIdFor(Function(f) f.Game3))';
        var ser = '#' + '@(Html.FieldIdFor(Function(f) f.Series))';
        var boa = '#'+'@(Html.FieldIdFor(Function(f) f.BowlerAverage))';
        var tgs = g1n + ',' + g2n + ','+g3n;

        if (!Modernizr.inputtypes.number) {
            $(boa).spinner({ min: 0, max: 300 });
            $(tgs).spinner(
                {min:0,max:300, 
                    step:1, incremental:false, 
                    stop:function(e,ui){
                        $(this).change();
                    }});
        };

        $(tgs).change(function() {
            var g1, g2, g3;

            var thisnum = parseInt($(this).val());
            if(isNaN(thisnum)){ $(this).val('0')};

            g1 = parseInt($(g1n).val());
            g2 = parseInt($(g2n).val());
            g3 = parseInt($(g3n).val());
            var series = CalcSeries(g1, g2, g3);
            $(ser).val(series);
        });
    });

    function CalcSeries(g1, g2, g3) {
        var series = 0;
        if (g1 < 0 || isNaN(g1)) {g1 = 0}; if(g1 > 300) {g1 = 300};
        if (g2 < 0 || isNaN(g2)) {g2 = 0}; if(g2 > 300) {g1 = 300};
        if (g3 < 0 || isNaN(g3)) {g3 = 0}; if(g3 > 300) {g1 = 300};
        return g1 + g2 + g3;
    };

</script>

@Html.Partial("_AwardProcess", New Web.Models.Award.Process With {.CurrentStep = Web.Models.Award.AwardStep.BowlerInfo, .AwardID = Model.AwardID})
<h2 class="align-center">@Html.Raw(Html.Localize("Award.Progress.BowlerInfo").ToHtmlString)</h2>
@Html.Widget("award_index")

@Using Html.BeginForm("BowlerInfo", "Award", FormMethod.Post, New With {.class = "award-form"})
    @Html.AntiForgeryToken()
    @Html.HiddenFor(Function(f) f.AwardID)
    @<div class="award">
            <div class="longbox">
                <h3>@Html.Localize("Award.Index.Center")</h3>
                @Html.TextBoxFor(Function(f) f.Center, New With {.required = "required", .placeholder=Html.Localize("Award.AwardForm.Center.Placeholder")})
                <br/>@Html.ValidationMessageFor(Function(f) f.Center)
            </div>
            <div class="longbox">
                <h3>@Html.Localize("Award.Index.League")</h3>
                @Html.TextBoxFor(Function(f) f.League, New With {.required = "required", .placeholder=Html.Localize("Award.AwardForm.League.Placeholder")})
                <br/>@Html.ValidationMessageFor(Function(f) f.League)
            </div>
            <div class="fullbox">&nbsp;</div>
            <div class="shortbox">
                <h3>@Html.Localize("Award.Index.BowlerType")</h3>
                @Html.DropDownListFor(Function(f) f.AwardTypeId, New SelectList(Model.BowlerTypeLst, "Id", "Description", Model.AwardTypeId))
            </div>
            <div class="longbox">
                <h3>@Html.Localize("Award.Index.BowlerName")</h3>
                @Html.TextBoxFor(Function(f) f.BowlerName, New With {.required = "required", .placeholder=Html.Localize("Award.AwardForm.BowlerName.Placeholder")})
                <br/>@Html.ValidationMessageFor(Function(f) f.BowlerName)
            </div>
            <div class="shortbox">
                <h3>@Html.Localize("Award.Index.USBCID")</h3>
                @Html.TextBoxFor(Function(f) f.USBCID, New With {.required = "required", .placeholder=Html.Localize("Award.AwardForm.USBCID.Placeholder")})
                <br/>@Html.ValidationMessageFor(Function(f) f.USBCID)
            </div>
            <div class="shortbox">
                <h3>@Html.Localize("Award.Index.DateBowled")</h3>
                @Html.TextBoxFor(Function(f) f.DateBowled, New With {.required = "required", .Value = Model.DateBowled.ToString("MM/dd/yyyy"), .placeholder = "MM/dd/yyyy"})
                <br/>@Html.ValidationMessageFor(Function(f) f.DateBowled)
            </div>
            <div class="fullbox">&nbsp;</div>
            <div class="shortbox">
                <h3>@Html.Localize("Award.Index.BowlerAverage")</h3>
                @Html.TextBoxFor(Function(f) f.BowlerAverage, New With {.type="number", .required="required", .min="0", .max="300"})
                <br/>@Html.ValidationMessageFor(Function(f) f.BowlerAverage)
            </div>    
            <div class="shortbox">
                <h3>@Html.Localize("Award.Index.BowlerGames")</h3>
                @Html.TextBoxFor(Function(f) f.BowlerGames, New With {.type = "number", .required = "required", .min = "1", .max = "255"})
                <br/>@Html.ValidationMessageFor(Function(f) f.BowlerGames)
            </div>
            <div class="shortbox">
                <h3>@Html.Localize("Award.Index.Game1")</h3>
                @Html.TextBoxFor(Function(f) f.Game1, New With {.type = "number", .required = "required", .min = "0", .max = "300"})
                <br/>@Html.ValidationMessageFor(Function(f) f.Game1)
            </div>
            <div class="shortbox">
                <h3>@Html.Localize("Award.Index.Game2")</h3>
                @Html.TextBoxFor(Function(f) f.game2, New With {.type="number", .required="required", .min="0", .max="300"})
                <br/>@Html.ValidationMessageFor(Function(f) f.Game2)
            </div>
            <div class="shortbox">
                <h3>@Html.Localize("Award.Index.Game3")</h3>
                @Html.TextBoxFor(Function(f) f.game3, New With {.type="number", .required="required", .min="0", .max="300"})
                <br/>@Html.ValidationMessageFor(Function(f) f.Game3)
            </div>
            <div class="shortbox">
                <h3>@Html.Localize("Award.Index.Series")</h3>
                @Html.TextBoxFor(Function(f) f.Series, New With {.type = "number", .required = "required", .min = "0", .max = "900"})
                <br/>@Html.ValidationMessageFor(Function(f) f.Series)
            </div>
            @Html.Partial("_AwardFormFooter")
    </div>
End Using
