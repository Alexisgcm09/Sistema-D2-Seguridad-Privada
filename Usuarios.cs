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
    public partial class Usuarios : Form
    {
        public Usuarios()
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
        Conexion conexion14 = new Conexion();
        Conexion conexion15 = new Conexion();
        Conexion conexion16 = new Conexion();
        Conexion conexion17 = new Conexion();

        //FUNCION PARA CARGAR LA TABLA
        public void cargar()
        {
            dataGridView1.DataSource = conexion3.cargarDatos("SELECT * FROM d2_bd.d2_users");
            dataGridView2.DataSource = conexion4.cargarDatos("SELECT * FROM d2_bd.d2_users");
            dataGridView3.DataSource = conexion7.cargarDatos("SELECT idd2_users, NuUsuario, NombreUs, EstadoUs FROM d2_bd.d2_users");
            dataGridView4.DataSource = conexion9.cargarDatos("SELECT idd2_users AS 'ID De Usuario Que Modifico', NombreUs AS 'Nombre Del Usuario Que Modifico', FechaMod AS 'Fecha De Modificacion', Modifico, UserMod AS 'ID De Usuario Modificado', UsModNombre AS 'Nombre De Usuario Modificado' FROM d2_bd.d2_modificar");
        }

        //BOTON INSERTAR
        private void button1_Click(object sender, EventArgs e)
        {
            string NoUs = txtNo.Text;
            string no2 = "";
            DataTable tb = new DataTable();
            //BUSCARA LOS USUARIOS QUE COINCIDA CON EL NUMERO DE USUARIO INGRESADO
            string consulta = "SELECT count(*) FROM d2_bd.d2_users WHERE NuUsuario = '" + NoUs + "' ";
            conexion.ejecutarQuery(consulta);
            tb = conexion.cargarDatos(consulta);
            no2 = tb.Rows[0]["count(*)"].ToString();
            //MessageBox.Show("El Conteo es: "+ no2 + " y el numero de usuario a registrar " + NoUs);
            //SI NO ENCUENTRA NINGUN USUARIO REGISTRADO CON EL NUMERO DE USUARIO INGRESADO LO REGISTRARA
            if (no2.Equals("0")) {
                //INSERTAR
                string consulta2 = "INSERT INTO d2_bd.d2_users(NuUsuario,NombreUs,ApellidoUs,TipoUs,ContraUs,DepartamentoUs,EstadoUs,ComentarioUs,UsAdd) values('" + txtNo.Text + "','" + txtNombre.Text + "','" + txtApellido.Text + "','" + cmbTipo.SelectedItem + "','" + txtContra.Text + "','" + cmbDepa.SelectedItem + "','" + cmbEstado.SelectedItem + "','" + txtComent.Text + "','" + textBox3.Text + "')";
                if (conexion2.ejecutarQuery(consulta2))
                {
                    MessageBox.Show("Usuario registrado correctamente");
                    DataTable dt = (DataTable)dataGridView1.DataSource;
                    DataTable dt1 = (DataTable)dataGridView2.DataSource;
                    DataTable dt2 = (DataTable)dataGridView3.DataSource;
                    DataTable dt3 = (DataTable)dataGridView4.DataSource;
                    dt.Clear();
                    dt1.Clear();
                    dt2.Clear();
                    dt3.Clear();
                    Limpiar();
                    cargar();
                    tb.Clear();
                }
                else
                {
                    MessageBox.Show("!Error!, El número de usuario ya EXISTE.");
                    txtNo.Text = "";
                    tb.Clear();
                }
            }
            else
            {
                MessageBox.Show("!Error!, El número de usuario ya EXISTE.");
                txtNo.Text = "";
                tb.Clear();
            }

        }


        //SOLO NUMEROS
        private void txtNo_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                MessageBox.Show("Solo se permiten números", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                e.Handled = true;
            }
        }

        private void txtNombre_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(char.IsLetter(e.KeyChar)) && (e.KeyChar != (char)Keys.Back))
            {
                MessageBox.Show("Solo se permiten letras", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                e.Handled = true;
                return;
            }
        }

        private void txtApellido_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(char.IsLetter(e.KeyChar)) && (e.KeyChar != (char)Keys.Back))
            {
                MessageBox.Show("Solo se permiten letras", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                e.Handled = true;
                return;
            }
        }

        private void button7_Click(object sender, EventArgs e)
        {
            string noUsu = textBox3.Text;
            string nombre = textBox1.Text;
            super sp = new super();
            sp.textBox1.Text = noUsu;
            sp.textBox2.Text = nombre;
            sp.Show();
            this.Close();
        }


        //BOTON ACTUALIZAR
        private void button2_Click(object sender, EventArgs e)
        {
            string cod = txtCod2.Text;
            string no2 = txtNo2.Text;
            string name = txtNombre2.Text;
            string ape = txtApellido2.Text;
            string edo = cmbEdo2.Text;
            string tip = cmbTipo2.Text;
            string com = txtComent2.Text;
            string con = txtContra2.Text;
            string depa = cmbDepa2.SelectedItem.ToString();
            string mod = "Usuario";
            string nuid = textBox5.Text;
            string idnu = "";
            string no = "";
            string nameUs = "";
            string idmod = txtCod2.Text;
            DateTime today = DateTime.Today;
            string fecha = today.ToString("yyyy-MM-dd");
            DataTable tb2 = new DataTable();

            //CONTAR LOS USUARIOS CON EL NUMERO DE USUARIO A REGISTRAR
            string consulta = "SELECT count(*) FROM d2_bd.d2_users WHERE NuUsuario = '" + no2 + "'";
            conexion6.ejecutarQuery(consulta);
            tb2 = conexion6.cargarDatos(consulta);
            no = tb2.Rows[0]["count(*)"].ToString();
            //MessageBox.Show("La cantidad de usuarios es: " + nous );
            //QUE NO EXISTA NINGUN USUARIO CON EL MISMO NUMERO DE USAUARIO
            if (no.Equals("1"))
            {
                //CONSULTAR USUARIO QUE VA MODIFICAR
                string consulta9 = "SELECT idd2_users, NombreUs FROM d2_bd.d2_users WHERE NuUsuario = '" + nuid + "' ";
                DataTable tb3 = new DataTable();
                tb3 = conexion10.cargarDatos(consulta9);
                idnu = tb3.Rows[0]["idd2_users"].ToString();
                nameUs = tb3.Rows[0]["NombreUs"].ToString();

                //MODIFICAR
                string consulta2 = "UPDATE d2_bd.d2_users SET NuUsuario= '" + no2 + "', NombreUs='" + name + "', ApellidoUs='" + ape + "' ,TipoUs='" + tip + "' , ContraUs='" + con + "' , DepartamentoUs ='" + depa + "' , EstadoUs ='" + edo + "' WHERE idd2_users=" + cod;
                //INSERTAR EN HISTORIAL DE MODIFICACIONES
                string consulta8 = "INSERT INTO d2_bd.d2_modificar(idd2_users,NombreUs,FechaMod,Modifico,UserMod,UsModNombre) values('" + idnu + "','" + nameUs + "','" + fecha + "','" + mod + "','" + idmod + "', '" + name + "')";

                if (conexion5.ejecutarQuery(consulta2))
                {
                    conexion8.ejecutarQuery(consulta8);
                    MessageBox.Show("Usuario Actualizado Correctamente");
                    DataTable dt = (DataTable)dataGridView1.DataSource;
                    DataTable dt1 = (DataTable)dataGridView2.DataSource;
                    DataTable dt2 = (DataTable)dataGridView3.DataSource;
                    DataTable dt3 = (DataTable)dataGridView4.DataSource;
                    dt.Clear();
                    dt1.Clear();
                    dt2.Clear();
                    dt3.Clear();
                    Limpiar2();
                    tb2.Clear();
                    tb3.Clear();
                    cargar();
                }
                else
                {
                    MessageBox.Show("¡Error!, Intente De Nuevo ó Comuniquese Con El Ing.");
                }
            }
            else
            {
                MessageBox.Show("Número De Usuario Ya EXISTE!, Intente Con Otro");
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            /* try
              {
                  txtCod2.Text = dataGridView1.CurrentRow.Cells[0].Value.ToString();
                  txtNo.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
                  txtNombre.Text = dataGridView1.CurrentRow.Cells[2].Value.ToString();
                  txtApellido.Text = dataGridView1.CurrentRow.Cells[3].Value.ToString();
                  cmbTipo.Text = dataGridView1.CurrentRow.Cells[4].Value.ToString();
                  txtContra.Text = dataGridView1.CurrentRow.Cells[5].Value.ToString();
                  cmbDepa.Text = dataGridView1.CurrentRow.Cells[6].Value.ToString();
                  cmbEstado.Text = dataGridView1.CurrentRow.Cells[7].Value.ToString();
                  txtComent.Text = dataGridView1.CurrentRow.Cells[8].Value.ToString();
              }
              catch (Exception ex)
              {
              }*/
        }

        private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                txtCod2.Text = dataGridView2.CurrentRow.Cells[0].Value.ToString();
                txtNo2.Text = dataGridView2.CurrentRow.Cells[1].Value.ToString();
                txtNombre2.Text = dataGridView2.CurrentRow.Cells[2].Value.ToString();
                txtApellido2.Text = dataGridView2.CurrentRow.Cells[3].Value.ToString();
                cmbTipo2.Text = dataGridView2.CurrentRow.Cells[4].Value.ToString();
                txtContra2.Text = dataGridView2.CurrentRow.Cells[5].Value.ToString();
                cmbDepa2.Text = dataGridView2.CurrentRow.Cells[6].Value.ToString();
                cmbEdo2.Text = dataGridView2.CurrentRow.Cells[7].Value.ToString();
                txtComent2.Text = dataGridView2.CurrentRow.Cells[8].Value.ToString();
            }
            catch (Exception ex)
            {

            }
        }

        Conexion conexion18 = new Conexion();
        private void button3_Click(object sender, EventArgs e)
        {
            //MODIFICAR
            string cod3 = txtCod3.Text;
            string edo2 = cmbEdo3.Text;
            string idnu2 = textBox14.Text;
            string name3 = txtNombre2.Text;
            string mod2 = "Estado De Usuario";
            string idus3 = "";
            string nameUs3 = "";
            string fecha2 = dtCambio.Value.ToString("yyyy-MM-dd");
            string consulta12 = "UPDATE d2_bd.d2_users SET EstadoUs ='" + edo2 + "' WHERE idd2_users=" + cod3;
            //CONSULTA ID DE USUARIO QUE MODIFICO
            string consulta14 = "SELECT idd2_users FROM d2_bd.d2_users WHERE NuUsuario = '" + idnu2 + "' ";
            DataTable tb6 = new DataTable();
            tb6 = conexion14.cargarDatos(consulta14);
            idus3 = tb6.Rows[0]["idd2_users"].ToString();

            //CONSULTA NOMBRE DE USUARIO QUE MODIFICO
            string consulta15 = "SELECT NombreUs FROM d2_bd.d2_users WHERE NuUsuario = '" + idnu2 + "' ";
            DataTable tb7 = new DataTable();
            tb7 = conexion18.cargarDatos(consulta15);
            nameUs3 = tb7.Rows[0]["NombreUs"].ToString();

            //INSERTAR EN HISTORIAL DE MODIFICACIONES
            string consulta13 = "INSERT INTO d2_bd.d2_modificar(idd2_users,NombreUs,FechaMod,Modifico,UserMod,UsModNombre) values('" + idus3 + "','" + nameUs3 + "','" + fecha2 + "','" + mod2 + "','" + cod3 + "','" + name3 + "')";

            if (conexion12.ejecutarQuery(consulta12))
            {
                conexion13.ejecutarQuery(consulta13);
                MessageBox.Show("Estado De Usuario Actualizado Correctamente");
                DataTable dt = (DataTable)dataGridView1.DataSource;
                DataTable dt1 = (DataTable)dataGridView2.DataSource;
                DataTable dt2 = (DataTable)dataGridView3.DataSource;
                DataTable dt3 = (DataTable)dataGridView4.DataSource;
                Limpiar3();
                dt.Clear();
                dt1.Clear();
                dt2.Clear();
                dt3.Clear();
                tb6.Clear();
                tb7.Clear();
                cargar();
            }
            else
            {
                MessageBox.Show("¡Error!, Intente De Nuevo ó Comuniquese Con El Ing.");
            }
        }

        private void dataGridView3_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                txtCod3.Text = dataGridView3.CurrentRow.Cells[0].Value.ToString();
                txtNo3.Text = dataGridView3.CurrentRow.Cells[1].Value.ToString();
                cmbEdo3.Text = dataGridView3.CurrentRow.Cells[7].Value.ToString();
            }
            catch (Exception ex)
            {

            }
        }

        private void Usuarios_Load(object sender, EventArgs e)
        {
            string Date = DateTime.Now.ToString();
            lblFecha1.Text = Date;
            lblFecha2.Text = Date;
            lblFecha3.Text = Date;
            lblFecha4.Text = Date;
        }

        private void textBox2_KeyUp(object sender, KeyEventArgs e)
        {
            dataGridView1.DataSource = conexion1.cargarDatos2("SELECT * FROM d2_bd.d2_users WHERE NombreUs like ('" + textBox2.Text + "%')");
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Limpiar();
        }
        
        public void Limpiar()
        {
            txtCod2.Text = "";
            txtNo.Text = "";
            txtNombre.Text = "";
            txtApellido.Text = "";
            cmbTipo.Text = "";
            txtContra.Text = "";
            cmbDepa.Text = "";
            cmbEstado.Text = "";
            txtComent.Text = "";
        }

        public void Limpiar2()
        {
            txtCod2.Text = "";
            txtNo2.Text = "";
            txtNombre2.Text = "";
            txtApellido2.Text = "";
            cmbTipo2.Text = "";
            txtContra2.Text = "";
            cmbDepa2.Text = "";
            cmbEdo2.Text = "";
            txtComent2.Text = "";
        }

        private void textBox6_KeyUp(object sender, KeyEventArgs e)
        {
            dataGridView2.DataSource = conexion15.cargarDatos2("SELECT * FROM d2_bd.d2_users WHERE NombreUs like ('" + textBox6.Text + "%')");
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Limpiar2();
        }

        private void textBox11_KeyUp(object sender, KeyEventArgs e)
        {
            dataGridView3.DataSource = conexion16.cargarDatos2("SELECT idd2_users, NuUsuario, NombreUs, EstadoUs FROM d2_bd.d2_users WHERE NombreUs like ('" + textBox11.Text + "%')");
        }

        private void button6_Click(object sender, EventArgs e)
        {
            Limpiar3();
        }
        public void Limpiar3()
        {
            txtCod3.Text = "";
            txtNo3.Text = "";
            cmbEdo3.Text = "";
        }

        private void textBox9_KeyUp(object sender, KeyEventArgs e)
        {
            dataGridView4.DataSource = conexion17.cargarDatos2("SELECT idd2_users AS 'ID De Usuario Que Modifico', NombreUs AS 'Nombre Del Usuario Que Modifico'" +
                ", FechaMod AS 'Fecha De Modificacion', Modifico, UserMod AS 'ID De Usuario Modificado', UsModNombre AS 'Nombre De Usuario Modificado' FROM d2_modificar WHERE NombreUs like ('" + textBox9.Text + "%')");
        }
    }
}
