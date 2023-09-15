$(function () {
    //var arrival = $("#Arrival").attr("value");
    ////var leave = $("#Leave").attr("value");
    //var arrival = $("#Arrival").attr("value") != "" ?
    //    moment($("#Arrival").attr("value"), "MMM-DD-YYYY HH:mm:ss", "en") : false;
    //var leave = $("#Leave").attr("value") != "" ?
    //    moment($("#Leave").attr("value"), "MMM-DD-YYYY HH:mm:ss", "en") : false;
    //Approval
    //$('#visitor-arrival').datetimepicker({
    //    format: 'MMM-DD-YYYY HH:mm:ss',
    //    ignoreReadonly: true,
    //    showClear: true,
    //    defaultDate: arrival,
    //    minDate: arrival,
    //    keepInvalid: false,
    //    parseInputDate: parseInputDate,
    //    useCurrent: false
    //});

    //$('#visitor-leave').datetimepicker({
    //    format: 'MMM-DD-YYYY HH:mm:ss',
    //    ignoreReadonly: true,
    //    showClear: true,
    //    defaultDate: leave,
    //    minDate: arrival,
    //    keepInvalid: false,
    //    parseInputDate: parseInputDate,
    //    useCurrent: false
    //});


    //// Datetime picker change (from) for search
    //$("#visitor-arrival").on("dp.change", function (e) {
    //    let curDate = e.date != false ? e.date.startOf('day') : false;
    //    $('#visitor-leave').data("DateTimePicker").minDate(curDate);
    //});

    //// Datetime picker change (until) for search
    //$("#visitor-leave").on("dp.change", function (e) {
    //    $('#visitor-arrival').data("DateTimePicker").maxDate(e.date);
    //});

    //$("#visitor-arrival").on("dp.show", function (e) {
    //    var currentFrom = $(this).val();
    //    if (currentFrom == "" && $("#Until").val() != "") {
    //        let untilDate = $("#Until").val()
    //        $("#visitor-arrival").data("DateTimePicker").defaultDate(untilDate);
    //    }
    //});

    //$("#visitor-leave").on("dp.show", function (e) {
    //    var currentUntil = $(this).val();
    //    if (currentUntil == "" && $("#From").val() != "") {
    //        let fromDate = $("#From").val()
    //        $("#visitor-leave").data("DateTimePicker").defaultDate(fromDate);
    //    }
    //});
});

$(document).ready(function () {
    var isInitLoad = true;
    var confirmCancelContent = "Are you sure you want to cancel?";

    $("form :input").on("change", function () {
        if (!isInitLoad) {
            $(this).closest('form').data('changed', true);
        }
    });

    //$("#visitorCreation-ok-btn").on("click", function () {
    //    $("#customerCreation-form").val();
    //    console.log("Will be created.");
    //});
    $("#visitorModification-ok-btn").on("click", function () {
        var postData = $(".visitorModification-form").serialize();
    });
    $("#visitorCreation-ok-btn").on("click", function () {
        var postData = $(".visitorCreation-form").serialize();
    });

    $("#visitorApproval-approve-btn").on("click", function () {
        $("#Status").val(3);
    });

    $("#visitorApproval-decline-btn").on("click", function () {
        $("#Status").val(4);
    });

    $("#securityApproval-pending-btn").on("click", function () {
        $("#Status").val(2);
    });

    $("#securityApproval-forcompletion-btn").on("click", function () {
        $("#Status").val(5);
    });

    $("#securityApproval-completed-btn").on("click", function () {
        $("#Status").val(6);
    });

    $("#visitorCreation-cancel-btn, #visitorModification-cancel-btn").on("click", function () {
        if ($(this).closest('form').on('changed')) {
            $.confirm({
                title: "Confirm cancel with changes",
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
    //Visitor Request
    //$('#visitor-request-table').DataTable();
    var visitorRequestTable = $('#visitor-request-table').DataTable({
        scrollCollapse: true,
        paging: false,
        info: false,
        ordering: false,
        //bInfo: null,
        searching: false,
        "bStateSave": true
    });

    var visitorCreationTable = $('#visitor-creation-table').DataTable({
        scrollCollapse: true,
        paging: false,
        info: false,
        ordering: false,
        //bInfo: null,
        searching: false,
        "bStateSave": true
    });

    var visitorRequestTable = $('#approval-table').DataTable({
        scrollCollapse: true,
        paging: false,
        info: false,
        //bInfo: null,
        "bStateSave": true
    });

    var visitorRequestTable = $('#security-table').DataTable({
        scrollCollapse: true,
        paging: false,
        info: false,
        //bInfo: null,
        "bStateSave": true
    });

    var visitorCreationTable = $('#visitor-worker-table').DataTable({
        scrollCollapse: true,
        paging: false,
        info: false,
        ordering: false,
        //bInfo: null,
        searching: false,
        "bStateSave": true
    });

    //Visitor Request
    $("#visitor-creation-btn").on("click", function () {
        var updateVisitorBtn = "<button id='createvisitor-ok' type='button' value='Create' class='btn btn-primary'>Create</button><button id='createvisitor-cancel' type='button' class='btn btn-danger'>Cancel</button>";

        $("#visitor-addupdate-footer").html(updateVisitorBtn);
        $("#visitor-creation-modal").modal("show");
    });

    //Visitor Modal
    $("#visitor-creation-modal").on("click", "#createvisitor-cancel, #updatevisitor-cancel", function (e) {
        let hasValue;
        vistiorHasChanged = false;
        $("#visitor-creation-modal").modal("hide");
        //$("input.visitor-validate").each(function (index, el) {
        //    if (el.value != "") {
        //        hasValue = true;
        //        return false;
        //    }
        //    hasValue = false;
        //});
        //e.preventDefault();
        //if (vistiorHasChanged && hasValue) {
        //    $.confirm({
        //        title: confirmCancel,
        //        content: "Sub-customer input has changed. Do you really want to cancel?",
        //        buttons: {
        //            confirm: {
        //                btnClass: "btn-blue",
        //                action: function () {
        //                    vistiorHasChanged = false;
        //                    $("#visitor-creation-modal").modal("hide");
        //                }
        //            },
        //            cancel: {
        //                btnClass: "btn-red"
        //            }
        //        }
        //    });
        //} else {
        //    vistiorHasChanged = false;
        //    $("#visitor-creation-modal").modal("hide");
        //}
    });

    $("#visitor-creation-modal").on("click", "#createvisitor-ok", function () {
        var url = $("#visitor-creation-modal").data("creationurl");
        var isValid = true;
        //var visitorName = $("#Name").val();
        

        //$(".hiddenVisitorName").val(visitorName);

        if (isValid == true) {
            var visitorIndex = $("div[class*='visitor-panel']").length;
            var postData = $("#visitorFields :input").serialize();

            visitorIndex++;
            $.ajax({
                url: url,
                type: "POST",
                data: postData + "&visitorIndex=" + visitorIndex,
                success: function (partialView) {
                    vistiorHasChanged = false;
                    $("#visitor-creationList").append(partialView);
                    $("#visitor-creation-modal").modal("hide");
                    //$('.collapse.in').collapse("hide");
                }
            })
        }
        else {
            console.log("Required field is not filled-up.");
        }
    });

    $("#visitor-creationList").on("click", ".modify-visitor", function (e) {
        //var parents = $(this).parents();
        //var parentEl = parents[1];
        var index = $(this).data("visitorindex");

        var visitorInfo = $("#hidden-visitor-" + index + " :input").map(function () {
            var type = $(this).prop("type");

            // checked radios/checkboxes
            if ((type == "checkbox" || type == "radio") && this.checked) {
                return $(this).val();
            }
            // all other fields, except buttons
            else if (type != "button" || type != "submit") {
                return $(this).val();
            }

        });

        $("#VisitorId").val(visitorInfo[1]);
        $("#RequestId").val(visitorInfo[2]);
        $("#FirstName").val(visitorInfo[3]);
        $("#MiddleName").val(visitorInfo[4]);
        $("#LastName").val(visitorInfo[5]);
        $("#EmailAddress").val(visitorInfo[6]);
        $("#Occupation").val(visitorInfo[7]);
        $("#CurriculumVitae").val(visitorInfo[8]);
        $("#Index").val(index);
        $("#ForAddition").val("True");

        var updateVisitorBtn = "<button id='updatevisitor-ok' type='button' class='btn btn-primary update-mode'>Update</button><button id='updatevisitor-cancel' type='button' class='btn btn-danger'>Cancel</button>";

        $("#visitor-addupdate-footer").html(updateVisitorBtn);
        $("#visitor-creation-modal").modal("show");

    });

    $("#visitor-creation-modal").on("click", "#updatevisitor-ok", function () {
        var url = $("#visitor-creation-modal").data("posturl");
        var isValid = false;
       
        isValid = true;//$(".subcustomer-validate").valid();
        if (isValid) {
            var index = $("#Index").val();
            var postData = $("#visitorFields :input").serialize();
            $.ajax({
                url: url,
                type: "POST",
                data: postData + "&visitorIndex=" + index,
                success: function (partialView) {
                    //subCustomerHasChanged = false;
                    $("#visitor-data-" + index).replaceWith(partialView)
                    $("#visitor-creation-modal").modal("hide");
                }
            })
        } else {
            console.log("Required visitor fields were blank.");
        }

    });

    $("#visitor-creationList").on("click", ".delete-visitor", function () {
        var index = $(this).data("visitorindex");
        $.confirm({
            title: 'Confirm Deletion',
            content: 'Are you sure you want to delete this item?',
            buttons: {
                confirm: {
                    btnClass: "btn-blue",
                    action: function () {
                        $("#visitor-data-" + index).replaceWith("");
                        $.alert({
                            title: "Info",
                            content: "Visitor is successfully deleted."
                        });
                        //$.info("Visitor is successfully deleted.");
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

    // Enable Disable Checkboxes - Visitor
    $('#visitor-creation-modal').on('show.bs.modal', function (e) {
        vistiorHasChanged = false;
        $(".required-visitor-field").removeAttr("disabled");
        //if ($("#SubCustomerActivityLogReportSettingEnabled").is(":checked")) {
        //    checkBoxRelatedFieldsByClass("#SubCustomerActivityLogReportSettingEnabled", ".subactivitylog-field-activator");
        //}
    });

    $('#visitor-creation-modal').on('hidden.bs.modal', function () {
        if ($(".formError").length) {
            $(".formError").remove();
        }

        $(".required-visitor-field").val("");
        $(".required-visitor-field").attr("disabled", "disabled");
        $("#ForAddition").val("False");
    })

    $('.collapse').collapse();
});
