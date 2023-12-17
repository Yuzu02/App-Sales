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

namespace Crud_Wpf.View
{
    /// <summary>
    /// Lógica de interacción para AcercaDe.xaml
    /// </summary>
    public partial class AcercaDe : Window
    {
        Window Aa;
        public AcercaDe(Window _Aa)
        {
            Aa = _Aa;
            InitializeComponent();
        }

        private void Cerrar(object sender, MouseButtonEventArgs e)
        {
            Aa.Opacity = 1;
            this.Close();
        }
    }
}
