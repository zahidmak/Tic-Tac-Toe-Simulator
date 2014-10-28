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
        TicTacToe TicTacToe1 = new TicTacToe();
        ObservableCollection<Element> coll = new ObservableCollection<Element>();
        public MainWindow()
        {
            InitializeComponent();
            // MainGrid.DataContext = TicTacToe;
            TicTacToe1.Collection = coll;
            MainGrid.DataContext = TicTacToe1;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {

            TicTacToe1.Start();
            SyncArrayAndCollection();
        }
        public void SyncArrayAndCollection()
        {
            coll.Clear();
            coll.Add(new Element() { Position = "00", Value = TicTacToe1.Game[0, 0] });
            coll.Add(new Element() { Position = "01", Value = TicTacToe1.Game[0, 1] });
            coll.Add(new Element() { Position = "02", Value = TicTacToe1.Game[0, 2] });
            coll.Add(new Element() { Position = "10", Value = TicTacToe1.Game[1, 0] });
            coll.Add(new Element() { Position = "11", Value = TicTacToe1.Game[1, 1] });
            coll.Add(new Element() { Position = "12", Value = TicTacToe1.Game[1, 2] });
            coll.Add(new Element() { Position = "20", Value = TicTacToe1.Game[2, 0] });
            coll.Add(new Element() { Position = "21", Value = TicTacToe1.Game[2, 1] });
            coll.Add(new Element() { Position = "22", Value = TicTacToe1.Game[2, 2] });


        }
    }
}
