using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient; //Conector Mysql
using System.Data;
using System.IO; //Uso De Tablas

namespace Sistema_D2_Seguridad_Privada
{
    class Conexion
    {
        public DataTable dt = new DataTable();

        //cadena de conexion 
        public String strConexion = "server = localhost; user id = root; password = Lana09; database = d2_bd";

        // clase para conectar con MySQL
        public MySqlConnection conectar;

        public bool abrir()
        {
            try
            {
                conectar = new MySqlConnection(strConexion);
                conectar.Open();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public void cerrar()
        {
            conectar.Close();
        }

        public bool ejecutarQuery(string query)
        {
            try
            {
                abrir();
                MySqlCommand comando = new MySqlCommand(query, conectar);
                comando.ExecuteNonQuery();
                cerrar();
                return true;
            }
            catch (Exception er)
            {
                System.Windows.Forms.MessageBox.Show(er.Message);
                return false;
            }

        }

        public DataTable cargarDatos2(String query)
        {
            try
            {
                abrir();
                MySqlCommand cmd = conectar.CreateCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = query;
                cmd.ExecuteNonQuery();
                DataTable dt = new DataTable();
                MySqlDataAdapter da = new MySqlDataAdapter(cmd);
                da.Fill(dt);
                return dt;
            }
            catch (Exception er)
            {
                return dt;
            }
        }



        public DataTable cargarDatos(String query)
        {
            try
            {
                abrir();
                MySqlDataAdapter comando = new MySqlDataAdapter(query,
                strConexion);
                comando.Fill(dt);
                return dt;
            }
            catch (Exception er)
            {
                return dt;
            }
        }
    }
}
