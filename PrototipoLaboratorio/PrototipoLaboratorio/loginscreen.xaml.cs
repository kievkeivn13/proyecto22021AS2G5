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
using System.Windows.Shapes;

namespace PrototipoLaboratorio
{
    /// <summary>
    /// Lógica de interacción para loginscreen.xaml
    /// </summary>
    public partial class loginscreen : Window
    {
        Conexion cn = new Conexion();
        public loginscreen()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (txtUsuario.Text != "" || txtContraseña.Password != "")
            {
                try
                {
                    string Query = "select COUNT(*) from CLINICA1.USUARIOS where nombre_usuario='" + this.txtUsuario.Text + "' AND passwd_usuario='" + this.txtContraseña.Password + "';";

                    OdbcCommand consulta = new OdbcCommand(Query, cn.conexion());
                    consulta.ExecuteNonQuery();
                   
                    int count = Convert.ToInt32(consulta.ExecuteScalar());
                    if (count == 1)
                    {
                        String user = txtUsuario.Text;
                        MessageBox.Show("Bienvenido "+user);
                        MainWindow dashboard = new MainWindow();
                        dashboard.Show();
                        this.Close();
                    }
                    else
                    {
                        MessageBox.Show("Usuario o contraseña incorrecta.");
                        txtContraseña.Password = "";
                        txtUsuario.Text = "";
                    }

                }
                catch (Exception ex)
                {
                   MessageBox.Show(ex.Message);
                }
            }
            else
            {
                MessageBox.Show("Falta usuario o contraseña.");
            }

        }
    }
}
