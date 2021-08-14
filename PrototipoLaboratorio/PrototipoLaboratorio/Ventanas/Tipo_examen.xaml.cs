
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

    public partial class Tipo_examen : UserControl
    {
        Conexion cn = new Conexion();
        public Tipo_examen()
        {
            InitializeComponent();
        }

        private void btnInsertar_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                string cadena = "INSERT INTO" +
                " TIPO_EXAMEN (id_tipo_examen, nombre_tipo_examen) VALUES (" +
                "'" + txtIdTipo_examen.Text + "', '"
                 + txtTipo_examen.Text + "' ); ";

                OdbcCommand consulta = new OdbcCommand(cadena, cn.conexion());
                consulta.ExecuteNonQuery();
                MessageBox.Show("Inserción realizada");

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            txtIdTipo_examen.Text = "";
            txtTipo_examen.Text = "";
        }

        private void btnModificar_Click(object sender, RoutedEventArgs e)
        {
            //string p = this.txtIdTipo_examen.Text.Trim();


            try
            {                
                string cadena = "update CLINICA1.TIPO_EXAMEN set id_tipo_examen ='" + this.txtIdTipo_examen.Text
                    + "',nombre_tipo_examen ='" + this.txtTipo_examen.Text

                    + "'where id_tipo_examen='" + this.txtIdTipo_examen.Text + "';";

                OdbcCommand consulta = new OdbcCommand(cadena, cn.conexion());
                consulta.ExecuteNonQuery();

                MessageBox.Show("Modificacion realizada");

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            txtIdTipo_examen.Text = "";
            txtTipo_examen.Text = "";

            txtIdTipo_examen.IsEnabled = true;
            btnInsertar.IsEnabled = true;
        }

        private void btnBuscar_Click(object sender, RoutedEventArgs e)
        {
            if (txtBuscar.Text != "")
            {
                try
                {
                    string Query = "select * from CLINICA1.TIPO_EXAMEN where id_tipo_examen='" + this.txtBuscar.Text + "';";

                    OdbcCommand consulta = new OdbcCommand(Query, cn.conexion());
                    consulta.ExecuteNonQuery();

                    OdbcDataReader busqueda;
                    busqueda = consulta.ExecuteReader();

                    if (busqueda.Read())
                    {
                        txtIdTipo_examen.Text = busqueda["id_tipo_examen"].ToString();
                        txtTipo_examen.Text = busqueda["nombre_tipo_examen"].ToString();
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

                txtIdTipo_examen.IsEnabled = false;
                btnInsertar.IsEnabled = false;
            }
            else
            {
                MessageBox.Show("Ingrese dato a buscar");
            }
        }

        private void btnLimpiar_Click(object sender, RoutedEventArgs e)
        {
            txtIdTipo_examen.Text = "";
            txtTipo_examen.Text = "";

            txtIdTipo_examen.IsEnabled = true;
            btnInsertar.IsEnabled = true;
        }

        private void btnEliminar_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                string cadena = "delete from CLINICA1.TIPO_EXAMEN where nombre_tipo_examen='" + this.txtIdTipo_examen.Text + "';";

                OdbcCommand consulta = new OdbcCommand(cadena, cn.conexion());
                consulta.ExecuteNonQuery();

                OdbcDataReader busqueda;
                busqueda = consulta.ExecuteReader();

                MessageBox.Show("Datos Eliminados");
                while (busqueda.Read())
                {
                }

                txtIdTipo_examen.Text = "";
                txtTipo_examen.Text = "";

                txtIdTipo_examen.IsEnabled = true;
                btnInsertar.IsEnabled = true;
            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}