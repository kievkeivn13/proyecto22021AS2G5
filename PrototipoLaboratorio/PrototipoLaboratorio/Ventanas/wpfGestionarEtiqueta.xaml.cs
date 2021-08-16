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
    /// Lógica de interacción para wpfGestionarEtiqueta.xaml
    /// </summary>
    public partial class wpfGestionarEtiqueta : UserControl
    {
        Conexion cn = new Conexion();
        public wpfGestionarEtiqueta()
        {
            InitializeComponent();
            Cargartabla();
            cargarCbo();
            cargarCboTM();
            txtBuscar.Focus();
            
        }

        //Cargar Tabla
        void Cargartabla()
        {
            try
            {
                string cadena = "SELECT * FROM CLINICA1.ETIQUETAS";

                OdbcCommand consulta = new OdbcCommand(cadena, cn.conexion());
                consulta.ExecuteNonQuery();

                OdbcDataAdapter dataAdp = new OdbcDataAdapter(consulta);
                DataTable dt = new DataTable("CLINICA1.ETIQUETAS");

                dataAdp.Fill(dt);
                dgDescuentoA.ItemsSource = dt.DefaultView;

                dataAdp.Update(dt);

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        //Cargar Combobox
        void cargarCbo()
        {
            try
            {
                string cadena = "SELECT id_muestra FROM CLINICA1.ETIQUETAS";

                OdbcCommand consulta = new OdbcCommand(cadena, cn.conexion());
                consulta.ExecuteNonQuery();

                OdbcDataReader busqueda;
                busqueda = consulta.ExecuteReader();

                cboIdMuestra.Items.Clear();

                cboIdMuestra.Items.Add("Selecione una opción");
                while (busqueda.Read())
                {
                    cboIdMuestra.Items.Add(busqueda["nombre_paciente"].ToString());
                }
                cboIdMuestra.SelectedIndex = 0;
            }
            catch (Exception ex)
            {
               // MessageBox.Show(ex.Message);
            }

        }
        void cargarCboTM()
        {
            try
            {
                string cadena = "SELECT nombre_tipo_muestra FROM CLINICA1.TIPO_MUESTRA";

                OdbcCommand consulta = new OdbcCommand(cadena, cn.conexion());
                consulta.ExecuteNonQuery();

                OdbcDataReader busqueda;
                busqueda = consulta.ExecuteReader();

                cboTipoMuestra.Items.Clear();

                cboTipoMuestra.Items.Add("Selecione una opción");
                while (busqueda.Read())
                {
                    cboTipoMuestra.Items.Add(busqueda["nombre_tipo_muestra"].ToString());
                }
                cboTipoMuestra.SelectedIndex = 0;
            }
            catch (Exception ex)
            {
               // MessageBox.Show(ex.Message);
            }
        }

        //Funcion de botones
        private void btnLimpiar_Click(object sender, RoutedEventArgs e)
        {
            txtIdEtiqueta.Text = "";
            cargarCbo();
            cargarCboTM();
            btnEliminar.IsEnabled = false;
            btnModificar.IsEnabled = false;
        }
        private void btnModificar_Click(object sender, RoutedEventArgs e)
        {

            if (txtIdEtiqueta.Text != "" || txtIdMuestra.Text != "" || txtIdTM.Text != "" )
            {
                try
                {
                    string cadena = "update CLINICA.ETIQUETAS set id_etiqueta ='" + this.txtIdEtiqueta.Text
                        + "',id_muestra ='" + this.txtIdMuestra.Text
                        + "',id_tipo_muestra='" + this.txtIdTM.Text
                        
                        + "'where id_etiqueta='" + this.txtIdEtiqueta.Text + "';";

                    OdbcCommand consulta = new OdbcCommand(cadena, cn.conexion());
                    consulta.ExecuteNonQuery();

                    MessageBox.Show("Modificacion realizada");

                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }

                txtIdEtiqueta.Text = "";
                cargarCboTM();
                cargarCbo();
                Cargartabla();                              
                btnModificar.IsEnabled = false;
                btnEliminar.IsEnabled = false;
            }
            else
            {
                MessageBox.Show("Faltan datos.");
                cboIdMuestra.Focus();
            }
        }
        private void btnEliminar_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                string cadena = "delete from CLINICA.ETIQUETAS where id_etiqueta='" + this.txtIdEtiqueta.Text + "';";

                OdbcCommand consulta = new OdbcCommand(cadena, cn.conexion());
                consulta.ExecuteNonQuery();

                OdbcDataReader busqueda;
                busqueda = consulta.ExecuteReader();

                MessageBox.Show("Datos Eliminados");
                while (busqueda.Read())
                {
                }
                txtIdEtiqueta.Text = "";           
                cargarCbo();
                Cargartabla();
                btnModificar.IsEnabled = false;
                btnEliminar.IsEnabled = false;
            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        //Seleccion en Combobox
        private void cboTipousuario_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            txtIdMuestra.Text = cboIdMuestra.SelectedItem.ToString();         
        }
       

        private void btnBuscar_Click(object sender, RoutedEventArgs e)
        {
            if (txtBuscar.Text != "")
            {
                try
                {
                    cargarCboTM();cargarCbo();
                    string Query = "select * from CLINICA.MUESTRAS where id_etiqueta='" + this.txtBuscar.Text + "';";

                    OdbcCommand consulta = new OdbcCommand(Query, cn.conexion());
                    consulta.ExecuteNonQuery();

                    OdbcDataReader busqueda;
                    busqueda = consulta.ExecuteReader();

                    if (busqueda.Read())
                    {
                        txtIdEtiqueta.Text = busqueda["id_etiqueta"].ToString();
                        cboIdMuestra.Items.Add( busqueda["id_muestra"].ToString());                        
                    }
                    else
                    {
                        MessageBox.Show("Registro no encontrado");
                    }
                    try
                    {
                        string Query2 = "select * from CLINICA.TIPO_MUESTRA where id_tipo_muestra='" + this.txtIdTM.Text.Trim() + "';";

                        OdbcCommand consulta2 = new OdbcCommand(Query2, cn.conexion());
                        consulta2.ExecuteNonQuery();

                        OdbcDataReader busqueda2;
                        busqueda2 = consulta2.ExecuteReader();

                        if (busqueda2.Read())
                        {
                            cboTipoMuestra.Items.Add(busqueda2["nombre_tipo_muestra"].ToString());
                        }
                        int ultimo = cboTipoMuestra.Items.Count - 1;
                        cboTipoMuestra.SelectedIndex = ultimo;  //<-- con esto lo dejas seleccionado

                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }

                    this.txtBuscar.Text = "";
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
               
                
                
                btnModificar.IsEnabled = true;
                btnEliminar.IsEnabled = true;
            }
            else
            {
                MessageBox.Show("Ingrese dato a buscar");
            }
        }

        private void cboNombreaseguradora_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                e.Handled = true;//elimina el sonido
                cboTipoMuestra.Focus();
            }
        }
        private void cboTipoMuestra_KeyDown(object sender, KeyEventArgs e)
        {

            if (e.Key == Key.Enter)
            {
                e.Handled = true;//elimina el sonido          
                 
                btnModificar_Click(sender, e);//llama al evento click del boton
                   
            }
        }

        private void txtBuscar_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                e.Handled = true;//elimina el sonido
                btnBuscar_Click(sender, e);//llama al evento click del boton
            }
        }

        private void cboTipoMuestra_SelectionChanged_1(object sender, SelectionChangedEventArgs e)
        {
            try
            {
                string cadena = "SELECT id_tipo_muestra FROM CLINICA1.TIPO_MUESTRA where nombre_tipo_muestra='" + this.cboTipoMuestra.SelectedItem.ToString() + "';";

                OdbcCommand consulta = new OdbcCommand(cadena, cn.conexion());
                consulta.ExecuteNonQuery();

                OdbcDataReader busqueda;
                busqueda = consulta.ExecuteReader();

                while (busqueda.Read())
                {
                    txtIdTM.Text = busqueda["id_tipo_muestra"].ToString();
                }
            }
            catch (Exception ex)
            {
                //MessageBox.Show(ex.Message);
            }
        }
    }
}
