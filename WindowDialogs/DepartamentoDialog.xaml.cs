using Microsoft.Extensions.DependencyInjection;
using NavegacionLateralWPF.Repositories;
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
    /// Lógica de interacción para DepartamentoDialog.xaml
    /// </summary>
    public partial class DepartamentoDialog : Window
    {
        DispatcherTimer timer = new DispatcherTimer();

        private readonly DepartamentoRepository _departamentoRepository;
        public string IdDepartamento { get; set; }
        public string NombreDepartamento { get; set; }
        public bool? DialogResult { get; private set; }

        public DepartamentoDialog()
        {
            InitializeComponent();

            _departamentoRepository = App.Current.Services.GetService<DepartamentoRepository>();

            timer.Interval = TimeSpan.FromSeconds(3);
            timer.Tick += Timer_Tick;
        }
        private void OnConfirmarButtonClick(object sender, RoutedEventArgs e)
        {
            if (IdTextBox.Text == "" || NombreTextBox.Text == "" || _departamentoRepository.ListarTodos().Exists(d => d.Id == IdTextBox.Text))
            {
                if (IdTextBox.Text == "" || NombreTextBox.Text == "")
                {
                    CamposToast.Visibility = Visibility.Visible;
                }
                if (_departamentoRepository.ListarTodos().Exists(d => d.Id == IdTextBox.Text))
                {
                    IdToast.Visibility = Visibility.Visible;
                }

                timer.Start();

            } else
            {
                IdDepartamento = IdTextBox.Text;
                NombreDepartamento = NombreTextBox.Text;
                DialogResult = true;
                Close();
            }

        }

        private void OnCancelarButtonClick(object sender, RoutedEventArgs e)
        {
            DialogResult = false;
            Close();
        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            IdToast.Visibility = Visibility.Collapsed;
            CamposToast.Visibility = Visibility.Collapsed;
            timer.Stop();
        }

    }
}
