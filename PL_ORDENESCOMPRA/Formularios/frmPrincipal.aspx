<%@ Page Title="" Language="C#" MasterPageFile="~/Formularios/frmPrincipalMaster.Master" AutoEventWireup="true" CodeBehind="frmPrincipal.aspx.cs" Inherits="PL_ORDENESCOMPRA.Formularios.frmPrincipal" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <script src="https://code.jquery.com/jquery-3.6.0.min.js"></script>
    <link rel="stylesheet" type="text/css" href="https://cdn.datatables.net/1.11.5/css/jquery.dataTables.min.css"/>
    <script src="https://cdn.datatables.net/1.11.5/js/jquery.dataTables.min.js"></script>

    <nav aria-label="breadcrumb">
      <ol class="breadcrumb my-breadcrumb">
        <li class="breadcrumb-item"><a href="frmPanel.aspx">Inicio</a></li>
        <li class="breadcrumb-item active" aria-current="page">Panel de Principal</li>
      </ol>
    </nav>
    <div class="welcome-msg pt-3 pb-4">
      <h1>Hola <span class="text-primary" id="nombreUsuario"></span>, Bienvenido</h1>
      <p id="emlUsuario">Email</p>
    </div>

    <!-- statistics data -->
    <div class="statistics">
      <div class="row">
        <div class="col-xl-6 pr-xl-2">
          <div class="row">
            <div class="col-sm-6 pr-sm-2 statistics-grid">
              <div class="card card_border border-primary-top p-4">
                <i class="lnr lnr-laptop"> </i>
                <h3 id="totalUsuarios" class="text-primary number"></h3>
                <p class="stat-text">Usuarios Registrados</p>
              </div>
            </div>
            <div class="col-sm-6 pl-sm-2 statistics-grid">
              <div class="card card_border border-primary-top p-4">
                <i class="lnr lnr-book"> </i>
                <h3 id="totalProductos" class="text-secondary number"></h3>
                <p class="stat-text">Productos Registrados</p>
              </div>
            </div>
          </div>
        </div>
        <div class="col-xl-6 pl-xl-2">
          <div class="row">
            <div class="col-sm-6 pr-sm-2 statistics-grid">
              <div class="card card_border border-primary-top p-4">
                <i class="lnr lnr-apartment"> </i>
                <h3 id="totalProveedores" class="text-success number"></h3>
                <p class="stat-text">Proveedores Registrados</p>
              </div>
            </div>
            <div class="col-sm-6 pl-sm-2 statistics-grid">
              <div class="card card_border border-primary-top p-4">
                <i class="lnr lnr-book"> </i>
                <h3 id="totalOrdenes" class="text-danger number"></h3>
                <p class="stat-text">Órdenes Registradas</p>
              </div>
            </div>
          </div>
        </div>
      </div>
    </div>
    <!-- //statistics data -->

    <!-- charts -->
    <div class="chart">
      <div class="row">
        <div class="col-lg-6 pl-lg-2 chart-grid">
          <div class="card text-center card_border">
            <div class="card-header chart-grid__header">
              Gráfico Pastel de Órdenes de Compra x Proveedor
            </div>
            <div class="card-body">
              <!-- line chart -->
              <div id="container">
                <canvas id="grfPersonasXPerfilPie"></canvas>
              </div>
              <!-- //line chart -->
            </div>
            <div class="card-footer text-muted chart-grid__footer">
              Actualizado Justo Ahora
            </div>
          </div>
        </div>
        <div class="col-lg-6 pl-lg-2 chart-grid">
          <div class="card text-center card_border">
            <div class="card-header chart-grid__header">
              Gráfico de Barras de Órdenes de Compra x Proveedor
            </div>
            <div class="card-body">
              <!-- line chart -->
              <div id="container">
                <canvas id="grfPersonasXSucursalPie"></canvas>
              </div>
              <!-- //line chart -->
            </div>
            <div class="card-footer text-muted chart-grid__footer">
              Actualizado Justo Ahora
            </div>
          </div>
        </div>
      </div>
    </div>
    <!-- //charts -->

    <!-- chart js -->
    <script src="../Base/assets/js/Chart.min.js"></script>
    <script src="../Base/assets/js/utils.js"></script>
    <!-- //chart js -->

    <!-- Different scripts of charts.  Ex.Barchart, Linechart -->
    <script src="../Base/assets/js/bar.js"></script>
    <script src="../Base/assets/js/linechart.js"></script>
    <!-- //Different scripts of charts.  Ex.Barchart, Linechart -->

    <script src="../JavaScript/Principal.js"></script>
</asp:Content>
