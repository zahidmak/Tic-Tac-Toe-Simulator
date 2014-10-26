using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Tic_Tac_Toe_Simulator
{
    public class TicTacToe : INotifyPropertyChanged
    {
        public ObservableCollection<int> Game = new ObservableCollection<int>();

        public TicTacToe()
        {
            Game.Add(1);
           
        }
      
        #region INotifyPropertyChanged Members

        private void NotifyPropertyChanged([CallerMemberName] String propertyName = "")
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        #endregion
    }
}
