(function (namespace, $) {
    "use strict";

    var Login = function () {
        var o = this;
        $(document).ready(function () {
            o.initialize();
        });
    };

    var p = Login.prototype;

    p.initialize = function () {
        this._enableEvents();
    };

    p._enableEvents = function () {
        var o = this;
        $("#login").click(function () {
            var dialog = bootbox.dialog({ message: '<div class="text-center"><i class="fa fa-spin fa-spinner"></i> Por favor espere...</div>' });
            var data = {
                uid: $("#username").val(),
                pwd: $("#password").val()
            }

            data.cteid = '';
            if (data.uid == "" || data.pwd == "")
                return;

            $.ajax({
                data: JSON.stringify(data),
                dataType: 'json',
                url: 'services/common.asmx/validateuser',
                type: 'POST',
                contentType: 'application/json; charset=utf-8',
                success: function (result) {
                    var obj = $.parseJSON(result.d);

                    if (!obj) {
                        toast.error("Usuario o password incorrecto!!! favor de verificar");
                        return;
                    }

                    if (obj.uid != null) {
                        $.cookie('uid', obj.uid, { expires: 7, path: '/' });
                        $.cookie('userid', obj.userid, { expires: 7, path: '/' });
                        $.cookie('userfname', obj.userfname, { expires: 7, path: '/' });
                        $.cookie('userlname', obj.userlname, { expires: 7, path: '/' });
                        $.cookie('useremail', obj.useremail, { expires: 7, path: '/' });
                        window.location = "index.aspx";
                    }
                    else {
                        $('#logerror').show();
                        toast.error("Usuario o password incorrecto!!! favor de verificar");
                    }

                }, error: function (xhr, textStatus, error) {
                    var errorM = $.parseJSON(xhr.responseText);
                    toastr.error(errorM.Message, '');
                }, complete: function () {
                    dialog.modal('hide');
                }
            });
            return false;
        });
    };

    namespace.Login = new Login;
}(this.edimanagement, jQuery));