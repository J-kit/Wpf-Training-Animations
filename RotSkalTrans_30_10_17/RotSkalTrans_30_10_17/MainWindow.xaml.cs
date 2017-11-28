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
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace RotSkalTrans_30_10_17
{
    /// <summary>
    /// Interaktionslogik für MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private double dGeschwindigkeit = 1;

        public MainWindow()
        {
            InitializeComponent();
        }

        private void butStart_Click(object sender, RoutedEventArgs e)
        {
            var rot = new DoubleAnimation
            {
                Duration = TimeSpan.FromSeconds(dGeschwindigkeit),
                By = 360,
                AutoReverse = true
            };

            var skal = new DoubleAnimation
            {
                Duration = TimeSpan.FromSeconds(dGeschwindigkeit),
                From = 1,
                To = 2,
                AutoReverse = true
            };

            var tran = new DoubleAnimation
            {
                Duration = TimeSpan.FromSeconds(dGeschwindigkeit),
                From = 0,
                To = leinwand.ActualWidth - 150,
                AutoReverse = true
            };

            var rt = new RotateTransform
            {
                CenterX = rec.Width / 2,
                CenterY = rec.Height / 2
            };

            var st = new ScaleTransform
            {
                CenterX = rec.Width / 2,
                CenterY = rec.Height / 2
            };

            var tg = new TransformGroup();

            var tt = new TranslateTransform();

            tg.Children.Add(rt);
            tg.Children.Add(st);
            tg.Children.Add(tt);

            //Animationen anwenden
            st.BeginAnimation(ScaleTransform.ScaleXProperty, skal);
            st.BeginAnimation(ScaleTransform.ScaleYProperty, skal);

            rt.BeginAnimation(RotateTransform.AngleProperty, rot);

            tt.BeginAnimation(TranslateTransform.XProperty, tran);

            rec.RenderTransform = tg;
        }

        private void sliGeschwindigkeit_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            dGeschwindigkeit = sliGeschwindigkeit.Value;
        }
    }
}