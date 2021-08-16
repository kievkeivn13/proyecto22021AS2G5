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
    /// Lógica de interacción para wpfPacientes.xaml
    /// </summary>
    public partial class wpfPacientes : UserControl
    {
        Conexion cn = new Conexion();
       
        public wpfPacientes()
        {
            InitializeComponent();
        }

        private void btnInsertar_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                string cadena = "INSERT INTO" +
                " PACIENTE (id_paciente, cui_paciente, nit_paciente, nombre_paciente, apellido_paciente," +
                " genero_paciente, edad_paciente, telefono_paciente, direccion_paciente, email_paciente," +
                " status_paciente, seguro_paciente) VALUES (" +
                "'" + txtIdPaciente.Text + "', '"
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
                 
                 + txtSeguro.Text + "' ); ";

            OdbcCommand consulta = new OdbcCommand(cadena, cn.conexion());
            consulta.ExecuteNonQuery();
            MessageBox.Show("Inserción realizada");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            txtIdPaciente.Text = "";
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
           
            txtSeguro.Text = "";
        }

        private void btnModificar_Click(object sender, RoutedEventArgs e)
        {
                     
                try
                {
                    string cadena = "update CLINICA1.PACIENTE set id_paciente ='" + this.txtIdPaciente.Text
                        + "',cui_paciente ='" + this.txtCui.Text
                        + "',nit_paciente='" + this.txtNit.Text
                        + "',nombre_paciente='" + this.txtNombre.Text
                        + "',apellido_paciente='" + this.txtApellido.Text
                        + "',genero_paciente='" + this.txtGenero.Text
                        + "',edad_paciente='" + this.txtEdad.Text
                        + "',telefono_paciente='" + this.txtTelefono.Text
                        + "',direccion_paciente='" + this.txtDireccion.Text
                        + "',email_paciente='" + this.txtEmail.Text
                        + "',status_paciente='" + this.txtStatus.Text
                      
                        + "',seguro_paciente='" + this.txtSeguro.Text

                        + "'where id_paciente='" + this.txtIdPaciente.Text + "';";


                    OdbcCommand consulta = new OdbcCommand(cadena, cn.conexion());
                    consulta.ExecuteNonQuery();

                    MessageBox.Show("Modificacion realizada");

                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }

            txtIdPaciente.Text = "";
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
            
            txtSeguro.Text = "";

            txtIdPaciente.IsEnabled = true;
            btnInsertar.IsEnabled = true;
        }

        private void btnBuscar_Click(object sender, RoutedEventArgs e)
        {
            if (txtBuscar.Text != "")
            {

                try
                {

                    string Query = "select * from CLINICA1.PACIENTE where id_paciente='" + this.txtBuscar.Text + "';";


                    OdbcCommand consulta = new OdbcCommand(Query, cn.conexion());
                    consulta.ExecuteNonQuery();

                    OdbcDataReader busqueda;
                    busqueda = consulta.ExecuteReader();

                    if (busqueda.Read())
                    {
                        txtIdPaciente.Text = busqueda["id_paciente"].ToString();
                        txtCui.Text = busqueda["cui_paciente"].ToString();
                        txtNit.Text = busqueda["nit_paciente"].ToString();
                        txtNombre.Text = busqueda["nombre_paciente"].ToString();
                        txtApellido.Text = busqueda["apellido_paciente"].ToString();
                        txtGenero.Text = busqueda["genero_paciente"].ToString();
                        txtEdad.Text = busqueda["edad_epaciente"].ToString();
                        txtTelefono.Text = busqueda["telefono_paciente"].ToString();
                        txtDireccion.Text = busqueda["direccion_paciente"].ToString();
                        txtEmail.Text = busqueda["email_paciente"].ToString();
                        txtStatus.Text = busqueda["status_paciente"].ToString();
                        
                        txtSeguro.Text = busqueda["seguro_paciente"].ToString();
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

                txtIdPaciente.IsEnabled = false;
                btnInsertar.IsEnabled = false;
            }
            else
            {
                MessageBox.Show("Ingrese dato a buscar");
            }
        }

        private void btnLimpiar_Click(object sender, RoutedEventArgs e)
        {
            //txtIdEPaciente.Text = "";
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
         
            txtSeguro.Text = "";

            txtIdPaciente.IsEnabled = true;
            btnInsertar.IsEnabled = true;
        }

        private void btnEliminar_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                string cadena = "delete from CLINICA1.PACIENTE where id_paciente='" + this.txtIdPaciente.Text + "';";
                

                OdbcCommand consulta = new OdbcCommand(cadena, cn.conexion());
                consulta.ExecuteNonQuery();

                OdbcDataReader busqueda;
                busqueda = consulta.ExecuteReader();

                MessageBox.Show("Datos Eliminados");
                while (busqueda.Read())
                {
                }
                

                txtIdPaciente.Text = "";
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
              
                txtSeguro.Text = "";

                txtIdPaciente.IsEnabled = true;
                btnInsertar.IsEnabled = true;
            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnCalcular_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                DateTime fecha = dpFecha.SelectedDate.Value;
                int edad = DateTime.Today.AddTicks(-fecha.Ticks).Year - 1;
                this.txtEdad.Text = edad.ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

    }
}