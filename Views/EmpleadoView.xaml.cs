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

namespace NavegacionLateralWPF.Views
{
    /// <summary>
    /// Lógica de interacción para EmpleadoView.xaml
    /// </summary>
    public partial class EmpleadoView : UserControl
    {

        public EmpleadoView()
        {
            InitializeComponent();
            this.DataContext = App.Current.Services.GetService<EmpleadoViewModel>();
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

        //private void SeleccionCambiada(object sender, SelectionChangedEventArgs e)
        //{

        //    ComboBox departamentoComboBox = DepartamentoComboBox;

        //    if (e.AddedItems.Count > 0)
        //    {
        //        Empleado? empleadoSeleccionado = e.AddedItems[0] as Empleado;

        //        if (empleadoSeleccionado != null)
        //        {
        //            (DataContext as EmpleadoViewModel)?.SeleccionarEmpleado(empleadoSeleccionado);

        //            //var nombresDepartamentos = DepartamentoComboBox.Items.Cast<Departamento>().Select(departamento => departamento.Name).ToList();
        //            //int index = nombresDepartamentos.IndexOf(empleadoSeleccionado.Departamento.Name);
        //            //departamentoComboBox.SelectedIndex = index;

        //        }
        //    }
        //}

        private void OnGuardarButtonClick(object sender, RoutedEventArgs e) 
        {
            Button guardarButton = GuardarButton;
            Button editarButton = EditarButton;

            if (guardarButton != null)
            {
                guardarButton.Visibility = Visibility.Collapsed;
            }
            if (editarButton != null)
            {
                editarButton.Visibility = Visibility.Visible;
            }
        }

        private void OnEditarButtonClick(object sender, RoutedEventArgs e)
        {
            Button guardarButton = GuardarButton;
            Button editarButton = EditarButton;

            if (guardarButton != null)
            {
                guardarButton.Visibility = Visibility.Visible;
            }
            if (editarButton != null)
            {
                editarButton.Visibility = Visibility.Collapsed;
            }
        }

    }
}
