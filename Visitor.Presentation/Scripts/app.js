//
// app.js is the global script we use for the website
//
var parseInputDate = function (inputDate) {
	var resultDate;
	if (moment.isMoment(inputDate) || inputDate instanceof Date) {
		resultDate = moment(inputDate);
	}
	else {
        resultDate = moment(inputDate, ["MMM-DD-YYYY HH:mm:ss", "MMM-DD.-YYYY HH:mm:ss"], "en", true);
        //resultDate = moment(inputDate);
       // resultDate.format("MMM-DD-YYYY", "MMM-DD.-YYYY")
	}
	return resultDate;
}

var getUserLanguage = function () {
	console.log("Accept Language: " + acceptLanguage)
	if ((acceptLanguage != "") && (acceptLanguage != undefined)) {
		var userLanguage = acceptLanguage;
	}
	else {
		var userLanguage = navigator.userLanguage;
	}

	return userLanguage;
};

function isIE() {
    ua = navigator.userAgent;
    var is_ie = ua.indexOf("MSIE ") > -1 || ua.indexOf("Trident/") > -1;

    return is_ie;
}

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

function isIE() {
    ua = navigator.userAgent;
    var is_ie = ua.indexOf("MSIE ") > -1 || ua.indexOf("Trident/") > -1;

    return is_ie;
}

// Event listener to activate/deactivate Loading UI on navigation links
document.addEventListener('click', function (e) {
	var target = e.target;
	if (e.which == 1) {
		if (target.className && target.className.toLowerCase() == "nav-link") {
			showLoading();
		} else if (target.dataset.blockui == "true") {
			showLoading();           
		}
	}    
});

// Enable/Disable Field Related to Checkbox
// Use the following function to enable/disabled field by checkbox toggle
// All Element referrer should use Id selector to avoid element mismatch

// Use this function checkBoxRelatedField() to activate enable/disable "SINGLE" field using checkbox using Element Id
function checkBoxRelatedField(checkboxId, targetFieldId) {
	var checkboxIsChecked = false;
	if (targetFieldId.charAt(0) == "#") {
		checkboxIsChecked = $(checkboxId).is(":checked");
		if (checkboxIsChecked) {
			$(targetFieldId).removeAttr("disabled");
		} else {
			$(targetFieldId).attr("disabled", "true");
		}
	} else {
		checkboxIsChecked = $("#" + checkboxId).is(":checked");        
		if (checkboxIsChecked) {
			$("#" + targetFieldId).removeAttr("disabled");
		} else {
			$("#" + targetFieldId).attr("disabled", "true");
		}
	}    
}

// Use this function checkBoxRelatedFieldsByClass() to activate enable/disable "MULTIPLE" field using checkbox using Element Class Name
function checkBoxRelatedFieldsByClass(checkboxId, targetFieldClass) {
	var checkboxIsChecked = false;
	if (checkboxId.charAt(0) == "#") {
		var checkboxIsChecked = $(checkboxId).is(":checked");
	} else {
		var checkboxIsChecked = $("#" + checkboxId).is(":checked");
	}
	
	if (targetFieldClass.charAt(0) == ".") {        
		if (checkboxIsChecked) {
			$(targetFieldClass).removeAttr("disabled");
		} else {
			$(targetFieldClass).attr("disabled", "true");
		}
	} else {
		if (checkboxIsChecked) {
			$("." + targetFieldClass).removeAttr("disabled");
		} else {
			$("." + targetFieldClass).attr("disabled", "true");
		}
	}
}
// end of Enable/Disable Field Related to Checkbox

$.validator.setDefaults({
    onkeyup: false
});

// jQuery Alert

function otErrorAlert(message) {
	var title = $("#localize-message-pool").data("localize-erroralert");
	$.alert({
		title: title,
		content: message
	});
}

function otInfoAlert(message) {
	var title = $("#localize-message-pool").data("localize-infoalert");
	$.alert({
		title: title,
		content: message
	});
}

function otWarningAlert(message) {
	var title = $("#localize-message-pool").data("localize-warningalert");
	$.alert({
		title: title,
		content: message
	});
}

// end of jQuery Alert

// System Message Script
// Bootstrap Notify Documentation: http://bootstrap-notify.remabledesigns.com/
function deactivateSystemMessage() {
    //localStorage.removeItem("systemMessageIsDisplayed");
    sessionStorage.setItem("systemMessageIsDisplayed", "false");
}

function activateSystemMessage() {
    if (!sessionStorage.getItem("systemMessageIsDisplayed") || sessionStorage.getItem("systemMessageIsDisplayed") == "true") {
        sessionStorage.setItem("systemMessageIsDisplayed", "true");
        runSystemMessage();
    }
}

function runSystemMessage() {
    let hostAddress = location.pathname;
    let address = hostAddress.split("/");
    let url = "";

    switch (address.length) {
        case 4: url = "../../Home/GetSystemMessageIfEnabled";
            break;
        case 5: url = "../../../Home/GetSystemMessageIfEnabled";
            break;
        case 6: url = "../../../../Home/GetSystemMessageIfEnabled";
            break;
        default: url = "../Home/GetSystemMessageIfEnabled";
    }

    $.ajax({
        url: url,
        type: "POST",
        success: function (res) {
            let enteredMessage;
            let systemMessage = "";

            if (res[1] != null) {
                enteredMessage = res[1];
                let numberOfLineBreaks = (enteredMessage.match(/\n/g) || []).length;

                if (numberOfLineBreaks > 0) {
                    let enteredMessages = enteredMessage.split("\n");

                    enteredMessages.forEach(function (message) {
                        systemMessage += message + "<br />";
                    });
                } else {
                    systemMessage = enteredMessage;
                }
            }

            if (res[0] === "True") {
                $.notify({
                    icon: 'glyphicon glyphicon-warning-sign',
                    title: " <span class='spo-notify-title'>System Message</span>: ",
                    message: systemMessage
                }, {
                    type: 'danger',
                    placement: {
                        from: "top",
                        align: "center"
                    },
                    delay: 0,
                    offset: 15,
                    z_index: 1031,
                    animate: {
                        enter: 'animated fadeInDown',
                        exit: 'animated fadeOutUp'
                    },
                    onClosed: function () {
                        //console.log("Notification is closed.");
                        //deactivateSystemMessage();
                    },
                    template: '<div data-notify="container" class="col-md-6 smart-notify-style alert alert-{0}" role="alert">' +
		                '<button type="button" aria-hidden="true" class="close" data-notify="dismiss">×</button>' +
		                '<span data-notify="icon"></span> ' +
		                '<span data-notify="title">{1}</span> ' +
		                '<span data-notify="message">{2}</span>' +
	                '</div>'
                });
            }
        },
        error: function (e) {
            console.log("Error on system message AJAX call: " + e.statusText);
        }
    });
}
// end of System Message Script

$(document).ajaxError(function (xhr, props) {
	if (props.status === 401) {
		location.reload();
	}
});

$(function () {
	//showLoadingInElement("inventory-container");    
	showLoading();

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


	$(".date-filter").on("click", function () {
		switch (this.parentElement.id) {
            case "visitor-arrival":
                $('#visitor-arrival').data("DateTimePicker").show();
                break;
            case "visitor-leave":
                $('#visitor-leave').data("DateTimePicker").show();
                break;
		}        
	});
	
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


function setActiveNavMenu(path) {
    let newPath = "";
    removeActiveNavMenu();

    $("li.nav-item").each(function (index, element) {
        if (path == "Items" ||
            path == "Requests" ||
            path == "DeleteItems") {
            newPath = "Inventory";
        } 

        if (element.dataset.pathname == path) {
            $(element).find("a").addClass("active");
            return false;
        //} else if (path == "") {
        //    $(element).find("a").addClass("active");
        //    return false;
        } else if (element.dataset.pathname == newPath) {
            $(element).find("a").addClass("active");
            return false;
        }
    });
}

function removeActiveNavMenu() {
    $("li.nav-item").each(function (index, element) {
        if ($(element).hasClass("active")) {
            $(element).removeClass("active");
        }
    });
}

$(window).on("load", function () {
    let curPathname = window.location.pathname;
    let curPaths = curPathname.split("/");
    let curUrlPath = curPaths[1];

    $.ready.then(function () {
        hideLoading();
        console.log("Hide Block UI from Main Page");
        hideLoadingInElement("inventory-container");
    });

    setActiveNavMenu(curUrlPath);
});