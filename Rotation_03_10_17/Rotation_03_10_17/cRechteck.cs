using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;

namespace Rotation_03_10_17
{
    internal class CRechteck
    {
        //Felder
        private readonly double _fBreite, _fHöhe;

        private readonly Point _fMittelpunkt;

        private readonly Rectangle _rec1, _rec2;

        //Konstruktor
        public CRechteck(Canvas lw = null)
        {
            _fBreite = 100;
            _fHöhe = 50;

            _fMittelpunkt = new Point(150, 150);

            _rec1 = new Rectangle
            {
                Width = _fBreite,
                Height = _fHöhe,
                Fill = new SolidColorBrush(Colors.Red)
            };

            _rec2 = new Rectangle
            {
                Height = 5,
                Width = 5,
                Fill = new SolidColorBrush(Colors.Blue)
            };

            if (lw != null) Anzeigen(lw);
        }

        public void Anzeigen(Canvas lw)
        {
            Canvas.SetLeft(_rec1, _fMittelpunkt.X - _fBreite / 2);
            Canvas.SetTop(_rec1, _fMittelpunkt.Y - _fHöhe / 2);

            Canvas.SetLeft(_rec2, _fMittelpunkt.X - _fBreite / 2);
            Canvas.SetTop(_rec2, _fMittelpunkt.Y - _fHöhe / 2);

            lw.Children.Add(_rec1);
            lw.Children.Add(_rec2);
        }

        public void Rotieren(double faktorHorizontal, double faktorVertikal)
        {
            var rt = new RotateTransform
            {
                CenterX = _rec1.Width * faktorHorizontal,
                CenterY = _rec1.Height * faktorVertikal
            };

            //Zuordnung an die entsprechenden Elemente
            _rec1.RenderTransform = rt;
            _rec2.RenderTransform = rt;

            //Animieren der Rotation
            //Zentrum der Rotation festlegen
            rt.BeginAnimation(RotateTransform.AngleProperty, new DoubleAnimation
            {
                Duration = TimeSpan.FromSeconds(1),
                From = 0,
                To = 360
            });
        }
    }
}