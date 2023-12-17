using CapaEntidad;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaDatos
{
    public class CD_Carrito
    {
        CD_Conexion _Conexion = new CD_Conexion();//Objeto conexion
        CE_Carrito ModeloCarrito = new CE_Carrito();//Objeto Carrito

        #region Buscar Producto
        public CE_Carrito Buscar(string _buscar)
        {
            SqlDataAdapter da = new SqlDataAdapter("SP_C_Buscar",_Conexion.AbrirConexion());
            da.SelectCommand.CommandType = CommandType.StoredProcedure;
            da.SelectCommand.Parameters.Add("@Buscar", SqlDbType.VarChar).Value = _buscar;
            DataSet ds = new DataSet();
            ds.Clear();
            da.Fill(ds);
            DataTable dt = ds.Tables[0];
            if (dt.Rows.Count>0)
            {
                DataRow row = dt.Rows[0];
                ModeloCarrito.Nombre = Convert.ToString(row[1]);
                ModeloCarrito.Precio = Convert.ToDecimal(row[4]);
                _Conexion.CerrarConexion();

            }
            return ModeloCarrito;
        }
        #endregion

        #region Agregar
        public DataTable Agregar(string _producto, decimal _cantidad)
        {
            SqlDataAdapter da = new SqlDataAdapter("SP_C_Buscar",_Conexion.AbrirConexion());
            da.SelectCommand.CommandType= CommandType.StoredProcedure;
            da.SelectCommand.Parameters.Add("@Buscar",SqlDbType.VarChar).Value = _producto;
            DataSet ds = new DataSet();
            ds.Clear();
            da.Fill(ds);
            DataTable dt = ds.Tables[0];
      
                var Precio = dt.Rows[0][4];
                decimal cantidad = _cantidad;
                decimal ProductoTotal = cantidad * (decimal)Precio;
                dt.Columns.Add("ProductoTotal", typeof(decimal));

                foreach(DataRow row in dt.Rows)
                {
                    row["Cantidad"] = cantidad;
                    row["ProductoTotal"] = ProductoTotal;
                }
            _Conexion.CerrarConexion();
            return dt;
        }
        #endregion

        #region Venta
        public void Venta(string _factura, decimal _total, DateTime _fecha, int _miId)
        {
            SqlCommand cmd = new SqlCommand("SP_C_Venta", _Conexion.AbrirConexion());
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("No_Factura",SqlDbType.VarChar).Value = _factura;
            cmd.Parameters.Add("Fecha",SqlDbType.DateTime).Value = _fecha;
            cmd.Parameters.Add("Total",SqlDbType.Decimal).Value = _total;
            cmd.Parameters.Add("IdUsuario",SqlDbType.Int).Value = _miId;
            cmd.ExecuteNonQuery();
            cmd.Parameters.Clear();
            _Conexion.CerrarConexion();
        }

        public void VentaDetalle(string _codigo, decimal _cantidad, string _factura, decimal _totalArticulos)
        {
            SqlCommand cmd = new SqlCommand("SP_C_Venta_Detalle", _Conexion.AbrirConexion());
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("Codigo", SqlDbType.VarChar).Value = _codigo;
            cmd.Parameters.Add("Cantidad", SqlDbType.Decimal).Value = _cantidad;
            cmd.Parameters.Add("No_Factura", SqlDbType.VarChar).Value = _factura;
            cmd.Parameters.Add("Total", SqlDbType.Decimal).Value = _totalArticulos / 100;
            cmd.ExecuteNonQuery();
            cmd.Parameters.Clear();
            _Conexion.CerrarConexion();
        }
        #endregion

    }
}
