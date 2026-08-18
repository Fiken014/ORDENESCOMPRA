using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using DAL_ORDENESCOMPRA.GESTOR_BD;
using BLL_ORDENESCOMPRA.GESTOR_BD;
using DAL_ORDENESCOMPRA.ENTIDADES;

namespace BLL_ORDENESCOMPRA.ENTIDADES
{
    public class cls_Usuarios_BLL
    {
        public void Inicio_Sesion_Usuarios(ref cls_Usuarios_DAL obj_Usuarios_DAL)
        {
            try
            {
                cls_GESTOR_BD_DAL obj_BD_DAL = new cls_GESTOR_BD_DAL(); //Objeto de acceso a datos de BD
                cls_GESTOR_BD_BLL obj_BD_BLL = new cls_GESTOR_BD_BLL(); //Objeto de lógica de negocio de BD

                obj_Usuarios_DAL.dtParametros = null;
                obj_Usuarios_DAL.dtParametros = obj_BD_BLL.gestionaParametros(obj_Usuarios_DAL.dtParametros);

                obj_Usuarios_DAL.dtParametros.Rows.Add("@Correo", "6", obj_Usuarios_DAL.sCorreo);
                obj_Usuarios_DAL.dtParametros.Rows.Add("@Password", "6", obj_Usuarios_DAL.sPassword);

                obj_BD_DAL.sNomSP = ConfigurationManager.AppSettings["SP_LogIn_Usuarios"];
                obj_BD_DAL.sIndAxn = "SCALAR";
                obj_BD_DAL.DT_Parametros = obj_Usuarios_DAL.dtParametros;

                obj_BD_BLL.gestionaProcesosComando(ref obj_BD_DAL);

                if (obj_BD_DAL.sMsjErrorBD == string.Empty)
                {
                    obj_Usuarios_DAL.sMSJError = obj_BD_DAL.sMsjErrorBD;
                    obj_Usuarios_DAL.sValorScalar = obj_BD_DAL.sValorScalar;
                }
                else
                {
                    obj_Usuarios_DAL.sMSJError = obj_BD_DAL.sMsjErrorBD;
                    obj_Usuarios_DAL.sValorScalar = null;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void Obtiene_Informacion_Usuarios(ref cls_Usuarios_DAL obj_Usuarios_DAL)
        {
            try
            {
                cls_GESTOR_BD_DAL obj_BD_DAL = new cls_GESTOR_BD_DAL(); //Objeto de acceso a datos de BD
                cls_GESTOR_BD_BLL obj_BD_BLL = new cls_GESTOR_BD_BLL(); //Objeto de lógica de negocio de BD

                obj_Usuarios_DAL.dtParametros = null;
                obj_Usuarios_DAL.dtParametros = obj_BD_BLL.gestionaParametros(obj_Usuarios_DAL.dtParametros);

                obj_Usuarios_DAL.dtParametros.Rows.Add("@IdUsuario", "1", obj_Usuarios_DAL.iId_Usuario);

                obj_BD_DAL.sNomSP = ConfigurationManager.AppSettings["SP_INFO_Usuarios"];
                obj_BD_DAL.DT_Parametros = obj_Usuarios_DAL.dtParametros;
                obj_BD_DAL.sNomTabla = "Usuarios";

                obj_BD_BLL.gestionaProcesosTabla(ref obj_BD_DAL);

                if (obj_BD_DAL.sMsjErrorBD == string.Empty)
                {
                    obj_Usuarios_DAL.dtDatos = obj_BD_DAL.DS.Tables[0];
                }
                else
                {
                    obj_Usuarios_DAL.dtDatos = null;
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void listarFiltrarUsuarios(ref cls_Usuarios_DAL obj_Usuarios_DAL)
        {
            try
            {
                cls_GESTOR_BD_DAL obj_BD_DAL = new cls_GESTOR_BD_DAL(); //Objeto de acceso a datos de BD
                cls_GESTOR_BD_BLL obj_BD_BLL = new cls_GESTOR_BD_BLL(); //Objeto de lógica de negocio de BD

                if (
                    ((obj_Usuarios_DAL.sCorreo == string.Empty) || (obj_Usuarios_DAL.sCorreo == null))
                    &&
                     ((obj_Usuarios_DAL.sNombre == string.Empty) || (obj_Usuarios_DAL.sNombre == null))
                     &&
                     ((obj_Usuarios_DAL.sEstado == string.Empty) || (obj_Usuarios_DAL.sEstado == null))
                    )
                {
                    obj_BD_DAL.sNomSP = ConfigurationManager.AppSettings["SP_LST_Usuarios"];
                    obj_BD_DAL.DT_Parametros = null;
                    obj_BD_DAL.sNomTabla = "Usuarios";
                }
                else 
                {
                    obj_Usuarios_DAL.dtParametros = null;
                    obj_Usuarios_DAL.dtParametros = obj_BD_BLL.gestionaParametros(obj_Usuarios_DAL.dtParametros);

                    obj_Usuarios_DAL.dtParametros.Rows.Add("@Correo", "6", obj_Usuarios_DAL.sCorreo);
                    obj_Usuarios_DAL.dtParametros.Rows.Add("@Nombre", "6", obj_Usuarios_DAL.sNombre);
                    obj_Usuarios_DAL.dtParametros.Rows.Add("@Estado", "6", obj_Usuarios_DAL.sEstado);

                    obj_BD_DAL.sNomSP = ConfigurationManager.AppSettings["SP_FILL_Usuarios"];
                    obj_BD_DAL.DT_Parametros = obj_Usuarios_DAL.dtParametros;
                    obj_BD_DAL.sNomTabla = "Usuarios";
                }

                obj_BD_BLL.gestionaProcesosTabla(ref obj_BD_DAL);

                if (obj_BD_DAL.sMsjErrorBD == string.Empty)
                {
                    obj_Usuarios_DAL.dtDatos = obj_BD_DAL.DS.Tables[0];
                }
                else
                {
                    obj_Usuarios_DAL.dtDatos = null;
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void crearUsuarios(ref cls_Usuarios_DAL obj_Usuarios_DAL)
        {
            try
            {
                cls_GESTOR_BD_DAL obj_BD_DAL = new cls_GESTOR_BD_DAL(); //Objeto de acceso a datos de BD
                cls_GESTOR_BD_BLL obj_BD_BLL = new cls_GESTOR_BD_BLL(); //Objeto de lógica de negocio de BD

                obj_Usuarios_DAL.dtParametros = null;
                obj_Usuarios_DAL.dtParametros = obj_BD_BLL.gestionaParametros(obj_Usuarios_DAL.dtParametros);

                obj_Usuarios_DAL.dtParametros.Rows.Add("@Nombre", "6", obj_Usuarios_DAL.sNombre);
                obj_Usuarios_DAL.dtParametros.Rows.Add("@Prim_Apellido", "6", obj_Usuarios_DAL.sPrim_Apellido);
                obj_Usuarios_DAL.dtParametros.Rows.Add("@Seg_Apellido", "6", obj_Usuarios_DAL.sSeg_Apellido);
                obj_Usuarios_DAL.dtParametros.Rows.Add("@Correo", "6", obj_Usuarios_DAL.sCorreo);
                obj_Usuarios_DAL.dtParametros.Rows.Add("@Estado", "6", obj_Usuarios_DAL.sEstado);
                obj_Usuarios_DAL.dtParametros.Rows.Add("@Password", "6", obj_Usuarios_DAL.sPassword);
                obj_Usuarios_DAL.dtParametros.Rows.Add("@IdUsuario_Global", "1", obj_Usuarios_DAL.iIdUsuarioGlobal);

                obj_BD_DAL.sNomSP = ConfigurationManager.AppSettings["SP_Insert_Usuarios"];
                obj_BD_DAL.sIndAxn = "SCALAR";
                obj_BD_DAL.DT_Parametros = obj_Usuarios_DAL.dtParametros;

                obj_BD_BLL.gestionaProcesosComando(ref obj_BD_DAL);

                if (obj_BD_DAL.sMsjErrorBD == string.Empty)
                {
                    obj_Usuarios_DAL.sMSJError = obj_BD_DAL.sMsjErrorBD;
                    obj_Usuarios_DAL.sValorScalar = obj_BD_DAL.sValorScalar;
                }
                else
                {
                    obj_Usuarios_DAL.sMSJError = obj_BD_DAL.sMsjErrorBD;
                    obj_Usuarios_DAL.sValorScalar = null;
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public void modificarUsuarios(ref cls_Usuarios_DAL obj_Usuarios_DAL)
        {
            try
            {
                cls_GESTOR_BD_DAL obj_BD_DAL = new cls_GESTOR_BD_DAL(); //Objeto de acceso a datos de BD
                cls_GESTOR_BD_BLL obj_BD_BLL = new cls_GESTOR_BD_BLL(); //Objeto de lógica de negocio de BD

                obj_Usuarios_DAL.dtParametros = null;
                obj_Usuarios_DAL.dtParametros = obj_BD_BLL.gestionaParametros(obj_Usuarios_DAL.dtParametros);

                obj_Usuarios_DAL.dtParametros.Rows.Add("@IdUsuario", "1", obj_Usuarios_DAL.iId_Usuario);
                obj_Usuarios_DAL.dtParametros.Rows.Add("@Nombre", "6", obj_Usuarios_DAL.sNombre);
                obj_Usuarios_DAL.dtParametros.Rows.Add("@Prim_Apellido", "6", obj_Usuarios_DAL.sPrim_Apellido);
                obj_Usuarios_DAL.dtParametros.Rows.Add("@Seg_Apellido", "6", obj_Usuarios_DAL.sSeg_Apellido);
                obj_Usuarios_DAL.dtParametros.Rows.Add("@Correo", "6", obj_Usuarios_DAL.sCorreo);
                obj_Usuarios_DAL.dtParametros.Rows.Add("@Estado", "6", obj_Usuarios_DAL.sEstado);
                obj_Usuarios_DAL.dtParametros.Rows.Add("@Password", "6", obj_Usuarios_DAL.sPassword);
                obj_Usuarios_DAL.dtParametros.Rows.Add("@IdUsuario_Global", "1", obj_Usuarios_DAL.iIdUsuarioGlobal);

                obj_BD_DAL.sNomSP = ConfigurationManager.AppSettings["SP_Update_Usuarios"];
                obj_BD_DAL.sIndAxn = "SCALAR";
                obj_BD_DAL.DT_Parametros = obj_Usuarios_DAL.dtParametros;

                obj_BD_BLL.gestionaProcesosComando(ref obj_BD_DAL);

                if (obj_BD_DAL.sMsjErrorBD == string.Empty)
                {
                    obj_Usuarios_DAL.sMSJError = obj_BD_DAL.sMsjErrorBD;
                    obj_Usuarios_DAL.sValorScalar = obj_BD_DAL.sValorScalar;
                }
                else
                {
                    obj_Usuarios_DAL.sMSJError = obj_BD_DAL.sMsjErrorBD;
                    obj_Usuarios_DAL.sValorScalar = null;
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public void eliminarUsuarios(ref cls_Usuarios_DAL obj_Usuarios_DAL)
        {
            try
            {
                cls_GESTOR_BD_DAL obj_BD_DAL = new cls_GESTOR_BD_DAL(); //Objeto de acceso a datos de BD
                cls_GESTOR_BD_BLL obj_BD_BLL = new cls_GESTOR_BD_BLL(); //Objeto de lógica de negocio de BD

                obj_Usuarios_DAL.dtParametros = null;
                obj_Usuarios_DAL.dtParametros = obj_BD_BLL.gestionaParametros(obj_Usuarios_DAL.dtParametros);

                obj_Usuarios_DAL.dtParametros.Rows.Add("@IdUsuario", "1", obj_Usuarios_DAL.iId_Usuario);
                obj_Usuarios_DAL.dtParametros.Rows.Add("@IdUsuario_Global", "1", obj_Usuarios_DAL.iIdUsuarioGlobal);

                obj_BD_DAL.sNomSP = ConfigurationManager.AppSettings["SP_Elim_Usuarios"];
                obj_BD_DAL.sIndAxn = "SCALAR";
                obj_BD_DAL.DT_Parametros = obj_Usuarios_DAL.dtParametros;

                obj_BD_BLL.gestionaProcesosComando(ref obj_BD_DAL);

                if (obj_BD_DAL.sMsjErrorBD == string.Empty)
                {
                    obj_Usuarios_DAL.sMSJError = obj_BD_DAL.sMsjErrorBD;
                    obj_Usuarios_DAL.sValorScalar = obj_BD_DAL.sValorScalar;
                }
                else
                {
                    obj_Usuarios_DAL.sMSJError = obj_BD_DAL.sMsjErrorBD;
                    obj_Usuarios_DAL.sValorScalar = null;
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public void Cerrar_Sesion_Usuario(ref cls_Usuarios_DAL obj_Usuarios_DAL)
        {
            try
            {
                cls_GESTOR_BD_DAL Obj_BD_DAL = new cls_GESTOR_BD_DAL();
                cls_GESTOR_BD_BLL Obj_BD_BLL = new cls_GESTOR_BD_BLL();

                obj_Usuarios_DAL.dtParametros = null;
                obj_Usuarios_DAL.dtParametros = Obj_BD_BLL.gestionaParametros(obj_Usuarios_DAL.dtParametros);

                obj_Usuarios_DAL.dtParametros.Rows.Add("@IdUsuario", "1", obj_Usuarios_DAL.iId_Usuario);

                Obj_BD_DAL.sNomSP = ConfigurationManager.AppSettings["SP_CierraSesion_Usuarios"];
                Obj_BD_DAL.sIndAxn = "SCALAR";
                Obj_BD_DAL.DT_Parametros = obj_Usuarios_DAL.dtParametros;

                Obj_BD_BLL.gestionaProcesosComando(ref Obj_BD_DAL);

                if (Obj_BD_DAL.sMsjErrorBD == string.Empty)
                {
                    obj_Usuarios_DAL.sMSJError = Obj_BD_DAL.sMsjErrorBD;
                    obj_Usuarios_DAL.sValorScalar = Obj_BD_DAL.sValorScalar;
                }
                else
                {
                    obj_Usuarios_DAL.sMSJError = Obj_BD_DAL.sMsjErrorBD;
                    obj_Usuarios_DAL.sValorScalar = null;
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }

        }

        public void carga_Lista_Opciones_Menu_Usuario(ref cls_Usuarios_DAL obj_Usuarios_DAL)
        {
            try
            {
                cls_GESTOR_BD_DAL Obj_BD_DAL = new cls_GESTOR_BD_DAL();
                cls_GESTOR_BD_BLL Obj_BD_BLL = new cls_GESTOR_BD_BLL();

                obj_Usuarios_DAL.dtParametros = null;
                obj_Usuarios_DAL.dtParametros = Obj_BD_BLL.gestionaParametros(obj_Usuarios_DAL.dtParametros);

                //orden de parametros: nombre  , tipo de dato, valor del parametro
                obj_Usuarios_DAL.dtParametros.Rows.Add("@IdUsuario", "1", obj_Usuarios_DAL.iId_Usuario);

                Obj_BD_DAL.sNomSP = ConfigurationManager.AppSettings["SP_LST_ModulosXUsuario"];
                Obj_BD_DAL.DT_Parametros = obj_Usuarios_DAL.dtParametros;
                Obj_BD_DAL.sNomTabla = "Opciones";
                Obj_BD_BLL.gestionaProcesosTabla(ref Obj_BD_DAL);

                if (Obj_BD_DAL.sMsjErrorBD == string.Empty)
                {
                    obj_Usuarios_DAL.dtDatos = Obj_BD_DAL.DS.Tables[0];
                }
                else
                {
                    obj_Usuarios_DAL.dtDatos = null;
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
    }
}
