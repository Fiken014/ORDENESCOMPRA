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
    public partial class frmMantenimientoProveedores : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        [WebMethod]
        public static string CargaInfoProveedor(List<string> obj_Parametros_JS)
        {
            try
            {
                string _mensaje = string.Empty;

                //Objetos de la entidad con la que estamos trabajando
                cls_Proveedores_DAL obj_Proveedores_DAL = new cls_Proveedores_DAL();
                cls_Proveedores_BLL obj_Proveedores_BLL = new cls_Proveedores_BLL();

                //Descomponemos los valores que nos envíe el js y lo asignamos a nuestro objeto 
                obj_Proveedores_DAL.iIdProveedor = Convert.ToInt32(obj_Parametros_JS[0].ToString());

                if (obj_Proveedores_DAL.iIdProveedor != 0)
                {
                    //Ejecutar en lógica de negocio el proceso o la accion necesaria
                    obj_Proveedores_BLL.Obtiene_Informacion_Proveedor(ref obj_Proveedores_DAL);

                    //Evaluamos la respuesta de la lógica de negocio
                    if (obj_Proveedores_DAL.dtDatos.Rows.Count != 0)
                    {
                        _mensaje = obj_Proveedores_DAL.dtDatos.Rows[0][0].ToString() + "<SPLITER>" +
                                    obj_Proveedores_DAL.dtDatos.Rows[0][1].ToString() + "<SPLITER>" +
                                    obj_Proveedores_DAL.dtDatos.Rows[0][2].ToString() + "<SPLITER>" +
                                    obj_Proveedores_DAL.dtDatos.Rows[0][3].ToString() + "<SPLITER>" +
                                    obj_Proveedores_DAL.dtDatos.Rows[0][4].ToString() + "<SPLITER>" +
                                    obj_Proveedores_DAL.dtDatos.Rows[0][5].ToString() + "<SPLITER>" +
                                    obj_Proveedores_DAL.dtDatos.Rows[0][6].ToString() + "<SPLITER>";
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
        public static string MantenimientoProveedores(List<string> obj_Parametros_JS)
        {
            try
            {
                string _mensaje = string.Empty;

                //Objetos de la entidad con la que estamos trabajando
                cls_Proveedores_DAL obj_Proveedores_DAL = new cls_Proveedores_DAL();
                cls_Proveedores_BLL obj_Proveedores_BLL = new cls_Proveedores_BLL();

                //Descomponemos los valores que nos envíe el js y lo asignamos a nuestro objeto 
                obj_Proveedores_DAL.iIdProveedor = Convert.ToInt32(obj_Parametros_JS[0].ToString());
                obj_Proveedores_DAL.sProveedor = obj_Parametros_JS[1].ToString();
                obj_Proveedores_DAL.sTelefono = obj_Parametros_JS[2].ToString();
                obj_Proveedores_DAL.sCorreo = obj_Parametros_JS[3].ToString();
                obj_Proveedores_DAL.sPais = obj_Parametros_JS[4].ToString();
                obj_Proveedores_DAL.sDireccion = obj_Parametros_JS[5].ToString();
                obj_Proveedores_DAL.sEstado = obj_Parametros_JS[6].ToString();
                obj_Proveedores_DAL.iIdUsuarioGlobal = Convert.ToInt32(obj_Parametros_JS[7].ToString());

                /*Si el identificador del valor de la cookie del registro es un 0:: es un dato nuevo vamos a insertar*/
                if (obj_Proveedores_DAL.iIdProveedor == 0)
                {
                    //Ejecutar en la lógica de negocio el proceso o la acción necesaria
                    obj_Proveedores_BLL.crearProveedores(ref obj_Proveedores_DAL);
                }
                else
                {
                    //Ejecutar en la lógica de negocio el proceso o la acción necesaria
                    obj_Proveedores_BLL.modificarProveedores(ref obj_Proveedores_DAL);
                }

                //Evaluamos la respuesta de la lógica de negocio
                if (obj_Proveedores_DAL.sValorScalar == "-1")
                {
                    _mensaje = "-1" + "<SPLITER>" + "Ya existe un registro con la misma información.";
                }
                else if (obj_Proveedores_DAL.sValorScalar == "0")
                {
                    _mensaje = "0" + "<SPLITER>" + "Ocurrió un error al intentar guardar la información del registro. Intente de nuevo.";
                }
                else
                {
                    _mensaje = obj_Proveedores_DAL.sValorScalar + "<SPLITER>" + "Información guardada de forma correcta.";
                }

                return _mensaje;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        [WebMethod]
        public static string EliminarProveedores(List<string> obj_Parametros_JS)
        {
            try
            {
                string _mensaje = string.Empty;

                //Objetos de la entidad con la que estamos trabajando
                cls_Proveedores_DAL obj_Proveedores_DAL = new cls_Proveedores_DAL();
                cls_Proveedores_BLL obj_Proveedores_BLL = new cls_Proveedores_BLL();

                obj_Proveedores_DAL.iIdProveedor = Convert.ToInt32(obj_Parametros_JS[0].ToString());
                obj_Proveedores_DAL.iIdUsuarioGlobal = Convert.ToInt32(obj_Parametros_JS[1].ToString());

                //Ejecutar en la lógica de negocio el proceso o la acción necesaria
                obj_Proveedores_BLL.eliminarProveedores(ref obj_Proveedores_DAL);

                if (obj_Proveedores_DAL.sValorScalar == "-1")
                {
                    _mensaje = "-1" + "<SPLITER>" + "Existen registros con dependencias asociados a la información que desea eliminar. Verifique!!!.";
                }
                else if (obj_Proveedores_DAL.sValorScalar == "0")
                {
                    _mensaje = "0" + "<SPLITER>" + "Ocurrió un error al intentar eliminar la información del registro. Intente nuevamente.";
                }
                else
                {
                    _mensaje = obj_Proveedores_DAL.sValorScalar + "<SPLITER>" + "Información eliminada de forma correcta.";
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