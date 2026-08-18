<%@ Page Title="" Language="C#" MasterPageFile="~/Formularios/frmPrincipalMaster.Master" AutoEventWireup="true" CodeBehind="frmConsultaUsuarios.aspx.cs" Inherits="PL_ORDENESCOMPRA.Formularios.frmConsultaUsuarios" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <script src="https://code.jquery.com/jquery-3.6.0.min.js"></script>
    

    <nav aria-label="breadcrumb">
      <ol class="breadcrumb my-breadcrumb">
        <li class="breadcrumb-item"><a href="frmPrincipal.aspx">Inicio</a></li>
        <li class="breadcrumb-item active" aria-current="page">Consulta de Usuarios</li>
      </ol>
    </nav>
    <div class="welcome-msg pt-3 pb-4">
      <h1>Hola <span class="text-primary" id="nombreUsuario"></span>, Bienvenido</h1>
      <p id="emlUsuario"></p>
    </div>

    <div class="card card_border py-2 mb-4">
		<div class="cards__heading">
            <h3>Filtros de Búsqueda de Usuarios <span></span></h3>
        </div>
        <div class="card-body">
            <form action="javascript: cargaListaUsuarios()" method="post">
               <div class="form-row">
                    <div class="form-group col-md-6">
                        <label for="bsqCorreo" class="input__label">Correo</label>
                        <input type="text" class="form-control input-style" id="bsqCorreo"
                            placeholder="Correo de Usuario" maxlength="50">
                    </div>
                </div>
                <div class="form-row">
                    <div class="form-group col-md-6">
                        <label for="bsqUsuario" class="input__label">Usuario</label>
                        <input type="text" class="form-control input-style" id="bsqUsuario"
                            placeholder="Nombre de Usuario" maxlength="50">
                    </div>
                    <div class="form-group col-md-6">
                        <label for="bsqEstado" class="input__label">Estado</label>
                        <select id="bsqEstado" class="form-control input-style">
                            <option value="Activo">Activo</option>
                            <option value="Inactivo">Inactivo</option>
                        </select>
                    </div>
                </div>
                <button type="submit" class="btn btn-primary btn-style mt-4">Buscar</button>
                <button type="button" class="btn btn-primary btn-style mt-4" onclick="javascript: crearUsuario()">Crear</button>
            </form>
        </div>
    </div>

    <div class="card card_border py-2 mb-4">
		<div class="cards__heading">
            <h3>Resultados de Búsqueda de Usuarios <span></span></h3>
        </div>
        <div class="card-body">
            <table id="tblUsuarios">
            <%--Aquí se carga el contenido dinámico de la tabla--%>
            </table>
        </div>
    </div>

    <script src="../JavaScript/Usuarios.js"></script>
</asp:Content>
