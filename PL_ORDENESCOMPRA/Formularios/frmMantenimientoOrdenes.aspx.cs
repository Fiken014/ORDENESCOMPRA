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
    public partial class frmMantenimientoOrdenes : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        [WebMethod]
        public static string CargaInfoOrden(List<string> obj_Parametros_JS)
        {
            try
            {
                string _mensaje = string.Empty;

                cls_Ordenes_DAL obj_Ordenes_DAL = new cls_Ordenes_DAL();
                cls_Ordenes_BLL obj_Ordenes_BLL = new cls_Ordenes_BLL();

                obj_Ordenes_DAL.iIdOrden = Convert.ToInt32(obj_Parametros_JS[0].ToString());

                if (obj_Ordenes_DAL.iIdOrden != 0)
                {
                    //Ejecutar en lógica de negocio el proceso o la accion necesaria
                    obj_Ordenes_BLL.Obtiene_Informacion_Orden(ref obj_Ordenes_DAL);

                    if (obj_Ordenes_DAL.dtDatos.Rows.Count != 0)
                    {
                        _mensaje = obj_Ordenes_DAL.dtDatos.Rows[0][0].ToString() + "<SPLITER>" +
                            obj_Ordenes_DAL.dtDatos.Rows[0][1].ToString() + "<SPLITER>" +
                            obj_Ordenes_DAL.dtDatos.Rows[0][2].ToString() + "<SPLITER>" +
                            obj_Ordenes_DAL.dtDatos.Rows[0][3].ToString() + "<SPLITER>" +
                            obj_Ordenes_DAL.dtDatos.Rows[0][4].ToString() + "<SPLITER>" +
                            obj_Ordenes_DAL.dtDatos.Rows[0][5].ToString() + "<SPLITER>" +
                            obj_Ordenes_DAL.dtDatos.Rows[0][6].ToString() + "<SPLITER>" +
                            obj_Ordenes_DAL.dtDatos.Rows[0][7].ToString();
                    }
                    else
                    {
                        _mensaje = "No se encontraron registros";
                    }
                }
                return _mensaje;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        [WebMethod]
        public static string MantenimientoOrden(List<string> obj_Parametros_JS)
        {
            try
            {
                string _mensaje = string.Empty;

                //Objetos de la entidad con la que estamos trabajando
                cls_Ordenes_DAL obj_Ordenes_DAL = new cls_Ordenes_DAL();
                cls_Ordenes_BLL obj_Ordenes_BLL = new cls_Ordenes_BLL();

                //Descomponemos los valores que nos envíe el js y lo asignamos a nuestro objeto 
                obj_Ordenes_DAL.iIdOrden = Convert.ToInt32(obj_Parametros_JS[0].ToString());
                obj_Ordenes_DAL.sSolicitante = obj_Parametros_JS[1].ToString();
                obj_Ordenes_DAL.iDiasCredito = Convert.ToInt32(obj_Parametros_JS[2].ToString());
                obj_Ordenes_DAL.dFecha_Orden = Convert.ToDateTime(obj_Parametros_JS[3].ToString());
                obj_Ordenes_DAL.iIdProveedor = Convert.ToInt32(obj_Parametros_JS[4].ToString());
                obj_Ordenes_DAL.sTipoOrden = obj_Parametros_JS[5].ToString();
                obj_Ordenes_DAL.sDescripcion = obj_Parametros_JS[6].ToString();
                obj_Ordenes_DAL.sEstado = obj_Parametros_JS[7].ToString();
                obj_Ordenes_DAL.iIdUsuarioGlobal = Convert.ToInt32(obj_Parametros_JS[8].ToString());

                if (obj_Ordenes_DAL.iIdOrden == 0)
                {
                    obj_Ordenes_BLL.crearOrdenes(ref obj_Ordenes_DAL);
                }
                else
                {
                    obj_Ordenes_BLL.modificarOrdenes(ref obj_Ordenes_DAL);
                }

                if (obj_Ordenes_DAL.sValorScalar == "-1")
                {
                    _mensaje = "-1" + "<SPLITER>" + "Ya existe un registro con la misma información.";
                }
                else if (obj_Ordenes_DAL.sValorScalar == "0")
                {
                    _mensaje = "0" + "<SPLITER>" + "Ocurrió un error al intentar guardar la información del registro. Intente nuevamente.";
                }
                else
                {
                    _mensaje = obj_Ordenes_DAL.sValorScalar + "<SPLITER>" + "Información guardada de forma correcta.";
                }

                return _mensaje;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        [WebMethod]
        public static string EliminarOrdenes(List<string> obj_Parametros_JS)
        {
            try
            {
                string _mensaje = string.Empty;

                //Objetos de la entidad con la que estamos trabajando
                cls_Ordenes_DAL obj_Ordenes_DAL = new cls_Ordenes_DAL();
                cls_Ordenes_BLL obj_Ordenes_BLL = new cls_Ordenes_BLL();

                //Descomponemos los valores que nos envíe el js y lo asignamos a nuestro objeto 
                obj_Ordenes_DAL.iIdOrden = Convert.ToInt32(obj_Parametros_JS[0].ToString());
                obj_Ordenes_DAL.iIdUsuarioGlobal = Convert.ToInt32(obj_Parametros_JS[1].ToString());

                obj_Ordenes_BLL.eliminarOrdenes(ref obj_Ordenes_DAL);

                if (obj_Ordenes_DAL.sValorScalar == "-1")
                {
                    _mensaje = "-1" + "<SPLITER>" + "Existen registros con dependencias asociados a la información que desea eliminar. Verifique!!!.";
                }
                else if (obj_Ordenes_DAL.sValorScalar == "0")
                {
                    _mensaje = "0" + "<SPLITER>" + "Ocurrió un error al intentar eliminar la información del registro. Intente nuevamente.";
                }
                else
                {
                    _mensaje = obj_Ordenes_DAL.sValorScalar + "<SPLITER>" + "Información eliminada de forma correcta.";
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