<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="labelsm.aspx.cs" Inherits="EDIManagement.labelsm" %>

<!DOCTYPE html>

<html>
<head>
    <meta charset="utf-8">
    <meta http-equiv="X-UA-Compatible" content="IE=edge">
    <title><%=ConfigurationManager.AppSettings["CIA.NAME"]%> - Dashboard</title>
    <meta content="width=device-width, initial-scale=1, maximum-scale=1, user-scalable=no" name="viewport">
    <link href="assets/libs/bootstrap/css/bootstrap.min.css" rel="stylesheet" />
    <link rel="stylesheet" href="https://cdnjs.cloudflare.com/ajax/libs/font-awesome/4.5.0/css/font-awesome.min.css">
    <link rel="stylesheet" href="https://cdnjs.cloudflare.com/ajax/libs/ionicons/2.0.1/css/ionicons.min.css">
    <link href="assets/libs/toastr/toastr.css" rel="stylesheet" />
    <link rel="stylesheet" href="dist/css/AdminLTE.min.css">
    <link rel="stylesheet" href="dist/css/skins/skin-blue.min.css">

    <!-- HTML5 Shim and Respond.js IE8 support of HTML5 elements and media queries -->
    <!-- WARNING: Respond.js doesn't work if you view the page via file:// -->
    <!--[if lt IE 9]>
  <script src="https://oss.maxcdn.com/html5shiv/3.7.3/html5shiv.min.js"></script>
  <script src="https://oss.maxcdn.com/respond/1.4.2/respond.min.js"></script>
  <![endif]-->
</head>
<body class="hold-transition skin-blue sidebar-mini">
    <div class="wrapper">
        <!-- Main Header -->
        <header class="main-header">

            <!-- Logo -->
            <a href="index.aspx" class="logo">
                <!-- mini logo for sidebar mini 50x50 pixels -->
                <span class="logo-mini"><b>EDI</b></span>
                <!-- logo for regular state and mobile devices -->
                <span class="logo-lg"><b><%=ConfigurationManager.AppSettings["CIA.NAME"]%></b></span>
            </a>

            <!-- Header Navbar -->
            <nav class="navbar navbar-static-top" role="navigation">
                <!-- Sidebar toggle button-->
                <a href="#" class="sidebar-toggle" data-toggle="offcanvas" role="button">
                    <span class="sr-only">Toggle navigation</span>
                </a>
                <!-- Navbar Right Menu -->
                <div class="navbar-custom-menu">
                    <ul class="nav navbar-nav">
                        <!-- User Account Menu -->
                        <li class="dropdown user user-menu">
                            <!-- Menu Toggle Button -->
                            <a href="#" class="dropdown-toggle" data-toggle="dropdown">
                                <!-- The user image in the navbar-->
                                <img src="dist/img/avatar.png" class="user-image" alt="User Image">
                                <!-- hidden-xs hides the username on small devices so only the image appears. -->
                                <span class="hidden-xs">
                                    <label id="lbluser">Administrator</label></span>
                            </a>
                            <ul class="dropdown-menu">
                                <!-- The user image in the menu -->
                                <li class="user-header">
                                    <img src="dist/img/avatar.png" class="img-circle" alt="User Image">
                                    <p>Admin</p>
                                </li>
                                <!-- Menu Body -->
                                <li class="user-body">
                                    <!-- /.row -->
                                </li>
                                <!-- Menu Footer-->
                                <li class="user-footer">
                                    <div class="pull-right">
                                        <a href="login.aspx" class="btn btn-default btn-flat">Sign out</a>
                                    </div>
                                </li>
                            </ul>
                        </li>
                        <!-- Control Sidebar Toggle Button -->
                        <li>
                            <a href="#" data-toggle="control-sidebar"><i class="fa fa-gears"></i></a>
                        </li>
                    </ul>
                </div>
            </nav>
        </header>
        <!-- Left side column. contains the logo and sidebar -->
        <aside class="main-sidebar">

            <!-- sidebar: style can be found in sidebar.less -->
            <section class="sidebar">

                <!-- Sidebar user panel (optional) -->
                <div class="user-panel">
                    <div class="pull-left image">
                        <img src="dist/img/avatar.png" class="img-circle" alt="User Image">
                    </div>
                    <div class="pull-left info">
                        <p>
                            <label id="lblusermenu">Administrator</label>
                        </p>
                    </div>
                </div>

                <!-- Sidebar Menu -->
                <ul class="sidebar-menu">
                    <li class="header">MAIN MENU</li>
                    <!-- Optionally, you can add icons to the links -->
                    <li><a href="index.aspx"><i class="fa fa-dashboard"></i><span>Dashboard</span></a></li>
                    <li class="treeview">
                        <a href="#"><i class="fa fa-file-code-o"></i><span>Archivos EDI</span>
                            <span class="pull-right-container">
                                <i class="fa fa-angle-left pull-right"></i>
                            </span>
                        </a>
                        <ul class="treeview-menu">
                            <li><a href="frmnewfile.aspx">Generar archivo</a></li>
                        </ul>
                    </li>
                    <li class="treeview active">
                        <a href="#"><i class="fa fa-print"></i><span>Impresion de Etiquetas</span>
                            <span class="pull-right-container">
                                <i class="fa fa-angle-left pull-right"></i>
                            </span>
                        </a>
                        <ul class="treeview-menu">
                            <li class="active"><a href="labelsm.aspx">Skid Manifest</a></li>
                            <li><a href="labelsrsm.aspx">Special Rack / Skid Manifest</a></li>
                            <li><a href="labelpp.aspx">Production Parts</a></li>
                            <li><a href="labelpml.aspx">Pallet Master Label</a></li>
                        </ul>
                    </li>
                </ul>
                <!-- /.sidebar-menu -->
            </section>
            <!-- /.sidebar -->
        </aside>

        <!-- Content Wrapper. Contains page content -->
        <div class="content-wrapper">
            <!-- Content Header (Page header) -->
            <section class="content-header">
                <h1>Dashboard</h1>
                <ol class="breadcrumb">
                    <li><a href="#"><i class="fa fa-dashboard"></i>Main</a></li>
                    <li class="active">Dashboard</li>
                </ol>
            </section>

            <!-- Main content -->
            <section class="content">
                <!-- Your Page Content Here -->
                <div class="row">
                    <div class="col-md-2"></div>
                    <div class="col-md-10">
                        <div class="form-horizontal">
                            <fieldset>
                                <legend>Skid Manifest Label</legend>
                                <div class="form-group">
                                    <label for="lgddateorder" class="col-lg-2 control-label">Date / order code</label>
                                    <div class="col-lg-6">
                                        <input class="form-control" id="lgddateorder" placeholder="Date / order code" type="text" />
                                        <input class="hidden" id="lgdid" />
                                    </div>
                                </div>
                                <div class="form-group">
                                    <label for="lgdsuppliercode" class="col-lg-2 control-label">Supplier Code</label>
                                    <div class="col-lg-6">
                                        <input class="form-control" id="lgdsuppliercode" placeholder="Supplier Code" type="text" value="A361-01" readonly />
                                    </div>
                                </div>
                                <div class="form-group">
                                    <label for="lgdshopcode" class="col-lg-2 control-label">Shop Code</label>
                                    <div class="col-lg-6">
                                        <input class="form-control" id="lgdshopcode" placeholder="Shop Code" type="text" />
                                    </div>
                                </div>
                                <div class="form-group">
                                    <label for="lgdroutesia" class="col-lg-2 control-label">Route/Run #</label>
                                    <div class="col-lg-6">
                                        <input class="form-control" id="lgdroutesia" placeholder="Route/Run #" type="text" />
                                    </div>
                                </div>
                                <div class="form-group">
                                    <label for="lgdshipdate" class="col-lg-2 control-label">Ship Date</label>
                                    <div class="col-lg-6">
                                        <input class="form-control" id="lgdshipdate" placeholder="Ship Date" type="text" />
                                    </div>
                                </div>
                                <div class="form-group">
                                    <label for="lgdlaredosia" class="col-lg-2 control-label">Route/Run #</label>
                                    <div class="col-lg-6">
                                        <input class="form-control" id="lgdlaredosia" placeholder="Route/Run #" type="text" />
                                    </div>
                                </div>
                                <div class="form-group">
                                    <label for="lgdshipdatetime" class="col-lg-2 control-label">Ship Date & Time</label>
                                    <div class="col-lg-6">
                                        <input class="form-control" id="lgdshipdatetime" type="text" placeholder="Ship Date & Time" />
                                    </div>
                                </div>
                                <div class="form-group">
                                    <label for="lgdroutecrossdock" class="col-lg-2 control-label">Route/Run #</label>
                                    <div class="col-lg-6">
                                        <input class="form-control" id="lgdroutecrossdock" placeholder="Route/Run #" type="text" />
                                    </div>
                                </div>
                                <div class="form-group">
                                    <label for="lgdshipdatetimecrossdock" class="col-lg-2 control-label">Ship Date & Time</label>
                                    <div class="col-lg-6">
                                        <input class="form-control" id="lgdshipdatetimecrossdock" type="text" placeholder="Ship Date & Time" />
                                    </div>
                                </div>
                                <div class="form-group">
                                    <label for="lgddeliverycycle" class="col-lg-2 control-label">Delivery Cycle</label>
                                    <div class="col-lg-6">
                                        <input class="form-control" id="lgddeliverycycle" placeholder="Delivery Cycle" type="text" />
                                    </div>
                                </div>
                                <div class="form-group">
                                    <label for="lgdconsumptiondatetime" class="col-lg-2 control-label">Consumtion Date & Time</label>
                                    <div class="col-lg-6">
                                        <input class="form-control" id="lgdconsumptiondatetime" placeholder="Consumtion Date & Time" type="text" />
                                    </div>
                                </div>
                                <div class="form-group">
                                    <label for="lgddeliverycode" class="col-lg-2 control-label">Delivery Code</label>
                                    <div class="col-lg-6">
                                        <input class="form-control" id="lgddeliverycode" placeholder="Delivery Code" type="text" />
                                    </div>
                                </div>
                                <div class="form-group">
                                    <label for="lgdskid" class="col-lg-2 control-label">Skid</label>
                                    <div class="col-lg-3">
                                        <input class="form-control" id="lgdskid" placeholder="Skid from" type="text" />
                                    </div>
                                    <div class="col-lg-3">
                                        <input class="form-control" id="lgdskidto" placeholder="Skid to" type="text" />
                                    </div>
                                </div>
                            </fieldset>
                        </div>
                    </div>
                    <div class="col-md-2"></div>

                </div>
                <div class="row">
                    <div class="col-md-4"></div>
                    <div class="col-md-4">
                        <div class="form-group">
                            <button id="cmdsavegendata" type="button" class="btn btn-primary">Guardar Etiqueta</button>
                            <button id="cmdprintlabel" type="button" class="btn btn-success">Imprimir Etiqueta</button>
                        </div>
                    </div>
                </div>
            </section>
            <!-- /.content -->
        </div>
        <!-- /.content-wrapper -->

        <!-- Main Footer -->
        <footer class="main-footer">
            <!-- To the right -->
            <div class="pull-right hidden-xs">
            </div>
            <!-- Default to the left -->
            <strong>Copyright &copy; 2017 <a href="#"><%=ConfigurationManager.AppSettings["CIA.NAME"]%></a>.</strong> All rights reserved.
        </footer>
    </div>
    <!-- ./wrapper -->
    <!-- REQUIRED JS SCRIPTS -->
    <script src="assets/libs/jQuery/jquery-2.2.3.min.js"></script>
    <script src="assets/libs/bootstrap/js/bootstrap.min.js"></script>
    <script src="assets/libs/bootbox/bootbox.min.js"></script>
    <script src="dist/js/app.min.js"></script>
    <script src="assets/libs/slimScroll/jquery.slimscroll.min.js"></script>
    <script src="assets/libs/fastclick/fastclick.js"></script>
    <script src="assets/libs/jcookie/jquery.cookie.js"></script>
    <script src="assets/libs/toastr/toastr.js"></script>
    <script src="app/js/core.js"></script>
    <script src="app/js/labelsm.js"></script>
</body>
</html>
