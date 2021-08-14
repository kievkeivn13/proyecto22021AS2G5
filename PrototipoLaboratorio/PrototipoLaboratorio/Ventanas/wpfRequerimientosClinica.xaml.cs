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
    /// Lógica de interacción para wpfRequerimientosClinica.xaml
    /// </summary>
    public partial class wpfRequerimientosClinica : UserControl
    {
        Conexion cn = new Conexion();
        public wpfRequerimientosClinica()
        {
            InitializeComponent();
        }

        private void btnInsertar_Click(object sender, RoutedEventArgs e)
        {
            string cadena = "INSERT INTO" +
                " requerimientos_clinicos (id_requerimiento_clinico, descripcion_requerimiento_clinico, cantidad) VALUES (" + "'" + txtIdRequerimiento.Text + "', '"+ txtDescripcion.Text + "', '" + txtCantidad.Text + "' ); ";

            OdbcCommand consulta = new OdbcCommand(cadena, cn.conexion());
            consulta.ExecuteNonQuery();
            MessageBox.Show("Inserción realizada");


            txtIdRequerimiento.Text = "";
            txtDescripcion.Text = "";
            txtCantidad.Text = "";
        }

        private void btnModificar_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                
                string cadena = "update CLINICA1.REQUERIMIENTOS_CLINICOS set id_requerimiento_clinico ='" + this.txtIdRequerimiento.Text
                    + "',descripcion_requerimiento_clinico ='" + this.txtDescripcion.Text + "',cantidad ='" + this.txtCantidad.Text  + "';";


                OdbcCommand consulta = new OdbcCommand(cadena, cn.conexion());
                consulta.ExecuteNonQuery();

                MessageBox.Show("Modificacion realizada");

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            txtIdRequerimiento.Text = "";
            txtDescripcion.Text = "";
            txtCantidad.Text = "";
            txtIdRequerimiento.IsEnabled = true;
            btnInsertar.IsEnabled = true;

        }

        private void btnLimpiar_Click(object sender, RoutedEventArgs e)
        {
            txtIdRequerimiento.Text = "";
            txtDescripcion.Text = "";
            txtCantidad.Text = "";
        }

        private void btnBuscar_Click(object sender, RoutedEventArgs e)
        {
            if (txtBuscar.Text != "")
            {
                try
                {

                    string Query = "select * from CLINICA1.REQUERIMIENTOS_CLINICOS where id_requerimiento_clinico='" + this.txtBuscar.Text + "';";


                    OdbcCommand consulta = new OdbcCommand(Query, cn.conexion());
                    consulta.ExecuteNonQuery();

                    OdbcDataReader busqueda;
                    busqueda = consulta.ExecuteReader();

                    if (busqueda.Read())
                    {
                        txtIdRequerimiento.Text = busqueda["id_requerimiento_clinico"].ToString();
                        txtDescripcion.Text = busqueda["descripcion_requerimiento_clinico"].ToString();
                        txtCantidad.Text = busqueda["cantidad"].ToString();
                    }
                    else
                    {
                        MessageBox.Show("Registro no encontrado");
                    }

                    this.txtBuscar.Text = "";

                    txtIdRequerimiento.IsEnabled = false;
                    btnInsertar.IsEnabled = false;
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
            else
            {
                MessageBox.Show("Ingrese dato a buscar");
            }
        }

        private void btnEliminar_Click(object sender, RoutedEventArgs e)
        {

            try { 
            string cadena = "delete from CLINICA1.REQUERIMIENTOS_CLINICOS where id_requerimiento_clinico='" + this.txtIdRequerimiento.Text + "';";
            
            OdbcCommand consulta = new OdbcCommand(cadena, cn.conexion());
            consulta.ExecuteNonQuery();

            OdbcDataReader busqueda;
            busqueda = consulta.ExecuteReader();

            MessageBox.Show("Datos Eliminados");
            while (busqueda.Read())
            {
            }
            //MyConn2.Close();

            txtIdRequerimiento.Text = "";
            txtDescripcion.Text = "";
            txtCantidad.Text = "";
            txtIdRequerimiento.IsEnabled = true;
            btnInsertar.IsEnabled = true;
            }   

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

 
    }
}
