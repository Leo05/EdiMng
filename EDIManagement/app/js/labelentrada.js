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
        $('#cmdprintlabel').on('click', function (e) {
                    o._printLabel();
                }
        );
    };
    p._printLabel = function () {

        var prm = {
            referencia: $("#txtreferencia").val()
        };
        var dialog = bootbox.dialog({ message: '<div class="text-center"><i class="fa fa-spin fa-spinner"></i> Por favor espere...</div>' });
        $.ajax({
            data: JSON.stringify(prm),
            dataType: 'json',
            url: 'services/recohandler.asmx/PrintGenLabel',
            type: 'POST',
            contentType: 'application/json; charset=utf-8',
            success: function (result) {
                $("#spanlabel").hide();
                var obj = $.parseJSON(result.d);
                var url = obj.fileurl;
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