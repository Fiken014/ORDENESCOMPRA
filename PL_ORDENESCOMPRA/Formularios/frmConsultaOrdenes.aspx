<%@ Page Title="" Language="C#" MasterPageFile="~/Formularios/frmPrincipalMaster.Master" AutoEventWireup="true" CodeBehind="frmConsultaOrdenes.aspx.cs" Inherits="PL_ORDENESCOMPRA.Formularios.frmConsultaOrdenes" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <script src="https://code.jquery.com/jquery-3.6.0.min.js"></script>
    

    <nav aria-label="breadcrumb">
      <ol class="breadcrumb my-breadcrumb">
        <li class="breadcrumb-item"><a href="frmPrincipal.aspx">Inicio</a></li>
        <li class="breadcrumb-item active" aria-current="page">Consulta de Órdenes de Compra</li>
      </ol>
    </nav>
    <div class="welcome-msg pt-3 pb-4">
      <h1>Hola <span class="text-primary" id="nombreUsuario"></span>, Bienvenido</h1>
      <p id="emlUsuario"></p>
    </div>

    <div class="card card_border py-2 mb-4">
		<div class="cards__heading">
            <h3>Filtros de Búsqueda de Órdenes de Compra <span></span></h3>
        </div>
        <div class="card-body">
            <form action="javascript: cargaListaOrdenes()" method="post">
               <div class="form-row">
                    <div class="form-group col-md-6">
                        <label for="bsqSolicitante" class="input__label">Orden</label>
                        <input type="text" class="form-control input-style" id="bsqSolicitante"
                            placeholder="Nombre de Solicitante" maxlength="50">
                    </div>
                    <div class="form-group col-md-6">
                        <label for="bsqProveedor" class="input__label">Proveedor</label>
                        <select id="bsqProveedor" class="form-control input-style">
                            
                        </select>
                    </div>
                </div>
                <button type="submit" class="btn btn-primary btn-style mt-4">Buscar</button>
                <button type="button" class="btn btn-primary btn-style mt-4" onclick="javascript: crearOrden()">Crear</button>
            </form>
        </div>
    </div>

    <div class="card card_border py-2 mb-4">
		<div class="cards__heading">
            <h3>Resultados de Búsqueda de Órdenes de Compra <span></span></h3>
        </div>
        <div class="card-body">
            <table id="tblOrdenes">
            <%--Aquí se carga el contenido dinámico de la tabla--%>
            </table>
        </div>
    </div>

    <script src="../JavaScript/Ordenes.js"></script>
</asp:Content>
