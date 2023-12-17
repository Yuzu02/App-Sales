using CapaNegocio;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Crud_Wpf.View
{

    public partial class Usuarios : UserControl
    {
        readonly CN_Usuarios _usuarios = new CN_Usuarios();

        #region Constructor
        public Usuarios()
        {
            InitializeComponent();
            Buscando("");
        }
        #endregion

        #region BtnCrearUsuario
        private void BtnCrearUsuario_Click(object sender, RoutedEventArgs e)
        {
            CRUDusuarios Ventana = new CRUDusuarios();
            FrameUsuarios.Content = Ventana;
            Contenido.Visibility = Visibility.Hidden;
            Ventana.BtnCrear.Visibility = Visibility.Visible;
        }

        #endregion

        #region BtnConsultarUsuario
        private void BtnConsultar_Click(object sender, RoutedEventArgs e)
        {
            int id = (int)((Button)sender).CommandParameter;
            CRUDusuarios Ventana = new CRUDusuarios();
            Ventana.IdUsuario = id;
            Ventana.Consultar();
            FrameUsuarios.Content = Ventana;
            Contenido.Visibility = Visibility.Hidden;
            Ventana.Titulo.Text = "Consulta de usuario";
            Ventana.tbNombre.IsEnabled = false;
            Ventana.tbApe.IsEnabled = false;
            Ventana.tbDui.IsEnabled = false;
            Ventana.tbNit.IsEnabled = false;
            Ventana.tbEmail.IsEnabled = false;
            Ventana.tbTelefono.IsEnabled = false;
            Ventana.tbFecha.IsEnabled = false;
            Ventana.cbPrivilegio.IsEnabled = false;
            Ventana.BtnCambiarImg.Visibility = Visibility.Hidden;
            Ventana.BtnCambiarImg.IsEnabled = false;
            Ventana.tbUsuario.IsEnabled = false;
            Ventana.tbContrasena.IsEnabled = false;
            Ventana.tbContrasena.Visibility = Visibility.Hidden;
            Ventana.txcontrasena.Visibility = Visibility.Hidden;
        }

        #endregion

        #region BtnModificarUsuario
        private void BtnModificar_Click(object sender, RoutedEventArgs e)
        {
            int id = (int)((Button)sender).CommandParameter;
            CRUDusuarios Ventana = new CRUDusuarios();
            Ventana.IdUsuario = id;
            Ventana.Consultar();
            FrameUsuarios.Content = Ventana;
            Contenido.Visibility = Visibility.Hidden;
            Ventana.Titulo.Text = "Actualizar de usuario";
            Ventana.tbNombre.IsEnabled = true;
            Ventana.tbApe.IsEnabled = true;
            Ventana.tbDui.IsEnabled = true;
            Ventana.tbNit.IsEnabled = true;
            Ventana.tbEmail.IsEnabled = true;
            Ventana.tbTelefono.IsEnabled = true;
            Ventana.tbFecha.IsEnabled = true;
            Ventana.cbPrivilegio.IsEnabled = true;
            Ventana.BtnCambiarImg.Visibility = Visibility.Visible;
            Ventana.BtnModificar.Visibility = Visibility.Visible;
            Ventana.BtnCambiarImg.IsEnabled = true;
            Ventana.tbUsuario.IsEnabled = true;
            Ventana.tbContrasena.IsEnabled = true;
        }

        #endregion

        #region BtnEliminarUsuario
        private void BtnEliminar_Click(object sender, RoutedEventArgs e)
        {
            int id = (int)((Button)sender).CommandParameter;
            CRUDusuarios Ventana = new CRUDusuarios();
            Ventana.IdUsuario = id;
            Ventana.Consultar();
            FrameUsuarios.Content = Ventana;
            Contenido.Visibility = Visibility.Hidden;
            Ventana.Titulo.Text = "Eliminación de usuario";
            Ventana.tbNombre.IsEnabled = false;
            Ventana.tbApe.IsEnabled = false;
            Ventana.tbDui.IsEnabled = false;
            Ventana.tbNit.IsEnabled = false;
            Ventana.tbEmail.IsEnabled = false;
            Ventana.tbTelefono.IsEnabled = false;
            Ventana.tbFecha.IsEnabled = false;
            Ventana.cbPrivilegio.IsEnabled = false;
            Ventana.BtnCambiarImg.Visibility = Visibility.Hidden;
            Ventana.BtnEliminar.Visibility = Visibility.Visible;
            Ventana.BtnCambiarImg.IsEnabled = false;
            Ventana.tbUsuario.IsEnabled = false;
            Ventana.tbContrasena.IsEnabled = false;
            Ventana.tbContrasena.Visibility = Visibility.Hidden;
            Ventana.txcontrasena.Visibility = Visibility.Hidden;
        }

        #endregion

        #region Buscar
        public void Buscando (string buscar)
        {
            GridDatos.ItemsSource=_usuarios.ServiceBuscarUsuario(buscar).DefaultView;
        }
        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            Buscando(TxBuscar.Text);
        }
        #endregion
    }
}
