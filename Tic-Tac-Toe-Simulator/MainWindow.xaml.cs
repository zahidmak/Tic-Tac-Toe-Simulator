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

namespace Tic_Tac_Toe_Simulator
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        TicTacToe TicTacToe = new TicTacToe();
        public MainWindow()
        {
            InitializeComponent();
            MainGrid.DataContext = TicTacToe;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            
        }
    }
}
