
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

    public partial class Examen : UserControl
    {
        Conexion cn = new Conexion();
        public Examen()
        {
            InitializeComponent();
        }

        private void btnInsertar_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                string cadena = "INSERT INTO" +
                " EXAMEN (id_examen, nombre_examen, id_tipo_examen, id_requerimiento_clinico, id_requerimiento_paciente, precio_examen) VALUES (" +
                "'" + txtid_examen.Text + "', '"
                 + txtnombre_examen.Text + "', '"
                 + txtid_tipo_examen.Text + "', '"
                 + txtid_requerimiento_clinico.Text + "', '"
                 + txtid_requerimiento_paciente.Text + "', '"
                 + txtprecio_examen.Text + "' ); ";

            OdbcCommand consulta = new OdbcCommand(cadena, cn.conexion());
            consulta.ExecuteNonQuery();
            MessageBox.Show("Inserción realizada");

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            txtid_examen.Text = "";
            txtnombre_examen.Text = "";
            txtid_tipo_examen.Text = "";
            txtid_requerimiento_clinico.Text = "";
            txtid_requerimiento_paciente.Text = "";
            txtprecio_examen.Text = "";
        }

        private void btnModificar_Click(object sender, RoutedEventArgs e)
        {
            
            try
            {
                string cadena = "update CLINICA1.EXAMEN set id_examen ='" + this.txtid_examen.Text
                    + "',nombre_examen ='" + this.txtnombre_examen.Text
                    + "',id_tipo_examen ='" + this.txtid_tipo_examen.Text
                    + "',id_requerimiento_clinico ='" + this.txtid_tipo_examen.Text
                    + "',id_requerimiento_paciente ='" + this.txtid_tipo_examen.Text
                    + "',precio_examen ='" + this.txtid_tipo_examen.Text
                    + "'where id_examen='" + this.txtid_examen.Text + "';";


                OdbcCommand consulta = new OdbcCommand(cadena, cn.conexion());
                consulta.ExecuteNonQuery();

                MessageBox.Show("Modificacion realizada");

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            txtid_examen.Text = "";
            txtnombre_examen.Text = "";
            txtid_tipo_examen.Text = "";
            txtid_requerimiento_clinico.Text = "";
            txtid_requerimiento_paciente.Text = "";
            txtprecio_examen.Text = "";

            txtid_examen.IsEnabled = true;
            btnInsertar.IsEnabled = true;
        }

        private void btnBuscar_Click(object sender, RoutedEventArgs e)
        {
            if (txtBuscar.Text != "")
            {

                try
                {
                    string Query = "select * from CLINICA1.EXAMEN where id_examen='" + this.txtBuscar.Text + "';";

                    OdbcCommand consulta = new OdbcCommand(Query, cn.conexion());
                    consulta.ExecuteNonQuery();

                    OdbcDataReader busqueda;
                    busqueda = consulta.ExecuteReader();

                    if (busqueda.Read())
                    {
                        txtid_examen.Text = busqueda["id_examen"].ToString();
                        txtnombre_examen.Text = busqueda["nombre_examen"].ToString();
                        txtid_tipo_examen.Text = busqueda["id_tipo_examen"].ToString();
                        txtid_requerimiento_clinico.Text = busqueda["id_requerimiento_clinico"].ToString();
                        txtid_requerimiento_paciente.Text = busqueda["id_requerimiento_paciente"].ToString();
                        txtprecio_examen.Text = busqueda["precio_examen"].ToString();
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

                txtid_examen.IsEnabled = false;
                btnInsertar.IsEnabled = false;
            }
            else
            {
                MessageBox.Show("Ingrese dato a buscar");
            }
        }

        private void btnLimpiar_Click(object sender, RoutedEventArgs e)
        {
            txtid_examen.Text = "";
            txtnombre_examen.Text = "";
            txtid_tipo_examen.Text = "";
            txtid_requerimiento_clinico.Text = "";
            txtid_requerimiento_paciente.Text = "";
            txtprecio_examen.Text = "";

            txtid_examen.IsEnabled = true;
            btnInsertar.IsEnabled = true;
        }

        private void btnEliminar_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                string cadena = "delete from CLINICA1.EXAMEN where nombre_examen='" + this.txtid_examen.Text + "';";

                OdbcCommand consulta = new OdbcCommand(cadena, cn.conexion());
                consulta.ExecuteNonQuery();

                OdbcDataReader busqueda;
                busqueda = consulta.ExecuteReader();

                MessageBox.Show("Datos Eliminados");
                while (busqueda.Read())
                {
                }

                txtid_examen.Text = "";
                txtnombre_examen.Text = "";
                txtid_tipo_examen.Text = "";
                txtid_requerimiento_clinico.Text = "";
                txtid_requerimiento_paciente.Text = "";
                txtprecio_examen.Text = "";

                txtid_examen.IsEnabled = true;
                btnInsertar.IsEnabled = true;
            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}