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
using MySqlConnector;
using PrototipoLaboratorio;

namespace PrototipoLaboratorio.Ventanas
{
    /// <summary>
    /// Lógica de interacción para wpfGestorusuario.xaml
    /// </summary>
    public partial class wpfGestorusuario : UserControl
    {
        Conexion cn = new Conexion();
        public wpfGestorusuario()
        {
            InitializeComponent();
            cargarCbo();
        }

        void cargarCbo()
        {
            try
            {
                string cadena = "SELECT nombre_tipo_usuario FROM CLINICA1.TIPO_USUARIO";

                OdbcCommand consulta = new OdbcCommand(cadena, cn.conexion());
                consulta.ExecuteNonQuery();

                OdbcDataReader busqueda;
                busqueda = consulta.ExecuteReader();

                cboTipousuario.Items.Clear();
                cboTipousuario.Items.Add("Selecione una opción");
                while (busqueda.Read())
                {
                    cboTipousuario.Items.Add(busqueda["nombre_tipo_usuario"].ToString());
                }
                cboTipousuario.SelectedIndex = 0;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
       
        private void btnInsertar_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                string cadena = "INSERT INTO " +
                    " CLINICA1.USUARIOS (id_usuario, id_tipo_usuario, nombre_usuario," +
                    " passwd_usuario, estado_usuario) VALUES (" +
                    "'" + txtIdusuario.Text + "', '"
                     + txtIdtipousuario.Text + "', '"
                     + txtNombreusuario.Text + "', '"
                     + txtContraseñausuario.Password + "', '"
                     + txtEstadousuario.Text + "' ); ";

                OdbcCommand consulta = new OdbcCommand(cadena, cn.conexion());

                consulta.ExecuteNonQuery();
                MessageBox.Show("Inserción realizada");

                txtIdusuario.Text = "";
                txtIdtipousuario.Text = "";
                txtNombreusuario.Text = "";
                txtContraseñausuario.Password = "";
                txtEstadousuario.Text = "";
                cboTipousuario.Items.Clear();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnModificar_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                string cadena = "update CLINICA1.USUARIOS set id_usuario ='" + this.txtIdusuario.Text
                    + "',id_tipo_usuario ='" + this.txtIdtipousuario.Text
                    + "',nombre_usuario ='" + this.txtNombreusuario.Text
                    + "',passwd_usuario ='" + this.txtContraseñausuario.Password
                    + "',estado_usuario ='" + this.txtEstadousuario.Text

                    + "'where id_usuario='" + this.txtIdusuario.Text + "';";

                OdbcCommand consulta = new OdbcCommand(cadena, cn.conexion());
                consulta.ExecuteNonQuery();

                MessageBox.Show("Modificacion realizada");

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            txtIdusuario.Text = "";
            txtIdtipousuario.Text = "";
            txtNombreusuario.Text = "";
            txtContraseñausuario.Password = "";
            txtEstadousuario.Text = "";
            cboTipousuario.Items.Clear();
            txtIdtipousuario.IsEnabled = true;
            btnInsertar.IsEnabled = true;
        }

        private void btnLimpiar_Click(object sender, RoutedEventArgs e)
        {

            txtBuscar.Text = "";
            txtIdusuario.Text = "";
            txtIdtipousuario.Text = "";
            txtNombreusuario.Text = "";
            txtContraseñausuario.Password = "";
            txtEstadousuario.Text = "";
            cboTipousuario.Items.Clear();
            cboTipousuario.Items.Add("Selecione una opción");
            cboTipousuario.SelectedIndex = 0;
            txtIdtipousuario.IsEnabled = true;
            btnInsertar.IsEnabled = true;

        } 

        private void btnEliminar_Click(object sender, RoutedEventArgs e)
        {
            try
            {

                string cadena = "delete from CLINICA1.USUARIOS where id_usuario='" + this.txtIdusuario.Text + "';";


                OdbcCommand consulta = new OdbcCommand(cadena, cn.conexion());
                consulta.ExecuteNonQuery();

                OdbcDataReader busqueda;
                busqueda = consulta.ExecuteReader();

                MessageBox.Show("Datos Eliminados");
                while (busqueda.Read())
                {
                }
                txtIdusuario.Text = "";
                txtIdtipousuario.Text = "";
                txtNombreusuario.Text = "";
                txtContraseñausuario.Password = "";
                txtEstadousuario.Text = "";
                cboTipousuario.Items.Clear();

                txtIdtipousuario.IsEnabled = true;
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
                    string Query = "select * from CLINICA1.USUARIOS where id_usuario='" + this.txtBuscar.Text + "';";

                    OdbcCommand consulta = new OdbcCommand(Query, cn.conexion());
                    consulta.ExecuteNonQuery();

                    OdbcDataReader busqueda;
                    busqueda = consulta.ExecuteReader();

                    if (busqueda.Read())
                    {
                        txtIdusuario.Text = busqueda["id_usuario"].ToString();
                        txtIdtipousuario.Text= busqueda["id_tipo_usuario"].ToString();
                        txtNombreusuario.Text = busqueda["nombre_usuario"].ToString();
                        txtContraseñausuario.Password = busqueda["passwd_usuario"].ToString();
                        txtEstadousuario.Text = busqueda["estado_usuario"].ToString();
                    }
                    else
                    {
                        MessageBox.Show("Registro no encontrado");
                    }
                    try
                    {
                        string Query2 = "select * from CLINICA1.TIPO_USUARIO where id_tipo_usuario='" + this.txtIdtipousuario.Text.Trim() + "';";

                        OdbcCommand consulta2 = new OdbcCommand(Query2, cn.conexion());
                        consulta2.ExecuteNonQuery();

                        OdbcDataReader busqueda2;
                        busqueda2 = consulta2.ExecuteReader();

                        if (busqueda2.Read())
                        {
                            cboTipousuario.Items.Add(busqueda2["nombre_tipo_usuario"].ToString());
                        }
                        int ultimo = cboTipousuario.Items.Count - 1;
                        cboTipousuario.SelectedIndex = ultimo;  //<-- con esto lo dejas seleccionado
                        
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

                txtIdtipousuario.IsEnabled = false;
                btnInsertar.IsEnabled = false;
            }
            else
            {
                MessageBox.Show("Ingrese dato a buscar");
            }

        }

        private void cboTipousuario_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            try
            {
                string cadena = "SELECT id_tipo_usuario FROM CLINICA1.TIPO_USUARIO where nombre_tipo_usuario='" + this.cboTipousuario.SelectedItem.ToString() + "';";

                OdbcCommand consulta = new OdbcCommand(cadena, cn.conexion());
                consulta.ExecuteNonQuery();

                OdbcDataReader busqueda;
                busqueda = consulta.ExecuteReader();

                while (busqueda.Read())
                {
                    txtIdtipousuario.Text = busqueda["id_tipo_usuario"].ToString();
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

    }
}
