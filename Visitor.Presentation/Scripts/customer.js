var subCustomerNameIsValid = false;

function disableSubCustomerBtn(action) {
    switch (action) {
        case "create":
            $("#inv-createSubCustomer-ok").attr("disabled", "disabled");
            break;
        case "update":
            $("#inv-updateSubCustomer-ok").attr("disabled", "disabled");
            break;
    }

}

function enableSubCustomerBtn(action) {
    switch (action) {
        case "create":
            if ($("#inv-createSubCustomer-ok").attr("disabled") == "disabled") {
                $("#inv-createSubCustomer-ok").removeAttr("disabled");
            }
            break;
        case "update":
            if ($("#inv-updateSubCustomer-ok").attr("disabled") == "disabled") {
                $("#inv-updateSubCustomer-ok").removeAttr("disabled");
            }
            break;
    }
}

function findDuplicateItemInSubCustomer(input, element, itemName, action) {
    let isValidInput;
    let ignoreCaseInput = input.toUpperCase();
    let curElId = $("#invListId").val();

    if ($("#subCustomer-creationList").has("div").length > 0) {
        $("#subCustomer-creationList").children("div").each(function (index, el) {
            let dom;
            let noCaseDome;
            if (element === "subCustomerName") {
                dom = $(this).children().find(".subcustomer-record-name").text();
            }
            noCaseDome = dom.toUpperCase();

            if (ignoreCaseInput == noCaseDome) {
                if ($("#visitorFields").find(".update-mode").length == 0) {
                    otErrorAlert(itemName + " already in use. Please input a unique " + itemName);
                    subCustomerNameIsValid = false;
                    disableSubCustomerBtn(action);
                    return false;
                } else {
                    if (el.id == curElId) {
                        subCustomerNameIsValid = true;
                        isValidInput = subCustomerNameIsValid;
                        isValidInput ? enableSubCustomerBtn(action) : disableSubCustomerBtn(action);
                    } else {
                        otErrorAlert(itemName + " already in use. Please input a unique " + itemName);
                        subCustomerNameIsValid = false;
                        disableSubCustomerBtn(action);
                        return false;
                    }
                }

            } else {
                subCustomerNameIsValid = true;
                isValidInput = subCustomerNameIsValid;
                isValidInput ? enableSubCustomerBtn(action) : disableSubCustomerBtn(action);
            }

        });
    }
}

$(function () {

    var customerData = {};
    var selectedCustomer = "";
    var selectedIndex = 0;
    var isInitLoad = true;
    var confirmCancel = "Confirm cancel with changes";
    var confirmCancelContent = "Are you sure you want to cancel?";
    var linkButtonHtml = "<button id=\"customer-cps-link-btn\" type=\"button\" data-target=\"#link-with-cps-modal\" class=\"btn btn-primary link-with-cps-button\">Link with CPS Customer <span class=\"glyphicon glyphicon-link\"></span></button>";
    var unlinkButtonHtml = "<button id=\"customer-cps-unlink-btn\" type=\"button\" class=\"btn btn-danger unlink-with-cps-button\"> Unlink CPS Customer <span class=\"glyphicon glyphicon-remove-circle\"></span></button>";
    var subCustomerHasChanged = false;

    $(".required-subcustomer-field").val("");
    $(".required-subcustomer-field").attr("disabled", "disabled");
    
    $("#customer-link").on("click", "#customer-cps-link-btn", function () {
        var url = $("#customerList").data('url');
        customerData = {};
        selectedCustomer = {};
        showLoading();

        $.get(url, function (data) {
            $("#modalContainer").html(data);
            var customersListTable = $('#customer-modal').DataTable();

            $('#customer-modal tbody').on('click', 'tr', function () {
                if ($(this).hasClass('selected')) {
                    $(this).removeClass('selected');
                    customerData = customersListTable.row(this).data();
                    $("#link-ok").attr("disabled", "disabled");
                }
                else {
                    customersListTable.$('tr.selected').removeClass('selected');
                    $(this).addClass('selected');
                    $("#link-ok").removeAttr("disabled");

                    customerData = customersListTable.row(this).data();
                    selectedIndex = customersListTable.row(this).index();
                    selectedCustomer = customerData;
                }
            });

            $('#link-ok').on("click", function () {
                if (selectedCustomer != null) {
                    var customerName = $("#selected-customer-name" + selectedIndex).val();
                    var cpsNSId = $("#selected-customer-cpsNSId" + selectedIndex).val();
                    var cpsId = $("#selected-customer-cpsId" + selectedIndex).val();
                    var axReference = $("#selected-customer-axReference" + selectedIndex).val();
                    var isAX = (axReference != "" ? true : false)
                    $("#customer-link").html(unlinkButtonHtml);
                    $("#Name").val(customerName);
                    $("#Name").valid();
                    $("#CPSNSId").val(cpsNSId);
                    $("#CPSId").val(cpsId);
                    $("#AXReference").val(axReference);
                    $("#Name").attr("readonly", "readonly")
                    if (isAX) {
                        $("#AXReference").attr("readonly", "readonly")
                    }
                    $("#IsCPSCustomer").val(true);
                    $("#IsAX").val(isAX);
                    $('#customerList').modal('hide');
                }
            });

            $("#customerList").modal("show");
            hideLoading();
        })
    });

    $("#customer-link").on("click", "#customer-cps-unlink-btn", function () {
        $("#customer-link").html(linkButtonHtml);
        $("#Name").val("");
        $("#CPSNSId").val("");
        $("#CPSId").val("");
        $("#AXReference").val("");
        $("#Name").removeAttr("readonly");
        $("#AXReference").removeAttr("readonly");
        $("#IsCPSCustomer").val(false);
        $("#IsAX").val(false);
    });

    // Notify if a form status is changed
    $("form :input").on("change", function () {
        if (!isInitLoad) {
            $(this).closest('form').data('changed', true);
        }
    });

    $("#customerCreation-cancel-btn, #customerModification-cancel-btn").on("click", function () {
        if ($(this).closest('form').data('changed')) {
            $.confirm({
                title: confirmCancel,
                content: confirmCancelContent,
                buttons: {
                    confirm: {
                        btnClass: "btn-blue",
                        action: function () {
                            window.history.back();
                        }
                    },
                    cancel: {
                        btnClass: "btn-red",
                    }
                }
            });
        } else {
            window.history.back();
        }
    });

    $("#customerCreation-ok-btn").on("click", function () {
        $("#customerCreation-form").val();
        console.log("Will be created.");
    });

    // Sub-customer

    // Check for input change confirmation
    $("#subcustomer-creation-modal").on("input", ".check-change", function () {
        subCustomerHasChanged = true;
    });

    $("#subcustomer-creation-modal").on("click", "#inv-createSubCustomer-cancel, #updateSubCustomer-cancel", function (e) {
        let hasValue;
        $("input.subcustomer-validate").each(function (index, el) {
            if (el.value != "") {
                hasValue = true;
                return false;
            }
            hasValue = false;
        });
        e.preventDefault();
        if (subCustomerHasChanged && hasValue) {
            $.confirm({
                title: confirmCancel,
                content: "Sub-customer input has changed. Do you really want to cancel?",
                buttons: {
                    confirm: {
                        btnClass: "btn-blue",
                        action: function () {
                            subCustomerHasChanged = false;
                            $("#subcustomer-creation-modal").modal("hide");
                        }
                    },
                    cancel: {
                        btnClass: "btn-red"
                    }
                }
            });
        } else {
            subCustomerHasChanged = false;
            $("#subcustomer-creation-modal").modal("hide");
        }
    });

    // Enable Disable Checkboxes - Sub Customer
    $('#subcustomer-creation-modal').on('show.bs.modal', function (e) {
        subCustomerHasChanged = false;
        $(".required-subcustomer-field").removeAttr("disabled");
        if ($("#SubCustomerActivityLogReportSettingEnabled").is(":checked")) {
            checkBoxRelatedFieldsByClass("#SubCustomerActivityLogReportSettingEnabled", ".subactivitylog-field-activator");
        }
    });

    $('#subcustomer-creation-modal').on('hidden.bs.modal', function () {
        if ($(".formError").length) {
            $(".formError").remove();
        }

        $(".required-subcustomer-field").val("");
        $(".required-subcustomer-field").attr("disabled", "disabled");
        $(".clear-email-content").val("");
        $(".clear-email-content").attr("disabled", "disabled");
        $(".clear-checkbox").prop("checked", false);
        $("#SubCustomerActivityLogReportSettingScheduleType").val("0");
        $("#SubCustomerActivityLogReportSettingFormatType").val("0");
        $("#SubCustomerActivityLogReportSettingScheduleType").attr("disabled", "disabled");
        $("#SubCustomerActivityLogReportSettingFormatType").attr("disabled", "disabled");
        $("#SubCustomerAXReference").val("");
        $("#SubCustomerLegacySystem").val("");
        $("#SubCustomerLegacyReference").val("");
        $("#ForAddition").val("False");
    })

    $("body").on("change", "#SubCustomerActivityLogReportSettingEnabled", function () {
        checkBoxRelatedFieldsByClass("#SubCustomerActivityLogReportSettingEnabled", ".subactivitylog-field-activator");
        $(".SubCustomerActivityLogReportSettingReceiverEmailAddressformError").remove();
    });

    // end of Enable Disable Checkboxes

    $("#inv-subcustomer-creation-btn").on("click", function () {
        var updateSubCustomerBtn = "<button id='inv-createSubCustomer-cancel' type='button' class='btn btn-danger'>Cancel</button><button id='inv-createSubCustomer-ok' type='button' value='Create' class='btn btn-primary'>Create</button>";

        $("#subCustomer-addupdate-footer").html(updateSubCustomerBtn);
        $("#subcustomer-creation-modal").modal("show");
    });

    $("#subcustomer-creation-modal").on("click", "#inv-createSubCustomer-ok", function () {
        var url = $("#subcustomer-creation-modal").data("creationurl");
        var isValid = true;
        var subCustomerName = $("#SubCustomerName").val();
        var axReference = $("#SubCustomerAXReference").val();
        var ssoKey = $("#SubCustomerSSOKey").val();
        var legacySystem = $("#SubCustomerLegacySystem").val();
        var legacyReference = $("#SubCustomerLegacyReference").val();
        var newSubCustomerId = 0;
        
        $(".subcustomer-validate").each(function () {
            isValid = $(this).valid() && isValid;
        });

        $(".hiddenSubCustomerName").val(subCustomerName);
        $(".hiddenSubCustomerAXReference").val(axReference);
        $(".hiddenSubCustomerSSOKey").val(ssoKey);
        $(".hiddenSubCustomerLegacySystem").val(legacySystem);
        $(".hiddenSubCustomerLegacyReference").val(legacyReference);
        $("#SubCustomerId").val(newSubCustomerId);

        if (isValid == true) {
            var subCustomerCount = $("div[class*='subCustomer-panel']").length;
            var postData = $("#visitorFields :input").serialize();

            subCustomerCount++;
            $.ajax({
                url: url,
                type: "POST",
                data: postData + "&subCustomerNumber=" + subCustomerCount,
                success: function (partialView) {
                    subCustomerHasChanged = false;
                    $("#subCustomer-creationList").append(partialView);
                    $("#subcustomer-creation-modal").modal("hide");
                }
            })
        }
        else {
            console.log("Required field is not filled-up.");
        }
    });

    $("#subCustomer-creationList").on("click", ".modify-subCustomer", function (e) {
        var parents = $(this).parents();
        var parentEl = parents[1];
        var subCustomerCount = $(parentEl).data("subcustomercount");

        var subCustomerInfo = $("#hidden-subcustomer-" + subCustomerCount + " :input").map(function () {
            var type = $(this).prop("type");
            var isScheduleType = false;
            var isFormatType = false;
            var isReportSettingsCheckbox = false;
            var isMailingListCheckbox = false;

            isScheduleType = $(this).data("type") == "scheduleType";
            isFormatType = $(this).data("type") == "formatType";
            isReportSettingsCheckbox = $(this).data("type") == "reportSettingsCheckbox";

            // checked radios/checkboxes
            if ((type == "checkbox" || type == "radio") && this.checked) {
                return $(this).val();
            }
            else if (isScheduleType) {
                var value = $(this).val();

                switch (value) {
                    case "Daily":
                        return 0;
                        break;
                    case "Weekly":
                        return 1;
                        break;
                    case "Monthly":
                        return 2;
                        break;
                    default:
                        console.log("There is something wrong. Value: " + value);
                }
            }
            else if (isFormatType) {
                var value = $(this).val();

                switch (value) {
                    case "CSV":
                        return 0;
                        break;
                    case "XLS":
                        return 1;
                        break;
                    default:
                        console.log("There is something wrong. Value: " + value);
                }
            }
            else if (isReportSettingsCheckbox) {
                return $(this).val();
            }
                // all other fields, except buttons
            else if (type != "button" || type != "submit") {
                return $(this).val();
            }

        });

        var subCustomerId = subCustomerInfo[1];
        var customerId = subCustomerInfo[2];
        var subCustomerName = subCustomerInfo[3];
        var ssoKey = subCustomerInfo[4];
        var axReference = subCustomerInfo[5];
        var legacySystem = subCustomerInfo[6];
        var legacyReference = subCustomerInfo[7];
        var scIsActivityLogReport = subCustomerInfo[8];
        var scActivityLogEmail = subCustomerInfo[9];
        var scActivityLogScheduleType = subCustomerInfo[10];
        var scActivityLogFormatType = subCustomerInfo[11];

        $("#SubCustomerName").val(subCustomerName);
        $("#SubCustomerSSOKey").val(ssoKey);
        $("#SubCustomerAXReference").val(axReference);
        $("#SubCustomerLegacySystem").val(legacySystem);
        $("#SubCustomerLegacyReference").val(legacyReference);
        $("#SubCustomerId").val(subCustomerId);
        $("#CustomerId").val(customerId);
        $("#SubCustomerCount").val(subCustomerCount);
        $("#ForAddition").val("True");
        $("#invListId").val(parentEl.id);
        if (scIsActivityLogReport == "True") {
            $("#SubCustomerActivityLogReportSettingEnabled").prop("checked", scIsActivityLogReport).change();
        }
        $("#SubCustomerActivityLogReportSettingReceiverEmailAddress").val(scActivityLogEmail);
        $("#SubCustomerActivityLogReportSettingScheduleType").val(scActivityLogScheduleType).change();
        $("#SubCustomerActivityLogReportSettingFormatType").val(scActivityLogFormatType).change();

        var updateSubCustomerBtn = "<button id='updateSubCustomer-cancel' type='button' class='btn btn-danger'>Cancel</button><button id='inv-updateSubCustomer-ok' type='button' class='btn btn-primary update-mode'>Update</button>";

        $("#subCustomer-addupdate-footer").html(updateSubCustomerBtn);
        $("#subcustomer-creation-modal").modal("show");

    });

    $("#SubCustomerActivityLogReportSettingEnabled").change(function () {
        checkbox = $(this);
        checkbox.val(checkbox.prop("checked"));

        $("#SubCustomerActivityLogReportSettingReceiverEmailAddress").val("");

    }).change();

    $("#subcustomer-creation-modal").on("click", "#inv-updateSubCustomer-ok", function () {
        var url = $("#subcustomer-creation-modal").data("posturl");
        var isValid = false;
        var subCustomerName = $("#SubCustomerName").val();
        var ssoKey = $("#SubCustomerSSOKey").val();

        isValid = $(".subcustomer-validate").valid();
        if (isValid) {
            var subCustomerNumber = $("#SubCustomerCount").val();
            var postData = $("#visitorFields :input").serialize();
            $.ajax({
                url: url,
                type: "POST",
                data: postData + "&subCustomerNumber=" + subCustomerNumber,
                success: function (partialView) {
                    subCustomerHasChanged = false;
                    $("#subCustomer-data-" + subCustomerNumber).replaceWith(partialView)
                    $("#subcustomer-creation-modal").modal("hide");
                }
            })            
        } else {
            console.log("Required Sub-customer fields were blank.");
        }

    });

    $("#subCustomer-creationList").on("click", ".delete-subCustomer", function () {
        var subCustomerNumber = $(this).data("subcustomercount");
        $.confirm({
            title: 'Confirm Deletion',
            content: 'Are you sure you want to delete this item?',
            buttons: {
                confirm: {
                    btnClass: "btn-blue",
                    action: function () {
                        $("#subCustomer-data-" + subCustomerNumber).replaceWith("");
                        otInfoAlert("Sub-customer is successfully deleted.");
                    }
                },
                cancel: {
                    btnClass: "btn-red",
                    action: function () {
                    }
                }
            }
        });
    });

    //Sub-customer name check
    $("#subcustomer-creation-modal").on("focusout", ".subcustomer-validate", function () {
        $(this).valid();
    });

    $("#subcustomer-creation-modal").on("keyup", "#SubCustomerName", function () {
        let input = $(this).val();
        if ($("#ForAddition").val() == "False") {
            findDuplicateItemInSubCustomer(input, "subCustomerName", "Sub-Customer name", "create");
        } else {
            findDuplicateItemInSubCustomer(input, "subCustomerName", "Sub-Customer name", "update");
        }
    });

    $("#ActivityLogReportSettingEnabled").change(function () {
        checkBoxRelatedFieldsByClass("#ActivityLogReportSettingEnabled", ".activitylog-field-activator");
        $(".ActivityLogReportSettingReceiverEmailAddressformError").remove();
    });
    if ($("#ActivityLogReportSettingEnabled").is(":checked")) {
        checkBoxRelatedFieldsByClass("#ActivityLogReportSettingEnabled", ".activitylog-field-activator");
        $(".ActivityLogReportSettingReceiverEmailAddressformError").remove();
    }

    isInitLoad = false;
});