using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaEntidad
{
    public class CE_Usuarios
    {
        public int IdUsuario { get; set; }
        public string Nombres { get; set; }
        public string Apellidos { get; set; }
        public int DUI { get; set; }
        public float NIT { get; set; }
        public string Correo { get; set; }
        public int Telefono { get; set; }
        public DateTime FechaNac { get; set; }
        public int Privilegio { get; set; }
        public byte[] Img { get; set; }
        public string Usuario { get; set; }
        public string Contrasena { get; set; }
        public string Patron { get; set; }
    }
}
