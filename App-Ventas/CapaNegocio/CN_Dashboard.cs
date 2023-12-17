using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CapaDatos;

namespace CapaNegocio
{

    public class CN_Dashboard
    {
        readonly CD_Dashboard AccesoDatos; //Objeto encargado del acceso a datos

        public CN_Dashboard()
        {
            AccesoDatos = new CD_Dashboard();//Inicilizar objeto encargado del acceso a datos
        }

        #region Servicio : Consultar cantidad de articulos disponibles
        public int ArticulosDisponibles()
        {
            return AccesoDatos.ArticulosDisponibles();
        }
        #endregion

        #region Servicio : Consultar antidad de vantas
        public int CantidadVentas()
        {
            return AccesoDatos.CantidadVentas();
        }
        #endregion

        #region Servicio : Grafico
        public DataTable Grafico()
        {
            return AccesoDatos.Grafico();
        }
        #endregion

    }


}
