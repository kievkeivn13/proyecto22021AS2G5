
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

    public partial class Formas_pago : UserControl
    {
        Conexion cn = new Conexion();
        public Formas_pago()
        {
            InitializeComponent();
        }

        private void btnInsertar_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                string cadena = "INSERT INTO" +
                " FORMAS_PAGO (id_forma_pago, nombre_forma_pago, status_forma_pago) VALUES (" +
                "'" + txtId_forma_pago.Text + "', '"
                 + txtNombre_forma_pago.Text + "', '"
                 + txtStatus.Text + "' ); ";

                OdbcCommand consulta = new OdbcCommand(cadena, cn.conexion());
                consulta.ExecuteNonQuery();
                MessageBox.Show("Inserción realizada");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }


            txtId_forma_pago.Text = "";
            txtNombre_forma_pago.Text = "";
            txtStatus.Text = "";
        }

        private void btnModificar_Click(object sender, RoutedEventArgs e)
        {            
            try
            {                
                string cadena = "update CLINICA1.FORMAS_PAGO set id_forma_pago ='" + this.txtId_forma_pago.Text
                    + "',nombre_forma_pago ='" + this.txtNombre_forma_pago.Text
                    + "',status_forma_pago ='" + this.txtStatus.Text
                    + "'where id_forma_pago='" + this.txtId_forma_pago.Text + "';";


                OdbcCommand consulta = new OdbcCommand(cadena, cn.conexion());
                consulta.ExecuteNonQuery();

                MessageBox.Show("Modificacion realizada");

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            txtId_forma_pago.Text = "";
            txtNombre_forma_pago.Text = "";
            txtStatus.Text = "";

            txtId_forma_pago.IsEnabled = true;
            btnInsertar.IsEnabled = true;
        }

        private void btnBuscar_Click(object sender, RoutedEventArgs e)
        {
            if (txtBuscar.Text != "")
            {
                try
                {
                    string Query = "select * from CLINICA1.FORMAS_PAGO where id_forma_pago='" + this.txtBuscar.Text + "';";


                    OdbcCommand consulta = new OdbcCommand(Query, cn.conexion());
                    consulta.ExecuteNonQuery();

                    OdbcDataReader busqueda;
                    busqueda = consulta.ExecuteReader();

                    if (busqueda.Read())
                    {
                        txtId_forma_pago.Text = busqueda["id_forma_pago"].ToString();
                        txtNombre_forma_pago.Text = busqueda["nombre_forma_pago"].ToString();
                        txtStatus.Text = busqueda["status_forma_pago"].ToString();
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

                txtId_forma_pago.IsEnabled = false;
                btnInsertar.IsEnabled = false;
            }
            else
            {
                MessageBox.Show("Ingrese dato a buscar");
            }
        }

        private void btnLimpiar_Click(object sender, RoutedEventArgs e)
        {
            txtId_forma_pago.Text = "";
            txtNombre_forma_pago.Text = "";
            txtStatus.Text = "";

            txtId_forma_pago.IsEnabled = true;
            btnInsertar.IsEnabled = true;
        }

        private void btnEliminar_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                string cadena = "delete from CLINICA1.FORMAS_PAGO where nombre_forma_pago='" + this.txtId_forma_pago.Text + "';";

                OdbcCommand consulta = new OdbcCommand(cadena, cn.conexion());
                consulta.ExecuteNonQuery();

                OdbcDataReader busqueda;
                busqueda = consulta.ExecuteReader();

                MessageBox.Show("Datos Eliminados");
                while (busqueda.Read())
                {
                }

                txtId_forma_pago.Text = "";
                txtNombre_forma_pago.Text = "";
                txtStatus.Text = "";

                txtId_forma_pago.IsEnabled = true;
                btnInsertar.IsEnabled = true;
            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}