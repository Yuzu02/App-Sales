using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using CapaEntidad;
using System.Data.SqlClient;

namespace CapaDatos
{
    public class CD_Usuarios
    {
        private readonly CD_Conexion Conexion = new CD_Conexion(); //Objeto Conexión
        private readonly CE_Usuarios Usuario = new CE_Usuarios(); //objeto Usuario

        //CRUD Usuarios

        #region Insertar
        public void InsertarUsuario(CE_Usuarios _Usuario)
        {
            SqlCommand cm = new SqlCommand()
            {
                Connection = Conexion.AbrirConexion(),
                CommandText = "SP_U_Insertar",
                CommandType = CommandType.StoredProcedure,
            };
            cm.Parameters.AddWithValue("@Nombres", _Usuario.Nombres);
            cm.Parameters.AddWithValue("@Apellidos", _Usuario.Apellidos);
            cm.Parameters.AddWithValue("@DUI", _Usuario.DUI);
            cm.Parameters.AddWithValue("@NIT", _Usuario.NIT);
            cm.Parameters.AddWithValue("@Correo", _Usuario.Correo);
            cm.Parameters.AddWithValue("@Telefono", _Usuario.Telefono);
            cm.Parameters.Add("@FechaNac", SqlDbType.Date).Value= _Usuario.FechaNac;
            cm.Parameters.AddWithValue("@Privilegio", _Usuario.Privilegio);
            cm.Parameters.AddWithValue("@Img", _Usuario.Img);
            cm.Parameters.AddWithValue("@Usuario", _Usuario.Usuario);
            cm.Parameters.AddWithValue("@Contrasena", _Usuario.Contrasena);
            cm.Parameters.AddWithValue("@Patron", _Usuario.Patron);
            cm.ExecuteNonQuery();
            cm.Parameters.Clear();
            Conexion.CerrarConexion();
        }
        #endregion

        #region Consulta
        public CE_Usuarios ConsultarUsuario(int IdUsuario)
        {
            SqlDataAdapter da = new SqlDataAdapter("SP_U_Consultar", Conexion.AbrirConexion());
            da.SelectCommand.CommandType = CommandType.StoredProcedure;
            da.SelectCommand.Parameters.Add("@IdUsuario", SqlDbType.Int).Value = IdUsuario;

            DataSet ds = new DataSet();
            ds.Clear();
            da.Fill(ds);

            DataTable dt;
            dt = ds.Tables[0];
            DataRow row= dt.Rows[0];
            Usuario.Nombres = Convert.ToString(row[1]);
            Usuario.Apellidos = Convert.ToString(row[2]);
            Usuario.DUI = Convert.ToInt32(row[3]);
            Usuario.NIT = Convert.ToInt32(row[4]);
            Usuario.Correo = Convert.ToString(row[5]);
            Usuario.Telefono = Convert.ToInt32(row[6]);
            Usuario.FechaNac = Convert.ToDateTime(row[7]);
            Usuario.Privilegio = Convert.ToInt32(row[8]);
            Usuario.Img = (byte[])(row[9]);
            Usuario.Usuario = Convert.ToString(row[10]);

            return Usuario;
        }
        #endregion

        #region Eliminar
        public void EliminarUsuario(CE_Usuarios _Usuario)
        {
            SqlCommand cm = new SqlCommand()
            {
                Connection = Conexion.AbrirConexion(),
                CommandText = "SP_U_Eliminar",
                CommandType = CommandType.StoredProcedure,
            };
            cm.Parameters.AddWithValue("@IdUsuario", _Usuario.IdUsuario);
            cm.ExecuteNonQuery();
            cm.Parameters.Clear();
            Conexion.CerrarConexion();
        }
        #endregion

        #region Actualizar datos
        public void ActualizarDatosUsuario( CE_Usuarios _Usuario)
        {
            SqlCommand cm = new SqlCommand()
            {
                Connection = Conexion.AbrirConexion(),
                CommandText = "SP_U_Actualizar",
                CommandType = CommandType.StoredProcedure,
            };
            cm.Parameters.AddWithValue("@IdUsuario", _Usuario.IdUsuario);
            cm.Parameters.AddWithValue("@Nombres", _Usuario.Nombres);
            cm.Parameters.AddWithValue("@Apellidos", _Usuario.Apellidos);
            cm.Parameters.AddWithValue("@DUI", _Usuario.DUI);
            cm.Parameters.AddWithValue("@NIT", _Usuario.NIT);
            cm.Parameters.AddWithValue("@Correo", _Usuario.Correo);
            cm.Parameters.AddWithValue("@Telefono", _Usuario.Telefono);
            cm.Parameters.AddWithValue("@FechaNac", _Usuario.FechaNac);
            cm.Parameters.AddWithValue("@Privilegio", _Usuario.Privilegio);
            cm.Parameters.AddWithValue("@Usuario", _Usuario.Usuario);
            cm.ExecuteNonQuery();
            cm.Parameters.Clear();
            Conexion.CerrarConexion(); 
        }
        #endregion

        #region Actualizar Pass
        public void ActualizarPassUsuario(CE_Usuarios _Usuario)
        {
            SqlCommand cm = new SqlCommand()
            {
                Connection = Conexion.AbrirConexion(),
                CommandText = "SP_U_ActualizarPass",
                CommandType = CommandType.StoredProcedure,
            };
            cm.Parameters.AddWithValue("@IdUsuario", _Usuario.IdUsuario);
            cm.Parameters.AddWithValue("@Contrasena", _Usuario.Contrasena);
            cm.Parameters.AddWithValue("@Patron", _Usuario.Patron);
            cm.ExecuteNonQuery();
            cm.Parameters.Clear();
            Conexion.CerrarConexion();
        }
        #endregion

        #region Actualizar Img
        public void ActualizarImgUsuario(CE_Usuarios _Usuario)
        {
            SqlCommand cm = new SqlCommand()
            {
                Connection = Conexion.AbrirConexion(),
                CommandText = "SP_U_ActualizarIMG",
                CommandType = CommandType.StoredProcedure,
            };
            cm.Parameters.AddWithValue("@IdUsuario", _Usuario.IdUsuario);
            cm.Parameters.AddWithValue("@Img", _Usuario.Img);
            cm.ExecuteNonQuery();
            cm.Parameters.Clear();
            Conexion.CerrarConexion();
        }
        #endregion

        //Buscar Usuarios

        #region BuscarUsuarios
        public DataTable BuscarUsuarios( string _Usuario)
        {
            SqlDataAdapter da = new SqlDataAdapter("SP_U_Buscar", Conexion.AbrirConexion());
            da.SelectCommand.CommandType = CommandType.StoredProcedure;
            da.SelectCommand.Parameters.Add("@buscar", SqlDbType.VarChar).Value = _Usuario;
            DataSet ds = new DataSet();
            ds.Clear();
            da.Fill(ds);
            DataTable dt = ds.Tables[0];
            Conexion.CerrarConexion();
            return dt;
        }
        #endregion
    }
}
