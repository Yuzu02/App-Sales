using CapaNegocio;
using System.Windows;
using System.Windows.Controls;

namespace Crud_Wpf.View
{

    public partial class Productos : UserControl
    {
        readonly CN_Productos ServiciosProductos = new CN_Productos();

        #region Constructor
        public Productos()
        {
            InitializeComponent();
            Buscar("");
        }
        #endregion

        #region Buscando
        public void Buscar(string buscar)
        {
            GridDatos.ItemsSource = ServiciosProductos.BuscarProducto(buscar).DefaultView;
        }
        private void TxBuscar_TextChanged(object sender, TextChangedEventArgs e)
        {
            Buscar(TxBuscar.Text);
        }

        #endregion

        #region CRUD

        #region Create
        private void BtnCrearProdcuto_Click(object sender, RoutedEventArgs e)
        {
            CRUDproductos FrmProductos = new CRUDproductos();
            FrameProductos.Content = FrmProductos;
            Contenido.Visibility = Visibility.Hidden;
        }

        #endregion

        #region Read
        private void BtnConsultar_Click(object sender, RoutedEventArgs e)
        {
            int id = (int)((Button)sender).CommandParameter;
            CRUDproductos Ventana = new CRUDproductos();
            FrameProductos.Content = Ventana;
            Contenido.Visibility = Visibility.Hidden;
            Ventana.BtnCrear.Visibility = Visibility.Hidden;
            Ventana.BtnEliminar.Visibility = Visibility.Hidden;
            Ventana.BtnModificar.Visibility = Visibility.Hidden;
            Ventana.IdProducto = id;
            Ventana.Consultar();
            Ventana.Titulo.Text = "Consulta de producto";
            Ventana.tbNombre.IsEnabled = false;
            Ventana.tbCodigo.IsEnabled = false;
            Ventana.tbCantidad.IsEnabled = false;
            Ventana.tbPrecio.IsEnabled = false;
            Ventana.tbUnidadMedida.IsEnabled = false;
            Ventana.tbDescripcion.IsEnabled = false;
            Ventana.tbActivo.IsEnabled = false;
            Ventana.cbGrupo.IsEnabled = false;
            Ventana.BtnCambiarImg.IsEnabled = false;
        }

        #endregion

        #region Update

        private void BtnModificar_Click(object sender, RoutedEventArgs e)
        {
            int id = (int)((Button)sender).CommandParameter;
            CRUDproductos Ventana = new CRUDproductos();
            FrameProductos.Content = Ventana;
            Contenido.Visibility = Visibility.Hidden;
            Ventana.BtnCrear.Visibility = Visibility.Hidden;
            Ventana.BtnEliminar.Visibility = Visibility.Hidden;
            Ventana.BtnModificar.Visibility = Visibility.Visible;
            Ventana.IdProducto = id;
            Ventana.Consultar();
            Ventana.Titulo.Text = "Actualizar productos";
            Ventana.tbNombre.IsEnabled = true;
            Ventana.tbCodigo.IsEnabled = true;
            Ventana.tbCantidad.IsEnabled = true;
            Ventana.tbPrecio.IsEnabled = true;
            Ventana.tbUnidadMedida.IsEnabled = true;
            Ventana.tbDescripcion.IsEnabled = true;
            Ventana.tbActivo.IsEnabled = true;
            Ventana.cbGrupo.IsEnabled = true;
            Ventana.BtnModificar.Visibility = Visibility.Visible;
        }


        #endregion

        #region Delete
        private void BtnEliminar_Click(object sender, RoutedEventArgs e)
        {
            int id = (int)((Button)sender).CommandParameter;
            CRUDproductos Ventana = new CRUDproductos();
            FrameProductos.Content = Ventana;
            Contenido.Visibility = Visibility.Hidden;
            Ventana.BtnCrear.Visibility = Visibility.Hidden;
            Ventana.BtnEliminar.Visibility = Visibility.Visible;
            Ventana.BtnModificar.Visibility = Visibility.Hidden;
            Ventana.IdProducto = id;
            Ventana.Consultar();
            Ventana.Titulo.Text = "Eliminar producto";
            Ventana.tbNombre.IsEnabled = false;
            Ventana.tbCodigo.IsEnabled = false;
            Ventana.tbCantidad.IsEnabled = false;
            Ventana.tbPrecio.IsEnabled = false;
            Ventana.tbUnidadMedida.IsEnabled = false;
            Ventana.tbDescripcion.IsEnabled = false;
            Ventana.tbActivo.IsEnabled = false;
            Ventana.cbGrupo.IsEnabled = false;
            Ventana.BtnEliminar.Visibility = Visibility.Visible;
        }
        #endregion

        #endregion

    }
}
