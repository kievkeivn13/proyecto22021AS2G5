using System;
using System.Collections.Generic;
using System.Data.Odbc;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Forms;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace PrototipoLaboratorio.Ventanas
{
    /// <summary>
    /// Lógica de interacción para PruebaComboBox.xaml
    /// </summary>
    public partial class PruebaComboBox : System.Windows.Controls.UserControl
    {
        Conexion cn = new Conexion();
        public PruebaComboBox()
        {
            InitializeComponent();
            cargarCbx();

            DataGridViewTextBoxColumn c1 = new DataGridViewTextBoxColumn();
            c1.HeaderText = "Id";
            DataGridViewTextBoxColumn c2 = new DataGridViewTextBoxColumn();
            c2.HeaderText = "Nombre";
            DataGridViewTextBoxColumn c3 = new DataGridViewTextBoxColumn();
            c3.HeaderText = "Apellido";
            DataGridViewTextBoxColumn c4 = new DataGridViewTextBoxColumn();
            c4.HeaderText = "Edad";

        }

        public void ComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            string cadena = "SELECT nombre_empleado FROM EMPLEADO";

            OdbcCommand consulta = new OdbcCommand(cadena, cn.conexion());
            consulta.ExecuteNonQuery();

            OdbcDataReader busqueda;
            busqueda = consulta.ExecuteReader();

            while (busqueda.Read())
            {
                //pendiente...
            }
        }

        void cargarCbx() 
        {
            
            string cadena = "SELECT nombre_empleado FROM EMPLEADO";

            OdbcCommand consulta = new OdbcCommand(cadena, cn.conexion());
            consulta.ExecuteNonQuery();

            OdbcDataReader busqueda;
            busqueda = consulta.ExecuteReader();

            cbxEmpleados.Items.Clear();
            while (busqueda.Read())
            {
                cbxEmpleados.Items.Add(busqueda["nombre_empleado"].ToString());
            }

            
        }
    }
}
