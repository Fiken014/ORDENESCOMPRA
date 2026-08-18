using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Services;
using DAL_ORDENESCOMPRA.ENTIDADES;
using BLL_ORDENESCOMPRA.ENTIDADES;
namespace PL_ORDENESCOMPRA.Formularios
{
    public partial class frmMantenimientoProductosXOrden : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        [WebMethod]
        public static string CargaListaProductosCombo(List<string> obj_Parametros_JS)
        {
            try
            {
                string _mensaje = string.Empty;

                //Objetos de la entidad con la que estamos trabajando
                cls_Productos_DAL obj_Productos_DAL = new cls_Productos_DAL();
                cls_Productos_BLL obj_Productos_BLL = new cls_Productos_BLL();

                //Ejecutar en lógica de negocio el proceso o la accion necesaria
                obj_Productos_BLL.listarFiltrarProductos(ref obj_Productos_DAL);

                //Evaluar los resultados de la ejecución de la lógica de negocio
                if (obj_Productos_DAL.dtDatos.Rows.Count != 0)
                {
                    for (int i = 0; i < obj_Productos_DAL.dtDatos.Rows.Count; i++)
                    {
                        _mensaje += "<option value=" + obj_Productos_DAL.dtDatos.Rows[i][0].ToString() +
                            ">" + obj_Productos_DAL.dtDatos.Rows[i][1].ToString() + "</option>";
                    }
                }
                else
                {
                    _mensaje = "No se encontraron registros";
                }

                return _mensaje;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        [WebMethod]
        public static string CargaListaProductosXOrden(List<string> obj_Parametros_JS)
        {
            try
            {
                string _mensaje = string.Empty;

                //Objetos de la entidad con la que estamos trabajando
                cls_ProductosXOrden_DAL obj_ProductosXOrden_DAL = new cls_ProductosXOrden_DAL();
                cls_ProductosXOrden_BLL obj_ProductosXOrden_BLL = new cls_ProductosXOrden_BLL();

                //Descomponemos los valores que nos envíe el js y lo asignamos a nuestro objeto 
                obj_ProductosXOrden_DAL.iId_Orden = Convert.ToInt32(obj_Parametros_JS[0].ToString());

                //Ejecutar en lógica de negocio el proceso o la accion necesaria
                obj_ProductosXOrden_BLL.listarFiltrarProductosXOrden(ref obj_ProductosXOrden_DAL);


                //Evaluar los resultados de la ejecución de la lógica de negocio
                if (obj_ProductosXOrden_DAL.dtDatos.Rows.Count != 0)
                {
                    _mensaje = "" +
                        "<thead>" +
                        "<tr>" +
                        "<th>Producto</th>" +
                        "<th style='text-align:center'>Eliminar</th>" +
                        "</tr>" +
                        "</thead>" +
                        "<tbody>";

                    for (int i = 0; i < obj_ProductosXOrden_DAL.dtDatos.Rows.Count; i++)
                    {
                        _mensaje += "<tr>" +
                                    "<td>" + obj_ProductosXOrden_DAL.dtDatos.Rows[i][1].ToString() + "</td>" +
                                     "<td style='text-align:center'><i class='fa fa-trash-o' onclick='javascript:eliminaProductoXOrden(" + obj_ProductosXOrden_DAL.dtDatos.Rows[i][0].ToString() + ")' style='cursor:pointer'></i></td>" +
                                     "</tr>";
                    }

                    _mensaje += "</tbody>";

                }
                else
                {
                    _mensaje = "No se encontraron registros";
                }

                return _mensaje;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        [WebMethod]
        public static string AsignaProductosXOrden(List<string> obj_Parametros_JS)
        {
            try
            {
                string _mensaje = string.Empty;

                //Objetos de la entidad con la que estamos trabajando
                cls_ProductosXOrden_DAL obj_ProductosXOrden_DAL = new cls_ProductosXOrden_DAL();
                cls_ProductosXOrden_BLL obj_ProductosXOrden_BLL = new cls_ProductosXOrden_BLL();

                //Descomponemos los valores que nos envíe el js y lo asignamos a nuestro objeto 
                obj_ProductosXOrden_DAL.iId_Orden = Convert.ToInt32(obj_Parametros_JS[0].ToString());
                obj_ProductosXOrden_DAL.iId_Producto = Convert.ToInt32(obj_Parametros_JS[1].ToString());
                obj_ProductosXOrden_DAL.iIdUsuarioGlobal = Convert.ToInt32(obj_Parametros_JS[2].ToString());

                obj_ProductosXOrden_BLL.asignarProductosXOrden(ref obj_ProductosXOrden_DAL);

                if (obj_ProductosXOrden_DAL.sValorScalar == "-1")
                {
                    _mensaje = "-1" + "<SPLITER>" + "El Producto ya ha sido asignado al vehículo. Verifique!!!";
                }
                else if (obj_ProductosXOrden_DAL.sValorScalar == "0")
                {
                    _mensaje = "0" + "<SPLITER>" + "Ocurrió un error al intentar guardar la información del registro. Intente nuevamente.";
                }
                else
                {
                    _mensaje = obj_ProductosXOrden_DAL.sValorScalar + "<SPLITER>" + "Información guardada de forma correcta.";
                }

                return _mensaje;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        [WebMethod]
        public static string EliminaProductosXOrden(List<string> obj_Parametros_JS)
        {
            try
            {
                string _mensaje = string.Empty;

                //Objetos de la entidad con la que estamos trabajando
                cls_ProductosXOrden_DAL obj_ProductosXOrden_DAL = new cls_ProductosXOrden_DAL();
                cls_ProductosXOrden_BLL obj_ProductosXOrden_BLL = new cls_ProductosXOrden_BLL();

                //Descomponemos los valores que nos envíe el js y lo asignamos a nuestro objeto 
                obj_ProductosXOrden_DAL.iId_Orden = Convert.ToInt32(obj_Parametros_JS[0].ToString());
                obj_ProductosXOrden_DAL.iId_Producto_Orden = Convert.ToInt32(obj_Parametros_JS[1].ToString());
                obj_ProductosXOrden_DAL.iIdUsuarioGlobal = Convert.ToInt32(obj_Parametros_JS[2].ToString());

                obj_ProductosXOrden_BLL.eliminarProductosXOrden(ref obj_ProductosXOrden_DAL);

                if (obj_ProductosXOrden_DAL.sValorScalar == "-1")
                {
                    _mensaje = "-1" + "<SPLITER>" + "No se pudo completar el proceso.";
                }
                else if (obj_ProductosXOrden_DAL.sValorScalar == "0")
                {
                    _mensaje = "0" + "<SPLITER>" + "Ocurrió un error al intentar guardar la información del registro. Intente nuevamente.";
                }
                else
                {
                    _mensaje = obj_ProductosXOrden_DAL.sValorScalar + "<SPLITER>" + "Información actualizada de forma correcta.";
                }

                return _mensaje;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}