using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CapaDatos;
using CapaEntidad;

namespace CapaNegocio
{
    public class CN_Carrito
    {
        CD_Carrito AccesoDatos = new CD_Carrito();//Objeto encargado del acceso a Datos

        #region Servicio : Buscar producto
        public CE_Carrito Buscar(string _buscar)
        {
            return AccesoDatos.Buscar(_buscar);
        }
        #endregion

        #region Servicio : Agregar producto
        public DataTable Agregar(string producto, decimal cantidad)
        {

            return AccesoDatos.Agregar(producto, cantidad);
        }
        #endregion

        #region Servicio : Venta
        public void Venta(string _factura, decimal _total, DateTime _fecha, int _miId)
        {
            AccesoDatos.Venta(_factura, _total, _fecha, _miId);
        }
        #endregion

        #region Servicio : Venta Detalles
        public void VentaDetalle(string _codigo, decimal _cantidad,string _factura,decimal _totalArticulos)
        {
            AccesoDatos.VentaDetalle(_codigo,_cantidad,_factura,_totalArticulos);
        }
        #endregion
    }
}
