using CapaNegocio;
using Crud_Wpf.Recursos.Boxes;
using System.Windows;
using System.Windows.Input;
using Application = System.Windows.Application;

namespace Crud_Wpf.View
{
    public partial class Login : Window
    {


        Error error;
        CN_Login serviciosLogin;

        #region Constructor
        public Login()
        {
            InitializeComponent();
            tblUsuario.Focus();

        }
        #endregion

        #region Minimizar
        private void BtnMinimizar_Click(object sender, RoutedEventArgs e)
        {
            WindowState = WindowState.Minimized;
        }

        #endregion

        #region Cerrar App
        //CERRAR APLICACION
        private void BtnCerrar_Click(object sender, RoutedEventArgs e)
        {
            // Ventana para confirmar salida de la aplicacion
            MessageBoxResult result = MessageBox.Show("¿Está seguro que desea salir?", "Salir", MessageBoxButton.YesNo, MessageBoxImage.Question);
            if (result == MessageBoxResult.Yes)
            {
                Application.Current.Shutdown();
            }

        }
        #endregion

        #region Mover Ventana
        //MOVER VENTANA CON CLICK-SOSTENIDO
        private void Window_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.LeftButton == MouseButtonState.Pressed)
                DragMove();
        }
        #endregion

        #region Login
        private void BtnIngresar_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrEmpty(tblUsuario.Text) || string.IsNullOrEmpty(tblUsuario.Text))//Valida que los campos no esten vacios
            {
                tblMensaje.Text = "¡Los campos no pueden estar vacios!";
            }
            else// Si no se hace un Try-Catch para el logeo
            {
                #region Try
                try
                {
                    serviciosLogin = new CN_Login();
                    int count = serviciosLogin.ServicioValidarUsuario(tblUsuario.Text);

                    if (count > 0)
                    {
                        string Psw = serviciosLogin.ServicioValidarContrasena(tblUsuario.Text);

                        if (tblContrasena.Password == Psw)//Valida contraseña
                        {
                            int Privilegio = serviciosLogin.ServicioObtenerPrivilegio(tblUsuario.Text);
                            int Id = serviciosLogin.ServicioObtenerIdUser(tblUsuario.Text);
                            Inicio inicio = new Inicio(Privilegio, Id);
                            this.Close();
                            inicio.Show();
                        }
                        else //Contrseña incorrecta
                        {
                            tblMensaje.Text = "Contaseña incorrecta";
                        }
                    }
                    else//Usuario incorrecto
                    {
                        tblMensaje.Text = "Usuario incorrecto";
                    }
                }
                #endregion

                #region Catch
                catch (System.Exception ex)
                {
                    error = new Error();
                    error.lbError.Text = ex.Message;
                    error.ShowDialog();
                }
                #endregion
            }
        }
        #endregion
    }
}

