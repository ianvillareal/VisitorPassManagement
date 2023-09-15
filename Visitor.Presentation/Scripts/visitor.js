$(function () {
    //var arrival = $("#Arrival").attr("value");
    //var leave = $("#Leave").attr("value");
    var arrival = $("#Arrival").attr("value") != "" ?
        moment($("#Arrival").attr("value"), "MMM-DD-YYYY HH:mm:ss", "en") : false;
    var leave = $("#Leave").attr("value") != "" ?
        moment($("#Leave").attr("value"), "MMM-DD-YYYY HH:mm:ss", "en") : false;
    //Approval
    $('#visitor-arrival').datetimepicker({
        format: 'MMM-DD-YYYY HH:mm:ss',
        ignoreReadonly: true,
        showClear: true,
        defaultDate: arrival,
        minDate: arrival,
        keepInvalid: false,
        parseInputDate: parseInputDate,
        useCurrent: false
    });

    $('#visitor-leave').datetimepicker({
        format: 'MMM-DD-YYYY HH:mm:ss',
        ignoreReadonly: true,
        showClear: true,
        defaultDate: leave,
        minDate: arrival,
        keepInvalid: false,
        parseInputDate: parseInputDate,
        useCurrent: false
    });


    // Datetime picker change (from) for search
    $("#visitor-arrival").on("dp.change", function (e) {
        let curDate = e.date != false ? e.date.startOf('day') : false;
        $('#visitor-leave').data("DateTimePicker").minDate(curDate);
    });

    // Datetime picker change (until) for search
    $("#visitor-leave").on("dp.change", function (e) {
        $('#visitor-arrival').data("DateTimePicker").maxDate(e.date);
    });

    $("#visitor-arrival").on("dp.show", function (e) {
        var currentFrom = $(this).val();
        if (currentFrom == "" && $("#Until").val() != "") {
            let untilDate = $("#Until").val()
            $("#visitor-arrival").data("DateTimePicker").defaultDate(untilDate);
        }
    });

    $("#visitor-leave").on("dp.show", function (e) {
        var currentUntil = $(this).val();
        if (currentUntil == "" && $("#From").val() != "") {
            let fromDate = $("#From").val()
            $("#visitor-leave").data("DateTimePicker").defaultDate(fromDate);
        }
    });
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
        //bInfo: null,
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
    
    //$('.visitor-creation-btn').on('click', function () {
    //    visitorCreationTable.row.add([
    //        $('#Visitor_Add').val()
    //    ]).draw(true);
    //});

    //var tableBody = $('.visitor-body');
    //var url = 'AddVisitor'; // adjust to suit
    //$('.visitor-creation-btn').on('click', function () {
    //    $.get(url, function(response) {
    //        //tableBody.append(response);
    //        $('<tr />').html(response).appendTo(tableBody);
    //    });
    //});

    //$('.visitor-creation-btn').on('click', function () {
    //    visitorCreationTable.row.add([
    //        $('#VisitorViewList_Visitor_Add').val()
    //    ]).draw(true);
    //});

});
