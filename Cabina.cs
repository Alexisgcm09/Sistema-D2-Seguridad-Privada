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
    public partial class Cabina : Form
    {
        public Cabina()
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
            dataGridView1.DataSource = conexion.cargarDatos("SELECT * FROM d2_bd.d2_empleados");          
            dataGridView2.DataSource = conexion3.cargarDatos("SELECT nombreS AS 'NOMBRE DEL 90', Domicilio, NoGuar AS 'NUMERO DE GUARDIAS'  " +
                ", TelDelta AS 'CEL. 90' FROM d2_bd.d2_servicios");
        }


        private void button2_Click(object sender, EventArgs e)
        {
            string idusu = "";
            string tipo = "";

            //CONSULTA PARA TRAER EL ID DE USUARIO
            string consulta = "SELECT d2_bd.d2_users.idd2_users FROM d2_bd.d2_users WHERE NuUsuario = '" + textBox3.Text + "'";
            DataTable tb = new DataTable();
            conexion1.ejecutarQuery(consulta);
            tb = conexion1.cargarDatos(consulta);
            idusu = tb.Rows[0]["idd2_users"].ToString();

            //CONSULTA PARA TRAER EL TIPO DE USUARIO
            string consulta2 = "SELECT d2_bd.d2_users.TipoUs FROM d2_bd.d2_users WHERE NuUsuario = '" + textBox3.Text + "'";
            DataTable tb2 = new DataTable();
            conexion2.ejecutarQuery(consulta2);
            tb2 = conexion2.cargarDatos(consulta2);
            tipo = tb2.Rows[0]["TipoUs"].ToString();

            if (tipo.Equals("Super Admin"))
            {
                string noUsu = textBox3.Text;
                string nombre = textBox2.Text;
                super sp = new super();
                sp.textBox1.Text = noUsu;
                sp.textBox2.Text = nombre;
                sp.Show();
                this.Close();
            }
            else
            {
                if (!tipo.Equals("Super Admin"))
                {
                    if (MessageBox.Show("¿Desea Cerrar Sesión?", "Cerrar Sesión", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) == System.Windows.Forms.DialogResult.Yes)
                    {
                        Login lg = new Login();
                        lg.Show();
                        this.Close();
                    }
                }
            }
        }

        private void Cabina_Load(object sender, EventArgs e)
        {
            string Date = DateTime.Now.ToString();
            lblFecha1.Text = Date;
            lblFecha2.Text = Date;
        }


        Conexion conexion4 = new Conexion();
        private void textBox23_KeyUp(object sender, KeyEventArgs e)
        {
            dataGridView1.DataSource = conexion4.cargarDatos2("SELECT * FROM d2_bd.d2_empleados WHERE Nombre like ('" + textBox23.Text + "%')");
        }

        Conexion conexion5 = new Conexion();
        private void textBox1_KeyUp(object sender, KeyEventArgs e)
        {
            dataGridView2.DataSource = conexion5.cargarDatos2("SELECT nombreS AS 'NOMBRE DEL 90', Domicilio, NoGuar AS 'NUMERO DE GUARDIAS'  " +
                ", TelDelta AS 'CEL. 90' FROM d2_bd.d2_servicios WHERE NombreS like ('" + textBox1.Text + "%')");
        }
    }
}
