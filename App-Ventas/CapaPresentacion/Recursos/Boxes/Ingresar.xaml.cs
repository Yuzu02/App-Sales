using System;
using System.Collections.Generic;
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

namespace Crud_Wpf.Recursos.Boxes
{
    public partial class Ingresar : Window
    {
        #region Propiedades
        public decimal total { get; set; }
        public decimal Efectivo { get; set; }
        #endregion

        #region Constructor
        public Ingresar()
        {
            InitializeComponent();
            tbCantidad.Focus();
        }
        #endregion

        #region Ok
        private void Ok(object sender, RoutedEventArgs e)
        {
            bool esnumerico = decimal.TryParse(tbCantidad.Text, out decimal _);
            if (esnumerico)
            {
                total = decimal.Parse(tbCantidad.Text);
                Efectivo = decimal.Parse(tbCantidad.Text);
                this.Close();
            }
            else
            {
                this.Close();
            }
        }
        #endregion

        #region Cancelar
        private void Cancelar(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
        #endregion
    }
}
