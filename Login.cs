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
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }

        Conexion conexion = new Conexion();
        Conexion conexion2 = new Conexion();
        Conexion conexion3 = new Conexion();



        private void button1_Click(object sender, EventArgs e)
        {
            string noUsu = txtNoUser.Text;
            string contra = txtContra.Text;
            string user = "";
            string pass = "";
            string nous = "";
            string tipo = "";
            string nombre = "";
            string edo = "";
            DataTable tabla = new DataTable();
            DataTable tb2 = new DataTable();
            DataTable tb3 = new DataTable();
            //CUENTA LA CONSULTA QUE SE HACEN CON LOS DATOS INGRESADOS EN LOS TEXT BOX
            string consulta = "SELECT count(*) FROM d2_bd.d2_users WHERE NuUsuario = '"+noUsu+"' AND ContraUs = '"+contra+"'";
            conexion.ejecutarQuery(consulta);
            tb2 = conexion.cargarDatos(consulta);
            nous = tb2.Rows[0]["count(*)"].ToString();
            //MessageBox.Show("La cantidad de usuarios es: " + nous );
            if (nous.Equals("1")){
                //CONSULTA LA INFORMACION Y LA COMPARA CON LOS TEXT BOX
                string consulta2 = "SELECT NuUsuario, ContraUs FROM d2_bd.d2_users WHERE NuUsuario = '" + noUsu + "' AND ContraUs = '" + contra + "'";
                conexion2.ejecutarQuery(consulta2);
                try
                {
                    tabla = conexion2.cargarDatos(consulta2);
                    user = tabla.Rows[0]["NuUsuario"].ToString();
                    pass = tabla.Rows[0]["ContraUs"].ToString();
                    //MessageBox.Show("El número usuario es: " + user + " Y la contraseña es: " + pass);
                    if (noUsu.Equals(user) && contra.Equals(pass))
                    {
                        //PARA SABER EL TIPO DE USUARIO Y ABRIR LA INTERFAZ CORRECTA
                        string consulta3 = "SELECT TipoUs, NombreUs, ApellidoUs, EstadoUs  FROM d2_bd.d2_users WHERE NuUsuario = '" + noUsu + "' AND ContraUs = '" + contra + "'";
                        conexion3.ejecutarQuery(consulta3);
                        tb3 = conexion3.cargarDatos(consulta3);
                        tipo = tb3.Rows[0]["TipoUs"].ToString();
                        edo = tb3.Rows[0]["EstadoUs"].ToString();
                        nombre = tb3.Rows[0]["NombreUs"].ToString() +" "+ tb3.Rows[0]["ApellidoUs"].ToString();
                        //MessageBox.Show("El Tipo es: "+tipo);
                        //IF PARA SABER SI ES UN USUARIO ACTIVO U INACTIVO.
                        if (edo.Equals("Activo"))
                        {
                            //IF PARA ACCESO A SUPER USUARIO
                            if (tipo.Equals("Super Admin"))
                            {
                                super sa = new super();
                                sa.Show();
                                //this.Close();
                                tb2.Clear();
                                tabla.Clear();
                                tb3.Clear();
                                // Super           Login
                                sa.textBox1.Text = noUsu;
                                sa.textBox2.Text = nombre;
                            }
                            else
                            {
                                //IF PARA ACESSO A RECURSOS HUMANOS
                                if (tipo.Equals("RH"))
                                {
                                    RH rh = new RH();
                                    rh.Show();
                                    //this.Close();
                                    tb2.Clear();
                                    tabla.Clear();
                                    tb3.Clear();
                                    rh.textBox24.Text = noUsu;
                                    rh.textBox6.Text = nombre;
                                }
                                else
                                {
                                    //IF PARA ACCESO A OPERATIO
                                    if (tipo.Equals("Operativo"))
                                    {
                                        Operativo op = new Operativo();
                                        op.Show();
                                        //this.Close();
                                        tb2.Clear();
                                        tabla.Clear();
                                        tb3.Clear();
                                        op.textBox43.Text = noUsu;
                                        op.textBox42.Text = nombre;
                                        op.textBox16.Text = noUsu;
                                        op.textBox15.Text = nombre;
                                        op.textBox18.Text = noUsu;
                                        op.textBox17.Text = nombre;
                                    }
                                    else
                                    {
                                        //IF PARA ACCESO ADMINISTRATIVO
                                        if (tipo.Equals("Administrativo"))
                                        {
                                            Almacen al = new Almacen();
                                            al.Show();
                                            //this.Close();
                                            tb2.Clear();
                                            tabla.Clear();
                                            tb3.Clear();
                                            al.textBox16.Text = noUsu;
                                            al.textBox15.Text = nombre;
                                            al.textBox18.Text = noUsu;
                                            al.textBox17.Text = nombre;
                                            al.textBox20.Text = noUsu;
                                            al.textBox19.Text = nombre;
                                            al.txtCantidad.Enabled = false;


                                        }
                                        else
                                        {
                                            //IF PARA ACCESO A CABINA
                                            if (tipo.Equals("Cabina"))
                                            {
                                                Cabina cb = new Cabina();
                                                cb.Show();
                                                //this.Close();
                                                tb2.Clear();
                                                tabla.Clear();
                                                tb3.Clear();
                                                cb.textBox3.Text = noUsu;
                                                cb.textBox2.Text = nombre;
                                                cb.textBox5.Text = noUsu;
                                                cb.textBox4.Text = nombre;
                                            }
                                            else
                                            {
                                                //ELSE PARA ERROR EN TIPO DE USUARIO
                                                MessageBox.Show("Error De Usuario y ó Contraseña Incorrecto. Revise Los Datos.");
                                            }
                                        }
                                    }
                                }
                            }
                        }
                        else
                        {
                            //ELSE PARA USUARIO INACTIVO
                            MessageBox.Show("USUARIO INACTIVO, Sin Acceso.");
                        }
                        
                    }
                    else
                    {
                        //ELSE PARA UN ERROR EN CONTRASENA O NO DE USUARIO
                        MessageBox.Show("Error En Contraseña o Número De Usuario. Revise Los Datos.");
                        tb2.Clear();
                        tabla.Clear();
                    }
                }
                catch (IndexOutOfRangeException ex)
                {
                    MessageBox.Show("Error En Contraseña o Número De Usuario. Revise Los Datos.");
                    tb2.Clear();
                    tabla.Clear();
                }
            }
            else
            {
                MessageBox.Show("¡El Usuario No Existe!");
                tb2.Clear();
                tabla.Clear();
            }          
        }

        //BOTON SALIR
        private void button2_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("¿Desea Salir Del Sistema?", "Salir Del Sistema", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) == System.Windows.Forms.DialogResult.Yes)
            {
                this.Close();
            }
        }


        //SOLO NUMEROS PARA NUMERO DE USUARIO
        private void txtNoUser_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                MessageBox.Show("Solo se permiten números", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                e.Handled = true;
            }
        }

        private void Login_Load(object sender, EventArgs e)
        {
            string Date = DateTime.Now.ToString();
            lblFecha.Text = Date;
        }
    }
}
