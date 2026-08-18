<%@ Page Title="" Language="C#" MasterPageFile="~/Formularios/frmPrincipalMaster.Master" AutoEventWireup="true" CodeBehind="frmMantenimientoProveedores.aspx.cs" Inherits="PL_ORDENESCOMPRA.Formularios.frmMantenimientoProveedores" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <script src="https://code.jquery.com/jquery-3.6.0.min.js"></script>

    <nav aria-label="breadcrumb">
      <ol class="breadcrumb my-breadcrumb">
        <li class="breadcrumb-item"><a href="frmPrincipal.aspx">Inicio</a></li>
          <li class="breadcrumb-item"><a href="frmConsultaProveedores.aspx">Consulta de Proveedores</a></li>
        <li class="breadcrumb-item active" aria-current="page">Mantenimiento de Proveedores</li>
      </ol>
    </nav>
    <div class="welcome-msg pt-3 pb-4">
      <h1>Hola <span class="text-primary" id="nombreUsuario"></span>, Bienvenido</h1>
      <p id="emlUsuario"></p>
    </div>

    <div class="card card_border py-2 mb-4">
		<div class="cards__heading">
            <h3>Mantenimiento de Información de Proveedores <span></span></h3>
        </div>
        <div class="card-body">
            <form action="javascript: mantenimientoProveedor()" method="post">
               <div class="form-row">
                    <div class="form-group col-md-6">
                        <label for="txtProveedor" class="input__label">Proveedor</label>
                        <input type="text" class="form-control input-style" id="txtProveedor"
                            placeholder="Nombre de Proveedor" maxlength="50" required="">
                    </div>
                    <div class="form-group col-md-6">
                        <label for="txtTel" class="input__label">Teléfono</label>
                        <input type="number" class="form-control input-style" id="txtTel"
                            placeholder="Teléfono del Proveedor" required="" min="0" max="99999999" maxlenght="8">
                    </div>
                </div>
                <div class="form-row">
                    <div class="form-group col-md-6">
                        <label for="txtEml" class="input__label">Correo</label>
                        <input type="email" class="form-control input-style" id="txtEml"
                            placeholder="Correo del Proveedor" required="" maxlenght="50">
                    </div>
                    <div class="form-group col-md-6">
                        <label for="cboPais" class="input__label">País Origen</label>
                        <select id="cboPais" class="form-control input-style">
                            <option value="ALE">Alemania</option>
                            <option value="FRA">Francia</option>
                            <option value="JAP">Japón</option>
                            <option value="CHI">China</option>
                            <option value="EU">Estados Unidos</option>
                            <option value="UK">Reino Unido</option>
                        </select>
                    </div>
                </div>
                <div class="form-row">
                    <div class="form-group col-md-6">
                        <label for="txtDir" class="input__label">Dirección</label>
                        <input type="text" class="form-control input-style" id="txtDir"
                            placeholder="Dirección del Proveedor" required="" maxlenght="500">
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

    <script src="../JavaScript/Proveedores.js"></script>
</asp:Content>
