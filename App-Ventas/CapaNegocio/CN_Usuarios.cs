using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CapaDatos;
using CapaEntidad;

namespace CapaNegocio
{
    public class CN_Usuarios
    {
        private readonly CD_Usuarios objDatos = new CD_Usuarios(); //Objeto - Acceso a Datos -> Usuario

        #region Servicio : Buscar Usuario
        public DataTable ServiceBuscarUsuario(string buscar)
        {
            return objDatos.BuscarUsuarios(buscar);
        }
        #endregion

        #region Servicio : CRUD Usuarios

        #region Servicio : Consultar usuario
        public CE_Usuarios ServiceConsultar(int IdUsuario) {
            return objDatos.ConsultarUsuario(IdUsuario); 
        }
        #endregion

        #region Servicio : Insertar usuario
        public void ServiceInsertar(CE_Usuarios Usuario)
        {
            objDatos.InsertarUsuario(Usuario);
        }

        #endregion

        #region Servicio : Eliminar usuario
        public void ServiceEliminar(CE_Usuarios Usuario)
        {
            objDatos.EliminarUsuario(Usuario);
        }
        #endregion

        #region Servicio : Actualizar datos usuario
        public void ServiceActualizarDatos(CE_Usuarios Usuario)
        {
            objDatos.ActualizarDatosUsuario(Usuario);
        }
        #endregion

        #region Servicio : Actualizar contraseña de Usuario
        public void ServiceActualizarPassUsuario(CE_Usuarios Usuario)
        {
            objDatos.ActualizarPassUsuario(Usuario);
        }
        #endregion

        #region Servicio : Actualizar Imagen de Usuario
        public void ServiceActualizarImgUsuario(CE_Usuarios Usuario)
        {
            objDatos.ActualizarImgUsuario(Usuario);
        }
        #endregion

        #endregion

    }
}
