using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CapaDatos;
using CapaEntidad;
using CapaDatos;

namespace CapaNegocio
{
    public class CN_Login
    {
        CD_Login AccesoDatosLogin = new CD_Login(); //Objeto encargado del acceso a datos

        #region Servicio :  Validar usuario
        public int ServicioValidarUsuario(string _Usuario){
            return AccesoDatosLogin.ValidarUsuario(_Usuario);
        }
        #endregion

        #region Servicio : Validar contraseña
        public string ServicioValidarContrasena(string _Usuario)
        {
            return AccesoDatosLogin.ValidarContrasena(_Usuario);
        }
        #endregion

        #region Servicio : Obtener privilegio de usuario
        public int ServicioObtenerPrivilegio(string _Usuario)
        {
            return AccesoDatosLogin.ObenterPrivilegio(_Usuario);
        }
        #endregion

        #region Servicio : Obtener id de usuario
        public int ServicioObtenerIdUser(string _Usuario)
        {
            return AccesoDatosLogin.ObenterIdUser(_Usuario);
        }
        #endregion
    }
}
