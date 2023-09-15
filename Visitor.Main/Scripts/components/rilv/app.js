// Loading UI
var hasBlockUI = false;
// Use this to activate Loading UI to entire page
function showLoading() {
    $.blockUI({
        message: loadingMessage,
        onBlock: function () {
            hasBlockUI = true;
        }
    });
};

// Use this to remove the Loading UI from the entire page
function hideLoading() {
    $.unblockUI();
};

// Use this to activate Loading UI to a selected element / Use element Id for selector
function showLoadingInElement(elementId) {
    if (elementId.charAt(0) != "#") {
        elementId = "#" + elementId;
    }

    $(elementId).block({
        message: loadingMessage
    });
}

// Use this to remove the Loading UI from the selected element / Use element Id for selector
function hideLoadingInElement(elementId) {
    if (elementId.charAt(0) != "#") {
        elementId = "#" + elementId;
    }

    $(elementId).unblock();
}

// Create a specific blockingUI for search Loading screen
function searchShowLoading() {
    $.blockUI({
        message: loadingMessage
    });
    console.log("Block UI for MVC Grid");
};

function searchHideLoading() {
    $.unblockUI();
    console.log("Hide Block UI for MVC Grid")
};
// end of Specific blockingUI for search screen
// end of Loading UI

function goBack() {
    window.history.back()
}


$(function () {
    //showLoadingInElement("inventory-container");    
    //showLoading();

    $("form.submit-disabled").on("submit", function (e) {
        e.preventDefault();
    });

    // Pressing enter triggers the MVCGrid search button 
    $('form.mvcgrid-search input[type=text]').on("keyup", function (e) {
        if (e.keyCode == 13) {
            $('.search-button').click();
        }
    });

    // Back Functionality
    $(".html-backbutton-action").on("click", function () {
        goBack();
    });

    // For Back to top functionality
    $(window).on("scroll", function () {
        if ($(this).scrollTop() > 1000) {
            $('#scroll').fadeIn();
        } else {
            $('#scroll').fadeOut();
        }
    });

    // Dropdown
    $('#scroll').on("click", function () {
        $("html, body").animate({ scrollTop: 0 }, 600);
        return false;
    });

    $('#csv-export-button').click(function () {
        if (!$(this).hasClass("disabled")) {
            var gridName = $(this).data("mvcgrid-name");
            location.href = MVCGrid.getEngineExportUrl(gridName, "customCSV");
        }
    });

    $('#xls-export-button').click(function () {
        if (!$(this).hasClass("disabled")) {
            var gridName = $(this).data("mvcgrid-name");
            location.href = MVCGrid.getEngineExportUrl(gridName, "xls");
        }
    });


    //$(".date-filter").on("click", function () {
    //    switch (this.parentElement.id) {
    //        case "visitor-arrival":
    //            $('#visitor-arrival').data("DateTimePicker").show();
    //            break;
    //        case "visitor-leave":
    //            $('#visitor-leave').data("DateTimePicker").show();
    //            break;
    //    }
    //});

    $(".date-filter").datepicker({
        autoclose: true
    })

    // Setting Active Navigation
    //function setThisTabActive(element) {
    //    var tab = element.getAttribute('href');
    //    if (tab == "/InputFiles" || tab == "/CardsAndPinMailers" || tab == "/PullRequests") {
    //        tab = "/JobTracking";
    //    }
    //    else if (tab == "/ActivityLog" || tab == "/DCSReport") {
    //        tab = "/Monitoring";
    //    }
    //    sessionStorage.setItem("activeTab", tab);
    //}

    function removePreviousTabActive(element) {
        $(element).removeClass("active");
    }

    $(".navbar-brand").on("click", function () {
        removePreviousTabActive(this);
        //setThisTabActive(this);
    });

    $(".nav-link").on("click", function () {
        removePreviousTabActive(this);
        //setThisTabActive(this);
    });

    //activateSystemMessage(true);

    $('.tooltip-wrapper').tooltip({
        'position': 'top'
    });

    $('tooltip').tooltip({
        'position': 'top'
    });
});

