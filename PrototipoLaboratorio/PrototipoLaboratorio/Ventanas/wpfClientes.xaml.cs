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
	/// Lógica de interacción para wpfClientes.xaml
	/// </summary>
	public partial class wpfClientes : UserControl
	{
		/*public static MySqlConnection ObtenerConexion()
		{
			MySqlConnection conectar = new MySqlConnection(@"server=127.0.0.1;database=clinica;Uid=root;pwd=6182;");
			conectar.Open();
			return conectar;

		}*/
		public wpfClientes()
		{
			InitializeComponent();

		}
 private void btnModificar_Click(object sender, RoutedEventArgs e)
        {
           
                try
                {
                    string MyConnection2 = "datasource=localhost;port=3306;username=root;password=6182";
                    string Query = "update CLINICA.CLIENTE set pk_id_cliente='" + this.txtIdcliente.Text + "',nombre_cliente='" + this.txtNombrecliente.Text + "',apellido_cliente='" + this.txtApellidocliente.Text + "',birthday_cliente='" + this.dpEdadcliente.Text + "',edad_cliente='" + this.txtEdadcliente.Text + "'where pk_id_cliente='" + this.txtIdcliente.Text + "';";
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
                    this.txtIdcliente.Text = "";
                    this.txtNombrecliente.Text = "";
                    this.txtApellidocliente.Text = "";
                    this.txtEdadcliente.Text = "";

            }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            
        }
		public void btnIngresaraseguradora_Click(object sender, RoutedEventArgs e)
		{
          
                try
                {
                    string MyConnection2 = "datasource=localhost;port=3306;username=root;password=6182";
                    
                    string Query = "insert into CLINICA.CLIENTE(pk_id_cliente,nombre_cliente,apellido_cliente,birthday_cliente,edad_cliente) values('" + this.txtIdcliente.Text + "','" + this.txtNombrecliente.Text + this.txtApellidocliente.Text + this.dpEdadcliente.Text + this.txtEdadcliente.Text + "');";
                    MySqlConnection MyConn2 = new MySqlConnection(MyConnection2);
                    MySqlCommand MyCommand2 = new MySqlCommand(Query, MyConn2);
                    MySqlDataReader MyReader2;
                    MyConn2.Open();
                    MyReader2 = MyCommand2.ExecuteReader();
                    this.txtIdcliente.Text = "";
                    this.txtNombrecliente.Text = "";
                    this.txtApellidocliente.Text = "";
                    this.dpEdadcliente.Text = "";
                    this.txtEdadcliente.Text = "";


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

        private void btnLimpiar_Click(object sender, RoutedEventArgs e)
        {
            this.txtIdcliente.Text = "";
            this.txtNombrecliente.Text = "";
            this.txtApellidocliente.Text = "";
            this.txtEdadcliente.Text = "";
            this.dpEdadcliente.Text = "";
            this.txtBuscar.Text = "";           
        }

        private void btnEliminar_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                string MyConnection2 = "datasource=localhost;port=3306;username=root;password=6182";
                string Query = "delete from CLINICA.CLIENTE where pk_id_cliente='" + this.txtIdcliente.Text + "';";
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
                this.txtIdcliente.Text = "";
                this.txtNombrecliente.Text = "";
                this.txtApellidocliente.Text = "";
                this.dpEdadcliente.Text = "";
                this.txtEdadcliente.Text = "";

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
                    string Query = "select * from CLINICA.CLIENTE where pk_id_cliente='" + this.txtBuscar.Text + "';";
                    MySqlConnection MyConn2 = new MySqlConnection(MyConnection2);
                    MySqlCommand MyCommand2 = new MySqlCommand(Query, MyConn2);
                    MySqlDataReader MyReader2;
                    MyConn2.Open();
                    MyReader2 = MyCommand2.ExecuteReader();

                    if (MyReader2.Read())
                    {
                        txtIdcliente.Text = MyReader2["pk_id_cliente"].ToString();
                        txtNombrecliente.Text = MyReader2["nombre_cliente"].ToString();
                        txtApellidocliente.Text = MyReader2["apellido_cliente"].ToString();
                        dpEdadcliente.Text = MyReader2["birthday_cliente"].ToString();
                        txtEdadcliente.Text = MyReader2["edad_cliente"].ToString();

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

      

        private void btnCalcular_Click(object sender, RoutedEventArgs e)
        {
            DateTime fecha = dpEdadcliente.SelectedDate.Value;
            int edad = DateTime.Today.AddTicks(-fecha.Ticks).Year - 1;
            this.txtEdadcliente.Text = edad.ToString();
        }
    }
}
