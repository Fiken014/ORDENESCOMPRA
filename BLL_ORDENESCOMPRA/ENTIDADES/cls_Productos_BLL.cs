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
    public class cls_Productos_BLL
    {
        public void listarFiltrarProductos(ref cls_Productos_DAL obj_Productos_DAL)
        {
            try
            {
                /* Objetos para comunicación al ámbito de BD */
                cls_GESTOR_BD_DAL obj_BD_DAL = new cls_GESTOR_BD_DAL(); //Objeto de acceso a datos de BD
                cls_GESTOR_BD_BLL obj_BD_BLL = new cls_GESTOR_BD_BLL(); //Objeto de lógica de negocio de BD

                //Filtrar Datos
                /*Dar forma al atributo de Data Table de Parametros del Objeto en cuestión*/
                obj_Productos_DAL.dtParametros = null;
                //Definimos el nombre del Key que contiene el valor del procedimiento almacenado
                obj_BD_DAL.sNomSP = ConfigurationManager.AppSettings["SP_LIST_Productos"];
                //Le asignamos al DT Parametros de BD_DAL la lista de parametros construida en el objeto en cuestión
                obj_BD_DAL.DT_Parametros = null;
                //Definimos un nombre de tabla lógico 
                obj_BD_DAL.sNomTabla = "Productos";

                obj_BD_BLL.gestionaProcesosTabla(ref obj_BD_DAL);

                //Validar los resultados
                //Si el mensaje de error de BD es vacío... todo salió de forma correcta, recuperemos lo valores
                if (obj_BD_DAL.sMsjErrorBD == string.Empty)
                {
                    obj_Productos_DAL.dtDatos = obj_BD_DAL.DS.Tables[0];
                }
                else
                {
                    obj_Productos_DAL.dtDatos = null;
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
