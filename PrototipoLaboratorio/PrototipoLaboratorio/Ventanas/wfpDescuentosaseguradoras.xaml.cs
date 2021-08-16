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
	/// Lógica de interacción para wfpDescuentosaseguradoras.xaml
	/// </summary>
	public partial class wfpDescuentosaseguradoras : UserControl
	{
        Conexion cn = new Conexion();
        public wfpDescuentosaseguradoras()
		{
			InitializeComponent();
            cargarCbo();
            Cargartabla();
            txtIddescuento.Focus();
		}

        //Cargar Tabla
        void Cargartabla()
        {
            try
            {
                string cadena = "SELECT * FROM CLINICA1.DESCUENTOS_ASEGURADORAS";

                OdbcCommand consulta = new OdbcCommand(cadena, cn.conexion());
                consulta.ExecuteNonQuery();

                OdbcDataAdapter dataAdp = new OdbcDataAdapter(consulta);
                DataTable dt = new DataTable("CLINICA1.DESCUENTOS_ASEGURADORAS");

                dataAdp.Fill(dt);
                dgDescuentoA.ItemsSource = dt.DefaultView;

                dataAdp.Update(dt);

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        //Cargar Combobox
        void cargarCbo()
        {
            string cadena = "SELECT nombre_aseguradora FROM CLINICA1.ASEGURADORAS";

            OdbcCommand consulta = new OdbcCommand(cadena, cn.conexion());
            consulta.ExecuteNonQuery();

            OdbcDataReader busqueda;
            busqueda = consulta.ExecuteReader();

            cboNombreaseguradora.Items.Clear();

            cboNombreaseguradora.Items.Add("Selecione una opción");
            while (busqueda.Read())
            {
                cboNombreaseguradora.Items.Add(busqueda["nombre_aseguradora"].ToString());
            }
            cboNombreaseguradora.SelectedIndex = 0;
        }

        //Funcion de botones
        private void btnInsertar_Click(object sender, RoutedEventArgs e)
        {
            if (txtIddescuento.Text != "" || txtNombredescuento.Text != "" || txtDescuento.Text != "" || txtIdaseguradora.Text != "")
            {
                try
                {
                    string cadena = "INSERT INTO " +
                        " CLINICA.DESCUENTOS_ASEGURADORAS (id_descuento, nombre_descuento, descuento," +
                        " id_aseguradora) VALUES (" +
                        "'" + txtIddescuento.Text + "', '"
                         + txtNombredescuento.Text + "', '"
                         + txtDescuento.Text + "', '"
                         + txtIdaseguradora.Text + "' ); ";

                    OdbcCommand consulta = new OdbcCommand(cadena, cn.conexion());

                    consulta.ExecuteNonQuery();
                    MessageBox.Show("Inserción realizada");

                    txtIddescuento.Text = "";
                    txtNombredescuento.Text = "";
                    txtDescuento.Text = "";
                    txtIdaseguradora.Text = "";
                    cargarCbo();
                    Cargartabla();
                    txtIddescuento.IsEnabled = true;
                    btnInsertar.IsEnabled = true;
                    btnModificar.IsEnabled = false;
                    btnEliminar.IsEnabled = false;

                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
            else
            {
                MessageBox.Show("Faltan datos.");
                txtIddescuento.Focus();
            }
        }
        private void btnModificar_Click(object sender, RoutedEventArgs e)
        {
            if (txtIddescuento.Text != "" || txtNombredescuento.Text != "" || txtDescuento.Text != "" || txtIdaseguradora.Text != "")
            {
                try
                {
                    string cadena = "update CLINICA.DESCUENTOS_ASEGURADORAS set id_descuento ='" + this.txtIddescuento.Text
                        + "',nombre_descuento ='" + this.txtNombredescuento.Text
                        + "',descuento='" + this.txtDescuento.Text
                        + "',id_aseguradora ='" + this.txtIdaseguradora.Text

                        + "'where id_descuento='" + this.txtIddescuento.Text + "';";

                    OdbcCommand consulta = new OdbcCommand(cadena, cn.conexion());
                    consulta.ExecuteNonQuery();

                    MessageBox.Show("Modificacion realizada");

                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }

                txtIdaseguradora.Text = "";
                txtNombredescuento.Text = "";
                txtDescuento.Text = "";
                txtIdaseguradora.Text = "";
                cargarCbo();
                Cargartabla();
                txtIddescuento.IsEnabled = true;
                btnInsertar.IsEnabled = true;
                btnModificar.IsEnabled = false;
                btnEliminar.IsEnabled = false;
            }
            else
            {
                MessageBox.Show("Faltan datos.");
                txtIddescuento.Focus();
            }
        }
        private void btnLimpiar_Click(object sender, RoutedEventArgs e)
        {
            txtIdaseguradora.Text = "";
            txtNombredescuento.Text = "";
            txtDescuento.Text = "";
            txtIdaseguradora.Text = "";
            cargarCbo();
            Cargartabla();
            txtIddescuento.IsEnabled = true;
            btnInsertar.IsEnabled = true;
            btnModificar.IsEnabled = false;
            btnEliminar.IsEnabled = false;
        }
        private void btnEliminar_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                string cadena = "delete from CLINICA.DESCUENTOS_ASEGURADORAS where id_descuento='" + this.txtIddescuento.Text + "';";

                OdbcCommand consulta = new OdbcCommand(cadena, cn.conexion());
                consulta.ExecuteNonQuery();

                OdbcDataReader busqueda;
                busqueda = consulta.ExecuteReader();

                MessageBox.Show("Datos Eliminados");
                while (busqueda.Read())
                {
                }
                txtIdaseguradora.Text = "";
                txtNombredescuento.Text = "";
                txtDescuento.Text = "";
                txtIdaseguradora.Text = "";
                cargarCbo();
                Cargartabla();
                txtIddescuento.IsEnabled = true;
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
            if (txtBuscar.Text != "")
            {
                try
                {
                    string Query = "select * from CLINICA.DESCUENTOS_ASEGURADORAS where id_descuento='" + this.txtBuscar.Text + "';";

                    OdbcCommand consulta = new OdbcCommand(Query, cn.conexion());
                    consulta.ExecuteNonQuery();

                    OdbcDataReader busqueda;
                    busqueda = consulta.ExecuteReader();

                    if (busqueda.Read())
                    {
                        txtIddescuento.Text = busqueda["id_descuento"].ToString();
                        txtNombredescuento.Text = busqueda["nombre_descuento"].ToString();
                        txtDescuento.Text = busqueda["descuento"].ToString();
                        txtIdaseguradora.Text = busqueda["id_aseguradora"].ToString();
                    }
                    else
                    {
                        MessageBox.Show("Registro no encontrado");
                    }
                    try
                    {
                        string Query2 = "select * from CLINICA.ASEGURADORAS where id_aseguradora='" + this.txtIdaseguradora.Text.Trim() + "';";

                        OdbcCommand consulta2 = new OdbcCommand(Query2, cn.conexion());
                        consulta2.ExecuteNonQuery();

                        OdbcDataReader busqueda2;
                        busqueda2 = consulta2.ExecuteReader();

                        if (busqueda2.Read())
                        {
                            cboNombreaseguradora.Items.Add(busqueda2["nombre_aseguradora"].ToString());
                        }
                        int ultimo = cboNombreaseguradora.Items.Count - 1;
                        cboNombreaseguradora.SelectedIndex = ultimo;  //<-- con esto lo dejas seleccionado

                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }

                    this.txtBuscar.Text = "";
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
                cargarCbo();
                Cargartabla();
                txtIddescuento.IsEnabled = false;
                btnInsertar.IsEnabled = false;
                btnModificar.IsEnabled = true;
                btnEliminar.IsEnabled = true;
            }
            else
            {
                MessageBox.Show("Ingrese dato a buscar");
            }
        }

        //Seleccion en Combobox
        private void cboTipousuario_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            try
            {
                string cadena = "SELECT id_aseguradora FROM CLINICA.ASEGURADORAS where nombre_aseguradora='" + this.cboNombreaseguradora.SelectedItem.ToString() + "';";

                OdbcCommand consulta = new OdbcCommand(cadena, cn.conexion());
                consulta.ExecuteNonQuery();

                OdbcDataReader busqueda;
                busqueda = consulta.ExecuteReader();

                while (busqueda.Read())
                {
                    txtIdaseguradora.Text = busqueda["id_aseguradora"].ToString();
                   
                }
            }
            catch (Exception ex)
            {
                //MessageBox.Show(ex.Message);
            }
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
        private void txtIddescuento_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                e.Handled = true;//elimina el sonido
                txtNombredescuento.Focus();
            }
        }
        private void txtNombredescuento_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                e.Handled = true;//elimina el sonido
                txtDescuento.Focus();
            }
        }
        private void txtDescuento_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                e.Handled = true;//elimina el sonido
                cboNombreaseguradora.Focus();
            }
        }
        private void cboNombreaseguradora_KeyDown(object sender, KeyEventArgs e)
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
