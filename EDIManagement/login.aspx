<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="login.aspx.cs" Inherits="EDIManagement.login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Genercion de etiquetas</title>
    <link href="assets/libs/bootstrap/css/bootstrap.css" rel="stylesheet" />
    <link href="assets/libs/toastr/toastr.css" rel="stylesheet" />
    <link href="app/css/login.css" rel="stylesheet" />
</head>
<body>
    <div>
        <div class="container">
            <div class="row">
                <div class="col-sm-6 col-md-4 col-md-offset-4">
                    <h1 class="text-center login-title">Bienvenidos</h1>
                    <div class="account-wall">
                        <img class="profile-img" src="assets/img/photo.jpg?sz=120"
                            alt="" />
                        <div class="form-signin">
                            <input id="username" type="text" class="form-control" placeholder="Usuario" required autofocus />
                            <input id="password" type="password" class="form-control" placeholder="Password" required />
                            <button id="login" class="btn btn-lg btn-primary btn-block">Aceptar</button>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
    <script src="assets/libs/jQuery/jquery-2.2.3.min.js"></script>
    <script src="assets/libs/bootstrap/js/bootstrap.js"></script>
    <script src="assets/libs/jcookie/jquery.cookie.js"></script>
    <script src="assets/libs/bootbox/bootbox.min.js"></script>
    <script src="assets/libs/toastr/toastr.js"></script>
    <script src="assets/libs/jcookie/jquery.cookie.js"></script>
    <script src="app/js/core.js"></script>
    <script src="app/js/login.js"></script>
</body>
</html>
