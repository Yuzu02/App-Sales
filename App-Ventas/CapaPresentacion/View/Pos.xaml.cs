using System;
using System.Data;
using System.IO;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Media;
using CapaNegocio;
using Crud_Wpf.Recursos.Boxes;
using iTextSharp.text;
using iTextSharp.text.pdf;
using iTextSharp.tool.xml;
using Microsoft.Win32;

namespace Crud_Wpf.View
{
    /// <summary>
    /// Lógica de interacción para POST.xaml
    /// </summary>
    public partial class Pos : UserControl
    {
        Error error;
        int MiId;
        CN_Carrito ServiciosCarrito;
        public Pos(int _MiId)
        {
            MiId = _MiId;
            InitializeComponent();
            TbBuscar.Focus();
            Precio();
        }
        #region Buscar
        private void BuscarProducto(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrEmpty(TbBuscar.Text))
            {
                error = new Error();
                error.lbError.Text = "!No se ha seleccionado un producto¡";
                error.ShowDialog();
            }
            else
            {
                CN_Carrito ServiciosCarrito = new CN_Carrito();
                var carrito = ServiciosCarrito.Buscar(TbBuscar.Text);

                if(carrito.Nombre != null)
                {
                    TbNombre.Text = carrito.Nombre.ToString();
                    TbPrecio.Text = carrito.Precio.ToString();
                    TbCantidad.Focus();
                }
                else
                {
                error = new Error();
                error.lbError.Text = "!No se ha encotrado el producto¡";
                error.ShowDialog();
                }

            }
        }
        #endregion

        #region Agregar producto
        private void AgregarProducto(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrEmpty(TbNombre.Text) || string.IsNullOrEmpty(TbCantidad.Text))
            {
                error = new Error();
                error.lbError.Text = "!No se ha seleccionado un producto¡";
                error.ShowDialog();
                
            }
            else
            {
                string producto = TbNombre.Text;
                decimal cantidad = decimal.Parse(TbCantidad.Text);
                Agregar(producto, cantidad);
                Limpiar();
            }
        }

        void Agregar(string producto, decimal cantidad)
        {
            CN_Carrito ServiciosCarrito = new CN_Carrito();
            DataTable dt;
            if (GridDatos.HasItems)
            {
                cantidad += Existe(producto);
                dt = ServiciosCarrito.Agregar(producto, cantidad);
                GridDatos.Items.Add(dt);
            }
            else
            {
                dt = ServiciosCarrito.Agregar(producto,cantidad);
                GridDatos.Items.Add(dt);
            }
            Precio();
        }

        #region Existe

        decimal can = 0;

        public ref decimal Existe(string _xProducto)
        {
            for (int i = 0; i < GridDatos.Items.Count; i++)
            {
                int j = 1;
                DataGridCell celda = GetCelda(i, j);
                TextBlock tb = celda.Content as TextBlock;

                int k = 3;
                DataGridCell celda2 = GetCelda(i, k);
                TextBlock tb2 = celda2.Content as TextBlock;
                can = decimal.Parse(tb2.Text);

                if (tb.Text == _xProducto)
                {
                    GridDatos.Items.RemoveAt(i);

                }
                else
                {
                    can = 0;

                }

            }
            return ref can;
        }
        #endregion

        #endregion

        #region Limpiar
        void Limpiar()
        {
            TbBuscar.Text = "";
            TbNombre.Text = "";
            TbPrecio.Text = "";
            TbCantidad.Text = "";
            Precio();
        }
        #endregion

        decimal efectivo, cambio, total;

        #region Precio
        void Precio()
        {
            total = 0;
            for(int i = 0; i< GridDatos.Items.Count; i++)
            {
                decimal precio;
                int j = 4;
                DataGridCell celda = GetCelda(i,j);
                TextBlock tb = celda.Content as TextBlock;
                precio = decimal .Parse(tb.Text);
                total += precio;
            }
            total = total / 100;
            cambio = efectivo - total;
            lbCambio.Content = "Cambio : $" + cambio.ToString("###,###.00");
            lbEfectivo.Content = "Efectivo : $" + efectivo.ToString("###,###.00");
            lbTotal.Content = "Total : $" + total.ToString("###,###.00");
        }

        #endregion

        #region GetVisualChild
        public static T GetVisualChild<T>(Visual padre) where T : Visual
        {
            T hijo = default;
            int num = VisualTreeHelper.GetChildrenCount(padre);
            for (int i = 0; i<num;i++)
            {
                Visual v= (Visual)VisualTreeHelper.GetChild(padre,i);
                hijo = v as T;
                if (hijo == null)
                {
                    hijo = GetVisualChild<T>(v);
                }
                if(hijo != null)
                {
                    break;
                }
            }
            return hijo;
        }
        #endregion

        #region GetFila
        public DataGridRow GetFila(int Index)
        {
            DataGridRow fila = (DataGridRow)GridDatos.ItemContainerGenerator.ContainerFromIndex(Index);
            if(fila == null)
            {
                GridDatos.UpdateLayout();
                GridDatos.ScrollIntoView(GridDatos.Items[Index]);
                fila = (DataGridRow)GridDatos.ItemContainerGenerator.ContainerFromIndex(Index);
            }
            return fila;
        }
        #endregion

        #region GetCelda
        public DataGridCell GetCelda(int _fila, int columna)
        {
            DataGridRow fila = GetFila(_fila);
            if (fila != null)
            {
                DataGridCellsPresenter presenter = GetVisualChild<DataGridCellsPresenter>(fila);
                DataGridCell celda = (DataGridCell)presenter.ItemContainerGenerator.ContainerFromIndex(columna);
                if (celda == null)
                {
                    GridDatos.ScrollIntoView(fila, GridDatos.Columns[columna]);
                    celda = (DataGridCell)presenter.ItemContainerGenerator.ContainerFromIndex(columna);
                }
                return celda;
            }
            return null;
        }
        #endregion

        #region Eliminar Producto
        private void EliminarProducto(object sender, RoutedEventArgs e)
        {
            var selected = GridDatos.SelectedItem;

            if( selected != null)
            {
                GridDatos.Items.Remove(selected);
                if (GridDatos.Items.Count<1)
                {
                    efectivo = 0;
                }
            }
            Precio();
        }
        #endregion

        #region Cambiar Cantidad
        private void CambiarCantidad(object sender, RoutedEventArgs e)
        {
            var selection = GridDatos.SelectedItem;
            if( selection != null)
            {
                var celda = GridDatos.SelectedCells[0];
                var codigo = (celda.Column.GetCellContent(celda.Item) as TextBlock).Text;
                var ingresar = new Ingresar();
                ingresar.ShowDialog();

                if (ingresar.total > 0)
                {
                    GridDatos.Items.Remove(selection);
                    Agregar(codigo, ingresar.total);
                    Precio();
                }
            }
        }
        #endregion

        #region Efectivo
        private void Efectivo(object sender, RoutedEventArgs e)
        {
            var ingresar = new Ingresar();
            ingresar.ShowDialog();

            if (ingresar.Efectivo > 0)
            {
                efectivo = ingresar.Efectivo;
                Precio();
            }
        }
        #endregion

        #region AnularOrdern
        private void AnularOrdern(object sender, RoutedEventArgs e)
        {
            efectivo = 0;
            GridDatos.Items.Clear();
            Limpiar();
        }
        #endregion

        #region Pagar
        private void Pagar(object sender, RoutedEventArgs e)
        {
            if(GridDatos.Items.Count > 0)
            {
                Venta();
                efectivo = 0;
                Precio();
            }else
            {
                error = new Error();
                error.lbTitulo.Content = "Error";
                error.lbError.Text = "!No se ha agregado ningun producto¡";
                error.ShowDialog();
            }
        }

        void Venta()
        {
            string factura = "F-" + DateTime.Now.ToString("ddMMyyyyhhmmss")+"-"+MiId;
            DateTime fecha = DateTime.Now;
            ServiciosCarrito= new CN_Carrito();

            if (cambio >=0)
            {
                ServiciosCarrito.Venta(factura,total, fecha,MiId);
                VentaDetalle(factura);
                GridDatos.Items.Clear();
            }
            else
            {
                error = new Error();
                error.lbTitulo.Content = "Error";
                error.lbError.Text = "!Ingrese un pago mayor a la venta¡";
                error.ShowDialog();
            }

        }
        void VentaDetalle(string _factura)
        {
            ServiciosCarrito = new CN_Carrito();
            for(int i = 0; i < GridDatos.Items.Count; i++)
            {
                string codigo;
                decimal totalArticulos, cantidad;

                DataGridCell cell = GetCelda(i,0);
                TextBlock tb = cell.Content as TextBlock;
                codigo = tb.Text;

                DataGridCell cell2 = GetCelda(i, 3);
                TextBlock tb2 = cell2.Content as TextBlock;
                cantidad = decimal.Parse(tb2.Text);

                DataGridCell cell3 = GetCelda(i,  4);
                TextBlock tb3 = cell3.Content as TextBlock;
                totalArticulos = decimal.Parse(tb3.Text);

                ServiciosCarrito.VentaDetalle(codigo,cantidad, _factura,totalArticulos);
            }
            Imprimir(_factura);
        }

        void Imprimir(string _factura)
        {
            SaveFileDialog saveFile = new SaveFileDialog
            {
                FileName = _factura +".pdf"
            };
            string Pagina = Properties.Resources.Ticket.ToString();
            Pagina = Pagina.Replace("@Ticket", _factura);
            Pagina = Pagina.Replace("@efectivo", efectivo.ToString("###,###.00"));
            Pagina = Pagina.Replace("@cambio", cambio.ToString("###,###.00"));
            Pagina = Pagina.Replace("@Usuario", MiId.ToString());
            Pagina = Pagina.Replace("@Fecha", DateTime.Now.ToString("dd/MM/yyyy"));

            string filas = string.Empty;

            for(int i = 0; i < GridDatos.Items.Count; i++)
            {
                string nombre, cantidad;
                decimal precioUnitario, totalArticulos;

                DataGridCell cell = GetCelda(i, 1);
                TextBlock tb = cell.Content as TextBlock;
                nombre = tb.Text;

                DataGridCell cell2 = GetCelda(i, 3);
                TextBlock tb2 = cell2.Content as TextBlock;
                cantidad = tb2.Text;

                DataGridCell cell3 = GetCelda(i, 4);
                TextBlock tb3 = cell3.Content as TextBlock;
                totalArticulos = Decimal.Parse(tb3.Text);

                DataGridCell cell4 = GetCelda(i, 2);
                TextBlock tb4 = cell4.Content as TextBlock;
                precioUnitario = Decimal.Parse(tb4.Text);


                filas += "<tr>";
                filas += "<td align=\"center\">" + cantidad.ToString()+"</td>";
                filas += "<td align=\"center\">" + nombre.ToString()+"</td>";
                filas += "<td align=\"right\">" + (precioUnitario / 100).ToString("###,##.00")+"</td>";
                filas += "<td align=\"right\">" + (totalArticulos/100).ToString("###,##.00")+"</td>";
                filas += "</tr>";
            }
            int cant = GridDatos.Items.Count;
            Pagina = Pagina.Replace("@cant_articulos", cant.ToString());
            Pagina = Pagina.Replace("@grid", filas);
            Pagina = Pagina.Replace("@TOTAL", total.ToString("###,##.00"));

            if (saveFile.ShowDialog() != null || saveFile.FileName != string.Empty)
            {
                using (FileStream stream = new FileStream(saveFile.FileName, FileMode.Create))
                {
                    int artFilas = GridDatos.Items.Count;
                    Rectangle pageSize = new Rectangle(298, 420 + (artFilas * 10));
                    Document pdfDoc = new Document(pageSize, 25, 25, 25, 25);
                    PdfWriter writer = PdfWriter.GetInstance(pdfDoc, stream);
                    pdfDoc.Open();

                    using(StringReader sr = new StringReader(Pagina)) { 

                        XMLWorkerHelper.GetInstance().ParseXHtml(writer,pdfDoc, sr);
                    }
                    pdfDoc.Close();
                    stream.Close();
                }
                error = new Error();
                error.lbTitulo.Content = "$";
                error.lbError.Text = "!Venta realizada con exito¡";
                error.ShowDialog();
            }
        }
        #endregion
    }
}
