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
    public class cls_Ordenes_BLL
    {
        public void listarFiltrarOrdenes(ref cls_Ordenes_DAL obj_Ordenes_DAL)
        {
            try
            {
                cls_GESTOR_BD_DAL obj_BD_DAL = new cls_GESTOR_BD_DAL(); //Objeto de acceso a datos de BD
                cls_GESTOR_BD_BLL obj_BD_BLL = new cls_GESTOR_BD_BLL(); //Objeto de lógica de negocio de BD

                if (
                    ((obj_Ordenes_DAL.sSolicitante == string.Empty) || (obj_Ordenes_DAL.sSolicitante == null))
                    &&
                    ((obj_Ordenes_DAL.iIdProveedor == 0))
                    )
                {
                    obj_BD_DAL.sNomSP = ConfigurationManager.AppSettings["SP_LST_Ordenes"];
                    obj_BD_DAL.DT_Parametros = null;
                    obj_BD_DAL.sNomTabla = "Ordenes";
                }
                else
                {
                    obj_Ordenes_DAL.dtParametros = null;
                    obj_Ordenes_DAL.dtParametros = obj_BD_BLL.gestionaParametros(obj_Ordenes_DAL.dtParametros);

                    obj_Ordenes_DAL.dtParametros.Rows.Add("@Solicitante", "6", obj_Ordenes_DAL.sSolicitante);
                    obj_Ordenes_DAL.dtParametros.Rows.Add("@Proveedor", "1", obj_Ordenes_DAL.iIdProveedor);

                    obj_BD_DAL.sNomSP = ConfigurationManager.AppSettings["SP_FILL_Ordenes"];
                    obj_BD_DAL.DT_Parametros = obj_Ordenes_DAL.dtParametros;
                    obj_BD_DAL.sNomTabla = "Ordenes";
                }

                obj_BD_BLL.gestionaProcesosTabla(ref obj_BD_DAL);

                if (obj_BD_DAL.sMsjErrorBD == string.Empty)
                {
                    obj_Ordenes_DAL.dtDatos = obj_BD_DAL.DS.Tables[0];
                }
                else
                {
                    obj_Ordenes_DAL.dtDatos = null;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public void Obtiene_Informacion_Orden(ref cls_Ordenes_DAL obj_Ordenes_DAL)
        {
            try
            {
                cls_GESTOR_BD_DAL obj_BD_DAL = new cls_GESTOR_BD_DAL(); //Objeto de acceso a datos de BD
                cls_GESTOR_BD_BLL obj_BD_BLL = new cls_GESTOR_BD_BLL(); //Objeto de lógica de negocio de BD

                obj_Ordenes_DAL.dtParametros = null;
                obj_Ordenes_DAL.dtParametros = obj_BD_BLL.gestionaParametros(obj_Ordenes_DAL.dtParametros);


                obj_Ordenes_DAL.dtParametros.Rows.Add("@IdOrden", "1", obj_Ordenes_DAL.iIdOrden);

                obj_BD_DAL.sNomSP = ConfigurationManager.AppSettings["SP_INFO_Ordenes"];
                obj_BD_DAL.DT_Parametros = obj_Ordenes_DAL.dtParametros;
                obj_BD_DAL.sNomTabla = "Ordenes";

                obj_BD_BLL.gestionaProcesosTabla(ref obj_BD_DAL);

                if (obj_BD_DAL.sMsjErrorBD == string.Empty)
                {
                    obj_Ordenes_DAL.dtDatos = obj_BD_DAL.DS.Tables[0];
                }
                else
                {
                    obj_Ordenes_DAL.dtDatos = null;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public void crearOrdenes(ref cls_Ordenes_DAL obj_Ordenes_DAL)
        {
            try
            {
                cls_GESTOR_BD_DAL obj_BD_DAL = new cls_GESTOR_BD_DAL(); //Objeto de acceso a datos de BD
                cls_GESTOR_BD_BLL obj_BD_BLL = new cls_GESTOR_BD_BLL(); //Objeto de lógica de negocio de BD

                obj_Ordenes_DAL.dtParametros = null;
                obj_Ordenes_DAL.dtParametros = obj_BD_BLL.gestionaParametros(obj_Ordenes_DAL.dtParametros);

                obj_Ordenes_DAL.dtParametros.Rows.Add("@Solicitante", "6", obj_Ordenes_DAL.sSolicitante);
                obj_Ordenes_DAL.dtParametros.Rows.Add("@DiasCredito", "1", obj_Ordenes_DAL.iDiasCredito);
                obj_Ordenes_DAL.dtParametros.Rows.Add("@Fecha_Orden", "8", obj_Ordenes_DAL.dFecha_Orden);
                obj_Ordenes_DAL.dtParametros.Rows.Add("@Id_Proveedor", "1", obj_Ordenes_DAL.iIdProveedor);
                obj_Ordenes_DAL.dtParametros.Rows.Add("@TipoOrden", "6", obj_Ordenes_DAL.sTipoOrden);
                obj_Ordenes_DAL.dtParametros.Rows.Add("@Descripcion", "6", obj_Ordenes_DAL.sDescripcion);
                obj_Ordenes_DAL.dtParametros.Rows.Add("@Estado", "6", obj_Ordenes_DAL.sEstado);
                obj_Ordenes_DAL.dtParametros.Rows.Add("@IdUsuario_Global", "1", obj_Ordenes_DAL.iIdUsuarioGlobal);

                obj_BD_DAL.sNomSP = ConfigurationManager.AppSettings["SP_Insert_Ordenes"];
                obj_BD_DAL.sIndAxn = "SCALAR";
                obj_BD_DAL.DT_Parametros = obj_Ordenes_DAL.dtParametros;

                obj_BD_BLL.gestionaProcesosComando(ref obj_BD_DAL);

                if (obj_BD_DAL.sMsjErrorBD == string.Empty)
                {
                    obj_Ordenes_DAL.sMSJError = obj_BD_DAL.sMsjErrorBD;
                    obj_Ordenes_DAL.sValorScalar = obj_BD_DAL.sValorScalar;
                }
                else
                {
                    obj_Ordenes_DAL.sMSJError = obj_BD_DAL.sMsjErrorBD;
                    obj_Ordenes_DAL.sValorScalar = null;
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        public void modificarOrdenes(ref cls_Ordenes_DAL obj_Ordenes_DAL)
        {
            try
            {
                cls_GESTOR_BD_DAL obj_BD_DAL = new cls_GESTOR_BD_DAL(); //Objeto de acceso a datos de BD
                cls_GESTOR_BD_BLL obj_BD_BLL = new cls_GESTOR_BD_BLL(); //Objeto de lógica de negocio de BD

                obj_Ordenes_DAL.dtParametros = null;
                obj_Ordenes_DAL.dtParametros = obj_BD_BLL.gestionaParametros(obj_Ordenes_DAL.dtParametros);

                obj_Ordenes_DAL.dtParametros.Rows.Add("@IdOrden", "1", obj_Ordenes_DAL.iIdOrden);
                obj_Ordenes_DAL.dtParametros.Rows.Add("@Solicitante", "6", obj_Ordenes_DAL.sSolicitante);
                obj_Ordenes_DAL.dtParametros.Rows.Add("@DiasCredito", "1", obj_Ordenes_DAL.iDiasCredito);
                obj_Ordenes_DAL.dtParametros.Rows.Add("@Fecha_Orden", "8", obj_Ordenes_DAL.dFecha_Orden);
                obj_Ordenes_DAL.dtParametros.Rows.Add("@Id_Proveedor", "1", obj_Ordenes_DAL.iIdProveedor);
                obj_Ordenes_DAL.dtParametros.Rows.Add("@TipoOrden", "6", obj_Ordenes_DAL.sTipoOrden);
                obj_Ordenes_DAL.dtParametros.Rows.Add("@Descripcion", "6", obj_Ordenes_DAL.sDescripcion);
                obj_Ordenes_DAL.dtParametros.Rows.Add("@Estado", "6", obj_Ordenes_DAL.sEstado);
                obj_Ordenes_DAL.dtParametros.Rows.Add("@IdUsuario_Global", "1", obj_Ordenes_DAL.iIdUsuarioGlobal);

                obj_BD_DAL.sNomSP = ConfigurationManager.AppSettings["SP_Update_Ordenes"];
                obj_BD_DAL.sIndAxn = "SCALAR";
                obj_BD_DAL.DT_Parametros = obj_Ordenes_DAL.dtParametros;

                obj_BD_BLL.gestionaProcesosComando(ref obj_BD_DAL);

                if (obj_BD_DAL.sMsjErrorBD == string.Empty)
                {
                    obj_Ordenes_DAL.sMSJError = obj_BD_DAL.sMsjErrorBD;
                    obj_Ordenes_DAL.sValorScalar = obj_BD_DAL.sValorScalar;
                }
                else
                {
                    obj_Ordenes_DAL.sMSJError = obj_BD_DAL.sMsjErrorBD;
                    obj_Ordenes_DAL.sValorScalar = null;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public void eliminarOrdenes(ref cls_Ordenes_DAL obj_Ordenes_DAL)
        {
            try
            {
                cls_GESTOR_BD_DAL obj_BD_DAL = new cls_GESTOR_BD_DAL(); //Objeto de acceso a datos de BD
                cls_GESTOR_BD_BLL obj_BD_BLL = new cls_GESTOR_BD_BLL(); //Objeto de lógica de negocio de BD

                obj_Ordenes_DAL.dtParametros = null;
                obj_Ordenes_DAL.dtParametros = obj_BD_BLL.gestionaParametros(obj_Ordenes_DAL.dtParametros);

                obj_Ordenes_DAL.dtParametros.Rows.Add("@IdOrden", "1", obj_Ordenes_DAL.iIdOrden);
                obj_Ordenes_DAL.dtParametros.Rows.Add("@IdUsuario_Global", "1", obj_Ordenes_DAL.iIdUsuarioGlobal);

                obj_BD_DAL.sNomSP = ConfigurationManager.AppSettings["SP_Delete_Ordenes"];
                obj_BD_DAL.sIndAxn = "SCALAR";
                obj_BD_DAL.DT_Parametros = obj_Ordenes_DAL.dtParametros;

                obj_BD_BLL.gestionaProcesosComando(ref obj_BD_DAL);

                if (obj_BD_DAL.sMsjErrorBD == string.Empty)
                {
                    obj_Ordenes_DAL.sMSJError = obj_BD_DAL.sMsjErrorBD;
                    obj_Ordenes_DAL.sValorScalar = obj_BD_DAL.sValorScalar;
                }
                else
                {
                    obj_Ordenes_DAL.sMSJError = obj_BD_DAL.sMsjErrorBD;
                    obj_Ordenes_DAL.sValorScalar = null;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
