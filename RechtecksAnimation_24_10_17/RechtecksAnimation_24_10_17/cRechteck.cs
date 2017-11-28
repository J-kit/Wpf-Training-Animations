using System;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;

namespace RechtecksAnimation_24_10_17
{
    internal class cRechteck
    {
        //Felder
        private double fBreite, fHöhe;

        private Rectangle rec;

        //Konstruktor
        public cRechteck(Canvas cv)
        {
            fBreite = 70;
            fHöhe = 50;

            rec = new Rectangle
            {
                Width = fBreite,
                Height = fHöhe,
                Fill = new SolidColorBrush(Colors.Red)
            };

            cv.Children.Add(rec);
        }

        public void Animieren(Canvas cv)
        {
            var tg = new TransformGroup();
            var tt1 = new TranslateTransform();
            var tt2 = new TranslateTransform();
            var tt3 = new TranslateTransform();
            var tt4 = new TranslateTransform();

            var da1 = new DoubleAnimation
            {
                From = 0,
                To = cv.ActualWidth - fBreite,
                Duration = TimeSpan.FromSeconds(1),
                BeginTime = TimeSpan.FromSeconds(0)
            };

            var da2 = new DoubleAnimation
            {
                From = 0,
                To = cv.ActualHeight - fHöhe,
                Duration = TimeSpan.FromSeconds(1),
                BeginTime = TimeSpan.FromSeconds(1)
            };

            var da3 = new DoubleAnimation
            {
                From = 0,
                To = -(cv.ActualWidth - fBreite),
                Duration = TimeSpan.FromSeconds(1),
                BeginTime = TimeSpan.FromSeconds(2)
            };

            var da4 = new DoubleAnimation
            {
                From = 0,
                To = -(cv.ActualHeight - fHöhe),
                Duration = TimeSpan.FromSeconds(1),
                BeginTime = TimeSpan.FromSeconds(3)
            };

            tg.Children.Add(tt1);
            tg.Children.Add(tt2);
            tg.Children.Add(tt3);
            tg.Children.Add(tt4);

            tt1.BeginAnimation(TranslateTransform.XProperty, da1);
            tt2.BeginAnimation(TranslateTransform.YProperty, da2);

            tt3.BeginAnimation(TranslateTransform.XProperty, da3);
            tt4.BeginAnimation(TranslateTransform.YProperty, da4);

            rec.RenderTransform = tg;
        }
    }
}