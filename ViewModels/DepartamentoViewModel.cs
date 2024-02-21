using CommunityToolkit.Mvvm.ComponentModel;
using Microsoft.Extensions.DependencyInjection;
using NavegacionLateralWPF.Models;
using NavegacionLateralWPF.Repositories;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NavegacionLateralWPF.Core;
using System.Windows;
using NavegacionLateralWPF.WindowDialogs;

namespace NavegacionLateralWPF.ViewModels
{
    partial class DepartamentoViewModel : ObservableObject
    {

        private readonly EmpleadoRepository _empleadoRepository;
        private readonly DepartamentoRepository _departamentoRepository;

        [ObservableProperty]
        private ObservableCollection<Empleado> empleados;

        [ObservableProperty]
        private ObservableCollection<Departamento> departamentos;

        public RelayCommand EliminarDepartamentoCommand { get; set; }
        public RelayCommand EditarDepartamentoCommand { get; set; }
        public RelayCommand NuevoButtonCommand { get; set; }

        public DepartamentoViewModel()
        {
            _empleadoRepository = App.Current.Services.GetService<EmpleadoRepository>();
            _departamentoRepository = App.Current.Services.GetService<DepartamentoRepository>();
            LoadData();
            EliminarDepartamentoCommand = new RelayCommand(EliminarDepartamento);
            EditarDepartamentoCommand = new RelayCommand(EditarDepartamento);
            NuevoButtonCommand = new RelayCommand(NuevoDepartamento);
        }

        private void LoadData()
        {
            Empleados = new ObservableCollection<Empleado>(_empleadoRepository.ListarTodos());
            Departamentos = new ObservableCollection<Departamento>(_departamentoRepository.ListarTodos());
        }

        private void EliminarDepartamento(object? obj)
        {
            Departamento departamento = obj as Departamento;
            if (departamento != null)
            {
                if (_empleadoRepository.ListarTodos().Where(e => e.Departamento.Id == departamento.Id).Count() > 0)
                {
                    MessageBoxResult result = MessageBox.Show("El departamento " + departamento.Name + " tiene empleados asociados. ¿Desea eliminar el departamento y todos sus empleados?", "Eliminar", MessageBoxButton.YesNo, MessageBoxImage.Warning);
                    if (result == MessageBoxResult.Yes)
                    {
                        List<Empleado> empleadosDepa = _empleadoRepository.ListarTodos().Where(e => e.Departamento.Id == departamento.Id).ToList();

                        foreach (var empleado in empleadosDepa)
                        {
                            _empleadoRepository.Eliminar(empleado);
                        }

                        _departamentoRepository.Eliminar(departamento);
                    }
                } else
                {
                    MessageBoxResult result = MessageBox.Show("¿Desea eliminar el departamento " + departamento.Name + "?", "Eliminar", MessageBoxButton.YesNo, MessageBoxImage.Warning);
                    if(result == MessageBoxResult.Yes)
                    {
                        _departamentoRepository.Eliminar(departamento);
                    }
                }

                LoadData();
                
            }
        }

        private void EditarDepartamento(object? obj)
        {
            Departamento departamento = obj as Departamento;
            if (departamento != null)
            {
                var dialog = new EditarDepartamentoDialog();
                dialog.NombreTextBox.Text = departamento.Name;
                dialog.Show();

                dialog.Closed += (sender, e) =>
                {
                    if (dialog.DialogResult == true)
                    {
                        departamento.Name = dialog.NombreDepartamento;
                        _departamentoRepository.Registrar(departamento);
                        LoadData();
                    }
                };
            }
        }

        private void NuevoDepartamento(object? obj)
        {
            var dialog = new DepartamentoDialog();
            dialog.Show();

            dialog.Closed += (sender, e) =>
            {
                if (dialog.DialogResult == true)
                {
                    Departamento departamento = new Departamento(dialog.IdDepartamento, dialog.NombreDepartamento);
                    _departamentoRepository.Registrar(departamento);
                    LoadData();
                }
            };

        }
    }
}
