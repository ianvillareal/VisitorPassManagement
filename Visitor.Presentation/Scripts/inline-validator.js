$(function () {
    if ($('form.with-validation').length > 0 )
    {
        $('form.with-validation').data("validator").settings.ignore = ":hidden:not(.form-control), novalidation";
    }
    $('#tabs').tabs({
        activate: function (event, ui) {
            $('form.with-validation').validationEngine("updatePromptsPosition");
        }
    });
    $('form.with-validation').on("invalid-form.validate", function (form, validator) {
        if (validator.errorList.length) {
            var validatorTab = null;
            var activeIndex = $("#tabs").tabs('option', 'active');
            var index = null;
            for (var i = validator.errorList.length - 1; i >= 0; i--) {
                validatorTab = $('#tabs a[href="#' + jQuery(validator.errorList[i].element).closest(".tab-pane").attr('id') + '"]');
                index = validatorTab.parent().index();
                if (activeIndex === index)
                    break;
                else if (index < activeIndex) {
                    validatorTab = $('#tabs a[href="#' + jQuery(validator.errorList[0].element).closest(".tab-pane").attr('id') + '"]');
                    index = validatorTab.parent().index();
                    break;
                }
            }
            //var validatorTab = $('#tabs a[href="#' + jQuery(validator.errorList[0].element).closest(".tab-pane").attr('id') + '"]');
            validatorTab.tab('show');
            $('#tabs').tabs("option", "active", index);
        }

    });
    $('form.with-validation').makeValidationInline({
        prettySelect: true,
        autoPositionUpdate: true,
    });
    $('form.with-validation').validationEngine('attach', {
        prettySelect: true,
        autoPositionUpdate: true,
    });
    //$.validationEngine.defaults.prettySelect = true;
    //$.validationEngine.defaults.autoPositionUpdate = true;
});