using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CapaDatos;
using CapaEntidad;

namespace CapaNegocio
{
    public class CN_Privilegios
    {
        readonly CD_Privilegios objectDatos = new CD_Privilegios(); //Objeto - Acceso a Datos -> Privilegios

        #region Servicio : Consultar IdPrivilegio
        public int ServicioConsultarIdPrivilegio(string NombrePrivilegio)
        {
            return objectDatos.ConsultarIdPrivilegio(NombrePrivilegio);
        }
        #endregion

        #region Servicio : Consultar NombrePrivilegio
        public CE_Privilegios ServicioConsultarNombrePrivilegio(int IdPrivilegio)
        {
            return objectDatos.ConsultarNombrePrivilegio(IdPrivilegio);
        }
        #endregion

        #region Servicio : ListarPrivilegios
        public List<string> ServicioListarPrivilegios()
        {
            return objectDatos.ListarPrivilegios();
        }
        #endregion
    }
}
