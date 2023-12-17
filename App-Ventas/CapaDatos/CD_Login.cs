using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CapaEntidad;

namespace CapaDatos
{
    public class CD_Login
    {
        private readonly CD_Conexion _Conexion;//Objeto conexión
        private readonly CE_Usuarios ModeloUsuario; //Objeto Usuario

        public CD_Login() { 
            _Conexion = new CD_Conexion(); //Inicializar objeto conexión
            ModeloUsuario = new CE_Usuarios();//Inicializar objeto usuario
        }

        #region Validar Usuario
        public int ValidarUsuario(string Usuario)
        {
            
            SqlCommand cm = new SqlCommand()
            {
                Connection = _Conexion.AbrirConexion(),
                CommandText = "SP_U_LoginUsuario",
                CommandType = System.Data.CommandType.StoredProcedure
            };

            cm.Parameters.Add("@Usuario", SqlDbType.VarChar).Value = Usuario;
            object valor = cm.ExecuteScalar();
            int Count = (int)valor;
            return Count;
        }
        #endregion

        #region Validar Contraseña
        public string ValidarContrasena(string Usuario)
        {
            SqlCommand cm = new SqlCommand()
            {
                Connection = _Conexion.AbrirConexion(),
                CommandText = "SP_U_LoginPassword",
                CommandType = System.Data.CommandType.StoredProcedure
            };

            cm.Parameters.Add("@Usuario", SqlDbType.VarChar).Value = Usuario;
            object valor = cm.ExecuteScalar();
            string Ps = (string)valor;
            return Ps;
        }
        #endregion

        #region Obtener Privilegio de usuario
        public int ObenterPrivilegio(string Usuario)
        {
            SqlCommand cm = new SqlCommand()
            {
                Connection = _Conexion.AbrirConexion(),
                CommandText = "SP_U_NivelAcceso",
                CommandType = System.Data.CommandType.StoredProcedure
            };

            cm.Parameters.Add("@Usuario", SqlDbType.VarChar).Value = Usuario;
            object valor = cm.ExecuteScalar();
            int Privilegio = (int)valor;
            return Privilegio;
        }
        #endregion

        #region Obtener Id de usuario
        public int ObenterIdUser(string Usuario)
        {
            SqlCommand cm = new SqlCommand()
            {
                Connection = _Conexion.AbrirConexion(),
                CommandText = "SP_U_IdUser",
                CommandType = System.Data.CommandType.StoredProcedure
            };

            cm.Parameters.Add("@Usuario", SqlDbType.VarChar).Value = Usuario;
            object valor = cm.ExecuteScalar();
            int Id = (int)valor;
            return Id;
        }
        #endregion
    }
}
