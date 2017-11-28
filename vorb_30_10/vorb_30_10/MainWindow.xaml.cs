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

namespace vorb_30_10
{
    /// <summary>
    /// Interaktionslogik für MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private TransformGroup tg;
        private RotateTransform rt;
        private TranslateTransform tt;
        private ScaleTransform sc;

        public MainWindow()
        {
            InitializeComponent();

            tg = new TransformGroup();
            rt = new RotateTransform();
            tt = new TranslateTransform();
            sc = new ScaleTransform();

            tg.Children.Add(rt);
            tg.Children.Add(sc);
            tg.Children.Add(tt);

            rt.CenterX = rec.Width / 2;
            rt.CenterY = rec.Height / 2;
            sc.CenterX = rec.Width / 2;
            sc.CenterY = rec.Height / 2;
        }

        private void button_Click(object sender, RoutedEventArgs e)
        {
            var da = new DoubleAnimation
            {
                Duration = TimeSpan.FromSeconds(1),
                From = 0,
                To = 360,
                AutoReverse = true
            };

            var da2 = new DoubleAnimation
            {
                Duration = TimeSpan.FromSeconds(1),
                From = 1,
                To = 2,
                AutoReverse = true
            };

            rt.BeginAnimation(RotateTransform.AngleProperty, da);
            tt.BeginAnimation(TranslateTransform.XProperty, da);

            sc.BeginAnimation(ScaleTransform.ScaleXProperty, da2);
            sc.BeginAnimation(ScaleTransform.ScaleYProperty, da2);

            rec.RenderTransform = tg;
        }
    }
}