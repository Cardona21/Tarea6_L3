using BL_Fiestas;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Fiestas
{
    public partial class FromReporteInventario : Form
    {
        public FromReporteInventario()
        {
            InitializeComponent();

            var _reservaBL = new ReservaBL();
            var bindingSource = new BindingSource();
            bindingSource.DataSource = _reservaBL.ObtenerReservas();

            var reporte = new ReporteInventario();
            reporte.SetDataSource(bindingSource);

            crystalReportViewer1.ReportSource = reporte;
            crystalReportViewer1.RefreshReport();

        }

        private void crystalReportViewer1_Load(object sender, EventArgs e)
        {

        }
    }
}
