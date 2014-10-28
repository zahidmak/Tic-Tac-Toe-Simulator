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
        private int currentPlayer;
       

        public int XWins { get { return xWins; } set { xWins = value; NotifyPropertyChanged(); } }
        public int OWins { get { return oWins; } set { oWins = value; NotifyPropertyChanged(); } }
        public int Ties { get { return ties; } set { ties = value; NotifyPropertyChanged(); } }
        public int CurrentPlayer { get { return currentPlayer; } set { currentPlayer = value; NotifyPropertyChanged(); } }
   

        public ObservableCollection<Element> Collection { set; get; }

        public void Start()
        {
            this.Game = new int[3, 3];
            Random Random = new Random();
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    Game[i, j] = 2;
                }
            }
            while (IsPlaceLeft())
            {
                if (CurrentPlayer == 1)
                {
                    int x = Random.Next(0, 2);
                    int y = Random.Next(0, 2);
                    if (Game[x, y] == 2)
                    {
                        if(CurrentPlayer==1)
                        {
                            Game[x, y] = 1;
                            CurrentPlayer = 0;
                            if(ChooseWinner())
                            {
                                break;
                            }
                        }
                        else
                        {
                            Game[x, y] = 0;
                            CurrentPlayer = 1;
                            if (ChooseWinner())
                            {
                                break;
                            }
                        }
                      

                    }

                }
            }

        }
        public bool IsPlaceLeft()
        {
            int count = 0;
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    if (Game[i, j] == 2)
                    {
                        count++;
                    }

                }

            }
            return count > 0 ? true : false;

        }
        public bool ChooseWinner()
        {
            //Verticals
            if (Game[0, 0] == Game[1, 0] && Game[1, 0] == Game[2, 0] && Game[2, 0] != 2)
            {
                if (Game[0, 0] == 1)
                {
                    this.XWins = XWins + 1;
                    return true;
                }
                else
                {
                    this.OWins = OWins + 1;
                    return true;
                }
            }
            if (Game[0, 1] == Game[1, 1] && Game[1, 1] == Game[2, 1] && Game[2, 1] != 2)
            {
                if (Game[0, 1] == 1)
                {
                    this.XWins = XWins + 1;
                    return true;
                }
                else
                {
                    this.OWins = OWins + 1;
                    return true;
                }
            }
            if (Game[0, 2] == Game[1, 2] && Game[1, 2] == Game[2, 2] && Game[2, 2] != 2)
            {
                if (Game[0, 2] == 1)
                {
                    this.XWins = XWins + 1;
                    return true;
                }
                else
                {
                    this.OWins = OWins + 1;
                    return true;
                }
            }

            //Horizontals
            if (Game[0, 0] == Game[0, 1] && Game[0, 1] == Game[0, 2] && Game[0, 2] != 2)
            {
                if (Game[0, 0] == 1)
                {
                    this.XWins = XWins + 1;
                    return true;
                }
                else
                {
                    this.OWins = OWins + 1;
                    return true;
                }
            }
            if (Game[1, 0] == Game[1, 1] && Game[1, 1] == Game[1, 2] && Game[1, 2] != 2)
            {
                if (Game[1, 0] == 1)
                {
                    this.XWins = XWins + 1;
                    return true;
                }
                else
                {
                    this.OWins = OWins + 1;
                    return true;
                }
            }
            if (Game[2, 0] == Game[2, 1] && Game[2, 1] == Game[2, 2] && Game[2, 2] != 2)
            {
                if (Game[2, 0] == 1)
                {
                    this.XWins = XWins + 1;
                    return true;
                }
                else
                {
                    this.OWins = OWins + 1;
                    return true;
                }
            }

            //Diagonals
            if (Game[0, 0] == Game[1, 1] && Game[1, 1] == Game[2, 2] && Game[2, 2] != 2)
            {
                if (Game[0, 0] == 1)
                {
                    this.XWins = XWins + 1;
                    return true;
                }
                else
                {
                    this.OWins = OWins + 1;
                    return true;
                }
            }
            if (Game[0, 2] == Game[1, 1] && Game[1, 1] == Game[2, 0] && Game[2, 0] != 2)
            {
                if (Game[0, 2] == 1)
                {
                    this.XWins = XWins + 1;
                    return true;
                }
                else
                {
                    this.OWins = OWins + 1;
                }
            }
            return false;
        }
        public TicTacToe()
        {
            CurrentPlayer = 1;
            

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
