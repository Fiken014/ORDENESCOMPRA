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
    public partial class frmConsultaProveedores : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        [WebMethod]
        public static string CargaListaProveedores(List<string> obj_Parametros_JS)
        {
            try
            {
                string _mensaje = string.Empty;

                //Objetos de la entidad con la que estamos trabajando
                cls_Proveedores_DAL obj_Proveedores_DAL = new cls_Proveedores_DAL();
                cls_Proveedores_BLL obj_Proveedores_BLL = new cls_Proveedores_BLL();

                //Descomponemos los valores que nos envíe el js y lo asignamos a nuestro objeto 
                obj_Proveedores_DAL.sProveedor = obj_Parametros_JS[0].ToString();
                obj_Proveedores_DAL.sEstado = obj_Parametros_JS[1].ToString();

                //Ejecutar en lógica de negocio el proceso o la accion necesaria
                obj_Proveedores_BLL.listarFiltrarProveedores(ref obj_Proveedores_DAL);


                //Evaluar los resultados de la ejecución de la lógica de negocio
                if (obj_Proveedores_DAL.dtDatos.Rows.Count != 0)
                {
                    _mensaje = "" +
                        "<thead>" +
                        "<tr>" +
                        "<th>Id Proveedor</th>" +
                        "<th>Proveedor</th>" +
                        "<th>Teléfono</th>" +
                        "<th>Correo</th>" +
                        "<th>Estado</th>" +
                        "<th style='text-align:center'>Eliminar</th>" +
                        "</tr>" +
                        "</thead>" +
                        "<tbody>";

                    for (int i = 0; i < obj_Proveedores_DAL.dtDatos.Rows.Count; i++)
                    {
                        _mensaje += "<tr><td style='cursor:pointer;' onclick='javascript:defineProveedor(" + obj_Proveedores_DAL.dtDatos.Rows[i][0].ToString() + ")'>" +
                                        obj_Proveedores_DAL.dtDatos.Rows[i][0].ToString() + "</td>" +
                                    "<td>" + obj_Proveedores_DAL.dtDatos.Rows[i][1].ToString() + "</td>" +
                                    "<td>" + obj_Proveedores_DAL.dtDatos.Rows[i][2].ToString() + "</td>" +
                                    "<td>" + obj_Proveedores_DAL.dtDatos.Rows[i][3].ToString() + "</td>" +
                                    "<td>" + obj_Proveedores_DAL.dtDatos.Rows[i][4].ToString() + "</td>" +
                                     "<td style='text-align:center'><i class='fa fa-trash-o' onclick='javascript:eliminaProveedor(" + obj_Proveedores_DAL.dtDatos.Rows[i][0].ToString() + ")' style='cursor:pointer'></i></td>" +
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

        [WebMethod]
        public static string CargaListaProveedoresCombo(List<string> obj_Parametros_JS)
        {
            try
            {
                string _mensaje = string.Empty;

                //Objetos de la entidad con la que estamos trabajando
                cls_Proveedores_DAL obj_Proveedores_DAL = new cls_Proveedores_DAL();
                cls_Proveedores_BLL obj_Proveedores_BLL = new cls_Proveedores_BLL();

                //Ejecutar en lógica de negocio el proceso o la accion necesaria
                obj_Proveedores_BLL.listarFiltrarProveedores(ref obj_Proveedores_DAL);

                //Evaluar los resultados de la ejecución de la lógica de negocio
                if (obj_Proveedores_DAL.dtDatos.Rows.Count != 0)
                {
                    for (int i = 0; i < obj_Proveedores_DAL.dtDatos.Rows.Count; i++)
                    {
                        //<option value="A">Automática</option>

                        _mensaje += "<option value=" + obj_Proveedores_DAL.dtDatos.Rows[i][0].ToString() +
                            ">" + obj_Proveedores_DAL.dtDatos.Rows[i][1].ToString() + "</option>";
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