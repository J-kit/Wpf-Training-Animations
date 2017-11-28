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

namespace AnimationTransRot_23_10_17
{
    /// <summary>
    /// Interaktionslogik für MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private CFigur oF;

        public MainWindow()
        {
            InitializeComponent();
            oF = new CFigur(leinwand);
        }

        private void butAnimation_Click(object sender, RoutedEventArgs e)
        {
            oF.Animieren(leinwand);
        }

        private void butAnimation2_Click(object sender, RoutedEventArgs e)
        {
            oF.Animieren2(leinwand);
        }
    }
}