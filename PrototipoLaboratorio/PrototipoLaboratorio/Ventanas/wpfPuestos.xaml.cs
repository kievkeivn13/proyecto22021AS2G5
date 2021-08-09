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
    public partial class wpfPuestos : UserControl
    {
        Conexion cn = new Conexion();
        public wpfPuestos()
        {
            InitializeComponent();
        }

        private void btnInsertar_Click(object sender, RoutedEventArgs e)
        {
            string cadena = "INSERT INTO" +
                " PUESTOS (pk_id_puesto, puesto_puesto) VALUES (" + "'" + txtIdPuesto.Text + "', '"+ txtNombrePuesto.Text + "' ); ";

            OdbcCommand consulta = new OdbcCommand(cadena, cn.conexion());
            consulta.ExecuteNonQuery();
            MessageBox.Show("Inserción realizada");


            txtIdPuesto.Text = "";
            txtNombrePuesto.Text = "";
        }

        private void btnModificar_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                //string MyConnection2 = "datasource=localhost;port=3306;username=root;password=6182";
                string cadena = "update CLINICA.PUESTOS set pk_id_puesto ='" + this.txtIdPuesto.Text
                    + "',puesto_puesto ='" + this.txtNombrePuesto.Text + "';";


                OdbcCommand consulta = new OdbcCommand(cadena, cn.conexion());
                consulta.ExecuteNonQuery();

                MessageBox.Show("Modificacion realizada");

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            txtIdPuesto.Text = "";
            txtNombrePuesto.Text = "";

        }

        private void btnLimpiar_Click(object sender, RoutedEventArgs e)
        {
            txtIdPuesto.Text = "";
            txtNombrePuesto.Text = "";
        }

        private void btnBuscar_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                
                string Query = "select * from CLINICA.PUESTOS where pk_id_puesto='" + this.txtBuscar.Text + "';";
                

                OdbcCommand consulta = new OdbcCommand(Query, cn.conexion());
                consulta.ExecuteNonQuery();

                OdbcDataReader busqueda;
                busqueda = consulta.ExecuteReader();

                if (busqueda.Read())
                {
                    txtIdPuesto.Text = busqueda["id_puesto"].ToString();
                    txtNombrePuesto.Text = busqueda["puesto_puesto"].ToString();
                    
                }
                else
                {
                    MessageBox.Show("Registro no encontrado");
                }
                //MyConn2.Close();
                this.txtBuscar.Text = "";
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnEliminar_Click(object sender, RoutedEventArgs e)
        {

            try { 
            string cadena = "delete from CLINICA.PUESTOS where pk_id_puesto='" + this.txtIdPuesto.Text + "';";
            
            OdbcCommand consulta = new OdbcCommand(cadena, cn.conexion());
            consulta.ExecuteNonQuery();

            OdbcDataReader busqueda;
            busqueda = consulta.ExecuteReader();

            MessageBox.Show("Datos Eliminados");
            while (busqueda.Read())
            {
            }
                //MyConn2.Close();

                txtIdPuesto.Text = "";
                txtNombrePuesto.Text = "";

            }   

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
