using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media.Animation;
using System.Windows;
using NavegacionLateralWPF.Core;
using System.Windows.Controls;
using NavegacionLateralWPF.Models;
using NavegacionLateralWPF.Repositories;
using System.Collections.ObjectModel;
using CommunityToolkit.Mvvm.ComponentModel;
using Microsoft.Extensions.DependencyInjection;

namespace NavegacionLateralWPF.ViewModels
{
    internal partial class HomeViewModel: ObservableObject
    {
        private readonly EmpleadoRepository _empleadoRepository;
        private readonly DepartamentoRepository _departamentoRepository;

        [ObservableProperty]
        private ObservableCollection<Empleado> empleados;

        [ObservableProperty]
        private ObservableCollection<Departamento> departamentos;

        public HomeViewModel()
        {
            _empleadoRepository = App.Current.Services.GetService<EmpleadoRepository>();
            _departamentoRepository = App.Current.Services.GetService<DepartamentoRepository>();
            LoadData();
        }

        private void LoadData()
        {
            empleados = new ObservableCollection<Empleado>(_empleadoRepository.ListarTodos());
            departamentos = new ObservableCollection<Departamento>(_departamentoRepository.ListarTodos());
        }
    }
}
