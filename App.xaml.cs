using NavegacionLateralWPF.ViewModels;
using System.Configuration;
using System.Data;
using System.Windows;
using System;
using Microsoft.Extensions.DependencyInjection;
using NavegacionLateralWPF.Repositories;

namespace NavegacionLateralWPF
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    ///

    public partial class App : Application
    {
        public new static App Current => (App)Application.Current;
        public IServiceProvider Services { get; }

        public App()
        {
            Services = ConfigureServices();
        }

        private static IServiceProvider ConfigureServices()
        {
            var services = new ServiceCollection();

            // Services
            services.AddSingleton<DepartamentoRepository>();
            services.AddSingleton<EmpleadoRepository>();

            // ViewModels
            services.AddTransient<HomeViewModel>();
            services.AddTransient<EmpleadoViewModel>();
            services.AddTransient<GraficaViewModel>();
            services.AddTransient<MainViewModel>();
            services.AddTransient<SettingsViewModel>();

            return services.BuildServiceProvider();
        }

    }

}
