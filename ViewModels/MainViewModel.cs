using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;
using System.Windows.Media;
using NavegacionLateralWPF.Core;
using NavegacionLateralWPF.Models;
using NavegacionLateralWPF.Repositories;
using CommunityToolkit.Mvvm.ComponentModel;


namespace NavegacionLateralWPF.ViewModels
{
    internal class MainViewModel: ObservableObject
    {

        private object _activeView;

        public object ActiveView
        {
            get { return _activeView; }
            set
            {
                _activeView = value;
                OnPropertyChanged();
            }
        }

        public HomeViewModel HomeViewModel { get; set; }
        public EmpleadoViewModel EmpleadoViewModel { get; set; }
        public GraficaViewModel GraficaViewModel { get; set; }
        public SettingsViewModel SettingsViewModel { get; set; }
        public RelayCommand ActivateHomeViewCommand { get; set; }
        public RelayCommand ActivateEmpleadoViewCommand { get; set; }
        public RelayCommand ActivateGraficaViewCommand { get; set; }
        public RelayCommand ActivateSettingsViewCommand { get; set; }

        public MainViewModel()
        {
            HomeViewModel = new HomeViewModel();
            EmpleadoViewModel = new EmpleadoViewModel();
            GraficaViewModel = new GraficaViewModel();
            SettingsViewModel = new SettingsViewModel();

            _activeView = HomeViewModel;

            ActivateHomeViewCommand = new RelayCommand(o => ActiveView = HomeViewModel);
            ActivateEmpleadoViewCommand = new RelayCommand(o => ActiveView = EmpleadoViewModel);
            ActivateGraficaViewCommand = new RelayCommand(o => ActiveView = GraficaViewModel);
            ActivateSettingsViewCommand = new RelayCommand(o => ActiveView = SettingsViewModel);
        }

    }
}
