﻿using CommunityToolkit.Mvvm.ComponentModel;
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

namespace NavegacionLateralWPF.ViewModels
{
    internal partial class EmpleadoViewModel: ObservableObject
    {
        private readonly EmpleadoRepository _empleadoRepository;
        private readonly DepartamentoRepository _departamentoRepository;

        [ObservableProperty]
        private ObservableCollection<Empleado> _empleados;

        [ObservableProperty]
        private ObservableCollection<string> _departamentos;

        private Empleado? _empleadoSeleccionado;
        public Empleado? EmpleadoSeleccionado
        {
            get { return _empleadoSeleccionado; }
            set
            {
                if (_empleadoSeleccionado != value)
                {
                    _empleadoSeleccionado = value;
                    if (_empleadoSeleccionado != null)
                    {
                        CambiarVariables(_empleadoSeleccionado);
                    }
                    OnPropertyChanged(nameof(EmpleadoSeleccionado));
                }
            }
        }

        private string _empleadoDni;
        private string _empleadoNombre;
        private string _empleadoApellidos;
        private string _empleadoPuesto;
        private string _empleadoUrlImagen;
        private string _empleadoDepartamento;

        public string EmpleadoDni
        {
            get { return _empleadoDni; }
            set
            {
                if (_empleadoDni != value)
                {
                    _empleadoDni = value;
                    OnPropertyChanged(nameof(EmpleadoDni));
                }
            }
        }

        public string EmpleadoNombre
        {
            get { return _empleadoNombre; }
            set
            {
                if (_empleadoNombre != value)
                {
                    _empleadoNombre = value;
                    OnPropertyChanged(nameof(EmpleadoNombre));
                }
            }
        }

        public string EmpleadoApellidos
        {
            get { return _empleadoApellidos; }
            set
            {
                if (_empleadoApellidos != value)
                {
                    _empleadoApellidos = value;
                    OnPropertyChanged(nameof(EmpleadoApellidos));
                }
            }
        }

        public string EmpleadoPuesto
        {
            get { return _empleadoPuesto; }
            set
            {
                if (_empleadoPuesto != value)
                {
                    _empleadoPuesto = value;
                    OnPropertyChanged(nameof(EmpleadoPuesto));
                }
            }
        }

        public string EmpleadoUrlImagen
        {
            get { return _empleadoUrlImagen; }
            set
            {
                if (_empleadoUrlImagen != value)
                {
                    _empleadoUrlImagen = value;
                    OnPropertyChanged(nameof(EmpleadoUrlImagen));
                }
            }
        }

        public string EmpleadoDepartamento
        {
            get { return _empleadoDepartamento; }
            set
            {
                if (_empleadoDepartamento != value)
                {
                    _empleadoDepartamento = value;
                    OnPropertyChanged(nameof(EmpleadoDepartamento));
                }
            }
        }

        public RelayCommand GuardarButtonCommand { get; set; }
        public RelayCommand EditarButtonCommand { get; set; }

        public EmpleadoViewModel()
        {
            _empleadoRepository = App.Current.Services.GetService<EmpleadoRepository>();
            _departamentoRepository = App.Current.Services.GetService<DepartamentoRepository>();
            Empleados = new ObservableCollection<Empleado>();
            GuardarButtonCommand = new RelayCommand(GuardarEmpleado);
            LoadData();
        }

        private void LoadData()
        {
            var newEmpleados = _empleadoRepository.ListarTodos();
            Empleados.Clear();
            foreach (var empleado in newEmpleados)
            {
                Empleados.Add(empleado);
            }

            Departamentos = new ObservableCollection<string>(_departamentoRepository.ListarTodos().Select(o => o.Name));
        }

        private void CambiarVariables(Empleado empleadoSeleccionado)
        {
            EmpleadoDni = empleadoSeleccionado.Dni;
            EmpleadoNombre = empleadoSeleccionado.Nombre;
            EmpleadoApellidos = empleadoSeleccionado.Apellidos;
            EmpleadoPuesto = empleadoSeleccionado.Puesto;
            EmpleadoUrlImagen = empleadoSeleccionado.UrlImagen;
            EmpleadoDepartamento = empleadoSeleccionado.Departamento.Name;
        }

        public void SeleccionarEmpleado(Empleado empleado)
        {
            EmpleadoSeleccionado = empleado;
        }

        private void GuardarEmpleado(object? obj)
        {
            Departamento? departamento = _departamentoRepository.ListarTodos().Find(o => o.Name == _empleadoDepartamento);
            _empleadoRepository.Registrar(new Empleado(_empleadoDni, _empleadoNombre, _empleadoApellidos, _empleadoPuesto, _empleadoUrlImagen, departamento));
            LoadData();
        }

    }
}
