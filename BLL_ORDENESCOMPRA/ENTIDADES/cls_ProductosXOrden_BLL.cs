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
    public class cls_ProductosXOrden_BLL
    {
        public void listarFiltrarProductosXOrden(ref cls_ProductosXOrden_DAL obj_ProductosXOrden_DAL)
        {
            try
            {
                /* Objetos para comunicación al ámbito de BD */
                cls_GESTOR_BD_DAL obj_BD_DAL = new cls_GESTOR_BD_DAL(); //Objeto de acceso a datos de BD
                cls_GESTOR_BD_BLL obj_BD_BLL = new cls_GESTOR_BD_BLL(); //Objeto de lógica de negocio de BD

                //Filtrar Datos
                /*Dar forma al atributo de Data Table de Parametros del Objeto en cuestión*/
                obj_ProductosXOrden_DAL.dtParametros = null;
                obj_ProductosXOrden_DAL.dtParametros = obj_BD_BLL.gestionaParametros(obj_ProductosXOrden_DAL.dtParametros);

                //agregar los parámetros que requiere el procedimiento almacenado
                //Regla: Orden de Valores del Parámetro: Nombre, Código de Tipo de Dato, Valor
                obj_ProductosXOrden_DAL.dtParametros.Rows.Add("@IdOrden", "1", obj_ProductosXOrden_DAL.iId_Orden);

                //Definimos el nombre del Key que contiene el valor del procedimiento almacenado
                obj_BD_DAL.sNomSP = ConfigurationManager.AppSettings["SP_LST_ProductosXOrden"];
                //Le asignamos al DT Parametros de BD_DAL la lista de parametros construida en el objeto en cuestión
                obj_BD_DAL.DT_Parametros = obj_ProductosXOrden_DAL.dtParametros;
                //Definimos un nombre de tabla lógico 
                obj_BD_DAL.sNomTabla = "ProductosXOrden";

                obj_BD_BLL.gestionaProcesosTabla(ref obj_BD_DAL);

                //Validar los resultados
                //Si el mensaje de error de BD es vacío... todo salió de forma correcta, recuperemos lo valores
                if (obj_BD_DAL.sMsjErrorBD == string.Empty)
                {
                    obj_ProductosXOrden_DAL.dtDatos = obj_BD_DAL.DS.Tables[0];
                }
                else
                {
                    obj_ProductosXOrden_DAL.dtDatos = null;
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void asignarProductosXOrden(ref cls_ProductosXOrden_DAL obj_ProductosXOrden_DAL)
        {
            try
            {
                /* Objetos para comunicación al ámbito de BD */
                cls_GESTOR_BD_DAL obj_BD_DAL = new cls_GESTOR_BD_DAL(); //Objeto de acceso a datos de BD
                cls_GESTOR_BD_BLL obj_BD_BLL = new cls_GESTOR_BD_BLL(); //Objeto de lógica de negocio de BD

                //Filtrar Datos
                /*Dar forma al atributo de Data Table de Parametros del Objeto en cuestión*/
                obj_ProductosXOrden_DAL.dtParametros = null;
                obj_ProductosXOrden_DAL.dtParametros = obj_BD_BLL.gestionaParametros(obj_ProductosXOrden_DAL.dtParametros);

                //agregar los parámetros que requiere el procedimiento almacenado
                //Regla: Orden de Valores del Parámetro: Nombre, Código de Tipo de Dato, Valor
                obj_ProductosXOrden_DAL.dtParametros.Rows.Add("@IdOrden", "1", obj_ProductosXOrden_DAL.iId_Orden);
                obj_ProductosXOrden_DAL.dtParametros.Rows.Add("@IdProducto", "1", obj_ProductosXOrden_DAL.iId_Producto);
                obj_ProductosXOrden_DAL.dtParametros.Rows.Add("@IdProductoOrden", "1", obj_ProductosXOrden_DAL.iId_Producto_Orden);
                obj_ProductosXOrden_DAL.dtParametros.Rows.Add("@Accion", "6", "I");
                obj_ProductosXOrden_DAL.dtParametros.Rows.Add("@IdUsuario_Global", "1", obj_ProductosXOrden_DAL.iIdUsuarioGlobal);

                //Definimos el nombre del Key que contiene el valor del procedimiento almacenado
                obj_BD_DAL.sNomSP = ConfigurationManager.AppSettings["SP_MANT_ProductosXOrden"];
                obj_BD_DAL.sIndAxn = "SCALAR";
                //Le asignamos al DT Parametros de BD_DAL la lista de parametros construida en el objeto en cuestión
                obj_BD_DAL.DT_Parametros = obj_ProductosXOrden_DAL.dtParametros;

                obj_BD_BLL.gestionaProcesosComando(ref obj_BD_DAL);

                //Validar los resultados
                //Si el mensaje de error de BD es vacío... todo salió de forma correcta, recuperemos lo valores
                if (obj_BD_DAL.sMsjErrorBD == string.Empty)
                {
                    obj_ProductosXOrden_DAL.sMSJError = obj_BD_DAL.sMsjErrorBD;
                    obj_ProductosXOrden_DAL.sValorScalar = obj_BD_DAL.sValorScalar;
                }
                else
                {
                    obj_ProductosXOrden_DAL.sMSJError = obj_BD_DAL.sMsjErrorBD;
                    obj_ProductosXOrden_DAL.sValorScalar = null;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void eliminarProductosXOrden(ref cls_ProductosXOrden_DAL obj_ProductosXOrden_DAL)
        {
            try
            {
                /* Objetos para comunicación al ámbito de BD */
                cls_GESTOR_BD_DAL obj_BD_DAL = new cls_GESTOR_BD_DAL(); //Objeto de acceso a datos de BD
                cls_GESTOR_BD_BLL obj_BD_BLL = new cls_GESTOR_BD_BLL(); //Objeto de lógica de negocio de BD

                //Filtrar Datos
                /*Dar forma al atributo de Data Table de Parametros del Objeto en cuestión*/
                obj_ProductosXOrden_DAL.dtParametros = null;
                obj_ProductosXOrden_DAL.dtParametros = obj_BD_BLL.gestionaParametros(obj_ProductosXOrden_DAL.dtParametros);

                //agregar los parámetros que requiere el procedimiento almacenado
                //Regla: Orden de Valores del Parámetro: Nombre, Código de Tipo de Dato, Valor
                obj_ProductosXOrden_DAL.dtParametros.Rows.Add("@IdOrden", "1", obj_ProductosXOrden_DAL.iId_Orden);
                obj_ProductosXOrden_DAL.dtParametros.Rows.Add("@IdProducto", "1", obj_ProductosXOrden_DAL.iId_Producto);
                obj_ProductosXOrden_DAL.dtParametros.Rows.Add("@IdProductoOrden", "1", obj_ProductosXOrden_DAL.iId_Producto_Orden);
                obj_ProductosXOrden_DAL.dtParametros.Rows.Add("@Accion", "6", "E");
                obj_ProductosXOrden_DAL.dtParametros.Rows.Add("@IdUsuario_Global", "1", obj_ProductosXOrden_DAL.iIdUsuarioGlobal);

                //Definimos el nombre del Key que contiene el valor del procedimiento almacenado
                obj_BD_DAL.sNomSP = ConfigurationManager.AppSettings["SP_MANT_ProductosXOrden"];
                obj_BD_DAL.sIndAxn = "SCALAR";
                //Le asignamos al DT Parametros de BD_DAL la lista de parametros construida en el objeto en cuestión
                obj_BD_DAL.DT_Parametros = obj_ProductosXOrden_DAL.dtParametros;

                obj_BD_BLL.gestionaProcesosComando(ref obj_BD_DAL);

                //Validar los resultados
                //Si el mensaje de error de BD es vacío... todo salió de forma correcta, recuperemos lo valores
                if (obj_BD_DAL.sMsjErrorBD == string.Empty)
                {
                    obj_ProductosXOrden_DAL.sMSJError = obj_BD_DAL.sMsjErrorBD;
                    obj_ProductosXOrden_DAL.sValorScalar = obj_BD_DAL.sValorScalar;
                }
                else
                {
                    obj_ProductosXOrden_DAL.sMSJError = obj_BD_DAL.sMsjErrorBD;
                    obj_ProductosXOrden_DAL.sValorScalar = null;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
