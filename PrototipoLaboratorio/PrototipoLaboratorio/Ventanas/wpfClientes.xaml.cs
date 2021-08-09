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
    /// Lógica de interacción para wpfClientes.xaml
    /// </summary>
    public partial class wpfClientes : UserControl
    {
        Conexion cn = new Conexion();
        public wpfClientes()
        {
            InitializeComponent();
        }

        private void btnInsertar_Click(object sender, RoutedEventArgs e)
        {
            string cadena = "INSERT INTO" +
                " CLIENTES (pk_id_cliente,nombre_cliente,apellido_cliente,birthday_cliente,edad_cliente) VALUES (" + "'" + txtIdCliente.Text + "', '"+ txtNombreCliente.Text + txtApellidoCliente.Text + dpFecha.Text + txtEdadCliente.Text + "' ); ";

            OdbcCommand consulta = new OdbcCommand(cadena, cn.conexion());
            consulta.ExecuteNonQuery();
            MessageBox.Show("Inserción realizada");


            txtIdCliente.Text = "";
            txtNombreCliente.Text = "";
            txtApellidoCliente.Text = "";
            dpFecha.Text = "";
            txtEdadCliente.Text = "";
        }

        private void btnModificar_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                //string MyConnection2 = "datasource=localhost;port=3306;username=root;password=6182";
                string cadena = "update CLINICA.CLIENTES pk_id_cliente='" + this.txtIdCliente.Text + "',nombre_cliente='" + this.txtNombreCliente.Text + "',apellido_cliente='" + this.txtApellidoCliente.Text + "',birthday_cliente='" + this.dpFecha.Text + "',edad_cliente='" + 
                    this.txtEdadCliente.Text + "'where pk_id_cliente='" + this.txtIdCliente.Text + "';";


                OdbcCommand consulta = new OdbcCommand(cadena, cn.conexion());
                consulta.ExecuteNonQuery();

                MessageBox.Show("Modificacion realizada");

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            txtIdCliente.Text = "";
            txtNombreCliente.Text = "";
            txtApellidoCliente.Text = "";
            dpFecha.Text = "";
            txtEdadCliente.Text = "";

        }

        private void btnLimpiar_Click(object sender, RoutedEventArgs e)
        {
            txtIdCliente.Text = "";
            txtNombreCliente.Text = "";
            txtApellidoCliente.Text = "";
            dpFecha.Text = "";
            txtEdadCliente.Text = "";
        }

        private void btnBuscar_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                
                string Query = "select * from CLINICA.CLIENTES where pk_id_cliente='" + this.txtBuscar.Text + "';";


                OdbcCommand consulta = new OdbcCommand(Query, cn.conexion());
                consulta.ExecuteNonQuery();

                OdbcDataReader busqueda;
                busqueda = consulta.ExecuteReader();

                if (busqueda.Read())
                {
                    txtIdCliente.Text = busqueda["pk_id_cliente"].ToString();
                    txtNombreCliente.Text = busqueda["nombre_cliente"].ToString();
                    txtApellidoCliente.Text = busqueda["apellido_cliente"].ToString();
                    dpFecha.Text = busqueda["birthday_cliente"].ToString();
                    txtEdadCliente.Text = busqueda["edad_cliente"].ToString();

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
            string cadena = "delete from CLINICA.CLIENTES where pk_id_cliente='" + this.txtIdCliente.Text + "';";

                OdbcCommand consulta = new OdbcCommand(cadena, cn.conexion());
            consulta.ExecuteNonQuery();

            OdbcDataReader busqueda;
            busqueda = consulta.ExecuteReader();

            MessageBox.Show("Datos Eliminados");
            while (busqueda.Read())
            {
            }
                //MyConn2.Close();

                txtIdCliente.Text = "";
                txtNombreCliente.Text = "";
                txtApellidoCliente.Text = "";
                dpFecha.Text = "";
                txtEdadCliente.Text = "";

            }   

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void seleccionar(object sender, DependencyPropertyChangedEventArgs e)
        {
           
        }

        private void btnCalcular_Click(object sender, RoutedEventArgs e)
        {
            DateTime fecha = dpFecha.SelectedDate.Value;
            int edad = DateTime.Today.AddTicks(-fecha.Ticks).Year - 1;
            this.txtEdadCliente.Text = edad.ToString();
        }
    }
}
