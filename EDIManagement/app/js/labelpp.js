(function (namespace, $) {
    "use strict";

    var labelpp = function () {
        // Create reference to this instance
        var o = this;
        // Initialize app when document is ready
        $(document).ready(function () {
            o.initialize();
        });

    };
    var p = labelpp.prototype;

    // =========================================================================
    // INIT
    // =========================================================================

    p.initialize = function () {
        this._enableEvents();
    };

    p._enableEvents = function () {
        var o = this;
        $('#cmdsavegendata').on('click', function (e) {
            o._savelabelchanges();
        });
        $('#cmdprintlabel').on('click', function (e) {
            bootbox.prompt({
                size: "small",
                title: "Ingrese cantidad de etiquetas a imprimir!",
                inputType: 'number',
                backdrop: false,
                callback: function (result) {
                    o._printLabel(result);
                }
            });
        });
    };
    p._savelabelchanges = function () {
        var dialog = bootbox.dialog({ message: '<div class="text-center"><i class="fa fa-spin fa-spinner"></i> Por favor espere...</div>' });
        var data = {
            pplpartnumber: $("#pplpartnumber").val(),
            ppldonumber: $("#ppldonumber").val(),
            pplpartname: $("#pplpartname").val(),
            pplsupplieruse: $("#pplsupplieruse").val(),
            pplecsnumber: $("#pplecsnumber").val(),
            pplquantity: $("#pplquantity").val(),
            ppllinedeliverycicle: $("#ppllinedeliverycicle").val(),
            pplkanban: $("#pplkanban").val(),
            pplwhloc: $("#pplwhloc").val(),
            ppldeliverycicle: '',
            pplordercode: $("#pplordercode").val(),
            pplshipdate: $("#pplshipdate").val(),
            pplfitloc: $("#pplfitloc").val()
        };
        $.ajax({
            data: JSON.stringify(data),
            dataType: 'json',
            url: 'services/PrintLabels.asmx/SaveProductionPartLabel',
            type: 'POST',
            contentType: 'application/json; charset=utf-8',
            success: function (result) {
                var obj = $.parseJSON(result.d);
                console.log(obj);
                $("#lgdig").val(obj.lgdig);
                toastr.success('Informacion grabada exitosamente', '');
            }, error: function (xhr, textStatus, error) {
                var errorM = $.parseJSON(xhr.responseText);
                toastr.error(errorM.Message, '');
            }, complete: function () {
                dialog.modal('hide');
            }
        });
    };
    p._printLabel = function (cantet) {
        var i = 1;
        if (!isNaN(cantet)) {
            i = cantet;
        }

        var prm = {
            etiquetas: i
        };
        var dialog = bootbox.dialog({ message: '<div class="text-center"><i class="fa fa-spin fa-spinner"></i> Por favor espere...</div>' });
        $.ajax({
            data: JSON.stringify(prm),
            dataType: 'json',
            url: 'services/PrintLabels.asmx/PrintProductionPartsLabels',
            type: 'POST',
            contentType: 'application/json; charset=utf-8',
            success: function (result) {
                $("#spanlabel").hide();
                var obj = $.parseJSON(result.d);
                var url = "documentos/" + obj.fileurl + ".pdf";
                window.open(url);
            }, error: function (xhr, textStatus, error) {
                $("#spanlabel").hide();
                var errorM = $.parseJSON(xhr.responseText);
                toastr.error(errorM.Message, '');
            }, complete: function () {
                dialog.modal('hide');
            }
        });
    };
    namespace.labelpp = new labelpp;
}(this.edimanagement, jQuery));