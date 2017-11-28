using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;

namespace Animation_25_09_17
{
    internal class KreisCreationOptions
    {
        public double Radius { get; set; }

        public Point LinksOben { get; set; }

        public Color KreisColor { get; set; }

        public KreisCreationOptions()
        {
            Radius = 30;
            KreisColor = Colors.Red;
            LinksOben = new Point(200, 200);
        }
    }

    internal class cKreis
    {
        private static int cId;

        public readonly int KreisId = cId++;

        private readonly KreisCreationOptions _options;

        private bool angezeigt;

        //Felder
        private readonly Ellipse fKreis;

        //Konstruktor
        public cKreis(KreisCreationOptions options = null)
        {
            _options = options ?? new KreisCreationOptions();
            fKreis = new Ellipse();
        }

        //Eigenschaften
        public Point LinksOben
        {
            get
            {
                return _options.LinksOben == default(Point)
                    ? (_options.LinksOben = new Point(0, 0))
                    : _options.LinksOben;
            }
            set
            {
                if (value.X >= 0 && value.Y >= 0)
                    _options.LinksOben = value;
                else
                    _options.LinksOben = new Point(0, 0);
            }
        }

        //Methoden
        public void Anzeigen(Canvas lw)
        {
            if (angezeigt) return;

            fKreis.Height = fKreis.Width = 2 * _options.Radius;
            fKreis.Fill = new SolidColorBrush(_options.KreisColor);

            Canvas.SetLeft(fKreis, _options.LinksOben.X);
            Canvas.SetTop(fKreis, _options.LinksOben.Y);

            lw.Children.Add(fKreis);

            angezeigt = true;
        }

        private void MoveAni(DependencyProperty property, double to)
        {
            var from = (property == Canvas.LeftProperty) ? _options.LinksOben.X : _options.LinksOben.Y;

            fKreis.BeginAnimation(property, new DoubleAnimation
            {
                Duration = TimeSpan.FromSeconds(1),
                From = from,
                To = to,
                AutoReverse = true, //Rückkehr zum Ausgangspunkt
                AccelerationRatio = 0.4, //Startbeschleunigung
                DecelerationRatio = 0.6, //Bremsung am Ende
                                         // FillBehavior = FillBehavior.Stop //Verhalten nach der Animation
                                         // RepeatBehavior = new RepeatBehavior(3), //Wiederholungen
            });

            //Rotating color
            fKreis.Fill.BeginAnimation(SolidColorBrush.ColorProperty, new ColorAnimation
            {
                Duration = TimeSpan.FromMilliseconds(500),
                From = Colors.Red,
                To = Colors.Blue,
                AutoReverse = true,
                RepeatBehavior = new RepeatBehavior(2),
                FillBehavior = FillBehavior.Stop
            });
        }

        #region MovingPlugins

        public void NachRechts()
        {
            RightLeftAni(_options.LinksOben.X + 200);
        }

        public void NachLinks()
        {
            RightLeftAni(_options.LinksOben.X - 200);
        }

        public void NachOben()
        {
            UpDownAni(_options.LinksOben.Y - 200);
        }

        public void NachUnten()
        {
            UpDownAni(_options.LinksOben.Y + 200);
        }

        private void RightLeftAni(double dstPos)
        {
            MoveAni(Canvas.LeftProperty, dstPos);
        }

        private void UpDownAni(double dstPos)
        {
            MoveAni(Canvas.TopProperty, dstPos);
        }

        #endregion MovingPlugins
    }
}