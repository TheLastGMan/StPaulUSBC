@ModelType String
@code
    Layout = Nothing
End Code

<div class="addthis_toolbox addthis_default_style addthis_32x32_style sharelinks">
    <a class="addthis_button_facebook"></a>
    <a class="addthis_button_google_plusone_share"></a>
    <a class="addthis_button_linkedin"></a>
    <a class="addthis_button_email"></a>
    <a class="addthis_button_print"></a>
    <a class="addthis_button_compact"></a>
</div>
<script type="text/javascript" src="//s7.addthis.com/js/300/addthis_widget.js"></script>
<script type="text/javascript">
    var addthis_config = {
        data_ga_property : '@(model)',
        data_ga_social : true
    };
</script>
