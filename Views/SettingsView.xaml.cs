using NavegacionLateralWPF.ViewModels;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace NavegacionLateralWPF.Views
{
    /// <summary>
    /// Lógica de interacción para SettingsView.xaml
    /// </summary>
    public partial class SettingsView : UserControl
    {

        public SettingsView()
        {
            InitializeComponent();
            string languageCode = Thread.CurrentThread.CurrentCulture.TwoLetterISOLanguageName;
            if (languageCode == "es")
            {
                EspButton.IsChecked = true;
            } else EngButton.IsChecked = true;
        }

        private void HomeView_Loaded(object sender, RoutedEventArgs e)
        {
            var floatInAnimation = (Storyboard)FindResource("FloatInAnimation");
            var fadeInAnimation = (Storyboard)FindResource("FadeInAnimation");

            if (floatInAnimation != null && fadeInAnimation != null)
            {
                var translateYTransform = new TranslateTransform();
                mainPanel.RenderTransform = translateYTransform;

                Storyboard.SetTarget(floatInAnimation, mainPanel);
                Storyboard.SetTarget(fadeInAnimation, mainPanel);
                floatInAnimation.Begin();
                fadeInAnimation.Begin();
            }
        }

        private void OnEspButtonClick(object sender, RoutedEventArgs e)
        {
            if (Properties.Settings.Default.Idioma != "es")
            {
                LanguageManager.ChangeLanguage("es");
                Properties.Settings.Default.Idioma = "es";
                Properties.Settings.Default.Save();
                UpdateUI();
            }
        }

        private void OnEngButtonClick(object sender, RoutedEventArgs e)
        {
            if (Properties.Settings.Default.Idioma != "en")
            {
                LanguageManager.ChangeLanguage("en");
                Properties.Settings.Default.Idioma = "en";
                Properties.Settings.Default.Save();
                UpdateUI();
            }
        }

        private void UpdateUI()
        {
            Application.Current.Shutdown();
            Process.Start(Process.GetCurrentProcess().MainModule.FileName);
        }

    }
}
