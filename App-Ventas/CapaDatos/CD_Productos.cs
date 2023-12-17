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
    public class CD_Productos
    {
        readonly CD_Conexion _Conexion = new CD_Conexion();//Objeto conexión
        readonly CE_Productos ModeloProductos = new CE_Productos();//Objeto Productos

        #region Buscar
        public DataTable Buscar (string _Producto)
        {
            SqlDataAdapter da = new SqlDataAdapter("SP_A_Buscar", _Conexion.AbrirConexion());
            da.SelectCommand.CommandType = CommandType.StoredProcedure;
            da.SelectCommand.Parameters.Add("@Nombre", SqlDbType.VarChar).Value = _Producto;

            DataSet ds = new DataSet();
            ds.Clear();
            da.Fill(ds);

            DataTable dt = ds.Tables[0];

            _Conexion.CerrarConexion();

            return dt;
        }
        #endregion

        #region CRUD

        #region Create
        public void Insertar(CE_Productos _Productos)
        {
            SqlCommand cm = new SqlCommand()
            {
                Connection = _Conexion.AbrirConexion(),
                CommandText = "SP_A_Insertar",
                CommandType = CommandType.StoredProcedure
            };
            cm.Parameters.AddWithValue("@Nombre", _Productos.Nombre);
            cm.Parameters.AddWithValue("@Grupo", _Productos.Grupo);
            cm.Parameters.AddWithValue("@Codigo", _Productos.Codigo);
            cm.Parameters.AddWithValue("@Precio", _Productos.Precio);
            cm.Parameters.AddWithValue("@Cantidad", _Productos.Cantidad);
            cm.Parameters.AddWithValue("@Activo", _Productos.Activo);
            cm.Parameters.AddWithValue("@UnidadMedida", _Productos.UnidadMedida);
            cm.Parameters.AddWithValue("@Img", _Productos.Img);
            cm.Parameters.AddWithValue("@Descripcion", _Productos.Descripcion);
            cm.ExecuteNonQuery();
            cm.Parameters.Clear();
            _Conexion.CerrarConexion();

        }
        #endregion

        #region Read
        public CE_Productos Consultar(int IdUsuario)
        {
            SqlDataAdapter da = new SqlDataAdapter("SP_A_Consultar",_Conexion.AbrirConexion());
            da.SelectCommand.CommandType = CommandType.StoredProcedure;
            da.SelectCommand.Parameters.Add("@IdArticulo",SqlDbType.Int).Value = IdUsuario;

            DataSet ds = new DataSet();
            ds .Clear();
            da.Fill(ds);

            DataTable dt;
            dt= ds.Tables[0];
            DataRow dr = dt.Rows[0];

            ModeloProductos.Nombre = Convert.ToString(dr[1]);
            ModeloProductos.Grupo = Convert.ToInt32(dr[2]);
            ModeloProductos.Codigo = Convert.ToString(dr[3]);
            ModeloProductos.Precio = Convert.ToDecimal(dr[4]);
            ModeloProductos.Activo = Convert.ToBoolean(dr[5]);
            ModeloProductos.Cantidad = Convert.ToDecimal(dr[6]);
            ModeloProductos.UnidadMedida = Convert.ToString(dr[7]);
            ModeloProductos.Img = (byte[])(dr[8]);
            ModeloProductos.Descripcion = Convert.ToString(dr[9]);

            return ModeloProductos;
        }
        #endregion

        #region Update

        #region Actualizar Datos
        public void Actualizar(CE_Productos _Productos)
        {
            SqlCommand cm = new SqlCommand()
            {
                Connection = _Conexion.AbrirConexion(),
                CommandText = "SP_A_Actualizar",
                CommandType = CommandType.StoredProcedure
            };
            cm.Parameters.AddWithValue("@IdArticulo", _Productos.IdArticulo);
            cm.Parameters.AddWithValue("@Nombre", _Productos.Nombre);
            cm.Parameters.AddWithValue("@Grupo", _Productos.Grupo);
            cm.Parameters.AddWithValue("@Codigo", _Productos.Codigo);
            cm.Parameters.AddWithValue("@Precio", _Productos.Precio);
            cm.Parameters.AddWithValue("@Cantidad", _Productos.Cantidad);
            cm.Parameters.AddWithValue("@Activo", _Productos.Activo);
            cm.Parameters.AddWithValue("@UnidadMedida", _Productos.UnidadMedida);
            cm.Parameters.AddWithValue("@Descripcion", _Productos.Descripcion);
            cm.ExecuteNonQuery();
            cm.Parameters.Clear();
            _Conexion.CerrarConexion();

        }
        #endregion

        #region Actualizar IMG
        public void ActualizarIMG(CE_Productos _Productos)
        {
            SqlCommand cm = new SqlCommand()
            {
                Connection = _Conexion.AbrirConexion(),
                CommandText = "SP_A_ActualizarIMG",
                CommandType = CommandType.StoredProcedure
            };
            cm.Parameters.AddWithValue("@IdArticulo", _Productos.IdArticulo);
            cm.Parameters.AddWithValue("@Img", _Productos.Img);
            cm.ExecuteNonQuery();
            cm.Parameters.Clear();
            _Conexion.CerrarConexion();

        }
        #endregion

        #endregion

        #region Delete
        public void  Eliminar(CE_Productos Producto)
        {
            SqlCommand cm = new SqlCommand()
            {
                Connection = _Conexion.AbrirConexion(),
                CommandType = CommandType.StoredProcedure,
                CommandText = "SP_A_Eliminar"
            };
            cm.Parameters.AddWithValue("@IdArticulo", Producto.IdArticulo);
            cm.ExecuteNonQuery();
            _Conexion.CerrarConexion();
        }
        #endregion

        #endregion
    }
}
