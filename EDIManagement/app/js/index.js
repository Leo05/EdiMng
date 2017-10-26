(function (namespace, $) {
    "use strict";

    var index = function () {
        // Create reference to this instance
        var o = this;
        // Initialize app when document is ready
        $(document).ready(function () {
            o.initialize();
        });

    };
    var p = index.prototype;
    var theme = "metro";

    // =========================================================================
    // INIT
    // =========================================================================

    p.initialize = function () {
        this._loadDom();
        this._enableEvents();
        this._loadData();
    };
    p._loadDom = function () {
        $("#grid").jqxGrid(
        {
            width: '100%',
            pageable: true,
            sortable: true,
            altrows: true,
            enabletooltips: true,
            editable: true,
            showfilterrow: true,
            filterable: true,
            selectionmode: 'multiplecellsadvanced',
            columns: [
              { text: '', datafield: 'genid', hidden: true },
              { text: 'Release Number', datafield: 'release_number', width: 200 },
              { text: 'Schedule Horizon From', datafield: 'schedule_horizon_from', width: 150 },
              { text: 'Schedule Horizon To', datafield: 'schedule_horizon_to', width: 150 },
              { text: 'Issued_Date', datafield: 'issued_date', width: 150 },
              { text: 'Buyer Part No', datafield: 'buyer_partnumber', width: 150 },
              { text: 'Purchase Order', datafield: 'purchase_order', width: 150 },
              { text: 'Unit', datafield: 'unit', width: 50 },
              { text: 'Product Description', datafield: 'product_description', width: 150 },
              { text: 'Quantity', datafield: 'quantity', width: 100 },
              { text: 'Timing', datafield: 'timing', width: 300 },
              { text: 'Scheduled Ddate', datafield: 'scheduled_date', width: 150 },
            ]
        });
    };

    p._enableEvents = function () {
        var o = this;
        var userfname = $.cookie('userfname');
        var userlname = $.cookie('userlname');
        var usernm = userfname + " " + userlname;
        toastr.success("Bienvenido, " + usernm);
    };
    p._loadData = function () {
        $('#grid').jqxGrid('showloadelement');
        $.ajax({
            type: 'POST',
            data: JSON.stringify({}),
            contentType: 'application/json; charset=utf-8',
            dataType: 'json',
            async: true,
            url: 'services/common.asmx/loaddashboard',
            success: function (data) {

                var data = $.parseJSON(data.d);
                var source =
                        {
                            localdata: data,
                            datatype: "json",
                            datafields:
                                [
                                    { name: 'genid', type: 'int' },
                                    { name: 'release_number', type: 'string' },
                                    { name: 'schedule_horizon_from', type: 'datetime' },
                                    { name: 'schedule_horizon_to', type: 'datetime' },
                                    { name: 'issued_date', type: 'datetime' },
                                    { name: 'buyer_partnumber', type: 'string' },
                                    { name: 'purchase_order', type: 'string' },
                                    { name: 'unit', type: 'string' },
                                    { name: 'product_description', type: 'datetime' },
                                    { name: 'quantity', type: 'int' },
                                    { name: 'timing', type: 'string' },
                                    { name: 'scheduled_date', type: 'datetime' }
                                ]
                        };
                var dataAdapter = new $.jqx.dataAdapter(source);
                $("#grid").jqxGrid({ source: dataAdapter });

                $('#grid').jqxGrid('hideloadelement');

            },
            error: function (xhr, textStatus, error) {
                if (typeof console == "object") {
                    console.log(xhr.status + "," + xhr.responseText + "," + textStatus + "," + error);
                }
            }
        });
    };
    namespace.index = new index;
}(this.edimanagement, jQuery));