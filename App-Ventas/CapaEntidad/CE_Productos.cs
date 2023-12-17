using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaEntidad
{
    public class CE_Productos
    {
        public int IdArticulo { get; set; }
        public string Nombre { get; set; }
        public int Grupo { get; set; }
        public string Codigo { get; set; }
        public decimal Precio { get; set; }
        public bool Activo { get; set; }
        public decimal Cantidad { get; set; }
        public string UnidadMedida { get; set; }
        public Byte[] Img { get; set; }
        public string Descripcion { get; set; }
    }
}
