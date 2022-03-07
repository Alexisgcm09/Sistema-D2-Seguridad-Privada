using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Sistema_D2_Seguridad_Privada
{
    public partial class ReporteEmpleados : Form
    {
        public ReporteEmpleados()
        {
            InitializeComponent();
        }

        private void ReporteEmpleados_Load(object sender, EventArgs e)
        {
            // TODO: esta línea de código carga datos en la tabla 'DatosSD2.sp_empleados' Puede moverla o quitarla según sea necesario.
            this.sp_empleadosTableAdapter.Fill(this.DatosSD2.sp_empleados);

            this.reportViewer1.RefreshReport();
        }
    }
}
