using System;
using System.Data;
using System.Windows.Forms;

namespace Sistema_D2_Seguridad_Privada
{
    public partial class Almacen : Form
    {
        public Almacen()
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
        Conexion conexion18 = new Conexion();
        Conexion conexion19 = new Conexion();
        Conexion conexion20 = new Conexion();
        Conexion conexion21 = new Conexion();
        Conexion conexion22 = new Conexion();
        Conexion conexion24 = new Conexion();

        public void cargar()
        {
            dataGridView1.DataSource = conexion3.cargarDatos("SELECT idd2_equipo AS 'ID', equipoAgregado AS 'Equipo', Codigo, Talla, Color, Estado, IMEI, Marca, " +
                "Modelo, Comentario, Cantidad FROM d2_bd.d2_equipo");
            dataGridView2.DataSource = conexion8.cargarDatos("SELECT idd2_equipo AS 'ID', equipoAgregado AS 'Equipo', Codigo, Talla, Color, Estado, IMEI, Marca, " +
                "Modelo, Comentario, Cantidad FROM d2_bd.d2_equipo");
            dataGridView3.DataSource = conexion9.cargarDatos("SELECT idd2_equipo AS 'ID', equipoAgregado AS 'Equipo', Codigo, Talla, Color, Estado, IMEI, Marca, " +
                "Modelo, Comentario, Cantidad FROM d2_bd.d2_equipo");
            dataGridView4.DataSource = conexion10.cargarDatos("SELECT idd2_empleados AS 'ID', CURP, Nombre, A_Paterno AS 'Apellido Paterno', " +
                "A_Materno AS 'Apellido Materno'  FROM d2_bd.d2_empleados");
            dataGridView5.DataSource = conexion24.cargarDatos("SELECT * FROM d2_asignarequipo");
        }

        //BOTON PARA SALIR
        private void button3_Click(object sender, EventArgs e)
        {
            string idusu = "";
            string tipo = "";

            //CONSULTA PARA TRAER EL ID DE USUARIO
            string consulta = "SELECT d2_bd.d2_users.idd2_users FROM d2_bd.d2_users WHERE NuUsuario = '" + textBox16.Text + "'";
            DataTable tb = new DataTable();
            conexion.ejecutarQuery(consulta);
            tb = conexion.cargarDatos(consulta);
            idusu = tb.Rows[0]["idd2_users"].ToString();

            //CONSULTA PARA TRAER EL TIPO DE USUARIO
            string consulta2 = "SELECT d2_bd.d2_users.TipoUs FROM d2_bd.d2_users WHERE NuUsuario = '" + textBox16.Text + "'";
            DataTable tb2 = new DataTable();
            conexion1.ejecutarQuery(consulta2);
            tb2 = conexion1.cargarDatos(consulta2);
            tipo = tb2.Rows[0]["TipoUs"].ToString();

            if (tipo.Equals("Super Admin"))
            {
                string noUsu = textBox16.Text;
                string nombre = textBox15.Text;
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

        //FILTRO PARA HABILITAR CAMPOS DE TEXTO.
        private void cmbAgreEquipo_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbAgreEquipo.SelectedItem.ToString() == "Camisola" ||
                cmbAgreEquipo.SelectedItem.ToString() == "Pantalon" ||
                cmbAgreEquipo.SelectedItem.ToString() == "Chamarra" ||
                cmbAgreEquipo.SelectedItem.ToString() == "Cachucha" ||
                cmbAgreEquipo.SelectedItem.ToString() == "Fornitura" ||
                cmbAgreEquipo.SelectedItem.ToString() == "Gas Pimienta" ||
                cmbAgreEquipo.SelectedItem.ToString() == "Aros Apreshesores" ||
                cmbAgreEquipo.SelectedItem.ToString() == "PR-24" ||
                cmbAgreEquipo.SelectedItem.ToString() == "Porta Aros" ||
                cmbAgreEquipo.SelectedItem.ToString() == "Porta Radios")
            {
                txtCodigoNS.Enabled = true;
                txtColor.Enabled = true;
                cmbTalla.Enabled = true;
                cmbEdo.Enabled = true;
                txtComen.Enabled = true;
                txtIMEI.Enabled = false;
                txtMarca.Enabled = false;
                txtModelo.Enabled = false;
            }
            else
            {
                if (cmbAgreEquipo.SelectedItem.ToString() == "Radio")
                {
                    txtCodigoNS.Enabled = true;
                    txtColor.Enabled = true;
                    cmbEdo.Enabled = true;
                    txtIMEI.Enabled = false;
                    txtMarca.Enabled = true;
                    txtModelo.Enabled = true;
                    txtComen.Enabled = true;
                    cmbTalla.Enabled = false;
                    cmbTalla.SelectedIndex = 0;
                }
                else
                {
                    if (cmbAgreEquipo.SelectedItem.ToString() == "Celular")
                    {
                        txtCodigoNS.Enabled = true;
                        txtColor.Enabled = true;
                        cmbEdo.Enabled = true;
                        txtIMEI.Enabled = true;
                        txtMarca.Enabled = true;
                        txtModelo.Enabled = true;
                        txtComen.Enabled = true;
                        cmbTalla.Enabled = false;
                        cmbTalla.SelectedIndex = 0;

                    }

                }
            }
        }

        private void Almacen_Load(object sender, EventArgs e)
        {
            string Date = DateTime.Now.ToString();
            lblFecha1.Text = Date;
            lblFecha2.Text = Date;
            lblFecha3.Text = Date;
        }

        //BOTON AGREGAR NUEVO EQUIPO
        private void button1_Click(object sender, EventArgs e)
        {
            //VARIABLES
            int idusu;
            string nombreUS = textBox15.Text;
            string cont = "";
            int uno = 1;
            int cantidad = 0;

            //CONSULTA PARA TRAER EL ID DE USUARIO
            string consulta = "SELECT d2_bd.d2_users.idd2_users FROM d2_bd.d2_users WHERE NuUsuario = '" + textBox16.Text + "'";
            DataTable tb = new DataTable();
            conexion2.ejecutarQuery(consulta);
            tb = conexion2.cargarDatos(consulta);
            idusu = (int)tb.Rows[0]["idd2_users"];

            //CONSULTA PARA VER SI HAY EQUIPOS EN EXISTENCIA
            string consulta2 = "SELECT count(*) FROM d2_bd.d2_equipo WHERE Codigo = '" + txtCodigoNS.Text+"'";
            DataTable tb2 = new DataTable();
            conexion4.ejecutarQuery(consulta2);
            tb2 = conexion4.cargarDatos(consulta2);
            cont = tb2.Rows[0]["count(*)"].ToString();

            string consulta3 = "INSERT INTO d2_bd.d2_equipo(equipoAgregado,Codigo,Talla,Color,Estado,IMEI,Marca,Modelo,Comentario,Cantidad,idus,NombreUS) " +
                "VALUES('"+cmbAgreEquipo.SelectedItem+"','"+txtCodigoNS.Text+"','"+cmbTalla.SelectedItem+"','"+txtColor.Text+"','"+cmbEdo.SelectedItem+"'" +
                ",'"+txtIMEI.Text+"','"+txtMarca.Text+"','"+txtModelo.Text+"','"+txtComen.Text+"',"+uno+","+idusu+",'"+nombreUS+"')";

            //SINO EXISTE NINGUN EQUIPO CON ESE CODIGO/NS LO INSERTA
            if (cont.Equals("0")) { 
                if (conexion6.ejecutarQuery(consulta3))
                {
                    MessageBox.Show("Equipo registrado correctamente");
                    DataTable dt = (DataTable)dataGridView1.DataSource;
                    DataTable dt1 = (DataTable)dataGridView2.DataSource;
                    DataTable dt2 = (DataTable)dataGridView3.DataSource;
                    DataTable dt3 = (DataTable)dataGridView4.DataSource;
                    DataTable dt4 = (DataTable)dataGridView5.DataSource;
                    dt4.Clear();
                    dt.Clear();
                    dt1.Clear();
                    dt2.Clear();
                    dt3.Clear();
                    Limpiar();
                    cargar();
                    tb.Clear();
                    tb2.Clear();
                    }
                    else
                    {
                        MessageBox.Show("!Error!");
                        tb.Clear();
                        tb2.Clear();
                    }
            }
                else
                {
                //SINO, SI SI EXISTE ESE EQUIPO LO ACTUALIZA Y LO AGREGA.
                    if (!cont.Equals("0"))
                    {
                        int uno2 = 1;
                        //CONSULTA PARA TRAER EL TOTAL DE EQUIPOS
                        string consulta5 = "SELECT Cantidad FROM d2_bd.d2_equipo WHERE Codigo = '" + txtCodigoNS.Text + "'";
                        DataTable tb3 = new DataTable();
                        conexion5.ejecutarQuery(consulta5);
                        tb3 = conexion5.cargarDatos(consulta5);
                        cantidad = (int)tb3.Rows[0]["Cantidad"] + uno2;
                    

                    string consulta4 = "UPDATE d2_bd.d2_equipo SET equipoAgregado = '" + cmbAgreEquipo.SelectedItem + "' ,Codigo = '" + txtCodigoNS.Text + "'," +
                        " Talla = '" + cmbTalla.SelectedItem + "' ,Color = '" + txtColor.Text + "' , Estado = '" + cmbEdo.SelectedItem + "', " +
                        " IMEI = '"+txtIMEI.Text+"' , Marca = '" + txtMarca.Text + "' , Modelo = '" + txtModelo.Text + "' , Comentario = '" + txtComen.Text + "', " +
                        " Cantidad = " + cantidad + " , idus = " + idusu + "  , NombreUS = '" + nombreUS + "' ";                  
                    
                    if (conexion7.ejecutarQuery(consulta4))
                        {
                            MessageBox.Show("Equipo registrado correctamente");
                            DataTable dt = (DataTable)dataGridView1.DataSource;
                            DataTable dt1 = (DataTable)dataGridView2.DataSource;
                            DataTable dt2 = (DataTable)dataGridView3.DataSource;
                            DataTable dt3 = (DataTable)dataGridView4.DataSource;
                            DataTable dt4 = (DataTable)dataGridView5.DataSource;
                            dt4.Clear();
                            dt.Clear();
                            dt1.Clear();
                            dt2.Clear();
                            dt3.Clear();
                            Limpiar();
                            cargar();
                            tb3.Clear();
                        }
                        else
                        {
                            MessageBox.Show("!Error!");
                            tb3.Clear();
                        }
                    }
                }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            txtID.Text = dataGridView1.CurrentRow.Cells[0].Value.ToString();
            cmbAgreEquipo2.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
            txtCodigoNS2.Text = dataGridView1.CurrentRow.Cells[2].Value.ToString();
            cmbTalla2.Text = dataGridView1.CurrentRow.Cells[3].Value.ToString();
            txtColor2.Text = dataGridView1.CurrentRow.Cells[4].Value.ToString();
            cmbEdo2.Text = dataGridView1.CurrentRow.Cells[5].Value.ToString();
            txtIMEI2.Text = dataGridView1.CurrentRow.Cells[6].Value.ToString();
            txtMarca2.Text = dataGridView1.CurrentRow.Cells[7].Value.ToString();
            txtModelo2.Text = dataGridView1.CurrentRow.Cells[8].Value.ToString();
            txtComen2.Text = dataGridView1.CurrentRow.Cells[9].Value.ToString();
            txtCantidad.Text = dataGridView1.CurrentRow.Cells[10].Value.ToString();
        }

        private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            txtID1.Text = dataGridView2.CurrentRow.Cells[0].Value.ToString();
            cmbAgreEquipo.Text = dataGridView2.CurrentRow.Cells[1].Value.ToString();
            txtCodigoNS.Text = dataGridView2.CurrentRow.Cells[2].Value.ToString();
            cmbTalla.Text = dataGridView2.CurrentRow.Cells[3].Value.ToString();
            txtColor.Text = dataGridView2.CurrentRow.Cells[4].Value.ToString();
            cmbEdo.Text = dataGridView2.CurrentRow.Cells[5].Value.ToString();
            txtIMEI.Text = dataGridView2.CurrentRow.Cells[6].Value.ToString();
            txtMarca.Text = dataGridView2.CurrentRow.Cells[7].Value.ToString();
            txtModelo.Text = dataGridView2.CurrentRow.Cells[8].Value.ToString();
            txtComen.Text = dataGridView2.CurrentRow.Cells[9].Value.ToString();
        }


        //BOTON PARA ACTUALIZAR
        private void button2_Click(object sender, EventArgs e)
        {   
            //VARIABLES
            int cantidad = int.Parse(txtCantidad.Text);
            string modifico = "Equipo";
            string fecha = DateTime.Now.ToString("yyyy-MM-dd");
            int idus;
            int id = int.Parse(txtID.Text);

            //CONSULTA PARA TRAER EL ID DE USUARIO
            string consulta8 = "SELECT d2_bd.d2_users.idd2_users FROM d2_bd.d2_users WHERE NuUsuario = '" + textBox18.Text + "'";
            DataTable tb = new DataTable();
            conexion12.ejecutarQuery(consulta8);
            tb = conexion12.cargarDatos(consulta8);
            idus = (int)tb.Rows[0]["idd2_users"];


            //CONSULTAS
            string consulta6 = "UPDATE d2_bd.d2_equipo SET equipoAgregado = '" + cmbAgreEquipo2.SelectedItem + "' ,Codigo = '" + txtCodigoNS2.Text + "'," +
                        " Talla = '" + cmbTalla2.SelectedItem + "' ,Color = '" + txtColor2.Text + "' , Estado = '" + cmbEdo2.SelectedItem + "', " +
                        " IMEI = '" + txtIMEI2.Text + "' , Marca = '" + txtMarca2.Text + "' , Modelo = '" + txtModelo2.Text + "' , Comentario = '" + txtComen2.Text + "', Cantidad = " + cantidad + " WHERE idd2_equipo = "+ txtID.Text + ""; 



            string consulta7 = "INSERT INTO d2_bd.d2_modificarequipo(idequipo, equipo, codigoE, fechaM, usuM, idus, modifico ) VALUES("+txtID.Text+", '"+cmbAgreEquipo2.SelectedItem+"'," +
                "'"+txtCodigoNS2.Text+"','"+fecha+"','"+textBox17.Text+"',"+idus+",'"+modifico+"')";

            if (conexion11.ejecutarQuery(consulta6))
            {
                if (conexion13.ejecutarQuery(consulta7))
                {
                    MessageBox.Show("Equipo registrado correctamente");
                    DataTable dt = (DataTable)dataGridView1.DataSource;
                    DataTable dt1 = (DataTable)dataGridView2.DataSource;
                    DataTable dt2 = (DataTable)dataGridView3.DataSource;
                    DataTable dt3 = (DataTable)dataGridView4.DataSource;
                    DataTable dt4 = (DataTable)dataGridView5.DataSource;
                    dt4.Clear();
                    dt.Clear();
                    dt1.Clear();
                    dt2.Clear();
                    dt3.Clear();
                    Limpiar2();
                    cargar();
                }
                else
                {
                    MessageBox.Show("!Error!");
                }
            }
            else
            {
                MessageBox.Show("!Error!");
            }

        }

        private void dataGridView3_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            txtID3.Text = dataGridView3.CurrentRow.Cells[0].Value.ToString();
            txtCodigoNS3.Text = dataGridView3.CurrentRow.Cells[2].Value.ToString();
        }

        private void dataGridView4_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            txtIDE.Text = dataGridView4.CurrentRow.Cells[0].Value.ToString();
            txtCURPE.Text = dataGridView4.CurrentRow.Cells[1].Value.ToString();
        }

        //BOTÓN ASIGNAR
        private void button5_Click(object sender, EventArgs e)
        {
            //VARIABLES
            int idusu;
            string equipo;
            int cantidad = int.Parse(txtCantidad2.Text);
            int total;

            //CONSULTA PARA TRAER EL ID DE USUARIO
            string consulta11 = "SELECT d2_bd.d2_users.idd2_users FROM d2_bd.d2_users WHERE NuUsuario = '" + textBox20.Text + "'";
            DataTable tb = new DataTable();
            conexion14.ejecutarQuery(consulta11);
            tb = conexion14.cargarDatos(consulta11);
            idusu = (int)tb.Rows[0]["idd2_users"];

            // CONSULTA PARA TRAER EL NOMBRE DEL EQUIPO
            string consulta10 = "SELECT d2_bd.d2_equipo.equipoAgregado FROM d2_bd.d2_equipo WHERE idd2_equipo = '" + txtID3.Text + "'";
            DataTable tb2 = new DataTable();
            conexion15.ejecutarQuery(consulta10);
            tb2 = conexion15.cargarDatos(consulta10);
            equipo = tb2.Rows[0]["equipoAgregado"].ToString();

            //CONSULTA PARA TRAER EL TOTAL DE EQUIPOS
            string consulta12 = "SELECT d2_bd.d2_equipo.Cantidad FROM d2_bd.d2_equipo WHERE Codigo = '" + txtCodigoNS3.Text + "'";
            DataTable tb3 = new DataTable();
            conexion16.ejecutarQuery(consulta12);
            tb3 = conexion16.cargarDatos(consulta12);
            total = (int)tb3.Rows[0]["Cantidad"];

            //CONSULTA PARA INSERTAR EN TABLA DE ASIGNACION
            string consulta9 = "INSERT INTO d2_bd.d2_asignarequipo(idequipo, Codigo, Equipo, cantidad, idemp, CURP, iduser, user, comentario) " +
                "VALUES("+txtID3.Text+",'"+ txtCodigoNS3.Text+"','"+equipo+"',"+cantidad+","+ txtIDE.Text + ",'"+txtCURPE.Text+"',"+idusu+"," +
                "'"+textBox19.Text+"', '"+txtComen3.Text+"')";

            //CONSULTA PARA ACTUALIZAR ALMACEN RESTANDOLE LO ASIGNADO
            string consulta13 = "UPDATE d2_bd.d2_equipo SET Cantidad = " + (total - cantidad) + " WHERE Codigo = '" + txtCodigoNS3.Text + "'";

            if (total > 0)
            {

                if (conexion17.ejecutarQuery(consulta9))
                {
                    if (conexion18.ejecutarQuery(consulta13))
                    {
                        MessageBox.Show("Equipo asignado correctamente");
                        DataTable dt = (DataTable)dataGridView1.DataSource;
                        DataTable dt1 = (DataTable)dataGridView2.DataSource;
                        DataTable dt2 = (DataTable)dataGridView3.DataSource;
                        DataTable dt3 = (DataTable)dataGridView4.DataSource;
                        DataTable dt4 = (DataTable)dataGridView5.DataSource;
                        dt4.Clear();
                        dt.Clear();
                        dt1.Clear();
                        dt2.Clear();
                        dt3.Clear();
                        Limpiar();
                        cargar();
                    }
                    else
                    {
                        MessageBox.Show("!Error!");
                    }
                }
                else
                {
                    MessageBox.Show("!Error!");
                }
            }
            else
            {
                if (total <= 0)
                {
                    MessageBox.Show("¡Error!, No hay disponibilidad del articulo.");
                }
            }

        }

        private void textBox10_KeyUp(object sender, KeyEventArgs e)
        {
            dataGridView2.DataSource = conexion19.cargarDatos2("SELECT idd2_equipo AS 'ID', equipoAgregado AS 'Equipo', Codigo, Talla, Color, Estado, IMEI, Marca, " +
                "Modelo, Comentario, Cantidad FROM d2_bd.d2_equipo WHERE Codigo like ('" + textBox10.Text + "%')");
        }

        public void Limpiar()
        {
            txtID1.Text = "";
            cmbAgreEquipo.Text = "";
            txtCodigoNS.Text = "";
            cmbTalla.Text = "";
            txtColor.Text = "";
            cmbEdo.Text = "";
            txtIMEI.Text = "";
            txtMarca.Text = "";
            txtModelo.Text = "";
            txtComen.Text = "";
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Limpiar();
        }

        private void textBox9_KeyUp(object sender, KeyEventArgs e)
        {
            dataGridView1.DataSource = conexion20.cargarDatos2("SELECT idd2_equipo AS 'ID', equipoAgregado AS 'Equipo', Codigo, Talla, Color, Estado, IMEI, Marca, " +
                "Modelo, Comentario, Cantidad FROM d2_bd.d2_equipo WHERE Codigo like ('" + textBox9.Text + "%')");
        }

        private void button6_Click(object sender, EventArgs e)
        {

        }

        public void Limpiar2()
        {
            txtID.Text = "";
            cmbAgreEquipo2.Text = "";
            txtCodigoNS2.Text = "";
            cmbTalla2.Text = "";
            txtColor2.Text = "";
            cmbEdo2.Text = "";
            txtIMEI2.Text = "";
            txtMarca2.Text = "";
            txtModelo2.Text = "";
            txtComen2.Text = "";
            txtCantidad.Text = "";
        }

        private void textBox12_KeyUp(object sender, KeyEventArgs e)
        {
            dataGridView3.DataSource = conexion21.cargarDatos2("SELECT idd2_equipo AS 'ID', equipoAgregado AS 'Equipo', Codigo, Talla, Color, Estado, IMEI, Marca, " +
                "Modelo, Comentario, Cantidad FROM d2_bd.d2_equipo  WHERE Codigo like ('" + textBox12.Text + "%')");
        }

        private void button7_Click(object sender, EventArgs e)
        {
            Limpiar();
        }

        public void Limpiar3()
        {
            txtIDE.Text = "";
            txtCURPE.Text = "";
            txtID3.Text = "";
            txtCodigoNS3.Text = "";
            txtComen3.Text = "";
            txtCantidad2.Text = "";
        }

        private void textBox13_KeyUp(object sender, KeyEventArgs e)
        {
            dataGridView4.DataSource = conexion22.cargarDatos2("SELECT idd2_empleados AS 'ID', CURP, Nombre, A_Paterno AS 'Apellido Paterno', " +
                "A_Materno AS 'Apellido Materno'  FROM d2_bd.d2_empleados WHERE CURP LIKE ('" + textBox13.Text + "%')");
        }

        Conexion conexion23 = new Conexion();
        private void textBox1_KeyUp(object sender, KeyEventArgs e)
        {
            dataGridView5.DataSource = conexion23.cargarDatos2("SELECT * FROM d2_asignarequipo WHERE CURP like ('" + textBox1.Text + "%') ");
        }
    }
}
