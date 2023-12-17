using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using CapaNegocio;

namespace Crud_Wpf.View
{
    
    public partial class MiCuenta : Window
    { 
        Window Ventana;
        CN_Usuarios ServiciosUsuario;

        public MiCuenta(Window A, int _MiId, int Miprivilegio)
        {
            Ventana = A;
            InitializeComponent();
            ServiciosUsuario = new CN_Usuarios();
            var a = ServiciosUsuario.ServiceConsultar(_MiId);


            tbNombre.Text += " " + a.Nombres.ToString();
            tbApellido.Text += " " + a.Apellidos.ToString();
            tbCorreo.Text += " " + a.Correo.ToString();

            tbPrivilegio.Text += " "+ Miprivilegio.ToString();

            ImageSourceConverter img = new ImageSourceConverter();
            Img.Source = (ImageSource)img.ConvertFrom(a.Img);
        }
        private void Cerrar(object sender, MouseButtonEventArgs e)
        {
            Ventana.Opacity = 1;
            this.Close();
        }
    }
}
