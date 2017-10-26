<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="frmnewfile.aspx.cs" Inherits="EDIManagement.frmnewfile" %>

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
                        <ul class="treeview-menu active">
                            <li class="active"><a href="frmnewfile.aspx">Generar archivo</a></li>
                        </ul>
                    </li>
                    <li class="treeview">
                        <a href="#"><i class="fa fa-print"></i><span>Impresion de Etiquetas</span>
                            <span class="pull-right-container">
                                <i class="fa fa-angle-left pull-right"></i>
                            </span>
                        </a>
                        <ul class="treeview-menu">
                            <li><a href="labelsm.aspx">Skid Manifest</a></li>
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
                    <div class="col-md-8">
                        <div class="form-horizontal">
                            <fieldset>
                                <legend>856 EDI File</legend>
                                <div class="form-group">
                                    <label for="edicontrolnumber" class="col-lg-6 control-label">Control Number</label>
                                    <div class="col-lg-6">
                                        <input class="form-control" id="edicontrolnumber" type="number" max="999" />
                                    </div>
                                </div>
                                <div class="form-group">
                                    <label for="edishipment" class="col-lg-6 control-label">Shipment Identification Code</label>
                                    <div class="col-lg-6">
                                        <input class="form-control" id="edishipment" placeholder="Shipment Identification" type="text" maxlength="20" />
                                    </div>
                                </div>
                                <div class="form-group">
                                    <label for="ediscaccode" class="col-lg-6 control-label">Carrier Identification Code(SCAC)</label>
                                    <div class="col-lg-6">
                                        <input class="form-control" id="ediscaccode" type="text" placeholder="Carrier Identification Code(SCAC)" maxlength="4" />
                                    </div>
                                </div>
                                <div class="form-group">
                                    <label for="edicarrier" class="col-lg-6 control-label">Carrier</label>
                                    <div class="col-lg-6">
                                        <input class="form-control" id="edicarrier" placeholder="Carrier" type="text" maxlength="30" />
                                    </div>
                                </div>
                                <div class="form-group">
                                    <label for="edibol" class="col-lg-6 control-label">Bill of Lading</label>
                                    <div class="col-lg-6">
                                        <input class="form-control" id="edibol" placeholder="Bill of Lading" type="text" />
                                    </div>
                                </div>
                                <div class="form-group">
                                    <label for="edipackinglist" class="col-lg-6 control-label">Packing List</label>
                                    <div class="col-lg-6">
                                        <input class="form-control" id="edipackinglist" placeholder="Packing List" type="text" />
                                    </div>
                                </div>
                                <div class="form-group">
                                    <label for="edicarrierref" class="col-lg-6 control-label">Carrier's Reference Number (PRO/Invoice)</label>
                                    <div class="col-lg-6">
                                        <input class="form-control" id="edicarrierref" placeholder="Carrier's Reference Number (PRO/Invoice)" type="text" />
                                    </div>
                                </div>
                                <div class="form-group">
                                    <label for="edipartnumber" class="col-lg-6 control-label">Part Number</label>
                                    <div class="col-lg-6">
                                        <input class="form-control" id="edipartnumber" placeholder="Part Number" type="text" />
                                    </div>
                                </div>
                                <div class="form-group">
                                    <label for="ediengchange" class="col-lg-6 control-label">Engineering Change Level</label>
                                    <div class="col-lg-6">
                                        <input class="form-control" id="ediengchange" placeholder="Engineering Change Level" type="text" />
                                    </div>
                                </div>
                                <div class="form-group">
                                    <label for="edipartquantity" class="col-lg-6 control-label">Number of Units Shipped</label>
                                    <div class="col-lg-6">
                                        <input class="form-control" id="edipartquantity" type="number" max="999" />
                                    </div>
                                </div>
                                <div class="form-group">
                                    <label for="edipartunit" class="col-lg-6 control-label">Part Unit</label>
                                    <div class="col-lg-6">
                                        <input class="form-control" id="edipartunit" placeholder="Part Unit" type="text" value="EA" readonly />
                                    </div>
                                </div>
                                <div class="form-group">
                                    <label for="edidevordernum" class="col-lg-6 control-label">Delivery Order Number</label>
                                    <div class="col-lg-6">
                                        <input class="form-control" id="edidevordernum" placeholder="Delivery Order Number" type="text" />
                                    </div>
                                </div>
                                <div class="form-group">
                                    <label for="edilinecount" class="col-lg-6 control-label">Line Count</label>
                                    <div class="col-lg-6">
                                        <input class="form-control" id="edilinecount" placeholder="Line Count" type="text" />
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
                            <button id="cmdsavegendata" type="button" class="btn btn-primary">Guardar</button>
                            <button id="cmdprintlabel" type="button" class="btn btn-success">Generar Archivo EDI</button>
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
    <script src="app/js/frmnewfile.js"></script>
</body>
</html>
