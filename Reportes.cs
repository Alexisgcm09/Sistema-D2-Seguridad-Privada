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
    public partial class Reportes : Form
    {
        public Reportes()
        {
            InitializeComponent();
            cargar();
        }
        Conexion conexion = new Conexion();
        Conexion conexion1 = new Conexion();
        Conexion conexion2 = new Conexion();
        Conexion conexion3 = new Conexion();
        public void cargar()
        {
            dataGridView1.DataSource = conexion.cargarDatos("SELECT * FROM d2_bd.d2_users");
            dataGridView2.DataSource = conexion2.cargarDatos("SELECT * FROM d2_bd.d2_empleados");
        }

        private void button1_Click(object sender, EventArgs e)
        {
            ReportUsers RU = new ReportUsers();
            RU.Show();
        }

        private void textBox1_KeyUp(object sender, KeyEventArgs e)
        {
            dataGridView1.DataSource = conexion1.cargarDatos2("SELECT * FROM d2_bd.d2_users WHERE NombreUs like ('" + textBox1.Text + "%')");
        }

        private void button5_Click(object sender, EventArgs e)
        {
            string noUsu = textBox3.Text;
            string nombre = textBox2.Text;
            super sp = new super();
            sp.textBox1.Text = noUsu;
            sp.textBox2.Text = nombre;
            sp.Show();
            this.Close();
        }


        private void textBox4_KeyUp(object sender, KeyEventArgs e)
        {
            dataGridView2.DataSource = conexion3.cargarDatos2("SELECT * FROM d2_bd.d2_empleados WHERE Nombre like ('" + textBox4.Text + "%')");
        }

        private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            txtIDERe.Text = dataGridView2.CurrentRow.Cells[0].Value.ToString();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            ReporteEmpleados RE = new ReporteEmpleados();
            RE.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            ReporteEmpleado R = new ReporteEmpleado();
            //para el filtro de reporte---------
            string id = txtIDERe.Text;
            R.d = id;
            if (id.Equals(""))
            {
                MessageBox.Show("ID Vacio, Seleccione un empleado.");
            }
            else
            {
                R.Show();
            }
            //-------------------------------
        }
    }
}
