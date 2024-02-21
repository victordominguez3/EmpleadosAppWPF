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
using System.Windows.Shapes;
using System.Windows.Threading;

namespace NavegacionLateralWPF.WindowDialogs
{
    /// <summary>
    /// Lógica de interacción para EditarDepartamentoDialog.xaml
    /// </summary>
    public partial class EditarDepartamentoDialog : Window
    {
        DispatcherTimer timer = new DispatcherTimer();
        public string NombreDepartamento { get; set; }
        public bool? DialogResult { get; private set; }

        public EditarDepartamentoDialog()
        {
            InitializeComponent();

            timer.Interval = TimeSpan.FromSeconds(3);
            timer.Tick += Timer_Tick;
        }

        private void OnConfirmarButtonClick(object sender, RoutedEventArgs e)
        {

            if (NombreTextBox.Text != "")
            {
                NombreDepartamento = NombreTextBox.Text;
                DialogResult = true;
                Close();
            }
            else
            {
                CamposToast.Visibility = Visibility.Visible;
                timer.Start();
            }

            
        }

        private void OnCancelarButtonClick(object sender, RoutedEventArgs e)
        {
            DialogResult = false;
            Close();
        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            CamposToast.Visibility = Visibility.Collapsed;
            timer.Stop();
        }

    }
}
