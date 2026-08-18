<%@ Page Title="" Language="C#" MasterPageFile="~/Formularios/frmPrincipalMaster.Master" AutoEventWireup="true" CodeBehind="frmMantenimientoOrdenes.aspx.cs" Inherits="PL_ORDENESCOMPRA.Formularios.frmMantenimientoOrdenes" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <script src="https://code.jquery.com/jquery-3.6.0.min.js"></script>

    <nav aria-label="breadcrumb">
      <ol class="breadcrumb my-breadcrumb">
        <li class="breadcrumb-item"><a href="frmPrincipal.aspx">Inicio</a></li>
          <li class="breadcrumb-item"><a href="frmConsultaOrdenes.aspx">Consulta de Órdenes de Compra</a></li>
        <li class="breadcrumb-item active" aria-current="page">Mantenimiento de Órdenes de Compra</li>
      </ol>
    </nav>
    <div class="welcome-msg pt-3 pb-4">
      <h1>Hola <span class="text-primary" id="nombreUsuario"></span>, Bienvenido</h1>
      <p id="emlUsuario"></p>
    </div>

    <div class="card card_border py-2 mb-4">
		<div class="cards__heading">
            <h3>Mantenimiento de Información de Órdenes de Compra <span></span></h3>
        </div>
        <div class="card-body">
            <form action="javascript: mantenimientoOrden()" method="post">
               <div class="form-row">
                    <div class="form-group col-md-6">
                        <label for="txtSolicitante" class="input__label">Solicitante Orden</label>
                        <input type="text" class="form-control input-style" id="txtSolicitante"
                            placeholder="Solicitante de Orden" maxlength="50" required="">
                    </div>
                </div>
                <div class="form-row">
                    <div class="form-group col-md-6">
                        <label for="txtDiasCredito" class="input__label">Días de Crédito</label>
                        <input type="number" class="form-control input-style" id="txtDiasCredito"
                            placeholder="Cantidad de Días de Crédito" required="" min="0" max="99" maxlenght="2">
                    </div>
                    <div class="form-group col-md-6">
                        <label for="txtFecOrden" class="input__label">Fecha Orden</label>
                        <input type="date" class="form-control input-style" id="txtFecOrden"
                             required="">
                    </div>
                </div>
                <div class="form-row">
                    <div class="form-group col-md-6">
                        <label for="cboProveedor" class="input__label">Proveedor</label>
                        <select id="cboProveedor" class="form-control input-style">
                            
                        </select>
                    </div>
                    <div class="form-group col-md-6">
                        <label for="cboTipoOrden" class="input__label">Tipo Orden</label>
                        <select id="cboTipoOrden" class="form-control input-style">
                            <option value="C">Contado</option>
                            <option value="F">Crédito</option>
                        </select>
                    </div>
                </div>
                <div class="form-row">
                    <div class="form-group col-md-6">
                        <label for="txtDsc" class="input__label">Descrcipción</label>
                        <input type="text" class="form-control input-style" id="txtDsc"
                            placeholder="Descrcipción de la Orden" required="" maxlenght="500">
                    </div>
                    <div class="form-group col-md-6">
                        <label for="cboSts" class="input__label">Estado</label>
                        <select id="cboSts" class="form-control input-style">
                            <option value="A">Activo</option>
                            <option value="I">Inactivo</option>
                        </select>
                    </div>
                </div>

                <button type="submit" class="btn btn-primary btn-style mt-4">Guardar</button>
                <button type="button" class="btn btn-primary btn-style mt-4" onclick="javascript: regresar()">Regresar</button>
            </form>
        </div>
    </div>

    <script src="../JavaScript/Ordenes.js"></script>
</asp:Content>
