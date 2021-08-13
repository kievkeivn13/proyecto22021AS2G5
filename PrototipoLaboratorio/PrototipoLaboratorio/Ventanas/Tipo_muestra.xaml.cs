
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

    public partial class Tipo_muestra : UserControl
    {
        Conexion cn = new Conexion();

        public Tipo_muestra()
        {
            InitializeComponent();
        }

        private void btnInsertar_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                string cadena = "INSERT INTO" +
                " TIPO_MUESTRA (id_tipo_muestra, nombre_tipo_muestra) VALUES (" +
                "'" + txtIdTipo_muestra.Text + "', '"
                 + txtTipo_muestra.Text + "' ); ";

                OdbcCommand consulta = new OdbcCommand(cadena, cn.conexion());
                consulta.ExecuteNonQuery();
                MessageBox.Show("Inserción realizada");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            txtIdTipo_muestra.Text = "";
            txtTipo_muestra.Text = "";
        }

        private void btnModificar_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                string cadena = "update CLINICA1.TIPO_MUESTRA set id_tipo_muestra ='" + this.txtIdTipo_muestra.Text
                    + "',nombre_tipo_muestra ='" + this.txtTipo_muestra.Text

                    + "'where id_tipo_muestra='" + this.txtIdTipo_muestra.Text + "';";

                OdbcCommand consulta = new OdbcCommand(cadena, cn.conexion());
                consulta.ExecuteNonQuery();

                MessageBox.Show("Modificacion realizada");

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            txtIdTipo_muestra.Text = "";
            txtTipo_muestra.Text = "";

            txtIdTipo_muestra.IsEnabled = true;
            btnInsertar.IsEnabled = true;
        }

        private void btnBuscar_Click(object sender, RoutedEventArgs e)
        {
            if (txtBuscar.Text != "")
            {
                try
                {
                    string Query = "select * from CLINICA1.TIPO_MUESTRA where id_tipo_muestra='" + this.txtBuscar.Text + "';";

                    OdbcCommand consulta = new OdbcCommand(Query, cn.conexion());
                    consulta.ExecuteNonQuery();

                    OdbcDataReader busqueda;
                    busqueda = consulta.ExecuteReader();

                    if (busqueda.Read())
                    {
                        txtIdTipo_muestra.Text = busqueda["id_tipo_muestra"].ToString();
                        txtTipo_muestra.Text = busqueda["nombre_tipo_muestra"].ToString();
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

                txtIdTipo_muestra.IsEnabled = false;
                btnInsertar.IsEnabled = false;
            }
            else
            {
                MessageBox.Show("Ingrese dato a buscar");
            }
        }

        private void btnLimpiar_Click(object sender, RoutedEventArgs e)
        {
            txtIdTipo_muestra.Text = "";
            txtTipo_muestra.Text = "";

            txtIdTipo_muestra.IsEnabled = true;
            btnInsertar.IsEnabled = true;
        }

        private void btnEliminar_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                string cadena = "delete from CLINICA1.TIPO_MUESTRA where nombre_tipo_muestra='" + this.txtIdTipo_muestra.Text + "';";

                OdbcCommand consulta = new OdbcCommand(cadena, cn.conexion());
                consulta.ExecuteNonQuery();

                OdbcDataReader busqueda;
                busqueda = consulta.ExecuteReader();

                MessageBox.Show("Datos Eliminados");
                while (busqueda.Read())
                {
                }

                txtIdTipo_muestra.Text = "";
                txtTipo_muestra.Text = "";

                txtIdTipo_muestra.IsEnabled = true;
                btnInsertar.IsEnabled = true;
            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}