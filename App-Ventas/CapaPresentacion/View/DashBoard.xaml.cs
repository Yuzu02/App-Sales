using CapaNegocio;
using LiveCharts;
using System.Data;
using System.Windows.Controls;

namespace Crud_Wpf.View
{
    public partial class DashBoard : UserControl
    {
        int MiId;
        public ChartValues<decimal> Values { get; set; }
        CN_Dashboard ServiciosDasboard;
        public DashBoard(int _miId)
        {

            InitializeComponent();
            MiId = _miId;
            ServiciosDasboard = new CN_Dashboard();
            lbVentasTotales.Content = ServiciosDasboard.CantidadVentas().ToString();
            lbArticulosDisp.Content = ServiciosDasboard.ArticulosDisponibles().ToString();
            Values = new ChartValues<decimal>();

            foreach (DataRow row in ServiciosDasboard.Grafico().Rows)
            {
                decimal i = decimal.Parse(row["monto_Total"].ToString());
                Values.Add(i);
            }
            DataContext = this;
        }


    }
}
