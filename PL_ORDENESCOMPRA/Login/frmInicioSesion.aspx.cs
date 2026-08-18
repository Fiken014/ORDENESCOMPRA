using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using DAL_ORDENESCOMPRA.ENTIDADES;
using BLL_ORDENESCOMPRA.ENTIDADES;

namespace PL_ORDENESCOMPRA.Login
{
    public partial class frmInicioSesion : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }


        [WebMethod]
        public static string InicioSesionUsuarios(List<string> obj_Parametros_JS)
        {
            try
            {
                string _mensaje = string.Empty;

                //Objetos de la entidad con la que estamos trabajando
                cls_Usuarios_DAL obj_Usuarios_DAL = new cls_Usuarios_DAL();
                cls_Usuarios_BLL obj_Usuarios_BLL = new cls_Usuarios_BLL();

                //Descomponemos los valores que nos envíe el js y lo asignamos a nuestro objeto 
                obj_Usuarios_DAL.sCorreo = obj_Parametros_JS[0].ToString();
                obj_Usuarios_DAL.sPassword = obj_Parametros_JS[1].ToString();

                //Ejecutar en lógica de negocio el proceso o la accion necesaria
                obj_Usuarios_BLL.Inicio_Sesion_Usuarios(ref obj_Usuarios_DAL);
                //Recuperamos y evaluamos los valores scalares y / o de respuesta de BD 
                if (obj_Usuarios_DAL.sValorScalar == "-1")
                {
                    _mensaje = "-1" + "<SPLITER>" + "El usuario se encuentra inactivo, por favor contacte al administrador del sistema.";
                }
                else if (obj_Usuarios_DAL.sValorScalar == "0")
                {
                    _mensaje = "0" + "<SPLITER>" + "Las credenciaes de acceso no son válidas. Verifique!!!.";
                }
                else
                {
                    obj_Usuarios_DAL.iId_Usuario = Convert.ToInt32(obj_Usuarios_DAL.sValorScalar);

                    obj_Usuarios_BLL.Obtiene_Informacion_Usuarios(ref obj_Usuarios_DAL);

                    _mensaje = obj_Usuarios_DAL.dtDatos.Rows[0][0].ToString() + "<SPLITER>" +
                            "Bienvenido de nuevo: " + obj_Usuarios_DAL.dtDatos.Rows[0][1].ToString() + " " +
                                                      obj_Usuarios_DAL.dtDatos.Rows[0][2].ToString() + " " +
                                                      obj_Usuarios_DAL.dtDatos.Rows[0][3].ToString() + "<SPLITER>" +
                            obj_Usuarios_DAL.dtDatos.Rows[0][4].ToString() + "<SPLITER>" +
                            obj_Usuarios_DAL.dtDatos.Rows[0][1].ToString() + " " +
                            obj_Usuarios_DAL.dtDatos.Rows[0][2].ToString() + " " +
                            obj_Usuarios_DAL.dtDatos.Rows[0][3].ToString();
                }
                return _mensaje;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        [WebMethod]
        public static string CierreSesionUsuarios(List<string> obj_Parametros_JS)
        {
            try
            {
                String _mensaje = string.Empty;

                cls_Usuarios_DAL Obj_Usuarios_DAL = new cls_Usuarios_DAL();
                cls_Usuarios_BLL Obj_Usuarios_BLL = new cls_Usuarios_BLL();

                //establecemos los atributos que necesitamos del usuario
                Obj_Usuarios_DAL.iId_Usuario = Convert.ToInt32(obj_Parametros_JS[0].ToString());

                //Ejecutamos la logica de negocio de usuarios
                Obj_Usuarios_BLL.Cerrar_Sesion_Usuario(ref Obj_Usuarios_DAL);

                if (Obj_Usuarios_DAL.sValorScalar != "0")
                {
                    _mensaje = Obj_Usuarios_DAL.sValorScalar;
                }

                return _mensaje;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        [WebMethod]
        public static string cargaOpcionesMenuUsuarios(List<string> obj_Parametros_JS)
        {
            try
            {
                string _mensaje = string.Empty;

                cls_Usuarios_DAL obj_Usuarios_DAL = new cls_Usuarios_DAL();
                cls_Usuarios_BLL obj_Usuarios_BLL = new cls_Usuarios_BLL();

                obj_Usuarios_DAL.iId_Usuario = Convert.ToInt32(obj_Parametros_JS[0]);

                obj_Usuarios_BLL.carga_Lista_Opciones_Menu_Usuario(ref obj_Usuarios_DAL);

                if (obj_Usuarios_DAL.dtDatos.Rows.Count != 0)
                {
                    DataView dv_opciones = obj_Usuarios_DAL.dtDatos.DefaultView;
                    dv_opciones.Sort = obj_Usuarios_DAL.dtDatos.Columns[4] + " ASC";

                    foreach (DataRowView row_view in dv_opciones)
                    {
                        _mensaje += "<li><a href='" + row_view[3].ToString() + "'><i class='" + row_view[2].ToString() + "'></i><span>" + row_view[1].ToString() + "</span></a></li>";
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
    }
}