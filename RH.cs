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
    public partial class RH : Form
    {
        public RH()
        {
            InitializeComponent();
            cargar();
           
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// 
        Conexion conexion = new Conexion();
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
        Conexion conexion18 = new Conexion();
        Conexion conexion19 = new Conexion();
        Conexion conexion20 = new Conexion();

        public void cargar()
        {
            dataGridView5.DataSource = conexion16.cargarDatos("SELECT * FROM d2_bd.d2_asignar90");
            dataGridView4.DataSource = conexion4.cargarDatos("SELECT * FROM d2_bd.d2_empleados");
            dataGridView3.DataSource = conexion5.cargarDatos("SELECT idd2_empleados AS 'ID', CURP, Nombre, A_Paterno AS 'Apellido Paterno'" +
                ", A_Materno AS 'Apellido Materno', Turno, EdoE AS 'Estado' FROM d2_bd.d2_empleados");
            dataGridView2.DataSource = conexion6.cargarDatos("SELECT idd2_empleados AS 'ID',CURP, Nombre, A_Paterno AS 'Apellido Paterno'" +
                ", A_Materno AS 'Apellido Materno', Turno, EdoE AS 'Estado', FechaIng AS 'Fecha De Ingreso' FROM d2_bd.d2_empleados");
            dataGridView1.DataSource = conexion7.cargarDatos("SELECT * FROM d2_bd.d2_empleados");
            dataGridView6.DataSource = conexion20.cargarDatos("SELECT idd2_servicios,nombreS FROM d2_bd.d2_servicios");
        }

        //BOTON AGREGAR EMPLEADO
        private void button1_Click(object sender, EventArgs e)
        {
            string CURP = txtCURP.Text;
            string no2 = "";
            string idusu = "";
            DataTable tb = new DataTable();
            //BUSCARA LOS USUARIOS QUE COINCIDA CON EL NUMERO DE USUARIO INGRESADO
            string consulta = "SELECT count(*) FROM d2_bd.d2_empleados WHERE CURP = '" + CURP + "' ";
            conexion.ejecutarQuery(consulta);
            tb = conexion.cargarDatos(consulta);
            no2 = tb.Rows[0]["count(*)"].ToString();
            //MessageBox.Show("El Conteo es: "+ no2 + " y el numero de usuario a registrar " + NoUs);
            //SI NO ENCUENTRA NINGUN USUARIO REGISTRADO CON EL NUMERO DE USUARIO INGRESADO LO REGISTRARA
            double sueldo = double.Parse(txtSueldo.Text);
            double bono = double.Parse(txtBono.Text);
            double suelt = sueldo+bono;

            //PARA SABER QUE USUARIO AGREGO
            string consulta3 = "SELECT d2_bd.d2_users.idd2_users FROM d2_bd.d2_users WHERE NuUsuario = '"+textBox24.Text+"'";
            DataTable tb2 = new DataTable();
            conexion3.ejecutarQuery(consulta3);
            tb2 = conexion3.cargarDatos(consulta3);
            idusu = tb2.Rows[0]["idd2_users"].ToString();
            int idus = int.Parse(idusu);
            string fecha = dateFechaNac.Value.ToString("yyyy-MM-dd"); 
            string fecha2 = dateFechaIng.Value.ToString("yyyy-MM-dd");
            if (no2.Equals("0"))
            {
                //INSERTAR
                string consulta2 = 
                    "INSERT INTO " +
                    "d2_bd.d2_empleados" +
                    "(CURP,idd2_users,RFC,NSS,Nombre,A_Paterno,A_Materno,Escolaridad,Carrera,LugNac,FechaNac,Edad,Emergencia,TelEmer," +
                    "Parentesco,Colonia,Calle,Numero,CP,Edo,Municipio,Celular,TelCasa,Sueldo,Bono,Turno,FechaIng,EdoE,TipoEmp,SueldoTotal) " +
                    "VALUES('" + txtCURP.Text + "','" + idus + "','" + txtRFC.Text + "','" + txtNSS.Text + "','" + txtNombreE.Text + 
                    "','" + txtAPaterno.Text + "','" + txtAMaterno.Text + "','" + cmbEscolaridad.SelectedItem + "','" + txtCarrera.Text +
                    "','" + cmbLugarNac.SelectedItem + "','" + fecha + "','" + txtEdad.Text + "','" + txtEmerN.Text + "','" + txtNoTelE.Text +
                    "','" + txtPare.Text + "','" + txtCol.Text + "','" + txtCalle.Text + "','" + txtNoCasa.Text + "','" + txtCP.Text + "','" + txtEdo.Text +
                    "','" + txtMun.Text + "','" + txtCel.Text + "','" + txtTelC.Text + "'," + sueldo + "," + bono + ",'" + cmbTurno.SelectedItem +
                    "','" + fecha2 + "','" + cmbEdoE.SelectedItem + "','" + cmbTipoEm.SelectedItem + "','" + suelt + "')";
                if (conexion2.ejecutarQuery(consulta2))
                {
                    MessageBox.Show("Empleado registrado correctamente");
                    DataTable dt = (DataTable)dataGridView1.DataSource;
                    DataTable dt1 = (DataTable)dataGridView2.DataSource;
                    DataTable dt2 = (DataTable)dataGridView3.DataSource;
                    DataTable dt3 = (DataTable)dataGridView4.DataSource;
                    DataTable dt4 = (DataTable)dataGridView5.DataSource;
                    DataTable dt5 = (DataTable)dataGridView6.DataSource;
                    dt.Clear();
                    dt1.Clear();
                    dt2.Clear();
                    dt3.Clear();
                    dt4.Clear();
                    dt5.Clear();
                    Limpiar();
                    cargar();
                    txtCURP.Text = "";
                    tb.Clear();
                }
                else
                {
                    MessageBox.Show("!Error!, La CURP ya EXISTE.");
                    txtCURP.Text = "";
                    tb.Clear();
                }
            }
            else
            {
                MessageBox.Show("!Error!, La CURP de empleado ya EXISTE.");
                txtCURP.Text = "";
                tb.Clear();
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                txtID.Text = dataGridView1.CurrentRow.Cells[0].Value.ToString();
                txtCURP2.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
                txtRFC2.Text = dataGridView1.CurrentRow.Cells[3].Value.ToString();
                txtNSS2.Text = dataGridView1.CurrentRow.Cells[4].Value.ToString();
                txtNombre2.Text = dataGridView1.CurrentRow.Cells[5].Value.ToString();
                txtAPaterno2.Text = dataGridView1.CurrentRow.Cells[6].Value.ToString();
                txtAMaterno2.Text = dataGridView1.CurrentRow.Cells[7].Value.ToString();
                cmbEscolaridad2.Text = dataGridView1.CurrentRow.Cells[8].Value.ToString();
                txtCarrera2.Text = dataGridView1.CurrentRow.Cells[9].Value.ToString();
                cmbLugNac2.Text = dataGridView1.CurrentRow.Cells[10].Value.ToString();
                dateFechaNac2.Text = dataGridView1.CurrentRow.Cells[11].Value.ToString();
                txtEdad2.Text = dataGridView1.CurrentRow.Cells[12].Value.ToString();
                txtEmerN2.Text = dataGridView1.CurrentRow.Cells[13].Value.ToString();
                txtNuEmer2.Text = dataGridView1.CurrentRow.Cells[14].Value.ToString();
                txtParen2.Text = dataGridView1.CurrentRow.Cells[15].Value.ToString();
                txtCol2.Text = dataGridView1.CurrentRow.Cells[16].Value.ToString();
                txtCalle2.Text = dataGridView1.CurrentRow.Cells[17].Value.ToString();
                txtNoCasa2.Text = dataGridView1.CurrentRow.Cells[18].Value.ToString();
                txtCP2.Text = dataGridView1.CurrentRow.Cells[19].Value.ToString();
                cmbEdo2.Text = dataGridView1.CurrentRow.Cells[20].Value.ToString();
                txtMun2.Text = dataGridView1.CurrentRow.Cells[21].Value.ToString();
                txtCel2.Text = dataGridView1.CurrentRow.Cells[22].Value.ToString();
                txtTelCa2.Text = dataGridView1.CurrentRow.Cells[23].Value.ToString();
                txtSueldo2.Text = dataGridView1.CurrentRow.Cells[24].Value.ToString();
                txtBono2.Text = dataGridView1.CurrentRow.Cells[25].Value.ToString();
                cmbTurno2.Text = dataGridView1.CurrentRow.Cells[26].Value.ToString();
                dateFechaIng2.Text = dataGridView1.CurrentRow.Cells[27].Value.ToString();
                cmbEdoE2.Text = dataGridView1.CurrentRow.Cells[28].Value.ToString();
                cmbTipoE2.Text = dataGridView1.CurrentRow.Cells[29].Value.ToString();

            }
            catch (Exception ex)
            {

            }
        }

        //BOTON PARA SALIR
        private void button2_Click(object sender, EventArgs e)
        {
            string idusu = "";
            string tipo = "";

            //CONSULTA PARA TRAER EL ID DE USUARIO
            string consulta = "SELECT d2_bd.d2_users.idd2_users FROM d2_bd.d2_users WHERE NuUsuario = '" + textBox43.Text + "'";
            DataTable tb = new DataTable();
            conexion18.ejecutarQuery(consulta);
            tb = conexion18.cargarDatos(consulta);
            idusu = tb.Rows[0]["idd2_users"].ToString();

            //CONSULTA PARA TRAER EL TIPO DE USUARIO
            string consulta2 = "SELECT d2_bd.d2_users.TipoUs FROM d2_bd.d2_users WHERE NuUsuario = '" + textBox43.Text + "'";
            DataTable tb2 = new DataTable();
            conexion19.ejecutarQuery(consulta2);
            tb2 = conexion19.cargarDatos(consulta2);
            tipo = tb2.Rows[0]["TipoUs"].ToString();

            if (tipo.Equals("Super Admin"))
            {
                string noUsu = textBox24.Text;
                string nombre = textBox6.Text;
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


        //FUNCION PARA ACTIVAR EL TEXTBOX PARA LAS CARRERAS
        private void cmbEscolaridad_SelectedIndexChanged(object sender, EventArgs e)
        {

            /*
             * Nivel Tecnico
               Superior
             */
            if (cmbEscolaridad.SelectedItem.ToString() == "Nivel Tecnico" || cmbEscolaridad.SelectedItem.ToString() == "Superior")
            {
                txtCarrera.Enabled = true;
            }
        }


        //BOTON MODIFICAR
        private void button6_Click(object sender, EventArgs e)
        {
            string fecha3 = dateFechaNac2.Value.ToString("yyyy-MM-dd");
            string fecha4 = dateFechaIng2.Value.ToString("yyyy-MM-dd");
            double sueldo2 = double.Parse(txtSueldo2.Text);
            double bono2 = double.Parse(txtBono2.Text);
            double suelt2 = sueldo2 + bono2;
            //MODIFICAR
            string consulta8 = "UPDATE d2_bd.d2_empleados SET " +
                "CURP= '" + txtCURP2.Text + "', RFC='" + txtRFC2.Text + "', NSS='" + txtNSS2.Text + "' ,Nombre='" + txtNombre2.Text +
                "' , A_Paterno='" + txtAPaterno2.Text + "' , A_Materno ='" + txtAMaterno2.Text + "' , Escolaridad ='" + cmbEscolaridad2.SelectedItem + 
                "' , Carrera='" + txtCarrera2.Text + "', LugNac='"+fecha3+"', Edad='"+txtEdad2.Text+"', Emergencia='"+txtEmerN2.Text+
                "', TelEmer='"+txtNuEmer2.Text+"', Parentesco='"+txtParen2.Text+"',Colonia='"+txtCol2.Text+"',Calle='"+txtCalle2.Text+
                "',CP='"+txtCP2.Text+"', Edo='"+cmbEdo2.SelectedItem+"',Municipio='"+txtMun2.Text+"',Celular='"+txtCel2.Text+"',TelCasa='"+txtTelCa2.Text+
                "', Sueldo='"+sueldo2+"', Bono='"+bono2+"', Turno='"+cmbTurno2.SelectedItem+"', FechaIng='"+fecha4+"',EdoE='"+cmbEdoE2.SelectedItem+
                "', TipoEmp='"+cmbTipoE2.SelectedItem+"',SueldoTotal='"+suelt2+"' " +
                "WHERE idd2_empleados='" + txtID.Text+"' ";
            //INSERTAR EN HISTORIAL DE MODIFICACIONES
            //string consulta9 = "INSERT INTO d2_bd.d2_modificar(idd2_users,FechaMod,Modifico,UserMod) values('" + idnu + "','" + fecha + "','" + mod + "','" + idmod + "')";

            if (conexion8.ejecutarQuery(consulta8))
            {
                //conexion9.ejecutarQuery(consulta9);
                MessageBox.Show("Empleado Actualizado Correctamente");              
                DataTable dt = (DataTable)dataGridView1.DataSource;
                DataTable dt1 = (DataTable)dataGridView2.DataSource;
                DataTable dt2 = (DataTable)dataGridView3.DataSource;
                DataTable dt3 = (DataTable)dataGridView4.DataSource;
                DataTable dt4 = (DataTable)dataGridView5.DataSource;
                DataTable dt5 = (DataTable)dataGridView6.DataSource;
                dt.Clear();
                dt1.Clear();
                dt2.Clear();
                dt3.Clear();
                dt4.Clear();
                dt5.Clear();
                Limpiar2();
                cargar();
            }
            else
            {
                MessageBox.Show("¡Error!, Intente De Nuevo ó Comuniquese Con El Ing.");
            }
        }


        //BOTON MODIFICAR ESTADO
        Conexion conexion23 = new Conexion();
        Conexion conexion24 = new Conexion();
        private void button3_Click(object sender, EventArgs e)
        {
            //VARIABLES
            string name = "";
            string Ape = "";
            string iduser = "";
            string nombreuser = "";
            string fecha5 = dateFechaBaja.Value.ToString("yyyy-MM-dd");


            //CONSULTA PARA ACTUALIZACION DE ESTADO
            string consulta10 = "UPDATE d2_bd.d2_empleados SET EdoE='" + cmbEdoE3.SelectedItem + "' WHERE idd2_empleados='" + txtID2.Text + "' ";

            //DATOS PARA ID DE EMPLEADO 
            string consulta12 = "SELECT NombreE FROM d2_bd.d2_empleados WHERE idd2_empleados='" + txtID2.Text + "'";
            DataTable tb4 = new DataTable();
            conexion12.ejecutarQuery(consulta12);
            tb4 = conexion12.cargarDatos(consulta12);
            name = tb4.Rows[0]["NombreE"].ToString();

            //DATOS PARA NOMBRE DE EMPLEADO
            string consulta14 = "SELECT ApellidoE FROM d2_bd.d2_empleados WHERE idd2_empleados='" + txtID2.Text + "'";
            DataTable tb6 = new DataTable();
            conexion12.ejecutarQuery(consulta14);
            tb6 = conexion12.cargarDatos(consulta14);
            Ape = tb6.Rows[0]["ApellidoE"].ToString();

            //DATOS PARA ID DE USUARIO
            string consulta13 = "SELECT idd2_users FROM d2_bd.d2users WHERE NuUsuario ='" + textBox40.Text + "'";
            DataTable tb5 = new DataTable();
            conexion13.ejecutarQuery(consulta13);
            tb5 = conexion13.cargarDatos(consulta13);
            iduser = tb5.Rows[0]["idd2_users"].ToString();

            //DATOS PARA NOMBRE DE USUARIO
            string consulta15 = "SELECT NombreUs FROM d2_bd.d2users WHERE NuUsuario ='" + textBox40.Text + "'";
            DataTable tb7 = new DataTable();
            conexion13.ejecutarQuery(consulta15);
            tb7 = conexion13.cargarDatos(consulta15);
            nombreuser = tb7.Rows[0]["NombreUs"].ToString();

            //PARA INSERTAR EN HISTORIAL DE BAJAS
            string consulta11 = "INSERT INTO d2_bd.bajaempleados(idd2_empleados,CURP,NombreE,ApellidoE,Estado,FechaBaja,idd2users,NombreUsuario) VALUES (" +
                "'" + txtID2.Text + "', '" + txtCURP3.Text + "','" + name + "','" + Ape + "','" + cmbEdoE3.SelectedItem + "','" + fecha5 + "', '" + iduser + "','" + nombreuser + "')";

            if (conexion23.ejecutarQuery(consulta10))
            {
                conexion24.ejecutarQuery(consulta11);
                DataTable dt = (DataTable)dataGridView1.DataSource;
                DataTable dt1 = (DataTable)dataGridView2.DataSource;
                DataTable dt2 = (DataTable)dataGridView3.DataSource;
                DataTable dt3 = (DataTable)dataGridView4.DataSource;
                DataTable dt4 = (DataTable)dataGridView5.DataSource;
                DataTable dt5 = (DataTable)dataGridView6.DataSource;
                dt.Clear();
                dt1.Clear();
                dt2.Clear();
                dt3.Clear();
                dt4.Clear();
                dt5.Clear();
                tb4.Clear();
                tb5.Clear();
                tb6.Clear();
                tb7.Clear();
                Limpiar3();
            }
            else
            {
                MessageBox.Show("!Error!, Revise bien los datos.");
            }
           
        }

        private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            txtID2.Text = dataGridView2.CurrentRow.Cells[0].Value.ToString();
            txtCURP3.Text = dataGridView2.CurrentRow.Cells[1].Value.ToString();
            cmbEdoE3.Text = dataGridView2.CurrentRow.Cells[6].Value.ToString();
        }

        private void dataGridView3_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            txtID3.Text = dataGridView3.CurrentRow.Cells[0].Value.ToString();
            txtCURP4.Text = dataGridView3.CurrentRow.Cells[1].Value.ToString();           
        }


        //BOTON PARA ASIGNAR SERVICIO
        Conexion conexion29 = new Conexion();
        Conexion conexion30 = new Conexion();
        private void button4_Click(object sender, EventArgs e)
        {
            //PARA SABER QUE USUARIO ASIGNO EL SERVICIO
            int idUs;
            string consulta14 = "SELECT d2_bd.d2_users.idd2_users FROM d2_bd.d2_users WHERE NuUsuario = '" + textBox43.Text + "'";
            DataTable tb7 = new DataTable();
            conexion14.ejecutarQuery(consulta14);
            tb7 = conexion14.cargarDatos(consulta14);
            idUs = (int)tb7.Rows[0]["idd2_users"];

            //PARA SABER EL NOMBRE DEL EMPLEADO
            string nameE = "";
            string apellido = "";
            string amaterno = "";
            string FullName = "";

            string consulta16 = "SELECT Nombre FROM d2_bd.d2_empleados WHERE idd2_empleados = '" + txtID3.Text + "'";
            DataTable tb8 = new DataTable();
            conexion16.ejecutarQuery(consulta16);
            tb8 = conexion16.cargarDatos(consulta16);
            nameE = tb8.Rows[0]["Nombre"].ToString();

            //PARA SABER EL APELLIDO PATERNO DEL EMPLEADO
            string consulta18 = "SELECT A_Paterno FROM d2_bd.d2_empleados WHERE idd2_empleados = '" + txtID3.Text + "'";
            DataTable tb9 = new DataTable();
            conexion29.ejecutarQuery(consulta18);
            tb9 = conexion29.cargarDatos(consulta18);
            apellido = tb9.Rows[0]["A_Paterno"].ToString();

            //PARA SABER EL APELLIDO PATERNO DEL EMPLEADO
            string consulta19 = "SELECT A_Materno FROM d2_bd.d2_empleados WHERE idd2_empleados = '" + txtID3.Text + "'";
            DataTable tb10 = new DataTable();
            conexion30.ejecutarQuery(consulta19);
            tb10 = conexion30.cargarDatos(consulta19);
            amaterno = tb10.Rows[0]["A_Materno"].ToString();

            FullName = nameE + " " + apellido+ " "+ amaterno;

            string fecha6 = dateAsignar90.Value.ToString("yyyy-MM-dd");
            //ASIGNAR SERVICIO
            string consulta15 = "INSERT INTO d2_bd.d2_asignar90(idd2_empleado, CURPEmpleado, nombreE, idd2_users, nombreUsu, Servicio, FechaAsignacion) VALUES(" +
                "'"+txtID3.Text+"','"+txtCURP4.Text+"','"+FullName+"','"+idUs+"','"+textBox42.Text+"','"+txtAsignar90.Text+"','"+fecha6+"')";
            if (conexion15.ejecutarQuery(consulta15))
            {
                //conexion9.ejecutarQuery(consulta9);
                MessageBox.Show("90 Asignado Correctamente");
                DataTable dt = (DataTable)dataGridView1.DataSource;
                DataTable dt1 = (DataTable)dataGridView2.DataSource;
                DataTable dt2 = (DataTable)dataGridView3.DataSource;
                DataTable dt3 = (DataTable)dataGridView4.DataSource;
                DataTable dt4 = (DataTable)dataGridView5.DataSource;
                DataTable dt5 = (DataTable)dataGridView6.DataSource;
                dt.Clear();
                dt1.Clear();
                dt2.Clear();
                dt3.Clear();
                dt4.Clear();
                dt5.Clear();
                Limpiar4();
                cargar();
            }
            else
            {
                MessageBox.Show("¡Error!, Intente De Nuevo ó Comuniquese Con El Ing.");
            }
        }

        private void dataGridView6_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            txtID90.Text = dataGridView6.CurrentRow.Cells[0].Value.ToString();
            txtAsignar90.Text = dataGridView6.CurrentRow.Cells[1].Value.ToString();
        }

        private void RH_Load(object sender, EventArgs e)
        {
            string Date = DateTime.Now.ToString();
            lblFecha1.Text = Date;
            lblFecha2.Text = Date;
            lblFecha3.Text = Date;
            lblFecha4.Text = Date;
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Limpiar();
        }

        public void Limpiar()
        {
            txtCURP.Text = "";
            txtRFC.Text = "";
            txtNSS.Text = "";
            txtNombreE.Text = "";
            txtAPaterno.Text = "";
            txtAMaterno.Text = "";
            cmbEscolaridad.Text = "";
            txtCarrera.Text = "";
            cmbLugarNac.Text = "";
            dateFechaNac.Text = "";
            txtEdad.Text = "";
            txtEmerN.Text = "";
            txtNoTelE.Text = "";
            txtPare.Text = "";
            txtCol.Text = "";
            txtCalle.Text = "";
            txtNoCasa.Text = "";
            txtCP.Text = "";
            cmbEdoE.Text = "";
            txtMun.Text = "";
            txtCel.Text = "";
            txtTelC.Text = "";
            txtSueldo.Text = "";
            txtBono.Text = "";
            cmbTurno.Text = "";
            cmbEdoE.Text = "";
            cmbTipoEm.Text = "";
        }

        public void Limpiar2()
        {
            txtID.Text = "";
            txtCURP2.Text = "";
            txtRFC2.Text = "";
            txtNSS2.Text = "";
            txtNombre2.Text = "";
            txtAPaterno2.Text = "";
            txtAMaterno2.Text = "";
            cmbEscolaridad2.Text = "";
            txtCarrera2.Text = "";
            cmbLugNac2.Text = "";
            dateFechaNac2.Text = "";
            txtEdad2.Text = "";
            txtEmerN2.Text = "";
            txtNuEmer2.Text = "";
            txtParen2.Text = "";
            txtCol2.Text = "";
            txtCalle2.Text = "";
            txtNoCasa2.Text = "";
            txtCP2.Text = "";
            cmbEdo2.Text = "";
            txtMun2.Text = "";
            txtCel2.Text = "";
            txtTelCa2.Text = "";
            txtSueldo2.Text = "";
            txtBono2.Text = "";
            cmbTurno2.Text = "";
            cmbEdoE2.Text = "";
            cmbTipoE2.Text = "";
        }

        private void button7_Click(object sender, EventArgs e)
        {
            Limpiar2();
        }

        Conexion conexion21 = new Conexion();

        private void textBox19_KeyUp(object sender, KeyEventArgs e)
        {
            dataGridView1.DataSource = conexion21.cargarDatos2("SELECT * FROM d2_bd.d2_empleados WHERE CURP like ('" + textBox19.Text + "%')");
        }

        Conexion conexion22 = new Conexion();
        private void textBox20_KeyUp(object sender, KeyEventArgs e)
        {
            dataGridView2.DataSource = conexion22.cargarDatos2("SELECT idd2_empleados AS 'ID',CURP, Nombre, A_Paterno AS 'Apellido Paterno'" +
                ", A_Materno AS 'Apellido Materno', Turno, EdoE AS 'Estado', FechaIng AS 'Fecha De Ingreso' FROM d2_bd.d2_empleados WHERE CURP like ('" + textBox20.Text + "%')");
        }

        private void button8_Click(object sender, EventArgs e)
        {
            Limpiar3();
        }

        public void Limpiar3()
        {
            txtID2.Text = "";
            txtCURP3.Text = "";
            cmbEdoE3.Text = "";
        }

        private void textBox20_TextChanged(object sender, EventArgs e)
        {

        }

        Conexion conexion25 = new Conexion();
        private void textBox23_KeyUp(object sender, KeyEventArgs e)
        {
            dataGridView3.DataSource = conexion25.cargarDatos2("SELECT idd2_empleados AS 'ID', CURP, Nombre, A_Paterno AS 'Apellido Paterno'" +
                ", A_Materno AS 'Apellido Materno', Turno, EdoE AS 'Estado' FROM d2_bd.d2_empleados WHERE CURP like ('" + textBox23.Text + "%')");
        }

        private void button9_Click(object sender, EventArgs e)
        {
            Limpiar4();
        }

        public void Limpiar4()
        {
            txtID3.Text = "";
            txtCURP4.Text = "";
            txtID90.Text = "";
            txtAsignar90.Text = "";
        }

        Conexion conexion26 = new Conexion();
        private void textBox4_KeyUp(object sender, KeyEventArgs e)
        {
            dataGridView6.DataSource = conexion26.cargarDatos2("SELECT idd2_servicios, nombreS FROM d2_bd.d2_servicios WHERE nombreS like ('" + textBox4.Text + "%')");
        }

        Conexion conexion27 = new Conexion();
        private void textBox1_KeyUp(object sender, KeyEventArgs e)
        {
            dataGridView4.DataSource = conexion27.cargarDatos2("SELECT * FROM d2_bd.d2_empleados WHERE CURP like ('" + textBox1.Text + "%')");
        }

        Conexion conexion28 = new Conexion();
        private void textBox2_KeyUp(object sender, KeyEventArgs e)
        {
            dataGridView5.DataSource = conexion28.cargarDatos2("SELECT * FROM d2_bd.d2_asignar90 WHERE CURPEmpleado like ('" + textBox2.Text + "%')");
        }
    }
}
