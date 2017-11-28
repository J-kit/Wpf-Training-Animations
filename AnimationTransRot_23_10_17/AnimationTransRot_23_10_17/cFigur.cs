using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;

namespace AnimationTransRot_23_10_17
{
    internal class CFigur
    {
        //Felder
        private double fSeite = 100;

        private Point fLinksoben;
        private TranslateTransform tt;
        private RotateTransform rt1, rt2, rt3;
        private TransformGroup tg1, tg2, tg3;
        private Rectangle rec1, rec2;
        private Ellipse ell;

        private bool _blnOben = true;

        //Konstruktor
        public CFigur(Canvas cv)
        {
            fLinksoben = new Point(50, 100);

            ell = new Ellipse
            {
                Width = fSeite,
                Height = fSeite,
                Fill = new SolidColorBrush(Colors.Red)
            };

            rec1 = new Rectangle
            {
                Width = fSeite,
                Height = fSeite,
                Fill = new SolidColorBrush(Colors.Red)
            };

            rec2 = new Rectangle
            {
                Width = fSeite - 20,
                Height = fSeite - 20,
                Fill = new SolidColorBrush(Colors.Blue)
            };

            tt = new TranslateTransform();

            rt1 = new RotateTransform();
            rt2 = new RotateTransform();
            rt3 = new RotateTransform();

            tg1 = new TransformGroup();
            tg2 = new TransformGroup();
            tg3 = new TransformGroup();

            tg1.Children.Add(rt1);
            tg1.Children.Add(tt);

            tg2.Children.Add(rt2);
            tg2.Children.Add(tt);

            tg3.Children.Add(rt3);
            tg3.Children.Add(tt);

            Canvas.SetLeft(rec1, fLinksoben.X);
            Canvas.SetTop(rec1, fLinksoben.Y);

            Canvas.SetLeft(ell, fLinksoben.X);
            Canvas.SetTop(ell, fLinksoben.Y - fSeite / 2);

            Canvas.SetLeft(rec2, fLinksoben.X + 10);
            Canvas.SetTop(rec2, fLinksoben.Y);

            cv.Children.Add(ell);

            cv.Children.Add(rec1);
            cv.Children.Add(rec2);
        }

        public void Animieren(Canvas cv)
        {
            var da1 = new DoubleAnimation
            {
                Duration = TimeSpan.FromSeconds(2),
                From = 0,
                To = cv.ActualWidth - fSeite - fLinksoben.X,
                AutoReverse = true
            };

            var da2 = new DoubleAnimation
            {
                Duration = TimeSpan.FromSeconds(0.25),
                By = 180,
                BeginTime = TimeSpan.FromSeconds(1)
            };

            rec1.RenderTransform = tg1;
            rec2.RenderTransform = tg2;

            ell.RenderTransform = tg3;

            rt1.CenterX = fSeite / 2;
            rt1.CenterY = fSeite / 2;

            rt2.CenterX = fSeite / 2 - 10;
            rt2.CenterY = fSeite / 2;

            rt3.CenterX = fSeite / 2;
            rt3.CenterY = fSeite;

            tt.BeginAnimation(TranslateTransform.XProperty, da1);
            rt1.BeginAnimation(RotateTransform.AngleProperty, da2);
            rt2.BeginAnimation(RotateTransform.AngleProperty, da2);
            rt3.BeginAnimation(RotateTransform.AngleProperty, da2);

            InvertOben();
        }

        public void Animieren2(Canvas cv)
        {
            var da1 = new DoubleAnimation
            {
                Duration = TimeSpan.FromSeconds(2),
                From = 0,
                AutoReverse = true
            };

            var da2 = new DoubleAnimation
            {
                Duration = TimeSpan.FromSeconds(0.25),
                By = 180,
                BeginTime = TimeSpan.FromSeconds(1)
            };

            if (InvertOben())
                da1.To = cv.ActualHeight - fSeite - fLinksoben.Y;
            else
                da1.To = cv.ActualHeight - 3 * fSeite / 2 - fLinksoben.Y;

            rt1.CenterX = fSeite / 2;
            rt1.CenterY = fSeite / 2;

            rt2.CenterX = fSeite / 2 - 10;
            rt2.CenterY = fSeite / 2;

            rt3.CenterX = fSeite / 2;
            rt3.CenterY = fSeite;

            rec1.RenderTransform = tg1;
            rec2.RenderTransform = tg2;

            ell.RenderTransform = tg3;

            tt.BeginAnimation(TranslateTransform.YProperty, da1);
            rt1.BeginAnimation(RotateTransform.AngleProperty, da2);
            rt2.BeginAnimation(RotateTransform.AngleProperty, da2);
            rt3.BeginAnimation(RotateTransform.AngleProperty, da2);
        }

        private bool InvertOben()
        {
            return _blnOben = !_blnOben;
        }
    }
}