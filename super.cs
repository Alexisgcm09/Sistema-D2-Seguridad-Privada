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
    public partial class super : Form
    {
        public super()
        {
            InitializeComponent();
        }

        //BOTON PARA ENTRAR A LA INTERFAZ DE USUARIOS
        private void button1_Click(object sender, EventArgs e)
        {
            string nous = textBox1.Text;
            string nom = textBox2.Text;
            Usuarios us = new Usuarios();
            us.textBox3.Text = nous;
            us.textBox1.Text = nom;
            us.textBox5.Text = nous;
            us.textBox4.Text = nom;
            us.textBox14.Text = nous;
            us.textBox13.Text = nom;
            us.textBox8.Text = nous;
            us.textBox7.Text = nom;
            us.Show();
            this.Close();          
            
        }

        //BOTON PARA ENTRAR EN LA INTERFAZ DEL DEPARTAMENTO OPERATIVO
        private void button2_Click(object sender, EventArgs e)
        {
            string noUsu = textBox1.Text;
            string nombre = textBox2.Text;
            Operativo op = new Operativo();
            op.textBox43.Text = noUsu;
            op.textBox42.Text = nombre;
            op.textBox16.Text = noUsu;
            op.textBox15.Text = nombre;
            op.textBox18.Text = noUsu;
            op.textBox17.Text = nombre;
            op.Show();
            this.Close();
        }

        //BOTON PARA ENTRAR EN LA INTERFAZ DE RH
        private void button6_Click(object sender, EventArgs e)
        {
            string nous = textBox1.Text;
            string nom = textBox2.Text;
            RH rh = new RH();
            rh.textBox24.Text = nous;
            rh.textBox6.Text = nom;
            rh.textBox38.Text = nous;
            rh.textBox39.Text = nom;
            rh.textBox41.Text = nous;
            rh.textBox40.Text = nom;
            rh.textBox43.Text = nous;
            rh.textBox42.Text = nom;
            rh.Show();
            this.Close();
        }

        //BOTON PARA ENTRAR EN LA INTERFAZ DE ALMACEN
        private void button4_Click(object sender, EventArgs e)
        {
            string noUsu = textBox1.Text;
            string nombre = textBox2.Text;
            Almacen al = new Almacen();
            al.textBox16.Text = noUsu;
            al.textBox15.Text = nombre;
            al.textBox18.Text = noUsu;
            al.textBox17.Text = nombre;
            al.textBox20.Text = noUsu;
            al.textBox19.Text = nombre;
            al.Show();
            this.Close();
        }

        //BOTON PARA ENTRAR EN LA INTERFAZ DE CABINA OPERATIVA
        private void button3_Click(object sender, EventArgs e)
        {
            string noUsu = textBox1.Text;
            string nombre = textBox2.Text;
            Cabina cab = new Cabina();
            cab.textBox3.Text = noUsu;
            cab.textBox2.Text = nombre;
            cab.textBox5.Text = noUsu;
            cab.textBox4.Text = nombre;
            cab.Show();
            this.Close();
        }

        //BOTON PARA CERRAR EL SISTEMA
        private void button5_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("¿Desea Cerrar Sesión?", "Cerrar Sesión", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) == System.Windows.Forms.DialogResult.Yes)
            {
                Login lg = new Login();
                lg.Show();
                this.Close();
            }
        }

        private void super_Load(object sender, EventArgs e)
        {
            string Date = DateTime.Now.ToString();
            lblFecha.Text = Date;
        }

        private void button7_Click(object sender, EventArgs e)
        {
            string noUsu = textBox1.Text;
            string nombre = textBox2.Text;            
            Reportes rp=new Reportes();
            rp.textBox3.Text = noUsu;
            rp.textBox2.Text = nombre;
            rp.Show();
            this.Close();
        }
    }
}
