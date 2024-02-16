﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace NavegacionLateralWPF.Views
{
    /// <summary>
    /// Lógica de interacción para MainView.xaml
    /// </summary>
    public partial class MainView : Window
    {
        public MainView()
        {
            LanguageManager.ChangeLanguage(Properties.Settings.Default.Idioma);
            InitializeComponent();
            this.WindowState = WindowState.Maximized;
        }

        private void OnExitButtonClick(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }

    }
}
