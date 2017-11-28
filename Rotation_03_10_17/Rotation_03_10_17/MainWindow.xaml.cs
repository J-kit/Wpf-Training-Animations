using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Shapes;

namespace Rotation_03_10_17
{
    /// <summary>
    /// Interaktionslogik für MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private double _dFHori, _dFVert;
        private readonly CRechteck _oRec;
        private readonly Ellipse _ell;

        public MainWindow()
        {
            InitializeComponent();
            _oRec = new CRechteck(leinwand);
            _ell = new Ellipse
            {
                Width = 6,
                Height = 6,
                Fill = new SolidColorBrush(Colors.Green)
            };

            //Kreis positionieren
            Canvas.SetLeft(_ell, 100 + _dFHori * 100 - 3);
            Canvas.SetTop(_ell, 125 + _dFVert * 50 - 3);

            leinwand.Children.Add(_ell);
        }

        private void butRotation_Click(object sender, RoutedEventArgs e)
        {
            _oRec.Rotieren(_dFHori, _dFVert);
        }

        private void rbtLinks_Checked(object sender, RoutedEventArgs e) => SetHori(0);

        private void rbtMitte_Checked(object sender, RoutedEventArgs e) => SetHori(0.5);

        private void rbtRechts_Checked(object sender, RoutedEventArgs e) => SetHori(1);

        private void rbtOben_Checked(object sender, RoutedEventArgs e) => SetVert(0);

        private void rbtMitte2_Checked(object sender, RoutedEventArgs e) => SetVert(0.5);

        private void rbtUnten_Checked(object sender, RoutedEventArgs e) => SetVert(1);

        private void slivertikal_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            SetVert(slivertikal.Value / 50);
        }

        private void sliHorizontal_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            if (_ell == null) return;

            SetHori(sliHorizontal.Value / 100);
        }

        private void SetHori(double dfHori)
        {
            if (_ell == null) return;

            _dFHori = dfHori;
            Canvas.SetLeft(_ell, 100 + _dFHori * 100 - 3);
        }

        private void SetVert(double dfVert)
        {
            if (_ell == null) return;

            _dFVert = dfVert;
            Canvas.SetTop(_ell, 125 + _dFVert * 50 - 3);
        }
    }
}