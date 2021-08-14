using MySql.Data.MySqlClient;
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
    /// Lógica de interacción para wpfEmpleados.xaml
    /// </summary>
    public partial class wpfEmpleados : UserControl
    {
        Conexion cn = new Conexion();
       
        public wpfEmpleados()
        {
            InitializeComponent();
            cargarCbxPuesto();
            cargarCbxSede();
        }

        private void btnInsertar_Click(object sender, RoutedEventArgs e)
        {
            
            /*
             (id_empleado, cui_empleado, nit_empleado, nombre_empleado, apellido_empleado," +
                " genero_empleado, edad_empleado, telefono_empleado, direccion_empleado, email_empleado," +
                " status_empleado, id_puesto, colegiado_empleado) 
             */

            string cadena = "INSERT INTO" +
                " empleado (id_empleado, cui_empleado, nit_empleado, nombre_empleado, apellido_empleado," +
                " genero_empleado, edad_empleado, telefono_empleado, direccion_empleado, email_empleado," +
                " status_empleado, id_puesto, colegiado_empleado, id_sede) VALUES (" +
                "'" + txtIdEmpleado.Text + "', '"
                 + txtCui.Text + "', '"
                 + txtNit.Text + "', '"
                 + txtNombre.Text + "', '"
                 + txtApellido.Text + "', '"
                 + txtGenero.Text + "', "
                 + int.Parse(txtEdad.Text) + " , '"
                 + txtTelefono.Text + "', '"
                 + txtDireccion.Text + "', '"
                 + txtEmail.Text + "', '"
                 + txtStatus.Text + "', '"
                 + lblIdPuesto.Content + "', '"
                 + txtColegiado.Text + "', '"
                 + lblIdSede.Content + "' ); ";

            OdbcCommand consulta = new OdbcCommand(cadena, cn.conexion());
            consulta.ExecuteNonQuery();
            MessageBox.Show("Inserción realizada");

            
            txtIdEmpleado.Text = "";
            txtCui.Text = "";
            txtNit.Text = "";
            txtNombre.Text = "";
            txtApellido.Text = "";
            txtGenero.Text = "";
            txtEdad.Text = "";
            txtTelefono.Text = "";
            txtDireccion.Text = "";
            txtEmail.Text = "";
            txtStatus.Text = "";
            lblIdSede.Content = "-";
            lblIdPuesto.Content = "-";
            cbxSede.Items.Clear();
            cbxPuesto.Items.Clear();
            txtColegiado.Text = "";
        }

        private void btnModificar_Click(object sender, RoutedEventArgs e)
        {
            //string p = this.txtIdEmpleado.Text.Trim();
            
            
                try
                {
                cargarCbxPuesto();
                    //string MyConnection2 = "datasource=localhost;port=3306;username=root;password=6182";
                    string cadena = "update CLINICA1.EMPLEADO set id_empleado ='" + this.txtIdEmpleado.Text
                        + "',cui_empleado ='" + this.txtCui.Text
                        + "',nit_empleado='" + this.txtNit.Text
                        + "',nombre_empleado='" + this.txtNombre.Text
                        + "',apellido_empleado='" + this.txtApellido.Text
                        + "',genero_empleado='" + this.txtGenero.Text
                        + "',edad_empleado='" + this.txtEdad.Text
                        + "',telefono_empleado='" + this.txtTelefono.Text
                        + "',direccion_empleado='" + this.txtDireccion.Text
                        + "',email_empleado='" + this.txtEmail.Text
                        + "',status_empleado='" + this.txtStatus.Text
                        + "',id_puesto='" + this.lblIdPuesto.Content
                        + "',colegiado_empleado='" + this.txtColegiado.Text
                        + "',id_sede='" + lblIdSede.Content 

                        + "'where id_empleado='" + this.txtIdEmpleado.Text + "';";


                    OdbcCommand consulta = new OdbcCommand(cadena, cn.conexion());
                    consulta.ExecuteNonQuery();

                    MessageBox.Show("Modificacion realizada");

                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }

            txtIdEmpleado.Text = "";
            txtCui.Text = "";
            txtNit.Text = "";
            txtNombre.Text = "";
            txtApellido.Text = "";
            txtGenero.Text = "";
            txtEdad.Text = "";
            txtTelefono.Text = "";
            txtDireccion.Text = "";
            txtEmail.Text = "";
            txtStatus.Text = "";
            cbxPuesto.Items.Clear();
            txtColegiado.Text = "";
            cbxSede.Items.Clear();
            lblIdSede.Content = "-";
            lblIdPuesto.Content = "-";
            txtIdEmpleado.IsEnabled = true;
            btnInsertar.IsEnabled = true;
        }

        private void btnBuscar_Click(object sender, RoutedEventArgs e)
        {
            if (txtBuscar.Text != "")
            {

                try
                {

                    string Query = "select * from CLINICA1.EMPLEADO where id_empleado='" + this.txtBuscar.Text + "';";


                    OdbcCommand consulta = new OdbcCommand(Query, cn.conexion());
                    consulta.ExecuteNonQuery();

                    OdbcDataReader busqueda;
                    busqueda = consulta.ExecuteReader();

                    if (busqueda.Read())
                    {
                        txtIdEmpleado.Text = busqueda["id_empleado"].ToString();
                        txtCui.Text = busqueda["cui_empleado"].ToString();
                        txtNit.Text = busqueda["nit_empleado"].ToString();
                        txtNombre.Text = busqueda["nombre_empleado"].ToString();
                        txtApellido.Text = busqueda["apellido_empleado"].ToString();
                        txtGenero.Text = busqueda["genero_empleado"].ToString();
                        txtEdad.Text = busqueda["edad_empleado"].ToString();
                        txtTelefono.Text = busqueda["telefono_empleado"].ToString();
                        txtDireccion.Text = busqueda["direccion_empleado"].ToString();
                        txtEmail.Text = busqueda["email_empleado"].ToString();
                        txtStatus.Text = busqueda["status_empleado"].ToString();
                        lblIdPuesto.Content = busqueda["id_puesto"].ToString();
                        txtColegiado.Text = busqueda["colegiado_empleado"].ToString();
                        lblIdSede.Content = busqueda["id_sede"].ToString();
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

                txtIdEmpleado.IsEnabled = false;
                btnInsertar.IsEnabled = false;
            }
            else
            {
                MessageBox.Show("Ingrese dato a buscar");
            }
        }

        private void btnLimpiar_Click(object sender, RoutedEventArgs e)
        {
            txtIdEmpleado.Text = "";
            txtCui.Text = "";
            txtNit.Text = "";
            txtNombre.Text = "";
            txtApellido.Text = "";
            txtGenero.Text = "";
            txtEdad.Text = "";
            txtTelefono.Text = "";
            txtDireccion.Text = "";
            txtEmail.Text = "";
            txtStatus.Text = "";
            cbxPuesto.Items.Clear();
            txtColegiado.Text = "";
            cbxSede.Items.Clear();
            lblIdSede.Content = "-";
            lblIdPuesto.Content = "-";
            txtIdEmpleado.IsEnabled = true;
            btnInsertar.IsEnabled = true;
        }

        private void btnEliminar_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                
                string cadena = "delete from CLINICA1.EMPLEADO where id_empleado='" + this.txtIdEmpleado.Text + "';";
                

                OdbcCommand consulta = new OdbcCommand(cadena, cn.conexion());
                consulta.ExecuteNonQuery();

                OdbcDataReader busqueda;
                busqueda = consulta.ExecuteReader();

                MessageBox.Show("Datos Eliminados");
                while (busqueda.Read())
                {
                }
                

                txtIdEmpleado.Text = "";
                txtCui.Text = "";
                txtNit.Text = "";
                txtNombre.Text = "";
                txtApellido.Text = "";
                txtGenero.Text = "";
                txtEdad.Text = "";
                txtTelefono.Text = "";
                txtDireccion.Text = "";
                txtEmail.Text = "";
                txtStatus.Text = "";
                cbxPuesto.Items.Clear();
                txtColegiado.Text = "";
                cbxSede.Items.Clear();
                lblIdSede.Content = "-";
                lblIdPuesto.Content = "-";
                txtIdEmpleado.IsEnabled = true;
                btnInsertar.IsEnabled = true;
            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        void cargarCbxPuesto()
        {

            string cadena = "SELECT nombre_puesto FROM PUESTO";

            OdbcCommand consulta = new OdbcCommand(cadena, cn.conexion());
            consulta.ExecuteNonQuery();

            OdbcDataReader busqueda;
            busqueda = consulta.ExecuteReader();

            cbxPuesto.Items.Clear();
            while (busqueda.Read())
            {
                cbxPuesto.Items.Add(busqueda["nombre_puesto"].ToString());
            }


        }

        private void cbxPuesto_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            string cadena = "SELECT id_puesto FROM PUESTO WHERE nombre_puesto = '" + cbxPuesto.SelectedItem + "';";

            OdbcCommand consulta = new OdbcCommand(cadena, cn.conexion());
            consulta.ExecuteNonQuery();

            OdbcDataReader busqueda;
            busqueda = consulta.ExecuteReader();

            while (busqueda.Read())
            {
                lblIdPuesto.Content = busqueda["id_puesto"].ToString();
            }
        }

        /*COMBO BOX SEDE*/
        void cargarCbxSede()
        {

            string cadena = "SELECT nombre_sede FROM SEDE";

            OdbcCommand consulta = new OdbcCommand(cadena, cn.conexion());
            consulta.ExecuteNonQuery();

            OdbcDataReader busqueda;
            busqueda = consulta.ExecuteReader();

            cbxSede.Items.Clear();
            while (busqueda.Read())
            {
                cbxSede.Items.Add(busqueda["nombre_sede"].ToString());
            }


        }

        private void cbxSede_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            string cadena = "SELECT id_sede FROM SEDE WHERE nombre_sede = '" + cbxSede.SelectedItem + "';";

            OdbcCommand consulta = new OdbcCommand(cadena, cn.conexion());
            consulta.ExecuteNonQuery();

            OdbcDataReader busqueda;
            busqueda = consulta.ExecuteReader();

            while (busqueda.Read())
            {
                lblIdSede.Content = busqueda["id_sede"].ToString();
            }
        }
    }
}