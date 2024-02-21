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
using System.IO;
using Microsoft.Extensions.DependencyInjection;
using SharpCompress.Common;
using System.Windows;


namespace NavegacionLateralWPF.ViewModels
{
    internal class MainViewModel: ObservableObject
    {

        private readonly EmpleadoRepository _empleadoRepository;
        private readonly DepartamentoRepository _departamentoRepository;

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
        public DepartamentoViewModel DepartamentoViewModel { get; set; }
        public GraficaViewModel GraficaViewModel { get; set; }
        public SettingsViewModel SettingsViewModel { get; set; }
        public RelayCommand ActivateHomeViewCommand { get; set; }
        public RelayCommand ActivateEmpleadoViewCommand { get; set; }
        public RelayCommand ActivateDepartamentoViewCommand { get; set; }
        public RelayCommand ActivateGraficaViewCommand { get; set; }
        public RelayCommand ActivateSettingsViewCommand { get; set; }

        public RelayCommand SalirButtonCommand { get; set; }

        public MainViewModel()
        {

            HomeViewModel = new HomeViewModel();
            EmpleadoViewModel = new EmpleadoViewModel();
            DepartamentoViewModel = new DepartamentoViewModel();
            GraficaViewModel = new GraficaViewModel();
            SettingsViewModel = new SettingsViewModel();

            _activeView = HomeViewModel;

            ActivateHomeViewCommand = new RelayCommand(o => ActiveView = HomeViewModel);
            ActivateEmpleadoViewCommand = new RelayCommand(o => ActiveView = EmpleadoViewModel);
            ActivateDepartamentoViewCommand = new RelayCommand(o => ActiveView = DepartamentoViewModel);
            ActivateGraficaViewCommand = new RelayCommand(o => ActiveView = GraficaViewModel);
            ActivateSettingsViewCommand = new RelayCommand(o => ActiveView = SettingsViewModel);

            SalirButtonCommand = new RelayCommand(Salir);

            _empleadoRepository = App.Current.Services.GetService<EmpleadoRepository>();
            _departamentoRepository = App.Current.Services.GetService<DepartamentoRepository>();
            LeerDatos();
        }

        private void LeerDatos()
        {
            string filePathEmpleados = "Datos/empleados.txt";
            string filePathDepartamentos = "Datos/departamentos.txt";

            using (StreamReader reader = new StreamReader(filePathDepartamentos))
            {
                string line;
                while ((line = reader.ReadLine()) != null)
                {
                    string[] parts = line.Split(';');

                    Departamento departamento = new Departamento(parts[0], parts[1]);

                    _departamentoRepository.Registrar(departamento);
                }
            }

            using (StreamReader reader = new StreamReader(filePathEmpleados))
            {
                string line;
                while ((line = reader.ReadLine()) != null)
                {
                    string[] parts = line.Split(';');

                    Empleado empleado = new Empleado(parts[0], parts[1], parts[2], parts[3], parts[4], _departamentoRepository.GetById(parts[5]));
                    _empleadoRepository.Registrar(empleado);
                }
            }
        }

        private void GuardarDatos()
        {

            string relativePathEmpleados = "Datos/empleados.txt";
            string relativePathDepartamentos = "Datos/departamentos.txt";

            string filePathEmpleados = Path.GetFullPath(relativePathEmpleados);
            string filePathDepartamentos = Path.GetFullPath(relativePathDepartamentos);

            List<Empleado> empleados = _empleadoRepository.ListarTodos();
            List<Departamento> departamentos = _departamentoRepository.ListarTodos();

            using (StreamWriter writer = new StreamWriter(filePathEmpleados, false, Encoding.UTF8))
            {
                foreach (Empleado empleado in empleados)
                {
                    writer.WriteLine($"{empleado.Dni};{empleado.Nombre};{empleado.Apellidos};{empleado.Puesto};{empleado.UrlImagen};{empleado.Departamento.Id}");
                }
            }

            using (StreamWriter writer = new StreamWriter(filePathDepartamentos, false, Encoding.UTF8))
            {
                foreach (Departamento departamento in departamentos)
                {
                    writer.WriteLine($"{departamento.Id};{departamento.Name}");
                }
            }
        }

        private void Salir(object? obj)
        {

            GuardarDatos();

            Application.Current.Shutdown();

        }



    }
}
