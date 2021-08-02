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
	/// Lógica de interacción para wfpDescuentosaseguradoras.xaml
	/// </summary>
	public partial class wfpDescuentosaseguradoras : UserControl
	{
		public wfpDescuentosaseguradoras()
		{
			InitializeComponent();
		}

        private void btnInsertar_Click(object sender, RoutedEventArgs e)
        {
            string p = this.txtIddescuento.Text.Trim();
            if (p.Contains(null))
            {
                MessageBox.Show("No pude haber campos vacios");
            }
            else
            {

                try
                {
                    string MyConnection2 = "datasource=localhost;port=3306;username=root;password=6182";
                    string Query = "insert into CLINICA.TIPO_USUARIO(id_tipo_usuario,nombre_tipo_usuario) values('" + this.txtIddescuento.Text + "','" + this.txtNombredescuento.Text + "," + this.txtEstatusaseguradora.Text + "," + this.txtIdaseguradora.Text + "');";
                    MySqlConnection MyConn2 = new MySqlConnection(MyConnection2);
                    MySqlCommand MyCommand2 = new MySqlCommand(Query, MyConn2);
                    MySqlDataReader MyReader2;
                    MyConn2.Open();
                    MyReader2 = MyCommand2.ExecuteReader();
                    this.txtIddescuento.Text = "";
                    this.txtNombredescuento.Text = "";
                    this.txtEstatusaseguradora.Text = "";
                    this.txtIdaseguradora.Text = "";
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
        }

        private void btnModificar_Click(object sender, RoutedEventArgs e)
        {
            string p = this.txtIddescuento.Text.Trim();
            if (p.Contains(null))
            {
                MessageBox.Show("No pude haber campos vacios");
            }
            else { 
                try
                {
                    string MyConnection2 = "datasource=localhost;port=3306;username=root;password=6182";
                    string Query = "update CLINICA.TIPO_USUARIO set id_tipo_usuario='" + this.txtIddescuento.Text + "',nombre_tipo_usuario='" + this.txtNombredescuento.Text + "',nombre_tipo_usuario='" + this.txtEstatusaseguradora.Text + "',nombre_tipo_usuario='" + this.txtIdaseguradora.Text + "'where id_tipo_usuario='" + this.txtIddescuento.Text + "';";
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
                    this.txtIddescuento.Text = "";
                    this.txtNombredescuento.Text = "";
                    this.txtEstatusaseguradora.Text = "";
                    this.txtIdaseguradora.Text = "";
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        private void btnLimpiar_Click(object sender, RoutedEventArgs e)
        {
            this.txtIddescuento.Text = "";
            this.txtNombredescuento.Text = "";
            this.txtEstatusaseguradora.Text = "";
            this.txtIdaseguradora.Text = "";
            this.txtBuscar.Text = "";

        }

        private void btnEliminar_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                string MyConnection2 = "datasource=localhost;port=3306;username=root;password=6182";
                string Query = "delete from CLINICA.TIPO_USUARIO where id_tipo_usuario='" + this.txtIddescuento.Text + "';";
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
                this.txtIddescuento.Text = "";
                this.txtNombredescuento.Text = "";
                this.txtEstatusaseguradora.Text = "";
                this.txtIdaseguradora.Text = "";
                this.txtBuscar.Text = "";
            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnBuscar_Click(object sender, RoutedEventArgs e)
        {
            string p = this.txtBuscar.Text.Trim();
            if (p.Contains(""))
            {
                MessageBox.Show("Ingrese un dato");
            }
            else
            {
                try
                {
                    string MyConnection2 = "datasource=localhost;port=3306;username=root;password=6182";
                    string Query = "select * from CLINICA.TIPO_USUARIO where id_tipo_usuario='" + this.txtBuscar.Text + "';";
                    MySqlConnection MyConn2 = new MySqlConnection(MyConnection2);
                    MySqlCommand MyCommand2 = new MySqlCommand(Query, MyConn2);
                    MySqlDataReader MyReader2;
                    MyConn2.Open();
                    MyReader2 = MyCommand2.ExecuteReader();

                    if (MyReader2.Read())
                    {
                        txtIddescuento.Text = MyReader2["id_tipo_usuario"].ToString();
                        txtNombredescuento.Text = MyReader2["nombre_tipo_usuario"].ToString();
                        txtEstatusaseguradora.Text = MyReader2["id_tipo_usuario"].ToString();
                        txtIdaseguradora.Text = MyReader2["nombre_tipo_usuario"].ToString();
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
}
