using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Text;

namespace PrototipoLaboratorio
{
    class Conexion
    {
        public static MySqlConnection conexion()
        {
            string servidor = "localhost";
            string bd = "clinica";
            string usuario = "root";
            string password = "Sebas1234";

            string cadenaConexion = "Database=" + bd + "; Data Source=" +
                servidor + "; User Id=" + usuario + "; Password=" + password;

            try
            {
                MySqlConnection conexionBD = new MySqlConnection(cadenaConexion);

                return conexionBD;
            }
            catch (MySqlException ex)
            {
                Console.WriteLine("Error:" + ex.Message);
                return null;
            }
        }
    }
}
