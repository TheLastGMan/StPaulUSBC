@ModelType Web.Models.Award.AwardModel
@Code
    Layout = Nothing
End Code

<div id="awardcontainer">
@Using Ajax.BeginForm("Index", "Award", New AjaxOptions With {.UpdateTargetId = "awardcontainer", .Url=Url.Action("Index", "Award"), .HttpMethod="POST", .LoadingElementId="modal", .LoadingElementDuration=1000})
    
    @Html.DateField("DateBowled")
    @Html.NumericField(1, 255, "BowlerGames")
    @Html.NumericField(0, 900, "Series")
    @Html.AutoComplete("Center", Model.CenterLst.ToArray)
    @Html.AutoComplete("League", Model.LeagueLst.ToArray)
    @<script type="text/javascript">

         function ShowId(id) {
             $("#" + id).css("visibility", "visible");
         };
         function RemoveId(id) {
             $("#" + id).remove();
         };

        $(function(){

            $("#USBCA_B@(model.USBCAwards.count)").css("visibility", "visible");
            $("#LocalA_B@(model.LocalAwards.Count)").css("visibility", "visible");
            $("#UpdateAwards").css("display", "none");

            if (!Modernizr.inputtypes.number) {
                $("#BowlerAverage").spinner({ min: 0, max: 300 });
                $("#Game1, #Game2, #Game3").spinner(
                                                    {min:0,max:300, 
                                                     step:1, incremental:false, 
                                                     stop:function(e,ui){
                                                         $(this).change();
                                                     }});
            };

            $("#BowlerAverage").blur(function () {
                $("#UpdateAwards").click();
            });
            $("#AwardTypeId").change(function () {
                $("#UpdateAwards").click();
            });

            $('#Game1, #Game2, #Game3').change(function() {
                var g1, g2, g3;

                var thisnum = parseInt($(this).val());
                if(isNaN(thisnum)){ $(this).val('0')};

                g1 = parseInt($('#Game1').val());
                g2 = parseInt($('#Game2').val());
                g3 = parseInt($('#Game3').val());
                var series = CalcSeries(g1, g2, g3);
                $('#Series').val(series);
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
            <h3>@Html.Localize("Award.Index.BowlerGames")</h3>
            @Html.TextBoxFor(Function(f) f.BowlerGames, New With {.type = "number", .required = "required", .min = "1", .max = "255"})
            <br/>@Html.ValidationMessageFor(Function(f) f.BowlerGames)
        </div>
        <div class="shortbox">
            <h3>@Html.Localize("Award.Index.BowlerAverage")</h3>
            @Html.TextBoxFor(Function(f) f.BowlerAverage, New With {.type="number", .required="required", .min="0", .max="300"})
            <br/>@Html.ValidationMessageFor(Function(f) f.BowlerAverage)
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
        <div class="fullbox">
            @Html.Widget("award_info_header")
            @Html.ValidationMessage("AwardCount")
        </div>
        <div class="longbox">
            <h3>@Html.Localize("Award.Index.Achievement")</h3>
            @For i As Integer = 1 To Model.USBCAwards.Count
                Dim lv As Integer = i
                Dim itm = Model.USBCAwards(lv - 1)
                @<div id="@(String.Format("USBCA_{0}", lv))">
                    @Html.HiddenFor(Function(f) f.USBCAwards(lv - 1).Id)
                    @Html.HiddenFor(Function(f) f.USBCAwards(lv - 1).Name)
                    <table style="width:95%; margin:auto; text-align:left;">
                        <tr>
                            <td style="width:95%;">
                                @(itm.Name)
                            </td>
                            <td>
                                <a id="USBCA_B@(lv)" href="#" style="visibility:hidden;" onclick="ShowId('USBCA_B@(lv-1)'); RemoveId('USBCA_@(lv)'); return false;">X</a>
                            </td>
                        </tr>
                    </table>
                 </div> 
            Next
            @Html.DropDownListFor(Function(f) f.USBCAwardId, New SelectList(Model.USBCAwardLst, "Id", "Name", 1))
            <input name="AddUSBCAward" type="submit" class="submit-green" value="@Html.Localize("Award.Index.USBCAward.Submit")" />
        </div>
        <div class="longbox">
            <h3>@Html.Localize("Award.Index.LocalAchievement")</h3>
            @For i As Integer = 1 To Model.LocalAwards.Count
                Dim lv As Integer = i
                Dim itm = Model.LocalAwards(lv - 1)
                @<div id="LocalA_@(lv)">
                    @Html.HiddenFor(Function(f) f.LocalAwards(lv - 1).Id)
                    @Html.HiddenFor(Function(f) f.LocalAwards(lv - 1).Name)
                    <table style="width:95%; margin:auto; text-align:left;">
                        <tr>
                            <td style="width:95%;">
                                @(itm.Name)
                            </td>
                            <td>
                                <a id="LocalA_B@(lv)" href="#" style="visibility:hidden;" onclick="ShowId('LocalA_B@(lv-1)'); RemoveId('LocalA_@(lv)'); return false;">X</a>
                            </td>
                        </tr>
                    </table>
                </div>
            Next
            @Html.DropDownListFor(Function(f) f.LocalAwardId, New SelectList(Model.LocalAwardLst, "Id", "Name", 1))
            <input name="AddLocalAward" type="submit" class="submit-red" value="@Html.Localize("Award.Index.LocalAward.Submit")" />
        </div>
        <div id="awardchoice" style="display:@(iif(Model.AwardTypeId = 1, "normal", "none"));" class="longbox">
            <h3>@Html.Localize("Award.Index.AwardChoice")</h3>
            @Html.DropDownListFor(Function(f) f.AdultAwardChoiceId, New SelectList(Model.AwardChoiceLst, "Id", "Name", Model.AdultAwardChoiceId))
        </div>
        <div class="fullbox">
            <input type="submit" id="UpdateAwards" name="UpdateAwards" class="submit-ltgold" style="display:normal;" value="@Html.Localize("Award.Index.LoadAwardSubmit")" />
            @Html.Widget("award_info_footer")
        </div>
        <div class="longbox">
            <h3>@Html.Localize("Award.Index.SecretaryName")</h3>
            @Html.TextBoxFor(Function(f) f.SecretaryName, New With {.required="required", .placeholder=Html.Localize("Award.AwardForm.SecretaryName.Placeholder")})
            <br/>@Html.ValidationMessageFor(Function(f) f.SecretaryName)
        </div>
        <div class="longbox">
            <h3>@Html.Localize("Award.Index.SecretaryEmail")</h3>
            @Html.TextBoxFor(Function(f) f.SecretaryEmail, New With {.placeholder=Html.Localize("Award.AwardForm.SecretaryEmail.Placeholder")})
            <br/>@Html.ValidationMessageFor(Function(f) f.SecretaryEmail)
        </div>
        <div class="shortbox">
            <h3>@Html.Localize("Award.Index.SecretaryPin")</h3>
            @Html.TextBoxFor(Function(f) f.SecretaryPin, New With {.required="required", .placeholder=Html.Localize("Award.AwardForm.SecretaryPin.Placeholder")})
            <br/>@Html.ValidationMessageFor(Function(f) f.SecretaryPin)
        </div>
        <div class="shortbox">
            <h3>@Html.Localize("Award.Index.SecretaryPhone")</h3>
            @Html.TextBoxFor(Function(f) f.SecretaryPhone, New With {.placeholder = Html.Localize("Award.AwardForm.SecretaryPhone.Placeholder")})
            <br/>@Html.ValidationMessageFor(Function(f) f.SecretaryPhone)
        </div>
        <div class="fullbox">&nbsp;</div>
        <div class="fullbox">
            <input type="submit" name="save" class="submit-green" value="@Html.Localize("Award.Index.SaveSubmit")" />&nbsp;&nbsp;
            <a href="@Url.Action("Index")" class="linkbutton submit-red">@Html.Localize("Award.Index.ResetSubmit")</a>
        </div>
    </div>
End Using
</div>
@html.FullScreenLoad()