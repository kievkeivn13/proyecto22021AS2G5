using System;
using System.Collections.Generic;
using System.Data;
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
            cargarCbocboIdEncargado();
            cargarCboIdPaciente();
            Cargartabla();
            txtIdCita.Focus();
        }

        //Cargar Combobox
        void cargarCboIdPaciente()
        {
            string cadena = "SELECT nombre_paciente FROM CLINICA1.PACIENTE";

            OdbcCommand consulta = new OdbcCommand(cadena, cn.conexion());
            consulta.ExecuteNonQuery();

            OdbcDataReader busqueda;
            busqueda = consulta.ExecuteReader();

            cboIdPaciente.Items.Clear();

            cboIdPaciente.Items.Add("Selecione una opción");
            while (busqueda.Read())
            {
                cboIdPaciente.Items.Add(busqueda["nombre_paciente"].ToString());
            }
            cboIdPaciente.SelectedIndex = 0;
        }        
        void cargarCbocboIdEncargado()
        {
            string cadena = "SELECT nombre_empleado FROM CLINICA1.EMPLEADO";

            OdbcCommand consulta = new OdbcCommand(cadena, cn.conexion());
            consulta.ExecuteNonQuery();

            OdbcDataReader busqueda;
            busqueda = consulta.ExecuteReader();

            cboIdEncargado.Items.Clear();

            cboIdEncargado.Items.Add("Selecione una opción");
            while (busqueda.Read())
            {
                cboIdEncargado.Items.Add(busqueda["nombre_empleado"].ToString());
            }
            cboIdEncargado.SelectedIndex = 0;
        }

        //Cargar Tabla
        void Cargartabla()
        {
            try
            {
                string cadena = "SELECT * FROM CLINICA1.CITAS";

                OdbcCommand consulta = new OdbcCommand(cadena, cn.conexion());
                consulta.ExecuteNonQuery();

                OdbcDataAdapter dataAdp = new OdbcDataAdapter(consulta);
                DataTable dt = new DataTable("CLINICA1.CITAS");

                dataAdp.Fill(dt);
                dgCita.ItemsSource = dt.DefaultView;

                dataAdp.Update(dt);

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnModificar_Click(object sender, RoutedEventArgs e)
        {
            if (txtIdCita.Text != "" || txtIdPaciente.Text != "" || txtIdEncargado.Text != "" || txtFecha.Text != "" || txtDescripcion.Text != "" || txtStatus.Text != "")
            {
                try
                {
                    txtFecha.Text = dpFechaCita.SelectedDate.Value.ToString("yyyy-MM-dd");
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
                cargarCbocboIdEncargado();
                cargarCboIdPaciente();
                Cargartabla();
                dpFechaCita.Text = "Seleccione una fecha";
                txtIdCita.IsEnabled = true;
                btnInsertar.IsEnabled = true;
                btnEliminar.IsEnabled = false;
                btnModificar.IsEnabled = false;
            }
            else
            {
                MessageBox.Show("Faltan datos.");
                txtIdCita.Focus();
            }
        }
        private void btnInsertar_Click(object sender, RoutedEventArgs e)
        {
            if (txtIdCita.Text != "" || txtIdPaciente.Text != "" || txtIdEncargado.Text != "" || txtFecha.Text != "" || txtDescripcion.Text !="" || txtStatus.Text != "")
            {
                try
                {
                    txtFecha.Text = dpFechaCita.SelectedDate.Value.ToString("yyyy-MM-dd");

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
                    cargarCbocboIdEncargado();
                    cargarCboIdPaciente();
                    Cargartabla();
                    dpFechaCita.Text = "Seleccione una fecha";
                    txtIdCita.IsEnabled = true;
                    btnInsertar.IsEnabled = true;
                    btnEliminar.IsEnabled = false;
                    btnModificar.IsEnabled = false;
                    rbnActivo.IsChecked = false;
                    rbnSuspendido.IsChecked = false;
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
            else
            {
                MessageBox.Show("Faltan datos.");
                txtIdCita.Focus();
            }
        }
        private void btnLimpiar_Click(object sender, RoutedEventArgs e)
        {
            txtIdCita.Text = "";
            txtIdEncargado.Text = "";
            txtIdPaciente.Text = "";
            txtFecha.Text = "";
            txtDescripcion.Text = "";
            txtStatus.Text = "";
            cargarCbocboIdEncargado();
            cargarCboIdPaciente();            
            dpFechaCita.Text = "Seleccione una fecha";
            txtIdCita.IsEnabled = true;
            btnInsertar.IsEnabled = true;
            btnEliminar.IsEnabled = false;
            btnModificar.IsEnabled = false;
            rbnActivo.IsChecked = false;
            rbnSuspendido.IsChecked = false;
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
                cargarCbocboIdEncargado();
                cargarCboIdPaciente();
                Cargartabla();
                dpFechaCita.Text = "Seleccione una fecha";
                txtIdCita.IsEnabled = true;
                btnInsertar.IsEnabled = true;
                btnEliminar.IsEnabled = false;
                btnModificar.IsEnabled = false;
                rbnActivo.IsChecked = false;
                rbnSuspendido.IsChecked = false;
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
                        txtIdEncargado.Text = busqueda["id_empleado"].ToString();
                        txtFecha.Text = busqueda["fecha_cita"].ToString();
                        dpFechaCita.Text= busqueda["fecha_cita"].ToString();
                        txtDescripcion.Text = busqueda["descripcion"].ToString();
                        txtStatus.Text = busqueda["status_cita"].ToString();
                    }
                    else
                    {
                        MessageBox.Show("Registro no encontrado");
                    }
                    try
                    {
                        string Query2 = "select * from CLINICA.EMPLEADO where id_empleado='" + this.txtIdEncargado.Text.Trim() + "';";

                        OdbcCommand consulta2 = new OdbcCommand(Query2, cn.conexion());
                        consulta2.ExecuteNonQuery();

                        OdbcDataReader busqueda2;
                        busqueda2 = consulta2.ExecuteReader();

                        if (busqueda2.Read())
                        {
                            cboIdEncargado.Items.Add(busqueda2["nombre_empleado"].ToString());
                        }
                        int ultimo = cboIdEncargado.Items.Count - 1;
                        cboIdEncargado.SelectedIndex = ultimo;  //<-- con esto lo dejas seleccionado

                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                    try
                    {
                        string Query2 = "select * from CLINICA.PACIENTE where id_paciente='" + this.txtIdPaciente.Text.Trim() + "';";

                        OdbcCommand consulta2 = new OdbcCommand(Query2, cn.conexion());
                        consulta2.ExecuteNonQuery();

                        OdbcDataReader busqueda2;
                        busqueda2 = consulta2.ExecuteReader();

                        if (busqueda2.Read())
                        {
                            cboIdPaciente.Items.Add(busqueda2["nombre_paciente"].ToString());
                        }
                        int ultimo = cboIdPaciente.Items.Count - 1;
                        cboIdPaciente.SelectedIndex = ultimo;  //<-- con esto lo dejas seleccionado

                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }

                    this.txtBuscar.Text = "";

                    txtIdCita.IsEnabled = false;
                    btnInsertar.IsEnabled = false;
                    rbnActivo.IsChecked = false;
                    rbnSuspendido.IsChecked = false;
                    btnEliminar.IsEnabled = true;
                    btnModificar.IsEnabled = true;
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

        private void cboIdPaciente_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            try
            {
                string cadena = "SELECT id_paciente FROM CLINICA1.PACIENTE where nombre_paciente='" + this.cboIdPaciente.SelectedItem.ToString() + "';";

                OdbcCommand consulta = new OdbcCommand(cadena, cn.conexion());
                consulta.ExecuteNonQuery();

                OdbcDataReader busqueda;
                busqueda = consulta.ExecuteReader();

                while (busqueda.Read())
                {
                    txtIdPaciente.Text = busqueda["id_paciente"].ToString();

                }
            }
            catch (Exception ex)
            {
                //MessageBox.Show(ex.Message);
            }
        }
        private void cboIdEncargado_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            try
            {
                string cadena = "SELECT id_empleado FROM CLINICA1.EMPLEADO where nombre_empleado='" + this.cboIdEncargado.SelectedItem.ToString() + "';";

                OdbcCommand consulta = new OdbcCommand(cadena, cn.conexion());
                consulta.ExecuteNonQuery();

                OdbcDataReader busqueda;
                busqueda = consulta.ExecuteReader();

                while (busqueda.Read())
                {
                    txtIdEncargado.Text = busqueda["id_empleado"].ToString();

                }
            }
            catch (Exception ex)
            {
                //MessageBox.Show(ex.Message);
            }
        }
    }
}
