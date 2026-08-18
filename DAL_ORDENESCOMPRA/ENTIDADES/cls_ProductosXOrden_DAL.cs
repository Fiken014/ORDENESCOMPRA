using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace DAL_ORDENESCOMPRA.ENTIDADES
{
    public class cls_ProductosXOrden_DAL
    {
        #region Variables Privadas
        //Sección de campos de la tabla
        private int _iId_Producto_Orden, _iId_Producto, _iId_Orden;
        //Sección presente en todas las clases 
        private string _sValorScalar, _sAXN, _sMSJError;
        private DataTable _dtDatos, _dtParametros;
        private int _iIdUsuarioGlobal;
        #endregion

        #region Variables Públicas o Constructores
        public int iId_Producto_Orden { get => _iId_Producto_Orden; set => _iId_Producto_Orden = value; }
        public int iId_Producto { get => _iId_Producto; set => _iId_Producto = value; }
        public int iId_Orden { get => _iId_Orden; set => _iId_Orden = value; }
        public string sValorScalar { get => _sValorScalar; set => _sValorScalar = value; }
        public string sAXN { get => _sAXN; set => _sAXN = value; }
        public string sMSJError { get => _sMSJError; set => _sMSJError = value; }
        public DataTable dtDatos { get => _dtDatos; set => _dtDatos = value; }
        public DataTable dtParametros { get => _dtParametros; set => _dtParametros = value; }
        public int iIdUsuarioGlobal { get => _iIdUsuarioGlobal; set => _iIdUsuarioGlobal = value; }
        #endregion
    }
}
