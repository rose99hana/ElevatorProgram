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

namespace ElevatorProgram
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            V = new ViewModel();
            DataContext = V;
        }

        ViewModel V { get; set; }

        private void ButtonUp_Click(object sender, RoutedEventArgs e)
        {
            V.ElevatorUp((sender as Button).CommandParameter + "U");
        }

        private void ButtonDown_Click(object sender, RoutedEventArgs e)
        {
            V.ElevatorDown((sender as Button).CommandParameter + "D");
        }
    }
}
