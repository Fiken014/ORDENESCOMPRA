using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
namespace DAL_ORDENESCOMPRA.ENTIDADES
{
    public class cls_Ordenes_DAL
    {
        #region Variables Privadas
        //Sección de campos de la tabla
        private int _iIdOrden, _iIdProveedor, _iDiasCredito;
        private string _sSolicitante, _sTipoOrden, _sDescripcion,_sEstado;
        private DateTime _dFecha_Orden;

        //Sección presente en todas las clases 
        private string _sValorScalar, _sAXN, _sMSJError;
        private DataTable _dtDatos, _dtParametros;
        private int _iIdUsuarioGlobal;
        #endregion

        #region Variables Públicas o Constructores
        public int iIdOrden { get => _iIdOrden; set => _iIdOrden = value; }
        public int iIdProveedor { get => _iIdProveedor; set => _iIdProveedor = value; }
        public int iDiasCredito { get => _iDiasCredito; set => _iDiasCredito = value; }
        public string sSolicitante { get => _sSolicitante; set => _sSolicitante = value; }
        public string sTipoOrden { get => _sTipoOrden; set => _sTipoOrden = value; }
        public string sDescripcion { get => _sDescripcion; set => _sDescripcion = value; }
        public string sEstado { get => _sEstado; set => _sEstado = value; }
        public DateTime dFecha_Orden { get => _dFecha_Orden; set => _dFecha_Orden = value; }
        public string sValorScalar { get => _sValorScalar; set => _sValorScalar = value; }
        public string sAXN { get => _sAXN; set => _sAXN = value; }
        public string sMSJError { get => _sMSJError; set => _sMSJError = value; }
        public DataTable dtDatos { get => _dtDatos; set => _dtDatos = value; }
        public DataTable dtParametros { get => _dtParametros; set => _dtParametros = value; }
        public int iIdUsuarioGlobal { get => _iIdUsuarioGlobal; set => _iIdUsuarioGlobal = value; }
        #endregion

    }
}
