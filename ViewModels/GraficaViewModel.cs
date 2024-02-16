using CommunityToolkit.Mvvm.ComponentModel;
using Microsoft.Extensions.DependencyInjection;
using MongoDB.Driver.Core.Servers;
using NavegacionLateralWPF.Models;
using NavegacionLateralWPF.Repositories;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NavegacionLateralWPF.ViewModels
{
    partial class GraficaViewModel: ObservableObject
    {
        private readonly EmpleadoRepository _empleadoRepository;
        private readonly DepartamentoRepository _departamentoRepository;

        [ObservableProperty]
        private ObservableCollection<Empleado> _empleados;
        [ObservableProperty]
        private ObservableCollection<Departamento> _departamentos;

        public GraficaViewModel()
        {
            _empleadoRepository = App.Current.Services.GetService<EmpleadoRepository>();
            _departamentoRepository = App.Current.Services.GetService<DepartamentoRepository>();

            _empleados = new ObservableCollection<Empleado>(_empleadoRepository.ListarTodos());
            _departamentos = new ObservableCollection<Departamento>(_departamentoRepository.ListarTodos());

            ConfigurePieSeries();
        }

        private void ConfigurePieSeries()
        {
            
        }

    }
}
