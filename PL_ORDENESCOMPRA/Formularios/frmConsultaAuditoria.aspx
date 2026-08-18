<%@ Page Title="" Language="C#" MasterPageFile="~/Formularios/frmPrincipalMaster.Master" AutoEventWireup="true" CodeBehind="frmConsultaAuditoria.aspx.cs" Inherits="PL_ORDENESCOMPRA.Formularios.frmConsultaAuditoria" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <script src="https://code.jquery.com/jquery-3.6.0.min.js"></script>
    

    <nav aria-label="breadcrumb">
      <ol class="breadcrumb my-breadcrumb">
        <li class="breadcrumb-item"><a href="frmPrincipal.aspx">Inicio</a></li>
        <li class="breadcrumb-item active" aria-current="page">Consulta de Auditoria</li>
      </ol>
    </nav>
    <div class="welcome-msg pt-3 pb-4">
      <h1>Hola <span class="text-primary" id="nombreUsuario"></span>, Bienvenido</h1>
      <p id="emlUsuario"></p>
    </div>

    <div class="card card_border py-2 mb-4">
		<div class="cards__heading">
            <h3>Filtros de Búsqueda de Auditoría <span></span></h3>
        </div>
        <div class="card-body">
            <form action="javascript: cargaListaAuditoria()" method="post">
               <div class="form-row">
                    <div class="form-group col-md-6">
                        <label for="bsqUsuario" class="input__label">Usuario</label>
                        <select id="bsqUsuario" class="form-control input-style">
                            
                        </select>
                    </div>
                   <div class="form-group col-md-6">
                        <label for="bsqAccion" class="input__label">Acción</label>
                        <select id="bsqAccion" class="form-control input-style">
                            <option value="T">Todas</option>
                            <option value="A">Actualizar</option>
                            <option value="I">Insertar</option>
                            <option value="E">Eliminar</option>
                        </select>
                    </div>
                    
                </div>
                <div class="form-row">
                    <div class="form-group col-md-6">
                        <label for="bsqFdd" class="input__label">Fecha Desde</label>
                        <input type="date" class="form-control input-style" id="bsqFdd"
                             required="">
                    </div>
                   <div class="form-group col-md-6">
                        <label for="bsqFhh" class="input__label">Fecha Hasta</label>
                        <input type="date" class="form-control input-style" id="bsqFhh"
                             required="">
                    </div>
                    
                </div>
                <button type="submit" class="btn btn-primary btn-style mt-4">Buscar</button>
            </form>
        </div>
    </div>

    <div class="card card_border py-2 mb-4">
		<div class="cards__heading">
            <h3>Resultados de Búsqueda de Auditorías <span></span></h3>
        </div>
        <div class="card-body">
            <table id="tblAuditoria">
            <%--Aquí se carga el contenido dinámico de la tabla--%>
            </table>
        </div>
    </div>

    <script src="../JavaScript/Auditoria.js"></script>
</asp:Content>
