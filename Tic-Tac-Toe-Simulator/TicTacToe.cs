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
       

        public ObservableCollection<Element> Collection{ set; get; }
       
        public void Start()
        {
            this.Game = new int[3, 3];
            Random Random = new Random();
            for (int i = 0; i < 3; i++)
            {
                for(int j=0; j<3; j++)
                {
                    Game[i, j] = Random.Next(0, 2);
                }
            }
           
        }
        public void ChooseWinner()
        {
            for(int i=0; i<=2; i++)
            {
                for(int j=0;j<=2;j++)
                {
                    if(i==j)
                    {
                        if(this.Game[i,j]==1)
                        {

                        }
                    }
                }
            }
        }
        public TicTacToe()
        {
            Start();
        }

        #region INotifyPropertyChanged Members

        public void NotifyPropertyChanged([CallerMemberName] String propertyName = "")
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
