
// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.
//const deepCopy = require('../../libs/rfdc')() // Returns the deep copy function

// Write your Javascript code.

$(document).ready(function () {
    initSettings(); 

    let options = {
        buttonWidth: '100%',
        includeSelectAllOption: true,
        enableFiltering: false,
        enableClickableOptGroups: true,
        includeResetOption: true,
        includeResetDivider: true,
        enableCollapsibleOptGroups: true
    };
    $.each($('.mltslct'), function (i, x) { $(x).multiselect(options); });
});
Array.prototype.removeIf = function (callback) {
    var i = this.length;
    while (i--) {
        if (callback(this[i], i)) {
            this.splice(i, 1);
        }
    }
};
Date.prototype.addDays = function (days) {
    var date = new Date(this.valueOf());
    date.setDate(date.getDate() + days);
    return date;
}
Date.prototype.getMonthName = function (month) {
    var months = ["January", "February", "March", "April", "May", "June",
        "July", "August", "September", "October", "November", "December"];

    return months[month-1];
}
Object.byString = function (o, s) {
    s = s.replace(/\[(\w+)\]/g, '.$1'); // convert indexes to properties
    s = s.replace(/^\./, '');           // strip a leading dot
    var a = s.split('.');
    for (var i = 0, n = a.length; i < n; ++i) {
        var k = a[i];
        if (o == null)
            continue;
        if (k in o) {
            o = o[k];
        } else {
            return;
        }
    }
    return o;ml
}
function newDefaultCommandClick(gridObj, args) {
    if (args.commandColumn.type == "View") {
        let params = args.rowData;
        console.log(params);
        //gridObj.detailRowModule.collapseAll();
        console.log(args.rowData.id);
        let rI = gridObj.getRowsObject().filter(function (x) { return typeof x.data !== 'undefined' && x.data.id == params.id })[0].index; /*params.id - 1*/;
        console.log(rI);
        gridObj.detailRowModule.expand(rI);

        fillDetailForm(params, false);
    }
    if (args.commandColumn.type == "Edit") {
        let params = args.rowData;
        console.log(params);
        //gridObj.detailRowModule.collapseAll();
        console.log(args.rowData.id);
        let rI = gridObj.getRowsObject().filter(function (x) { return typeof x.data !== 'undefined' && x.data.id == params.id })[0].index; /*params.id - 1*/;
        console.log(rI);
        gridObj.detailRowModule.expand(rI);

        fillDetailForm(params, true);
    }
    else if (args.commandColumn.type == "Copy") {
        this.copy(false);
    }

    setTimeout(function () { gridObj.hideSpinner() }, 200);

}
function toggleAreaFormBtn(formId, state)
{
    var btn = $($('#' + formId).prev().find('.areaHeaderBtn'));
    var btnSec = btn.closest('.areaHeaderBtnSec');
    const areaHeader = btn.closest('.areaHeader');
    var form = $(areaHeader).next('.areaForm');

    let btnTxt = $(btn).text();
    if (state) {
        $(form).slideDown(150);
        if (btnTxt != 'Cancel') {
            $(btnSec).slideUp(150);
            setTimeout(function () { $(btn).html('<i class="fa fa-arrow-up p-r-5"></i> Cancel') }, 200)
            $(btnSec).slideDown(150);
        }
    } else {
        $(form).slideUp(150);
        if (btnTxt == 'Add New') {
            $(btnSec).slideUp(150);
            setTimeout(function () { $(btn).html('<i class="fa fa-plus p-r-5"></i> Add New') }, 200)
            $(btnSec).slideDown(150);
        }
    }
}

function areaHeaderBtnClick(e) {
    var btn = e.target.closest('.areaHeaderBtn');
    var btnSec = e.target.closest('.areaHeaderBtnSec');
    const areaHeader = e.target.closest('.areaHeader');
    var form = $(areaHeader).next('.areaForm');
    var isCollapsed = form.css('display') == 'none';

    if (isCollapsed) {
        ClearForm(form);
        $(btnSec).slideUp(200);
        $(form).slideDown(200);
        setTimeout(function () { $(btn).html('<i class="fa fa-arrow-up p-r-5"></i> Cancel') }, 200)
        $(btnSec).slideDown(200);

    } else {    
        $(btnSec).slideUp(200);
        $(form).slideUp(200);
        setTimeout(function () { $(btn).html('<i class="fa fa-plus p-r-5"></i> Add New') }, 200)
        $(btnSec).slideDown(200);
    }
}

// Returns mathematic mod, not javascript mod
// e.g. gmod(-3, 2) returns 1, whereas -3%2 returns -1
function gmod(n, m) {
    return ((n % m) + m) % m;
}

/* @param {Date}   date   - optional, default is today
** @param {number} adjust - optiona, days to adjust date by
*/
function kuwaiticalendar(date, adjust) {
    var today = date ? new Date(+date) : new Date();
    if (adjust) {
        today.setDate(today.getDate() + +adjust);
    }

    var day = today.getDate();
    var month = today.getMonth();
    var year = today.getFullYear();
    var m = month + 1;
    var y = year;

    if (m < 3) {
        y -= 1;
        m += 12;
    }

    var a = Math.floor(y / 100);
    var b = 2 - a + Math.floor(a / 4);

    if (y < 1583) b = 0;
    if (y == 1582) {
        if (m > 10) b = -10;
        if (m == 10) {
            b = 0;
            if (day > 4) b = -10;
        }
    }

    var jd = Math.floor(365.25 * (y + 4716)) + Math.floor(30.6001 * (m + 1)) + day + b - 1524;

    b = 0;
    if (jd > 2299160) {
        a = Math.floor((jd - 1867216.25) / 36524.25);
        b = 1 + a - Math.floor(a / 4);
    }

    var bb = jd + b + 1524;
    var cc = Math.floor((bb - 122.1) / 365.25);
    var dd = Math.floor(365.25 * cc);
    var ee = Math.floor((bb - dd) / 30.6001);
    day = (bb - dd) - Math.floor(30.6001 * ee);
    month = ee - 1;

    if (ee > 13) {
        cc += 1;
        month = ee - 13;
    }
    year = cc - 4716;
    var wd = gmod(jd + 1, 7) + 1;

    var iyear = 10631. / 30.;
    var epochastro = 1948084;
    var epochcivil = 1948085;

    var shift1 = 8.01 / 60.;

    var z = jd - epochastro;
    var cyc = Math.floor(z / 10631.);
    z = z - 10631 * cyc;
    var j = Math.floor((z - shift1) / iyear);
    var iy = 30 * cyc + j;
    z = z - Math.floor(j * iyear + shift1);
    var im = Math.floor((z + 28.5001) / 29.5);

    if (im == 13) im = 12;
    var id = z - Math.floor(29.5001 * im - 29);

    return [
        day,       //calculated day (CE)
        month - 1, //calculated month (CE)
        year,      //calculated year (CE)
        jd - 1,    //julian day number
        wd - 1,    //weekday number
        id,        //islamic date
        im - 1,    //islamic month
        iy         //islamic year
    ];
}

function dataBoundResponsive() {
    var visCount = 0;
    for (var i = 0; i < this.columns.length; i++) {
        if (this.columns[i].visible) visCount++;
    }
    if (visCount == this.columns.length) {
        for (var i = 0; i < this.columns.length; i++) {
            var col = this.columns[i];
            if (typeof col.customAttributes != 'undefined' && typeof col.customAttributes.id != 'undefined' && col.customAttributes.id == 'detailed')
                this.showHider.hide(col.headerText, 'headerText');
            else
                this.showHider.show(col.headerText, 'headerText');
        }
    }
    if (screen.width <= 600)
        this.autoFitColumns();
}

function writeIslamicDate(date, adjustment) {
    var wdNames = ["Ahad", "Ithnin", "Thulatha", "Arbaa", "Khams", "Jumuah", "Sabt"];
    var iMonthNames = ["Muharram", "Safar", "Rabi'ul Awwal", "Rabi'ul Akhir", "Jumadal Ula", "Jumadal Akhira",
        "Rajab", "Sha'ban", "Ramadan", "Shawwal", "Dhul Qa'ada", "Dhul Hijja"];
    var iDate = kuwaiticalendar(date, adjustment);
    var outputIslamicDate = wdNames[iDate[4]] + ", " + iDate[5] + " " +
        iMonthNames[iDate[6]] + " " + iDate[7] + " AH";
    return outputIslamicDate;
}

function initSettings() {
    $('.navbar-toggler').on('click', function () {
        let hB = $('#header-brand');
        if (hB.attr('src') != '/img/logos/OxygenERPLogo.png') {
            hB.attr('src', '/img/logos/OxygenERPLogo.png');

            hB.animate({ height: '113%' }, 500);
        }
        else {
            hB.animate({ height: '100%' }, 300);
            hB.attr('src', '/img/logos/OxygenERP 2.3.png');
        }
    });
    Date.prototype.getWeekOfMonth = function (exact) {
        var month = this.getMonth()
            , year = this.getFullYear()
            , firstWeekday = new Date(year, month, 1).getDay()
            , lastDateOfMonth = new Date(year, month + 1, 0).getDate()
            , offsetDate = this.getDate() + firstWeekday - 1
            , index = 1 // start index at 0 or 1, your choice
            , weeksInMonth = index + Math.ceil((lastDateOfMonth + firstWeekday - 7) / 7)
            , week = index + Math.floor(offsetDate / 7)
            ;
        if (exact || week < 2 + index) return week;
        return week === weeksInMonth ? index + 5 : week;
    };
    Date.prototype.getWeek = function () {
        return $.datepicker.iso8601Week(this);
    }
    $(".DatePicker").on('change', function () {
        $(this).parent().parent().siblings().find(".DatePickerHijri").val(writeIslamicDate(new Date($(this).val()), 0));
    });
    //initDatePicker();


    toastr.options = {
        "closeButton": false,
        "debug": false,
        "newestOnTop": false,
        "progressBar": false,
        "positionClass": "toast-bottom-right",
        "preventDuplicates": false,
        "onclick": null,
        "showDuration": "300",
        "hideDuration": "1000",
        "timeOut": "5000",
        "extendedTimeOut": "1000",
        "showEasing": "swing",
        "hideEasing": "linear",
        "showMethod": "fadeIn",
        "hideMethod": "fadeOut"
    }
    //toastr.options.positionClass = 'toast-bottom-right';
    toastr.options.closeButton = true;
        
    toastr.options.showEasing = 'swing';
    toastr.options.hideEasing = 'linear';
    toastr.options.closeEasing = 'linear';

    toastr.options.showMethod = 'slideDown';
    toastr.options.hideMethod = 'slideUp';
    toastr.options.closeMethod = 'slideUp';

    toastr.options.progressBar = true;
}

function initDatePicker() {
    $('.DatePicker').datepicker();
    //$('.DatePicker').attr('readonly', 'readonly');
    $('.DatePicker').css('cursor', 'default');

    $('.DatePicker').calendarsPicker({
        yearRange: 'c-40:c+6',
        dateFormat: 'dd-M-yyyy',
    });


    $('.DatePicker,.DatePickerHijri').attr('autocomplete', 'off');

    $('.DatePicker').on("keypress paste", function (e) {
        e.preventDefault();
    })

    $('.DatePickerHijri').calendarsPicker($.extend({
        calendar: $.calendars.instance('Islamic', 'ar'),
        yearRange: 'c-40:c+6',
        dateFormat: 'dd-m-yyyy',
    }, $.calendarsPicker.regionalOptions['ar']));
}

function objectifyForm(formArray) {
    //serialize data function
    var returnArray = {};
    console.log(formArray);
    for (var i = 0; i < formArray.length; i++) {
        var curName = formArray[i]['name'];
        var newObjIndex = curName.indexOf('.');
        if (newObjIndex != -1) {
            var objName = curName.substring(0, newObjIndex);
            var propName = curName.substring(newObjIndex + 1);
            if (returnArray[objName] == null)
                returnArray[objName] = {};
            returnArray[objName][propName] = (propName.includes('Is') || propName.includes('Has') || curName.includes('Allow')) && (formArray[i]['value'] == 'on' || formArray[i]['value'] == 'off')? formArray[i]['value'] == 'on' : formArray[i]['value'];
        }
        else
            returnArray[curName] = (curName.includes('Is') || curName.includes('Has') || curName.includes('Allow')) && (formArray[i]['value'] == 'on' || formArray[i]['value'] == 'off')? formArray[i]['value'] == 'on' : formArray[i]['value'];
    }
    return returnArray;
}
function array_move(arr, old_index, new_index) {
    while (old_index < 0) {
        old_index += arr.length;
    }
    while (new_index < 0) {
        new_index += arr.length;
    }
    if (new_index >= arr.length) {
        var k = new_index - arr.length + 1;
        while (k--) {
            arr.push(undefined);
        }
    }
    arr.splice(new_index, 0, arr.splice(old_index, 1)[0]);
    return arr; // for testing purposes
};

const ValueTypeModules = {
    Country: 0,
    Gender: 1,
    MaritalStatus: 2,
    BloodGroup: 3,
    Religion: 4,
    IDType: 5,
    CashflowStatementType: 6,
    ContractType: 7,
    ContractStatus: 8,
    EmployeeStatus: 9,
    Bank: 10,
    Relationship: 11,
    Degree: 12,
    AcademicInstitution: 13,
    AllowanceType: 14,
    OwnerType: 15,
    DocumentType: 16,
    ServiceCategory: 17,
    ServiceLineChargeables: 18,
    ServiceLineNonChargeables: 19,
    ServiceLineAdmins: 20,
    Clients: 21,
    EmployeeType: 22,
    IndemnityType: 23,
    SocialInsuranceType: 24,
    LeaveType: 25,
    HolidayType: 26,
    LoanType: 27,
    CompanyDocumentType: 28,
    CostCenter: 29,
    OrganizationPositionType: 30,
    OrganizationPositionStatus: 31,
    OrganizationPositionJobLevels: 32,
    OrganizationPositionJobEmployeeClasses: 33,
    OrganizationPositionJobContractTypes: 34,
    EmailType: 35,
    PhoneType: 36,
    AddressType: 37,
    EducationCertificate: 38,
    TrainingCertificate: 39,
    TypeISkill: 40,
    TypeIISkill: 41,
    Timezone: 42,
    Salutation: 43,
    EmploymentType: 44,
    EmployeeGroup: 45,
    EmployeeSubGroup: 46,
    Languages: 47
}

function SelectDepartmentPositions(departmentsElmId, positionsElmId, departmentsArr, positionsArr, isEditing, isEditingLoaded, toSelectPositions) {
    $(`#${positionsElmId}`).multiselect('dataprovider', null);
    $(`#${positionsElmId}`).change();
    var departmentIds = $('#' + departmentsElmId).val();
    if (departmentIds.length == 0) return; 
    $.ajax({
        type: "GET",
        url: '?handler=DepartmentsPositions',
        data: { departmentIds: JSON.stringify(departmentIds) },
        success: function (data) {
            var dataMS = [];
            var positions = []; 
            $.each(departmentIds, function (i, departmentId) {
                $.each(data, function (j, position) {
                    if (position.departmentId == departmentId)
                        positions.push({ label: position.title, value: position.id });
                });
                dataMS.push({
                    label: $(`#${departmentsElmId} option[value='${departmentId}']`).text(), children: positions
                });
            });

            Object.assign(positionsArr, positions);
            Object.assign(departmentsArr, dataMS);

            $(`#${positionsElmId}`).multiselect('dataprovider', dataMS);

            if (isEditing && !isEditingLoaded) {
                $(`#${positionsElmId}`).multiselect('select', toSelectPositions);
                $(`#${positionsElmId}`).change();

                Object.assign(isEditingLoaded, true);
            }

        }
    });
}

function SelectPositionEmployees(positionsElmId, employeesElmId, positionsArr, employeesArr, isEditing, isEditingLoaded, toSelectEmployees) {
    var positionIds = $(`#${positionsElmId}`).val();
    var positions = positionsArr;
    $(`#${employeesElmId}`).multiselect('dataprovider', null);
    Object.assign(employeesArr, []);
    if (positionIds.length == 0) return;

    $.ajax({
        type: "GET",
        url: '?handler=Employees',
        data: { positionIds: JSON.stringify(positionIds) },
        success: function (data) {
            var positionEmployees = [];

            $.each(positionIds, function (i, positionId) {
                var position = positions.find(function (x) { return x.value == positionId });
                var employees = [];
                $.each(data, function (j, employee) {
                    if (employee.posId == positionId) {
                        var emp = { id: employee.id, value: employee.id, name: employee.name, label: employee.name, departmentId: employee.depId, depName: employee.depName, positionId: employee.posId, posName: employee.posTitle };
                        employees.push(emp);
                        employeesArr.push(emp);
                    }
                });
                positionEmployees.push({ label: position.label, children: employees })
            });
            $(`#${employeesElmId}`).multiselect('dataprovider', positionEmployees);

            console.log(isEditing);
            console.log(isEditingLoaded);
            console.log(toSelectEmployees);
            if (isEditing && !isEditingLoaded) {
                $(`#${employeesElmId}`).multiselect('select', toSelectEmployees);
                $(`#${employeesElmId}`).change();

                Object.assign(isEditingLoaded, true);
            }
        }
    });
}

function ValidateFormByQuery(query) {
    var elmForm = $(query);
    // stepDirection === 'forward' :- this condition allows to do the form validation
    // only on forward navigation, that makes easy navigation on backwards still do the validation when going next
    var valid = false;
    for (var i = 0; i < elmForm.length; i++) {
        let form = elmForm[i];
        if (form) {
            $(form).validator('validate');
            var elmErr = $(form).find('.has-error');
            if (elmErr) {
                if (elmErr.length > 0) {
                    // Form validation failed
                    valid = false;
                    return valid;
                }
                else {
                    valid = true;
                }
            }
        }
    }
    return valid;
}
function ValidateForm(formId) {
    var elmForm = $(`#${formId}`);
    // stepDirection === 'forward' :- this condition allows to do the form validation
    // only on forward navigation, that makes easy navigation on backwards still do the validation when going next
    var valid = false;
    if (elmForm) {
        elmForm.validator('validate');
        var elmErr = elmForm.find('.has-error');
        if (elmErr) {
            if (elmErr.length > 0) {
                // Form validation failed
                valid = false;
            }
            else {
                valid = true;
            }
        }
    }
    return valid;
}

function FillFormByObject(obj, form) {
    let props = Object.keys(obj);
    let formObjs = $(`#${form[0].id} :input`);
    try {
        for (var i = 0; i < formObjs.length; i++) {
            let elm = formObjs[i];
            let type = elm.type;
            let propName = props.filter(function (x) { return x.toLowerCase() == elm.name.toLowerCase(); });
            if (type == 'select-multiple') {
                let melm = $('#' + elm.id);
                if ($(melm).parent()[0].id.includes('multiselect') || $(melm).parent()[0].className.includes('multiselect')) {
                    $(melm).multiselect('deselectAll', false);
                    $(melm).multiselect('refresh');
                    $(melm).multiselect('select', obj[propName]);
                    $(melm).change();
                }
            }
            else if (type == 'select-one') {
                let melm = $('#' + elm.id);
                if ($(melm).parent()[0].id.includes('multiselect') || $(melm).parent()[0].className.includes('multiselect')) {
                    $(melm).multiselect('deselectAll', false);
                    $(melm).multiselect('refresh');
                    $(melm).change();
                }
                else
                    $(melm).val(obj[propName]);
            }
            else if (type == 'checkbox') {
                let melm = $('#' + elm.id);
                $(melm)[0].checked = (obj[propName] != true || obj[propName] == false) ? obj[propName] == 'on' ? true : false : obj[propName];
            }
        }
    } catch (ex) {

    }
    for (var i = 0; i < formObjs.length; i++) {
        let elm = formObjs[i];
        let type = elm.type;
        let propName = props.filter(function (x) { return x.toLowerCase() == elm.name.toLowerCase(); });
        if (propName != '') {

            if (type == 'date') {
                let val = new Date(obj[propName]);
                let month = ('0' + (val.getMonth() + 1)).slice(-2);
                let date = ('0' + (val.getDate())).slice(-2);
                let dateVal = `${val.getUTCFullYear()}-${month}-${date}`;
                console.log(dateVal.toString());
                elm.value = dateVal.toString();
                console.log(elm.value);
            }
            else if (type == 'select-one') {
                let melm = $('#' + elm.id);
                //console.log(melm);
                if ($(melm).parent()[0].id.includes('multiselect') || $(melm).parent()[0].className.includes('multiselect')) {
                    $(melm).multiselect('deselectAll', false);
                    $(melm).multiselect('refresh');
                    $(melm).multiselect('select', obj[propName]);
                    $(melm).change();
                }
                else
                    $(melm).val(obj[propName]);
            }
            else if (type == 'select-multiple') {
                let melm = $('#' + elm.id);
                if ($(melm).parent()[0].id.includes('multiselect') || $(melm).parent()[0].className.includes('multiselect')) {
                    console.log(elm.name);
                    $(melm).multiselect('deselectAll', false);
                    $(melm).multiselect('refresh');
                    $(melm).multiselect('select', obj[propName]);
                    $(melm).change();
                }
            }
            else if (type == 'checkbox') {
                let melm = $('#' + elm.id);
                $(melm)[0].checked = (obj[propName] != true || obj[propName] == false) ? obj[propName] == 'on' ? true : false : obj[propName];
            }
            else {
                try {
                    elm.value = obj[propName];
                }
                catch{

                }
            }
        }
    }
}
function modifyObject(obj, newObj) {

    Object.keys(obj).forEach(function (key) {
        delete obj[key];
    });

    Object.keys(newObj).forEach(function (key) {
        obj[key] = newObj[key];
    });

}
function FillDivFormByObject(obj, elements, isReadonly = false) {
    let props = Object.keys(obj);
    for (var i = 0; i < elements.length; i++) {
        let elm = elements[i];
        let type = elm.type;
        if (type == 'button' || type == 'submit')
            continue;
        let propName = props.filter(function (x) { return x.toLowerCase() == elm.name.toLowerCase(); });
        if (isReadonly) {
            $(elm).attr('readonly', 'readonly')
        }
        else {
            $(elm).attr('disabled', false)
            $(elm).removeAttr('readonly')
        }
        if (propName != '') {
            if (type == 'date') {
                let val = new Date(obj[propName]);
                let month = ('0' + (val.getMonth() + 1)).slice(-2);
                let date = ('0' + (val.getDate())).slice(-2);
                let dateVal = `${val.getUTCFullYear()}-${month}-${date}`;
                console.log(dateVal.toString());
                elm.value = dateVal.toString();
                console.log(elm.value);
            }
            else if (type == 'checkbox') {
                $(elm)[0].checked = (obj[propName] != true || obj[propName] == false) ? obj[propName] == 'on' ? true : false : obj[propName];
                if (isReadonly) {
                    $(elm).attr('disabled', true)
                }
                else {
                    $(elm).attr('disabled', false)
                }
            }
            else if (type == 'select-multiple') {
                let melm = $('#' + elm.id);
                if ($(melm).parent()[0].id.includes('multiselect') || $(melm).parent()[0].className.includes('multiselect')) {
                    $(melm).multiselect('deselectAll', false);
                    $(melm).multiselect('refresh');
                    $(melm).multiselect('select', obj[propName]);
                    $(melm).change();
                    if (isReadonly) {
                        setTimeout(function (x) {
                            $(melm).multiselect('disable');
                        }, 1000);
                    }
                    else {
                        setTimeout(function (x) {
                            $(melm).multiselect('enable');
                        }, 1000);
                    }
                }
            }
            else if (type == 'select-one') {
                console.log(elm.id);
                let melm = $('#' + elm.id, $(elm).parent()[0]);
                //console.log(melm);
                if ($(melm).parent()[0].id.includes('multiselect') || $(melm).parent()[0].className.includes('multiselect')) {
                    $(melm).multiselect('deselectAll', false);
                    //$(melm).multiselect('reset');
                    console.log(obj[propName]);
                    setTimeout(function () {
                        $(melm).multiselect('select', obj[propName]);
                    }, 1000);
                    $(melm).change();
                    if (isReadonly) {
                        setTimeout(function (x) {
                            $(melm).multiselect('disable');
                        }, 1000);
                    }
                    else {
                        setTimeout(function (x) {
                            $(melm).multiselect('enable');
                        }, 1000);
                    }
                }
                else {
                    $(melm).val(obj[propName]);
                }
            }
            else {
                elm.value = obj[propName];
            }
        }
        else {
            if (type == 'date') {
                //let val = new Date();
                //let month = ('0' + (val.getMonth() + 1)).slice(-2);
                //let date = ('0' + (val.getDate())).slice(-2);
                //let dateVal = `${val.getUTCFullYear()}-${month}-${date}`;
                elm.value = '';
                console.log(elm.value);
            }
            else if (type == 'checkbox') {
                $(elm)[0].checked = false;
            }
            else if (type == 'select-multiple') {
                let melm = $('#' + elm.id);
                if ($(melm).parent()[0].id.includes('multiselect') || $(melm).parent()[0].className.includes('multiselect')) {
                    $(melm).multiselect('deselectAll', false);
                    $(melm).multiselect('refresh');
                    $(melm).change();
                    if (isReadonly) {
                        setTimeout(function (x) {
                            $(melm).multiselect('disable');
                        }, 1000);
                    }
                    else {
                        setTimeout(function (x) {
                            $(melm).multiselect('enable');
                        }, 1000);
                    }
                }
            }
            else if (type == 'select-one') {
                let melm = $('#' + elm.id, $(elm).parent()[0]);
                //console.log(melm);
                if ($(melm).parent()[0].id.includes('multiselect') || $(melm).parent()[0].className.includes('multiselect')) {
                    $(melm).multiselect('deselectAll', false);
                    //$(melm).multiselect('reset');
                    $(melm).change();
                    if (isReadonly) {
                        setTimeout(function (x) {
                            $(melm).multiselect('disable');
                        }, 1000);
                    }
                    else {
                        setTimeout(function (x) {
                            $(melm).multiselect('enable');
                        }, 1000);
                    }
                }
                else
                    $(melm).val('');
            }
            else
                elm.value = '';
        }
    }
}
function ClearForm(form) {

    if (typeof form[0].length === 'undefined') {
        let selection = `#${form[0].id} :input`;
        ClearDivForm($(selection));
        return;
    }
    let grids = $(`*[role="grid"]`, `#${form[0].id}`);
    if (grids.length > 0) {
        for (var y = 0; y < grids.length; y++)
        {
            try {
                let grid = $(`#${grids[y].id.toString()}`)[0].ej2_instances[0];

                grid.dataSource = [];
                grid.refresh();
                setTimeout(function () { grid.hideSpinner(); }, 200);
            } catch (e) {

            }
        }
    }
    for (var i = 0; i < form[0].length; i++) {
        let type = form[0][i].type;
        if (type != 'submit' && type != 'button' && type != 'select-one' && type != 'select-multiple' && type != 'checkbox')
            form[0][i].value = '';
        else if (type == 'select-one') {
            return;
            try {
                let melm = $('#' + form[0][i].id);
                if ($(melm).parent()[0].id.includes('multiselect') || $(melm).parent()[0].className.includes('multiselect')) {
                    $(melm).multiselect('deselectAll', false);
                    $(melm).multiselect('refresh');
                }
            } catch (e) {

            }
        }
        else if (type == 'select-multiple') {
            try {
                let melm = $('#' + form[0][i].id);
                if ($(melm).parent()[0].id.includes('multiselect') || $(melm).parent()[0].className.includes('multiselect')) {
                    $(melm).multiselect('deselectAll', false);
                    $(melm).multiselect('refresh');
                }
            } catch (e) {

            }
        }
    }
    //let grids = $(`*[id*="Grid"]`, form);
    //for (var i = 0; i < grids.length; i++) {

    //}
}
function ClearDivForm(elements) {
    for (var i = 0; i < elements.length; i++) {
        let elm = elements[i];
        let type = elm.type;
        let role = elm.role;
        if (role == 'grid') {
            console.log(role);
            try {
                let grid = $(`#${elm.id}`)[0].ej2_instances[0];

                grid.dataSource = [];
                grid.refresh();
                setTimeout(function () { grid.hideSpinner(); }, 200);
            } catch (e) {

            }
        }
        else if (type != 'submit' && type != 'button' && type != 'select-one' && type != 'select-multiple' && type != 'checkbox') {
            elm.value = '';
        }
        else if (type == 'select-one') {
            try {
                let melm = $('#' + elm.id);
                if ($(melm).parent().id.includes('multiselect')) {
                    console.log(melm.id);
                    melm.multiselect('refresh');
                }
            } catch (e) {

            }
        }
    }
}
function camelCase(str) {
    return str.replace(/(?:^\w|[A-Z]|\b\w)/g, function (word, index) {
        return index == 0 ? word.toLowerCase() : word.toUpperCase();
    }).replace(/\s+/g, '');
} 

function defaultToolbarClick(args) {
    let gridObj = this;
    let id = this.element.id;

    if (args.item.id === `${id}_pdfexport`) {
        gridObj.pdfExport();
    }
    if (args.item.id === `${id}_excelexport`) {
        gridObj.excelExport();
    }
    if (args.item.id === `${id}_csvexport`) {
        gridObj.csvExport();
    }
    if (this.getSelectedRecords().length > 0) {
        let withHeader = false;
        if (args.item.id === 'copyHeader') {
            withHeader = true;
        }
        this.copy(withHeader);
    }
    else {
        if (args.item.id === 'copyHeader') {
            let dialogObj = document.getElementById('alert_dialog').ej2_instances[0];
            dialogObj.show();
        }
        else if (args.item.id === 'copy') {
            let dialogObj = document.getElementById('alert_dialog_1').ej2_instances[0];
            dialogObj.show();
        }
    }
    if (args.item.id === 'showActions') {
        gridObj.toolbar = [{ text: "Hide Actions", tooltipText: "Actions", prefixIcon: "e-custom-hide-actions", id: "hideActions" }, { text: "Toggle Grouping", tooltipText: "Grouping", prefixIcon: "e-custom-group-toggle", id: "toggleGrouping" }, { text: "Toggle Detailed", tooltipText: "Toggle Detailed", prefixIcon: "e-toggledetailed", id: "toggleDetailed" }, { text: "ExcelExport", tooltipText: "Excel Export", prefixIcon: "e-excelexport", id: this.element.id + "_excelexport", align: 'Right' }, { text: this.element.id + "_PdfExport", tooltipText: "Pdf Export", prefixIcon: "e-pdfexport", id: "pdfexport", align: 'Right' }, { text: "CsvExport", tooltipText: "Csv Export", prefixIcon: "e-csvexport", id: this.element.id + "_csvexport", align: 'Right' }, { text: "Print", tooltipText: "Print", prefixIcon: "e-print", id: this.element.id + "_print", align: 'Right' },, "Search", { text: "Copy", tooltipText: "Copy", prefixIcon: "e-copy", id: "copy" }, "Search", { text: "Copy With Header", tooltipText: "Copy With Header", prefixIcon: "e-copy", id: "copyHeader" }, "ColumnChooser"];
        gridObj.refresh();
    }
    if (args.item.id === 'hideActions') {
        gridObj.toolbar = [{ text: "Show Actions", tooltipText: "Actions", prefixIcon: "e-custom-show-actions", id: "showActions" }, "Search", "ColumnChooser"];
        gridObj.showColumnChooser = true;
        gridObj.refresh();
    }
    if (args.item.id === 'toggleGrouping') {
        gridObj.allowGrouping = !gridObj.allowGrouping;
        gridObj.refresh();
    }
    if (args.item.id === 'toggleDetailed') {
        let visCount = 0;
        for (let i = 0; i < gridObj.columns.length; i++) {
            if (gridObj.columns[i].visible) visCount++;
        }
        if (visCount == gridObj.columns.length) {
            for (let i = 0; i < gridObj.columns.length; i++) {
                let col = gridObj.columns[i];
                if (typeof col.customAttributes != 'undefined' && typeof col.customAttributes.id != 'undefined' && col.customAttributes.id == 'detailed')
                    gridObj.showHider.hide(col.headerText, 'headerText');
                else if (col.showInColumnChooser)
                    gridObj.showHider.show(col.headerText, 'headerText');
            }
        }
        else {
            for (let i = 0; i < gridObj.columns.length; i++) {
                let col = gridObj.columns[i];
                if (col.showInColumnChooser)
                    gridObj.showHider.show(col.headerText, 'headerText');
            }
        }
    }
    if (args.item.id === 'toggleaudittrail') {

    }
    if (args.item.id === 'togglesearch') {
        gridObj.toolbarModule.enableItems([`${id}_Search`], true);
    }
    setTimeout(function () { gridObj.hideSpinner() }, 200);
}
function defaultCrudToolbarClick(args) {
    let gridObj = this;
    let id = this.element.id;

    if (args.item.id === `${id}_pdfexport`) {
        gridObj.pdfExport();
    }
    if (args.item.id === `${id}_excelexport`) {
        gridObj.excelExport();
    }
    if (args.item.id === `${id}_csvexport`) {
        gridObj.csvExport();
    }
    if (this.getSelectedRecords().length > 0) {
        let withHeader = false;
        if (args.item.id === 'copyHeader') {
            withHeader = true;
        }
        this.copy(withHeader);
    }
    else {
        if (args.item.id === 'copyHeader') {
            let dialogObj = document.getElementById('alert_dialog').ej2_instances[0];
            dialogObj.show();
        }
        else if (args.item.id === 'copy') {
            let dialogObj = document.getElementById('alert_dialog_1').ej2_instances[0];
            dialogObj.show();
        }
    }
    if (args.item.id === 'showActions') {
        gridObj.toolbar = [{ text: "Hide Actions", tooltipText: "Actions", prefixIcon: "e-custom-hide-actions", id: "hideActions" }, "Add", "Delete", { text: "Toggle Grouping", tooltipText: "Grouping", prefixIcon: "e-custom-group-toggle", id: "toggleGrouping" }, { text: "Toggle Detailed", tooltipText: "Toggle Detailed", prefixIcon: "e-toggledetailed", id: "toggleDetailed" }, { text: "ExcelExport", tooltipText: "Excel Export", prefixIcon: "e-excelexport", id: this.element.id + "_excelexport", align: 'Right' }, { text: this.element.id + "_PdfExport", tooltipText: "Pdf Export", prefixIcon: "e-pdfexport", id: "pdfexport", align: 'Right' }, { text: "CsvExport", tooltipText: "Csv Export", prefixIcon: "e-csvexport", id: this.element.id + "_csvexport", align: 'Right' }, { text: "Print", tooltipText: "Print", prefixIcon: "e-print", id: this.element.id + "_print", align: 'Right' }, { text: "Copy", tooltipText: "Copy", prefixIcon: "e-copy", id: "copy" }, "Search", { text: "Copy With Header", tooltipText: "Copy With Header", prefixIcon: "e-copy", id: "copyHeader" }, "ColumnChooser"];
        gridObj.refresh();
    }
    if (args.item.id === 'hideActions') {
        gridObj.toolbar = [{ text: "Show Actions", tooltipText: "Actions", prefixIcon: "e-custom-show-actions", id: "showActions" }, "Add", "Delete", "Search", "ColumnChooser"];
        gridObj.showColumnChooser = true;
        gridObj.refresh();
    }
    if (args.item.id === 'toggleGrouping') {
        gridObj.allowGrouping = !gridObj.allowGrouping;
        gridObj.refresh();
    }
    if (args.item.id === 'toggleDetailed') {
        let visCount = 0;
        for (let i = 0; i < gridObj.columns.length; i++) {
            if (gridObj.columns[i].visible) visCount++;
        }
        if (visCount == gridObj.columns.length) {
            for (let i = 0; i < gridObj.columns.length; i++) {
                let col = gridObj.columns[i];
                if (typeof col.customAttributes != 'undefined' && typeof col.customAttributes.id != 'undefined' && col.customAttributes.id == 'detailed')
                    gridObj.showHider.hide(col.headerText, 'headerText');
                else if (col.showInColumnChooser)
                    gridObj.showHider.show(col.headerText, 'headerText');
            }
        }
        else {
            for (let i = 0; i < gridObj.columns.length; i++) {
                let col = gridObj.columns[i];
                if (col.showInColumnChooser)
                    gridObj.showHider.show(col.headerText, 'headerText');
            }
        }
    }
    if (args.item.id === 'toggleaudittrail') {

    }
    setTimeout(function () { gridObj.hideSpinner() }, 200);
}


function getAllChildren(nodes, curNode) {
    let result = [];

    let children = nodes.filter(function (x) { return x.parentId == curNode.id });
    nodes = nodes.filter(function (x) { return x.parentId != curNode.id });

    if (children.length > 0) {
        for (var i = 0; i < children.length; i++) {
            let curChild = children[i];
            let subChildren = getAllChildren(nodes, curChild);

            result.push({
                id: curChild.id,
                type: curChild._unit.unitType,
                name: curChild._unit.name,
                //unit: curChild._unit,

                children: subChildren
            });
        }
    }

    return result;
}

function diff_weeks(dt2, dt1) {

    var diff = (dt2.getTime() - dt1.getTime()) / 1000;
    diff /= (60 * 60 * 24 * 7);
    return Math.abs(Math.round(diff));

}
function diff_months(dt2, dt1) {

    var diff = (dt2.getTime() - dt1.getTime()) / 1000;
    diff /= (60 * 60 * 24 * 30);
    return Math.abs(Math.round(diff));
}
function diff_quarters(dt2, dt1) {

    var diff = (dt2.getTime() - dt1.getTime()) / 1000;
    diff /= (60 * 60 * 24 * 30 * 3);
    return Math.abs(Math.round(diff));
}
function diff_halfYears(dt2, dt1) {

    var diff = (dt2.getTime() - dt1.getTime()) / 1000;
    diff /= (60 * 60 * 24 * 30 * 6);
    return Math.abs(Math.round(diff));
}
function diff_years(dt2, dt1) {

    var diff = (dt2.getTime() - dt1.getTime()) / 1000;
    diff /= (60 * 60 * 24 * 30 * 12);
    return Math.abs(Math.round(diff));
}


let dictionaryValueTypes = [];
let fullNameValueObjects = [];
let codeNameTypes = [];
function populateDictionaryValues(data, grid, columnIndex) {
    let dataMS = [];
    for (let i = 0; i < data.length; i++) {
        let item = data[i];
        dataMS.push({ label: `${item.value} (${item.key})`, value: item.id, data: item });
    }
    try {
        if (typeof columnIndex === typeof '')
            grid.columns.filter(function (x) { return x.field == columnIndex })[0].edit.params.dataSource = dataMS;
        else
            grid.columns[columnIndex].edit.params.dataSource = dataMS;
    } catch (ex) {
        console.error(ex);
        console.log(columnIndex);
        console.log(grid.columns[columnIndex]);
        console.log(grid.columns.filter(function (x) { return x.field == columnIndex })[0]);
    }
    //console.log(dataMS);
}
function populateMSDictionaryValues(data, multiselect) {
    let dataMS = [];
    for (let i = 0; i < data.length; i++) {
        let item = data[i];
        dataMS.push({ label: `${item.value} (${item.key})`, value: item.id, data: item });
    }
    //console.log(dataMS);
    $(multiselect).multiselect('dataprovider', dataMS);
}
function loadDictionaryValues(valueType, gridsArray = [], columnsArray = [], multiselects = [], callback = null) {
    $.each(gridsArray, function (i, x) { x.showSpinner(); });
    cERP.appServices.setup.lookup.dictionaryValue.getAllByValueType(valueType).done(function (data) {
        $.each(gridsArray, function (i, x) { x.hideSpinner(); });

        dictionaryValueTypes.removeIf(function (x) { return data.filter(function (y) { return y.id == x.id }).length > 0 })
        dictionaryValueTypes = dictionaryValueTypes.concat(data);

        $.each(gridsArray, function (i, x) { populateDictionaryValues(data, x, columnsArray[i]) });
        if (multiselects.length > 0)
            $.each(multiselects, function (i, x) { populateMSDictionaryValues(data, x) });
        if (callback) callback(data);
    });
}

function populateCodeNameTypes(data, grid, columnIndex, codeProp = null, valueProp = null) {
    let dataMS = [];
    for (let i = 0; i < data.length; i++) {
        let item = data[i];
        let cP = codeProp != null ? codeProp : 'code';
        let vP = valueProp != null ? valueProp : 'name';

        dataMS.push({ label: `${item[cP]} - ${item[vP]}`, value: item.id, data: item });
    }
    console.log(columnIndex);
    if (typeof columnIndex === typeof '')
        grid.columns.filter(function (x) { return x.field == columnIndex })[0].edit.params.dataSource = dataMS;
    else
        grid.columns[columnIndex].edit.params.dataSource = dataMS;

    //console.log(dataMS);
}
function populateMSCodeNameTypes(data, multiselect, codeProp = null, valueProp = null) {
    let dataMS = [];
    for (let i = 0; i < data.length; i++) {
        let item = data[i];
        let cP = codeProp != null ? codeProp : 'code';
        let vP = valueProp != null ? valueProp : 'name';

        dataMS.push({ label: `${item[cP]} - ${item[vP]}`, value: item.id, data: item });
    }
    //console.log(dataMS);
    $(multiselect).multiselect('dataprovider', dataMS);
}
function loadCodeNameTypes(serviceFuncion, gridsArray = [], columnsArray = [], multiselects = [], codeProp = null, valueProp = null, callback = null) {
    $.each(gridsArray, function (i, x) { x.showSpinner(); });
    serviceFuncion().done(function (data) {
        $.each(gridsArray, function (i, x) { x.hideSpinner(); });

        codeNameTypes.removeIf(function (x) { return data.filter(function (y) { return y.id == x.id }).length > 0 })
        codeNameTypes = codeNameTypes.concat(data);

        $.each(gridsArray, function (i, x) { populateCodeNameTypes(data, x, columnsArray[i], codeProp, valueProp) });
        if (multiselects.length > 0) {
            $.each(multiselects, function (i, x) {
                if (x[0] == '.') {
                    $.each($(x), function (j, y) { populateMSCodeNameTypes(data, y, codeProp, valueProp) })
                }
                else
                    populateMSCodeNameTypes(data, x, codeProp, valueProp);
            });
        }
        if (callback) callback();
    });
}

function generateCardTiles(data, title, subTitle, fields, cardActionBtns, isHorizontal)
{
    $('.tile_layout > .content > #staticContent .loader-inline').slideDown();
    let result = [];
    console.log(data);
    var def = $('.tile_layout > .content > #staticContent');
    $('.e-card-layout > .card-container').empty();
    for (var i = 0; i < data.length; i++) {
        let curCardActionBtns = rfdc()(cardActionBtns);
        let curData = data[i];

        cardHtml = `<div class="col-xs-6 col-sm-6 col-lg-6 col-md-6 cardHolder">
                        <div id="view_tile_${i + 1}" class="view_tile"></div>
                    </div>`;

        $('.e-card-layout > .card-container').append(cardHtml);
        console.log('CURRENT DATA');
        console.log(curData);
        let header_title = Object.byString(curData, title);
        let header_subtitle = Object.byString(curData, subTitle);
        let card = {
            data: curData,
            header_title,
            header_subtitle,
            isHorizontal
        }
        card.cardContent = [];  
        for (var j = 0; j < fields.length; j++) {
            let isVisible = typeof fields[j].isVisible == 'undefined'? true : fields[j].isVisible;
            let fieldValue = '';
            if (fields[j].path == '*') {
                fieldValue = curData;
            }
            else {
                try {
                    fieldValue = Object.byString(rfdc()(curData), fields[j].path);
                }
                catch {
                    fieldValue = curData[fields[j].path];
                }
            }
            card.cardContent.push({ name: fields[j].title, value: fieldValue, isVisible});
        }
        for (var j = 0; j < curCardActionBtns.action_btns.length; j++) {
            curCardActionBtns.action_btns[j].onclick = 'onCardButtonClicked';
            curCardActionBtns.action_btns[j].args = { type: curCardActionBtns.action_btns[j].type, data: rfdc()(curData) };
        }
        card.card_action_btn = curCardActionBtns;

        result.push(card);
    }

    $('.tile_layout > .content > #staticContent .loader-inline').slideUp();
    return result;
}
function onCardButtonClickedData(type, data) {
    console.log(type);
    if (type == 'view' || type == 'edit') {
        isEditingCrudSpace = false;
        isSearchingCrudSpace = false;

        let crudSpaceIndex = spaceTabs.items.findIndex(function (x) {
            return x.properties.content == '#crudSpace';
        });
        spaceTabs.setActive(crudSpaceIndex);
        console.log('fdsf');
        let isReadonly = false;
        curCrudSpaceEdit = data;
        if (type == 'view') {

            isReadonly = true;
            $('.formSpaceSubmitBtn', '#crudSpace').slideUp();

            spaceTabs.items[crudSpaceIndex].header.properties.text = "View";
            spaceTabs.refresh()
        }
        else {
            isEditingCrudSpace = true;

            isReadonly = false;

            let curValue = $('.formSpaceSubmitBtn', '#crudSpace').val();
            curValue = curValue.replace('Create', 'Update');
            $('.formSpaceSubmitBtn', '#crudSpace').val(curValue);
            $('.formSpaceSubmitBtn', '#crudSpace').slideDown();

            spaceTabs.items[crudSpaceIndex].header.properties.text = "Edit";
            spaceTabs.refresh()
        }

        FillDivFormByObject(data, $('#formSpaceForm :input', '#crudSpace'), isReadonly);
    }
    else if (type == "auditTrail") {
        console.log("Fdfds");
        toggleAuditTrail(data);
    }
    try {
        onCardButtonClickedDataCustom(type, data);
    }
    catch (ex) {
        console.log(ex);
    }
}

function onCardButtonClicked(btn) {
    let curId = $(btn).attr('data-id');
    let curType = $(btn).attr('data-type');
    let data = listOfData.filter(function (x) { return x.data.id == curId })[0].data;

    onCardButtonClickedData(curType, data);
}

function cardRendering(cardObj) {
    console.log(cardObj);
    var staticContent = document.querySelector('.tile_layout > .content');
    if (cardObj.length > 0) {
        staticContent.style.display = 'none';
        cardObj.forEach(function (data, index) {
            card = cardTemplateFn(data);
            cardEle = document.getElementById('view_tile_' + (++index));
            if (cardEle) {
                cardEle.appendChild(card[0]);
            }
        });
    }
    else {
        staticContent.style.display = 'flex';
    }
}
function destroyAllCard() {
    var cards = document.querySelectorAll('.card-control-section .e-card');
    [].slice.call(cards).forEach(function (el) {
        ej.base.detach(el);
    });
}

function onOverlayClick() {
    this.hide();
}

function spacesTabSelected(args) {
    console.log(this);
    if (this.templateEle[0] == "#crudSpace") {
        toggleCreateNew(false);
    }
}