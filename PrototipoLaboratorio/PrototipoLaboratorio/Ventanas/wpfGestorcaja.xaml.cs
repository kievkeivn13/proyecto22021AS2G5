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
    /// Lógica de interacción para wpfGestorcaja.xaml
    /// </summary>
    public partial class wpfGestorcaja : UserControl
    {
        Conexion cn = new Conexion();
        public wpfGestorcaja()
        {
            InitializeComponent();
        }

        //RadioButton
        void rbnestado()
        {
            if (txtEstadocaja.Text == "1")
            {
                rbnActivo.IsChecked = true;
                rbnSuspendido.IsChecked = false;
            }
            else
            {
                if (txtEstadocaja.Text == "0")
                {
                    rbnActivo.IsChecked = false;
                    rbnSuspendido.IsChecked = true;
                }
            }
        }

        //Funcion Tabla
        void Cargartabla()
        {
            try
            {
                string cadena = "SELECT * FROM CLINICA1.CAJA";

                OdbcCommand consulta = new OdbcCommand(cadena, cn.conexion());
                consulta.ExecuteNonQuery();

                OdbcDataAdapter dataAdp = new OdbcDataAdapter(consulta);
                DataTable dt = new DataTable("CLINICA1.CAJA");

                dataAdp.Fill(dt);
                dgCaja.ItemsSource = dt.DefaultView;

                dataAdp.Update(dt);

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        //Funcion de Botones
        private void btnModificar_Click(object sender, RoutedEventArgs e)
        {
            if (txtIdcaja.Text != "" || txtNombrecaja.Text != "" || txtSaldocaja.Text != "" || txtEstadocaja.Text != "")
            {
                try
                {
                    string cadena = "update CLINICA1.CAJA set id_caja ='" + this.txtIdcaja.Text
                        + "',nombre_caja ='" + this.txtNombrecaja.Text
                        + "',saldo_caja ='" + this.txtSaldocaja.Text
                        + "',status_caja ='" + this.txtEstadocaja.Text

                        + "'where id_caja='" + this.txtIdcaja.Text + "';";

                    OdbcCommand consulta = new OdbcCommand(cadena, cn.conexion());
                    consulta.ExecuteNonQuery();

                    MessageBox.Show("Modificacion realizada");

                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }

                txtIdcaja.Text = "";
                txtNombrecaja.Text = "";
                txtSaldocaja.Text = "";
                txtEstadocaja.Text = "";
                txtBuscar.Text = "";

                txtIdcaja.IsEnabled = true;
                btnInsertar.IsEnabled = true;
                btnEliminar.IsEnabled = false;
                btnModificar.IsEnabled = false;
            }
            else
            {
                MessageBox.Show("Faltan datos.");
                txtIdcaja.Focus();
            }
        }
        private void btnInsertar_Click(object sender, RoutedEventArgs e)
        {
            if (txtIdcaja.Text != "" || txtNombrecaja.Text != "" || txtSaldocaja.Text != "" || txtEstadocaja.Text != "")
            {
                try
                {
                    string cadena = "INSERT INTO" +
                        " CLINICA1.CAJA (id_caja, nombre_caja, saldo_caja, status_caja) VALUES (" +
                        "'" + txtIdcaja.Text + "', '"
                            + txtNombrecaja.Text + "', '"
                            + txtSaldocaja.Text + "', '"
                            + txtEstadocaja.Text + "' ); ";

                    OdbcCommand consulta = new OdbcCommand(cadena, cn.conexion());

                    consulta.ExecuteNonQuery();
                    MessageBox.Show("Inserción realizada");

                    txtIdcaja.Text = "";
                    txtNombrecaja.Text = "";
                    txtSaldocaja.Text = "";
                    txtEstadocaja.Text = "";
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
                txtIdcaja.Focus();
            }
        }
        private void btnLimpiar_Click(object sender, RoutedEventArgs e)
        {
            txtIdcaja.Text = "";
            txtNombrecaja.Text = "";
            txtSaldocaja.Text = "";
            txtEstadocaja.Text = "";
            txtBuscar.Text = "";
            btnEliminar.IsEnabled = false;
            txtIdcaja.IsEnabled = true;
            btnInsertar.IsEnabled = true;
            btnModificar.IsEnabled = false;
        }
        private void btnEliminar_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                string cadena = "delete from CLINICA1.CAJA where id_caja='" + this.txtIdcaja.Text + "';";

                OdbcCommand consulta = new OdbcCommand(cadena, cn.conexion());
                consulta.ExecuteNonQuery();

                OdbcDataReader busqueda;
                busqueda = consulta.ExecuteReader();

                MessageBox.Show("Datos Eliminados");
                while (busqueda.Read())
                {
                }
                txtIdcaja.Text = "";
                txtNombrecaja.Text = "";
                txtSaldocaja.Text = "";
                txtEstadocaja.Text = "";
                txtBuscar.Text = "";

                txtIdcaja.IsEnabled = true;
                btnInsertar.IsEnabled = true;
                btnEliminar.IsEnabled = false;
                btnModificar.IsEnabled = false;
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
                    string Query = "select * from CLINICA1.CAJA where id_caja='" + this.txtBuscar.Text + "';";

                    OdbcCommand consulta = new OdbcCommand(Query, cn.conexion());
                    consulta.ExecuteNonQuery();

                    OdbcDataReader busqueda;
                    busqueda = consulta.ExecuteReader();

                    if (busqueda.Read())
                    {
                        txtIdcaja.Text = busqueda["id_caja"].ToString();
                        txtNombrecaja.Text = busqueda["nombre_caja"].ToString();
                        txtSaldocaja.Text = busqueda["saldo_caja"].ToString();
                        txtEstadocaja.Text = busqueda["status_caja"].ToString();
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
                rbnestado();
                this.txtBuscar.Text = "";
                txtIdcaja.IsEnabled = false;
                btnInsertar.IsEnabled = false;
            }
            else
            {
                MessageBox.Show("Ingrese dato a buscar");
            }

        }

        //Funcion de Radiobutton
        private void rbnActivo_Checked(object sender, RoutedEventArgs e)
        {
            rbnActivo.IsChecked = true;
            rbnSuspendido.IsChecked = false;
            txtEstadocaja.Text = "1";
        }
        private void rbnSuspensido_Checked(object sender, RoutedEventArgs e)
        {
            {
                rbnSuspendido.IsChecked = true;
                rbnActivo.IsChecked = false;
                txtEstadocaja.Text = "0";
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
        private void txtIdcaja_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                e.Handled = true;//elimina el sonido
                txtNombrecaja.Focus();
            }
        }
        private void txtNombrecaja_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                e.Handled = true;//elimina el sonido
                txtSaldocaja.Focus();
            }
        }
        private void txtSaldocaja_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                e.Handled = true;//elimina el sonido
                rbnActivo.Focus();
            }
        }
        private void rbnActivo_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                e.Handled = true;//elimina el sonido
                rbnActivo_Checked(sender, e);

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
            else
            {
                if (e.Key == Key.Right || e.Key == Key.Left)
                {
                    e.Handled = true;//elimina el sonido
                    rbnSuspendido.Focus();
                }

            }
        }
        private void rbnSuspensido_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                e.Handled = true;//elimina el sonido
                rbnSuspensido_Checked(sender, e);

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
            else
            {
                if (e.Key == Key.Left || e.Key == Key.Right)
                {
                    e.Handled = true;//elimina el sonido
                    rbnActivo.Focus();
                }
            }
        }
    }
}
