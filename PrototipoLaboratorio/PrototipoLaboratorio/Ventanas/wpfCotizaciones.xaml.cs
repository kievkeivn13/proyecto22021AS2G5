using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Odbc;
using System.Net;
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
    /// Lógica de interacción para wpfCotizaciones.xaml
    /// </summary>
    public partial class wpfCotizaciones : UserControl
    {
        Conexion cn = new Conexion();
        Conexion cn2 = new Conexion();
        
        public wpfCotizaciones()
        {
            InitializeComponent();
            cbxExamen.IsEnabled = false;
            cbxTipoExamen.IsEnabled = false;
            cbxPaquete.IsEnabled = false;

            cargarCbxPaquete();
            cargarCbxTipoExamen();
            
        }



        private void btnCotizar_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (txtIdPaciente.Text != "")
                {
                    if (rbIndividual.IsChecked == true && rbPaquete.IsChecked == false)
                    {
                        lblRequerimientos.Content = "Requerimiento:";
                        string cadena = "SELECT id_requerimiento_paciente, precio_examen FROM CLINICA1.EXAMEN where id_examen='" + lblExamen.Content.ToString() + "';";

                        OdbcCommand consulta = new OdbcCommand(cadena, cn.conexion());
                        consulta.ExecuteNonQuery();

                        OdbcDataReader busqueda;
                        busqueda = consulta.ExecuteReader();

                        string id_requerimiento = "";
                        while (busqueda.Read())
                        {
                            txtPrecio.Text = busqueda["precio_examen"].ToString() + ".00";
                            id_requerimiento = busqueda["id_requerimiento_paciente"].ToString();
                        }


                        string cadena2 = "SELECT descripcion_requerimiento_paciente FROM CLINICA1.REQUERIMIENTOS_PACIENTE WHERE id_requerimiento_paciente= '" + id_requerimiento + "';";
                        OdbcCommand consulta2 = new OdbcCommand(cadena2, cn2.conexion());
                        consulta2.ExecuteNonQuery();
                        OdbcDataReader busqueda2;
                        busqueda2 = consulta2.ExecuteReader();

                        while (busqueda2.Read())
                        {
                            txtRequerimientos.Text = busqueda2["descripcion_requerimiento_paciente"].ToString();

                        }

                        //INGRESO A TABLA DE COTIZACION

                        string cadena3 = "INSERT INTO" +
                           " cotizacion  VALUES (" +
                           "" + "0" + ", '"
                            + txtIdPaciente.Text + "', '"
                            + DateTime.Now.ToString("yyyy-MM-dd") + "', '"
                            + lblPaquete.Content + "', '"
                            + lblTipoExamen.Content + "', '"
                            + cbxExamen.SelectedItem.ToString() + "', "
                            + float.Parse(txtPrecio.Text) + " ); ";

                        OdbcCommand consulta3 = new OdbcCommand(cadena3, cn.conexion());
                        consulta3.ExecuteNonQuery();
                        MessageBox.Show("Inserción realizada");

                        cbxExamen.Items.Clear();
                        cbxTipoExamen.Items.Clear();
                        rbIndividual.IsChecked = false;

                        cbxExamen.IsEnabled = false;
                        cbxTipoExamen.IsEnabled = false;
                        lblExamen.Content = "-";
                        lblTipoExamen.Content = "-";
                        //txtIdPaciente.Text = "";
                        //txtIdCotizacion.Text = "";
                        cargarCbxTipoExamen();
                    }
                    else if (rbPaquete.IsChecked == true && rbIndividual.IsChecked == false)
                    {
                        lblRequerimientos.Content = "Descripción:";
                        string cadena = "SELECT nombre_paquete, precio FROM CLINICA1.PAQUETE_ENCABEZADO where id_paquete='" + lblPaquete.Content.ToString() + "';";

                        OdbcCommand consulta = new OdbcCommand(cadena, cn.conexion());
                        consulta.ExecuteNonQuery();

                        OdbcDataReader busqueda;
                        busqueda = consulta.ExecuteReader();


                        while (busqueda.Read())
                        {
                            txtPrecio.Text = busqueda["precio"].ToString() + ".00";
                            txtRequerimientos.Text = busqueda["nombre_paquete"].ToString();
                        }


                        //INGRESO A TABLA DE COTIZACION

                        string cadena3 = "INSERT INTO" +
                           " cotizacion  VALUES (" +
                           "" + "0" + ", '"
                            + txtIdPaciente.Text + "', '"
                            + DateTime.Now.ToString("yyyy-MM-dd") + "', '"
                            + lblPaquete.Content + "', '"
                            + lblTipoExamen.Content + "', '"
                            + "Paquete " + txtRequerimientos.Text + "', "
                            + float.Parse(txtPrecio.Text) + " ); ";

                        OdbcCommand consulta3 = new OdbcCommand(cadena3, cn.conexion());
                        consulta3.ExecuteNonQuery();
                        MessageBox.Show("Inserción realizada");

                        cbxExamen.Items.Clear();
                        cbxTipoExamen.Items.Clear();
                        rbIndividual.IsChecked = false;

                        cbxExamen.IsEnabled = false;
                        cbxTipoExamen.IsEnabled = false;
                        lblExamen.Content = "-";
                        lblTipoExamen.Content = "-";
                        //txtIdPaciente.Text = "";
                        //txtIdCotizacion.Text = "";
                        cargarCbxTipoExamen();
                    }
                }
                else
                {
                    MessageBox.Show("Por favor ingresar Id Del Paciente");
                }
                
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void btnComprar_Click(object sender, RoutedEventArgs e)
        {
            //Acá se guardará información en las tablas de factura
            //Y se abrira windows forms para la facura
            try
            {
                
                if(txtCodigoFactura.Text != "")
                {
                    //Insert encabezado factura
                    string cadena2 = "INSERT INTO"
                        + " ENCABEZADO_FACTURA  VALUES ("
                        + "'"
                        + txtCodigoFactura.Text
                        + "', '"
                        + txtIdPaciente.Text
                        + "', '"
                        + "1"
                        + "' , '"
                        + DateTime.Now.ToString("yyyy-MM-dd")
                        + "', '"
                        + DateTime.Now.ToString("hh:mm:ss")
                        + "' , '"
                        + float.Parse(txtTotal.Text)
                        + "' ); ";

                    OdbcCommand consulta2 = new OdbcCommand(cadena2, cn.conexion());
                    consulta2.ExecuteNonQuery();
                    MessageBox.Show("Inserción a encabezado realizada");



                    //select en la cotizacion para llenar el detalle de la factura
                    string cadena = "SELECT nombre_examen, precio FROM CLINICA1.COTIZACION where id_paciente='" + txtIdPaciente.Text.ToString() + "' AND fecha_cotizacion ='" + DateTime.Now.ToString("yyyy-MM-dd") + "';";

                    OdbcCommand consulta = new OdbcCommand(cadena, cn.conexion());
                    consulta.ExecuteNonQuery();

                    OdbcDataReader busqueda;
                    busqueda = consulta.ExecuteReader();

                    while (busqueda.Read())
                    {



                        //Insert a factura detalle
                        string cadena3 = "INSERT INTO" +
                         " DETALLE_FACTURA  VALUES (" +
                         "" + 0 + ", '"
                         + txtCodigoFactura.Text + "', '"
                         + busqueda["nombre_examen"].ToString() + "', "
                         + float.Parse(busqueda["precio"].ToString()) + " ); ";

                        OdbcCommand consulta3 = new OdbcCommand(cadena3, cn.conexion());
                        consulta3.ExecuteNonQuery();
                        MessageBox.Show("Inserción a detalle realizada");
                    }

                }
                else
                {
                    MessageBox.Show("Porfavor ingrese numero de factura");
                }
               


            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.ToString());
                
            }
            finally
            {
                cargarCbxExamen();
            }

        }

        private void btnLimpiar_Click(object sender, RoutedEventArgs e)
        {
            dgExamenes.ItemsSource = null;
            dgExamenes.Items.Clear();
            dgExamenes.Items.Refresh();
            txtCodigoFactura.Text = "";
            txtIdPaciente.Text = "";
            cbxExamen.Items.Clear();
            cbxTipoExamen.Items.Clear();
            cbxPaquete.Items.Clear();
            lblExamen.Content = "";
            lblPaquete.Content = "";
            lblTipoExamen.Content = "";
            txtRequerimientos.Text = "";
            txtTotal.Text = "";
            rbIndividual.IsChecked = false;
            rbPaquete.IsChecked = false;

        }

        private void btnEliminar_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btnBuscar_Click(object sender, RoutedEventArgs e)
        {

        }

        private void rbPaquete_Checked(object sender, RoutedEventArgs e)
        {
            cbxExamen.IsEnabled = false;
            cbxTipoExamen.IsEnabled = false;
            cbxPaquete.IsEnabled = true;

            cbxTipoExamen.Items.Clear();
            cbxExamen.Items.Clear();
            cargarCbxPaquete();
            lblExamen.Content = "-";
            lblPaquete.Content = "-";
            lblTipoExamen.Content = "-";
            lblRequerimientos.Content = "Descripcion:";
        }

        private void rbIndividual_Checked(object sender, RoutedEventArgs e)
        {
            cbxExamen.IsEnabled = true;
            cbxTipoExamen.IsEnabled = true;
            cbxPaquete.IsEnabled = false;
            cbxPaquete.Items.Clear();
            cargarCbxTipoExamen();

            lblExamen.Content = "-";
            lblPaquete.Content = "-";
            lblTipoExamen.Content = "-";
            lblRequerimientos.Content = "Requerimiento:";
        }

        //Combo box Paquete
        void cargarCbxPaquete()
        {

            string cadena = "SELECT nombre_paquete FROM PAQUETE_ENCABEZADO";

            OdbcCommand consulta = new OdbcCommand(cadena, cn.conexion());
            consulta.ExecuteNonQuery();

            OdbcDataReader busqueda;
            busqueda = consulta.ExecuteReader();

            cbxPaquete.Items.Clear();
            cbxPaquete.Items.Add("Seleccione una opcion.-");
            while (busqueda.Read())
            {
                cbxPaquete.Items.Add(busqueda["nombre_paquete"].ToString());
            }
            cbxPaquete.SelectedIndex = 0;

        }

        private void cbxPaquete_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            string cadena = "SELECT id_paquete FROM PAQUETE_ENCABEZADO WHERE nombre_paquete = '" + cbxPaquete.SelectedItem + "';";

            OdbcCommand consulta = new OdbcCommand(cadena, cn.conexion());
            consulta.ExecuteNonQuery();

            OdbcDataReader busqueda;
            busqueda = consulta.ExecuteReader();

            while (busqueda.Read())
            {
                lblPaquete.Content = busqueda["id_paquete"].ToString();
            }
        }

        //Cargando combo box de tipo examen
        void cargarCbxTipoExamen()
        {
            try
            {
                if (cbxTipoExamen.SelectedIndex != 0)
                {
                    string cadena = "SELECT nombre_tipo_examen FROM CLINICA1.TIPO_EXAMEN";

                    OdbcCommand consulta = new OdbcCommand(cadena, cn.conexion());
                    consulta.ExecuteNonQuery();

                    OdbcDataReader busqueda;
                    busqueda = consulta.ExecuteReader();

                    cbxTipoExamen.Items.Clear();
                    cbxTipoExamen.Items.Add("Selecione una opción");
                    while (busqueda.Read())
                    {
                        cbxTipoExamen.Items.Add(busqueda["nombre_tipo_examen"].ToString());
                    }
                    cbxTipoExamen.SelectedIndex = 0;
                    txtPrecio.Text = "";
                    txtRequerimientos.Text = "";
                }
                else
                {
                    cbxExamen.Items.Clear();
                }
            }
            catch (Exception ex)
            {
                // MessageBox.Show(ex.Message);
            }
        }

        private void cbxTipoExamen_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            try
            {
                string cadena = "SELECT id_tipo_examen FROM CLINICA1.TIPO_EXAMEN where nombre_tipo_examen='" + this.cbxTipoExamen.SelectedItem.ToString() + "';";

                OdbcCommand consulta = new OdbcCommand(cadena, cn.conexion());
                consulta.ExecuteNonQuery();

                OdbcDataReader busqueda;
                busqueda = consulta.ExecuteReader();

                while (busqueda.Read())
                {
                    lblTipoExamen.Content = busqueda["id_tipo_examen"].ToString();
                }

                cargarCbxExamen();
                txtPrecio.Text = "";
                txtRequerimientos.Text = "";
            }
            catch (Exception ex)
            {
                // MessageBox.Show(ex.Message);
            }


        }

        //Cargar combo box de examen
        void cargarCbxExamen()
        {
            try
            {
                if (cbxTipoExamen.SelectedIndex != 0)
                {
                    string cadena = "SELECT nombre_examen FROM CLINICA1.EXAMEN where id_tipo_examen = '" +
                        lblTipoExamen.Content + "'";

                    OdbcCommand consulta = new OdbcCommand(cadena, cn.conexion());
                    consulta.ExecuteNonQuery();

                    OdbcDataReader busqueda;
                    busqueda = consulta.ExecuteReader();

                    cbxExamen.Items.Clear();
                    cbxExamen.Items.Add("Selecione una opción");
                    while (busqueda.Read())
                    {
                        cbxExamen.Items.Add(busqueda["nombre_examen"].ToString());
                    }
                    cbxExamen.SelectedIndex = 0;
                }
                else
                {
                    cbxExamen.Items.Clear();
                }
            }
            catch (Exception ex)
            {
               // MessageBox.Show(ex.Message);
            }
            
        }

        private void cbxExamen_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            try
            {
                if(cbxExamen.SelectedIndex != 0)
                {
                    string cadena = "SELECT id_examen FROM CLINICA1.EXAMEN where nombre_examen='" + this.cbxExamen.SelectedItem.ToString() + "';";

                    OdbcCommand consulta = new OdbcCommand(cadena, cn.conexion());
                    consulta.ExecuteNonQuery();

                    OdbcDataReader busqueda;
                    busqueda = consulta.ExecuteReader();

                    while (busqueda.Read())
                    {
                        lblExamen.Content = busqueda["id_examen"].ToString();
                        
                    }
 
                    
                }
                

            }
            catch (Exception ex)
            {
                // MessageBox.Show(ex.Message);
            }
        }

      

        private void btnCargar_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                string cadena = "SELECT nombre_examen, precio FROM CLINICA1.COTIZACION where id_paciente ='" + txtIdPaciente.Text.ToString() + "';";

                OdbcCommand consulta = new OdbcCommand(cadena, cn.conexion());
                consulta.ExecuteNonQuery();

                OdbcDataAdapter dataAdp = new OdbcDataAdapter(consulta);
                DataTable dt = new DataTable("CLINICA1.COTIZACION");

                dataAdp.Fill(dt);
                dgExamenes.ItemsSource = dt.DefaultView;

                dataAdp.Update(dt);
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                sumaTotal();
            }
        }

        public void sumaTotal()
        {
            float sum = 0;
            foreach (DataRowView row in dgExamenes.ItemsSource)
            {
                sum += (float)row["precio"];
            }
            txtTotal.Text = sum.ToString();
        }
    }
}
