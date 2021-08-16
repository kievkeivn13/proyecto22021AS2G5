using PrototipoLaboratorio.Ventanas;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace PrototipoLaboratorio
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            
        }

        private void MenuItem_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btnUsuarios_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btnPersonal_Click(object sender, RoutedEventArgs e)
        {

        }
        private void btnGestionusuario_Click(object sender, RoutedEventArgs e){
            funGestorventas(new Ventanas.wpfGestorusuario());
        }
        private void btnTipousuario_Click(object sender, RoutedEventArgs e)
        {
            funGestorventas(new Ventanas.wpfTipousuario());
        }
        private void btnTipocambio_Click(object sender, RoutedEventArgs e)
        {
            funGestorventas(new Ventanas.wpfTipocambio());
        }

        private void btnGestionaraseguradora_Click(object sender, RoutedEventArgs e)
        {
            funGestorventas(new Ventanas.wpfAseguradoras());
        }

        private void btnDescuentoaseguradoras_Click(object sender, RoutedEventArgs e)
        {
            funGestorventas(new Ventanas.wfpDescuentosaseguradoras());
        }

        private void btnEmpleado_Click(object sender, RoutedEventArgs e)
        {
            funGestorventas(new Ventanas.wpfEmpleados());
        }

        private void btnRequerimientosC_Click(object sender, RoutedEventArgs e)
        {
            funGestorventas(new Ventanas.wpfRequerimientosClinica());
        }

        private void btnRequerimientosP_Click(object sender, RoutedEventArgs e)
        {
            funGestorventas(new Ventanas.wpfRequerimientosPaciente());
        }

        private void btnAgendarCita_Click(object sender, RoutedEventArgs e)
        {
            funGestorventas(new Ventanas.wpfGestorCitas());
        }

        private void btnGestorpacientes_Click(object sender, RoutedEventArgs e)
        {
            funGestorventas(new Ventanas.wpfPacientes());
        }

        private void btnGestorPuestos_Click(object sender, RoutedEventArgs e)
        {
            funGestorventas(new Ventanas.wpfPuestos());
        }
        private void btnExamen_Click(object sender, RoutedEventArgs e)
        {
            funGestorventas(new Ventanas.Examen());
        }

        private void btnTipo_muestra_Click(object sender, RoutedEventArgs e)
        {
            funGestorventas(new Ventanas.Tipo_muestra());
        }

        private void btnTipo_examen_Click(object sender, RoutedEventArgs e)
        {
            funGestorventas(new Ventanas.Tipo_examen());
        }

        private void btnFormas_pago_Click(object sender, RoutedEventArgs e)
        {
            funGestorventas(new Ventanas.Formas_pago());
        }

        private void btnPaquete_Click(object sender, RoutedEventArgs e)
        {
            funGestorventas(new Ventanas.Paquete());
        }
        private void btnEtiqueta_Click(object sender, RoutedEventArgs e)
        {
            funGestorventas(new Ventanas.wpfGestionarEtiqueta());
        }
        private void btnVentanaAyuda_Click(object sender, RoutedEventArgs e)
        {
            funGestorventas(new Ventanas.wpfVentanaAyuda());
        }
        private void btnCotizaciones_Click(object sender, RoutedEventArgs e)
        {
            funGestorventas(new Ventanas.wpfCotizaciones());
        }
        private void btnRptPaciantes_Click(object sender, RoutedEventArgs e)
        {
            rptPaciente dashboard = new rptPaciente();
            dashboard.Show();
        }
        private void funGestorventas(UserControl control)
        {
            this.pnlVentanas.Children.Clear();
            this.pnlVentanas.Children.Add(control);
        }

        private void btnSalir_Click(object sender, RoutedEventArgs e)
        {
            this.pnlVentanas.Children.Clear();
        }

        private void btnSignOut_Click(object sender, RoutedEventArgs e)
        {
            loginscreen dashboard = new loginscreen();
            dashboard.Show();
            this.Close();
        }
    }

}
