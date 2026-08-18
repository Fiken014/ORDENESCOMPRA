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
    public class cls_Modulos_BLL
    {
        public void listarFiltrarModulos(ref cls_Modulos_DAL obj_Modulos_DAL)
        {
            try
            {
                /**Se requieren en todos los metodos de bll*/
                cls_GESTOR_BD_DAL Obj_BD_DAL = new cls_GESTOR_BD_DAL();
                cls_GESTOR_BD_BLL Obj_BD_BLL = new cls_GESTOR_BD_BLL();
                /**Se requieren en todos los metodos de bll*/

                Obj_BD_DAL.sNomSP = ConfigurationManager.AppSettings["SP_LST_Modulos"];
                Obj_BD_DAL.DT_Parametros = null;
                Obj_BD_DAL.sNomTabla = "Modulos";

                Obj_BD_BLL.gestionaProcesosTabla(ref Obj_BD_DAL);

                if (Obj_BD_DAL.sMsjErrorBD == string.Empty)
                {
                    obj_Modulos_DAL.dtDatos = Obj_BD_DAL.DS.Tables[0];
                }
                else
                {
                    obj_Modulos_DAL.dtDatos = null;
                }

            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
    }
}
