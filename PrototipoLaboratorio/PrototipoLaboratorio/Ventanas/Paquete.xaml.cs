
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
    public partial class Paquete : UserControl
    {
        Conexion cn = new Conexion();

        public Paquete()
        {
            InitializeComponent();
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
                " status_empleado, id_puesto, colegiado_empleado) VALUES (" +
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
                 + txtIdPuesto.Text + "', '"
                 + txtColegiado.Text + "' ); ";

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
            txtIdPuesto.Text = "";
            txtColegiado.Text = "";
        }

        private void btnModificar_Click(object sender, RoutedEventArgs e)
        {
            //string p = this.txtIdEmpleado.Text.Trim();


            try
            {
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
                    + "',id_puesto='" + this.txtIdPuesto.Text
                    + "',colegiado_empleado='" + this.txtColegiado.Text

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
            txtIdPuesto.Text = "";
            txtColegiado.Text = "";

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
                        txtIdPuesto.Text = busqueda["id_puesto"].ToString();
                        txtColegiado.Text = busqueda["colegiado_empleado"].ToString();
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
            txtIdPuesto.Text = "";
            txtColegiado.Text = "";

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
                txtIdPuesto.Text = "";
                txtColegiado.Text = "";

                txtIdEmpleado.IsEnabled = true;
                btnInsertar.IsEnabled = true;
            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}