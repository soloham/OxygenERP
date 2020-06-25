(function () {
    abp.log.debug('PayrollPeriodWidget loaded :)');
    abp.widgets.PayrollPeriodWidget = function ($wrapper) {

        var loadPayrollPeriodDependencies = function() {
            console.log('Loading All Dependencies');
            $('#periodFrequency').multiselect('dataprovider', frequencyPeriods);
        }           

        var getFilters = function () {
            return {

            };
        }

        var refresh = function (filters) {

            console.log('Loading All Dependencies');
            loadPayrollPeriodDependencies();
        };

        var init = function (filters) {

            console.log('Loading All Dependencies');
            loadPayrollPeriodDependencies();
        };

        return {
            getFilters: getFilters,
            init: init,
            refresh: refresh
        };
    };
})();

function payPeriodActionComplete(args) {
    if (args.requestType == "delete") {
        if (this.dataSource.length == 0) {
            this.toolbar = [{ text: "Show Actions", tooltipText: "Actions", prefixIcon: "e-custom-show-actions", id: "showActions" }, "Add", "Cancel", "Search"];
            this.refresh();
        }
    }
    if (args.requestType == "save") {
        if (this.dataSource.length <= 1) {
            //args.cancel = true;

            this.toolbar = [{ text: "Show Actions", tooltipText: "Actions", prefixIcon: "e-custom-show-actions", id: "showActions" }, "Search"];
            this.refresh();

            let initialPeriod = args.data;
            let payrollPeriod = $('.payrollCalendarRange > input', '#crudSpace')[0].ej2_instances[0].value;
            let payrollFrequency = $('#periodFrequency').val();
            let periodName = $('#periodName').val();

            setPayPeriodsMinMaxDates(payrollPeriod[0], payrollPeriod[1]);
            console.log(initialPeriod);
            this.dataSource = calculatePayrollPeriods(payrollPeriod, initialPeriod, payrollFrequency, periodName);
        }
        else
            args.cancel = true;


    }
}

function payPeriodActionBegin(args) {
    if (args.requestType == "delete") {
        if (this.dataSource.length == 0) {
            this.toolbar = [{ text: "Show Actions", tooltipText: "Actions", prefixIcon: "e-custom-show-actions", id: "showActions" }, "Add", "Cancel", "Search", "ColumnChooser"];
            this.refresh();
        }
    }
    if (args.requestType == "add") {
        if (this.dataSource.length > 0) {
            args.cancel = true;

            this.toolbar = [{ text: "Show Actions", tooltipText: "Actions", prefixIcon: "e-custom-show-actions", id: "showActions" }, "Search", "ColumnChooser"];
            this.refresh();
        }
    }
}

function payrollPeriodGridCreated(args) {
    abp.log.debug('PayrollPeriodWidget loaded :)');
    let gridObj = document.getElementById("PayrollPeriodsGrid").ej2_instances[0];
    gridObj.toolbar = [{ text: "Show Actions", tooltipText: "Actions", prefixIcon: "e-custom-show-actions", id: "showActions" }, "Add", "Cancel", "Search", "ColumnChooser"];
}
function payrollPeriodToolbarClick(args) {
    let gridObj = document.getElementById("PayrollPeriodsGrid").ej2_instances[0];

    if (args.item.id === 'PayrollPeriodsGrid_pdfexport') {
        gridObj.pdfExport();
    }
    if (args.item.id === 'PayrollPeriodsGrid_excelexport') {
        gridObj.excelExport();
    }
    if (args.item.id === 'PayrollPeriodsGrid_csvexport') {
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
        gridObj.toolbar = [{ text: "Hide Actions", tooltipText: "Actions", prefixIcon: "e-custom-hide-actions", id: "hideActions" }, { text: "Toggle Grouping", tooltipText: "Grouping", prefixIcon: "e-custom-group-toggle", id: "toggleGrouping" }, { text: "Audit Trail", tooltipText: "View Audit Trail", prefixIcon: "e-custom-audit-trail", id: "toggleaudittrail" }, { text: "Toggle Detailed", tooltipText: "Toggle Detailed", prefixIcon: "e-toggledetailed", id: "toggleDetailed" }, { text: "ExcelExport", tooltipText: "Excel Export", prefixIcon: "e-excelexport", id: this.element.id + "_excelexport", align: 'Right' }, { text: this.element.id + "_PdfExport", tooltipText: "Pdf Export", prefixIcon: "e-pdfexport", id: "pdfexport", align: 'Right' }, { text: "CsvExport", tooltipText: "Csv Export", prefixIcon: "e-csvexport", id: this.element.id + "_csvexport", align: 'Right' }, { text: "Print", tooltipText: "Print", prefixIcon: "e-print", id: this.element.id + "_print", align: 'Right' }, { text: "Copy", tooltipText: "Copy", prefixIcon: "e-copy", id: "copy" }, "Search", { text: "Copy With Header", tooltipText: "Copy With Header", prefixIcon: "e-copy", id: "copyHeader" }, "ColumnChooser"];
        gridObj.refresh();
    }
    if (args.item.id === 'hideActions') {
        if (gridObj.dataSource.length == 0)
            gridObj.toolbar = [{ text: "Show Actions", tooltipText: "Actions", prefixIcon: "e-custom-show-actions", id: "showActions" }, "Add", "Cancel", "Search", "ColumnChooser"];
        else
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

        if (!isAuditTrail) {
            var agtGrid = $("#AuditTrailGrid")[0].ej2_instances[0];
            gridObj.showSpinner();

            $.ajax({
                url: '?handler=DataAuditTrail',
                async: true,
                type: "GET",
                data: {},
                success: function (data) {
                    gridObj.hideSpinner();

                    //agtGrid.childGrid.childGrid.dataSource = data.tertiaryDS;
                    //agtGrid.childGrid.dataSource = data.secondaryDS;
                    agtGrid.dataSource = data.ds;
                    agtGrid.refresh();

                    $(".customContentArea").css('position', 'unset');
                    $("#auditTrail").slideDown(200);
                },
                error: function (data) {
                    gridObj.hideSpinner();

                    $(".customContentArea").css('position', 'absolute');
                    $("#auditTrail").slideUp(200);

                    swal.fire('Failed', `An error occured while generating the audit trail`, 'error');
                }
            });

        }
        else {
            $(".customContentArea").css('position', 'absolute');
            $("#auditTrail").slideUp(200);
        }

        isAuditTrail = !isAuditTrail;
    }
    setTimeout(function () { gridObj.hideSpinner() }, 200);
}

