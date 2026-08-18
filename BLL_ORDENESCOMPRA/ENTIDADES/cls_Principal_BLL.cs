using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL_ORDENESCOMPRA.GESTOR_BD;
using BLL_ORDENESCOMPRA.GESTOR_BD;
using DAL_ORDENESCOMPRA.ENTIDADES;
using System.Configuration;
namespace BLL_ORDENESCOMPRA.ENTIDADES
{
    public class cls_Principal_BLL
    {
        public void listarFiltrarGraficoTablas(ref cls_Principal_DAL obj_Principal_DAL)
        {
            try
            {
                cls_GESTOR_BD_DAL Obj_BD_DAL = new cls_GESTOR_BD_DAL();
                cls_GESTOR_BD_BLL Obj_BD_BLL = new cls_GESTOR_BD_BLL();

                Obj_BD_DAL.sNomSP = ConfigurationManager.AppSettings["SP_LST_Grafico_Tablas"];
                Obj_BD_DAL.DT_Parametros = null;
                Obj_BD_DAL.sNomTabla = "Tablas";

                Obj_BD_BLL.gestionaProcesosTabla(ref Obj_BD_DAL);

                if (Obj_BD_DAL.sMsjErrorBD == string.Empty)
                {
                    obj_Principal_DAL.dtDatos = Obj_BD_DAL.DS.Tables[0];
                }
                else
                {
                    obj_Principal_DAL.dtDatos = null;
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public void listarCantidadOrdenesXProveedor(ref cls_Principal_DAL obj_Principal_DAL)
        {
            try
            {
                cls_GESTOR_BD_DAL Obj_BD_DAL = new cls_GESTOR_BD_DAL();
                cls_GESTOR_BD_BLL Obj_BD_BLL = new cls_GESTOR_BD_BLL();

                Obj_BD_DAL.sNomSP = ConfigurationManager.AppSettings["SP_LST_Cantidad_OrdenesXProveedor"];
                Obj_BD_DAL.DT_Parametros = null;
                Obj_BD_DAL.sNomTabla = "Cantidades";

                Obj_BD_BLL.gestionaProcesosTabla(ref Obj_BD_DAL);

                if (Obj_BD_DAL.sMsjErrorBD == string.Empty)
                {
                    obj_Principal_DAL.dtDatos = Obj_BD_DAL.DS.Tables[0];
                }
                else
                {
                    obj_Principal_DAL.dtDatos = null;
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
    }
}
