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
    public partial class ReporteEmpleado : Form
    {
        public ReporteEmpleado()
        {
            InitializeComponent();
        }
        public string d;
        private void ReporteEmpleado_Load(object sender, EventArgs e)
        {
            //para el filtro de reporte------------------
            Reportes RP = new Reportes();
            int id = int.Parse(d); 
            //------------------------------------------

            // TODO: esta línea de código carga datos en la tabla 'DatosSD2.d2_empleados' Puede moverla o quitarla según sea necesario.
            this.d2_empleadosTableAdapter.Fill(this.DatosSD2.d2_empleados,id);

            this.reportViewer1.RefreshReport();
        }
    }
}
