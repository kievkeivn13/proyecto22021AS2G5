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
    /// Lógica de interacción para wpfGestorCitas.xaml
    /// </summary>
    public partial class wpfGestorCitas : UserControl
    {
        Conexion cn = new Conexion();
        public wpfGestorCitas()
        {
            InitializeComponent();
            
            
        }
        public void CreateMyDateTimePicker()
        {
            // Create a new DateTimePicker control and initialize it.
            System.Windows.Forms.DateTimePicker dateTimePicker1 = new System.Windows.Forms.DateTimePicker();

            // Set the MinDate and MaxDate.
            dateTimePicker1.MinDate = new DateTime(1985, 6, 20);
            dateTimePicker1.MaxDate = DateTime.Today;

            // Set the CustomFormat string.
            dateTimePicker1.CustomFormat = "MMMM dd, yyyy - dddd";
            dateTimePicker1.Format = System.Windows.Forms.DateTimePickerFormat.Custom;

            // Show the CheckBox and display the control as an up-down control.
            dateTimePicker1.ShowCheckBox = true;
            dateTimePicker1.ShowUpDown = true;
        }

        private void btnModificar_Click(object sender, RoutedEventArgs e)
        {
            try
            {

                string cadena = "update CLINICA1.CITAS set" +
                    " id_cita ='" + this.txtIdCita.Text
                    + "',id_paciente ='" + this.txtIdPaciente.Text
                    + "',id_encargado ='" + this.txtIdEncargado.Text
                    + "',fecha_cita ='" + this.txtFecha.Text
                    + "',descripcion ='" + this.txtDescripcion.Text
                    + "',status_cita ='" + this.txtStatus.Text
                    + "';";


                OdbcCommand consulta = new OdbcCommand(cadena, cn.conexion());
                consulta.ExecuteNonQuery();

                MessageBox.Show("Modificacion realizada");

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            txtIdCita.Text = "";
            txtIdEncargado.Text = "";
            txtIdPaciente.Text = "";
            txtFecha.Text = "";
            txtDescripcion.Text = "";
            txtStatus.Text = "";
            txtIdCita.IsEnabled = true;
            btnInsertar.IsEnabled = true;

        }

        private void btnInsertar_Click(object sender, RoutedEventArgs e)
        {

            txtFecha.Text = dpFechaCita.SelectedDate.Value.ToString("yyyy-dd-MM");

            string cadena = "INSERT INTO" +
            " CLINICA1.CITAS VALUES (" + 
            "'" + txtIdCita.Text + "', '" 
            + txtIdPaciente.Text + "', '" 
            + txtIdEncargado.Text + "', '"
            + txtFecha.Text + "', '"
            + txtDescripcion.Text + "', '"
            + txtStatus.Text + "' ); ";

            OdbcCommand consulta = new OdbcCommand(cadena, cn.conexion());
            consulta.ExecuteNonQuery();
            MessageBox.Show("Inserción realizada");


            txtIdCita.Text = "";
            txtIdEncargado.Text = "";
            txtIdPaciente.Text = "";
            txtFecha.Text = "";
            txtDescripcion.Text = "";
            txtStatus.Text = "";
        }

        private void btnLimpiar_Click(object sender, RoutedEventArgs e)
        {
            txtIdCita.Text = "";
            txtIdEncargado.Text = "";
            txtIdPaciente.Text = "";
            txtFecha.Text = "";
            txtDescripcion.Text = "";
            txtStatus.Text = "";
        }

        private void btnEliminar_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                string cadena = "delete from CLINICA1.CITAS where" 
                    + " id_cita='" + this.txtIdCita.Text + "';";

                OdbcCommand consulta = new OdbcCommand(cadena, cn.conexion());
                consulta.ExecuteNonQuery();

                OdbcDataReader busqueda;
                busqueda = consulta.ExecuteReader();

                MessageBox.Show("Datos Eliminados");
                while (busqueda.Read())
                {
                }
                //MyConn2.Close();

                txtIdCita.Text = "";
                txtIdEncargado.Text = "";
                txtIdPaciente.Text = "";
                txtFecha.Text = "";
                txtDescripcion.Text = "";
                txtStatus.Text = "";
                txtIdCita.IsEnabled = true;
                btnInsertar.IsEnabled = true;
            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnBuscar_Click(object sender, RoutedEventArgs e)
        {
            if (txtBuscar.Text != "")
            {
                try
                {

                    string Query = "select * from CLINICA1.CITAS where id_cita='" + this.txtBuscar.Text + "';";


                    OdbcCommand consulta = new OdbcCommand(Query, cn.conexion());
                    consulta.ExecuteNonQuery();

                    OdbcDataReader busqueda;
                    busqueda = consulta.ExecuteReader();

                    if (busqueda.Read())
                    {
                        txtIdCita.Text = busqueda["id_cita"].ToString();
                        txtIdPaciente.Text = busqueda["id_paciente"].ToString();
                        txtIdEncargado.Text = busqueda["id_encargado"].ToString();
                        txtFecha.Text = busqueda["fecha_cita"].ToString();
                        txtDescripcion.Text = busqueda["descripcion"].ToString();
                        txtStatus.Text = busqueda["status_cita"].ToString();
                    }
                    else
                    {
                        MessageBox.Show("Registro no encontrado");
                    }

                    this.txtBuscar.Text = "";

                    txtIdCita.IsEnabled = false;
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
        private void rbnActivo_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                e.Handled = true;//elimina el sonido
                rbnActivo_Checked(sender, e);

                if (btnInsertar.IsEnabled == true || btnModificar.IsEnabled == false)
                {
                    btnInsertar_Click(sender, e);//llama al evento click del boton
                }
                else
                {
                    if (btnModificar.IsEnabled == true || btnInsertar.IsEnabled == false)
                    {
                        btnModificar_Click(sender, e);//llama al evento click del boton
                    }
                }
            }
            else
            {
                if (e.Key == Key.Right || e.Key == Key.Left)
                {
                    e.Handled = true;//elimina el sonido
                    rbnSuspendido.Focus();
                }

            }
        }
        private void rbnSuspensido_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                e.Handled = true;//elimina el sonido
                rbnSuspensido_Checked(sender, e);

                if (btnInsertar.IsEnabled == true || btnModificar.IsEnabled == false)
                {
                    btnInsertar_Click(sender, e);//llama al evento click del boton
                }
                else
                {
                    if (btnModificar.IsEnabled == true || btnInsertar.IsEnabled == false)
                    {
                        btnModificar_Click(sender, e);//llama al evento click del boton
                    }
                }
            }
            else
            {
                if (e.Key == Key.Left || e.Key == Key.Right)
                {
                    e.Handled = true;//elimina el sonido
                    rbnActivo.Focus();
                }
            }
        }

        //Funcion de Radiobutton
        private void rbnActivo_Checked(object sender, RoutedEventArgs e)
        {
            rbnActivo.IsChecked = true;
            rbnSuspendido.IsChecked = false;
            txtStatus.Text = "1";
        }
        private void rbnSuspensido_Checked(object sender, RoutedEventArgs e)
        {
            {
                rbnSuspendido.IsChecked = true;
                rbnActivo.IsChecked = false;
                txtStatus.Text = "0";
            }
        }

    }
}
