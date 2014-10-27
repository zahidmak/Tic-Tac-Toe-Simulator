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
        public int[,] Game = new int[3, 3];
        private int xWins;
        private int oWins;
        private int ties;
       
        public int XWins { get { return xWins; } set { xWins = value; NotifyPropertyChanged(); } }
        public int OWins { get { return oWins; } set { oWins = value; NotifyPropertyChanged(); } }
        public int Ties { get { return ties; } set { ties = value; NotifyPropertyChanged(); } }
       
        public class Element
        {
            public string Position;
            public int Value;
        }

        public ObservableCollection<Element> Collection{ set; get; }
        public void SyncArrayAndCollection()
        {
            this.Collection = new ObservableCollection<Element>();
            this.Collection.Add(new Element() { Position = "00", Value = Game[0, 0] });
            this.Collection.Add(new Element() { Position = "01", Value = Game[0, 1] });
            this.Collection.Add(new Element() { Position = "02", Value = Game[0, 2] });
            this.Collection.Add(new Element() { Position = "10", Value = Game[1, 0] });
            this.Collection.Add(new Element() { Position = "11", Value = Game[1, 1] });
            this.Collection.Add(new Element() { Position = "12", Value = Game[1, 2] });
            this.Collection.Add(new Element() { Position = "20", Value = Game[2, 0] });
            this.Collection.Add(new Element() { Position = "21", Value = Game[2, 1] });
            this.Collection.Add(new Element() { Position = "22", Value = Game[2, 2] });
            
        }
        public void Start()
        {
            Random Random = new Random();
            for (int i = 0; i < 3; i++)
            {
                for(int j=0; j<3; j++)
                {
                    Game[i, j] = Random.Next(0, 2);
                }
            }
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
