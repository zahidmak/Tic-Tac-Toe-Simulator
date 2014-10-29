using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
using System.Windows.Threading;

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

        private void Reset_Click(object sender, RoutedEventArgs e)
        {
            TicTacToe.XWins = 0;
            TicTacToe.OWins = 0;
            TicTacToe.Ties = 0;
        }

        private void Simulate_Click(object sender, RoutedEventArgs e)
        {
            TicTacToe.Start();
        }

    }
}
