using System;
using System.Windows;

namespace Animation_Skalieren_17_10_17
{
    /// <summary>
    /// Interaktionslogik für MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private CFigur oF;
        private Point _pCenter;

        public MainWindow()
        {
            InitializeComponent();
            oF = new CFigur(leinwand);
            _pCenter = new Point(0.5, 0.5);
        }

        private void cbxZentrum_DropDownClosed(object sender, EventArgs e)
        {
            if (cbxZentrum.SelectedIndex == 0)//cbxZentrum.Text == "Mitte"
            {
                _pCenter = new Point(0.5, 0.5);
            }
            if (cbxZentrum.SelectedIndex == 1)//cbxZentrum.SelectionBoxItem.ToString() == "Links oben"
            {
                _pCenter = new Point(0, 0);
            }
            if (cbxZentrum.SelectedIndex == 2)
            {
                _pCenter = new Point(1, 1);
            }
        }

        private void butStart_Click(object sender, RoutedEventArgs e)
        {
            oF.Skalieren(_pCenter);
        }
    }
}