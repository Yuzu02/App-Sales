using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaDatos
{
    public class CD_Dashboard
    {
        CD_Conexion _Conexion;//Objeto Conexión

        public CD_Dashboard()
        {
            _Conexion = new CD_Conexion();//Inicializar objeto conexión
        }

        #region Cantidad Articulos
        public int ArticulosDisponibles()
        {
            SqlCommand cmd = new SqlCommand("SP_A_Cantidad_Articulos", _Conexion.AbrirConexion());
            cmd.CommandType = CommandType.StoredProcedure;
            object valor = cmd.ExecuteScalar();
            int cantidadArticulos = Convert.ToInt32(valor);
            _Conexion.CerrarConexion();
            return cantidadArticulos;
        }
        #endregion

        #region CatidadVentas
        public int CantidadVentas()
        {
            SqlCommand cmd = new SqlCommand("SP_V_Cantidad_Ventas", _Conexion.AbrirConexion());
            cmd.CommandType = CommandType.StoredProcedure;
            object valor = cmd.ExecuteScalar();
            int cantidadArticulos = Convert.ToInt32(valor);
            cmd.Parameters.Clear();
            _Conexion.CerrarConexion();
            return cantidadArticulos;
        }
        #endregion

        #region Grafico
        public DataTable Grafico()
        {
            SqlDataAdapter da = new SqlDataAdapter("SP_V_Grafico", _Conexion.AbrirConexion());
            da.SelectCommand.CommandType = CommandType.StoredProcedure;
            DataSet ds = new DataSet();
            ds.Clear();
            da.Fill(ds);
            DataTable dt = ds.Tables[0];
            _Conexion.CerrarConexion();
            return dt;
        #endregion
        }
    }
}
