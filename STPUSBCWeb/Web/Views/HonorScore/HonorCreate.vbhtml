@ModelType Web.Models.HonorScore.HonorScoreEditModel
@Code
    ViewData("Title") = Html.TitleMaker(Html.Localize("HonorScore.HonorCreate.URLTitle").ToString)
    Dim ad As String = ""
    If Model.Honor.Achieved > New Date(1901, 1, 1) Then
        ad = Model.Honor.Achieved.ToString("MMM-dd-yyyy")
    End If
End Code

@Html.DateField("Honor_Achieved")

<script type="text/javascript">

    $(function(){

        if (!Modernizr.inputtypes.number) {
            $("#Honor_Game1, #Honor_Game2, #Honor_Game3").spinner(
                                                {min:-1, 
                                                 max:300, 
                                                 step:1, 
                                                 incremental:false, 
                                                 stop:function(e,ui){
                                                     $(this).change();}});
            $("#Honor_Series").spinner({min:-1, max:900, step:1, incremental:false});
        };
        $('#Honor_Game1, #Honor_Game2, #Honor_Game3').change(function() {
            var g1, g2, g3;

            var thisnum = parseInt($(this).val());
            if(isNaN(thisnum)){ $(this).val('-1')};

            g1 = parseInt($('#Honor_Game1').val());
            g2 = parseInt($('#Honor_Game2').val());
            g3 = parseInt($('#Honor_Game3').val());
            var series = CalcSeries(g1, g2, g3);
            $('#Honor_Series').val(series);
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

<h1>@Html.Localize("HonorScore.HonorCreate.Title")</h1>
@Html.ValidationSummary()
@Using Html.BeginForm("HonorCreatePost", "HonorScore")
    @<table id="edithonor" >
        <thead>
            <tr>
                <td>&nbsp;</td>
                <td></td>
            </tr>
        </thead>
            <tbody>
                <tr class="odd-line">
                    <td>@Html.Localize("HonorScore.HonorCreate.FirstName") :&nbsp;</td>
                    <td>@Html.TextBoxFor(Function(f) f.Honor.FirstName, New With {.required = "required", .placeholder="First Name"})</td>
                </tr>
                <tr class="even-line">
                    <td>@Html.Localize("HonorScore.HonorCreate.LastName") :&nbsp;</td>
                    <td>@Html.TextBoxFor(Function(f) f.Honor.LastName, New With {.required = "required", .placeholder = "Last Name"})</td>
                </tr>
                <tr class="odd-line">
                    <td>@Html.Localize("HonorScore.HonorCreate.HonorType") :&nbsp;</td>
                    <td>@(html.DropDownListFor(Function(f) f.Honor.HonorTypeId, New SelectList(Model.TypeList, "Id", "Description", Model.Honor.HonorTypeId)))</td>
                </tr>
                <tr class="even-line">
                    <td>@Html.Localize("HonorScore.HonorCreate.HonorCategory") :&nbsp;</td>
                    <td>@(html.DropDownListFor(Function(f) f.Honor.HonorCategoryId, New SelectList(model.CategoryList, "Id", "Description", Model.Honor.HonorCategoryId)))</td>
                </tr>
                <tr class="odd-line">
                    <td>@Html.Localize("HonorScore.HonorCreate.Game1") :&nbsp;</td>
                    <td>@(Html.TextBoxFor(Function(f) f.Honor.Game1, New With {.type = "number", .min = -1, .max = 300, .Value = -1}))</td>
                </tr>
                <tr class="even-line">
                    <td>@Html.Localize("HonorScore.HonorCreate.Game2") :&nbsp;</td>
                    <td>@(Html.TextBoxFor(Function(f) f.Honor.Game2, New With {.type = "number", .min = -1, .max = 300, .Value = -1}))</td>
                </tr>
                <tr class="odd-line">
                    <td>@Html.Localize("HonorScore.HonorCreate.Game3") :&nbsp;</td>
                    <td>@(Html.TextBoxFor(Function(f) f.Honor.Game3, New With {.type = "number", .min = -1, .max = 300, .Value = -1}))</td>
                </tr>
                <tr class="even-line">
                    <td>@Html.Localize("HonorScore.HonorCreate.Series") :&nbsp;</td>
                    <td>@(Html.TextBoxFor(Function(f) f.Honor.Series, New With {.type = "number", .min = 0, .max = 900, .Value = IIf(model.Honor.Series < 0, 0, Model.Honor.Series)}))</td>
                </tr>
                <tr class="odd-line">
                    <td>@Html.Localize("HonorScore.HonorCreate.Achieved") :&nbsp;</td>
                    <td>@(Html.TextBoxFor(Function(f) f.Honor.Achieved, New With {.Value = ad, .placeholder = "mm/dd/yyyy", .required="required"}))</td>
                </tr>
            </tbody>
        <tfoot>
            <tr>
                <td colspan="2">
                    @Html.HiddenFor(Function(f) f.CategoryId)
                    @Html.HiddenFor(Function(f) f.TypeId)
                    <input type="submit" class="submit-green" value="@Html.Localize("HonorScore.HonorCreate.SaveSubmit")" />&nbsp;&nbsp;
                    <a href="@(url.Action("Manage", New With {.hcid = Model.CategoryId, .htid = Model.TypeId}))" class="linkbutton submit-red">
                        @Html.Localize("HonorScore.HonorCreate.CancelSubmit")
                    </a>
                </td>
            </tr>
        </tfoot>
    </table>
end using
