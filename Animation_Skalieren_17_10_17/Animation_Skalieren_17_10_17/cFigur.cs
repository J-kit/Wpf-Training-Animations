using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;

namespace Animation_Skalieren_17_10_17
{
    internal class CFigur
    {
        private readonly Ellipse _fEll;
        private readonly Rectangle _fRec;

        //Konstruktor
        public CFigur(Canvas cw)
        {
            var fLinksOben = new Point(150, 150);

            _fRec = new Rectangle
            {
                Width = 100,
                Height = 50,
                Fill = new SolidColorBrush(Colors.Blue)
            };

            _fEll = new Ellipse
            {
                Width = 100,
                Height = 50,
                Fill = new SolidColorBrush(Colors.Red)
            };

            //positionieren
            Canvas.SetLeft(_fRec, fLinksOben.X);
            Canvas.SetTop(_fRec, fLinksOben.Y);

            Canvas.SetLeft(_fEll, fLinksOben.X);
            Canvas.SetTop(_fEll, fLinksOben.Y);

            //zum Canvas hinzufügen
            cw.Children.Add(_fRec);
            cw.Children.Add(_fEll);
        }

        public void Skalieren(Point pCenter)
        {
            var st = new ScaleTransform
            {
                CenterX = 100 * pCenter.X,
                CenterY = 50 * pCenter.Y
            };

            var da = new DoubleAnimation
            {
                Duration = TimeSpan.FromSeconds(1),
                From = 1,
                To = 2,
                AutoReverse = true
            };

            st.BeginAnimation(ScaleTransform.ScaleXProperty, da);
            st.BeginAnimation(ScaleTransform.ScaleYProperty, da);

            _fRec.RenderTransform = st;
            _fEll.RenderTransform = st;
        }
    }
}