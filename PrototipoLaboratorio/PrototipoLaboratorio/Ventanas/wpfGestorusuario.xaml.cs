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
using MySqlConnector;
using PrototipoLaboratorio;

namespace PrototipoLaboratorio.Ventanas
{
    /// <summary>
    /// Lógica de interacción para wpfGestorusuario.xaml
    /// </summary>
    public partial class wpfGestorusuario : UserControl
    {
        public wpfGestorusuario()
        {
            InitializeComponent();
          

        }
                
        private void btnInsertar_Click(object sender, RoutedEventArgs e)
        {
           
            

                try
                {
                    string MyConnection2 = "datasource=localhost;port=3306;username=root;password=6182";
                    string Query = "insert into CLINICA.REGISTRO(pk_usuario_registro,contrasena_registro) values('" + this.txtUsuario.Text + "','" + this.txtContraseña.Password + "');";
                    MySqlConnection MyConn2 = new MySqlConnection(MyConnection2);
                    MySqlCommand MyCommand2 = new MySqlCommand(Query, MyConn2);
                    MySqlDataReader MyReader2;
                    MyConn2.Open();
                    MyReader2 = MyCommand2.ExecuteReader();
                    this.txtUsuario.Text = "";
                    this.txtContraseña.Password = "";
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
                    string Query = "update CLINICA.REGISTRO set pk_usuario_registro='" + this.txtUsuario.Text + "',contrasena_registro='" + this.txtContraseña.Password + "'where pk_usuario_registro='" + this.txtUsuario.Text + "';";
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
                    this.txtUsuario.Text = "";
                    this.txtContraseña.Password = "";
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            
        }

        private void btnLimpiar_Click(object sender, RoutedEventArgs e)
        {
            this.txtUsuario.Text = "";
            this.txtContraseña.Password = "";
            this.txtBuscar.Text = "";
            
        }

        private void btnEliminar_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                string MyConnection2 = "datasource=localhost;port=3306;username=root;password=6182";
                string Query = "delete from CLINICA.REGISTRO where pk_usuario_registro='" + this.txtUsuario.Text + "';";
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
            this.txtUsuario.Text = "";
            this.txtContraseña.Password = "";
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
                    string Query = "select * from CLINICA.REGISTRO where pk_usuario_registro='" + this.txtBuscar.Text + "';";
                    MySqlConnection MyConn2 = new MySqlConnection(MyConnection2);
                    MySqlCommand MyCommand2 = new MySqlCommand(Query, MyConn2);
                    MySqlDataReader MyReader2;
                    MyConn2.Open();
                    MyReader2 = MyCommand2.ExecuteReader();

                    if (MyReader2.Read())
                    {
                        txtUsuario.Text = MyReader2["pk_usuario_registro"].ToString();
                        txtContraseña.Password = MyReader2["contrasena_registro"].ToString();
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
