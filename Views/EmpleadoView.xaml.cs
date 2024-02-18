using Microsoft.Extensions.DependencyInjection;
using NavegacionLateralWPF.Models;
using NavegacionLateralWPF.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Resources;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Threading;

namespace NavegacionLateralWPF.Views
{
    /// <summary>
    /// Lógica de interacción para EmpleadoView.xaml
    /// </summary>
    public partial class EmpleadoView : UserControl
    {

        DispatcherTimer timer = new DispatcherTimer();

        public EmpleadoView()
        {
            InitializeComponent();
            this.DataContext = App.Current.Services.GetService<EmpleadoViewModel>();

            timer.Interval = TimeSpan.FromSeconds(3);
            timer.Tick += Timer_Tick;

            HacerCamposSoloLectura();

        }

        private void EmpleadoView_Loaded(object sender, RoutedEventArgs e)
        {
            var floatInAnimation = (Storyboard)FindResource("FloatInAnimation");
            var fadeInAnimation = (Storyboard)FindResource("FadeInAnimation");

            if (floatInAnimation != null && fadeInAnimation != null)
            {
                var translateYTransform = new TranslateTransform();
                mainPanel.RenderTransform = translateYTransform;

                Storyboard.SetTarget(floatInAnimation, mainPanel);
                Storyboard.SetTarget(fadeInAnimation, mainPanel);
                floatInAnimation.Begin();
                fadeInAnimation.Begin();
            }
        }

        private void ExcluirColumnaImagen(object sender, DataGridAutoGeneratingColumnEventArgs e)
        {
            
            if (e.PropertyName == "UrlImagen")
            {
                e.Cancel = true;
            }
            else
            {
                string encabezado = Properties.Resources.ResourceManager.GetString(e.PropertyName);

                if (!string.IsNullOrEmpty(encabezado))
                {
                    e.Column.Header = encabezado;
                }
            }
        }

        private void SeleccionCambiada(object sender, SelectionChangedEventArgs e)
        {
            Button guardarButton = GuardarButton;
            Button editarButton = EditarButton;
            Button cancelarButton = CancelarButton;
            Button nuevoButton = NuevoButton;
            Button eliminarButton = EliminarButton;

            guardarButton.Visibility = Visibility.Collapsed;
            editarButton.Visibility = Visibility.Visible;
            cancelarButton.Visibility = Visibility.Collapsed;
            nuevoButton.Visibility = Visibility.Visible;
            eliminarButton.Visibility = Visibility.Visible;

            HacerCamposSoloLectura();
        }

        private void OnGuardarButtonClick(object sender, RoutedEventArgs e) 
        {
            Button guardarButton = GuardarButton;
            Button editarButton = EditarButton;
            Button cancelarButton = CancelarButton;
            Button nuevoButton = NuevoButton;
            Button eliminarButton = EliminarButton;

            TextBox dniTextBox = DniTextBox;
            TextBox nombreTextBox = NombreTextBox;
            TextBox apellidosTextBox = ApellidosTextBox;
            TextBox puestoTextBox = PuestoTextBox;
            ComboBox departamentoComboBox = DepartamentoComboBox;

            if (dniTextBox.Text != "" && 
                nombreTextBox.Text != "" && 
                apellidosTextBox.Text != "" && 
                puestoTextBox.Text != "" &&
                departamentoComboBox.SelectedItem != null)
            {
                guardarButton.Visibility = Visibility.Collapsed;
                editarButton.Visibility = Visibility.Visible;
                cancelarButton.Visibility = Visibility.Collapsed;
                nuevoButton.Visibility = Visibility.Visible;
                eliminarButton.Visibility = Visibility.Visible;

                GuardadoToast.Visibility = Visibility.Visible;
                HacerCamposSoloLectura();

            } else
            {
                CamposToast.Visibility = Visibility.Visible;
            }
            timer.Start();
        }

        private void OnEditarButtonClick(object sender, RoutedEventArgs e)
        {
            Button guardarButton = GuardarButton;
            Button editarButton = EditarButton;
            Button cancelarButton = CancelarButton;
            Button nuevoButton = NuevoButton;
            Button eliminarButton = EliminarButton;

            guardarButton.Visibility = Visibility.Visible;
            editarButton.Visibility = Visibility.Collapsed;
            cancelarButton.Visibility = Visibility.Visible;
            nuevoButton.Visibility = Visibility.Collapsed;
            eliminarButton.Visibility = Visibility.Collapsed;

            HacerCamposEscritura();
        }
        private void OnCancelarButtonClick(object sender, RoutedEventArgs e)
        {
            Button guardarButton = GuardarButton;
            Button editarButton = EditarButton;
            Button cancelarButton = CancelarButton;
            Button nuevoButton = NuevoButton;
            Button eliminarButton = EliminarButton;

            guardarButton.Visibility = Visibility.Collapsed;
            cancelarButton.Visibility = Visibility.Collapsed;
            nuevoButton.Visibility = Visibility.Visible;
            

            if (Datagrid.SelectedItem != null)
            {
                eliminarButton.Visibility = Visibility.Visible;
                editarButton.Visibility = Visibility.Visible;
            }

            HacerCamposSoloLectura();
        }
        private void OnNuevoButtonClick(object sender, RoutedEventArgs e)
        {
            Button guardarButton = GuardarButton;
            Button editarButton = EditarButton;
            Button cancelarButton = CancelarButton;
            Button nuevoButton = NuevoButton;
            Button eliminarButton = EliminarButton;

            guardarButton.Visibility = Visibility.Visible;
            editarButton.Visibility = Visibility.Collapsed;
            cancelarButton.Visibility = Visibility.Visible;
            nuevoButton.Visibility = Visibility.Collapsed;
            eliminarButton.Visibility = Visibility.Collapsed;

            DepartamentoComboBox.SelectedItem = null;
            HacerCamposEscritura();
        }

        private void OnEliminarButtonClick(object sender, RoutedEventArgs e)
        {
            Button guardarButton = GuardarButton;
            Button editarButton = EditarButton;
            Button cancelarButton = CancelarButton;
            Button nuevoButton = NuevoButton;
            Button eliminarButton = EliminarButton;

            guardarButton.Visibility = Visibility.Collapsed;
            editarButton.Visibility = Visibility.Collapsed;
            cancelarButton.Visibility = Visibility.Collapsed;
            nuevoButton.Visibility = Visibility.Visible;
            eliminarButton.Visibility = Visibility.Collapsed;

            HacerCamposSoloLectura();
        }

        private void HacerCamposSoloLectura()
        {
            TextBox dniTextBox = DniTextBox;
            TextBox nombreTextBox = NombreTextBox;
            TextBox apellidosTextBox = ApellidosTextBox;
            TextBox puestoTextBox = PuestoTextBox;
            TextBox imagenTextBox = ImagenTextBox;
            ComboBox departamentoComboBox = DepartamentoComboBox;

            dniTextBox.IsReadOnly = true;
            nombreTextBox.IsReadOnly = true;
            apellidosTextBox.IsReadOnly = true;
            puestoTextBox.IsReadOnly = true;
            imagenTextBox.IsReadOnly = true;
            departamentoComboBox.IsEnabled = false;
        }

        private void HacerCamposEscritura()
        {
            TextBox dniTextBox = DniTextBox;
            TextBox nombreTextBox = NombreTextBox;
            TextBox apellidosTextBox = ApellidosTextBox;
            TextBox puestoTextBox = PuestoTextBox;
            TextBox imagenTextBox = ImagenTextBox;
            ComboBox departamentoComboBox = DepartamentoComboBox;

            dniTextBox.IsReadOnly = false;
            nombreTextBox.IsReadOnly = false;
            apellidosTextBox.IsReadOnly = false;
            puestoTextBox.IsReadOnly = false;
            imagenTextBox.IsReadOnly = false;
            departamentoComboBox.IsEnabled = true;
        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            GuardadoToast.Visibility = Visibility.Collapsed;
            CamposToast.Visibility = Visibility.Collapsed;
            timer.Stop();
        }

    }
}
