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
    /// Lógica de interacción para wpfTipocambio.xaml
    /// </summary>
    public partial class wpfTipocambio : UserControl
    {
        Conexion cn = new Conexion();
        public wpfTipocambio()
        {
            InitializeComponent();
        }

        private void btnModificar_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                string cadena = "update CLINICA1.MONEDA set id_moneda ='" + this.txtIdmoneda.Text
                    + "',nombre_moneda ='" + this.txtNombremoneda.Text
                    + "',tipo_cambio ='" + this.txtTipocambio.Text
                    + "',status_moneda ='" + this.txtEstadomoneda.Text

                    + "'where id_moneda='" + this.txtIdmoneda.Text + "';";

                OdbcCommand consulta = new OdbcCommand(cadena, cn.conexion());
                consulta.ExecuteNonQuery();

                MessageBox.Show("Modificacion realizada");

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            txtIdmoneda.Text = "";
            txtNombremoneda.Text = "";
            txtTipocambio.Text = "";
            txtEstadomoneda.Text = "";
            txtBuscar.Text = "";

            txtIdmoneda.IsEnabled = true;
            btnInsertar.IsEnabled = true;
        }

        private void btnInsertar_Click(object sender, RoutedEventArgs e)
        {

            try
            {
                string cadena = "INSERT INTO" +
                    " CLINICA1.MONEDA (id_moneda, nombre_moneda, tipo_cambio, status_moneda) VALUES (" +
                    "'" + txtIdmoneda.Text + "', '"
                        + txtNombremoneda.Text + "', '"
                        + txtTipocambio.Text + "', '"
                        + txtEstadomoneda.Text + "' ); ";

                OdbcCommand consulta = new OdbcCommand(cadena, cn.conexion());

                consulta.ExecuteNonQuery();
                MessageBox.Show("Inserción realizada");

                txtIdmoneda.Text = "";
                txtNombremoneda.Text = "";
                txtTipocambio.Text = "";
                txtEstadomoneda.Text = "";
                txtBuscar.Text = "";

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnLimpiar_Click(object sender, RoutedEventArgs e)
        {
            txtIdmoneda.Text = "";
            txtNombremoneda.Text = "";
            txtTipocambio.Text = "";
            txtEstadomoneda.Text = "";
            txtBuscar.Text = "";

            txtIdmoneda.IsEnabled = true;
            btnInsertar.IsEnabled = true;
        }

        private void btnEliminar_Click(object sender, RoutedEventArgs e)
        {
            try
            {

                string cadena = "delete from CLINICA1.MONEDA where id_moneda='" + this.txtIdmoneda.Text + "';";


                OdbcCommand consulta = new OdbcCommand(cadena, cn.conexion());
                consulta.ExecuteNonQuery();

                OdbcDataReader busqueda;
                busqueda = consulta.ExecuteReader();

                MessageBox.Show("Datos Eliminados");
                while (busqueda.Read())
                {
                }
                txtIdmoneda.Text = "";
                txtNombremoneda.Text = "";
                txtTipocambio.Text = "";
                txtEstadomoneda.Text = "";
                txtBuscar.Text = "";

                txtIdmoneda.IsEnabled = true;
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
                string Query = "select * from CLINICA1.MONEDA where id_moneda='" + this.txtBuscar.Text + "';";

                OdbcCommand consulta = new OdbcCommand(Query, cn.conexion());
                consulta.ExecuteNonQuery();

                OdbcDataReader busqueda;
                busqueda = consulta.ExecuteReader();

                if (busqueda.Read())
                {
                    txtIdmoneda.Text = busqueda["id_moneda"].ToString();
                    txtNombremoneda.Text = busqueda["nombre_moneda"].ToString();
                    txtTipocambio.Text = busqueda["tipo_cambio"].ToString();
                    txtEstadomoneda.Text = busqueda["status_moneda"].ToString();

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

            txtIdmoneda.IsEnabled = false;
            btnInsertar.IsEnabled = false;
        }
    }
}
