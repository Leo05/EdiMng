(function (namespace, $) {
    "use strict";

    var frmnewfile = function () {
        // Create reference to this instance
        var o = this;
        // Initialize app when document is ready
        $(document).ready(function () {
            o.initialize();
        });

    };
    var p = frmnewfile.prototype;

    // =========================================================================
    // INIT
    // =========================================================================

    p.initialize = function () {
        this._enableEvents();
    };

    p._enableEvents = function () {
        var o = this;
        $('#cmdsavegendata').on('click', function (e) {
            bootbox.confirm("Grabar informacion?", function (result) {
                if (result)
                    o._savelabelchanges();
            });
        });
        $('#cmdprintlabel').on('click', function (e) {
            bootbox.confirm("Generar archivo?", function (result) {
                if (result) {
                    bootbox.prompt({
                        title: "Seleccione Identificador, produccion (P), Prueba (T)",
                        size: "small",
                        inputType: 'select',
                        inputOptions: [
                            {
                                text: 'Production Qualifier P',
                                value: 'P',
                            },
                            {
                                text: 'Test Qualifier T',
                                value: 'T',
                            }
                        ],
                        callback: function (result) {
                            if (result != null)
                                o._printLabel(result);
                        }
                    });
                }
            });
        });
    };
    p._savelabelchanges = function () {
        var dialog = bootbox.dialog({ message: '<div class="text-center"><i class="fa fa-spin fa-spinner"></i> Por favor espere...</div>' });
        var data = {
            edicontrolnumber: $("#edicontrolnumber").val(),
            edishipment: $("#edishipment").val(),
            ediscaccode: $("#ediscaccode").val(),
            edicarrier: $("#edicarrier").val(),
            edibol: $("#edibol").val(),
            edipackinglist: $("#edipackinglist").val(),
            edicarrierref: $("#edicarrierref").val(),
            edipartnumber: $("#edipartnumber").val(),
            ediengchange: $("#ediengchange").val(),
            edipartquantity: $("#edipartquantity").val(),
            edipartunit: $("#edipartunit").val(),
            edidevordernum: $("#edidevordernum").val(),
            edilinecount: $("#edilinecount").val(),
        };
        $.ajax({
            data: JSON.stringify(data),
            dataType: 'json',
            url: 'services/edihandler.asmx/saveEDIFile',
            type: 'POST',
            contentType: 'application/json; charset=utf-8',
            success: function (result) {
                toastr.success('Informacion grabada exitosamente', '');
            }, error: function (xhr, textStatus, error) {
                var errorM = $.parseJSON(xhr.responseText);
                toastr.error(errorM.Message, '');
            }, complete: function () {
                dialog.modal('hide');
            }
        });
    };
    p._printLabel = function (qrid) {

        var qualifier = { qrid: qrid };

        var dialog = bootbox.dialog({ message: '<div class="text-center"><i class="fa fa-spin fa-spinner"></i> Por favor espere...</div>' });
        $.ajax({
            data: JSON.stringify(qualifier),
            dataType: 'json',
            url: 'services/edihandler.asmx/printEDIFile',
            type: 'POST',
            contentType: 'application/json; charset=utf-8',
            success: function (result) {
                $("#spanlabel").hide();
                var obj = $.parseJSON(result.d);
                var url = "Archivo " + obj.fileurl + ".edi, Generado exitosamente, desea ver la confirmacion?";
                bootbox.confirm(url, function (result) {
                    if (result) {
                        var urlhtml = "htmledifiles/" + obj.fileurl + ".html";
                        window.open(urlhtml);
                    }
                });
                toastr.success(url, '');

            }, error: function (xhr, textStatus, error) {
                $("#spanlabel").hide();
                var errorM = $.parseJSON(xhr.responseText);
                toastr.error(errorM.Message, '');
            }, complete: function () {
                dialog.modal('hide');
            }
        });
    };

    namespace.frmnewfile = new frmnewfile;
}(this.edimanagement, jQuery));