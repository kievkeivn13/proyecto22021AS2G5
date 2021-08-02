using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace PrototipoLaboratorio.Ventanas
{
    /// <summary>
    /// Lógica de interacción para wpfEmpleados.xaml
    /// </summary>
    public partial class wpfEmpleados : UserControl
    {
        public wpfEmpleados()
        {
            InitializeComponent();
        }

        private void btnInsertar_Click(object sender, RoutedEventArgs e)
        {
            String strIdEmpleado = txtIdEmpleado.Text;
            String strCui = txtCui.Text;
            String strNit = txtNit.Text;
            String strNombre= txtNombre.Text;
            String strApellido = txtApellido.Text;
            String strGenero = txtGenero.Text;
            int intEdad = int.Parse(txtEdad.Text);
            String strTelefono = txtTelefono.Text;
            String strDireccion = txtDireccion.Text;
            String strEmail = txtEmail.Text;
            String strStatus = txtStatus.Text;
            String strIdPuesto = txtIdPuesto.Text;
            String strColegiado = txtColegiado.Text;

            string sql = "INSERT INTO empleado VALUES (" +
                +'"' + strIdEmpleado +
                "' , '" + strCui +
                "' , '" + strNit +
                "' , '" + strNombre +
                "' , '" + strApellido +
                "' , '" + strGenero +
                "' , '" + intEdad +
                "' , '" + strTelefono +
                "' , '" + strDireccion +
                "' , '" + strEmail +
                "' , '" + strStatus +
                "' , '" + strIdPuesto +
                "' , '" + strColegiado 
                + ");";

            MySqlConnection conexionBD = Conexion.conexion();
            conexionBD.Open();

            try
            {
                MySqlCommand comando = new MySqlCommand(sql, conexionBD);
                comando.ExecuteNonQuery();
                MessageBox.Show("Registro guardado con éxito!");
            }
            catch (MySqlException ex)
            {
                MessageBox.Show("Error al guardar: " + ex.Message);
            }

            finally
            {
                conexionBD.Close();
            }
        }
    }
}
