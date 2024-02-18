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
using LiveCharts;
using LiveCharts.Wpf;
using LiveCharts.Defaults;

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

        [ObservableProperty]
        public SeriesCollection _pieSeries;

        [ObservableProperty]
        public SeriesCollection _barSeries;

        [ObservableProperty]
        public string[] _labels;

        public GraficaViewModel()
        {
            _empleadoRepository = App.Current.Services.GetService<EmpleadoRepository>();
            _departamentoRepository = App.Current.Services.GetService<DepartamentoRepository>();

            _empleados = new ObservableCollection<Empleado>(_empleadoRepository.ListarTodos());
            _departamentos = new ObservableCollection<Departamento>(_departamentoRepository.ListarTodos());

            ConfigurePieSeries();
            ConfigureBarSeries();
        }

        private void ConfigurePieSeries()
        {
            PieSeries = new SeriesCollection();

            foreach (var departamento in _departamentos)
            {
                PieSeries.Add(new PieSeries 
                { 
                    Values = new ChartValues<ObservableValue> { new ObservableValue(_empleados.Where(e => e.Departamento.Id == departamento.Id).Count()) },
                    Title = departamento.Name, DataLabels = true,
                    LabelPoint = chartPoint =>
                    {
                        return $"{chartPoint.SeriesView.Title} ({chartPoint.Participation:P2})";
                    }
                });
            }
        }

        private void ConfigureBarSeries()
        {
            BarSeries = new SeriesCollection();
            Labels = [];

            foreach (var departamento in _departamentos)
            {
                BarSeries.Add(new ColumnSeries
                {
                    Values = new ChartValues<ObservableValue> { new ObservableValue(_empleados.Where(e => e.Departamento.Id == departamento.Id).Count()) },
                    Title = departamento.Name
                });
            }
        }

    }
}
