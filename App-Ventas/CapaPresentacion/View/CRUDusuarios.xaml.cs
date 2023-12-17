using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.IO;
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
using CapaEntidad;
using CapaNegocio;
using System.Security.Cryptography.X509Certificates;

namespace Crud_Wpf.View
{

    public partial class CRUDusuarios : Page
    {
        readonly CN_Usuarios Servicios = new CN_Usuarios();
        readonly CE_Usuarios ModeloUsuario = new CE_Usuarios();
        readonly CN_Privilegios ServiciosPrivilegio = new CN_Privilegios();

        #region Inicio
        public CRUDusuarios()
        {
            InitializeComponent();
            CargarCB();//Llamado del metodo para mostrar los privilegios en el CB
        }
        #endregion

        #region CargarPrivilegios
        private void CargarCB()
        {
            List<string> Privilegios = ServiciosPrivilegio.ServicioListarPrivilegios();
            for(int i = 0; i < Privilegios.Count; i++)
            {
                cbPrivilegio.Items.Add(Privilegios[i]);
            }
        }
        #endregion

        #region Regresar
        private void BtnRegresar_Click(object sender, RoutedEventArgs e)
        {
            Content = new Usuarios();
        }
        #endregion

        #region validarCamposVacios
        public bool ValidarCamposVacios()
        {
            if (string.IsNullOrEmpty(tbNombre.Text) || string.IsNullOrEmpty(tbApe.Text) || string.IsNullOrEmpty(tbDui.Text) || string.IsNullOrEmpty(tbNit.Text) || string.IsNullOrEmpty(tbEmail.Text) || string.IsNullOrEmpty(tbTelefono.Text) || string.IsNullOrEmpty(tbTelefono.Text) || string.IsNullOrEmpty(cbPrivilegio.Text) || string.IsNullOrEmpty(tbUsuario.Text))
            {
                return true;
            }
            else
            {
                return false;
            }

        }
        #endregion

        #region CRUD

        public int IdUsuario;
        public string Patron = "FAMC";


        #region Create
        private void BtnCrear_Click(object sender, RoutedEventArgs e)
        {

            if (ValidarCamposVacios()==true && string.IsNullOrEmpty(tbContrasena.Text))
            {
                MessageBox.Show("Los campos no pueden estar vacios");
            }
            else
            {
                int Privilegio = ServiciosPrivilegio.ServicioConsultarIdPrivilegio(cbPrivilegio.Text);

                ModeloUsuario.Nombres = tbNombre.Text;
                ModeloUsuario.Apellidos = tbApe.Text;
                ModeloUsuario.DUI = Convert.ToInt32(tbDui.Text);
                ModeloUsuario.NIT = float.Parse(tbNit.Text);
                ModeloUsuario.Correo = tbEmail.Text;
                ModeloUsuario.Telefono = Convert.ToInt32(tbTelefono.Text);
                ModeloUsuario.FechaNac = Convert.ToDateTime(tbFecha.Text);
                ModeloUsuario.Privilegio = Privilegio;
                ModeloUsuario.Img = Data;
                ModeloUsuario.Usuario = tbUsuario.Text;
                ModeloUsuario.Contrasena = tbContrasena.Text;
                ModeloUsuario.Patron = Patron;

                Servicios.ServiceInsertar(ModeloUsuario);
                Content = new Usuarios();
            }
        }
        #endregion

        #region Read
        public void Consultar()
        {
            var m = Servicios.ServiceConsultar(IdUsuario);
            tbNombre.Text = m.Nombres.ToString();
            tbApe.Text = m.Apellidos.ToString();
            tbDui.Text = m.DUI.ToString();
            tbNit.Text = m.NIT.ToString();
            tbEmail.Text = m.Correo.ToString();
            tbTelefono.Text = m.Telefono.ToString();
            tbFecha.Text = m.FechaNac.ToString();
            var p = ServiciosPrivilegio.ServicioConsultarNombrePrivilegio(m.Privilegio);
            cbPrivilegio.Text = p.NombrePrivilegio.ToString();
            //Pendiente
            ImageSourceConverter img = new ImageSourceConverter();
            Image.Source = (ImageSource)img.ConvertFrom(m.Img);
            tbUsuario.Text = m.Usuario;

        }
        #endregion

        #region Update
        private void BtnModificar_Click(object sender, RoutedEventArgs e)
        {
            if (ValidarCamposVacios() == true)
            {
                MessageBox.Show("Los campos no pueden estar vacios");
            }
            else
            {
                int Privilegio = ServiciosPrivilegio.ServicioConsultarIdPrivilegio(cbPrivilegio.Text);

                ModeloUsuario.IdUsuario = IdUsuario;
                ModeloUsuario.Nombres = tbNombre.Text;
                ModeloUsuario.Apellidos = tbApe.Text;
                ModeloUsuario.DUI = Convert.ToInt32(tbDui.Text);
                ModeloUsuario.NIT = float.Parse(tbNit.Text);
                ModeloUsuario.Correo = tbEmail.Text;
                ModeloUsuario.Telefono = Convert.ToInt32(tbTelefono.Text);
                ModeloUsuario.FechaNac = Convert.ToDateTime(tbFecha.Text);
                ModeloUsuario.Privilegio = Privilegio;
                ModeloUsuario.Usuario = tbUsuario.Text;

                Servicios.ServiceActualizarDatos(ModeloUsuario);
                Content = new Usuarios();
            }
            if (string.IsNullOrEmpty(tbContrasena.Text) == false)
            {
                ModeloUsuario.Patron = Patron;
                ModeloUsuario.Contrasena = tbContrasena.Text;
                ModeloUsuario.IdUsuario = IdUsuario;
                Servicios.ServiceActualizarPassUsuario(ModeloUsuario);
                Content= new Usuarios();
                
            }
            if(UpImg == true)
            {
                ModeloUsuario.IdUsuario = IdUsuario;
                ModeloUsuario.Img = Data;
                Servicios.ServiceActualizarImgUsuario(ModeloUsuario);
                Content = new Usuarios();
            }
        }
        #endregion

        #region updateImg (En el formulario)
        bool UpImg = false; //Bandera booleana para validar si se selecciono imagen
        byte[] Data { get; set; }//Arreglo para almacenar los bytes de la imagen de usuario
        //Seleccionar y almacenar el valor de la imagen de usuarios en el arreglo de bytes
        private void BtnCambiarImg_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog fd = new OpenFileDialog();
            if (fd.ShowDialog() == true)
            {
                FileStream fs = new FileStream(fd.FileName, FileMode.Open, FileAccess.Read);
                Data = new Byte[fs.Length];
                fs.Read(Data, 0, System.Convert.ToInt32(Data.Length));
                fs.Close();
                ImageSourceConverter Imgs = new ImageSourceConverter();
                Image.SetValue(Image.SourceProperty, Imgs.ConvertFromString(fd.FileName.ToString()));
            }
            UpImg = true;
        }
        #endregion

        #region Delete
        private void BtnEliminar_Click(object sender, RoutedEventArgs e)
        {
            ModeloUsuario.IdUsuario = IdUsuario;
            Servicios.ServiceEliminar(ModeloUsuario);
            Content = new Usuarios();
        }
        #endregion

        #endregion
    }
}

