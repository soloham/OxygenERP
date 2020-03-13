// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your Javascript code.
$(document).ready(function () {
    initSettings();
});

function initSettings() {
    initDatePicker();
}

function initDatePicker() {
    $('.DatePicker').datepicker();
    //$('.DatePicker').attr('readonly', 'readonly');
    $('.DatePicker').css('cursor', 'default');

    $('.DatePicker').calendarsPicker({
        yearRange: 'c-40:c+6',
        dateFormat: 'dd-M-yyyy',
    });
    $('.DatePickerHijri').calendarsPicker($.extend({
        calendar: $.calendars.instance('Islamic', 'ar'),
        yearRange: 'c-40:c+6',
        dateFormat: 'dd-m-yyyy',
    }, $.calendarsPicker.regionalOptions['ar']));


    $('.DatePicker,.DatePickerHijri').attr('autocomplete', 'off');

    $('.DatePicker').on("keypress paste", function (e) {
        e.preventDefault();
    })

    console.log("HEYY - " + $('.DatePicker').length)
}

function objectifyForm(formArray) {//serialize data function
    var returnArray = {};
    for (var i = 0; i < formArray.length; i++) {
        var curName = formArray[i]['name'];
        var newObjIndex = curName.indexOf('.');
        if (newObjIndex != -1) {
            var objName = curName.substring(0, newObjIndex);
            var propName = curName.substring(newObjIndex + 1);
            if (returnArray[objName] == null)
                returnArray[objName] = {};
            returnArray[objName][propName] = formArray[i]['value'];
        }
        else
            returnArray[curName] = formArray[i]['value'];
    }
    return returnArray;
}
