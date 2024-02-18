using LiveCharts.Wpf;
using LiveCharts;
using System;
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
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Media.Animation;

namespace NavegacionLateralWPF.Views
{
    /// <summary>
    /// Lógica de interacción para GraficaView.xaml
    /// </summary>
    public partial class GraficaView : UserControl
    {
        public GraficaView()
        {
            InitializeComponent();
        }

        private void GraficaView_Loaded(object sender, RoutedEventArgs e)
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

    }
}
