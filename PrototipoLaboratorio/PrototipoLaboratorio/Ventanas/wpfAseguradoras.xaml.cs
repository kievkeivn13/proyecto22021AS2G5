//using Castle.Components.DictionaryAdapter.Xaml;
using MySqlConnector;
using System;
using System.Collections.Generic;
using System.Data;
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
            txtIdaseguradora.Focus();
            Cargartabla();
        }

        //Funcion Tabla
        void Cargartabla()
        {
            try
            {
                string cadena = "SELECT * FROM CLINICA1.ASEGURADORAS";

                OdbcCommand consulta = new OdbcCommand(cadena, cn.conexion());
                consulta.ExecuteNonQuery();

                OdbcDataAdapter dataAdp = new OdbcDataAdapter(consulta);
                DataTable dt = new DataTable("CLINICA1.ASEGURADORAS");

                dataAdp.Fill(dt);
                dgMoneda.ItemsSource = dt.DefaultView;

                dataAdp.Update(dt);

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        //Funcion de Botones
        private void btnInsertar_Click(object sender, RoutedEventArgs e)
        {
            if (txtIdaseguradora.Text != "" || txtNombreaseguradora.Text != "")
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
            else
            {
                MessageBox.Show("Faltan datos.");
                txtIdaseguradora.Focus();
            }

        }
        private void btnModificar_Click(object sender, RoutedEventArgs e)
        {
            if (txtIdaseguradora.Text != "" || txtNombreaseguradora.Text != "")
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
                btnModificar.IsEnabled = false;
                btnEliminar.IsEnabled = false;
            }
            else
            {
                MessageBox.Show("Faltan datos.");
                txtIdaseguradora.Focus();
            }
        }
        private void btnLimpiar_Click(object sender, RoutedEventArgs e)
        {
            txtIdaseguradora.Text = "";
            txtNombreaseguradora.Text = "";
            
            txtBuscar.Text = "";

            txtIdaseguradora.IsEnabled = true;
            btnInsertar.IsEnabled = true;
            btnModificar.IsEnabled = false;
            btnEliminar.IsEnabled = false;

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
                btnModificar.IsEnabled = false;
                btnEliminar.IsEnabled = false;
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
            btnModificar.IsEnabled = true;
            btnEliminar.IsEnabled = true;

        }

        //Funcion tecla enter
        private void txtBuscar_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                e.Handled = true;//elimina el sonido
                btnBuscar_Click(sender, e);//llama al evento click del boton
            }
        }
        private void txtIdaseguradora_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                e.Handled = true;//elimina el sonido
                txtNombreaseguradora.Focus();
            }
        }
        private void txtNombreaseguradora_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                e.Handled = true;//elimina el sonido
                if (btnInsertar.IsEnabled == true || btnModificar.IsEnabled == false)
                {
                    btnInsertar_Click(sender, e);//llama al evento click del boton
                }
                else
                {
                    if (btnModificar.IsEnabled == true || btnInsertar.IsEnabled == false)
                    {
                        btnModificar_Click(sender, e);//llama al evento click del boton
                    }
                }
            }
        }
    }
}
