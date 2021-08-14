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
    /// Lógica de interacción para wpfPuestos.xaml
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
            try
            {
                string cadena = "INSERT INTO" +
                " PUESTOS (id_puesto, nombre_puesto, status_puesto) VALUES (" + "'" + txtIdPuesto.Text + "', '"+ txtNombrePuesto.Text + txtEstatusPuesto.Text + "' ); ";

                OdbcCommand consulta = new OdbcCommand(cadena, cn.conexion());
                consulta.ExecuteNonQuery();
                MessageBox.Show("Inserción realizada");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            txtIdPuesto.Text = "";
            txtNombrePuesto.Text = "";
            txtEstatusPuesto.Text = "";
        }

        private void btnModificar_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                string cadena = "update CLINICA1.PUESTOS set id_puesto ='" + this.txtIdPuesto.Text
                    + "',nombre_puesto ='" + this.txtNombrePuesto.Text + "',status_puesto ='" + this.txtEstatusPuesto.Text + "';";


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
            txtEstatusPuesto.Text = "";

        }

        private void btnLimpiar_Click(object sender, RoutedEventArgs e)
        {
            txtIdPuesto.Text = "";
            txtNombrePuesto.Text = "";
            txtEstatusPuesto.Text = "";
        }

        private void btnBuscar_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                
                string Query = "select * from CLINICA1.PUESTOS where id_puesto='" + this.txtBuscar.Text + "';";
               
                OdbcCommand consulta = new OdbcCommand(Query, cn.conexion());
                consulta.ExecuteNonQuery();

                OdbcDataReader busqueda;
                busqueda = consulta.ExecuteReader();

                if (busqueda.Read())
                {
                    txtIdPuesto.Text = busqueda["id_puesto"].ToString();
                    txtNombrePuesto.Text = busqueda["nombre_puesto"].ToString();
                    txtEstatusPuesto.Text = busqueda["status_puesto"].ToString();

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
        }

        private void btnEliminar_Click(object sender, RoutedEventArgs e)
        {

            try { 
            string cadena = "delete from CLINICA1.PUESTOS where id_puesto='" + this.txtIdPuesto.Text + "';";
            
            OdbcCommand consulta = new OdbcCommand(cadena, cn.conexion());
            consulta.ExecuteNonQuery();

            OdbcDataReader busqueda;
            busqueda = consulta.ExecuteReader();

            MessageBox.Show("Datos Eliminados");
            while (busqueda.Read())
            {
            }
                txtIdPuesto.Text = "";
                txtNombrePuesto.Text = "";
                txtEstatusPuesto.Text = "";
            }   

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
