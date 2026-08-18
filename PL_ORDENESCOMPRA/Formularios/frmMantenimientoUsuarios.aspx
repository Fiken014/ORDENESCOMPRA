<%@ Page Title="" Language="C#" MasterPageFile="~/Formularios/frmPrincipalMaster.Master" AutoEventWireup="true" CodeBehind="frmMantenimientoUsuarios.aspx.cs" Inherits="PL_ORDENESCOMPRA.Formularios.frmMantenimientoUsuarios" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <script src="https://code.jquery.com/jquery-3.6.0.min.js"></script>

    <nav aria-label="breadcrumb">
      <ol class="breadcrumb my-breadcrumb">
        <li class="breadcrumb-item"><a href="frmPrincipal.aspx">Inicio</a></li>
          <li class="breadcrumb-item"><a href="frmConsultaUsuarios.aspx">Consulta de Usuarios</a></li>
        <li class="breadcrumb-item active" aria-current="page">Mantenimiento de Usuarios</li>
      </ol>
    </nav>
    <div class="welcome-msg pt-3 pb-4">
      <h1>Hola <span class="text-primary" id="nombreUsuario"></span>, Bienvenido</h1>
      <p id="emlUsuario"></p>
    </div>

    <div class="card card_border py-2 mb-4">
		<div class="cards__heading">
            <h3>Mantenimiento de Información de Usuarios <span></span></h3>
        </div>
        <div class="card-body">
            <form action="javascript: mantenimientoUsuario()" method="post">
               <div class="form-row">
                    <div class="form-group col-md-6">
                        <label for="txtEml" class="input__label">Correo</label>
                        <input type="email" class="form-control input-style" id="txtEml"
                            placeholder="Correo del Usuario" required="" maxlenght="50">
                    </div>
                   <div class="form-group col-md-6">
                        <label for="txtNom" class="input__label">Nombre</label>
                        <input type="text" class="form-control input-style" id="txtNom"
                            placeholder="Nombre del Usuario" required="" maxlenght="100">
                    </div>
                </div>
                <div class="form-row">
                    <div class="form-group col-md-6">
                        <label for="txtApe1" class="input__label">Apellido 1</label>
                        <input type="text" class="form-control input-style" id="txtApe1"
                            placeholder="Apellido 1 del Usuario" required="" maxlenght="100">
                    </div>
                    <div class="form-group col-md-6">
                       <label for="txtApe2" class="input__label">Apellido 2</label>
                        <input type="text" class="form-control input-style" id="txtApe2"
                            placeholder="Apellido 2 del Usuario" required="" maxlenght="100">
                    </div>
                </div>
                <div class="form-row">
                    <div class="form-group col-md-6">
                       <label for="txtPwd" class="input__label">Password</label>
                        <input type="password" class="form-control input-style" id="txtPwd"
                            placeholder="Password" required="" maxlenght="100">
                    </div>
                    <div class="form-group col-md-6">
                        <label for="cboSts" class="input__label">Estado</label>
                        <select id="cboSts" class="form-control input-style">
                            <option value="Activo">Activo</option>
                            <option value="Inactivo">Inactivo</option>
                        </select>
                    </div>
                </div>
                

                <button type="submit" class="btn btn-primary btn-style mt-4">Guardar</button>
                <button type="button" class="btn btn-primary btn-style mt-4" onclick="javascript: regresar()">Regresar</button>
            </form>
        </div>
    </div>

    <script src="../JavaScript/Usuarios.js"></script>
</asp:Content>
