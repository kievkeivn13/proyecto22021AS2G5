//using Castle.Components.DictionaryAdapter.Xaml;
using MySqlConnector;
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
	/// Lógica de interacción para wpfAseguradoras.xaml
	/// </summary>
	public partial class wpfAseguradoras : UserControl
	{
		/*public static MySqlConnection ObtenerConexion()
		{
			MySqlConnection conectar = new MySqlConnection(@"server=127.0.0.1;database=clinica;Uid=root;pwd=6182;");
			conectar.Open();
			return conectar;

		}*/
		public wpfAseguradoras()
		{
			InitializeComponent();

		}

        private void btnInsertar_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                string MyConnection2 = "datasource=localhost;port=3306;username=root;password=6182";
                string Query = "insert into CLINICA.ASEGURADORA(pk_id_aseguradora,aseguradora_aseguradora) values('" + this.txtIdaseguradora.Text + "','" + this.txtNombreaseguradora.Text + "');";
                MySqlConnection MyConn2 = new MySqlConnection(MyConnection2);
                MySqlCommand MyCommand2 = new MySqlCommand(Query, MyConn2);
                MySqlDataReader MyReader2;
                MyConn2.Open();
                MyReader2 = MyCommand2.ExecuteReader();
                this.txtIdaseguradora.Text = "";
                this.txtNombreaseguradora.Text = "";
                MessageBox.Show("Datos guardados");

                while (MyReader2.Read())
                {

                }
                MyConn2.Close();
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
                string MyConnection2 = "datasource=localhost;port=3306;username=root;password=6182";
                string Query = "update CLINICA.ASEGURADORA set pk_id_aseguradora='" + this.txtIdaseguradora.Text + "',aseguradora_aseguradora='" + this.txtNombreaseguradora.Text + "'where pk_id_aseguradora='" + this.txtIdaseguradora.Text + "';";
                MySqlConnection MyConn2 = new MySqlConnection(MyConnection2);
                MySqlCommand MyCommand2 = new MySqlCommand(Query, MyConn2);
                MySqlDataReader MyReader2;
                MyConn2.Open();
                MyReader2 = MyCommand2.ExecuteReader();

                MessageBox.Show("Modificacion realizada");
                while (MyReader2.Read())
                {
                }
                MyConn2.Close();
                this.txtIdaseguradora.Text = "";
                this.txtNombreaseguradora.Text = "";
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        private void btnLimpiar_Click(object sender, RoutedEventArgs e)
        {
            this.txtIdaseguradora.Text = "";
            this.txtNombreaseguradora.Text = "";
            this.txtBuscar.Text = "";

        }

        private void btnEliminar_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                string MyConnection2 = "datasource=localhost;port=3306;username=root;password=6182";
                string Query = "delete from CLINICA.ASEGURADORA where pk_id_aseguradora='" + this.txtIdaseguradora.Text + "';";
                MySqlConnection MyConn2 = new MySqlConnection(MyConnection2);
                MySqlCommand MyCommand2 = new MySqlCommand(Query, MyConn2);
                MySqlDataReader MyReader2;
                MyConn2.Open();
                MyReader2 = MyCommand2.ExecuteReader();
                MessageBox.Show("Datos Eliminados");
                while (MyReader2.Read())
                {
                }
                MyConn2.Close();
                this.txtIdaseguradora.Text = "";
                this.txtNombreaseguradora.Text = "";
                this.txtBuscar.Text = "";
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
                string MyConnection2 = "datasource=localhost;port=3306;username=root;password=6182";
                string Query = "select * from CLINICA.ASEGURADORA where pk_id_aseguradora='" + this.txtBuscar.Text + "';";
                MySqlConnection MyConn2 = new MySqlConnection(MyConnection2);
                MySqlCommand MyCommand2 = new MySqlCommand(Query, MyConn2);
                MySqlDataReader MyReader2;
                MyConn2.Open();
                MyReader2 = MyCommand2.ExecuteReader();

                if (MyReader2.Read())
                {
                    txtIdaseguradora.Text = MyReader2["pk_id_aseguradora"].ToString();
                    txtNombreaseguradora.Text = MyReader2["caseguradora_aseguradora"].ToString();
                }
                else
                {
                    MessageBox.Show("Registro no encontrado");
                }
                MyConn2.Close();
                this.txtBuscar.Text = "";
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }
    }
}
