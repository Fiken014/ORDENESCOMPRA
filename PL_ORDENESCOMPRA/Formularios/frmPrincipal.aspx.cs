using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Services;
using System.Data;
using BLL_ORDENESCOMPRA.ENTIDADES;
using DAL_ORDENESCOMPRA.ENTIDADES;
namespace PL_ORDENESCOMPRA.Formularios
{
    public partial class frmPrincipal : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        [WebMethod]
        public static string CargaListaGraficoTablas(List<string> obj_Parametros_JS)
        {
            try
            {
                String _mensaje = string.Empty;

                cls_Principal_DAL obj_Principal_DAL = new cls_Principal_DAL();
                cls_Principal_BLL obj_Principal_BLL = new cls_Principal_BLL();

                obj_Principal_BLL.listarFiltrarGraficoTablas(ref obj_Principal_DAL);

                if (obj_Principal_DAL.dtDatos.Rows.Count != 0)
                {
                    _mensaje = obj_Principal_DAL.dtDatos.Rows[0][0].ToString() + "<SPLITER>" +
                                obj_Principal_DAL.dtDatos.Rows[0][1].ToString() + "<SPLITER>" +
                                obj_Principal_DAL.dtDatos.Rows[0][2].ToString() + "<SPLITER>" +
                                obj_Principal_DAL.dtDatos.Rows[0][3].ToString() + "<SPLITER>";
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


        [WebMethod]
        public static string CargaListaProveedoresGrafico(List<string> obj_Parametros_JS)
        {
            try
            {

                String _mensaje = string.Empty;

                cls_Proveedores_DAL obj_Proveedores_DAL = new cls_Proveedores_DAL();
                cls_Proveedores_BLL obj_Proveedores_BLL = new cls_Proveedores_BLL();

                obj_Proveedores_BLL.listarFiltrarProveedores(ref obj_Proveedores_DAL);

                if (obj_Proveedores_DAL.dtDatos.Rows.Count != 0)
                {
                    DataView dv = obj_Proveedores_DAL.dtDatos.DefaultView;
                    dv.Sort = obj_Proveedores_DAL.dtDatos.Columns[1].ColumnName + " ASC";

                    foreach (DataRowView drv in dv)
                    {
                        _mensaje += drv[1].ToString() + "<SPLITER>";
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

        [WebMethod]
        public static string CargaListaCantidadOrdenesXProveedores(List<string> obj_Parametros_JS)
        {
            try
            {
                String _mensaje = string.Empty;

                cls_Principal_DAL obj_Principal_DAL = new cls_Principal_DAL();
                cls_Principal_BLL obj_Principal_BLL = new cls_Principal_BLL();

                obj_Principal_BLL.listarCantidadOrdenesXProveedor(ref obj_Principal_DAL);

                if (obj_Principal_DAL.dtDatos.Rows.Count != 0)
                {
                    DataView dv = obj_Principal_DAL.dtDatos.DefaultView;
                    dv.Sort = obj_Principal_DAL.dtDatos.Columns[0].ColumnName + " ASC";

                    foreach (DataRowView drv in dv)
                    {
                        _mensaje += drv[1].ToString() + "<SPLITER>";
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