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
                 + txtNit.Text + ", '"
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

        }
    }
}
