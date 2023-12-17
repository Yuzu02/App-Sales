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
    public class CD_Grupos
    {
        CD_Conexion _Conexion = new CD_Conexion();//Objeto conexión
        CE_Grupos ModeloGrupos = new CE_Grupos();//Objto Grupos

        #region Listar Grupos
        public List<string> ListarGrupos()
        {
            SqlCommand cm = new SqlCommand()
            {
                Connection = _Conexion.AbrirConexion(),
                CommandText = "SP_G_CargarGrupos",
                CommandType = CommandType.StoredProcedure,
            };
            SqlDataReader dr = cm.ExecuteReader();
            List<string> retorno = new List<string>();
            while (dr.Read())
            {
                retorno.Add(Convert.ToString(dr["Nombre"]));
            }
            _Conexion.CerrarConexion();
            return retorno;
        }
        #endregion

        #region Nombre
        public CE_Grupos Nombre(int IdGrupo)
        { 
            SqlDataAdapter da = new SqlDataAdapter("SP_G_NombreGrupo", _Conexion.AbrirConexion());
            da.SelectCommand.CommandType = CommandType.StoredProcedure;
            da.SelectCommand.Parameters.Add("@IdGrupo", SqlDbType.Int).Value = IdGrupo;
            DataSet ds = new DataSet();
            ds.Clear();
            da.Fill(ds);
            DataTable dt;
            dt = ds.Tables[0];
            DataRow dr = dt.Rows[0];
            ModeloGrupos.Nombre = Convert.ToString(dr[0]);

            
            return ModeloGrupos;
        }
        #endregion

        #region IdGrupo
        public int IdGrupo(string Nombre)
        {
            SqlCommand cm = new SqlCommand()
            {
                Connection = _Conexion.AbrirConexion(),
                CommandText = "SP_G_IdGrupo",
                CommandType = CommandType.StoredProcedure,
            };
            cm.Parameters.AddWithValue("@Nombre", Nombre);
            object valor = cm.ExecuteScalar();
            int IdGrupo = (int)valor;
            _Conexion.CerrarConexion();
            
            return IdGrupo;
        }
        #endregion
    }
}
