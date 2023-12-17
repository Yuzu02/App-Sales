using Crud_Wpf.Recursos.Boxes;
using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media.Imaging;

namespace Crud_Wpf.View
{

    public partial class Inicio : Window
    {
        readonly int Miprivilegio;
        readonly int MiId;
        Error error;
        public Inicio(int _Privilegio, int _MiId)
        {
            InitializeComponent();
            Miprivilegio = _Privilegio;
            MiId = _MiId;
            ValidarPrivilegios();
            if (Miprivilegio == 1)
            {
                DataContext = new DashBoard(MiId);
            }
            else
            {
                DataContext = new Pos(MiId);
            }

        }
        //ValidarPrivilegios
        private void ValidarPrivilegios()
        {
            if (Miprivilegio != 1)
            {
                ItemListProduct.Visibility = Visibility.Collapsed;
                ItemListUsers.Visibility = Visibility.Hidden;
                ItemListDashBoard.Visibility = Visibility.Hidden;
                ItemListDashBoard.Height = 0;
            }
        }
        //Metodo para cerrar la app
        private void BtnCerrar_Click(object sender, RoutedEventArgs e)
        {
            MessageBoxResult result = MessageBox.Show("¿Desea cerrar sesion y salir ?", "Salir", MessageBoxButton.YesNo, MessageBoxImage.Question);
            if (result == MessageBoxResult.Yes)
            {
                Application.Current.Shutdown();
            }
        }
        //Metodo para minimizar ventana
        private void BtnMinimizar_Click(object sender, RoutedEventArgs e)
        {
            WindowState = WindowState.Minimized;
        }
        //Evento para mover la ventana (con el click Presionado)

        //Metodo para determinar el estado inicial del BtnMenuLateral (MenuLateal)
        private void PreviewMouseLeftBottomDownBG(object sender, MouseButtonEventArgs e)
        {
            BtnMenuLateral.IsChecked = false;
        }
        //Metodo para configurar el menu lateral (Btn activado)
        private void BtnMenuLateral_Checked(object sender, RoutedEventArgs e)
        {
            GridContent.Opacity = 0.2;

            var imagePath = "../../Recursos/Img/MenuHide.png";
            var imageUri = new Uri(imagePath, UriKind.Relative);
            var imageSource = new BitmapImage(imageUri);
            ImageToggleButton.ImageSource = imageSource;
        }
        //Metodo para configurar el menu lateral (Btn Desactivado)
        private void BtnMenuLateral_Unchecked(object sender, RoutedEventArgs e)
        {
            GridContent.Opacity = 1;

            var imagePath = "../../Recursos/Img/MenuOpen.png";
            var imageUri = new Uri(imagePath, UriKind.Relative);
            var imageSource = new BitmapImage(imageUri);
            ImageToggleButton.ImageSource = imageSource;

        }
        //Metodo para acceder a la sección Usuarios
        private void BtnUsers_Click(object sender, RoutedEventArgs e)
        {
            DataContext = new Usuarios();
        }

        private void DashBoard(object sender, RoutedEventArgs e)
        {
            DataContext = new DashBoard(MiId);
        }

        private void BtnProduct_Click(object sender, RoutedEventArgs e)
        {
            DataContext = new Productos();
        }

        private void PuntoDeVenta(object sender, RoutedEventArgs e)
        {
            DataContext = new Pos(MiId);
        }
        private void MiCuenta(object sender, RoutedEventArgs e)
        {
            MiCuenta mc = new MiCuenta(this, MiId, Miprivilegio);
            this.Opacity = 1;
            mc.ShowDialog();
        }

        private void AcercaDe(object sender, RoutedEventArgs e)
        {
            AcercaDe ac = new AcercaDe(this);
            this.Opacity = 1;
            ac.ShowDialog();

        }
        private void BtnOut_Click(object sender, RoutedEventArgs e)
        {
            // Ventana para confirmar cierre de sesion 
            MessageBoxResult result = MessageBox.Show("¿Desea cerrar sesión?", "Cerrar sesión", MessageBoxButton.YesNo, MessageBoxImage.Question);
            if (result == MessageBoxResult.Yes)
            {
                Login login = new Login();
                this.Close();
                login.Show();
            }

        }
        public void Mover(Grid header)
        {
            var restaurar = false;

            header.MouseLeftButtonDown += (s, e) =>
            {
                if (e.ClickCount == 2)
                {
                    if ((ResizeMode == ResizeMode.CanResize) || (ResizeMode == ResizeMode.CanResizeWithGrip))
                    {
                        cambiarEstado();
                    }
                }
                else
                {
                    if (WindowState == WindowState.Maximized)
                    {
                        restaurar = true;
                    }
                    DragMove();
                }
            };
            header.MouseLeftButtonUp += (s, e) =>
            {
                restaurar = false;
            };
            header.MouseMove += (s, e) =>
            {
                if (restaurar)
                {
                    try
                    {
                        restaurar = false;
                        var mouseX = e.GetPosition(this).X;
                        var width = RestoreBounds.Width;
                        var x = mouseX - width / 2;
                        if (x < 0)
                        {
                            x = 0;
                        }
                        else if (x + width > SystemParameters.PrimaryScreenWidth)
                        {
                            x = SystemParameters.PrimaryScreenWidth - width;
                        }
                        WindowState = WindowState.Normal;
                        Left = x;
                        Top = 0;
                        DragMove();
                    }
                    catch (System.Exception ex)
                    {
                        error = new Error();
                        error.lbError.Text = ex.Message;
                        error.ShowDialog();
                    }
                }
            };
        }
        public void cambiarEstado()
        {
            switch (WindowState)
            {
                case WindowState.Normal:
                    {
                        WindowState = WindowState.Maximized;
                        break;
                    }
                case WindowState.Maximized:
                    {
                        WindowState = WindowState.Normal;
                        break;
                    }

            }
        }
        private void RestaurarVentana(object sender, RoutedEventArgs e)
        {
            Mover(sender as Grid);
        }
    }
}
