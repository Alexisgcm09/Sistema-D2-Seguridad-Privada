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
    public partial class Operativo : Form
    {
        public Operativo()
        {
            InitializeComponent();
            cargar();
        }
        Conexion conexion = new Conexion();
        Conexion conexion1 = new Conexion();
        Conexion conexion2 = new Conexion();
        Conexion conexion3 = new Conexion();
        Conexion conexion4 = new Conexion();
        Conexion conexion5 = new Conexion();
        Conexion conexion6 = new Conexion();
        Conexion conexion7 = new Conexion();
        Conexion conexion8 = new Conexion();
        Conexion conexion9 = new Conexion();
        Conexion conexion10 = new Conexion();
        Conexion conexion11 = new Conexion();
        Conexion conexion12 = new Conexion();
        Conexion conexion13 = new Conexion();
        public void cargar()
        {
            dataGridView3.DataSource = conexion.cargarDatos("SELECT idd2_servicios AS 'ID SERVICIO', nombreS AS 'NOMBRE SERVICIO'  " +
                ",RFC, RazonSocial AS 'Razon Social', Domicilio, FechaAlta AS 'FECHA ALTA', RepresentanteAdmin AS 'Administrador', " +
                "NoGuar AS 'Numero De Guardias', TurnoBD AS 'TURNO 12 HD', TurnoBN AS 'TURNO 12 HN', TurnoC AS 'TURNO 24 HRS', EdoS AS 'ESTADO 90'" +
                ", TelDelta AS 'CEL DELTA', TelAdminS AS 'TEL. ADMIN' FROM d2_bd.d2_servicios");
            dataGridView2.DataSource = conexion6.cargarDatos("SELECT idd2_servicios AS 'ID SERVICIO', nombreS AS 'NOMBRE SERVICIO' " +
                ",FechaAlta AS 'FECHA ALTA', EdoS AS 'ESTADO 90' FROM d2_bd.d2_servicios");
            dataGridView1.DataSource = conexion4.cargarDatos("SELECT * FROM d2_bd.d2_servicios");
        }

        //BOTON AGREGAR SERVICIO
        private void button1_Click(object sender, EventArgs e)
        {
            //VARIABLES
            string idusu = "";
            string fecha = dateFechaDeAltaS.Value.ToString("yyyy-MM-dd");
            int NoG = int.Parse(txtNoGuardias.Text);
            int NoGBD = int.Parse(txtTurnoBD.Text);
            int NoGBN = int.Parse(txtTurnoBN.Text);
            int NoGC = int.Parse(txtTurnoC.Text);
            DataTable tb2 = new DataTable();
            //CONSULTA PARA TRAER EL ID DE USUARIO
            string consulta = "SELECT d2_bd.d2_users.idd2_users FROM d2_bd.d2_users WHERE NuUsuario = '" + textBox43.Text + "'";
            DataTable tb = new DataTable();
            conexion1.ejecutarQuery(consulta);
            tb = conexion1.cargarDatos(consulta);
            idusu = tb.Rows[0]["idd2_users"].ToString();

            string consulta1 = "INSERT INTO d2_bd.d2_servicios(nombreS,RFC,RazonSocial,Domicilio,FechaAlta,RepresentanteAdmin,NoGuar,TurnoBD," +
                "TurnoBN,TurnoC,EdoS,TelDelta,TelAdminS,idd2_users,nombreUser) VALUES('"+txtNombreS.Text+"','"+txtRFC_S.Text+"','"+txtRSocialS.Text+"'" +
                ",'"+txtDomicilioS.Text+"','"+fecha+"','"+txtRepAdmin.Text+"',"+NoG+","+NoGBD+","+NoGBN+" " +
                ","+NoGC+",'"+cmbEdoS.SelectedItem+"','"+txtTelDelta.Text+"','"+txtTelAdmin.Text+"',"+idusu+",'"+textBox42.Text+"')";

            if (conexion2.ejecutarQuery(consulta1))
            {
                conexion13.ejecutarQuery(consulta);
                MessageBox.Show("Servicio registrado correctamente");
                DataTable dt2 = (DataTable)dataGridView1.DataSource;
                DataTable dt1 = (DataTable)dataGridView2.DataSource;
                DataTable dt3 = (DataTable)dataGridView3.DataSource;
                dt2.Clear();
                dt1.Clear();
                dt3.Clear();
                cargar();
                tb2.Clear();
                tb.Clear();
                Limpiar();
            }
            else
            {
                MessageBox.Show("!Error!");
                tb2.Clear();
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            txtID.Text = dataGridView1.CurrentRow.Cells[0].Value.ToString();
            txtNombreS2.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
            txtRFC2.Text = dataGridView1.CurrentRow.Cells[2].Value.ToString();
            txtRazonS2.Text = dataGridView1.CurrentRow.Cells[3].Value.ToString();
            txtDomS2.Text = dataGridView1.CurrentRow.Cells[4].Value.ToString();
            dateFechaA2.Text = dataGridView1.CurrentRow.Cells[5].Value.ToString();
            txtRepAdmin2.Text = dataGridView1.CurrentRow.Cells[6].Value.ToString();
            txtNoG2.Text = dataGridView1.CurrentRow.Cells[7].Value.ToString();
            txtTurnoBD2.Text = dataGridView1.CurrentRow.Cells[8].Value.ToString();
            txtTurnoBN2.Text = dataGridView1.CurrentRow.Cells[9].Value.ToString();
            txtTurnoC2.Text = dataGridView1.CurrentRow.Cells[10].Value.ToString();
            cmbEdoS2.Text = dataGridView1.CurrentRow.Cells[11].Value.ToString();
            txtTelDelta2.Text = dataGridView1.CurrentRow.Cells[12].Value.ToString();
            txtTelAdmin2.Text = dataGridView1.CurrentRow.Cells[13].Value.ToString();
        }

        //MODIFICAR SERVICIO
        private void button2_Click(object sender, EventArgs e)
        {
            //VARIABLES
            int idusu;
            string fecha = DateTime.Now.ToString("yyyy-MM-dd");
            int NoG = int.Parse(txtNoG2.Text);
            int NoGBD2 = int.Parse(txtTurnoBD2.Text);
            int NoGBN2 = int.Parse(txtTurnoBN2.Text);
            int NoGC2 = int.Parse(txtTurnoC2.Text);
            int id = int.Parse(txtID.Text);
            string modifico = "Servicio";
            DataTable tb2 = new DataTable();

            //CONSULTA PARA TRAER EL ID DE USUARIO
            string consulta = "SELECT d2_bd.d2_users.idd2_users FROM d2_bd.d2_users WHERE NuUsuario = '" + textBox16.Text + "'";
            DataTable tb = new DataTable();
            conexion3.ejecutarQuery(consulta);
            tb = conexion3.cargarDatos(consulta);
            idusu = (int)tb.Rows[0]["idd2_users"];

            //CONSULTA PARA INSERTAR DATOS DEL LA MODIFICACION
            string consulta3 = "INSERT INTO d2_bd.d2_modificar90(idservicio,nombreServicio,fechaC,usuarioMod,idusers,modifico) VALUES(" + txtID.Text + "" +
                ",'" + txtNombreS2.Text + "', '" + fecha + "', '" + textBox15.Text + "'," + idusu + ",'" + modifico + "' )";

            //CONSULTA PARA MODIFICAR 
            string consulta2 = "UPDATE d2_bd.d2_servicios SET nombreS ='"+txtNombreS2.Text+"', RFC='"+txtRFC2.Text+"',RazonSocial='"+txtRazonS2.Text+"', " +
                "Domicilio='"+txtDomS2.Text+"', FechaAlta='"+fecha+"',RepresentanteAdmin='"+txtRepAdmin2.Text+ "', NoGuar = "+NoG+", TurnoBD="+NoGBD2+"  " +
                ", TurnoBN="+NoGBN2+", TurnoC="+NoGC2+", EdoS='"+cmbEdoS2.SelectedItem+"',TelDelta='"+txtTelDelta2.Text+"',TelAdminS='"+txtTelAdmin2.Text+"'" +
                ",idd2_users="+idusu+",nombreUser='"+textBox15.Text+"' WHERE idd2_servicios = "+id+" ";
             
            if (conexion5.ejecutarQuery(consulta2))
            {
                MessageBox.Show("Servicio Modificado correctamente");
                DataTable dt2 = (DataTable)dataGridView1.DataSource;
                DataTable dt1 = (DataTable)dataGridView2.DataSource;
                DataTable dt3 = (DataTable)dataGridView3.DataSource;
                dt2.Clear();
                dt1.Clear();
                dt3.Clear();
                cargar();
                tb2.Clear();
                tb.Clear();
                Limpiar2();
            }
            else
            {
                MessageBox.Show("!Error!");
                tb2.Clear();
            }

        }


        //MODIFICAR ESTADO DEL SERVCIO
        private void button3_Click(object sender, EventArgs e)
        {
            //VARIABLES
            int ids = int.Parse(txtIDS2.Text);
            string nombre90 = "";
            string fecha = dateFechaBajaS2.Value.ToString("yyyy-MM-dd");
            int idu;
            string modifico = "Estado Servicio";
            DataTable tb2 = new DataTable();

            //CONSULTA PARA ACTUALIZAR EL ESTADO DEL SERVICIO
            string consulta = "UPDATE d2_bd.d2_servicios SET EdoS='" + cmbEdo3.Text + "' WHERE idd2_servicios=" + ids + "";

            //CONSULTA PARA TRAER EL NOMBRE DEL SERVICIO
            string consulta3 = "SELECT nombreS FROM d2_bd.d2_servicios WHERE idd2_servicios=" + ids + "";
            DataTable tb = new DataTable();
            conexion9.ejecutarQuery(consulta3);
            tb = conexion9.cargarDatos(consulta3);
            nombre90 = tb.Rows[0]["nombreS"].ToString();

            //CONSULTA PARA TRAER EL ID DEL USUARIO QUE MODIFICO
            string consulta4 = "SELECT idd2_users FROM d2_bd.d2_users WHERE NuUsuario=" + ids + "";
            DataTable tb1 = new DataTable();
            conexion10.ejecutarQuery(consulta4);
            tb1 = conexion10.cargarDatos(consulta4);
            idu = (int)tb1.Rows[0]["idd2_users"];

            //CONSULTA PARA INSERTAR DATOS DEL LA MODIFICACION
            string consulta2 = "INSERT INTO d2_bd.d2_modificar90(idservicio,nombreServicio,fechaC,usuarioMod,idusers,modifico) VALUES(" + idu + "" +
                ",'" + nombre90 + "', '" + fecha + "', '" + textBox17.Text+"',"+idu+",'"+modifico+"' )";

            if (conexion11.ejecutarQuery(consulta))
            {
                conexion12.ejecutarQuery(consulta2);
                MessageBox.Show("Servicio Modificado Correctamente");
                DataTable dt2 = (DataTable)dataGridView1.DataSource;
                DataTable dt3 = (DataTable)dataGridView2.DataSource;
                DataTable dt4 = (DataTable)dataGridView3.DataSource;
                dt2.Clear();
                dt3.Clear();
                dt4.Clear();
                Limpiar3();
                cargar();
                tb2.Clear();
            }
            else
            {
                MessageBox.Show("!Error!");
                tb2.Clear();
            }
        }

        private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            txtIDS2.Text = dataGridView2.CurrentRow.Cells[0].Value.ToString();      
            cmbEdo3.Text = dataGridView2.CurrentRow.Cells[3].Value.ToString();
        }

        //BOTON DE SALIR
        private void button5_Click(object sender, EventArgs e)
        {
            string idusu = "";
            string tipo = "";

            //CONSULTA PARA TRAERT EL ID DE USUARIO
            string consulta = "SELECT d2_bd.d2_users.idd2_users FROM d2_bd.d2_users WHERE NuUsuario = '" + textBox43.Text + "'";
            DataTable tb = new DataTable();
            conexion7.ejecutarQuery(consulta);
            tb = conexion7.cargarDatos(consulta);
            idusu = tb.Rows[0]["idd2_users"].ToString();

            //CONSULTA PARA TRAER EL TIPO DE USUARIO
            string consulta2 = "SELECT d2_bd.d2_users.TipoUs FROM d2_bd.d2_users WHERE NuUsuario = '" + textBox43.Text + "'";
            DataTable tb2 = new DataTable();
            conexion8.ejecutarQuery(consulta2);
            tb2 = conexion8.cargarDatos(consulta2);
            tipo = tb2.Rows[0]["TipoUs"].ToString();

            if (tipo.Equals("Super Admin"))
            {
                string noUsu = textBox43.Text;
                string nombre = textBox42.Text;
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

        private void Operativo_Load(object sender, EventArgs e)
        {
            string Date = DateTime.Now.ToString();
            lblFecha1.Text = Date;
            lblFecha2.Text = Date;
            lblFecha3.Text = Date;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Limpiar();
        }

        public void Limpiar()
        {
            txtNombreS.Text = "";
            txtRFC_S.Text = "";
            txtRSocialS.Text = "";
            txtDomicilioS.Text = "";
            dateFechaDeAltaS.Text = "";
            txtRepAdmin.Text = "";
            txtNoGuardias.Text = "";
            txtTurnoBD.Text = "";
            txtTurnoBN.Text = "";
            txtTurnoC.Text = "";
            cmbEdoS.Text = "";
            txtTelDelta.Text = "";
            txtTelAdmin.Text = "";
        }

        private void button6_Click(object sender, EventArgs e)
        {
            Limpiar2();
        }

        public void Limpiar2()
        {
            txtID.Text = "";
            txtNombreS2.Text = "";
            txtRFC2.Text = "";
            txtRazonS2.Text = "";
            txtDomS2.Text = "";
            dateFechaA2.Text = "";
            txtRepAdmin2.Text = "";
            txtNoG2.Text = "";
            txtTurnoBD2.Text = "";
            txtTurnoBN2.Text = "";
            txtTurnoC2.Text = "";
            cmbEdoS2.Text = "";
            txtTelDelta2.Text = "";
            txtTelAdmin2.Text = "";
        }

        Conexion conexion14 = new Conexion();
        private void textBox13_KeyUp(object sender, KeyEventArgs e)
        {
            dataGridView1.DataSource = conexion14.cargarDatos2("SELECT * FROM d2_bd.d2_servicios WHERE NombreS like ('" + textBox13.Text + "%')");
        }

        private void button7_Click(object sender, EventArgs e)
        {
            Limpiar3();
        }

        public void Limpiar3()
        {
            txtIDS2.Text = "";
            cmbEdo3.Text = "";
        }

        Conexion conexion15 = new Conexion();
        private void textBox20_KeyUp(object sender, KeyEventArgs e)
        {
            dataGridView3.DataSource = conexion15.cargarDatos2("SELECT idd2_servicios AS 'ID SERVICIO', nombreS AS 'NOMBRE SERVICIO'  " +
                ",RFC, RazonSocial AS 'Razon Social', Domicilio, FechaAlta AS 'FECHA ALTA', RepresentanteAdmin AS 'Administrador', " +
                "NoGuar AS 'Numero De Guardias', TurnoBD AS 'TURNO 12 HD', TurnoBN AS 'TURNO 12 HN', TurnoC AS 'TURNO 24 HRS', EdoS AS 'ESTADO 90'" +
                ", TelDelta AS 'CEL DELTA', TelAdminS AS 'TEL. ADMIN' FROM d2_bd.d2_servicios  WHERE NombreS like ('" + textBox20.Text + "%')");
        }
    }
}
