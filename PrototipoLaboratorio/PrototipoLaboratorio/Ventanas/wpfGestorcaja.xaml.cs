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
    /// Lógica de interacción para wpfGestorcaja.xaml
    /// </summary>
    public partial class wpfGestorcaja : UserControl
    {
        Conexion cn = new Conexion();
        public wpfGestorcaja()
        {
            InitializeComponent();
        }

        private void btnModificar_Click(object sender, RoutedEventArgs e)
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
        }

        private void btnInsertar_Click(object sender, RoutedEventArgs e)
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

        private void btnLimpiar_Click(object sender, RoutedEventArgs e)
        {
            txtIdcaja.Text = "";
            txtNombrecaja.Text = "";
            txtSaldocaja.Text = "";
            txtEstadocaja.Text = "";
            txtBuscar.Text = "";

            txtIdcaja.IsEnabled = true;
            btnInsertar.IsEnabled = true;
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

            txtIdcaja.IsEnabled = false;
            btnInsertar.IsEnabled = false;
        }
    }
}
