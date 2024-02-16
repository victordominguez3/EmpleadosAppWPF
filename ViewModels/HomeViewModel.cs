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

        [ObservableProperty]
        private ObservableCollection<Empleado> empleados;

        public HomeViewModel()
        {
            _empleadoRepository = App.Current.Services.GetService<EmpleadoRepository>();
            LoadEmpleados();
        }

        private void LoadEmpleados()
        {
            empleados = new ObservableCollection<Empleado>(_empleadoRepository.ListarTodos());
        }
    }
}
