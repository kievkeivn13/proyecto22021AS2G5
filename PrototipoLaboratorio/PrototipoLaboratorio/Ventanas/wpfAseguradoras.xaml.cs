//using Castle.Components.DictionaryAdapter.Xaml;
using MySqlConnector;
using System;
using System.Collections.Generic;
using System.Data.Odbc;
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
	/// Lógica de interacción para wpfAseguradoras.xaml
	/// </summary>
    public partial class wpfAseguradoras : UserControl
	{
        Conexion cn = new Conexion();
        public wpfAseguradoras()
		{
			InitializeComponent();

		}

        private void btnInsertar_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                string cadena = "INSERT INTO" +
                    " CLINICA.ASEGURADORAS (id_aseguradora, nombre_aseguradora) VALUES (" +
                    "'" + txtIdaseguradora.Text + "', '"
                        + txtNombreaseguradora.Text + "' ); ";

                OdbcCommand consulta = new OdbcCommand(cadena, cn.conexion());

                consulta.ExecuteNonQuery();
                MessageBox.Show("Inserción realizada");

                txtIdaseguradora.Text = "";
                txtNombreaseguradora.Text = "";
                txtBuscar.Text = "";

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        private void btnModificar_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                string cadena = "update CLINICA.ASEGURADORAS set id_aseguradora ='" + this.txtIdaseguradora.Text
                    + "',nombre_aseguradora ='" + this.txtNombreaseguradora.Text
                 
                    + "'where id_aseguradora='" + this.txtIdaseguradora.Text + "';";

                OdbcCommand consulta = new OdbcCommand(cadena, cn.conexion());
                consulta.ExecuteNonQuery();

                MessageBox.Show("Modificacion realizada");

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            txtIdaseguradora.Text = "";
            txtNombreaseguradora.Text = "";
          
            txtBuscar.Text = "";

            txtIdaseguradora.IsEnabled = true;
            btnInsertar.IsEnabled = true;

        }

        private void btnLimpiar_Click(object sender, RoutedEventArgs e)
        {
            txtIdaseguradora.Text = "";
            txtNombreaseguradora.Text = "";
            
            txtBuscar.Text = "";

            txtIdaseguradora.IsEnabled = true;
            btnInsertar.IsEnabled = true;

        }

        private void btnEliminar_Click(object sender, RoutedEventArgs e)
        {
            try
            {

                string cadena = "delete from CLINICA.ASEGURADORAS where id_aseguradora='" + this.txtIdaseguradora.Text + "';";


                OdbcCommand consulta = new OdbcCommand(cadena, cn.conexion());
                consulta.ExecuteNonQuery();

                OdbcDataReader busqueda;
                busqueda = consulta.ExecuteReader();

                MessageBox.Show("Datos Eliminados");
                while (busqueda.Read())
                {
                }
                txtIdaseguradora.Text = "";
                txtNombreaseguradora.Text = "";
           
                txtBuscar.Text = "";

                txtIdaseguradora.IsEnabled = true;
                btnInsertar.IsEnabled = true;
            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        private void btnBuscar_Click(object sender, RoutedEventArgs e)
        {

            try
            {
                string Query = "select * from CLINICA.ASEGURADORAS where id_aseguradora='" + this.txtBuscar.Text + "';";

                OdbcCommand consulta = new OdbcCommand(Query, cn.conexion());
                consulta.ExecuteNonQuery();

                OdbcDataReader busqueda;
                busqueda = consulta.ExecuteReader();

                if (busqueda.Read())
                {
                    txtIdaseguradora.Text = busqueda["id_aseguradora"].ToString();
                    txtNombreaseguradora.Text = busqueda["nombre_aseguradora"].ToString();
                    
                }
                else
                {
                    MessageBox.Show("Registro no encontrado");
                }

                this.txtBuscar.Text = "";
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            txtIdaseguradora.IsEnabled = false;
            btnInsertar.IsEnabled = false;

        }
    }
}
