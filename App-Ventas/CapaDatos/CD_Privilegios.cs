using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CapaEntidad;
using System.Data;
using System.Data.SqlClient;

namespace CapaDatos
{
    public class CD_Privilegios
    {
        readonly CD_Conexion Conexion = new CD_Conexion();//Objeto Conexion
        readonly CE_Privilegios ModeloPrivilegios = new CE_Privilegios(); //Objeto Usuario

        #region ConsultarIdPrivilegio
        public int ConsultarIdPrivilegio(string NombrePrivilegio)
        {
            SqlCommand cm = new SqlCommand()
            {
                Connection = Conexion.AbrirConexion(),
                CommandText = "SP_U_IdPrivilegio",
                CommandType = CommandType.StoredProcedure,
                
            };
            cm.Parameters.AddWithValue("@NombrePrivilegio", NombrePrivilegio);
            object valor = cm.ExecuteScalar();
            int IdPrivilegio = (int)valor;
            Conexion.CerrarConexion();
            return IdPrivilegio;
        }
        #endregion

        #region ConsultarNombrePrivilegio
        public CE_Privilegios ConsultarNombrePrivilegio(int IdPrivilegio)
        {
            SqlDataAdapter da = new SqlDataAdapter("SP_U_NombrePrivilegio", Conexion.AbrirConexion());
            da.SelectCommand.CommandType = CommandType.StoredProcedure;
            da.SelectCommand.Parameters.Add("@IdPrivilegio",SqlDbType.Int).Value=IdPrivilegio;

            DataSet ds = new DataSet();
            ds.Clear();
            da.Fill(ds);

            DataTable dt;
            dt = ds.Tables[0];
            DataRow row = dt.Rows[0];

            ModeloPrivilegios.NombrePrivilegio = Convert.ToString(row[0]);
            Conexion.CerrarConexion();
            return  ModeloPrivilegios;
        }
        #endregion

        #region Listar Privilegios
        public List<string> ListarPrivilegios()
        {
            SqlCommand cm = new SqlCommand
            {
                Connection = Conexion.AbrirConexion(),
                CommandType = CommandType.StoredProcedure,
                CommandText = "SP_U_CargarPrivilegios",
            };
            SqlDataReader dr = cm.ExecuteReader();
            List<string> lista = new List<string>();
            while(dr.Read())
            {
                lista.Add(Convert.ToString(dr["NombrePrivilegio"]));
            }
            Conexion.CerrarConexion();
            return lista;
        }
        #endregion
    }
}
