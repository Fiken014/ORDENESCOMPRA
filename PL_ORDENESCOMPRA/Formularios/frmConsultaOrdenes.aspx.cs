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
    public partial class frmConsultaOrdenes : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        [WebMethod]
        public static string CargaListaOrdenes(List<string> obj_Parametros_JS)
        {
            try
            {
                string _mensaje = string.Empty;

                cls_Ordenes_DAL obj_Ordenes_DAL = new cls_Ordenes_DAL();
                cls_Ordenes_BLL obj_Ordenes_BLL = new cls_Ordenes_BLL();

                obj_Ordenes_DAL.sSolicitante = obj_Parametros_JS[0].ToString();
                obj_Ordenes_DAL.iIdProveedor = Convert.ToInt32(obj_Parametros_JS[1].ToString());

                obj_Ordenes_BLL.listarFiltrarOrdenes(ref obj_Ordenes_DAL);
                //Evaluar los resultados de la ejecución de la lógica de negocio
                if (obj_Ordenes_DAL.dtDatos.Rows.Count != 0)
                {
                    _mensaje = "" +
                        "<thead>" +
                        "<tr>" +
                        "<th>Id Orden</th>" +
                        "<th>Solicitante</th>" +
                        "<th>Proveedor</th>" +
                        "<th>Fecha Orden</th>" +
                        "<th style='text-align:center'>Productos</th>" +
                        "<th style='text-align:center'>Eliminar</th>" +
                        "</tr>" +
                        "</thead>" +
                        "<tbody>";

                    for (int i = 0; i < obj_Ordenes_DAL.dtDatos.Rows.Count; i++)
                    {
                        _mensaje += "<tr><td style='cursor:pointer;' onclick='javascript:defineOrden(" + obj_Ordenes_DAL.dtDatos.Rows[i][0].ToString() + ")'>" +
                                        obj_Ordenes_DAL.dtDatos.Rows[i][0].ToString() + "</td>" +
                                    "<td>" + obj_Ordenes_DAL.dtDatos.Rows[i][1].ToString() + "</td>" +
                                    "<td>" + obj_Ordenes_DAL.dtDatos.Rows[i][2].ToString() + "</td>" +
                                    "<td>" + Convert.ToDateTime(obj_Ordenes_DAL.dtDatos.Rows[i][3]).ToShortDateString().ToString() + "</td>" +
                                    "<td style='text-align:center'><i class='fa fa-book' onclick='javascript:productosOrden(" + obj_Ordenes_DAL.dtDatos.Rows[i][0].ToString() + ")' style='cursor:pointer'></i></td>" +
                                    "<td style='text-align:center'><i class='fa fa-trash-o' onclick='javascript:eliminaOrden(" + obj_Ordenes_DAL.dtDatos.Rows[i][0].ToString() + ")' style='cursor:pointer'></i></td>" +
                                    "</tr>";
                    }

                    _mensaje += "</tbody>";

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