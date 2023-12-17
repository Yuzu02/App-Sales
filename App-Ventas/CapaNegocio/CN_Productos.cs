using CapaEntidad;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CapaDatos;
using System.Data;

namespace CapaNegocio
{
    public class CN_Productos
    {
        readonly CD_Productos AccesoDatos = new CD_Productos(); //Objeto encargado del acceso a datos

        #region Servicio :  Buscar producto
        public DataTable BuscarProducto(string buscar)
        {
            return AccesoDatos.Buscar(buscar);
        }
        #endregion

        #region Servicio : CRUD productos

        #region Create
        public void Insertar(CE_Productos Producto)
        {
            AccesoDatos.Insertar(Producto);
        }
        #endregion

        #region Read
        public CE_Productos Consultar(int IdUsusario)
        {
            return AccesoDatos.Consultar(IdUsusario);
        }
        #endregion

        #region Update

        #region Actualizar Datos
        public void ActualizarDatos(CE_Productos _Producto)
        {
            AccesoDatos.Actualizar(_Producto);
        }
        #endregion

        #region Actualizar Img
        public void ActualizarIMG(CE_Productos _Producto)
        {
            AccesoDatos.ActualizarIMG(_Producto);
        }
        #endregion

        #endregion

        #region Delete
        public void Eliminar( CE_Productos Producto)
        {
            AccesoDatos.Eliminar(Producto);
        }
        #endregion

        #endregion

    }
}
