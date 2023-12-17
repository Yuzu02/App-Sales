using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CapaDatos;
using CapaEntidad;

namespace CapaNegocio
{
    public class CN_Grupos
    {
        CD_Grupos AccesoDatos = new CD_Grupos(); //Objeto encargado del acceso a datos
        CE_Grupos ModeloGrupo = new CE_Grupos(); //Objeto grupos

        #region Servicio : Listar Grupos de productos
        public List<string> ListarGrupos()
        {
            return AccesoDatos.ListarGrupos();
        }
        #endregion

        #region Servicio : obtenr nombre del grupo de productos
        public CE_Grupos NombreGrupo(int IdGrupo)
        {
            return AccesoDatos.Nombre(IdGrupo);
        }
        #endregion

        #region Servicio : Otener Id del Grupo de producto
        public int IdGrupo(string Nombre)
        {
            return AccesoDatos.IdGrupo(Nombre);
        }
        #endregion
    }
}
