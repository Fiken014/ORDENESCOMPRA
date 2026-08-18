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
    public class cls_Proveedores_BLL
    {
        public void listarFiltrarProveedores(ref cls_Proveedores_DAL obj_Proveedores_DAL)
        {
            try
            {
                cls_GESTOR_BD_DAL obj_BD_DAL = new cls_GESTOR_BD_DAL(); //Objeto de acceso a datos de BD
                cls_GESTOR_BD_BLL obj_BD_BLL = new cls_GESTOR_BD_BLL(); //Objeto de lógica de negocio de BD

                if (
                    ((obj_Proveedores_DAL.sProveedor == string.Empty) || (obj_Proveedores_DAL.sProveedor == null))
                    &&
                    ((obj_Proveedores_DAL.sEstado == string.Empty) || (obj_Proveedores_DAL.sEstado == null))
                    )
                {
                    obj_BD_DAL.sNomSP = ConfigurationManager.AppSettings["SP_LST_Proveedores"];
                    obj_BD_DAL.DT_Parametros = null;
                    obj_BD_DAL.sNomTabla = "Proveedores";
                }
                else
                {
                    obj_Proveedores_DAL.dtParametros = null;
                    obj_Proveedores_DAL.dtParametros = obj_BD_BLL.gestionaParametros(obj_Proveedores_DAL.dtParametros);

                    obj_Proveedores_DAL.dtParametros.Rows.Add("@Proveedor", "6", obj_Proveedores_DAL.sProveedor);
                    obj_Proveedores_DAL.dtParametros.Rows.Add("@Estado", "6", obj_Proveedores_DAL.sEstado);

                    obj_BD_DAL.sNomSP = ConfigurationManager.AppSettings["SP_FILL_Proveedores"];
                    obj_BD_DAL.DT_Parametros = obj_Proveedores_DAL.dtParametros;
                    obj_BD_DAL.sNomTabla = "Proveedores";
                }

                obj_BD_BLL.gestionaProcesosTabla(ref obj_BD_DAL);

                if (obj_BD_DAL.sMsjErrorBD == string.Empty)
                {
                    obj_Proveedores_DAL.dtDatos = obj_BD_DAL.DS.Tables[0];
                }
                else
                {
                    obj_Proveedores_DAL.dtDatos = null;
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void Obtiene_Informacion_Proveedor(ref cls_Proveedores_DAL obj_Proveedores_DAL)
        {
            try
            {
                cls_GESTOR_BD_DAL obj_BD_DAL = new cls_GESTOR_BD_DAL(); //Objeto de acceso a datos de BD
                cls_GESTOR_BD_BLL obj_BD_BLL = new cls_GESTOR_BD_BLL(); //Objeto de lógica de negocio de BD

                /*Dar forma al atributo de Data Table de Parámetros del objeto en cuestión*/
                obj_Proveedores_DAL.dtParametros = null;
                obj_Proveedores_DAL.dtParametros = obj_BD_BLL.gestionaParametros(obj_Proveedores_DAL.dtParametros);

                //agregar al data table de parametros la lista de parametros que requiere el procedimiento almacenado
                //Regla: Orden de valores del Parámetro: Nombre, Código Tipo de Dato, Valor
                obj_Proveedores_DAL.dtParametros.Rows.Add("@IdProveedor", "1", obj_Proveedores_DAL.iIdProveedor);

                //Definimos el nombre del Key que contiene el valor del procedimiento almacenado de la base de datos
                obj_BD_DAL.sNomSP = ConfigurationManager.AppSettings["SP_INFO_Proveedores"];
                //Asignamos al DATA TABLE de Parametros de la base de datos nuestro Data Table construido anteriormente en el objeto en cuestión
                obj_BD_DAL.DT_Parametros = obj_Proveedores_DAL.dtParametros;
                //Definimos un nombre lógico del data table de respuesta de la base de datos 
                obj_BD_DAL.sNomTabla = "Proveedores";

                obj_BD_BLL.gestionaProcesosTabla(ref obj_BD_DAL);

                if (obj_BD_DAL.sMsjErrorBD == string.Empty)
                {
                    obj_Proveedores_DAL.dtDatos = obj_BD_DAL.DS.Tables[0];
                }
                else
                {
                    obj_Proveedores_DAL.dtDatos = null;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void crearProveedores(ref cls_Proveedores_DAL obj_Proveedores_DAL)
        {
            try
            {
                cls_GESTOR_BD_DAL obj_BD_DAL = new cls_GESTOR_BD_DAL(); //Objeto de acceso a datos de BD
                cls_GESTOR_BD_BLL obj_BD_BLL = new cls_GESTOR_BD_BLL(); //Objeto de lógica de negocio de BD

                /*Dar forma al atributo de Data Table de Parámetros del objeto en cuestión*/
                obj_Proveedores_DAL.dtParametros = null;
                obj_Proveedores_DAL.dtParametros = obj_BD_BLL.gestionaParametros(obj_Proveedores_DAL.dtParametros);


                obj_Proveedores_DAL.dtParametros.Rows.Add("@Proveedor", "6", obj_Proveedores_DAL.sProveedor);
                obj_Proveedores_DAL.dtParametros.Rows.Add("@Telefono", "6", obj_Proveedores_DAL.sTelefono);
                obj_Proveedores_DAL.dtParametros.Rows.Add("@Correo", "6", obj_Proveedores_DAL.sCorreo);
                obj_Proveedores_DAL.dtParametros.Rows.Add("@Pais", "6", obj_Proveedores_DAL.sPais);
                obj_Proveedores_DAL.dtParametros.Rows.Add("@Direccion", "6", obj_Proveedores_DAL.sDireccion);
                obj_Proveedores_DAL.dtParametros.Rows.Add("@Estado", "6", obj_Proveedores_DAL.sEstado);
                obj_Proveedores_DAL.dtParametros.Rows.Add("@IdUsuario_Global", "1", obj_Proveedores_DAL.iIdUsuarioGlobal);

                obj_BD_DAL.sNomSP = ConfigurationManager.AppSettings["SP_Insert_Proveedores"];
                obj_BD_DAL.sIndAxn = "SCALAR";
                obj_BD_DAL.DT_Parametros = obj_Proveedores_DAL.dtParametros;

                obj_BD_BLL.gestionaProcesosComando(ref obj_BD_DAL);
                if (obj_BD_DAL.sMsjErrorBD == string.Empty)
                {
                    obj_Proveedores_DAL.sMSJError = obj_BD_DAL.sMsjErrorBD;
                    obj_Proveedores_DAL.sValorScalar = obj_BD_DAL.sValorScalar;
                }
                else
                {
                    obj_Proveedores_DAL.sMSJError = obj_BD_DAL.sMsjErrorBD;
                    obj_Proveedores_DAL.sValorScalar = null;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        public void modificarProveedores(ref cls_Proveedores_DAL obj_Proveedores_DAL)
        {
            try
            {
                cls_GESTOR_BD_DAL obj_BD_DAL = new cls_GESTOR_BD_DAL(); //Objeto de acceso a datos de BD
                cls_GESTOR_BD_BLL obj_BD_BLL = new cls_GESTOR_BD_BLL(); //Objeto de lógica de negocio de BD

                obj_Proveedores_DAL.dtParametros = null;
                obj_Proveedores_DAL.dtParametros = obj_BD_BLL.gestionaParametros(obj_Proveedores_DAL.dtParametros);

                obj_Proveedores_DAL.dtParametros.Rows.Add("@IdProveedor", "1", obj_Proveedores_DAL.iIdProveedor);
                obj_Proveedores_DAL.dtParametros.Rows.Add("@Proveedor", "6", obj_Proveedores_DAL.sProveedor);
                obj_Proveedores_DAL.dtParametros.Rows.Add("@Telefono", "6", obj_Proveedores_DAL.sTelefono);
                obj_Proveedores_DAL.dtParametros.Rows.Add("@Correo", "6", obj_Proveedores_DAL.sCorreo);
                obj_Proveedores_DAL.dtParametros.Rows.Add("@Pais", "6", obj_Proveedores_DAL.sPais);
                obj_Proveedores_DAL.dtParametros.Rows.Add("@Direccion", "6", obj_Proveedores_DAL.sDireccion);
                obj_Proveedores_DAL.dtParametros.Rows.Add("@Estado", "6", obj_Proveedores_DAL.sEstado);
                obj_Proveedores_DAL.dtParametros.Rows.Add("@IdUsuario_Global", "1", obj_Proveedores_DAL.iIdUsuarioGlobal);

                obj_BD_DAL.sNomSP = ConfigurationManager.AppSettings["SP_Update_Proveedores"];
                obj_BD_DAL.sIndAxn = "SCALAR";
                obj_BD_DAL.DT_Parametros = obj_Proveedores_DAL.dtParametros;

                obj_BD_BLL.gestionaProcesosComando(ref obj_BD_DAL);

                if (obj_BD_DAL.sMsjErrorBD == string.Empty)
                {
                    obj_Proveedores_DAL.sMSJError = obj_BD_DAL.sMsjErrorBD;
                    obj_Proveedores_DAL.sValorScalar = obj_BD_DAL.sValorScalar;
                }
                else
                {
                    obj_Proveedores_DAL.sMSJError = obj_BD_DAL.sMsjErrorBD;
                    obj_Proveedores_DAL.sValorScalar = null;
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public void eliminarProveedores(ref cls_Proveedores_DAL obj_Proveedores_DAL)
        {
            try
            {
                cls_GESTOR_BD_DAL obj_BD_DAL = new cls_GESTOR_BD_DAL(); //Objeto de acceso a datos de BD
                cls_GESTOR_BD_BLL obj_BD_BLL = new cls_GESTOR_BD_BLL(); //Objeto de lógica de negocio de BD

                obj_Proveedores_DAL.dtParametros = null;
                obj_Proveedores_DAL.dtParametros = obj_BD_BLL.gestionaParametros(obj_Proveedores_DAL.dtParametros);

                obj_Proveedores_DAL.dtParametros.Rows.Add("@IdProveedor", "1", obj_Proveedores_DAL.iIdProveedor);
                obj_Proveedores_DAL.dtParametros.Rows.Add("@IdUsuario_Global", "1", obj_Proveedores_DAL.iIdUsuarioGlobal);

                //Definimos el nombre del Key que contiene el valor del procedimiento almacenado de la base de datos
                obj_BD_DAL.sNomSP = ConfigurationManager.AppSettings["SP_Delete_Proveedores"];
                //Definir el tipo de acción que vamos a ejecutar (SCALAR / NORMAL)
                obj_BD_DAL.sIndAxn = "SCALAR";
                //Asignamos al DATA TABLE de Parametros de la base de datos nuestro Data Table construido anteriormente en el objeto en cuestión
                obj_BD_DAL.DT_Parametros = obj_Proveedores_DAL.dtParametros;

                //Ejecutamos en base de datos la sentencia / instrucción de SQL 
                obj_BD_BLL.gestionaProcesosComando(ref obj_BD_DAL);

                //Validar los resultados
                //Si el mensaje de error de base de datos es vacío.... todo salió de forma correcta, recuperemos los valores
                if (obj_BD_DAL.sMsjErrorBD == string.Empty)
                {
                    obj_Proveedores_DAL.sMSJError = obj_BD_DAL.sMsjErrorBD;
                    obj_Proveedores_DAL.sValorScalar = obj_BD_DAL.sValorScalar;
                }
                else
                {
                    obj_Proveedores_DAL.sMSJError = obj_BD_DAL.sMsjErrorBD;
                    obj_Proveedores_DAL.sValorScalar = null;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
